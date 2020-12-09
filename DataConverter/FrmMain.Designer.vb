<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.TxtWindyFile = New System.Windows.Forms.TextBox()
        Me.BtnToXml = New System.Windows.Forms.Button()
        Me.TxtXMLFile = New System.Windows.Forms.TextBox()
        Me.BtnToWindy = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuAPPEnd = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtWindyFile
        '
        Me.TxtWindyFile.AllowDrop = True
        Me.TxtWindyFile.Location = New System.Drawing.Point(115, 31)
        Me.TxtWindyFile.Name = "TxtWindyFile"
        Me.TxtWindyFile.Size = New System.Drawing.Size(342, 19)
        Me.TxtWindyFile.TabIndex = 0
        '
        'BtnToXml
        '
        Me.BtnToXml.Location = New System.Drawing.Point(115, 56)
        Me.BtnToXml.Name = "BtnToXml"
        Me.BtnToXml.Size = New System.Drawing.Size(166, 33)
        Me.BtnToXml.TabIndex = 1
        Me.BtnToXml.Text = "↓XMLファイルに変換する"
        Me.BtnToXml.UseVisualStyleBackColor = True
        '
        'TxtXMLFile
        '
        Me.TxtXMLFile.AllowDrop = True
        Me.TxtXMLFile.Location = New System.Drawing.Point(115, 95)
        Me.TxtXMLFile.Name = "TxtXMLFile"
        Me.TxtXMLFile.Size = New System.Drawing.Size(342, 19)
        Me.TxtXMLFile.TabIndex = 0
        '
        'BtnToWindy
        '
        Me.BtnToWindy.Location = New System.Drawing.Point(291, 56)
        Me.BtnToWindy.Name = "BtnToWindy"
        Me.BtnToWindy.Size = New System.Drawing.Size(166, 33)
        Me.BtnToWindy.TabIndex = 1
        Me.BtnToWindy.Text = "↑Windyファイルに変換する"
        Me.BtnToWindy.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAPPEnd})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(481, 26)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuAPPEnd
        '
        Me.MenuAPPEnd.Name = "MenuAPPEnd"
        Me.MenuAPPEnd.Size = New System.Drawing.Size(62, 22)
        Me.MenuAPPEnd.Text = "終了(&X)"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 126)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(481, 23)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Windyデータファイル"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "XMLデータファイル"
        '
        'LblMessage
        '
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(12, 18)
        Me.LblMessage.Text = "."
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 149)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnToWindy)
        Me.Controls.Add(Me.BtnToXml)
        Me.Controls.Add(Me.TxtXMLFile)
        Me.Controls.Add(Me.TxtWindyFile)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMain"
        Me.Text = "Windyデータコンバーター"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtWindyFile As System.Windows.Forms.TextBox
    Friend WithEvents BtnToXml As System.Windows.Forms.Button
    Friend WithEvents TxtXMLFile As System.Windows.Forms.TextBox
    Friend WithEvents BtnToWindy As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MenuAPPEnd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblMessage As System.Windows.Forms.ToolStripStatusLabel

End Class
