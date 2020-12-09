<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBalloonnProperty
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBalloonnProperty))
        Me.Edit1 = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.ColorPicker_BackColor = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.DropDownButton1 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPickerButton1 = New GrapeCity.Win.Common.ColorPickerButton()
        Me.ColorPicker_ForeColor = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.DropDownButton2 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPickerButton2 = New GrapeCity.Win.Common.ColorPickerButton()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextAlignment = New Windy2.UserControlTextAlignment2()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorPicker_BackColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorPicker_ForeColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Edit1
        '
        Me.Edit1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Edit1.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Edit1.Location = New System.Drawing.Point(12, 12)
        Me.Edit1.Multiline = True
        Me.Edit1.Name = "Edit1"
        Me.GcShortcut1.SetShortcuts(Me.Edit1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.Edit1, Object)}, New String() {"ShortcutClear"}))
        Me.Edit1.Size = New System.Drawing.Size(310, 152)
        Me.Edit1.TabIndex = 0
        '
        'ColorPicker_BackColor
        '
        Me.ColorPicker_BackColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ColorPicker_BackColor.AutomaticColor = System.Drawing.Color.LightYellow
        Me.ColorPicker_BackColor.AutoSize = True
        Me.ColorPicker_BackColor.DropDownStyle = GrapeCity.Win.Pickers.DropDownStyle.DropDownList
        Me.ColorPicker_BackColor.Location = New System.Drawing.Point(333, 27)
        Me.ColorPicker_BackColor.Name = "ColorPicker_BackColor"
        Me.ColorPicker_BackColor.ShowAutomaticColor = True
        Me.ColorPicker_BackColor.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton1, Me.ColorPickerButton1})
        Me.ColorPicker_BackColor.Size = New System.Drawing.Size(174, 20)
        Me.ColorPicker_BackColor.TabIndex = 2
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
        'ColorPicker_ForeColor
        '
        Me.ColorPicker_ForeColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ColorPicker_ForeColor.AutoSize = True
        Me.ColorPicker_ForeColor.DropDownStyle = GrapeCity.Win.Pickers.DropDownStyle.DropDownList
        Me.ColorPicker_ForeColor.Location = New System.Drawing.Point(333, 65)
        Me.ColorPicker_ForeColor.Name = "ColorPicker_ForeColor"
        Me.ColorPicker_ForeColor.ShowAutomaticColor = True
        Me.ColorPicker_ForeColor.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton2, Me.ColorPickerButton2})
        Me.ColorPicker_ForeColor.Size = New System.Drawing.Size(174, 20)
        Me.ColorPicker_ForeColor.TabIndex = 2
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
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(423, 138)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Location = New System.Drawing.Point(328, 138)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(89, 26)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(331, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "バルーン色(&B)"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(331, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "文字色(&F)"
        '
        'TextAlignment
        '
        Me.TextAlignment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextAlignment.IsHorizon = True
        Me.TextAlignment.Location = New System.Drawing.Point(333, 93)
        Me.TextAlignment.Name = "TextAlignment"
        Me.TextAlignment.SelectedAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.TextAlignment.Size = New System.Drawing.Size(175, 37)
        Me.TextAlignment.TabIndex = 5
        '
        'FrmBalloonnProperty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(519, 176)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextAlignment)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.ColorPicker_ForeColor)
        Me.Controls.Add(Me.ColorPicker_BackColor)
        Me.Controls.Add(Me.Edit1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(372, 214)
        Me.Name = "FrmBalloonnProperty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "バルーンプロパティ"
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorPicker_BackColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorPicker_ForeColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Edit1 As GrapeCity.Win.Editors.GcTextBox
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents ColorPicker_BackColor As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPickerButton1 As GrapeCity.Win.Common.ColorPickerButton
    Friend WithEvents ColorPicker_ForeColor As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPickerButton2 As GrapeCity.Win.Common.ColorPickerButton
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents TextAlignment As Windy2.UserControlTextAlignment2
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
