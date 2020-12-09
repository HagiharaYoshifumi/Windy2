Namespace My

    ' 次のイベントは MyApplication に対して利用できます:
    ' 
    ' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。
    ' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    Partial Friend Class MyApplication

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            Logs.PutEnd("アプリケーションを終了しました")
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            Logs.LogFileName = "Windy2_ExecuteLog.log" 'ログファイル名
            Logs.Enable = ReadReg("General", "WriteLog", enum_Type.er_Boolean)
            Logs.PutStart("アプリケーション開始しました", True, 3) 'ログ内容保持日数

            If Not System.IO.File.Exists(AppFullPath("stoneicon.dat")) Then
                MsgBox("ストーンアイコンファイルが見つかりません", 48, "起動エラー")
                Logs.PutError("ストーンアイコンファイルが見つかりません")
                e.Cancel = True
            End If
        End Sub
    End Class


End Namespace

