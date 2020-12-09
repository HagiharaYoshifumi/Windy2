Module Module1
    ''' <summary>
    ''' ファイルをエンコードする
    ''' </summary>
    ''' <param name="FromName">エンコードするファイル</param>
    ''' <param name="ToFile">エンコード先ファイル</param>
    ''' <remarks></remarks>
    Public Function FileEncode(FromName As String, ToFile As String) As Boolean
        Try
            Dim _Data As String = ""
            'Using sr As New System.IO.StreamReader(FileName, System.Text.Encoding.GetEncoding("shift_jis"))
            Using sr As New System.IO.StreamReader(FromName)
                _Data = sr.ReadToEnd()
            End Using
            _Data = SQLEncode(_Data)
            'Using sw As New System.IO.StreamWriter(FileName, False, System.Text.Encoding.GetEncoding("shift_jis"))
            Using sw As New System.IO.StreamWriter(ToFile)
                sw.Write(_Data)
            End Using
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, 48, "エラー")
            Return False
        End Try

    End Function
    ''' <summary>
    ''' ファイルをデコードする
    ''' </summary>
    ''' <param name="FromName">デコード元ファイル</param>
    ''' <param name="ToFile">デコード先ファイル</param>
    ''' <remarks></remarks>
    Public Function FileDecode(FromName As String, ToFile As String) As Boolean
        Try
            Dim _Data As String = ""
            'Using sr As New System.IO.StreamReader(FileName, System.Text.Encoding.GetEncoding("shift_jis"))
            Using sr As New System.IO.StreamReader(FromName)
                _Data = sr.ReadToEnd()
            End Using
            _Data = SQLDecode(_Data)
            'Using sw As New System.IO.StreamWriter(FileName, False, System.Text.Encoding.GetEncoding("shift_jis"))
            Using sw As New System.IO.StreamWriter(ToFile)
                sw.Write(_Data)
            End Using
            Return True

        Catch ex As Exception
            MsgBox(ex.Message, 48, "エラー")
            Return False
        End Try
    End Function
#Region "BASE64変換関係"
    'Base64は、データを64種類の印字可能な英数字のみを用いて、
    'それ以外の文字を扱うことの出来ない通信環境にてマルチバイト文字や
    'バイナリデータを扱うためのエンコード方式である。
    'MIMEによって規定されていて、7ビットのデータしか扱うことの出来ない
    '電子メールにて広く利用されている。具体的には、A?Z, a?z, 0?9 までの62文字と
    '、記号2つ (+ , /) 、さらにパディング（余った部分を詰める）のための記号として 
    '= が用いられる。この変換によって、データ量は4/3になる。
    'また、MIMEの基準では76文字ごとに改行コードが入るため、この分の2バイトを
    '計算に入れるとデータ量は約138%となる。

    ''' <summary>
    ''' 指定した文字をBASE64形式に変換する
    ''' </summary>
    ''' <param name="Value">変換元文字列</param>
    ''' <returns>変換後(BASE64)文字列</returns>
    ''' <remarks></remarks>
    Public Function SQLEncode(ByVal Value As String) As String
        If IsNothing(Value) OrElse Value.Length = 0 Then Return ""
        Try
            'ファイルをbyte型配列としてすべて読み込む
            Dim ByteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(Value)
            'Base64で文字列に変換
            Return System.Convert.ToBase64String(ByteArray)

        Catch ex As Exception
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' BASE64に変換された文字列を復号する
    ''' </summary>
    ''' <param name="ValueBASE64">変換元BASE64文字列</param>
    ''' <returns>復号文字列</returns>
    ''' <remarks></remarks>
    Public Function SQLDecode(ByVal ValueBASE64 As String) As String
        If IsNothing(ValueBASE64) OrElse ValueBASE64.Length = 0 Then Return ""
        Try
            Dim ByteArray() As Byte = System.Convert.FromBase64String(ValueBASE64)
            Return System.Text.Encoding.UTF8.GetString(ByteArray)

        Catch ex As Exception
            Return ""
        End Try
    End Function
#End Region

End Module
