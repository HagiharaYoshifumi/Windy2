<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlPiece
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
        Me.LblLeft = New iGreen.Controls.uControls.uLabelX.uLabelX()
        Me.PosiTop = New System.Windows.Forms.Label()
        Me.PosiCenter = New System.Windows.Forms.Label()
        Me.PosiBottom = New System.Windows.Forms.Label()
        Me.PosiLeft = New System.Windows.Forms.Label()
        Me.PosiRight = New System.Windows.Forms.Label()
        Me.LblRight = New iGreen.Controls.uControls.uLabelX.uLabelX()
        Me.LblCenter = New iGreen.Controls.uControls.uLabelX.uLabelX()
        Me.LblProgress = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblLeft
        '
        Me.LblLeft.BorderColor = System.Drawing.Color.Black
        Me.LblLeft.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.LblLeft.BorderStyle = iGreen.Controls.uControls.uLabelX.Common.BorderStyles.None
        Me.LblLeft.BorderWidth = 1.0!
        Me.LblLeft.Image = Nothing
        Me.LblLeft.Location = New System.Drawing.Point(13, 3)
        Me.LblLeft.Name = "LblLeft"
        Me.LblLeft.Size = New System.Drawing.Size(75, 23)
        Me.LblLeft.Text = "uLabelX1"
        Me.LblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PosiTop
        '
        Me.PosiTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PosiTop.BackColor = System.Drawing.Color.White
        Me.PosiTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PosiTop.Location = New System.Drawing.Point(109, 0)
        Me.PosiTop.Name = "PosiTop"
        Me.PosiTop.Size = New System.Drawing.Size(334, 41)
        Me.PosiTop.TabIndex = 1
        Me.PosiTop.Visible = False
        '
        'PosiCenter
        '
        Me.PosiCenter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PosiCenter.BackColor = System.Drawing.Color.Blue
        Me.PosiCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PosiCenter.Location = New System.Drawing.Point(109, 50)
        Me.PosiCenter.Name = "PosiCenter"
        Me.PosiCenter.Size = New System.Drawing.Size(334, 73)
        Me.PosiCenter.TabIndex = 1
        '
        'PosiBottom
        '
        Me.PosiBottom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PosiBottom.BackColor = System.Drawing.Color.White
        Me.PosiBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PosiBottom.Location = New System.Drawing.Point(109, 129)
        Me.PosiBottom.Name = "PosiBottom"
        Me.PosiBottom.Size = New System.Drawing.Size(334, 41)
        Me.PosiBottom.TabIndex = 1
        Me.PosiBottom.Visible = False
        '
        'PosiLeft
        '
        Me.PosiLeft.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PosiLeft.BackColor = System.Drawing.Color.White
        Me.PosiLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PosiLeft.Location = New System.Drawing.Point(3, 50)
        Me.PosiLeft.Name = "PosiLeft"
        Me.PosiLeft.Size = New System.Drawing.Size(100, 73)
        Me.PosiLeft.TabIndex = 1
        Me.PosiLeft.Visible = False
        '
        'PosiRight
        '
        Me.PosiRight.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PosiRight.BackColor = System.Drawing.Color.White
        Me.PosiRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PosiRight.Location = New System.Drawing.Point(449, 50)
        Me.PosiRight.Name = "PosiRight"
        Me.PosiRight.Size = New System.Drawing.Size(100, 73)
        Me.PosiRight.TabIndex = 1
        Me.PosiRight.Visible = False
        '
        'LblRight
        '
        Me.LblRight.BorderColor = System.Drawing.Color.Black
        Me.LblRight.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.LblRight.BorderStyle = iGreen.Controls.uControls.uLabelX.Common.BorderStyles.None
        Me.LblRight.BorderWidth = 1.0!
        Me.LblRight.Image = Nothing
        Me.LblRight.Location = New System.Drawing.Point(474, 18)
        Me.LblRight.Name = "LblRight"
        Me.LblRight.Size = New System.Drawing.Size(75, 23)
        Me.LblRight.Text = "uLabelX1"
        Me.LblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCenter
        '
        Me.LblCenter.BorderColor = System.Drawing.Color.Black
        Me.LblCenter.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.LblCenter.BorderStyle = iGreen.Controls.uControls.uLabelX.Common.BorderStyles.None
        Me.LblCenter.BorderWidth = 1.0!
        Me.LblCenter.Image = Nothing
        Me.LblCenter.Location = New System.Drawing.Point(3, 126)
        Me.LblCenter.Name = "LblCenter"
        Me.LblCenter.Size = New System.Drawing.Size(75, 23)
        Me.LblCenter.Text = "uLabelX1"
        Me.LblCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblProgress
        '
        Me.LblProgress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblProgress.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblProgress.Location = New System.Drawing.Point(109, 50)
        Me.LblProgress.Name = "LblProgress"
        Me.LblProgress.Size = New System.Drawing.Size(151, 73)
        Me.LblProgress.TabIndex = 1
        '
        'UserControlPiece
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.LblCenter)
        Me.Controls.Add(Me.LblRight)
        Me.Controls.Add(Me.LblLeft)
        Me.Controls.Add(Me.PosiRight)
        Me.Controls.Add(Me.PosiLeft)
        Me.Controls.Add(Me.PosiBottom)
        Me.Controls.Add(Me.LblProgress)
        Me.Controls.Add(Me.PosiCenter)
        Me.Controls.Add(Me.PosiTop)
        Me.Name = "UserControlPiece"
        Me.Size = New System.Drawing.Size(555, 177)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblLeft As iGreen.Controls.uControls.uLabelX.uLabelX
    Friend WithEvents PosiTop As System.Windows.Forms.Label
    Friend WithEvents PosiCenter As System.Windows.Forms.Label
    Friend WithEvents PosiBottom As System.Windows.Forms.Label
    Friend WithEvents PosiLeft As System.Windows.Forms.Label
    Friend WithEvents PosiRight As System.Windows.Forms.Label
    Friend WithEvents LblRight As iGreen.Controls.uControls.uLabelX.uLabelX
    Friend WithEvents LblCenter As iGreen.Controls.uControls.uLabelX.uLabelX
    Friend WithEvents LblProgress As System.Windows.Forms.Label

End Class
