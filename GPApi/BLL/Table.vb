Imports GPModels
Imports GPModels.Base

Public Class Table
    Shared Function Upload()
        Dim t = New Tab() {
            New Tab With {
                    .code = "001",
                    .uid = "001"
                    },
                New Tab With {
                    .code = "002",
                    .uid = "002"
                    }
                }


        '写R1.json
        Dim action = New R(Of Tables) With
            {
                .action = New Action With {.action = "do_init_tables"}，
                .[get] = New Dictionary(Of String, String) From
                    {
                        {"replace", "1"}
                    },
                .post = New Tables With
                        {
                             .tables = t
                        }
            }

        Dim result = TapiCall(Of TBase)("1", action)
        Console.WriteLine(JsonFromObj(result))
    End Function
End Class
