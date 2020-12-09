<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrinterDialog
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrinterDialog))
        Me.cboOrientation = New System.Windows.Forms.ComboBox()
        Me.updMag = New System.Windows.Forms.NumericUpDown()
        Me.cboPaperSize = New System.Windows.Forms.ComboBox()
        Me.cboColFrom = New System.Windows.Forms.ComboBox()
        Me.cboColTo = New System.Windows.Forms.ComboBox()
        Me.cboNewPage = New System.Windows.Forms.ComboBox()
        Me.chkCol = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkBreak = New System.Windows.Forms.CheckBox()
        Me.chkMono = New System.Windows.Forms.CheckBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnPreview = New System.Windows.Forms.Button()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtEndDay = New System.Windows.Forms.DateTimePicker()
        Me.ChkYohoku = New System.Windows.Forms.CheckBox()
        Me.TxtStartDay = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkJustClippingToScale = New System.Windows.Forms.CheckBox()
        CType(Me.updMag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboOrientation
        '
        Me.cboOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrientation.FormattingEnabled = True
        Me.cboOrientation.Location = New System.Drawing.Point(110, 7)
        Me.cboOrientation.Name = "cboOrientation"
        Me.cboOrientation.Size = New System.Drawing.Size(121, 20)
        Me.cboOrientation.TabIndex = 1
        '
        'updMag
        '
        Me.updMag.Location = New System.Drawing.Point(291, 10)
        Me.updMag.Name = "updMag"
        Me.updMag.Size = New System.Drawing.Size(60, 19)
        Me.updMag.TabIndex = 11
        Me.updMag.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'cboPaperSize
        '
        Me.cboPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaperSize.FormattingEnabled = True
        Me.cboPaperSize.Location = New System.Drawing.Point(110, 35)
        Me.cboPaperSize.Name = "cboPaperSize"
        Me.cboPaperSize.Size = New System.Drawing.Size(121, 20)
        Me.cboPaperSize.TabIndex = 3
        '
        'cboColFrom
        '
        Me.cboColFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColFrom.FormattingEnabled = True
        Me.cboColFrom.Location = New System.Drawing.Point(110, 63)
        Me.cboColFrom.Name = "cboColFrom"
        Me.cboColFrom.Size = New System.Drawing.Size(121, 20)
        Me.cboColFrom.TabIndex = 5
        '
        'cboColTo
        '
        Me.cboColTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColTo.FormattingEnabled = True
        Me.cboColTo.Location = New System.Drawing.Point(264, 63)
        Me.cboColTo.Name = "cboColTo"
        Me.cboColTo.Size = New System.Drawing.Size(121, 20)
        Me.cboColTo.TabIndex = 6
        '
        'cboNewPage
        '
        Me.cboNewPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewPage.FormattingEnabled = True
        Me.cboNewPage.Location = New System.Drawing.Point(110, 91)
        Me.cboNewPage.Name = "cboNewPage"
        Me.cboNewPage.Size = New System.Drawing.Size(121, 20)
        Me.cboNewPage.TabIndex = 8
        '
        'chkCol
        '
        Me.chkCol.AutoSize = True
        Me.chkCol.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCol.Location = New System.Drawing.Point(9, 65)
        Me.chkCol.Name = "chkCol"
        Me.chkCol.Size = New System.Drawing.Size(60, 16)
        Me.chkCol.TabIndex = 4
        Me.chkCol.Text = "列指定"
        Me.chkCol.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "用紙方向(&L)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "用紙サイズ(&S)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(239, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "～"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(241, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 12)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "倍率(&Z)"
        '
        'chkBreak
        '
        Me.chkBreak.AutoSize = True
        Me.chkBreak.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBreak.Location = New System.Drawing.Point(9, 93)
        Me.chkBreak.Name = "chkBreak"
        Me.chkBreak.Size = New System.Drawing.Size(90, 16)
        Me.chkBreak.TabIndex = 7
        Me.chkBreak.Text = "強制改ページ"
        Me.chkBreak.UseVisualStyleBackColor = True
        '
        'chkMono
        '
        Me.chkMono.AutoSize = True
        Me.chkMono.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkMono.Location = New System.Drawing.Point(247, 95)
        Me.chkMono.Name = "chkMono"
        Me.chkMono.Size = New System.Drawing.Size(121, 16)
        Me.chkMono.TabIndex = 9
        Me.chkMono.Text = "テキストを白黒にする"
        Me.chkMono.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(304, 214)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(94, 28)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "閉じる(&C)"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(357, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "%"
        '
        'BtnPreview
        '
        Me.BtnPreview.Location = New System.Drawing.Point(204, 214)
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(94, 28)
        Me.BtnPreview.TabIndex = 14
        Me.BtnPreview.Text = "プレビュー(&P)"
        Me.BtnPreview.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(13, 18)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(78, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "全ての範囲"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(13, 40)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(77, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "ユーザ範囲"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtEndDay)
        Me.GroupBox1.Controls.Add(Me.ChkYohoku)
        Me.GroupBox1.Controls.Add(Me.TxtStartDay)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 139)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 69)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "印刷日付範囲"
        '
        'TxtEndDay
        '
        Me.TxtEndDay.Enabled = False
        Me.TxtEndDay.Location = New System.Drawing.Point(250, 38)
        Me.TxtEndDay.Name = "TxtEndDay"
        Me.TxtEndDay.Size = New System.Drawing.Size(131, 19)
        Me.TxtEndDay.TabIndex = 20
        '
        'ChkYohoku
        '
        Me.ChkYohoku.AutoSize = True
        Me.ChkYohoku.Location = New System.Drawing.Point(245, 14)
        Me.ChkYohoku.Name = "ChkYohoku"
        Me.ChkYohoku.Size = New System.Drawing.Size(117, 16)
        Me.ChkYohoku.TabIndex = 19
        Me.ChkYohoku.Text = "日付余白をとらない"
        Me.ChkYohoku.UseVisualStyleBackColor = True
        '
        'TxtStartDay
        '
        Me.TxtStartDay.Enabled = False
        Me.TxtStartDay.Location = New System.Drawing.Point(96, 38)
        Me.TxtStartDay.Name = "TxtStartDay"
        Me.TxtStartDay.Size = New System.Drawing.Size(131, 19)
        Me.TxtStartDay.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(230, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "～"
        '
        'ChkJustClippingToScale
        '
        Me.ChkJustClippingToScale.AutoSize = True
        Me.ChkJustClippingToScale.Location = New System.Drawing.Point(9, 117)
        Me.ChkJustClippingToScale.Name = "ChkJustClippingToScale"
        Me.ChkJustClippingToScale.Size = New System.Drawing.Size(144, 16)
        Me.ChkJustClippingToScale.TabIndex = 19
        Me.ChkJustClippingToScale.Text = "横目盛りを一杯まで表示"
        Me.ChkJustClippingToScale.UseVisualStyleBackColor = True
        '
        'FrmPrinterDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(406, 252)
        Me.Controls.Add(Me.ChkJustClippingToScale)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnPreview)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkMono)
        Me.Controls.Add(Me.chkBreak)
        Me.Controls.Add(Me.chkCol)
        Me.Controls.Add(Me.updMag)
        Me.Controls.Add(Me.cboNewPage)
        Me.Controls.Add(Me.cboColTo)
        Me.Controls.Add(Me.cboColFrom)
        Me.Controls.Add(Me.cboPaperSize)
        Me.Controls.Add(Me.cboOrientation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPrinterDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "出力設定"
        CType(Me.updMag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboOrientation As System.Windows.Forms.ComboBox
    Friend WithEvents updMag As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboPaperSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboColFrom As System.Windows.Forms.ComboBox
    Friend WithEvents cboColTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboNewPage As System.Windows.Forms.ComboBox
    Friend WithEvents chkCol As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkBreak As System.Windows.Forms.CheckBox
    Friend WithEvents chkMono As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnPreview As System.Windows.Forms.Button
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChkYohoku As System.Windows.Forms.CheckBox
    Friend WithEvents TxtStartDay As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtEndDay As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkJustClippingToScale As System.Windows.Forms.CheckBox
End Class
