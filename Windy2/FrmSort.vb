''' <summary>
''' 行のソート設定と実行1
''' </summary>
''' <remarks></remarks>
Public Class FrmSort
    ''' <summary>
    ''' 作業対象のTViewを設定します。
    ''' </summary>
    ''' <value>対象TView</value>
    ''' <returns>対象設定済みTView</returns>
    ''' <remarks></remarks>
    Property Obj As AxKnTViewLib.AxKnTView

    Private Sub FrmSort_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmSort_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Initial()
    End Sub
    Private Sub Initial()
        Dim Row As Integer = Obj.Items.Count
        Dim Col As Integer = Obj.ColumnHeaders.Count
        TxtStartRowIndex.Minimum = 1 : TxtStartRowIndex.Maximum = Row : TxtStartRowIndex.Value = 1
        TxtFinRowIndex.Minimum = 1 : TxtFinRowIndex.Maximum = Row : TxtFinRowIndex.Value = Row
        TxtStartColIndex.Minimum = 1 : TxtStartColIndex.Maximum = Col : TxtStartColIndex.Value = 1
        TxtFinColIndex.Minimum = 1 : TxtFinColIndex.Maximum = Col : TxtFinColIndex.Value = Col
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If TxtStartRowIndex.Value > TxtFinRowIndex.Value Then
            MsgBox("対象行番号が不正です", 48, "エラー")
            TxtStartRowIndex.Value = 1 : TxtFinRowIndex.Value = TxtFinRowIndex.Maximum
            Return
        End If
        If TxtStartColIndex.Value > TxtFinColIndex.Value Then
            MsgBox("対象列番号が不正です", 48, "エラー")
            TxtStartColIndex.Value = 1 : TxtFinColIndex.Value = TxtFinColIndex.Maximum
            Return
        End If
        If MsgBox("ソートを開始してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Dim Flg As Integer = 0
            If OptAscending.Checked Then
                Flg = 0
            Else
                Flg = 1
            End If
            Try
                Obj.Sort(TxtStartRowIndex.Value, TxtFinRowIndex.Value, TxtStartColIndex.Value, TxtFinColIndex.Value, Flg, False)
                Me.Close()
            Catch ex As Exception
                MsgBox("ソートに失敗しました", 48, "エラー")
            End Try
        End If
    End Sub
End Class