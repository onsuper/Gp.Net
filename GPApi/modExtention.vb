Imports Newtonsoft.Json

''' <summary>
''' 扩展方法
''' </summary>
Public Module modExtention
    Public Function JsonFromObj(ByVal obj As Object, Optional cls As Boolean = True) As String
        '过滤JSON-NULL
        Dim JSet As New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore}

        If cls = True Then
            Return JsonConvert.SerializeObject(obj, Formatting.Indented, JSet)
        Else
            Dim objName As String = obj.GetType.FullName & vbCrLf
            Return " : " & objName & JsonConvert.SerializeObject(obj, Formatting.Indented, JSet)
        End If

    End Function

    Public Function JsonToObject(Of T)(json As String) As T
        Return JsonConvert.DeserializeObject(Of T)(json)
    End Function
End Module

