''' <summary>
''' TimeView専用モジュール
''' </summary>
''' <remarks></remarks>
Module ModuleKnowlbo
    ''' <summary>
    ''' プログレス種類変換
    ''' </summary>
    ''' <param name="Value">TivBarShape</param>
    ''' <returns>対応番号</returns>
    ''' <remarks></remarks>
    Public Function ConvertProgressType(ByVal Value As KnTViewLib.TivBarShape) As Integer
        Select Case Value
            Case KnTViewLib.TivBarShape.tivBarShapeLine : Return 0
            Case KnTViewLib.TivBarShape.tivBarShapeRectangle : Return 1
            Case KnTViewLib.TivBarShape.tivBarShapeUpperLine : Return 2
            Case KnTViewLib.TivBarShape.tivBarShapeLowerLine : Return 3
            Case KnTViewLib.TivBarShape.tivBarShapeUpperRectangle : Return 4
            Case KnTViewLib.TivBarShape.tivBarShapeCenterRectangle : Return 5
            Case KnTViewLib.TivBarShape.tivBarShapeLowerRectangle : Return 6
        End Select
    End Function
    ''' <summary>
    ''' プログレス種類変換
    ''' </summary>
    ''' <param name="Value">対応番号</param>
    ''' <returns>TivBarShape</returns>
    ''' <remarks></remarks>
    Public Function ConvertProgressType(ByVal Value As Integer) As KnTViewLib.TivBarShape
        Select Case Value
            Case 0 : Return KnTViewLib.TivBarShape.tivBarShapeLine
            Case 1 : Return KnTViewLib.TivBarShape.tivBarShapeRectangle
            Case 2 : Return KnTViewLib.TivBarShape.tivBarShapeUpperLine
            Case 3 : Return KnTViewLib.TivBarShape.tivBarShapeLowerLine
            Case 4 : Return KnTViewLib.TivBarShape.tivBarShapeUpperRectangle
            Case 5 : Return KnTViewLib.TivBarShape.tivBarShapeCenterRectangle
            Case 6 : Return KnTViewLib.TivBarShape.tivBarShapeLowerRectangle
        End Select
    End Function
    ''' <summary>
    ''' ヘッダーコピー
    ''' </summary>
    ''' <param name="Obj">対象TView</param>
    ''' <param name="FromCol">元列番号</param>
    ''' <param name="ToCol">先列番号</param>
    ''' <remarks></remarks>
    Public Sub CellHeader(ByVal Obj As AxKnTViewLib.AxKnTView, ByVal FromCol As Integer, ByVal ToCol As Integer)
        Dim FromCell As KnTViewLib.ColumnHeader = Obj.ColumnHeaders.Item(FromCol)
        Dim ToCell As KnTViewLib.ColumnHeader = Obj.ColumnHeaders.Item(ToCol)

        ToCell.BottomBorder.Color = FromCell.BottomBorder.Color
        ToCell.BottomBorder.Style = FromCell.BottomBorder.Style
        ToCell.Color = FromCell.Color
        ToCell.ColumnWidthMode = FromCell.ColumnWidthMode
        ToCell.Fill.BackColor = FromCell.Fill.BackColor
        ToCell.Fill.BkMode = FromCell.Fill.BkMode
        ToCell.Fill.ForeColor = FromCell.Fill.ForeColor
        ToCell.Fill.Pattern = FromCell.Fill.Pattern
        ToCell.Font.Bold = FromCell.Font.Bold
        ToCell.Font.Charset = FromCell.Font.Charset
        ToCell.Font.Italic = FromCell.Font.Italic
        ToCell.Font.Name = FromCell.Font.Name
        ToCell.Font.Size = FromCell.Font.Size
        ToCell.Font.Strikethrough = FromCell.Font.Strikethrough
        ToCell.Font.Underline = FromCell.Font.Underline
        ToCell.Font.Weight = FromCell.Font.Weight
        ToCell.Hidden = FromCell.Hidden
        ToCell.HorAlign = FromCell.HorAlign
        ToCell.ImagePosition = FromCell.ImagePosition
        ToCell.IndentUIPosition = FromCell.IndentUIPosition
        ToCell.IndentUIWidth = FromCell.IndentUIWidth
        ToCell.IndentWidth = FromCell.IndentWidth
        ToCell.Key = FromCell.Key
        ToCell.MergeMode = FromCell.MergeMode
        ToCell.RightBorder.Color = FromCell.RightBorder.Color
        ToCell.RightBorder.Style = FromCell.RightBorder.Style
        ToCell.Tag = FromCell.Tag
        ToCell.Text = FromCell.Text
        ToCell.VerAlign = FromCell.VerAlign
        ToCell.Width = FromCell.Width
        ToCell.WordWrap = FromCell.WordWrap
    End Sub
    ''' <summary>
    ''' セルコピー
    ''' </summary>
    ''' <param name="Obj">対象TView</param>
    ''' <param name="FromRow">元行番号</param>
    ''' <param name="FromCol">元列番号</param>
    ''' <param name="ToRow">先行番号</param>
    ''' <param name="ToCol">元列番号</param>
    ''' <param name="NotValue">内容もコピーするか？</param>
    ''' <remarks></remarks>
    Public Sub CellCopy(ByVal Obj As AxKnTViewLib.AxKnTView, ByVal FromRow As Integer, ByVal FromCol As Integer, ByVal ToRow As Integer, ByVal ToCol As Integer, Optional NotValue As Integer = False)
        Dim FromCell As KnTViewLib.Cell = Obj.Cell(FromRow, FromCol)
        Dim ToCell As KnTViewLib.Cell = Obj.Cell(ToRow, ToCol)

        ToCell.Color = FromCell.Color
        ToCell.Fill.BackColor = FromCell.Fill.BackColor
        ToCell.Fill.BackColor = FromCell.Fill.BackColor
        ToCell.Fill.BkMode = FromCell.Fill.BkMode
        ToCell.Fill.ForeColor = FromCell.Fill.ForeColor
        ToCell.Fill.Pattern = FromCell.Fill.Pattern
        ToCell.HorAlign = FromCell.HorAlign
        ToCell.ImagePosition = FromCell.ImagePosition
        ToCell.IndentLevel = FromCell.IndentLevel
        ToCell.Key = FromCell.Key
        ToCell.RightBorder.Color = FromCell.RightBorder.Color
        ToCell.RightBorder.Style = FromCell.RightBorder.Style
        ToCell.BottomBorder.Color = FromCell.BottomBorder.Color
        ToCell.BottomBorder.Style = FromCell.BottomBorder.Style
        ToCell.IndentLevel = FromCell.IndentLevel
        Call Cell_SetIntendIcon(ToCell) 'インデントイメージの表示・非表示

        ToCell.Tag = FromCell.Tag
        If Not NotValue Then
            ToCell.Value = FromCell.Value
        End If
        ToCell.VerAlign = FromCell.VerAlign

    End Sub
    Public Function PieceCopy(ByVal FromPiece As KnTViewLib.Piece) As PieceCollection

        Dim TM As New PieceCollection

        TM.PieceColor = FromPiece.BarShape.Fill.BackColor
        With FromPiece.Captions.Item(1)
            Dim _T As New CaptionCollection
            _T.ForeColor = .Color
            _T.HAlign = .HorAlign
            _T.VAlign = .VerAlign
            _T.Position = .Position
            TM.CaptionLeft = _T
        End With
        With FromPiece.Captions.Item(2)
            Dim _T As New CaptionCollection
            _T.ForeColor = .Color
            _T.HAlign = .HorAlign
            _T.VAlign = .VerAlign
            _T.Position = .Position
            TM.CaptionCenter = _T
        End With
        With FromPiece.Captions.Item(3)
            Dim _T As New CaptionCollection
            _T.ForeColor = .Color
            _T.HAlign = .HorAlign
            _T.VAlign = .VerAlign
            _T.Position = .Position
            TM.CaptionRight = _T
        End With

        TM.Tunnel = FromPiece.Tunnel
        With FromPiece.Progresses.Item(1)
            Dim _T As New ProgressBarCollection
            _T.ProgressType = .Shape
            _T.ProgressColor = .Fill.BackColor
            _T.ProgressDisplay = .Key
            TM.ProgressBar = _T
        End With

        Return TM
    End Function
    ''' <summary>
    ''' ピース日付描写
    ''' </summary>
    ''' <param name="PCE"></param>
    ''' <param name="StartDay"></param>
    ''' <param name="FinshDay"></param>
    ''' <remarks></remarks>
    Public Sub PieceDateDraw(PCE As KnTViewLib.Piece, StartDay As Date, FinshDay As Date)
        With PCE
            Dim PV As PieceValueCollection = PCE.Value

            If StartDay <> FinshDay Then
                .Captions.Item(1).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionLeft, StartDay), StartDay, FinshDay)
                .Captions.Item(2).Text = ConvCaptionDateCount(PV.CaptionCenter, StartDay, FinshDay)
            Else
                '開始日と終了日が同じなら右のみの日付表示とする
                .Captions.Item(1).Text = ConvCaptionDateCount(PV.CaptionCenter, StartDay, FinshDay)
                .Captions.Item(2).Text = ""
            End If

            If PCE.Progresses.Item(1).Key = "1" AndAlso PCE.Progresses.Item(1).Hidden = False Then
                If PCE.Progresses.Item(1).PercentTo > 0 Then
                    Dim PC As Integer = CInt(PCE.Progresses.Item(1).PercentTo * 100)
                    .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, FinshDay), StartDay, FinshDay) & String.Format("({0}%)", PC)
                Else
                    .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, FinshDay), StartDay, FinshDay)
                End If
            Else
                .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, FinshDay), StartDay, FinshDay)
            End If
        End With
    End Sub
    ''' <summary>
    ''' ピースオブジェクトからピースコレクションに変換
    ''' </summary>
    ''' <param name="f1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PieceConvert(f1 As KnTViewLib.Piece) As PieceCollection
        Dim _TmpPiece As New PieceCollection

        _TmpPiece.Start = f1.Start
        If Not f1.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
            _TmpPiece.Finish = f1.Finish
        End If

        _TmpPiece.PieceColor = f1.BarShape.Fill.BackColor
        _TmpPiece.Tunnel = f1.Tunnel
        _TmpPiece.Shape = f1.StartShape.Shape
        '_TmpPiece.ShapeName = f1.Start

        Dim CL As New CaptionCollection
        With f1.Captions.Item(1)
            CL.Text = .Text
            CL.ForeColor = .Color
            CL.HAlign = .HorAlign
            CL.VAlign = .VerAlign
            CL.Position = .Position
        End With
        _TmpPiece.CaptionLeft = CL

        Dim CC As New CaptionCollection
        With f1.Captions.Item(2)
            CC.Text = .Text
            CC.ForeColor = .Color
            CC.HAlign = .HorAlign
            CC.VAlign = .VerAlign
            CC.Position = .Position
        End With
        _TmpPiece.CaptionCenter = CC

        Dim CR As New CaptionCollection
        If Not f1.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then

            With f1.Captions.Item(3)
                CR.Text = .Text
                CR.ForeColor = .Color
                CR.HAlign = .HorAlign
                CR.VAlign = .VerAlign
                CR.Position = .Position
            End With
        End If
        _TmpPiece.CaptionRight = CR

        Dim PR As New ProgressBarCollection
        If Not f1.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
            With f1.Progresses.Item(1)
                PR.ProgressType = .Shape
                PR.ProgressColor = .Fill.BackColor
                PR.ProgressDisplay = .Key
                PR.ProgressPercent = .PercentTo
            End With
        End If
        _TmpPiece.ProgressBar = PR

        Return _TmpPiece

    End Function
    ''' <summary>
    ''' ピースコレクションからピースオブジェクトに変換
    ''' </summary>
    ''' <param name="f1"></param>
    ''' <param name="_TmpPiece"></param>
    ''' <remarks></remarks>
    Public Sub PieceConvert2(f1 As PieceCollection, ByRef _TmpPiece As KnTViewLib.Piece)

        _TmpPiece.Start = f1.Start
        _TmpPiece.Finish = f1.Finish
        _TmpPiece.BarShape.Fill.BackColor = f1.PieceColor
        _TmpPiece.Tunnel = f1.Tunnel
        _TmpPiece.StartShape.Shape = f1.Shape
        '_TmpPiece.ShapeName = f1.Start

        With _TmpPiece.Captions.Item(1)
            .Text = f1.CaptionLeft.Text
            .Color = f1.CaptionLeft.ForeColor
            .HorAlign = f1.CaptionLeft.HAlign
            .VerAlign = f1.CaptionLeft.VAlign
            .Position = f1.CaptionLeft.Position
        End With
        With _TmpPiece.Captions.Item(2)
            .Text = f1.CaptionCenter.Text
            .Color = f1.CaptionCenter.ForeColor
            .HorAlign = f1.CaptionCenter.HAlign
            .VerAlign = f1.CaptionCenter.VAlign
            .Position = f1.CaptionCenter.Position
        End With
        If Not _TmpPiece.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
            With _TmpPiece.Captions.Item(3)
                .Text = f1.CaptionRight.Text
                .Color = f1.CaptionRight.ForeColor
                .HorAlign = f1.CaptionRight.HAlign
                .VerAlign = f1.CaptionRight.VAlign
                .Position = f1.CaptionRight.Position
            End With

            With _TmpPiece.Progresses.Item(1)
                .Shape = f1.ProgressBar.ProgressType
                .Fill.BackColor = f1.ProgressBar.ProgressColor
                .Key = ""
                .Key = f1.ProgressBar.ProgressDisplay
                .PercentTo = f1.ProgressBar.ProgressPercent
            End With
        End If

    End Sub
    ''' <summary>
    ''' 指定ピースがストーンピースか？？
    ''' </summary>
    ''' <param name="PCE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PieceIsStone(PCE As KnTViewLib.Piece) As Boolean
        If Not IsNothing(PCE) Then
            If PCE.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                Return True
            End If
        End If
        Return False
    End Function
    ''' <summary>
    ''' セルインデントアイコンの設定・非設定
    ''' </summary>
    ''' <param name="CItem"></param>
    ''' <remarks></remarks>
    Public Sub Cell_SetIntendIcon(CItem As KnTViewLib.Cell)
        With CItem
            If .IndentLevel < 2 Then
                .Image("", "")
                .ImagePosition = KnTViewLib.TivImagePosition.tivImagePositionRight
            Else
                .Image("IndentImageList", "Indent")
                .ImagePosition = KnTViewLib.TivImagePosition.tivImagePositionLeft
            End If

        End With
    End Sub

End Module
