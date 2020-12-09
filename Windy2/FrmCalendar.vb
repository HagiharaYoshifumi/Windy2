Public Class FrmCalendar


#Region "Property"
    ''' <summary>
    ''' 選択された日付
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SelectedDate() As Date

#End Region

    Private Sub FrmCalendar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmCalendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GcCalendar1.SelectedDate = _SelectedDate
        GcCalendar1.FocusDate = _SelectedDate
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        _SelectedDate = GcCalendar1.SelectedDate
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub


    Private Sub GcCalendar1_ClickDate(sender As Object, e As GrapeCity.Win.Calendar.ClickDateEventArgs) Handles GcCalendar1.ClickDate
        _SelectedDate = e.Date
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class