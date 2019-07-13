Imports System.Windows.Forms
Imports GPModels

Public Class API
    Inherits Form

    Private _shopid As String
    Private _key As String
    Private frm As Form

    Public Enum doState
        confirm = 1
        cancel = 0

    End Enum


    ''' <summary>
    ''' 订单委托
    ''' </summary>
    ''' <param name="order">订单数据</param>
    ''' <param name="doState">订单的后续操作</param>
    Public Delegate Sub doOrderEventHandler(ByVal order As GPModels.Order.Order, ByRef doState As doState)

    ''' <summary>
    ''' 接收订单事件处理
    ''' </summary>
    Public Event DoOrder As doOrderEventHandler

    Sub New(shopid As String, key As String, Optional ex As String = "")
        _shopid = shopid
        _key = key
        Dim result = apiInit(shopid, key, Me.Handle, ex)
        If result <> 1 Then
            MsgBox("启动点单系统失败10001，请联系管理员", MsgBoxStyle.Critical)

            Application.ExitThread()
            Application.Exit()
        End If
    End Sub

    Public Const WM_GPAPI_PUB As Integer = 2907
    Protected Overrides Sub DefWndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_GPAPI_PUB
                m.Result = MsgAPI(m.LParam)
            Case Else
                MyBase.DefWndProc(m)
        End Select
    End Sub


    ''' <summary>
    ''' 处理消息
    ''' </summary>
    ''' <param name="number"></param>
    Function MsgAPI(number As Long) As Long
        If number = 0 Then Exit Function
        '收到的数据
        Dim FileR As String = $"bin\Tx{number}.json"
        Dim txt = IO.File.ReadAllText(FileR)
        Dim msg = JsonToObject(Of Tx(Of Object))(txt)
        If KeyCheck(msg.key) = False Then
        End If

        '先检查是否已经处理过的订单数据
        Select Case msg.type
            Case "do-new" '未确认的新订单, 数据对应协议1.4(MQTT中暂时不劫持do-New, 待后续更新优化后更新支持)"
            Case "do-order" ':已确认的新订单， 数据对应协议1.1

                Dim data = JsonToObject(Of Tx(Of GPModels.Order.Order))(txt)
                Dim doState As doState
                RaiseEvent DoOrder(data.data, doState)

                '处理订单的后续过程
                Select Case doState
                    Case doState.confirm
                        Order.confirm(data.data)
                    Case doState.cancel
                        Order.cancel(data.data)
                End Select
                Return 666

            Case "cash-request"' 桌台拉账单请求, 数据对应协议2.1中state=0
            Case "cash-pay"': 线上支付完成通知， 数据对应协议2.1中state=2, 3
            Case "bk-new"': 新预订订单, 数据对应协议7.3
            Case "do-state"':订单状态变化， 主要用于外卖订单状态变化时通知线下
            Case "order-sync"': 订单同步， 主要用于通需要线下同步当前桌台账单 对应 2.15 同步桌台账单
            Case "data-dish"': 基础数据-菜品同步， 主要用于通知线下主动同步当前门店菜品 对应 3.1 上传基础菜品信息
            Case "data-table" ': 基础数据-桌台同步， 主要用于通知线下主动同步当前桌台列表 对应 3.3 桌台列表上传
        End Select


    End Function
End Class
