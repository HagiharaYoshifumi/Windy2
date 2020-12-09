''' <summary>
''' バルーンプロパティ
''' </summary>
''' <remarks></remarks>
Public Class FrmBalloonnProperty
    Dim FC As New ClassFormControl
#Region "Property"
    ''' <summary>
    ''' バルーン文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property BalloonText() As String
    ''' <summary>
    ''' 背景色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property BalloonBackColor() As System.UInt32
    ''' <summary>
    ''' 文字色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property BalloonForeColor() As System.UInt32
    ''' <summary>
    ''' 文字配置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property BalloonTextAlign() As ContentAlignment
#End Region
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmEditHeaderCell_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmBalloonnProperty_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If FC.Edited Then
            If MsgBox("変更を保存せずに閉じてもいいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmEditHeaderCell_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FC.TargetForm = Me
        FC.Title = Me.Text
        Try
            Edit1.Text = _BalloonText
            Edit1.BackColor = ConvertColorValue(_BalloonBackColor)
            ColorPicker_BackColor.SelectedColor = ConvertColorValue(_BalloonBackColor)
            Edit1.ForeColor = ConvertColorValue(_BalloonForeColor)
            ColorPicker_ForeColor.SelectedColor = ConvertColorValue(_BalloonForeColor)
            Edit1.ContentAlignment = _BalloonTextAlign
            TextAlignment.SelectedAlignment = _BalloonTextAlign

            If ColorPicker_BackColor.SelectedColor = Color.Empty Then
                ColorPicker_BackColor.SelectedColor = ColorPicker_BackColor.AutomaticColor
            End If
            If ColorPicker_ForeColor.SelectedColor = Color.Empty Then
                ColorPicker_ForeColor.SelectedColor = ColorPicker_ForeColor.AutomaticColor
            End If

        Catch ex As Exception
            Logs.PutErrorEx("ロードエラー", ex)
        End Try

        FC.ScanTargetControl()
        FC.Edited = False
    End Sub
    ''' <summary>
    ''' キャンセルボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' ＯＫボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        _BalloonText = Edit1.Text
        _BalloonBackColor = ConvertColorValue(Edit1.BackColor)
        _BalloonForeColor = ConvertColorValue(Edit1.ForeColor)

        _BalloonTextAlign = Edit1.ContentAlignment
        FC.Edited = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    ''' <summary>
    ''' 背景色が変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ColorPicker_BackColor_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPicker_BackColor.SelectedColorChanged
        Edit1.BackColor = ColorPicker_BackColor.SelectedColor
        ColorPicker_ForeColor.AutomaticColor = ToBackColor(Edit1.BackColor)
    End Sub
    ''' <summary>
    ''' 文字色が変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ColorPicker_ForeColor_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPicker_ForeColor.SelectedColorChanged
        Edit1.ForeColor = ColorPicker_ForeColor.SelectedColor
    End Sub
    ''' <summary>
    ''' 文字位置が変更された
    ''' </summary>
    ''' <param name="SelectdAlig"></param>
    ''' <param name="HAlign"></param>
    ''' <param name="VAlign"></param>
    ''' <remarks></remarks>
    Private Sub TextAlignment_AlignmentChaned(SelectdAlig As ContentAlignment, HAlign As Integer, VAlign As Integer) Handles TextAlignment.AlignmentChaned
        Edit1.ContentAlignment = SelectdAlig
    End Sub

End Class