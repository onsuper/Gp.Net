Imports GPModels

Public Module modPublic
    Public Declare Function apiInit Lib "bin/GuoPAPI.dll" (ByVal shopid As String, apikey As String, handle As Integer, extention As String) As Integer
    Public Declare Function apiCall Lib "bin/GuoPAPI.dll" (ByVal msgid As Integer) As Integer

    ''' <summary>
    ''' 检查 防止重复的处理
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns></returns>
    Public Function KeyCheck(key As String) As Boolean
        Return True
    End Function

    ''' <summary>
    ''' 回复数据
    ''' </summary>
    ''' <param name="number"></param>
    ''' <param name="state"></param>
    ''' <param name="info"></param>
    Public Sub Tjson(number As Long, state As Long, Optional info As String = "onsuper success")
        Dim T As New TBase With {.status = state, .info = info}
        '回复数据
        Dim FileT As String = $"bin\T{number}.json"
        IO.File.WriteAllText(FileT, JsonFromObj(T))
        apiCall(number)
    End Sub

    Public Function WriteTXT(File As String, number As Long, result As Object) As Integer
        Dim FileT As String = $"bin\{File}{number}.json"
        IO.File.WriteAllText(FileT, JsonFromObj(result))
        Return apiCall(number)
    End Function

    Public Function TapiCall(Of T)(number As Long, action As Object) As T
        ULog.WriteLog("请求参数 :" & JsonFromObj(action))
        Dim i = WriteTXT("R", number, action)
        '读取相应文件
        Dim txt = IO.File.ReadAllText($"bin\T{number}.json")

        Dim result = JsonToObject(Of T)(txt)
        ULog.WriteLog("请求结果 :" & JsonFromObj(result))

        Return result
    End Function



    Function actionT(Of T)(act As String, [get] As Dictionary(Of String, String), Optional post As T = Nothing)
        Dim action = New R(Of T) With
            {
                .action = New Action With {.action = act}，
                .[get] = [get],
                .post = post
            }
        Return action
    End Function

End Module
