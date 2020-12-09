Imports System.IO
''' <summary>
''' ログ操作クラス
''' </summary>
''' <remarks></remarks>
Public Class ClassLog
    Dim _LogPath = Application.StartupPath
    Dim _LogFileName = String.Format("Log_{0:yyyyMMdd}.log", Now)
    Dim _LogFormat = "%DateTime% %LogKind% <%ClassName%> [%MethodName%] : %Message%"
    Dim _Enable As Boolean = True
    'Dim DefFormat = "%DateTime%<TAB>%LogKind%<TAB>%ClassName%<TAB>%MethodName%<TAB>: %Message%"

#Region "Property"
    ''' <summary>
    ''' ログ出力フォルダを設定します。(既定：Exeフォルダ)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LogPath As String
        Get
            Return _LogPath
        End Get
        Set(value As String)
            If value <> "" Then
                If Directory.Exists(value) Then
                    _LogPath = value
                End If
            End If
        End Set
    End Property
    ''' <summary>
    ''' ログファイル名を設定します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LogFileName As String
        Get
            Return _LogFileName
        End Get
        Set(value As String)
            If value <> "" Then
                _LogFileName = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' ログファイル出力形式を設定します。(既定：[タイムスタンプ][状態][フォーム名][メソッド名][メッセージ])
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LogFormat As String
        Get
            Return _LogFormat
        End Get
        Set(value As String)
            If value <> "" Then
                If value.IndexOf("%Message%") > -1 Then

                End If
            End If
        End Set
    End Property
    ''' <summary>
    ''' ログ出力有効／無効を設定します。(既定：TRUE出力する)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Enable As Boolean
        Get
            Return _Enable
        End Get
        Set(value As Boolean)
            Dim StFrame As New StackFrame(1)
            'If Not value Then
            '    Call WriteLog("[SYSTEM]", StFrame, "ログ出力が無効になりました", "")
            'End If
            _Enable = value
            'If value Then
            '    Call WriteLog("[SYSTEM]", StFrame, "ログ出力が有効になりました", "")
            'End If
        End Set
    End Property
    ''' <summary>
    ''' 区切り線出力の有効／無効を設定します。(既定：TRUE出力する)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AddLine As Boolean = True
#End Region
#Region "Method"
    ''' <summary>
    ''' ログの書込(開始)
    ''' </summary>
    ''' <param name="Msg">書込メッセージ</param>
    ''' <param name="IsTrim">True:作業前にログのトリミングを行います。</param>
    ''' <param name="TrimDay">ログの保持日数を設定します。既定：３日保持</param>
    ''' <remarks>自動的に実行ファイル名がログに書き込まれます。</remarks>
    <DebuggerStepThrough()> _
    Public Sub PutStart(Msg As String, Optional IsTrim As Boolean = False, Optional TrimDay As Integer = 3)
        Dim StFrame As New StackFrame(1)
        If _AddLine Then Call WriteLine()
        If IsTrim Then
            Call LogTrim(TrimDay, True)
            Call WriteLog("[開始]", StFrame, Msg & " (WithTrim)", Me.[GetType]().Assembly.Location)
        Else
            Call WriteLog("[開始]", StFrame, Msg, "File: " & Me.[GetType]().Assembly.Location)
        End If
    End Sub
    ''' <summary>
    ''' ログの書込(終了)
    ''' </summary>
    ''' <param name="Msg">書込メッセージ</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub PutEnd(Msg As String)
        Dim StFrame As New StackFrame(1)
        Call WriteLog("[終了]", StFrame, Msg, "")
    End Sub
    ''' <summary>
    ''' ログの書込(システム)
    ''' </summary>
    ''' <param name="Msg">書込メッセージ</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Private Sub PutSystem(Msg As String)
        Dim StFrame As New StackFrame(1)
        Call WriteLog("[SYSTEM]", StFrame, Msg, "")
    End Sub
    ''' <summary>
    ''' ログの書込(デバグ)
    ''' </summary>
    ''' <param name="Msg">書込メッセージ</param>
    ''' <param name="OtherData">追加記載するデータ</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub PutDebug(Msg As String, Optional OtherData As String = "")
        Dim StFrame As New StackFrame(1)
        Call WriteLog("[デバグ]", StFrame, Msg, OtherData)
    End Sub
    ''' <summary>
    ''' ログの書込(情報)
    ''' </summary>
    ''' <param name="Msg">書込メッセージ</param>
    ''' <param name="OtherData">追加記載するデータ</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub PutInformation(Msg As String, Optional OtherData As String = "")
        Dim StFrame As New StackFrame(1)
        Call WriteLog("[情報]", StFrame, Msg, OtherData)
    End Sub
    ''' <summary>
    ''' ログの書込(警告)
    ''' </summary>
    ''' <param name="Msg">書込メッセージ</param>
    ''' <param name="OtherData">追加記載するデータ</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub PutWarning(Msg As String, Optional OtherData As String = "")
        Dim StFrame As New StackFrame(1)
        Call WriteLog("[警告]", StFrame, Msg, OtherData)
    End Sub
    ''' <summary>
    ''' ログの書込(エラー)
    ''' </summary>
    ''' <param name="Msg">書込メッセージ</param>
    ''' <param name="OtherData">追加記載するデータ</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub PutError(Msg As String, Optional OtherData As String = "")
        Dim StFrame As New StackFrame(1)
        Call WriteLog("[エラー]", StFrame, Msg, OtherData)
    End Sub
    ''' <summary>
    ''' ログの書込(Error Exception)
    ''' </summary>
    ''' <param name="Message">書込メッセージ</param>
    ''' <param name="exd">Error Exception(ex)</param>
    ''' <remarks>自動的にエラー発生行番号も出力されます。</remarks>
    <DebuggerStepThrough()> _
    Public Sub PutErrorEx(Message As String, exd As Exception, Optional RiseUserMessage As Boolean = False)
        Dim lineNumber As Integer = 0
        Try
            Dim stackTrace As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace(exd, True)
            If stackTrace.GetFrames.Count > 0 Then
                lineNumber = stackTrace.GetFrame(0).GetFileLineNumber()
            End If

            Dim StFrame As New StackFrame(1)
            Dim _T As String = String.Format("{0}(行番号：{1})", exd.Message, lineNumber)
            Call WriteLog("[エラーex]", StFrame, Message, _T)
            If RiseUserMessage Then
                MsgBox(Message, 48, "エラー")
            End If
        Catch ex As Exception
        End Try

    End Sub
    ''' <summary>
    ''' 出力ログファイルを開きます。
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub OpenLogFile()
        Try
            Dim FN As String = GetLogFileName()
            If File.Exists(FN) Then
                Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(FN)
            End If
        Catch ex As Exception
        End Try
    End Sub
    ''' <summary>
    ''' 出力ログファイルのフォルダを開きます。
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub OpenLogFolder()
        Try
            If Directory.Exists(_LogPath) Then
                System.Diagnostics.Process.Start(_LogPath)
            End If
        Catch ex As Exception
        End Try
    End Sub
    ''' <summary>
    ''' ログファイルフルネームを返します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Function GetLogFileName() As String
        Return My.Computer.FileSystem.CombinePath(_LogPath, _LogFileName)
    End Function
    ''' <summary>
    ''' ログファイルのクリア
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LogClear()
        Try
            Call WriteFile("", False)
            Dim StFrame As New StackFrame(1)
            Call WriteLine()
            Call WriteLog("[SYSTEM]", StFrame, "ログがクリアされました", "")
            Call WriteLine()
        Catch ex As Exception
        End Try
    End Sub
    ''' <summary>
    ''' ログを日付によりトリムする
    ''' </summary>
    ''' <param name="TrimDay">トリム対象日数(0:前日までを削除 1:前々日までを削除)</param>
    ''' <remarks>注意：先頭区切り線は削除されます</remarks>
    Public Sub LogTrim(TrimDay As Integer, Optional NoMessage As Boolean = False)

        Dim DfDay As Integer = 3
        If TrimDay >= 0 Then DfDay = TrimDay '正しい指定がなければ３日前までは残す

        Try
            Dim FN As String = GetLogFileName()
            Dim LineTexts As New ArrayList
            Dim LineTexts2 As New ArrayList
            Dim OKFlg As Boolean = False
            Dim WorkFlg As Boolean = False

            '既存ログを読み込む
            Using sr As New System.IO.StreamReader(FN, System.Text.Encoding.GetEncoding("shift_jis"))
                While sr.Peek() > -1
                    LineTexts.Add(sr.ReadLine())
                End While
            End Using

            If LineTexts.Count > 0 Then
                '対象日付の検索
                For Each Itm As String In LineTexts
                    If Not OKFlg Then
                        If Itm.IndexOf(" ") > -1 Then
                            Dim Ls() As String = Itm.Split(" ")
                            If Ls.Length > 0 Then
                                If IsDate(Ls(0)) Then
                                    Dim DT As Date = CDate(Ls(0))
                                    If DateDiff(DateInterval.Day, Now, DT) >= 0 - DfDay Then
                                        OKFlg = True
                                        LineTexts2.Add(Itm)
                                    Else
                                        WorkFlg = True
                                    End If
                                End If
                            End If
                        End If
                    Else
                        LineTexts2.Add(Itm)
                    End If
                Next

                If LineTexts2.Count > 0 Then
                    'トリムしたログを書き込む
                    Using sw As New System.IO.StreamWriter(FN, False, System.Text.Encoding.GetEncoding("shift_jis"))
                        For Each Itm As String In LineTexts2
                            sw.Write(Itm & vbCrLf)
                        Next
                    End Using
                Else
                    Using sw As New System.IO.StreamWriter(FN, False, System.Text.Encoding.GetEncoding("shift_jis"))
                        sw.Write("")
                    End Using
                End If
                If Not NoMessage Then
                    Dim StFrame As New StackFrame(1)
                    Call WriteLine()
                    Call WriteLog("[SYSTEM]", StFrame, String.Format("ログがトリムされました 調整日数：{0}", DfDay), "")
                    Call WriteLine()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
#End Region
#Region "Provatte Method"
    Private Sub WriteLog(Kind As String, FR As StackFrame, MSG As String, Data As String)
        Dim Moji As String = _LogFormat
        Dim MFlg As Boolean = Moji.IndexOf("%Message%") > -1

        Moji = Moji.Replace("%DateTime%", Now.ToString)
        Moji = Moji.Replace("%LogKind%", Kind)
        Moji = Moji.Replace("%ClassName%", FR.GetMethod.DeclaringType.Name.ToString)
        Moji = Moji.Replace("%MethodName%", FR.GetMethod.Name.ToString)
        If MFlg Then
            Moji = Moji.Replace("%Message%", MSG)
            If Data <> "" Then
                Dim M2 As String = Data.Replace("|", vbCrLf)
                Moji = Moji & vbCrLf & "  <DATA> " & M2
            End If
        End If
        Moji = Moji.Replace("<TAB>", vbTab)
        Moji = Moji & vbCrLf
        Call WriteFile(Moji)
    End Sub
    Private Sub WriteLine()
        Call WriteFile("-----------------------------------------------------------------------------" & vbCrLf)
    End Sub
    Private Sub WriteFile(Moji As String, Optional IsAppend As Boolean = True)
        If Not Enable Then Return
        Try
            Dim FN As String = GetLogFileName()
            Using sw As New System.IO.StreamWriter(FN, IsAppend, System.Text.Encoding.GetEncoding("shift_jis"))
                sw.Write(Moji)
            End Using
        Catch ex As Exception
        End Try
    End Sub
#End Region

End Class
