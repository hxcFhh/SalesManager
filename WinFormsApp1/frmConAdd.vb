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

    Private Sub Button4_Click(sender As Object, e As EventArgs, dgCon As DataGridView) Handles Button4.Click
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
        Dim myReader As OleDbDataReader
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
End Class