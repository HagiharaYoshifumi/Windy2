''' <summary>
''' 列ヘッダープロパティ
''' </summary>
''' <remarks></remarks>
Public Class FrmColumnHeaderProperty
    Dim FC As New ClassFormControl
#Region "Property"
    ''' <summary>
    ''' ヘッダ文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property HeaderText() As String
    ''' <summary>
    ''' 文字配置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property HeaderTextAlign() As Integer
    ''' <summary>
    ''' ヘッダ列番号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property HeaderColNo As Integer
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
    Private Sub FrmColumnHeaderProperty_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        Me.Text = String.Format("{0}({1}列目)", Me.Text, HeaderColNo)
        FC.Title = Me.Text

        Edit1.Text = _HeaderText
        Edit1.ContentAlignment = _HeaderTextAlign
        TextAlignment.SelectedAlignment = _HeaderTextAlign

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
        _HeaderText = Edit1.Text

        _HeaderTextAlign = Edit1.ContentAlignment
        FC.Edited = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    ''' <summary>
    ''' 文字位置が変更された
    ''' </summary>
    ''' <param name="SelectdAlignment"></param>
    ''' <param name="HAlign"></param>
    ''' <param name="VAlign"></param>
    ''' <remarks></remarks>
    Private Sub TextAlignment_AlignmentChaned(SelectdAlignment As ContentAlignment, HAlign As Integer, VAlign As Integer) Handles TextAlignment.AlignmentChaned
        Edit1.ContentAlignment = SelectdAlignment
        FC.Edited = True
    End Sub
    ''' <summary>
    ''' 文字が変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Edit1_TextChanged(sender As Object, e As EventArgs) Handles Edit1.TextChanged
        FC.Edited = True
    End Sub
End Class