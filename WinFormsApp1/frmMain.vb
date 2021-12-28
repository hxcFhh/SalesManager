Public Class frmMain
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripLabel6_Click(sender As Object, e As EventArgs) Handles ToolStripLabel6.Click
        ' 关于
        Dim myAbout As New frmAbout
        myAbout.ShowDialog()
    End Sub

    Private Sub ToolStripLabel5_Click(sender As Object, e As EventArgs) Handles ToolStripLabel5.Click
        '帮助
        Help.ShowHelpIndex(Me, "help.chm")
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub 欢迎界面ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 欢迎界面ToolStripMenuItem.Click

    End Sub

    Private Sub 合同统计ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 合同统计ToolStripMenuItem.Click
        Dim myConSum As New frmConSum
        myConSum.ShowDialog()
    End Sub

    Private Sub 系统设置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 系统设置ToolStripMenuItem.Click
        Dim mySetting As New frmSetting
        mySetting.ShowDialog()
    End Sub

    Private Sub 系统信息ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 系统信息ToolStripMenuItem.Click
        Shell("C:\Program Files\Common Files\Microsoft Shared\MSInfo\msinfo32.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub 帮助ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 帮助ToolStripMenuItem.Click
        Help.ShowHelpIndex(Me, "help.chm")
    End Sub

    Private Sub 关于ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关于ToolStripMenuItem.Click
        Dim myAbout As New frmAbout
        myAbout.ShowDialog()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
    End Sub

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click
        ' 合同统计
        Dim myConSum As New frmConSum
        myConSum.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ' 合同统计
        Dim myConSum As New frmConSum
        myConSum.ShowDialog()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        ' 系统设置
        Dim mySetting As New frmSetting
        mySetting.ShowDialog()
    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        ' 系统设置
        Dim mySetting As New frmSetting
        mySetting.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ' 系统信息
        Shell("C:\Program Files\Common Files\Microsoft Shared\MSInfo\msinfo32.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub ToolStripLabel4_Click(sender As Object, e As EventArgs) Handles ToolStripLabel4.Click
        ' 系统信息
        Shell("C:\Program Files\Common Files\Microsoft Shared\MSInfo\msinfo32.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub ToolStripButton5_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        '帮助
        Help.ShowHelpIndex(Me, "help.chm")
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        ' 关于
        Dim myAbout As New frmAbout
        myAbout.ShowDialog()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Close()
    End Sub
    Private Sub ToolStripLabel7_Click(sender As Object, e As EventArgs) Handles ToolStripLabel7.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' 这里有问题还没有解决，到时候再看这里
        Label4.Text = Now
    End Sub
End Class