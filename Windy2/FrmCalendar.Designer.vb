<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCalendar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCalendar))
        Me.GcCalendar1 = New GrapeCity.Win.Calendar.GcCalendar()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.GcCalendar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GcCalendar1
        '
        Me.GcCalendar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GcCalendar1.Location = New System.Drawing.Point(0, 0)
        Me.GcCalendar1.Name = "GcCalendar1"
        Me.GcCalendar1.Size = New System.Drawing.Size(238, 219)
        Me.GcCalendar1.TabIndex = 0
        Me.GcCalendar1.TitleStyle = New GrapeCity.Win.Calendar.Style(System.Drawing.SystemColors.Window, New GrapeCity.Win.Common.Bevel(System.Drawing.SystemColors.Control, 0, 25, -25), System.Drawing.SystemColors.WindowFrame, System.Windows.Forms.BorderStyle.None, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte)), GrapeCity.Win.Common.TextEffect.Flat, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, GrapeCity.Win.Calendar.AlignHorizontal.Right, GrapeCity.Win.Calendar.AlignVertical.Middle)
        Me.GcCalendar1.Weekdays = New GrapeCity.Win.Calendar.WeekdaysStyle(New GrapeCity.Win.Calendar.DayOfWeekStyle("日", GrapeCity.Win.Calendar.ReflectTitle.Both, New GrapeCity.Win.Calendar.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.Color.Red, System.Drawing.Color.Empty, False, False), CType((((((GrapeCity.Win.Calendar.WeekFlags.FirstWeek Or GrapeCity.Win.Calendar.WeekFlags.SecondWeek) _
                    Or GrapeCity.Win.Calendar.WeekFlags.ThirdWeek) _
                    Or GrapeCity.Win.Calendar.WeekFlags.FourthWeek) _
                    Or GrapeCity.Win.Calendar.WeekFlags.FifthWeek) _
                    Or GrapeCity.Win.Calendar.WeekFlags.LastWeek), GrapeCity.Win.Calendar.WeekFlags)), New GrapeCity.Win.Calendar.DayOfWeekStyle("月", GrapeCity.Win.Calendar.ReflectTitle.None, New GrapeCity.Win.Calendar.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, False, False), GrapeCity.Win.Calendar.WeekFlags.None), New GrapeCity.Win.Calendar.DayOfWeekStyle("火", GrapeCity.Win.Calendar.ReflectTitle.None, New GrapeCity.Win.Calendar.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, False, False), GrapeCity.Win.Calendar.WeekFlags.None), New GrapeCity.Win.Calendar.DayOfWeekStyle("水", GrapeCity.Win.Calendar.ReflectTitle.None, New GrapeCity.Win.Calendar.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, False, False), GrapeCity.Win.Calendar.WeekFlags.None), New GrapeCity.Win.Calendar.DayOfWeekStyle("木", GrapeCity.Win.Calendar.ReflectTitle.None, New GrapeCity.Win.Calendar.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, False, False), GrapeCity.Win.Calendar.WeekFlags.None), New GrapeCity.Win.Calendar.DayOfWeekStyle("金", GrapeCity.Win.Calendar.ReflectTitle.None, New GrapeCity.Win.Calendar.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, False, False), GrapeCity.Win.Calendar.WeekFlags.None), New GrapeCity.Win.Calendar.DayOfWeekStyle("土", GrapeCity.Win.Calendar.ReflectTitle.Both, New GrapeCity.Win.Calendar.SubStyle(System.Drawing.SystemColors.Window, System.Drawing.Color.Blue, System.Drawing.Color.Empty, False, False), CType((((((GrapeCity.Win.Calendar.WeekFlags.FirstWeek Or GrapeCity.Win.Calendar.WeekFlags.SecondWeek) _
                    Or GrapeCity.Win.Calendar.WeekFlags.ThirdWeek) _
                    Or GrapeCity.Win.Calendar.WeekFlags.FourthWeek) _
                    Or GrapeCity.Win.Calendar.WeekFlags.FifthWeek) _
                    Or GrapeCity.Win.Calendar.WeekFlags.LastWeek), GrapeCity.Win.Calendar.WeekFlags)))
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Location = New System.Drawing.Point(49, 6)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(89, 26)
        Me.BtnOK.TabIndex = 1
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(144, 6)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnCancel)
        Me.Panel1.Controls.Add(Me.BtnOK)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 219)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(238, 38)
        Me.Panel1.TabIndex = 2
        '
        'FrmCalendar
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(238, 257)
        Me.Controls.Add(Me.GcCalendar1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCalendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "カレンダー"
        CType(Me.GcCalendar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GcCalendar1 As GrapeCity.Win.Calendar.GcCalendar
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
