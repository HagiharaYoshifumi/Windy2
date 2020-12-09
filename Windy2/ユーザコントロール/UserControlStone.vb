Public Class UserControlStone
    ''' <summary>
    ''' 垂直位置
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumUCP_VAlign
        ''' <summary>
        ''' 上
        ''' </summary>
        ''' <remarks></remarks>
        Top
        ''' <summary>
        ''' 中間
        ''' </summary>
        ''' <remarks></remarks>
        Center
        ''' <summary>
        ''' 下
        ''' </summary>
        ''' <remarks></remarks>
        Bottom
    End Enum
    ''' <summary>
    ''' 水平位置
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumUCP_HAlign
        ''' <summary>
        ''' 左
        ''' </summary>
        ''' <remarks></remarks>
        Left
        ''' <summary>
        ''' 真ん中
        ''' </summary>
        ''' <remarks></remarks>
        Center
        ''' <summary>
        ''' 右
        ''' </summary>
        ''' <remarks></remarks>
        Right
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

    Dim _RightText As String = ""
    Dim _RightVAlign As enumUCP_VAlign = enumUCP_VAlign.Center
    Dim _RightHAlign As enumUCP_HAlign = enumUCP_HAlign.Center
    Dim _RightPosition As enumUCP_Position = enumUCP_Position.Left
    Dim _RightForeColor As Color

#Region "Property"

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

        _RightText = "RightText"
        _RightVAlign = enumUCP_VAlign.Center
        _RightHAlign = enumUCP_HAlign.Center
        _RightPosition = enumUCP_Position.Right
        _RightForeColor = Color.Black

        LblLeft.Text = _LeftText : LblLeft.ForeColor = _LeftForeColor
        LblRight.Text = _RightText : LblLeft.ForeColor = _RightForeColor

        Call MoveLabel(LblLeft, _LeftPosition, _LeftVAlign, _LeftHAlign)
        Call MoveLabel(LblRight, _RightPosition, _RightVAlign, _RightHAlign)

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

    Private Sub UserControlPiece_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call MoveLabel(LblLeft, _LeftPosition, _LeftVAlign, _LeftHAlign)
        Call MoveLabel(LblRight, _RightPosition, _RightVAlign, _RightHAlign)
    End Sub

    Private Sub PosiLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PosiLeft.Click

    End Sub

    Private Sub PosiRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PosiRight.Click

    End Sub

    Private Sub LblRight_Click(sender As Object, e As EventArgs) Handles LblRight.Click

    End Sub
End Class
