Imports System.ComponentModel
<DefaultEvent("AlignmentChaned")> _
Public Class UserControlTextAlignment2
    Dim _SelectnAlignment As ContentAlignment
    Dim _IsHorizon As Boolean = False
    ''' <summary>
    ''' 水平配置を行う
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsHorizon As Boolean
        Get
            Return _IsHorizon
        End Get
        Set(value As Boolean)
            _IsHorizon = value
            If value Then
                GroupBox2.Location = New Point(88, -5)
                Me.Size = New Size(175, 37)
            Else
                GroupBox2.Location = New Point(0, 31)
                Me.Size = New Size(87, 74)

            End If
        End Set
    End Property
    ''' <summary>
    ''' 選択位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SelectedAlignment() As ContentAlignment
        Get
            Return SeekButton()
        End Get
        Set(ByVal value As ContentAlignment)
            'Dim lNum As Int32 = CType(Math.Log(CType(value, Double), 2), Int32)
            'Select Case (CType((lNum Mod 4), StringAlignment))
            '    Case 0 : OptH0.Checked = True
            '    Case 1 : OptH1.Checked = True
            '    Case Else : OptH2.Checked = True
            'End Select
            'Select Case (CType((lNum / 4), StringAlignment))
            '    Case 0 : OptV0.Checked = True
            '    Case 1 : OptV1.Checked = True
            '    Case Else : OptV2.Checked = True
            'End Select
            Select Case value
                Case ContentAlignment.TopLeft, ContentAlignment.MiddleLeft, ContentAlignment.BottomLeft
                    OptH0.Checked = True
                Case ContentAlignment.TopCenter, ContentAlignment.MiddleCenter, ContentAlignment.BottomCenter
                    OptH1.Checked = True
                Case Else
                    OptH2.Checked = True
            End Select
            Select Case value
                Case ContentAlignment.TopLeft, ContentAlignment.TopCenter, ContentAlignment.TopRight
                    OptV0.Checked = True
                Case ContentAlignment.MiddleLeft, ContentAlignment.MiddleCenter, ContentAlignment.MiddleRight
                    OptV1.Checked = True
                Case Else
                    OptV2.Checked = True
            End Select
        End Set
    End Property
    ''' <summary>
    ''' 選択中の位置を取得する
    ''' </summary>
    ''' <returns>選択位置</returns>
    ''' <remarks></remarks>
    Private Function SeekButton() As ContentAlignment
        Dim H As Integer = 0
        Dim V As Integer = 0
        Select Case True
            Case OptH0.Checked : H = 0
            Case OptH1.Checked : H = 1
            Case Else : H = 2
        End Select
        Select Case True
            Case OptV0.Checked : V = 0
            Case OptV1.Checked : V = 1
            Case Else : V = 2
        End Select

        'Return (16 ^ CInt(V)) * (2 ^ CInt(H))
        Select Case V
            Case 0
                Select Case H
                    Case 0 : Return ContentAlignment.TopLeft
                    Case 1 : Return ContentAlignment.TopCenter
                    Case Else : Return ContentAlignment.TopRight
                End Select
            Case 1
                Select Case H
                    Case 0 : Return ContentAlignment.MiddleLeft
                    Case 1 : Return ContentAlignment.MiddleCenter
                    Case Else : Return ContentAlignment.MiddleRight
                End Select
            Case Else
                Select Case H
                    Case 0 : Return ContentAlignment.BottomLeft
                    Case 1 : Return ContentAlignment.BottomCenter
                    Case Else : Return ContentAlignment.BottomRight
                End Select
        End Select

    End Function
    ''' <summary>
    ''' 選択されている垂直位置を取得する
    ''' </summary>
    ''' <returns>選択垂直位置番号</returns>
    ''' <remarks></remarks>
    Public Function GetSetV() As Integer
        Select Case True
            Case OptV0.Checked : Return 0
            Case OptV1.Checked : Return 1
            Case Else : Return 2
        End Select
    End Function
    ''' <summary>
    ''' 選択されている水平位置を取得する
    ''' </summary>
    ''' <returns>選択垂直位置番号</returns>
    ''' <remarks></remarks>
    Public Function GetSetH() As Integer
        Select Case True
            Case OptH0.Checked : Return 0
            Case OptH1.Checked : Return 1
            Case Else : Return 2
        End Select
    End Function

    ''' <summary>
    ''' 選択位置が変更された時に発生します。
    ''' </summary>
    ''' <param name="SelectdAlignment">選択位置</param>
    ''' <param name="HAlign">水平選択位置</param>
    ''' <param name="VAlign">垂直選択位置</param>
    ''' <remarks>
    ''' </remarks>
    Public Event AlignmentChaned(SelectdAlignment As ContentAlignment, HAlign As Integer, VAlign As Integer)

    ''' <summary>
    ''' 位置が選択されると発生します。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OptionChanged(sender As Object, e As EventArgs) Handles OptH0.CheckedChanged, OptH1.CheckedChanged, OptH2.CheckedChanged, OptV0.CheckedChanged, OptV1.CheckedChanged, OptV2.CheckedChanged
        RaiseEvent AlignmentChaned(SeekButton, GetSetH, GetSetV)
    End Sub
End Class
