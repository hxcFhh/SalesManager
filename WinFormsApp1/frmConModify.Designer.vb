<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConModify
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent(components As System.ComponentModel.IContainer)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.labConCustomerLevel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbConType = New System.Windows.Forms.ComboBox()
        Me.cbConCustomer = New System.Windows.Forms.ComboBox()
        Me.cbConPaytype = New System.Windows.Forms.ComboBox()
        Me.cbConID = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtpCon = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgCon = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.cbStockProname = New System.Windows.Forms.ComboBox()
        Me.nubStockNumber = New System.Windows.Forms.NumericUpDown()
        Me.txtConInprice = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtConSum = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgCon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nubStockNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(233, 497)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpCon)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cbConID)
        Me.GroupBox1.Controls.Add(Me.cbConPaytype)
        Me.GroupBox1.Controls.Add(Me.cbConCustomer)
        Me.GroupBox1.Controls.Add(Me.cbConType)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.labConCustomerLevel)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(239, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(620, 246)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "基本信息修改"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtConSum)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.txtConInprice)
        Me.GroupBox2.Controls.Add(Me.nubStockNumber)
        Me.GroupBox2.Controls.Add(Me.cbStockProname)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.dgCon)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(239, 264)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(606, 206)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "订单信息修改"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "合同编号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "合同类型："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "合同对象："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "付款方式："
        '
        'labConCustomerLevel
        '
        Me.labConCustomerLevel.AutoSize = True
        Me.labConCustomerLevel.Location = New System.Drawing.Point(268, 139)
        Me.labConCustomerLevel.Name = "labConCustomerLevel"
        Me.labConCustomerLevel.Size = New System.Drawing.Size(48, 17)
        Me.labConCustomerLevel.TabIndex = 4
        Me.labConCustomerLevel.Text = "★★☆☆"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(268, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "签订日期："
        '
        'cbConType
        '
        Me.cbConType.FormattingEnabled = True
        Me.cbConType.Location = New System.Drawing.Point(98, 85)
        Me.cbConType.Name = "cbConType"
        Me.cbConType.Size = New System.Drawing.Size(121, 25)
        Me.cbConType.TabIndex = 6
        '
        'cbConCustomer
        '
        Me.cbConCustomer.FormattingEnabled = True
        Me.cbConCustomer.Location = New System.Drawing.Point(98, 131)
        Me.cbConCustomer.Name = "cbConCustomer"
        Me.cbConCustomer.Size = New System.Drawing.Size(121, 25)
        Me.cbConCustomer.TabIndex = 7
        '
        'cbConPaytype
        '
        Me.cbConPaytype.FormattingEnabled = True
        Me.cbConPaytype.Location = New System.Drawing.Point(98, 184)
        Me.cbConPaytype.Name = "cbConPaytype"
        Me.cbConPaytype.Size = New System.Drawing.Size(121, 25)
        Me.cbConPaytype.TabIndex = 8
        '
        'cbConID
        '
        Me.cbConID.FormattingEnabled = True
        Me.cbConID.Location = New System.Drawing.Point(98, 31)
        Me.cbConID.Name = "cbConID"
        Me.cbConID.Size = New System.Drawing.Size(121, 25)
        Me.cbConID.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(341, 131)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "查看客户信息"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtpCon
        '
        Me.dtpCon.Location = New System.Drawing.Point(341, 186)
        Me.dtpCon.Name = "dtpCon"
        Me.dtpCon.Size = New System.Drawing.Size(101, 23)
        Me.dtpCon.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 17)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "产品名称："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(268, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 17)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "数量："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(451, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 17)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "单价："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(451, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 17)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "折扣率："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(451, 118)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 17)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "交易金额："
        '
        'dgCon
        '
        Me.dgCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCon.Location = New System.Drawing.Point(6, 52)
        Me.dgCon.Name = "dgCon"
        Me.dgCon.RowTemplate.Height = 25
        Me.dgCon.Size = New System.Drawing.Size(410, 159)
        Me.dgCon.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(420, 177)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "添加"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(525, 177)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "删除"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(784, 476)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "关闭"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(690, 474)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 9
        Me.Button5.Text = "添加"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(596, 474)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "修改"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'cbStockProname
        '
        Me.cbStockProname.FormattingEnabled = True
        Me.cbStockProname.Location = New System.Drawing.Point(98, 24)
        Me.cbStockProname.Name = "cbStockProname"
        Me.cbStockProname.Size = New System.Drawing.Size(121, 25)
        Me.cbStockProname.TabIndex = 12
        '
        'nubStockNumber
        '
        Me.nubStockNumber.Location = New System.Drawing.Point(312, 25)
        Me.nubStockNumber.Name = "nubStockNumber"
        Me.nubStockNumber.Size = New System.Drawing.Size(70, 23)
        Me.nubStockNumber.TabIndex = 13
        '
        'txtConInprice
        '
        Me.txtConInprice.Location = New System.Drawing.Point(491, 24)
        Me.txtConInprice.Name = "txtConInprice"
        Me.txtConInprice.Size = New System.Drawing.Size(100, 23)
        Me.txtConInprice.TabIndex = 14
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(536, 79)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(55, 23)
        Me.TextBox2.TabIndex = 15
        '
        'txtConSum
        '
        Me.txtConSum.Location = New System.Drawing.Point(451, 138)
        Me.txtConSum.Name = "txtConSum"
        Me.txtConSum.Size = New System.Drawing.Size(140, 23)
        Me.txtConSum.TabIndex = 16
        '
        'frmConModify
        '
        Me.ClientSize = New System.Drawing.Size(890, 534)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "frmConModify"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgCon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nubStockNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents labConCustomerLevel As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbConPaytype As ComboBox
    Friend WithEvents cbConCustomer As ComboBox
    Friend WithEvents cbConType As ComboBox
    Friend WithEvents cbConID As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents dtpCon As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dgCon As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents cbStockProname As ComboBox
    Friend WithEvents nubStockNumber As NumericUpDown
    Friend WithEvents txtConSum As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents txtConInprice As TextBox
End Class
