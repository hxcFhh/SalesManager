Imports System.Data.OleDb

Public Class frmConAdd
    Dim changeAble As Boolean = False
    Private Sub frmConAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtConID.Enabled = False
        Me.txtConID.Text = "自动"
        Me.txtConInprice.Enabled = False
        Me.txtConSum.Enabled = False
        Me.txtConSum.Text = "0"
        Me.txtConInprice.Text = "0"
        Me.labConCustomerLevel.Text = ""
        '获取客户信息，从access数据库中
        Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn) '和原文中的不同在于不能直接访问modMain中的strConn
        Dim myComm As OleDbCommand = New OleDbCommand
        myComm.Connection = myConn
        myComm.CommandText = "select name from customer"
        Dim myReader As OleDbDataReader
        myConn.Open()
        myReader = myComm.ExecuteReader()
        While myReader.Read
            cbConCustomer.Items.Add(myReader.GetString(0))
        End While
        myConn.Close()

        '获取成品信息
        Dim pmyConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim pmyComm As OleDbCommand = New OleDbCommand
        pmyComm.Connection = pmyConn
        pmyComm.CommandText = "select name from product"
        Dim pmyReader As OleDbDataReader
        pmyConn.Open()
        pmyReader = pmyComm.ExecuteReader
        While pmyReader.Read
            cbStockProname.Items.Add(pmyReader.GetString(0))
        End While
        pmyConn.Close()

        '删除临时库存记录
        Dim tmyConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim tmyComm As OleDbCommand = New OleDbCommand
        tmyComm.Connection = tmyConn
        tmyComm.CommandText = "delete * from stocktemp"
        tmyConn.Open()
        tmyComm.ExecuteNonQuery()
        tmyConn.Close()

        '初始化订单信息
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

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtConInprice.TextChanged
        modMain.checkNum(txtStockPrice)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If changeAble Then
            Dim temp As MsgBoxResult
            temp = MsgBox("输入的信息未保存，要关闭吗？", MsgBoxStyle.YesNo, "提示信息:")
            If temp = MsgBoxResult.No Then
                Exit Sub
            Else
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.cbConType.SelectedIndex = -1
        Me.cbConCustomer.SelectedIndex = -1
        Me.cbConPaytype.SelectedIndex = -1
        Me.cbStockProname.SelectedIndex = -1
        Me.nubStockNumber.Value = 1
        Me.txtStockPrice.Text = ""
        Me.txtConInprice.Text = "0"
        Me.txtConSum.Text = ""
        Me.labConCustomerLevel.Text = ""
        Me.dtpCon.Value = Date.Today
        '删除临时库存记录
        Dim tmyConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim tmyComm As OleDbCommand = New OleDbCommand
        tmyComm.Connection = tmyConn
        tmyComm.CommandText = "delete * frm stocktemp"
        tmyConn.Open()
        tmyComm.ExecuteNonQuery()
        tmyConn.Close()
        '初始化订单信息
        Dim sqlStr As String = "select tindx,proname,tnumber,price from stocktemp"
        Dim conConn As New OleDbConnection(modMain.strConn)
        Dim conComm As New OleDbCommand(sqlStr, conConn)
        Dim myDa As New OleDbDataAdapter
        myDa.SelectCommand = conComm
        Dim myDs As New DataSet
        myDa.Fill(myDs, "stocktemp")
        dgCon.DataSource = myDs.Tables("stocktemp")
        conConn.Close()
    End Sub

    Private Function GetDgCon() As DataGridView
        Return dgCon
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Me.cbConType.SelectedIndex = -1 Then
            MsgBox("合同类型不能为空！", MsgBoxStyle.Information, "提示信息")
            Exit Sub
        End If
        If Me.cbConCustomer.SelectedIndex = -1 Then
            MsgBox("合同对象不能为空！", MsgBoxStyle.Information, "提示信息")
            Exit Sub
        End If
        If Me.cbConPaytype.SelectedIndex = -1 Then
            MsgBox("付款方式不能为空！", MsgBoxStyle.Information, "提示信息")
            Exit Sub
        End If
        If CDbl(Me.txtConSum.Text) = 0 Then
            MsgBox("订单信息不能为空！", MsgBoxStyle.Information, "提示信息")
            Exit Sub
        End If
        '获取合同编号
        Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim myComm As OleDbCommand = New OleDbCommand
        myComm.Connection = myConn
        myComm.CommandText = "select max(id) from contract"
        'Dim myReader As OleDbDataReader
        myConn.Open()
        Dim maxIDTemp As Long
        Dim maxID As Object = myComm.ExecuteScalar()
        If maxID Is System.DBNull.Value Then
            maxIDTemp = 100000001
        Else
            Dim strid As String
            strid = CStr(maxID)
            maxIDTemp = CInt(strid)
            maxIDTemp = maxIDTemp + 1
        End If
        myConn.Close()
        '更新合同表
        Dim saveComm As OleDbCommand = New OleDbCommand
        saveComm.CommandText = "insert into contract(id,ctype,customer,csum,paytype,signdate) values(@id,@ctype,@customer,@csum,@paytype,@signdate)"
        saveComm.Connection = myConn
        saveComm.Parameters.AddWithValue("@id", maxIDTemp)
        saveComm.Parameters.AddWithValue("@ctype", Me.cbConType.SelectedItem)
        saveComm.Parameters.AddWithValue("@customer", Me.cbConCustomer.SelectedItem)
        saveComm.Parameters.AddWithValue("@csum", Me.txtConSum.Text)
        saveComm.Parameters.AddWithValue("@paytype", Me.cbConPaytype.SelectedItem)
        saveComm.Parameters.AddWithValue("@signdate", Me.dtpCon.Text)
        myConn.Open()
        Try
            saveComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Information)
        End Try
        myConn.Close()
        '更新库存表
        Dim tProname As String
        Dim tNumber As Long
        Dim tPrice As Double
        Dim i As Integer
        Dim g As Integer
        Dim stockTempComm As OleDbCommand = New OleDbCommand
        stockTempComm.Connection = myConn
        stockTempComm.CommandText = "select count(tindex) from stocktemp"
        myConn.Open()
        Dim count As Object = stockTempComm.ExecuteScalar()
        g = CInt(count)
        myConn.Close()
        Dim stockComm As OleDbCommand = New OleDbCommand
        stockComm.Connection = myConn
        stockComm.CommandText = "insert into stock(contract,stype,proname,snumber,price) values(@contract,@stype,@proname,@snumber,@price)"
        myConn.Open()

        For i = 0 To g - 1
            '修改过的地方，和书上不同
            tProname = dgCon.Item(i, 1).ToString
            tNumber = CLng(dgCon.Item(i, 2).ToString)
            tPrice = CSng(dgCon.Item(i, 3).ToString)
            stockComm.Parameters.AddWithValue("@contract", maxIDTemp)
            stockComm.Parameters.AddWithValue("@stype", Me.cbConType.SelectedItem)
            stockComm.Parameters.AddWithValue("@proname", tProname)
            stockComm.Parameters.AddWithValue("@snumber", tNumber)
            stockComm.Parameters.AddWithValue("@price", tPrice)
            Try
                stockComm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description)
            End Try
            stockComm.Parameters.Clear()
        Next

        myConn.Close()
        MsgBox("合同添加成功，合同号为：" & maxIDTemp, MsgBoxStyle.Information, "提示信息")
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.cbStockProname.SelectedIndex = -1 Then
            MsgBox("产品名称不能为空！", MsgBoxStyle.Information, "提示信息")
            Exit Sub
        End If
        If Me.txtStockPrice.Text = "" Then
            MsgBox("产品单价不能为空！", MsgBoxStyle.Information, "提示信息")
            Exit Sub
        End If
        changeAble = True
        modMain.stockTemp = modMain.stockTemp + 1
        Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn)
        Dim myComm As OleDbCommand = New OleDbCommand
        myComm.Connection = myConn
        myComm.CommandText = "insert into stocktemp (tindex,proname,tnumber,price) values(@tindex,@proname,@tnumber,@price)"
        myComm.Parameters.AddWithValue("@tindex"， modMain.stockTemp)
        myComm.Parameters.AddWithValue("@proname"， Me.cbStockProname.SelectedItem)
        myComm.Parameters.AddWithValue("@tnumber"， CLng(nubStockNumber.Value))
        myComm.Parameters.AddWithValue("@price"， CStr(txtStockPrice.Text))
        myConn.Open()
        Try
            myComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("产品重复添加，请查看您输入的信息！", MsgBoxStyle.Information, "提示信息")
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
        tConn.Close()
        '更新订单信息
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.cbConCustomer.SelectedIndex = -1 Then
            Exit Sub
        End If
        Try
            Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn)
            Dim myComm As OleDbCommand = New OleDbCommand
            myComm.Connection = myConn
            myComm.CommandText = "select id,address,phone,banknumber from customer where name = @name"
            myComm.Parameters.AddWithValue("@name", Me.cbConCustomer.SelectedItem)
            Dim myReader As OleDbDataReader
            myConn.Open()
            Dim tID As Long = 0
            Dim tPhone As String = ""
            Dim tAddress As String = ""
            ' 有个黄波，错误改这里
            Dim tBankNumber As Object = New Object
            myReader = myComm.ExecuteReader
            While myReader.Read
                tID = myReader.GetInt32(0)
                tAddress = myReader.GetString(1)
                tPhone = myReader.GetString(2)
                tBankNumber = myReader.GetString(3)
            End While
            myConn.Close()
            MsgBox("客户编号：" & tID & Chr(10) & "客户姓名：" & Me.cbConCustomer.SelectedItem & Chr(10) & "客户电话：" & tPhone & Chr(10) & "客户地址：" & tAddress & Chr(10) &
                   "银行账号：" & tBankNumber & Chr(10), MsgBoxStyle.Information, "提示信息")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cbConCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConCustomer.SelectedIndexChanged
        If Me.cbConCustomer.SelectedIndex = -1 Then
            Exit Sub
        End If
        changeAble = True

        Try
            Dim myConn As OleDbConnection = New OleDbConnection(modMain.strConn)
            Dim myComm As OleDbCommand = New OleDbCommand
            myComm.Connection = myConn
            myComm.CommandText = "select clever from customer where name = @name"
            Dim myReader As OleDbDataReader
            myConn.Open()
            myComm.Parameters.AddWithValue("@name", cbConCustomer.SelectedItem)
            myReader = myComm.ExecuteReader
            While myReader.Read
                Me.labConCustomerLevel.Text = myReader.GetString(0)
            End While
            myConn.Close()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
        If Me.labConCustomerLevel.Text = "★☆☆☆" Then
            Me.txtConInprice.Text = "0.05"
        End If
        If Me.labConCustomerLevel.Text = "★★☆☆" Then
            Me.txtConInprice.Text = "0.1"
        End If
        If Me.labConCustomerLevel.Text = "★★★☆" Then
            Me.txtConInprice.Text = "0.15"
        End If
        If Me.labConCustomerLevel.Text = "★★★★" Then
            Me.txtConInprice.Text = "0.2"
        End If

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
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' 删除按钮 这里有框架问题，暂时这么写
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

    Private Sub cbConType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConType.SelectedIndexChanged
        changeAble = True
    End Sub

    Private Sub cbConPaytype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConPaytype.SelectedIndexChanged
        changeAble = True
    End Sub

    Private Sub nubStockNumber_ValueChanged(sender As Object, e As EventArgs) Handles nubStockNumber.ValueChanged
        If nubStockNumber.Value > 100000 Then
            MsgBox("超出数量限定!", MsgBoxStyle.Information, "提示信息")
            nubStockNumber.Value = 100000
        Else
            If nubStockNumber.Value < 1 Then
                MsgBox("低于限定数量!", MsgBoxStyle.Information, "提示信息")
                nubStockNumber.Value = 1
            End If
        End If
    End Sub
End Class