''' <summary>
''' ピースコントロールパネル
''' </summary>
''' <remarks></remarks>
Public Class UserControlPiece
    ''' <summary>
    ''' 垂直
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumUCP_VAlign
        ''' <summary>
        ''' 上
        ''' </summary>
        ''' <remarks></remarks>
        Top = 0
        ''' <summary>
        ''' 中間
        ''' </summary>
        ''' <remarks></remarks>
        Center = 1
        ''' <summary>
        ''' 下
        ''' </summary>
        ''' <remarks></remarks>
        Bottom = 2
    End Enum
    ''' <summary>
    ''' 水平
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumUCP_HAlign
        ''' <summary>
        ''' 左
        ''' </summary>
        ''' <remarks></remarks>
        Left = 0
        ''' <summary>
        ''' 真ん中
        ''' </summary>
        ''' <remarks></remarks>
        Center = 1
        ''' <summary>
        ''' 右
        ''' </summary>
        ''' <remarks></remarks>
        Right = 2
    End Enum
    ''' <summary>
    ''' 位置
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumUCP_Position
        ''' <summary>
        ''' 左
        ''' </summary>
        ''' <remarks></remarks>
        Left
        ''' <summary>
        ''' 右
        ''' </summary>
        ''' <remarks></remarks>
        Right
        ''' <summary>
        ''' 上
        ''' </summary>
        ''' <remarks></remarks>
        Top
        ''' <summary>
        ''' 下
        ''' </summary>
        ''' <remarks></remarks>
        Bottom
        ''' <summary>
        ''' 真ん中
        ''' </summary>
        ''' <remarks></remarks>
        Center
    End Enum
    Dim _LeftText As String
    Dim _LeftVAlign As enumUCP_VAlign = enumUCP_VAlign.Center
    Dim _LeftHAlign As enumUCP_HAlign = enumUCP_HAlign.Center
    Dim _LeftPosition As enumUCP_Position = enumUCP_Position.Left
    Dim _LeftForeColor As Color

    Dim _CenterText As String
    Dim _CenterVAlign As enumUCP_VAlign = enumUCP_VAlign.Center
    Dim _CenterHAlign As enumUCP_HAlign = enumUCP_HAlign.Center
    Dim _CenterPosition As enumUCP_Position = enumUCP_Position.Center
    Dim _CenterForeColor As Color

    Dim _RightText As String = ""
    Dim _RightVAlign As enumUCP_VAlign = enumUCP_VAlign.Center
    Dim _RightHAlign As enumUCP_HAlign = enumUCP_HAlign.Center
    Dim _RightPosition As enumUCP_Position = enumUCP_Position.Left
    Dim _RightForeColor As Color

    Dim _BackColor As Color
    Dim _ProgressBackColor As Color
    Dim _ProgressValue As Integer = 0
    Dim _ProgressType As Integer = 1
    Dim _ProgressHidden As Boolean = False
#Region "Property"
    ''' <summary>
    ''' ピース背景色
    ''' </summary>
    ''' <value>設定ピース色</value>
    ''' <returns>設定済みピース色</returns>
    ''' <remarks></remarks>
    Property PieceBackColor() As Color
        Get
            Return _BackColor
        End Get
        Set(ByVal value As Color)
            _BackColor = value
            PosiCenter.BackColor = value
        End Set
    End Property
    ''' <summary>
    ''' 進捗バー背景色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ProgressBackColor() As Color
        Get
            Return _ProgressBackColor
        End Get
        Set(ByVal value As Color)
            _ProgressBackColor = value
            LblProgress.BackColor = value
        End Set
    End Property
    ''' <summary>
    ''' 進捗値
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ProgressValue() As Integer
        Get
            Return _ProgressValue
        End Get
        Set(ByVal value As Integer)
            _ProgressValue = value
            Call MoveProgress()
        End Set
    End Property
    ''' <summary>
    ''' 進捗バー種類
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ProgressType() As Integer
        Get
            Return _ProgressType
        End Get
        Set(ByVal value As Integer)
            _ProgressType = value
            Call MoveProgress()
        End Set
    End Property
    ''' <summary>
    ''' 進捗バー非表示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ProgressHidden() As Boolean
        Get
            Return _ProgressHidden
        End Get
        Set(ByVal value As Boolean)
            _ProgressHidden = value
            Call MoveProgress()
        End Set
    End Property

#Region "Left"
    ''' <summary>
    ''' 左キャプション文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftText() As String
        Get
            Return _LeftText
        End Get
        Set(ByVal value As String)
            _LeftText = value
            LblLeft.Text = value
        End Set
    End Property
    ''' <summary>
    ''' 左キャプション垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftVAlign() As enumUCP_VAlign
        Get
            Return _LeftVAlign
        End Get
        Set(ByVal value As enumUCP_VAlign)
            _LeftVAlign = value
            Call MoveLabel(LblLeft, _LeftPosition, _LeftVAlign, _LeftHAlign)
        End Set
    End Property
    ''' <summary>
    ''' 左キャプション水平位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftHAlign() As enumUCP_HAlign
        Get
            Return _LeftHAlign
        End Get
        Set(ByVal value As enumUCP_HAlign)
            _LeftHAlign = value
            Call MoveLabel(LblLeft, _LeftPosition, _LeftVAlign, _LeftHAlign)
        End Set
    End Property
    ''' <summary>
    ''' 左キャプション表示位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftPosition() As enumUCP_Position
        Get
            Return _LeftPosition
        End Get
        Set(ByVal value As enumUCP_Position)
            _LeftPosition = value
            Call MoveLabel(LblLeft, _LeftPosition, _LeftVAlign, _LeftHAlign)
        End Set
    End Property
    ''' <summary>
    ''' 左キャプション文字色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftForeColor() As Color
        Get
            Return _LeftForeColor
        End Get
        Set(ByVal value As Color)
            _LeftForeColor = value
            LblLeft.ForeColor = value
        End Set
    End Property
#End Region
#Region "Center"
    ''' <summary>
    ''' ピースキャプション文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionCenterText() As String
        Get
            Return _CenterText
        End Get
        Set(ByVal value As String)
            _CenterText = value
            LblCenter.Text = value
        End Set
    End Property
    ''' <summary>
    ''' ピースキャプション垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionCenterVAlign() As enumUCP_VAlign
        Get
            Return _CenterVAlign
        End Get
        Set(ByVal value As enumUCP_VAlign)
            _CenterVAlign = value
            Call MoveLabel(LblCenter, _CenterPosition, _CenterVAlign, _CenterHAlign)
        End Set
    End Property
    ''' <summary>
    ''' ピースキャプション水平位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionCenterHAlign() As enumUCP_HAlign
        Get
            Return _CenterHAlign
        End Get
        Set(ByVal value As enumUCP_HAlign)
            _CenterHAlign = value
            Call MoveLabel(LblCenter, _CenterPosition, _CenterVAlign, _CenterHAlign)
        End Set
    End Property
    ''' <summary>
    ''' ピースキャプション表示位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionCenterPosition() As enumUCP_Position
        Get
            Return _CenterPosition
        End Get
        Set(ByVal value As enumUCP_Position)
            _CenterPosition = value
            Call MoveLabel(LblCenter, _CenterPosition, _CenterVAlign, _CenterHAlign)
        End Set
    End Property
    ''' <summary>
    ''' ピースキャプション文字色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionCenterForeColor() As Color
        Get
            Return _CenterForeColor
        End Get
        Set(ByVal value As Color)
            _CenterForeColor = value
            LblCenter.ForeColor = value
        End Set
    End Property
#End Region
#Region "Right"
    ''' <summary>
    ''' 右キャプション文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightText() As String
        Get
            Return _RightText
        End Get
        Set(ByVal value As String)
            _RightText = value
            LblRight.Text = value
        End Set
    End Property
    ''' <summary>
    ''' 右キャプション垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightVAlign() As enumUCP_VAlign
        Get
            Return _RightVAlign
        End Get
        Set(ByVal value As enumUCP_VAlign)
            _RightVAlign = value
            Call MoveLabel(LblRight, _RightPosition, _RightVAlign, _RightHAlign)
        End Set
    End Property
    ''' <summary>
    ''' 右キャプション水平位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightHAlign() As enumUCP_HAlign
        Get
            Return _RightHAlign
        End Get
        Set(ByVal value As enumUCP_HAlign)
            _RightHAlign = value
            Call MoveLabel(LblRight, _RightPosition, _RightVAlign, _RightHAlign)
        End Set
    End Property
    ''' <summary>
    ''' 右キャプション表示位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightPosition() As enumUCP_Position
        Get
            Return _RightPosition
        End Get
        Set(ByVal value As enumUCP_Position)
            _RightPosition = value
            Call MoveLabel(LblRight, _RightPosition, _RightVAlign, _RightHAlign)
        End Set
    End Property
    ''' <summary>
    ''' 右キャプション文字色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightForeColor() As Color
        Get
            Return _RightForeColor
        End Get
        Set(ByVal value As Color)
            _RightForeColor = value
            LblRight.ForeColor = value
        End Set
    End Property
#End Region
#End Region
    Private Sub MoveProgress()
        If Not _ProgressHidden Then
            Dim TY As Integer = _ProgressType
            Dim NarrowHight As Integer = (PosiCenter.Height / 8)
            Dim WideHight As Integer = (PosiCenter.Height / 4)
            Select Case TY
                Case 0 '線上
                    LblProgress.Location = New Point(PosiCenter.Location.X, PosiCenter.Location.Y + NarrowHight * 3)
                    LblProgress.Size = New Size(LblCenter.Width * (_ProgressValue / 100), PosiCenter.Height / 4)
                Case 1 '矩形
                    LblProgress.Location = New Point(PosiCenter.Location.X, PosiCenter.Location.Y)
                    LblProgress.Size = New Size(LblCenter.Width * (_ProgressValue / 100), PosiCenter.Height)
                Case 2 '線中央
                    LblProgress.Location = New Point(PosiCenter.Location.X, PosiCenter.Location.Y)
                    LblProgress.Size = New Size(LblCenter.Width * (_ProgressValue / 100), PosiCenter.Height / 4)
                Case 3 '線下
                    LblProgress.Location = New Point(PosiCenter.Location.X, PosiCenter.Location.Y + NarrowHight * 6)
                    LblProgress.Size = New Size(LblCenter.Width * (_ProgressValue / 100), PosiCenter.Height / 4)

                Case 4 '矩形上
                    LblProgress.Location = New Point(PosiCenter.Location.X, PosiCenter.Location.Y)
                    LblProgress.Size = New Size(LblCenter.Width * (_ProgressValue / 100), PosiCenter.Height / 2)
                Case 5 '矩形中央
                    LblProgress.Location = New Point(PosiCenter.Location.X, PosiCenter.Location.Y + WideHight)
                    LblProgress.Size = New Size(LblCenter.Width * (_ProgressValue / 100), PosiCenter.Height / 2)
                Case 6 '矩形下
                    LblProgress.Location = New Point(PosiCenter.Location.X, PosiCenter.Location.Y + WideHight * 2)
                    LblProgress.Size = New Size(LblCenter.Width * (_ProgressValue / 100), PosiCenter.Height / 2)
            End Select
            Call MoveLabel(LblLeft, _LeftPosition, _LeftVAlign, _LeftHAlign)
            'LblProgress.Location = New Point(PosiCenter.Location.X, PosiCenter.Location.Y)
            'LblProgress.Size = New Size(LblCenter.Width * (_ProgressValue / 100), LblProgress.Height)
        Else
            LblProgress.Location = New Point(PosiCenter.Location.X, PosiCenter.Location.Y)
            LblProgress.Size = New Size(0, PosiCenter.Height)
        End If
   
    End Sub
    Private Sub MoveLabel(ByVal Obj As iGreen.Controls.uControls.uLabelX.uLabelX, ByVal Posi As enumUCP_Position, ByVal V As enumUCP_VAlign, ByVal H As enumUCP_HAlign)
        Select Case Posi
            Case enumUCP_Position.Left
                Obj.Location = New Point(PosiLeft.Location)
                Obj.Size = New Size(PosiLeft.Size)
                Select Case V
                    Case enumUCP_VAlign.Top : Obj.TextAlign = ContentAlignment.TopRight
                    Case enumUCP_VAlign.Center : Obj.TextAlign = ContentAlignment.MiddleRight
                    Case enumUCP_VAlign.Bottom : Obj.TextAlign = ContentAlignment.BottomRight
                End Select
            Case enumUCP_Position.Right
                Obj.Location = New Point(PosiRight.Location)
                Obj.Size = New Size(PosiRight.Size)
                Select Case V
                    Case enumUCP_VAlign.Top : Obj.TextAlign = ContentAlignment.TopLeft
                    Case enumUCP_VAlign.Center : Obj.TextAlign = ContentAlignment.MiddleLeft
                    Case enumUCP_VAlign.Bottom : Obj.TextAlign = ContentAlignment.BottomLeft
                End Select
            Case enumUCP_Position.Top
                Obj.Location = New Point(PosiTop.Location)
                Obj.Size = New Size(PosiTop.Size)
                Select Case H
                    Case enumUCP_HAlign.Left : Obj.TextAlign = ContentAlignment.BottomLeft
                    Case enumUCP_HAlign.Center : Obj.TextAlign = ContentAlignment.BottomCenter
                    Case enumUCP_HAlign.Right : Obj.TextAlign = ContentAlignment.BottomRight
                End Select
            Case enumUCP_Position.Bottom
                Obj.Location = New Point(PosiBottom.Location)
                Obj.Size = New Size(PosiBottom.Size)
                Select Case H
                    Case enumUCP_HAlign.Left : Obj.TextAlign = ContentAlignment.TopLeft
                    Case enumUCP_HAlign.Center : Obj.TextAlign = ContentAlignment.TopCenter
                    Case enumUCP_HAlign.Right : Obj.TextAlign = ContentAlignment.TopRight
                End Select
            Case Else
                Obj.Location = New Point(PosiCenter.Location)
                Obj.Size = New Size(PosiCenter.Size)
                Select Case V
                    Case enumUCP_VAlign.Top
                        Select Case H
                            Case enumUCP_HAlign.Left : Obj.TextAlign = ContentAlignment.TopLeft
                            Case enumUCP_HAlign.Center : Obj.TextAlign = ContentAlignment.TopCenter
                            Case enumUCP_HAlign.Right : Obj.TextAlign = ContentAlignment.TopRight
                        End Select
                    Case enumUCP_VAlign.Center
                        Select Case H
                            Case enumUCP_HAlign.Left : Obj.TextAlign = ContentAlignment.MiddleLeft
                            Case enumUCP_HAlign.Center : Obj.TextAlign = ContentAlignment.MiddleCenter
                            Case enumUCP_HAlign.Right : Obj.TextAlign = ContentAlignment.MiddleRight
                        End Select
                    Case enumUCP_VAlign.Bottom
                        Select Case H
                            Case enumUCP_HAlign.Left : Obj.TextAlign = ContentAlignment.BottomLeft
                            Case enumUCP_HAlign.Center : Obj.TextAlign = ContentAlignment.BottomCenter
                            Case enumUCP_HAlign.Right : Obj.TextAlign = ContentAlignment.BottomRight
                        End Select
                End Select
        End Select
    End Sub

    Private Sub UserControlPiece_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()
        _LeftText = "LeftText"
        _LeftVAlign = enumUCP_VAlign.Center
        _LeftHAlign = enumUCP_HAlign.Center
        _LeftPosition = enumUCP_Position.Left
        _LeftForeColor = Color.Black

        _CenterText = "CenterText"
        _CenterVAlign = enumUCP_VAlign.Center
        _CenterHAlign = enumUCP_HAlign.Center
        _CenterPosition = enumUCP_Position.Center
        _CenterForeColor = Color.Black

        _RightText = "RightText"
        _RightVAlign = enumUCP_VAlign.Center
        _RightHAlign = enumUCP_HAlign.Center
        _RightPosition = enumUCP_Position.Right
        _RightForeColor = Color.Black

        LblLeft.Text = _LeftText : LblLeft.ForeColor = _LeftForeColor
        LblCenter.Text = _CenterText : LblCenter.ForeColor = _CenterForeColor
        LblRight.Text = _RightText : LblLeft.ForeColor = _RightForeColor

        _BackColor = PosiCenter.BackColor
        _ProgressBackColor = LblProgress.BackColor
        _ProgressValue = 0
        _ProgressHidden = False
        Call MoveLabel(LblLeft, _LeftPosition, _LeftVAlign, _LeftHAlign)
        Call MoveLabel(LblCenter, _CenterPosition, _CenterVAlign, _CenterHAlign)
        Call MoveLabel(LblRight, _RightPosition, _RightVAlign, _RightHAlign)

        Call MoveProgress()
        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

    Private Sub UserControlPiece_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call MoveLabel(LblLeft, _LeftPosition, _LeftVAlign, _LeftHAlign)
        Call MoveLabel(LblCenter, _CenterPosition, _CenterVAlign, _CenterHAlign)
        Call MoveLabel(LblRight, _RightPosition, _RightVAlign, _RightHAlign)
        Call MoveProgress()
    End Sub
End Class
