<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmColumnHeaderProperty
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmColumnHeaderProperty))
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.Edit1 = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TextAlignment = New Windy2.UserControlTextAlignment2()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(203, 102)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 28)
        Me.BtnOK.TabIndex = 9
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'Edit1
        '
        Me.Edit1.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Edit1.Location = New System.Drawing.Point(7, 11)
        Me.Edit1.Multiline = True
        Me.Edit1.Name = "Edit1"
        Me.GcShortcut1.SetShortcuts(Me.Edit1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.Edit1, Object)}, New String() {"ShortcutClear"}))
        Me.Edit1.Size = New System.Drawing.Size(390, 80)
        Me.Edit1.TabIndex = 4
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(303, 102)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 28)
        Me.BtnCancel.TabIndex = 10
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TextAlignment
        '
        Me.TextAlignment.IsHorizon = True
        Me.TextAlignment.Location = New System.Drawing.Point(7, 97)
        Me.TextAlignment.Name = "TextAlignment"
        Me.TextAlignment.SelectedAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.TextAlignment.Size = New System.Drawing.Size(175, 37)
        Me.TextAlignment.TabIndex = 12
        '
        'FrmColumnHeaderProperty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(405, 138)
        Me.Controls.Add(Me.TextAlignment)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Edit1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmColumnHeaderProperty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "カラムヘッダープロパティ"
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents Edit1 As GrapeCity.Win.Editors.GcTextBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents TextAlignment As Windy2.UserControlTextAlignment2
End Class
