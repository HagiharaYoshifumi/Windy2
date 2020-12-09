<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSheetProperty
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSheetProperty))
        Me.TxtTitle = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.TxtCellDateFormat = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.TxtNACellValue = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.TxtOwner = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbPieceLayout = New System.Windows.Forms.ComboBox()
        Me.TxtPassword1 = New System.Windows.Forms.TextBox()
        Me.TxtPassword2 = New System.Windows.Forms.TextBox()
        Me.ChkIsExclusion = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChkIsWaterFall = New System.Windows.Forms.CheckBox()
        Me.ChkIsWaterFallLock = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChkTemporaryLock = New System.Windows.Forms.CheckBox()
        Me.ChkLoadLock = New System.Windows.Forms.CheckBox()
        Me.TxtIndentLevel = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnExpansionWork = New System.Windows.Forms.Button()
        CType(Me.TxtTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCellDateFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNACellValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOwner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TxtIndentLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtTitle
        '
        Me.TxtTitle.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TxtTitle.Location = New System.Drawing.Point(86, 12)
        Me.TxtTitle.Name = "TxtTitle"
        Me.GcShortcut1.SetShortcuts(Me.TxtTitle, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.TxtTitle, Object)}, New String() {"ShortcutClear"}))
        Me.TxtTitle.Size = New System.Drawing.Size(409, 20)
        Me.TxtTitle.TabIndex = 1
        '
        'TxtCellDateFormat
        '
        Me.TxtCellDateFormat.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TxtCellDateFormat.Location = New System.Drawing.Point(105, 15)
        Me.TxtCellDateFormat.Name = "TxtCellDateFormat"
        Me.GcShortcut1.SetShortcuts(Me.TxtCellDateFormat, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.TxtCellDateFormat, Object)}, New String() {"ShortcutClear"}))
        Me.TxtCellDateFormat.Size = New System.Drawing.Size(168, 20)
        Me.TxtCellDateFormat.TabIndex = 1
        '
        'TxtNACellValue
        '
        Me.TxtNACellValue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TxtNACellValue.Location = New System.Drawing.Point(106, 41)
        Me.TxtNACellValue.Name = "TxtNACellValue"
        Me.GcShortcut1.SetShortcuts(Me.TxtNACellValue, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.TxtNACellValue, Object)}, New String() {"ShortcutClear"}))
        Me.TxtNACellValue.Size = New System.Drawing.Size(167, 20)
        Me.TxtNACellValue.TabIndex = 3
        '
        'TxtOwner
        '
        Me.TxtOwner.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TxtOwner.Location = New System.Drawing.Point(86, 40)
        Me.TxtOwner.Name = "TxtOwner"
        Me.TxtOwner.Size = New System.Drawing.Size(409, 20)
        Me.TxtOwner.TabIndex = 3
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(311, 243)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(89, 26)
        Me.BtnOK.TabIndex = 12
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(406, 243)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancel.TabIndex = 13
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "タイトル(&T)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "作成者(&W)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "ピース表示(&L)"
        '
        'CmbPieceLayout
        '
        Me.CmbPieceLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPieceLayout.FormattingEnabled = True
        Me.CmbPieceLayout.Items.AddRange(New Object() {"平行表示にしない", "自動平行表示", "常に平行表示する"})
        Me.CmbPieceLayout.Location = New System.Drawing.Point(86, 68)
        Me.CmbPieceLayout.Name = "CmbPieceLayout"
        Me.CmbPieceLayout.Size = New System.Drawing.Size(197, 20)
        Me.CmbPieceLayout.TabIndex = 5
        '
        'TxtPassword1
        '
        Me.TxtPassword1.Enabled = False
        Me.TxtPassword1.Location = New System.Drawing.Point(105, 20)
        Me.TxtPassword1.Name = "TxtPassword1"
        Me.TxtPassword1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword1.Size = New System.Drawing.Size(167, 19)
        Me.TxtPassword1.TabIndex = 3
        '
        'TxtPassword2
        '
        Me.TxtPassword2.Enabled = False
        Me.TxtPassword2.Location = New System.Drawing.Point(105, 42)
        Me.TxtPassword2.Name = "TxtPassword2"
        Me.TxtPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword2.Size = New System.Drawing.Size(167, 19)
        Me.TxtPassword2.TabIndex = 0
        '
        'ChkIsExclusion
        '
        Me.ChkIsExclusion.AutoSize = True
        Me.ChkIsExclusion.Location = New System.Drawing.Point(5, 0)
        Me.ChkIsExclusion.Name = "ChkIsExclusion"
        Me.ChkIsExclusion.Size = New System.Drawing.Size(199, 16)
        Me.ChkIsExclusion.TabIndex = 1
        Me.ChkIsExclusion.Text = "排他制御(読取専用モード)を行う(&E)"
        Me.ChkIsExclusion.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "設定パスワード(&P)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "確認パスワード(&A)"
        '
        'ChkIsWaterFall
        '
        Me.ChkIsWaterFall.AutoSize = True
        Me.ChkIsWaterFall.Location = New System.Drawing.Point(6, 18)
        Me.ChkIsWaterFall.Name = "ChkIsWaterFall"
        Me.ChkIsWaterFall.Size = New System.Drawing.Size(146, 16)
        Me.ChkIsWaterFall.TabIndex = 0
        Me.ChkIsWaterFall.Text = "関連線ピース連動する(&S)"
        Me.ChkIsWaterFall.UseVisualStyleBackColor = True
        '
        'ChkIsWaterFallLock
        '
        Me.ChkIsWaterFallLock.AutoSize = True
        Me.ChkIsWaterFallLock.Location = New System.Drawing.Point(26, 40)
        Me.ChkIsWaterFallLock.Name = "ChkIsWaterFallLock"
        Me.ChkIsWaterFallLock.Size = New System.Drawing.Size(153, 16)
        Me.ChkIsWaterFallLock.TabIndex = 1
        Me.ChkIsWaterFallLock.Text = "ロックピースは連動しない(&L)"
        Me.ChkIsWaterFallLock.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtPassword1)
        Me.GroupBox1.Controls.Add(Me.TxtPassword2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ChkIsExclusion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 68)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtCellDateFormat)
        Me.GroupBox2.Controls.Add(Me.TxtNACellValue)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(283, 67)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "セル日付書式"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 12)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "無値時表示(&N)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "日付書式(&F)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(189, 24)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "※Altを押しながら操作すると" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　　一時的に連動をキャンセル出来ます"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkIsWaterFall)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.ChkIsWaterFallLock)
        Me.GroupBox3.Location = New System.Drawing.Point(294, 68)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(201, 93)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "関係線連動"
        '
        'ChkTemporaryLock
        '
        Me.ChkTemporaryLock.AutoSize = True
        Me.ChkTemporaryLock.Location = New System.Drawing.Point(294, 170)
        Me.ChkTemporaryLock.Name = "ChkTemporaryLock"
        Me.ChkTemporaryLock.Size = New System.Drawing.Size(187, 16)
        Me.ChkTemporaryLock.TabIndex = 8
        Me.ChkTemporaryLock.Text = "移動操作以外を一時中止する(&J)"
        Me.ChkTemporaryLock.UseVisualStyleBackColor = True
        '
        'ChkLoadLock
        '
        Me.ChkLoadLock.AutoSize = True
        Me.ChkLoadLock.Location = New System.Drawing.Point(294, 190)
        Me.ChkLoadLock.Name = "ChkLoadLock"
        Me.ChkLoadLock.Size = New System.Drawing.Size(195, 16)
        Me.ChkLoadLock.TabIndex = 9
        Me.ChkLoadLock.Text = "読込時には作業Lock状態にする(&D)"
        Me.ChkLoadLock.UseVisualStyleBackColor = True
        '
        'TxtIndentLevel
        '
        Me.TxtIndentLevel.Location = New System.Drawing.Point(392, 213)
        Me.TxtIndentLevel.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.TxtIndentLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtIndentLevel.Name = "TxtIndentLevel"
        Me.TxtIndentLevel.Size = New System.Drawing.Size(73, 19)
        Me.TxtIndentLevel.TabIndex = 11
        Me.TxtIndentLevel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(294, 216)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 12)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "セルインデント幅(&I)"
        '
        'BtnExpansionWork
        '
        Me.BtnExpansionWork.Location = New System.Drawing.Point(6, 243)
        Me.BtnExpansionWork.Name = "BtnExpansionWork"
        Me.BtnExpansionWork.Size = New System.Drawing.Size(89, 26)
        Me.BtnExpansionWork.TabIndex = 14
        Me.BtnExpansionWork.Text = "拡張操作"
        Me.BtnExpansionWork.UseVisualStyleBackColor = True
        '
        'FrmSheetProperty
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(505, 276)
        Me.Controls.Add(Me.BtnExpansionWork)
        Me.Controls.Add(Me.TxtIndentLevel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ChkLoadLock)
        Me.Controls.Add(Me.ChkTemporaryLock)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CmbPieceLayout)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.TxtOwner)
        Me.Controls.Add(Me.TxtTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSheetProperty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "シートプロパティ"
        CType(Me.TxtTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCellDateFormat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNACellValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOwner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TxtIndentLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents TxtTitle As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Private WithEvents TxtOwner As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents BtnOK As System.Windows.Forms.Button
    Private WithEvents BtnCancel As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents CmbPieceLayout As System.Windows.Forms.ComboBox
    Private WithEvents TxtPassword1 As System.Windows.Forms.TextBox
    Private WithEvents TxtPassword2 As System.Windows.Forms.TextBox
    Private WithEvents ChkIsExclusion As System.Windows.Forms.CheckBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents ChkIsWaterFall As System.Windows.Forms.CheckBox
    Private WithEvents ChkIsWaterFallLock As System.Windows.Forms.CheckBox
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents TxtCellDateFormat As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents TxtNACellValue As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents ChkTemporaryLock As System.Windows.Forms.CheckBox
    Private WithEvents ChkLoadLock As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIndentLevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnExpansionWork As System.Windows.Forms.Button
End Class
