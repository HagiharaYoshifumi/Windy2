''' <summary>
''' アイテム検索
''' </summary>
''' <remarks></remarks>
Public Class FrmItemFind

    Dim _Title As String = ""
    Dim _TargetForm As FrmMain
    Dim _IsWork As Boolean = False

    ''' <summary>
    ''' 対象フォーム
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property TargetForm As FrmMain
        Get
            Return _TargetForm
        End Get
        Set(value As FrmMain)
            _TargetForm = value
        End Set
    End Property
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmItemFind_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmItemFind_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _IsWork Then
            e.Cancel = True
        End If
        Call ClearPattern() '全パターンのクリア
        Call ClearPattern2()
    End Sub
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmItemFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _Title = Me.Text
        DataGridView1.Columns(5).Visible = False '列番号列を非表示にする
    End Sub
    ''' <summary>
    ''' 検索ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles BtnScan.Click
        If _IsWork Then Return

        If TxtTargetString.Text = "" Then
            MsgBox("検索する文字列が入力されていません", 48, "エラー")
            Return
        End If

        If ChkP.Checked = False AndAlso ChkS.Checked = False AndAlso ChkB.Checked = False Then
            MsgBox("検索対象アイテムが選択されていません", 48, "エラー")
            Return
        End If

        If MsgBox("検索を開始してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Me.Text = String.Format("{0}(検索中)", _Title)
            Application.DoEvents()

            _IsWork = True
            DataGridView1.RowCount = 0
            Dim Datas As New List(Of FindItemCollection)
            Dim Mode As Integer = 0
            Select Case True
                Case OptFindType_Item1.Checked : Mode = 1 '前方一致
                Case OptFindType_Item2.Checked : Mode = 2 '後方一致
                Case Else : Mode = 0 '部分一致
            End Select

            Datas = _TargetForm.FindItem(TxtTargetString.Text, Mode) 'アイテムの検索を行う

            If Datas.Count > 0 Then
                For Each Itm As FindItemCollection In Datas
                    Dim Flg As Boolean = False
                    '検索対象アイテムタイプの確認
                    Select Case True
                        Case ChkP.Checked AndAlso Itm.ItemType = FindItemCollection.EnumItemType.IsPeacs
                            Flg = True
                        Case ChkS.Checked AndAlso Itm.ItemType = FindItemCollection.EnumItemType.IsStone
                            Flg = True
                        Case ChkB.Checked AndAlso Itm.ItemType = FindItemCollection.EnumItemType.IsBollen
                            Flg = True
                    End Select

                    '開始日範囲の確認
                    If Flg Then
                        If Not IsNothing(TxtStartDay.Value) Then
                            If Itm.StartDate < TxtStartDay.Value Then
                                Flg = False
                            End If
                        End If
                    End If
                    '終了日範囲の確認
                    If Flg Then
                        If Not IsNothing(TxtFinishDay.Value) Then
                            If Itm.StartDate > TxtFinishDay.Value Then
                                Flg = False
                            End If
                        End If
                    End If

                    If Flg Then
                        '検索結果がマッチした
                        With DataGridView1
                            .RowCount += 1
                            Dim Row As Integer = .RowCount - 1
                            With .Rows(Row)
                                Select Case Itm.ItemType
                                    Case FindItemCollection.EnumItemType.IsStone
                                        .Cells(0).Value = My.Resources.plugin
                                    Case FindItemCollection.EnumItemType.IsBollen
                                        .Cells(0).Value = My.Resources.Ballon
                                    Case Else
                                        .Cells(0).Value = My.Resources.Piece
                                End Select
                                .Cells(1).Value = Itm.Row
                                .Cells(2).Value = ConvCaptionDateCount(Itm.Text, Itm.StartDate, Itm.Finish)
                                .Cells(3).Value = String.Format("{0:yy年M月d日}", Itm.StartDate)
                                If Not Itm.Finish.ToOADate = 0 Then
                                    .Cells(4).Value = String.Format("{0:yy年M月d日}", Itm.Finish)
                                End If
                                .Cells(5).Value = Itm.Col

                            End With
                        End With
                    End If
                Next
                LblMessage.Text = String.Format("{0}件のアイテムがヒットしました", DataGridView1.RowCount)
            Else
                LblMessage.Text = "該当アイテムはありません"
            End If
            Me.Text = _Title
            _IsWork = False
        End If

    End Sub
    ''' <summary>
    ''' 選択行のアイテムに向けてTimeViewを移動させる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If _IsWork Then
        Else
            _IsWork = True
            Dim S As Date = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            _TargetForm.TView.ViewTopTime = DateAdd(DateInterval.Day, 0 - CInt(TxtTopMarge.Value), S)

            Call ClearPattern()

            Dim Row As Integer = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            Dim Col As Integer = DataGridView1.Rows(e.RowIndex).Cells(5).Value
            Dim PCE As KnTViewLib.Piece = _TargetForm.TView.Items.Item(Row).Pieces.Item(Col)

            PCE.BarShape.Fill.Pattern = KnTViewLib.TivFillPattern.tivPattern50Percent '該当ピースのパターンを変更する
            PCE.Selected = True
            _IsWork = False

        End If
    End Sub
    ''' <summary>
    ''' パターンをクリアする
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearPattern()
        For RowIndex As Integer = 0 To DataGridView1.RowCount - 1
            Dim Row As Integer = DataGridView1.Rows(RowIndex).Cells(1).Value
            Dim Col As Integer = DataGridView1.Rows(RowIndex).Cells(5).Value
            Try
                Dim PCE As KnTViewLib.Piece = _TargetForm.TView.Items.Item(Row).Pieces.Item(Col)
                If PCE.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                Else
                    PCE.BarShape.Fill.Pattern = KnTViewLib.TivFillPattern.tivPatternNull
                End If
                PCE.Selected = False
            Catch ex As Exception

            End Try
        Next
    End Sub
    ''' <summary>
    ''' 閉じるメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuFrmClose_Click(sender As Object, e As EventArgs) Handles MenuFrmClose.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' ヘッダー検索ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnScanHeader_Click(sender As Object, e As EventArgs) Handles BtnScanHeader.Click
        If _IsWork Then Return

        If TxtTargetString2.Text = "" Then
            MsgBox("検索する文字列が入力されていません", 48, "エラー")
            Return
        End If

        If MsgBox("検索を開始してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Me.Text = String.Format("{0}(検索中)", _Title)
            Application.DoEvents()

            _IsWork = True
            DataGridView2.RowCount = 0
            Dim Datas As New List(Of FindHeaderCollection)
            Dim Mode As Integer = 0
            Select Case True
                Case OptFindType_Header0.Checked : Mode = 1 '前方一致
                Case OptFindType_Header1.Checked : Mode = 2 '後方一致
                Case Else : Mode = 0 '部分一致
            End Select

            Datas = _TargetForm.FindHeader(TxtTargetString2.Text, Mode) 'アイテムの検索を行う

            If Datas.Count > 0 Then
                For Each Itm As FindHeaderCollection In Datas
                    Dim Flg As Boolean = False
                    With DataGridView2

                        .RowCount += 1
                        Dim Row As Integer = .RowCount - 1
                        With .Rows(Row)
                            .Cells(0).Value = Itm.Row
                            .Cells(1).Value = Itm.Col
                            .Cells(2).Value = Itm.Text
                        End With
                    End With
                Next
                LblMessage.Text = String.Format("{0}件のアイテムがヒットしました", DataGridView1.RowCount)
            Else
                LblMessage.Text = "該当アイテムはありません"
            End If
            Me.Text = _Title
            _IsWork = False
        End If

    End Sub

    ''' <summary>
    ''' セルがクリックされた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If _IsWork Then
        Else
            _IsWork = True

            Call ClearPattern2()

            Dim Row As Integer = DataGridView2.Rows(e.RowIndex).Cells(0).Value
            Dim Col As Integer = DataGridView2.Rows(e.RowIndex).Cells(1).Value

            _TargetForm.TView.Cell(Row, Col).Fill.ForeColor = ConvertColorValue(Color.Red)
            _TargetForm.TView.Cell(Row, Col).Fill.Pattern = KnTViewLib.TivFillPattern.tivPattern50Percent
            _IsWork = False

        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
    ''' <summary>
    ''' 検索条件クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearPattern2()
        For TRow As Integer = 1 To _TargetForm.TView.Items.Count
            For TCol As Integer = 1 To _TargetForm.TView.ColumnHeaders.Count
                _TargetForm.TView.Cell(TRow, TCol).Fill.Pattern = KnTViewLib.TivFillPattern.tivPatternNull
            Next
        Next
    End Sub
End Class