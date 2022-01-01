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
            Me.txtStockPrice.Text = "0.05"
        ElseIf Me.labConCustomerLevel.Text = "◆◆◇◇" Then
            Me.txtStockPrice.Text = "0.1"
        ElseIf Me.labConCustomerLevel.Text = "◆◆◆◇" Then
            Me.txtStockPrice.Text = "0.15"
        ElseIf Me.labConCustomerLevel.Text = "◆◆◆◆" Then
            Me.txtStockPrice.Text = "0.2"
        End If
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
        stockTempComm.CommandText = "select count(proname) from stock where contract = " & "'" & Me.cbConID.SelectedItem & "'"
        myConn.Open()
        Dim count As Object = stockTempComm.ExecuteScalar
        g = CInt(count)
        myConn.Close()
        Dim stockComm As OleDbCommand = New OleDbCommand
        stockComm.Connection = myConn
        stockComm.CommandText = "insert into stocktemp(tindex,proname,tnumber,price) values(@tindex,
@proname,@tnumber,@price)"
        myConn.Open()
        For i = 0 To g - 1
            modMain.stockTemp = modMain.stockTemp + 1
            tProname = CStr(dgCon.Item(i, 0).ToString)
            tNumber = CLng(dgCon.Item(i, 1).ToString)
            tPrice = CSng(dgCon.Item(i, 2).ToString)
            stockTempComm.Parameters.AddWithValue("@tindex", modMain.stockTemp)
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
        Me.txtStockPrice.Enabled = False
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

    Private Sub txtConInprice_TextChanged(sender As Object, e As EventArgs) Handles txtStockPrice.TextChanged
        If Me.cbStockProname.SelectedIndex = -1 Then
            MsgBox("产品名称不能为空!", MsgBoxStyle.Information, "提示信息")
            Exit Sub
        End If
        If Me.txtStockPrice.Text = "" Then
            MsgBox("单价不能为空！", MsgBoxStyle.Information, "提示信息")
            Exit Sub
        End If
        modMain.stockTemp = modMain.stockTemp + 1
        Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim myComm As OleDbCommand
        myComm.Connection = myConn
        myComm.CommandText = "insert into stocktemp(tindex,proname,tnumber,price) values(@tindex,
@proname,@tnumber,@price)"
        myComm.Parameters.AddWithValue("@tindex", modMain.stockTemp)
        myComm.Parameters.AddWithValue("@proname", cbStockProname.Text)
        myComm.Parameters.AddWithValue("@tnumber", CLng(nubStockNumber.Value))
        myComm.Parameters.AddWithValue("@tnumber", CSng(txtStockPrice.Text))
        myConn.Open()
        Try
            myComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("产品添加重复，请查看您输入的信息！", MsgBoxStyle.Information, "提示信息")
        End Try

        myConn.Close()
        ' 计算交易金额
        Dim tNumber As Long
        Dim tPrice As Single
        Dim tSum As Double = 0
        Dim tConn As New OleDbConnection(modMain.strConn)
        Dim tComm As New OleDbCommand
        tComm.Connection = tConn
        tComm.CommandText = "select tnumber,price from stocktemp"
        Dim tReader As OleDbDataReader
        tConn.Open()
        tReader = tComm.ExecuteReader
        While tReader.Read
            tNumber = tReader.GetInt32(0)
            tPrice = tReader.GetFloat(1)
            tSum = tSum + tNumber * tPrice
        End While
        Dim tDou As Double = (1 - CSng(txtConInprice.Text)) * tSum
        txtConSum.Text = Format(tDou, "0.00")

        ' 更新订单信息
        Dim sqlStr As String = "select tindex, proname, tnumber, price, from stocktemp"
        Dim conConn As New OleDbConnection(modMain.strConn)
        Dim ConComm As New OleDbCommand(sqlStr, conConn)
        Dim myDa As New OleDbDataAdapter
        myDa.SelectCommand = ConComm
        Dim myDs As New DataSet
        myDa.Fill(myDs, "stocktemp")
        dgCon.DataSource = myDs.Tables("stocktemp")
        conConn.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If dgCon.CurrentRow.Index = -1 Then
            Exit Sub
        End If
        Dim tMsg As MsgBoxResult
        Dim numTemp As Integer
        numTemp = dgCon.CurrentRow.Index
        Dim numTemp2 As Integer
        numTemp2 = CInt(dgCon.Item(numTemp, 0).ToString)
        tMsg = MsgBox("确定要删除索引号为<" & numTemp2 & ">的订单记录?", MsgBoxStyle.YesNo, "提示信息")
        If tMsg = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim myComm As OleDbCommand = New OleDbCommand
        myComm.Connection = myConn
        myComm.CommandText = "delete from stocktemp where tindex = @tindex"
        myComm.Parameters.AddWithValue("@tindex", numTemp2)
        myConn.Open()
        myComm.ExecuteNonQuery()
        myConn.Close()

        ' 计算交易金额
        Dim tNumber As Long
        Dim tPrice As Single
        Dim tSum As Double = 0
        Dim tConn As New OleDbConnection(modMain.strConn)
        Dim tComm As New OleDbCommand
        tComm.Connection = tConn
        tComm.CommandText = "select tnumber,price from stocktemp"
        Dim tReader As OleDbDataReader
        tConn.Open()
        tReader = tComm.ExecuteReader
        While tReader.Read
            tNumber = tReader.GetInt32(0)
            tPrice = tReader.GetFloat(1)
            tSum = tSum + tNumber * tPrice
        End While

        Dim tDou As Double = (1 - CSng(txtConInprice.Text)) * tSum
        txtConSum.Text = Format(tDou, "0.00")
        tConn.Close()

        ' 更新订单信息
        Dim sqlStr As String = "select tindex,proname,tnumber,price from stocktemp"
        Dim conConn As New OleDbConnection(modMain.strConn)
        Dim conComm As New OleDbCommand(sqlStr, conConn)
        Dim myDa As New OleDbDataAdapter
        myDa.SelectCommand = conComm
        Dim myDs As New DataSet
        myDa.Fill(myDs, "stocktemp")
        dgCon.DataSource = myDs.Tables("stocktemp")
        conConn.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If CDbl(Me.txtConSum.Text) = 0 Then
            MsgBox("订单信息不能为空！", MsgBoxStyle.Information, "提示信息")
            Exit Sub
        End If
        '删除原有合同
        Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim myComm As OleDbCommand
        myComm.Connection = myConn
        myComm.CommandText = "delete from stock where contract = " & "'" & Me.cbConID.SelectedItem & "'"
        myConn.Open()
        myComm.ExecuteNonQuery()
        myConn.Close()

        ' 更新合同表
        Dim saveComm As OleDbCommand = New OleDbCommand
        saveComm.CommandText = "update contract set ctype = @ctype,customer = @customer,csum = @csum,
        paytype=@paytype,signdate=@signdate,where id = " & Me.cbConID.SelectedItem
        saveComm.Connection = myConn
    End Sub
End Class