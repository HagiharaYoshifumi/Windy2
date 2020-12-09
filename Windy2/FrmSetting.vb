''' <summary>
''' Windy全体設定
''' </summary>
''' <remarks></remarks>
Public Class FrmSetting
    Dim FC As New ClassFormControl
    Dim _SaturdayColor As UInt32
    Dim _SundayColor As UInt32
    Dim _TodayColor As UInt32
    Dim _TodayDay As Integer = 7
    Dim _StartDay As Integer = 7 '先頭余白日数
    Dim _FinalDay As Integer = 7 '最終余白日数
    Dim _PrintDay As Integer = 7 '印刷余白日数
    Dim _NoHighlight As Boolean = False
    Dim _TabletMode As Boolean = False
    Dim _FontSizePiece As Integer = 9
    Dim _FontSizeCell As Integer = 9
    Dim _FontSizeCellHeader As Integer = 9


    Property DefTunnel() As Boolean
#Region "Property"
    ''' <summary>
    ''' 土曜日表示色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SaturdayColor() As UInt32
        Get
            Return _SaturdayColor
        End Get
        Set(ByVal value As UInt32)
            ColorPicker_Saturday.SelectedColor = ConvertColorValue(value)
        End Set
    End Property
    ''' <summary>
    ''' 日曜日表示色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SundayColor() As UInt32
        Get
            Return _SundayColor
        End Get
        Set(ByVal value As UInt32)
            ColorPicker_Sunday.SelectedColor = ConvertColorValue(value)
        End Set
    End Property
    ''' <summary>
    ''' 本日表示色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property TodayColor() As UInt32
        Get
            Return _TodayColor
        End Get
        Set(ByVal value As UInt32)
            ColorPicker_Today.SelectedColor = ConvertColorValue(value)
        End Set
    End Property
    Property ToDay() As Integer
        Get
            Return _Today
        End Get
        Set(ByVal value As Integer)
            If TxtToDay.Maximum > value Then
                TxtToDay.Value = value
            Else
            End If
        End Set
    End Property
    Property StartDay() As Integer
        Get
            Return _StartDay
        End Get
        Set(ByVal value As Integer)
            TxtStartDay.Value = value
        End Set
    End Property
    Property FinalDay() As Integer
        Get
            Return _FinalDay
        End Get
        Set(ByVal value As Integer)
            TxtFinalDay.Value = value
        End Set
    End Property
    Property NoHighlight() As Boolean
        Get
            Return _NoHighlight
        End Get
        Set(ByVal value As Boolean)
            ChkNoHighlight.Checked = value
        End Set
    End Property
    ''' <summary>
    ''' タブレットモード
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property TabletMode() As Boolean
        Get
            Return _TabletMode
        End Get
        Set(ByVal value As Boolean)
            ChkTabletMode.Checked = value
        End Set
    End Property

    ''' <summary>
    ''' 印刷余白日（前後余裕日数）
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PrintDay() As Integer
        Get
            Return _PrintDay
        End Get
        Set(ByVal value As Integer)
            TxtPrintDay.Value = value
        End Set
    End Property
    Property FontSizeCellHeader() As Integer
        Get
            Return _FontSizeCellHeader
        End Get
        Set(value As Integer)
            Select Case True
                Case value < TxtCellHeaderFontSize.Minimum
                    TxtCellHeaderFontSize.Value = TxtCellHeaderFontSize.Minimum
                    _FontSizeCellHeader = TxtCellHeaderFontSize.Minimum
                Case value > TxtCellHeaderFontSize.Maximum
                    TxtCellHeaderFontSize.Value = TxtCellHeaderFontSize.Maximum
                    _FontSizeCellHeader = TxtCellHeaderFontSize.Maximum
                Case Else
                    TxtCellHeaderFontSize.Value = value
                    _FontSizeCellHeader = value
            End Select
        End Set
    End Property
    ''' <summary>
    ''' セルフォントサイズ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property FontSizeCell() As Integer
        Get
            Return _FontSizeCell
        End Get
        Set(value As Integer)
            Select Case True
                Case value < TxtCellFontSize.Minimum
                    TxtCellFontSize.Value = TxtCellFontSize.Minimum
                    _FontSizeCell = TxtCellFontSize.Minimum
                Case value > TxtCellFontSize.Maximum
                    TxtCellFontSize.Value = TxtCellFontSize.Maximum
                    _FontSizeCell = TxtCellFontSize.Maximum
                Case Else
                    TxtCellFontSize.Value = value
                    _FontSizeCell = value
            End Select
        End Set
    End Property
    ''' <summary>
    ''' ピースフォントサイズ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property FontSizePiece() As Integer
        Get
            Return _FontSizePiece
        End Get
        Set(value As Integer)
            Select Case True
                Case value < TxtPieceFontSize.Minimum
                    TxtPieceFontSize.Value = TxtPieceFontSize.Minimum
                    _FontSizePiece = TxtPieceFontSize.Minimum
                Case value > TxtPieceFontSize.Maximum
                    TxtPieceFontSize.Value = TxtPieceFontSize.Maximum
                    _FontSizePiece = TxtPieceFontSize.Maximum
                Case Else
                    TxtPieceFontSize.Value = value
                    _FontSizePiece = value
            End Select
        End Set
    End Property
#End Region
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSetting_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSetting_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If FC.Edited Then
            If MsgBox("変更を保存せずに閉じてもいいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If

    End Sub
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FC.TargetForm = Me
        FC.Title = Me.Text

        ChkTunnel.Checked = _DefTunnel

        FC.ScanTargetControl()
        FC.Edited = False
    End Sub
    ''' <summary>
    ''' キャンセルボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' ＯＫボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        _DefTunnel = ChkTunnel.Checked
        _SaturdayColor = ConvertColorValue(ColorPicker_Saturday.SelectedColor)
        _SundayColor = ConvertColorValue(ColorPicker_Sunday.SelectedColor)
        _TodayColor = ConvertColorValue(ColorPicker_Today.SelectedColor)
        _Today = TxtToDay.Value
        _StartDay = TxtStartDay.Value
        _FinalDay = TxtFinalDay.Value
        _PrintDay = TxtPrintDay.Value
        _NoHighlight = ChkNoHighlight.Checked
        _TabletMode = ChkTabletMode.Checked
        _FontSizeCell = TxtCellFontSize.Value
        _FontSizePiece = TxtPieceFontSize.Value
        _FontSizeCellHeader = TxtCellHeaderFontSize.Value
        FC.Edited = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    ''' <summary>
    ''' 休日設定ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnHoliday_Click(sender As Object, e As EventArgs) Handles BtnHoliday.Click
        FrmHolidaySetting.ShowDialog()
    End Sub
    ''' <summary>
    ''' ファイル履歴クリアボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDelFileRireki_Click(sender As Object, e As EventArgs) Handles BtnDelFileRireki.Click
        If MsgBox("ファイル履歴をクリアしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            'FrmParent.MenuList.Clear()
            Call FrmParent.FileListClear()
            MsgBox("ファイル履歴をクリアしました", 64, "情報")
        End If
    End Sub

    Private Sub TxtPrintDay_ValueChanged(sender As Object, e As EventArgs) Handles TxtPrintDay.ValueChanged

    End Sub
End Class