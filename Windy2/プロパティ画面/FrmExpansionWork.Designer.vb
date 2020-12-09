<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExpansionWork
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
        Dim DateYearDisplayField1 As GrapeCity.Win.Editors.Fields.DateYearDisplayField = New GrapeCity.Win.Editors.Fields.DateYearDisplayField()
        Dim DateLiteralDisplayField1 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField1 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField2 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField1 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateLiteralDisplayField3 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateYearField1 As GrapeCity.Win.Editors.Fields.DateYearField = New GrapeCity.Win.Editors.Fields.DateYearField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Me.BtnPieceDel = New System.Windows.Forms.Button()
        Me.BtnEmptyRow = New System.Windows.Forms.Button()
        Me.ChkCellText = New System.Windows.Forms.CheckBox()
        Me.TxtDay = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        CType(Me.TxtDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnPieceDel
        '
        Me.BtnPieceDel.Location = New System.Drawing.Point(207, 34)
        Me.BtnPieceDel.Name = "BtnPieceDel"
        Me.BtnPieceDel.Size = New System.Drawing.Size(152, 35)
        Me.BtnPieceDel.TabIndex = 0
        Me.BtnPieceDel.Text = "対象ピースの削除(&P)"
        Me.BtnPieceDel.UseVisualStyleBackColor = True
        '
        'BtnEmptyRow
        '
        Me.BtnEmptyRow.Location = New System.Drawing.Point(207, 18)
        Me.BtnEmptyRow.Name = "BtnEmptyRow"
        Me.BtnEmptyRow.Size = New System.Drawing.Size(152, 35)
        Me.BtnEmptyRow.TabIndex = 1
        Me.BtnEmptyRow.Text = "対象行の削除(&R)"
        Me.BtnEmptyRow.UseVisualStyleBackColor = True
        '
        'ChkCellText
        '
        Me.ChkCellText.AutoSize = True
        Me.ChkCellText.Location = New System.Drawing.Point(8, 28)
        Me.ChkCellText.Name = "ChkCellText"
        Me.ChkCellText.Size = New System.Drawing.Size(168, 16)
        Me.ChkCellText.TabIndex = 2
        Me.ChkCellText.Text = "セルに文字が入っていても削除"
        Me.ChkCellText.UseVisualStyleBackColor = True
        '
        'TxtDay
        '
        Me.TxtDay.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        DateLiteralDisplayField1.Text = "年"
        DateMonthDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField2.Text = "月"
        DateDayDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField3.Text = "日"
        Me.TxtDay.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateYearDisplayField1, DateLiteralDisplayField1, DateMonthDisplayField1, DateLiteralDisplayField2, DateDayDisplayField1, DateLiteralDisplayField3})
        Me.TxtDay.DropDownCalendar.TrailingStyle = New GrapeCity.Win.Editors.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.Color.Silver, False, False)
        Me.TxtDay.DropDownCalendar.Weekdays = New GrapeCity.Win.Editors.WeekdaysStyle(New GrapeCity.Win.Editors.DayOfWeekStyle("日", GrapeCity.Win.Editors.ReflectTitle.None, New GrapeCity.Win.Editors.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.Color.Red, True, False), CType((((((GrapeCity.Win.Editors.WeekFlags.FirstWeek Or GrapeCity.Win.Editors.WeekFlags.SecondWeek) _
                    Or GrapeCity.Win.Editors.WeekFlags.ThirdWeek) _
                    Or GrapeCity.Win.Editors.WeekFlags.FourthWeek) _
                    Or GrapeCity.Win.Editors.WeekFlags.FifthWeek) _
                    Or GrapeCity.Win.Editors.WeekFlags.LastWeek), GrapeCity.Win.Editors.WeekFlags)), New GrapeCity.Win.Editors.DayOfWeekStyle("月", GrapeCity.Win.Editors.ReflectTitle.None, New GrapeCity.Win.Editors.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, False, False), GrapeCity.Win.Editors.WeekFlags.None), New GrapeCity.Win.Editors.DayOfWeekStyle("火", GrapeCity.Win.Editors.ReflectTitle.None, New GrapeCity.Win.Editors.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, False, False), GrapeCity.Win.Editors.WeekFlags.None), New GrapeCity.Win.Editors.DayOfWeekStyle("水", GrapeCity.Win.Editors.ReflectTitle.None, New GrapeCity.Win.Editors.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, False, False), GrapeCity.Win.Editors.WeekFlags.None), New GrapeCity.Win.Editors.DayOfWeekStyle("木", GrapeCity.Win.Editors.ReflectTitle.None, New GrapeCity.Win.Editors.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, False, False), GrapeCity.Win.Editors.WeekFlags.None), New GrapeCity.Win.Editors.DayOfWeekStyle("金", GrapeCity.Win.Editors.ReflectTitle.None, New GrapeCity.Win.Editors.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, False, False), GrapeCity.Win.Editors.WeekFlags.None), New GrapeCity.Win.Editors.DayOfWeekStyle("土", GrapeCity.Win.Editors.ReflectTitle.None, New GrapeCity.Win.Editors.SubStyle(System.Drawing.Color.White, System.Drawing.Color.Blue, True, False), CType((((((GrapeCity.Win.Editors.WeekFlags.FirstWeek Or GrapeCity.Win.Editors.WeekFlags.SecondWeek) _
                    Or GrapeCity.Win.Editors.WeekFlags.ThirdWeek) _
                    Or GrapeCity.Win.Editors.WeekFlags.FourthWeek) _
                    Or GrapeCity.Win.Editors.WeekFlags.FifthWeek) _
                    Or GrapeCity.Win.Editors.WeekFlags.LastWeek), GrapeCity.Win.Editors.WeekFlags)))
        DateLiteralField1.Text = "年"
        DateLiteralField2.Text = "月"
        DateLiteralField3.Text = "日"
        Me.TxtDay.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField1, DateLiteralField1, DateMonthField1, DateLiteralField2, DateDayField1, DateLiteralField3})
        Me.TxtDay.Location = New System.Drawing.Point(8, 41)
        Me.TxtDay.Name = "TxtDay"
        Me.TxtDay.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.TxtDay.Size = New System.Drawing.Size(120, 20)
        Me.TxtDay.TabIndex = 7
        Me.TxtDay.Value = Nothing
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkCellText)
        Me.GroupBox1.Controls.Add(Me.BtnEmptyRow)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 100)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(369, 70)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ピース・ストーン未設置行の削除"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TxtDay)
        Me.GroupBox2.Controls.Add(Me.BtnPieceDel)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 82)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "指定日以前ピース削除"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(134, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "以前のピース"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "削除対象日付(&D)"
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(292, 176)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(89, 32)
        Me.BtnClose.TabIndex = 9
        Me.BtnClose.Text = "閉じる(&C)"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'FrmExpansionWork
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 219)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmExpansionWork"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "拡張アイテム削除"
        CType(Me.TxtDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnPieceDel As System.Windows.Forms.Button
    Friend WithEvents BtnEmptyRow As System.Windows.Forms.Button
    Friend WithEvents ChkCellText As System.Windows.Forms.CheckBox
    Friend WithEvents TxtDay As GrapeCity.Win.Editors.GcDate
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
End Class
