''' <summary>
''' ドラッグによるDataGridViewの行移動
''' </summary>
''' <remarks>
''' <example><code>
''' 使用方法
'''  Dim WithEvents DGV_DragMove As New DataGridView_DragMove
''' 
'''  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
'''      DGV_DragMove.TargetObject = DataGridView1
'''      DGV_DragMove.MoveHandre = DataGridView_DragMove.enum_MoveHandre.RowHeader '行ヘッダーで移動を行う
'''      DGV_DragMove.CopyOK = True 'CTRLドラッグでコピーする事を許可する
'''  End Sub
''' </code></example>
'''  </remarks>
Public Class DataGridView_DragMove
    Dim _Obj As DataGridView = Nothing '対象GridView
    Dim DropDestinationIsNextRow As Boolean = False
    Dim DropDestinationIsValid As Boolean = False
    Dim DropDestinationRowIndex As Integer = 0
    Dim OwnBeginGrabRowIndex As Integer = 0

    Dim _TargetCell As DataGridViewCell = Nothing '選択セル
    Dim WithEvents _SelCelMoveTimer As New Timer 'カレント移動用タイマー

#Region "プロパティ・イベント"
    ''' <summary>
    ''' 対象となるDataGridViewを設定します
    ''' </summary>
    ''' <value>対象DataGridView</value>
    ''' <returns>対象DataGridView</returns>
    ''' <remarks></remarks>
    Property TargetObject As DataGridView
        Get
            Return _Obj
        End Get
        Set(value As DataGridView)
            _Obj = value
            If Not IsNothing(_Obj) Then
                Call AddEvent()
            End If
        End Set
    End Property
    ''' <summary>
    ''' ドラッグハンドラをどれにするかの値です
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enum_MoveHandre
        ''' <summary>
        ''' 行でドラッグする
        ''' </summary>
        ''' <remarks></remarks>
        RowHeader
        ''' <summary>
        ''' セルでドラッグする
        ''' </summary>
        ''' <remarks></remarks>
        Cell
    End Enum
    ''' <summary>
    ''' ドラッグハンドラを設定します
    ''' </summary>
    ''' <value>対象するハンドラ値</value>
    ''' <returns>設定済みハンドラ</returns>
    ''' <remarks>
    ''' <list type="table">
    ''' <listheader><term>値</term><description>内容</description></listheader>
    ''' <item><term>RowHeader</term><description>行ヘッダーをドラッグする事により動作します</description></item>
    ''' <item><term>Cell</term><description>セルをドラッグする事により動作します</description></item>
    ''' </list>
    ''' </remarks>
    Property MoveHandre As enum_MoveHandre
    ''' <summary>
    ''' CTRLキーを押しながらドラッグした際にコピーするかを設定する
    ''' </summary>
    ''' <value>
    ''' <list type="table">
    ''' <listheader><term>値</term><description>内容</description></listheader>
    ''' <item><term>True</term><description>コピーする</description></item>
    ''' <item><term>False</term><description>移動のみ</description></item>
    ''' </list> 
    ''' </value>
    ''' <returns>設定済み値</returns>
    ''' <remarks></remarks>
    Property CopyOK As Boolean

    ''' <summary>
    ''' 行が移動時に発生します
    ''' </summary>
    ''' <param name="FromRowIndex">移動元行番号</param>
    ''' <param name="ToRowIndex">移動先行番号</param>
    ''' <param name="NewRowIndex">ドロップ行の新行番号</param>
    ''' <param name="RowCount">移動行数</param>
    ''' <remarks>実質の移動された行は(ToRowIndex - RowCount + 1)～ToRowIndex</remarks>
    Public Event RowMoved(FromRowIndex As Integer, ToRowIndex As Integer, NewRowIndex As Integer, RowCount As Integer)

    ''' <summary>
    ''' 行がコピーされた時に発生します
    ''' </summary>
    ''' <param name="FromRowIndex">コピー元行番号</param>
    ''' <param name="ToRowIndex">コピー先行番号</param>
    ''' <param name="NewRowIndex">コピー行の新行番号</param>
    ''' <param name="RowCount">コピー行数</param>
    ''' <remarks>実質の移動された行は(ToRowIndex + 1)～(ToRowIndex + RowCount)</remarks>
    Public Event RowCopyed(FromRowIndex As Integer, ToRowIndex As Integer, NewRowIndex As Integer, RowCount As Integer)
#End Region
    ''' <summary>
    ''' イベントの追加
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddEvent()
        _Obj.AllowDrop = True
        AddHandler _Obj.DragDrop, AddressOf DragDrop
        AddHandler _Obj.DragLeave, AddressOf DragLeave
        AddHandler _Obj.DragOver, AddressOf DragOver
        AddHandler _Obj.MouseDown, AddressOf MouseDown
        AddHandler _Obj.RowPostPaint, AddressOf RowPostPaint
        AddHandler _Obj.CellDoubleClick, AddressOf CellDoubleClick
    End Sub

    ''' <summary>
    ''' セル編集開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        _Obj.BeginEdit(True)
    End Sub
    ''' <summary>
    ''' 行のドロップ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DragDrop(sender As Object, e As DragEventArgs)

        If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim FromRow As Integer = -1
            Dim ToRow As Integer = -1
            Dim ToRowCount As Integer = 0
            Dim tugi As Boolean = False

            If Not (DecideDropDestinationRowIndex(_Obj, e, FromRow, ToRow, tugi)) Then
                Return
            End If

            DropDestinationIsValid = False
            ToRowCount = _Obj.SelectedRows.Count
            'データの移動
            _CopyMode = False
            ToRow = MoveDataValue(FromRow, ToRow, tugi)
            If ToRow > -1 Then
                _TargetCell = _Obj(_Obj.CurrentCell.ColumnIndex, ToRow)
                _Obj.Invalidate()

                _SelCelMoveTimer.Interval = 50
                _SelCelMoveTimer.Enabled = True

                If _CopyMode Then
                    If ToRow > FromRow Then
                        '下にコピー
                        RaiseEvent RowCopyed(FromRow, ToRow, ToRow + 1, ToRowCount)
                    Else
                        '上にコピー
                        RaiseEvent RowCopyed(FromRow, ToRow, ToRow, ToRowCount)
                    End If
                Else
                    If ToRow > FromRow Then
                        '下に移動
                        RaiseEvent RowMoved(FromRow, ToRow, ToRow - ToRowCount + 1, ToRowCount)
                    Else
                        '上に移動
                        RaiseEvent RowMoved(FromRow, ToRow, ToRow, ToRowCount)
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub DragLeave(sender As Object, e As EventArgs)
        If (DropDestinationIsValid) Then
            DropDestinationIsValid = False
            _Obj.InvalidateRow(DropDestinationRowIndex)
        End If
    End Sub

    Private Sub DragOver(sender As Object, e As DragEventArgs)
        If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then 'ファイルがドラッグされてきたら実行しない
            If e.Data.GetDataPresent(GetType(Integer)) Then
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.None
            End If

            _Obj.Rows(OwnBeginGrabRowIndex).Selected = True

            Dim kara, made As Integer
            Dim tugi As Boolean
            Dim valid As Boolean = DecideDropDestinationRowIndex(_Obj, e, kara, made, tugi)

            Dim needRedraw As Boolean = (valid <> DropDestinationIsValid)
            If (valid) Then
                needRedraw = (needRedraw Or (made <> DropDestinationRowIndex) Or (tugi <> DropDestinationIsNextRow))
            End If

            If (needRedraw) Then
                If (DropDestinationIsValid) Then _Obj.InvalidateRow(DropDestinationRowIndex)
                If (valid) Then _Obj.InvalidateRow(made)
            End If

            DropDestinationIsValid = valid
            DropDestinationRowIndex = made
            DropDestinationIsNextRow = tugi
        End If

    End Sub

    Private Sub MouseDown(sender As Object, e As MouseEventArgs)
        OwnBeginGrabRowIndex = -1

        If (e.Button <> MouseButtons.Left And MouseButtons.Left <> MouseButtons.Left) Then Return 'マウス左ボタン以外は実行しない

        Dim hit As DataGridView.HitTestInfo = _Obj.HitTest(e.X, e.Y)

        'If (hit.Type <> DataGridViewHitTestType.Cell) Then Return
        'If hit.ColumnIndex <> 0 Then Return

        If _MoveHandre = enum_MoveHandre.RowHeader Then
            'ヘッダーをつかんで移動
            If (hit.Type <> DataGridViewHitTestType.RowHeader) Then Return
        Else
            'セルをつかんで移動
            If (hit.Type <> DataGridViewHitTestType.Cell) Then Return
        End If

        OwnBeginGrabRowIndex = hit.RowIndex
        _Obj.DoDragDrop(OwnBeginGrabRowIndex, DragDropEffects.Move)

    End Sub
    ''' <summary>
    ''' 行の再描写
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)

        'ドロップ先のマーカーを描画
        If _Obj.NewRowIndex > -1 AndAlso e.RowIndex = _Obj.NewRowIndex Then
            Return
        End If

        If (DropDestinationIsValid And e.RowIndex = DropDestinationRowIndex) Then
            Using objpen As New Pen(Color.Red, 2)
                Dim y As Integer = IIf(DropDestinationIsNextRow = False, e.RowBounds.Y + 2, e.RowBounds.Bottom - 2)
                e.Graphics.DrawLine(objpen, e.RowBounds.X, y, e.RowBounds.X + _Obj.RowHeadersWidth, y)
            End Using
        End If

    End Sub
    Private Function DecideDropDestinationRowIndex(grid As DataGridView, e As DragEventArgs, ByRef FromRow As Integer, ByRef ToRow As Integer, ByRef tugi As Boolean) As Boolean

        FromRow = DirectCast(e.Data.GetData(GetType(Integer)), Integer)

        '元の行が追加用の行であれば、常に false
        If (grid.NewRowIndex <> -1 And grid.NewRowIndex = FromRow) Then
            ToRow = 0
            tugi = False
            Return False
        End If

        Dim clientPoint As Point = grid.PointToClient(New Point(e.X, e.Y))
        '上下のみに着目するため、横方向は無視する
        clientPoint.X = 1
        Dim hit As DataGridView.HitTestInfo = grid.HitTest(clientPoint.X, clientPoint.Y)

        ToRow = hit.RowIndex
        If (ToRow = -1) Then
            Dim top As Integer = IIf(grid.ColumnHeadersVisible, grid.ColumnHeadersHeight, 0)
            top += 1

            If (top > clientPoint.Y) Then
                'ヘッダへのドロップ時は表示中の先頭行とする
                ToRow = grid.FirstDisplayedCell.RowIndex
            Else
                '最終行へ
                ToRow = grid.Rows.Count - 1
            End If
        End If

        '追加用の行は無視
        If (tugi = grid.NewRowIndex) Then
            ToRow -= ToRow
        End If

        tugi = (ToRow > FromRow)
        Return (FromRow <> ToRow)

    End Function
    Dim _CopyMode As Boolean = False

    ''' <summary>
    ''' 実質の行移動
    ''' </summary>
    ''' <param name="FromRow"></param>
    ''' <param name="ToRow"></param>
    ''' <param name="tugi"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function MoveDataValue(ByVal FromRow As Integer, ByVal ToRow As Integer, ByVal tugi As Boolean) As Integer

        With _Obj
            'コピー許可プロパティが設定されていてCTRLキーが押されている場合はコピーモード
            If _CopyOK Then
                If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                    _CopyMode = True
                Else
                    _CopyMode = False
                End If
            Else
                _CopyMode = False
            End If

            If _Obj.NewRowIndex > -1 AndAlso _Obj.NewRowIndex = ToRow Then
                Return -1
            End If

            '選択行のデータをコピーする
            Dim _SelRowItem As New List(Of DataGridViewRow)
            For Each R As DataGridViewRow In .SelectedRows
                Dim _S As DataGridViewRow
                _S = CType(R.Clone(), DataGridViewRow)
                For index As Int32 = 0 To R.Cells.Count - 1
                    _S.Cells(index).Value = R.Cells(index).Value
                    _S.Cells(index).Style.BackColor = R.Cells(index).Style.BackColor
                Next
                _SelRowItem.Add(_S)
            Next

            If FromRow < ToRow Then
                '下に行を挿入する
                .Rows.Insert(ToRow + 1, _SelRowItem.Count)
                'データを復元する
                _SelRowItem.Reverse()
                For Row As Integer = 0 To _SelRowItem.Count - 1
                    Dim _S As DataGridViewRow = _SelRowItem(Row)
                    For Col As Integer = 0 To _S.Cells.Count - 1
                        .Rows(ToRow + Row + 1).Cells(Col).Value = _S.Cells(Col).Value
                        .Rows(ToRow + Row + 1).Cells(Col).Style.BackColor = _S.Cells(Col).Style.BackColor
                    Next
                Next
            Else
                '上に行を挿入する
                .Rows.Insert(ToRow, _SelRowItem.Count)
                'データを復元する
                _SelRowItem.Reverse()
                For Row As Integer = 0 To _SelRowItem.Count - 1
                    Dim _S As DataGridViewRow = _SelRowItem(Row)
                    For Col As Integer = 0 To _S.Cells.Count - 1
                        .Rows(ToRow + Row).Cells(Col).Value = _S.Cells(Col).Value
                        .Rows(ToRow + Row).Cells(Col).Style.BackColor = _S.Cells(Col).Style.BackColor
                    Next
                Next
            End If

            If Not _CopyMode Then
                '選択行を削除する
                'http://www.itlab51.com/?p=3531
                For Each Itm As DataGridViewRow In .SelectedRows
                    If Not Itm.IsNewRow Then
                        .Rows.Remove(Itm)
                    End If
                Next
            End If
            Return ToRow
        End With

    End Function
    ''' <summary>
    ''' 選択行の確認
    ''' </summary>
    ''' <param name="FromRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSelRowCount(FromRow As Integer)
        With _Obj
            Dim _C As Integer = 0
            Dim C As Integer = .CurrentCell.ColumnIndex
            Dim FR As Integer = SelectTopRow()
            For i As Integer = FromRow To .RowCount - 1
                If Not .Rows(i).IsNewRow Then
                    If .Rows(i).Cells(C).Selected Then
                        _C += 1
                    Else
                        Exit For
                    End If
                End If
            Next
            Return _C
        End With
    End Function
    Private Function SelectTopRow() As Integer
        Dim _Ret As Integer = 10000
        With _Obj
            If .SelectedRows.Count > 0 Then
                For Row As Integer = 0 To .SelectedRows.Count - 1
                    If .SelectedRows.Item(Row).Index <= _Ret Then
                        _Ret = .SelectedRows(Row).Index
                    End If
                Next
            End If
        End With
        Return _Ret
    End Function
    ''' <summary>
    ''' カレントセルの移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub _SelCelMoveTimer_Tick(sender As Object, e As EventArgs) Handles _SelCelMoveTimer.Tick
        _SelCelMoveTimer.Enabled = False
        _Obj.Focus()
        _Obj.CurrentCell = _TargetCell

    End Sub
End Class
