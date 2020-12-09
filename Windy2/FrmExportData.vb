''' <summary>
''' データエクスポート
''' </summary>
''' <remarks></remarks>
Public Class FrmExportData
    Property Obj As AxKnTViewLib.AxKnTView
    ''' <summary>
    ''' フォームを閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmExportData_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmExportData_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Initial()
    End Sub
    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initial()
        Call GetCellData()
        Call GetPeaceData()
        Call GetBallonData()
    End Sub
    ''' <summary>
    ''' セルデータ読込
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetCellData()
        Try
            If _Obj.ColumnHeaders.Count > 0 Then
                For Col As Integer = 1 To _Obj.ColumnHeaders.Count
                    Dim Item As New DataGridViewTextBoxColumn
                    DataColumn.Columns.Add(Item)

                    Item.ReadOnly = True
                    Item.HeaderText = _Obj.ColumnHeaders.Item(Col).Text
                Next
                DataColumn.RowCount = _Obj.Items.Count

                For Row As Integer = 1 To _Obj.Items.Count
                    For Col As Integer = 1 To _Obj.ColumnHeaders.Count
                        DataColumn.Rows(Row - 1).Cells(Col - 1).Value = _Obj.Cell(Row, Col).Value
                    Next
                Next
            End If
        Catch ex As Exception
            Logs.PutErrorEx("セルデータ読込エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' ピースデータ読込
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetPeaceData()
        Try
            If _Obj.Items.Count > 0 Then
                For Row As Integer = 1 To _Obj.Items.Count
                    If _Obj.Items.Item(Row).Pieces.Count > 0 Then
                        For Col As Integer = 1 To _Obj.Items.Item(Row).Pieces.Count
                            Dim RR As Integer = GridAddRow(DataPeace)

                            DataPeace.Rows(RR).Cells(0).Value = Row
                            DataPeace.Rows(RR).Cells(1).Value = Col

                            DataPeace.Rows(RR).Cells(2).Value = String.Format("{0:yyyy/MM/dd}", _Obj.Items.Item(Row).Pieces.Item(Col).Start)
                            DataPeace.Rows(RR).Cells(3).Value = String.Format("{0:yyyy/MM/dd}", _Obj.Items.Item(Row).Pieces.Item(Col).Finish)
                            DataPeace.Rows(RR).Cells(4).Value = _Obj.Items.Item(Row).Pieces.Item(Col).Captions.Item(2).Text
                            If _Obj.Items.Item(Row).Pieces.Item(Col).Progresses.Count > 0 Then
                                DataPeace.Rows(RR).Cells(5).Value = _Obj.Items.Item(Row).Pieces.Item(Col).Progresses.Item(1).PercentTo
                            Else
                                DataPeace.Rows(RR).Cells(5).Value = "0"
                            End If
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            Logs.PutErrorEx("ピースデータ読込エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' バルーンデータ読込
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetBallonData()
        'DataBallon
        Try
            If _Obj.Items.Count > 0 Then
                For Row As Integer = 1 To _Obj.Items.Count
                    If _Obj.Items.Item(Row).Pieces.Count > 0 Then
                        For Col As Integer = 1 To _Obj.Items.Item(Row).Pieces.Count
                            If _Obj.Items.Item(Row).Pieces.Item(Col).Balloons.Count > 0 Then
                                For X As Integer = 1 To _Obj.Items.Item(Row).Pieces.Item(Col).Balloons.Count
                                    Dim RR As Integer = GridAddRow(DataBallon)

                                    DataBallon.Rows(RR).Cells(0).Value = Row
                                    DataBallon.Rows(RR).Cells(1).Value = Col
                                    DataBallon.Rows(RR).Cells(2).Value = X

                                    DataBallon.Rows(RR).Cells(3).Value = _Obj.Items.Item(Row).Pieces.Item(Col).Balloons.Item(X).Caption.Text
                                Next
                            End If
                        Next
                    End If
                Next
            End If

        Catch ex As Exception
            Logs.PutErrorEx("バルーンデータ読込エラー", ex, True)

        End Try
    End Sub
    ''' <summary>
    ''' 行追加
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GridAddRow(Obj As DataGridView) As Integer
        Obj.RowCount += 1
        Return Obj.RowCount - 1
    End Function
    ''' <summary>
    ''' 閉じるメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuClose_Click(sender As Object, e As EventArgs) Handles MenuClose.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' 選択データコピーメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuCopy_Click(sender As Object, e As EventArgs) Handles MenuCopy.Click
        'ContextMenuStripを表示しているコントロールを取得する
        Dim source As Control = ContextMenuStrip1.SourceControl
        If source IsNot Nothing Then
            Select Case source.Name
                Case "DataColumn"
                    Clipboard.SetDataObject(DataColumn.GetClipboardContent())
                Case "DataPeace"
                    Clipboard.SetDataObject(DataPeace.GetClipboardContent())
                Case Else
                    Clipboard.SetDataObject(DataBallon.GetClipboardContent())
            End Select
            MsgBox("クリップボードにコピーしました", 64, "情報")
        End If
    End Sub
End Class