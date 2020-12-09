Imports System.IO
''' <summary>
''' ファイル操作モジュール
''' </summary>
''' <remarks></remarks>
Module ModuleSaveLoadData
    ''' <summary>
    ''' TODO:XMLデータ書込
    ''' </summary>
    ''' <param name="Data">書き込むデータ</param>
    ''' <param name="FileName">ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function XMLSaveData(ByVal Data As WindyDataCollection, ByVal FileName As String)
        Try
            Dim _TmpFile As String = TemporaryFile() '作業テンポラリファイル名

            Dim LocalClass() As WindyXMLDataCollection = Nothing
            ReDim LocalClass(0)
            'For i As Integer = 0 To StampData.Length - 1
            LocalClass(0) = New WindyXMLDataCollection
            With LocalClass(0)
                .Title = Data.Title
                .Owner = Data.Owner
                .IsExclusion = Data.IsExclusion
                .ExclusionPassword = SQLEncode(Data.ExclusionPassword)
                .LoadLock = Data.LoadLock
                .RowCount = Data.RowCount
                .ColCount = Data.ColCount
                .RowHeight = Data.RowHeight
                .Zoom = Data.Zoom
                .PieceCenterHeight = Data.PieceCenterHeight
                .PieceLayout = Data.PieceLayout
                .ViewTopTime = Data.ViewTopTime
                .IsWaterFall = Data.IsWaterFall
                .IsWaterFallLock = Data.IsWaterFallLock
                .CellDateFormat = Data.CellDateFormat
                .NACellValue = Data.NACellValue
                .IndentWidth = Data.IndentLevel

                ReDim .Header(Data.Header.Count - 1)
                For i As Integer = 0 To Data.Header.Count - 1
                    .Header(i) = New HeaderCollection
                    .Header(i).ColIndex = Data.Header(i).ColIndex
                    .Header(i).Text = Data.Header(i).Text
                    .Header(i).HAlign = Data.Header(i).HAlign
                    .Header(i).VAlign = Data.Header(i).VAlign
                    .Header(i).Width = Data.Header(i).Width
                    .Header(i).CellMerge = Data.Header(i).CellMerge
                    .Header(i).IsHidden = Data.Header(i).IsHidden
                Next

                ReDim .RowAttrib(Data.RowAttrib.Count - 1)
                For i As Integer = 0 To Data.RowAttrib.Count - 1
                    .RowAttrib(i) = New RowAttribCollection
                    .RowAttrib(i).RowIndex = Data.RowAttrib(i).RowIndex
                    .RowAttrib(i).BackColor = Data.RowAttrib(i).BackColor
                    .RowAttrib(i).IsHidden = Data.RowAttrib(i).IsHidden
                Next

                ReDim .HeaderCell(Data.HeaderCell.Count - 1)
                For i As Integer = 0 To Data.HeaderCell.Count - 1
                    .HeaderCell(i) = New HeaderCellCollection
                    .HeaderCell(i).RowIndex = Data.HeaderCell(i).RowIndex
                    .HeaderCell(i).ColIndex = Data.HeaderCell(i).ColIndex
                    .HeaderCell(i).HAlign = Data.HeaderCell(i).HAlign
                    .HeaderCell(i).VAlign = Data.HeaderCell(i).VAlign
                    .HeaderCell(i).BackColor = Data.HeaderCell(i).BackColor
                    .HeaderCell(i).ForeColor = Data.HeaderCell(i).ForeColor
                    .HeaderCell(i).Text = Data.HeaderCell(i).Text
                    .HeaderCell(i).IsHidden = Data.HeaderCell(i).IsHidden
                    .HeaderCell(i).IndentLevel = Data.HeaderCell(i).IndentLevel
                Next

                ReDim .SpecialTime(Data.SpecialTime.Count - 1)
                For i As Integer = 0 To Data.SpecialTime.Count - 1
                    .SpecialTime(i) = New SpecialTimeCollection
                    .SpecialTime(i).Start = Data.SpecialTime(i).Start
                    .SpecialTime(i).Finish = Data.SpecialTime(i).Finish
                    .SpecialTime(i).CellText = Data.SpecialTime(i).CellText
                    .SpecialTime(i).CellColor = Data.SpecialTime(i).CellColor
                    .SpecialTime(i).IsTunnel = Data.SpecialTime(i).IsTunnel
                Next

                ReDim .Piece(Data.Piece.Count - 1)
                For i As Integer = 0 To Data.Piece.Count - 1
                    .Piece(i) = New PieceCollection
                    .Piece(i).RowIndex = Data.Piece(i).RowIndex
                    .Piece(i).ColIndex = Data.Piece(i).ColIndex
                    .Piece(i).Start = Data.Piece(i).Start
                    .Piece(i).Finish = Data.Piece(i).Finish
                    .Piece(i).PieceColor = Data.Piece(i).PieceColor
                    .Piece(i).Shape = Data.Piece(i).Shape
                    .Piece(i).ShapeName = Data.Piece(i).ShapeName
                    .Piece(i).Tunnel = Data.Piece(i).Tunnel

                    .Piece(i).CaptionLeft = Data.Piece(i).CaptionLeft
                    .Piece(i).CaptionRight = Data.Piece(i).CaptionRight
                    .Piece(i).CaptionCenter = Data.Piece(i).CaptionCenter
                    .Piece(i).ProgressBar = Data.Piece(i).ProgressBar
                    .Piece(i).LockPiece = Data.Piece(i).LockPiece
                    .Piece(i).IsSummaryPiece = Data.Piece(i).IsSummaryPiece
                    .Piece(i).UseSummaryProgress = Data.Piece(i).UseSummaryProgress
                    .Piece(i).IsSummaryExclusion = Data.Piece(i).IsSummaryExclusion
                Next

                ReDim .RelatedLine(Data.RelatedLine.Count - 1)
                For i As Integer = 0 To Data.RelatedLine.Count - 1
                    .RelatedLine(i) = New RelatedLineCollection
                    .RelatedLine(i).FromRowIndex = Data.RelatedLine(i).FromRowIndex
                    .RelatedLine(i).FromColIndex = Data.RelatedLine(i).FromColIndex
                    .RelatedLine(i).ToRowIndex = Data.RelatedLine(i).ToRowIndex
                    .RelatedLine(i).ToColIndex = Data.RelatedLine(i).ToColIndex
                    .RelatedLine(i).RelatedStyle = Data.RelatedLine(i).RelatedStyle
                    .RelatedLine(i).RelatedLineStyle = Data.RelatedLine(i).RelatedLineStyle
                Next

                ReDim .Balloon(Data.Balloon.Count - 1)
                For i As Integer = 0 To Data.Balloon.Count - 1
                    .Balloon(i) = New BalloonCollection
                    .Balloon(i).RowIndex = Data.Balloon(i).RowIndex
                    .Balloon(i).ColIndex = Data.Balloon(i).ColIndex
                    .Balloon(i).Pont = Data.Balloon(i).Pont
                    .Balloon(i).AnchorPoint = Data.Balloon(i).AnchorPoint
                    .Balloon(i).AnchorRelPoint = Data.Balloon(i).AnchorRelPoint
                    .Balloon(i).BackColor = Data.Balloon(i).BackColor
                    .Balloon(i).Style = Data.Balloon(i).Style

                    .Balloon(i).BalloonShape = Data.Balloon(i).BalloonShape
                    .Balloon(i).Caption = Data.Balloon(i).Caption
                Next

                ReDim .WorkHistory(Data.WorkHistory.Count - 1)
                For i As Integer = 0 To Data.WorkHistory.Count - 1
                    .WorkHistory(i) = New WorkHistoryCollection
                    .WorkHistory(i).WorkTime = Data.WorkHistory(i).WorkTime
                    .WorkHistory(i).WorkerName = Data.WorkHistory(i).WorkerName
                    .WorkHistory(i).WorkNote = Data.WorkHistory(i).WorkNote
                Next

                'マスタピース
                If Not IsNothing(Data.MasterPiece) Then
                    .MasterPiece = New PieceCollection
                    .MasterPiece.RowIndex = Data.MasterPiece.RowIndex
                    .MasterPiece.ColIndex = Data.MasterPiece.ColIndex
                    .MasterPiece.Start = Data.MasterPiece.Start
                    .MasterPiece.Finish = Data.MasterPiece.Finish
                    .MasterPiece.PieceColor = Data.MasterPiece.PieceColor
                    .MasterPiece.Shape = Data.MasterPiece.Shape
                    .MasterPiece.ShapeName = Data.MasterPiece.ShapeName
                    .MasterPiece.Tunnel = Data.MasterPiece.Tunnel
                    .MasterPiece.CaptionLeft = Data.MasterPiece.CaptionLeft
                    .MasterPiece.CaptionRight = Data.MasterPiece.CaptionRight
                    .MasterPiece.CaptionCenter = Data.MasterPiece.CaptionCenter
                    .MasterPiece.ProgressBar = Data.MasterPiece.ProgressBar
                    .MasterPiece.LockPiece = Data.MasterPiece.LockPiece
                End If
                'テンプレートピース
                If Not IsNothing(Data.TemplatePiece) Then
                    .TemplatePiece = New PieceCollection
                    .TemplatePiece.RowIndex = Data.TemplatePiece.RowIndex
                    .TemplatePiece.ColIndex = Data.TemplatePiece.ColIndex
                    .TemplatePiece.Start = Data.TemplatePiece.Start
                    .TemplatePiece.Finish = Data.TemplatePiece.Finish
                    .TemplatePiece.PieceColor = Data.TemplatePiece.PieceColor
                    .TemplatePiece.Shape = Data.TemplatePiece.Shape
                    .TemplatePiece.ShapeName = Data.TemplatePiece.ShapeName
                    .TemplatePiece.Tunnel = Data.TemplatePiece.Tunnel
                    .TemplatePiece.CaptionLeft = Data.TemplatePiece.CaptionLeft
                    .TemplatePiece.CaptionRight = Data.TemplatePiece.CaptionRight
                    .TemplatePiece.CaptionCenter = Data.TemplatePiece.CaptionCenter
                    .TemplatePiece.ProgressBar = Data.TemplatePiece.ProgressBar
                End If
            End With
            'Next

            '一旦テンポラリファイルに書き込む
            Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(WindyXMLDataCollection()))
            Using FS As New IO.FileStream(_TmpFile, IO.FileMode.Create)
                SRZ.Serialize(FS, LocalClass)
            End Using
            'エンコードの際にテンポラリから正規ファイルに移管する
            Call FileEncode(_TmpFile, FileName)

            'テンポラリファイルを削除する
            If File.Exists(_TmpFile) Then File.Delete(_TmpFile)

            Logs.PutInformation("ファイル保存", FileName)
        Catch ex As Exception
            Logs.PutErrorEx("ファイル保存エラー", ex, True)
        End Try
        Return True
    End Function
    ''' <summary>
    ''' TODO:XMLデータ読込
    ''' </summary>
    ''' <param name="Data">読み込んだデータ</param>
    ''' <param name="FileName">ファイル名</param>
    ''' <returns>True:読込成功</returns>
    ''' <remarks></remarks>
    Public Function XMLReadData(ByRef Data As List(Of WindyDataCollection), ByVal FileName As String) As Boolean

        If File.Exists(FileName) Then
            Try
                Dim _TmpFile As String = TemporaryFile() '作業テンポラリファイル名
                'デコード時に正規ファイルからテンポラリファイルに移管する
                Call FileDecode(FileName, _TmpFile)

                Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(WindyXMLDataCollection()))
                'テンポラリファイルから読み込む
                Using FS As New IO.FileStream(_TmpFile, IO.FileMode.Open)
                    Dim LocalClass() As WindyXMLDataCollection = SRZ.Deserialize(FS)
                    Dim D As New WindyDataCollection
                    D.Title = LocalClass(0).Title
                    D.Owner = LocalClass(0).Owner
                    D.IsExclusion = LocalClass(0).IsExclusion
                    D.ExclusionPassword = SQLDecode(LocalClass(0).ExclusionPassword)
                    D.LoadLock = LocalClass(0).LoadLock
                    D.RowCount = LocalClass(0).RowCount
                    D.ColCount = LocalClass(0).ColCount
                    D.RowHeight = LocalClass(0).RowHeight
                    D.Zoom = LocalClass(0).Zoom
                    D.PieceCenterHeight = LocalClass(0).PieceCenterHeight
                    D.PieceLayout = LocalClass(0).PieceLayout
                    D.ViewTopTime = LocalClass(0).ViewTopTime
                    D.IsWaterFall = LocalClass(0).IsWaterFall
                    D.IsWaterFallLock = LocalClass(0).IsWaterFallLock
                    D.CellDateFormat = LocalClass(0).CellDateFormat
                    D.NACellValue = LocalClass(0).NACellValue
                    D.IndentLevel = LocalClass(0).IndentWidth

                    If Not IsNothing(LocalClass(0).Header) Then
                        For i As Integer = 0 To LocalClass(0).Header.Length - 1
                            Dim Itm As New HeaderCollection
                            Itm.ColIndex = LocalClass(0).Header(i).ColIndex
                            Itm.Text = LocalClass(0).Header(i).Text
                            Itm.HAlign = LocalClass(0).Header(i).HAlign
                            Itm.VAlign = LocalClass(0).Header(i).VAlign
                            Itm.Width = LocalClass(0).Header(i).Width
                            Itm.CellMerge = LocalClass(0).Header(i).CellMerge
                            Itm.IsHidden = LocalClass(0).Header(i).IsHidden
                            D.Header.Add(Itm)
                        Next
                    End If

                    If Not IsNothing(LocalClass(0).RowAttrib) Then
                        For i As Integer = 0 To LocalClass(0).RowAttrib.Length - 1
                            Dim Itm As New RowAttribCollection
                            Itm.RowIndex = LocalClass(0).RowAttrib(i).RowIndex
                            Itm.BackColor = LocalClass(0).RowAttrib(i).BackColor
                            Itm.IsHidden = LocalClass(0).RowAttrib(i).IsHidden
                            D.RowAttrib.Add(Itm)
                        Next
                    End If

                    If Not IsNothing(LocalClass(0).HeaderCell) Then
                        For i As Integer = 0 To LocalClass(0).HeaderCell.Length - 1
                            Dim Itm As New HeaderCellCollection
                            Itm.RowIndex = LocalClass(0).HeaderCell(i).RowIndex
                            Itm.ColIndex = LocalClass(0).HeaderCell(i).ColIndex
                            Itm.Text = LocalClass(0).HeaderCell(i).Text
                            Itm.HAlign = LocalClass(0).HeaderCell(i).HAlign
                            Itm.VAlign = LocalClass(0).HeaderCell(i).VAlign
                            Itm.BackColor = LocalClass(0).HeaderCell(i).BackColor
                            Itm.ForeColor = LocalClass(0).HeaderCell(i).ForeColor
                            Itm.IsHidden = LocalClass(0).HeaderCell(i).IsHidden
                            Itm.IndentLevel = LocalClass(0).HeaderCell(i).IndentLevel
                            D.HeaderCell.Add(Itm)
                        Next
                    End If

                    If Not IsNothing(LocalClass(0).SpecialTime) Then
                        For i As Integer = 0 To LocalClass(0).SpecialTime.Length - 1
                            Dim Itm As New SpecialTimeCollection
                            Itm.Start = LocalClass(0).SpecialTime(i).Start
                            Itm.Finish = LocalClass(0).SpecialTime(i).Finish
                            Itm.CellText = LocalClass(0).SpecialTime(i).CellText
                            Itm.CellColor = LocalClass(0).SpecialTime(i).CellColor
                            Itm.IsTunnel = LocalClass(0).SpecialTime(i).IsTunnel
                            D.SpecialTime.Add(Itm)
                        Next
                    End If

                    If Not IsNothing(LocalClass(0).Piece) Then
                        For i As Integer = 0 To LocalClass(0).Piece.Length - 1
                            Dim Itm As New PieceCollection
                            Itm.RowIndex = LocalClass(0).Piece(i).RowIndex
                            Itm.ColIndex = LocalClass(0).Piece(i).ColIndex
                            Itm.Start = LocalClass(0).Piece(i).Start
                            Itm.Finish = LocalClass(0).Piece(i).Finish
                            Itm.PieceColor = LocalClass(0).Piece(i).PieceColor
                            Itm.Shape = LocalClass(0).Piece(i).Shape
                            Itm.ShapeName = LocalClass(0).Piece(i).ShapeName
                            Itm.Tunnel = LocalClass(0).Piece(i).Tunnel
                            Itm.CaptionLeft = LocalClass(0).Piece(i).CaptionLeft
                            Itm.CaptionCenter = LocalClass(0).Piece(i).CaptionCenter
                            Itm.CaptionRight = LocalClass(0).Piece(i).CaptionRight
                            Itm.ProgressBar = LocalClass(0).Piece(i).ProgressBar
                            Itm.LockPiece = LocalClass(0).Piece(i).LockPiece
                            Itm.IsSummaryPiece = LocalClass(0).Piece(i).IsSummaryPiece
                            Itm.UseSummaryProgress = LocalClass(0).Piece(i).UseSummaryProgress
                            Itm.IsSummaryExclusion = LocalClass(0).Piece(i).IsSummaryExclusion
                            D.Piece.Add(Itm)
                        Next
                    End If

                    If Not IsNothing(LocalClass(0).RelatedLine) Then
                        For i As Integer = 0 To LocalClass(0).RelatedLine.Length - 1
                            Dim Itm As New RelatedLineCollection
                            Itm.FromRowIndex = LocalClass(0).RelatedLine(i).FromRowIndex
                            Itm.FromColIndex = LocalClass(0).RelatedLine(i).FromColIndex
                            Itm.ToRowIndex = LocalClass(0).RelatedLine(i).ToRowIndex
                            Itm.ToColIndex = LocalClass(0).RelatedLine(i).ToColIndex
                            Itm.RelatedStyle = LocalClass(0).RelatedLine(i).RelatedStyle
                            Itm.RelatedLineStyle = LocalClass(0).RelatedLine(i).RelatedLineStyle
                            D.RelatedLine.Add(Itm)
                        Next
                    End If

                    If Not IsNothing(LocalClass(0).Balloon) Then
                        For i As Integer = 0 To LocalClass(0).Balloon.Length - 1
                            Dim Itm As New BalloonCollection
                            Itm.RowIndex = LocalClass(0).Balloon(i).RowIndex
                            Itm.ColIndex = LocalClass(0).Balloon(i).ColIndex
                            Itm.Pont = LocalClass(0).Balloon(i).Pont
                            Itm.AnchorPoint = LocalClass(0).Balloon(i).AnchorPoint
                            Itm.AnchorRelPoint = LocalClass(0).Balloon(i).AnchorRelPoint
                            Itm.BackColor = LocalClass(0).Balloon(i).BackColor
                            Itm.Style = LocalClass(0).Balloon(i).Style
                            Itm.BalloonShape = LocalClass(0).Balloon(i).BalloonShape
                            Itm.Caption = LocalClass(0).Balloon(i).Caption
                            D.Balloon.Add(Itm)
                        Next
                    End If

                    If Not IsNothing(LocalClass(0).WorkHistory) Then
                        For i As Integer = 0 To LocalClass(0).WorkHistory.Length - 1
                            Dim Itm As New WorkHistoryCollection
                            Itm.WorkTime = LocalClass(0).WorkHistory(i).WorkTime
                            Itm.WorkerName = LocalClass(0).WorkHistory(i).WorkerName
                            Itm.WorkNote = LocalClass(0).WorkHistory(i).WorkNote
                            D.WorkHistory.Add(Itm)
                        Next
                    End If

                    'マスタピース
                    If Not IsNothing(LocalClass(0).MasterPiece) Then
                        Dim Itm As New PieceCollection
                        Itm.RowIndex = LocalClass(0).MasterPiece.RowIndex
                        Itm.ColIndex = LocalClass(0).MasterPiece.ColIndex
                        Itm.Start = LocalClass(0).MasterPiece.Start
                        Itm.Finish = LocalClass(0).MasterPiece.Finish
                        Itm.PieceColor = LocalClass(0).MasterPiece.PieceColor
                        Itm.Shape = LocalClass(0).MasterPiece.Shape
                        Itm.ShapeName = LocalClass(0).MasterPiece.ShapeName
                        Itm.Tunnel = LocalClass(0).MasterPiece.Tunnel
                        Itm.CaptionLeft = LocalClass(0).MasterPiece.CaptionLeft
                        Itm.CaptionCenter = LocalClass(0).MasterPiece.CaptionCenter
                        Itm.CaptionRight = LocalClass(0).MasterPiece.CaptionRight
                        Itm.ProgressBar = LocalClass(0).MasterPiece.ProgressBar
                        Itm.LockPiece = LocalClass(0).MasterPiece.LockPiece
                        D.MasterPiece = Itm
                    End If

                    'テンプレートピース
                    If Not IsNothing(LocalClass(0).TemplatePiece) Then
                        Dim Itm As New PieceCollection
                        Itm.RowIndex = LocalClass(0).TemplatePiece.RowIndex
                        Itm.ColIndex = LocalClass(0).TemplatePiece.ColIndex
                        Itm.Start = LocalClass(0).TemplatePiece.Start
                        Itm.Finish = LocalClass(0).TemplatePiece.Finish
                        Itm.PieceColor = LocalClass(0).TemplatePiece.PieceColor
                        Itm.Shape = LocalClass(0).TemplatePiece.Shape
                        Itm.ShapeName = LocalClass(0).TemplatePiece.ShapeName
                        Itm.Tunnel = LocalClass(0).TemplatePiece.Tunnel
                        Itm.CaptionLeft = LocalClass(0).TemplatePiece.CaptionLeft
                        Itm.CaptionCenter = LocalClass(0).TemplatePiece.CaptionCenter
                        Itm.CaptionRight = LocalClass(0).TemplatePiece.CaptionRight
                        Itm.ProgressBar = LocalClass(0).TemplatePiece.ProgressBar
                        D.TemplatePiece = Itm
                    End If
                    Data.Add(D)
                End Using

                '読込済みのテンポラリファイルを削除する
                If File.Exists(_TmpFile) Then File.Delete(_TmpFile)
                Logs.PutInformation("ファイル読み込み", FileName)
            Catch ex As Exception
                Logs.PutErrorEx("ファイル読み込みエラー", ex, True)
            End Try
        End If
        Return True
    End Function


  

    ''' <summary>
    ''' ファイルをエンコードする
    ''' </summary>
    ''' <param name="FromName">エンコードするファイル</param>
    ''' <param name="ToFile">エンコード先ファイル</param>
    ''' <remarks></remarks>
    Public Sub FileEncode(FromName As String, ToFile As String)
        Try
            Dim _Data As String = ""
            'Using sr As New System.IO.StreamReader(FileName, System.Text.Encoding.GetEncoding("shift_jis"))
            Using sr As New System.IO.StreamReader(FromName)
                _Data = sr.ReadToEnd()
            End Using
            _Data = SQLEncode(_Data)
            'Using sw As New System.IO.StreamWriter(FileName, False, System.Text.Encoding.GetEncoding("shift_jis"))
            Using sw As New System.IO.StreamWriter(ToFile)
                sw.Write(_Data)
            End Using
            Logs.PutInformation("エンコード", FromName & " → " & ToFile)
        Catch ex As Exception
            Logs.PutErrorEx("ファイルエンコードエラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' ファイルをデコードする
    ''' </summary>
    ''' <param name="FromName">デコード元ファイル</param>
    ''' <param name="ToFile">デコード先ファイル</param>
    ''' <remarks></remarks>
    Public Sub FileDecode(FromName As String, ToFile As String)
        Try
            Dim _Data As String = ""
            'Using sr As New System.IO.StreamReader(FileName, System.Text.Encoding.GetEncoding("shift_jis"))
            Using sr As New System.IO.StreamReader(FromName)
                _Data = sr.ReadToEnd()
            End Using
            _Data = SQLDecode(_Data)
            'Using sw As New System.IO.StreamWriter(FileName, False, System.Text.Encoding.GetEncoding("shift_jis"))
            Using sw As New System.IO.StreamWriter(ToFile)
                sw.Write(_Data)
            End Using
            Logs.PutInformation("デコード", FromName & " → " & ToFile)
        Catch ex As Exception
            Logs.PutErrorEx("ファイルデコードエラー", ex, True)
        End Try
    End Sub
#Region "ファイル履歴関係"
    Dim FileListName As String = AppFullPath("FileList.xml")
    ''' <summary>
    ''' ファイル履歴保存
    ''' </summary>
    ''' <param name="Data">読込ファイル履歴</param>
    ''' <returns>True:読込成功</returns>
    ''' <remarks></remarks>
    Public Function XMLSaveFileList(ByVal Data As List(Of FileListCollection))

        Dim LocalClass() As FileListCollection = Nothing
        ReDim LocalClass(Data.Count - 1)
        For i As Integer = 0 To Data.Count - 1
            LocalClass(i) = New FileListCollection
            LocalClass(i).Title = Data(i).Title
            LocalClass(i).FileName = Data(i).FileName
        Next
        Try
            Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(FileListCollection()))
            Using FS As New IO.FileStream(FileListName, IO.FileMode.Create)
                SRZ.Serialize(FS, LocalClass)
            End Using
            Logs.PutInformation("履歴ファイル保存", FileListName)
        Catch ex As Exception
            Logs.PutErrorEx("履歴ファイル保存エラー", ex, True)
        End Try
        Return True
    End Function
    ''' <summary>
    ''' ファイル履歴読込
    ''' </summary>
    ''' <param name="Data">読込ファイル履歴</param>
    ''' <returns>True:読込成功</returns>
    ''' <remarks></remarks>
    Public Function XMLReadFileList(ByRef Data As List(Of FileListCollection)) As Boolean
        If File.Exists(FileListName) Then
            Try
                If File.Exists(FileListName) Then
                    Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(FileListCollection()))
                    Using FS As New IO.FileStream(FileListName, IO.FileMode.Open)
                        Dim LocalClass() As FileListCollection = SRZ.Deserialize(FS)
                        For Each Item As FileListCollection In LocalClass
                            Data.Add(Item)
                        Next
                    End Using
                End If
                Logs.PutInformation("履歴ファイル読み込み", FileListName)
            Catch ex As Exception
                Logs.PutErrorEx("履歴ファイル読込エラー", ex, True)
                Return False
            End Try
        End If
        Return True
    End Function
#End Region
#Region "休日ファイル関係"
    Dim HolidayListName As String = AppFullPath("HolidayFile.xml")
    ''' <summary>
    ''' 休日設定保存
    ''' </summary>
    ''' <param name="Data">保存休日データ</param>
    ''' <returns>True:読込成功</returns>
    ''' <remarks></remarks>
    Public Function XMLSaveHolidayList(ByVal Data As List(Of HolidayCollection))

        Dim LocalClass() As HolidayCollection = Nothing
        ReDim LocalClass(Data.Count - 1)
        For i As Integer = 0 To Data.Count - 1
            LocalClass(i) = New HolidayCollection
            LocalClass(i).HolidayStartDate = Data(i).HolidayStartDate
            LocalClass(i).HolidayFinDate = Data(i).HolidayFinDate
            LocalClass(i).HolidayName = Data(i).HolidayName
        Next
        Try
            Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(HolidayCollection()))
            Using FS As New IO.FileStream(HolidayListName, IO.FileMode.Create)
                SRZ.Serialize(FS, LocalClass)
            End Using
            Logs.PutInformation("休日ファイル保存", FileListName)
        Catch ex As Exception
            Logs.PutErrorEx("休日ファイル保存エラー", ex, True)
        End Try
        Return True
    End Function
    ''' <summary>
    ''' 休日設定読込
    ''' </summary>
    ''' <param name="Data">読込休日データ</param>
    ''' <returns>True:読込成功</returns>
    ''' <remarks></remarks>
    Public Function XMLReadHolidayList(ByRef Data As List(Of HolidayCollection)) As Boolean
        If File.Exists(FileListName) Then
            Try
                If File.Exists(HolidayListName) Then
                    Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(HolidayCollection()))
                    Using FS As New IO.FileStream(HolidayListName, IO.FileMode.Open)
                        Dim LocalClass() As HolidayCollection = SRZ.Deserialize(FS)
                        For Each Item As HolidayCollection In LocalClass
                            Data.Add(Item)
                        Next
                    End Using
                End If
                Logs.PutInformation("休日ファイル書込", FileListName)
            Catch ex As Exception
                Logs.PutErrorEx("休日ファイル読込エラー", ex, True)
                Return False
            End Try
        End If
        Return True
    End Function
#End Region

    Public Function AppFullPath(ByVal FileName As String) As String

        AppFullPath = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, FileName)

    End Function
    ''' <summary>
    ''' テンポラリファイル名を生成する
    ''' </summary>
    ''' <returns>生成ファイル名</returns>
    ''' <remarks></remarks>
    Public Function TemporaryFile() As String
        Return TemporaryFolder(String.Format("{0}.wtf", CreateUniqueString))
    End Function
    ''' <summary>
    ''' 特殊フォルダパスを検索する
    ''' </summary>
    ''' <param name="TargetFolder">対象となる特殊フォルダ</param>
    ''' <param name="FileName">ファイル名</param>
    ''' <returns>ファイル名を含むフルパス</returns>
    ''' <remarks>
    ''' <para>ファイル名指定時</para>
    ''' <para>ファイル名指定時はファイル名を含むフルパスを返します。(特殊フォルダ名＋固定フォルダ名＋ファイル名)またその特殊フォルダが無い場合は自動的に作成されます。</para>
    ''' <para>ファイル名が未指定の場合は特殊フォルダのパスを返します。(特殊フォルダ名＋固定フォルダ）但しこのフォルダの自動作成は行われません</para>
    ''' <para>また、特殊フォルダ自体が存在しない場合は””が帰ります。</para>
    ''' </remarks>s
    Public Function NFuncSystemFullPath(TargetFolder As System.Environment.SpecialFolder, Optional FileName As String = "") As String
        'http://dobon.net/vb/dotnet/file/getfolderpath.html
        Dim _Folder As System.Environment.SpecialFolder = Environment.SpecialFolder.ApplicationData
        Dim _LocalApricationName As String = "NKS\Windy2" '←アプリケーションによって変更してください。

        Try
            If FileName = "" Then
                'フォルダが存在しない時は空の文字列を返す（既定）
                Dim _SysPath As String = Environment.GetFolderPath(TargetFolder, Environment.SpecialFolderOption.None)
                If _SysPath = "" Then
                    Return ""
                Else
                    Return My.Computer.FileSystem.CombinePath(_SysPath, _LocalApricationName)
                End If
            Else
                'フォルダが存在しない時は作成して、パスを返す
                Dim _SysPath As String = Environment.GetFolderPath(TargetFolder, Environment.SpecialFolderOption.Create)
                Dim _Path2 As String = My.Computer.FileSystem.CombinePath(_SysPath, _LocalApricationName)
                If Not System.IO.Directory.Exists(_Path2) Then
                    System.IO.Directory.CreateDirectory(_Path2)
                End If
                Return My.Computer.FileSystem.CombinePath(_Path2, FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try

    End Function
    ''' <summary>
    ''' テンポラリフォルダを取得する
    ''' </summary>
    ''' <param name="FileName">ファイル名</param>
    ''' <returns>ファイル名を含んだフルパス</returns>
    ''' <remarks>
    ''' ファイル名未指定の場合はテンポラリフォルダのフォルダパスが返されます
    ''' </remarks>
    Public Function TemporaryFolder(Optional FileName As String = "") As String
        'https://dobon.net/vb/dotnet/file/gettempfilename.html
        Dim Fld As String = My.Computer.FileSystem.SpecialDirectories.Temp
        Try
            If FileName = "" Then
                Return Fld
            Else
                'フォルダが存在しない時は作成して、パスを返す
                If Not System.IO.Directory.Exists(Fld) Then
                    System.IO.Directory.CreateDirectory(Fld)
                End If
                Return My.Computer.FileSystem.CombinePath(Fld, FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' 一意の文字列を生成します。
    ''' </summary>
    ''' <returns>生成文字列</returns>
    ''' <remarks></remarks>
    Public Function CreateUniqueString() As String
        Dim StrAry As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklnmopqrstuvwxyz0123456789"
        Dim PasW As New System.Text.StringBuilder
        For Count As Integer = 1 To 20
            PasW.Append(StrAry.Chars(NFuncRollDice(Len(StrAry))))
        Next
        Return PasW.ToString
    End Function
    Private Function NFuncRollDice(ByVal NumSides As Integer) As Integer
        Dim randomNumber(0) As Byte
        Dim Gen As New System.Security.Cryptography.RNGCryptoServiceProvider()
        Gen.GetBytes(randomNumber)
        Dim rand As Integer = Convert.ToInt32(randomNumber(0))
        Return rand Mod NumSides
    End Function 'RollDice
End Module
''' <summary>
''' 休日設定コレクション
''' </summary>
''' <remarks></remarks>
Public Class HolidayCollection
    ''' <summary>
    ''' 休日開始日
    ''' </summary>
    ''' <remarks></remarks>
    Public HolidayStartDate As Date
    ''' <summary>
    ''' 休日終了日
    ''' </summary>
    ''' <remarks></remarks>
    Public HolidayFinDate As Date
    ''' <summary>
    ''' 休日名
    ''' </summary>
    ''' <remarks></remarks>
    Public HolidayName As String
    Sub New()
        Me.HolidayStartDate = Nothing
        Me.HolidayFinDate = Nothing
        Me.HolidayName = ""
    End Sub

End Class
Public Class FileListCollection
    ''' <summary>
    ''' タイトル
    ''' </summary>
    ''' <remarks></remarks>
    Public Title As String
    ''' <summary>
    ''' ファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public FileName As String
    Sub New()
        Me.Title = ""
        Me.FileName = ""
    End Sub
End Class
''' <summary>
''' ヘッダーコレクション
''' </summary>
''' <remarks></remarks>
Public Class HeaderCollection
    ''' <summary>
    ''' 列番号
    ''' </summary>
    ''' <remarks></remarks>
    Public ColIndex As Integer
    ''' <summary>
    ''' タイトル
    ''' </summary>
    ''' <remarks></remarks>
    Public Text As String
    ''' <summary>
    ''' 垂直位置
    ''' </summary>
    ''' <remarks></remarks>
    Public HAlign As Integer
    ''' <summary>
    ''' 水平位置
    ''' </summary>
    ''' <remarks></remarks>
    Public VAlign As Integer
    ''' <summary>
    ''' 表示幅
    ''' </summary>
    ''' <remarks></remarks>
    Public Width As Integer
    ''' <summary>
    ''' マージンスイッチ
    ''' </summary>
    ''' <remarks></remarks>
    Public CellMerge As Integer
    ''' <summary>
    ''' 非表示スイッチ
    ''' </summary>
    ''' <remarks></remarks>
    Public IsHidden As Boolean
    Sub New()
        Me.ColIndex = 0
        Me.Text = ""
        Me.HAlign = 0
        Me.VAlign = 0
        Me.Width = 0
        Me.CellMerge = 0
        Me.IsHidden = False
    End Sub
End Class
''' <summary>
''' セルコレクション
''' </summary>
''' <remarks></remarks>
Public Class HeaderCellCollection
    ''' <summary>
    ''' 行番号
    ''' </summary>
    ''' <remarks></remarks>
    Public RowIndex As Integer
    ''' <summary>
    ''' 列番号
    ''' </summary>
    ''' <remarks></remarks>
    Public ColIndex As Integer
    ''' <summary>
    ''' 内容
    ''' </summary>
    ''' <remarks></remarks>
    Public Text As String
    ''' <summary>
    ''' 水平位置
    ''' </summary>
    ''' <remarks></remarks>
    Public HAlign As Integer
    ''' <summary>
    ''' 垂直位置
    ''' </summary>
    ''' <remarks></remarks>
    Public VAlign As Integer
    ''' <summary>
    ''' 背景色
    ''' </summary>
    ''' <remarks></remarks>
    Public BackColor As System.UInt32
    ''' <summary>
    ''' 文字色
    ''' </summary>
    ''' <remarks></remarks>
    Public ForeColor As System.UInt32
    ''' <summary>
    ''' 非表示スイッチ
    ''' </summary>
    ''' <remarks></remarks>
    Public IsHidden As Boolean
    ''' <summary>
    ''' インデントレベル
    ''' </summary>
    ''' <remarks></remarks>
    Public IndentLevel As Integer
    Sub New()
        Me.RowIndex = 0
        Me.ColIndex = 0
        Me.Text = ""
        Me.HAlign = 0
        Me.VAlign = 0
        Me.BackColor = RGB(255, 255, 255)
        Me.ForeColor = RGB(0, 0, 0)
        Me.IsHidden = False
        Me.IndentLevel = 1
    End Sub
End Class
''' <summary>
''' 行コレクション
''' </summary>
''' <remarks></remarks>
Public Class RowAttribCollection
    ''' <summary>
    ''' 行番号
    ''' </summary>
    ''' <remarks></remarks>
    Public RowIndex As Integer
    ''' <summary>
    ''' 背景色
    ''' </summary>
    ''' <remarks></remarks>
    Public BackColor As System.UInt32
    ''' <summary>
    ''' 非表示設定
    ''' </summary>
    ''' <remarks></remarks>
    Public IsHidden As Boolean
    Sub New()
        Me.RowIndex = 0
        Me.BackColor = RGB(255, 255, 255)
        Me.IsHidden = False
    End Sub
End Class
''' <summary>
''' 特別期間コレクション
''' </summary>
''' <remarks></remarks>
Public Class SpecialTimeCollection
    ''' <summary>
    ''' 開始日
    ''' </summary>
    ''' <remarks></remarks>
    Public Start As Date
    ''' <summary>
    ''' 終了日
    ''' </summary>
    ''' <remarks></remarks>
    Public Finish As Date
    ''' <summary>
    ''' 期間名
    ''' </summary>
    ''' <remarks></remarks>
    Public CellText As String
    ''' <summary>
    ''' 背景色
    ''' </summary>
    ''' <remarks></remarks>
    Public CellColor As System.UInt32
    ''' <summary>
    ''' トンネル表示スイッチ
    ''' </summary>
    ''' <remarks></remarks>
    Public IsTunnel As Boolean
End Class
''' <summary>
''' キャプションコレクション
''' </summary>
''' <remarks></remarks>
Public Class CaptionCollection
    ''' <summary>
    ''' 文字色
    ''' </summary>
    ''' <remarks></remarks>
    Public ForeColor As System.UInt32
    ''' <summary>
    ''' 内容
    ''' </summary>
    ''' <remarks></remarks>
    Public Text As String
    ''' <summary>
    ''' 水平位置
    ''' </summary>
    ''' <remarks></remarks>
    Public HAlign As Integer
    ''' <summary>
    ''' 垂直位置
    ''' </summary>
    ''' <remarks></remarks>
    Public VAlign As Integer
    ''' <summary>
    ''' 表示位置
    ''' </summary>
    ''' <remarks></remarks>
    Public Position As Integer
End Class
''' <summary>
''' 達成率コレクション
''' </summary>
''' <remarks></remarks>
Public Class ProgressBarCollection
    ''' <summary>
    ''' 表示タイプ
    ''' </summary>
    ''' <remarks></remarks>
    Public ProgressType As Integer
    ''' <summary>
    ''' 達成率
    ''' </summary>
    ''' <remarks></remarks>
    Public ProgressPercent As Single
    ''' <summary>
    ''' プログレス色
    ''' </summary>
    ''' <remarks></remarks>
    Public ProgressColor As System.UInt32
    ''' <summary>
    ''' 達成率表示スイッチ
    ''' </summary>
    ''' <remarks></remarks>
    Public ProgressDisplay As String
    ''' <summary>
    ''' プログレス使用しないスイッチ
    ''' </summary>
    ''' <remarks></remarks>
    Public IsNotUseProgress As Boolean
End Class
''' <summary>
''' ピースコレクション
''' </summary>
''' <remarks></remarks>
Public Class PieceCollection
    ''' <summary>
    ''' 行番号
    ''' </summary>
    ''' <remarks></remarks>
    Public RowIndex As Integer
    ''' <summary>
    ''' 列番号
    ''' </summary>
    ''' <remarks></remarks>
    Public ColIndex As Integer
    ''' <summary>
    ''' 開始日
    ''' </summary>
    ''' <remarks></remarks>
    Public Start As Date
    ''' <summary>
    ''' 終了日
    ''' </summary>
    ''' <remarks></remarks>
    Public Finish As Date
    ''' <summary>
    ''' ピース色
    ''' </summary>
    ''' <remarks></remarks>
    Public PieceColor As System.UInt32
    ''' <summary>
    ''' トンネル表示スイッチ
    ''' </summary>
    ''' <remarks></remarks>
    Public Tunnel As Boolean
    ''' <summary>
    ''' シェイプ種類
    ''' </summary>
    ''' <remarks></remarks>
    Public Shape As Integer
    ''' <summary>
    ''' シェイプ名
    ''' </summary>
    ''' <remarks></remarks>
    Public ShapeName As String
    ''' <summary>
    ''' 左文字コレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public CaptionLeft As CaptionCollection
    ''' <summary>
    ''' 中央文字コレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public CaptionCenter As CaptionCollection
    ''' <summary>
    ''' 右文字コレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public CaptionRight As CaptionCollection
    ''' <summary>
    ''' プログレスコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public ProgressBar As ProgressBarCollection
    ''' <summary>
    ''' ロックピース
    ''' </summary>
    ''' <remarks></remarks>
    Public LockPiece As Integer
    ''' <summary>
    ''' サマリーピース
    ''' </summary>
    ''' <remarks></remarks>
    Public IsSummaryPiece As Boolean
    ''' <summary>
    ''' サマリーピース進捗率使用
    ''' </summary>
    ''' <remarks></remarks>
    Public UseSummaryProgress As Boolean
    ''' <summary>
    ''' サマリー集計除外ピース
    ''' </summary>
    ''' <remarks></remarks>
    Public IsSummaryExclusion As Boolean
    Sub New()
        Me.RowIndex = 0
        Me.ColIndex = 0
        Me.Start = Nothing
        Me.Finish = Nothing
    End Sub
End Class
''' <summary>
''' 関係線コレクション
''' </summary>
''' <remarks></remarks>
Public Class RelatedLineCollection
    ''' <summary>
    ''' 元ピース行番号
    ''' </summary>
    ''' <remarks></remarks>
    Public FromRowIndex As Integer
    ''' <summary>
    ''' 元ピース番号
    ''' </summary>
    ''' <remarks></remarks>
    Public FromColIndex As Integer
    ''' <summary>
    ''' 先ピース行番号
    ''' </summary>
    ''' <remarks></remarks>
    Public ToRowIndex As Integer
    ''' <summary>
    ''' 先ピース番号
    ''' </summary>
    ''' <remarks></remarks>
    Public ToColIndex As Integer
    ''' <summary>
    ''' 関係線スタイル
    ''' </summary>
    ''' <remarks></remarks>
    Public RelatedStyle As Integer
    ''' <summary>
    ''' 関係線 線スタイル
    ''' </summary>
    ''' <remarks></remarks>
    Public RelatedLineStyle As Integer
    Sub New()
        Me.FromRowIndex = 0
        Me.FromColIndex = 0
        Me.ToRowIndex = 0
        Me.ToColIndex = 0
        Me.RelatedStyle = 0
        Me.RelatedLineStyle = 1
    End Sub
End Class
''' <summary>
''' バルーンシェイプコレクション
''' </summary>
''' <remarks></remarks>
Public Class BalloonShapeCollection
    ''' <summary>
    ''' シェイプ形状
    ''' </summary>
    ''' <remarks></remarks>
    Public BeakBase As Integer
    ''' <summary>
    ''' 高さ
    ''' </summary>
    ''' <remarks></remarks>
    Public Height As Integer
    ''' <summary>
    ''' 幅
    ''' </summary>
    ''' <remarks></remarks>
    Public Width As Integer
End Class
''' <summary>
''' バルーンコレクション
''' </summary>
''' <remarks></remarks>
Public Class BalloonCollection
    ''' <summary>
    ''' 対象行番号
    ''' </summary>
    ''' <remarks></remarks>
    Public RowIndex As Integer
    ''' <summary>
    ''' 対象列番号
    ''' </summary>
    ''' <remarks></remarks>
    Public ColIndex As Integer
    ''' <summary>
    ''' 設置ポイント
    ''' </summary>
    ''' <remarks></remarks>
    Public Pont As Point
    ''' <summary>
    ''' 表示文字
    ''' </summary>
    ''' <remarks></remarks>
    Public Caption As CaptionCollection
    ''' <summary>
    ''' アンカーポイント
    ''' </summary>
    ''' <remarks></remarks>
    Public AnchorPoint As Point
    ''' <summary>
    ''' アンカーポイント
    ''' </summary>
    ''' <remarks></remarks>
    Public AnchorRelPoint As Point
    ''' <summary>
    ''' バルーンシェイプ
    ''' </summary>
    ''' <remarks></remarks>
    Public BalloonShape As BalloonShapeCollection
    ''' <summary>
    ''' 背景色
    ''' </summary>
    ''' <remarks></remarks>
    Public BackColor As System.UInt32
    ''' <summary>
    ''' シェイプ形状
    ''' </summary>
    ''' <remarks></remarks>
    Public Style As Integer
    Sub New()
    End Sub
End Class
''' <summary>
''' 作業履歴コレクション
''' </summary>
''' <remarks></remarks>
Public Class WorkHistoryCollection
    ''' <summary>
    ''' 作業日時
    ''' </summary>
    ''' <remarks></remarks>
    Public WorkTime As DateTime
    ''' <summary>
    ''' 作業者名
    ''' </summary>
    ''' <remarks></remarks>
    Public WorkerName As String
    ''' <summary>
    ''' 作業内容
    ''' </summary>
    ''' <remarks></remarks>
    Public WorkNote As String
    Sub New()
        Me.WorkTime = Now
        Me.WorkerName = ""
        Me.WorkNote = ""
    End Sub
End Class
''' <summary>
''' アイテムXML用コレクション
''' </summary>
''' <remarks></remarks>
Public Class ItemXMLCollection
    ''' <summary>
    ''' ピースコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public Pieces() As PieceCollection
End Class
''' <summary>
''' TODO:データコレクション
''' </summary>
''' <remarks></remarks>
Public Class WindyDataCollection
    ''' <summary>
    ''' タイトル
    ''' </summary>
    ''' <remarks></remarks>
    Public Title As String
    ''' <summary>
    ''' 管理者
    ''' </summary>
    ''' <remarks></remarks>
    Public Owner As String
    ''' <summary>
    ''' ロックスイッチ
    ''' </summary>
    ''' <remarks></remarks>
    Public IsExclusion As Boolean
    ''' <summary>
    ''' ロックパスワード
    ''' </summary>
    ''' <remarks></remarks>
    Public ExclusionPassword As String
    ''' <summary>
    ''' ロードロック
    ''' </summary>
    ''' <remarks></remarks>
    Public LoadLock As Boolean
    ''' <summary>
    ''' インデントレベル
    ''' </summary>
    ''' <remarks></remarks>
    Public IndentLevel As Integer
    ''' <summary>
    ''' 行数
    ''' </summary>
    ''' <remarks></remarks>
    Public RowCount As Integer
    ''' <summary>
    ''' 列数
    ''' </summary>
    ''' <remarks></remarks>
    Public ColCount As Integer
    ''' <summary>
    ''' 行高さ
    ''' </summary>
    ''' <remarks></remarks>
    Public RowHeight As Integer
    ''' <summary>
    ''' ズーム数
    ''' </summary>
    ''' <remarks></remarks>
    Public Zoom As Integer
    ''' <summary>
    ''' ピース高さ
    ''' </summary>
    ''' <remarks></remarks>
    Public PieceCenterHeight As Integer
    ''' <summary>
    ''' 表示モード
    ''' </summary>
    ''' <remarks></remarks>
    Public PieceLayout As Integer
    ''' <summary>
    ''' 表示先頭日付（前回閉じた時の先頭日付）
    ''' </summary>
    ''' <remarks></remarks>
    Public ViewTopTime As String
    ''' <summary>
    ''' 行属性コレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public RowAttrib As New List(Of RowAttribCollection)
    ''' <summary>
    ''' ヘッダーコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public Header As New List(Of HeaderCollection)
    ''' <summary>
    ''' セルコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public HeaderCell As New List(Of HeaderCellCollection)
    ''' <summary>
    ''' 特別期間コレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public SpecialTime As New List(Of SpecialTimeCollection)
    ''' <summary>
    ''' ピースコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public Piece As New List(Of PieceCollection)
    ''' <summary>
    ''' 関係線コレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public RelatedLine As New List(Of RelatedLineCollection)
    ''' <summary>
    ''' バルーンコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public Balloon As New List(Of BalloonCollection)
    ''' <summary>
    ''' 作業履歴コレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public WorkHistory As New List(Of WorkHistoryCollection)
    ''' <summary>
    ''' マスタピースコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public MasterPiece As PieceCollection
    ''' <summary>
    ''' テンプレートピースコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public TemplatePiece As PieceCollection
    Public IsWaterFall As Boolean
    Public IsWaterFallLock As Boolean
    Public CellDateFormat As String
    Public NACellValue As String
End Class
''' <summary>
''' XMLファイル用コレクション
''' </summary>
''' <remarks></remarks>
Public Class WindyXMLDataCollection
    ''' <summary>
    ''' タイトル
    ''' </summary>
    ''' <remarks></remarks>
    Public Title As String
    ''' <summary>
    ''' 管理者
    ''' </summary>
    ''' <remarks></remarks>
    Public Owner As String
    ''' <summary>
    ''' ロックスイッチ
    ''' </summary>
    ''' <remarks></remarks>
    Public IsExclusion As Boolean
    ''' <summary>
    ''' ロックパスワード
    ''' </summary>
    ''' <remarks></remarks>
    Public ExclusionPassword As String
    ''' <summary>
    ''' ロードロック
    ''' </summary>
    ''' <remarks></remarks>
    Public LoadLock As Boolean
    ''' <summary>
    ''' インテンド幅
    ''' </summary>
    ''' <remarks></remarks>
    Public IndentWidth As Integer
    ''' <summary>
    ''' 行数
    ''' </summary>
    ''' <remarks></remarks>
    Public RowCount As Integer
    ''' <summary>
    ''' 列数
    ''' </summary>
    ''' <remarks></remarks>
    Public ColCount As Integer
    ''' <summary>
    ''' 行高さ
    ''' </summary>
    ''' <remarks></remarks>
    Public RowHeight As Integer
    ''' <summary>
    ''' ズーム数
    ''' </summary>
    ''' <remarks></remarks>
    Public Zoom As Integer
    ''' <summary>
    ''' ピース高さ
    ''' </summary>
    ''' <remarks></remarks>
    Public PieceCenterHeight As Integer
    ''' <summary>
    ''' 表示モード
    ''' </summary>
    ''' <remarks></remarks>
    Public PieceLayout As Integer
    ''' <summary>
    ''' 表示先頭日付（前回閉じた時の先頭日付）
    ''' </summary>
    ''' <remarks></remarks>
    Public ViewTopTime As String
    ''' <summary>
    ''' 行属性コレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public RowAttrib() As RowAttribCollection
    ''' <summary>
    ''' ヘッダーコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public Header() As HeaderCollection
    ''' <summary>
    ''' セルコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public HeaderCell() As HeaderCellCollection
    ''' <summary>
    ''' 特別期間コレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public SpecialTime() As SpecialTimeCollection
    ''' <summary>
    ''' ピースコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public Piece() As PieceCollection
    ''' <summary>
    ''' 関係線コレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public RelatedLine() As RelatedLineCollection
    ''' <summary>
    ''' バルーンコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public Balloon() As BalloonCollection
    ''' <summary>
    ''' 作業履歴コレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public WorkHistory() As WorkHistoryCollection
    ''' <summary>
    ''' マスタピースコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public MasterPiece As PieceCollection
    Public TemplatePiece As PieceCollection

    Public IsWaterFall As Boolean
    Public IsWaterFallLock As Boolean
    Public CellDateFormat As String
    Public NACellValue As String
End Class
