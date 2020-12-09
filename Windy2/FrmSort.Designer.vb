<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSort
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSort))
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TxtFinColIndex = New System.Windows.Forms.NumericUpDown()
        Me.TxtStartColIndex = New System.Windows.Forms.NumericUpDown()
        Me.TxtFinRowIndex = New System.Windows.Forms.NumericUpDown()
        Me.TxtStartRowIndex = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OptAscending = New System.Windows.Forms.RadioButton()
        Me.OptDescending = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.TxtFinColIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStartColIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFinRowIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStartRowIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(33, 112)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 28)
        Me.BtnOK.TabIndex = 7
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(133, 112)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 28)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TxtFinColIndex
        '
        Me.TxtFinColIndex.Location = New System.Drawing.Point(177, 39)
        Me.TxtFinColIndex.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtFinColIndex.Name = "TxtFinColIndex"
        Me.TxtFinColIndex.Size = New System.Drawing.Size(50, 19)
        Me.TxtFinColIndex.TabIndex = 5
        Me.TxtFinColIndex.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtStartColIndex
        '
        Me.TxtStartColIndex.Location = New System.Drawing.Point(98, 39)
        Me.TxtStartColIndex.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtStartColIndex.Name = "TxtStartColIndex"
        Me.TxtStartColIndex.Size = New System.Drawing.Size(50, 19)
        Me.TxtStartColIndex.TabIndex = 4
        Me.TxtStartColIndex.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtFinRowIndex
        '
        Me.TxtFinRowIndex.Location = New System.Drawing.Point(177, 12)
        Me.TxtFinRowIndex.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtFinRowIndex.Name = "TxtFinRowIndex"
        Me.TxtFinRowIndex.Size = New System.Drawing.Size(50, 19)
        Me.TxtFinRowIndex.TabIndex = 2
        Me.TxtFinRowIndex.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtStartRowIndex
        '
        Me.TxtStartRowIndex.Location = New System.Drawing.Point(98, 12)
        Me.TxtStartRowIndex.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtStartRowIndex.Name = "TxtStartRowIndex"
        Me.TxtStartRowIndex.Size = New System.Drawing.Size(50, 19)
        Me.TxtStartRowIndex.TabIndex = 1
        Me.TxtStartRowIndex.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(154, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "～"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "対象列番号(C)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "～"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "対象行番号(R)"
        '
        'OptAscending
        '
        Me.OptAscending.AutoSize = True
        Me.OptAscending.Checked = True
        Me.OptAscending.Location = New System.Drawing.Point(16, 18)
        Me.OptAscending.Name = "OptAscending"
        Me.OptAscending.Size = New System.Drawing.Size(63, 16)
        Me.OptAscending.TabIndex = 0
        Me.OptAscending.TabStop = True
        Me.OptAscending.Text = "昇順(&A)"
        Me.OptAscending.UseVisualStyleBackColor = True
        '
        'OptDescending
        '
        Me.OptDescending.AutoSize = True
        Me.OptDescending.Location = New System.Drawing.Point(84, 18)
        Me.OptDescending.Name = "OptDescending"
        Me.OptDescending.Size = New System.Drawing.Size(63, 16)
        Me.OptDescending.TabIndex = 1
        Me.OptDescending.Text = "降順(&D)"
        Me.OptDescending.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptAscending)
        Me.GroupBox1.Controls.Add(Me.OptDescending)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(213, 42)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ソート順序"
        '
        'FrmSort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(243, 149)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.TxtFinColIndex)
        Me.Controls.Add(Me.TxtStartColIndex)
        Me.Controls.Add(Me.TxtFinRowIndex)
        Me.Controls.Add(Me.TxtStartRowIndex)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSort"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ソート"
        CType(Me.TxtFinColIndex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStartColIndex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFinRowIndex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStartRowIndex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents TxtFinColIndex As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtStartColIndex As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtFinRowIndex As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtStartRowIndex As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OptAscending As System.Windows.Forms.RadioButton
    Friend WithEvents OptDescending As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
