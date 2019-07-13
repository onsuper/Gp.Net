Imports GPModels
Imports GPModels.Base

Public Class Menu
    ''' <summary>
    ''' 上传菜品资料
    ''' </summary>
    ''' <returns></returns>
    Shared Function Upload()

        Dim m = New Type() {
        New Type With {
                        .cateid = 1001,
                        .catename = "冷菜",
                        .catestate = 1,
                        .dishes = {New Dish With
                            {
                                .gdsname = "凉拌木耳",
                                .gdsprice = "0.01",
                                .gdsid = "10001",
                                .gdsstate = 1
                            }，
                            New Dish With
                            {
                                .gdsname = "花生米",
                                .gdsprice = "0.01",
                                .gdsid = "10002",
                                .gdsstate = 1
                            }
                        }
                    },
        New Type With {
                    .cateid = 2001,
                    .catename = "热菜",
                    .catestate = 1,
                    .dishes =
                    {New Dish With
                        {
                            .gdsname = "剁椒鱼头",
                            .gdsprice = "0.01",
                            .gdsid = "20001",
                                .gdsstate = 1
                        }，
                        New Dish With
                        {
                            .gdsname = "辣椒炒肉",
                            .gdsprice = "0.01",
                            .gdsid = "20002",
                                .gdsstate = 1
                        }
                    }
                }}

        '写R1.json
        Dim action = New R(Of Menus) With
            {
                .action = New Action With {.action = "do_post_dishes"}，
                .[get] = New Dictionary(Of String, String) From
                    {
                        {"replace", "1"}
                    },
                .post = New Menus With
                        {
                            .dish = m
                        }
            }

        Dim result = TapiCall(Of TCount)("1", action)
        Console.WriteLine(JsonFromObj(result))
    End Function

    ''' <summary>
    ''' 菜品沽清
    ''' </summary>
    ''' <returns></returns>
    Shared Function sellout(id As String)
        '写R1.json
        Dim d = Now.AddHours(4)
        Dim action = New R(Of Object) With
            {
                .action = New Action With {.action = "do_sellout"}，
                .[get] = New Dictionary(Of String, String) From
                    {
                        {"gdsid", id},
                         {"enddate", Format(d, "yyyyMMdd")},
                        {"endtime", Format(d, "HHmm")}
                    }
            }

        Dim result = TapiCall(Of TBase)("1", action)
        Console.WriteLine(JsonFromObj(result))
    End Function

    ''' <summary>
    ''' 上传图片
    ''' </summary>
    ''' <returns></returns>
    Shared Function UpImage(id As String, file As String)
        '写R1.json
        Dim action = New R(Of Dictionary(Of String, String)) With
            {
                .action = New Action With {.action = "do_upload_pic"}，
                .[get] = New Dictionary(Of String, String) From
                    {
                        {"gdsid", id}
                    },
                .post = New Dictionary(Of String, String) From
                    {
                        {"file", file}
                    }
            }

        Dim result = TapiCall(Of TImage)("1", action)
        Console.WriteLine(JsonFromObj(result))
    End Function
End Class
