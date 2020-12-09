''' <summary>
''' ピースプロパティ
''' </summary>
''' <remarks></remarks>
Public Class FrmPieceProperty
    Dim FC As New ClassFormControl

    Dim _Started As Boolean = False

    Dim _StartDay As Date
    Dim _EndDay As Date
    Dim _IsDateLock As Boolean

    Dim _BackColor As Color
    Dim _ProgressType As Integer
    Dim _ProgressColor As Color
    Dim _ProgressPercent As Single
    Dim _ProgressDisplay As String
    Dim _IsNotUseProgress As Boolean = False
    Dim _IsTunnel As Boolean

    Dim _CaptionLeftText As String
    Dim _CaptionLeftAlignment As ContentAlignment
    Dim _CaptionLeftPosition As Integer = 0
    Dim _CaptionleftForeColor As Color

    Dim _CaptionCenterText As String
    Dim _CaptionCenterAlignment As ContentAlignment
    Dim _CaptionCenterPosition As Integer = 0
    Dim _CaprionCenterForeColor As Color

    Dim _CaptionRightText As String
    Dim _CaptionRightAlignment As ContentAlignment
    Dim _CaptionRightPosition As Integer = 0
    Dim _CaprionRightForeColor As Color

    Dim _IsSummaryPiece As Boolean = False
    Dim _UseSummaryProgress As Boolean = False
    Dim _IsSummaryExclusion As Boolean = False
    Dim _IsUseSummaryPiece As Boolean = False
#Region "Property"
    Property MoreMaster As Boolean
    Property TagetFrom As FrmMain
    ''' <summary>
    ''' 開始日
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property StartDay() As Date
        Get
            Return _StartDay
        End Get
        Set(value As Date)
            _StartDay = value
            TxtStartDay.Value = value
        End Set
    End Property
    ''' <summary>
    ''' 終了日
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property EndDay() As Date
        Get
            Return _EndDay
        End Get
        Set(value As Date)
            _EndDay = value
            TxtEndDay.Value = value
        End Set
    End Property
    ''' <summary>
    ''' 日付をロックする？
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsDateLock As Boolean
        Get
            Return _IsDateLock
        End Get
        Set(value As Boolean)
            _IsDateLock = value
        End Set
    End Property
    ''' <summary>
    ''' 中央ラベル文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionCenterText() As String
        Get
            Return _CaptionCenterText
        End Get
        Set(ByVal value As String)
            TxtCenter.Text = value
            PiecePreview.CaptionCenterText = value
        End Set
    End Property
    ''' <summary>
    ''' 左ラベル文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftText() As String
        Get
            Return _CaptionLeftText
        End Get
        Set(ByVal value As String)
            TxtLeft.Text = value
            'PiecePreview.CaptionLeftText = ConvCaptionDate(value, Now)
            PiecePreview.CaptionLeftText = ConvCaptionDate(value, TxtStartDay.Value)

        End Set
    End Property
    ''' <summary>
    ''' 右ラベル文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightText() As String
        Get
            Return _CaptionRightText
        End Get
        Set(ByVal value As String)
            TxtRight.Text = value
            'PiecePreview.CaptionRightText = ConvCaptionDate(value, Now)
            PiecePreview.CaptionRightText = ConvCaptionDate(value, TxtEndDay.Value)
        End Set
    End Property
    ''' <summary>
    ''' ピース背景色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PieceBackColor() As Color
        Get
            Return _BackColor
        End Get
        Set(ByVal value As Color)
            'TxtCenter.BackColor = value
            'Panel2.BackColor = value
            PiecePreview.PieceBackColor = value
            ColorPicker_Bar.SelectedColor = value
        End Set
    End Property
    ''' <summary>
    ''' ピース文字色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaprionCenterForeColor() As Color
        Get
            Return _CaprionCenterForeColor
        End Get
        Set(ByVal value As Color)
            'TxtCenter.ForeColor = value
            PiecePreview.CaptionCenterForeColor = value
            ColorPicker_Center.SelectedColor = value
        End Set
    End Property
    ''' <summary>
    ''' トンネルピース？
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsTunnel() As Boolean
        Get
            Return _IsTunnel
        End Get
        Set(ByVal value As Boolean)
            _IsTunnel = value
            ChkIsTunnel.Checked = value
        End Set
    End Property
    ''' <summary>
    ''' ピース文字垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionCenterAlignment() As ContentAlignment
        Get
            Return _CaptionCenterAlignment
        End Get
        Set(ByVal value As ContentAlignment)

            TxtCenter.ContentAlignment = value
            AlignCenter2.SelectedAlignment = value
            PiecePreview.CaptionCenterHAlign = AlignCenter2.GetSetH
            PiecePreview.CaptionCenterVAlign = AlignCenter2.GetSetV

        End Set
    End Property
    ''' <summary>
    ''' 左文字垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftAlignment() As ContentAlignment
        Get
            Return _CaptionLeftAlignment
        End Get
        Set(ByVal value As ContentAlignment)
            TxtLeft.ContentAlignment = value
            AlignLeft2.SelectedAlignment = value
            PiecePreview.CaptionLeftHAlign = AlignLeft2.GetSetH
            PiecePreview.CaptionLeftVAlign = AlignLeft2.GetSetV
        End Set
    End Property
    ''' <summary>
    ''' 右文字垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightAlignment() As ContentAlignment
        Get
            Return _CaptionRightAlignment
        End Get
        Set(ByVal value As ContentAlignment)
            TxtRight.ContentAlignment = value
            AlignRight2.SelectedAlignment = value
            PiecePreview.CaptionRightHAlign = AlignRight2.GetSetH
            PiecePreview.CaptionRightVAlign = AlignRight2.GetSetV
        End Set
    End Property
    ''' <summary>
    ''' 達成率色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ProgressColor() As Color
        Get
            Return _ProgressColor
        End Get
        Set(ByVal value As Color)
            'LblProgress.BackColor = value
            PiecePreview.ProgressBackColor = value
            ColorPicker_Progress.SelectedColor = value
        End Set
    End Property
    ''' <summary>
    ''' 達成率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ProgressPercent() As Single
        Get
            Return _ProgressPercent
        End Get
        Set(ByVal value As Single)
            Dim T As Integer = CInt(value * 100)
            TxtProgress.Value = T
            PiecePreview.ProgressValue = T
        End Set
    End Property
    ''' <summary>
    ''' 達成率タイプ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ProgressType() As Integer
        Get
            Return _ProgressType
        End Get
        Set(ByVal value As Integer)
            CmbProgressType.SelectedIndex = value
        End Set
    End Property
    ''' <summary>
    ''' 達成率数表示する？
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ProgressDisplay() As String
        Get
            Return _ProgressDisplay
        End Get
        Set(ByVal value As String)
            If value = "1" Then
                ChkProgressDisplay.Checked = True
            Else
                ChkProgressDisplay.Checked = False
            End If
        End Set
    End Property
    ''' <summary>
    ''' 達成率を使用しない？
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsNotUseProgress As Boolean
        Get
            Return _IsNotUseProgress
        End Get
        Set(value As Boolean)
            _IsNotUseProgress = value
            ChkNoUseProgress.Checked = value
        End Set
    End Property
    ''' <summary>
    ''' 左文字位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftPosition() As Integer
        Get
            Return _CaptionLeftPosition
        End Get
        Set(ByVal value As Integer)
            CmbLeftPosition.SelectedIndex = value
            Select Case value
                Case 0 : PiecePreview.CaptionLeftPosition = UserControlPiece.enumUCP_Position.Center
                Case 1 : PiecePreview.CaptionLeftPosition = UserControlPiece.enumUCP_Position.Top
                Case 2 : PiecePreview.CaptionLeftPosition = UserControlPiece.enumUCP_Position.Bottom
                Case 3 : PiecePreview.CaptionLeftPosition = UserControlPiece.enumUCP_Position.Left
                Case Else : PiecePreview.CaptionLeftPosition = UserControlPiece.enumUCP_Position.Right
            End Select
        End Set
    End Property
    ''' <summary>
    ''' ピース文字位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionCenterPosition() As Integer
        Get
            Return _CaptionCenterPosition
        End Get
        Set(ByVal value As Integer)
            CmbCenterPosition.SelectedIndex = value
            Select Case value
                Case 0 : PiecePreview.CaptionCenterPosition = UserControlPiece.enumUCP_Position.Center
                Case 1 : PiecePreview.CaptionCenterPosition = UserControlPiece.enumUCP_Position.Top
                Case 2 : PiecePreview.CaptionCenterPosition = UserControlPiece.enumUCP_Position.Bottom
                Case 3 : PiecePreview.CaptionCenterPosition = UserControlPiece.enumUCP_Position.Left
                Case Else : PiecePreview.CaptionCenterPosition = UserControlPiece.enumUCP_Position.Right
            End Select
        End Set
    End Property
    ''' <summary>
    ''' 右文字位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightPosition() As Integer
        Get
            Return _CaptionRightPosition
        End Get
        Set(ByVal value As Integer)
            CmbRightPosition.SelectedIndex = value
            Select Case value
                Case 0 : PiecePreview.CaptionRightPosition = UserControlPiece.enumUCP_Position.Center
                Case 1 : PiecePreview.CaptionRightPosition = UserControlPiece.enumUCP_Position.Top
                Case 2 : PiecePreview.CaptionRightPosition = UserControlPiece.enumUCP_Position.Bottom
                Case 3 : PiecePreview.CaptionRightPosition = UserControlPiece.enumUCP_Position.Left
                Case Else : PiecePreview.CaptionRightPosition = UserControlPiece.enumUCP_Position.Right
            End Select
        End Set
    End Property
    ''' <summary>
    ''' 左文字色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftForeColor() As Color
        Get
            Return _CaptionleftForeColor
        End Get
        Set(ByVal value As Color)
            PiecePreview.CaptionLeftForeColor = value
            ColorPicker_Left.SelectedColor = value
        End Set
    End Property
    ''' <summary>
    ''' 右文字色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightForeColor() As Color
        Get
            Return _CaprionRightForeColor
        End Get
        Set(ByVal value As Color)
            PiecePreview.CaptionRightForeColor = value
            ColorPicker_Right.SelectedColor = value
        End Set
    End Property
    ''' <summary>
    ''' マスタピースにする
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsMasterPiece As Boolean
    ''' <summary>
    ''' マスタピースをクリアする
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsMasterPieceClear As Boolean
    Dim _LockPiece As Integer = 0
    ''' <summary>
    ''' ロックピース
    ''' </summary>
    ''' <value>0:ロックしない 1:達成率のみ許可 2:全てロック</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LockPiece As Integer
        Get
            Return _LockPiece
        End Get
        Set(value As Integer)
            _LockPiece = value
        End Set
    End Property

 
    ''' <summary>
    ''' サマリーピース
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsSummaryPiece As Boolean
        Get
            Return _IsSummaryPiece
        End Get
        Set(value As Boolean)
            _IsSummaryPiece = value
        End Set
    End Property
    ''' <summary>
    ''' サマリーピース進捗率自動集計を使用する？
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property UseSummaryProgress As Boolean
        Get
            Return _UseSummaryProgress
        End Get
        Set(value As Boolean)
            _UseSummaryProgress = value
        End Set
    End Property
    Property IsSummaryExclusion As Boolean
        Get
            Return _IsSummaryExclusion
        End Get
        Set(value As Boolean)
            _IsSummaryExclusion = value
        End Set
    End Property
    ''' <summary>
    ''' サマリーピースに設定してもいいか？
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsUseSummaryPiece As Boolean
        Get
            Return _IsUseSummaryPiece
        End Get
        Set(value As Boolean)
            _IsUseSummaryPiece = value
        End Set
    End Property
#End Region
    ''' <summary>
    ''' フォーム終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmPieceProperty_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォーム終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmPieceProperty_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub FrmPieceProperty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FC.TargetForm = Me
        FC.Title = Me.Text

        'CmbLeftPosition.SelectedIndex = 0
        'CmbRightPosition.SelectedIndex = 0
        If ColorPicker_Bar.SelectedColor = Color.Empty Then
            ColorPicker_Bar.SelectedColor = ColorPicker_Bar.AutomaticColor
        End If
        If ColorPicker_Center.SelectedColor = Color.Empty Then
            ColorPicker_Center.SelectedColor = ColorPicker_Center.AutomaticColor
        End If
        If ColorPicker_Left.SelectedColor = Color.Empty Then
            ColorPicker_Left.SelectedColor = ColorPicker_Left.AutomaticColor
        End If
        If ColorPicker_Progress.SelectedColor = Color.Empty Then
            ColorPicker_Progress.SelectedColor = ColorPicker_Progress.AutomaticColor
        End If
        If ColorPicker_Right.SelectedColor = Color.Empty Then
            ColorPicker_Right.SelectedColor = ColorPicker_Right.AutomaticColor
        End If
        If _MoreMaster Then
            ChkMasterPiece.ForeColor = Color.Red
            BtnClearMasterPiece.Enabled = True
        Else
            BtnClearMasterPiece.Enabled = False
        End If

        If Not IsNothing(TxtStartDay.Value) AndAlso Not IsNothing(TxtEndDay.Value) Then
            Dim i As Integer = DateDiff(DateInterval.Day, CDate(TxtStartDay.Value), CDate(TxtEndDay.Value)) + 1
            If i > 0 Then
                TxtDaySpan.Value = i
            End If
        End If

        Select Case _LockPiece
            Case 1 : OptLock1.Checked = True
            Case 2 : OptLock2.Checked = True
            Case Else : OptLock0.Checked = True
        End Select

        ChkSummaryPiece.Checked = _IsSummaryPiece
        ChkSummaryProgress.Checked = _UseSummaryProgress
        If _IsSummaryPiece Then
            TxtStartDay.Enabled = False
            TxtDaySpan.Enabled = False
            TxtEndDay.Enabled = False
            BtnSpanLock.Visible = False

            ChkSummaryProgress.Enabled = True
            TxtProgress.Enabled = Not _UseSummaryProgress

            'サマリーピースはマスタピースに出来ない
            ChkMasterPiece.Checked = False
            ChkMasterPiece.Enabled = False
        End If
        ChkSummaryExclusion.Checked = _IsSummaryExclusion

        PiecePreview.CaptionLeftText = ConvCaptionDateCount(ConvCaptionDate(TxtLeft.Text, TxtStartDay.Value), TxtStartDay.Value, TxtEndDay.Value)
        PiecePreview.CaptionCenterText = ConvCaptionDateCount(TxtCenter.Text, TxtStartDay.Value, TxtEndDay.Value)
        PiecePreview.CaptionRightText = ConvCaptionDateCount(ConvCaptionDate(TxtRight.Text, TxtEndDay.Value), TxtStartDay.Value, TxtEndDay.Value)

        Call TxtRight_TextChanged(Nothing, Nothing)

        FC.ScanTargetControl()
        FC.Edited = False
    End Sub
    ''' <summary>
    ''' フォーム表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmPieceProperty_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _Started = True
    End Sub
    ''' <summary>
    ''' OKボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Select Case True
            Case IsNothing(TxtStartDay.Value)
                MsgBox("開始日が設定されていません", 48, "エラー")
                TxtStartDay.Focus()
                Return
            Case IsNothing(TxtEndDay.Value)
                MsgBox("終了日が設定されていません", 48, "エラー")
                TxtEndDay.Focus()
                Return
            Case TxtEndDay.Value < TxtStartDay.Value
                MsgBox("日付設定が異常です", 48, "エラー")
                TxtStartDay.Focus()
                Return
        End Select

        _StartDay = TxtStartDay.Value
        _EndDay = TxtEndDay.Value

        _CaptionLeftText = TxtLeft.Text
        _CaptionCenterText = TxtCenter.Text
        _CaptionRightText = TxtRight.Text
        _BackColor = PiecePreview.PieceBackColor

        _CaptionleftForeColor = PiecePreview.CaptionLeftForeColor
        _CaprionCenterForeColor = PiecePreview.CaptionCenterForeColor
        _CaprionRightForeColor = PiecePreview.CaptionRightForeColor

        _CaptionCenterAlignment = TxtCenter.ContentAlignment
        _CaptionLeftAlignment = TxtLeft.ContentAlignment
        _CaptionRightAlignment = TxtRight.ContentAlignment

        _ProgressType = CmbProgressType.SelectedIndex
        _ProgressColor = PiecePreview.ProgressBackColor
        _ProgressPercent = TxtProgress.Value / 100
        _ProgressDisplay = IIf(ChkProgressDisplay.Checked, "1", "")
        _IsNotUseProgress = ChkNoUseProgress.Checked

        _CaptionLeftPosition = CmbLeftPosition.SelectedIndex
        _CaptionCenterPosition = CmbCenterPosition.SelectedIndex
        _CaptionRightPosition = CmbRightPosition.SelectedIndex
        _IsTunnel = ChkIsTunnel.Checked
        _IsMasterPiece = ChkMasterPiece.Checked
        _IsSummaryPiece = ChkSummaryPiece.Checked
        _UseSummaryProgress = ChkSummaryProgress.Checked
        _IsSummaryExclusion = ChkSummaryExclusion.Checked
        Select Case True
            Case OptLock1.Checked : _LockPiece = 1
            Case OptLock2.Checked : _LockPiece = 2
            Case Else : _LockPiece = 0
        End Select

        FC.Edited = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    ''' <summary>
    ''' ピース色選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GcColorPicker1_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPicker_Bar.SelectedColorChanged
        PiecePreview.PieceBackColor = ColorPicker_Bar.SelectedColor
        PiecePreview.Refresh()

        ColorPicker_Center.AutomaticColor = ToBackColor(ColorPicker_Bar.SelectedColor)
        If CmbLeftPosition.SelectedIndex = 0 Then
            ColorPicker_Left.AutomaticColor = ToBackColor(PiecePreview.PieceBackColor)
        Else
            ColorPicker_Left.AutomaticColor = SystemColors.WindowText
        End If
        If CmbRightPosition.SelectedIndex = 0 Then
            ColorPicker_Right.AutomaticColor = ToBackColor(PiecePreview.PieceBackColor)
        Else
            ColorPicker_Right.AutomaticColor = SystemColors.WindowText
        End If
    End Sub
    ''' <summary>
    ''' ピース文字色選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ColorPicker_Center_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPicker_Center.SelectedColorChanged
        PiecePreview.CaptionCenterForeColor = ColorPicker_Center.SelectedColor
        PiecePreview.Refresh()
    End Sub
    ''' <summary>
    ''' ピース内文字変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtCenter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCenter.TextChanged
        PiecePreview.CaptionCenterText = ConvCaptionDateCount(TxtCenter.Text, TxtStartDay.Value, TxtEndDay.Value)
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
    ''' 達成率を使用しないチェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkNoUseProgress_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNoUseProgress.CheckedChanged
        GroupBox10.Enabled = Not ChkNoUseProgress.Checked
        PiecePreview.ProgressHidden = ChkNoUseProgress.Checked

        Call TxtRight_TextChanged(Nothing, Nothing)
        PiecePreview.Refresh()
    End Sub
    ''' <summary>
    ''' 達成率が変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtProgress_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProgress.ValueChanged
        PiecePreview.ProgressValue = TxtProgress.Value
        Call TxtRight_TextChanged(Nothing, Nothing)
        PiecePreview.Refresh()
    End Sub
    ''' <summary>
    ''' 達成率色選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ColorPicker_Progress_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPicker_Progress.SelectedColorChanged
        PiecePreview.ProgressBackColor = ColorPicker_Progress.SelectedColor
        PiecePreview.Refresh()
    End Sub
    ''' <summary>
    ''' 左文字色選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ColorPicker_Left_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPicker_Left.SelectedColorChanged
        PiecePreview.CaptionLeftForeColor = ColorPicker_Left.SelectedColor
        PiecePreview.Refresh()
    End Sub
    ''' <summary>
    ''' 右文字色選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ColorPicker_Right_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPicker_Right.SelectedColorChanged
        PiecePreview.CaptionRightForeColor = ColorPicker_Right.SelectedColor
        PiecePreview.Refresh()
    End Sub
    ''' <summary>
    ''' 左文字位置変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbLeftPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbLeftPosition.SelectedIndexChanged
        Select Case CmbLeftPosition.SelectedIndex
            Case 0 : PiecePreview.CaptionLeftPosition = UserControlPiece.enumUCP_Position.Center
            Case 1 : PiecePreview.CaptionLeftPosition = UserControlPiece.enumUCP_Position.Top
            Case 2 : PiecePreview.CaptionLeftPosition = UserControlPiece.enumUCP_Position.Bottom
            Case 3 : PiecePreview.CaptionLeftPosition = UserControlPiece.enumUCP_Position.Left
            Case Else : PiecePreview.CaptionLeftPosition = UserControlPiece.enumUCP_Position.Right
        End Select
        If CmbLeftPosition.SelectedIndex = 0 Then
            ColorPicker_Left.AutomaticColor = ToBackColor(PiecePreview.PieceBackColor)
        Else
            ColorPicker_Left.AutomaticColor = SystemColors.WindowText
        End If
    End Sub
    ''' <summary>
    ''' 右文字位置変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbRightPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbRightPosition.SelectedIndexChanged
        Select Case CmbRightPosition.SelectedIndex
            Case 0 : PiecePreview.CaptionRightPosition = UserControlPiece.enumUCP_Position.Center
            Case 1 : PiecePreview.CaptionRightPosition = UserControlPiece.enumUCP_Position.Top
            Case 2 : PiecePreview.CaptionRightPosition = UserControlPiece.enumUCP_Position.Bottom
            Case 3 : PiecePreview.CaptionRightPosition = UserControlPiece.enumUCP_Position.Left
            Case Else : PiecePreview.CaptionRightPosition = UserControlPiece.enumUCP_Position.Right
        End Select
        If CmbRightPosition.SelectedIndex = 0 Then
            ColorPicker_Right.AutomaticColor = ToBackColor(PiecePreview.PieceBackColor)
        Else
            ColorPicker_Right.AutomaticColor = SystemColors.WindowText
        End If

    End Sub
    ''' <summary>
    ''' 左文字が変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtLeft_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLeft.TextChanged
        'PiecePreview.CaptionLeftText = ConvCaptionDate(TxtLeft.Text, Now)
        If IsNothing(TxtStartDay.Value) Then
            PiecePreview.CaptionLeftText = Replace(TxtLeft.Text, "<DATE>", "")
        Else
            PiecePreview.CaptionLeftText = ConvCaptionDateCount(ConvCaptionDate(TxtLeft.Text, TxtStartDay.Value), TxtStartDay.Value, TxtEndDay.Value)
        End If
    End Sub
    ''' <summary>
    ''' 右文字が変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtRight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRight.TextChanged
        'PiecePreview.CaptionRightText = ConvCaptionDate(TxtRight.Text, Now)
        If IsNothing(TxtEndDay.Value) Then
            PiecePreview.CaptionRightText = Replace(TxtRight.Text, "<DATE>", "")
        Else
            If Not ChkNoUseProgress.Checked Then
                If ChkProgressDisplay.Checked AndAlso TxtProgress.Value > 0 Then
                    PiecePreview.CaptionRightText = ConvCaptionDateCount(ConvCaptionDate(TxtRight.Text, TxtEndDay.Value), TxtStartDay.Value, TxtEndDay.Value) & String.Format("({0}%)", TxtProgress.Value.ToString)
                Else
                    PiecePreview.CaptionRightText = ConvCaptionDateCount(ConvCaptionDate(TxtRight.Text, TxtEndDay.Value), TxtStartDay.Value, TxtEndDay.Value)
                End If
            Else
                PiecePreview.CaptionRightText = ConvCaptionDateCount(ConvCaptionDate(TxtRight.Text, TxtEndDay.Value), TxtStartDay.Value, TxtEndDay.Value)
            End If
        End If
    End Sub
    ''' <summary>
    ''' ピース文字位置変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbCenterPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCenterPosition.SelectedIndexChanged
        Select Case CmbCenterPosition.SelectedIndex
            Case 0 : PiecePreview.CaptionCenterPosition = UserControlPiece.enumUCP_Position.Center
            Case 1 : PiecePreview.CaptionCenterPosition = UserControlPiece.enumUCP_Position.Top
            Case 2 : PiecePreview.CaptionCenterPosition = UserControlPiece.enumUCP_Position.Bottom
            Case 3 : PiecePreview.CaptionCenterPosition = UserControlPiece.enumUCP_Position.Left
            Case Else : PiecePreview.CaptionCenterPosition = UserControlPiece.enumUCP_Position.Right
        End Select
        If CmbCenterPosition.SelectedIndex = 0 Then
            ColorPicker_Center.AutomaticColor = Color.White
        Else
            ColorPicker_Center.AutomaticColor = SystemColors.WindowText
        End If
    End Sub
    ''' <summary>
    ''' 中文字位置変更
    ''' </summary>
    ''' <param name="SelectdAlignment"></param>
    ''' <param name="HAlign"></param>
    ''' <param name="VAlign"></param>
    ''' <remarks></remarks>
    Private Sub AlignCenter2_AlignmentChaned(SelectdAlignment As ContentAlignment, HAlign As Integer, VAlign As Integer) Handles AlignCenter2.AlignmentChaned
        TxtCenter.ContentAlignment = SelectdAlignment
        PiecePreview.CaptionCenterHAlign = HAlign
        PiecePreview.CaptionCenterVAlign = VAlign
    End Sub
    ''' <summary>
    ''' 右文字位置変更
    ''' </summary>
    ''' <param name="SelectdAlignment"></param>
    ''' <param name="HAlign"></param>
    ''' <param name="VAlign"></param>
    ''' <remarks></remarks>
    Private Sub AlignRight_AlignmentChaned(SelectdAlignment As ContentAlignment, HAlign As Integer, VAlign As Integer) Handles AlignRight2.AlignmentChaned
        TxtRight.ContentAlignment = SelectdAlignment
        PiecePreview.CaptionRightHAlign = HAlign
        PiecePreview.CaptionRightVAlign = VAlign
    End Sub
    ''' <summary>
    ''' 左文字位置変更
    ''' </summary>
    ''' <param name="SelectdAlignment"></param>
    ''' <param name="HAlign"></param>
    ''' <param name="VAlign"></param>
    ''' <remarks></remarks>
    Private Sub AlignLeft_AlignmentChaned(SelectdAlignment As ContentAlignment, HAlign As Integer, VAlign As Integer) Handles AlignLeft2.AlignmentChaned
        TxtLeft.ContentAlignment = SelectdAlignment
        PiecePreview.CaptionLeftHAlign = HAlign
        PiecePreview.CaptionLeftVAlign = VAlign
    End Sub
    ''' <summary>
    ''' 一括文字変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnAllForeColorChange_Click(sender As Object, e As EventArgs) Handles BtnAllForeColorChange.Click
        ColorPicker_Left.SelectedColor = ColorPicker_Left.AutomaticColor
        ColorPicker_Right.SelectedColor = ColorPicker_Right.AutomaticColor
        ColorPicker_Center.SelectedColor = ColorPicker_Center.AutomaticColor
    End Sub
    ''' <summary>
    ''' 達成率タイプが変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbProgressType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbProgressType.SelectedIndexChanged
        PiecePreview.ProgressType = CmbProgressType.SelectedIndex
    End Sub
    ''' <summary>
    ''' 日付コマンドの追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ConMenu_AddCommand1_Click(sender As Object, e As EventArgs) Handles ConMenu_AddCommand1.Click
        Dim source As Control = ContextMenu1.SourceControl
        If source IsNot Nothing Then
            Dim Obj As Object = FindControlByFieldName(Me, source.Name)
            If Not IsNothing(Obj) Then
                If TypeOf Obj Is GrapeCity.Win.Editors.GcTextBox Then
                    Obj.Text = Obj.Text & " <DATE>"
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 日数コマンドの追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ConMenu_AddCommand2_Click(sender As Object, e As EventArgs) Handles ConMenu_AddCommand2.Click
        Dim source As Control = ContextMenu1.SourceControl
        If source IsNot Nothing Then
            Dim Obj As Object = FindControlByFieldName(Me, source.Name)
            If Not IsNothing(Obj) Then
                If TypeOf Obj Is GrapeCity.Win.Editors.GcTextBox Then
                    Obj.Text = Obj.Text & " <COUNT>"
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 日数コマンドの追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        TxtCenter.Text = TxtCenter.Text & " <COUNT>"
    End Sub
    ''' <summary>
    ''' フォームに配置されているコントロールを名前で探す
    ''' （フォームクラスのフィールドをフィールド名で探す）
    ''' </summary>
    ''' <param name="frm">コントロールを探すフォーム</param>
    ''' <param name="name">コントロール（フィールド）の名前</param>
    ''' <returns>見つかった時は、コントロールのオブジェクト。
    ''' 見つからなかった時は、null(VB.NETではNothing)。</returns>
    Public Shared Function FindControlByFieldName(ByVal frm As Form, ByVal name As String) As Object
        'まずプロパティ名を探し、見つからなければフィールド名を探す
        Dim t As System.Type = frm.GetType()

        Dim pi As System.Reflection.PropertyInfo = _
            t.GetProperty(name, _
                System.Reflection.BindingFlags.Public Or _
                System.Reflection.BindingFlags.NonPublic Or _
                System.Reflection.BindingFlags.Instance Or _
                System.Reflection.BindingFlags.DeclaredOnly)

        If Not pi Is Nothing Then
            Return pi.GetValue(frm, Nothing)
        End If

        Dim fi As System.Reflection.FieldInfo = _
            t.GetField(name, _
                System.Reflection.BindingFlags.Public Or _
                System.Reflection.BindingFlags.NonPublic Or _
                System.Reflection.BindingFlags.Instance Or _
                System.Reflection.BindingFlags.DeclaredOnly)

        If fi Is Nothing Then
            Return Nothing
        End If

        Return fi.GetValue(frm)
    End Function
    ''' <summary>
    ''' 開始日付変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtStartDay_ValueChanged(sender As Object, e As EventArgs) Handles TxtStartDay.ValueChanged
        If IsNothing(TxtStartDay.Value) Then
            PiecePreview.CaptionLeftText = Replace(TxtLeft.Text, "<DATE>", "")
        Else
            PiecePreview.CaptionCenterText = ConvCaptionDateCount(ConvCaptionDate(TxtCenter.Text, TxtStartDay.Value), TxtStartDay.Value, TxtEndDay.Value)
            PiecePreview.CaptionLeftText = ConvCaptionDateCount(ConvCaptionDate(TxtLeft.Text, TxtStartDay.Value), TxtStartDay.Value, TxtEndDay.Value)
            If _Started Then
                If _SpanLock Then
                    Dim S As Integer = TxtDaySpan.Value - 1
                    Dim D As Date = CDate(TxtStartDay.Value)
                    TxtEndDay.Value = DateAdd(DateInterval.Day, S, D)
                Else
                    TxtDaySpan.Value = DateDiff(DateInterval.Day, CDate(TxtStartDay.Value), CDate(TxtEndDay.Value)) + 1
                End If

            End If
        End If
        Call TxtRight_TextChanged(Nothing, Nothing)
    End Sub
    ''' <summary>
    ''' 終了日付変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtEndDay_ValueChanged(sender As Object, e As EventArgs) Handles TxtEndDay.ValueChanged
        If IsNothing(TxtEndDay.Value) Then
            PiecePreview.CaptionRightText = Replace(TxtRight.Text, "<DATE>", "")
        Else
            PiecePreview.CaptionCenterText = ConvCaptionDateCount(ConvCaptionDate(TxtCenter.Text, TxtStartDay.Value), TxtStartDay.Value, TxtEndDay.Value)

            PiecePreview.CaptionRightText = ConvCaptionDateCount(ConvCaptionDate(TxtRight.Text, TxtEndDay.Value), TxtStartDay.Value, TxtEndDay.Value)
            If _Started Then
                If _SpanLock Then
                    Dim S As Integer = 0 - TxtDaySpan.Value + 1
                    Dim D As Date = CDate(TxtEndDay.Value)
                    TxtStartDay.Value = DateAdd(DateInterval.Day, S, D)
                Else
                    TxtDaySpan.Value = DateDiff(DateInterval.Day, CDate(TxtStartDay.Value), CDate(TxtEndDay.Value)) + 1
                End If
            End If
        End If
        Call TxtRight_TextChanged(Nothing, Nothing)
    End Sub
    ''' <summary>
    ''' 日付スパン変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtDaySpan_ValueChanged(sender As Object, e As EventArgs) Handles TxtDaySpan.ValueChanged
        If OptDayMae.Checked Then
            If Not IsNothing(TxtEndDay.Value) Then
                Dim S As Integer = 0 - TxtDaySpan.Value + 1
                Dim D As Date = CDate(TxtEndDay.Value)
                TxtStartDay.Value = DateAdd(DateInterval.Day, S, D)
            End If
        Else
            If Not IsNothing(TxtStartDay.Value) Then
                Dim S As Integer = TxtDaySpan.Value - 1
                Dim D As Date = CDate(TxtStartDay.Value)
                TxtEndDay.Value = DateAdd(DateInterval.Day, S, D)
            End If
        End If
        Call TxtRight_TextChanged(Nothing, Nothing)
    End Sub

    Dim _SpanLock As Boolean = True
    ''' <summary>
    ''' 日付スパンのロック設定と解除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSpanLock_Click(sender As Object, e As EventArgs) Handles BtnSpanLock.Click
        _SpanLock = Not _SpanLock
        If _SpanLock Then
            BtnSpanLock.Image = My.Resources.lock
        Else
            BtnSpanLock.Image = My.Resources.lock_open
        End If
        TxtDaySpan.Enabled = Not _SpanLock

        OptDayAto.Visible = Not _SpanLock
        OptDayMae.Visible = Not _SpanLock
    End Sub
    ''' <summary>
    ''' マスタピースをクリアする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClearMasterPiece_Click(sender As Object, e As EventArgs) Handles BtnClearMasterPiece.Click
        If MsgBox("マスタピースをクリアしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            _IsMasterPieceClear = True
            ChkMasterPiece.ForeColor = Color.Black
            BtnClearMasterPiece.Enabled = False
        End If
    End Sub
    ''' <summary>
    ''' 達成率表示チェックが変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkProgressDisplay_CheckedChanged(sender As Object, e As EventArgs) Handles ChkProgressDisplay.CheckedChanged
        Call TxtRight_TextChanged(Nothing, Nothing)
    End Sub
    ''' <summary>
    ''' サマリーピースチェックボックス変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkSummaryPiece_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSummaryPiece.CheckedChanged
        If ChkSummaryPiece.Checked AndAlso Not _IsUseSummaryPiece Then
            MsgBox("子レベル設定がされていないので、サマリーピースに設定する事は出来ません", 48, "エラー")
            ChkSummaryPiece.Checked = False
            Return
        End If
        If Not _SpanLock Then
            Call BtnSpanLock_Click(Nothing, Nothing)
        End If
        TxtStartDay.Enabled = Not ChkSummaryPiece.Checked
        TxtDaySpan.Enabled = Not ChkSummaryPiece.Checked
        TxtEndDay.Enabled = Not ChkSummaryPiece.Checked
        BtnSpanLock.Visible = Not ChkSummaryPiece.Checked
        ChkSummaryProgress.Enabled = ChkSummaryPiece.Checked

        If ChkSummaryPiece.Checked Then
            ChkMasterPiece.Checked = False
            ChkMasterPiece.Enabled = False

            ChkSummaryExclusion.Checked = False
            ChkSummaryExclusion.Enabled = False
        Else
            ChkMasterPiece.Enabled = True
            ChkSummaryProgress.Checked = False
            ChkSummaryExclusion.Enabled = True
        End If
    End Sub
    ''' <summary>
    ''' マスタピースチェックボックス変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkMasterPiece_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMasterPiece.CheckedChanged
        If ChkMasterPiece.Checked Then
            ChkSummaryPiece.Checked = False
            ChkSummaryPiece.Enabled = False
        Else
            ChkSummaryPiece.Enabled = True
        End If
    End Sub

    Private Sub ChkSummaryProgress_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSummaryProgress.CheckedChanged
        TxtProgress.Enabled = Not ChkSummaryProgress.Checked
    End Sub
End Class

