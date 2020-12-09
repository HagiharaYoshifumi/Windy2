Module Module1
    Public _CopyPiece As KnTViewLib.Piece = Nothing 'コピーしたピースオブジェクト
    Public _CopyBalloons As KnTViewLib.Balloons = Nothing 'コピーしたバルーンブジェクト

    Public _CopyItem As KnTViewLib.Item = Nothing

    Public _SaturdayColor As UInt32 '土曜日色
    Public _SundayColor As UInt32 '日曜日色
    Public _TodayColor As UInt32 '当日色
    Public _Today As Integer = 7 '今日の余白日数
    Public _StartDay As Integer = 7 '先頭余白日数
    Public _FinalDay As Integer = 7 '最終余白日数
    Public _PrintDay As Integer = 7 '印刷余白日数
    Public _DefTunnel As Boolean = False
    Public _Holiday As New List(Of HolidayCollection)
    Public _NoHighlight As Boolean = False 'ピース選択時にハイライトしない
    Public _TabletMode As Boolean = False
    Public _IsDebugMode As Boolean = False
    Public _FontSizeCellHeader As Integer = 9
    Public _FontSizeCell As Integer = 9
    Public _FontSizePiece As Integer = 9

    Public Logs As New ClassLog
    ''' <summary>
    ''' 反対色を作る
    ''' </summary>
    ''' <param name="Source">元となる色</param>
    ''' <returns>生成色</returns>
    ''' <remarks></remarks>
    Public Function ToBackColor(ByVal Source As Color) As Color
        Dim bColor As Single = CSng(Source.R * 299I + Source.G * 587I + Source.B * 114I) / 1000.0F
        If bColor > 127.5F Then
            Return SystemColors.WindowText
        Else
            Return Color.White
        End If
    End Function
    ''' <summary>
    ''' 色値変換
    ''' </summary>
    ''' <param name="Value">色番号</param>
    ''' <returns>色</returns>
    ''' <remarks></remarks>
    Public Function ConvertColorValue(ByVal Value As System.UInt32) As Color
        Try
            Return System.Drawing.ColorTranslator.FromOle(Value)
            'Return ColorTranslator.FromWin32(Value)
        Catch ex As Exception
        End Try
    End Function
    ''' <summary>
    ''' 色値変換
    ''' </summary>
    ''' <param name="Value">色</param>
    ''' <returns>色番号</returns>
    ''' <remarks></remarks>
    Public Function ConvertColorValue(ByVal Value As Color) As System.UInt32
        'Return System.Drawing.ColorTranslator.ToOle(Value)
        Return System.UInt32.Parse(RGB(Value.R, Value.G, Value.B))
    End Function
    ''' <summary>
    ''' ラベルに日付を設定する
    ''' </summary>
    ''' <param name="Value">対象文字</param>
    ''' <param name="Value2">設定日付</param>
    ''' <returns>調整された文字</returns>
    ''' <remarks></remarks>
    Public Function ConvCaptionDate(ByVal Value As String, ByVal Value2 As Date) As String
        If Not IsNothing(Value2) Then
            Return Replace(Value, "<DATE>", Format(Value2, "M/d"))
        Else
            Return Replace(Value, "<DATE>", "日付")
        End If
    End Function
    ''' <summary>
    ''' ラベルに日数を設定する
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <param name="StartDay"></param>
    ''' <param name="FinishDay"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConvCaptionDateCount(ByVal Value As String, ByVal StartDay As Date, FinishDay As Date) As String
        If Not IsNothing(StartDay) Then
            If Not IsNothing(FinishDay) Then
                Dim S As Integer = DateDiff(DateInterval.Day, StartDay, FinishDay)
                Return Replace(Value, "<COUNT>", String.Format("{0}日", S + 1))
            Else
                Return Replace(Value, "<COUNT>", String.Format("{0}日", 1))
            End If
        Else
            Return Replace(Value, "<COUNT>", "")
        End If
    End Function
    ''' <summary>
    ''' ContentAlignmentを分ける
    ''' </summary>
    ''' <param name="value">位置</param>
    ''' <returns>位置</returns>
    ''' <remarks>
    ''' X=横方向(0:左 1:中 2:右)
    ''' Y=縦方向(0:上 1:中 2:下)
    ''' </remarks>
    Public Function AlignmentValue(value As ContentAlignment) As Point

        'Dim Y As Integer = Int(Math.Log(value, 16))
        'Dim X As Integer = value / (16 ^ Y)
        'Return New Point(X, Y)

        Select Case value
            Case ContentAlignment.TopLeft : Return New Point(0, 0)
            Case ContentAlignment.TopCenter : Return New Point(1, 0)
            Case ContentAlignment.TopRight : Return New Point(2, 0)
            Case ContentAlignment.MiddleLeft : Return New Point(0, 1)
            Case ContentAlignment.MiddleCenter : Return New Point(1, 1)
            Case ContentAlignment.MiddleRight : Return New Point(2, 1)
            Case ContentAlignment.BottomLeft : Return New Point(0, 2)
            Case ContentAlignment.BottomCenter : Return New Point(1, 2)
            Case Else : Return New Point(2, 2)
        End Select

    End Function
    ''' <summary>
    ''' グループ内の選択されているラジオボタンを検索する
    ''' </summary>
    ''' <param name="top">入っているグループボックス</param>
    ''' <returns>見つけたラジオボタン</returns>
    ''' <remarks></remarks>
    Public Function CheckedRadioButton(ByVal top As GroupBox) As RadioButton
        Dim buf As ArrayList = New ArrayList
        For Each c As Control In top.Controls
            If TypeOf c Is RadioButton Then
                Dim Obj As RadioButton = c
                If Obj.Checked Then
                    Return c
                End If
            End If
        Next
        Return Nothing
    End Function
    ''' <summary>
    ''' 水平オプショングループと垂直オプショングループから文字位置を検索する
    ''' </summary>
    ''' <param name="HGroup"></param>
    ''' <param name="VGroup"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AlignmentButtons(HGroup As GroupBox, VGroup As GroupBox) As ContentAlignment
        Dim _HG As RadioButton = CheckedRadioButton(HGroup)
        Dim _VG As RadioButton = CheckedRadioButton(VGroup)
        If Not IsNothing(_HG) AndAlso Not IsNothing(_VG) Then
            Dim _HI As String = _HG.Tag
            Dim _VI As String = _VG.Tag
            Dim _Value As ContentAlignment = GetAlignmentValue(_HI, _VI)
            Return _Value
        End If
        Return 0
    End Function
    ''' <summary>
    ''' XYからContentAlignmentに変換
    ''' </summary>
    ''' <param name="H_Value">横方向位置(0:左 1:中 2:右)</param>
    ''' <param name="V_Value">縦方向位置(0:上 1:中 2:下)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAlignmentValue(H_Value As Integer, V_Value As Integer) As ContentAlignment

        'Dim V As Integer = (2 ^ H_Value) * (16 ^ V_Value)

        Select Case V_Value
            Case 0
                Select Case H_Value
                    Case 0 : Return ContentAlignment.TopLeft
                    Case 1 : Return ContentAlignment.TopCenter
                    Case Else : Return ContentAlignment.TopRight
                End Select
            Case 1
                Select Case H_Value
                    Case 0 : Return ContentAlignment.MiddleLeft
                    Case 1 : Return ContentAlignment.MiddleCenter
                    Case Else : Return ContentAlignment.MiddleRight
                End Select
            Case Else
                Select Case H_Value
                    Case 0 : Return ContentAlignment.BottomLeft
                    Case 1 : Return ContentAlignment.BottomCenter
                    Case Else : Return ContentAlignment.BottomRight
                End Select
        End Select
    End Function
#Region "ピースタグ関係"
    ''' <summary>
    ''' ピースタグ要素変換
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PeaceTag(Value As String) As PeaceTagCollection
        Dim T As New PeaceTagCollection
        If Value <> "" Then
            Dim S() As String = Split(Value, "|")
            Select Case S.Length
                Case 2
                    T.IsWaterFall = IIf(S(0) = "1", True, False)
                    T.IsSummaryPiece = IIf(S(1) = "1", True, False)
                    T.UseSummaryPreogress = False
                    T.IsSummaryExclusion = False
                Case 3
                    T.IsWaterFall = IIf(S(0) = "1", True, False)
                    T.IsSummaryPiece = IIf(S(1) = "1", True, False)
                    T.UseSummaryPreogress = IIf(S(2) = "1", True, False)
                    T.IsSummaryExclusion = False
                Case 4
                    T.IsWaterFall = IIf(S(0) = "1", True, False)
                    T.IsSummaryPiece = IIf(S(1) = "1", True, False)
                    T.UseSummaryPreogress = IIf(S(2) = "1", True, False)
                    T.IsSummaryExclusion = IIf(S(3) = "1", True, False)
                Case Else
                    T.IsWaterFall = IIf(S(0) = "1", True, False)
                    T.IsSummaryPiece = False
                    T.UseSummaryPreogress = False
                    T.IsSummaryExclusion = False
            End Select
        End If

        Return T
    End Function
    ''' <summary>
    ''' ピースタグ要素変換
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PeaceTag(Value As PeaceTagCollection) As String
        Dim D1 As String = IIf(Value.IsWaterFall, "1", "0")
        Dim D2 As String = IIf(Value.IsSummaryPiece, "1", "0")
        Dim D3 As String = IIf(Value.UseSummaryPreogress, "1", "0")
        Dim D4 As String = IIf(Value.IsSummaryExclusion, "1", "0")
        Dim T As String = ""
        T = String.Format("{0}|{1}|{2}|{3}", D1, D2, D3, D4)

        Return T
    End Function
#End Region

#Region "セルタグ関係"
    ''' <summary>
    ''' セルタグ要素変換
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CellTagConvert(Value As String) As CellTagCollection
        Dim _D As New CellTagCollection
        If Value.IndexOf("|") > -1 Then
            Dim _A() As String = Value.Split("|")
            _D.Caption = _A(0)
            If _A(1) = "HIDDEN" Then
                _D.IsHidden = True
            Else
                _D.IsHidden = False
            End If
        Else
            If Value = "HIDDEN" OrElse Value = "NOHIDDEN" Then
                _D.Caption = ""
                If Value = "HIDDEN" Then
                    _D.IsHidden = True
                Else
                    _D.IsHidden = False
                End If
            Else
                _D.Caption = Value
                _D.IsHidden = False
            End If
        End If
        Return _D
    End Function
    ''' <summary>
    ''' セルタグ要素変換
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CellTagConvert(Value As CellTagCollection) As String
        Dim _H As String = IIf(Value.IsHidden, "HIDDEN", "NOHIDDEN")
        Return String.Format("{0}|{1}", Value.Caption, _H)
    End Function
#End Region
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
''' <summary>
''' ピースタグ用コレクション
''' </summary>
''' <remarks></remarks>
Public Class PeaceTagCollection
    Public IsWaterFall As Boolean
    ''' <summary>
    ''' サマリーピース？
    ''' </summary>
    ''' <remarks></remarks>
    Public IsSummaryPiece As Boolean
    ''' <summary>
    ''' サマリー進捗合計を行う？
    ''' </summary>
    ''' <remarks></remarks>
    Public UseSummaryPreogress As Boolean
    Public IsSummaryExclusion As Boolean
    Sub New()
        Me.IsWaterFall = False
        Me.IsSummaryPiece = False
        Me.UseSummaryPreogress = False
        Me.IsSummaryExclusion = False
    End Sub
End Class
''' <summary>
''' セルタグ用コレクション
''' </summary>
''' <remarks></remarks>
Public Class CellTagCollection
    ''' <summary>
    ''' セル内容
    ''' </summary>
    ''' <remarks></remarks>
    Public Caption As String
    ''' <summary>
    ''' 非表示スイッチ
    ''' </summary>
    ''' <remarks></remarks>
    Public IsHidden As Boolean
    Sub New()
        Me.Caption = ""
        Me.IsHidden = False
    End Sub
End Class
