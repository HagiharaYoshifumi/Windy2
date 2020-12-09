Public Class FrmExpansionWork
    ''' <summary>
    ''' 対象フォーム
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property TargetFrm As FrmMain
    ''' <summary>
    ''' 指定日以前のピースを削除する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPieceDel_Click(sender As Object, e As EventArgs) Handles BtnPieceDel.Click
        If IsNothing(TxtDay.Value) Then
            MsgBox("削除対象日付が設定されていません。", 48, "エラー")
            Return
        End If
        If TargetFrm.TView.Items.Count > 0 Then
            Dim TPC As New List(Of KnTViewLib.Piece)

            Try
                '対象ピースの確認
                For Row As Integer = TargetFrm.TView.Items.Count To 1 Step -1
                    If TargetFrm.TView.Items.Item(Row).Pieces.Count > 0 Then
                        For Index As Integer = TargetFrm.TView.Items.Item(Row).Pieces.Count To 1 Step -1
                            Dim PCE As KnTViewLib.Piece = TargetFrm.TView.Items.Item(Row).Pieces.Item(Index)
                            If PieceIsStone(PCE) Then
                                If DateDiff(DateInterval.Day, CDate(TxtDay.Value), CDate(PCE.Start)) < 0 Then
                                    TPC.Add(PCE)
                                    Call HiLight(PCE, True)
                                End If
                            Else
                                If DateDiff(DateInterval.Day, CDate(TxtDay.Value), CDate(PCE.Finish)) <= 0 Then
                                    TPC.Add(PCE)
                                    Call HiLight(PCE, True)
                                End If
                            End If
                        Next
                    End If
                Next

                If TPC.Count > 0 Then
                    If MsgBox("指定日以前のピースを削除してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                        'ピースの削除
                        For Each PCE As KnTViewLib.Piece In TPC
                            Dim Row As Integer = PCE.ItemIndex
                            Dim Col As Integer = PCE.Index
                            TargetFrm.TView.Items.Item(Row).Pieces.Remove(Col)
                        Next
                        Call TargetFrm.CellDateRefresh()
                        TargetFrm.FR.Edited = True
                        FrmParent.LblMessage.Text = "指定日付以前ピースを削除しました"
                    Else
                        'キャンセルの時はハイライトを戻す
                        For Row As Integer = TargetFrm.TView.Items.Count To 1 Step -1
                            If TargetFrm.TView.Items.Item(Row).Pieces.Count > 0 Then
                                For Index As Integer = TargetFrm.TView.Items.Item(Row).Pieces.Count To 1 Step -1
                                    Dim PCE As KnTViewLib.Piece = TargetFrm.TView.Items.Item(Row).Pieces.Item(Index)
                                    Call HiLight(PCE, False)
                                Next
                            End If
                        Next
                    End If

                End If
            Catch ex As Exception
                Logs.PutErrorEx("指定日ピース削除エラー", ex, True)
            End Try
           
        End If
    End Sub
    ''' <summary>
    ''' 指定ピースのハイライト
    ''' </summary>
    ''' <param name="PCE"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Private Sub HiLight(PCE As KnTViewLib.Piece, Value As Boolean)
        With PCE
            If Value Then
                'ハイライトする
                .BarShape.Line.Color = ConvertColorValue(Color.Red)
                .BarShape.Fill.BkMode = KnTViewLib.TivBkMode.tivTransparent
                .BarShape.Fill.ForeColor = ConvertColorValue(Color.White)
                .BarShape.Fill.Pattern = KnTViewLib.TivFillPattern.tivPattern50Percent
                If .Progresses.Count > 0 Then
                    For T As Integer = 1 To .Progresses.Count
                        .Progresses.Item(T).Fill.ForeColor = ConvertColorValue(Color.White)
                        .Progresses.Item(T).Fill.Pattern = KnTViewLib.TivFillPattern.tivPattern50Percent
                    Next
                End If
            Else
                '元に戻す
                .BarShape.Line.Color = ConvertColorValue(Color.Black)
                .BarShape.Fill.Pattern = KnTViewLib.TivFillPattern.tivPatternNull
                If .Progresses.Count > 0 Then
                    For T As Integer = 1 To .Progresses.Count
                        .Progresses.Item(T).Fill.ForeColor = ConvertColorValue(Color.Black)
                        .Progresses.Item(T).Fill.Pattern = KnTViewLib.TivFillPattern.tivPatternNull
                    Next
                End If
            End If

        End With
    End Sub
    ''' <summary>
    ''' 未使用行の削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnEmptyRow_Click(sender As Object, e As EventArgs) Handles BtnEmptyRow.Click
        If TargetFrm.TView.Items.Count > 0 Then
            Dim TargetRow As New List(Of Integer)
            Dim MemRowColor As New List(Of UInteger)
            Try
                '削除対象行の確認
                For Row As Integer = TargetFrm.TView.Items.Count To 1 Step -1
                    Dim Flg As Boolean = False
                    If TargetFrm.TView.Items.Item(Row).Pieces.Count = 0 Then
                        If ChkCellText.Checked Then
                            Flg = True
                        Else
                            If TargetFrm.TView.Items.Item(Row).Cells.Count > 0 Then
                                For Col As Integer = 1 To TargetFrm.TView.Items.Item(Row).Cells.Count
                                    Dim KK As String = TargetFrm.TView.Items.Item(Row).Cells.Item(Col).Value
                                    If Trim(KK) = "" Then
                                        Flg = True
                                    Else
                                        Flg = False
                                        Exit For
                                    End If
                                Next
                            End If

                        End If
                    End If

                    MemRowColor.Add(TargetFrm.TView.Items.Item(Row).PiecePane.Fill.BackColor) '全ての行の背景色を記憶する
                    If Flg Then
                        '削除対象行
                        TargetRow.Add(Row)
                        TargetFrm.TView.Items.Item(Row).PiecePane.Fill.BackColor = ConvertColorValue(Color.Yellow)
                    End If
                Next

                If TargetRow.Count > 0 Then
                    If MsgBox("未使用行を削除してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                        For Each i As Integer In TargetRow
                            TargetFrm.TView.Items.Item(i).Pieces.Clear()
                            TargetFrm.TView.Items.Remove(i)

                        Next
                        TargetFrm.FR.Edited = True
                        FrmParent.LblMessage.Text = "未使用行を削除しました"
                    Else
                        'キャンセルの場合は背景色を戻す
                        Dim i As Integer = 0
                        For Row As Integer = TargetFrm.TView.Items.Count To 1 Step -1
                            TargetFrm.TView.Items.Item(Row).PiecePane.Fill.BackColor = MemRowColor(i)
                            i += 1
                        Next
                    End If
                End If

            Catch ex As Exception
                Logs.PutErrorEx("未使用行削除エラー", ex, True)
            End Try
        End If
    End Sub
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmExpansionWork_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' 閉じるボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmExpansionWork_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class