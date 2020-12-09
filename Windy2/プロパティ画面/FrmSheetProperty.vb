''' <summary>
''' シートプロパティ
''' </summary>
''' <remarks></remarks>
Public Class FrmSheetProperty
    Dim FC As New ClassFormControl()
#Region "Property"
    'Property TargetTV As AxKnTViewLib.AxKnTView
    Property TargetForm As FrmMain

    ''' <summary>
    ''' タイトル
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Titile() As String
    ''' <summary>
    ''' 作成者
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SheetOwner() As String
    ''' <summary>
    ''' 重なりピースレイアウト
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PieceLayout() As Integer
    ''' <summary>
    ''' 排他制御の仕様
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsExclusion() As Boolean
    ''' <summary>
    ''' 排他パスワード
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ExclusionPassword() As String
    ''' <summary>
    ''' ピース連動
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsWaterFall() As Boolean
    ''' <summary>
    ''' ピース連動（ロックピース除外）
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsWaterFallLock() As Boolean
    ''' <summary>
    ''' セル日付書式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CellDateFormat() As String
    ''' <summary>
    ''' 無値時表示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property NACellValue() As String
    ''' <summary>
    ''' 一時ロック
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property TemporaryLock As Boolean
    ''' <summary>
    ''' ロード時一時ロック使用
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LoadLock As Boolean
    ''' <summary>
    ''' インデントレベル
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IndentLevel() As Integer
#End Region
    ''' <summary>
    ''' ＯＫボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If ChkIsExclusion.Checked Then
            Select Case True
                Case String.IsNullOrWhiteSpace(TxtPassword1.Text)
                    MsgBox("パスワード１が未入力です", 48, "エラー")
                    Return
                Case String.IsNullOrWhiteSpace(TxtPassword2.Text)
                    MsgBox("パスワード２が未入力です", 48, "エラー")
                    Return
                Case TxtPassword1.Text <> TxtPassword2.Text
                    MsgBox("パスワードが違います", 48, "エラー")
                    Return
                Case String.IsNullOrWhiteSpace(TxtCellDateFormat.Text)
                    If MsgBox("セル日付書式が設定されていません。" & vbCrLf & "作業を続行しますか？", 4 + 32, "確認") = MsgBoxResult.No Then
                        Return
                    End If
            End Select
        End If
        _Titile = TxtTitle.Text
        _SheetOwner = TxtOwner.Text
        _PieceLayout = CmbPieceLayout.SelectedIndex
        _IsExclusion = ChkIsExclusion.Checked
        _ExclusionPassword = IIf(ChkIsExclusion.Checked, TxtPassword1.Text, "")
        _IsWaterFall = ChkIsWaterFall.Checked
        _IsWaterFallLock = ChkIsWaterFallLock.Checked
        _CellDateFormat = TxtCellDateFormat.Text
        _NACellValue = TxtNACellValue.Text
        _TemporaryLock = ChkTemporaryLock.Checked
        _LoadLock = ChkLoadLock.Checked
        _IndentLevel = TxtIndentLevel.Value
       
        FC.Edited = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMainProperty_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMainProperty_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub FrmMainProperty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FC.TargetForm = Me
        FC.Title = Me.Text

        TxtTitle.Text = _Titile
        TxtOwner.Text = _SheetOwner
        CmbPieceLayout.SelectedIndex = _PieceLayout
        ChkIsExclusion.Checked = _IsExclusion
        If _IsExclusion Then
            TxtPassword1.Text = _ExclusionPassword
            TxtPassword2.Text = _ExclusionPassword
        End If
        ChkIsWaterFall.Checked = _IsWaterFall
        ChkIsWaterFallLock.Checked = _IsWaterFallLock
        ChkIsWaterFallLock.Enabled = ChkIsWaterFall.Checked

        TxtCellDateFormat.Text = _CellDateFormat
        TxtNACellValue.Text = _NACellValue
        ChkTemporaryLock.Checked = _TemporaryLock
        ChkLoadLock.Checked = _LoadLock
        Select Case _IndentLevel
            Case Is < TxtIndentLevel.Minimum : TxtIndentLevel.Value = TxtIndentLevel.Minimum
            Case Is > TxtIndentLevel.Maximum : TxtIndentLevel.Value = TxtIndentLevel.Maximum
            Case Else
                TxtIndentLevel.Value = _IndentLevel
        End Select

        Call FC.ScanTargetControl() '対象コントロールイベント追加
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
    ''' 排他モード使用が変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkIsExclusion_CheckedChanged(sender As Object, e As EventArgs) Handles ChkIsExclusion.CheckedChanged
        TxtPassword1.Enabled = ChkIsExclusion.Checked
        TxtPassword2.Enabled = ChkIsExclusion.Checked
    End Sub
    ''' <summary>
    ''' ピース連動が変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkIsWaterFall_CheckedChanged(sender As Object, e As EventArgs) Handles ChkIsWaterFall.CheckedChanged
        ChkIsWaterFallLock.Enabled = ChkIsWaterFall.Checked
    End Sub
    ''' <summary>
    ''' 拡張操作ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExpansionWork_Click(sender As Object, e As EventArgs) Handles BtnExpansionWork.Click
        With FrmExpansionWork
            .TargetFrm = _TargetForm
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

            End If
        End With
    End Sub
End Class