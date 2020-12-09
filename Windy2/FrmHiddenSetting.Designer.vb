<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHiddenSetting
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTargetString = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.BtnExecScan = New System.Windows.Forms.Button()
        Me.BtnDisHidden = New System.Windows.Forms.Button()
        Me.BtnHidden = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtTargetString, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TxtTargetString)
        Me.Panel1.Controls.Add(Me.BtnExecScan)
        Me.Panel1.Controls.Add(Me.BtnDisHidden)
        Me.Panel1.Controls.Add(Me.BtnHidden)
        Me.Panel1.Controls.Add(Me.BtnOK)
        Me.Panel1.Controls.Add(Me.BtnCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 351)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 70)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "検索文字列"
        '
        'TxtTargetString
        '
        Me.TxtTargetString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTargetString.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.TxtTargetString.HighlightText = True
        Me.TxtTargetString.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TxtTargetString.Location = New System.Drawing.Point(81, 9)
        Me.TxtTargetString.Name = "TxtTargetString"
        Me.TxtTargetString.Size = New System.Drawing.Size(346, 20)
        Me.TxtTargetString.TabIndex = 15
        '
        'BtnExecScan
        '
        Me.BtnExecScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExecScan.Location = New System.Drawing.Point(433, 8)
        Me.BtnExecScan.Name = "BtnExecScan"
        Me.BtnExecScan.Size = New System.Drawing.Size(75, 23)
        Me.BtnExecScan.TabIndex = 14
        Me.BtnExecScan.Text = "検索"
        Me.BtnExecScan.UseVisualStyleBackColor = True
        '
        'BtnDisHidden
        '
        Me.BtnDisHidden.Location = New System.Drawing.Point(112, 35)
        Me.BtnDisHidden.Name = "BtnDisHidden"
        Me.BtnDisHidden.Size = New System.Drawing.Size(98, 28)
        Me.BtnDisHidden.TabIndex = 13
        Me.BtnDisHidden.Text = "表示に設定"
        Me.BtnDisHidden.UseVisualStyleBackColor = True
        '
        'BtnHidden
        '
        Me.BtnHidden.Location = New System.Drawing.Point(8, 35)
        Me.BtnHidden.Name = "BtnHidden"
        Me.BtnHidden.Size = New System.Drawing.Size(98, 28)
        Me.BtnHidden.TabIndex = 13
        Me.BtnHidden.Text = "非表示に設定"
        Me.BtnHidden.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Location = New System.Drawing.Point(324, 35)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 28)
        Me.BtnOK.TabIndex = 11
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(419, 35)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 28)
        Me.BtnCancel.TabIndex = 12
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(520, 351)
        Me.DataGridView1.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.FillWeight = 25.0!
        Me.Column2.HeaderText = " "
        Me.Column2.MinimumWidth = 25
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 25
        '
        'FrmHiddenSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(520, 421)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.MinimizeBox = False
        Me.Name = "FrmHiddenSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmHiddenSetting"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TxtTargetString, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents BtnOK As System.Windows.Forms.Button
    Private WithEvents BtnCancel As System.Windows.Forms.Button
    Private WithEvents BtnDisHidden As System.Windows.Forms.Button
    Private WithEvents BtnHidden As System.Windows.Forms.Button
    Friend WithEvents BtnExecScan As System.Windows.Forms.Button
    Friend WithEvents TxtTargetString As GrapeCity.Win.Editors.GcTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewImageColumn
End Class
