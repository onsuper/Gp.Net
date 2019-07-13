Public Class ULog
    Const LogFile As String = "GPApi"
    Delegate Sub DLog(logFile As String, msg As String)
    Shared Log As DLog = New DLog(AddressOf LogManager.WriteLog)
    ''' <summary>
    ''' 写入日志
    ''' </summary>
    ''' <param name="msg"></param>
    Public Shared Sub WriteLog(msg As String, Optional File As String = LogFile)

        '获取父方法

        Dim ss As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace(True)
        Dim mb As System.Reflection.MethodBase = ss.GetFrame(1).GetMethod()
        Dim str As String = "Method = "
        'str += mb.DeclaringType.[Namespace] & "." & vbLf
        'str += mb.DeclaringType.Name & "." & vbLf
        str += mb.DeclaringType.FullName & "."
        str += mb.Name & vbCrLf

        ''异步写入日志
        'Log.BeginInvoke(LogFile, str & msg & vbCrLf, Nothing, Nothing)
        LogManager.WriteLog(File, str & msg & vbCrLf)
    End Sub

End Class
