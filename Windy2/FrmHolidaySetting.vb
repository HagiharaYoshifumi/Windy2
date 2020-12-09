''' <summary>
''' 休日設定画面
''' </summary>
''' <remarks></remarks>
Public Class FrmHolidaySetting
    Dim WithEvents DGV_DragMove As New DataGridView_DragMove
    Const ColDate1 As Integer = 0
    Const ColDate2 As Integer = 1
    Const ColNote As Integer = 2

    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmHolidaySetting_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmHolidaySetting_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not CheckData() Then
            e.Cancel = True
            Return
        End If
        Try
            Grid.EndEdit()
            _Holiday.Clear()
            If Grid.RowCount > 1 Then
                For Row As Integer = 0 To Grid.RowCount - 2
                    With Grid.Rows(Row)
                        Dim t As New HolidayCollection
                        t.HolidayStartDate = .Cells(ColDate1).Value
                        t.HolidayFinDate = .Cells(ColDate2).Value
                        t.HolidayName = .Cells(ColNote).Value
                        _Holiday.Add(t)
                    End With
                Next
            End If
        Catch ex As Exception
            Logs.PutErrorEx("フォームクローズエラー", ex)
        End Try
      
     
    End Sub
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmHolidaySetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            DGV_DragMove.TargetObject = Grid
            DGV_DragMove.MoveHandre = DataGridView_DragMove.enum_MoveHandre.RowHeader
            DGV_DragMove.CopyOK = True

            Dim maskedColumn1 As New DataGridViewMaskedTextBoxColumn()
            maskedColumn1.DataPropertyName = "Column2"
            maskedColumn1.Mask = "0000/00/00"
            Grid.Columns.Insert(0, maskedColumn1)
            Grid.Columns(0).HeaderText = "終了日"

            Dim maskedColumn2 As New DataGridViewMaskedTextBoxColumn()
            maskedColumn2.DataPropertyName = "Column1"
            maskedColumn2.Mask = "0000/00/00"
            Grid.Columns.Insert(0, maskedColumn2)
            Grid.Columns(0).HeaderText = "開始日"

            If _Holiday.Count > 0 Then
                With Grid
                    .RowCount = 1
                    For Each Item As HolidayCollection In _Holiday
                        .RowCount += 1
                        Dim Row As Integer = .RowCount - 2
                        With .Rows(Row)
                            .Cells(ColDate1).Value = Format(Item.HolidayStartDate, "yyyy/MM/dd")
                            .Cells(ColDate2).Value = Format(Item.HolidayFinDate, "yyyy/MM/dd")
                            .Cells(ColNote).Value = Item.HolidayName
                        End With
                    Next
                End With
            End If
        Catch ex As Exception
            Logs.PutErrorEx("フォームロードエラー", ex)
        End Try
    
    End Sub
    ''' <summary>
    ''' データ登録前チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckData() As Boolean
        Try
            If Grid.RowCount > 1 Then
                For Row As Integer = 0 To Grid.RowCount - 2
                    With Grid.Rows(Row)
                        If Not IsDate(.Cells(ColDate1).Value) Then
                            MsgBox(String.Format("{0}行目の開始日付が不正です。", Row + 1), 48, "エラー")
                            Return False
                        End If
                        If Not IsDate(.Cells(ColDate2).Value) Then
                            If IsDate(.Cells(ColDate1).Value) Then
                                .Cells(1).Value = .Cells(ColDate1).Value
                            End If
                            'MsgBox(String.Format("{0}行目の終了日付が不正です。", Row + 1), 48, "エラー")
                            'Return False
                        End If
                        Dim S As Date = .Cells(ColDate1).Value
                        Dim E As Date = .Cells(ColDate2).Value
                        If S > E Then
                            MsgBox(String.Format("{0}行目の開始・終了日付が不正です。", Row + 1), 48, "エラー")
                            Return False
                        End If
                    End With
                Next
            End If

            Return True
        Catch ex As Exception
            Logs.PutErrorEx("休日設定確認エラー", ex)
            Return False
        End Try
    
    End Function

    ''' <summary>
    ''' 行の入替
    ''' </summary>
    ''' <param name="FromRow"></param>
    ''' <param name="ToRow"></param>
    ''' <remarks></remarks>
    Private Sub RowSwap(ByVal FromRow As Integer, ByVal ToRow As Integer)
        Try
            If Grid.Rows(FromRow).IsNewRow OrElse Grid.Rows(ToRow).IsNewRow Then
                Return
            End If
            Dim T As New HolidayCollection
            With Grid.Rows(FromRow)
                T.HolidayStartDate = .Cells(ColDate1).Value
                T.HolidayFinDate = .Cells(ColDate2).Value
                T.HolidayName = .Cells(ColNote).Value
            End With
            With Grid.Rows(ToRow)
                Grid.Rows(FromRow).Cells(0).Value = .Cells(ColDate1).Value
                Grid.Rows(FromRow).Cells(1).Value = .Cells(ColDate2).Value
                Grid.Rows(FromRow).Cells(2).Value = .Cells(ColNote).Value

                .Cells(ColDate1).Value = Format(T.HolidayStartDate, "yyyy/MM/dd")
                .Cells(ColDate2).Value = Format(T.HolidayFinDate, "yyyy/MM/dd")
                .Cells(ColNote).Value = T.HolidayName
            End With
        Catch ex As Exception
            Logs.PutErrorEx("休日行入替エラー", ex)
        End Try
       
    End Sub


    ''' <summary>
    ''' 終了メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuFormClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFormClose.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' セルのダブルクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Grid.EndEdit()
        Dim Row As Integer = e.RowIndex
        Select Case e.ColumnIndex
            Case 0
                With FrmCalendar
                    If Grid.Rows(Row).Cells(ColDate1).Value <> "" Then
                        If IsDate(Grid.Rows(Row).Cells(0).Value) Then
                            .SelectedDate = Grid.Rows(Row).Cells(0).Value
                        Else
                            .SelectedDate = Now
                        End If
                    Else
                        If Grid.Rows(Row).Cells(ColDate2).Value <> "" Then
                            If IsDate(Grid.Rows(Row).Cells(1).Value) Then
                                .SelectedDate = Grid.Rows(Row).Cells(1).Value
                            Else
                                .SelectedDate = Now
                            End If
                        Else
                            .SelectedDate = Now
                        End If
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Grid.Rows(Row).Cells(ColDate1).Value = Format(.SelectedDate, "yyyy/MM/dd")
                    End If
                End With
            Case 1
                With FrmCalendar
                    If Grid.Rows(Row).Cells(ColDate2).Value <> "" Then
                        If IsDate(Grid.Rows(Row).Cells(ColDate2).Value) Then
                            .SelectedDate = Grid.Rows(Row).Cells(ColDate2).Value
                        Else
                            .SelectedDate = Now
                        End If
                    Else
                        If Grid.Rows(Row).Cells(ColDate1).Value <> "" Then
                            If IsDate(Grid.Rows(Row).Cells(ColDate1).Value) Then
                                .SelectedDate = Grid.Rows(Row).Cells(ColDate1).Value
                            Else
                                .SelectedDate = Now
                            End If
                        Else
                            .SelectedDate = Now
                        End If
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Grid.Rows(Row).Cells(ColDate2).Value = Format(.SelectedDate, "yyyy/MM/dd")
                    End If
                End With
        End Select
    End Sub

    Private Sub Grid_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grid.CellEnter
        Select Case e.ColumnIndex
            Case ColDate1, ColDate2
                Grid.ImeMode = Windows.Forms.ImeMode.Off
            Case Else
                Grid.ImeMode = Windows.Forms.ImeMode.On
        End Select
    End Sub

    Private Sub Grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid.CellContentClick

    End Sub
    ''' <summary>
    ''' クリップボードからメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuGetClip_Click(sender As Object, e As EventArgs) Handles MenuGetClip.Click
        If Clipboard.ContainsText() Then
            '文字列データがあるときはこれを取得する
            '取得できないときは空の文字列（String.Empty）を返す
            Dim _T() As String = Split(Clipboard.GetText(), vbCrLf)
            For Each Itm As String In _T
                Dim _TT() As String = Split(Itm, vbTab)
                If _TT.Length = 2 OrElse _TT.Length = 3 Then
                    If IsDate(_TT(0)) Then
                        Grid.RowCount += 1
                        Dim Row As Integer = Grid.RowCount - 2
                        With Grid.Rows(Row)
                            .Cells(ColDate1).Value = _TT(0)
                            If IsDate(_TT(1)) Then
                                .Cells(ColDate2).Value = _TT(1)
                                .Cells(ColNote).Value = _TT(2)
                            Else
                                .Cells(ColDate2).Value = _TT(0)
                                .Cells(ColNote).Value = _TT(1)
                            End If

                        End With
                    End If
                End If
            Next
        End If
    End Sub
End Class
