<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlStone
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
        Me.LblRight = New iGreen.Controls.uControls.uLabelX.uLabelX()
        Me.PosiTop = New iGreen.Controls.uControls.uLabelX.uLabelX()
        Me.PosiLeft = New iGreen.Controls.uControls.uLabelX.uLabelX()
        Me.PosiRight = New iGreen.Controls.uControls.uLabelX.uLabelX()
        Me.PosiBottom = New iGreen.Controls.uControls.uLabelX.uLabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblLeft
        '
        Me.LblLeft.BorderColor = System.Drawing.Color.Black
        Me.LblLeft.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.LblLeft.BorderStyle = iGreen.Controls.uControls.uLabelX.Common.BorderStyles.None
        Me.LblLeft.BorderWidth = 1.0!
        Me.LblLeft.Image = Nothing
        Me.LblLeft.Location = New System.Drawing.Point(5, 5)
        Me.LblLeft.Name = "LblLeft"
        Me.LblLeft.Size = New System.Drawing.Size(75, 23)
        Me.LblLeft.Text = "uLabelX1"
        Me.LblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblRight
        '
        Me.LblRight.BorderColor = System.Drawing.Color.Black
        Me.LblRight.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.LblRight.BorderStyle = iGreen.Controls.uControls.uLabelX.Common.BorderStyles.None
        Me.LblRight.BorderWidth = 1.0!
        Me.LblRight.Image = Nothing
        Me.LblRight.Location = New System.Drawing.Point(5, 34)
        Me.LblRight.Name = "LblRight"
        Me.LblRight.Size = New System.Drawing.Size(75, 31)
        Me.LblRight.Text = "uLabelX1"
        Me.LblRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PosiTop
        '
        Me.PosiTop.BorderColor = System.Drawing.Color.Black
        Me.PosiTop.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.PosiTop.BorderStyle = iGreen.Controls.uControls.uLabelX.Common.BorderStyles.None
        Me.PosiTop.BorderWidth = 1.0!
        Me.PosiTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PosiTop.Image = Nothing
        Me.PosiTop.Location = New System.Drawing.Point(105, 0)
        Me.PosiTop.Margin = New System.Windows.Forms.Padding(0)
        Me.PosiTop.Name = "PosiTop"
        Me.PosiTop.Size = New System.Drawing.Size(90, 36)
        Me.PosiTop.Text = Nothing
        Me.PosiTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PosiLeft
        '
        Me.PosiLeft.BorderColor = System.Drawing.Color.Black
        Me.PosiLeft.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.PosiLeft.BorderStyle = iGreen.Controls.uControls.uLabelX.Common.BorderStyles.None
        Me.PosiLeft.BorderWidth = 1.0!
        Me.PosiLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PosiLeft.Image = Nothing
        Me.PosiLeft.Location = New System.Drawing.Point(0, 36)
        Me.PosiLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.PosiLeft.Name = "PosiLeft"
        Me.PosiLeft.Size = New System.Drawing.Size(105, 48)
        Me.PosiLeft.Text = Nothing
        Me.PosiLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PosiRight
        '
        Me.PosiRight.BorderColor = System.Drawing.Color.Black
        Me.PosiRight.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.PosiRight.BorderStyle = iGreen.Controls.uControls.uLabelX.Common.BorderStyles.None
        Me.PosiRight.BorderWidth = 1.0!
        Me.PosiRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PosiRight.Image = Nothing
        Me.PosiRight.Location = New System.Drawing.Point(195, 36)
        Me.PosiRight.Margin = New System.Windows.Forms.Padding(0)
        Me.PosiRight.Name = "PosiRight"
        Me.PosiRight.Size = New System.Drawing.Size(105, 48)
        Me.PosiRight.Text = Nothing
        Me.PosiRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PosiBottom
        '
        Me.PosiBottom.BorderColor = System.Drawing.Color.Black
        Me.PosiBottom.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.PosiBottom.BorderStyle = iGreen.Controls.uControls.uLabelX.Common.BorderStyles.None
        Me.PosiBottom.BorderWidth = 1.0!
        Me.PosiBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PosiBottom.Image = Nothing
        Me.PosiBottom.Location = New System.Drawing.Point(105, 84)
        Me.PosiBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.PosiBottom.Name = "PosiBottom"
        Me.PosiBottom.Size = New System.Drawing.Size(90, 36)
        Me.PosiBottom.Text = Nothing
        Me.PosiBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PosiTop, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PosiLeft, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PosiBottom, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PosiRight, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(300, 120)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'UserControlStone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.LblRight)
        Me.Controls.Add(Me.LblLeft)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "UserControlStone"
        Me.Size = New System.Drawing.Size(300, 120)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblLeft As iGreen.Controls.uControls.uLabelX.uLabelX
    Friend WithEvents LblRight As iGreen.Controls.uControls.uLabelX.uLabelX
    Friend WithEvents PosiTop As iGreen.Controls.uControls.uLabelX.uLabelX
    Friend WithEvents PosiLeft As iGreen.Controls.uControls.uLabelX.uLabelX
    Friend WithEvents PosiRight As iGreen.Controls.uControls.uLabelX.uLabelX
    Friend WithEvents PosiBottom As iGreen.Controls.uControls.uLabelX.uLabelX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class
