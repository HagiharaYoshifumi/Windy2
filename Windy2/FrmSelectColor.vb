Public Class FrmSelectColor
    Property SelectColor As Color

    Private Sub FrmSelectColor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmSelectColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _SelectColor = Nothing Then
            _SelectColor = Color.White
        End If
        ColorPicker_SelColor.SelectedColor = _SelectColor
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        _SelectColor = ColorPicker_SelColor.SelectedColor
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class