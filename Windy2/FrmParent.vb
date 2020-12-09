Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.WindowsAPICodePack
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports Microsoft.WindowsAPICodePack.Dialogs.Controls
Public Class FrmParent
    Dim _OpenFileName As New List(Of String)
    Dim _SplitOpend As Boolean = False 'スプリットボタンサブメニュー表示中
#Region "ファイル"
    ''' <summary>
    ''' 新規作成
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles MenuNewFile.Click, ToolButton_NewFile.ButtonClick, NewWindowToolStripMenuItem.Click
        ' 子フォームの新しいインスタンスを作成します
        Dim ChildForm As New FrmMain
        ' 表示する前に、この MDI フォームの子に設定します
        ChildForm.MdiParent = Me
        ChildForm.WindowState = FormWindowState.Maximized

        m_ChildFormNumber += 1

        Call SetIconImage(ChildForm.TView) 'アイコンイメージセット

        ChildForm.Show()
        Logs.PutInformation("新規作成")
        '設定したアイコンが正しく表示されない対策
        ToolStrip.Visible = False
        ToolStrip.Visible = True
        ChildForm.EnableUndo = True 'UNDO有効
    End Sub
    ''' <summary>
    ''' テンプレートファイルを開く
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_NewFile_Temprate_Click(sender As Object, e As EventArgs) Handles ToolButton_NewFile_Temprate.Click, Menu_NewFile_Temprate.Click
        Dim FileName As String = ""
        Dim LK As Boolean = False
        Using OFD As New OpenFileDialog
            With OFD
                .AddExtension = True
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = ".wtf"
                .Filter = "Windyテンプレートファイル(*.wtf)|*.wtf|全てのファイル(*.*)|*.*"
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
            Dim _TI As String = OpenFile(FileName)
            'Call FileListAdd(_TI, FileName)'テンプレートファイルは読み込み履歴に追加しない
            Logs.PutInformation("テンプレートファイル", FileName)
        End If
    End Sub
    ''' <summary>
    ''' ファイルを開く
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles MenuOpenFile.Click, ToolButton_OpenFile.Click
        Dim FileName As String = ""
        Dim LK As Boolean = False 'ロックモードフラグ
        Dim EM As Boolean = True '編集モードフラグ

        'https://www.ipentec.com/document/csharp-customize-open-file-dialog
        Dim dialog As CommonOpenFileDialog = New CommonOpenFileDialog

        'Dim AA As New CommonFileDialogLabel
        'AA.Text = "ファイルを開く際の動作方法選択"
        'dialog.Controls.Add(AA)

        'Dim ABC As New Microsoft.WindowsAPICodePack.Dialogs.Controls.CommonFileDialogRadioButtonList
        'ABC.Items.Add(New Microsoft.WindowsAPICodePack.Dialogs.Controls.CommonFileDialogRadioButtonListItem("DDD"))
        'ABC.Items.Add(New Microsoft.WindowsAPICodePack.Dialogs.Controls.CommonFileDialogRadioButtonListItem("CC"))
        'ABC.Items.Add(New Microsoft.WindowsAPICodePack.Dialogs.Controls.CommonFileDialogRadioButtonListItem("DDD"))
        'ABC.Items.Add(New Microsoft.WindowsAPICodePack.Dialogs.Controls.CommonFileDialogRadioButtonListItem("CC"))
        'dialog.Controls.Add(ABC)


        Dim comboBox As CommonFileDialogComboBox = New CommonFileDialogComboBox
        comboBox.Items.Add(New CommonFileDialogComboBoxItem("通常通りで開く"))
        comboBox.Items.Add(New CommonFileDialogComboBoxItem("読取専用で開く"))
        comboBox.Items.Add(New CommonFileDialogComboBoxItem("排他ロック状態で開く"))
        comboBox.SelectedIndex = 0
        dialog.Controls.Add(comboBox)


        With dialog
            .EnsureReadOnly = True

            'https://johobase.com/wpf-file-folder-common-dialog/
            Dim filter1 As CommonFileDialogFilter = New CommonFileDialogFilter()
            filter1.DisplayName = "Windyファイル" : filter1.Extensions.Add("wdf")
            dialog.Filters.Add(filter1)
            Dim filter2 As CommonFileDialogFilter = New CommonFileDialogFilter()
            filter2.DisplayName = "全てのファイル" : filter2.Extensions.Add("*")
            dialog.Filters.Add(filter2)

            .Multiselect = False
            .RestoreDirectory = True
            .Title = "開く"

            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case True
                    Case comboBox.SelectedIndex = 1 '読み取り専用モード
                        EM = False
                    Case comboBox.SelectedIndex = 2 'ロックモード
                        LK = True
                End Select
                FileName = .FileName
            End If
        End With

        If FileName <> "" Then
            If IsNowFileLock(FileName) Then
                MsgBox("このファイルは現在使用中（ロック中）です。" & vbCrLf & GetLockFileData(FileName), 48, "エラー")
                Return
            End If
            If LK Then
                If MsgBox("このファイルをロックしていいですか？" & vbCrLf & "([いいえ]を選択すると、ロックなしでファイルを開きます)", 4 + 32, "確認") = MsgBoxResult.No Then
                    LK = False
                End If
            End If
            Dim _TI As String = OpenFile(FileName, LK, EM)
            Call FileListAdd(_TI, FileName)
            Logs.PutInformation("既存ファイルを開く", FileName)
        End If

        'Dim FileName As String = ""
        'Dim LK As Boolean = False
        'Using OFD As New OpenFileDialog
        '    With OFD
        '        .AddExtension = True
        '        .CheckFileExists = True
        '        .CheckPathExists = True
        '        .DefaultExt = ".wdf"
        '        .Filter = "Windyファイル(*.wdf)|*.wdf|[ロック]Windyファイル(*.wdf)|*.wdf|全てのファイル(*.*)|*.*"
        '        .FilterIndex = 0
        '        .Multiselect = False
        '        .RestoreDirectory = True
        '        .Title = "開く"

        '        If .ShowDialog = Windows.Forms.DialogResult.OK Then
        '            Select Case True
        '                Case (Control.ModifierKeys And Keys.Control) = Keys.Control
        '                    LK = True
        '                Case .FilterIndex = 2
        '                    LK = True
        '            End Select
        '            FileName = .FileName
        '        End If
        '    End With
        'End Using
        'If FileName <> "" Then
        '    Dim LFL As String = FileName & ".lck"
        '    If File.Exists(LFL) Then
        '        MsgBox("このファイルは現在使用中（ロック中）です。" & vbCrLf & GetLockFileData(LFL), 48, "エラー")
        '        Return
        '    End If
        '    If LK Then
        '        If MsgBox("このファイルをロックしていいですか？" & vbCrLf & "([いいえ]を選択すると、ロックなしでファイルを開きます)", 4 + 32, "確認") = MsgBoxResult.No Then
        '            LK = False
        '        End If
        '    End If
        '    Dim _TI As String = OpenFile(FileName, LK)
        '    Call FileListAdd(_TI, FileName)
        'End If
    End Sub
    ''' <summary>
    ''' 現在ファイルがロック中？
    ''' </summary>
    ''' <param name="Filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsNowFileLock(Filename As String) As Boolean
        Dim LFL As String = Filename & ".lck"
        Return File.Exists(LFL)
    End Function

    ''' <summary>
    ''' ロックデータを読み込む
    ''' </summary>
    ''' <param name="FL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetLockFileData(FL As String) As String
        Dim FLName As String = FL & ".lck"
        Dim Dat As String = ""
        Try
            If File.Exists(FL) Then
                Using sr As New System.IO.StreamReader(FL, System.Text.Encoding.GetEncoding("shift_jis"))
                    Dat = sr.ReadToEnd
                End Using
            End If
            If Dat <> "" Then
                Dat = "ファイルロック情報なし"
            End If
        Catch ex As Exception
            Logs.PutErrorEx("ロックデータの読込に失敗しました", ex, True)
        End Try
        Return Dat
    End Function
    ''' <summary>
    ''' ファイル保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub ToolButton_SaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_SaveFile.Click, MenuSaveFile.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            If TargetForm.WorkFileName = "" Then
                Dim FileName As String = ""
                Using SFD As New SaveFileDialog
                    With SFD
                        .AddExtension = True
                        .CheckPathExists = True
                        .DefaultExt = ".wdf"
                        .FileName = "新規スケジュール"
                        .Filter = "Windyファイル(*.wdf)|*.wdf|Windyテンプレートファイル(*.wtf)|*.wtf|全てのファイル(*.*)|*.*"
                        .FilterIndex = 0
                        .OverwritePrompt = True
                        .Title = "保存"
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                            FileName = .FileName
                        End If
                    End With
                End Using
                If FileName <> "" Then
                    TargetForm.WorkFileName = FileName
                    TargetForm.SaveData()
                    TargetForm.IsSaved = True
                    Dim _T As String = TargetForm._Title
                    Call FileListAdd(_T, FileName)
                    Logs.PutInformation("ファイル保存", FileName)

                Else
                    TargetForm.IsSaved = False
                End If
            Else
                TargetForm.SaveData()
                TargetForm.IsSaved = True
                Dim _F As String = TargetForm._WorkFileName
                Dim _T As String = TargetForm._Title
                Call FileListAdd(_T, _F)
                Logs.PutInformation("ファイル保存", _F)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 全てのシートを保存する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSaveFileAll_Click(sender As Object, e As EventArgs) Handles MenuSaveFileAll.Click
        For Each ChildForm As Form In Me.MdiChildren
            Dim TargetForm As FrmMain = ChildForm

            If Not IsNothing(TargetForm) Then
                If TargetForm.WorkFileName = "" Then
                    Dim FileName As String = ""
                    Using SFD As New SaveFileDialog
                        With SFD
                            .AddExtension = True
                            .CheckPathExists = True
                            .FileName = "新規スケジュール.wdf"
                            .DefaultExt = ".wdf"
                            .Filter = "Windyファイル(*.wdf)|*.wdf|全てのファイル(*.*)|*.*"
                            .FilterIndex = 0
                            .OverwritePrompt = True
                            .Title = "保存"
                            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                FileName = .FileName
                            End If
                        End With
                    End Using
                    If FileName <> "" Then
                        TargetForm.WorkFileName = FileName
                        TargetForm.SaveData()
                        Dim _T As String = TargetForm._Title
                        Call FileListAdd(_T, FileName)
                        Logs.PutInformation("ファイル保存", FileName)
                    End If
                Else
                    TargetForm.SaveData()
                    Dim _F As String = TargetForm._WorkFileName
                    Dim _T As String = TargetForm._Title
                    Call FileListAdd(_T, _F)
                    Logs.PutInformation("ファイル保存", _F)
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' 名前を付けて保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuSaveFileAs.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        Dim FileName As String = ""
        Using SFD As New SaveFileDialog
            With SFD
                .AddExtension = True
                .CheckPathExists = True
                .DefaultExt = ".wdf"
                .Filter = "Windyファイル(*.wdf)|*.wdf|Windyテンプレートファイル(*.wtf)|*.wtf|全てのファイル(*.*)|*.*"
                .FilterIndex = 0
                .OverwritePrompt = True
                .Title = "保存"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    FileName = .FileName
                End If
            End With
        End Using
        If FileName <> "" Then
            TargetForm.WorkFileName = FileName
            TargetForm.SaveData()
            Dim _T As String = TargetForm._Title
            Call FileListAdd(_T, FileName)
            Logs.PutInformation("名前を付けて保存", FileName)
        End If

    End Sub
    ''' <summary>
    ''' 終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
#End Region
#Region "ウィンドウ関係"
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    ''' <summary>
    ''' 全てのフォームを閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' この親のすべての子フォームを閉じます
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    ''' <summary>
    ''' 日付の同期
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Sub SyncTime(Value As Object)
        If MenuSheetSync.Checked Then
            For Each ChildForm As Form In Me.MdiChildren
                Dim TargetForm As FrmMain = ChildForm
                TargetForm.TView.ViewTopTime = Value
            Next
        End If
    End Sub
#End Region

    Private m_ChildFormNumber As Integer
    ''' <summary>
    ''' 行追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_AddRow.ButtonClick
        If Not _SplitOpend Then
            Dim TargetForm As FrmMain = Me.ActiveMdiChild
            If Not IsNothing(TargetForm) Then
                TargetForm.RowAdd(FrmMain.enumAddRow.ToBottom)
            End If
        End If
    End Sub
    Private Sub ToolButton_AddRow_ToUp_Click(sender As Object, e As EventArgs) Handles ToolButton_AddRow_ToUp.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.RowAdd(FrmMain.enumAddRow.ToUp)
        End If
    End Sub

    Private Sub ToolButton_AddRow_ToDown_Click(sender As Object, e As EventArgs) Handles ToolButton_AddRow_ToDown.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.RowAdd(FrmMain.enumAddRow.ToDown)
        End If

    End Sub
    ''' <summary>
    ''' 縮小
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuZoomOut.Click, ToolButton_ZoomOut.ButtonClick
        If Not _SplitOpend Then
            Dim TargetForm As FrmMain = Me.ActiveMdiChild
            If Not IsNothing(TargetForm) Then
                TargetForm.TView.TimeScale.Medium.Interval += 1
                Call DrawButtonText(TargetForm)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 縮小（２日）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ZoomOut_2Day_Click(sender As Object, e As EventArgs) Handles ToolButton_ZoomOut_2Day.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.TView.TimeScale.Medium.Interval = 2
            Call DrawButtonText(TargetForm)
        End If
    End Sub
    ''' <summary>
    ''' 縮小（５日）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ZoomOut_5Day_Click(sender As Object, e As EventArgs) Handles ToolButton_ZoomOut_5Day.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.TView.TimeScale.Medium.Interval = 5
            Call DrawButtonText(TargetForm)
        End If
    End Sub
    ''' <summary>
    ''' 縮小（７日）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ZoomOut_Week_Click(sender As Object, e As EventArgs) Handles ToolButton_ZoomOut_Week.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.TView.TimeScale.Medium.Interval = 7
            Call DrawButtonText(TargetForm)
        End If
    End Sub

    ''' <summary>
    ''' 拡大
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuZoomIn.Click, ToolButton_ZoomIn.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not _SplitOpend Then
            If Not IsNothing(TargetForm) Then
                If TargetForm.TView.TimeScale.Medium.Interval > 1 Then
                    TargetForm.TView.TimeScale.Medium.Interval -= 1
                    Call DrawButtonText(TargetForm)
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 拡大（1日）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ZoomIn_1Day_Click(sender As Object, e As EventArgs) Handles ToolButton_ZoomIn_1Day.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            If TargetForm.TView.TimeScale.Medium.Interval > 1 Then
                TargetForm.TView.TimeScale.Medium.Interval = 1
                Call DrawButtonText(TargetForm)
            End If
        End If
    End Sub
    Private Sub DrawButtonText(TargetForm As FrmMain)
        ToolButton_ZoomOut.Text = String.Format("日付間隔縮小({0}日)", TargetForm.TView.TimeScale.Medium.Interval)
        ToolButton_ZoomIn.Text = String.Format("日付間隔拡大({0}日)", TargetForm.TView.TimeScale.Medium.Interval)

    End Sub
    ''' <summary>
    ''' 今日に移動する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSetTodaySet_Click(sender As Object, e As EventArgs) Handles MenuSetTodaySet.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            If MsgBox("本日が画面の真ん中になっていますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                With TargetForm.TView
                    If DateDiff(DateInterval.Day, .ViewTopTime, Now) > 0 Then
                        _Today = DateDiff(DateInterval.Day, .ViewTopTime, Now)
                        Call WriteReg("TimeScale", "Today", _Today)

                        Dim D As Object = TargetForm.TView.ViewTopTime
                        Call SyncTime(D)
                    End If
                End With
            End If
        End If
    End Sub
    ''' <summary>
    ''' 補正値をクリアする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSetTodayClear_Click(sender As Object, e As EventArgs) Handles MenuSetTodayClear.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            If MsgBox("設定補正値をクリアしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                _Today = 7
                Call WriteReg("TimeScale", "Today", _Today)
                MsgBox("設定画面の「本日余白」でも設定可能です", 64, "情報")
            End If
        End If
    End Sub
    ''' <summary>
    ''' ７日前へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_Front7Day_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_Front7Day.Click, MenuFront7Day.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            With TargetForm.TView
                .ViewTopTime = DateAdd(DateInterval.Day, -7, .ViewTopTime)
                Dim D As Object = TargetForm.TView.ViewTopTime
                Call SyncTime(D)
            End With
        End If
    End Sub
    ''' <summary>
    ''' 今日へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_Today_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_Today.Click, MenuToday.Click
        If Not _SplitOpend Then
            Dim TargetForm As FrmMain = Me.ActiveMdiChild
            If Not IsNothing(TargetForm) Then
                Call TargetForm.MoveToday()
                Dim D As Object = TargetForm.TView.ViewTopTime
                Call SyncTime(D)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 保存時の日付に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_SaveDate_Click(sender As Object, e As EventArgs) Handles ToolButton_SaveDate.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveSavedDate()
            Dim D As Object = TargetForm.TView.ViewTopTime
            Call SyncTime(D)
        End If
    End Sub
    ''' <summary>
    ''' 指定日へ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_SelDate_Click(sender As Object, e As EventArgs) Handles ToolButton_SelDate.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Dim SelDate As Date = Nothing
            With FrmCalendar
                .SelectedDate = TargetForm.TView.ViewTopTime
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    SelDate = .SelectedDate
                End If
            End With
            If SelDate <> Nothing Then
                Call TargetForm.MoveSelDate(SelDate)
                Dim D As Object = TargetForm.TView.ViewTopTime
                Call SyncTime(D)
            End If
        End If
    End Sub
    ''' <summary>
    ''' ７日後へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_Back7Day_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_Back7Day.Click, MenuBack7Day.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            With TargetForm.TView
                .ViewTopTime = DateAdd(DateInterval.Day, 7, .ViewTopTime)
                Dim D As Object = TargetForm.TView.ViewTopTime
                Call SyncTime(D)
            End With
        End If
    End Sub
    ''' <summary>
    ''' 先頭ピースへ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub ToolButton_TopPiace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_TopPiace.Click, MenuTopPiace.Click
        If Not _SplitOpend Then
            Dim TargetForm As FrmMain = Me.ActiveMdiChild
            If Not IsNothing(TargetForm) Then
                TargetForm.MoveTop()
                Dim D As Object = TargetForm.TView.ViewTopTime
                Call SyncTime(D)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 最終ピースへ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub ToolButton_LastPiace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_LastPiace.Click, MenuLastPiace.Click
        If Not _SplitOpend Then
            Dim TargetForm As FrmMain = Me.ActiveMdiChild
            If Not IsNothing(TargetForm) Then
                TargetForm.MoveLast()
                Dim D As Object = TargetForm.TView.ViewTopTime
                Call SyncTime(D)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 選択行の先頭ピースへ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_TopPiace_Row_Click(sender As Object, e As EventArgs) Handles ToolButton_TopPiace_Row.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveSelectRowItemDay(False)
            Dim D As Object = TargetForm.TView.ViewTopTime
            Call SyncTime(D)
        End If
    End Sub
    ''' <summary>
    ''' 選択行の最終ピースへ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_LastPiace_Row_Click(sender As Object, e As EventArgs) Handles ToolButton_LastPiace_Row.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveSelectRowItemDay(True)
            Dim D As Object = TargetForm.TView.ViewTopTime
            Call SyncTime(D)
        End If
    End Sub

    ''' <summary>
    ''' ピース拡大
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_PeaceWide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_PeaceWide.Click, MenuPeaceWide.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.TView.PieceCenterHeight += 1
        End If
    End Sub
    ''' <summary>
    ''' ピース縮小
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_PeaceNarrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_PeaceNarrow.Click, MenuPeaceNarrow.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            If TargetForm.TView.PieceCenterHeight > 1 Then
                TargetForm.TView.PieceCenterHeight -= 1
            End If
        End If
    End Sub
    ''' <summary>
    ''' 特別期間設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_SpecialTimeSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_SpecialTimeSetting.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.SpecialTimeSetting()
        End If
    End Sub
    ''' <summary>
    ''' ドラッグによるファイルオープン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmParent_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim fileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        For Each FN As String In fileName
            If IsNowFileLock(FN) Then
                MsgBox("このファイルは現在使用中（ロック中）です。" & vbCrLf & GetLockFileData(FN), 48, "エラー")
            Else
                Dim _T As String = OpenFile(FN)
                Call FileListAdd(_T, FN)
            End If
        Next
    End Sub
    ''' <summary>
    ''' ドラッグエンター
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmParent_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Link
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If

    End Sub
#Region "ファイル履歴関係"

    Dim MenuSets() As ToolStripMenuItem = New ToolStripMenuItem(5) {} 'オープン履歴メニューリスト
    Public MenuList As New List(Of FileListCollection) '履歴リスト
    ''' <summary>
    ''' 読込履歴をメニューへ反映させる
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetFileList()
        Try
            For Each Itm As ToolStripMenuItem In MenuSets
                Itm.Text = ""
                Itm.Tag = ""
                Itm.Visible = False
            Next

            If MenuList.Count > 0 Then
                Dim A As Integer = 0
                MenuList.Reverse()
                For B As Integer = 0 To MenuSets.Count - 1
                    'If A > 5 Then Exit For
                    If A > MenuList.Count - 1 Then
                        Exit For
                    End If
                    MenuSets(B).Text = String.Format("{0}({1})", MenuList(A).Title, Path.GetFileName(MenuList(A).FileName))
                    MenuSets(B).Tag = MenuList(A).FileName
                    MenuSets(B).ToolTipText = MenuList(A).FileName
                    MenuSets(B).Visible = True
                    A += 1
                Next
                MenuList.Reverse()
            End If
        Catch ex As Exception
            Logs.PutErrorEx("履歴反映エラー", ex, True)
        End Try
    End Sub
    ''' <summary>
    ''' 履歴に追加する
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <param name="FileName"></param>
    ''' <remarks></remarks>
    Private Sub FileListAdd(ByVal Title As String, FileName As String)
        Try
            If Path.GetExtension(FileName).ToUpper = ".WDF" Then
                If MenuList.Count > 0 Then
                    For i As Integer = MenuList.Count - 1 To 0 Step -1
                        If MenuList(i).FileName.ToUpper = FileName.ToUpper Then
                            MenuList.RemoveAt(i)
                        End If
                    Next
                End If
                Dim _T As New FileListCollection
                _T.Title = Title
                _T.FileName = FileName
                MenuList.Add(_T)
                Call SetFileList()
            End If
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' ファイル履歴クリア
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FileListClear()
        For Each Itm As ToolStripMenuItem In MenuSets
            Itm.Text = ""
            Itm.Tag = ""
            Itm.Visible = False
        Next
        MenuList.Clear()
    End Sub
#End Region
    ''' <summary>
    ''' フォームを閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmParent_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call XMLSaveFileList(MenuList) '読込履歴保存
        Call XMLSaveHolidayList(_Holiday) '休日保存
        My.Settings.GideNoVisible = Not Panel1.Visible
        My.Settings.Save()
    End Sub
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmParent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MenuSets(0) = Me.MenuSet0
        MenuSets(1) = Me.MenuSet1
        MenuSets(2) = Me.MenuSet2
        MenuSets(3) = Me.MenuSet3
        MenuSets(4) = Me.MenuSet4
        MenuSets(5) = Me.MenuSet5

        If XMLReadFileList(MenuList) Then
            Call SetFileList()
        End If
        Call XMLReadHolidayList(_Holiday) '休日ファイル

        If System.Environment.GetCommandLineArgs.Length > 1 Then
            _OpenFileName.Clear()
            For i As Integer = 1 To System.Environment.GetCommandLineArgs.Length - 1
                Dim FN As String = System.Environment.GetCommandLineArgs(i)
                If Path.GetExtension(FN).ToUpper = ".WDF" Then
                    If File.Exists(FN) Then
                        _OpenFileName.Add(FN)
                    End If
                End If
            Next
        End If
        Call Initial()
        LblToday.Text = String.Format("本日：{0:yyyy年M月d日(dddd)}", Now)
        LblToday.BackColor = ConvertColorValue(_TodayColor)
        Panel1.Visible = Not My.Settings.GideNoVisible
        MenuGideNoVisible.Checked = My.Settings.GideNoVisible
    End Sub
    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initial()
        _SaturdayColor = 16777153
        _SundayColor = 13553407
        _TodayColor = 13172680

        Try
            If ReadReg("UseColor", "SaturdayColor") <> "" Then
                _SaturdayColor = System.UInt32.Parse(ReadReg("UseColor", "SaturdayColor"))
            End If
            If ReadReg("UseColor", "SundayColor") <> "" Then
                _SundayColor = System.UInt32.Parse(ReadReg("UseColor", "SundayColor"))
            End If
            If ReadReg("UseColor", "TodayColor") <> "" Then
                _TodayColor = System.UInt32.Parse(ReadReg("UseColor", "TodayColor"))
            End If
            If ReadReg("TimeScale", "Today", enum_Type.er_Integer) <> 0 Then
                _Today = ReadReg("TimeScale", "Today", enum_Type.er_Integer)
            Else
                _Today = 7
            End If
            If ReadReg("TimeScale", "StartDay", enum_Type.er_Integer) <> 0 Then
                _StartDay = ReadReg("TimeScale", "StartDay", enum_Type.er_Integer)
            Else
                _StartDay = 7
            End If
            If ReadReg("TimeScale", "FinalDay", enum_Type.er_Integer) <> 0 Then
                _FinalDay = ReadReg("TimeScale", "FinalDay", enum_Type.er_Integer)
            Else
                _FinalDay = 7
            End If
            If ReadReg("TimeScale", "PrintDay", enum_Type.er_Integer) <> 0 Then
                _PrintDay = ReadReg("TimeScale", "PrintDay", enum_Type.er_Integer)
            Else
                _PrintDay = 7
            End If
            _DefTunnel = ReadReg("Sheet", "DefTunnel", enum_Type.er_Boolean)

            _NoHighlight = ReadReg("General", "NoHighlight", enum_Type.er_Boolean)
            _TabletMode = ReadReg("General", "TabletMode", enum_Type.er_Boolean)

            _FontSizePiece = ReadReg("General", "FontSizePiece", enum_Type.er_Integer)
            _FontSizeCell = ReadReg("General", "FontSizeCell", enum_Type.er_Integer)
            _FontSizeCellHeader = ReadReg("General", "FontSizeCellHeader", enum_Type.er_Integer)

            'スプリットボタン用イベント追加
            For Each Ctr As ToolStripItem In ToolStrip.Items
                If (TypeOf Ctr Is ToolStripSplitButton) Then
                    Dim Obj As ToolStripSplitButton = CType(Ctr, ToolStripSplitButton)
                    AddHandler Obj.DropDownOpening, AddressOf ToolStripSplitButton_DropDownOpening
                    AddHandler Obj.DropDownClosed, AddressOf ToolStripSplitButton_DropDownClosed
                End If
            Next

            'タブレットモード画面調整
            Call IniTabletMode()

        Catch ex As Exception
            Logs.PutErrorEx("初期化失敗", ex, True)
        End Try

    End Sub
    Private Sub ToolStripSplitButton_DropDownOpening(sender As Object, e As EventArgs)
        _SplitOpend = True
    End Sub

    Private Sub ToolStripSplitButton_DropDownClosed(sender As Object, e As EventArgs)
        _SplitOpend = False
    End Sub
    ''' <summary>
    ''' タブレットモードの画面調整
    ''' </summary>
    Private Sub IniTabletMode()
        Dim FKL As Label() = {LblF1, LblF2, LblF3, LblF4, LblF5, LblF6, LblF7, LblF8, LblF9, LblF10, LblF11, LblF12}
        '一旦「；」を削除
        For Each Itm As Label In FKL
            Dim SepIndex As Integer = Itm.Text.IndexOf("：")
            If SepIndex > -1 Then
                Itm.Text = Mid(Itm.Text, SepIndex + 2, Len(Itm.Text) - 1)
            End If
        Next

        If _TabletMode Then
            LblTabletMode.Image = My.Resources.tablet

            LblF12.Text = "プロパティ"
            LblF12.BackColor = LblF11.BackColor
            LblF12.BorderStyle = BorderStyle.FixedSingle
        Else
            LblTabletMode.Image = My.Resources.terminal

            '通常モードは最初に「F」を付ける
            For i As Integer = 1 To 11
                With FKL(i - 1)
                    .Text = String.Format("F{0}：{1}", i, .Text)
                End With
            Next
            LblF12.Text = "F12"
            LblF12.BackColor = Color.Transparent
            LblF12.BorderStyle = BorderStyle.None

        End If
    End Sub
    Private Sub FrmParent_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _OpenFileName.Count > 0 Then
            For Each FN As String In _OpenFileName
                If IsNowFileLock(FN) Then
                    MsgBox("このファイルは現在使用中（ロック中）です。" & vbCrLf & GetLockFileData(FN), 48, "エラー")
                Else
                    Dim _T As String = OpenFile(FN)
                    Call FileListAdd(_T, FN)
                End If
            Next
        End If
        If ReadReg("General", "DebugMode", enum_Type.er_Boolean) Then
            LblMessage.Text = "[ デバグモードで起動しました ]"
            _IsDebugMode = True
        End If
    End Sub

    ''' <summary>
    ''' 印刷
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_Print.Click, MenuPrint.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.SheetPrint()
        End If
    End Sub
    ''' <summary>
    ''' 列追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_AddCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_AddCol.ButtonClick
        If Not _SplitOpend Then
            Dim TargetForm As FrmMain = Me.ActiveMdiChild
            If Not IsNothing(TargetForm) Then
                TargetForm.ColumnAdd(FrmMain.enumColumnAdd.ToLast)
            End If
        End If
    End Sub
    Private Sub ToolButton_AddCol_ToLeft_Click(sender As Object, e As EventArgs) Handles ToolButton_AddCol_ToLeft.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.ColumnAdd(FrmMain.enumColumnAdd.ToLeft)
        End If

    End Sub

    Private Sub ToolButton_AddCol_ToRight_Click(sender As Object, e As EventArgs) Handles ToolButton_AddCol_ToRight.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.ColumnAdd(FrmMain.enumColumnAdd.ToRight)
        End If

    End Sub
    ''' <summary>
    ''' 列削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_DelCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_DelCol.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.ColumnDelete()
        End If
    End Sub
    ''' <summary>
    ''' 行上へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ToUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_ToUp.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveRow(FrmMain.enum_MoveRow.ToUp)
        End If
    End Sub
    ''' <summary>
    ''' 行下へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ToDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_ToDown.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveRow(FrmMain.enum_MoveRow.ToDown)
        End If
    End Sub
    ''' <summary>
    ''' 行削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_DelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_DelRow.ButtonClick
        If Not _SplitOpend Then
            Dim TargetForm As FrmMain = Me.ActiveMdiChild
            If Not IsNothing(TargetForm) Then
                Call TargetForm.RowDelete()
            End If
        End If
    End Sub
    ''' <summary>
    ''' 拡張行削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_DelRowEx_Click(sender As Object, e As EventArgs) Handles ToolButton_DelRowEx.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.RowDeleteEx()
        End If
    End Sub
    ''' <summary>
    ''' 列左へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ToLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_ToLeft.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveCol(FrmMain.enum_MoveCol.ToLeft)
        End If
    End Sub
    ''' <summary>
    ''' 列右へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ToRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_ToRight.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveCol(FrmMain.enum_MoveCol.ToRight)
        End If
    End Sub
    ''' <summary>
    ''' 選択列を非表示にする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_HiddenCol_Click(sender As Object, e As EventArgs) Handles ToolButton_HiddenCol.Click
        If Not _SplitOpend Then
            Dim TargetForm As FrmMain = Me.ActiveMdiChild
            If Not IsNothing(TargetForm) Then
                Call TargetForm.HiddenSelColumun()
            End If
        End If
    End Sub
    ''' <summary>
    ''' 選択行を非表示にする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_HiddenRow_Click(sender As Object, e As EventArgs) Handles ToolButton_HiddenRow.Click
        If Not _SplitOpend Then
            Dim TargetForm As FrmMain = Me.ActiveMdiChild
            If Not IsNothing(TargetForm) Then
                Call TargetForm.HiddenSelRow()
            End If
        End If
    End Sub
    Private Sub ToolButton_HiddenRowTree_Click(sender As Object, e As EventArgs) Handles ToolButton_HiddenRowTree.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.RowHidden_Tree()
        End If
    End Sub
    ''' <summary>
    ''' 全ての列を再表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_DisHiddenCol_Click(sender As Object, e As EventArgs) Handles ToolButton_DisHiddenCol.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.DisHiddenAllColumun()
        End If
    End Sub
    ''' <summary>
    ''' 全ての行を再表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_DisHiddenRow_Click(sender As Object, e As EventArgs) Handles ToolButton_DisHiddenRow.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.DisHiddenAllRow()
        End If
    End Sub
    ''' <summary>
    ''' 関係線作成
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_AddLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_AddLink.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.AddRelatedLine()
        End If
    End Sub
    ''' <summary>
    ''' バルーン作成
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_AddBalloon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton_AddBalloon.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.BalloonnAdd()
        End If
    End Sub
    ''' <summary>
    ''' アイテム変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ItemChange_Click(sender As Object, e As EventArgs) Handles ToolButton_ItemChange.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.ItemChange()
        End If
    End Sub
    ''' <summary>
    ''' 選択アイテムコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_CopyPiece_Click(sender As Object, e As EventArgs) Handles ToolButton_CopyPiece.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.CopyItem()
        End If
    End Sub
    ''' <summary>
    ''' 選択アイテムペースト
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_PastePiece_Click(sender As Object, e As EventArgs) Handles ToolButton_PastePiece.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.PasteItem()
        End If
    End Sub
    ''' <summary>
    ''' アンドゥー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_Undo_Click(sender As Object, e As EventArgs) Handles ToolButton_Undo.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.UndoExecute()
            Call TargetForm.SheetInfomation(True)
        End If
    End Sub
    ''' <summary>
    ''' シートプロパティ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuProperty.Click, ToolButton_SheetProperty.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.EditSheetProperty()
        End If
    End Sub
    ''' <summary>
    ''' 子フォームが変わった
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmParent_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Dim Flg As Boolean = TargetForm.IsEditMode
            Call ToolButtomMode(Flg)
            Call TargetForm.SheetInfomation()
        Else
            LblRendou.Text = ""
            LblRendou.Image = Nothing
        End If
    End Sub
    ''' <summary>
    ''' ツールボタンの有効・無効の設定
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks>TAGに１が設定されているメニュー／ツールバーが対象となる</remarks>
    Private Sub ToolButtomMode(Value As Boolean)
        'ツールバーの設定
        For Each Itm As ToolStripItem In ToolStrip.Items
            If Itm.Tag = "1" Then 'TAGに「1」が入っているものが対象となる
                Itm.Enabled = Value
            End If
        Next

        'メニューの設定
        For Each _MenuItem As ToolStripMenuItem In MenuStrip.Items
            If _MenuItem.DropDownItems.Count > 0 Then
                '子メニューも設定する
                Call ScanChildMenuItem(_MenuItem, Value)
            End If
            If _MenuItem.Tag = "1" Then 'TAGに「1」が入っているものが対象となる
                _MenuItem.Enabled = Value
            End If
        Next

        'ファンクションキー
        For Each Itm As Control In C1Sizer1.Controls
            If TypeOf Itm Is Label Then
                Dim t As Label = Itm
                If t.Tag = "1" Then 'TAGに「1」が入っているものが対象となる
                    If Value Then
                        t.Enabled = True
                        t.BackColor = LblF1.BackColor ' Color.FromArgb(255, 255, 192)
                    Else
                        t.Enabled = False
                        t.BackColor = System.Drawing.SystemColors.Control
                    End If
                End If
            End If
        Next

    End Sub
    ''' <summary>
    ''' 子メニューを検索する
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <param name="Flg"></param>
    ''' <remarks></remarks>
    Private Sub ScanChildMenuItem(ByVal Value As ToolStripMenuItem, Flg As Boolean)
        For Each _LoopItem As Object In Value.DropDownItems
            If TypeOf _LoopItem Is ToolStripMenuItem Then
                Dim _MenuItem As ToolStripMenuItem = _LoopItem
                If _MenuItem.DropDownItems.Count > 0 Then
                    Call ScanChildMenuItem(_MenuItem, Flg)
                End If
                If _MenuItem.Tag = "1" Then
                    _MenuItem.Enabled = Flg
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' TODO:アイコンセット
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <remarks></remarks>
    Private Sub SetIconImage(ByVal Obj As AxKnTViewLib.AxKnTView)
        'imgList = ChildForm.TView.ImageLists.Add(, "ImageList", AppFullPath("TasksImages.bmp"), RGB(255, 0, 255), 16, 16)
        'imgList.Images.Keys = New Object() {"memo", "review", "thander", "flag", "task"}

        'ストーンアイコン
        If File.Exists(AppFullPath("stoneicon.dat")) Then
            Dim imgList As KnTViewLib.ImageList = Obj.ImageLists.Add(, "ImageList", AppFullPath("stoneicon.dat"), RGB(255, 0, 255), 16, 16)
            imgList.Images.Keys = New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35"}
        End If

        'インデントアイコン
        If File.Exists(AppFullPath("IndentIcon12.dat")) Then
            Dim imgList As KnTViewLib.ImageList = Obj.ImageLists.Add(, "IndentImageList", AppFullPath("IndentIcon12.dat"), RGB(255, 0, 255), 12, 12)
            imgList.Images.Keys = New Object() {"Indent"}
        End If

    End Sub

    ''' <summary>
    ''' ファイルを開く
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OpenFile(ByVal FileName As String, Optional IsLock As Boolean = False, Optional EditMode As Boolean = True) As String

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Dim _Ret As String = ""

        If File.Exists(FileName) Then
            LblMessage.Text = "データ読込中..."
            Application.DoEvents()

            Select Case Path.GetExtension(FileName).ToUpper
                Case ".WDF" '通常のファイルを開く
                    For Each frm As FrmMain In Me.MdiChildren
                        If frm.WorkFileName = FileName Then
                            frm.Activate()
                            Me.Cursor = Cursors.Default
                            Return _Ret
                        End If
                    Next

                    ' 子フォームの新しいインスタンスを作成します
                    Dim ChildForm As New FrmMain
                    ' 表示する前に、この MDI フォームの子に設定します
                    ChildForm.MdiParent = Me
                    ChildForm.WindowState = FormWindowState.Maximized

                    m_ChildFormNumber += 1

                    Call SetIconImage(ChildForm.TView) 'アイコンイメージセット

                    'パスワード確認がある時、一瞬チャートが見えてしまうので、一旦非表示にする
                    ChildForm.TView.Visible = False
                    Application.DoEvents()

                    ChildForm.WorkFileName = FileName
                    ChildForm.WorkFileIsLock = IsLock
                    ChildForm.Show() 'ファイルを読み込ます為に一旦SHOWして、すぐにHIDEする
                    ChildForm.Hide()
                    _Ret = ChildForm._Title

                    'もしパスワード設定があったら確認する
                    If ChildForm._IsExclusion Then
                        With FrmExclusion
                            .DefPassword = ChildForm._ExclusionPassword
                            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                                Select Case .OpenMode
                                    Case FrmExclusion.enum_OpenMode.IsOK 'パスワードOK
                                        'ChildForm.EditMode = True
                                        'ChildForm.ChangeTitle(True)
                                        ChildForm.EditMode = EditMode
                                        ChildForm.ChangeTitle(EditMode)
                                        Logs.PutInformation("ファイルを開く(Password OK)", FileName)
                                    Case FrmExclusion.enum_OpenMode.IsView '閲覧モードで開く
                                        ChildForm.EditMode = False
                                        ChildForm.ChangeTitle(False)
                                        Logs.PutInformation("ファイルを開く(ViewMode)", FileName)
                                    Case FrmExclusion.enum_OpenMode.IsCancel 'キャンセル
                                        ChildForm.Close()
                                        Logs.PutInformation("ファイルを開く(キャンセル)", FileName)
                                        Me.Cursor = Cursors.Default
                                        Return _Ret
                                End Select
                            Else
                                '確認画面がXで閉じられたらキャンセル扱い
                                ChildForm.Close()
                                Logs.PutInformation("ファイルを開く(キャンセル)", FileName)
                                Me.Cursor = Cursors.Default
                                Return _Ret
                            End If
                        End With
                    Else
                        '設定が無かったらそのままスルー
                        'ChildForm.EditMode = True
                        'ChildForm.ChangeTitle(True)
                        ChildForm.EditMode = EditMode
                        ChildForm.ChangeTitle(EditMode)
                        Logs.PutInformation("既存ファイルを開く", FileName)

                    End If
                    ChildForm.TView.Visible = True '非表示になっていたチャートを表示に戻す
                    ChildForm.Show()

                    ChildForm.UndoGetData() 'UNDOデータ取得
                    ChildForm.EnableUndo = True 'UNDO有効

                    '設定したアイコンが正しく表示されない対策
                    ToolStrip.Visible = False
                    ToolStrip.Visible = True
                    LblMessage.Text = "読込完了"

                Case ".WTF" 'テンプレートファイルを開く

                    ' 子フォームの新しいインスタンスを作成します
                    Dim ChildForm As New FrmMain
                    ' 表示する前に、この MDI フォームの子に設定します
                    ChildForm.MdiParent = Me
                    ChildForm.WindowState = FormWindowState.Maximized
                    m_ChildFormNumber += 1

                    ChildForm.WorkFileName = FileName
                    ChildForm.WorkFileIsLock = IsLock
                    _Ret = ChildForm._Title

                    ChildForm.EditMode = EditMode
                    ChildForm.ChangeTitle(EditMode)
                    Logs.PutInformation("テンプレートファイルを開く", FileName)


                    ChildForm.Show()

                    ChildForm.UndoGetData() 'UNDOデータ取得
                    ChildForm.EnableUndo = True 'UNDO有効

                    '設定したアイコンが正しく表示されない対策
                    ToolStrip.Visible = False
                    ToolStrip.Visible = True
                    LblMessage.Text = "読込完了"
            End Select
        
        End If

        Me.Cursor = Cursors.Default
        Return _Ret

    End Function
    ''' <summary>
    ''' ファイルを開く（未使用）
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OpenFile2(ByVal FileName As String) As String
        Dim _Ret As String = ""

        If File.Exists(FileName) AndAlso Path.GetExtension(FileName).ToUpper = ".WDF" Then
            LblMessage.Text = "データ読込中..."
            Application.DoEvents()

            For Each frm As FrmMain In Me.MdiChildren
                If frm.WorkFileName = FileName Then
                    frm.Activate()
                    Return _Ret
                End If
            Next

            Dim EditMode As Boolean = True
            Dim Dat As DataHeaderCollection = GetDatatHeader(FileName) 'データヘッダー情報抽出
            If Dat.IsExclusion Then 'パスワードの設定確認
                With FrmExclusion
                    .DefPassword = Dat.ExclusionPassword
                    If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Select Case .OpenMode
                            Case FrmExclusion.enum_OpenMode.IsOK 'パスワードOK
                                EditMode = True
                            Case FrmExclusion.enum_OpenMode.IsView '閲覧モードで開く
                                EditMode = False
                            Case FrmExclusion.enum_OpenMode.IsCancel 'キャンセル
                                Return _Ret
                        End Select
                    Else
                        Return _Ret '確認画面がXで閉じられたらキャンセル扱い
                    End If
                End With
            Else

            End If

            ' 子フォームの新しいインスタンスを作成します
            Dim ChildForm As New FrmMain
            With ChildForm
                ' 表示する前に、この MDI フォームの子に設定します
                .MdiParent = Me
                .WindowState = FormWindowState.Maximized

                m_ChildFormNumber += 1

                Call SetIconImage(.TView) 'アイコンイメージセット

                .WorkFileName = FileName
                .Show()
                .EditMode = EditMode '編集モードの設定
                .ChangeTitle(EditMode) 'フォームタイトルの設定
                Call ToolButtomMode(EditMode) 'ツールバーの調整
            End With

            LblMessage.Text = "読込完了"
        End If

        Return _Ret

    End Function
    ''' <summary>
    ''' 行を上に追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAddRowUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAddRowUp.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.RowAdd(FrmMain.enumAddRow.ToUp)
        End If
    End Sub
    ''' <summary>
    ''' 行を下に追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAddRowDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAddRowDown.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.RowAdd(FrmMain.enumAddRow.ToDown)
        End If
    End Sub
    ''' <summary>
    ''' 行を最下段に追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAddRowLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAddRowLast.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.RowAdd(FrmMain.enumAddRow.ToBottom)
        End If
    End Sub
    ''' <summary>
    ''' 行を上に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuMoveRowUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMoveRowUp.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveRow(FrmMain.enum_MoveRow.ToUp)
        End If
    End Sub
    ''' <summary>
    ''' 行を下に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuMoveRowDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMoveRowDown.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveRow(FrmMain.enum_MoveRow.ToDown)
        End If
    End Sub
    ''' <summary>
    ''' 行の削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDeleteRow.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.RowDelete()
        End If
    End Sub
    ''' <summary>
    ''' 列を左に追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAddColumnLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAddColumnLeft.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.ColumnAdd(FrmMain.enumColumnAdd.ToLeft)
        End If
    End Sub
    ''' <summary>
    ''' 列を右に追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAddColumnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAddColumnRight.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.ColumnAdd(FrmMain.enumColumnAdd.ToLeft)
        End If
    End Sub
    ''' <summary>
    ''' 列を最右に追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAddColumnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAddColumnLast.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.ColumnAdd(FrmMain.enumColumnAdd.ToLast)
        End If
    End Sub
    ''' <summary>
    ''' 列を左に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuMoveColumnLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMoveColumnLeft.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveCol(FrmMain.enum_MoveCol.ToLeft)
        End If
    End Sub
    ''' <summary>
    ''' 列を右に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuMoveColumnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMoveColumnRight.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveCol(FrmMain.enum_MoveCol.ToRight)
        End If
    End Sub
    ''' <summary>
    ''' 列削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuDeleteColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDeleteColumn.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.ColumnDelete()
        End If
    End Sub
    ''' <summary>
    ''' シートリフレッシュ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolSheetRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSheetRefresh.Click, MenuSheetReflesh.Click
        If Not _SplitOpend Then
            Dim TargetForm As FrmMain = Me.ActiveMdiChild
            If Not IsNothing(TargetForm) Then
                Call TargetForm.TView.Refresh(1)
            End If
        End If
    End Sub

    ''' <summary>
    ''' シートリロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuReload_Click(sender As Object, e As EventArgs) Handles MenuReload.Click, ToolSheetReload.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.ReloadData()
        End If
    End Sub
    ''' <summary>
    ''' 読込履歴
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSet0.Click, MenuSet1.Click, MenuSet2.Click, MenuSet3.Click, MenuSet4.Click, MenuSet5.Click
        Dim Obj As ToolStripMenuItem = sender
        If File.Exists(Obj.Tag) Then
            Dim LK As Boolean = False
            If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                LK = True
            End If

            If IsNowFileLock(Obj.Tag) Then
                MsgBox("このファイルは現在使用中（ロック中）です。" & vbCrLf & GetLockFileData(Obj.Tag), 48, "エラー")
                Return
            End If

            If LK Then
                If MsgBox("このファイルをロックしていいですか？" & vbCrLf _
                          & "([いいえ]を選択すると、ロックなしでファイルを開きます)", 4 + 32, "確認") = MsgBoxResult.No Then
                    LK = False
                End If
            End If

            Dim _T As String = OpenFile(Obj.Tag, LK)
            If _T <> "" Then
                Call FileListAdd(_T, Obj.Tag)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub MenuSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSetting.Click
        Try
            With FrmSetting
                .SaturdayColor = _SaturdayColor
                .SundayColor = _SundayColor
                .TodayColor = _TodayColor
                .ToDay = _Today
                .StartDay = _StartDay
                .FinalDay = _FinalDay
                .PrintDay = _PrintDay
                .DefTunnel = _DefTunnel
                .NoHighlight = _NoHighlight
                .TabletMode = _TabletMode
                .FontSizeCell = _FontSizeCell
                .FontSizePiece = _FontSizePiece
                .FontSizeCellHeader = _FontSizeCellHeader
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    _SaturdayColor = .SaturdayColor
                    _SundayColor = .SundayColor
                    _TodayColor = .TodayColor
                    _Today = .ToDay
                    _StartDay = .StartDay
                    _FinalDay = .FinalDay
                    _PrintDay = .PrintDay
                    _DefTunnel = .DefTunnel
                    _NoHighlight = .NoHighlight
                    _TabletMode = .TabletMode
                    _FontSizeCell = .FontSizeCell
                    _FontSizePiece = .FontSizePiece
                    _FontSizeCellHeader = .FontSizeCellHeader
                    Call WriteReg("UseColor", "SaturdayColor", _SaturdayColor.ToString)
                    Call WriteReg("UseColor", "SundayColor", _SundayColor.ToString)
                    Call WriteReg("UseColor", "TodayColor", _TodayColor.ToString)
                    Call WriteReg("TimeScale", "Today", _Today)
                    Call WriteReg("TimeScale", "StartDay", _StartDay)
                    Call WriteReg("TimeScale", "FinalDay", _FinalDay)
                    Call WriteReg("TimeScale", "PrintDay", _PrintDay)
                    Call WriteReg("Sheet", "DefTunnel", _PrintDay)

                    Call WriteReg("General", "NoHighlight", _NoHighlight)
                    Call WriteReg("General", "TabletMode", _TabletMode)
                    Call WriteReg("General", "FontSizePiece", _FontSizePiece)
                    Call WriteReg("General", "FontSizeCell", _FontSizeCell)
                    Call WriteReg("General", "FontSizeCellHeader", _FontSizeCellHeader)

                    For Each FM As FrmMain In Me.MdiChildren
                        FM.RedrawSpecialTime()
                        FM.FontSizeChange()
                    Next

                    Call IniTabletMode()
                End If
            End With
        Catch ex As Exception
            Logs.PutErrorEx("設定操作エラー", ex, True)
        End Try

    End Sub
    ''' <summary>
    ''' 本日に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblToday.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MoveToday()
        End If
    End Sub

    ''' <summary>
    ''' 稲妻線表示・非表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_ProgressLine_Click(sender As Object, e As EventArgs) Handles ToolButton_ProgressLine.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm.ViewInazuma = Not TargetForm.ViewInazuma
        End If
    End Sub
    ''' <summary>
    ''' 日付幅縮小
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_TimeNarrow_Click(sender As Object, e As EventArgs) Handles ToolButton_TimeNarrow.Click, MenuTimeNarrow.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.DayWidth(FrmMain.enum_DayWidth.ToNarrow)
        End If
    End Sub
    ''' <summary>
    ''' 日付幅拡大
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_TimeWide_Click(sender As Object, e As EventArgs) Handles ToolButton_TimeWide.Click, MenuTimeWide.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.DayWidth(FrmMain.enum_DayWidth.ToWide)
        End If
    End Sub
    ''' <summary>
    ''' 日付幅標準に戻す
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolButton_TimeDefault_Click(sender As Object, e As EventArgs) Handles ToolButton_TimeDefault.Click, MenuTimeDefault.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.DayWidth(FrmMain.enum_DayWidth.ToDefault)
        End If
    End Sub
    ''' <summary>
    ''' ヘルプREADMEファイル表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub ContentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContentsToolStripMenuItem.Click
        Dim _FN As String = AppFullPath("readme.txt")
        If File.Exists(_FN) Then
            Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(_FN)
        End If
    End Sub
    ''' <summary>
    ''' スナップショットメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSnapshot_Click(sender As Object, e As EventArgs) Handles ToolButton_Snapshot.Click, MenuSnapshot.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.SaveSnapShot()
        End If
    End Sub

    ''' <summary>
    ''' XMLファイルにエクスポートメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuDataExport_XML_Click(sender As Object, e As EventArgs) Handles MenuDataExport_XML.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.DataExportXML()
        End If
    End Sub
    ''' <summary>
    ''' グリッドへエクスポートメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuDataExport_Grid_Click(sender As Object, e As EventArgs) Handles MenuDataExport_Grid.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.DataExport()
        End If
    End Sub
    ''' <summary>
    ''' バージョン表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        FrmAbout.ShowDialog()
    End Sub
    ''' <summary>
    ''' ファイルデータヘッダの取得
    ''' </summary>
    ''' <param name="_OpenFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDatatHeader(_OpenFileName As String) As DataHeaderCollection

        Dim Ret As New DataHeaderCollection
        If _OpenFileName <> "" AndAlso File.Exists(_OpenFileName) Then
            Dim Data As New List(Of WindyDataCollection)
            If XMLReadData(Data, _OpenFileName) Then
                Ret.Title = Data(0).Title
                Ret.Owner = Data(0).Owner
                Ret.IsExclusion = Data(0).IsExclusion
                Ret.ExclusionPassword = Data(0).ExclusionPassword
            End If
        End If
        Return Ret
    End Function
    ''' <summary>
    ''' ツールバーを隠す
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuToolbarHide_Click(sender As Object, e As EventArgs) Handles MenuToolbarHide.Click
        MenuToolbarHide.Checked = Not MenuToolbarHide.Checked
        ToolStrip.Visible = Not MenuToolbarHide.Checked
    End Sub

    ''' <summary>
    ''' シート日付を同期する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSheetSync_Click(sender As Object, e As EventArgs) Handles MenuSheetSync.Click
        MenuSheetSync.Checked = Not MenuSheetSync.Checked
    End Sub
    ''' <summary>
    ''' 日付幅を揃える
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSyncScale_Click(sender As Object, e As EventArgs) Handles MenuSyncScale.Click
        Dim MasterForm As FrmMain = Me.ActiveMdiChild
        Dim a As Object = MasterForm.TView.TimeScale.Medium.Interval
        Dim b As Single = MasterForm.TView.TimeScale.WidthPerScale

        For Each ChildForm As Form In Me.MdiChildren
            Dim TargetForm As FrmMain = ChildForm
            TargetForm.TView.TimeScale.Medium.Interval = a
            TargetForm.TView.TimeScale.WidthPerScale = b
        Next
    End Sub

    Private Sub WindowsMenu_Click(sender As Object, e As EventArgs) Handles WindowsMenu.Click
        MenuSyncScale.Enabled = IIf(Me.MdiChildren.Count > 1, True, False)
    End Sub
    ''' <summary>
    ''' アイテム検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuItemScan_Click(sender As Object, e As EventArgs) Handles MenuItemScan.Click, ToolButton_ItemScan.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            With FrmItemFind
                .TargetForm = TargetForm
                .ShowDialog()
            End With
        End If
    End Sub

    ''' <summary>
    ''' クリップボードからインポート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuImport_Clip_Click(sender As Object, e As EventArgs) Handles MenuImport_Clip.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.Import_Clip()
        End If
    End Sub
    ''' <summary>
    ''' CSVファイルからインポート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuImport_CSV_Click(sender As Object, e As EventArgs) Handles MenuImport_CSV.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.Import_CSV()
        End If

    End Sub
    ''' <summary>
    ''' Windyファイルマージ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuImport_Windy_Click(sender As Object, e As EventArgs) Handles MenuImport_Windy.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.MergeData()
        End If
    End Sub


    Dim _MemStyle As FormWindowState = FormWindowState.Normal
    ''' <summary>
    ''' 全画面にする
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AllScreen()
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                '全面表示から通常表示に戻す
                MenuStrip.Visible = True
                ToolStrip.Visible = True
                StatusStrip.Visible = True

                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                If _MemStyle = FormWindowState.Maximized Then
                    Me.WindowState = FormWindowState.Maximized
                Else
                    Me.WindowState = FormWindowState.Normal
                End If
                TargetForm.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                Me.TopMost = False
                Panel1.Visible = Not MenuGideNoVisible.Checked
            Else
                '現在が通常なら全面表示に設定する
                _MemStyle = Me.WindowState
                MenuStrip.Visible = False
                ToolStrip.Visible = False
                StatusStrip.Visible = False
                Me.WindowState = FormWindowState.Normal
                TargetForm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                TargetForm.WindowState = FormWindowState.Maximized
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                Me.WindowState = FormWindowState.Maximized
                'Me.Location = New Point(0, 0)
                'Me.Size = Screen.PrimaryScreen.Bounds.Size
                Me.TopMost = True
                Panel1.Visible = False
            End If
        End If
    End Sub

    ''' <summary>
    ''' 全画面メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAllScreen_Click(sender As Object, e As EventArgs) Handles MenuAllScreen.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            If MsgBox("全画面にしますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                Call AllScreen()
                If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
                    MsgBox("もう一度F11を押すと通常画面に戻ります", 64, "情報")
                End If
            End If
        End If

    End Sub
    ''' <summary>
    ''' ファンクションキーガイド　非表示メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuGideNoVisible_Click(sender As Object, e As EventArgs) Handles MenuGideNoVisible.Click
        MenuGideNoVisible.Checked = Not MenuGideNoVisible.Checked
        Panel1.Visible = Not MenuGideNoVisible.Checked
    End Sub
    ''' <summary>
    ''' 連動・非連動切り替え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblRendou_Click(sender As Object, e As EventArgs) Handles LblRendou.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm._IsWaterFall = Not TargetForm._IsWaterFall
            Call TargetForm.SheetInfomation()
        End If
    End Sub
    Private Sub FrmParent_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
#Region "ファンクションキーガイド"
    ''' <summary>
    ''' F1ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF1_Click(sender As Object, e As EventArgs) Handles LblF1.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(112)
        End If
    End Sub
    ''' <summary>
    ''' F2ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF2_Click(sender As Object, e As EventArgs) Handles LblF2.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(113)
        End If
    End Sub
    ''' <summary>
    ''' F3ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF3_Click(sender As Object, e As EventArgs) Handles LblF3.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(114)
        End If
    End Sub
    ''' <summary>
    ''' F4ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF4_Click(sender As Object, e As EventArgs) Handles LblF4.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(115)
        End If
    End Sub
    ''' <summary>
    ''' F5ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF5_Click(sender As Object, e As EventArgs) Handles LblF5.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(116)
        End If
    End Sub
    ''' <summary>
    ''' F6ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF6_Click(sender As Object, e As EventArgs) Handles LblF6.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(117)
        End If
    End Sub
    ''' <summary>
    ''' F7ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF7_Click(sender As Object, e As EventArgs) Handles LblF7.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(118)
        End If
    End Sub
    ''' <summary>
    ''' F8ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF8_Click(sender As Object, e As EventArgs) Handles LblF8.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(119)
        End If
    End Sub
    ''' <summary>
    ''' F9ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF9_Click(sender As Object, e As EventArgs) Handles LblF9.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(120)
        End If
    End Sub
    ''' <summary>
    ''' F10ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF10_Click(sender As Object, e As EventArgs) Handles LblF10.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(121)
        End If
    End Sub
    ''' <summary>
    ''' F11ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF11_Click(sender As Object, e As EventArgs) Handles LblF11.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(122)
        End If
    End Sub
    ''' <summary>
    ''' F12ファンクション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblF12_Click(sender As Object, e As EventArgs) Handles LblF12.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            Call TargetForm.FunctionAction(123)
        End If
    End Sub
#End Region

    ''' <summary>
    ''' 一時ロック切り替え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblTempLock_Click(sender As Object, e As EventArgs) Handles LblTempLock.Click
        Dim TargetForm As FrmMain = Me.ActiveMdiChild
        If Not IsNothing(TargetForm) Then
            TargetForm._TemporaryLock = Not TargetForm._TemporaryLock
            If TargetForm._TemporaryLock Then
                LblMessage.Text = "一時ロックを有効にしました"
            Else
                LblMessage.Text = "一時ロックを無効にしました"
            End If
            Call TargetForm.SheetInfomation()
        End If
    End Sub
    ''' <summary>
    ''' タブレットモードの切替
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblTabletMode_Click(sender As Object, e As EventArgs) Handles LblTabletMode.Click
        If _TabletMode Then
            If MsgBox("通常モードに切り換えてもいいですか？", 4 + 32, "切替確認") = MsgBoxResult.No Then
                Return
            End If
        Else
            If MsgBox("タブレットモードに切り換えてもいいですか？", 4 + 32, "切替確認") = MsgBoxResult.No Then
                Return
            End If
        End If
        _TabletMode = Not _TabletMode
        Call WriteReg("General", "TabletMode", _TabletMode)
        If _TabletMode Then
            LblTabletMode.Image = My.Resources.tablet
            LblMessage.Text = "タブレットモードになりました"
        Else
            LblTabletMode.Image = My.Resources.terminal
            LblMessage.Text = "通常モードになりました"
        End If
        Call IniTabletMode()
    End Sub

  
End Class
''' <summary>
''' ファイル内容確認用コレクション
''' </summary>
''' <remarks></remarks>
Public Class DataHeaderCollection
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
    ''' パスワード設定スイッチ
    ''' </summary>
    ''' <remarks></remarks>
    Public IsExclusion As Boolean
    ''' <summary>
    ''' 設定パスワード
    ''' </summary>
    ''' <remarks></remarks>
    Public ExclusionPassword As String
End Class