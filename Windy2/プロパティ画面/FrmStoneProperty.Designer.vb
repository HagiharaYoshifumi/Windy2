<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStoneProperty
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStoneProperty))
        Me.CmbImage = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtLeft = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.TextAlignment_Left = New Windy2.UserControlTextAlignment2()
        Me.CmbLeftPosition = New System.Windows.Forms.ComboBox()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.TxtStartDay = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextAlignment_Right = New Windy2.UserControlTextAlignment2()
        Me.TxtRight = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.CmbRightPosition = New System.Windows.Forms.ComboBox()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.IconList = New System.Windows.Forms.ImageList(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.OptLock0 = New System.Windows.Forms.RadioButton()
        Me.OptLock2 = New System.Windows.Forms.RadioButton()
        Me.StonePreview = New Windy2.UserControlStone()
        Me.ChkSummaryExclusion = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TxtLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStartDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.TxtRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbImage
        '
        Me.CmbImage.FormattingEnabled = True
        Me.CmbImage.Location = New System.Drawing.Point(151, 53)
        Me.CmbImage.Name = "CmbImage"
        Me.CmbImage.Size = New System.Drawing.Size(100, 20)
        Me.CmbImage.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtLeft)
        Me.GroupBox1.Controls.Add(Me.TextAlignment_Left)
        Me.GroupBox1.Controls.Add(Me.CmbLeftPosition)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 121)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 155)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "左ラベル"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Tag = ""
        Me.Label7.Text = "左ラベルには日付は入りません"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "ポジション(&P)"
        '
        'TxtLeft
        '
        Me.TxtLeft.AcceptsReturn = True
        Me.TxtLeft.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TxtLeft.Location = New System.Drawing.Point(8, 84)
        Me.TxtLeft.Multiline = True
        Me.TxtLeft.Name = "TxtLeft"
        Me.GcShortcut1.SetShortcuts(Me.TxtLeft, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.TxtLeft, Object)}, New String() {"ShortcutClear"}))
        Me.TxtLeft.Size = New System.Drawing.Size(177, 46)
        Me.TxtLeft.TabIndex = 5
        '
        'TextAlignment_Left
        '
        Me.TextAlignment_Left.IsHorizon = True
        Me.TextAlignment_Left.Location = New System.Drawing.Point(6, 18)
        Me.TextAlignment_Left.Name = "TextAlignment_Left"
        Me.TextAlignment_Left.SelectedAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.TextAlignment_Left.Size = New System.Drawing.Size(175, 37)
        Me.TextAlignment_Left.TabIndex = 4
        '
        'CmbLeftPosition
        '
        Me.CmbLeftPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbLeftPosition.FormattingEnabled = True
        Me.CmbLeftPosition.Items.AddRange(New Object() {"ピースのバーの上", "ピースのバーの下", "ピースのバーの左", "ピースのバーの右"})
        Me.CmbLeftPosition.Location = New System.Drawing.Point(77, 58)
        Me.CmbLeftPosition.Name = "CmbLeftPosition"
        Me.CmbLeftPosition.Size = New System.Drawing.Size(100, 20)
        Me.CmbLeftPosition.TabIndex = 1
        '
        'TxtStartDay
        '
        Me.TxtStartDay.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        DateLiteralDisplayField1.Text = "年"
        DateMonthDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField2.Text = "月"
        DateDayDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField3.Text = "日"
        Me.TxtStartDay.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateYearDisplayField1, DateLiteralDisplayField1, DateMonthDisplayField1, DateLiteralDisplayField2, DateDayDisplayField1, DateLiteralDisplayField3})
        Me.TxtStartDay.DropDownCalendar.TrailingStyle = New GrapeCity.Win.Editors.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.Color.Silver, False, False)
        Me.TxtStartDay.DropDownCalendar.Weekdays = New GrapeCity.Win.Editors.WeekdaysStyle(New GrapeCity.Win.Editors.DayOfWeekStyle("日", GrapeCity.Win.Editors.ReflectTitle.None, New GrapeCity.Win.Editors.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.Color.Red, True, False), CType((((((GrapeCity.Win.Editors.WeekFlags.FirstWeek Or GrapeCity.Win.Editors.WeekFlags.SecondWeek) _
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
        Me.TxtStartDay.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField1, DateLiteralField1, DateMonthField1, DateLiteralField2, DateDayField1, DateLiteralField3})
        Me.TxtStartDay.Location = New System.Drawing.Point(77, 287)
        Me.TxtStartDay.Name = "TxtStartDay"
        Me.GcShortcut1.SetShortcuts(Me.TxtStartDay, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.TxtStartDay, Object), CType(Me.TxtStartDay, Object), CType(Me.TxtStartDay, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.TxtStartDay.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.TxtStartDay.Size = New System.Drawing.Size(120, 20)
        Me.TxtStartDay.TabIndex = 9
        Me.TxtStartDay.Value = New Date(2018, 3, 15, 0, 0, 0, 0)
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.LinkLabel1)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.TextAlignment_Right)
        Me.GroupBox4.Controls.Add(Me.TxtRight)
        Me.GroupBox4.Controls.Add(Me.CmbRightPosition)
        Me.GroupBox4.Location = New System.Drawing.Point(209, 121)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(189, 155)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "右ラベル"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(10, 136)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(77, 12)
        Me.LinkLabel1.TabIndex = 7
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "<DATE>"
        Me.LinkLabel1.Text = "日付：<DATE>"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "ポジション(&S)"
        '
        'TextAlignment_Right
        '
        Me.TextAlignment_Right.IsHorizon = True
        Me.TextAlignment_Right.Location = New System.Drawing.Point(6, 18)
        Me.TextAlignment_Right.Name = "TextAlignment_Right"
        Me.TextAlignment_Right.SelectedAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.TextAlignment_Right.Size = New System.Drawing.Size(175, 37)
        Me.TextAlignment_Right.TabIndex = 4
        '
        'TxtRight
        '
        Me.TxtRight.AcceptsReturn = True
        Me.TxtRight.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TxtRight.Location = New System.Drawing.Point(6, 84)
        Me.TxtRight.Multiline = True
        Me.TxtRight.Name = "TxtRight"
        Me.TxtRight.Size = New System.Drawing.Size(177, 46)
        Me.TxtRight.TabIndex = 5
        '
        'CmbRightPosition
        '
        Me.CmbRightPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbRightPosition.FormattingEnabled = True
        Me.CmbRightPosition.Items.AddRange(New Object() {"ピースのバーの上", "ピースのバーの下", "ピースのバーの左", "ピースのバーの右"})
        Me.CmbRightPosition.Location = New System.Drawing.Point(81, 58)
        Me.CmbRightPosition.Name = "CmbRightPosition"
        Me.CmbRightPosition.Size = New System.Drawing.Size(96, 20)
        Me.CmbRightPosition.TabIndex = 1
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(204, 327)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 28)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(304, 327)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 28)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'IconList
        '
        Me.IconList.ImageStream = CType(resources.GetObject("IconList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.IconList.TransparentColor = System.Drawing.Color.Fuchsia
        Me.IconList.Images.SetKeyName(0, "0.png")
        Me.IconList.Images.SetKeyName(1, "1.png")
        Me.IconList.Images.SetKeyName(2, "2.png")
        Me.IconList.Images.SetKeyName(3, "3.png")
        Me.IconList.Images.SetKeyName(4, "4.png")
        Me.IconList.Images.SetKeyName(5, "5.png")
        Me.IconList.Images.SetKeyName(6, "6.png")
        Me.IconList.Images.SetKeyName(7, "7.png")
        Me.IconList.Images.SetKeyName(8, "8.png")
        Me.IconList.Images.SetKeyName(9, "9.png")
        Me.IconList.Images.SetKeyName(10, "10.png")
        Me.IconList.Images.SetKeyName(11, "11.png")
        Me.IconList.Images.SetKeyName(12, "12.png")
        Me.IconList.Images.SetKeyName(13, "13.png")
        Me.IconList.Images.SetKeyName(14, "14.png")
        Me.IconList.Images.SetKeyName(15, "15.png")
        Me.IconList.Images.SetKeyName(16, "16.png")
        Me.IconList.Images.SetKeyName(17, "17.png")
        Me.IconList.Images.SetKeyName(18, "18.png")
        Me.IconList.Images.SetKeyName(19, "19.png")
        Me.IconList.Images.SetKeyName(20, "20.png")
        Me.IconList.Images.SetKeyName(21, "21.png")
        Me.IconList.Images.SetKeyName(22, "22.png")
        Me.IconList.Images.SetKeyName(23, "23.png")
        Me.IconList.Images.SetKeyName(24, "24.png")
        Me.IconList.Images.SetKeyName(25, "25.png")
        Me.IconList.Images.SetKeyName(26, "26.png")
        Me.IconList.Images.SetKeyName(27, "27.png")
        Me.IconList.Images.SetKeyName(28, "28.png")
        Me.IconList.Images.SetKeyName(29, "29.png")
        Me.IconList.Images.SetKeyName(30, "30.png")
        Me.IconList.Images.SetKeyName(31, "31.png")
        Me.IconList.Images.SetKeyName(32, "32.png")
        Me.IconList.Images.SetKeyName(33, "33.png")
        Me.IconList.Images.SetKeyName(34, "34.png")
        Me.IconList.Images.SetKeyName(35, "35.png")
        Me.IconList.Images.SetKeyName(36, "36.png")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 291)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Tag = ""
        Me.Label5.Text = "設置日(&S)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OptLock0)
        Me.GroupBox2.Controls.Add(Me.OptLock2)
        Me.GroupBox2.Location = New System.Drawing.Point(203, 282)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(195, 37)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ロックストーン"
        '
        'OptLock0
        '
        Me.OptLock0.AutoSize = True
        Me.OptLock0.Checked = True
        Me.OptLock0.Location = New System.Drawing.Point(7, 15)
        Me.OptLock0.Name = "OptLock0"
        Me.OptLock0.Size = New System.Drawing.Size(92, 16)
        Me.OptLock0.TabIndex = 15
        Me.OptLock0.TabStop = True
        Me.OptLock0.Text = "ロックしない(&U)"
        Me.OptLock0.UseVisualStyleBackColor = True
        '
        'OptLock2
        '
        Me.OptLock2.AutoSize = True
        Me.OptLock2.Location = New System.Drawing.Point(103, 15)
        Me.OptLock2.Name = "OptLock2"
        Me.OptLock2.Size = New System.Drawing.Size(80, 16)
        Me.OptLock2.TabIndex = 17
        Me.OptLock2.TabStop = True
        Me.OptLock2.Text = "ロックする(&L)"
        Me.OptLock2.UseVisualStyleBackColor = True
        '
        'StonePreview
        '
        Me.StonePreview.BackColor = System.Drawing.Color.White
        Me.StonePreview.CaptionLeftForeColor = System.Drawing.Color.Black
        Me.StonePreview.CaptionLeftHAlign = Windy2.UserControlStone.enumUCP_HAlign.Center
        Me.StonePreview.CaptionLeftPosition = Windy2.UserControlStone.enumUCP_Position.Left
        Me.StonePreview.CaptionLeftText = "LeftText"
        Me.StonePreview.CaptionLeftVAlign = Windy2.UserControlStone.enumUCP_VAlign.Center
        Me.StonePreview.CaptionRightForeColor = System.Drawing.Color.Black
        Me.StonePreview.CaptionRightHAlign = Windy2.UserControlStone.enumUCP_HAlign.Center
        Me.StonePreview.CaptionRightPosition = Windy2.UserControlStone.enumUCP_Position.Right
        Me.StonePreview.CaptionRightText = "RightText"
        Me.StonePreview.CaptionRightVAlign = Windy2.UserControlStone.enumUCP_VAlign.Center
        Me.StonePreview.Location = New System.Drawing.Point(12, 12)
        Me.StonePreview.Name = "StonePreview"
        Me.StonePreview.Size = New System.Drawing.Size(384, 103)
        Me.StonePreview.TabIndex = 0
        '
        'ChkSummaryExclusion
        '
        Me.ChkSummaryExclusion.AutoSize = True
        Me.ChkSummaryExclusion.Location = New System.Drawing.Point(12, 313)
        Me.ChkSummaryExclusion.Name = "ChkSummaryExclusion"
        Me.ChkSummaryExclusion.Size = New System.Drawing.Size(124, 16)
        Me.ChkSummaryExclusion.TabIndex = 24
        Me.ChkSummaryExclusion.Text = "サマリーピース集計外"
        Me.ChkSummaryExclusion.UseVisualStyleBackColor = True
        '
        'FrmStoneProperty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(408, 364)
        Me.Controls.Add(Me.ChkSummaryExclusion)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtStartDay)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CmbImage)
        Me.Controls.Add(Me.StonePreview)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmStoneProperty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "マイルストーンプロパティ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TxtLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStartDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TxtRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StonePreview As Windy2.UserControlStone
    Friend WithEvents CmbImage As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtLeft As GrapeCity.Win.Editors.GcTextBox
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents CmbLeftPosition As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRight As GrapeCity.Win.Editors.GcTextBox
    Friend WithEvents CmbRightPosition As System.Windows.Forms.ComboBox
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents IconList As System.Windows.Forms.ImageList
    Friend WithEvents TextAlignment_Left As Windy2.UserControlTextAlignment2
    Friend WithEvents TextAlignment_Right As Windy2.UserControlTextAlignment2
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtStartDay As GrapeCity.Win.Editors.GcDate
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptLock0 As System.Windows.Forms.RadioButton
    Friend WithEvents OptLock2 As System.Windows.Forms.RadioButton
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents ChkSummaryExclusion As System.Windows.Forms.CheckBox
End Class
