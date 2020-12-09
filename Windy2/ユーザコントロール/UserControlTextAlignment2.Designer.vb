<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlTextAlignment2
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControlTextAlignment2))
        Me.OptH2 = New GrapeCity.Win.Buttons.GcRadioButton()
        Me.OptH1 = New GrapeCity.Win.Buttons.GcRadioButton()
        Me.OptH0 = New GrapeCity.Win.Buttons.GcRadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.OptV0 = New GrapeCity.Win.Buttons.GcRadioButton()
        Me.OptV1 = New GrapeCity.Win.Buttons.GcRadioButton()
        Me.OptV2 = New GrapeCity.Win.Buttons.GcRadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OptH2
        '
        Me.OptH2.Appearance = System.Windows.Forms.Appearance.Button
        Me.OptH2.CheckMarkSize = New System.Drawing.Size(13, 13)
        Me.OptH2.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Professional
        Me.OptH2.Image = CType(resources.GetObject("OptH2.Image"), System.Drawing.Image)
        Me.OptH2.Location = New System.Drawing.Point(56, 11)
        Me.OptH2.Name = "OptH2"
        Me.OptH2.Size = New System.Drawing.Size(25, 25)
        Me.OptH2.TabIndex = 4
        Me.OptH2.Tag = "4"
        Me.OptH2.UseVisualStyleBackColor = True
        '
        'OptH1
        '
        Me.OptH1.Appearance = System.Windows.Forms.Appearance.Button
        Me.OptH1.CheckMarkSize = New System.Drawing.Size(13, 13)
        Me.OptH1.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Professional
        Me.OptH1.Image = CType(resources.GetObject("OptH1.Image"), System.Drawing.Image)
        Me.OptH1.Location = New System.Drawing.Point(31, 11)
        Me.OptH1.Name = "OptH1"
        Me.OptH1.Size = New System.Drawing.Size(25, 25)
        Me.OptH1.TabIndex = 7
        Me.OptH1.Tag = "2"
        Me.OptH1.UseVisualStyleBackColor = True
        '
        'OptH0
        '
        Me.OptH0.Appearance = System.Windows.Forms.Appearance.Button
        Me.OptH0.Checked = True
        Me.OptH0.CheckMarkSize = New System.Drawing.Size(13, 13)
        Me.OptH0.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Professional
        Me.OptH0.Image = CType(resources.GetObject("OptH0.Image"), System.Drawing.Image)
        Me.OptH0.Location = New System.Drawing.Point(6, 11)
        Me.OptH0.Name = "OptH0"
        Me.OptH0.Size = New System.Drawing.Size(25, 25)
        Me.OptH0.TabIndex = 10
        Me.OptH0.TabStop = True
        Me.OptH0.Tag = "1"
        Me.OptH0.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptH0)
        Me.GroupBox1.Controls.Add(Me.OptH1)
        Me.GroupBox1.Controls.Add(Me.OptH2)
        Me.GroupBox1.Location = New System.Drawing.Point(0, -5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(85, 41)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OptV0)
        Me.GroupBox2.Controls.Add(Me.OptV1)
        Me.GroupBox2.Controls.Add(Me.OptV2)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(85, 41)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'OptV0
        '
        Me.OptV0.Appearance = System.Windows.Forms.Appearance.Button
        Me.OptV0.Checked = True
        Me.OptV0.CheckMarkSize = New System.Drawing.Size(13, 13)
        Me.OptV0.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Professional
        Me.OptV0.Image = CType(resources.GetObject("OptV0.Image"), System.Drawing.Image)
        Me.OptV0.Location = New System.Drawing.Point(6, 11)
        Me.OptV0.Name = "OptV0"
        Me.OptV0.Size = New System.Drawing.Size(25, 25)
        Me.OptV0.TabIndex = 10
        Me.OptV0.TabStop = True
        Me.OptV0.Tag = "1"
        Me.OptV0.UseVisualStyleBackColor = True
        '
        'OptV1
        '
        Me.OptV1.Appearance = System.Windows.Forms.Appearance.Button
        Me.OptV1.CheckMarkSize = New System.Drawing.Size(13, 13)
        Me.OptV1.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Professional
        Me.OptV1.Image = CType(resources.GetObject("OptV1.Image"), System.Drawing.Image)
        Me.OptV1.Location = New System.Drawing.Point(31, 11)
        Me.OptV1.Name = "OptV1"
        Me.OptV1.Size = New System.Drawing.Size(25, 25)
        Me.OptV1.TabIndex = 7
        Me.OptV1.Tag = "2"
        Me.OptV1.UseVisualStyleBackColor = True
        '
        'OptV2
        '
        Me.OptV2.Appearance = System.Windows.Forms.Appearance.Button
        Me.OptV2.CheckMarkSize = New System.Drawing.Size(13, 13)
        Me.OptV2.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Professional
        Me.OptV2.Image = CType(resources.GetObject("OptV2.Image"), System.Drawing.Image)
        Me.OptV2.Location = New System.Drawing.Point(56, 11)
        Me.OptV2.Name = "OptV2"
        Me.OptV2.Size = New System.Drawing.Size(25, 25)
        Me.OptV2.TabIndex = 4
        Me.OptV2.Tag = "4"
        Me.OptV2.UseVisualStyleBackColor = True
        '
        'UserControlTextAlignment2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "UserControlTextAlignment2"
        Me.Size = New System.Drawing.Size(87, 74)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents OptH2 As GrapeCity.Win.Buttons.GcRadioButton
    Private WithEvents OptH1 As GrapeCity.Win.Buttons.GcRadioButton
    Private WithEvents OptH0 As GrapeCity.Win.Buttons.GcRadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents OptV0 As GrapeCity.Win.Buttons.GcRadioButton
    Private WithEvents OptV1 As GrapeCity.Win.Buttons.GcRadioButton
    Private WithEvents OptV2 As GrapeCity.Win.Buttons.GcRadioButton

End Class
