
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports iGreen.Controls.uControls.uLabelX.Common
Imports System.Runtime.InteropServices

''' <summary>
''' iGreen.Controls.uControls.uLabelX.uLabelX { .Net Transparent Label Control Class}
''' </summary>
''' <remarks>.Net Transparent <see cref="Label"></see> Control</remarks>
<ComVisible(False), Designer(GetType(uLabelXDesigner)), ClassInterface(ClassInterfaceType.AutoDispatch), _
        DefaultProperty("Text"), DefaultEvent("Click")> _
        <ToolboxBitmap("../../Resources/star.png"), ToolboxItem(True), _
        Description("iGreen's uLabelX Transparent Label Control..")> _
Public Class uLabelX
    Inherits Control

    ''' <summary>
    ''' Event Invoked when Property Changed
    ''' </summary>
    ''' <param name="_RecreateHandle">Flag to set control handle to be create again or not</param>
    ''' <remarks></remarks>
    Protected Event PropertyChanged(ByVal _RecreateHandle As Boolean)

    Private m_TextAlign As ContentAlignment = ContentAlignment.MiddleCenter
    Private m_BorderStyle As iGreen.Controls.uControls.uLabelX.Common.BorderStyles
    Private m_BorderDashStyle As System.Drawing.Drawing2D.DashStyle = DashStyle.Solid
    Private m_BorderWidth As Single = 1
    Private m_BorderColor As Color = Color.Black
    Private m_Image As Image
    Private m_ImageSize As ImageSizes = ImageSizes.x16x16

    ''' <summary>
    ''' Initializes a new instance of the <see cref="uLabelX"></see> control class.
    ''' <example>Private <i>instance</i> As <see cref="uLabelX">New</see> uLabelX</example>
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()

        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.Opaque, False)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, False)

        AddHandler Me.PropertyChanged, AddressOf OnPropertyChanged
        RaiseEvent PropertyChanged(False)

    End Sub

    ''' <summary>
    ''' Invoked when Property Changed <br></br><br></br>
    ''' <example><i>Declaration :</i> Protected Event <see cref="PropertyChanged"></see>(ByVal _RecreateHandle As Boolean)<br></br>
    ''' <i>On Constructor :</i> AddHandler <see cref="PropertyChanged"></see>, AddressOf <see cref="OnPropertyChanged"></see>
    ''' </example>
    ''' </summary>
    ''' <remarks><i>How to Call..? >> : </i>RaiseEvent <see cref="PropertyChanged"></see>()</remarks>
    Private Sub OnPropertyChanged(ByVal _RecreateHandle As Boolean)
        If (Not Me.Parent Is Nothing) Then
            'Dim _ControlRect As Rectangle = New Rectangle(Me.Location, Me.Size)
            'Me.Parent.Invalidate(_ControlRect, True)
        End If
        If (_RecreateHandle = True) Then Me.RecreateHandle()
        Me.Invalidate()
    End Sub

    ''' <summary>
    ''' Gets or sets the Image of the control, An abstract base class that provides functionality for the <see cref="Bitmap"></see> and Metafile descended classes.
    ''' </summary>
    ''' <value></value>
    ''' <returns>The Image As <see cref="System.Drawing.Image"></see> of the control. The default is the value of the <see cref="iGreen.Controls.uControls.uLabelX.uLabelX.Image"></see> property.</returns>
    ''' <remarks></remarks>
    <Browsable(True), Category("Image"), Description("Gets or sets the specified image / logo for the control.")> _
    Public Property Image() As Image
        Get
            Return m_Image
        End Get
        Set(ByVal value As Image)
            m_Image = value
            RaiseEvent PropertyChanged(True)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ImageSize of the control. Specifies the Image Size of Control
    ''' </summary>
    ''' <value></value>
    ''' <returns>The ImageSize As <see cref="iGreen.Controls.uControls.uLabelX.Common.ImageSizes"></see> of the control. The default is the value of the <see cref="iGreen.Controls.uControls.uLabelX.uLabelX.ImageSize"></see> property.</returns>
    ''' <remarks></remarks>
    <Browsable(True), Category("Image"), Description("Gets the specified Image size for the style.")> _
    Public ReadOnly Property ImageSize() As ImageSizes
        Get
            Return m_ImageSize
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the BorderStyle of the control, Specifies the border style of Control
    ''' </summary>
    ''' <value></value>
    ''' <returns>The BorderStyle As <see cref="iGreen.Controls.uControls.uLabelX.Common.BorderStyles"></see> of the control. The default is the value of the <see cref="iGreen.Controls.uControls.uLabelX.uLabelX.BorderStyle"></see> property.</returns>
    ''' <remarks></remarks>
    <Browsable(True), Category("Border"), Description("Gets or sets the specified border style for the style.")> _
    Public Shadows Property BorderStyle() As iGreen.Controls.uControls.uLabelX.Common.BorderStyles
        Get
            Return m_BorderStyle
        End Get
        Set(ByVal value As iGreen.Controls.uControls.uLabelX.Common.BorderStyles)
            m_BorderStyle = value
            RaiseEvent PropertyChanged(True)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the BorderDashStyle of the control, Specifies the border dash style of Control
    ''' </summary>
    ''' <value></value>
    ''' <returns>The BorderDashStyle As <see cref="System.Drawing.Drawing2D.DashStyle"></see> of the control. The default is the value of the iGreen.Controls.uControls.uLabelX.BorderDashStyle property.</returns>
    ''' <remarks></remarks>
    <Browsable(True), Category("Border"), Description("Gets or sets the specified border dash style for the style.")> _
    Public Property BorderDashStyle() As System.Drawing.Drawing2D.DashStyle
        Get
            Return m_BorderDashStyle
        End Get
        Set(ByVal value As System.Drawing.Drawing2D.DashStyle)
            m_BorderDashStyle = value
            RaiseEvent PropertyChanged(True)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the BorderWidth of the control, Represents a 32-bit signed integer.
    ''' </summary>
    ''' <value></value>
    ''' <returns>The BorderWidth <see cref="System.Int32"></see> of the control. The default is the value of the iGreen.Controls.uControls.uLabelX.BorderWidth property.</returns>
    ''' <remarks></remarks>
    <Browsable(True), Category("Border"), Description("Gets or sets the specified border width for the style.")> _
    Public Property BorderWidth() As Single
        Get
            Return m_BorderWidth
        End Get
        Set(ByVal value As Single)
            m_BorderWidth = value
            RaiseEvent PropertyChanged(True)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the BorderColor of the control, Represents an ARGB (alpha, red, green, blue) color
    ''' </summary>
    ''' <value></value>
    ''' <returns>The BorderColor System.Drawing.Color of the control. The default is the value of the iGreen.Controls.uControls.uLabelX.BorderColor property.</returns>
    ''' <remarks></remarks>
    <Browsable(True), Category("Border"), Description("Gets or sets the specified border color for the style.")> _
    Public Property BorderColor() As Color
        Get
            Return m_BorderColor
        End Get
        Set(ByVal value As Color)
            m_BorderColor = value
            RaiseEvent PropertyChanged(True)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the Text of the control, Represents Text as a series of Unicode characters.
    ''' </summary>
    ''' <value></value>
    ''' <returns>The Text System.String of the control. The default is the value of the iGreen.Controls.uControls.uLabelX.Text property.</returns>
    ''' <remarks></remarks>
    <Browsable(True), Category("Text"), Description("Gets or sets the text inside the control")> _
    Public Overrides Property Text() As String
        Get
            Return Replace(MyBase.Text, "ULabelX", "uLabelX")
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            RaiseEvent PropertyChanged(True)
        End Set
    End Property

    ''' <summary>
    ''' Specifies alignment of <see cref="Text"></see> on the control. Placement and direction of text in relation to the control border 
    ''' </summary>
    ''' <value></value>
    ''' <returns>The TextAlign As <see cref="System.Drawing.ContentAlignment"></see>The default is the value of the <see cref="TextAlign"></see> property.</returns>
    ''' <remarks></remarks>
    <Browsable(True), Category("Text"), Description("Gets or sets the alignment of text inside the control")> _
    Public Property TextAlign() As ContentAlignment
        Get
            Return m_TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            m_TextAlign = value
            RaiseEvent PropertyChanged(True)
        End Set
    End Property

    ''' <summary>
    ''' Summarize the information needed when creating a control.
    ''' </summary>
    ''' <value></value>
    ''' <returns>CreateParams As <see cref="System.Windows.Forms.CreateParams"></see></returns>
    ''' <remarks>Overrides base class <see cref="Control"></see> CreateParams property<br></br>Inherits <see cref="System.Object"></see> <br></br>Member of: <see cref="System.Windows.Forms"></see></remarks>
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim _Cp As CreateParams = MyBase.CreateParams
            _Cp.ExStyle = _Cp.ExStyle Or &H20
            Return _Cp
        End Get
    End Property

    ''' <summary>
    ''' Call(s) to Paints the control background.
    ''' </summary>
    ''' <param name="e">A System.Windows.Forms.PaintEventArgs that contains the event data.</param>
    ''' <remarks><b>Here don't allow the background to be painted</b>, <i>Otherwise the background draw task spoil the recently repainted parent control content by crushing out the OnPaintBackground() method </i></remarks>
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        ' NOTHING TODO:
    End Sub

    ''' <summary>
    ''' Raises the iGreen.Controls.uControls.uLabelX.uLabelX.TabIndexChanged event.
    ''' </summary>
    ''' <param name="e">An <see cref="System.EventArgs"></see> that contains the event data.</param>
    ''' <remarks>Temporary solution for copy and paste uLabelX control name display issue</remarks>
    Protected Overrides Sub OnTabIndexChanged(ByVal e As System.EventArgs)
        If (String.Compare(Me.Text, 0, "ULabelX", 0, 7, True) = 0) Then
            Me.Text = Me.Name
        End If
    End Sub

    ''' <summary>
    ''' Raises the iGreen.Controls.uControls.uLabelX.uLabelX.FontChanged event.
    ''' </summary>
    ''' <param name="e">An System.EventArgs that contains the event data.</param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)
        RaiseEvent PropertyChanged(True)
    End Sub
    ''' <summary>
    ''' Raises the iGreen.Controls.uControls.uLabelX.uLabelX.ForeColorChanged event.
    ''' </summary>
    ''' <param name="e">An System.EventArgs that contains the event data.</param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnForeColorChanged(ByVal e As System.EventArgs)
        RaiseEvent PropertyChanged(True)
    End Sub

    ''' <summary>
    ''' Raises the System.Windows.Forms.Control.Paint event, Call(s) to <b>RePaint</b> the control using the method <b><i>instance</i>.Invalidate()</b>
    ''' </summary>
    ''' <param name="e">A System.Windows.Forms.PaintEventArgs that contains the event data.</param>
    ''' <remarks>Overrides base class <seealso cref="Control">MyBase</seealso> OnPaint()</remarks>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.CompositingMode = CompositingMode.SourceOver
        e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Call DrawControlBorder(e.Graphics, Me.ClientRectangle)
        Call DrawControlText(e.Graphics, Me.ClientRectangle)
        Call DrawControlImage(e.Graphics, Me.ClientRectangle)
    End Sub

    ''' <summary>
    ''' Call this from OnPaint() to Draw Control's Border 
    ''' </summary>
    ''' <param name="g">Graphics Object Used to Paint</param>
    ''' <param name="_ClientRect">The Rectangle that represents the client area of the control.</param>
    ''' <remarks></remarks>
    Protected Sub DrawControlBorder(ByRef g As Graphics, ByVal _ClientRect As Rectangle)
        Dim ObjPen As New Pen(m_BorderColor, m_BorderWidth)

        _ClientRect.Width = _ClientRect.Width - 1
        _ClientRect.Height = _ClientRect.Height - 1

        Select Case m_BorderStyle
            Case Common.BorderStyles.None
                Exit Sub
                ' DO NOTHING
            Case Common.BorderStyles.FixedSingle
                ObjPen.DashStyle = DashStyle.Solid
                ObjPen.Width = 1
                ObjPen.Color = Color.Black
            Case Common.BorderStyles.Fixed3D
                ObjPen.DashStyle = DashStyle.Solid
                ObjPen.Width = 2
                ObjPen.Color = Color.Gray
                g.DrawRectangle(ObjPen, _ClientRect.X, _ClientRect.Y, _ClientRect.Width - 1, _ClientRect.Height - 1)
            Case Common.BorderStyles.uControlStyle
                ObjPen.DashStyle = m_BorderDashStyle
        End Select

        g.DrawRectangle(ObjPen, _ClientRect)
        ObjPen.Dispose()

    End Sub

    ''' <summary>
    ''' Call this from OnPaint() to Draw Control's Text
    ''' </summary>
    ''' <param name="g">Graphics Object Used to Paint</param>
    ''' <remarks></remarks>
    Protected Sub DrawControlText(ByRef g As Graphics, ByVal _ClientRect As Rectangle)
        If (Not IsNothing(m_Image)) Then _ClientRect.Width = _ClientRect.Width - 16
        Dim _TextRect As Rectangle = GetTextRectangle(Me.Text, Me.Font, g, _ClientRect, Me.TextAlign)
        g.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), _TextRect)
    End Sub

    ''' <summary>
    ''' Call this from OnPaint() to Draw Control's Image
    ''' </summary>
    ''' <param name="g">Graphics Object Used to Paint</param>
    ''' <param name="_ClientRect">The Rectangle that represents the client area of the control.</param>
    ''' <remarks></remarks>
    Protected Sub DrawControlImage(ByRef g As Graphics, ByVal _ClientRect As Rectangle)
        If (Not IsNothing(m_Image)) Then
            g.DrawImage(m_Image, (_ClientRect.Width - 18), CInt(Fix((_ClientRect.Height / 2) - 8)), m_ImageSize, m_ImageSize)
        End If
    End Sub

    ''' <summary>
    ''' Get(s) the Text Rectangle to draw String, Call this from OnPaint() to Draw Control's Text
    ''' </summary>
    ''' <param name="_Text">Gets or sets the Text of the control, Represents Text as a series of Unicode characters.</param>
    ''' <param name="_Font">System.Drawing.Font, Defines a particular format for text, including font face, size, and style attributes. </param>
    ''' <param name="g">Graphics Object Used to Paint</param>
    ''' <param name="_ClientRect">The Rectangle that represents the client area of the control.</param>
    ''' <param name="_TextAlign">Specifies alignment of text on the control.</param>
    ''' <returns></returns>
    ''' <remarks>Public Enum System.Drawing.ContentAlignment As Integer</remarks>
    Protected Function GetTextRectangle(ByVal _Text As String, ByVal _Font As Font, ByRef g As Graphics, _
                                    ByVal _ClientRect As Rectangle, ByVal _TextAlign As ContentAlignment) As Rectangle
        Dim _TextSize As SizeF = g.MeasureString(_Text, _Font)
        Dim _TextLeft As Integer
        _TextSize.Width = _TextSize.Width + 4

        Select Case _TextAlign
            Case ContentAlignment.TopLeft
                Return _ClientRect
            Case ContentAlignment.TopCenter
                _TextLeft = (_ClientRect.Width / 2) - (CInt(Fix(_TextSize.Width)) / 2)
                Return _
                    New Rectangle((_ClientRect.Left + _TextLeft), _ClientRect.Top, CInt(Fix(_TextSize.Width)), _
                                   CInt(Fix(_TextSize.Height)))
            Case ContentAlignment.TopRight
                _TextLeft = (_ClientRect.Width - _TextSize.Width)
                Return _
                    New Rectangle((_ClientRect.Left + _TextLeft), _ClientRect.Top, CInt(Fix(_TextSize.Width)), _
                                   CInt(Fix(_TextSize.Height)))
            Case ContentAlignment.MiddleLeft
                Return _
                    New Rectangle(_ClientRect.Left, CInt(Fix(_ClientRect.Height / 2)) - CInt(Fix(_TextSize.Height / 2)), _
                                   CInt(Fix(_TextSize.Width)), CInt(Fix(_TextSize.Height)))
            Case ContentAlignment.MiddleCenter
                _TextLeft = (_ClientRect.Width / 2) - (CInt(Fix(_TextSize.Width)) / 2)
                Return _
                    New Rectangle((_ClientRect.Left + _TextLeft), _
                                   CInt(Fix(_ClientRect.Height / 2)) - CInt(Fix(_TextSize.Height / 2)), _
                                   CInt(Fix(_TextSize.Width)), CInt(Fix(_TextSize.Height)))
            Case ContentAlignment.MiddleRight
                _TextLeft = (_ClientRect.Width - _TextSize.Width)
                Return _
                    New Rectangle((_ClientRect.Left + _TextLeft), _
                                   CInt(Fix(_ClientRect.Height / 2)) - CInt(Fix(_TextSize.Height / 2)), _
                                   CInt(Fix(_TextSize.Width)), CInt(Fix(_TextSize.Height)))
            Case ContentAlignment.BottomLeft
                Return _
                    New Rectangle(_ClientRect.Left, CInt(Fix(_ClientRect.Bottom - _TextSize.Height)), _
                                   CInt(Fix(_TextSize.Width)), CInt(Fix(_TextSize.Height)))
            Case ContentAlignment.BottomCenter
                _TextLeft = (_ClientRect.Width / 2) - (CInt(Fix(_TextSize.Width)) / 2)
                Return _
                    New Rectangle((_ClientRect.Left + _TextLeft), CInt(Fix(_ClientRect.Bottom - _TextSize.Height)), _
                                   CInt(Fix(_TextSize.Width)), CInt(Fix(_TextSize.Height)))
            Case ContentAlignment.BottomRight
                _TextLeft = (_ClientRect.Width - _TextSize.Width)
                Return _
                    New Rectangle((_ClientRect.Left + _TextLeft), CInt(Fix(_ClientRect.Bottom - _TextSize.Height)), _
                                   CInt(Fix(_TextSize.Width)), CInt(Fix(_TextSize.Height)))
        End Select
    End Function
End Class
