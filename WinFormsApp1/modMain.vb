Imports System.IO
Public Class modMain
    Public strConn As String
    Public stockTemp As String
    Public Sub GetConn()
        '从配置文件中得到连接字符串连接数据库
        Dim strFileName As String = "mag.ini"
        Dim objReader As StreamReader = New StreamReader(strFileName)
        strConn = objReader.ReadToEnd()
        ' 关闭句柄
        objReader.Close()
        ' CG回收
        objReader = Nothing
    End Sub
    Public Sub checkNum(ByVal txtTemp As TextBox)
        Dim tText As String = txtTemp.Text
        If tText = "" Then
            Exit Sub
        End If
        Dim tNum As Double
        Try
            tNum = CDbl(tText)
        Catch ex As Exception
            MsgBox("请检查是否输入了其他字符！", MsgBoxStyle.Information, "提示信息")

        End Try
    End Sub
    Private Sub modMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
