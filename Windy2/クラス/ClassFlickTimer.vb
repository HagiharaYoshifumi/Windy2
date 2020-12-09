''' <summary>
''' 点滅タイマー
''' </summary>
''' <remarks></remarks>
Public Class ClassFlickTimer
    Dim WithEvents Tim As New Timer
    Public Event Flick(ByVal Value As Boolean)
    ''' <summary>
    ''' 点滅間隔（既定：０．５秒）
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Intarval As Integer
        Get
            Return Tim.Interval
        End Get
        Set(value As Integer)
            Tim.Interval = value
        End Set
    End Property
    ''' <summary>
    ''' 点滅タイマ有効・無効
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Enable As Boolean
        Get
            Return Tim.Enabled
        End Get
        Set(value As Boolean)
            If value Then
                _Flg = False
            End If
            Tim.Enabled = value
        End Set
    End Property

    Dim _Flg As Boolean = False
    Private Sub Tim_Tick(sender As Object, e As EventArgs) Handles Tim.Tick
        _Flg = Not _Flg
        RaiseEvent Flick(_Flg)
    End Sub

    Sub New()
        Tim.Interval = 500
        Tim.Enabled = False
    End Sub


End Class
