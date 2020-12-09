<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSnapShotInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSnapShotInfo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtStartRowIndex = New System.Windows.Forms.NumericUpDown()
        Me.TxtFinRowIndex = New System.Windows.Forms.NumericUpDown()
        Me.TxtStartColIndex = New System.Windows.Forms.NumericUpDown()
        Me.TxtFinColIndex = New System.Windows.Forms.NumericUpDown()
        Me.TxtStartDate = New System.Windows.Forms.DateTimePicker()
        Me.TxtFinDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        CType(Me.TxtStartRowIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFinRowIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStartColIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFinColIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "出力行番号(&R)"
        '
        'TxtStartRowIndex
        '
        Me.TxtStartRowIndex.Location = New System.Drawing.Point(101, 12)
        Me.TxtStartRowIndex.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtStartRowIndex.Name = "TxtStartRowIndex"
        Me.TxtStartRowIndex.Size = New System.Drawing.Size(50, 19)
        Me.TxtStartRowIndex.TabIndex = 1
        Me.TxtStartRowIndex.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtFinRowIndex
        '
        Me.TxtFinRowIndex.Location = New System.Drawing.Point(180, 12)
        Me.TxtFinRowIndex.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtFinRowIndex.Name = "TxtFinRowIndex"
        Me.TxtFinRowIndex.Size = New System.Drawing.Size(50, 19)
        Me.TxtFinRowIndex.TabIndex = 3
        Me.TxtFinRowIndex.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtStartColIndex
        '
        Me.TxtStartColIndex.Location = New System.Drawing.Point(101, 39)
        Me.TxtStartColIndex.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtStartColIndex.Name = "TxtStartColIndex"
        Me.TxtStartColIndex.Size = New System.Drawing.Size(50, 19)
        Me.TxtStartColIndex.TabIndex = 5
        Me.TxtStartColIndex.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtFinColIndex
        '
        Me.TxtFinColIndex.Location = New System.Drawing.Point(180, 39)
        Me.TxtFinColIndex.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtFinColIndex.Name = "TxtFinColIndex"
        Me.TxtFinColIndex.Size = New System.Drawing.Size(50, 19)
        Me.TxtFinColIndex.TabIndex = 7
        Me.TxtFinColIndex.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Location = New System.Drawing.Point(99, 64)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(131, 19)
        Me.TxtStartDate.TabIndex = 9
        '
        'TxtFinDate
        '
        Me.TxtFinDate.Location = New System.Drawing.Point(99, 91)
        Me.TxtFinDate.Name = "TxtFinDate"
        Me.TxtFinDate.Size = New System.Drawing.Size(131, 19)
        Me.TxtFinDate.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(157, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "～"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "出力列番号(&C)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(157, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "～"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "出力開始日(&S)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "出力終了日(&F)"
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(36, 116)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 28)
        Me.BtnOK.TabIndex = 12
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(136, 116)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 28)
        Me.BtnCancel.TabIndex = 13
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'FrmSnapShotInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(242, 150)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.TxtFinDate)
        Me.Controls.Add(Me.TxtStartDate)
        Me.Controls.Add(Me.TxtFinColIndex)
        Me.Controls.Add(Me.TxtStartColIndex)
        Me.Controls.Add(Me.TxtFinRowIndex)
        Me.Controls.Add(Me.TxtStartRowIndex)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSnapShotInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "出力範囲設定"
        CType(Me.TxtStartRowIndex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFinRowIndex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStartColIndex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFinColIndex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtStartRowIndex As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtFinRowIndex As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtStartColIndex As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtFinColIndex As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtFinDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
End Class
