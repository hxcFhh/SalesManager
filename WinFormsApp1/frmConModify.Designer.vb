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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpCon = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbConID = New System.Windows.Forms.ComboBox()
        Me.cbConType = New System.Windows.Forms.ComboBox()
        Me.cbConCustomer = New System.Windows.Forms.ComboBox()
        Me.cbConPaytype = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.labConCustomerLevel = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgCon = New System.Windows.Forms.DataGridView()
        Me.txtConInprice = New System.Windows.Forms.TextBox()
        Me.txtStockPrice = New System.Windows.Forms.TextBox()
        Me.txtConSum = New System.Windows.Forms.TextBox()
        Me.nubStockNumber = New System.Windows.Forms.NumericUpDown()
        Me.cbStockProname = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
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
        Me.PictureBox1.Size = New System.Drawing.Size(216, 532)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpCon)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cbConID)
        Me.GroupBox1.Controls.Add(Me.cbConType)
        Me.GroupBox1.Controls.Add(Me.cbConCustomer)
        Me.GroupBox1.Controls.Add(Me.cbConPaytype)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.labConCustomerLevel)
        Me.GroupBox1.Controls.Add(Me.label12)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.label1)
        Me.GroupBox1.Location = New System.Drawing.Point(222, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 244)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "基本信息修改"
        '
        'dtpCon
        '
        Me.dtpCon.Location = New System.Drawing.Point(425, 179)
        Me.dtpCon.Name = "dtpCon"
        Me.dtpCon.Size = New System.Drawing.Size(185, 30)
        Me.dtpCon.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(416, 125)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 34)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "查看用户信息"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbConID
        '
        Me.cbConID.FormattingEnabled = True
        Me.cbConID.Location = New System.Drawing.Point(133, 35)
        Me.cbConID.Name = "cbConID"
        Me.cbConID.Size = New System.Drawing.Size(182, 32)
        Me.cbConID.TabIndex = 10
        '
        'cbConType
        '
        Me.cbConType.FormattingEnabled = True
        Me.cbConType.Location = New System.Drawing.Point(133, 84)
        Me.cbConType.Name = "cbConType"
        Me.cbConType.Size = New System.Drawing.Size(182, 32)
        Me.cbConType.TabIndex = 9
        '
        'cbConCustomer
        '
        Me.cbConCustomer.FormattingEnabled = True
        Me.cbConCustomer.Location = New System.Drawing.Point(133, 130)
        Me.cbConCustomer.Name = "cbConCustomer"
        Me.cbConCustomer.Size = New System.Drawing.Size(182, 32)
        Me.cbConCustomer.TabIndex = 8
        '
        'cbConPaytype
        '
        Me.cbConPaytype.FormattingEnabled = True
        Me.cbConPaytype.Location = New System.Drawing.Point(133, 171)
        Me.cbConPaytype.Name = "cbConPaytype"
        Me.cbConPaytype.Size = New System.Drawing.Size(182, 32)
        Me.cbConPaytype.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(334, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 24)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "签订日期："
        '
        'labConCustomerLevel
        '
        Me.labConCustomerLevel.AutoSize = True
        Me.labConCustomerLevel.Location = New System.Drawing.Point(334, 130)
        Me.labConCustomerLevel.Name = "labConCustomerLevel"
        Me.labConCustomerLevel.Size = New System.Drawing.Size(43, 24)
        Me.labConCustomerLevel.TabIndex = 4
        Me.labConCustomerLevel.Text = "000"
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(27, 174)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(100, 24)
        Me.label12.TabIndex = 3
        Me.label12.Text = "付款方式："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "合同对象："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "合同类型："
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(27, 38)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(100, 24)
        Me.label1.TabIndex = 0
        Me.label1.Text = "合同编号："
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgCon)
        Me.GroupBox2.Controls.Add(Me.txtConInprice)
        Me.GroupBox2.Controls.Add(Me.txtStockPrice)
        Me.GroupBox2.Controls.Add(Me.txtConSum)
        Me.GroupBox2.Controls.Add(Me.nubStockNumber)
        Me.GroupBox2.Controls.Add(Me.cbStockProname)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(222, 262)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(784, 232)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "订单信息修改"
        '
        'dgCon
        '
        Me.dgCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCon.Location = New System.Drawing.Point(6, 53)
        Me.dgCon.Name = "dgCon"
        Me.dgCon.RowHeadersWidth = 62
        Me.dgCon.RowTemplate.Height = 32
        Me.dgCon.Size = New System.Drawing.Size(513, 173)
        Me.dgCon.TabIndex = 17
        '
        'txtConInprice
        '
        Me.txtConInprice.Location = New System.Drawing.Point(613, 69)
        Me.txtConInprice.Name = "txtConInprice"
        Me.txtConInprice.Size = New System.Drawing.Size(150, 30)
        Me.txtConInprice.TabIndex = 18
        '
        'txtStockPrice
        '
        Me.txtStockPrice.Location = New System.Drawing.Point(613, 29)
        Me.txtStockPrice.Name = "txtStockPrice"
        Me.txtStockPrice.Size = New System.Drawing.Size(150, 30)
        Me.txtStockPrice.TabIndex = 17
        '
        'txtConSum
        '
        Me.txtConSum.Location = New System.Drawing.Point(525, 139)
        Me.txtConSum.Name = "txtConSum"
        Me.txtConSum.Size = New System.Drawing.Size(150, 30)
        Me.txtConSum.TabIndex = 16
        '
        'nubStockNumber
        '
        Me.nubStockNumber.Location = New System.Drawing.Point(371, 20)
        Me.nubStockNumber.Name = "nubStockNumber"
        Me.nubStockNumber.Size = New System.Drawing.Size(129, 30)
        Me.nubStockNumber.TabIndex = 15
        '
        'cbStockProname
        '
        Me.cbStockProname.FormattingEnabled = True
        Me.cbStockProname.Location = New System.Drawing.Point(125, 26)
        Me.cbStockProname.Name = "cbStockProname"
        Me.cbStockProname.Size = New System.Drawing.Size(182, 32)
        Me.cbStockProname.TabIndex = 14
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(543, 183)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 34)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "添加"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(661, 183)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 34)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "删除"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(525, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 24)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "折扣率："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(525, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 24)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "交易金额："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(525, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 24)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "单价："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(313, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 24)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "数量："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(27, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 24)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "产品名称："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(883, 508)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(112, 34)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "关闭"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(765, 508)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(112, 34)
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "删除"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(647, 508)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(112, 34)
        Me.Button6.TabIndex = 16
        Me.Button6.Text = "修改"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'frmConModify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 565)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "frmConModify"
        Me.Text = "frmConModify"
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
    Friend WithEvents labConCustomerLevel As Label
    Friend WithEvents label12 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents label1 As Label
    Friend WithEvents cbConID As ComboBox
    Friend WithEvents cbConType As ComboBox
    Friend WithEvents cbConCustomer As ComboBox
    Friend WithEvents cbConPaytype As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents dtpCon As DateTimePicker
    Friend WithEvents cbStockProname As ComboBox
    Friend WithEvents txtConInprice As TextBox
    Friend WithEvents txtStockPrice As TextBox
    Friend WithEvents txtConSum As TextBox
    Friend WithEvents nubStockNumber As NumericUpDown
    Friend WithEvents dgCon As DataGridView
End Class
