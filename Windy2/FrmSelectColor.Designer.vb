<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectColor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelectColor))
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.ColorPicker_SelColor = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.DropDownButton2 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPickerButton2 = New GrapeCity.Win.Common.ColorPickerButton()
        CType(Me.ColorPicker_SelColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(12, 38)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 28)
        Me.BtnOK.TabIndex = 1
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(107, 38)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 28)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'ColorPicker_SelColor
        '
        Me.ColorPicker_SelColor.AutoSize = True
        Me.ColorPicker_SelColor.DropDownStyle = GrapeCity.Win.Pickers.DropDownStyle.DropDownList
        Me.ColorPicker_SelColor.Location = New System.Drawing.Point(12, 12)
        Me.ColorPicker_SelColor.Name = "ColorPicker_SelColor"
        Me.ColorPicker_SelColor.ShowAutomaticColor = True
        Me.ColorPicker_SelColor.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton2, Me.ColorPickerButton2})
        Me.ColorPicker_SelColor.Size = New System.Drawing.Size(189, 20)
        Me.ColorPicker_SelColor.TabIndex = 0
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
        'FrmSelectColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(212, 71)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.ColorPicker_SelColor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelectColor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "行背景色選択"
        CType(Me.ColorPicker_SelColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents ColorPicker_SelColor As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPickerButton2 As GrapeCity.Win.Common.ColorPickerButton
End Class
