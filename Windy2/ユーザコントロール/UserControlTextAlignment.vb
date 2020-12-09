Imports System.ComponentModel
<DefaultEvent("AlignmentChaned")> _
Public Class UserControlTextAlignment
    Dim _SelectnAlignment As ContentAlignment

    ''' <summary>
    ''' 選択位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SelectedAlignment() As ContentAlignment
        Get
            Return SeekButton()
        End Get
        Set(ByVal value As ContentAlignment)
            Select Case value
                Case ContentAlignment.TopLeft : OptButton1.Checked = True
                Case ContentAlignment.TopCenter : OptButton2.Checked = True
                Case ContentAlignment.TopRight : OptButton4.Checked = True
                Case ContentAlignment.MiddleLeft : OptButton16.Checked = True
                Case ContentAlignment.MiddleCenter : OptButton32.Checked = True
                Case ContentAlignment.MiddleRight : OptButton64.Checked = True
                Case ContentAlignment.BottomLeft : OptButton256.Checked = True
                Case ContentAlignment.BottomCenter : OptButton512.Checked = True
                Case Else : OptButton1024.Checked = True
            End Select
        End Set
    End Property
    ''' <summary>
    ''' 現在の選択位置を取得する
    ''' </summary>
    ''' <returns>選択位置</returns>
    ''' <remarks></remarks>
    Private Function SeekButton() As ContentAlignment
        Dim buf As ArrayList = New ArrayList
        For Each c As Control In Me.Controls
            If TypeOf c Is GrapeCity.Win.Buttons.GcRadioButton Then
                Dim Obj As GrapeCity.Win.Buttons.GcRadioButton = c
                If Obj.Checked Then
                    Return CInt(Obj.Tag)
                End If
            End If
        Next

        Return 0
    End Function
    Public Event AlignmentChaned(SelectdAlignment As ContentAlignment)
    ''' <summary>
    ''' 位置が選択された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OptionChanged(sender As Object, e As EventArgs) Handles OptButton1.CheckedChanged, OptButton1024.CheckedChanged, OptButton16.CheckedChanged, OptButton2.CheckedChanged, OptButton256.CheckedChanged, OptButton32.CheckedChanged, OptButton4.CheckedChanged, OptButton512.CheckedChanged, OptButton64.CheckedChanged
        RaiseEvent AlignmentChaned(SeekButton)

    End Sub
End Class
