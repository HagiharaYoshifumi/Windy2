<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSetting))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TxtToDay = New System.Windows.Forms.NumericUpDown()
        Me.TxtStartDay = New System.Windows.Forms.NumericUpDown()
        Me.TxtFinalDay = New System.Windows.Forms.NumericUpDown()
        Me.TxtPrintDay = New System.Windows.Forms.NumericUpDown()
        Me.ColorPicker_Saturday = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.DropDownButton1 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPickerButton1 = New GrapeCity.Win.Common.ColorPickerButton()
        Me.ColorPicker_Sunday = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.DropDownButton2 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPickerButton2 = New GrapeCity.Win.Common.ColorPickerButton()
        Me.ColorPicker_Today = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.DropDownButton3 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPickerButton3 = New GrapeCity.Win.Common.ColorPickerButton()
        Me.ChkTunnel = New System.Windows.Forms.CheckBox()
        Me.BtnHoliday = New System.Windows.Forms.Button()
        Me.BtnDelFileRireki = New System.Windows.Forms.Button()
        Me.ChkNoHighlight = New System.Windows.Forms.CheckBox()
        Me.ChkTabletMode = New System.Windows.Forms.CheckBox()
        Me.TxtCellFontSize = New System.Windows.Forms.NumericUpDown()
        Me.TxtPieceFontSize = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtCellHeaderFontSize = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.TxtToDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStartDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFinalDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPrintDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorPicker_Saturday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorPicker_Sunday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorPicker_Today, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCellFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPieceFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCellHeaderFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "土曜日色(&A)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "日曜日色(&S)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "本日色(&D)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(233, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "本日余日(&H)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(233, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 12)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "先頭余日(&T)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(233, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 12)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "最終余白日(&L)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(233, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 12)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "印刷余白日(&P)"
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(286, 190)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(89, 26)
        Me.BtnOK.TabIndex = 20
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(286, 222)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancel.TabIndex = 21
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TxtToDay
        '
        Me.TxtToDay.Location = New System.Drawing.Point(319, 9)
        Me.TxtToDay.Name = "TxtToDay"
        Me.TxtToDay.Size = New System.Drawing.Size(56, 19)
        Me.TxtToDay.TabIndex = 11
        '
        'TxtStartDay
        '
        Me.TxtStartDay.Location = New System.Drawing.Point(319, 36)
        Me.TxtStartDay.Name = "TxtStartDay"
        Me.TxtStartDay.Size = New System.Drawing.Size(56, 19)
        Me.TxtStartDay.TabIndex = 13
        '
        'TxtFinalDay
        '
        Me.TxtFinalDay.Location = New System.Drawing.Point(319, 63)
        Me.TxtFinalDay.Name = "TxtFinalDay"
        Me.TxtFinalDay.Size = New System.Drawing.Size(56, 19)
        Me.TxtFinalDay.TabIndex = 15
        '
        'TxtPrintDay
        '
        Me.TxtPrintDay.Location = New System.Drawing.Point(319, 90)
        Me.TxtPrintDay.Name = "TxtPrintDay"
        Me.TxtPrintDay.Size = New System.Drawing.Size(56, 19)
        Me.TxtPrintDay.TabIndex = 17
        '
        'ColorPicker_Saturday
        '
        Me.ColorPicker_Saturday.AutoSize = True
        Me.ColorPicker_Saturday.DropDownStyle = GrapeCity.Win.Pickers.DropDownStyle.DropDownList
        Me.ColorPicker_Saturday.Location = New System.Drawing.Point(85, 9)
        Me.ColorPicker_Saturday.Name = "ColorPicker_Saturday"
        Me.ColorPicker_Saturday.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton1, Me.ColorPickerButton1})
        Me.ColorPicker_Saturday.Size = New System.Drawing.Size(140, 20)
        Me.ColorPicker_Saturday.TabIndex = 1
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'ColorPickerButton1
        '
        Me.ColorPickerButton1.Name = "ColorPickerButton1"
        Me.ColorPickerButton1.UseVisualStyleBackColor = True
        '
        'ColorPicker_Sunday
        '
        Me.ColorPicker_Sunday.AutoSize = True
        Me.ColorPicker_Sunday.DropDownStyle = GrapeCity.Win.Pickers.DropDownStyle.DropDownList
        Me.ColorPicker_Sunday.Location = New System.Drawing.Point(85, 37)
        Me.ColorPicker_Sunday.Name = "ColorPicker_Sunday"
        Me.ColorPicker_Sunday.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton2, Me.ColorPickerButton2})
        Me.ColorPicker_Sunday.Size = New System.Drawing.Size(140, 20)
        Me.ColorPicker_Sunday.TabIndex = 3
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'ColorPickerButton2
        '
        Me.ColorPickerButton2.Name = "ColorPickerButton2"
        Me.ColorPickerButton2.UseVisualStyleBackColor = True
        '
        'ColorPicker_Today
        '
        Me.ColorPicker_Today.AutoSize = True
        Me.ColorPicker_Today.DropDownStyle = GrapeCity.Win.Pickers.DropDownStyle.DropDownList
        Me.ColorPicker_Today.Location = New System.Drawing.Point(85, 65)
        Me.ColorPicker_Today.Name = "ColorPicker_Today"
        Me.ColorPicker_Today.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton3, Me.ColorPickerButton3})
        Me.ColorPicker_Today.Size = New System.Drawing.Size(140, 20)
        Me.ColorPicker_Today.TabIndex = 5
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'ColorPickerButton3
        '
        Me.ColorPickerButton3.Name = "ColorPickerButton3"
        Me.ColorPickerButton3.UseVisualStyleBackColor = True
        '
        'ChkTunnel
        '
        Me.ChkTunnel.AutoSize = True
        Me.ChkTunnel.Location = New System.Drawing.Point(12, 188)
        Me.ChkTunnel.Name = "ChkTunnel"
        Me.ChkTunnel.Size = New System.Drawing.Size(167, 16)
        Me.ChkTunnel.TabIndex = 7
        Me.ChkTunnel.Text = "既定でトンネルピースにする(&N)"
        Me.ChkTunnel.UseVisualStyleBackColor = True
        '
        'BtnHoliday
        '
        Me.BtnHoliday.Location = New System.Drawing.Point(224, 147)
        Me.BtnHoliday.Name = "BtnHoliday"
        Me.BtnHoliday.Size = New System.Drawing.Size(151, 26)
        Me.BtnHoliday.TabIndex = 19
        Me.BtnHoliday.Text = "休日設定(&H)"
        Me.BtnHoliday.UseVisualStyleBackColor = True
        '
        'BtnDelFileRireki
        '
        Me.BtnDelFileRireki.Location = New System.Drawing.Point(224, 115)
        Me.BtnDelFileRireki.Name = "BtnDelFileRireki"
        Me.BtnDelFileRireki.Size = New System.Drawing.Size(151, 26)
        Me.BtnDelFileRireki.TabIndex = 18
        Me.BtnDelFileRireki.Text = "ファイル履歴のクリア(&F)"
        Me.BtnDelFileRireki.UseVisualStyleBackColor = True
        '
        'ChkNoHighlight
        '
        Me.ChkNoHighlight.AutoSize = True
        Me.ChkNoHighlight.Location = New System.Drawing.Point(12, 210)
        Me.ChkNoHighlight.Name = "ChkNoHighlight"
        Me.ChkNoHighlight.Size = New System.Drawing.Size(237, 16)
        Me.ChkNoHighlight.TabIndex = 8
        Me.ChkNoHighlight.Text = "関係線があるピースのハイライトは行わない(&L)"
        Me.ChkNoHighlight.UseVisualStyleBackColor = True
        '
        'ChkTabletMode
        '
        Me.ChkTabletMode.AutoSize = True
        Me.ChkTabletMode.Location = New System.Drawing.Point(12, 232)
        Me.ChkTabletMode.Name = "ChkTabletMode"
        Me.ChkTabletMode.Size = New System.Drawing.Size(108, 16)
        Me.ChkTabletMode.TabIndex = 9
        Me.ChkTabletMode.Text = "タブレットモード(&E)"
        Me.ChkTabletMode.UseVisualStyleBackColor = True
        '
        'TxtCellFontSize
        '
        Me.TxtCellFontSize.Location = New System.Drawing.Point(111, 38)
        Me.TxtCellFontSize.Maximum = New Decimal(New Integer() {48, 0, 0, 0})
        Me.TxtCellFontSize.Minimum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.TxtCellFontSize.Name = "TxtCellFontSize"
        Me.TxtCellFontSize.Size = New System.Drawing.Size(56, 19)
        Me.TxtCellFontSize.TabIndex = 3
        Me.TxtCellFontSize.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'TxtPieceFontSize
        '
        Me.TxtPieceFontSize.Location = New System.Drawing.Point(111, 63)
        Me.TxtPieceFontSize.Maximum = New Decimal(New Integer() {48, 0, 0, 0})
        Me.TxtPieceFontSize.Minimum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.TxtPieceFontSize.Name = "TxtPieceFontSize"
        Me.TxtPieceFontSize.Size = New System.Drawing.Size(56, 19)
        Me.TxtPieceFontSize.TabIndex = 5
        Me.TxtPieceFontSize.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "セルサイズ(&U)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "ピースサイズ(&I)"
        '
        'TxtCellHeaderFontSize
        '
        Me.TxtCellHeaderFontSize.Location = New System.Drawing.Point(111, 13)
        Me.TxtCellHeaderFontSize.Maximum = New Decimal(New Integer() {48, 0, 0, 0})
        Me.TxtCellHeaderFontSize.Minimum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.TxtCellHeaderFontSize.Name = "TxtCellHeaderFontSize"
        Me.TxtCellHeaderFontSize.Size = New System.Drawing.Size(56, 19)
        Me.TxtCellHeaderFontSize.TabIndex = 1
        Me.TxtCellHeaderFontSize.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "セルヘッダサイズ(&Q)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtCellHeaderFontSize)
        Me.GroupBox1.Controls.Add(Me.TxtPieceFontSize)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtCellFontSize)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 88)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "フォントサイズ設定"
        '
        'FrmSetting
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(386, 258)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ChkTabletMode)
        Me.Controls.Add(Me.ChkNoHighlight)
        Me.Controls.Add(Me.BtnDelFileRireki)
        Me.Controls.Add(Me.BtnHoliday)
        Me.Controls.Add(Me.ChkTunnel)
        Me.Controls.Add(Me.ColorPicker_Today)
        Me.Controls.Add(Me.ColorPicker_Sunday)
        Me.Controls.Add(Me.ColorPicker_Saturday)
        Me.Controls.Add(Me.TxtPrintDay)
        Me.Controls.Add(Me.TxtFinalDay)
        Me.Controls.Add(Me.TxtStartDay)
        Me.Controls.Add(Me.TxtToDay)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Windy 全体設定"
        CType(Me.TxtToDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStartDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFinalDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPrintDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorPicker_Saturday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorPicker_Sunday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorPicker_Today, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCellFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPieceFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCellHeaderFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents TxtToDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtStartDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtFinalDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtPrintDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents ColorPicker_Saturday As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPickerButton1 As GrapeCity.Win.Common.ColorPickerButton
    Friend WithEvents ColorPicker_Sunday As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPickerButton2 As GrapeCity.Win.Common.ColorPickerButton
    Friend WithEvents ColorPicker_Today As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPickerButton3 As GrapeCity.Win.Common.ColorPickerButton
    Friend WithEvents ChkTunnel As System.Windows.Forms.CheckBox
    Friend WithEvents BtnHoliday As System.Windows.Forms.Button
    Friend WithEvents BtnDelFileRireki As System.Windows.Forms.Button
    Private WithEvents ChkNoHighlight As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTabletMode As System.Windows.Forms.CheckBox
    Friend WithEvents TxtCellFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtPieceFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCellHeaderFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
