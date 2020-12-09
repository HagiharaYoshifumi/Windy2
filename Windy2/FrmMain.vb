
Imports System.Runtime.InteropServices
Imports System.IO
''' <summary>
''' ガントチャートフォーム
''' </summary>
''' <remarks></remarks>
Public Class FrmMain
    Public IsEditMode As Boolean = False
    Public WithEvents FR As New ClassFormControl
    Public _WorkFileName As String
    Public _WorkFileIsLock As Boolean = False
    Public _Title As String = "新規スケジュール"
    Dim _Owner As String = ""
    Public _IsExclusion As Boolean = False
    Public _ExclusionPassword As String = ""
    Public _IsWaterFall As Boolean = False '関係線のついているピースを連動する
    Dim _IsWaterFallLock As Boolean = False '関係線のついているピースを連動する
    Dim _ProgressDisplay As Boolean = False
    Dim _WorkHistory As New List(Of WorkHistoryCollection)
    Public _MasterPiece As  New PieceCollection
    Public _TemplatePiece As New PieceCollection
    Public _TemporaryLock As Boolean = False '一時ロック
    Dim _LoadLock As Boolean = False
    Dim _ViewTopDate As String = ""
    Dim _IndentLevel As Integer = 19 'インテンド幅

    Dim _CellDateFormat As String = "yy/M/d"
    Public _NACellValue As String = "N/A"
    Dim _IsSaved As Boolean = False

#Region "TImeView API"

    '///////////////////////////////////////////////////////////////////////////////
    ' DrawText関数用定数

    Private Const DT_BOTTOM = &H8
    Private Const DT_CENTER = &H1
    Private Const DT_RIGHT = &H2
    Private Const DT_VCENTER = &H4
    Private Const DT_SINGLELINE = &H20
    Private Const DT_TOP = &H0

    '///////////////////////////////////////////////////////////////////////////////
    ' CreateFont関数用定数

    Private Const SHIFTJIS_CHARSET = 128
    Private Const OUT_DEFAULT_PRECIS = 0
    Private Const CLIP_DEFAULT_PRECIS = 0
    Private Const DEFAULT_QUALITY = 0
    Private Const DEFAULT_PITCH = 0
    Private Const FF_DONTCARE = 0    '  Don't care or don't know.

    '///////////////////////////////////////////////////////////////////////////////
    ' 矩形

    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    '///////////////////////////////////////////////////////////////////////////////
    ' DrawText関数(API)

    Public Declare Auto Function DrawText Lib "user32.dll" Alias "DrawTextA" ( _
        ByVal hDC As Integer, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpString As String, _
        ByVal nCount As Integer, _
        ByRef lpRect As RECT, _
        ByVal uFormat As Integer _
    ) As Integer

    '///////////////////////////////////////////////////////////////////////////////
    ' CreateFont関数(API)

    Private Declare Auto Function CreateFont Lib "gdi32.dll" Alias "CreateFontA" ( _
        ByVal nHeight As Integer, _
        ByVal nWidth As Integer, _
        ByVal nEscapement As Integer, _
        ByVal nOrientation As Integer, _
        ByVal fnWeight As Integer, _
        ByVal fdwItalic As Integer, _
        ByVal fdwUnderline As Integer, _
        ByVal fdwStrikeOut As Integer, _
        ByVal fdwCharSet As Integer, _
        ByVal fdwOutputPrecision As Integer, _
        ByVal fdwClipPrecision As Integer, _
        ByVal fdwQuality As Integer, _
        ByVal fdwPitchAndFamily As Integer, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpszFace As String _
    ) As Integer

    '///////////////////////////////////////////////////////////////////////////////
    ' SelectObject関数(API)

    Private Declare Auto Function SelectObject Lib "gdi32.dll" ( _
        ByVal hdc As Integer, _
        ByVal hgdiobj As Integer _
    ) As Integer

    '///////////////////////////////////////////////////////////////////////////////
    ' DeleteObject関数(API)

    Private Declare Auto Function DeleteObject Lib "gdi32.dll" ( _
        ByVal hObject As Integer _
    ) As Integer

#End Region
#Region "Property"
    ''' <summary>
    ''' 作業ファイル名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property WorkFileName() As String
        Get
            Return _WorkFileName
        End Get
        Set(ByVal value As String)
            _WorkFileName = value
        End Set
    End Property
    Property WorkFileIsLock() As Boolean
        Get
            Return _WorkFileIsLock
        End Get
        Set(value As Boolean)
            _WorkFileIsLock = value
        End Set
    End Property

    Property EditMode As Boolean
        Get
            Return IsEditMode
        End Get
        Set(ByVal value As Boolean)
            IsEditMode = value
        End Set
    End Property
    Property IsSaved As Boolean
        Get
            Return _IsSaved
        End Get
        Set(ByVal value As Boolean)
            _IsSaved = value
        End Set
    End Property
#End Region
    Dim MemHT As KnTViewLib.HitTestResult
    Dim SelectedObjct As KnTViewLib.TivObjectType '選択中アイテム
    Dim SelectedRow As Integer '選択中行
    Dim SelectedColumn As Integer '選択中セルカラム
    Dim SelectedTime As Date '選択時間
    Dim SelectedPeace As Integer '選択ピースインデックス
    Dim SelectedRelatedLineIndex As Integer '選択関係線インデックス
    Dim SelectedBalloonIndex As Integer '選択バルーンインデックス
    Dim _SpecialTimeData As New List(Of SpecialTimeCollection) '特別時間帯データ

#Region "フォーム"
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームを閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call RadialMenuHide()
        If IsEditMode Then
            If FR.IsEdited Then
                Dim _S As Boolean = False
                With FrmClosing
                    '終了方法選択ダイアログ表示
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        If .IsSave Then
                            '保存終了
                            Call FrmParent.ToolButton_SaveFile_Click(Nothing, Nothing)
                            If Not _IsSaved Then
                                e.Cancel = True
                            End If
                            Logs.PutInformation("保存終了", String.Format("{0}({1})", _WorkFileName, _Title))
                        Else
                            '破棄終了
                            Logs.PutInformation("破棄終了", String.Format("{0}({1})", _WorkFileName, _Title))
                        End If
                    Else
                        'キャンセル
                        e.Cancel = True
                    End If
                End With
            Else
                Logs.PutInformation("フォーム終了", String.Format("{0}({1})", _WorkFileName, _Title))
            End If
        Else
            Logs.PutInformation("フォーム終了", String.Format("{0}({1})", _WorkFileName, _Title))
        End If

        If _WorkFileIsLock Then
            If File.Exists(_WorkFileName & ".lck") Then
                File.Delete(_WorkFileName & ".lck")
                FrmParent.LblLockFile.Text = ""
            End If
        End If
    End Sub

    ''' <summary>
    ''' 休日を設定する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HolidayAdd()
        If _Holiday.Count > 0 Then
            Try
                Dim STS As KnTViewLib.SpecialTimeSet = TView.SpecialTimeSets.Item(1)
                For Each Item As HolidayCollection In _Holiday
                    Dim spt As KnTViewLib.SpecialTime = STS.SpecialTimes.Add(, )
                    spt.ZOrder = 0
                    spt.Fill.BkMode = KnTViewLib.TivBkMode.tivOpaque
                    spt.Fill.Pattern = KnTViewLib.TivFillPattern.tivPatternNull
                    spt.Fill.BackColor = _SundayColor
                    spt.Pattern = KnTViewLib.TivSpecialTime.tivSpecialTimeDirect
                    spt.Start = String.Format("{0:yyyy/MM/dd} 00:00:00", Item.HolidayStartDate)
                    spt.Finish = String.Format("{0:yyyy/MM/dd} 23:59:59", Item.HolidayFinDate)
                    spt.Tunnelable = False
                Next

            Catch ex As Exception
                Logs.PutErrorEx("休日設定エラー", ex, True)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' TODO:フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FR.TargetForm = Me

        Call HolidayAdd() '休日設定

        If _WorkFileName <> "" Then
            If File.Exists(_WorkFileName) Then
                If _WorkFileIsLock Then
                    '書き込むロックデータ
                    Dim MSG As String = ""
                    MSG &= String.Format("コンピュータ :{0}", System.Net.Dns.GetHostName()) & vbCrLf
                    MSG &= String.Format("ロック日時   :{0}", Now.ToString)
                    Try
                        Using sw As New System.IO.StreamWriter(_WorkFileName & ".lck", False, System.Text.Encoding.GetEncoding("shift_jis"))
                            sw.Write(MSG)
                        End Using
                    Catch ex As Exception
                        Logs.PutErrorEx("ロックデータの書込に失敗しました", ex, True)
                    End Try
                End If

                Call ReadData() 'ファイル（データ）を読み込む

                If Path.GetExtension(_WorkFileName).ToUpper = ".WTF" Then
                    '読み込んだファイルがテンプレートファイルの場合、ファイル名を消して上書き保存出来ない様にする
                    _WorkFileName = ""
                    Me.Text = _Title
                Else
                    Me.Text = String.Format("{0} ( {1} )", _Title, Path.GetFileName(_WorkFileName))
                End If

            Else
                EditMode = True
                Me.Text = _Title
            End If
        Else
            EditMode = True
            Me.Text = _Title
        End If
        FR.Title = Me.Text

        TView.SpecialTimeSets.Item(1).SpecialTimes.Item(1).Fill.BackColor = _SaturdayColor
        TView.SpecialTimeSets.Item(1).SpecialTimes.Item(2).Fill.BackColor = _SundayColor
        TView.SpecialTimeSets.Item(1).SpecialTimes.Item(3).Fill.BackColor = _TodayColor

        TView.ViewTopTime = DateAdd(DateInterval.Day, -7, Now)
        TView.SpecialTimeSets.Item(1).SpecialTimes.Item(3).Start = String.Format("{0:yyyy/MM/dd} 00:00:00", Now)
        TView.SpecialTimeSets.Item(1).SpecialTimes.Item(3).Finish = String.Format("{0:yyyy/MM/dd} 23:59:59", Now)
        TView.PiecePane.PieceMoveStartInterval = 10

        If _ViewTopDate <> "" AndAlso IsDate(_ViewTopDate) Then
            '前回閉じた所の日付に移動する
            TView.ViewTopTime = CDate(_ViewTopDate)
        Else
            Call MoveTop() '先頭ピースの開始日が左になる様にする
        End If
        Call FontSizeChange() 'フォントサイズ調整
        Call SheetInfomation()
        FR.Edited = False

    End Sub
#End Region
#Region "TimeView関係"
    'TODO:TimeView関係
    ''' <summary>
    ''' バルーンが編集された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_AfterBalloonEdit(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_AfterBalloonEditEvent) Handles TView.AfterBalloonEdit
        FR.Edited = True
    End Sub
    ''' <summary>
    ''' セルが選択された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_AfterCellSelect(ByVal sender As Object, ByVal e As System.EventArgs) Handles TView.AfterCellSelect
        SelectedRow = MemHT.ItemIndex()
        SelectedColumn = MemHT.ColumnIndex
    End Sub
    ''' <summary>
    ''' ピースが選択された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_AfterPieceSelect(ByVal sender As Object, ByVal e As System.EventArgs) Handles TView.AfterPieceSelect
        SelectedRow = MemHT.ItemIndex
        SelectedPeace = MemHT.PieceIndex
    End Sub

    ''' <summary>
    ''' RGBから色番号に変換
    ''' </summary>
    ''' <param name="red"></param>
    ''' <param name="green"></param>
    ''' <param name="blue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RGBtoUint32(ByVal red As Integer, ByVal green As Integer, ByVal blue As Integer) As System.UInt32
        Return System.UInt32.Parse(RGB(red, green, blue).ToString())
    End Function
    ''' <summary>
    ''' マウスを動かした
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_MouseMoveEvent(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_MouseMoveEvent) Handles TView.MouseMoveEvent
        MemHT = TView.HitTest(e.x, e.y)
        Dim ObjName As String = ""
        Select Case MemHT.ObjectType
            Case KnTViewLib.TivObjectType.tivBalloon
                ObjName = "バルーン"
                If e.button = 1 Then
                    FR.Edited = True
                End If
            Case KnTViewLib.TivObjectType.tivPiece, KnTViewLib.TivObjectType.tivProgress, KnTViewLib.TivObjectType.tivPieceStart, KnTViewLib.TivObjectType.tivPieceFinish

                Dim R As Integer = MemHT.ItemIndex
                Dim C As Integer = MemHT.PieceIndex
                If TView.Items.Item(R).Pieces.Item(C).StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                    ObjName = "マイルストーン"
                Else
                    Dim PT As PeaceTagCollection = PeaceTag(TView.Items.Item(R).Pieces.Item(C).Tag)
                    If PT.IsSummaryPiece Then
                        ObjName = "SUMピース"
                    Else
                        ObjName = "ピース"
                    End If
                End If
                If TView.Items.Item(R).Pieces.Item(C).Weight > 0 Then
                    ObjName += String.Format("(ロック{0})", TView.Items.Item(R).Pieces.Item(C).Weight)
                End If
            Case KnTViewLib.TivObjectType.tivProgressPoint, KnTViewLib.TivObjectType.tivProgressUIPoint

                Dim R As Integer = MemHT.ItemIndex
                Dim C As Integer = MemHT.PieceIndex
                Dim PT As PeaceTagCollection = PeaceTag(TView.Items.Item(R).Pieces.Item(C).Tag)
                If PT.IsSummaryPiece Then
                    ObjName = "SUMピース[達成率]"
                Else
                    ObjName = "ピース[達成率]"
                End If
                If TView.Items.Item(R).Pieces.Item(C).Weight > 0 Then
                    ObjName += String.Format("(ロック{0})", TView.Items.Item(R).Pieces.Item(C).Weight)
                End If
            Case KnTViewLib.TivObjectType.tivProgressLine '稲妻線

            Case KnTViewLib.TivObjectType.tivRelatedLine : ObjName = "関係線"

        End Select
        If ObjName = "" Then
            FrmParent.LblItemObject.Text = "アイテム："
        Else
            FrmParent.LblItemObject.Text = String.Format("アイテム：{0}", ObjName)
        End If
        Call SpecialDaysNameSerch(MemHT.Time)

    End Sub
    ''' <summary>
    '''　設定特別期間の名前を検索する
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Private Sub SpecialDaysNameSerch(ByVal Value As Date)
        Try
            If _SpecialTimeData.Count > 0 Then
                Dim Dat As Date = String.Format("{0:yyyy/MM/dd 00:00:00}", Value)
                For Each Item As SpecialTimeCollection In _SpecialTimeData
                    If Item.Start <= Dat AndAlso Dat <= Item.Finish Then
                        FrmParent.LblSpecialTime.Text = String.Format("特別期間：{0}", Item.CellText)
                        Return
                    End If
                Next
                FrmParent.LblSpecialTime.Text = String.Format("特別期間：{0}", "")
            End If
        Catch ex As Exception
            Logs.PutErrorEx("特別期間名前検索エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' ラジアルメニューを消す
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RadialMenuHide()
        RadialMenuPeace.HideMenu()
        RadialMenuCell.HideMenu()
        RadialMenuCellHeader.HideMenu()
        RadialMenuStone.HideMenu()
        RadialMenuRelatedLine.HideMenu()
        RadialMenuStripBalloon.HideMenu()
        RadialMenuPiecePane.HideMenu()
        RadialMenuSheetNothing.HideMenu()
    End Sub
#Region "関係線点滅関係"
    ''' <summary>
    ''' 関係線点滅用タイマー
    ''' </summary>
    ''' <remarks></remarks>
    Dim WithEvents RelatedLine_Flick_Timer As New ClassFlickTimer
    ''' <summary>
    ''' 選択関係線を点滅させる
    ''' </summary>
    ''' <param name="Value">True:点滅 Flase：点滅中止</param>
    ''' <remarks></remarks>
    Private Sub RelatedLine_Flick(Value As Boolean)
        If Value Then
            RelatedLine_Flick_Timer.Enable = True
        Else
            RelatedLine_Flick_Timer.Enable = False
            If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedRelatedLineIndex > 0 Then
                Try
                    TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).RelatedLines.Item(SelectedRelatedLineIndex).Hidden = False
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    ''' <summary>
    ''' 点滅タイマアップ
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Private Sub RelatedLine_Flick_Timer_Flick(Value As Boolean) Handles RelatedLine_Flick_Timer.Flick
        If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedRelatedLineIndex > 0 Then
            Try
                Dim Obj As KnTViewLib.RelatedLine = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).RelatedLines.Item(SelectedRelatedLineIndex)
                Obj.Hidden = Not Obj.Hidden
            Catch ex As Exception
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 関係線ラジアルメニューが閉じたら点滅を停止させる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RadialMenuRelatedLine_MenuClosed(sender As Object, e As EventArgs) Handles RadialMenuRelatedLine.MenuClosed
        Call RelatedLine_Flick(False)
    End Sub
#End Region
    ''' <summary>
    ''' サブメニュー表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_MouseDownEvent(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_MouseDownEvent) Handles TView.MouseDownEvent
        If Not IsEditMode Then
            Return
        End If
        'MemHT = TView.HitTest(e.x, e.y)
        'SelectedRow = MemHT.ItemIndex
        'SelectedColumn = MemHT.ColumnIndex
        'SelectedPeace = MemHT.PieceIndex
        'SelectedRelatedLineIndex = MemHT.RelatedLineIndex
        'SelectedBalloonIndex = MemHT.BalloonIndex
        'SelectedTime = MemHT.Time

        Call RadialMenuHide()

        If e.button = MouseButtons.Middle OrElse e.button = 4 Then
            'マウス真ん中ボタン
            Select Case MemHT.ObjectType
                Case KnTViewLib.TivObjectType.tivCell 'セル
                    If SelectedRow > 0 AndAlso SelectedColumn > 0 Then
                        Call RowHidden_Tree()
                    End If

            End Select
        ElseIf e.button = 2 Then
            Select Case MemHT.ObjectType
                Case KnTViewLib.TivObjectType.tivCell 'セル
                    If SelectedRow > 0 AndAlso SelectedColumn > 0 Then
                        Call ContextMenuCell_Opening(Nothing, Nothing)
                        RadialMenuCell.ShowMenu(Me, FormCenter, True)
                    End If

                Case KnTViewLib.TivObjectType.tivColumnHeader 'セルヘッダ
                    Call ContextMenuCellHeader_Opening(Nothing, Nothing)
                    RadialMenuCellHeader.ShowMenu(Me, FormCenter, True)

                Case KnTViewLib.TivObjectType.tivPiece 'ピース／ストーン
                    'タブレットモードの場合は表示しない
                    If Not _TabletMode Then
                        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                            'If TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                            If PieceIsStone(TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)) Then
                                'ストーン
                                Call ContextMenuStone_Opening(Nothing, Nothing)
                                RadialMenuStone.ShowMenu(Me, FormCenter, True)
                            Else
                                'ピース
                                Call ContextMenuPeace_Opening(Nothing, Nothing)
                                RadialMenuPeace.ShowMenu(Me, FormCenter, True)
                            End If
                        End If
                    End If

                Case KnTViewLib.TivObjectType.tivProgress '進捗率
                    Call ContextMenuPeace_Opening(Nothing, Nothing)
                    RadialMenuPeace.ShowMenu(Me, FormCenter, True)

                Case KnTViewLib.TivObjectType.tivRelatedLine '関係線
                    If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedRelatedLineIndex > 0 Then
                        Call RelatedLine_Flick(True) '分かりにくいので関係線を点滅させる
                        RadialMenuRelatedLine.ShowMenu(Me, FormCenter, True)
                    End If

                Case KnTViewLib.TivObjectType.tivBalloon 'バルーン
                    If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedBalloonIndex > 0 Then
                        RadialMenuStripBalloon.ShowMenu(Me, FormCenter, True)
                    End If

                Case KnTViewLib.TivObjectType.tivPiecePane 'シート
                    Call ContextMenuPiecePane_Opening(Nothing, Nothing)
                    RadialMenuPiecePane.ShowMenu(Me, FormCenter, True)

                Case KnTViewLib.TivObjectType.tivProgressLine '稲妻線

                Case KnTViewLib.TivObjectType.tivObjectNothing '何もないとこ
                    Call ContextMenuSheetNothing_Opening(Nothing, Nothing)
                    RadialMenuSheetNothing.ShowMenu(Me, FormCenter, True)

            End Select
        Else
            MemHT = TView.HitTest(e.x, e.y)
            SelectedObjct = MemHT.ObjectType
            SelectedRow = MemHT.ItemIndex
            SelectedColumn = MemHT.ColumnIndex
            SelectedPeace = MemHT.PieceIndex
            SelectedRelatedLineIndex = MemHT.RelatedLineIndex
            SelectedBalloonIndex = MemHT.BalloonIndex
            SelectedTime = MemHT.Time

            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                '特定キーを押しながら左クリックすると移動又は複写モードに入る
                If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
                    'ピースをドラッグで移動させる
                    _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                    _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
                    _DragPiceMode = enum_DragMoveMode.Move
                    'Me.Cursor = Cursors.Hand
                    FrmParent.LblMessage.Text = "上下動かすと選択アイテムを移動させます"
                    'e.cancel.Value = True

                ElseIf (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                    'ピースをドラッグでコピーする
                    _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                    _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
                    _DragPiceMode = enum_DragMoveMode.Copy
                    FrmParent.LblMessage.Text = "上下動かすと選択アイテムをコピーします"
                    'e.cancel.Value = True

                ElseIf (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                    If _IsWaterFall Then
                        Dim I As Integer = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).RelatedLines.Count
                        If I > 0 Then
                            FrmParent.LblMessage.Text = "関係線非連動にて選択アイテムを移動します"
                        Else
                            FrmParent.LblMessage.Text = "選択アイテムを移動します"
                        End If

                    Else
                        FrmParent.LblMessage.Text = "選択アイテムを移動します"
                    End If
                Else
                    If _IsWaterFall Then
                        Dim I As Integer = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).RelatedLines.Count
                        If I > 0 Then
                            FrmParent.LblMessage.Text = "関係線連動にて選択アイテムを移動します"
                        Else
                            FrmParent.LblMessage.Text = "選択アイテムを移動します"
                        End If
                    Else
                        FrmParent.LblMessage.Text = "選択アイテムを移動します"
                    End If

                    If Not _NoHighlight Then
                        'ピースかストーンの本体をクリックしたらピースのハイライトを行う
                        If MemHT.ObjectType = KnTViewLib.TivObjectType.tivPiece OrElse MemHT.ObjectType = KnTViewLib.TivObjectType.tivProgress Then
                            Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                            Call SelectPiecHighligh(PCE, True) '選択ピースのハイライト
                        End If
                    End If
                End If
            End If

        End If

    End Sub

    ''' <summary>
    ''' 選択ピースのハイライト
    ''' </summary>
    ''' <param name="PCE"></param>
    ''' <param name="IsDown"></param>
    ''' <remarks></remarks>
    Private Sub SelectPiecHighligh(PCE As KnTViewLib.Piece, IsDown As Boolean, Optional IsLoop As Boolean = False)
        If Not _IsDebugMode Then 'バグモードならハイライトしない
            If MemHT.ObjectType = KnTViewLib.TivObjectType.tivPiece OrElse MemHT.ObjectType = KnTViewLib.TivObjectType.tivProgress Then '選択アイテムがピースのみハイライトする
                If Not IsLoop Then
                    '１回目
                    If PCE.RelatedLines.Count > 0 Then
                        Call PiecHighligh(PCE, IsDown)
                        Call SelectPiecHighligh(PCE, IsDown, True) '子ピースを確認する
                    End If
                Else
                    'それ以降
                    For i As Integer = 1 To PCE.RelatedLines.Count
                        Dim PC As KnTViewLib.Piece = PCE.RelatedLines.Item(i).Relation
                        If Not SeekRelatedPeace(PCE, PC) Then 'ハイライトする前に子とループになっていなか確認する
                            Call PiecHighligh(PC, IsDown)
                            Call SelectPiecHighligh(PC, IsDown, True) '子ピースを確認する
                        End If
                    Next
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 指定ピースをハイライトする
    ''' </summary>
    ''' <param name="PCE"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Private Sub PiecHighligh(PCE As KnTViewLib.Piece, Value As Boolean)
        If Not _IsDebugMode Then 'バグモードならハイライトしない
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
        End If
    End Sub
    ''' <summary>
    ''' キーを押した
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub TView_KeyDownEvent(sender As Object, e As AxKnTViewLib._DKnTViewEvents_KeyDownEvent) Handles TView.KeyDownEvent
        Select Case e.keyCode.Value
            Case 37 '←
                If (e.shift And 1) Then 'SHIFT押しながら
                    Call PieceMove(-1) 'ピースを左に移動
                End If
            Case 39 '→
                If (e.shift And 1) Then 'SHIFT押しながら
                    Call PieceMove(1) 'ピースを右に移動
                End If
            Case 38 '↑
                If (e.shift And 1) Then 'SHIFT押しながら
                    Call FunctionAction(120) 'ピースを上に移動
                End If
            Case 40 '↓
                If (e.shift And 1) Then 'SHIFT押しながら
                    Call FunctionAction(121) 'ピースを下に移動
                    e.keyCode.Value = 0 'WINDOWSで割り当てられているので、クリアにする
                End If
            Case 46 'DELETE
                '押されたキーがDELETEなら各要素の削除
                Select Case MemHT.ObjectType
                    Case KnTViewLib.TivObjectType.tivCell
                    Case KnTViewLib.TivObjectType.tivColumnHeader
                    Case KnTViewLib.TivObjectType.tivPiece
                        'ピース／ストーン削除
                        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                            'If TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                            If PieceIsStone(TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)) Then
                                Call CMS_DeleteStone_Click(Nothing, Nothing)
                            Else
                                Call CTMP_DeletePeace_Click(Nothing, Nothing)
                            End If
                        End If

                    Case KnTViewLib.TivObjectType.tivProgress
                    Case KnTViewLib.TivObjectType.tivRelatedLine
                        '関係線削除
                        Call CMRL_Delete_Click(Nothing, Nothing)
                    Case KnTViewLib.TivObjectType.tivBalloon
                        'バルーン削除
                        Call CMSB_DeleteBalloon_Click(Nothing, Nothing)
                    Case KnTViewLib.TivObjectType.tivPiecePane
                    Case KnTViewLib.TivObjectType.tivProgressLine '稲妻線

                    Case KnTViewLib.TivObjectType.tivObjectNothing

                End Select

            Case 112 'F1
                Call FunctionAction(CInt(e.keyCode.Value))
            Case 113 'F2
                Call FunctionAction(CInt(e.keyCode.Value))
            Case 114 'F3
                Call FunctionAction(CInt(e.keyCode.Value))
            Case 115 'F4
                Call FunctionAction(CInt(e.keyCode.Value))
            Case 116 'F5
                Call FunctionAction(CInt(e.keyCode.Value))
            Case 117 'F6
                Call FunctionAction(CInt(e.keyCode.Value))
            Case 118 'F7
                Call FunctionAction(CInt(e.keyCode.Value))
            Case 119 'F8
                Call FunctionAction(CInt(e.keyCode.Value))
            Case 120 'F9
                Call FunctionAction(CInt(e.keyCode.Value))
            Case 121 'F10
                Call FunctionAction(CInt(e.keyCode.Value))
                e.keyCode.Value = 0 'WINDOWSで割り当てられているので、クリアにする

            Case 122 'F11
                Call FunctionAction(CInt(e.keyCode.Value))
            Case 123 'F12
                Call FunctionAction(CInt(e.keyCode.Value))
        End Select

        'http://faq.creasus.net/04/0131/CharCode.html


        If IsEditMode Then
            'CTRL+S(保存)
            If e.keyCode.Value = 83 AndAlso (e.shift And 2) Then
                Call FrmParent.ToolButton_SaveFile_Click(Nothing, Nothing)
            End If
            'CTRL+Z(UNDO)
            If e.keyCode.Value = 90 AndAlso (e.shift And 2) Then
                Call UndoExecute()
            End If
        End If

    End Sub
    ''' <summary>
    ''' ピースの移動
    ''' </summary>
    ''' <param name="MoveVectre"></param>
    ''' <remarks></remarks>
    Private Sub PieceMove(MoveVectre As Integer)
        If IsEditMode Then
            If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedColumn = 0 Then 'ピースが選択され、セルが選ばれてなかったら
                Try
                    Dim MemEndDay As Date
                    Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                    'If Not IsLockItem(PCE) Then
                    If TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Weight = 0 Then
                        'If PCE.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                        If PieceIsStone(PCE) Then
                            MemEndDay = PCE.Start
                            PCE.Start = DateAdd(DateInterval.Day, MoveVectre, PCE.Start)

                            If _IsWaterFall Then
                                Dim ff As Integer = DateDiff(DateInterval.Minute, MemEndDay, PCE.Start)
                                Call RelatedPeace(PCE, ff) '関係線が引いてある子ピースを移動させる
                            End If

                        Else
                            MemEndDay = PCE.Finish
                            Dim DS As Date = DateAdd(DateInterval.Day, MoveVectre, PCE.Start)
                            Dim DE As Date = DateAdd(DateInterval.Day, MoveVectre, DateAdd(DateInterval.Day, -1, PCE.Finish))

                            PCE.Start = DS
                            PCE.Finish = DateAdd(DateInterval.Day, 1, DE)

                            If _IsWaterFall Then 'ピース連動
                                Dim ff As Integer = DateDiff(DateInterval.Minute, MemEndDay, PCE.Finish)
                                Call RelatedPeace(PCE, ff) '関係線が引いてある子ピースを移動させる
                            End If

                            'ピース日付の再描写
                            Dim PV As PieceValueCollection = PCE.Value
                            With PCE
                                PV = PCE.Value
                                DS = .Start
                                DE = .Finish
                                DE = DateAdd(DateInterval.Day, -1, DE)
                                Call PieceDateDraw(PCE, DS, DE) 'ピース日付の再描写
                            End With
                        End If

                        Call CellDateRefresh()

                        TView.Refresh(1)
                        FR.Edited = True

                    End If

                Catch ex As Exception
                    Logs.PutErrorEx("ピース移動に失敗しました", ex, True)
                End Try
            End If
        End If

    End Sub
    ''' <summary>
    ''' TODO:(PUB)ファンクションキーの動作
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Sub FunctionAction(Value As Integer)
        Select Case Value

            Case 112 'F1
                'ヘルプ表示
                Call FrmParent.ContentsToolStripMenuItem_Click(Nothing, Nothing)
            Case 113 'F2
                '保存
                If IsEditMode Then
                    Call FrmParent.ToolButton_SaveFile_Click(Nothing, Nothing)
                End If
            Case 114 'F3
                'ピースのコピー
                If IsEditMode Then
                    If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                        _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                        _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
                        Dim PCE As KnTViewLib.Piece = PastePiece(SelectedRow)
                        TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Selected = False
                        Call CellDateRefresh() 'セル内容更新
                        PCE.Selected = True
                    End If
                End If
            Case 115 'F4
                'アイテム検索
                With FrmItemFind
                    .TargetForm = Me
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = False
                        Me.TopMost = True
                    End If
                    .ShowDialog()
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = True
                    End If
                End With
            Case 116 'F5
                'リフレッシュ
                If _WorkFileName = "" Then
                    TView.Refresh(1)
                Else
                    If IsEditMode Then
                        Select Case FrmRefreshSelecter.ShowDialog(Me)
                            Case Windows.Forms.DialogResult.Yes
                                Call FrmParent.ToolButton_SaveFile_Click(Nothing, Nothing)
                                Call ReloadData()

                            Case Windows.Forms.DialogResult.OK
                                TView.Refresh(1)
                            Case Else
                                Return
                        End Select
                    Else
                        TView.Refresh(1)
                    End If
                End If
            Case 117 'F6
                'リロード
                Call ReloadData()
            Case 118 'F7
                '行を上に移動
                If IsEditMode Then
                    Call MoveRow(FrmMain.enum_MoveRow.ToUp)
                End If
            Case 119 'F8
                '行を下に移動
                If IsEditMode Then
                    Call MoveRow(FrmMain.enum_MoveRow.ToDown)
                End If
            Case 120 'F9
                '上へピース移動
                If IsEditMode Then
                    If SelectedRow > 1 Then
                        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                            Dim SelPCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                            Dim PT As PeaceTagCollection = PeaceTag(SelPCE.Tag)
                            If PT.IsSummaryPiece Then
                                MsgBox("サマリーピースは移動出来ません", 64, "情報")
                                Return
                            End If

                            Try
                                _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                                _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
                                If TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Weight = 0 Then
                                    _DragPiceMode = enum_DragMoveMode.Move
                                    SelectedTime = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Start
                                    Dim PCE As KnTViewLib.Piece = PastePiece(SelectedRow - 1)
                                    TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)
                                    FrmParent.LblMessage.Text = "選択ピースを上行に移動させました"
                                    _DragPiceMode = enum_DragMoveMode.Non
                                    SelectedRow = SelectedRow - 1
                                    SelectedPeace = PCE.Index
                                    TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Selected = True
                                    Dim DS As Date = PCE.Start
                                    Dim DE As Date = DateAdd(DateInterval.Day, -1, PCE.Finish)
                                    With PCE
                                        'PV = PCE.Value
                                        DS = .Start
                                        DE = .Finish
                                        DE = DateAdd(DateInterval.Day, -1, DE)
                                        Call PieceDateDraw(PCE, DS, DE) 'ピース日付の再描写
                                    End With
                                    FR.Edited = True

                                Else
                                    MsgBox("ロックピース／ストーンの移動は出来ません", 64, "情報")
                                End If
                                Call CellDateRefresh() 'セル内容更新
                            Catch ex As Exception

                            End Try
                        End If
                    End If
                End If

            Case 121 'F10
                '下へピース移動
                If IsEditMode Then
                    If SelectedRow < TView.Items.Count Then
                        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                            Dim SelPCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                            Dim PT As PeaceTagCollection = PeaceTag(SelPCE.Tag)
                            If PT.IsSummaryPiece Then
                                MsgBox("サマリーピースは移動出来ません", 64, "情報")
                                Return
                            End If

                            Try
                                _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                                _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
                                'If Not IsLockItem(_CopyPiece) Then
                                If TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Weight = 0 Then
                                    _DragPiceMode = enum_DragMoveMode.Move
                                    SelectedTime = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Start
                                    Dim PCE As KnTViewLib.Piece = PastePiece(SelectedRow + 1)
                                    TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)
                                    FrmParent.LblMessage.Text = "選択ピースを下行に移動させました"
                                    _DragPiceMode = enum_DragMoveMode.Non
                                    SelectedRow = SelectedRow + 1
                                    SelectedPeace = PCE.Index
                                    TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Selected = True
                                    Dim DS As Date = PCE.Start
                                    Dim DE As Date = DateAdd(DateInterval.Day, -1, PCE.Finish)
                                    With PCE
                                        'PV = PCE.Value
                                        DS = .Start
                                        DE = .Finish
                                        DE = DateAdd(DateInterval.Day, -1, DE)
                                        Call PieceDateDraw(PCE, DS, DE) 'ピース日付の再描写
                                    End With
                                    FR.Edited = True

                                Else
                                    MsgBox("ロックピース／ストーンの移動は出来ません", 64, "情報")
                                End If
                                Call CellDateRefresh() 'セル内容更新
                            Catch ex As Exception

                            End Try
                        End If
                    End If
                End If
            Case 122 'F11
                Call FrmParent.AllScreen()
                If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    'MsgBox("もう一度F11を押すと通常画面に戻ります", 64, "情報")
                End If
            Case 123 'F12 プロパティ
                If _TabletMode Then 'タブレットモードのみ有効
                    If IsEditMode Then
                        If SelectedRow < TView.Items.Count Then
                            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                                Select Case SelectedObjct
                                    Case KnTViewLib.TivObjectType.tivCell
                                        Call CMC_CellProperty_Click(Nothing, Nothing)
                                    Case KnTViewLib.TivObjectType.tivColumnHeader
                                        Call RMCH_PropertyHeader_Click(Nothing, Nothing)
                                    Case KnTViewLib.TivObjectType.tivPiece
                                        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                                            'If TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                                            If PieceIsStone(TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)) Then
                                                Call CMS_Property_Click(Nothing, Nothing)
                                            Else
                                                Call CMP_Property_Click(Nothing, Nothing)
                                            End If
                                        End If
                                    Case KnTViewLib.TivObjectType.tivProgress
                                        Call CMP_Property_Click(Nothing, Nothing)

                                    Case KnTViewLib.TivObjectType.tivRelatedLine

                                    Case KnTViewLib.TivObjectType.tivBalloon
                                        Call CMSB_Property_Click(Nothing, Nothing)
                                    Case KnTViewLib.TivObjectType.tivPiecePane

                                End Select

                            End If
                        End If
                    End If
                End If
        End Select
    End Sub
    ''' <summary>
    ''' 指定ピースがロックピースか判別する
    ''' </summary>
    ''' <param name="PCE"></param>
    ''' <returns>TRUE:ロックピース</returns>
    ''' <remarks></remarks>
    'Private Function IsLockItem(PCE As KnTViewLib.Piece) As Boolean
    '    Dim FLG As Boolean = False
    '    Dim PV As PieceValueCollection = PCE.Value
    '    If PCE.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
    '        'ストーン（全てのキャプションが対象）
    '        If (Not IsNothing(PV.CaptionCenter)) Then
    '            If PV.CaptionCenter.IndexOf("*") = -1 Then
    '            Else
    '                FLG = True
    '            End If
    '        Else
    '        End If
    '        If (Not IsNothing(PV.CaptionLeft)) Then
    '            If PV.CaptionLeft.IndexOf("*") = -1 Then
    '            Else
    '                FLG = True
    '            End If
    '        Else
    '        End If
    '        If (Not IsNothing(PV.CaptionLeft)) Then
    '            If PV.CaptionLeft.IndexOf("*") = -1 Then
    '            Else
    '                FLG = True
    '            End If
    '        Else
    '        End If
    '    Else
    '        'ピース（センターキャプションのみ）
    '        If (Not IsNothing(PV.CaptionCenter)) Then
    '            If PV.CaptionCenter.IndexOf("*") = -1 Then
    '            Else
    '                FLG = True
    '            End If
    '        Else
    '        End If
    '    End If

    '    Return FLG
    'End Function
    ''' <summary>
    ''' アイテムダブルクリックでプロパティ表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TView.DblClick
        If Not IsEditMode Then
            Return
        End If
        'マウスをアップする瞬間にコントロールかシフトキーをおされていれば処理続行（押されていなければキャンセル）
        Dim KeyFlg As Boolean = False
        If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
            KeyFlg = True
        ElseIf (Control.ModifierKeys And Keys.Control) = Keys.Control Then
            KeyFlg = True
        End If
        If Not KeyFlg Then
            Select Case MemHT.ObjectType
                'Case KnTViewLib.TivObjectType.tivCell
                '    Call ContextMenuCell.Show(TView, New Point(e.x, e.y))
                Case KnTViewLib.TivObjectType.tivColumnHeader
                    Call RMCH_PropertyHeader_Click(Nothing, Nothing)

                Case KnTViewLib.TivObjectType.tivPiece
                    If Not _TabletMode Then
                        '通常モードではダブルクリックでプロパティを表示する
                        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                            'If TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                            If PieceIsStone(TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)) Then
                                Call CMS_Property_Click(Nothing, Nothing)
                            Else
                                Call CMP_Property_Click(Nothing, Nothing)
                            End If
                        End If
                    Else
                        'タブレットモードの場合、ダブルタップでメニューを表示する
                        'If TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                        If PieceIsStone(TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)) Then
                            'ストーン
                            Call ContextMenuStone_Opening(Nothing, Nothing)
                            RadialMenuStone.ShowMenu(Me, FormCenter, True)
                        Else
                            'ピース
                            Call ContextMenuPeace_Opening(Nothing, Nothing)
                            RadialMenuPeace.ShowMenu(Me, FormCenter, True)
                        End If
                    End If
                Case KnTViewLib.TivObjectType.tivProgress
                    Call CMP_Property_Click(Nothing, Nothing)

                Case KnTViewLib.TivObjectType.tivRelatedLine

                Case KnTViewLib.TivObjectType.tivBalloon

                Case KnTViewLib.TivObjectType.tivPiecePane

            End Select

        Else
            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                'キーを押しながらピースをダブルクリックすると、最終アイテムに移動か最終アイテムにコピーする
                Dim _PieceName As String = "ピース"
                'If _CopyPiece.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                If PieceIsStone(_CopyPiece) Then
                    _PieceName = "ストーン"
                End If

                If _DragPiceMode = enum_DragMoveMode.Copy OrElse _DragPiceMode = enum_DragMoveMode.Move Then
                    SelectedTime = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Start
                    Call PastePiece(SelectedRow)
                    If _DragPiceMode = enum_DragMoveMode.Move Then
                        TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)
                        FrmParent.LblMessage.Text = String.Format("選択{0}を移動させました", _PieceName)
                    Else
                        FrmParent.LblMessage.Text = String.Format("選択{0}をコピーしました", _PieceName)
                    End If
                    _DragPiceMode = enum_DragMoveMode.Non
                    FR.Edited = True
                Else
                    FrmParent.LblMessage.Text = ""
                End If

            End If
        End If

    End Sub

    ''' <summary>
    ''' ピースの追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_AfterPieceAdd(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_AfterPieceAddEvent) Handles TView.AfterPieceAdd
        e.cancel.Value = True
        Dim PCE As KnTViewLib.Piece = e.item.Pieces.AddFromTemplate(1)
        With PCE
            PCE.Start = e.start
            PCE.Finish = e.finish
            PCE.Weight = 0
            Dim PV As New PieceValueCollection
            PV.CaptionLeft = "<DATE>"
            PV.CaptionRight = "<DATE>"
            PCE.Value = PV

            Dim DS As Date = e.start.Value
            Dim DE As Date = DateAdd(DateInterval.Day, -1, e.finish.Value)
            Call PieceDateDraw(PCE, DS, DE) 'ピース日付の再描写
            PCE.Tunnel = _DefTunnel
        End With

        Dim prgrs As KnTViewLib.Progress = PCE.Progresses.Item(1)
        prgrs.Shape = KnTViewLib.TivBarShape.tivBarShapeRectangle
        prgrs.PercentTo = 0

        'ピースを追加する度にテンプレートピースを更新する
        _TemplatePiece.PieceColor = PCE.BarShape.Fill.BackColor
        Dim CL As New CaptionCollection
        Dim CC As New CaptionCollection
        Dim CR As New CaptionCollection
        With PCE.Captions.Item(1)
            CL.ForeColor = .Color
            CL.HAlign = .HorAlign
            CL.VAlign = .VerAlign
            CL.Position = .Position
        End With
        With PCE.Captions.Item(2)
            CC.ForeColor = .Color
            CC.HAlign = .HorAlign
            CC.VAlign = .VerAlign
            CC.Position = .Position
        End With
        With PCE.Captions.Item(3)
            CR.ForeColor = .Color
            CR.HAlign = .HorAlign
            CR.VAlign = .VerAlign
            CR.Position = .Position
        End With
        _TemplatePiece.CaptionLeft = CL
        _TemplatePiece.CaptionCenter = CC
        _TemplatePiece.CaptionRight = CR

        _TemplatePiece.Tunnel = PCE.Tunnel

        Dim PR As New ProgressBarCollection
        With PCE.Progresses.Item(1)
            PR.ProgressType = .Shape
            PR.ProgressColor = .Fill.BackColor
            PR.ProgressDisplay = .Key
            PR.IsNotUseProgress = .Hidden
        End With
        _TemplatePiece.ProgressBar = PR

        'マスタピースが設定されているのであれば、それを適用させる
        Call MasterPieceFormatSet(PCE)

        FR.Edited = True

    End Sub
    ''' <summary>
    ''' マスタピースの書式を適用する
    ''' </summary>
    ''' <param name="PCE"></param>
    ''' <remarks></remarks>
    Private Sub MasterPieceFormatSet(PCE As KnTViewLib.Piece)
        If Not IsNothing(_MasterPiece) AndAlso _MasterPiece.PieceColor <> 0 Then
            PCE.BarShape.Fill.BackColor = _MasterPiece.PieceColor
            PCE.TunnelShape.Fill.BackColor = _MasterPiece.PieceColor
            With PCE.Captions.Item(1)
                .Color = _MasterPiece.CaptionLeft.ForeColor
                .HorAlign = _MasterPiece.CaptionLeft.HAlign
                .VerAlign = _MasterPiece.CaptionLeft.VAlign
                .Position = _MasterPiece.CaptionLeft.Position
            End With
            With PCE.Captions.Item(2)
                .Color = _MasterPiece.CaptionCenter.ForeColor
                .HorAlign = _MasterPiece.CaptionCenter.HAlign
                .VerAlign = _MasterPiece.CaptionCenter.VAlign
                .Position = _MasterPiece.CaptionCenter.Position
            End With
            With PCE.Captions.Item(3)
                .Color = _MasterPiece.CaptionRight.ForeColor
                .HorAlign = _MasterPiece.CaptionRight.HAlign
                .VerAlign = _MasterPiece.CaptionRight.VAlign
                .Position = _MasterPiece.CaptionRight.Position
            End With

            PCE.Tunnel = _MasterPiece.Tunnel
            With PCE.Progresses.Item(1)
                .Shape = _MasterPiece.ProgressBar.ProgressType
                .Fill.BackColor = _MasterPiece.ProgressBar.ProgressColor
                .Key = ""
                .Key = _MasterPiece.ProgressBar.ProgressDisplay
                .Hidden = _MasterPiece.ProgressBar.IsNotUseProgress
            End With
            Call PieceDateDraw(PCE, PCE.Start, PCE.Finish)
        End If
    End Sub
    Dim _TViewEventLevel As Integer = 0
    ''' <summary>
    ''' TODO:ピースを移動した
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_AfterPieceMove(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_AfterPieceMoveEvent) Handles TView.AfterPieceMove
        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
            EnableUndo = False
            _TViewEventLevel += 1

            Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
            'If PCE.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
            If PieceIsStone(PCE) Then
                'Dim DS As Date = DateAdd(DateInterval.Minute, e.minutes, PCE.Start)
                Dim PV As PieceValueCollection = PCE.Value
                Dim DS As Date = DateAdd(DateInterval.Minute, e.minutes, PCE.Start)
                'PCE.Captions.Item(2).Text = Format(DS, PV.CaptionLeft)
                PCE.Captions.Item(2).Text = ConvCaptionDate(PV.CaptionLeft, DS)

                If _IsWaterFall Then
                    If Not (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                        Call RelatedPeace(PCE, e.minutes) '関係線が引いてある子ピースを移動させる
                    End If
                End If
            Else
                Dim DS As Date = DateAdd(DateInterval.Minute, e.minutes, PCE.Start)
                Dim DE As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Minute, e.minutes, PCE.Finish))
                With PCE
                    Call PieceDateDraw(PCE, DS, DE) 'ピース日付の再描写

                    If _IsWaterFall Then
                        If Not (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                            Call RelatedPeace(PCE, e.minutes) '関係線が引いてある子ピースを移動させる
                        End If
                    End If

                End With
            End If

            _TViewEventLevel -= 1
            If _TViewEventLevel < 1 Then
                EnableUndo = True
                _TViewEventLevel = 0
            End If
            'Call SummaryPieceDraw() 'サマリーピースの更新

            FR.Edited = True
        End If

    End Sub

    Dim _MovedPiece As New List(Of Point) '動かしたピース番号
    ''' <summary>
    ''' 関係線が引いてある子ピースを移動させる
    ''' </summary>
    ''' <param name="PCE"></param>
    ''' <param name="Val"></param>
    ''' <remarks></remarks>
    Private Sub RelatedPeace(PCE As KnTViewLib.Piece, Val As Integer)
        _MovedPiece.Clear()
        _MovedPiece.Add(New Point(PCE.ItemIndex, PCE.Index)) '動かしたピースを登録
        Call RelatedPeace_SUB(PCE, Val)
    End Sub
    ''' <summary>
    ''' 関係線が引いてある子ピースを移動させる
    ''' </summary>
    ''' <param name="PCE"></param>
    ''' <param name="Val"></param>
    ''' <remarks></remarks>
    Private Sub RelatedPeace_SUB(PCE As KnTViewLib.Piece, Val As Integer)
        For i = 1 To PCE.RelatedLines.Count
            Dim PC As KnTViewLib.Piece = PCE.RelatedLines.Item(i).Relation
            If Not IsNothing(PC) Then
                If Not SeekMovedPiece(PC.ItemIndex, PC.Index) Then '対象ピースが既に作業済みかどうか確認する
                    Dim PT As PeaceTagCollection = PeaceTag(PC.Tag)
                    Dim Flg As Boolean = False
                    If _IsWaterFallLock Then
                        If PC.Weight > 0 Then
                            Flg = True
                        End If
                    Else
                        Flg = False
                    End If

                    If PT.IsSummaryPiece Then
                        Flg = True
                    End If

                    If Flg = False Then
                        PC.Start = DateAdd(DateInterval.Minute, Val, PC.Start)
                        If Not IsDBNull(PC.Finish) Then
                            PC.Finish = DateAdd(DateInterval.Minute, Val, PC.Finish)
                        End If

                        '移動したピース／ストーンの日付再表示
                        'If PC.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                        If PieceIsStone(PC) Then
                            'ストーン
                            Dim PV As PieceValueCollection = PC.Value
                            PC.Captions.Item(2).Text = ConvCaptionDate(PV.CaptionLeft, PC.Start)
                        Else
                            'ピース
                            Dim DS As Date = PC.Start
                            Dim DE As Date = DateAdd(DateInterval.Day, -1, PC.Finish)
                            Call PieceDateDraw(PC, DS, DE) 'ピース日付の再描写

                        End If
                        _MovedPiece.Add(New Point(PC.ItemIndex, PC.Index)) '動かしたピースを登録
                        Call RelatedPeace_SUB(PC, Val) '子ピースを作業する
                    End If
                End If
            End If
        Next

    End Sub
    ''' <summary>
    ''' 指定インデックスのピースは登録済み？
    ''' </summary>
    ''' <param name="ItemIndex"></param>
    ''' <param name="Index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SeekMovedPiece(ItemIndex As Integer, Index As Integer) As Boolean
        If _MovedPiece.Count > 0 Then
            For Each Itm As Point In _MovedPiece
                If Itm.X = ItemIndex AndAlso Itm.Y = Index Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function
    ''' <summary>
    ''' ドラッグによるピース移動／コピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_MouseUpEvent(sender As Object, e As AxKnTViewLib._DKnTViewEvents_MouseUpEvent) Handles TView.MouseUpEvent
        If Not IsEditMode Then
            Return
        End If

        Dim KeyFlg As Boolean = False
        'マウスをアップする瞬間にコントロールかシフトキーをおされていれば処理続行（押されていなければキャンセル）
        If Not IsNothing(_CopyPiece) Then
            If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
                'ロックピースならキャンセル
                If _CopyPiece.Weight > 0 Then
                    MsgBox("ロックピース／ストーンの移動は出来ません" & vbCrLf & "(移動する場合は先にロックを解除してください)", 64, "情報")
                Else
                    KeyFlg = True
                End If

                If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                    Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                    Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
                    If PT.IsSummaryPiece Then
                        MsgBox("サマリーピースは移動出来ません", 64, "情報")
                        KeyFlg = False
                    Else
                        KeyFlg = True
                    End If
                End If

            ElseIf (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                'コピーはロックピースでも実行する
                KeyFlg = True
            End If
        End If

        If KeyFlg Then
            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                Dim _PieceName As String = "ピース"
                'If _CopyPiece.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                If PieceIsStone(_CopyPiece) Then
                    _PieceName = "ストーン"
                End If

                If _DragPiceMode = enum_DragMoveMode.Copy OrElse _DragPiceMode = enum_DragMoveMode.Move Then
                    MemHT = TView.HitTest(e.x, e.y)
                    Dim SelRow As Integer = MemHT.ItemIndex
                    If SelectedRow <> SelRow Then
                        SelectedTime = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Start
                        Dim ITM As KnTViewLib.Piece = PastePiece(SelRow)
                        If _DragPiceMode = enum_DragMoveMode.Move Then
                            TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)
                            FrmParent.LblMessage.Text = String.Format("選択{0}を移動させました", _PieceName)
                        Else
                            FrmParent.LblMessage.Text = String.Format("選択{0}をコピーしました", _PieceName)
                            TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Selected = False
                        End If

                        'ピース日付の再描写
                        Dim DS As Date = ITM.Start
                        Dim DE As Date = DateAdd(DateInterval.Day, -1, ITM.Finish)
                        With ITM
                            DS = .Start
                            DE = .Finish
                            DE = DateAdd(DateInterval.Day, -1, DE)
                            Call PieceDateDraw(ITM, DS, DE) 'ピース日付の再描写
                        End With

                        _DragPiceMode = enum_DragMoveMode.Non
                        ITM.Selected = True
                        FR.Edited = True
                    End If
                End If

            End If
        Else
            Select Case _DragPiceMode
                Case enum_DragMoveMode.Move
                    FrmParent.LblMessage.Text = "移動がキャンセルされました"
                Case enum_DragMoveMode.Copy
                    FrmParent.LblMessage.Text = "コピーがキャンセルされました"
                Case Else
                    FrmParent.LblMessage.Text = ""
            End Select

            If Not _NoHighlight Then
                Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                Call SelectPiecHighligh(PCE, False) '選択ピースのハイライトを止める
            End If
        End If

        If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedBalloonIndex > 0 Then
            'バルーンは選択しただけで更新したとみなす
            FR.Edited = True
        End If

        Call CellDateRefresh() 'セル内容更新

        _DragPiceMode = enum_DragMoveMode.Non
    End Sub
    ''' <summary>
    ''' 達成率を変更しようとした
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_BeforePieceProgressMouseChange(sender As Object, e As AxKnTViewLib._DKnTViewEvents_BeforePieceProgressMouseChangeEvent) Handles TView.BeforePieceProgressMouseChange
        If Not IsEditMode Then
            e.cancel.Value = True '閲覧モードの場合は作業禁止
        End If
        If _TemporaryLock Then '一時ロック中はキャンセル
            e.cancel.Value = True
            FrmParent.LblMessage.Text = "一時ロック中は達成率を変更出来ません"
        End If

        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
            'ロックピースならキャンセル
            Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
            If PCE.Weight > 1 Then
                FrmParent.LblMessage.Text = "ロックピースは達成率を変更出来ません"
                e.cancel.Value = True
                Return
            End If

            'サマリーピースならキャンセル
            Dim PT As PeaceTagCollection = PeaceTag(TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Tag)
            If PT.IsSummaryPiece AndAlso PT.UseSummaryPreogress Then
                FrmParent.LblMessage.Text = "サマリー進捗率集計の為、操作は出来ません"
                e.cancel.Value = True
                Return
            End If
        End If
    End Sub
    ''' <summary>
    ''' 達成率を変更しようとした
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_BeforePieceProgressMouseChange2(sender As Object, e As AxKnTViewLib._DKnTViewEvents_BeforePieceProgressMouseChange2Event) Handles TView.BeforePieceProgressMouseChange2
        If Not IsEditMode Then
            e.cancel.Value = True '閲覧モードの場合は作業禁止
        End If
        If _TemporaryLock Then '一時ロック中はキャンセル
            e.cancel.Value = True
        End If

        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
            'ロックピースならキャンセル
            Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
            If PCE.Weight > 1 Then
                FrmParent.LblMessage.Text = "ロックピースは達成率を変更出来ません"
                e.cancel.Value = True
                Return
            End If

            'サマリーピースならキャンセル
            Dim PT As PeaceTagCollection = PeaceTag(TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Tag)
            If PT.IsSummaryPiece AndAlso PT.UseSummaryPreogress Then
                FrmParent.LblMessage.Text = "サマリー進捗率集計の為、操作は出来ません"
                e.cancel.Value = True
                Return
            End If

        End If
    End Sub
    Enum enum_DragMoveMode As Integer
        ''' <summary>
        ''' 何もしない
        ''' </summary>
        ''' <remarks></remarks>
        Non = 0
        ''' <summary>
        ''' コピーする
        ''' </summary>
        ''' <remarks></remarks>
        Copy = 1
        ''' <summary>
        ''' 移動させる
        ''' </summary>
        ''' <remarks></remarks>
        Move = 2
    End Enum
    Dim _DragPiceMode As enum_DragMoveMode = enum_DragMoveMode.Non
    ''' <summary>
    ''' ドラッグによる関係線作成
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_PieceMoveStart(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_PieceMoveStartEvent) Handles TView.PieceMoveStart
        Try
            If _DragPiceMode = enum_DragMoveMode.Non Then

                If System.Math.Abs(e.startPoint.Y - e.currentPoint.Y) > System.Math.Abs(e.startPoint.X - e.currentPoint.X) Then
                    Dim PCE As KnTViewLib.Piece = e.piece.StartStretchSelect(e.startPoint.X, e.startPoint.Y)
                    ' ストレッチ操作でピースが選択されていたら、関係線を引く
                    If Not PCE Is Nothing Then
                        Select Case True
                            Case Not IsEditMode '閲覧モード
                                e.cancel.Value = False
                                Return
                            Case SeekPastRelatedPeace(e.piece, PCE) '既に関係線を作成していない？
                                MsgBox("すでに関係線が作成済みです。", 48, "関係線作成エラー")
                                e.cancel.Value = False
                                Return
                            Case SeekRelatedPeace(e.piece, PCE) 'ループにならないか？
                                MsgBox("関係線がループ状態になります。", 48, "関係線作成エラー")
                                e.cancel.Value = False
                                Return
                            Case Else
                                AddRelatedLine(e.piece, PCE)
                        End Select
                    End If
                    e.cancel.Value = True
                    ' ドラッグ操作が、水平方向への移動の場合は、ピースの移動操作開始
                Else
                    e.cancel.Value = False
                End If
            End If
        Catch ex As Exception
            Logs.PutErrorEx("関係線作成エラー", ex, True)
        End Try
    End Sub
    ''' <summary>
    ''' 関係線が作成か確認する
    ''' </summary>
    ''' <param name="FromPCE"></param>
    ''' <param name="ToPCE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SeekPastRelatedPeace(FromPCE As KnTViewLib.Piece, ToPCE As KnTViewLib.Piece) As Boolean
        For i = 1 To FromPCE.RelatedLines.Count
            Dim PC As KnTViewLib.Piece = FromPCE.RelatedLines.Item(i).Relation
            If Not IsNothing(PC) Then
                If PC.Index = ToPCE.Index AndAlso PC.ItemIndex = ToPCE.ItemIndex Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function
    ''' <summary>
    ''' 関係線作成前にループにならないか確認する
    ''' </summary>
    ''' <param name="FromPCE"></param>
    ''' <param name="ToPCE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SeekRelatedPeace(FromPCE As KnTViewLib.Piece, ToPCE As KnTViewLib.Piece) As Boolean
        For i = 1 To ToPCE.RelatedLines.Count
            Dim PC As KnTViewLib.Piece = ToPCE.RelatedLines.Item(i).Relation
            If Not IsNothing(PC) Then
                If PC.Index = FromPCE.Index AndAlso PC.ItemIndex = FromPCE.ItemIndex Then
                    Return True
                Else
                    If SeekRelatedPeace(FromPCE, PC) Then
                        Return True
                    End If
                End If
            End If
        Next
        Return False
    End Function
    ''' <summary>
    ''' ピースの長さを変えた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_AfterPieceTimeChange(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_AfterPieceTimeChangeEvent) Handles TView.AfterPieceTimeChange
        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
            Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
            Dim _IsWorkFinish As Boolean = False
            Dim _MemFinish As Date = PCE.Finish

            With PCE
                Dim PV As PieceValueCollection = PCE.Value
                Dim DS As Date = .Start
                Dim DE As Date = .Finish
                If e.which = 0 Then
                    DS = e.time.Value
                Else
                    DE = e.time.Value
                    _IsWorkFinish = True
                End If
                DE = DateAdd(DateInterval.Day, -1, DE)
                Call PieceDateDraw(PCE, DS, DE) 'ピース日付の再描写

                If _IsWaterFall Then
                    If _IsWorkFinish Then
                        If Not (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                            Dim T As Integer = DateDiff(DateInterval.Minute, _MemFinish, e.time.Value)
                            Call RelatedPeace(PCE, T) '関係線が引いてある子ピースを移動させる
                        End If
                    End If
                End If
            End With
            'Call SummaryPieceDraw() 'サマリーピースの更新

            FR.Edited = True
        End If

    End Sub
    ''' <summary>
    ''' 達成率を動かした
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_AfterPieceProgressMouseChange(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_AfterPieceProgressMouseChangeEvent) Handles TView.AfterPieceProgressMouseChange
        e.piece.Progresses.Item(e.progressIndex).PercentTo = e.newPercent
        Dim DS As Date = e.piece.Start
        Dim DE As Date = DateAdd(DateInterval.Day, -1, e.piece.Finish)
        Dim PV As PieceValueCollection = e.piece.Value
        If e.piece.Progresses.Item(1).Key = "1" And Not e.piece.Progresses.Item(1).Hidden Then
            If e.piece.Progresses.Item(1).PercentTo > 0 Then
                e.piece.Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE) & String.Format("({0}%)", e.piece.Progresses.Item(1).PercentTo * 100)
            Else
                e.piece.Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
            End If
        Else
            e.piece.Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
        End If

        If TView.ProgressLines.Count > 0 Then
            ' 達成率の設定
            e.piece.Progresses.Item(e.progressIndex).PercentTo = e.newPercent

            ' 稲妻線と達成率の関係が同期以外は処理しない
            'If cboProgress.SelectedIndex <> 0 Then
            '    Exit Sub
            'End If

            ' 達成率が0%か100%の時の制御
            Dim plineTarget As KnTViewLib.ProgressLine = TView.ProgressLines.Item(e.progressIndex)
            Dim pptTarget As KnTViewLib.ProgressPoint = plineTarget.ProgressPoints.Find(e.piece, e.progressIndex)

            ' 達成率が0%か100%の時は、進捗ポイントを削除する
            If e.newPercent = 1 Or e.newPercent = 0 Then
                If Not pptTarget Is Nothing Then
                    plineTarget.ProgressPoints.Remove(pptTarget.Index)
                End If

                ' 進捗ポイントがない場合は追加する
            Else
                If pptTarget Is Nothing Then
                    pptTarget = plineTarget.ProgressPoints.Add()

                    pptTarget.TargetPiece = e.piece
                    pptTarget.ProgressIndex = e.progressIndex
                End If
            End If
        End If

        FR.Edited = True

    End Sub
    ''' <summary>
    ''' TODO:(PUB)セルのコマンドの表示処理する
    ''' </summary>
    ''' <param name="AndSummary">False:サマリーピースは除外する</param>
    ''' <remarks></remarks>
    Public Sub CellDateRefresh(Optional AndSummary As Boolean = True)
        Dim MinDateText As String = "<MINDATE>"
        Dim MaxDateText As String = "<MAXDATE>"
        Dim SumDays As String = "<SUMDAY>"
        Dim RowNoText As String = "<ROWNO>"
        Dim AverageProgText As String = "<PROG>"

        Try
            If TView.ColumnHeaders.Count > 0 Then
                If TView.Items.Count > 0 Then
                    For Row As Integer = 1 To TView.Items.Count
                        Dim _MinDate As DateTime = Nothing
                        Dim _MaxDate As DateTime = Nothing
                        If TView.Items.Item(Row).Pieces.Count > 0 Then
                            For Each PCE As KnTViewLib.Piece In TView.Items.Item(Row).Pieces
                                Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
                                If Not PCE.Hidden Then
                                    If Not PT.IsSummaryExclusion Then 'サマリー対象外なら集計しない
                                        Dim _SD As DateTime = PCE.Start
                                        Dim _ED As DateTime
                                        If IsDBNull(PCE.Finish) Then
                                            _ED = _SD
                                        Else
                                            _ED = DateAdd(DateInterval.Day, -1, PCE.Finish)
                                        End If

                                        If _MinDate.ToOADate = 0 OrElse _SD <= _MinDate Then
                                            _MinDate = _SD
                                        End If
                                        If _MaxDate.ToOADate = 0 OrElse _MaxDate <= _ED Then
                                            _MaxDate = _ED
                                        End If

                                    End If
                                End If
                            Next
                        End If

                        For Col As Integer = 1 To TView.ColumnHeaders.Count
                            Dim _Tag As CellTagCollection = CellTagConvert(TView.Cell(Row, Col).Tag)

                            Dim _Value As String = _Tag.Caption
                            '最小日付処理
                            If _MinDate.ToOADate = 0 Then
                                _Value = Replace(_Value, MinDateText, _NACellValue)
                            Else
                                If _CellDateFormat = "" Then
                                    _Value = Replace(_Value, MinDateText, String.Format("{0:yy/MM/dd}", _MinDate))
                                Else
                                    Dim _F As String = "{0:" & _CellDateFormat & "}"
                                    _Value = Replace(_Value, MinDateText, String.Format(_F, _MinDate))
                                End If
                            End If
                            '最大日付処理
                            If _MaxDate.ToOADate = 0 Then
                                _Value = Replace(_Value, MaxDateText, _NACellValue)
                            Else
                                If _CellDateFormat = "" Then
                                    _Value = Replace(_Value, MaxDateText, String.Format("{0:yy/MM/dd}", _MaxDate))
                                Else
                                    Dim _F As String = "{0:" & _CellDateFormat & "}"
                                    _Value = Replace(_Value, MaxDateText, String.Format(_F, _MaxDate))
                                End If
                            End If

                            '合計日数処理
                            Dim DaysCount As Integer = 0
                            If TView.Items.Item(Row).Pieces.Count > 0 Then
                                For Each PCE As KnTViewLib.Piece In TView.Items.Item(Row).Pieces
                                    If Not PCE.Hidden Then
                                        Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
                                        If Not PT.IsSummaryExclusion Then 'サマリー対象外なら集計しない
                                            If PCE.StartShape.Shape <> KnTViewLib.TivPointShape.tivPointShapeImage Then
                                                DaysCount += DateDiff(DateInterval.Day, PCE.Start, PCE.Finish)
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                            _Value = Replace(_Value, SumDays, String.Format("{0}日", DaysCount))

                            '行番号処理
                            _Value = Replace(_Value, RowNoText, Row)

                            '進捗率処理
                            Dim ProTotalDay As Decimal = 0
                            Dim ProCountDay As Decimal = 0
                            If TView.Items.Item(Row).Pieces.Count > 0 Then
                                For Each PCE As KnTViewLib.Piece In TView.Items.Item(Row).Pieces
                                    If Not PCE.Hidden Then
                                        If PCE.StartShape.Shape <> KnTViewLib.TivPointShape.tivPointShapeImage Then
                                            Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
                                            If Not PT.IsSummaryExclusion Then 'サマリー対象外なら集計しない
                                                If PCE.Progresses.Count > 0 Then
                                                    If PCE.Progresses.Count > 0 Then
                                                        Dim _ProTotalDay As Decimal = 0
                                                        Dim _ProCountDay As Decimal = 0
                                                        Dim _ProValue As Decimal = 0

                                                        _ProTotalDay = DateDiff(DateInterval.Day, PCE.Start, PCE.Finish)
                                                        _ProValue = PCE.Progresses.Item(1).PercentTo
                                                        _ProCountDay = _ProTotalDay * _ProValue

                                                        ProTotalDay += _ProTotalDay
                                                        ProCountDay += _ProCountDay
                                                    End If
                                                End If

                                            End If
                                        End If
                                    End If
                                Next
                            End If
                            If ProTotalDay > 0 AndAlso ProCountDay > 0 Then
                                Dim PC As Integer = CInt((ProCountDay / ProTotalDay) * 100)
                                _Value = Replace(_Value, AverageProgText, String.Format("{0}%", PC))
                            Else
                                _Value = Replace(_Value, AverageProgText, _NACellValue)
                            End If

                            TView.Cell(Row, Col).Value = _Value
                        Next
                    Next
                End If
            End If

            If AndSummary Then
                Call SummaryPieceDraw() 'サマリーピースの更新
            End If
        Catch ex As Exception
            Logs.PutErrorEx("セル内容更新エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' TODO:サマリーピースを更新する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SummaryPieceDraw()
        Try
            If TView.ColumnHeaders.Count > 0 Then
                If TView.Items.Count > 0 Then
                    For Row As Integer = 1 To TView.Items.Count
                        If TView.Items.Item(Row).Pieces.Count > 0 Then
                            For Each PCE As KnTViewLib.Piece In TView.Items.Item(Row).Pieces
                                Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
                                Dim _IsWaterFall As Boolean = PT.IsWaterFall
                                Dim _IsSummaryPiece As Boolean = PT.IsSummaryPiece
                                If _IsSummaryPiece Then
                                    'サマリーピースの場合は赤枠にする
                                    PCE.BarShape.Line.Color = ConvertColorValue(Color.Red)

                                    '進捗率の変更
                                    If PT.UseSummaryPreogress Then
                                        If PCE.Progresses.Item(1).Hidden Then
                                            PCE.Progresses.Item(1).PercentTo = 0
                                        Else
                                            Dim ProValue As Decimal = 0
                                            Call CheckChildPieceProgress(Row, ProValue)
                                            PCE.Progresses.Item(1).PercentTo = ProValue
                                        End If
                                    End If

                                    '日付の変更
                                    Dim _MinDate As DateTime = Nothing
                                    Dim _MaxDate As DateTime = Nothing
                                    Call CheckChildPieceDate(Row, _MinDate, _MaxDate)
                                    If _MinDate.ToOADate <> 0 AndAlso _MaxDate.ToOADate <> 0 Then
                                        PCE.Start = _MinDate
                                        PCE.Finish = DateAdd(DateInterval.Day, 1, _MaxDate)
                                        Dim DS As Date = PCE.Start
                                        Dim DE As Date = DateAdd(DateInterval.Day, -1, PCE.Finish)
                                        Call PieceDateDraw(PCE, DS, DE) 'ピース日付の再描写
                                    Else
                                        '子レベルが確認出来なかったら、サマリーピースを解除する
                                        PT.IsSummaryPiece = False
                                        PT.UseSummaryPreogress = False
                                        PCE.Tag = PeaceTag(PT)
                                    End If
                                Else
                                    'サマリーピースじゃなかったら黒枠にする
                                    PCE.BarShape.Line.Color = ConvertColorValue(Color.Black)
                                End If
                            Next
                        End If

                    Next
                    Call CellDateRefresh(False) 'ピースの最大と最小を確認しセルに入れる(サマリーピースは除外）
                End If
            End If

        Catch ex As Exception
            Logs.PutErrorEx("サマリーピース更新エラー", ex, True)
        End Try
    End Sub
    ''' <summary>
    ''' 指定行の下の子レベルの最大・最小日を取得する
    ''' </summary>
    ''' <param name="BaseRow"></param>
    ''' <param name="MiniDate"></param>
    ''' <param name="MaxDate"></param>
    ''' <remarks></remarks>
    Private Sub CheckChildPieceDate(BaseRow As Integer, ByRef MiniDate As DateTime, ByRef MaxDate As DateTime)
        Dim ColIndex As Integer = SummaryTagetCol()
        If ColIndex > -1 Then
            Try
                Dim ParentLevel As Integer = TView.Cell(BaseRow, ColIndex).IndentLevel

                For Row As Integer = BaseRow + 1 To TView.Items.Count
                    Dim Level As Integer = TView.Cell(Row, ColIndex).IndentLevel
                    If Level > ParentLevel Then
                        If TView.Items.Item(Row).Pieces.Count > 0 Then
                            For Each PCE As KnTViewLib.Piece In TView.Items.Item(Row).Pieces
                                If Not PCE.Hidden Then
                                    Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
                                    Dim _IsSummaryPiece As Boolean = PT.IsSummaryPiece
                                    Dim _IsSummaryExclusion As Boolean = PT.IsSummaryExclusion
                                    If Not _IsSummaryPiece AndAlso Not _IsSummaryExclusion Then '確認するピースがサマリーピースの場合は無視する
                                        Dim _SD As DateTime = PCE.Start
                                        Dim _ED As DateTime
                                        If IsDBNull(PCE.Finish) Then
                                            _ED = _SD
                                        Else
                                            _ED = DateAdd(DateInterval.Day, -1, PCE.Finish)
                                        End If

                                        If MiniDate.ToOADate = 0 OrElse _SD <= MiniDate Then
                                            MiniDate = _SD
                                        End If
                                        If MaxDate.ToOADate = 0 OrElse MaxDate <= _ED Then
                                            MaxDate = _ED
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Else
                        Exit For
                    End If
                Next
            Catch ex As Exception
                Logs.PutErrorEx("サマリーピース日付取得エラー", ex, True)
            End Try
            
        End If
       
    End Sub
    ''' <summary>
    ''' 子レベルの進捗率を計算する
    ''' </summary>
    ''' <param name="BaseRow"></param>
    ''' <param name="Progress"></param>
    ''' <remarks></remarks>
    Private Sub CheckChildPieceProgress(BaseRow As Integer, ByRef Progress As Decimal)
        Dim ColIndex As Integer = SummaryTagetCol()
        If ColIndex > -1 Then
            Try
                Dim ParentLevel As Integer = TView.Cell(BaseRow, ColIndex).IndentLevel

                Dim ProTotalDay As Decimal = 0
                Dim ProCountDay As Decimal = 0

                For Row As Integer = BaseRow + 1 To TView.Items.Count
                    Dim Level As Integer = TView.Cell(Row, ColIndex).IndentLevel
                    If Level > ParentLevel Then
                        If TView.Items.Item(Row).Pieces.Count > 0 Then
                            For Each PCE As KnTViewLib.Piece In TView.Items.Item(Row).Pieces
                                If Not PCE.Hidden Then
                                    If PCE.StartShape.Shape <> KnTViewLib.TivPointShape.tivPointShapeImage Then
                                        Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
                                        Dim _IsSummaryPiece As Boolean = PT.IsSummaryPiece
                                        Dim _IsSummaryExclusion As Boolean = PT.IsSummaryExclusion
                                        If Not _IsSummaryPiece AndAlso Not _IsSummaryExclusion Then '確認するピースがサマリーピースの場合は無視する
                                            If PCE.Progresses.Count > 0 Then
                                                Dim _ProTotalDay As Decimal = 0
                                                Dim _ProCountDay As Decimal = 0
                                                Dim _ProValue As Double = 0

                                                _ProTotalDay = DateDiff(DateInterval.Day, PCE.Start, PCE.Finish)
                                                _ProValue = PCE.Progresses.Item(1).PercentTo
                                                _ProCountDay = _ProTotalDay * _ProValue

                                                ProTotalDay += _ProTotalDay
                                                ProCountDay += _ProCountDay
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Else
                        Exit For
                    End If
                Next

                If ProTotalDay > 0 AndAlso ProCountDay > 0 Then
                    Progress = ProCountDay / ProTotalDay
                Else
                    Progress = 0
                End If
            Catch ex As Exception
                Logs.PutErrorEx("サマリーピース進捗集計エラー", ex, True)
            End Try

        End If

    End Sub
   
    ''' <summary>
    ''' どの列のレベルでサマリーを作るか確認する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>便宜上左から確認して見つけたらその列とする</remarks>
    Private Function SummaryTagetCol() As Integer
        Try
            For Index As Integer = 1 To TView.ColumnHeaders.Count
                For Row As Integer = 1 To TView.Items.Count
                    If TView.Cell(Row, Index).IndentLevel > 1 Then
                        Return Index
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
       
        Return -1
    End Function
    ''' <summary>
    ''' 指定行下に子レベルの行があるか？
    ''' </summary>
    ''' <param name="BaseRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckSummaryRow(BaseRow As Integer) As Boolean
        Dim ColIndex As Integer = SummaryTagetCol()
        Try
            If ColIndex > -1 Then
                Dim ParentLevel As Integer = TView.Cell(BaseRow, ColIndex).IndentLevel

                For Row As Integer = BaseRow + 1 To TView.Items.Count
                    Dim Level As Integer = TView.Cell(Row, ColIndex).IndentLevel
                    If Level > ParentLevel Then
                        Return True
                    Else
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

        Return False
    End Function
    ''' <summary>
    ''' ドラッグ表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_DragTipFormat(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_DragTipFormatEvent) Handles TView.DragTipFormat
        If e.dragPattern = KnTViewLib.TivDragPattern.tivDragPatternRubberBand Then
            e.tip.Value = "行№:" + e.startIndex.ToString() & "開始日時:" + e.startTime.ToString() & "行№:" & e.finishIndex.ToString() & "終了日時:" & e.finishTime.ToString()
        Else
            'e.tip.Value = e.startTime.ToString() & "～ " + e.finishTime.ToString()

            If CDate(e.finishTime).ToOADate = 0 Then
                e.tip.Value = String.Format(" {0:yy年M月d日} ", e.startTime)
            Else
                e.tip.Value = String.Format(" {0:yy年M月d日}", e.startTime) & " ～ " & String.Format("{0:yy年M月d日} ", DateAdd(DateInterval.Day, -1, e.finishTime))
            End If
        End If
    End Sub

    ''' <summary>
    ''' 印刷ヘッダー関係
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_HeaderPrint(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_HeaderPrintEvent) Handles TView.HeaderPrint
        ' タイトル描画
        Dim rcTitle As RECT

        ' タイトル文字列描画領域
        rcTitle.left = e.left : rcTitle.top = e.top + 20
        rcTitle.right = e.right : rcTitle.bottom = e.bottom

        ' タイトル
        Dim fontTitle As Integer = CreateFont(20, 0, 0, 0, 700, False, False, False, _
            SHIFTJIS_CHARSET, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS, DEFAULT_QUALITY, DEFAULT_PITCH Or FF_DONTCARE, "ＭＳ Ｐゴシック")
        Dim fontOld As Integer = SelectObject(e.hdc, fontTitle)
        DrawText(e.hdc, _Title, -1, rcTitle, 0)
        SelectObject(e.hdc, fontOld)
        DeleteObject(fontTitle)

        '作成者
        Dim fontOwner As Integer = CreateFont(14, 0, 0, 0, 0, False, False, False, _
            SHIFTJIS_CHARSET, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS, DEFAULT_QUALITY, DEFAULT_PITCH Or FF_DONTCARE, "ＭＳ Ｐゴシック")
        Dim fontOld2 As Integer = SelectObject(e.hdc, fontOwner)
        If _Owner <> "" Then
            DrawText(e.hdc, String.Format("作成：{0}", _Owner), -1, rcTitle, DT_SINGLELINE Or DT_TOP Or DT_RIGHT)
        End If
        SelectObject(e.hdc, fontOld2)
        DeleteObject(fontOwner)

        ' 日付描画
        Dim fontDate As Integer
        Dim strDate As String
        Dim rcDate As RECT
        strDate = "出力日付：" & Format(TView.CurrentTime.Time, "Long Date")
        rcDate.left = e.left : rcDate.top = e.top
        rcDate.right = e.right : rcDate.bottom = e.bottom
        fontDate = CreateFont(12, 0, 0, 0, 0, False, False, False, _
            SHIFTJIS_CHARSET, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS, DEFAULT_QUALITY, DEFAULT_PITCH Or FF_DONTCARE, "ＭＳ Ｐゴシック")
        fontOld = SelectObject(e.hdc, fontDate)
        DrawText(e.hdc, strDate, -1, rcDate, DT_SINGLELINE Or DT_TOP Or DT_RIGHT)
        SelectObject(e.hdc, fontOld)
        DeleteObject(fontDate)
    End Sub

#End Region
#Region "公開メソッド"
    ''' <summary>
    ''' TODO:(PUB)親フォームへの情報表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SheetInfomation(Optional IsNotUNDO As Boolean = False)
        FrmParent.LblOwner.Text = String.Format("制作者：{0}", _Owner)
        If _IsWaterFall Then
            FrmParent.LblRendou.Text = "ピース連動"
            FrmParent.LblRendou.Image = My.Resources.link_edit
        Else
            FrmParent.LblRendou.Text = "ピース非連動"
            FrmParent.LblRendou.Image = My.Resources.link_break
        End If

        If _TemporaryLock Then
            FrmParent.LblTempLock.Image = My.Resources.lock_16
        Else
            FrmParent.LblTempLock.Image = My.Resources.lock_open_16
        End If

        'インテンド幅の再調整
        For i As Integer = 0 To TView.ColumnHeaders.Count - 1
            With TView.ColumnHeaders.Item(i)
                .IndentWidth = _IndentLevel
            End With
        Next

        'UNDOの利用可能状況
        If Not IsNotUNDO Then
            FrmParent.ToolButton_Undo.Enabled = (_UndoDatas.Count > 1)
            FrmParent.LblUndoLevel.Text = _UndoDatas.Count
        End If
        'アイテムコピー状況
        FrmParent.ToolButton_PastePiece.Enabled = Not IsNothing(_CopyPiece)

        If _WorkFileIsLock Then
            FrmParent.LblLockFile.Text = "(LOCK)"
        Else
            FrmParent.LblLockFile.Text = ""
        End If

        TView.Refresh()
    End Sub

    Enum enumAddRow As Integer
        ''' <summary>
        ''' 上へ追加
        ''' </summary>
        ''' <remarks></remarks>
        ToUp = 0
        ''' <summary>
        ''' 下に追加
        ''' </summary>
        ''' <remarks></remarks>
        ToDown = 1
        ''' <summary>
        ''' 最下段に追加
        ''' </summary>
        ''' <remarks></remarks>
        ToBottom = 2
    End Enum
    ''' <summary>
    ''' TODO:(PUB)行追加
    ''' </summary>
    ''' <remarks></remarks>
    Public Function RowAdd(ByVal Value As enumAddRow) As KnTViewLib.Item
        Dim Item As KnTViewLib.IItem = Nothing
        Select Case Value
            Case enumAddRow.ToUp
                If SelectedRow > 0 Then
                    Item = TView.Items.AddFromTemplate(1, SelectedRow)
                    Item.Pieces.Format = "m/d"
                    Call CellDateRefresh()
                    FR.Edited = True
                    FrmParent.LblMessage.Text = "行を１行追加しました"
                End If
            Case enumAddRow.ToDown
                If SelectedRow > 0 Then
                    Item = TView.Items.AddFromTemplate(1, SelectedRow + 1)
                    Item.Pieces.Format = "m/d"
                    Call CellDateRefresh()
                    FR.Edited = True
                    FrmParent.LblMessage.Text = "行を１行追加しました"
                End If
            Case enumAddRow.ToBottom
                Item = TView.Items.AddFromTemplate(1)
                Item.Pieces.Format = "m/d"
                Call CellDateRefresh()
                FR.Edited = True
                FrmParent.LblMessage.Text = "行を最下段に追加しました"
        End Select
        Return Item
    End Function
    ''' <summary>
    ''' TODO:(PUB)行削除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RowDelete()
        Call RadialMenuHide()
        Try
            If SelectedRow > 0 Then
                Dim _Deleted As Boolean = False
                Dim _MotoColor As Color = ConvertColorValue(TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor)
                '現行設定背景色を待避する
                TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor = ConvertColorValue(Color.Yellow)

                If TView.Items.Count = 1 Then
                    If MsgBox("表示最後の行ですが、削除してもいいですか？", 4 + 32, "行削除確認") = MsgBoxResult.Yes Then
                        For Each PCE As KnTViewLib.Piece In TView.Items.Item(SelectedRow).Pieces
                            PCE.Balloons.Clear()
                            PCE.RelatedLines.Clear()
                        Next

                        TView.Items.Item(SelectedRow).Pieces.Clear()
                        TView.Items.Remove(SelectedRow)
                        SelectedRow = 0
                        FR.Edited = True
                        _Deleted = True
                    Else
                        '操作キャンセルなら、待避した背景色に戻す
                        TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor = ConvertColorValue(_MotoColor)
                        Return
                    End If
                Else
                    If MsgBox(String.Format("{0}行目を削除してもいいですか？", SelectedRow), 4 + 32, "行削除確認") = MsgBoxResult.Yes Then
                        If TView.Items.Item(SelectedRow).Pieces.Count > 0 Then
                            If MsgBox("行にピース／ストーンがありますが、削除してもいいですか？" & vbCrLf & "(設置ピース／ストーンも一緒に削除されます)", 4 + 32, "行削除確認") = MsgBoxResult.No Then
                                '操作キャンセルなら、待避した背景色に戻す
                                TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor = ConvertColorValue(_MotoColor)
                                Return
                            End If
                        End If
                        For Each PCE As KnTViewLib.Piece In TView.Items.Item(SelectedRow).Pieces
                            PCE.Balloons.Clear()
                            PCE.RelatedLines.Clear()
                        Next
                        TView.Items.Item(SelectedRow).Pieces.Clear()
                        TView.Items.Remove(SelectedRow)
                        SelectedRow -= 1
                        Call CellDateRefresh()
                        FR.Edited = True
                        _Deleted = True
                    End If
                End If

                '接続先が削除された関係線を全て削除する
                If TView.Items.Count > 0 Then
                    For IIndex As Integer = 1 To TView.Items.Count
                        Dim Item As KnTViewLib.Item = TView.Items.Item(IIndex)
                        If Item.Pieces.Count > 0 Then
                            For PIndex As Integer = 1 To Item.Pieces.Count
                                Dim PCE As KnTViewLib.Piece = Item.Pieces.Item(PIndex)
                                If PCE.RelatedLines.Count > 0 Then
                                    For RlineIndex As Integer = PCE.RelatedLines.Count To 1 Step -1
                                        If Not PCE.RelatedLines.Item(RlineIndex).IsConnected Then
                                            PCE.RelatedLines.Remove(RlineIndex)
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If

                If Not _Deleted Then
                    '操作キャンセルなら、待避した背景色に戻す
                    If _MotoColor = Nothing Then
                        TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor = ConvertColorValue(Color.White)
                    Else
                        TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor = ConvertColorValue(_MotoColor)
                    End If
                End If
                FrmParent.LblMessage.Text = "行削除しました"

            End If
        Catch ex As Exception
            Logs.PutErrorEx("行削除エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' TODO:(PUB)拡張行削除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RowDeleteEx()
        Call RadialMenuHide()
        With FrmExpansionWork
            .TargetFrm = Me
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

            End If
        End With
    End Sub
    ''' <summary>
    ''' 全行削除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RowDeleteAll()
        Call RadialMenuHide()
        Try
            For Row As Integer = TView.Items.Count To 1 Step -1
                For Each PCE As KnTViewLib.Piece In TView.Items.Item(Row).Pieces
                    PCE.Balloons.Clear()
                    PCE.RelatedLines.Clear()
                Next
                TView.Items.Item(Row).Pieces.Clear()
                TView.Items.Remove(Row)
                SelectedRow = 0
            Next
        Catch ex As Exception
            Logs.PutErrorEx("行削除エラー", ex, True)
        End Try
    End Sub
    ''' <summary>
    ''' 行非表示設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RowHidden()
        Call RadialMenuHide()
        If SelectedRow > 0 Then
            Dim _IsHedden As Boolean = False
            For Each CEL As KnTViewLib.Cell In TView.Items(SelectedRow - 1).cells
                If CEL.Tag = "HIDDEN" Then
                    _IsHedden = True
                    Exit For
                End If
            Next

            If Not _IsHedden Then
                If MsgBox(String.Format("{0}行目を非表示に設定してもいいですか？", SelectedRow), 4 + 32, "行非表示確認") = MsgBoxResult.Yes Then
                    For Each CEL As KnTViewLib.Cell In TView.Items(SelectedRow - 1).cells
                        CEL.Tag = "HIDDEN"
                        CEL.Fill.BackColor = ConvertColorValue(SystemColors.Control)
                    Next
                    FR.Edited = True
                End If
            Else
                If MsgBox(String.Format("{0}行目を非表示を解除してもいいですか？", SelectedRow), 4 + 32, "行非表示解除確認") = MsgBoxResult.Yes Then
                    For Each CEL As KnTViewLib.Cell In TView.Items(SelectedRow - 1).cells
                        CEL.Tag = ""
                        CEL.Fill.BackColor = ConvertColorValue(Color.White)
                    Next
                    FR.Edited = True
                End If
            End If
        End If
    End Sub

    Enum enumColumnAdd As Integer
        ''' <summary>
        ''' 左に追加
        ''' </summary>
        ''' <remarks></remarks>
        ToLeft = 0
        ''' <summary>
        ''' 右に追加
        ''' </summary>
        ''' <remarks></remarks>
        ToRight = 1
        ''' <summary>
        ''' 最後尾に追加
        ''' </summary>
        ''' <remarks></remarks>
        ToLast = 2
    End Enum
    ''' <summary>
    ''' TODO:(PUB)列追加
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ColumnAdd(ByVal Value As enumColumnAdd)
        Call RadialMenuHide()
        Dim Item As KnTViewLib.ColumnHeader
        Select Case Value
            Case enumColumnAdd.ToLeft
                If SelectedColumn > 0 Then
                    Item = TView.ColumnHeaders.Add(SelectedColumn, )
                    Item.MergeMode = KnTViewLib.TivMergeMode.tivMergeFree
                    Call CellDateRefresh()
                    FR.Edited = True
                    FrmParent.LblMessage.Text = "列を１列追加しました"
                End If
            Case enumColumnAdd.ToRight
                If SelectedColumn > 0 Then
                    Item = TView.ColumnHeaders.Add(SelectedColumn + 1, )
                    Item.MergeMode = KnTViewLib.TivMergeMode.tivMergeFree
                    Call CellDateRefresh()
                    FR.Edited = True
                    FrmParent.LblMessage.Text = "列を１列追加しました"
                End If
            Case enumColumnAdd.ToLast
                Item = TView.ColumnHeaders.Add(, )
                'MsgBox("2")
                Item.MergeMode = KnTViewLib.TivMergeMode.tivMergeFree
                Call CellDateRefresh()
                FR.Edited = True
                FrmParent.LblMessage.Text = "列を最後尾に追加しました"
        End Select
        Call FontSizeChange() 'フォント調整
        'For Each Col As KnTViewLib.ColumnHeader In TView.ColumnHeaders
        '    Col.Font.Charset = 128
        'Next
        'TView.Refresh()
    End Sub
    ''' <summary>
    ''' TODO:(PUB)列削除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ColumnDelete()
        Call RadialMenuHide()
        Try
            If SelectedColumn > 0 Then
                Dim _Deleted As Boolean = False
                Dim _MotoColor As New List(Of UInteger)

                For Row As Integer = 1 To TView.Items.Count
                    '設定済みの背景色を待避してハイライト表示する
                    _MotoColor.Add(TView.Cell(Row, SelectedColumn).Fill.BackColor)
                    TView.Cell(Row, SelectedColumn).Fill.BackColor = ConvertColorValue(Color.Yellow)
                Next

                If TView.ColumnHeaders.Count = 1 Then
                    If MsgBox("表示最後の列ですが、削除してもいいですか？", 4 + 32, "列削除確認") = MsgBoxResult.Yes Then
                        TView.ColumnHeaders.Remove(SelectedColumn)
                        SelectedColumn = 0
                        Call CellDateRefresh()
                        FR.Edited = True
                        _Deleted = True
                    End If
                Else
                    If MsgBox(String.Format("{0}列目を削除してもいいですか？", SelectedColumn), 4 + 32, "列削除確認") = MsgBoxResult.Yes Then
                        TView.ColumnHeaders.Remove(SelectedColumn)
                        SelectedColumn -= 1
                        Call CellDateRefresh()
                        FR.Edited = True
                        _Deleted = True
                    End If
                End If

                If Not _Deleted Then
                    '操作がキャンセルなら、待避していた背景色に戻す
                    For Row As Integer = 1 To TView.Items.Count
                        TView.Cell(Row, SelectedColumn).Fill.BackColor = _MotoColor(Row - 1)
                    Next
                End If
                FrmParent.LblMessage.Text = "列削除しました"
            End If
        Catch ex As Exception
            Logs.PutErrorEx("列削除エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' 全列を削除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ColumnDeleteAll()
        Call RadialMenuHide()
        Try
            For Col As Integer = TView.ColumnHeaders.Count To 1 Step -1
                TView.ColumnHeaders.Remove(Col)
            Next
        Catch ex As Exception
            Logs.PutErrorEx("列削除エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' 行移動値
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enum_MoveRow As Integer
        ''' <summary>
        ''' 上へ移動
        ''' </summary>
        ''' <remarks></remarks>
        ToUp = 0
        ''' <summary>
        ''' 下へ移動
        ''' </summary>
        ''' <remarks></remarks>
        ToDown = 1
    End Enum
    ''' <summary>
    ''' TODO:(PUB)行移動
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Sub MoveRow(ByVal Value As enum_MoveRow)
        Call RadialMenuHide()
        With TView.Items
            If .Count > 0 AndAlso SelectedRow > 0 Then
                Try
                    Dim Flg As Boolean = False
                    If TView.Items.Item(SelectedRow).Pieces.Count > 0 Then
                        For Each PCE As KnTViewLib.Piece In TView.Items.Item(SelectedRow).Pieces
                            Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
                            If PT.IsSummaryPiece Then
                                Flg = True
                                Exit For
                            End If
                        Next
                    End If
                    If Flg Then
                        If MsgBox("移動する行にサマリーピースが含まれます" & vbCrLf & "移動を続けますか？", 4 + 32, "確認") = MsgBoxResult.No Then
                            Return
                        End If
                    End If

                    If Value = enum_MoveRow.ToUp Then
                        If SelectedRow > 1 Then
                            .Move(SelectedRow, SelectedRow - 1)
                            SelectedRow -= 1
                        End If
                        FrmParent.LblMessage.Text = "行を上に移動しました"

                    Else
                        If SelectedRow < .Count Then
                            .Move(SelectedRow, SelectedRow + 1)
                            SelectedRow += 1
                        End If
                        FrmParent.LblMessage.Text = "行を下に移動しました"

                    End If
                    Call CellDateRefresh()
                    FR.Edited = True

                Catch ex As Exception
                    Logs.PutErrorEx("行移動エラー", ex, True)
                End Try
            End If
        End With

    End Sub
    ''' <summary>
    ''' 列移動値
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enum_MoveCol As Integer
        ''' <summary>
        ''' 左へ移動
        ''' </summary>
        ''' <remarks></remarks>
        ToLeft = 0
        ''' <summary>
        ''' 右へ移動
        ''' </summary>
        ''' <remarks></remarks>
        ToRight = 1
    End Enum
    ''' <summary>
    ''' TODO:(PUB)列移動
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Sub MoveCol(ByVal Value As enum_MoveCol)
        Call RadialMenuHide()
        Try
            With TView.ColumnHeaders
                If .Count > 0 AndAlso SelectedColumn > 0 Then
                    If Value = enum_MoveCol.ToLeft Then
                        If SelectedColumn > 1 Then
                            .Add(SelectedColumn - 1)
                            Dim OldCol As Integer = SelectedColumn + 1
                            Dim NewCol As Integer = SelectedColumn - 1
                            Call CellHeader(TView, OldCol, NewCol)
                            For Row As Integer = 1 To TView.Items.Count
                                Call CellCopy(TView, Row, OldCol, Row, NewCol)
                            Next
                            TView.ColumnHeaders.Remove(OldCol)
                            SelectedColumn -= 1
                            FrmParent.LblMessage.Text = "列を左に移動しました"
                        End If
                    Else
                        If SelectedColumn < .Count Then
                            .Add(SelectedColumn + 2)
                            Dim OldCol As Integer = SelectedColumn
                            Dim NewCol As Integer = SelectedColumn + 2
                            Call CellHeader(TView, OldCol, NewCol)
                            For Row As Integer = 1 To TView.Items.Count
                                Call CellCopy(TView, Row, OldCol, Row, NewCol)
                            Next
                            TView.ColumnHeaders.Remove(OldCol)
                            SelectedColumn += 1
                            FrmParent.LblMessage.Text = "列を右に移動しました"
                        End If
                    End If
                    Call CellDateRefresh()
                    FR.Edited = True
                End If
            End With
        Catch ex As Exception
            Logs.PutErrorEx("列移動エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' TODO:(PUB)バルーンの追加
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BalloonnAdd()
        Call RadialMenuHide()
        Try
            Dim BL As KnTViewLib.Balloon = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons.Add(, )
            With BL
                .AnchorPoint.X = 50
                .AnchorPoint.Y = 50
                .AnchorRelPoint.X = 0
                .AnchorRelPoint.Y = 0
                .BalloonShape.Fill.BackColor = ConvertColorValue(Color.LightYellow)
                .Caption.Color = ConvertColorValue(Color.Black)
            End With
            FR.Edited = True
        Catch ex As Exception
            Logs.PutErrorEx("バルーン追加エラー", ex, True)
        End Try

    End Sub

    ''' <summary>
    ''' TODO:(PUB)データのエクスポート（グリッド）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DataExport()
        Call RadialMenuHide()
        With FrmExportData
            .Obj = TView
            Call .ShowDialog()
        End With
    End Sub
    ''' <summary>
    ''' TODO:(PUB)データエクスポート（XML）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DataExportXML()
        Call RadialMenuHide()
        If TView.Items.Count = 0 Then
            Return
        End If

        Dim FileName As String = ""
        Using SFD As New SaveFileDialog
            With SFD
                .AddExtension = True
                .CheckPathExists = True
                .DefaultExt = ".xml"
                .Filter = "XMLファイル(*.xml)|*.xml|全てのファイル(*.*)|*.*"
                .FilterIndex = 0
                .OverwritePrompt = True
                .Title = "XMLファイル保存"
                .FileName = String.Format("{0}.xml", _Title)
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    FileName = .FileName
                End If
            End With
        End Using

        If FileName <> "" Then
            Try
                Dim LocalClass As New XMLData
                LocalClass.Title = _Title
                LocalClass.Owner = _Owner
                If TView.Items.Count > 0 Then
                    ReDim LocalClass.Row(TView.Items.Count - 1)
                    For Row As Integer = 1 To TView.Items.Count
                        LocalClass.Row(Row - 1) = New RowData

                        'セルデータ
                        If TView.ColumnHeaders.Count > 0 Then
                            ReDim LocalClass.Row(Row - 1).Cell(TView.ColumnHeaders.Count - 1)
                            For Col As Integer = 1 To TView.ColumnHeaders.Count
                                LocalClass.Row(Row - 1).Cell(Col - 1) = New CellData
                                LocalClass.Row(Row - 1).Cell(Col - 1).CellText = TView.Cell(Row, Col).Value
                            Next
                        End If

                        'ピースデータ
                        If TView.Items.Item(Row).Pieces.Count > 0 Then
                            ReDim LocalClass.Row(Row - 1).Piece(TView.Items.Count - 1)
                            For P As Integer = 1 To TView.Items.Item(Row).Pieces.Count
                                LocalClass.Row(Row - 1).Piece(P - 1) = New PieceData
                                If Not IsDBNull(TView.Items.Item(Row).Pieces.Item(P).Start) Then
                                    LocalClass.Row(Row - 1).Piece(P - 1).StartDate = CDate(TView.Items.Item(Row).Pieces.Item(P).Start)
                                Else
                                    LocalClass.Row(Row - 1).Piece(P - 1).StartDate = Nothing
                                End If
                                If Not IsDBNull(TView.Items.Item(Row).Pieces.Item(P).Finish) Then
                                    LocalClass.Row(Row - 1).Piece(P - 1).FinDate = TView.Items.Item(Row).Pieces.Item(P).Finish
                                Else
                                    LocalClass.Row(Row - 1).Piece(P - 1).FinDate = Nothing
                                End If
                                LocalClass.Row(Row - 1).Piece(P - 1).PieceText = TView.Items.Item(Row).Pieces.Item(P).Captions.Item(2).Text

                                '進捗データ
                                If TView.Items.Item(Row).Pieces.Item(P).Progresses.Count > 0 Then
                                    LocalClass.Row(Row - 1).Piece(P - 1).Progress = TView.Items.Item(Row).Pieces.Item(P).Progresses.Item(1).PercentTo.ToString
                                Else
                                    LocalClass.Row(Row - 1).Piece(P - 1).Progress = "0"
                                End If

                                'バルーンデータ
                                If TView.Items.Item(Row).Pieces.Item(P).Balloons.Count > 0 Then
                                    ReDim LocalClass.Row(Row - 1).Piece(P - 1).Balloon(TView.Items.Item(Row).Pieces.Item(P).Balloons.Count - 1)
                                    For B As Integer = 1 To TView.Items.Item(Row).Pieces.Item(P).Balloons.Count
                                        LocalClass.Row(Row - 1).Piece(P - 1).Balloon(B - 1) = New BalloonData
                                        LocalClass.Row(Row - 1).Piece(P - 1).Balloon(B - 1).BalloonText = TView.Items.Item(Row).Pieces.Item(P).Balloons.Item(B).Caption.Text
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If

                'ファイルの書き込み
                Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(XMLData))
                Using FS As New IO.FileStream(FileName, IO.FileMode.Create)
                    SRZ.Serialize(FS, LocalClass)
                End Using
                Logs.PutInformation("XMLファイルを出力しました", FileName)
                MsgBox("XMLファイルを出力しました", 64, "情報")
            Catch ex As Exception
                Logs.PutErrorEx("XMLファイルを出力に失敗しました", ex, True)
            End Try
        End If

    End Sub
    ''' <summary>
    ''' 画像ファイルに出力する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveSnapShot()
        Call RadialMenuHide()
        Dim Flg As Boolean = False
        If TView.Items.Count > 0 Then
            If TView.ColumnHeaders.Count > 0 Then
                For Row As Integer = 1 To TView.Items.Count
                    If TView.Items.Item(Row).Pieces.Count > 0 Then
                        Flg = True
                        Exit For
                    End If
                Next
            End If
        End If

        If Flg Then
            Dim FL As String = ""
            Using SFD As New SaveFileDialog
                With SFD
                    .AddExtension = True
                    .CheckPathExists = True
                    .DefaultExt = ".bmp"
                    .FileName = String.Format("{0}.bmp", _Title)
                    .Filter = "ビットマップ(*.bmp)|*.bmp|JPEGファイル(*.jpg)|*.jpg|PNGファイル(*.png)|*.png|全てのファイル(*.*)|*.*"
                    .FilterIndex = 0
                    .OverwritePrompt = True
                    .RestoreDirectory = True
                    .Title = "保存先"
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        FL = .FileName
                    End If
                End With
            End Using

            If FL <> "" Then
                Try
                    With FrmSnapShotInfo
                        .Obj = TView
                        If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                            FrmParent.TopMost = False
                            Me.TopMost = True
                        End If
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                            Dim kk As KnTViewLib.OutputInfo = .OutputInfo
                            If Path.GetExtension(FL).ToUpper = ".BMP" Then
                                TView.SaveFile(FL, KnTViewLib.TivSaveFileFormat.tivSaveFileFmtBitmap, kk)
                            Else
                                TView.SaveFile(FL, KnTViewLib.TivSaveFileFormat.tivSaveFileFmtBitmap, kk)
                            End If
                            Logs.PutInformation("スナップショットを保存しました", FL)
                            MsgBox("スナップショットを保存しました", 64, "情報")
                        End If
                        If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                            FrmParent.TopMost = True
                        End If
                    End With
                Catch ex As Exception
                    Logs.PutErrorEx("スナップショット保存に失敗しました。", ex, True)
                End Try

            End If
        End If

    End Sub
    ''' <summary>
    ''' TODO:(PUB)フォントサイズ調整
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FontSizeChange()
        Select Case _FontSizePiece
            Case Is < 7 : _FontSizePiece = 7
            Case Is > 48 : _FontSizePiece = 48
        End Select
        Select Case _FontSizeCell
            Case Is < 7 : _FontSizeCell = 7
            Case Is > 48 : _FontSizeCell = 48
        End Select
        Select Case _FontSizeCellHeader
            Case Is < 7 : _FontSizeCellHeader = 7
            Case Is > 48 : _FontSizeCellHeader = 48
        End Select

        Try
            TView.PieceFont = New Font(FontFamily.GenericSansSerif, _FontSizePiece)
            TView.Font = New Font(FontFamily.GenericSansSerif, _FontSizeCellHeader)

            If TView.ColumnHeaders.Count > 0 Then
                For Index As Integer = 0 To TView.ColumnHeaders.Count - 1
                    TView.ColumnHeaders(Index).Font.size = _FontSizeCell
                Next
            End If
        Catch ex As Exception
            Logs.PutErrorEx("フォントサイズ設定に失敗しました。", ex, True)
        End Try
    End Sub
    ''' <summary>
    ''' TODO:(PUB)データ保存
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveData()
        Call RadialMenuHide()
        If Not IsEditMode Then '閲覧モード時は操作をキャンセル
            Return
        End If
        Try
            Dim Data As New WindyDataCollection
            Data.Title = _Title
            Data.Owner = _Owner
            Data.IsExclusion = _IsExclusion
            Data.ExclusionPassword = _ExclusionPassword
            Data.LoadLock = _LoadLock
            Data.RowCount = TView.Items.Count
            Data.ColCount = TView.ColumnHeaders.Count
            Data.RowHeight = TView.ItemHeight
            Data.Zoom = TView.TimeScale.Medium.Interval
            Data.PieceCenterHeight = TView.PieceCenterHeight
            Data.PieceLayout = TView.PieceLayout
            Data.ViewTopTime = TView.ViewTopTime.ToString
            Data.IsWaterFall = _IsWaterFall
            Data.IsWaterFallLock = _IsWaterFallLock
            Data.CellDateFormat = _CellDateFormat
            Data.NACellValue = _NACellValue
            Data.IndentLevel = _IndentLevel

            '作業履歴
            For Each Item As WorkHistoryCollection In _WorkHistory
                Data.WorkHistory.Add(Item)
            Next

            For Each Item As SpecialTimeCollection In _SpecialTimeData
                Dim S As New SpecialTimeCollection
                S.Start = Item.Start
                S.Finish = Item.Finish
                S.CellText = Item.CellText
                S.CellColor = Item.CellColor
                S.IsTunnel = Item.IsTunnel
                Data.SpecialTime.Add(S)
            Next

            'カラムヘッダ
            For Index As Integer = 1 To TView.ColumnHeaders.Count
                Dim H As New HeaderCollection
                H.ColIndex = Index
                H.Text = TView.ColumnHeaders.Item(Index).Text
                H.HAlign = TView.ColumnHeaders.Item(Index).HorAlign
                H.VAlign = TView.ColumnHeaders.Item(Index).VerAlign
                H.Width = TView.ColumnHeaders.Item(Index).Width
                H.CellMerge = TView.ColumnHeaders.Item(Index).MergeMode
                H.IsHidden = TView.ColumnHeaders.Item(Index).Hidden
                Data.Header.Add(H)
            Next

            For Index As Integer = 1 To TView.Items.Count
                Dim H As New RowAttribCollection
                H.RowIndex = Index
                H.BackColor = TView.Items.Item(Index).PiecePane.Fill.BackColor
                H.IsHidden = TView.Items.Item(Index).Hidden
                Data.RowAttrib.Add(H)
            Next

            'マスタピース
            If Not IsNothing(_MasterPiece) AndAlso _MasterPiece.PieceColor <> 0 Then
                Dim MItm As New PieceCollection
                MItm.RowIndex = 0 : MItm.ColIndex = 0
                'Dim MPCE As KnTViewLib.Piece = _MasterPiece
                MItm.Start = _MasterPiece.Start
                If Not IsDBNull(_MasterPiece.Finish) Then
                    MItm.Finish = _MasterPiece.Finish
                End If
                MItm.PieceColor = _MasterPiece.PieceColor
                MItm.Shape = _MasterPiece.Shape
                MItm.ShapeName = _MasterPiece.ShapeName
                MItm.Tunnel = _MasterPiece.Tunnel
                MItm.LockPiece = _MasterPiece.LockPiece

                Dim MItmL As New CaptionCollection
                Dim MItmC As New CaptionCollection
                Dim MItmR As New CaptionCollection
                With _MasterPiece
                    With .CaptionLeft
                        MItmL.ForeColor = .ForeColor
                        MItmL.HAlign = .HAlign
                        MItmL.VAlign = .VAlign
                        MItmL.Position = .Position
                        MItmL.Text = .Text
                        MItm.CaptionLeft = MItmL
                    End With
                    With .CaptionCenter
                        MItmC.ForeColor = .ForeColor
                        MItmC.HAlign = .HAlign
                        MItmC.VAlign = .VAlign
                        MItmC.Position = .Position
                        MItmC.Text = .Text
                        MItm.CaptionCenter = MItmC
                    End With
                    With .CaptionRight
                        MItmR.ForeColor = .ForeColor
                        MItmR.HAlign = .HAlign
                        MItmR.VAlign = .VAlign
                        MItmR.Position = .Position
                        MItmR.Text = .Text
                        MItm.CaptionRight = MItmR
                    End With
                    'End If

                    MItm.CaptionLeft = MItmL
                    MItm.CaptionCenter = MItmC
                    MItm.CaptionRight = MItmR

                End With
                'If MPCE.Progresses.Count > 0 Then
                Dim Prg As New ProgressBarCollection
                Prg.ProgressType = _MasterPiece.ProgressBar.ProgressType
                Prg.ProgressPercent = _MasterPiece.ProgressBar.ProgressPercent
                Prg.ProgressColor = _MasterPiece.ProgressBar.ProgressColor
                Prg.ProgressDisplay = _MasterPiece.ProgressBar.ProgressDisplay
                Prg.IsNotUseProgress = _MasterPiece.ProgressBar.IsNotUseProgress
                MItm.ProgressBar = Prg
                'End If
                Data.MasterPiece = MItm
            End If

            'テンプレートピース
            If Not IsNothing(_TemplatePiece) AndAlso _TemplatePiece.PieceColor <> 0 Then
                Dim MItm As New PieceCollection
                MItm.RowIndex = 0 : MItm.ColIndex = 0
                MItm.Start = _TemplatePiece.Start
                If Not IsDBNull(_TemplatePiece.Finish) Then
                    MItm.Finish = _TemplatePiece.Finish
                End If
                MItm.PieceColor = _TemplatePiece.PieceColor
                MItm.Shape = _TemplatePiece.Shape
                MItm.ShapeName = _TemplatePiece.ShapeName
                MItm.Tunnel = _TemplatePiece.Tunnel
                MItm.LockPiece = _TemplatePiece.LockPiece

                Dim MItmL As New CaptionCollection
                Dim MItmC As New CaptionCollection
                Dim MItmR As New CaptionCollection
                With _TemplatePiece

                    'ピース
                    With .CaptionLeft
                        MItmL.ForeColor = .ForeColor
                        MItmL.HAlign = .HAlign
                        MItmL.VAlign = .VAlign
                        MItmL.Position = .Position
                        MItmL.Text = .Text
                        MItm.CaptionLeft = MItmL
                    End With
                    With .CaptionCenter
                        MItmC.ForeColor = .ForeColor
                        MItmC.HAlign = .HAlign
                        MItmC.VAlign = .VAlign
                        MItmC.Position = .Position
                        MItmC.Text = .Text
                        MItm.CaptionCenter = MItmC
                    End With
                    With .CaptionRight
                        MItmR.ForeColor = .ForeColor
                        MItmR.HAlign = .HAlign
                        MItmR.VAlign = .VAlign
                        MItmR.Position = .Position
                        MItmR.Text = .Text
                        MItm.CaptionRight = MItmR
                    End With
                    'End If

                    MItm.CaptionLeft = MItmL
                    MItm.CaptionCenter = MItmC
                    MItm.CaptionRight = MItmR

                End With
                'If MPCE.Progresses.Count > 0 Then
                Dim Prg As New ProgressBarCollection
                Prg.ProgressType = _TemplatePiece.ProgressBar.ProgressType
                Prg.ProgressPercent = _TemplatePiece.ProgressBar.ProgressPercent
                Prg.ProgressColor = _TemplatePiece.ProgressBar.ProgressColor
                Prg.ProgressDisplay = _TemplatePiece.ProgressBar.ProgressDisplay
                Prg.IsNotUseProgress = _TemplatePiece.ProgressBar.IsNotUseProgress
                MItm.ProgressBar = Prg
                'End If
                Data.TemplatePiece = MItm
            End If

            If TView.Items.Count > 0 Then
                For Row As Integer = 1 To TView.Items.Count
                    'セル
                    For Index As Integer = 1 To TView.ColumnHeaders.Count
                        Dim _T As CellTagCollection = CellTagConvert(TView.Cell(Row, Index).Tag)
                        Dim H As New HeaderCellCollection
                        H.RowIndex = Row : H.ColIndex = Index
                        'H.Text = TView.Cell(Row, Index).Value
                        H.Text = _T.Caption
                        H.HAlign = TView.Cell(Row, Index).HorAlign
                        H.VAlign = TView.Cell(Row, Index).VerAlign
                        H.BackColor = TView.Cell(Row, Index).Fill.BackColor
                        H.ForeColor = TView.Cell(Row, Index).Color
                        'If TView.Cell(Row, Index).Tag = "HIDDEN" Then
                        '    H.IsHidden = True
                        'Else
                        '    H.IsHidden = False
                        'End If
                        H.IsHidden = _T.IsHidden
                        H.IndentLevel = TView.Cell(Row, Index).IndentLevel
                        Data.HeaderCell.Add(H)
                    Next

                    For Index As Integer = 1 To TView.Items.Item(Row).Pieces.Count
                        'Hidden設定されているピースはマスターピースなので、それは保存しない
                        If Not TView.Items.Item(Row).Pieces.Item(Index).Hidden Then
                            Dim Itm As New PieceCollection
                            Itm.RowIndex = Row : Itm.ColIndex = Index
                            Dim PCE As KnTViewLib.Piece = TView.Items.Item(Row).Pieces.Item(Index)
                            Itm.Start = PCE.Start
                            If Not PCE.Finish Is System.DBNull.Value Then
                                Itm.Finish = PCE.Finish
                            End If
                            Itm.PieceColor = PCE.BarShape.Fill.BackColor
                            Itm.Shape = PCE.StartShape.Shape
                            Itm.ShapeName = PCE.Tag

                            ''''''
                            Itm.LockPiece = PCE.Weight

                            Itm.Tunnel = PCE.Tunnel

                            Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
                            Itm.IsSummaryPiece = PT.IsSummaryPiece
                            Itm.UseSummaryProgress = PT.UseSummaryPreogress
                            Itm.IsSummaryExclusion = PT.IsSummaryExclusion


                            Dim ItmL As New CaptionCollection
                            Dim ItmC As New CaptionCollection
                            Dim ItmR As New CaptionCollection
                            With PCE.Captions
                                Dim PV As PieceValueCollection = PCE.Value
                                If PCE.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                                    'マイルストーン
                                    With .Item(1)
                                        ItmL.ForeColor = .Color
                                        ItmL.HAlign = .HorAlign
                                        ItmL.VAlign = .VerAlign
                                        ItmL.Position = .Position
                                        ItmL.Text = PV.CaptionLeft
                                        Itm.CaptionLeft = ItmL
                                    End With
                                    With .Item(2)
                                        ItmC.ForeColor = .Color
                                        ItmC.HAlign = .HorAlign
                                        ItmC.VAlign = .VerAlign
                                        ItmC.Position = .Position
                                        ItmC.Text = PV.CaptionCenter
                                        Itm.CaptionCenter = ItmC
                                    End With
                                    With .Item(2)
                                        ItmR.ForeColor = .Color
                                        ItmR.HAlign = .HorAlign
                                        ItmR.VAlign = .VerAlign
                                        ItmR.Position = .Position
                                        ItmR.Text = PV.CaptionRight
                                        Itm.CaptionRight = ItmR
                                    End With
                                    Itm.ShapeName = PV.StoneImageKey
                                Else

                                    'ピース
                                    With .Item(1)
                                        ItmL.ForeColor = .Color
                                        ItmL.HAlign = .HorAlign
                                        ItmL.VAlign = .VerAlign
                                        ItmL.Position = .Position
                                        ItmL.Text = PV.CaptionLeft
                                        Itm.CaptionLeft = ItmL
                                    End With
                                    With .Item(2)
                                        ItmC.ForeColor = .Color
                                        ItmC.HAlign = .HorAlign
                                        ItmC.VAlign = .VerAlign
                                        ItmC.Position = .Position
                                        ItmC.Text = PV.CaptionCenter
                                        Itm.CaptionCenter = ItmC
                                    End With
                                    With .Item(3)
                                        ItmR.ForeColor = .Color
                                        ItmR.HAlign = .HorAlign
                                        ItmR.VAlign = .VerAlign
                                        ItmR.Position = .Position
                                        ItmR.Text = PV.CaptionRight
                                        Itm.CaptionRight = ItmR
                                    End With
                                End If

                                Itm.CaptionLeft = ItmL
                                Itm.CaptionCenter = ItmC
                                Itm.CaptionRight = ItmR

                            End With
                            If PCE.Progresses.Count > 0 Then
                                Dim Prg As New ProgressBarCollection
                                Prg.ProgressType = PCE.Progresses.Item(1).Shape
                                Prg.ProgressPercent = PCE.Progresses.Item(1).PercentTo
                                Prg.ProgressColor = PCE.Progresses.Item(1).Fill.BackColor
                                Prg.ProgressDisplay = PCE.Progresses.Item(1).Key
                                Prg.IsNotUseProgress = PCE.Progresses.Item(1).Hidden
                                Itm.ProgressBar = Prg
                            End If
                            Data.Piece.Add(Itm)
                        End If
                    Next

                    For Index As Integer = 1 To TView.Items.Item(Row).Pieces.Count
                        Dim PCE As KnTViewLib.Piece = TView.Items.Item(Row).Pieces.Item(Index)
                        For ItmIndex As Integer = 1 To PCE.RelatedLines.Count
                            If PCE.RelatedLines.Item(ItmIndex).IsConnected Then
                                Dim Itm As New RelatedLineCollection
                                Itm.FromRowIndex = Row : Itm.FromColIndex = Index
                                Itm.ToRowIndex = PCE.RelatedLines.Item(ItmIndex).Relation.ItemIndex
                                Itm.ToColIndex = PCE.RelatedLines.Item(ItmIndex).Relation.Index
                                Itm.RelatedStyle = PCE.RelatedLines.Item(ItmIndex).Style
                                Itm.RelatedLineStyle = PCE.RelatedLines.Item(ItmIndex).Line.Style
                                Data.RelatedLine.Add(Itm)
                            End If
                        Next
                    Next

                    For Index As Integer = 1 To TView.Items.Item(Row).Pieces.Count
                        Dim PCE As KnTViewLib.Piece = TView.Items.Item(Row).Pieces.Item(Index)
                        For ItmIndex As Integer = 1 To PCE.Balloons.Count
                            Dim Itm As New BalloonCollection
                            Itm.RowIndex = Row : Itm.ColIndex = Index
                            Itm.Pont = New Point(PCE.Balloons.Item(ItmIndex).PosRelPoint.X, PCE.Balloons.Item(ItmIndex).PosRelPoint.Y)
                            Itm.AnchorPoint = New Point(PCE.Balloons.Item(ItmIndex).AnchorPoint.X, PCE.Balloons.Item(ItmIndex).AnchorPoint.Y)
                            Itm.AnchorRelPoint = New Point(PCE.Balloons.Item(ItmIndex).AnchorRelPoint.X, PCE.Balloons.Item(ItmIndex).AnchorRelPoint.Y)
                            Itm.BackColor = PCE.Balloons.Item(ItmIndex).BalloonShape.Fill.BackColor
                            'Itm.ForeColor = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).BalloonShape.Fill.ForeColor
                            Itm.Style = PCE.Balloons.Item(ItmIndex).BalloonShape.Shape

                            Dim ItmC As New CaptionCollection
                            ItmC.ForeColor = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).Caption.Color
                            ItmC.Text = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).Caption.Text
                            ItmC.HAlign = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).Caption.HorAlign
                            ItmC.VAlign = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).Caption.VerAlign
                            Itm.Caption = ItmC

                            Dim ItmB As New BalloonShapeCollection
                            ItmB.BeakBase = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).BalloonShape.BeakBase
                            ItmB.Height = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).BalloonShape.Height
                            ItmB.Width = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).BalloonShape.Width
                            Itm.BalloonShape = ItmB
                            Data.Balloon.Add(Itm)
                        Next
                    Next
                Next
            End If
            Call XMLSaveData(Data, _WorkFileName)

            Me.Text = String.Format("{0} ( {1} )", _Title, Path.GetFileName(_WorkFileName))
            FR.Title = String.Format("{0} ( {1} )", _Title, Path.GetFileName(_WorkFileName))

            FR.Edited = False
            Logs.PutInformation("データを保存")
            FrmParent.LblMessage.Text = "データ保存完了しました"

            Call UndoClear() 'UNDOクリア

        Catch ex As Exception
            Logs.PutErrorEx("データ保存失敗しました", ex, True)
        End Try

    End Sub

    ''' <summary>
    ''' TODO:(PUB)データ読込
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReadData()
        Call RadialMenuHide()
        Try
            Dim Data As New List(Of WindyDataCollection)
            If XMLReadData(Data, _WorkFileName) Then
                _Title = Data(0).Title
                _Owner = Data(0).Owner
                _IsExclusion = Data(0).IsExclusion
                _ExclusionPassword = Data(0).ExclusionPassword
                _LoadLock = Data(0).LoadLock
                _IsWaterFall = Data(0).IsWaterFall
                _IsWaterFallLock = Data(0).IsWaterFallLock
                _CellDateFormat = Data(0).CellDateFormat
                _NACellValue = Data(0).NACellValue

                Select Case Data(0).IndentLevel
                    Case Is < 1 : _IndentLevel = 1
                    Case Is > 30 : _IndentLevel = 30
                    Case Else
                        _IndentLevel = Data(0).IndentLevel
                End Select

                '作業履歴
                For i As Integer = 0 To Data(0).WorkHistory.Count - 1
                    Dim W As New WorkHistoryCollection
                    W.WorkTime = Data(0).WorkHistory(i).WorkTime
                    W.WorkerName = Data(0).WorkHistory(i).WorkerName
                    W.WorkNote = Data(0).WorkHistory(i).WorkNote
                    _WorkHistory.Add(W)
                Next

                For i As Integer = 1 To Data(0).RowCount
                    Call RowAdd(enumAddRow.ToBottom)
                Next
                For i As Integer = 1 To Data(0).ColCount - 1
                    Call ColumnAdd(enumColumnAdd.ToLast)
                Next

                TView.ItemHeightMode = KnTViewLib.TivMode.tivManual
                TView.ItemHeight = Data(0).RowHeight
                _ViewTopDate = Data(0).ViewTopTime
                TView.TimeScale.Medium.Interval = Data(0).Zoom
                TView.PieceCenterHeight = Data(0).PieceCenterHeight
                TView.PieceLayout = Data(0).PieceLayout

                'ヘッダー
                For i As Integer = 0 To Data(0).Header.Count - 1
                    Dim c As Integer = Data(0).Header(i).ColIndex
                    With TView.ColumnHeaders.Item(c)
                        .Text = Data(0).Header(i).Text
                        .HorAlign = Data(0).Header(i).HAlign
                        .VerAlign = Data(0).Header(i).VAlign
                        .Width = Data(0).Header(i).Width
                        .MergeMode = Data(0).Header(i).CellMerge
                        .Hidden = Data(0).Header(i).IsHidden
                        .IndentWidth = _IndentLevel
                    End With
                Next

                'セル
                For i As Integer = 0 To Data(0).HeaderCell.Count - 1
                    Dim r As Integer = Data(0).HeaderCell(i).RowIndex
                    Dim c As Integer = Data(0).HeaderCell(i).ColIndex
                    With TView.Cell(r, c)
                        Dim _C As New CellTagCollection
                        _C.Caption = Data(0).HeaderCell(i).Text
                        .Value = Data(0).HeaderCell(i).Text
                        .HorAlign = Data(0).HeaderCell(i).HAlign
                        .VerAlign = Data(0).HeaderCell(i).VAlign
                        .Fill.BackColor = Data(0).HeaderCell(i).BackColor
                        .Color = Data(0).HeaderCell(i).ForeColor

                        If Data(0).HeaderCell(i).IsHidden Then
                            .Fill.BackColor = ConvertColorValue(SystemColors.Control)
                            '.Tag = "HIDDEN"
                            _C.IsHidden = True
                        Else
                            '.Tag = ""
                            _C.IsHidden = False
                        End If
                        If Data(0).HeaderCell(i).IndentLevel = 0 Then
                            .IndentLevel = 1
                        Else
                            .IndentLevel = Data(0).HeaderCell(i).IndentLevel
                        End If

                        Call Cell_SetIntendIcon(TView.Cell(r, c)) 'インデントイメージの表示・非表示
                        .Tag = CellTagConvert(_C)
                    End With
                Next

                '特別時間帯
                _SpecialTimeData.Clear()
                _SpecialTimeData.AddRange(Data(0).SpecialTime)
                If _SpecialTimeData.Count > 0 Then
                    Dim STS As KnTViewLib.SpecialTimeSet = TView.SpecialTimeSets.Item(1)
                    For Each Item As SpecialTimeCollection In _SpecialTimeData
                        Dim spt As KnTViewLib.SpecialTime = STS.SpecialTimes.Add(, )
                        spt.ZOrder = 0
                        spt.Fill.BkMode = KnTViewLib.TivBkMode.tivOpaque
                        spt.Fill.Pattern = KnTViewLib.TivFillPattern.tivPatternNull
                        spt.Fill.BackColor = Item.CellColor
                        spt.Pattern = KnTViewLib.TivSpecialTime.tivSpecialTimeDirect
                        spt.Start = String.Format("{0:yyyy/MM/dd} 00:00:00", Item.Start)
                        spt.Finish = String.Format("{0:yyyy/MM/dd} 23:59:59", Item.Finish)
                        spt.Tunnelable = Item.IsTunnel
                    Next
                End If

                '行色
                For i As Integer = 0 To Data(0).RowAttrib.Count - 1
                    Dim c As Integer = Data(0).RowAttrib(i).RowIndex
                    TView.Items.Item(c).PiecePane.Fill.BackColor = Data(0).RowAttrib(i).BackColor
                    TView.Items.Item(c).Hidden = Data(0).RowAttrib(i).IsHidden
                Next

                'ピース／ストーン
                For i As Integer = 0 To Data(0).Piece.Count - 1
                    Dim r As Integer = Data(0).Piece(i).RowIndex
                    If Data(0).Piece(i).Shape = 11 Then
                        Dim PCE As KnTViewLib.Piece = TView.Items.Item(Data(0).Piece(i).RowIndex).Pieces.AddFromTemplate(2)
                        Dim PV As New PieceValueCollection
                        With PCE

                            PV.CaptionLeft = Data(0).Piece(i).CaptionLeft.Text
                            PV.CaptionCenter = Data(0).Piece(i).CaptionCenter.Text
                            PV.CaptionRight = Data(0).Piece(i).CaptionRight.Text
                            PV.StoneImageKey = Data(0).Piece(i).ShapeName

                            PCE.Start = Data(0).Piece(i).Start
                            'pce.Finish = Data(0).Piece(i).Finish

                            PCE.Weight = Data(0).Piece(i).LockPiece
                            Dim PT As New PeaceTagCollection
                            PT.IsWaterFall = False
                            PT.IsSummaryPiece = False
                            PT.UseSummaryPreogress = False
                            PT.IsSummaryExclusion = Data(0).Piece(i).IsSummaryExclusion
                            PCE.Tag = PeaceTag(PT)

                            If TView.ImageLists.Count > 0 Then
                                PCE.StartShape.Shape = Data(0).Piece(i).Shape
                                PCE.StartShape.Image("ImageList", Data(0).Piece(i).ShapeName)
                            End If

                            'PCE.Tag = Data(0).Piece(i).ShapeName
                            With .Captions.Item(1)
                                .Color = Data(0).Piece(i).CaptionLeft.ForeColor
                                .Text = PV.CaptionCenter
                                .HorAlign = Data(0).Piece(i).CaptionLeft.HAlign
                                .VerAlign = Data(0).Piece(i).CaptionLeft.VAlign
                                .Position = Data(0).Piece(i).CaptionLeft.Position
                            End With
                            With .Captions.Item(2)
                                .Color = Data(0).Piece(i).CaptionCenter.ForeColor
                                .Text = ConvCaptionDate(PV.CaptionLeft, PCE.Start)
                                .HorAlign = Data(0).Piece(i).CaptionCenter.HAlign
                                .VerAlign = Data(0).Piece(i).CaptionCenter.VAlign
                                .Position = Data(0).Piece(i).CaptionCenter.Position
                            End With

                        End With
                        PCE.Value = PV
                    Else
                        Dim PCE As KnTViewLib.Piece = TView.Items.Item(Data(0).Piece(i).RowIndex).Pieces.AddFromTemplate(1)
                        Dim prgrs As KnTViewLib.Progress = PCE.Progresses.Item(1)
                        prgrs.Shape = KnTViewLib.TivBarShape.tivBarShapeRectangle
                        prgrs.PercentTo = 0
                        With PCE
                            PCE.Start = Data(0).Piece(i).Start
                            PCE.Finish = Data(0).Piece(i).Finish
                            PCE.BarShape.Fill.BackColor = Data(0).Piece(i).PieceColor
                            PCE.Tunnel = Data(0).Piece(i).Tunnel
                            '''''
                            PCE.Weight = Data(0).Piece(i).LockPiece
                            Dim PT As New PeaceTagCollection
                            PT.IsWaterFall = False
                            PT.IsSummaryPiece = Data(0).Piece(i).IsSummaryPiece
                            PT.UseSummaryPreogress = Data(0).Piece(i).UseSummaryProgress
                            PT.IsSummaryExclusion = Data(0).Piece(i).IsSummaryExclusion
                            PCE.Tag = PeaceTag(PT)

                            Dim PV As New PieceValueCollection
                            PV.CaptionLeft = Data(0).Piece(i).CaptionLeft.Text
                            PV.CaptionCenter = Data(0).Piece(i).CaptionCenter.Text
                            PV.CaptionRight = Data(0).Piece(i).CaptionRight.Text
                            With .Captions.Item(1)
                                .Color = Data(0).Piece(i).CaptionLeft.ForeColor
                                '.Text = Data(0).Piece(i).CaptionLeft.Text
                                .HorAlign = Data(0).Piece(i).CaptionLeft.HAlign
                                .VerAlign = Data(0).Piece(i).CaptionLeft.VAlign
                                .Position = Data(0).Piece(i).CaptionLeft.Position
                            End With
                            With .Captions.Item(2)
                                .Color = Data(0).Piece(i).CaptionCenter.ForeColor
                                '.Text = Data(0).Piece(i).CaptionCenter.Text
                                .HorAlign = Data(0).Piece(i).CaptionCenter.HAlign
                                .VerAlign = Data(0).Piece(i).CaptionCenter.VAlign
                                .Position = Data(0).Piece(i).CaptionCenter.Position
                            End With
                            With .Captions.Item(3)
                                .Color = Data(0).Piece(i).CaptionRight.ForeColor
                                '.Text = Data(0).Piece(i).CaptionRight.Text
                                .HorAlign = Data(0).Piece(i).CaptionRight.HAlign
                                .VerAlign = Data(0).Piece(i).CaptionRight.VAlign
                                .Position = Data(0).Piece(i).CaptionRight.Position
                            End With

                            If Not IsNothing(Data(0).Piece(i).ProgressBar) Then
                                PCE.Progresses.Item(1).Shape = Data(0).Piece(i).ProgressBar.ProgressType
                                PCE.Progresses.Item(1).PercentTo = Data(0).Piece(i).ProgressBar.ProgressPercent
                                PCE.Progresses.Item(1).Fill.BackColor = Data(0).Piece(i).ProgressBar.ProgressColor
                                PCE.Progresses.Item(1).Key = ""
                                PCE.Progresses.Item(1).Key = Data(0).Piece(i).ProgressBar.ProgressDisplay
                                PCE.Progresses.Item(1).Hidden = Data(0).Piece(i).ProgressBar.IsNotUseProgress
                            End If
                            PCE.TunnelShape.Fill.BackColor = Data(0).Piece(i).PieceColor

                            Dim DS As Date = Data(0).Piece(i).Start
                            Dim DE As Date = DateAdd(DateInterval.Day, -1, Data(0).Piece(i).Finish)

                            If DS <> DE Then
                                .Captions.Item(1).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionLeft, DS), DS, DE)
                                .Captions.Item(2).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                            Else
                                .Captions.Item(1).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                                .Captions.Item(2).Text = ""
                            End If
                            If PCE.Progresses.Item(1).Key = "1" AndAlso PCE.Progresses.Item(1).Hidden = False Then
                                If PCE.Progresses.Item(1).PercentTo > 0 Then
                                    .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE) & String.Format("({0}%)", PCE.Progresses.Item(1).PercentTo * 100)
                                Else
                                    .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                                End If
                            Else
                                .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                            End If
                            PCE.Value = PV
                        End With
                    End If
                Next

                '関係線
                For i As Integer = 0 To Data(0).RelatedLine.Count - 1
                    Dim pce As KnTViewLib.Piece = TView.Items.Item(Data(0).RelatedLine(i).FromRowIndex).Pieces.Item(Data(0).RelatedLine(i).FromColIndex)
                    Dim pce2 As KnTViewLib.Piece = TView.Items.Item(Data(0).RelatedLine(i).ToRowIndex).Pieces.Item(Data(0).RelatedLine(i).ToColIndex)
                    Dim Style As Integer = Data(0).RelatedLine(i).RelatedStyle
                    Dim RL As KnTViewLib.RelatedLine = AddRelatedLine(pce, pce2, Style)
                    If Data(0).RelatedLine(i).RelatedLineStyle > 0 Then
                        RL.Line.Style = Data(0).RelatedLine(i).RelatedLineStyle
                    Else
                        RL.Line.Style = 1
                    End If
                Next

                'バルーン
                For i As Integer = 0 To Data(0).Balloon.Count - 1
                    Dim r As Integer = Data(0).Balloon(i).RowIndex
                    Dim c As Integer = Data(0).Balloon(i).ColIndex
                    Dim pce As KnTViewLib.Piece = TView.Items.Item(r).Pieces.Item(c)
                    With pce.Balloons
                        Dim BL As KnTViewLib.Balloon = .Add(, )
                        BL.PosRelPoint.X = Data(0).Balloon(i).Pont.X
                        BL.PosRelPoint.Y = Data(0).Balloon(i).Pont.Y
                        BL.AnchorPoint.X = Data(0).Balloon(i).AnchorPoint.X
                        BL.AnchorPoint.Y = Data(0).Balloon(i).AnchorPoint.Y
                        BL.AnchorRelPoint.X = Data(0).Balloon(i).AnchorRelPoint.X
                        BL.AnchorRelPoint.Y = Data(0).Balloon(i).AnchorRelPoint.Y

                        BL.BalloonShape.Fill.BackColor = Data(0).Balloon(i).BackColor
                        BL.BalloonShape.Shape = Data(0).Balloon(i).Style

                        BL.Caption.Color = Data(0).Balloon(i).Caption.ForeColor
                        BL.Caption.Text = Data(0).Balloon(i).Caption.Text
                        BL.Caption.HorAlign = Data(0).Balloon(i).Caption.HAlign
                        BL.Caption.VerAlign = Data(0).Balloon(i).Caption.VAlign

                        BL.BalloonShape.BeakBase = Data(0).Balloon(i).BalloonShape.BeakBase
                        BL.BalloonShape.Height = Data(0).Balloon(i).BalloonShape.Height
                        BL.BalloonShape.Width = Data(0).Balloon(i).BalloonShape.Width
                    End With
                Next

                'マスタピース
                If Not IsNothing(Data(0).MasterPiece) AndAlso Data(0).MasterPiece.PieceColor <> 0 Then
                    With _MasterPiece
                        _MasterPiece.Start = Data(0).MasterPiece.Start
                        _MasterPiece.Finish = Data(0).MasterPiece.Finish
                        _MasterPiece.PieceColor = Data(0).MasterPiece.PieceColor
                        _MasterPiece.Tunnel = Data(0).MasterPiece.Tunnel

                        Dim PV As New PieceValueCollection
                        PV.CaptionLeft = Data(0).MasterPiece.CaptionLeft.Text
                        PV.CaptionCenter = Data(0).MasterPiece.CaptionCenter.Text
                        PV.CaptionRight = Data(0).MasterPiece.CaptionRight.Text

                        Dim TL As New CaptionCollection
                        Dim TC As New CaptionCollection
                        Dim TR As New CaptionCollection
                        With TL
                            .ForeColor = Data(0).MasterPiece.CaptionLeft.ForeColor
                            .HAlign = Data(0).MasterPiece.CaptionLeft.HAlign
                            .VAlign = Data(0).MasterPiece.CaptionLeft.VAlign
                            .Position = Data(0).MasterPiece.CaptionLeft.Position
                        End With
                        With TC
                            .ForeColor = Data(0).MasterPiece.CaptionCenter.ForeColor
                            .HAlign = Data(0).MasterPiece.CaptionCenter.HAlign
                            .VAlign = Data(0).MasterPiece.CaptionCenter.VAlign
                            .Position = Data(0).MasterPiece.CaptionCenter.Position
                        End With
                        With TR
                            .ForeColor = Data(0).MasterPiece.CaptionRight.ForeColor
                            .HAlign = Data(0).MasterPiece.CaptionRight.HAlign
                            .VAlign = Data(0).MasterPiece.CaptionRight.VAlign
                            .Position = Data(0).MasterPiece.CaptionRight.Position
                        End With
                        .CaptionLeft = TL
                        .CaptionCenter = TC
                        .CaptionRight = TR

                        If Not IsNothing(Data(0).MasterPiece.ProgressBar) Then
                            Dim PL As New ProgressBarCollection
                            PL.ProgressType = Data(0).MasterPiece.ProgressBar.ProgressType
                            PL.ProgressPercent = Data(0).MasterPiece.ProgressBar.ProgressPercent
                            PL.ProgressColor = Data(0).MasterPiece.ProgressBar.ProgressColor
                            PL.ProgressDisplay = Data(0).MasterPiece.ProgressBar.ProgressDisplay
                            PL.IsNotUseProgress = Data(0).MasterPiece.ProgressBar.IsNotUseProgress
                            _MasterPiece.ProgressBar = PL
                        End If

                    End With
                End If
                'テンプレートピース
                If Not IsNothing(Data(0).TemplatePiece) AndAlso Data(0).TemplatePiece.PieceColor <> 0 Then
                    With _TemplatePiece
                        _TemplatePiece.Start = Data(0).TemplatePiece.Start
                        _TemplatePiece.Finish = Data(0).TemplatePiece.Finish
                        _TemplatePiece.PieceColor = Data(0).TemplatePiece.PieceColor
                        _TemplatePiece.Tunnel = Data(0).TemplatePiece.Tunnel

                        Dim PV As New PieceValueCollection
                        PV.CaptionLeft = Data(0).TemplatePiece.CaptionLeft.Text
                        PV.CaptionCenter = Data(0).TemplatePiece.CaptionCenter.Text
                        PV.CaptionRight = Data(0).TemplatePiece.CaptionRight.Text

                        Dim TL As New CaptionCollection
                        Dim TC As New CaptionCollection
                        Dim TR As New CaptionCollection
                        With TL
                            .ForeColor = Data(0).TemplatePiece.CaptionLeft.ForeColor
                            .HAlign = Data(0).TemplatePiece.CaptionLeft.HAlign
                            .VAlign = Data(0).TemplatePiece.CaptionLeft.VAlign
                            .Position = Data(0).TemplatePiece.CaptionLeft.Position
                        End With
                        With TC
                            .ForeColor = Data(0).TemplatePiece.CaptionCenter.ForeColor
                            .HAlign = Data(0).TemplatePiece.CaptionCenter.HAlign
                            .VAlign = Data(0).TemplatePiece.CaptionCenter.VAlign
                            .Position = Data(0).TemplatePiece.CaptionCenter.Position
                        End With
                        With TR
                            .ForeColor = Data(0).TemplatePiece.CaptionRight.ForeColor
                            .HAlign = Data(0).TemplatePiece.CaptionRight.HAlign
                            .VAlign = Data(0).TemplatePiece.CaptionRight.VAlign
                            .Position = Data(0).TemplatePiece.CaptionRight.Position
                        End With
                        .CaptionLeft = TL
                        .CaptionCenter = TC
                        .CaptionRight = TR

                        If Not IsNothing(Data(0).TemplatePiece.ProgressBar) Then
                            Dim PL As New ProgressBarCollection
                            PL.ProgressType = Data(0).TemplatePiece.ProgressBar.ProgressType
                            PL.ProgressPercent = Data(0).TemplatePiece.ProgressBar.ProgressPercent
                            PL.ProgressColor = Data(0).TemplatePiece.ProgressBar.ProgressColor
                            PL.ProgressDisplay = Data(0).TemplatePiece.ProgressBar.ProgressDisplay
                            PL.IsNotUseProgress = Data(0).TemplatePiece.ProgressBar.IsNotUseProgress
                            _TemplatePiece.ProgressBar = PL
                        End If

                    End With
                End If
                _TemporaryLock = _LoadLock
            End If
            Call SummaryPieceDraw() 'サマリーピースの更新
            Call CellDateRefresh()
            Call FontSizeChange() 'フォントサイズ調整
            Logs.PutInformation("データ読込完了", _WorkFileName)
            FR.Edited = False
        Catch ex As Exception
            Logs.PutErrorEx("データ読込に失敗しました", ex, True)
        End Try
    End Sub

    ''' <summary>
    ''' データのリロード
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReloadData()
        Call RadialMenuHide()
        If FR.Edited Then
            If MsgBox("データ編集中ですが、破棄してファイルをリロードしますか？", 4 + 32, "確認") = MsgBoxResult.No Then
                Return
            End If
        End If

        Call RowDeleteAll() '一旦全行を削除
        Call ColumnDeleteAll() '一旦全列を削除
        Call ColumnAdd(FrmMain.enumColumnAdd.ToLast) '空列を１列追加
        Call ReadData() 'データの読込
        FrmParent.LblMessage.Text = "シートリロード完了"
    End Sub

    Private HeaderHeight As Double  'ヘッダの高さ
    Private FooterHeight As Double  'フッタの高さ
    ''' <summary>
    ''' TODO:(PUB)印刷
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SheetPrint()
        Call RadialMenuHide()
        Try
            Dim DS As Date = Nothing
            Dim DE As Date = Nothing
            For Row As Integer = 1 To TView.Items.Count
                If TView.Items.Item(Row).Pieces.Count > 0 Then
                    For Col As Integer = 1 To TView.Items.Item(Row).Pieces.Count
                        If DS = Nothing Then
                            DS = TView.Items.Item(Row).Pieces.Item(Col).Start
                        Else
                            If DS > TView.Items.Item(Row).Pieces.Item(Col).Start Then
                                DS = TView.Items.Item(Row).Pieces.Item(Col).Start
                            End If
                        End If

                        If TView.Items.Item(Row).Pieces.Item(Col).StartShape.Shape <> KnTViewLib.TivPointShape.tivPointShapeImage Then
                            If DE = Nothing Then
                                DE = TView.Items.Item(Row).Pieces.Item(Col).Finish
                            Else
                                If DE < TView.Items.Item(Row).Pieces.Item(Col).Finish Then
                                    DE = TView.Items.Item(Row).Pieces.Item(Col).Finish
                                End If
                            End If
                        Else
                            If DE = Nothing Then
                                DE = TView.Items.Item(Row).Pieces.Item(Col).Start
                            Else
                                If DE < TView.Items.Item(Row).Pieces.Item(Col).Start Then
                                    DE = TView.Items.Item(Row).Pieces.Item(Col).Start
                                End If
                            End If
                        End If
                    Next
                End If
            Next
            If DS.ToOADate = 0 Then
                MsgBox("印字開始日付取得エラー", 48, "エラー")
                Return
            End If
            If DE.ToOADate = 0 Then
                MsgBox("印字終了日付取得エラー", 48, "エラー")
                Return
            End If


            For Row As Integer = 1 To TView.Items.Count
                For Col As Integer = 1 To TView.ColumnHeaders.Count
                    '一旦インデントアイコンを非表示にする
                    TView.Cell(Row, Col).Image("", "")

                    '一旦N/Aセルをクリアにする
                    If TView.Cell(Row, Col).Value = _NACellValue Then
                        TView.Cell(Row, Col).Value = ""
                    End If
                Next
            Next



            Dim frm As FrmPrinterDialog = New FrmPrinterDialog()
            frm.Title = _Title
            frm.TViewItemCount = TView.Items.Count
            frm.TViewColHeaderCount = TView.ColumnHeaders.Count
            If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                FrmParent.TopMost = False
                Me.TopMost = True
            End If

            frm.TargetTV = TView
            frm.DS = DS
            frm.DE = DE
            frm.ShowDialog()

            'If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    'frm.Visible = False



            '    Dim pi As New KnTViewLib.PrintInfo()

            '    pi.HeaderHeight = 1.5 'Single.Parse(HeaderHeight)   'ヘッダー高
            '    pi.FooterHeight = 1 'Single.Parse(FooterHeight)   'フッター高

            '    If frm.Orientation <> -1 Then
            '        pi.Orientation = CType(frm.Orientation, KnTViewLib.TivPrintOrientation) '用紙方向
            '    Else
            '        pi.Orientation = KnTViewLib.TivPrintOrientation.tivDefaultOrientation
            '    End If
            '    If (frm.PaperSize <> -1) Then
            '        pi.PaperSize = CType(frm.PaperSize, KnTViewLib.TivPaperSize)  '用紙サイズ
            '    Else
            '        pi.PaperSize = KnTViewLib.TivPaperSize.tivDefaultPaperSize
            '    End If
            '    'pi.Orientation = KnTViewLib.TivPrintOrientation.tivPrintLandscape
            '    'pi.PaperSize = KnTViewLib.TivPaperSize.tivPaperA3
            '    pi.ChartBorder.Style = KnTViewLib.TivLineStyle.tivLineSolid 'タイムビューの外枠の線種：実線

            '    ''印刷対象の列指定(From-To)
            '    If (frm.col) Then
            '        If frm.ColFrom <> -1 Then
            '            pi.StartColumn = frm.ColFrom
            '        End If
            '        If (frm.ColTo <> -1) Then
            '            pi.FinishColumn = frm.ColTo
            '        End If
            '    End If

            '    ''特定アイテム（行）で強制改頁
            '    Dim blnNewPage As Boolean = False
            '    If frm.Break Then
            '        If frm.BreakItem <> -1 Then
            '            TView.Items.Item(frm.BreakItem).PageBreak = True
            '            blnNewPage = True
            '        End If
            '    End If

            '    ''文字列の色を白か黒にする
            '    If frm.Mono Then pi.MonochromeText = True

            '    '倍率
            '    pi.Magnification = Convert.ToInt16(frm.Magnification)
            '    pi.JustClippingToScale = True

            '    If Not IsNothing(DS) Then
            '        '最小日付の１週間前から範囲とする
            '        pi.StartTime = DateAdd(DateInterval.Day, 0 - _PrintDay, DS)
            '    End If
            '    If Not IsNothing(DE) Then
            '        '最大日付から１週間後を範囲とする
            '        pi.FinishTime = DateAdd(DateInterval.Day, _PrintDay, DE)
            '    End If

            '    'プレビュー
            '    TView.PrintPreview(CType(pi, KnTViewLib.PrintInfo))

            '    '強制改頁のリセット
            '    If (blnNewPage) Then
            '        For Each itm As KnTViewLib.IItem In TView.Items
            '            itm.PageBreak = False
            '        Next
            '    End If
            'End If
            If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                FrmParent.TopMost = True
            End If
            FrmParent.LblMessage.Text = "印刷完了"

            'インデントアイコンの再表示
            For Row As Integer = 1 To TView.Items.Count
                For Col As Integer = 1 To TView.ColumnHeaders.Count
                    Call Cell_SetIntendIcon(TView.Cell(Row, Col))
                Next
            Next
            'N/Aセルを元に戻す
            Call CellDateRefresh()

        Catch ex As Exception
            Logs.PutErrorEx("印刷に失敗しました", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' (PUB)今日へ移動
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveToday()
        Call RadialMenuHide()
        TView.ViewTopTime = DateAdd(DateInterval.Day, 0 - _Today, Now)
        FrmParent.SyncTime(TView.ViewTopTime)
    End Sub
    ''' <summary>
    ''' (PUB)選択行の先頭または最終日に移動する
    ''' </summary>
    ''' <param name="IsFinish"></param>
    ''' <remarks></remarks>
    Public Sub MoveSelectRowItemDay(IsFinish As Boolean)
        Call RadialMenuHide()
        Try
            If SelectedRow > 0 AndAlso SelectedColumn > 0 Then
                If TView.Items.Item(SelectedRow).Pieces.Count > 0 Then
                    Dim POS As Date = Nothing
                    For i As Integer = 1 To TView.Items.Item(SelectedRow).Pieces.Count
                        Dim ll As Date = TView.Items.Item(SelectedRow).Pieces.Item(i).Start
                        If POS = Nothing Then
                            POS = ll
                        Else
                            If Not IsFinish Then
                                If POS >= ll Then POS = ll
                            Else
                                If POS <= ll Then POS = ll
                            End If
                        End If
                    Next
                    If Not POS = Nothing Then
                        TView.ViewTopTime = DateAdd(DateInterval.Day, -7, POS)
                    End If
                End If
            End If
        Catch ex As Exception
            Logs.PutErrorEx("選択行日移動エラー", ex)
        End Try

    End Sub
    ''' <summary>
    ''' タイトルの変更(PUB)
    ''' </summary>
    ''' <param name="SetIsEditMode"></param>
    ''' <remarks></remarks>
    Public Sub ChangeTitle(SetIsEditMode As Boolean)
        Call RadialMenuHide()
        If SetIsEditMode Then
            Me.Text = String.Format("{0} ( {1} )", _Title, Path.GetFileName(_WorkFileName))
        Else
            Me.Text = String.Format("{0} ( {1} )[閲覧モード]", _Title, Path.GetFileName(_WorkFileName))
        End If
        FR.Title = Me.Text
    End Sub
    ''' <summary>
    ''' (PUB)先頭ピースまで移動
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveTop()
        Call RadialMenuHide()
        Try
            Dim DT As Date = Nothing
            If TView.Items.Count > 0 Then
                For Row As Integer = 1 To TView.Items.Count
                    If TView.Items.Item(Row).Pieces.Count > 0 Then
                        For Col As Integer = 1 To TView.Items.Item(Row).Pieces.Count
                            If DT = Nothing Then
                                DT = TView.Items.Item(Row).Pieces.Item(Col).Start
                            Else
                                If DT > TView.Items.Item(Row).Pieces.Item(Col).Start Then
                                    DT = TView.Items.Item(Row).Pieces.Item(Col).Start
                                End If
                            End If
                        Next
                    End If
                Next
            End If
            If DT <> Nothing Then
                TView.ViewTopTime = DateAdd(DateInterval.Day, 0 - _StartDay, DT)
            End If
        Catch ex As Exception
            Logs.PutErrorEx("移動エラー", ex)
        End Try

    End Sub
    ''' <summary>
    ''' (PUB)最終ピースまで移動
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveLast()
        Call RadialMenuHide()
        Dim DT As Date = Nothing
        Try
            If TView.Items.Count > 0 Then
                For Row As Integer = 1 To TView.Items.Count
                    If TView.Items.Item(Row).Pieces.Count > 0 Then
                        For Col As Integer = 1 To TView.Items.Item(Row).Pieces.Count
                            'If TView.Items.Item(Row).Pieces.Item(Col).StartShape.Shape <> KnTViewLib.TivPointShape.tivPointShapeImage Then
                            If PieceIsStone(TView.Items.Item(Row).Pieces.Item(Col)) Then
                                If DT = Nothing Then
                                    DT = TView.Items.Item(Row).Pieces.Item(Col).Finish
                                Else
                                    If DT < TView.Items.Item(Row).Pieces.Item(Col).Finish Then
                                        DT = TView.Items.Item(Row).Pieces.Item(Col).Finish
                                    End If
                                End If
                            Else
                                If DT = Nothing Then
                                    DT = TView.Items.Item(Row).Pieces.Item(Col).Start
                                Else
                                    If DT < TView.Items.Item(Row).Pieces.Item(Col).Start Then
                                        DT = TView.Items.Item(Row).Pieces.Item(Col).Start
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
            End If
            If DT <> Nothing Then
                TView.ViewTopTime = DateAdd(DateInterval.Day, 0 - _FinalDay, DT)
            End If
        Catch ex As Exception
            Logs.PutErrorEx("移動エラー", ex)
        End Try

    End Sub
    ''' <summary>
    ''' (PUB)保存時の表示日付に移動
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveSavedDate()
        Call RadialMenuHide()
        If _ViewTopDate <> "" AndAlso IsDate(_ViewTopDate) Then
            '前回閉じた所の日付に移動する
            TView.ViewTopTime = CDate(_ViewTopDate)
        End If
    End Sub
    ''' <summary>
    ''' (PUB)指定日に移動
    ''' </summary>
    ''' <param name="SelDate"></param>
    ''' <remarks></remarks>
    Public Sub MoveSelDate(SelDate As Date)
        Call RadialMenuHide()
        If SelDate <> Nothing AndAlso IsDate(SelDate) Then
            '前回閉じた所の日付に移動する
            TView.ViewTopTime = DateAdd(DateInterval.Day, 0 - _Today, SelDate)
        End If
    End Sub
    Public Enum enum_DayWidth As Integer
        ''' <summary>
        ''' 幅を広げる
        ''' </summary>
        ''' <remarks></remarks>
        ToWide = 0
        ''' <summary>
        ''' 幅を縮める
        ''' </summary>
        ''' <remarks></remarks>
        ToNarrow = 1
        ''' <summary>
        ''' 標準に戻す
        ''' </summary>
        ''' <remarks></remarks>
        ToDefault = 2
    End Enum
    ''' <summary>
    ''' (PUB)チャート日付幅を変更
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Sub DayWidth(Value As enum_DayWidth)
        Call RadialMenuHide()
        With TView.TimeScale
            Select Case Value
                Case enum_DayWidth.ToWide
                    If .WidthPerScale < 40 Then
                        .WidthPerScale += 1
                    End If
                Case enum_DayWidth.ToNarrow
                    If .WidthPerScale > 5 Then
                        .WidthPerScale -= 1
                    End If
                Case Else
                    .WidthPerScale = 20
            End Select
        End With
    End Sub
    ''' <summary>
    ''' (PUB)特別期間設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SpecialTimeSetting()
        Call RadialMenuHide()
        Try
            With FrmSpecialTime
                .SpecialTimeData = _SpecialTimeData
                If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    FrmParent.TopMost = False
                    Me.TopMost = True
                End If
                .ShowDialog()
                _SpecialTimeData = .SpecialTimeData
                Dim STS As KnTViewLib.SpecialTimeSet = TView.SpecialTimeSets.Item(1)
                If STS.SpecialTimes.Count > 3 Then
                    For i As Integer = 4 To STS.SpecialTimes.Count
                        STS.SpecialTimes.Remove(4)
                    Next
                End If
                Call HolidayAdd() '休日設定
                If _SpecialTimeData.Count > 0 Then
                    For Each Item As SpecialTimeCollection In _SpecialTimeData
                        Dim spt As KnTViewLib.SpecialTime = STS.SpecialTimes.Add(, )
                        spt.ZOrder = 0
                        spt.Fill.BkMode = KnTViewLib.TivBkMode.tivOpaque
                        spt.Fill.Pattern = KnTViewLib.TivFillPattern.tivPatternNull
                        spt.Fill.BackColor = Item.CellColor

                        spt.Pattern = KnTViewLib.TivSpecialTime.tivSpecialTimeDirect
                        spt.Start = String.Format("{0:yyyy/MM/dd} 00:00:00", Item.Start)
                        spt.Finish = String.Format("{0:yyyy/MM/dd} 23:59:59", Item.Finish)
                        spt.Tunnelable = Item.IsTunnel
                    Next
                End If
                If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    FrmParent.TopMost = True
                End If
            End With
            FR.Edited = True
        Catch ex As Exception
            Logs.PutErrorEx("特別期間設定エラー", ex, True)
        End Try
    End Sub
    ''' <summary>
    ''' (PUB)特別期間（休日）の再設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RedrawSpecialTime()
        Call RadialMenuHide()
        Try

            Dim STS As KnTViewLib.SpecialTimeSet = TView.SpecialTimeSets.Item(1)
            If STS.SpecialTimes.Count > 3 Then
                For i As Integer = 4 To STS.SpecialTimes.Count
                    STS.SpecialTimes.Remove(4)
                Next
            End If
            Call HolidayAdd() '休日設定
            If _SpecialTimeData.Count > 0 Then
                For Each Item As SpecialTimeCollection In _SpecialTimeData
                    Dim spt As KnTViewLib.SpecialTime = STS.SpecialTimes.Add(, )
                    spt.ZOrder = 0
                    spt.Fill.BkMode = KnTViewLib.TivBkMode.tivOpaque
                    spt.Fill.Pattern = KnTViewLib.TivFillPattern.tivPatternNull
                    spt.Fill.BackColor = Item.CellColor
                    spt.Pattern = KnTViewLib.TivSpecialTime.tivSpecialTimeDirect
                    spt.Start = String.Format("{0:yyyy/MM/dd} 00:00:00", Item.Start)
                    spt.Finish = String.Format("{0:yyyy/MM/dd} 23:59:59", Item.Finish)
                    spt.Tunnelable = Item.IsTunnel
                Next
            End If
        Catch ex As Exception
            Logs.PutErrorEx("休日再設定エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' TODO:(PUB)シートプロパティ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EditSheetProperty()
        Call RadialMenuHide()
        Try
            With FrmSheetProperty
                .TargetForm = Me
                .SheetOwner = _Owner
                .Titile = _Title
                .PieceLayout = TView.PieceLayout
                .IsExclusion = _IsExclusion
                .ExclusionPassword = _ExclusionPassword
                .IsWaterFall = _IsWaterFall
                .IsWaterFallLock = _IsWaterFallLock
                .CellDateFormat = _CellDateFormat
                .NACellValue = _NACellValue
                .TemporaryLock = _TemporaryLock
                .LoadLock = _LoadLock
                .IndentLevel = _IndentLevel
                If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    FrmParent.TopMost = False
                    Me.TopMost = True
                End If
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    _Title = .Titile
                    _Owner = .SheetOwner
                    _IsExclusion = .IsExclusion
                    _ExclusionPassword = .ExclusionPassword
                    Me.Text = String.Format("{0} ( {1} )", _Title, Path.GetFileName(_WorkFileName))
                    If _WorkFileName = "" Then
                        FR.Title = _Title
                    Else
                        FR.Title = String.Format("{0} ( {1} )", _Title, Path.GetFileName(_WorkFileName))
                    End If
                    TView.PieceLayout = .PieceLayout
                    _IsWaterFall = .IsWaterFall
                    _IsWaterFallLock = .IsWaterFallLock
                    _CellDateFormat = .CellDateFormat
                    _NACellValue = .NACellValue
                    _TemporaryLock = .TemporaryLock
                    _LoadLock = .LoadLock
                    _IndentLevel = .IndentLevel

                    Call SheetInfomation()
                    Call CellDateRefresh()
                    FR.Edited = True

                End If
                If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    FrmParent.TopMost = True
                End If
            End With
        Catch ex As Exception
            Logs.PutErrorEx("シートプロパティ設定エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' TODO:(PUB)選択アイテムコピー
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CopyItem()
        RadialMenuStone.HideMenu()
        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
            _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
            _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
            If PieceIsStone(_CopyPiece) Then
                FrmParent.LblMessage.Text = "選択ストーンをコピーしました。"
            Else
                FrmParent.LblMessage.Text = "選択ピースをコピーしました。"
            End If
            Call SheetInfomation()
        End If
    End Sub
    ''' <summary>
    ''' TODO:(PUB)コピーアイテム貼付
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PasteItem()
        Call PastePiece(SelectedRow)
    End Sub

    ''' <summary>
    ''' (PUB)コピーしたピースの貼り付け
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PastePiece(ByVal PasteRow As Integer) As KnTViewLib.Piece
        Try
            If Not IsNothing(_CopyPiece) Then
                FR.Edited = True
                Dim PV As PieceValueCollection = _CopyPiece.Value

                'If _CopyPiece.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                If PieceIsStone(_CopyPiece) Then

                    Dim pce As KnTViewLib.Piece = TView.Items.Item(PasteRow).Pieces.AddFromTemplate(2)
                    pce.Start = String.Format("{0:yyyy/MM/dd 00:00:00}", SelectedTime)
                    pce.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage
                    pce.StartShape.Image("ImageList", PV.StoneImageKey)
                    pce.Weight = _CopyPiece.Weight

                    pce.Tag = _CopyPiece.Tag

                    With pce.Captions.Item(1)
                        .Color = _CopyPiece.Captions.Item(1).Color
                        .Text = PV.CaptionCenter
                        .HorAlign = _CopyPiece.Captions.Item(1).HorAlign
                        .VerAlign = _CopyPiece.Captions.Item(1).VerAlign
                        .Position = _CopyPiece.Captions.Item(1).Position
                    End With
                    With pce.Captions.Item(2)
                        .Color = _CopyPiece.Captions.Item(2).Color
                        .Text = ConvCaptionDate(PV.CaptionLeft, pce.Start) 'Format(pce.Start, PV.CaptionLeft)
                        .HorAlign = _CopyPiece.Captions.Item(2).HorAlign
                        .VerAlign = _CopyPiece.Captions.Item(2).VerAlign
                        .Position = _CopyPiece.Captions.Item(2).Position
                    End With

                    pce.Value = PV
                    pce.Tunnel = _CopyPiece.Tunnel
                    pce.TunnelShape.Fill.BackColor = _CopyPiece.BarShape.Fill.BackColor

                    If Not IsNothing(_CopyBalloons) Then
                        For Each BItem As KnTViewLib.Balloon In _CopyBalloons
                            Dim B As KnTViewLib.Balloon = pce.Balloons.Add(, )
                            B.PosRelPoint.X = BItem.PosRelPoint.X
                            B.PosRelPoint.Y = BItem.PosRelPoint.Y
                            B.AnchorPoint.X = BItem.AnchorPoint.X
                            B.AnchorPoint.Y = BItem.AnchorPoint.Y
                            B.AnchorRelPoint.X = BItem.AnchorRelPoint.X
                            B.AnchorRelPoint.Y = BItem.AnchorRelPoint.Y

                            B.BalloonShape.Fill.BackColor = BItem.BalloonShape.Fill.BackColor
                            B.BalloonShape.Shape = BItem.BalloonShape.Shape

                            B.Caption.Color = BItem.Caption.Color
                            B.Caption.Text = BItem.Caption.Text
                            B.Caption.HorAlign = B.Caption.HorAlign
                            B.Caption.VerAlign = BItem.Caption.VerAlign

                            B.BalloonShape.BeakBase = BItem.BalloonShape.BeakBase
                            B.BalloonShape.Height = BItem.BalloonShape.Height
                            B.BalloonShape.Width = BItem.BalloonShape.Width
                        Next
                    End If

                    ''移動元ピースへ接続されている関係線の移行
                    'If _CopyPiece.JoinRelatedLines.Count > 0 Then
                    '    For i As Integer = 1 To _CopyPiece.JoinRelatedLines.Count
                    '        Dim RL As KnTViewLib.RelatedLine = AddRelatedLine(_CopyPiece.JoinRelatedLines.Item(i).Parent, pce)
                    '    Next
                    'End If
                    ''移動ピースから引き出されている関係線の移行
                    'If _CopyPiece.RelatedLines.Count > 0 Then
                    '    For i As Integer = 1 To _CopyPiece.RelatedLines.Count
                    '        Dim RL As KnTViewLib.RelatedLine = AddRelatedLine(pce, _CopyPiece.RelatedLines.Item(i).Relation)
                    '    Next
                    'End If
                    Return pce
                Else
                    Dim pce As KnTViewLib.Piece = TView.Items.Item(PasteRow).Pieces.AddFromTemplate(1)

                    With pce
                        Dim d As Date = String.Format("{0:yyyy/MM/dd 00:00:00}", SelectedTime)
                        Dim u As Date = DateAdd(DateInterval.Hour, DateDiff(DateInterval.Hour, _CopyPiece.Start, _CopyPiece.Finish), d)
                        pce.Start = d
                        pce.Finish = u ' DateAdd(DateInterval.Hour, DateDiff(DateInterval.Hour, _CopyPec.Start, _CopyPec.Finish), SelectedTime)
                        pce.Weight = _CopyPiece.Weight
                        pce.Tag = _CopyPiece.Tag

                        Dim DS As Date = pce.Start
                        Dim DE As Date = DateAdd(DateInterval.Day, -1, pce.Finish)
                        'pce.Captions.Item(1).Text = _CopyPiece.Captions.Item(1).Text
                        With pce.Captions.Item(1)
                            .VerAlign = _CopyPiece.Captions.Item(1).VerAlign
                            .HorAlign = _CopyPiece.Captions.Item(1).HorAlign
                            .Position = _CopyPiece.Captions.Item(1).Position
                            .Color = _CopyPiece.Captions.Item(1).Color
                        End With
                        With pce.Captions.Item(2)
                            .Text = PV.CaptionCenter '_CopyPiece.Captions.Item(2).Text
                            .HorAlign = _CopyPiece.Captions.Item(2).HorAlign
                            .VerAlign = _CopyPiece.Captions.Item(2).VerAlign
                            .Position = _CopyPiece.Captions.Item(2).Position
                            .Color = _CopyPiece.Captions.Item(2).Color
                        End With
                        With pce.Captions.Item(3)
                            .VerAlign = _CopyPiece.Captions.Item(3).VerAlign
                            .HorAlign = _CopyPiece.Captions.Item(3).HorAlign
                            .Position = _CopyPiece.Captions.Item(3).Position
                            .Color = _CopyPiece.Captions.Item(3).Color
                        End With
                        pce.Tunnel = _CopyPiece.Tunnel
                        pce.BarShape.Fill.BackColor = _CopyPiece.BarShape.Fill.BackColor
                        pce.TunnelShape.Fill.BackColor = _CopyPiece.BarShape.Fill.BackColor

                        If DS <> DE Then
                            .Captions.Item(1).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionLeft, DS), DS, DE)
                            .Captions.Item(2).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                        Else
                            .Captions.Item(1).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                            .Captions.Item(2).Text = ""
                        End If
                        'Dim DE As Date = DateAdd(DateInterval.Day, -1, PCE.Finish)
                        If pce.Progresses.Item(1).Key = "1" Then
                            If pce.Progresses.Item(1).PercentTo > 0 Then
                                .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE) & String.Format("({0}%)", pce.Progresses.Item(1).PercentTo * 100)
                            Else
                                .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                            End If
                        Else
                            .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                        End If
                        pce.Value = PV

                        pce.Progresses.Item(1).Shape = _CopyPiece.Progresses.Item(1).Shape
                        pce.Progresses.Item(1).PercentTo = _CopyPiece.Progresses.Item(1).PercentTo
                        pce.Progresses.Item(1).Fill.BackColor = _CopyPiece.Progresses.Item(1).Fill.BackColor
                        pce.Progresses.Item(1).Key = ""
                        pce.Progresses.Item(1).Key = _CopyPiece.Progresses.Item(1).Key
                        pce.Progresses.Item(1).Hidden = _CopyPiece.Progresses.Item(1).Hidden

                        If Not IsNothing(_CopyBalloons) Then
                            For Each BItem As KnTViewLib.Balloon In _CopyBalloons
                                Dim B As KnTViewLib.Balloon = pce.Balloons.Add(, )
                                B.PosRelPoint.X = BItem.PosRelPoint.X
                                B.PosRelPoint.Y = BItem.PosRelPoint.Y
                                B.AnchorPoint.X = BItem.AnchorPoint.X
                                B.AnchorPoint.Y = BItem.AnchorPoint.Y
                                B.AnchorRelPoint.X = BItem.AnchorRelPoint.X
                                B.AnchorRelPoint.Y = BItem.AnchorRelPoint.Y

                                B.BalloonShape.Fill.BackColor = BItem.BalloonShape.Fill.BackColor
                                B.BalloonShape.Shape = BItem.BalloonShape.Shape

                                B.Caption.Color = BItem.Caption.Color
                                B.Caption.Text = BItem.Caption.Text
                                B.Caption.HorAlign = B.Caption.HorAlign
                                B.Caption.VerAlign = BItem.Caption.VerAlign

                                B.BalloonShape.BeakBase = BItem.BalloonShape.BeakBase
                                B.BalloonShape.Height = BItem.BalloonShape.Height
                                B.BalloonShape.Width = BItem.BalloonShape.Width
                            Next
                        End If

                        ''移動元ピースへ接続されている関係線の移行
                        'If _CopyPiece.JoinRelatedLines.Count > 0 Then
                        '    For i As Integer = 1 To _CopyPiece.JoinRelatedLines.Count
                        '        Dim RL As KnTViewLib.RelatedLine = AddRelatedLine(_CopyPiece.JoinRelatedLines.Item(i).Parent, pce, _CopyPiece.JoinRelatedLines.Item(i).Style)
                        '    Next
                        'End If
                        ''移動ピースから引き出されている関係線の移行
                        'If _CopyPiece.RelatedLines.Count > 0 Then
                        '    For i As Integer = 1 To _CopyPiece.RelatedLines.Count
                        '        Dim RL As KnTViewLib.RelatedLine = AddRelatedLine(pce, _CopyPiece.RelatedLines.Item(i).Relation)
                        '    Next
                        'End If

                        'ピース日付の再描写
                        With pce
                            PV = pce.Value
                            DS = .Start
                            DE = .Finish
                            DE = DateAdd(DateInterval.Day, -1, DE)
                            Call PieceDateDraw(pce, DS, DE) 'ピース日付の再描写
                        End With
                    End With

                    Dim prgrs As KnTViewLib.Progress
                    prgrs = pce.Progresses.Add(, )
                    Return pce
                End If
            Else
                MsgBox("貼り付けるアイテムが見つかりません", 48, "手順エラー")
                Return Nothing
            End If
        Catch ex As Exception
            Logs.PutErrorEx("ピース貼り付けに失敗しました", ex, True)
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' TODO:(PUB)アイテム変更
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ItemChange()
        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
            Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
            If PieceIsStone(PCE) Then
                Call CMS_ChagePeace_Click(Nothing, Nothing)
            Else
                Call CTMP_ChangeStone_Click(Nothing, Nothing)
            End If
            Call SheetInfomation()
        End If
    End Sub
    ''' <summary>
    ''' TODO:(PUB)アイテム検索
    ''' </summary>
    ''' <param name="TargetText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindItem(TargetText As String, Mode As Integer) As List(Of FindItemCollection)

        Dim Data As New List(Of FindItemCollection)

        For Row As Integer = 1 To TView.Items.Count
            For PIndex As Integer = 1 To TView.Items.Item(Row).Pieces.Count
                Dim PCE As KnTViewLib.Piece = TView.Items.Item(Row).Pieces.Item(PIndex)
                Dim PV As PieceValueCollection = PCE.Value

                Dim Flg As Integer = 0
                Dim T1 As String = Replace(PV.CaptionCenter, "<DATE>", "")
                Dim T2 As String = Replace(PV.CaptionLeft, "<DATE>", "")
                Dim T3 As String = Replace(PV.CaptionRight, "<DATE>", "")

                Select Case Mode
                    Case 1 '前方一致
                        Select Case True
                            Case (Not IsNothing(T1)) AndAlso T1.ToUpper.StartsWith(TargetText.ToUpper)
                                Flg = 1
                            Case (Not IsNothing(T2)) AndAlso T2.ToUpper.StartsWith(TargetText.ToUpper)
                                Flg = 2
                            Case (Not IsNothing(T3)) AndAlso T3.ToUpper.StartsWith(TargetText.ToUpper)
                                Flg = 3
                        End Select
                    Case 2 '後方一致
                        Select Case True
                            Case (Not IsNothing(T1)) AndAlso T1.ToUpper.EndsWith(TargetText.ToUpper)
                                Flg = 1
                            Case (Not IsNothing(T2)) AndAlso T2.ToUpper.EndsWith(TargetText.ToUpper)
                                Flg = 2
                            Case (Not IsNothing(T3)) AndAlso T3.ToUpper.EndsWith(TargetText.ToUpper)
                                Flg = 3
                        End Select
                    Case Else '部分一致
                        Select Case True
                            Case (Not IsNothing(T1)) AndAlso T1.ToUpper.IndexOf(TargetText.ToUpper) > -1
                                Flg = 1
                            Case (Not IsNothing(T2)) AndAlso T2.ToUpper.IndexOf(TargetText.ToUpper) > -1
                                Flg = 2
                            Case (Not IsNothing(T3)) AndAlso T3.ToUpper.IndexOf(TargetText.ToUpper) > -1
                                Flg = 3
                        End Select
                End Select

                If Flg > 0 Then
                    Dim T As New FindItemCollection
                    T.Row = Row
                    T.Col = PIndex
                    T.StartDate = PCE.Start
                    If Not IsDBNull(PCE.Finish) Then
                        T.Finish = PCE.Finish
                    End If

                    If PCE.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                        T.ItemType = FindItemCollection.EnumItemType.IsStone
                    Else
                        T.ItemType = FindItemCollection.EnumItemType.IsPeacs
                    End If
                    Select Case Flg
                        Case 1 : T.Text = T1
                        Case 2 : T.Text = T2
                        Case 3 : T.Text = T3

                    End Select
                    Data.Add(T)
                End If

                'バルーン検索
                For Bindex As Integer = 1 To PCE.Balloons.Count
                    Dim Bln As KnTViewLib.Balloon = PCE.Balloons.Item(Bindex)
                    Dim TB As String = Bln.Caption.Text
                    If (Not IsNothing(TB)) AndAlso TB.ToUpper.IndexOf(TargetText.ToUpper) > -1 Then
                        Dim T As New FindItemCollection
                        T.Row = Row
                        T.Col = PIndex
                        T.StartDate = PCE.Start
                        If Not IsDBNull(PCE.Finish) Then
                            T.Finish = PCE.Finish
                        End If
                        T.ItemType = FindItemCollection.EnumItemType.IsBollen
                        T.Text = TB
                        Data.Add(T)
                    End If
                Next
            Next
        Next
        Return Data
    End Function
    ''' <summary>
    ''' (PUB)ヘッダー検索
    ''' </summary>
    ''' <param name="TargetText"></param>
    ''' <param name="Mode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindHeader(TargetText As String, Mode As Integer) As List(Of FindHeaderCollection)

        Dim Data As New List(Of FindHeaderCollection)

        For Row As Integer = 1 To TView.Items.Count
            For Col As Integer = 1 To TView.ColumnHeaders.Count
                Dim _T As String = TView.Cell(Row, Col).Value
                If Not IsNothing(_T) Then
                    Dim IsFind As Boolean = False

                    Select Case Mode
                        Case 1 '前方一致
                            If _T.ToUpper.StartsWith(TargetText.ToUpper) Then
                                IsFind = True
                            End If
                        Case 2 '後方一致
                            If _T.ToUpper.EndsWith(TargetText.ToUpper) Then
                                IsFind = True
                            End If
                        Case Else '部分一致
                            If _T.ToUpper.IndexOf(TargetText.ToUpper) > -1 Then
                                IsFind = True
                            End If
                    End Select

                    If IsFind Then
                        Dim T As New FindHeaderCollection
                        T.Row = Row
                        T.Col = Col
                        T.Text = _T
                        Data.Add(T)
                    End If
                End If
            Next
        Next
        Return Data
    End Function
#End Region
    ''' <summary>
    ''' (PUB)ピース削除メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CTMP_DeletePeace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CTMP_DeletePeace.Click, RTMP_DeletePeace.Click
        Call RadialMenuHide()
        If IsEditMode AndAlso (Not _TemporaryLock) Then
            Try
                If TView.SelectedPieces.Count > 0 Then
                    If TView.SelectedPieces.Count = 1 Then
                        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                            If TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Weight = 0 Then
                                Dim PT As PeaceTagCollection = PeaceTag(TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Tag)
                                If PT.IsSummaryPiece Then
                                    If MsgBox("対象ピースはサマリーピースですが削除してもいいですか？", 4 + 32, "削除確認") = MsgBoxResult.No Then
                                        Return
                                    End If
                                Else
                                    Dim _Tit As PieceValueCollection = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Value

                                    If _Tit.CaptionCenter = "" Then
                                        If MsgBox("選択ピースを削除してもいいですか？", 4 + 32, "削除確認") = MsgBoxResult.No Then
                                            Return
                                        End If
                                    Else
                                        Dim ST As String = _Tit.CaptionCenter.Replace(Chr(10), "/")
                                        ST = ST.Replace("<COUNT>", "")
                                        If MsgBox(String.Format("[{0}]ピースを削除してもいいですか？", ST), 4 + 32, "削除確認") = MsgBoxResult.No Then
                                            Return
                                        End If
                                    End If
                                End If

                             

                                TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)
                                Call CellDateRefresh()
                                FR.Edited = True
                            Else
                                MsgBox("ロックピースは削除出来ません", 48, "エラー")
                            End If
                        End If
                    Else
                        If MsgBox("複数選択中のピースを削除してもいいですか？" & vbCrLf & "(ロックピースは削除されません)", 4 + 32, "確認") = MsgBoxResult.Yes Then
                            Do While TView.SelectedPieces.Count > 0
                                Dim PCE As KnTViewLib.Piece = TView.SelectedPieces(0)
                                If PCE.Weight = 0 Then
                                    TView.Items.Item(PCE.ItemIndex).Pieces.Remove(PCE.Index)
                                End If
                            Loop
                            Call CellDateRefresh()
                            FR.Edited = True
                        End If
                    End If
                End If

            Catch ex As Exception
                Logs.PutErrorEx("ピース削除に失敗しました", ex, True)
            End Try
        Else
            If _TemporaryLock Then
                FrmParent.LblMessage.Text = "ロックモードではピースを削除出来ません"
            End If
        End If

    End Sub

    ''' <summary>
    ''' 関係線追加
    ''' </summary>
    ''' <param name="pieceSrc"></param>
    ''' <param name="pieceDest"></param>
    ''' <remarks></remarks>
    Private Function AddRelatedLine(ByRef pieceSrc As KnTViewLib.Piece, ByRef pieceDest As KnTViewLib.Piece, Optional ByVal Style As Integer = -1) As KnTViewLib.RelatedLine
        Try
            ' 元のピースに関係線を追加
            Dim rellineWork As KnTViewLib.RelatedLine = pieceSrc.RelatedLines.Add

            ' 関係線の設定
            If Style = -1 Then
                If pieceSrc.ItemIndex = pieceDest.ItemIndex Then
                    rellineWork.Style = KnTViewLib.TivRelLineStyle.tivRelLineStyleDiagonal
                Else
                    rellineWork.Style = KnTViewLib.TivRelLineStyle.tivRelLineStyleBreakLater
                End If
            Else
                rellineWork.Style = Style
            End If

            rellineWork.FinishShape.Length = 12
            rellineWork.FinishShape.Shape = KnTViewLib.TivArrowShape.tivArrowShapeTriangle

            ' 先のピースと接続
            rellineWork.Connect(pieceDest)
            FR.Edited = True
            Return rellineWork
        Catch ex As Exception
            Logs.PutErrorEx("関係線追加に失敗しました", ex, True)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' バルーン追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_AddBalloon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMP_AddBalloon.Click, RMP_AddBalloon.Click
        Call RadialMenuHide()
        BalloonnAdd()
    End Sub
    ''' <summary>
    ''' ピース・ストーン貼り付け
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMNO_Paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMNO_Paste.Click, RMNO_Paste.Click
        Call RadialMenuHide()
        Call PastePiece(SelectedRow)
    End Sub

    ''' <summary>
    ''' ピースコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMP_Copy.Click, RMP_Copy.Click
        'Call RadialMenuHide()
        'If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
        '    _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
        '    _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
        '    FrmParent.LblMessage.Text = "選択ピースをコピーしました。"
        'End If

        Call CopyItem() '選択アイテムのコピー

    End Sub

    ''' <summary>
    ''' ピースメニュー展開
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContextMenuPeace_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuPeace.Opening
        If TView.SelectedPieces.Count >= 2 Then
            CMP_AddRelatedLine.Enabled = True
            RMP_AddRelatedLine.Enabled = True : RMP_AddRelatedLine.BorderColor = Color.RoyalBlue
        Else
            CMP_AddRelatedLine.Enabled = False
            RMP_AddRelatedLine.Enabled = False : RMP_AddRelatedLine.BorderColor = SystemColors.ControlDark
        End If

        If Not IsNothing(_CopyPiece) Then
            If _CopyPiece.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                CTMP_CopyFormat.Enabled = False
                RTMP_CopyFormat_Copy.Enabled = False : RTMP_CopyFormat_Copy.BorderColor = SystemColors.ControlDark
            Else
                CTMP_CopyFormat.Enabled = True
                RTMP_CopyFormat_Copy.Enabled = True : RTMP_CopyFormat_Copy.BorderColor = Color.RoyalBlue
            End If
        Else
            RTMP_CopyFormat_Copy.Enabled = False : RTMP_CopyFormat_Copy.BorderColor = SystemColors.ControlDark
            CTMP_CopyFormat.Enabled = True
        End If
        If Not IsNothing(_MasterPiece) AndAlso _MasterPiece.PieceColor <> 0 Then
            If _MasterPiece.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                RTMP_CopyFormat_Master.Enabled = False : RTMP_CopyFormat_Master.BorderColor = SystemColors.ControlDark
            Else
                RTMP_CopyFormat_Master.Enabled = True : RTMP_CopyFormat_Master.BorderColor = Color.RoyalBlue
            End If
        Else
            RTMP_CopyFormat_Master.Enabled = False : RTMP_CopyFormat_Master.BorderColor = SystemColors.ControlDark
        End If
        If Not IsNothing(_TemplatePiece) AndAlso _TemplatePiece.PieceColor <> 0 Then
            If _TemplatePiece.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                RTMP_CopyFormat_Template.Enabled = False : RTMP_CopyFormat_Template.BorderColor = SystemColors.ControlDark
            Else
                RTMP_CopyFormat_Template.Enabled = True : RTMP_CopyFormat_Template.BorderColor = Color.RoyalBlue
            End If
        Else
            RTMP_CopyFormat_Template.Enabled = False : RTMP_CopyFormat_Template.BorderColor = SystemColors.ControlDark
        End If

    End Sub
    ''' <summary>
    ''' 関係線追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_AddRelatedLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMP_AddRelatedLine.Click, RMP_AddRelatedLine.Click
        Call RadialMenuHide()
        Call AddRelatedLine()
    End Sub
    ''' <summary>
    ''' 関係線追加
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddRelatedLine()
        Call RadialMenuHide()
        If TView.SelectedPieces.Count = 2 Then
            Dim P1 As KnTViewLib.Piece = TView.SelectedPieces.Item(1)
            Dim P2 As KnTViewLib.Piece = TView.SelectedPieces.Item(2)

            Select Case True
                Case SeekPastRelatedPeace(P1, P2) '既に関係線が作成作成済みではないか？
                    MsgBox("すでに関係線が作成済みです。", 48, "関係線作成エラー")
                Case SeekRelatedPeace(P1, P2) 'ループ状態もならないか？
                    MsgBox("関係線がループ状態になります。", 48, "関係線作成エラー")
                Case Else
                    Call AddRelatedLine(P1, P2)
            End Select
        Else
            MsgBox("関係線を追加するには２つのピースが選択されている必要があります。", 48, "関係線追加エラー")
        End If
    End Sub
    ''' <summary>
    ''' TODO:ピースプロパティ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_Property_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMP_Property.Click, RMP_Property.Click

        Call RadialMenuHide()
        Try
            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                Dim MemEndDay As Date
                With FrmPieceProperty
                    .TagetFrom = Me
                    Dim DS As Date = PCE.Start
                    Dim DE As Date = DateAdd(DateInterval.Day, -1, PCE.Finish)
                    'If DS = DE Then
                    '    .PieceText = Replace(PCE.Captions.Item(1).Text, Chr(10), vbCrLf)
                    'Else
                    '    .PieceText = Replace(PCE.Captions.Item(2).Text, Chr(10), vbCrLf)
                    'End If

                    .StartDay = DS
                    .EndDay = DE
                    MemEndDay = PCE.Finish ' DE

                    .PieceBackColor = ConvertColorValue(PCE.BarShape.Fill.BackColor)
                    .LockPiece = PCE.Weight

                    Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
                    .IsSummaryPiece = PT.IsSummaryPiece
                    .UseSummaryProgress = PT.UseSummaryPreogress
                    .IsUseSummaryPiece = CheckSummaryRow(SelectedRow) 'サマリーピースに設定してもよいか？
                    .IsSummaryExclusion = PT.IsSummaryExclusion

                    Dim PV As PieceValueCollection = PCE.Value
                    .CaptionCenterText = Replace(PV.CaptionCenter, Chr(10), vbCrLf)
                    .CaprionCenterForeColor = ConvertColorValue(PCE.Captions.Item(2).Color)

                    .CaptionCenterAlignment = GetAlignmentValue(PCE.Captions.Item(2).HorAlign, PCE.Captions.Item(2).VerAlign)
                    .CaptionCenterPosition = PCE.Captions.Item(2).Position

                    .CaptionLeftText = Replace(PV.CaptionLeft, Chr(10), vbCrLf)
                    .CaptionLeftAlignment = GetAlignmentValue(PCE.Captions.Item(1).HorAlign, PCE.Captions.Item(1).VerAlign)
                    .CaptionLeftPosition = PCE.Captions.Item(1).Position
                    .CaptionLeftForeColor = ConvertColorValue(PCE.Captions.Item(1).Color)

                    .CaptionRightText = Replace(PV.CaptionRight, Chr(10), vbCrLf)
                    .CaptionRightAlignment = GetAlignmentValue(PCE.Captions.Item(3).HorAlign, PCE.Captions.Item(3).VerAlign)

                    .CaptionRightPosition = PCE.Captions.Item(3).Position
                    .CaptionRightForeColor = ConvertColorValue(PCE.Captions.Item(3).Color)

                    .IsTunnel = PCE.Tunnel
                    .ProgressType = ConvertProgressType(PCE.Progresses.Item(1).Shape)
                    .ProgressPercent = PCE.Progresses.Item(1).PercentTo
                    .ProgressColor = ConvertColorValue(PCE.Progresses.Item(1).Fill.BackColor)
                    .ProgressDisplay = PCE.Progresses.Item(1).Key
                    .IsNotUseProgress = PCE.Progresses.Item(1).Hidden


                    If Not IsNothing(_MasterPiece) AndAlso _MasterPiece.PieceColor <> 0 Then
                        .MoreMaster = True
                    End If

                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = False
                        .TopMost = True
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        FR.Edited = True

                        PCE.Start = .StartDay
                        PCE.Finish = DateAdd(DateInterval.Day, 1, .EndDay)
                        PCE.Weight = .LockPiece

                        Dim PVN As New PieceValueCollection
                        PVN.CaptionLeft = Replace(.CaptionLeftText, Chr(13), "")
                        PVN.CaptionCenter = Replace(.CaptionCenterText, Chr(13), "")
                        PVN.CaptionRight = Replace(.CaptionRightText, Chr(13), "")

                        PCE.BarShape.Fill.BackColor = ConvertColorValue(.PieceBackColor)

                        PCE.Captions.Item(1).HorAlign = AlignmentValue(.CaptionLeftAlignment).X
                        PCE.Captions.Item(1).VerAlign = AlignmentValue(.CaptionLeftAlignment).Y
                        PCE.Captions.Item(1).Position = .CaptionLeftPosition
                        PCE.Captions.Item(1).Color = ConvertColorValue(.CaptionLeftForeColor)

                        PCE.Captions.Item(2).Color = ConvertColorValue(.CaprionCenterForeColor)
                        PCE.Captions.Item(2).HorAlign = AlignmentValue(.CaptionCenterAlignment).X
                        PCE.Captions.Item(2).VerAlign = AlignmentValue(.CaptionCenterAlignment).Y
                        PCE.Captions.Item(2).Position = .CaptionCenterPosition

                        PCE.Captions.Item(3).HorAlign = AlignmentValue(.CaptionRightAlignment).X
                        PCE.Captions.Item(3).VerAlign = AlignmentValue(.CaptionRightAlignment).Y
                        PCE.Captions.Item(3).Position = .CaptionRightPosition
                        PCE.Captions.Item(3).Color = ConvertColorValue(.CaptionRightForeColor)

                        PCE.Progresses.Item(1).Shape = ConvertProgressType(.ProgressType)
                        PCE.Progresses.Item(1).PercentTo = .ProgressPercent
                        PCE.Progresses.Item(1).Fill.BackColor = ConvertColorValue(.ProgressColor)
                        PCE.Progresses.Item(1).Key = ""
                        PCE.Progresses.Item(1).Key = .ProgressDisplay
                        PCE.Progresses.Item(1).Hidden = .IsNotUseProgress

                        PCE.Value = PVN
                        PCE.Tunnel = .IsTunnel
                        PCE.TunnelShape.Fill.BackColor = ConvertColorValue(.PieceBackColor)

                        Dim PT2 As New PeaceTagCollection
                        PT2.IsWaterFall = False
                        If CheckSummaryRow(SelectedRow) Then
                            PT2.IsSummaryPiece = .IsSummaryPiece
                            PT2.UseSummaryPreogress = .UseSummaryProgress
                            PT2.IsSummaryExclusion = False
                        Else
                            'サマリーピースに設定されても子レベル設定がされていなければOFFにする
                            PT2.IsSummaryPiece = False
                            PT2.UseSummaryPreogress = False
                            PT2.IsSummaryExclusion = .IsSummaryExclusion
                        End If
                        PCE.Tag = PeaceTag(PT2)

                        If .IsMasterPiece Then
                            'マスタピースに書式を転記
                            _MasterPiece.PieceColor = PCE.BarShape.Fill.BackColor
                            With PCE.Captions.Item(1)
                                Dim _T As New CaptionCollection
                                _T.ForeColor = .Color
                                _T.HAlign = .HorAlign
                                _T.VAlign = .VerAlign
                                _T.Position = .Position
                                _MasterPiece.CaptionLeft = _T
                            End With
                            With PCE.Captions.Item(2)
                                Dim _T As New CaptionCollection
                                _T.ForeColor = .Color
                                _T.HAlign = .HorAlign
                                _T.VAlign = .VerAlign
                                _T.Position = .Position
                                _MasterPiece.CaptionCenter = _T
                            End With
                            With PCE.Captions.Item(3)
                                Dim _T As New CaptionCollection
                                _T.ForeColor = .Color
                                _T.HAlign = .HorAlign
                                _T.VAlign = .VerAlign
                                _T.Position = .Position
                                _MasterPiece.CaptionRight = _T
                            End With

                            _MasterPiece.Tunnel = PCE.Tunnel
                            With PCE.Progresses.Item(1)
                                Dim _T As New ProgressBarCollection
                                _T.ProgressType = .Shape
                                _T.ProgressColor = .Fill.BackColor
                                _T.ProgressDisplay = .Key
                                _T.IsNotUseProgress = .Hidden
                                _MasterPiece.ProgressBar = _T
                            End With
                        Else
                            If .IsMasterPieceClear Then
                                'マスタワークをクリアする
                                '_MasterPiece = Nothing
                                _MasterPiece = New PieceCollection
                            End If
                        End If

                        If _IsWaterFall Then
                            Dim ff As Integer = DateDiff(DateInterval.Minute, MemEndDay, PCE.Finish)
                            Call RelatedPeace(PCE, ff) '関係線が引いてある子ピースを移動させる
                        End If

                        'ピース日付の再描写
                        With PCE
                            PV = PCE.Value
                            DS = .Start
                            DE = .Finish
                            DE = DateAdd(DateInterval.Day, -1, DE)
                            Call PieceDateDraw(PCE, DS, DE) 'ピース日付の再描写
                        End With

                        Call CellDateRefresh()
                        TView.Refresh(1)
                    End If
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = True
                    End If
                End With
            End If

        Catch ex As Exception
            Logs.PutErrorEx("ピースプロパティエラー", ex, True)
        End Try

    End Sub

#Region "関係線用メニュー"

    ''' <summary>
    ''' 関係線削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMRL_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMRL_Delete.Click, RMRL_Delete.Click
        Call RadialMenuHide()
        If IsEditMode AndAlso (Not _TemporaryLock) Then
            Try
                If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                    If MsgBox("選択関係線を削除してもいいですか？", 4 + 32, "削除確認") = MsgBoxResult.Yes Then
                        With TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).RelatedLines
                            .Item(SelectedRelatedLineIndex).Disconnect()
                            .Remove(SelectedRelatedLineIndex)
                        End With
                        FR.Edited = True
                    End If
                End If

            Catch ex As Exception
                Logs.PutErrorEx("関係線削除エラー", ex)
            End Try
        Else
            If _TemporaryLock Then
                FrmParent.LblMessage.Text = "ロックモード中では関係線は削除出来ません"
            End If
        End If

    End Sub
    ''' <summary>
    ''' 関係線向き反転
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMRL_Change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMRL_Change.Click, RMRL_Change.Click
        Call RadialMenuHide()

        Try
            If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedRelatedLineIndex > 0 Then
                Dim FromPCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                'Dim ToPCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).RelatedLines.Item(1).Relation
                Dim ToPCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).RelatedLines.Item(SelectedRelatedLineIndex).Relation
                With TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).RelatedLines
                    .Item(SelectedRelatedLineIndex).Disconnect()
                    .Remove(SelectedRelatedLineIndex)
                End With
                Call AddRelatedLine(ToPCE, FromPCE)
            End If

        Catch ex As Exception
            Logs.PutErrorEx("関係線向き変更エラー", ex)
        End Try

    End Sub
    ''' <summary>
    ''' 関係線位置変更（メニュー）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMRL_Position_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMRL_Position0.Click, CMRL_Position1.Click, CMRL_Position2.Click, CMRL_Position3.Click, CMRL_Position4.Click, CMRL_Position5.Click
        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
            Dim Obj As ToolStripMenuItem = sender
            Dim pce As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
            Dim rellineWork As KnTViewLib.RelatedLine = pce.RelatedLines.Item(SelectedRelatedLineIndex)
            rellineWork.Style = Obj.Tag
            FR.Edited = True
        End If
    End Sub
    ''' <summary>
    ''' 関係線位置変更（ラジアルメニュー）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMRL_Position_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RMRL_Position0.Click, RMRL_Position1.Click, RMRL_Position2.Click, RMRL_Position3.Click, RMRL_Position4.Click, RMRL_Position5.Click
        Call RadialMenuHide()
        Try
            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                Dim Obj As C1.Win.C1Command.RadialMenuItem = sender
                Dim pce As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                Dim rellineWork As KnTViewLib.RelatedLine = pce.RelatedLines.Item(SelectedRelatedLineIndex)
                rellineWork.Style = Obj.UserData
                FR.Edited = True
            End If
        Catch ex As Exception
            Logs.PutErrorEx("関係線位置変更エラー", ex)
        End Try

    End Sub
    ''' <summary>
    '''　関係線種類変更（メニュー）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMRL_LineType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMRL_LineType1.Click, CMRL_LineType2.Click, CMRL_LineType3.Click, CMRL_LineType4.Click, CMRL_LineType5.Click
        Try
            If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedRelatedLineIndex > 0 Then
                Dim Obj As ToolStripMenuItem = sender
                Dim pce As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                Dim rellineWork As KnTViewLib.RelatedLine = pce.RelatedLines.Item(SelectedRelatedLineIndex)
                rellineWork.Line.Style = Obj.Tag
                FR.Edited = True
            End If

        Catch ex As Exception
            Logs.PutErrorEx("関係線変更エラー", ex)

        End Try
    End Sub
    ''' <summary>
    ''' 関係線種類変更（ラジアルメニュー）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMRL_LineType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RMRL_LineType1.Click, RMRL_LineType2.Click, RMRL_LineType3.Click, RMRL_LineType4.Click, RMRL_LineType5.Click
        Call RadialMenuHide()
        Try
            If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedRelatedLineIndex > 0 Then
                Dim Obj As C1.Win.C1Command.RadialMenuItem = sender
                Dim pce As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                Dim rellineWork As KnTViewLib.RelatedLine = pce.RelatedLines.Item(SelectedRelatedLineIndex)
                rellineWork.Line.Style = Obj.UserData
                FR.Edited = True

            End If
        Catch ex As Exception
            Logs.PutErrorEx("関係線変更エラー", ex)
        End Try

    End Sub
#End Region

#Region "バルーン用メニュー"

    ''' <summary>
    ''' バルーン形状１
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMSB_Style0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMSB_Style0.Click, RMSB_Style0.Click
        Call RadialMenuHide()
        If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedBalloonIndex > 0 Then
            TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons.Item(SelectedBalloonIndex).BalloonShape.Shape = KnTViewLib.TivBalloonShape.tivBalloonShapeNull
            FR.Edited = True
        End If
    End Sub
    ''' <summary>
    ''' バルーン形状２
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMSB_Style1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMSB_Style1.Click, RMSB_Style1.Click
        Call RadialMenuHide()
        If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedBalloonIndex > 0 Then
            TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons.Item(SelectedBalloonIndex).BalloonShape.Shape = KnTViewLib.TivBalloonShape.tivBalloonShapeRect
            FR.Edited = True
        End If
    End Sub
    ''' <summary>
    ''' バルーン形状３
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMSB_Style2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMSB_Style2.Click, RMSB_Style2.Click
        Call RadialMenuHide()
        If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedBalloonIndex > 0 Then
            TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons.Item(SelectedBalloonIndex).BalloonShape.Shape = KnTViewLib.TivBalloonShape.tivBalloonShapeRoundRect
            FR.Edited = True
        End If
    End Sub
    ''' <summary>
    ''' 全面切り替え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMSN_F11_Click(sender As Object, e As EventArgs) Handles RMSN_F11.Click
        Call FunctionAction(122)
    End Sub
    ''' <summary>
    ''' バルーン削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMSB_DeleteBalloon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMSB_DeleteBalloon.Click, RMSB_DeleteBalloon.Click
        Call RadialMenuHide()
        If IsEditMode AndAlso (Not _TemporaryLock) Then
            Try
                If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedBalloonIndex > 0 Then
                    If MsgBox("選択バル－ンを削除してもいいですか？", 4 + 32, "削除確認") = MsgBoxResult.Yes Then
                        With TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
                            .Remove(SelectedBalloonIndex)
                        End With
                        FR.Edited = True
                    End If
                End If
            Catch ex As Exception
                Logs.PutErrorEx("バルーン削除エラー", ex)
            End Try
        Else
            If _TemporaryLock Then
                FrmParent.LblMessage.Text = "ロックモードではバルーンは削除出来ません"
            End If

        End If
    End Sub
#End Region

    ''' <summary>
    ''' ストーンへ変換
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CTMP_ChangeStone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CTMP_ChangeStone.Click, RTMP_ChangeStone.Click
        Call RadialMenuHide()
        Try
            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                Dim p As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                Dim PT As PeaceTagCollection = PeaceTag(p.Tag)
                If PT.IsSummaryPiece Then
                    MsgBox("サマリーピースをストーンピースに変換する事は出来ません", 48, "エラー")
                    Return
                End If

                Dim pieceWork As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.AddFromTemplate(2)
                Dim PV As PieceValueCollection = p.Value
                Dim PVN As New PieceValueCollection

                PVN.CaptionCenter = PV.CaptionCenter
                PVN.CaptionLeft = PV.CaptionLeft
                PVN.CaptionRight = PV.CaptionRight
                PVN.StoneImageKey = "0"

                pieceWork.Start = p.Start
                If p.Weight = 0 Then
                    pieceWork.Weight = 0
                Else
                    pieceWork.Weight = 2
                End If

                pieceWork.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage
                pieceWork.StartShape.Image("ImageList", "0")
                pieceWork.Captions.Item(1).Text = PVN.CaptionCenter
                'pieceWork.Captions.Item(2).Text = Format(p.Start, PV.CaptionLeft)
                pieceWork.Captions.Item(2).Text = ConvCaptionDate(PV.CaptionLeft, p.Start)

                pieceWork.Value = PVN

                If p.Balloons.Count > 0 Then
                    For i As Integer = 1 To p.Balloons.Count
                        Dim BL As KnTViewLib.Balloon = pieceWork.Balloons.Add(, )
                        With BL
                            .AnchorPoint.X = p.Balloons.Item(i).AnchorPoint.X
                            .AnchorPoint.Y = p.Balloons.Item(i).AnchorPoint.Y
                            .AnchorRelPoint.X = p.Balloons.Item(i).AnchorRelPoint.X
                            .AnchorRelPoint.Y = p.Balloons.Item(i).AnchorRelPoint.Y
                            .BalloonShape.Fill.BackColor = p.Balloons.Item(i).BalloonShape.Fill.BackColor
                            .Caption.Color = p.Balloons.Item(i).Caption.Color
                            .Caption.Text = p.Balloons.Item(i).Caption.Text
                            .Caption.VerAlign = p.Balloons.Item(i).Caption.VerAlign
                            .Caption.HorAlign = p.Balloons.Item(i).Caption.HorAlign
                        End With
                    Next
                End If

                TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)
                FR.Edited = True
                Call CellDateRefresh()
            End If
        Catch ex As Exception
            Logs.PutErrorEx("ストーンへ変換に失敗しました", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' TODO:ストーン削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMS_DeleteStone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_DeleteStone.Click, RMS_DeleteStone.Click
        Call RadialMenuHide()
        If IsEditMode AndAlso (Not _TemporaryLock) Then
            Try
                If TView.SelectedPieces.Count > 0 Then
                    If TView.SelectedPieces.Count = 1 Then
                        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                            Dim p As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                            If p.Weight = 0 Then
                                If MsgBox("選択ストーンを削除してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                                    TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)
                                    Call CellDateRefresh()

                                    FR.Edited = True
                                End If
                            Else
                                MsgBox("ロックストーンは削除出来ません", 48, "エラー")
                            End If
                        End If
                    Else
                        If MsgBox("複数選択中のストーンを削除してもいいですか？" & vbCrLf & "(ロックストーンは削除されません)", 4 + 32, "確認") = MsgBoxResult.Yes Then
                            Do While TView.SelectedPieces.Count > 0
                                Dim PCE As KnTViewLib.Piece = TView.SelectedPieces(0)
                                If PCE.Weight = 0 Then
                                    TView.Items.Item(PCE.ItemIndex).Pieces.Remove(PCE.Index)
                                End If
                            Loop
                            Call CellDateRefresh()
                            FR.Edited = True
                        End If
                    End If
                End If
            Catch ex As Exception
                Logs.PutErrorEx("ストーン削除に失敗しました", ex, True)
            End Try
        Else
            If _TemporaryLock Then
                FrmParent.LblMessage.Text = "ロックモードではストーンは削除出来ません"
            End If
        End If
    End Sub
    ''' <summary>
    ''' ピースへ変換
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMS_ChagePeace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_ChagePeace.Click, RMS_ChagePeace.Click
        Call RadialMenuHide()
        Try
            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                Dim p As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                Dim pce As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.AddFromTemplate(1)
                Dim PV As PieceValueCollection = p.Value
                With pce
                    Dim Start As Date = p.Start
                    Dim Fin As Date = DateAdd(DateInterval.Day, 10, Start)

                    pce.Start = Start
                    pce.Finish = Fin
                    pce.Weight = p.Weight

                    Dim DS As Date = Start
                    Dim DE As Date = DateAdd(DateInterval.Day, -1, Fin)

                    .Captions.Item(2).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)

                    .Captions.Item(1).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionLeft, DS), DS, DE)
                    .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                    .Value = PV

                    If p.Balloons.Count > 0 Then
                        For i As Integer = 1 To p.Balloons.Count
                            Dim BL As KnTViewLib.Balloon = pce.Balloons.Add(, )
                            With BL
                                .AnchorPoint.X = p.Balloons.Item(i).AnchorPoint.X
                                .AnchorPoint.Y = p.Balloons.Item(i).AnchorPoint.Y
                                .AnchorRelPoint.X = p.Balloons.Item(i).AnchorRelPoint.X
                                .AnchorRelPoint.Y = p.Balloons.Item(i).AnchorRelPoint.Y
                                .BalloonShape.Fill.BackColor = p.Balloons.Item(i).BalloonShape.Fill.BackColor
                                .Caption.Color = p.Balloons.Item(i).Caption.Color
                                .Caption.Text = p.Balloons.Item(i).Caption.Text
                                .Caption.VerAlign = p.Balloons.Item(i).Caption.VerAlign
                                .Caption.HorAlign = p.Balloons.Item(i).Caption.HorAlign
                            End With
                        Next
                    End If
                End With
                TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)
                FR.Edited = True
            End If
        Catch ex As Exception
            Logs.PutErrorEx("ピースへ変換に失敗しました", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' 関係線追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMS_AddRelatedLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_AddRelatedLine.Click, RMS_AddRelatedLine.Click
        Call RadialMenuHide()
        Call AddRelatedLine()
    End Sub
    ''' <summary>
    ''' バルーン追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMS_AddBalloon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_AddBalloon.Click, RMS_AddBalloon.Click
        Call RadialMenuHide()
        Call BalloonnAdd()
    End Sub
    ''' <summary>
    ''' TODO:ストーンのプロパティ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMS_Property_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_Property.Click, RMS_Property.Click
        Call RadialMenuHide()

        Dim MemEndDay As Date
        Try
            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then

                Dim STN As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                Dim DS As Date = STN.Start
                'Dim DE As Date = DateAdd(DateInterval.Day, -1, STN.Finish)

                MemEndDay = STN.Start
                With FrmStoneProperty
                    Dim PV As PieceValueCollection = STN.Value

                    .StartDay = DS
                    '.EndDay = DE
                    .LockPiece = STN.Weight

                    .ImageNo = PV.StoneImageKey
                    .CaptionLeftText = PV.CaptionCenter
                    .CaptionLeftAlignment = GetAlignmentValue(STN.Captions.Item(1).HorAlign, STN.Captions.Item(1).VerAlign)

                    .CaptionLeftPosition = STN.Captions.Item(1).Position

                    .CaptionRightText = PV.CaptionLeft
                    .CaptionRightAlignment = GetAlignmentValue(STN.Captions.Item(2).HorAlign, STN.Captions.Item(2).VerAlign)
                    .CaptionRightPosition = STN.Captions.Item(2).Position

                    Dim PT As PeaceTagCollection = PeaceTag(STN.Tag)
                    .IsSummaryExclusion = PT.IsSummaryExclusion

                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = False
                        Me.TopMost = True
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Dim PVN As New PieceValueCollection

                        PVN.CaptionLeft = .CaptionRightText
                        PVN.CaptionCenter = .CaptionLeftText
                        PVN.CaptionRight = PV.CaptionRight
                        PVN.StoneImageKey = .ImageNo

                        STN.Start = .StartDay

                        STN.StartShape.Image("ImageList", .ImageNo)
                        STN.Captions.Item(1).Text = PVN.CaptionCenter
                        STN.Captions.Item(1).VerAlign = AlignmentValue(.CaptionLeftAlignment).Y
                        STN.Captions.Item(1).HorAlign = AlignmentValue(.CaptionLeftAlignment).X

                        STN.Captions.Item(1).Position = .CaptionLeftPosition

                        Dim DE As Date = DateAdd(DateInterval.Day, 0, STN.Start)
                        STN.Captions.Item(2).Text = ConvCaptionDate(PVN.CaptionLeft, DE)
                        STN.Captions.Item(2).VerAlign = AlignmentValue(.CaptionRightAlignment).Y
                        STN.Captions.Item(2).HorAlign = AlignmentValue(.CaptionRightAlignment).X

                        STN.Captions.Item(2).Position = .CaptionRightPosition
                        STN.Value = PVN
                        STN.Weight = .LockPiece
                        PT.IsSummaryExclusion = .IsSummaryExclusion
                        STN.Tag = PeaceTag(PT)

                        If _IsWaterFall Then
                            Dim ff As Integer = DateDiff(DateInterval.Minute, MemEndDay, STN.Start)
                            Call RelatedPeace(STN, ff) '関係線が引いてある子ピースを移動させる
                        End If
                        FR.Edited = True

                        If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                            FrmParent.TopMost = True
                        End If

                        Call CellDateRefresh()
                        TView.Refresh(1)
                    End If
                End With
            End If
        Catch ex As Exception
            Logs.PutErrorEx("ストーンプロパティエラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' ストーンコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMS_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_Copy.Click, RMS_Copy.Click
        'RadialMenuStone.HideMenu()
        'If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
        '    _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
        '    _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
        '    FrmParent.LblMessage.Text = "選択ストーンをコピーしました。"
        'End If

        Call CopyItem() '選択アイテムのコピー
    End Sub
    ''' <summary>
    ''' メニュー展開
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContextMenuPiecePane_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuPiecePane.Opening
        If IsNothing(_CopyPiece) Then
            CMNO_Paste.Text = "貼り付け"
            CMNO_Paste.Enabled = False
            RMNO_Paste.Text = "貼り付け" : RMNO_Paste.ToolTip = "貼り付け"
            RMNO_Paste.Enabled = False : RMNO_Paste.BorderColor = SystemColors.ControlDark
        Else
            CMNO_Paste.Enabled = True
            RMNO_Paste.Enabled = True
            Dim _Moji As String = ""
            If _CopyPiece.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                _Moji = "ストーン"
            Else
                _Moji = "ピース"
            End If
            CMNO_Paste.Text = String.Format("{0}貼付", _Moji)
            RMNO_Paste.Text = String.Format("{0}貼付", _Moji) : RMNO_Paste.ToolTip = String.Format("{0}貼付", _Moji) : RMNO_Paste.BorderColor = Color.RoyalBlue
        End If
    End Sub
    ''' <summary>
    ''' ストーンメニュー展開
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContextMenuStone_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStone.Opening
        If TView.SelectedPieces.Count >= 2 Then
            CMS_AddRelatedLine.Enabled = True
            RMS_AddRelatedLine.Enabled = True : RMS_AddRelatedLine.BorderColor = Color.RoyalBlue
        Else
            CMS_AddRelatedLine.Enabled = False
            RMS_AddRelatedLine.Enabled = False : RMS_AddRelatedLine.BorderColor = SystemColors.ControlDark
        End If

        If Not IsNothing(_CopyPiece) Then
            If _CopyPiece.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                CMS_CopyFormat.Enabled = True
                RMS_CopyFormat.Enabled = True : RMS_AddRelatedLine.BorderColor = Color.RoyalBlue
            Else
                CMS_CopyFormat.Enabled = False
                RMS_CopyFormat.Enabled = False : RMS_AddRelatedLine.BorderColor = SystemColors.ControlDark
            End If
        Else
            CMS_CopyFormat.Enabled = False
            RMS_CopyFormat.Enabled = False : RMS_AddRelatedLine.BorderColor = Color.RoyalBlue
        End If
    End Sub
    ''' <summary>
    ''' セル編集後
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub TView_AfterCellEdit(sender As Object, e As AxKnTViewLib._DKnTViewEvents_AfterCellEditEvent) Handles TView.AfterCellEdit
        'セル編集前に閲覧モードでの編集禁止処理を入れているが、読み出し最初の際にはなぜかBeforeCellEditイベントが発生しないので、
        'AfterCellEditでも編集を禁止にしている
        If Not IsEditMode Then
            e.cancel.Value = True
            Return
        End If
    End Sub
    ''' <summary>
    ''' TODO:セル編集
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_BeforeCellEdit(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_BeforeCellEditEvent) Handles TView.BeforeCellEdit
        Call CMC_CellProperty_Click(Nothing, Nothing)
        'Try
        '    If SelectedRow <> 0 AndAlso SelectedColumn <> 0 Then
        '        e.cancel.Value = True
        '        If Not IsEditMode Then
        '            Return
        '        End If
        '        With FrmCellProperty
        '            Dim _T1 As CellTagCollection = CellTagConvert(TView.Cell(SelectedRow, SelectedColumn).Tag)
        '            .CellTextAlign = GetAlignmentValue(TView.Cell(SelectedRow, SelectedColumn).HorAlign, TView.Cell(SelectedRow, SelectedColumn).VerAlign)

        '            '.CellText = Replace(TView.Cell(SelectedRow, SelectedColumn).Value, Chr(10), "<CR>")
        '            .CellText = Replace(_T1.Caption, Chr(10), "<CR>")
        '            .CellBackColor = TView.Cell(SelectedRow, SelectedColumn).Fill.BackColor
        '            .CellForeColor = TView.Cell(SelectedRow, SelectedColumn).Color
        '            .IndentLevel = TView.Cell(SelectedRow, SelectedColumn).IndentLevel
        '            If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
        '                FrmParent.TopMost = False
        '                Me.TopMost = True
        '            End If
        '            If .ShowDialog = Windows.Forms.DialogResult.OK Then
        '                Dim FlgBottom As Boolean = False
        '                If .IsBottomCopy Then
        '                    Select Case MsgBox("以下の行も同じ書式に設定してもいいですか？", MsgBoxStyle.YesNoCancel, "確認")
        '                        Case MsgBoxResult.Cancel
        '                            Return
        '                        Case MsgBoxResult.No
        '                        Case MsgBoxResult.Yes
        '                            FlgBottom = True
        '                    End Select
        '                End If
        '                If FlgBottom Then
        '                    Dim _T2 As New CellTagCollection
        '                    _T2.Caption = Replace(.CellText, Chr(13), "")
        '                    _T2.IsHidden = _T1.IsHidden
        '                    For Row As Integer = SelectedRow To TView.Items.Count
        '                        TView.Cell(Row, SelectedColumn).Value = Replace(.CellText, Chr(13), "")
        '                        Dim _P As Point = AlignmentValue(.CellTextAlign)
        '                        TView.Cell(Row, SelectedColumn).HorAlign = _P.X
        '                        TView.Cell(Row, SelectedColumn).VerAlign = _P.Y

        '                        TView.Cell(Row, SelectedColumn).IndentLevel = .IndentLevel

        '                        TView.Cell(Row, SelectedColumn).Fill.BackColor = .CellBackColor
        '                        TView.Cell(Row, SelectedColumn).Color = .CellForeColor
        '                        TView.Cell(Row, SelectedColumn).Tag = CellTagConvert(_T2)
        '                    Next
        '                Else
        '                    Dim _T2 As New CellTagCollection
        '                    _T2.Caption = Replace(.CellText, Chr(13), "")
        '                    _T2.IsHidden = _T1.IsHidden
        '                    Dim _P As Point = AlignmentValue(.CellTextAlign)
        '                    TView.Cell(SelectedRow, SelectedColumn).Value = Replace(.CellText, Chr(13), "")
        '                    TView.Cell(SelectedRow, SelectedColumn).HorAlign = _P.X
        '                    TView.Cell(SelectedRow, SelectedColumn).VerAlign = _P.Y
        '                    TView.Cell(SelectedRow, SelectedColumn).IndentLevel = .IndentLevel
        '                    TView.Cell(SelectedRow, SelectedColumn).Fill.BackColor = .CellBackColor
        '                    TView.Cell(SelectedRow, SelectedColumn).Color = .CellForeColor
        '                    TView.Cell(SelectedRow, SelectedColumn).Tag = CellTagConvert(_T2)
        '                End If
        '                Call Cell_SetIntendIcon(TView.Cell(SelectedRow, SelectedColumn)) 'インデントイメージの表示・非表示
        '                Call CellDateRefresh()
        '                FR.Edited = True
        '            End If
        '            If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
        '                FrmParent.TopMost = False
        '            End If
        '        End With

        '    End If
        'Catch ex As Exception
        '    Logs.PutErrorEx("セル編集に失敗しました", ex, True)
        'End Try

    End Sub
    ''' <summary>
    ''' 選択列一括プロパティ設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMCH_PropertyCol_Click(sender As Object, e As EventArgs) Handles RMCH_PropertyCol.Click
        Call RadialMenuHide()
        Try
            If TView.Items.Count > 0 AndAlso SelectedColumn > 0 Then
                With FrmColumnProperty
                    .ColNo = SelectedColumn
                    .CellTextAlign = GetAlignmentValue(TView.Cell(1, SelectedColumn).HorAlign, TView.Cell(1, SelectedColumn).VerAlign)
                    .CellBackColor = TView.Cell(1, SelectedColumn).Fill.BackColor
                    .CellForeColor = TView.Cell(1, SelectedColumn).Color
                    .Hidden = TView.ColumnHeaders.Item(SelectedColumn).Hidden
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = False
                        Me.TopMost = True
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        If MsgBox(String.Format("{0}列目の書式を全て変更してもいいですか？", SelectedColumn), 4 + 32, "確認") = MsgBoxResult.Yes Then
                            For Row As Integer = 1 To TView.Items.Count
                                Dim _P As Point = AlignmentValue(.CellTextAlign)
                                TView.Cell(Row, SelectedColumn).HorAlign = _P.X
                                TView.Cell(Row, SelectedColumn).VerAlign = _P.Y

                                TView.Cell(Row, SelectedColumn).Fill.BackColor = .CellBackColor
                                TView.Cell(Row, SelectedColumn).Color = .CellForeColor
                                TView.ColumnHeaders.Item(SelectedColumn).Hidden = .Hidden
                            Next
                        End If
                        FR.Edited = True
                    End If
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = True
                    End If
                End With
            End If
        Catch ex As Exception
            Logs.PutErrorEx("列一括設定に失敗しました", ex, True)
        End Try
    End Sub
    ''' <summary>
    ''' 全ての列を非表示に設定します
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ColumnHidden_AllColumn(sender As Object, e As EventArgs) Handles RMCH_HiddenCol_AllCol.Click, RMNO_Hidden_Hidden.Click
        Call RadialMenuHide()
        Try
            If TView.ColumnHeaders.Count > 0 Then
                If MsgBox("全ての列を非表示にしますか？", 4 + 32, "列非表示確認") = MsgBoxResult.Yes Then
                    For Col As Integer = 1 To TView.ColumnHeaders.Count
                        TView.ColumnHeaders.Item(Col).Hidden = True
                    Next
                    Call CellDateRefresh()
                    FR.Edited = True
                    FrmParent.ToolButton_DisHiddenCol.Enabled = True
                End If
                FrmParent.LblMessage.Text = "列を非表示にしました"
            End If

        Catch ex As Exception
            Logs.PutErrorEx("列非表示エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' 選択列を非表示に設定します
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ColumnHidden_SelColumn(sender As Object, e As EventArgs) Handles RMCH_HiddenCol_SelCol.Click, RMC_ColHidden.Click
        Call RadialMenuHide()
        Call HiddenSelColumun()
    End Sub
    ''' <summary>
    ''' 選択行を非表示にする
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub HiddenSelColumun()
        Call RadialMenuHide()
        Try
            If SelectedColumn > 0 Then
                Dim _MotoColor As New List(Of UInteger)
                Dim _MemColumn As Integer = SelectedColumn

                For Row As Integer = 1 To TView.Items.Count
                    '設定済みの背景色を待避してハイライト表示する
                    _MotoColor.Add(TView.Cell(Row, SelectedColumn).Fill.BackColor)
                    TView.Cell(Row, SelectedColumn).Fill.BackColor = ConvertColorValue(Color.Yellow)
                Next

                If MsgBox(String.Format("{0}列目を非表示してもいいですか？", SelectedColumn), 4 + 32, "列非表示確認") = MsgBoxResult.Yes Then
                    TView.ColumnHeaders.Item(SelectedColumn).Hidden = True
                    SelectedColumn -= 1
                    Call CellDateRefresh()
                    FR.Edited = True
                    FrmParent.ToolButton_DisHiddenCol.Enabled = True
                End If

                For Row As Integer = 1 To TView.Items.Count
                    TView.Cell(Row, _MemColumn).Fill.BackColor = _MotoColor(Row - 1)
                Next
                FrmParent.LblMessage.Text = "列を非表示にしました"
            End If
        Catch ex As Exception
            Logs.PutErrorEx("列非表示エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' 全ての列を再表示します
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ColumnDisHidden_AllColumn(sender As Object, e As EventArgs) Handles RMCH_HiddenCol_AllView.Click, RMNO_Hidden_View.Click
        Call RadialMenuHide()
        Call DisHiddenAllColumun()
    End Sub
    ''' <summary>
    ''' 全列を再表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisHiddenAllColumun()
        Call RadialMenuHide()
        If TView.ColumnHeaders.Count > 0 AndAlso TView.Items.Count > 0 Then
            '行と列がある場合は一覧表で設定
            With FrmHiddenSetting
                If SelectedColumn > 0 Then
                    '選択列がある場合はそれを既定とする
                    .CurrentRow = SelectedColumn
                End If
                .IsColMode = True
                .TargetTView = TView
                If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    FrmParent.TopMost = False
                    Me.TopMost = True
                End If
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                End If

                If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    FrmParent.TopMost = True
                End If
            End With
        Else
            '行と列のどちらかが無い場合は一括
            Try
                If TView.ColumnHeaders.Count > 0 Then
                    If MsgBox("全ての列を再表示にしますか？", 4 + 32, "列再表示確認") = MsgBoxResult.Yes Then
                        For Col As Integer = 1 To TView.ColumnHeaders.Count
                            TView.ColumnHeaders.Item(Col).Hidden = False
                        Next
                        Call CellDateRefresh()
                        FR.Edited = True
                        FrmParent.ToolButton_DisHiddenCol.Enabled = False
                    End If
                    FrmParent.LblMessage.Text = "列を再表示しました"
                End If

            Catch ex As Exception
                Logs.PutErrorEx("列再表示エラー", ex, True)
            End Try
        End If


    End Sub
    ''' <summary>
    ''' ヘッダープロパティ設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMCH_PropertyHeader_Click(sender As Object, e As EventArgs) Handles RMCH_PropertyHeader.Click
        Call RadialMenuHide()
        Try
            With FrmColumnHeaderProperty
                .HeaderColNo = SelectedColumn
                .HeaderText = Replace(TView.ColumnHeaders.Item(SelectedColumn).Text, Chr(10), vbCrLf)
                .HeaderTextAlign = GetAlignmentValue(TView.ColumnHeaders.Item(SelectedColumn).HorAlign, TView.ColumnHeaders.Item(SelectedColumn).VerAlign)
                If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    FrmParent.TopMost = False
                    Me.TopMost = True
                End If

                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    TView.ColumnHeaders.Item(SelectedColumn).Text = Replace(.HeaderText, Chr(13), "")
                    Dim _P As Point = AlignmentValue(.HeaderTextAlign)
                    TView.ColumnHeaders.Item(SelectedColumn).HorAlign = _P.X
                    TView.ColumnHeaders.Item(SelectedColumn).VerAlign = _P.Y
                    FR.Edited = True
                End If
                If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    FrmParent.TopMost = True
                End If
            End With
        Catch ex As Exception
            Logs.PutErrorEx("ヘッダプロパティエラー", ex, True)
        End Try

    End Sub
    '''' <summary>
    '''' バルーン文字編集開始
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    Private Sub TView_BeforeBalloonEdit(ByVal sender As Object, ByVal e As AxKnTViewLib._DKnTViewEvents_BeforeBalloonEditEvent) Handles TView.BeforeBalloonEdit
        e.cancel.Value = True
        If Not IsEditMode Then
            Return
        End If

        Try
            If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedBalloonIndex > 0 Then
                Dim Bln As KnTViewLib.Balloon = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons.Item(SelectedBalloonIndex)
                With FrmBalloonnProperty
                    .BalloonText = Replace(Bln.Caption.Text, Chr(10), vbCrLf)
                    .BalloonTextAlign = GetAlignmentValue(Bln.Caption.HorAlign, Bln.Caption.VerAlign)

                    .BalloonBackColor = Bln.BalloonShape.Fill.BackColor
                    .BalloonForeColor = Bln.Caption.Color
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = False
                        Me.TopMost = True
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Bln.Caption.Text = Replace(.BalloonText, Chr(13), "")
                        Dim _P As Point = AlignmentValue(.BalloonTextAlign)
                        Bln.Caption.HorAlign = _P.X
                        Bln.Caption.VerAlign = _P.Y
                        Bln.BalloonShape.Fill.BackColor = .BalloonBackColor
                        Bln.Caption.Color = .BalloonForeColor
                        FR.Edited = True
                    End If
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = True
                    End If
                End With

            End If
        Catch ex As Exception
            Logs.PutErrorEx("バルーン編集エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' バルーンプロパティ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMSB_Property_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMSB_Property.Click, RMSB_Property.Click
        Call RadialMenuHide()
        Try
            If SelectedRow > 0 AndAlso SelectedPeace > 0 AndAlso SelectedBalloonIndex > 0 Then
                Dim Bln As KnTViewLib.Balloon = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons.Item(SelectedBalloonIndex)
                With FrmBalloonnProperty
                    .BalloonText = Replace(Bln.Caption.Text, Chr(10), vbCrLf)
                    .BalloonTextAlign = GetAlignmentValue(Bln.Caption.HorAlign, Bln.Caption.VerAlign)

                    .BalloonBackColor = Bln.BalloonShape.Fill.BackColor
                    .BalloonForeColor = Bln.Caption.Color
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = False
                        Me.TopMost = True
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Bln.Caption.Text = Replace(.BalloonText, Chr(13), "")
                        Dim _P As Point = AlignmentValue(.BalloonTextAlign)

                        Bln.Caption.HorAlign = _P.X
                        Bln.Caption.VerAlign = _P.Y
                        Bln.BalloonShape.Fill.BackColor = .BalloonBackColor
                        Bln.Caption.Color = .BalloonForeColor
                        FR.Edited = True
                    End If
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = True
                    End If
                End With
            End If
        Catch ex As Exception
            Logs.PutErrorEx("バルーンプロパティエラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' ヘッダータイトル展開
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContextMenuCellHeader_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuCellHeader.Opening

        Select Case TView.ColumnHeaders.Item(SelectedColumn).MergeMode
            Case KnTViewLib.TivMergeMode.tivMergeNone
                '結合設定されていないとき
                CMCH_Merge.Text = "セル制約結合"
                RMCH_Merge.Text = "セル制約結合"
            Case KnTViewLib.TivMergeMode.tivMergeRestrict
                '制約結合設定されているとき
                CMCH_Merge.Text = "セル自由結合"
                RMCH_Merge.Text = "セル自由結合"
            Case Else
                '自由結合設定されているとき
                CMCH_Merge.Text = "セル結合解除"
                RMCH_Merge.Text = "セル結合解除"
        End Select

    End Sub
    ''' <summary>
    ''' セル結合
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMCH_Merge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMCH_Merge.Click, RMCH_Merge.Click
        Call RadialMenuHide()
        With TView.ColumnHeaders.Item(SelectedColumn)
            Select Case .MergeMode
                Case KnTViewLib.TivMergeMode.tivMergeNone
                    .MergeMode = KnTViewLib.TivMergeMode.tivMergeRestrict
                Case KnTViewLib.TivMergeMode.tivMergeRestrict
                    .MergeMode = KnTViewLib.TivMergeMode.tivMergeFree
                Case Else
                    .MergeMode = KnTViewLib.TivMergeMode.tivMergeNone
            End Select
        End With

        FR.Edited = True
    End Sub
    ''' <summary>
    ''' 列の追加（前）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMCH_AddColToFore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMCH_AddColToLeft.Click, RMCH_AddColToLeft.Click
        Call RadialMenuHide()
        Dim y As KnTViewLib.ColumnHeader = TView.ColumnHeaders.Add(SelectedColumn, )
        y.MergeMode = KnTViewLib.TivMergeMode.tivMergeFree
        FR.Edited = True
    End Sub
    ''' <summary>
    ''' 列の追加（後ろ）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMCH_AddColToBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMCH_AddColToRight.Click, RMCH_AddColToRight.Click
        Call RadialMenuHide()
        Dim y As KnTViewLib.ColumnHeader = TView.ColumnHeaders.Add(SelectedColumn + 1, )
        y.MergeMode = KnTViewLib.TivMergeMode.tivMergeFree
        FR.Edited = True
    End Sub
    ''' <summary>
    ''' 列移動（左）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMCD_MoveToLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMCD_MoveToLeft.Click, RMCD_MoveToLeft.Click
        Call RadialMenuHide()
        Call MoveCol(enum_MoveCol.ToLeft)
    End Sub
    ''' <summary>
    ''' 列移動（右）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMCD_MoveToRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMCD_MoveToRight.Click, RMCD_MoveToRight.Click
        Call RadialMenuHide()
        Call MoveCol(enum_MoveCol.ToRight)
    End Sub
    ''' <summary>
    ''' 列削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMCH_DelCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMCH_DelCol.Click, RMCH_DelCol.Click
        Call RadialMenuHide()
        Call ColumnDelete()
    End Sub
#Region "セル用メニュー"

    ''' <summary>
    ''' セル行追加（上）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_RowAddToUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_RowAddToUp.Click, RMC_RowAddToUp.Click
        Call RadialMenuHide()
        Call RowAdd(enumAddRow.ToUp)
    End Sub
    ''' <summary>
    ''' セル行追加（下）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_RowAddToDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_RowAddToDown.Click, RMC_RowAddToDown.Click
        Call RadialMenuHide()
        Call RowAdd(enumAddRow.ToDown)
    End Sub
    ''' <summary>
    ''' セル行追加（最下段）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_RowAddToBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_RowAddToBottom.Click, RMC_RowAddToBottom.Click
        Call RadialMenuHide()
        Call RowAdd(enumAddRow.ToBottom)
    End Sub
    ''' <summary>
    ''' セル行移動（上）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_RowMoveToUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_RowMoveToUp.Click, RMC_RowMoveToUp.Click
        Call RadialMenuHide()
        Call MoveRow(enum_MoveRow.ToUp)
    End Sub
    ''' <summary>
    ''' セル行移動（下）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_RowMoveToDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_RowMoveToDown.Click, RMC_RowMoveToDown.Click
        Call RadialMenuHide()
        Call MoveRow(enum_MoveRow.ToDown)
    End Sub
    ''' <summary>
    ''' セル行削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_RowDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_RowDel.Click, RMC_RowDel.Click
        Call RadialMenuHide()
        Call RowDelete()
    End Sub
    ''' <summary>
    ''' TODO:選択行の非表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMC_RowHidden_One_Click(sender As Object, e As EventArgs) Handles RMC_RowHidden_One.Click
        Call RadialMenuHide()
        Call HiddenSelRow()
    End Sub

    ''' <summary>
    ''' TODO:(PUB)選択行下の子レベルを非表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMC_RowHidden_Tree_Click(sender As Object, e As EventArgs) Handles RMC_RowHidden_Tree.Click
        Call RowHidden_Tree()
    End Sub
    Public Sub RowHidden_Tree()
        Call RadialMenuHide()
        Try
            If SelectedRow > 0 Then
                Dim _Flg As Boolean = False
                Dim _SW As Integer = 0
                Dim ParentLevel As Integer = TView.Cell(SelectedRow, SelectedColumn).IndentLevel
                For Row As Integer = SelectedRow + 1 To TView.Items.Count
                    Dim Level As Integer = TView.Cell(Row, SelectedColumn).IndentLevel
                    If Level > ParentLevel Then
                        If _SW = 0 Then
                            If TView.Items.Item(Row).Hidden Then
                                _SW = 1 '表示
                            Else
                                _SW = -1 '非表示
                            End If
                        End If

                        If _SW = 1 Then
                            TView.Items.Item(Row).Hidden = False
                        Else
                            TView.Items.Item(Row).Hidden = True
                        End If

                        _Flg = True
                    Else
                        Exit For
                    End If
                Next

                If _Flg Then
                    If _SW = 1 Then
                        FrmParent.LblMessage.Text = "子レベル行を表示に設定しました"
                    Else
                        FrmParent.LblMessage.Text = "子レベル行を非表示に設定しました"
                    End If

                    FR.Edited = True
                End If
            End If
        Catch ex As Exception
            Logs.PutErrorEx("子レベル行非表示エラー", ex, True)
        End Try
    End Sub
    ''' <summary>
    ''' TODO:(PUB)選択行の非表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub HiddenSelRow()
        Call RadialMenuHide()
        Try
            If SelectedRow > 0 Then
                Dim _Deleted As Boolean = False
                Dim _MemRow As Integer = SelectedRow
                Dim _MotoColor As Color = ConvertColorValue(TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor)
                '現行設定背景色を待避する
                TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor = ConvertColorValue(Color.Yellow)
                If MsgBox(String.Format("{0}行目を非表示に設定してもいいですか？", SelectedRow), 4 + 32, "行非表示確認") = MsgBoxResult.Yes Then
                    TView.Items.Item(SelectedRow).Hidden = True
                    SelectedRow -= 1
                    Call CellDateRefresh()
                    FR.Edited = True
                    FrmParent.ToolButton_DisHiddenRow.Enabled = True
                End If

                If _MotoColor = Nothing Then
                    TView.Items.Item(_MemRow).PiecePane.Fill.BackColor = ConvertColorValue(Color.White)
                Else
                    TView.Items.Item(_MemRow).PiecePane.Fill.BackColor = ConvertColorValue(_MotoColor)
                End If

                FrmParent.LblMessage.Text = "選択行を非表示に設定しました"

            End If
        Catch ex As Exception
            Logs.PutErrorEx("行非表示エラー", ex, True)
        End Try
    End Sub

    ''' <summary>
    ''' 全行再表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMNO_HiddenRow_Click(sender As Object, e As EventArgs) Handles RMNO_HiddenRow.Click
        Call RadialMenuHide()
        Call DisHiddenAllRow()
    End Sub
    ''' <summary>
    ''' TODO:(PUB)全行再表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisHiddenAllRow()
        Call RadialMenuHide()
        If TView.ColumnHeaders.Count > 0 AndAlso TView.Items.Count > 0 Then
            '行と列がある場合は一覧表で設定
            With FrmHiddenSetting
                If SelectedRow > 0 Then
                    '選択行がある場合はそれを既定とする
                    .CurrentRow = SelectedRow
                End If
                .IsColMode = False
                .TargetTView = TView
                If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    FrmParent.TopMost = False
                    Me.TopMost = True
                End If
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    FR.Edited = True
                End If

                If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    FrmParent.TopMost = True
                End If
            End With
        Else
            '行と列のどちらかが無い場合は一括
            Try
                If TView.Items.Count > 0 Then
                    If MsgBox("全ての行を再表示しますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                        For Row As Integer = 1 To TView.Items.Count
                            TView.Items.Item(Row).Hidden = False
                        Next

                        Call CellDateRefresh()
                        FR.Edited = True
                        FrmParent.ToolButton_DisHiddenRow.Enabled = False

                        FrmParent.LblMessage.Text = "全行を再表示しました"
                        FR.Edited = True
                    End If

                End If
            Catch ex As Exception
                Logs.PutErrorEx("行再表示エラー", ex, True)
            End Try

        End If

    End Sub
    ''' <summary>
    ''' 選択行ピースクリア
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMC_RowPeceClear_Click(sender As Object, e As EventArgs) Handles RMC_RowPeceClear.Click
        Call RadialMenuHide()
        If TView.Items.Count > 0 AndAlso SelectedRow > 0 Then
            Try
                If TView.Items.Item(SelectedRow).Pieces.Count > 0 Then

                    Dim _MotoColor As Color = ConvertColorValue(TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor)
                    '現行設定背景色を待避する
                    TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor = ConvertColorValue(Color.Yellow)

                    If MsgBox("選択行のピースを全て削除してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                        For Col As Integer = TView.Items.Item(SelectedRow).Pieces.Count To 1 Step -1
                            TView.Items.Item(SelectedRow).Pieces.Remove(Col)
                        Next
                        Call CellDateRefresh()
                        FR.Edited = True
                    End If

                    '現行設定背景色を待避する
                    TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor = ConvertColorValue(_MotoColor)
                End If
            Catch ex As Exception
                Logs.PutErrorEx("ピースクリアエラー", ex)
            End Try
        End If
    End Sub
    ''' <summary>
    ''' セル列追加（左）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_ColAddToLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_ColAddToLeft.Click, RMC_ColAddToLeft.Click
        Call RadialMenuHide()
        Call ColumnAdd(enumColumnAdd.ToLeft)
    End Sub
    ''' <summary>
    ''' セル列追加（右）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_ColAddToRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_ColAddToRight.Click, RMC_ColAddToRight.Click
        Call RadialMenuHide()
        Call ColumnAdd(enumColumnAdd.ToRight)
    End Sub
    ''' <summary>
    ''' セル列追加（最右）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_ColAddToEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_ColAddToEnd.Click, RMC_ColAddToEnd.Click
        Call RadialMenuHide()
        Call ColumnAdd(enumColumnAdd.ToLast)
    End Sub
    ''' <summary>
    ''' セル列移動（左）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_ColMoveToLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_ColMoveToLeft.Click, RMC_ColMoveToLeft.Click
        Call RadialMenuHide()
        Call MoveCol(enum_MoveCol.ToLeft)
    End Sub
    ''' <summary>
    ''' セル列移動（右）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_ColMoveToRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_ColMoveToRight.Click, RMC_ColMoveToRight.Click
        Call RadialMenuHide()
        Call MoveCol(enum_MoveCol.ToRight)
    End Sub
    ''' <summary>
    ''' セル列削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_ColDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_ColDel.Click, RMC_ColDel.Click
        Call RadialMenuHide()
        Call ColumnDelete()
    End Sub
    ''' <summary>
    ''' 下セルのコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_CopyFromDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_CopyFromDown.Click, RMC_CopyFromDown.Click
        Call RadialMenuHide()
        If SelectedRow > 0 AndAlso SelectedColumn > 0 Then
            Call CellCopy(TView, SelectedRow + 1, SelectedColumn, SelectedRow, SelectedColumn)
            Call CellDateRefresh()
            FR.Edited = True
        End If
    End Sub
    ''' <summary>
    ''' 上セルのコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_CopyFromUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_CopyFromUp.Click, RMC_CopyFromUp.Click
        Call RadialMenuHide()
        If SelectedRow > 0 AndAlso SelectedColumn > 0 Then
            Call CellCopy(TView, SelectedRow - 1, SelectedColumn, SelectedRow, SelectedColumn)
            Call CellDateRefresh()
            FR.Edited = True
        End If
    End Sub
    ''' <summary>
    ''' TODO:セルプロパティ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_CellProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_CellProperty.Click, RMC_CellProperty.Click
        Call RadialMenuHide()
        With FrmCellProperty
            Try
                If SelectedRow > 0 AndAlso SelectedColumn > 0 Then

                    Dim _T1 As CellTagCollection = CellTagConvert(TView.Cell(SelectedRow, SelectedColumn).Tag)
                    .CellTextAlign = GetAlignmentValue(TView.Cell(SelectedRow, SelectedColumn).HorAlign, TView.Cell(SelectedRow, SelectedColumn).VerAlign)

                    '.CellText = Replace(TView.Cell(SelectedRow, SelectedColumn).Value, Chr(10), "<CR>")
                    .CellText = Replace(_T1.Caption, Chr(10), "<CR>")
                    .CellBackColor = TView.Cell(SelectedRow, SelectedColumn).Fill.BackColor
                    .CellForeColor = TView.Cell(SelectedRow, SelectedColumn).Color
                    .IndentLevel = TView.Cell(SelectedRow, SelectedColumn).IndentLevel
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = False
                        Me.TopMost = True
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Dim _EndRow As Integer = 0
                        If .IsBottomCopy Then
                            Select Case MsgBox("以下の行も同じ書式に設定してもいいですか？", MsgBoxStyle.YesNoCancel + 32, "確認")
                                Case MsgBoxResult.Cancel
                                    Return
                                Case MsgBoxResult.No
                                    _EndRow = SelectedRow
                                Case MsgBoxResult.Yes
                                    _EndRow = TView.Items.Count
                            End Select
                        Else
                            _EndRow = SelectedRow
                        End If

                        Dim _T2 As New CellTagCollection
                        _T2.Caption = Replace(.CellText, Chr(13), "")
                        _T2.IsHidden = _T1.IsHidden
                        For Row As Integer = SelectedRow To _EndRow
                            TView.Cell(Row, SelectedColumn).Value = Replace(.CellText, Chr(13), "")
                            Dim _P As Point = AlignmentValue(.CellTextAlign)
                            TView.Cell(Row, SelectedColumn).HorAlign = _P.X
                            TView.Cell(Row, SelectedColumn).VerAlign = _P.Y

                            TView.Cell(Row, SelectedColumn).IndentLevel = .IndentLevel

                            TView.Cell(Row, SelectedColumn).Fill.BackColor = .CellBackColor
                            TView.Cell(Row, SelectedColumn).Color = .CellForeColor
                            TView.Cell(Row, SelectedColumn).Tag = CellTagConvert(_T2)

                            Call Cell_SetIntendIcon(TView.Cell(Row, SelectedColumn)) 'インデントイメージの表示・非表示
                        Next

                        FR.Edited = True
                        Call CellDateRefresh()
                    End If
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = True
                    End If

                End If
            Catch ex As Exception
                Logs.PutErrorEx("セルプロパティエラー", ex)
            End Try

        End With
    End Sub
    ''' <summary>
    ''' 行の背景色設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMC_RowColor_Click(sender As Object, e As EventArgs) Handles RMC_RowColor.Click, RMNO_RowColor.Click

        Call RadialMenuHide()

        With FrmSelectColor
            Try
                If SelectedRow > 0 Then
                    .SelectColor = ConvertColorValue(TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor)
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = False
                        Me.TopMost = True
                    End If
                    If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        TView.Items.Item(SelectedRow).PiecePane.Fill.BackColor = ConvertColorValue(.SelectColor)
                        FR.Edited = True
                    End If
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = True
                    End If
                End If
            Catch ex As Exception
                Logs.PutErrorEx("行背景色設定エラー", ex)
            End Try
        End With
    End Sub
    ''' <summary>
    ''' アイテム検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMNO_Seek_Click(sender As Object, e As EventArgs) Handles RMNO_Seek.Click
        Call RadialMenuHide()
        With FrmItemFind
            .TargetForm = Me
            If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                FrmParent.TopMost = False
                Me.TopMost = True
            End If
            .ShowDialog()
            If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                FrmParent.TopMost = True
            End If
        End With
    End Sub
#End Region

    ''' <summary>
    ''' 全体プロパティ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMNO_Property_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMNO_Property.Click, RMNO_Property.Click
        Call RadialMenuHide()
        Call EditSheetProperty()
    End Sub
    ''' <summary>
    ''' ピースを上へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_MoveToUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMP_MoveToUp.Click, RMP_MoveToUp.Click
        Call RadialMenuHide()
        If SelectedRow > 1 Then
            Try
                If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                    Dim PT As PeaceTagCollection = PeaceTag(TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Tag)
                    If PT.IsSummaryPiece Then
                        MsgBox("サマリーピースは移動出来ません", 64, "情報")
                        Return
                    End If

                    _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                    _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
                    Dim PV As PieceValueCollection = _CopyPiece.Value
                    Dim PCE As KnTViewLib.Piece = PastePiece(SelectedRow - 1)
                    PCE.Start = _CopyPiece.Start
                    PCE.Finish = _CopyPiece.Finish

                    Dim DS As Date = PCE.Start
                    Dim DE As Date = DateAdd(DateInterval.Day, -1, PCE.Finish)

                    If DS <> DE Then
                        PCE.Captions.Item(1).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionLeft, DS), DS, DE)
                        PCE.Captions.Item(2).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                    Else
                        PCE.Captions.Item(1).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                        PCE.Captions.Item(2).Text = ""
                    End If

                    If PCE.Progresses.Item(1).Key = "1" AndAlso Not PCE.Progresses.Item(1).Hidden Then
                        If PCE.Progresses.Item(1).PercentTo > 0 Then
                            PCE.Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE) & String.Format("({0}%)", PCE.Progresses.Item(1).PercentTo * 100)
                        Else
                            PCE.Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                        End If
                    Else
                        PCE.Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                    End If
                    TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)

                    'ピース日付の再描写
                    With PCE
                        PV = PCE.Value
                        'DS = .Start
                        'DE = .Finish
                        DE = DateAdd(DateInterval.Day, -1, DE)
                        Call PieceDateDraw(PCE, DS, DE) 'ピース日付の再描写
                    End With
                End If
            Catch ex As Exception
                Logs.PutErrorEx("ピース移動に失敗しました", ex, True)
            End Try

        End If
    End Sub
    ''' <summary>
    ''' ピースを下に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_MoveToDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMP_MoveToDown.Click, RMP_MoveToDown.Click
        Call RadialMenuHide()
        If SelectedRow < TView.Items.Count Then
            Try
                If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                    Dim PT As PeaceTagCollection = PeaceTag(TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Tag)
                    If PT.IsSummaryPiece Then
                        MsgBox("サマリーピースは移動出来ません", 64, "情報")
                        Return
                    End If


                    _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                    _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
                    Dim PV As PieceValueCollection = _CopyPiece.Value
                    Dim PCE As KnTViewLib.Piece = PastePiece(SelectedRow + 1)
                    PCE.Start = _CopyPiece.Start
                    PCE.Finish = _CopyPiece.Finish

                    Dim DS As Date = PCE.Start
                    Dim DE As Date = DateAdd(DateInterval.Day, -1, PCE.Finish)
                    If DS <> DE Then
                        PCE.Captions.Item(1).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionLeft, DS), DS, DE)
                        PCE.Captions.Item(2).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                    Else
                        PCE.Captions.Item(1).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                        PCE.Captions.Item(2).Text = ""
                    End If

                    If PCE.Progresses.Item(1).Key = "1" AndAlso Not PCE.Progresses.Item(1).Hidden Then
                        If PCE.Progresses.Item(1).PercentTo > 0 Then
                            PCE.Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE) & String.Format("({0}%)", PCE.Progresses.Item(1).PercentTo * 100)
                        Else
                            PCE.Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                        End If
                    Else
                        PCE.Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                    End If

                    TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)

                    'ピース日付の再描写
                    With PCE
                        PV = PCE.Value
                        DS = .Start
                        DE = .Finish
                        DE = DateAdd(DateInterval.Day, -1, DE)
                        Call PieceDateDraw(PCE, DS, DE) 'ピース日付の再描写
                    End With
                End If
            Catch ex As Exception
                Logs.PutErrorEx("ピース移動に失敗しました", ex, True)
            End Try

        End If
    End Sub
    ''' <summary>
    ''' TODO:ピース順序を入れ替える
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMP_PeaceSwap_Click(sender As Object, e As EventArgs) Handles RMP_PeaceSwap.Click
        Call RadialMenuHide()
        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
            Try
                _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons

                Dim SelRow As Integer = SelectedRow
                SelectedTime = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Start
                Dim ITM As KnTViewLib.Piece = PastePiece(SelRow)
                TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)

                'ピース日付の再描写
                With ITM
                    Dim DS As Date = ITM.Start
                    Dim DE As Date = DateAdd(DateInterval.Day, -1, ITM.Finish)
                    DE = DateAdd(DateInterval.Day, -1, DE)
                    Call PieceDateDraw(ITM, DS, DE) 'ピース日付の再描写
                End With

                ITM.Selected = True
                FR.Edited = True

            Catch ex As Exception
                Logs.PutErrorEx("ピース移動に失敗しました", ex, True)
            End Try
        End If

    End Sub

    ''' <summary>
    ''' ストーンの順序を入れ替える
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMS_StoneSwap_Click(sender As Object, e As EventArgs) Handles RMS_StoneSwap.Click
        Call RadialMenuHide()
        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
            Try
                _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
                Dim PV As PieceValueCollection = _CopyPiece.Value
                Dim PCE As KnTViewLib.Piece = PastePiece(SelectedRow)
                PCE.Start = _CopyPiece.Start
                PCE.Captions.Item(2).Text = ConvCaptionDate(PV.CaptionLeft, _CopyPiece.Start)
                TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)
            Catch ex As Exception
                Logs.PutErrorEx("ピース移動に失敗しました", ex, True)
            End Try

        End If
    End Sub
    ''' <summary>
    ''' ストーンを上に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMS_MoveToUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_MoveToUp.Click, RMS_MoveToUp.Click
        Call RadialMenuHide()
        If SelectedRow > 1 Then
            Try
                If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                    _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                    _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
                    Dim PV As PieceValueCollection = _CopyPiece.Value
                    Dim PCE As KnTViewLib.Piece = PastePiece(SelectedRow - 1)
                    PCE.Start = _CopyPiece.Start
                    PCE.Captions.Item(2).Text = ConvCaptionDate(PV.CaptionLeft, _CopyPiece.Start)
                    TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)
                End If
            Catch ex As Exception
                Logs.PutErrorEx("ストーン移動に失敗しました", ex, True)
            End Try
        End If
    End Sub
    ''' <summary>
    ''' ストーンを下に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMS_MoveToDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_MoveToDown.Click, RMS_MoveToDown.Click
        Call RadialMenuHide()
        If SelectedRow < TView.Items.Count Then
            Try
                If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                    _CopyPiece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                    _CopyBalloons = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace).Balloons
                    Dim PV As PieceValueCollection = _CopyPiece.Value
                    Dim PCE As KnTViewLib.Piece = PastePiece(SelectedRow + 1)
                    PCE.Start = _CopyPiece.Start
                    PCE.Captions.Item(2).Text = ConvCaptionDate(PV.CaptionLeft, _CopyPiece.Start)
                    TView.Items.Item(SelectedRow).Pieces.Remove(SelectedPeace)
                End If
            Catch ex As Exception
                Logs.PutErrorEx("ストーン移動に失敗しました", ex, True)
            End Try

        End If
    End Sub
    ''' <summary>
    ''' ストーン書式複写
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMS_CopyFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_CopyFormat.Click, RMS_CopyFormat.Click
        Call RadialMenuHide()
        If Not IsNothing(_CopyPiece) Then
            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then

                Dim STN As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                With STN.Captions.Item(1)
                    .Color = _CopyPiece.Captions.Item(1).Color
                    .HorAlign = _CopyPiece.Captions.Item(1).HorAlign
                    .VerAlign = _CopyPiece.Captions.Item(1).VerAlign
                    .Position = _CopyPiece.Captions.Item(1).Position
                End With

                With STN.Captions.Item(2)
                    .Color = _CopyPiece.Captions.Item(2).Color
                    .HorAlign = _CopyPiece.Captions.Item(2).HorAlign
                    .VerAlign = _CopyPiece.Captions.Item(2).VerAlign
                    .Position = _CopyPiece.Captions.Item(2).Position
                End With

                FR.Edited = True
            End If
        End If
    End Sub
    ''' <summary>
    ''' コピー済みピースから書式適用
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RTMP_CopyFormat_Copy_Click(sender As Object, e As EventArgs) Handles RTMP_CopyFormat_Copy.Click
        Call RadialMenuHide()

        If Not IsNothing(_CopyPiece) Then
            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then

                Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                FR.Edited = True

                PCE.BarShape.Fill.BackColor = _CopyPiece.BarShape.Fill.BackColor
                PCE.TunnelShape.Fill.BackColor = _CopyPiece.BarShape.Fill.BackColor

                With PCE.Captions.Item(1)
                    .Color = _CopyPiece.Captions.Item(1).Color
                    .HorAlign = _CopyPiece.Captions.Item(1).HorAlign
                    .VerAlign = _CopyPiece.Captions.Item(1).VerAlign
                    .Position = _CopyPiece.Captions.Item(1).Position
                End With
                With PCE.Captions.Item(2)
                    .Color = _CopyPiece.Captions.Item(2).Color
                    .HorAlign = _CopyPiece.Captions.Item(2).HorAlign
                    .VerAlign = _CopyPiece.Captions.Item(2).VerAlign
                    .Position = _CopyPiece.Captions.Item(2).Position
                End With
                With PCE.Captions.Item(3)
                    .Color = _CopyPiece.Captions.Item(3).Color
                    .HorAlign = _CopyPiece.Captions.Item(3).HorAlign
                    .VerAlign = _CopyPiece.Captions.Item(3).VerAlign
                    .Position = _CopyPiece.Captions.Item(3).Position
                End With

                PCE.Tunnel = _CopyPiece.Tunnel
                With PCE.Progresses.Item(1)
                    .Shape = _CopyPiece.Progresses.Item(1).Shape
                    .Fill.BackColor = _CopyPiece.Progresses.Item(1).Fill.BackColor
                    .Key = ""
                    .Key = _CopyPiece.Progresses.Item(1).Key
                End With
                Call PieceDateDraw(PCE, PCE.Start, PCE.Finish)


                'ピース日付の再描写
                With PCE
                    Call PieceDateDraw(PCE, .Start, DateAdd(DateInterval.Day, -1, .Finish)) 'ピース日付の再描写
                End With

                Call CellDateRefresh()
                TView.Refresh(1)
            End If
        End If
    End Sub
    ''' <summary>
    ''' マスターピースから書式適用
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RTMP_CopyFormat_Master_Click(sender As Object, e As EventArgs) Handles RTMP_CopyFormat_Master.Click
        Call PieceFormatCopy(0)
    End Sub
    ''' <summary>
    ''' テンプレートピースから書式適用
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RTMP_CopyFormat_Template_Click(sender As Object, e As EventArgs) Handles RTMP_CopyFormat_Template.Click
        Call PieceFormatCopy(1)
    End Sub
    ''' <summary>
    ''' 書式適用
    ''' </summary>
    ''' <param name="Mode"></param>
    ''' <remarks></remarks>
    Private Sub PieceFormatCopy(Mode As Integer)
        Call RadialMenuHide()

        Dim _T As PieceCollection = Nothing
        Select Case Mode
            Case 1 : _T = _TemplatePiece
            Case Else : _T = _MasterPiece
        End Select

        If Not IsNothing(_T) And _T.PieceColor <> 0 Then
            If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
                Try
                    Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
                    FR.Edited = True

                    PCE.BarShape.Fill.BackColor = _T.PieceColor
                    PCE.TunnelShape.Fill.BackColor = _T.PieceColor
                    With PCE.Captions.Item(1)
                        .Color = _T.CaptionLeft.ForeColor
                        .HorAlign = _T.CaptionLeft.HAlign
                        .VerAlign = _T.CaptionLeft.VAlign
                        .Position = _T.CaptionLeft.Position
                    End With
                    With PCE.Captions.Item(2)
                        .Color = _T.CaptionCenter.ForeColor
                        .HorAlign = _T.CaptionCenter.HAlign
                        .VerAlign = _T.CaptionCenter.VAlign
                        .Position = _T.CaptionCenter.Position
                    End With
                    With PCE.Captions.Item(3)
                        .Color = _T.CaptionRight.ForeColor
                        .HorAlign = _T.CaptionRight.HAlign
                        .VerAlign = _T.CaptionRight.VAlign
                        .Position = _T.CaptionRight.Position
                    End With

                    PCE.Tunnel = _T.Tunnel
                    With PCE.Progresses.Item(1)
                        .Shape = _T.ProgressBar.ProgressType
                        .Fill.BackColor = _T.ProgressBar.ProgressColor
                        .Key = ""
                        .Key = _T.ProgressBar.ProgressDisplay
                        .Hidden = _T.ProgressBar.IsNotUseProgress
                    End With

                    Dim DS As Date = PCE.Start
                    Dim DE As Date = DateAdd(DateInterval.Day, -1, PCE.Finish)

                    'ピース日付の再描写
                    Call PieceDateDraw(PCE, DS, DE)

                    Call CellDateRefresh()

                Catch ex As Exception
                    Logs.PutErrorEx("ピース書式適用に失敗", ex, True)
                End Try
            End If
        End If
    End Sub
    ''' <summary>
    ''' 行コピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_ItemCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_ItemCopy.Click, RMC_ItemCopy.Click, RMC_RowCopy.Click
        Call RadialMenuHide()
        Dim Row As Integer = SelectedRow
        If SelectedRow > 0 Then
            _CopyItem = TView.Items.Item(SelectedRow)
            FrmParent.LblMessage.Text = "選択行をコピーしました。"
        End If
    End Sub
    ''' <summary>
    ''' メニュー展開
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContextMenuCell_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuCell.Opening
        CMC_CopyFromUp.Enabled = IIf(SelectedRow = 1, False, True)
        CMC_CopyFromDown.Enabled = IIf(SelectedRow = TView.Items.Count, False, True)
        CMC_ItemPaste.Enabled = Not IsNothing(_CopyItem)

        RMC_CopyFromUp.Enabled = IIf(SelectedRow = 1, False, True)
        RMC_CopyFromDown.Enabled = IIf(SelectedRow = TView.Items.Count, False, True)
        RMC_ItemPaste.Enabled = Not IsNothing(_CopyItem)
        RMC_CopyFromUp.BorderColor = IIf(SelectedRow = 1, SystemColors.ControlDark, Color.RoyalBlue)
        RMC_CopyFromDown.BorderColor = IIf(SelectedRow = TView.Items.Count, SystemColors.ControlDark, Color.RoyalBlue)
        RMC_ItemPaste.BorderColor = IIf(IsNothing(_CopyItem), SystemColors.ControlDark, Color.RoyalBlue)

        RMC_CellPaste1.Enabled = Not IsNothing(_MemCell)
        RMC_CellPaste2.Enabled = Not IsNothing(_MemCell)
        RMC_CellPaste1.BorderColor = IIf(IsNothing(_MemCell), SystemColors.ControlDark, Color.RoyalBlue)
        RMC_CellPaste2.BorderColor = IIf(IsNothing(_MemCell), SystemColors.ControlDark, Color.RoyalBlue)
        If SelectedRow > 0 Then
            For Each CEL As KnTViewLib.Cell In TView.Items(SelectedRow - 1).cells
                If CEL.Tag = "HIDDEN" Then
                    CMC_RowHidden.Text = "非表示解除"
                    Return
                End If
            Next
            CMC_RowHidden.Text = "非表示設定"
        End If
    End Sub
    ''' <summary>
    ''' 行上へコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_ItemPasteToUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_ItemPasteToUp.Click, RMC_ItemPasteToUp.Click
        Call RadialMenuHide()
        Dim Item As KnTViewLib.Item = RowAdd(enumAddRow.ToUp)
        If Not IsNothing(Item) Then
            Call PasteRow(Item)
        End If
    End Sub
    ''' <summary>
    ''' 行下へコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_ItemPasteToDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_ItemPasteToDown.Click, RMC_ItemPasteToDown.Click
        Call RadialMenuHide()
        Dim Item As KnTViewLib.Item = RowAdd(enumAddRow.ToDown)
        If Not IsNothing(Item) Then
            Call PasteRow(Item)
        End If
    End Sub
    ''' <summary>
    ''' 行最下段へコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMC_ItemPasteToBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMC_ItemPasteToBottom.Click, RMC_ItemPasteToBottom.Click
        Call RadialMenuHide()
        Dim Item As KnTViewLib.Item = RowAdd(enumAddRow.ToBottom)
        If Not IsNothing(Item) Then
            Call PasteRow(Item)
        End If
    End Sub
    ''' <summary>
    ''' TODO:行のペースト
    ''' </summary>
    ''' <param name="ToItem"></param>
    ''' <remarks></remarks>
    Private Sub PasteRow(ByVal ToItem As KnTViewLib.Item)

        Try
            ToItem.PiecePane.Fill.BackColor = _CopyItem.PiecePane.Fill.BackColor

            For c As Integer = 1 To _CopyItem.Cells.Count
                If ToItem.Cells.Count >= c Then
                    Dim CItem As KnTViewLib.Cell = _CopyItem.Cells.Item(c)
                    With ToItem.Cells.Item(c)
                        .Value = CItem.Value
                        .HorAlign = CItem.HorAlign
                        .VerAlign = CItem.VerAlign
                        .Fill.BackColor = CItem.Fill.BackColor
                        .Color = CItem.Color
                        .IndentLevel = CItem.IndentLevel
                        .Tag = CItem.Tag

                        Call Cell_SetIntendIcon(ToItem.Cells.Item(c)) 'インデントイメージの表示・非表示
                    End With
                End If
            Next
            If _CopyItem.Pieces.Count > 0 Then
                For Each PItem As KnTViewLib.Piece In _CopyItem.Pieces
                    Dim ToPiece As KnTViewLib.Piece
                    Dim PV As PieceValueCollection = PItem.Value
                    'If PItem.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                    If PieceIsStone(PItem) Then
                        'ストーン
                        ToPiece = ToItem.Pieces.AddFromTemplate(2)
                        With ToPiece
                            .Start = PItem.Start
                            .Finish = PItem.Finish
                            If TView.ImageLists.Count > 0 Then
                                .StartShape.Shape = PItem.StartShape.Shape
                                .StartShape.Image("ImageList", PV.StoneImageKey)
                            End If
                            With .Captions.Item(1)
                                .Color = PItem.Captions.Item(1).Color
                                .Text = PItem.Captions.Item(1).Text
                                .HorAlign = PItem.Captions.Item(1).HorAlign
                                .VerAlign = PItem.Captions.Item(1).VerAlign
                                .Position = PItem.Captions.Item(1).Position
                            End With
                            With .Captions.Item(2)
                                .Color = PItem.Captions.Item(2).Color
                                .Text = PItem.Captions.Item(2).Text
                                .HorAlign = PItem.Captions.Item(2).HorAlign
                                .VerAlign = PItem.Captions.Item(2).VerAlign
                                .Position = PItem.Captions.Item(2).Position
                            End With
                            .Value = PV
                        End With
                    Else
                        'ピース
                        ToPiece = ToItem.Pieces.AddFromTemplate(1)
                        Dim prgrs As KnTViewLib.Progress = ToPiece.Progresses.Item(1)
                        prgrs.Shape = KnTViewLib.TivBarShape.tivBarShapeRectangle
                        prgrs.PercentTo = 0
                        With ToPiece
                            .Start = PItem.Start
                            .Finish = PItem.Finish
                            .BarShape.Fill.BackColor = PItem.BarShape.Fill.BackColor
                            .Tunnel = PItem.Tunnel
                            With .Captions.Item(1)
                                .Color = PItem.Captions.Item(1).Color
                                .Text = PItem.Captions.Item(1).Text
                                .HorAlign = PItem.Captions.Item(1).HorAlign
                                .VerAlign = PItem.Captions.Item(1).VerAlign
                                .Position = PItem.Captions.Item(1).Position
                            End With
                            With .Captions.Item(2)
                                .Color = PItem.Captions.Item(2).Color
                                .Text = PItem.Captions.Item(2).Text
                                .HorAlign = PItem.Captions.Item(2).HorAlign
                                .VerAlign = PItem.Captions.Item(2).VerAlign
                                .Position = PItem.Captions.Item(2).Position
                            End With
                            With .Captions.Item(3)
                                .Color = PItem.Captions.Item(3).Color
                                .Text = PItem.Captions.Item(3).Text
                                .HorAlign = PItem.Captions.Item(3).HorAlign
                                .VerAlign = PItem.Captions.Item(3).VerAlign
                                .Position = PItem.Captions.Item(3).Position
                            End With

                            .Value = PV
                            With .Progresses
                                .Item(1).Shape = PItem.Progresses.Item(1).Shape
                                .Item(1).PercentTo = PItem.Progresses.Item(1).PercentTo
                                .Item(1).Fill.BackColor = PItem.Progresses.Item(1).Fill.BackColor
                                .Item(1).Key = ""
                                .Item(1).Key = PItem.Progresses.Item(1).Key
                                .Item(1).Hidden = PItem.Progresses.Item(1).Hidden
                            End With

                            Dim DS As Date = PItem.Start
                            Dim DE As Date = DateAdd(DateInterval.Day, -1, PItem.Finish)
                            .Captions.Item(1).Text = PItem.Captions.Item(1).Text
                            .Captions.Item(2).Text = PItem.Captions.Item(2).Text
                            If .Progresses.Item(1).Key = "1" AndAlso Not .Progresses.Item(1).Hidden Then
                                If .Progresses.Item(1).PercentTo > 0 Then
                                    .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE) & String.Format("({0}%)", .Progresses.Item(1).PercentTo * 100)
                                Else
                                    .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                                End If
                            Else
                                .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                            End If
                        End With
                    End If

                    If PItem.Balloons.Count > 0 Then
                        For Each BItem As KnTViewLib.Balloon In PItem.Balloons
                            Dim BL As KnTViewLib.Balloon = ToPiece.Balloons.Add(, )
                            BL.PosRelPoint.X = BItem.PosRelPoint.X
                            BL.PosRelPoint.Y = BItem.PosRelPoint.Y
                            BL.AnchorRelPoint.X = BItem.AnchorRelPoint.X
                            BL.AnchorRelPoint.Y = BItem.AnchorRelPoint.Y

                            BL.BalloonShape.Fill.BackColor = BItem.BalloonShape.Fill.BackColor
                            BL.BalloonShape.Shape = BItem.BalloonShape.Shape

                            BL.Caption.Color = BItem.Caption.Color
                            BL.Caption.Text = BItem.Caption.Text
                            BL.Caption.HorAlign = BItem.Caption.HorAlign
                            BL.Caption.VerAlign = BItem.Caption.VerAlign

                            BL.BalloonShape.BeakBase = BItem.BalloonShape.BeakBase
                            BL.BalloonShape.Height = BItem.BalloonShape.Height
                            BL.BalloonShape.Width = BItem.BalloonShape.Width
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            Logs.PutErrorEx("行ペーストエラー", ex, True)
        End Try

    End Sub

    ''' <summary>
    ''' メニュー展開
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContextMenuSheetNothing_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuSheetNothing.Opening
        Call RadialMenuHide()
        CMSN_ItemPaste.Enabled = Not IsNothing(_CopyItem)
        If IsNothing(_CopyItem) Then
            RMSN_ItemPaste.Enabled = False : RMSN_ItemPaste.BorderColor = SystemColors.ControlDark
        Else
            RMSN_ItemPaste.Enabled = True : RMSN_ItemPaste.BorderColor = Color.RoyalBlue
        End If
    End Sub
    ''' <summary>
    ''' 行追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMSN_RowAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMSN_RowAdd.Click, RMSN_RowAdd.Click
        RadialMenuSheetNothing.HideMenu()
        Call RowAdd(enumAddRow.ToBottom)
    End Sub
    ''' <summary>
    ''' 行貼り付けメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMSN_ItemPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMSN_ItemPaste.Click, RMSN_ItemPaste.Click
        Call RadialMenuHide()
        Dim Item As KnTViewLib.Item = RowAdd(enumAddRow.ToBottom)
        If Not IsNothing(Item) Then
            If Not IsNothing(_CopyItem) Then
                Call PasteRow(Item)
            End If
        End If

    End Sub
    ''' <summary>
    ''' フォームの中心位置を算出する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormCenter() As Point
        Dim X As Integer = FrmParent.Location.X + Me.Location.X + (Me.Size.Width / 2)
        Dim Y As Integer = FrmParent.Location.Y + Me.Location.Y + (Me.Size.Height / 2)
        Return New Point(X, Y)
    End Function
    ''' <summary>
    ''' 本日に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMNO_MoveToday_Click(sender As Object, e As EventArgs) Handles RMNO_MoveToday.Click, RMSN_MoveToday.Click
        Call RadialMenuHide()
        Call MoveToday()
    End Sub

    Private Sub RadialMenuStripBalloon_ItemClick(sender As Object, e As C1.Win.C1Command.RadialMenuItemClickEventArgs) Handles RadialMenuStripBalloon.ItemClick
        RadialMenuStripBalloon.HideMenu()
    End Sub

    Private Sub CMC_RowHidden_Click(sender As Object, e As EventArgs) Handles CMC_RowHidden.Click
        Call RowHidden()
    End Sub

    Private Sub RadialMenuCellHeader_ItemClick(sender As Object, e As C1.Win.C1Command.RadialMenuItemClickEventArgs) Handles RadialMenuCellHeader.ItemClick
        RadialMenuCellHeader.HideMenu()
    End Sub

    Private Sub RadialMenuRelatedLine_ItemClick(sender As Object, e As C1.Win.C1Command.RadialMenuItemClickEventArgs) Handles RadialMenuRelatedLine.ItemClick
        RadialMenuRelatedLine.HideMenu()
    End Sub

    Private Sub RadialMenuStone_ItemClick(sender As Object, e As C1.Win.C1Command.RadialMenuItemClickEventArgs) Handles RadialMenuStone.ItemClick
        RadialMenuStone.HideMenu()
    End Sub

    Private Sub RadialMenuSheetNothing_ItemClick(sender As Object, e As C1.Win.C1Command.RadialMenuItemClickEventArgs) Handles RadialMenuSheetNothing.ItemClick
        RadialMenuSheetNothing.HideMenu()
    End Sub

    Private Sub RadialMenuCell_ItemClick(sender As Object, e As C1.Win.C1Command.RadialMenuItemClickEventArgs) Handles RadialMenuCell.ItemClick
        RadialMenuCell.HideMenu()
    End Sub

    Private Sub RadialMenuPeace_ItemClick(sender As Object, e As C1.Win.C1Command.RadialMenuItemClickEventArgs) Handles RadialMenuPeace.ItemClick
        RadialMenuPeace.HideMenu()
    End Sub

    Private Sub RadialMenuPiecePane_ItemClick(sender As Object, e As C1.Win.C1Command.RadialMenuItemClickEventArgs) Handles RadialMenuPiecePane.ItemClick
        RadialMenuPiecePane.HideMenu()
    End Sub
#Region "稲妻線"
    Dim _ViewInazuma As Boolean = False
    ''' <summary>
    ''' 稲妻線表示・非表示プロパティ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ViewInazuma As Boolean
        Get
            Return _ViewInazuma
        End Get
        Set(value As Boolean)
            _ViewInazuma = value
            Call DrawInazuma()
        End Set
    End Property
    ''' <summary>
    ''' 稲妻線表示非表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DrawInazuma()
        Dim FLG As Boolean = FR.Edited
        '一旦作成済み稲妻線を削除
        For i As Integer = TView.ProgressLines.Count To 1 Step -1
            TView.ProgressLines.Remove(i)
        Next

        If _ViewInazuma Then
            Dim plineTarget As KnTViewLib.ProgressLine
            'Dim pptTarget As KnTViewLib.ProgressPoint
            Dim itemTarget As KnTViewLib.Item
            Dim pieceTarget As KnTViewLib.Piece
            'Dim WDate As Date

            'If itm.TargetIsToday Then
            'WDate = Now
            'Else
            'WDate = itm.TargetDate
            'End If

            ' 稲妻線の追加
            plineTarget = TView.ProgressLines.Add()

            ' 稲妻線の設定
            plineTarget.TargetTime = Now 'dateTarget
            plineTarget.UpdateMode = KnTViewLib.TivMode.tivAutomatic
            plineTarget.Line.Color = System.Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red))

            ' 進捗ポイントの追加
            For Each itemTarget In TView.Items
                For Each pieceTarget In itemTarget.Pieces
                    If pieceTarget.Progresses.Count >= plineTarget.Index Then
                        TView_AfterPieceProgressMouseChange(TView, New AxKnTViewLib._DKnTViewEvents_AfterPieceProgressMouseChangeEvent(False, pieceTarget.Progresses.Item(plineTarget.Index).PercentTo, pieceTarget, plineTarget.Index))
                    End If
                Next pieceTarget
            Next itemTarget

            FR.Edited = FLG
        End If

    End Sub
#End Region

    ''' <summary>
    ''' 設定メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMSN_SheetProperty_Click(sender As Object, e As EventArgs) Handles RMSN_SheetProperty.Click
        Call RadialMenuHide()
        Call FrmParent.MenuSetting_Click(Nothing, Nothing)
    End Sub
    'セルコピー用変数
    Dim _MemCell As KnTViewLib.Cell = Nothing
    ''' <summary>
    ''' セルコピーメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMC_CellCopy_Click(sender As Object, e As EventArgs) Handles RMC_CellCopy.Click
        Call RadialMenuHide()

        Try
            Dim FromCell As KnTViewLib.Cell = TView.Cell(SelectedRow, SelectedColumn)
            _MemCell = TView.Cell(SelectedRow, SelectedColumn)
            FrmParent.LblMessage.Text = "セルコピーしました"
        Catch ex As Exception
            Logs.PutErrorEx("セルコピーに失敗しました", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' セルペーストメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMC_CellPaste1_Click(sender As Object, e As EventArgs) Handles RMC_CellPaste1.Click
        Call RadialMenuHide()
        Try
            If Not IsNothing(_MemCell) Then
                If SelectedRow > 0 AndAlso SelectedColumn > 0 Then
                    Dim ToCell As KnTViewLib.Cell = TView.Cell(SelectedRow, SelectedColumn)
                    ToCell.Color = _MemCell.Color
                    ToCell.Fill.BackColor = _MemCell.Fill.BackColor
                    ToCell.Fill.BackColor = _MemCell.Fill.BackColor
                    ToCell.Fill.BkMode = _MemCell.Fill.BkMode
                    ToCell.Fill.ForeColor = _MemCell.Fill.ForeColor
                    ToCell.Fill.Pattern = _MemCell.Fill.Pattern
                    ToCell.HorAlign = _MemCell.HorAlign
                    ToCell.ImagePosition = _MemCell.ImagePosition
                    ToCell.IndentLevel = _MemCell.IndentLevel
                    ToCell.Key = _MemCell.Key
                    ToCell.RightBorder.Color = _MemCell.RightBorder.Color
                    ToCell.RightBorder.Style = _MemCell.RightBorder.Style
                    ToCell.BottomBorder.Color = _MemCell.BottomBorder.Color
                    ToCell.BottomBorder.Style = _MemCell.BottomBorder.Style
                    ToCell.Tag = _MemCell.Tag
                    ToCell.Value = _MemCell.Value
                    ToCell.VerAlign = _MemCell.VerAlign
                    FrmParent.LblMessage.Text = "セルを貼り付けました"
                End If
            End If
        Catch ex As Exception
            Logs.PutErrorEx("セルペーストに失敗しました", ex, True)
        End Try
    End Sub
    ''' <summary>
    ''' セル文字なしペーストメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMC_CellPaste2_Click(sender As Object, e As EventArgs) Handles RMC_CellPaste2.Click
        Call RadialMenuHide()
        Try
            If Not IsNothing(_MemCell) Then
                If SelectedRow > 0 AndAlso SelectedColumn > 0 Then
                    Dim ToCell As KnTViewLib.Cell = TView.Cell(SelectedRow, SelectedColumn)
                    ToCell.Color = _MemCell.Color
                    ToCell.Fill.BackColor = _MemCell.Fill.BackColor
                    ToCell.Fill.BackColor = _MemCell.Fill.BackColor
                    ToCell.Fill.BkMode = _MemCell.Fill.BkMode
                    ToCell.Fill.ForeColor = _MemCell.Fill.ForeColor
                    ToCell.Fill.Pattern = _MemCell.Fill.Pattern
                    ToCell.HorAlign = _MemCell.HorAlign
                    ToCell.ImagePosition = _MemCell.ImagePosition
                    ToCell.IndentLevel = _MemCell.IndentLevel
                    ToCell.Key = _MemCell.Key
                    ToCell.RightBorder.Color = _MemCell.RightBorder.Color
                    ToCell.RightBorder.Style = _MemCell.RightBorder.Style
                    ToCell.BottomBorder.Color = _MemCell.BottomBorder.Color
                    ToCell.BottomBorder.Style = _MemCell.BottomBorder.Style
                    'ToCell.Tag = _MemCell.Tag
                    ToCell.VerAlign = _MemCell.VerAlign
                    FrmParent.LblMessage.Text = "書式を貼り付けました"
                End If
            End If
        Catch ex As Exception
            Logs.PutErrorEx("セルペーストに失敗しました", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' 選択セルから下へ全コピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMC_CellAllCopy_Click(sender As Object, e As EventArgs) Handles RMC_CellAllCopy.Click
        Call RadialMenuHide()

        Try
            If SelectedRow > 0 AndAlso SelectedColumn > 0 Then
                If MsgBox("選択セルから下の全セルにコピーしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                    Dim FromCell As KnTViewLib.Cell = TView.Cell(SelectedRow, SelectedColumn)
                    _MemCell = TView.Cell(SelectedRow, SelectedColumn)

                    If Not IsNothing(_MemCell) Then
                        For Row As Integer = SelectedRow + 1 To TView.Items.Count
                            Dim ToCell As KnTViewLib.Cell = TView.Cell(Row, SelectedColumn)
                            ToCell.Color = _MemCell.Color
                            ToCell.Fill.BackColor = _MemCell.Fill.BackColor
                            ToCell.Fill.BackColor = _MemCell.Fill.BackColor
                            ToCell.Fill.BkMode = _MemCell.Fill.BkMode
                            ToCell.Fill.ForeColor = _MemCell.Fill.ForeColor
                            ToCell.Fill.Pattern = _MemCell.Fill.Pattern
                            ToCell.HorAlign = _MemCell.HorAlign
                            ToCell.ImagePosition = _MemCell.ImagePosition
                            ToCell.IndentLevel = _MemCell.IndentLevel
                            ToCell.Key = _MemCell.Key
                            ToCell.RightBorder.Color = _MemCell.RightBorder.Color
                            ToCell.RightBorder.Style = _MemCell.RightBorder.Style
                            ToCell.BottomBorder.Color = _MemCell.BottomBorder.Color
                            ToCell.BottomBorder.Style = _MemCell.BottomBorder.Style
                            ToCell.Tag = _MemCell.Tag
                            ToCell.Value = _MemCell.Value
                            ToCell.VerAlign = _MemCell.VerAlign
                        Next
                        Call CellDateRefresh()
                        FrmParent.LblMessage.Text = "下までの全セルにコピー完了"
                    End If
                End If
            End If
        Catch ex As Exception
            Logs.PutErrorEx("セルコピーに失敗しました", ex, True)
        End Try

    End Sub

    ''' <summary>
    ''' ピースを動かそうとした
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_BeforePieceMove(sender As Object, e As AxKnTViewLib._DKnTViewEvents_BeforePieceMoveEvent) Handles TView.BeforePieceMove
        If Not IsEditMode Then '閲覧モード時は操作をキャンセル
            e.cancel.Value = True
        End If
        If _TemporaryLock Then '一時ロック中はキャンセル
            e.cancel.Value = True
            FrmParent.LblMessage.Text = "ロックモードではピースの移動は出来ません"
        End If


        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
            'ロックピースならキャンセル
            Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
            Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
            Dim _IsWaterFall As Boolean = PT.IsWaterFall
            Dim _IsNummaryPiece As Boolean = PT.IsSummaryPiece
            If _IsNummaryPiece Then
                FrmParent.LblMessage.Text = "サマリーピースの移動は出来ません"
                e.cancel.Value = True
                Return
            End If

            'If IsLockItem(PCE) Then
            '    e.cancel.Value = True
            'End If
            If PCE.Weight > 0 Then
                e.cancel.Value = True
            End If

            'Dim UD As PieceCollection = PieceConvert(PCE)
            '_UndoData.Add(UD)
        End If

    End Sub
    ''' <summary>
    ''' ピースの時間を変更しようとした
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_BeforePieceTimeChange(sender As Object, e As AxKnTViewLib._DKnTViewEvents_BeforePieceTimeChangeEvent) Handles TView.BeforePieceTimeChange
        If Not IsEditMode Then '閲覧モード時は操作をキャンセル
            e.cancel.Value = True
        End If
        If _TemporaryLock Then '一時ロック中はキャンセル
            e.cancel.Value = True
            FrmParent.LblMessage.Text = "ロックモードではピース日付変更は出来ません"
        End If

        If SelectedRow > 0 AndAlso SelectedPeace > 0 Then
            'ロックピースならキャンセル
            Dim PCE As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(SelectedPeace)
            Dim PT As PeaceTagCollection = PeaceTag(PCE.Tag)
            Dim _IsWaterFall As Boolean = PT.IsWaterFall
            Dim _IsNummaryPiece As Boolean = PT.IsSummaryPiece
            If _IsNummaryPiece Then
                FrmParent.LblMessage.Text = "サマリーピースの日付変更は出来ません"
                e.cancel.Value = True
                Return
            End If

            'If IsLockItem(PCE) Then
            '    e.cancel.Value = True
            'End If
            If PCE.Weight > 0 Then
                e.cancel.Value = True
            End If

            'Dim UD As PieceCollection = PieceConvert(PCE)
            '_UndoData.Add(UD)

        End If
    End Sub
    ''' <summary>
    ''' ピースを追加使用とした
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_BeforePieceAdd(sender As Object, e As AxKnTViewLib._DKnTViewEvents_BeforePieceAddEvent) Handles TView.BeforePieceAdd
        If Not IsEditMode Then '閲覧モード時は操作をキャンセル
            e.cancel.Value = True
        End If

        If _TemporaryLock Then '一時ロック中はキャンセル
            e.cancel.Value = True
            FrmParent.LblMessage.Text = "ロックモードではピースの追加は出来ません"
        End If
    End Sub

    ''' <summary>
    ''' エクスポート（グリッド）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMNO_DataExport_Grid_Click(sender As Object, e As EventArgs) Handles RMNO_DataExport_Grid.Click
        Call RadialMenuHide()
        Call DataExport()
    End Sub
    ''' <summary>
    ''' エクスポート（XML)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMNO_DataExport_XML_Click(sender As Object, e As EventArgs) Handles RMNO_DataExport_XML.Click
        Call RadialMenuHide()
        Call DataExportXML()
    End Sub
    ''' <summary>
    ''' 全面切替
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMNO_F11_Click(sender As Object, e As EventArgs) Handles RMNO_F11.Click
        Call FunctionAction(122)
    End Sub
    ''' <summary>
    ''' 特別期間設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMNO_SpecialTimeSetting_Click(sender As Object, e As EventArgs) Handles RMNO_SpecialTimeSetting.Click, RMSN_SpecialTimeSetting.Click
        Call RadialMenuHide()
        Call SpecialTimeSetting()
    End Sub

#Region "並び替え関係"

    ''' <summary>
    ''' 並び替え（昇順）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMCH_SortAscending_Click(sender As Object, e As EventArgs) Handles RMCH_SortAscending.Click
        Call RadialMenuHide()
        Try
            Dim Row As Integer = TView.Items.Count
            If Row > 0 AndAlso SelectedColumn > 0 Then
                TView.Sort(1, Row, SelectedColumn, SelectedColumn, 0, False)
                Call CellDateRefresh()
                FR.Edited = True
            End If
        Catch ex As Exception
            Logs.PutErrorEx("ソートエラー", ex)
        End Try
    End Sub
    ''' <summary>
    ''' 並び替え（降順）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMCH_SortDescending_Click(sender As Object, e As EventArgs) Handles RMCH_SortDescending.Click
        Call RadialMenuHide()
        Try
            Dim Row As Integer = TView.Items.Count
            If Row > 0 AndAlso SelectedColumn > 0 Then
                TView.Sort(1, Row, SelectedColumn, SelectedColumn, 1, False)
                Call CellDateRefresh()
                FR.Edited = True
            End If
        Catch ex As Exception
            Logs.PutErrorEx("ソートエラー", ex)
        End Try
    End Sub
    ''' <summary>
    ''' 並び替え（詳細）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMCH_SortManual_Click(sender As Object, e As EventArgs) Handles RMCH_SortManual.Click
        Call RadialMenuHide()
        With FrmSort
            .Obj = TView
            If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                FrmParent.TopMost = False
                Me.TopMost = True
            End If
            Call .ShowDialog()
            If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                FrmParent.TopMost = True
            End If
            Call CellDateRefresh()
            FR.Edited = True
        End With
    End Sub
#End Region

    ''' <summary>
    ''' 行番号付与
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMCH_AutoNumber_Click(sender As Object, e As EventArgs) Handles RMCH_AutoNumber.Click
        Call RadialMenuHide()
        Try
            If TView.Items.Count > 0 AndAlso SelectedColumn > 0 Then
                Dim Flg As Boolean = False
                With FrmAutoNumber
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = False
                        Me.TopMost = True
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        If TView.Items.Count > 0 AndAlso SelectedColumn > 0 Then
                            For Row As Integer = 1 To TView.Items.Count
                                Dim Moji As String = ""
                                Select Case .IsNomal
                                    Case 1
                                        Select Case TView.Items.Count
                                            Case Is >= 10000
                                                Moji = String.Format("{0:00000}", Row)
                                            Case Is >= 1000
                                                Moji = String.Format("{0:0000}", Row)
                                            Case Is >= 100
                                                Moji = String.Format("{0:000}", Row)
                                            Case Is >= 10
                                                Moji = String.Format("{0:00}", Row)
                                            Case Else
                                                Moji = Row.ToString
                                        End Select
                                    Case 2

                                        Moji = "<ROWNO>"
                                    Case Else
                                        Moji = Row.ToString
                                End Select

                                Dim _T1 As CellTagCollection = CellTagConvert(TView.Cell(Row, SelectedColumn).Tag)
                                Dim _T2 As New CellTagCollection
                                _T2.Caption = Moji
                                _T2.IsHidden = _T1.IsHidden

                                TView.Cell(Row, SelectedColumn).Value = Moji
                                TView.Cell(Row, SelectedColumn).Tag = CellTagConvert(_T2)
                            Next
                        End If
                        Call CellDateRefresh()
                        FR.Edited = True
                    End If
                    If FrmParent.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                        FrmParent.TopMost = True
                    End If

                End With
            End If
        Catch ex As Exception
            Logs.PutErrorEx("行番号付与に失敗しました", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' ピース最終へ移動（行）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMC_MoveLast_Click(sender As Object, e As EventArgs) Handles RMC_MoveLast.Click
        Call RadialMenuHide()

        Dim DT As Date = Nothing
        If TView.Items.Count > 0 AndAlso SelectedRow > 0 Then
            Dim D As Date = Nothing
            For Col As Integer = 1 To TView.Items.Item(SelectedRow).Pieces.Count
                Dim PC As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(Col)
                Dim DD As Date = Nothing
                If Not IsDBNull(PC.Finish) Then
                    DD = PC.Finish
                Else
                    DD = PC.Start
                End If
                If DD.ToOADate <> 0 Then
                    If D.ToOADate = 0 OrElse D < DD Then
                        D = DD
                    End If
                End If
            Next
            If D.ToOADate <> 0 Then
                TView.ViewTopTime = DateAdd(DateInterval.Day, 0 - _StartDay, D)
            End If
        End If
    End Sub
    ''' <summary>
    ''' ピース先頭へ移動（行）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMC_MoveTop_Click(sender As Object, e As EventArgs) Handles RMC_MoveTop.Click
        Call RadialMenuHide()

        Dim DT As Date = Nothing
        If TView.Items.Count > 0 AndAlso SelectedRow > 0 Then
            Dim D As Date = Nothing
            For Col As Integer = 1 To TView.Items.Item(SelectedRow).Pieces.Count
                Dim PC As KnTViewLib.Piece = TView.Items.Item(SelectedRow).Pieces.Item(Col)
                If Not IsDBNull(PC.Start) Then
                    Dim DD As Date = PC.Start
                    If D.ToOADate = 0 OrElse D > DD Then
                        D = DD
                    End If
                End If
            Next
            If D.ToOADate <> 0 Then
                TView.ViewTopTime = DateAdd(DateInterval.Day, 0 - _StartDay, D)
            End If
        End If
    End Sub

    Private Sub TView_AfterHorScroll(sender As Object, e As AxKnTViewLib._DKnTViewEvents_AfterHorScrollEvent) Handles TView.AfterHorScroll
        FrmParent.SyncTime(TView.ViewTopTime)
    End Sub

    ''' <summary>
    ''' ガントチャータが選択されたらフォームを選択状態にする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TView_GotFocus(sender As Object, e As EventArgs) Handles TView.GotFocus
        Me.Focus()
    End Sub


#Region "インポート関係"

    ''' <summary>
    ''' クリップボードからインポート
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Import_Clip()
        Call RadialMenuHide()
        Try
            If Clipboard.ContainsText() Then
                '文字列データがあるときはこれを取得する
                '取得できないときは空の文字列（String.Empty）を返す
                Dim _T() As String = Split(Clipboard.GetText(), vbCrLf)
                For Each Itm As String In _T
                    Dim _TT() As String = Split(Itm, vbTab)

                    Dim SDate As Date = Nothing
                    Dim EDate As Date = Nothing
                    Dim ColItem As New ArrayList
                    For Each ClipData As String In _TT
                        If IsDate(ClipData) Then
                            If SDate = Nothing Then
                                SDate = CDate(ClipData)
                            ElseIf EDate = Nothing Then
                                EDate = CDate(ClipData)
                            End If
                        Else
                            ColItem.Add(ClipData)
                        End If
                    Next
                    Call Import_AddRow(SDate, EDate, ColItem)
                Next
                Call CellDateRefresh()

                Logs.PutInformation("インポート完了", _WorkFileName)
                FR.Edited = True
                FrmParent.LblMessage.Text = "インポート完了"
            End If
        Catch ex As Exception
            Logs.PutErrorEx("クリップボードからのインポートに失敗しました", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' CSVファイルからインポート
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Import_CSV()
        Call RadialMenuHide()
        Dim FileName As String = ""
        Using OFD As New OpenFileDialog
            With OFD
                .AddExtension = True
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = ".csv"
                .Filter = "CSVファイル(*.csv)|*.csv|全てのファイル(*.*)|*.*"
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
            Try
                Using sr As New System.IO.StreamReader(FileName, System.Text.Encoding.GetEncoding("shift_jis"))
                    While sr.Peek() > -1
                        Dim _TT() As String = Split(sr.ReadLine(), ",")

                        Dim SDate As Date = Nothing
                        Dim EDate As Date = Nothing
                        Dim ColItem As New ArrayList
                        For Each ClipData As String In _TT
                            If IsDate(ClipData) Then
                                If SDate = Nothing Then
                                    SDate = CDate(ClipData)
                                ElseIf EDate = Nothing Then
                                    EDate = CDate(ClipData)
                                End If
                            Else
                                ColItem.Add(ClipData)
                            End If
                        Next

                        Call Import_AddRow(SDate, EDate, ColItem)

                    End While
                End Using
                Call CellDateRefresh()
                Logs.PutInformation("インポート完了", _WorkFileName)
                FR.Edited = True
                FrmParent.LblMessage.Text = "インポート完了"
            Catch ex As Exception
                Logs.PutErrorEx("CSVファイルからのインポートに失敗しました", ex, True)
            End Try

        End If
    End Sub
    ''' <summary>
    ''' インポートデータを追加
    ''' </summary>
    ''' <param name="SDate"></param>
    ''' <param name="EDate"></param>
    ''' <param name="CellData"></param>
    ''' <remarks></remarks>
    Private Sub Import_AddRow(SDate As Date, EDate As Date, CellData As ArrayList)
        If Not SDate.ToOADate = 0 AndAlso Not EDate.ToOADate = 0 Then
            Call RowAdd(enumAddRow.ToBottom)
            Dim Row As Integer = TView.Items.Count

            Dim PCE As KnTViewLib.Piece = TView.Items.Item(Row).Pieces.AddFromTemplate(1)

            With PCE
                PCE.Start = SDate
                PCE.Finish = EDate
                Dim PV As New PieceValueCollection
                PV.CaptionLeft = "<DATE>"
                PV.CaptionRight = "<DATE>"
                PCE.Value = PV

                Dim DS As Date = SDate
                Dim DE As Date = EDate
                If DS <> DE Then
                    '.Captions.Item(1).Text = Format(DS, PV.CaptionLeft)
                    .Captions.Item(1).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionLeft, DS), DS, DE)
                    .Captions.Item(2).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                Else
                    .Captions.Item(1).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                    .Captions.Item(2).Text = ""
                End If

                If PCE.Progresses.Item(1).Key = "1" Then
                    If PCE.Progresses.Item(1).PercentTo > 0 Then
                        .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE) & String.Format("({0}%)", PCE.Progresses.Item(1).PercentTo * 100)
                    Else
                        .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                    End If
                Else
                    .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                End If
                PCE.Tunnel = _DefTunnel
            End With

            Dim prgrs As KnTViewLib.Progress = PCE.Progresses.Item(1)
            prgrs.Shape = KnTViewLib.TivBarShape.tivBarShapeRectangle
            prgrs.PercentTo = 0

            'マスタピースが設定されているのであれば、それを適用させる
            Call MasterPieceFormatSet(PCE)

            'セル
            For Col As Integer = 1 To TView.Items.Item(Row).Cells.Count
                If CellData.Count > Col - 1 Then
                    Dim _ST As String = CellData(Col - 1)
                    Dim _T2 As New CellTagCollection

                    _T2.Caption = Replace(_ST, Chr(13), "")
                    _T2.IsHidden = False
                    TView.Cell(Row, Col).Value = Replace(_ST, Chr(13), "")
                    TView.Cell(Row, Col).Tag = CellTagConvert(_T2)
                End If
            Next

        End If
    End Sub
    ''' <summary>
    ''' スケジュールのマージ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MergeData()
        Call RadialMenuHide()
        Dim FileName As String = ""
        Using OFD As New OpenFileDialog
            With OFD
                .AddExtension = True
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = ".csv"
                .Filter = "Windyファイル(*.wdf)|*.wdf|全てのファイル(*.*)|*.*"
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
            If MsgBox("スケジュールをマージしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                Try
                    Dim Data As New List(Of WindyDataCollection)
                    If XMLReadData(Data, FileName) Then

                        '統合するファイルの列数確認
                        If TView.ColumnHeaders.Count < Data(0).Header.Count Then
                            If MsgBox("統合元ファイルの列数が統合先ファイルの列数を上回っています。" & vbCrLf & _
                                      String.Format("※統合元ファイルには列が{0}列あります", Data(0).Header.Count) & vbCrLf & _
                                      "※越える列データは切り捨てられます" & vbCrLf & "マージ作業を続行しますか？", 4 + 32, "マージ処理続行確認") = MsgBoxResult.No Then
                                Return
                            End If
                        End If

                        Dim _StartRow As Integer = TView.Items.Count '現在の行数を保存

                        '先に必要行を追加
                        For i As Integer = 1 To Data(0).RowCount + 1
                            Call RowAdd(enumAddRow.ToBottom)
                        Next

                        'ピース／ストーン
                        For i As Integer = 0 To Data(0).Piece.Count - 1
                            Dim Row As Integer = Data(0).Piece(i).RowIndex + _StartRow + 1
                            If Data(0).Piece(i).Shape = 11 Then
                                Dim PCE As KnTViewLib.Piece = TView.Items.Item(Row).Pieces.AddFromTemplate(2)
                                Dim PV As New PieceValueCollection
                                With PCE

                                    PV.CaptionLeft = Data(0).Piece(i).CaptionLeft.Text
                                    PV.CaptionCenter = Data(0).Piece(i).CaptionCenter.Text
                                    PV.CaptionRight = Data(0).Piece(i).CaptionRight.Text
                                    PV.StoneImageKey = Data(0).Piece(i).ShapeName

                                    PCE.Start = Data(0).Piece(i).Start
                                    PCE.Finish = Data(0).Piece(i).Finish
                                    PCE.Weight = Data(0).Piece(i).LockPiece
                                    If TView.ImageLists.Count > 0 Then
                                        PCE.StartShape.Shape = Data(0).Piece(i).Shape
                                        PCE.StartShape.Image("ImageList", Data(0).Piece(i).ShapeName)
                                    End If

                                    PCE.Tag = Data(0).Piece(i).ShapeName
                                    With .Captions.Item(1)
                                        .Color = Data(0).Piece(i).CaptionLeft.ForeColor
                                        .Text = PV.CaptionCenter
                                        .HorAlign = Data(0).Piece(i).CaptionLeft.HAlign
                                        .VerAlign = Data(0).Piece(i).CaptionLeft.VAlign
                                        .Position = Data(0).Piece(i).CaptionLeft.Position
                                    End With
                                    With .Captions.Item(2)
                                        .Color = Data(0).Piece(i).CaptionCenter.ForeColor
                                        .Text = ConvCaptionDate(PV.CaptionLeft, PCE.Start)
                                        .HorAlign = Data(0).Piece(i).CaptionCenter.HAlign
                                        .VerAlign = Data(0).Piece(i).CaptionCenter.VAlign
                                        .Position = Data(0).Piece(i).CaptionCenter.Position
                                    End With

                                End With
                                PCE.Value = PV
                            Else
                                Dim PCE As KnTViewLib.Piece = TView.Items.Item(Row).Pieces.AddFromTemplate(1)
                                Dim prgrs As KnTViewLib.Progress = PCE.Progresses.Item(1)
                                prgrs.Shape = KnTViewLib.TivBarShape.tivBarShapeRectangle
                                prgrs.PercentTo = 0
                                With PCE
                                    PCE.Start = Data(0).Piece(i).Start
                                    PCE.Finish = Data(0).Piece(i).Finish
                                    PCE.BarShape.Fill.BackColor = Data(0).Piece(i).PieceColor
                                    PCE.Tunnel = Data(0).Piece(i).Tunnel
                                    PCE.Weight = Data(0).Piece(i).LockPiece

                                    Dim PV As New PieceValueCollection
                                    PV.CaptionLeft = Data(0).Piece(i).CaptionLeft.Text
                                    PV.CaptionCenter = Data(0).Piece(i).CaptionCenter.Text
                                    PV.CaptionRight = Data(0).Piece(i).CaptionRight.Text
                                    With .Captions.Item(1)
                                        .Color = Data(0).Piece(i).CaptionLeft.ForeColor
                                        .Text = Data(0).Piece(i).CaptionLeft.Text
                                        .HorAlign = Data(0).Piece(i).CaptionLeft.HAlign
                                        .VerAlign = Data(0).Piece(i).CaptionLeft.VAlign
                                        .Position = Data(0).Piece(i).CaptionLeft.Position
                                    End With
                                    With .Captions.Item(2)
                                        .Color = Data(0).Piece(i).CaptionCenter.ForeColor
                                        .Text = Data(0).Piece(i).CaptionCenter.Text
                                        .HorAlign = Data(0).Piece(i).CaptionCenter.HAlign
                                        .VerAlign = Data(0).Piece(i).CaptionCenter.VAlign
                                        .Position = Data(0).Piece(i).CaptionCenter.Position
                                    End With
                                    With .Captions.Item(3)
                                        .Color = Data(0).Piece(i).CaptionRight.ForeColor
                                        .Text = Data(0).Piece(i).CaptionRight.Text
                                        .HorAlign = Data(0).Piece(i).CaptionRight.HAlign
                                        .VerAlign = Data(0).Piece(i).CaptionRight.VAlign
                                        .Position = Data(0).Piece(i).CaptionRight.Position
                                    End With

                                    If Not IsNothing(Data(0).Piece(i).ProgressBar) Then
                                        PCE.Progresses.Item(1).Shape = Data(0).Piece(i).ProgressBar.ProgressType
                                        PCE.Progresses.Item(1).PercentTo = Data(0).Piece(i).ProgressBar.ProgressPercent
                                        PCE.Progresses.Item(1).Fill.BackColor = Data(0).Piece(i).ProgressBar.ProgressColor
                                        PCE.Progresses.Item(1).Key = ""
                                        PCE.Progresses.Item(1).Key = Data(0).Piece(i).ProgressBar.ProgressDisplay
                                    End If


                                    Dim DS As Date = Data(0).Piece(i).Start
                                    Dim DE As Date = DateAdd(DateInterval.Day, -1, Data(0).Piece(i).Finish)
                                    If DS <> DE Then
                                        .Captions.Item(1).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionLeft, DS), DS, DE)
                                        .Captions.Item(2).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                                    Else
                                        .Captions.Item(1).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                                        .Captions.Item(2).Text = ""
                                    End If
                                    If PCE.Progresses.Item(1).Key = "1" Then
                                        If PCE.Progresses.Item(1).PercentTo > 0 Then
                                            .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE) & String.Format("({0}%)", PCE.Progresses.Item(1).PercentTo * 100)
                                        Else
                                            .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                                        End If
                                    Else
                                        .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                                    End If
                                    PCE.Value = PV
                                End With
                            End If

                        Next

                        Dim _Index As Integer = _StartRow + 1 '行番号

                        '関係線
                        For i As Integer = 0 To Data(0).RelatedLine.Count - 1
                            With Data(0).RelatedLine(i)
                                Dim pce As KnTViewLib.Piece = TView.Items.Item(_Index + .FromRowIndex).Pieces.Item(.FromColIndex)
                                Dim pce2 As KnTViewLib.Piece = TView.Items.Item(_Index + .ToRowIndex).Pieces.Item(.ToColIndex)
                                Dim Style As Integer = .RelatedStyle
                                Dim RL As KnTViewLib.RelatedLine = AddRelatedLine(pce, pce2, Style)
                                If Data(0).RelatedLine(i).RelatedLineStyle > 0 Then
                                    RL.Line.Style = Data(0).RelatedLine(i).RelatedLineStyle
                                Else
                                    RL.Line.Style = 1
                                End If
                            End With

                        Next

                        'バルーン
                        For i As Integer = 0 To Data(0).Balloon.Count - 1
                            Dim r As Integer = _Index + Data(0).Balloon(i).RowIndex
                            Dim c As Integer = Data(0).Balloon(i).ColIndex
                            Dim pce As KnTViewLib.Piece = TView.Items.Item(r).Pieces.Item(c)
                            With pce.Balloons
                                Dim BL As KnTViewLib.Balloon = .Add(, )
                                BL.PosRelPoint.X = Data(0).Balloon(i).Pont.X
                                BL.PosRelPoint.Y = Data(0).Balloon(i).Pont.Y
                                BL.AnchorPoint.X = Data(0).Balloon(i).AnchorPoint.X
                                BL.AnchorPoint.Y = Data(0).Balloon(i).AnchorPoint.Y
                                BL.AnchorRelPoint.X = Data(0).Balloon(i).AnchorRelPoint.X
                                BL.AnchorRelPoint.Y = Data(0).Balloon(i).AnchorRelPoint.Y

                                BL.BalloonShape.Fill.BackColor = Data(0).Balloon(i).BackColor
                                BL.BalloonShape.Shape = Data(0).Balloon(i).Style

                                BL.Caption.Color = Data(0).Balloon(i).Caption.ForeColor
                                BL.Caption.Text = Data(0).Balloon(i).Caption.Text
                                BL.Caption.HorAlign = Data(0).Balloon(i).Caption.HAlign
                                BL.Caption.VerAlign = Data(0).Balloon(i).Caption.VAlign

                                BL.BalloonShape.BeakBase = Data(0).Balloon(i).BalloonShape.BeakBase
                                BL.BalloonShape.Height = Data(0).Balloon(i).BalloonShape.Height
                                BL.BalloonShape.Width = Data(0).Balloon(i).BalloonShape.Width
                            End With
                        Next

                        'セル
                        For i As Integer = 0 To Data(0).HeaderCell.Count - 1
                            Dim r As Integer = Data(0).HeaderCell(i).RowIndex + _Index
                            Dim c As Integer = Data(0).HeaderCell(i).ColIndex
                            If c <= TView.ColumnHeaders.Count Then
                                With TView.Cell(r, c)
                                    Dim _C As New CellTagCollection
                                    _C.Caption = Data(0).HeaderCell(i).Text
                                    .Value = Data(0).HeaderCell(i).Text
                                    .HorAlign = Data(0).HeaderCell(i).HAlign
                                    .VerAlign = Data(0).HeaderCell(i).VAlign
                                    .Fill.BackColor = Data(0).HeaderCell(i).BackColor
                                    .Color = Data(0).HeaderCell(i).ForeColor

                                    If Data(0).HeaderCell(i).IsHidden Then
                                        .Fill.BackColor = ConvertColorValue(SystemColors.Control)
                                        '.Tag = "HIDDEN"
                                        _C.IsHidden = True
                                    Else
                                        '.Tag = ""
                                        _C.IsHidden = False
                                    End If
                                    .Tag = CellTagConvert(_C)
                                End With
                            End If
                        Next
                    End If
                    Call CellDateRefresh()
                    Logs.PutInformation("データマージ完了", _WorkFileName)
                    FR.Edited = True
                    FrmParent.LblMessage.Text = "データマージ完了"
                Catch ex As Exception
                    Logs.PutErrorEx("データ読込に失敗しました", ex, True)
                End Try
            End If
        End If

    End Sub
    ''' <summary>
    ''' インポートクリップボードメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMNO_Import_Clip_Click(sender As Object, e As EventArgs) Handles RMNO_Import_Clip.Click
        Call RadialMenuHide()
        Call Import_Clip()
    End Sub
    ''' <summary>
    ''' インポートCSVメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMNO_Import_CSV_Click(sender As Object, e As EventArgs) Handles RMNO_Import_CSV.Click
        Call RadialMenuHide()
        Call Import_CSV()
    End Sub
    ''' <summary>
    ''' インポートマージメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RMNO_Import_Merge_Click(sender As Object, e As EventArgs) Handles RMNO_Import_Merge.Click
        Call RadialMenuHide()
        Call MergeData()
    End Sub
#End Region

#Region "UNDO関係"
    ''' <summary>
    ''' UNDO用データ
    ''' </summary>
    ''' <remarks></remarks>
    Dim _UndoDatas As New List(Of WindyDataCollection)
    ''' <summary>
    ''' UNDO有効・無効
    ''' </summary>
    ''' <remarks></remarks>
    Public EnableUndo As Boolean = False
    Private Sub FR_EditStatusChanged(Edited As Boolean) Handles FR.EditStatusChanged
        If EnableUndo Then
            EnableUndo = False
            Call UndoGetData()
            EnableUndo = True
        End If
    End Sub
    ''' <summary>
    ''' TODO:(PUB)UNDOデータ保存
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UndoGetData()
        If _UndoDatas.Count > 50 Then
            'UNDOデータが50件を越えたら古いデータから削除
            For i = 1 To _UndoDatas.Count - 50
                _UndoDatas.RemoveAt(0)
            Next
        End If

        Call SetUndoData()
        FrmParent.ToolButton_Undo.Enabled = (_UndoDatas.Count > 1)
        FrmParent.LblUndoLevel.Text = _UndoDatas.Count

    End Sub
    ''' <summary>
    ''' TODO:UNDO実行
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UndoExecute()
        If _UndoDatas.Count > 0 Then
            EnableUndo = False
            Call RowDeleteAll() '一旦全行を削除
            Call ColumnDeleteAll() '一旦全列を削除

            Call GetUndoData()
            _UndoDatas.RemoveAt(_UndoDatas.Count - 1) 'データを１つ減らす

            If _UndoDatas.Count = 0 Then
                Call UndoGetData()
                FrmParent.ToolButton_Undo.Enabled = False
            Else
                FrmParent.ToolButton_Undo.Enabled = True
            End If
            FrmParent.LblMessage.Text = "元に戻しました"
            FrmParent.LblUndoLevel.Text = _UndoDatas.Count
            EnableUndo = True
        End If
    End Sub
    ''' <summary>
    ''' 保存中UNDOデータをクリアする
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UndoClear()
        _UndoDatas.Clear()
        Call UndoGetData()
        EnableUndo = True
    End Sub
    ''' <summary>
    ''' UNDO用データを保存する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetUndoData()
        Try
            Dim Data As New WindyDataCollection
            Data.Title = _Title
            Data.Owner = _Owner
            Data.IsExclusion = _IsExclusion
            Data.ExclusionPassword = _ExclusionPassword
            Data.LoadLock = _LoadLock
            Data.RowCount = TView.Items.Count
            Data.ColCount = TView.ColumnHeaders.Count
            Data.RowHeight = TView.ItemHeight
            Data.Zoom = TView.TimeScale.Medium.Interval
            Data.PieceCenterHeight = TView.PieceCenterHeight
            Data.PieceLayout = TView.PieceLayout
            Data.ViewTopTime = TView.ViewTopTime.ToString
            Data.IsWaterFall = _IsWaterFall
            Data.IsWaterFallLock = _IsWaterFallLock
            Data.CellDateFormat = _CellDateFormat
            Data.NACellValue = _NACellValue
            Data.IndentLevel = _IndentLevel

            '作業履歴
            For Each Item As WorkHistoryCollection In _WorkHistory
                Data.WorkHistory.Add(Item)
            Next

            For Each Item As SpecialTimeCollection In _SpecialTimeData
                Dim S As New SpecialTimeCollection
                S.Start = Item.Start
                S.Finish = Item.Finish
                S.CellText = Item.CellText
                S.CellColor = Item.CellColor
                S.IsTunnel = Item.IsTunnel
                Data.SpecialTime.Add(S)
            Next

            'カラムヘッダ
            For Index As Integer = 1 To TView.ColumnHeaders.Count
                Dim H As New HeaderCollection
                H.ColIndex = Index
                H.Text = TView.ColumnHeaders.Item(Index).Text
                H.HAlign = TView.ColumnHeaders.Item(Index).HorAlign
                H.VAlign = TView.ColumnHeaders.Item(Index).VerAlign
                H.Width = TView.ColumnHeaders.Item(Index).Width
                H.CellMerge = TView.ColumnHeaders.Item(Index).MergeMode
                H.IsHidden = TView.ColumnHeaders.Item(Index).Hidden
                Data.Header.Add(H)
            Next

            For Index As Integer = 1 To TView.Items.Count
                Dim H As New RowAttribCollection
                H.RowIndex = Index
                H.BackColor = TView.Items.Item(Index).PiecePane.Fill.BackColor
                H.IsHidden = TView.Items.Item(Index).Hidden
                Data.RowAttrib.Add(H)
            Next

            'マスタピース
            If Not IsNothing(_MasterPiece) AndAlso _MasterPiece.PieceColor <> 0 Then
                Dim MItm As New PieceCollection
                MItm.RowIndex = 0 : MItm.ColIndex = 0
                'Dim MPCE As KnTViewLib.Piece = _MasterPiece
                MItm.Start = _MasterPiece.Start
                If Not IsDBNull(_MasterPiece.Finish) Then
                    MItm.Finish = _MasterPiece.Finish
                End If
                MItm.PieceColor = _MasterPiece.PieceColor
                MItm.Shape = _MasterPiece.Shape
                MItm.ShapeName = _MasterPiece.ShapeName
                MItm.Tunnel = _MasterPiece.Tunnel
                MItm.LockPiece = _MasterPiece.LockPiece

                Dim MItmL As New CaptionCollection
                Dim MItmC As New CaptionCollection
                Dim MItmR As New CaptionCollection
                With _MasterPiece
                    With .CaptionLeft
                        MItmL.ForeColor = .ForeColor
                        MItmL.HAlign = .HAlign
                        MItmL.VAlign = .VAlign
                        MItmL.Position = .Position
                        MItmL.Text = .Text
                        MItm.CaptionLeft = MItmL
                    End With
                    With .CaptionCenter
                        MItmC.ForeColor = .ForeColor
                        MItmC.HAlign = .HAlign
                        MItmC.VAlign = .VAlign
                        MItmC.Position = .Position
                        MItmC.Text = .Text
                        MItm.CaptionCenter = MItmC
                    End With
                    With .CaptionRight
                        MItmR.ForeColor = .ForeColor
                        MItmR.HAlign = .HAlign
                        MItmR.VAlign = .VAlign
                        MItmR.Position = .Position
                        MItmR.Text = .Text
                        MItm.CaptionRight = MItmR
                    End With
                    'End If

                    MItm.CaptionLeft = MItmL
                    MItm.CaptionCenter = MItmC
                    MItm.CaptionRight = MItmR

                End With
                'If MPCE.Progresses.Count > 0 Then
                Dim Prg As New ProgressBarCollection
                Prg.ProgressType = _MasterPiece.ProgressBar.ProgressType
                Prg.ProgressPercent = _MasterPiece.ProgressBar.ProgressPercent
                Prg.ProgressColor = _MasterPiece.ProgressBar.ProgressColor
                Prg.ProgressDisplay = _MasterPiece.ProgressBar.ProgressDisplay
                Prg.IsNotUseProgress = _MasterPiece.ProgressBar.IsNotUseProgress
                MItm.ProgressBar = Prg
                'End If
                Data.MasterPiece = MItm
            End If

            'テンプレートピース
            If Not IsNothing(_TemplatePiece) AndAlso _TemplatePiece.PieceColor <> 0 Then
                Dim MItm As New PieceCollection
                MItm.RowIndex = 0 : MItm.ColIndex = 0
                MItm.Start = _TemplatePiece.Start
                If Not IsDBNull(_TemplatePiece.Finish) Then
                    MItm.Finish = _TemplatePiece.Finish
                End If
                MItm.PieceColor = _TemplatePiece.PieceColor
                MItm.Shape = _TemplatePiece.Shape
                MItm.ShapeName = _TemplatePiece.ShapeName
                MItm.Tunnel = _TemplatePiece.Tunnel
                MItm.LockPiece = _TemplatePiece.LockPiece

                Dim MItmL As New CaptionCollection
                Dim MItmC As New CaptionCollection
                Dim MItmR As New CaptionCollection
                With _TemplatePiece

                    'ピース
                    With .CaptionLeft
                        MItmL.ForeColor = .ForeColor
                        MItmL.HAlign = .HAlign
                        MItmL.VAlign = .VAlign
                        MItmL.Position = .Position
                        MItmL.Text = .Text
                        MItm.CaptionLeft = MItmL
                    End With
                    With .CaptionCenter
                        MItmC.ForeColor = .ForeColor
                        MItmC.HAlign = .HAlign
                        MItmC.VAlign = .VAlign
                        MItmC.Position = .Position
                        MItmC.Text = .Text
                        MItm.CaptionCenter = MItmC
                    End With
                    With .CaptionRight
                        MItmR.ForeColor = .ForeColor
                        MItmR.HAlign = .HAlign
                        MItmR.VAlign = .VAlign
                        MItmR.Position = .Position
                        MItmR.Text = .Text
                        MItm.CaptionRight = MItmR
                    End With
                    'End If

                    MItm.CaptionLeft = MItmL
                    MItm.CaptionCenter = MItmC
                    MItm.CaptionRight = MItmR

                End With
                'If MPCE.Progresses.Count > 0 Then
                Dim Prg As New ProgressBarCollection
                Prg.ProgressType = _TemplatePiece.ProgressBar.ProgressType
                Prg.ProgressPercent = _TemplatePiece.ProgressBar.ProgressPercent
                Prg.ProgressColor = _TemplatePiece.ProgressBar.ProgressColor
                Prg.ProgressDisplay = _TemplatePiece.ProgressBar.ProgressDisplay
                Prg.IsNotUseProgress = _TemplatePiece.ProgressBar.IsNotUseProgress
                MItm.ProgressBar = Prg
                'End If
                Data.TemplatePiece = MItm
            End If

            If TView.Items.Count > 0 Then
                For Row As Integer = 1 To TView.Items.Count
                    For Index As Integer = 1 To TView.ColumnHeaders.Count
                        Dim _T As CellTagCollection = CellTagConvert(TView.Cell(Row, Index).Tag)
                        Dim H As New HeaderCellCollection
                        H.RowIndex = Row : H.ColIndex = Index
                        'H.Text = TView.Cell(Row, Index).Value
                        H.Text = _T.Caption
                        H.HAlign = TView.Cell(Row, Index).HorAlign
                        H.VAlign = TView.Cell(Row, Index).VerAlign
                        H.BackColor = TView.Cell(Row, Index).Fill.BackColor
                        H.ForeColor = TView.Cell(Row, Index).Color
                        'If TView.Cell(Row, Index).Tag = "HIDDEN" Then
                        '    H.IsHidden = True
                        'Else
                        '    H.IsHidden = False
                        'End If
                        H.IsHidden = _T.IsHidden
                        H.IndentLevel = TView.Cell(Row, Index).IndentLevel
                        Data.HeaderCell.Add(H)
                    Next

                    For Index As Integer = 1 To TView.Items.Item(Row).Pieces.Count
                        'Hidden設定されているピースはマスターピースなので、それは保存しない
                        If Not TView.Items.Item(Row).Pieces.Item(Index).Hidden Then
                            Dim Itm As New PieceCollection
                            Itm.RowIndex = Row : Itm.ColIndex = Index
                            Dim PCE As KnTViewLib.Piece = TView.Items.Item(Row).Pieces.Item(Index)
                            Itm.Start = PCE.Start
                            If Not PCE.Finish Is System.DBNull.Value Then
                                Itm.Finish = PCE.Finish
                            End If
                            Itm.PieceColor = PCE.BarShape.Fill.BackColor
                            Itm.Shape = PCE.StartShape.Shape
                            Itm.ShapeName = PCE.Tag

                            ''''''
                            Itm.LockPiece = PCE.Weight

                            Itm.Tunnel = PCE.Tunnel

                            Dim ItmL As New CaptionCollection
                            Dim ItmC As New CaptionCollection
                            Dim ItmR As New CaptionCollection
                            With PCE.Captions
                                Dim PV As PieceValueCollection = PCE.Value
                                If PCE.StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                                    'マイルストーン
                                    With .Item(1)
                                        ItmL.ForeColor = .Color
                                        ItmL.HAlign = .HorAlign
                                        ItmL.VAlign = .VerAlign
                                        ItmL.Position = .Position
                                        ItmL.Text = PV.CaptionLeft
                                        Itm.CaptionLeft = ItmL
                                    End With
                                    With .Item(2)
                                        ItmC.ForeColor = .Color
                                        ItmC.HAlign = .HorAlign
                                        ItmC.VAlign = .VerAlign
                                        ItmC.Position = .Position
                                        ItmC.Text = PV.CaptionCenter
                                        Itm.CaptionCenter = ItmC
                                    End With
                                    With .Item(2)
                                        ItmR.ForeColor = .Color
                                        ItmR.HAlign = .HorAlign
                                        ItmR.VAlign = .VerAlign
                                        ItmR.Position = .Position
                                        ItmR.Text = PV.CaptionRight
                                        Itm.CaptionRight = ItmR
                                    End With
                                    Itm.ShapeName = PV.StoneImageKey
                                Else

                                    'ピース
                                    With .Item(1)
                                        ItmL.ForeColor = .Color
                                        ItmL.HAlign = .HorAlign
                                        ItmL.VAlign = .VerAlign
                                        ItmL.Position = .Position
                                        ItmL.Text = PV.CaptionLeft
                                        Itm.CaptionLeft = ItmL
                                    End With
                                    With .Item(2)
                                        ItmC.ForeColor = .Color
                                        ItmC.HAlign = .HorAlign
                                        ItmC.VAlign = .VerAlign
                                        ItmC.Position = .Position
                                        ItmC.Text = PV.CaptionCenter
                                        Itm.CaptionCenter = ItmC
                                    End With
                                    With .Item(3)
                                        ItmR.ForeColor = .Color
                                        ItmR.HAlign = .HorAlign
                                        ItmR.VAlign = .VerAlign
                                        ItmR.Position = .Position
                                        ItmR.Text = PV.CaptionRight
                                        Itm.CaptionRight = ItmR
                                    End With
                                End If

                                Itm.CaptionLeft = ItmL
                                Itm.CaptionCenter = ItmC
                                Itm.CaptionRight = ItmR

                            End With
                            If PCE.Progresses.Count > 0 Then
                                Dim Prg As New ProgressBarCollection
                                Prg.ProgressType = PCE.Progresses.Item(1).Shape
                                Prg.ProgressPercent = PCE.Progresses.Item(1).PercentTo
                                Prg.ProgressColor = PCE.Progresses.Item(1).Fill.BackColor
                                Prg.ProgressDisplay = PCE.Progresses.Item(1).Key
                                Prg.IsNotUseProgress = PCE.Progresses.Item(1).Hidden
                                Itm.ProgressBar = Prg
                            End If
                            Data.Piece.Add(Itm)
                        End If
                    Next

                    For Index As Integer = 1 To TView.Items.Item(Row).Pieces.Count
                        Dim PCE As KnTViewLib.Piece = TView.Items.Item(Row).Pieces.Item(Index)
                        For ItmIndex As Integer = 1 To PCE.RelatedLines.Count
                            If PCE.RelatedLines.Item(ItmIndex).IsConnected Then
                                Dim Itm As New RelatedLineCollection
                                Itm.FromRowIndex = Row : Itm.FromColIndex = Index
                                Itm.ToRowIndex = PCE.RelatedLines.Item(ItmIndex).Relation.ItemIndex
                                Itm.ToColIndex = PCE.RelatedLines.Item(ItmIndex).Relation.Index
                                Itm.RelatedStyle = PCE.RelatedLines.Item(ItmIndex).Style
                                Itm.RelatedLineStyle = PCE.RelatedLines.Item(ItmIndex).Line.Style
                                Data.RelatedLine.Add(Itm)
                            End If
                        Next
                    Next

                    For Index As Integer = 1 To TView.Items.Item(Row).Pieces.Count
                        Dim PCE As KnTViewLib.Piece = TView.Items.Item(Row).Pieces.Item(Index)
                        For ItmIndex As Integer = 1 To PCE.Balloons.Count
                            Dim Itm As New BalloonCollection
                            Itm.RowIndex = Row : Itm.ColIndex = Index
                            Itm.Pont = New Point(PCE.Balloons.Item(ItmIndex).PosRelPoint.X, PCE.Balloons.Item(ItmIndex).PosRelPoint.Y)
                            Itm.AnchorPoint = New Point(PCE.Balloons.Item(ItmIndex).AnchorPoint.X, PCE.Balloons.Item(ItmIndex).AnchorPoint.Y)
                            Itm.AnchorRelPoint = New Point(PCE.Balloons.Item(ItmIndex).AnchorRelPoint.X, PCE.Balloons.Item(ItmIndex).AnchorRelPoint.Y)
                            Itm.BackColor = PCE.Balloons.Item(ItmIndex).BalloonShape.Fill.BackColor
                            'Itm.ForeColor = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).BalloonShape.Fill.ForeColor
                            Itm.Style = PCE.Balloons.Item(ItmIndex).BalloonShape.Shape

                            Dim ItmC As New CaptionCollection
                            ItmC.ForeColor = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).Caption.Color
                            ItmC.Text = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).Caption.Text
                            ItmC.HAlign = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).Caption.HorAlign
                            ItmC.VAlign = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).Caption.VerAlign
                            Itm.Caption = ItmC

                            Dim ItmB As New BalloonShapeCollection
                            ItmB.BeakBase = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).BalloonShape.BeakBase
                            ItmB.Height = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).BalloonShape.Height
                            ItmB.Width = TView.Items.Item(Row).Pieces.Item(Index).Balloons.Item(ItmIndex).BalloonShape.Width
                            Itm.BalloonShape = ItmB
                            Data.Balloon.Add(Itm)
                        Next
                    Next
                Next
            End If

            _UndoDatas.Add(Data)

        Catch ex As Exception
            Logs.PutError("UNDOデータ取得失敗")
        End Try

    End Sub
    ''' <summary>
    ''' UNDOを実行する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetUndoData()
        Try
            Dim Data As WindyDataCollection = _UndoDatas(_UndoDatas.Count - 1)

            _Title = Data.Title
            _Owner = Data.Owner
            _IsExclusion = Data.IsExclusion
            _ExclusionPassword = Data.ExclusionPassword
            _LoadLock = Data.LoadLock
            _IsWaterFall = Data.IsWaterFall
            _IsWaterFallLock = Data.IsWaterFallLock
            _CellDateFormat = Data.CellDateFormat
            _NACellValue = Data.NACellValue

            Select Case Data.IndentLevel
                Case Is < 1 : _IndentLevel = 1
                Case Is > 30 : _IndentLevel = 30
                Case Else
                    _IndentLevel = Data.IndentLevel
            End Select

            '作業履歴
            For i As Integer = 0 To Data.WorkHistory.Count - 1
                Dim W As New WorkHistoryCollection
                W.WorkTime = Data.WorkHistory(i).WorkTime
                W.WorkerName = Data.WorkHistory(i).WorkerName
                W.WorkNote = Data.WorkHistory(i).WorkNote
                _WorkHistory.Add(W)
            Next

            For i As Integer = 1 To Data.RowCount
                Call RowAdd(enumAddRow.ToBottom)
            Next
            'For i As Integer = 1 To Data.ColCount - 1
            For i As Integer = 1 To Data.ColCount
                Call ColumnAdd(enumColumnAdd.ToLast)
            Next

            TView.ItemHeightMode = KnTViewLib.TivMode.tivManual
            TView.ItemHeight = Data.RowHeight
            _ViewTopDate = Data.ViewTopTime
            TView.TimeScale.Medium.Interval = Data.Zoom
            TView.PieceCenterHeight = Data.PieceCenterHeight
            TView.PieceLayout = Data.PieceLayout

            'ヘッダー
            For i As Integer = 0 To Data.Header.Count - 1
                Dim c As Integer = Data.Header(i).ColIndex
                With TView.ColumnHeaders.Item(c)
                    .Text = Data.Header(i).Text
                    .HorAlign = Data.Header(i).HAlign
                    .VerAlign = Data.Header(i).VAlign
                    .Width = Data.Header(i).Width
                    .MergeMode = Data.Header(i).CellMerge
                    .Hidden = Data.Header(i).IsHidden
                    .IndentWidth = _IndentLevel
                End With
            Next

            'セル
            For i As Integer = 0 To Data.HeaderCell.Count - 1
                Dim r As Integer = Data.HeaderCell(i).RowIndex
                Dim c As Integer = Data.HeaderCell(i).ColIndex
                With TView.Cell(r, c)
                    Dim _C As New CellTagCollection
                    _C.Caption = Data.HeaderCell(i).Text
                    .Value = Data.HeaderCell(i).Text
                    .HorAlign = Data.HeaderCell(i).HAlign
                    .VerAlign = Data.HeaderCell(i).VAlign
                    .Fill.BackColor = Data.HeaderCell(i).BackColor
                    .Color = Data.HeaderCell(i).ForeColor

                    If Data.HeaderCell(i).IsHidden Then
                        .Fill.BackColor = ConvertColorValue(SystemColors.Control)
                        '.Tag = "HIDDEN"
                        _C.IsHidden = True
                    Else
                        '.Tag = ""
                        _C.IsHidden = False
                    End If
                    If Data.HeaderCell(i).IndentLevel = 0 Then
                        .IndentLevel = 1
                    Else
                        .IndentLevel = Data.HeaderCell(i).IndentLevel
                    End If

                    Call Cell_SetIntendIcon(TView.Cell(r, c)) 'インデントイメージの表示・非表示
                    .Tag = CellTagConvert(_C)
                End With
            Next

            '特別時間帯
            _SpecialTimeData.Clear()
            _SpecialTimeData.AddRange(Data.SpecialTime)
            If _SpecialTimeData.Count > 0 Then
                Dim STS As KnTViewLib.SpecialTimeSet = TView.SpecialTimeSets.Item(1)
                For Each Item As SpecialTimeCollection In _SpecialTimeData
                    Dim spt As KnTViewLib.SpecialTime = STS.SpecialTimes.Add(, )
                    spt.ZOrder = 0
                    spt.Fill.BkMode = KnTViewLib.TivBkMode.tivOpaque
                    spt.Fill.Pattern = KnTViewLib.TivFillPattern.tivPatternNull
                    spt.Fill.BackColor = Item.CellColor
                    spt.Pattern = KnTViewLib.TivSpecialTime.tivSpecialTimeDirect
                    spt.Start = String.Format("{0:yyyy/MM/dd} 00:00:00", Item.Start)
                    spt.Finish = String.Format("{0:yyyy/MM/dd} 23:59:59", Item.Finish)
                    spt.Tunnelable = Item.IsTunnel
                Next
            End If

            '行色
            For i As Integer = 0 To Data.RowAttrib.Count - 1
                Dim c As Integer = Data.RowAttrib(i).RowIndex
                TView.Items.Item(c).PiecePane.Fill.BackColor = Data.RowAttrib(i).BackColor
                TView.Items.Item(c).Hidden = Data.RowAttrib(i).IsHidden
            Next

            'ピース／ストーン
            For i As Integer = 0 To Data.Piece.Count - 1
                Dim r As Integer = Data.Piece(i).RowIndex
                If Data.Piece(i).Shape = 11 Then
                    Dim PCE As KnTViewLib.Piece = TView.Items.Item(Data.Piece(i).RowIndex).Pieces.AddFromTemplate(2)
                    Dim PV As New PieceValueCollection
                    With PCE

                        PV.CaptionLeft = Data.Piece(i).CaptionLeft.Text
                        PV.CaptionCenter = Data.Piece(i).CaptionCenter.Text
                        PV.CaptionRight = Data.Piece(i).CaptionRight.Text
                        PV.StoneImageKey = Data.Piece(i).ShapeName

                        PCE.Start = Data.Piece(i).Start
                        'pce.Finish = Data(0).Piece(i).Finish

                        PCE.Weight = Data.Piece(i).LockPiece

                        If TView.ImageLists.Count > 0 Then
                            PCE.StartShape.Shape = Data.Piece(i).Shape
                            PCE.StartShape.Image("ImageList", Data.Piece(i).ShapeName)
                        End If

                        'PCE.Tag = Data(0).Piece(i).ShapeName
                        With .Captions.Item(1)
                            .Color = Data.Piece(i).CaptionLeft.ForeColor
                            .Text = PV.CaptionCenter
                            .HorAlign = Data.Piece(i).CaptionLeft.HAlign
                            .VerAlign = Data.Piece(i).CaptionLeft.VAlign
                            .Position = Data.Piece(i).CaptionLeft.Position
                        End With
                        With .Captions.Item(2)
                            .Color = Data.Piece(i).CaptionCenter.ForeColor
                            .Text = ConvCaptionDate(PV.CaptionLeft, PCE.Start)
                            .HorAlign = Data.Piece(i).CaptionCenter.HAlign
                            .VerAlign = Data.Piece(i).CaptionCenter.VAlign
                            .Position = Data.Piece(i).CaptionCenter.Position
                        End With

                    End With
                    PCE.Value = PV
                Else
                    Dim PCE As KnTViewLib.Piece = TView.Items.Item(Data.Piece(i).RowIndex).Pieces.AddFromTemplate(1)
                    Dim prgrs As KnTViewLib.Progress = PCE.Progresses.Item(1)
                    prgrs.Shape = KnTViewLib.TivBarShape.tivBarShapeRectangle
                    prgrs.PercentTo = 0
                    With PCE
                        PCE.Start = Data.Piece(i).Start
                        PCE.Finish = Data.Piece(i).Finish
                        PCE.BarShape.Fill.BackColor = Data.Piece(i).PieceColor
                        PCE.Tunnel = Data.Piece(i).Tunnel
                        '''''
                        PCE.Weight = Data.Piece(i).LockPiece

                        Dim PV As New PieceValueCollection
                        PV.CaptionLeft = Data.Piece(i).CaptionLeft.Text
                        PV.CaptionCenter = Data.Piece(i).CaptionCenter.Text
                        PV.CaptionRight = Data.Piece(i).CaptionRight.Text
                        With .Captions.Item(1)
                            .Color = Data.Piece(i).CaptionLeft.ForeColor
                            '.Text = Data(0).Piece(i).CaptionLeft.Text
                            .HorAlign = Data.Piece(i).CaptionLeft.HAlign
                            .VerAlign = Data.Piece(i).CaptionLeft.VAlign
                            .Position = Data.Piece(i).CaptionLeft.Position
                        End With
                        With .Captions.Item(2)
                            .Color = Data.Piece(i).CaptionCenter.ForeColor
                            '.Text = Data(0).Piece(i).CaptionCenter.Text
                            .HorAlign = Data.Piece(i).CaptionCenter.HAlign
                            .VerAlign = Data.Piece(i).CaptionCenter.VAlign
                            .Position = Data.Piece(i).CaptionCenter.Position
                        End With
                        With .Captions.Item(3)
                            .Color = Data.Piece(i).CaptionRight.ForeColor
                            '.Text = Data(0).Piece(i).CaptionRight.Text
                            .HorAlign = Data.Piece(i).CaptionRight.HAlign
                            .VerAlign = Data.Piece(i).CaptionRight.VAlign
                            .Position = Data.Piece(i).CaptionRight.Position
                        End With

                        If Not IsNothing(Data.Piece(i).ProgressBar) Then
                            PCE.Progresses.Item(1).Shape = Data.Piece(i).ProgressBar.ProgressType
                            PCE.Progresses.Item(1).PercentTo = Data.Piece(i).ProgressBar.ProgressPercent
                            PCE.Progresses.Item(1).Fill.BackColor = Data.Piece(i).ProgressBar.ProgressColor
                            PCE.Progresses.Item(1).Key = ""
                            PCE.Progresses.Item(1).Key = Data.Piece(i).ProgressBar.ProgressDisplay
                            PCE.Progresses.Item(1).Hidden = Data.Piece(i).ProgressBar.IsNotUseProgress
                        End If
                        PCE.TunnelShape.Fill.BackColor = Data.Piece(i).PieceColor

                        Dim DS As Date = Data.Piece(i).Start
                        Dim DE As Date = DateAdd(DateInterval.Day, -1, Data.Piece(i).Finish)

                        If DS <> DE Then
                            .Captions.Item(1).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionLeft, DS), DS, DE)
                            .Captions.Item(2).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                        Else
                            .Captions.Item(1).Text = ConvCaptionDateCount(PV.CaptionCenter, DS, DE)
                            .Captions.Item(2).Text = ""
                        End If
                        If PCE.Progresses.Item(1).Key = "1" AndAlso PCE.Progresses.Item(1).Hidden = False Then
                            If PCE.Progresses.Item(1).PercentTo > 0 Then
                                .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE) & String.Format("({0}%)", PCE.Progresses.Item(1).PercentTo * 100)
                            Else
                                .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                            End If
                        Else
                            .Captions.Item(3).Text = ConvCaptionDateCount(ConvCaptionDate(PV.CaptionRight, DE), DS, DE)
                        End If
                        PCE.Value = PV
                    End With
                End If

            Next

            '関係線
            For i As Integer = 0 To Data.RelatedLine.Count - 1
                Dim pce As KnTViewLib.Piece = TView.Items.Item(Data.RelatedLine(i).FromRowIndex).Pieces.Item(Data.RelatedLine(i).FromColIndex)
                Dim pce2 As KnTViewLib.Piece = TView.Items.Item(Data.RelatedLine(i).ToRowIndex).Pieces.Item(Data.RelatedLine(i).ToColIndex)
                Dim Style As Integer = Data.RelatedLine(i).RelatedStyle
                Dim RL As KnTViewLib.RelatedLine = AddRelatedLine(pce, pce2, Style)
                If Data.RelatedLine(i).RelatedLineStyle > 0 Then
                    RL.Line.Style = Data.RelatedLine(i).RelatedLineStyle
                Else
                    RL.Line.Style = 1
                End If
            Next

            'バルーン
            For i As Integer = 0 To Data.Balloon.Count - 1
                Dim r As Integer = Data.Balloon(i).RowIndex
                Dim c As Integer = Data.Balloon(i).ColIndex
                Dim pce As KnTViewLib.Piece = TView.Items.Item(r).Pieces.Item(c)
                With pce.Balloons
                    Dim BL As KnTViewLib.Balloon = .Add(, )
                    BL.PosRelPoint.X = Data.Balloon(i).Pont.X
                    BL.PosRelPoint.Y = Data.Balloon(i).Pont.Y
                    BL.AnchorPoint.X = Data.Balloon(i).AnchorPoint.X
                    BL.AnchorPoint.Y = Data.Balloon(i).AnchorPoint.Y
                    BL.AnchorRelPoint.X = Data.Balloon(i).AnchorRelPoint.X
                    BL.AnchorRelPoint.Y = Data.Balloon(i).AnchorRelPoint.Y

                    BL.BalloonShape.Fill.BackColor = Data.Balloon(i).BackColor
                    BL.BalloonShape.Shape = Data.Balloon(i).Style

                    BL.Caption.Color = Data.Balloon(i).Caption.ForeColor
                    BL.Caption.Text = Data.Balloon(i).Caption.Text
                    BL.Caption.HorAlign = Data.Balloon(i).Caption.HAlign
                    BL.Caption.VerAlign = Data.Balloon(i).Caption.VAlign

                    BL.BalloonShape.BeakBase = Data.Balloon(i).BalloonShape.BeakBase
                    BL.BalloonShape.Height = Data.Balloon(i).BalloonShape.Height
                    BL.BalloonShape.Width = Data.Balloon(i).BalloonShape.Width
                End With
            Next

            'マスタピース
            If Not IsNothing(Data.MasterPiece) AndAlso Data.MasterPiece.PieceColor <> 0 Then
                With _MasterPiece
                    _MasterPiece.Start = Data.MasterPiece.Start
                    _MasterPiece.Finish = Data.MasterPiece.Finish
                    _MasterPiece.PieceColor = Data.MasterPiece.PieceColor
                    _MasterPiece.Tunnel = Data.MasterPiece.Tunnel

                    Dim PV As New PieceValueCollection
                    PV.CaptionLeft = Data.MasterPiece.CaptionLeft.Text
                    PV.CaptionCenter = Data.MasterPiece.CaptionCenter.Text
                    PV.CaptionRight = Data.MasterPiece.CaptionRight.Text

                    Dim TL As New CaptionCollection
                    Dim TC As New CaptionCollection
                    Dim TR As New CaptionCollection
                    With TL
                        .ForeColor = Data.MasterPiece.CaptionLeft.ForeColor
                        .HAlign = Data.MasterPiece.CaptionLeft.HAlign
                        .VAlign = Data.MasterPiece.CaptionLeft.VAlign
                        .Position = Data.MasterPiece.CaptionLeft.Position
                    End With
                    With TC
                        .ForeColor = Data.MasterPiece.CaptionCenter.ForeColor
                        .HAlign = Data.MasterPiece.CaptionCenter.HAlign
                        .VAlign = Data.MasterPiece.CaptionCenter.VAlign
                        .Position = Data.MasterPiece.CaptionCenter.Position
                    End With
                    With TR
                        .ForeColor = Data.MasterPiece.CaptionRight.ForeColor
                        .HAlign = Data.MasterPiece.CaptionRight.HAlign
                        .VAlign = Data.MasterPiece.CaptionRight.VAlign
                        .Position = Data.MasterPiece.CaptionRight.Position
                    End With
                    .CaptionLeft = TL
                    .CaptionCenter = TC
                    .CaptionRight = TR

                    If Not IsNothing(Data.MasterPiece.ProgressBar) Then
                        Dim PL As New ProgressBarCollection
                        PL.ProgressType = Data.MasterPiece.ProgressBar.ProgressType
                        PL.ProgressPercent = Data.MasterPiece.ProgressBar.ProgressPercent
                        PL.ProgressColor = Data.MasterPiece.ProgressBar.ProgressColor
                        PL.ProgressDisplay = Data.MasterPiece.ProgressBar.ProgressDisplay
                        PL.IsNotUseProgress = Data.MasterPiece.ProgressBar.IsNotUseProgress
                        _MasterPiece.ProgressBar = PL
                    End If

                End With
            End If
            'テンプレートピース
            If Not IsNothing(Data.TemplatePiece) AndAlso Data.TemplatePiece.PieceColor <> 0 Then
                With _TemplatePiece
                    _TemplatePiece.Start = Data.TemplatePiece.Start
                    _TemplatePiece.Finish = Data.TemplatePiece.Finish
                    _TemplatePiece.PieceColor = Data.TemplatePiece.PieceColor
                    _TemplatePiece.Tunnel = Data.TemplatePiece.Tunnel

                    Dim PV As New PieceValueCollection
                    PV.CaptionLeft = Data.TemplatePiece.CaptionLeft.Text
                    PV.CaptionCenter = Data.TemplatePiece.CaptionCenter.Text
                    PV.CaptionRight = Data.TemplatePiece.CaptionRight.Text

                    Dim TL As New CaptionCollection
                    Dim TC As New CaptionCollection
                    Dim TR As New CaptionCollection
                    With TL
                        .ForeColor = Data.TemplatePiece.CaptionLeft.ForeColor
                        .HAlign = Data.TemplatePiece.CaptionLeft.HAlign
                        .VAlign = Data.TemplatePiece.CaptionLeft.VAlign
                        .Position = Data.TemplatePiece.CaptionLeft.Position
                    End With
                    With TC
                        .ForeColor = Data.TemplatePiece.CaptionCenter.ForeColor
                        .HAlign = Data.TemplatePiece.CaptionCenter.HAlign
                        .VAlign = Data.TemplatePiece.CaptionCenter.VAlign
                        .Position = Data.TemplatePiece.CaptionCenter.Position
                    End With
                    With TR
                        .ForeColor = Data.TemplatePiece.CaptionRight.ForeColor
                        .HAlign = Data.TemplatePiece.CaptionRight.HAlign
                        .VAlign = Data.TemplatePiece.CaptionRight.VAlign
                        .Position = Data.TemplatePiece.CaptionRight.Position
                    End With
                    .CaptionLeft = TL
                    .CaptionCenter = TC
                    .CaptionRight = TR

                    If Not IsNothing(Data.TemplatePiece.ProgressBar) Then
                        Dim PL As New ProgressBarCollection
                        PL.ProgressType = Data.TemplatePiece.ProgressBar.ProgressType
                        PL.ProgressPercent = Data.TemplatePiece.ProgressBar.ProgressPercent
                        PL.ProgressColor = Data.TemplatePiece.ProgressBar.ProgressColor
                        PL.ProgressDisplay = Data.TemplatePiece.ProgressBar.ProgressDisplay
                        PL.IsNotUseProgress = Data.TemplatePiece.ProgressBar.IsNotUseProgress
                        _TemplatePiece.ProgressBar = PL
                    End If

                End With
            End If

            Call CellDateRefresh()
        Catch ex As Exception
            Logs.PutError("UNDOデータ反映失敗")

        End Try
    End Sub
#End Region

 
    Private Sub TView_AfterCellPaneWidthChange(sender As Object, e As AxKnTViewLib._DKnTViewEvents_AfterCellPaneWidthChangeEvent) Handles TView.AfterCellPaneWidthChange

    End Sub

    Private Sub FrmMain_MaximizedBoundsChanged(sender As Object, e As EventArgs) Handles Me.MaximizedBoundsChanged

    End Sub

    Private Sub TView_OLEStartDrag(sender As Object, e As AxKnTViewLib._DKnTViewEvents_OLEStartDragEvent) Handles TView.OLEStartDrag

    End Sub
End Class
''' <summary>
''' ピース作業用コレクション
''' </summary>
''' <remarks></remarks>
Public Class PieceValueCollection
    ''' <summary>
    ''' 左文字
    ''' </summary>
    ''' <remarks></remarks>
    Public CaptionLeft As String
    ''' <summary>
    ''' 中文字
    ''' </summary>
    ''' <remarks></remarks>
    Public CaptionCenter As String
    ''' <summary>
    ''' 右文字
    ''' </summary>
    ''' <remarks></remarks>
    Public CaptionRight As String
    ''' <summary>
    ''' ストーンキー
    ''' </summary>
    ''' <remarks></remarks>
    Public StoneImageKey As String
    Sub New()
        Me.CaptionLeft = ""
        Me.CaptionCenter = ""
        Me.CaptionRight = ""
        Me.StoneImageKey = ""
    End Sub
End Class

#Region "XMLデータエクスポート用"
''' <summary>
''' バルーンデータコレクション
''' </summary>
''' <remarks></remarks>
Public Class BalloonData
    ''' <summary>
    ''' バルーン内容
    ''' </summary>
    ''' <remarks></remarks>
    Public BalloonText As String
End Class
''' <summary>
''' ピースデータコレクション
''' </summary>
''' <remarks></remarks>
Public Class PieceData
    ''' <summary>
    ''' 開始日
    ''' </summary>
    ''' <remarks></remarks>
    Public StartDate As Date
    ''' <summary>
    ''' 終了日
    ''' </summary>
    ''' <remarks></remarks>
    Public FinDate As Date
    ''' <summary>
    ''' ピース内容
    ''' </summary>
    ''' <remarks></remarks>
    Public PieceText As String
    ''' <summary>
    ''' 達成率
    ''' </summary>
    ''' <remarks></remarks>
    Public Progress As String
    ''' <summary>
    ''' バルーンデータ
    ''' </summary>
    ''' <remarks></remarks>
    Public Balloon() As BalloonData
End Class
''' <summary>
''' セルデータコレクション
''' </summary>
''' <remarks></remarks>
Public Class CellData
    ''' <summary>
    ''' セル内容
    ''' </summary>
    ''' <remarks></remarks>
    Public CellText As String
End Class
''' <summary>
''' 行データコレクション
''' </summary>
''' <remarks></remarks>
Public Class RowData
    ''' <summary>
    ''' セルデータ
    ''' </summary>
    ''' <remarks></remarks>
    Public Cell() As CellData
    ''' <summary>
    ''' ピースデータ
    ''' </summary>
    ''' <remarks></remarks>
    Public Piece() As PieceData
End Class
''' <summary>
''' エクスポート用コレクション
''' </summary>
''' <remarks></remarks>
Public Class XMLData
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
    ''' 行コレクションデータ
    ''' </summary>
    ''' <remarks></remarks>
    Public Row() As RowData
End Class
#End Region
Public Class FindItemCollection
    Public Enum EnumItemType
        IsPeacs
        IsStone
        IsBollen
    End Enum
    Public Row As Integer
    Public Col As Integer
    Public Text As String
    Public StartDate As Date
    Public Finish As Date
    Public ItemType As EnumItemType
    Sub New()
        Me.Row = 0
        Me.Col = 0
        Me.Text = ""
        Me.StartDate = Nothing
        Me.Finish = Nothing
        Me.ItemType = EnumItemType.IsStone
    End Sub
End Class
Public Class FindHeaderCollection
    Public Row As Integer
    Public Col As Integer
    Public Text As String
    Sub New()
        Me.Row = 0
        Me.Col = 0
        Me.Text = ""
    End Sub
End Class
