<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAutoNumber
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAutoNumber))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OptAutoNo = New System.Windows.Forms.RadioButton()
        Me.OptNomal = New System.Windows.Forms.RadioButton()
        Me.OptFrontZero = New System.Windows.Forms.RadioButton()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptAutoNo)
        Me.GroupBox1.Controls.Add(Me.OptNomal)
        Me.GroupBox1.Controls.Add(Me.OptFrontZero)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(294, 40)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "番号付与体系"
        '
        'OptAutoNo
        '
        Me.OptAutoNo.AutoSize = True
        Me.OptAutoNo.Location = New System.Drawing.Point(207, 18)
        Me.OptAutoNo.Name = "OptAutoNo"
        Me.OptAutoNo.Size = New System.Drawing.Size(83, 16)
        Me.OptAutoNo.TabIndex = 29
        Me.OptAutoNo.Text = "自動行番号"
        Me.OptAutoNo.UseVisualStyleBackColor = True
        '
        'OptNomal
        '
        Me.OptNomal.AutoSize = True
        Me.OptNomal.Checked = True
        Me.OptNomal.Location = New System.Drawing.Point(16, 18)
        Me.OptNomal.Name = "OptNomal"
        Me.OptNomal.Size = New System.Drawing.Size(77, 16)
        Me.OptNomal.TabIndex = 28
        Me.OptNomal.TabStop = True
        Me.OptNomal.Text = "通常(1.2.3)"
        Me.OptNomal.UseVisualStyleBackColor = True
        '
        'OptFrontZero
        '
        Me.OptFrontZero.AutoSize = True
        Me.OptFrontZero.Location = New System.Drawing.Point(99, 18)
        Me.OptFrontZero.Name = "OptFrontZero"
        Me.OptFrontZero.Size = New System.Drawing.Size(102, 16)
        Me.OptFrontZero.TabIndex = 28
        Me.OptFrontZero.Text = "前ゼロ(01.02.03)"
        Me.OptFrontZero.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(106, 58)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 28)
        Me.BtnOK.TabIndex = 38
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(206, 58)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 28)
        Me.BtnCancel.TabIndex = 39
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'FrmAutoNumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(312, 91)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAutoNumber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "自動番号付与"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OptNomal As System.Windows.Forms.RadioButton
    Friend WithEvents OptFrontZero As System.Windows.Forms.RadioButton
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents OptAutoNo As System.Windows.Forms.RadioButton
End Class
