''' <summary>
''' 特別期間の設定を行います。
''' </summary>
''' <remarks></remarks>
Public Class FrmSpecialTime
    Dim WithEvents DGV_DragMove As New DataGridView_DragMove
    Dim _Data As New List(Of SpecialTimeCollection)
#Region "Property"
    Const ColText As Integer = 2
    ''' <summary>
    ''' 設定特別期間
    ''' </summary>
    ''' <value>設定済み特別期間コレクション</value>
    ''' <returns>設定済み特別期間コレクション</returns>
    ''' <remarks></remarks>
    Property SpecialTimeData() As List(Of SpecialTimeCollection)
        Get
            Return _Data
        End Get
        Set(ByVal value As List(Of SpecialTimeCollection))
            _Data = value
        End Set
    End Property
#End Region

    Private Sub FrmSpecialTime_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmSpecialTime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not CheckData() Then
            e.Cancel = True
            Return
        End If
        Grid.EndEdit()
        _Data.Clear()
        If Grid.RowCount > 1 Then
            For Row As Integer = 0 To Grid.RowCount - 2
                With Grid.Rows(Row)
                    Dim t As New SpecialTimeCollection
                    t.Start = .Cells(0).Value
                    t.Finish = .Cells(1).Value
                    t.CellText = .Cells(2).Value
                    If System.Drawing.ColorTranslator.ToOle(.Cells(3).Style.BackColor) = 0 Then
                        t.CellColor = System.Drawing.ColorTranslator.ToOle(Color.White)
                    Else
                        t.CellColor = System.Drawing.ColorTranslator.ToOle(.Cells(3).Style.BackColor)
                    End If
                    t.IsTunnel = .Cells(4).Value
                    _Data.Add(t)
                End With
            Next
        End If
    End Sub


    Private Sub FrmSpecialTime_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If _Data.Count > 0 Then
                With Grid
                    .RowCount = 1
                    For Each Item As SpecialTimeCollection In _Data
                        .RowCount += 1
                        Dim Row As Integer = .RowCount - 2
                        With .Rows(Row)
                            .Cells(0).Value = Format(Item.Start, "yyyy/MM/dd")
                            .Cells(1).Value = Format(Item.Finish, "yyyy/MM/dd")
                            .Cells(2).Value = Item.CellText
                            .Cells(3).Style.BackColor = System.Drawing.ColorTranslator.FromOle(Item.CellColor)
                            .Cells(4).Value = Item.IsTunnel
                        End With
                    Next
                End With
            End If
        Catch ex As Exception
            Logs.PutErrorEx("特別期間フォームロードエラー", ex)
        End Try
     
    End Sub
    Private Function CheckData() As Boolean
        If Grid.RowCount > 1 Then
            For Row As Integer = 0 To Grid.RowCount - 2
                With Grid.Rows(Row)
                    If Not IsDate(.Cells(0).Value) Then
                        MsgBox(String.Format("{0}行目の開始日付が不正です。", Row + 1), 48, "エラー")
                        Return False
                    End If
                    If Not IsDate(.Cells(1).Value) Then
                        MsgBox(String.Format("{0}行目の終了日付が不正です。", Row + 1), 48, "エラー")
                        Return False
                    End If
                    Dim S As Date = .Cells(0).Value
                    Dim E As Date = .Cells(1).Value
                    If S > E Then
                        MsgBox(String.Format("{0}行目の開始・終了日付が不正です。", Row + 1), 48, "エラー")
                        Return False
                    End If
                End With
            Next
        End If
        Return True
    End Function

    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        If e.ColumnIndex = 3 Then
            Using CD As New ColorDialog
                With CD
                    .Color = Grid.Rows(e.RowIndex).Cells(3).Style.BackColor
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Grid.Rows(e.RowIndex).Cells(3).Style.BackColor = .Color
                        Grid.Rows(e.RowIndex).Cells(2).Selected = True
                    End If
                End With
            End Using
        End If
    End Sub
    Private Sub MenuToUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Grid.SelectedRows.Count > 0 Then
            If Grid.SelectedRows(0).Index > 0 Then
                Call RowSwap(Grid.SelectedRows(0).Index, Grid.SelectedRows(0).Index - 1)
                Grid.Rows(Grid.SelectedRows(0).Index - 1).Selected = True
            End If
        End If
    End Sub

    Private Sub RowSwap(ByVal FromRow As Integer, ByVal ToRow As Integer)
        If Grid.Rows(FromRow).IsNewRow OrElse Grid.Rows(ToRow).IsNewRow Then
            Return
        End If
        Dim T As New SpecialTimeCollection
        With Grid.Rows(FromRow)
            T.Start = .Cells(0).Value
            T.Finish = .Cells(1).Value
            T.CellText = .Cells(2).Value
            T.CellColor = System.Drawing.ColorTranslator.ToOle(.Cells(3).Style.BackColor)
            T.IsTunnel = .Cells(4).Value
        End With
        With Grid.Rows(ToRow)
            Grid.Rows(FromRow).Cells(0).Value = .Cells(0).Value
            Grid.Rows(FromRow).Cells(1).Value = .Cells(1).Value
            Grid.Rows(FromRow).Cells(2).Value = .Cells(2).Value
            Grid.Rows(FromRow).Cells(3).Style.BackColor = .Cells(3).Style.BackColor
            Grid.Rows(FromRow).Cells(4).Value = .Cells(4).Value

            .Cells(0).Value = Format(T.Start, "yyyy/MM/dd")
            .Cells(1).Value = Format(T.Finish, "yyyy/MM/dd")
            .Cells(2).Value = T.CellText
            .Cells(3).Style.BackColor = System.Drawing.ColorTranslator.FromOle(T.CellColor)
            .Cells(4).Value = T.IsTunnel
        End With
    End Sub

    Private Sub MenuToDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Grid.SelectedRows.Count > 0 Then
            If Grid.SelectedRows(0).Index < Grid.RowCount - 2 Then
                Call RowSwap(Grid.SelectedRows(0).Index, Grid.SelectedRows(0).Index + 1)
                Grid.Rows(Grid.SelectedRows(0).Index + 1).Selected = True
            End If
        End If
    End Sub


    Private Sub MenuFormClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFormClose.Click
        Me.Close()
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Grid.EndEdit()
        Dim Row As Integer = e.RowIndex
        Select Case e.ColumnIndex
            Case 0
                With FrmCalendar
                    If Grid.Rows(Row).Cells(0).Value <> "" Then
                        If IsDate(Grid.Rows(Row).Cells(0).Value) Then
                          .SelectedDate = Grid.Rows(Row).Cells(0).Value
                        Else
                            .SelectedDate = Now
                        End If
                    Else
                        If Grid.Rows(Row).Cells(1).Value <> "" Then
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
                        Grid.Rows(Row).Cells(0).Value = Format(.SelectedDate, "yyyy/MM/dd")
                    End If
                End With
            Case 1
                With FrmCalendar
                    If Grid.Rows(Row).Cells(1).Value <> "" Then
                        If IsDate(Grid.Rows(Row).Cells(1).Value) Then
                            .SelectedDate = Grid.Rows(Row).Cells(1).Value
                        Else
                            .SelectedDate = Now
                        End If
                    Else
                        If Grid.Rows(Row).Cells(0).Value <> "" Then
                            If IsDate(Grid.Rows(Row).Cells(0).Value) Then
                                .SelectedDate = Grid.Rows(Row).Cells(0).Value
                            Else
                                .SelectedDate = Now
                            End If
                        Else
                        End If
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Grid.Rows(Row).Cells(1).Value = Format(.SelectedDate, "yyyy/MM/dd")
                    End If
                End With
        End Select
    End Sub

    Private Sub Grid_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grid.CellMouseClick
        If e.ColumnIndex = ColText Then
            Grid.ImeMode = Windows.Forms.ImeMode.On
        Else
            Grid.ImeMode = Windows.Forms.ImeMode.Off
        End If
    End Sub

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
                            .Cells(0).Value = _TT(0)
                            If IsDate(_TT(1)) Then
                                .Cells(1).Value = _TT(1)
                                .Cells(2).Value = _TT(2)
                            Else
                                .Cells(1).Value = _TT(0)
                                .Cells(2).Value = _TT(1)
                            End If
                        End With
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub MenuExport_Click(sender As Object, e As EventArgs) Handles MenuExport.Click
        If Grid.RowCount > 1 Then
            Dim FileName As String = ""
            Using SFD As New SaveFileDialog
                With SFD
                    .AddExtension = True
                    .CheckPathExists = True
                    .DefaultExt = ".wdsh"
                    .FileName = "特別期間データ.wdsh"
                    .Filter = "特別期間データファイル(*.wdsh)|*.wdsh|全てのファイル(*.*)|*.*"
                    .FilterIndex = 0
                    .OverwritePrompt = True
                    .Title = "保存"
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        FileName = .FileName
                    End If
                End With
            End Using
            If FileName <> "" Then
                ExportData.Clear()
                For Row As Integer = 0 To Grid.RowCount - 2
                    With Grid.Rows(Row)
                        If Not .IsNewRow Then
                            Dim t As New SpecialTimeCollection
                            t.Start = .Cells(0).Value
                            t.Finish = .Cells(1).Value
                            t.CellText = .Cells(2).Value
                            t.CellColor = System.Drawing.ColorTranslator.ToOle(.Cells(3).Style.BackColor)
                            t.IsTunnel = .Cells(4).Value
                            ExportData.Add(t)
                        End If
                    End With
                Next
                Call SaveSpecialTime(FileName)
                MsgBox("エクスポート完了", 64, "情報")
            End If
        End If
    End Sub
    Private Sub MenuImport_Click(sender As Object, e As EventArgs) Handles MenuImport.Click
        Dim FileName As String = ""
        Using OFD As New OpenFileDialog
            With OFD
                .AddExtension = True
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = ".wdsh"
                .Filter = "特別期間データファイル(*.wdsh)|*.wdsh|全てのファイル(*.*)|*.*"
                .FilterIndex = 0
                .Multiselect = False
                .RestoreDirectory = True
                .Title = "開く"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    FileName = .FileName
                End If
            End With
        End Using
        If FileName <> "" Then
            ExportData.Clear()
            If LoadSpecialTime(FileName) Then
                If ExportData.Count > 0 Then
                    With Grid
                        If .RowCount > 1 Then
                            If MsgBox("現在のデータをクリアして続行しますか？" & vbCrLf & "※下に追加する場合はいいえを選択してください", 4 + 32, "確認") = MsgBoxResult.Yes Then
                                .RowCount = 1
                            End If
                        End If
                        '.RowCount = 1
                        For Each Item As SpecialTimeCollection In ExportData
                            .RowCount += 1
                            Dim Row As Integer = .RowCount - 2
                            With .Rows(Row)
                                .Cells(0).Value = Format(Item.Start, "yyyy/MM/dd")
                                .Cells(1).Value = Format(Item.Finish, "yyyy/MM/dd")
                                .Cells(2).Value = Item.CellText
                                .Cells(3).Style.BackColor = System.Drawing.ColorTranslator.FromOle(Item.CellColor)
                                .Cells(4).Value = Item.IsTunnel
                            End With
                        Next
                    End With
                End If
            End If

        End If
    End Sub

    Dim ExportData As New List(Of SpecialTimeCollection)
    Private Function SaveSpecialTime(FileName As String) As Boolean
        Try
            If Not String.IsNullOrEmpty(FileName) Then
                If System.IO.File.Exists(FileName) Then System.IO.File.Delete(FileName)

                Dim LocalClass() As SpecialTimeCollection = TryCast(ExportData.ToArray, SpecialTimeCollection())

                If Not LocalClass Is Nothing Then
                    Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(SpecialTimeCollection()))
                    Using FS As New IO.FileStream(FileName, IO.FileMode.Create)
                        SRZ.Serialize(FS, LocalClass)
                    End Using
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    Private Function LoadSpecialTime(FileName As String) As Boolean
        Try
            If System.IO.File.Exists(FileName) Then
                Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(SpecialTimeCollection()))
                Using FS As New IO.FileStream(FileName, IO.FileMode.Open)
                    Dim LocalClass() As SpecialTimeCollection
                    LocalClass = SRZ.Deserialize(FS)

                    Dim i As Integer = 0
                    For Each LoopClass As SpecialTimeCollection In LocalClass
                        ExportData.Add(LoopClass)
                        'ExportData(i) = LoopClass
                        'i += 1
                    Next
                End Using
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, 48, "エラー")
            Return False
        End Try

    End Function


    Private Sub Grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid.CellContentClick

    End Sub
End Class
