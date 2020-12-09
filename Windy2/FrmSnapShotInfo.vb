Public Class FrmSnapShotInfo
#Region "Property"
    ''' <summary>
    ''' タイムビューオブジェクト
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Obj As AxKnTViewLib.AxKnTView
    ''' <summary>
    ''' 設定アウトプットインフォ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property OutputInfo As New KnTViewLib.OutputInfo
#End Region

    Private Sub FrmSnapShotInfo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmSnapShotInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Initial()
    End Sub
    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initial()
        Try
            TxtStartRowIndex.Value = 1
            TxtFinRowIndex.Value = Obj.Items.Count
            TxtStartRowIndex.Maximum = TxtFinRowIndex.Value
            TxtFinRowIndex.Maximum = TxtFinRowIndex.Value

            TxtStartColIndex.Value = 1
            TxtFinColIndex.Value = _Obj.ColumnHeaders.Count
            TxtStartColIndex.Maximum = TxtFinColIndex.Value
            TxtFinColIndex.Maximum = TxtFinColIndex.Value

            Dim S As Date = Nothing
            Dim E As Date = Nothing
            With _Obj
                For Row As Integer = 1 To .Items.Count
                    With .Items.Item(Row)
                        If .Pieces.Count > 0 Then
                            For Col As Integer = 1 To .Pieces.Count
                                With .Pieces.Item(Col)
                                    If Not IsDBNull(.Start) Then
                                        Dim SS As Date = CDate(.Start)
                                        If S.ToOADate = 0 OrElse SS < S Then
                                            S = SS
                                        End If
                                    End If

                                    If .StartShape.Shape = KnTViewLib.TivPointShape.tivPointShapeImage Then
                                        If Not IsDBNull(.Start) Then
                                            Dim EE As Date = CDate(.Start)
                                            If E.ToOADate = 0 OrElse E < EE Then
                                                E = EE
                                            End If
                                        End If
                                    Else
                                        If Not IsDBNull(.Finish) Then
                                            Dim EE As Date = CDate(.Finish)
                                            If E.ToOADate = 0 OrElse E < EE Then
                                                E = EE
                                            End If
                                        End If
                                    End If
                                End With
                            Next
                        End If
                    End With
                Next
            End With

            S = DateAdd(DateInterval.Day, 0 - _PrintDay, S)
            E = DateAdd(DateInterval.Day, _PrintDay, E)

            TxtStartDate.Value = S
            TxtFinDate.Value = E
        Catch ex As Exception
            Logs.PutErrorEx("初期化失敗", ex)
        End Try
   
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If TxtStartDate.Value > TxtFinDate.Value Then
            MsgBox("設定開始・終了日付が不正です。", 48, "エラー")
            Return
        End If
        OutputInfo.StartIndex = TxtStartRowIndex.Value
        OutputInfo.FinishIndex = TxtFinRowIndex.Value
        OutputInfo.StartColumn = TxtStartColIndex.Value
        OutputInfo.FinishColumn = TxtFinColIndex.Value
        OutputInfo.StartTime = String.Format("{0:yyyy/MM/dd 00:00:00}", TxtStartDate.Value)
        OutputInfo.FinishTime = String.Format("{0:yyyy/MM/dd 23:59:59}", TxtFinDate.Value)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class