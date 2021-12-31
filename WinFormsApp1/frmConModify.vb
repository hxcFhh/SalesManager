Imports System.Data.OleDb

Public Class frmConModify



    Private Sub cbConCustomer_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Me.cbConCustomer.SelectedIndex = -1 Then
            Exit Sub
        End If
        Try
            Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn)
            Dim myComm As OleDbCommand = New OleDbCommand
            myComm.Connection = myConn
            myComm.CommandText = "select clevel from customer where name = @name"
            Dim myReader As OleDbDataReader
            myConn.Open()
            myComm.Parameters.AddWithValue("@name", cbConCustomer.SelectedItem)
            myReader = myComm.ExecuteReader()
            While myReader.Read
                Me.labConCustomerLevel.Text = myReader.GetString(0)

            End While
            myConn.Close()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
        If Me.labConCustomerLevel.Text = "◆◇◇◇" Then
            Me.txtConInprice.Text = "0.05"
        ElseIf Me.labConCustomerLevel.Text = "◆◆◇◇" Then
            Me.txtConInprice.Text = "0.1"
        ElseIf Me.labConCustomerLevel.Text = "◆◆◆◇" Then
            Me.txtConInprice.Text = "0.15"
        ElseIf Me.labConCustomerLevel.Text = "◆◆◆◆" Then
            Me.txtConInprice.Text = "0.2"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        If Me.cbConCustomer.SelectedIndex = -1 Then
            Exit Sub
        End If
        Try
            Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn)
            Dim myComm As OleDbCommand = New OleDbCommand
            myComm.Connection = myConn
            myComm.CommandText = "select id ,address,phone,banknumber from customer where name = @name"
            myComm.Parameters.AddWithValue("@name", Me.cbConCustomer.SelectedItem)
            Dim myReader As OleDbDataReader
            myConn.Open()
            Dim tID As Long
            Dim tPhone As String
            Dim tAddress As String
            Dim tBankNumber As Object
            myReader = myComm.ExecuteReader()
            While myReader.Read
                tID = myReader.GetInt32(0)
                tAddress = myReader.GetString(1)
                tPhone = myReader.GetString(2)
                tBankNumber = myReader.GetString(3)
            End While
            myConn.Close()
            MsgBox("客户编号：" & tID & Chr(10) & "客户姓名：" & Me.cbConCustomer.SelectedItem & Chr(10) & "客户电话：" & tPhone & Chr(10) & "客户地址：" & tAddress & Chr(10) & "银行账号：" & tBankNumber, MsgBoxStyle.Information, "提示信息")

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub nubStockNumber_ValueChanged(sender As Object, e As EventArgs)
        If nubStockNumber.Value > 100000 Then
            MsgBox("超出数量限定！", MsgBoxStyle.Information, "提示信息")
            nubStockNumber.Value = 100000
        Else
            If nubStockNumber.Value < 1 Then
                MsgBox("低于数量限定！", MsgBoxStyle.Information, "提示信息")
                nubStockNumber.Value = 1
            End If
        End If
    End Sub

    Private Sub cbConID_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cbConID.SelectedIndex = -1 Then
            Exit Sub
        End If
        '删除临时库存记录
        Dim tmyConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim tmyComm As OleDbCommand = New OleDbCommand
        tmyComm.Connection = tmyConn
        tmyComm.CommandText = "delete * from stocktemp"
        tmyConn.Open()
        tmyComm.ExecuteNonQuery()
        tmyConn.Close()
        Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim myComm As OleDbCommand = New OleDbCommand
        myComm.Connection = myConn
        myComm.CommandText = "select * from contract where id = " & cbConID.SelectedItem
        Dim myReader As OleDbDataReader
        myConn.Open()
        myReader = tmyComm.ExecuteReader()
        While myReader.Read
            cbConType.SelectedItem = myReader.GetString(1)
            cbConCustomer.SelectedItem = myReader.GetString(2)
            txtConSum.Text = myReader.GetDouble(3)
            cbConPaytype.SelectedItem = myReader.GetString(4)
            dtpCon.Text = myReader.GetDateTime(6)
        End While
        myConn.Close()
        '订单信息
        Dim sqlStr As String = "select proname ,snumber ,price from stock where contract = " & "`" & Me.cbConID.SelectedItem & "`"
        Dim conConn As New OleDbConnection(modMain.strConn)
        Dim conComm As New OleDbCommand(sqlStr, conConn)
        Dim myDa As New OleDbDataAdapter
        myDa.SelectCommand = conComm
        Dim myDs As New DataSet
        myDa.Fill(myDs.Tables("stock"))
        conConn.Close()
        '将订单信息加入临时库存
        Dim tProname As String
        Dim tNumber As Long
        Dim tPrice As Double
        Dim i As Integer
        Dim g As Integer
        Dim stockTempComm As OleDbCommand = New OleDbCommand
        stockTempComm.Connection = myConn
        stockTempComm.CommandText = "insert into stocktemp(tindex , proname , tnumber , price ) values (@tindex,@proname,@tnumber,@price)"
        myConn.Open()
        For i = 0 To g - 1
            ' stockTemp = stockTempComm + 1
            tProname = CStr(dgCon.Item(i, 0).ToString)
            tNumber = CLng(dgCon.Item(i, 1).ToString)
            tPrice = CSng(dgCon.Item(i, 2).ToString)
            'stockTempComm.Parameters.AddWithValue("@tindex", stockTemp)
            stockTempComm.Parameters.AddWithValue("@proname", tProname)
            stockTempComm.Parameters.AddWithValue("@tnumber", tNumber)
            stockTempComm.Parameters.AddWithValue("@price", tPrice)
            Try
                stockTempComm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description)
            End Try
            stockTempComm.Parameters.Clear()
        Next
        myConn.Close()
    End Sub

    Private Sub frmConModify_Load(sender As Object, e As EventArgs)
        '删除临时库存记录
        Dim tmyConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim tmyComm As OleDbCommand = New OleDbCommand
        tmyComm.Connection = tmyConn
        tmyComm.CommandText = "delete * from stocktemp"
        tmyConn.Open()
        tmyComm.ExecuteNonQuery()
        tmyConn.Close()
        Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim myuComm As OleDbCommand = New OleDbCommand
        tmyComm.Connection = myConn
        tmyComm.CommandText = "select id from contract where factor = false"
        Dim myReader As OleDbDataReader
        myConn.Open()
        myReader = tmyComm.ExecuteReader()
        While myReader.Read
            cbConID.Items.Add(myReader.GetInt32(0))
        End While
        myConn.Close()
        Me.txtConSum.Enabled = False
        Me.labConCustomerLevel.Text = ""
        Me.txtConInprice.Enabled = False
        '获取客户信息
        Dim cmyComm As OleDbCommand = New OleDbCommand
        cmyComm.Connection = myConn
        cmyComm.CommandText = "Select Name from customer"
        Dim cmyReader As OleDbDataReader
        myConn.Open()
        cmyReader = cmyComm.ExecuteReader()
        While cmyReader.Read
            cbConCustomer.Items.Add(cmyReader.GetString(0))
        End While
        myConn.Close()
        '获取成品名称
        Dim pmyConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim pmyComm As OleDbCommand = New OleDbCommand
        pmyComm.Connection = pmyConn
        pmyComm.CommandText = "select name from product"
        Dim pmyReader As OleDbDataReader
        pmyConn.Open()
        pmyReader = pmyComm.ExecuteReader()
        While pmyReader.Read
            cbStockProname.Items.Add(pmyReader.GetString(0))
        End While
        pmyConn.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class