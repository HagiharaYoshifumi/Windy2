Public Class FrmAutoNumber
    Property IsNomal As Integer

    Private Sub FrmAutoNumber_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmAutoNumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Select Case True
            Case OptFrontZero.Checked : _IsNomal = 1
            Case OptAutoNo.Checked : _IsNomal = 2
            Case Else : _IsNomal = 0
        End Select
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class