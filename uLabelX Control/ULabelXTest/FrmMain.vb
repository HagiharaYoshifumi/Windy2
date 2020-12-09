Imports System.Drawing.Drawing2D
Imports iGreen.Controls.uControls.uLabelX

Public Class FrmMain

    Private Sub FrmMain_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim _LBrush As LinearGradientBrush = New LinearGradientBrush(Me.ClientRectangle, Color.Red, Color.Yellow, LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(_LBrush, Me.ClientRectangle)
    End Sub

    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint, Panel2.Paint
        Dim ObjPanel As Panel = CType(sender, Panel)
        Dim _LBrush As LinearGradientBrush = New LinearGradientBrush(ObjPanel.ClientRectangle, ObjPanel.BackColor, Color.Pink, LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(_LBrush, ObjPanel.ClientRectangle)
        e.Graphics.DrawString(ObjPanel.Name, ObjPanel.Font, Brushes.Black, 5, 5)
    End Sub
End Class
