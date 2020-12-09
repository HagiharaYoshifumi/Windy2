Imports System.IO
Public Class FrmAbout

    Private Sub FrmAbout_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FN As String = Path.Combine(My.Application.Info.DirectoryPath, My.Application.Info.AssemblyName & ".exe")
        If File.Exists(FN) Then
            Dim Info As _VersionInfo = GetFileVersionInfo(FN)
            LblVersion.Text = Info.FileVersion
            LblAssyVer.Text = My.Application.Info.Version.ToString
        End If
        LblPath.Text = AppFullPath("")  '実行パス
        If System.Environment.Is64BitOperatingSystem Then
            LblOS.Text = "使用ＯＳ：６４ビット"
            Console.WriteLine("64ビットOSです。")
        Else
            LblOS.Text = "使用ＯＳ：３２ビット"
            Console.WriteLine("32ビットOSです。")
        End If
    End Sub
    ''' <summary>
    ''' ファイルの情報を取得する
    ''' </summary>
    ''' <param name="FileName">取得するファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Function GetFileVersionInfo(ByVal FileName As String) As _VersionInfo
        Dim Ret As _VersionInfo = Nothing
        If File.Exists(FileName) Then
            Try
                Dim vi As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(FileName)
                With Ret
                    'バージョン番号
                    .FileVersion = vi.FileVersion
                    'メジャーバージョン番号
                    .FileMajorPart = vi.FileMajorPart
                    'マイナバージョン番号
                    .FileMinorPart = vi.FileMinorPart
                    'プライベートパート番号
                    .FilePrivatePart = vi.FilePrivatePart
                    'ビルド番号
                    .FileBuildPart = vi.FileBuildPart
                    'プライベートバージョン
                    .PrivateBuild = vi.PrivateBuild
                    'スペシャルビルド
                    .SpecialBuild = vi.SpecialBuild

                    '説明
                    .FileDescription = vi.FileDescription
                    '著作権
                    .LegalCopyright = vi.LegalCopyright
                    '会社名
                    .CompanyName = vi.CompanyName
                    'コメント
                    .Comments = vi.Comments
                    '内部名
                    .InternalName = vi.InternalName
                    '言語
                    .Language = vi.Language
                    '商標
                    .LegalTrademarks = vi.LegalTrademarks
                    'オリジナルファイル名
                    .OriginalFilename = vi.OriginalFilename

                    '製品名
                    .ProductName = vi.ProductName
                    '製品バージョン
                    .ProductVersion = vi.ProductVersion
                    '製品メジャーバージョン番号
                    .ProductMajorPart = vi.ProductMajorPart
                    '製品マイナバージョン番号
                    .ProductMinorPart = vi.ProductMinorPart
                    '製品プライベートバージョン番号
                    .ProductPrivatePart = vi.ProductPrivatePart
                    '製品ビルド番号
                    .ProductBuildPart = vi.ProductBuildPart

                    'デバッグ情報があるか
                    .IsDebug = vi.IsDebug
                    'パッチされているか
                    .IsPatched = vi.IsPatched
                    'プレリリースか
                    .IsPreRelease = vi.IsPreRelease
                    'スペシャルビルドか
                    .IsSpecialBuild = vi.IsSpecialBuild
                End With
            Catch ex As Exception
                Logs.PutErrorEx("情報取得エラー", ex)
            End Try
        End If
        Return Ret
    End Function
    ''' <summary>
    ''' ファイル情報
    ''' </summary>
    ''' <remarks></remarks>
    Structure _VersionInfo
        ''' <summary>
        ''' バージョン番号
        ''' </summary>
        ''' <remarks></remarks>
        Dim FileVersion As String
        ''' <summary>
        ''' メジャーバージョン番号
        ''' </summary>
        ''' <remarks></remarks>
        Dim FileMajorPart As Integer
        ''' <summary>
        ''' マイナバージョン番号
        ''' </summary>
        ''' <remarks></remarks>
        Dim FileMinorPart As Integer
        ''' <summary>
        ''' ビルド番号
        ''' </summary>
        ''' <remarks></remarks>
        Dim FileBuildPart As Integer
        ''' <summary>
        ''' プライベートパート番号
        ''' </summary>
        ''' <remarks></remarks>
        Dim FilePrivatePart As Integer
        ''' <summary>
        ''' プライベートバージョン
        ''' </summary>
        ''' <remarks></remarks>
        Dim PrivateBuild As String
        ''' <summary>
        ''' スペシャルビルド
        ''' </summary>
        ''' <remarks></remarks>
        Dim SpecialBuild As String
        ''' <summary>
        ''' 説明
        ''' </summary>
        ''' <remarks></remarks>
        Dim FileDescription As String
        ''' <summary>
        ''' 著作権
        ''' </summary>
        ''' <remarks></remarks>
        Dim LegalCopyright As String
        ''' <summary>
        ''' 会社名
        ''' </summary>
        ''' <remarks></remarks>
        Dim CompanyName As String
        ''' <summary>
        ''' コメント
        ''' </summary>
        ''' <remarks></remarks>
        Dim Comments As String
        ''' <summary>
        ''' 内部名
        ''' </summary>
        ''' <remarks></remarks>
        Dim InternalName As String
        ''' <summary>
        ''' 言語
        ''' </summary>
        ''' <remarks></remarks>
        Dim Language As String
        ''' <summary>
        ''' 商標
        ''' </summary>
        ''' <remarks></remarks>
        Dim LegalTrademarks As String
        ''' <summary>
        ''' オリジナルファイル名
        ''' </summary>
        ''' <remarks></remarks>
        Dim OriginalFilename As String
        ''' <summary>
        ''' 製品名
        ''' </summary>
        ''' <remarks></remarks>
        Dim ProductName As String
        ''' <summary>
        ''' 製品バージョン
        ''' </summary>
        ''' <remarks></remarks>
        Dim ProductVersion As String
        ''' <summary>
        ''' 製品メジャーバージョン番号
        ''' </summary>
        ''' <remarks></remarks>
        Dim ProductMajorPart As Integer
        ''' <summary>
        ''' 製品マイナバージョン番号
        ''' </summary>
        ''' <remarks></remarks>
        Dim ProductMinorPart As Integer
        ''' <summary>
        ''' 製品ビルド番号
        ''' </summary>
        ''' <remarks></remarks>
        Dim ProductBuildPart As Integer
        ''' <summary>
        ''' 製品プライベートバージョン番号
        ''' </summary>
        ''' <remarks></remarks>
        Dim ProductPrivatePart As Integer
        ''' <summary>
        ''' デバッグ情報があるか
        ''' </summary>
        ''' <remarks></remarks>
        Dim IsDebug As Boolean
        ''' <summary>
        ''' パッチされているか
        ''' </summary>
        ''' <remarks></remarks>
        Dim IsPatched As Boolean
        ''' <summary>
        ''' プレリリースか
        ''' </summary>
        ''' <remarks></remarks>
        Dim IsPreRelease As Boolean
        ''' <summary>
        ''' スペシャルビルドか
        ''' </summary>
        ''' <remarks></remarks>
        Dim IsSpecialBuild As Boolean
    End Structure

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Me.Close()
    End Sub

    Private Sub BtnOpenFolder0_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnOpenFolder1_Click(sender As Object, e As EventArgs)
        Dim FL As String = NFuncSystemFullPath(Environment.SpecialFolder.CommonApplicationData, "")
        Try
            If Directory.Exists(FL) Then
                System.Diagnostics.Process.Start(FL)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, 48, "フォルダーを開く")
        End Try
    End Sub

    Private Sub BtnOpenFolder3_Click(sender As Object, e As EventArgs)
        Dim FL As String = NFuncSystemFullPath(Environment.SpecialFolder.ApplicationData, "")
        Try
            If Directory.Exists(FL) Then
                System.Diagnostics.Process.Start(FL)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, 48, "フォルダーを開く")
        End Try
    End Sub

    Private Sub LblPath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblPath.LinkClicked
        Dim FL As String = AppFullPath("")  '実行パス
        Try
            If Directory.Exists(FL) Then
                System.Diagnostics.Process.Start(FL)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, 48, "フォルダーを開く")
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub BtnAppFolder_Click(sender As Object, e As EventArgs)
        Dim FL As String = AppFullPath("")
        Try
            If Directory.Exists(FL) Then
                System.Diagnostics.Process.Start(FL)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, 48, "フォルダーを開く")
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class