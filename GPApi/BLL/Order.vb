Imports GPModels

Public Class Order
    ''' <summary>
    ''' 确认订单内容
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Shared Function confirm(data As GPModels.Order.Order)
        '写R1.json   
        Dim action = New R(Of Object) With
            {
                .action = New Action With {.action = "do_confirm"}，
                .[get] = New Dictionary(Of String, String) From
                    {
                        {"id", data.id},
                         {"state", "2"}
                    }
            }

        Dim result = TapiCall(Of TBase)("1", action)
        Console.WriteLine(JsonFromObj(result))
    End Function

    ''' <summary>
    ''' 取消订单
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Shared Function cancel(data As GPModels.Order.Order)
        '写R1.json   
        Dim action = actionT(Of Object)("do_cancel",
                                    New Dictionary(Of String, String) From
                                    {
                                        {"id", data.id}
                                    })

        Dim result = TapiCall(Of TBase)("1", action)
        Console.WriteLine(JsonFromObj(result))
    End Function
End Class
