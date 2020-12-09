<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCellProperty
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCellProperty))
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.ColorPickerButton2 = New GrapeCity.Win.Common.ColorPickerButton()
        Me.DropDownButton2 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPicker_Fore = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.ColorPickerButton1 = New GrapeCity.Win.Common.ColorPickerButton()
        Me.DropDownButton1 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPicker_Back = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.Edit1 = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCom2 = New System.Windows.Forms.LinkLabel()
        Me.LblCom1 = New System.Windows.Forms.LinkLabel()
        Me.LblCom0 = New System.Windows.Forms.LinkLabel()
        Me.CmbIndent = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnToDown = New System.Windows.Forms.Button()
        Me.BtnToUp = New System.Windows.Forms.Button()
        Me.LblCom3 = New System.Windows.Forms.LinkLabel()
        Me.LblCom4 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextAlignment2 = New Windy2.UserControlTextAlignment2()
        Me.ChkBottomFormat = New System.Windows.Forms.CheckBox()
        CType(Me.ColorPicker_Fore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorPicker_Back, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(407, 138)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 28)
        Me.BtnOK.TabIndex = 9
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'ColorPickerButton2
        '
        Me.ColorPickerButton2.Name = "ColorPickerButton2"
        Me.ColorPickerButton2.UseVisualStyleBackColor = True
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'ColorPicker_Fore
        '
        Me.ColorPicker_Fore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ColorPicker_Fore.AutoSize = True
        Me.ColorPicker_Fore.Location = New System.Drawing.Point(368, 12)
        Me.ColorPicker_Fore.Name = "ColorPicker_Fore"
        Me.ColorPicker_Fore.ShowAutomaticColor = True
        Me.ColorPicker_Fore.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton2, Me.ColorPickerButton2})
        Me.ColorPicker_Fore.Size = New System.Drawing.Size(140, 20)
        Me.ColorPicker_Fore.TabIndex = 7
        '
        'ColorPickerButton1
        '
        Me.ColorPickerButton1.Name = "ColorPickerButton1"
        Me.ColorPickerButton1.UseVisualStyleBackColor = True
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'ColorPicker_Back
        '
        Me.ColorPicker_Back.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ColorPicker_Back.AutomaticColor = System.Drawing.Color.White
        Me.ColorPicker_Back.AutoSize = True
        Me.ColorPicker_Back.Location = New System.Drawing.Point(368, 39)
        Me.ColorPicker_Back.Name = "ColorPicker_Back"
        Me.ColorPicker_Back.ShowAutomaticColor = True
        Me.ColorPicker_Back.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton1, Me.ColorPickerButton1})
        Me.ColorPicker_Back.Size = New System.Drawing.Size(140, 20)
        Me.ColorPicker_Back.TabIndex = 8
        '
        'Edit1
        '
        Me.Edit1.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.Edit1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Edit1.Location = New System.Drawing.Point(12, 12)
        Me.Edit1.Multiline = True
        Me.Edit1.Name = "Edit1"
        Me.GcShortcut1.SetShortcuts(Me.Edit1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.Edit1, Object)}, New String() {"ShortcutClear"}))
        Me.Edit1.Size = New System.Drawing.Size(287, 96)
        Me.Edit1.TabIndex = 4
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(195, 114)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripMenuItem1.Text = "最小日付(コマンド)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripMenuItem2.Text = "最大日付(コマンド)"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripMenuItem3.Text = "自動行番号(コマンド)"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripMenuItem4.Text = "平均進捗率(コマンド)"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripMenuItem5.Text = "総合日数(コマンド)"
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(407, 172)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 28)
        Me.BtnCancel.TabIndex = 10
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(305, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "背景色(&B)"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(306, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 12)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "文字色(&F)"
        '
        'LblCom2
        '
        Me.LblCom2.AutoSize = True
        Me.LblCom2.Location = New System.Drawing.Point(253, 15)
        Me.LblCom2.Name = "LblCom2"
        Me.LblCom2.Size = New System.Drawing.Size(120, 12)
        Me.LblCom2.TabIndex = 15
        Me.LblCom2.TabStop = True
        Me.LblCom2.Tag = "<ROWNO>"
        Me.LblCom2.Text = "<ROWNO>:自動行番号"
        '
        'LblCom1
        '
        Me.LblCom1.AutoSize = True
        Me.LblCom1.Location = New System.Drawing.Point(126, 15)
        Me.LblCom1.Name = "LblCom1"
        Me.LblCom1.Size = New System.Drawing.Size(121, 12)
        Me.LblCom1.TabIndex = 15
        Me.LblCom1.TabStop = True
        Me.LblCom1.Tag = "<MAXDATE>"
        Me.LblCom1.Text = "<MAXDATE>:最大日付"
        '
        'LblCom0
        '
        Me.LblCom0.AutoSize = True
        Me.LblCom0.Location = New System.Drawing.Point(5, 15)
        Me.LblCom0.Name = "LblCom0"
        Me.LblCom0.Size = New System.Drawing.Size(117, 12)
        Me.LblCom0.TabIndex = 15
        Me.LblCom0.TabStop = True
        Me.LblCom0.Tag = "<MINDATE>"
        Me.LblCom0.Text = "<MINDATE>:最小日付"
        '
        'CmbIndent
        '
        Me.CmbIndent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbIndent.FormattingEnabled = True
        Me.CmbIndent.Items.AddRange(New Object() {"0-なし", "1-レベル1", "2-レベル2", "3-レベル3", "4-レベル4"})
        Me.CmbIndent.Location = New System.Drawing.Point(157, 114)
        Me.CmbIndent.Name = "CmbIndent"
        Me.CmbIndent.Size = New System.Drawing.Size(106, 20)
        Me.CmbIndent.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 12)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "インデントレベル(&I)"
        '
        'BtnToDown
        '
        Me.BtnToDown.Image = CType(resources.GetObject("BtnToDown.Image"), System.Drawing.Image)
        Me.BtnToDown.Location = New System.Drawing.Point(268, 113)
        Me.BtnToDown.Name = "BtnToDown"
        Me.BtnToDown.Size = New System.Drawing.Size(28, 23)
        Me.BtnToDown.TabIndex = 17
        Me.BtnToDown.UseVisualStyleBackColor = True
        '
        'BtnToUp
        '
        Me.BtnToUp.Image = CType(resources.GetObject("BtnToUp.Image"), System.Drawing.Image)
        Me.BtnToUp.Location = New System.Drawing.Point(123, 113)
        Me.BtnToUp.Name = "BtnToUp"
        Me.BtnToUp.Size = New System.Drawing.Size(28, 23)
        Me.BtnToUp.TabIndex = 17
        Me.BtnToUp.UseVisualStyleBackColor = True
        '
        'LblCom3
        '
        Me.LblCom3.AutoSize = True
        Me.LblCom3.Location = New System.Drawing.Point(5, 37)
        Me.LblCom3.Name = "LblCom3"
        Me.LblCom3.Size = New System.Drawing.Size(110, 12)
        Me.LblCom3.TabIndex = 18
        Me.LblCom3.TabStop = True
        Me.LblCom3.Tag = "<PROG>"
        Me.LblCom3.Text = "<PROG>:総合進捗率"
        '
        'LblCom4
        '
        Me.LblCom4.AutoSize = True
        Me.LblCom4.Location = New System.Drawing.Point(126, 37)
        Me.LblCom4.Name = "LblCom4"
        Me.LblCom4.Size = New System.Drawing.Size(114, 12)
        Me.LblCom4.TabIndex = 19
        Me.LblCom4.TabStop = True
        Me.LblCom4.Tag = "<SUMDAY>"
        Me.LblCom4.Text = "<SUMDAY>:総合日数"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblCom0)
        Me.GroupBox1.Controls.Add(Me.LblCom1)
        Me.GroupBox1.Controls.Add(Me.LblCom4)
        Me.GroupBox1.Controls.Add(Me.LblCom2)
        Me.GroupBox1.Controls.Add(Me.LblCom3)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(381, 58)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "コマンド"
        '
        'TextAlignment2
        '
        Me.TextAlignment2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextAlignment2.IsHorizon = True
        Me.TextAlignment2.Location = New System.Drawing.Point(326, 65)
        Me.TextAlignment2.Name = "TextAlignment2"
        Me.TextAlignment2.SelectedAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.TextAlignment2.Size = New System.Drawing.Size(175, 37)
        Me.TextAlignment2.TabIndex = 12
        '
        'ChkBottomFormat
        '
        Me.ChkBottomFormat.AutoSize = True
        Me.ChkBottomFormat.Location = New System.Drawing.Point(307, 108)
        Me.ChkBottomFormat.Name = "ChkBottomFormat"
        Me.ChkBottomFormat.Size = New System.Drawing.Size(166, 16)
        Me.ChkBottomFormat.TabIndex = 21
        Me.ChkBottomFormat.Text = "以下の行も同じ設定にする(&L)"
        Me.ChkBottomFormat.UseVisualStyleBackColor = True
        '
        'FrmCellProperty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(515, 209)
        Me.Controls.Add(Me.ChkBottomFormat)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnToUp)
        Me.Controls.Add(Me.BtnToDown)
        Me.Controls.Add(Me.CmbIndent)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextAlignment2)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.ColorPicker_Fore)
        Me.Controls.Add(Me.ColorPicker_Back)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Edit1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(393, 206)
        Me.Name = "FrmCellProperty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "セルプロパティ"
        CType(Me.ColorPicker_Fore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorPicker_Back, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents ColorPickerButton2 As GrapeCity.Win.Common.ColorPickerButton
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPicker_Fore As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents ColorPickerButton1 As GrapeCity.Win.Common.ColorPickerButton
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPicker_Back As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents Edit1 As GrapeCity.Win.Editors.GcTextBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents TextAlignment2 As Windy2.UserControlTextAlignment2
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblCom2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LblCom1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LblCom0 As System.Windows.Forms.LinkLabel
    Friend WithEvents CmbIndent As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnToDown As System.Windows.Forms.Button
    Friend WithEvents BtnToUp As System.Windows.Forms.Button
    Friend WithEvents LblCom3 As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblCom4 As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkBottomFormat As System.Windows.Forms.CheckBox
End Class
