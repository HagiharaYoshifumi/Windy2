<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmColumnProperty
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmColumnProperty))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.ColorPicker_Back = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.DropDownButton1 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPickerButton1 = New GrapeCity.Win.Common.ColorPickerButton()
        Me.ColorPicker_Fore = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.DropDownButton2 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPickerButton2 = New GrapeCity.Win.Common.ColorPickerButton()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.Edit1 = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.ChkHidden = New System.Windows.Forms.CheckBox()
        Me.TextAlignment2 = New Windy2.UserControlTextAlignment2()
        CType(Me.ColorPicker_Back, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorPicker_Fore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 12)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "文字色(&F)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 12)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "背景色(&B)"
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(9, 131)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 28)
        Me.BtnOK.TabIndex = 18
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'ColorPicker_Back
        '
        Me.ColorPicker_Back.AutomaticColor = System.Drawing.Color.White
        Me.ColorPicker_Back.AutoSize = True
        Me.ColorPicker_Back.Location = New System.Drawing.Point(69, 39)
        Me.ColorPicker_Back.Name = "ColorPicker_Back"
        Me.ColorPicker_Back.ShowAutomaticColor = True
        Me.ColorPicker_Back.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton1, Me.ColorPickerButton1})
        Me.ColorPicker_Back.Size = New System.Drawing.Size(140, 20)
        Me.ColorPicker_Back.TabIndex = 17
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
        'ColorPicker_Fore
        '
        Me.ColorPicker_Fore.AutoSize = True
        Me.ColorPicker_Fore.Location = New System.Drawing.Point(69, 12)
        Me.ColorPicker_Fore.Name = "ColorPicker_Fore"
        Me.ColorPicker_Fore.ShowAutomaticColor = True
        Me.ColorPicker_Fore.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton2, Me.ColorPickerButton2})
        Me.ColorPicker_Fore.Size = New System.Drawing.Size(140, 20)
        Me.ColorPicker_Fore.TabIndex = 16
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
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(107, 131)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 28)
        Me.BtnCancel.TabIndex = 19
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Edit1
        '
        Me.Edit1.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Edit1.Location = New System.Drawing.Point(193, 65)
        Me.Edit1.Multiline = True
        Me.Edit1.Name = "Edit1"
        Me.GcShortcut1.SetShortcuts(Me.Edit1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.Edit1, Object)}, New String() {"ShortcutClear"}))
        Me.Edit1.Size = New System.Drawing.Size(86, 18)
        Me.Edit1.TabIndex = 15
        Me.Edit1.Visible = False
        '
        'ChkHidden
        '
        Me.ChkHidden.AutoSize = True
        Me.ChkHidden.Location = New System.Drawing.Point(14, 108)
        Me.ChkHidden.Name = "ChkHidden"
        Me.ChkHidden.Size = New System.Drawing.Size(125, 16)
        Me.ChkHidden.TabIndex = 23
        Me.ChkHidden.Text = "列を非表示にする(&H)"
        Me.ChkHidden.UseVisualStyleBackColor = True
        '
        'TextAlignment2
        '
        Me.TextAlignment2.IsHorizon = True
        Me.TextAlignment2.Location = New System.Drawing.Point(12, 65)
        Me.TextAlignment2.Name = "TextAlignment2"
        Me.TextAlignment2.SelectedAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.TextAlignment2.Size = New System.Drawing.Size(175, 37)
        Me.TextAlignment2.TabIndex = 20
        '
        'FrmColProperty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(213, 169)
        Me.Controls.Add(Me.ChkHidden)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextAlignment2)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.ColorPicker_Back)
        Me.Controls.Add(Me.ColorPicker_Fore)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Edit1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmColProperty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "列プロパティ"
        CType(Me.ColorPicker_Back, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorPicker_Fore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextAlignment2 As Windy2.UserControlTextAlignment2
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents ColorPicker_Back As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPickerButton1 As GrapeCity.Win.Common.ColorPickerButton
    Friend WithEvents ColorPicker_Fore As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPickerButton2 As GrapeCity.Win.Common.ColorPickerButton
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents Edit1 As GrapeCity.Win.Editors.GcTextBox
    Friend WithEvents ChkHidden As System.Windows.Forms.CheckBox
End Class
