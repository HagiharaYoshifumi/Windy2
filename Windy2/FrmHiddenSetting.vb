''' <summary>
''' 行・列の表示・非表示設定
''' </summary>
''' <remarks></remarks>
Public Class FrmHiddenSetting
    Property TargetTView As AxKnTViewLib.AxKnTView = Nothing
    Property IsColMode As Boolean = False
    Property CurrentRow As Integer = 0
    ''' <summary>
    ''' 行の状態を取得
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetDataRow()
        If Not IsNothing(TargetTView) Then
            If TargetTView.Items.Count > 0 Then
                If TargetTView.ColumnHeaders.Count > 0 Then
                    DataGridView1.RowCount = 0
                    DataGridView1.ColumnCount = 2
                    DataGridView1.Columns(0).Visible = False

                    For Col As Integer = 2 To TargetTView.ColumnHeaders.Count + 1
                        Dim Title As String = TargetTView.ColumnHeaders.Item(Col - 1).Text
                        Dim textColumn As New DataGridViewTextBoxColumn()
                        'データソースの"Column1"をバインドする
                        'textColumn.DataPropertyName = "Column1"
                        '名前とヘッダーを設定する
                        'textColumn.Name = "Column1"
                        textColumn.HeaderText = Title
                        '列を追加する
                        DataGridView1.Columns.Add(textColumn)
                    Next

                    For Row As Integer = 1 To TargetTView.Items.Count
                        DataGridView1.RowCount += 1
                        Dim GRow As Integer = DataGridView1.RowCount - 1

                        DataGridView1.Rows(GRow).Cells(0).Value = Not TargetTView.Items.Item(Row).Hidden
                        If Not TargetTView.Items.Item(Row).Hidden Then
                            DataGridView1.Rows(GRow).Cells(1).Value = My.Resources.eye_icon
                        Else
                            DataGridView1.Rows(GRow).Cells(1).Value = My.Resources.non_eye_icon
                        End If

                        For Col As Integer = 2 To TargetTView.ColumnHeaders.Count + 1
                            DataGridView1.Rows(GRow).Cells(Col).Value = TargetTView.Cell(Row, Col - 1).Value
                            If TargetTView.Items.Item(Row).Hidden Then
                                DataGridView1.Rows(GRow).Cells(Col).Style.BackColor = Color.Gainsboro
                            Else
                                DataGridView1.Rows(GRow).Cells(Col).Style.BackColor = Color.White
                            End If

                            'インデント設定されているセルは文字前に空白を挿入する
                            If TargetTView.Cell(Row, Col - 1).IndentLevel > 1 Then
                                DataGridView1.Rows(GRow).Cells(Col).Value = StrDup(TargetTView.Cell(Row, Col - 1).IndentLevel - 1, " ") & DataGridView1.Rows(GRow).Cells(Col).Value
                            End If
                        Next
                    Next

                    If _CurrentRow > 0 Then
                        DataGridView1.Rows(0).Selected = False
                        DataGridView1.Rows(_CurrentRow - 1).Selected = True
                    End If
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 行の状態を設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDataRow()
        For Row As Integer = 0 To DataGridView1.RowCount - 1
            Dim Flg As Boolean = DataGridView1.Rows(Row).Cells(0).Value 'True:表示
            TargetTView.Items.Item(Row + 1).Hidden = Not Flg
        Next
    End Sub
    ''' <summary>
    ''' 列の状態を取得
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetDataCol()
        If Not IsNothing(TargetTView) Then
            If TargetTView.Items.Count > 0 Then
                If TargetTView.ColumnHeaders.Count > 0 Then
                    DataGridView1.RowCount = 0
                    DataGridView1.ColumnCount = 2
                    DataGridView1.Columns(0).Visible = False

                    Dim textColumn As New DataGridViewTextBoxColumn()
                    'データソースの"Column1"をバインドする
                    'textColumn.DataPropertyName = "Column1"
                    '名前とヘッダーを設定する
                    'textColumn.Name = "Column1"
                    textColumn.HeaderText = "ヘッダー"
                    '列を追加する
                    DataGridView1.Columns.Add(textColumn)

                    For Row As Integer = 1 To TargetTView.ColumnHeaders.Count
                        DataGridView1.RowCount += 1
                        Dim GRow As Integer = DataGridView1.RowCount - 1

                        DataGridView1.Rows(GRow).Cells(0).Value = Not TargetTView.ColumnHeaders.Item(Row).Hidden
                        If Not TargetTView.ColumnHeaders.Item(Row).Hidden Then
                            DataGridView1.Rows(GRow).Cells(1).Value = My.Resources.eye_icon
                        Else
                            DataGridView1.Rows(GRow).Cells(1).Value = My.Resources.non_eye_icon
                        End If

                        DataGridView1.Rows(GRow).Cells(2).Value = TargetTView.ColumnHeaders.Item(Row).Text

                        If TargetTView.ColumnHeaders.Item(Row).Hidden Then
                            DataGridView1.Rows(GRow).Cells(2).Style.BackColor = Color.Gainsboro
                        Else
                            DataGridView1.Rows(GRow).Cells(2).Style.BackColor = Color.White
                        End If

                    Next
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 列の状態を設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDataCol()
        For Row As Integer = 0 To DataGridView1.RowCount - 1
            Dim Flg As Boolean = DataGridView1.Rows(Row).Cells(0).Value 'True:表示
            TargetTView.ColumnHeaders.Item(Row + 1).Hidden = Not Flg
        Next
    End Sub
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmHiddenSetting_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmHiddenSetting_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsColMode Then
            Me.Text = "列の表示・非表示設定"
            Call GetDataCol()
        Else
            Me.Text = "行の表示・非表示設定"
            Call GetDataRow()

        End If
    End Sub
    ''' <summary>
    ''' 非表示に設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnHidden_Click(sender As Object, e As EventArgs) Handles BtnHidden.Click
        For Each r As DataGridViewRow In DataGridView1.SelectedRows
            Dim Row As Integer = r.Index
            DataGridView1.Rows(Row).Cells(0).Value = False
            DataGridView1.Rows(Row).Cells(1).Value = My.Resources.non_eye_icon
            For Col As Integer = 2 To DataGridView1.ColumnCount - 1
                DataGridView1.Rows(Row).Cells(Col).Style.BackColor = Color.Gainsboro
            Next
        Next r
    End Sub
    ''' <summary>
    ''' 表示に設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDisHidden_Click(sender As Object, e As EventArgs) Handles BtnDisHidden.Click
        For Each r As DataGridViewRow In DataGridView1.SelectedRows
            Dim Row As Integer = r.Index
            DataGridView1.Rows(Row).Cells(0).Value = True
            DataGridView1.Rows(Row).Cells(1).Value = My.Resources.eye_icon
            For Col As Integer = 2 To DataGridView1.ColumnCount - 1
                DataGridView1.Rows(Row).Cells(Col).Style.BackColor = Color.White
            Next
        Next r
    End Sub
    ''' <summary>
    ''' キャンセルボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' OKボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If MsgBox("設定を反映しますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            If IsColMode Then
                Call SetDataCol()
            Else
                Call SetDataRow()
            End If
            Me.Close()
        End If
    End Sub
    ''' <summary>
    ''' 目アイコンをクリックしたら表示・非表示を切り換える
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim _Row As Integer = e.RowIndex
        If e.ColumnIndex = 1 Then
            Dim _Flg As Boolean = DataGridView1.Rows(_Row).Cells(0).Value
            If _Flg Then
                DataGridView1.Rows(_Row).Cells(0).Value = False
                DataGridView1.Rows(_Row).Cells(1).Value = My.Resources.non_eye_icon
            Else
                DataGridView1.Rows(_Row).Cells(0).Value = True
                DataGridView1.Rows(_Row).Cells(1).Value = My.Resources.eye_icon
            End If

            For Col As Integer = 2 To DataGridView1.ColumnCount - 1
                If _Flg Then
                    DataGridView1.Rows(_Row).Cells(Col).Style.BackColor = Color.Gainsboro
                Else
                    DataGridView1.Rows(_Row).Cells(Col).Style.BackColor = Color.White
                End If
            Next
        End If
    End Sub
    ''' <summary>
    ''' GRIDに行番号を付ける
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGrid_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        '列ヘッダーかどうか調べる
        If e.ColumnIndex < 0 And e.RowIndex >= 0 Then
            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            'e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
            Dim indexRect As System.Drawing.Rectangle = e.CellBounds
            indexRect.Inflate(-2, -2)
            '行番号を描画する
            TextRenderer.DrawText(e.Graphics, _
                (e.RowIndex + 1).ToString(), _
                e.CellStyle.Font, _
                indexRect, _
                e.CellStyle.ForeColor, _
                TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)
            '描画が完了したことを知らせる
            e.Handled = True
        End If
    End Sub
    ''' <summary>
    ''' 文字検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExecScan_Click(sender As Object, e As EventArgs) Handles BtnExecScan.Click
        If TxtTargetString.Text <> "" Then
            If DataGridView1.RowCount > 0 Then
                Dim FindCount As Integer = 0
                For Row As Integer = 0 To DataGridView1.RowCount - 1
                    DataGridView1.Rows(Row).Selected = False
                Next
                Dim Dat As String = TxtTargetString.Text
                For Row As Integer = 0 To DataGridView1.RowCount - 1
                    For Col As Integer = 0 To DataGridView1.ColumnCount - 1
                        Dim Val As String = DataGridView1.Rows(Row).Cells(Col).Value
                        If Val <> "" Then
                            If Val.Contains(Dat) Then
                                DataGridView1.Rows(Row).Selected = True
                                FindCount += 1
                                Exit For
                            End If
                        End If
                    Next
                Next
                If FindCount > 0 Then
                    'MsgBox(String.Format("{0}件見つけました", FindCount), 64, "情報")
                Else
                    MsgBox("該当する文字列は見つかりませんでした", 64, "情報")
                End If
            End If

        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class