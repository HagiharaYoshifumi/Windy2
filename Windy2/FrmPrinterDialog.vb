Public Class FrmPrinterDialog

    Private iOrientation As Integer            '用紙方向
    Private iPaperSize As Integer              '用紙サイズ
    Private iMag As Integer                    '倍率
    Private blnCol As Boolean                  '列指定を行うか？
    Private iColFrom As Integer                '開始列
    Private iColTo As Integer                  '終了列
    Private blnBreak As Boolean                '強制改ページを行うか？
    Private iBreakItem As Integer              '強制改ページを行うアイテム番号
    Private blnMono As Boolean                 'テキストを白黒にするか？ 
    Private iTViewItemCount As Integer         'TimeViewのアイテムカウント
    Private iTViewColHeaderCount As Integer    'TimeViewのカラムヘッダカウント

    Dim _TargetTV As AxKnTViewLib.AxKnTView
    Dim _DS As Date = Nothing
    Dim _DE As Date = Nothing
    Dim _Title As String = "無題"

    '各プロパティのGet関数
#Region "プロパティ"
    Public Property TargetTV As AxKnTViewLib.AxKnTView
        Get
            Return _TargetTV
        End Get
        Set(value As AxKnTViewLib.AxKnTView)
            _TargetTV = value
        End Set
    End Property
    Public Property DS As Date
        Get
            Return _DS
        End Get
        Set(value As Date)
            _DS = value
            TxtStartDay.Value = value
        End Set
    End Property
    Public Property DE As Date
        Get
            Return _DE
        End Get
        Set(value As Date)
            _DE = value
            TxtEndDay.Value = value
        End Set
    End Property
    Public Property Title As String
        Get
            Return _Title
        End Get
        Set(value As String)
            _Title = value
        End Set
    End Property



    Public ReadOnly Property Orientation() As Integer
        Get
            Return iOrientation
        End Get
    End Property

    Public ReadOnly Property PaperSize()
        Get
            Return iPaperSize
        End Get
    End Property

    Public ReadOnly Property Magnification()
        Get
            Return iMag
        End Get
    End Property
    Public ReadOnly Property col()
        Get
            Return blnCol
        End Get
    End Property

    Public ReadOnly Property ColFrom()
        Get
            Return iColFrom
        End Get
    End Property

    Public ReadOnly Property ColTo()
        Get
            Return iColTo
        End Get
    End Property
    Public ReadOnly Property Break()
        Get
            Return blnBreak
        End Get
    End Property
    Public ReadOnly Property BreakItem()
        Get
            Return iBreakItem
        End Get
    End Property
    Public ReadOnly Property Mono()
        Get
            Return blnMono
        End Get
    End Property

    Public Property TViewItemCount()
        Get
            Return iTViewItemCount
        End Get
        Set(ByVal Value)
            iTViewItemCount = Value
        End Set
    End Property

    Public Property TViewColHeaderCount()
        Get
            Return iTViewColHeaderCount
        End Get
        Set(ByVal Value)
            iTViewColHeaderCount = Value
        End Set
    End Property
#End Region

    Private Sub getValue()
        cboOrientation.SelectedItem = iOrientation
        cboPaperSize.SelectedItem = iPaperSize
        updMag.Value = iMag
        If (blnCol) Then
            chkCol.Checked = True
        Else
            chkCol.Checked = False
        End If
        cboColFrom.SelectedItem = iColFrom
        cboColTo.SelectedItem = iColTo
        If (blnBreak) Then
            chkBreak.Checked = True
        Else
            chkBreak.Checked = False
        End If
        cboNewPage.SelectedItem = iBreakItem
        If (blnMono) Then
            chkMono.Checked = True
        Else
            chkMono.Checked = False
        End If

    End Sub

    Private Sub setValue()

        Dim strCombo As String
        Dim strTemp As String
        Dim i As Integer
        iOrientation = Convert.ToInt32(cboOrientation.SelectedIndex.ToString())
        iPaperSize = Convert.ToInt32(cboPaperSize.SelectedIndex.ToString())
        iMag = Convert.ToInt32(updMag.Value)
        If chkCol.Checked Then
            blnCol = True
        Else
            blnCol = False
        End If

        If (Convert.ToInt32(cboColFrom.SelectedIndex.ToString()) <> -1) Then
            strCombo = cboColFrom.SelectedItem.ToString()
            strTemp = ""
            For i = 0 To strCombo.Length - 3
                strTemp = strTemp + Convert.ToString(strCombo.Substring(i, 1))
            Next
            strCombo = strTemp
            iColFrom = Convert.ToInt32(strCombo)
        End If

        If (Convert.ToInt32(cboColTo.SelectedIndex.ToString()) <> -1) Then

            strCombo = cboColTo.SelectedItem.ToString()
            strTemp = ""
            For i = 0 To strCombo.Length - 3
                strTemp = strTemp + Convert.ToString(strCombo.Substring(i, 1))
            Next
            strCombo = strTemp
            iColTo = Convert.ToInt32(strCombo)
        End If

        If (chkBreak.Checked) Then
            blnBreak = True
            strCombo = cboNewPage.SelectedItem.ToString()
            strTemp = ""

            For i = 0 To strCombo.Length - 3
                strTemp = strTemp + Convert.ToString(strCombo.Substring(i, 1))
            Next

            strCombo = strTemp
            iBreakItem = Convert.ToInt32(strCombo)
        Else
            blnBreak = False
        End If

        If (chkMono.Checked) Then
            blnMono = True
        Else
            blnMono = False
        End If

    End Sub

    '固定値を初期設定します。
    Private Sub setDefault()

        iOrientation = -1
        iPaperSize = -1
        iMag = 100
        blnCol = False
        iColFrom = -1
        iColTo = -1
        blnBreak = False
        iBreakItem = -1
        blnMono = False
    End Sub

    Private Sub updateItemCombo()
        Dim i As Integer
        cboNewPage.Items.Clear()
        For i = 1 To iTViewItemCount
            cboNewPage.Items.Add(Convert.ToString(i) + "行目")
        Next
    End Sub

    Private Sub updateColumnCombo()
        Dim i As Integer

        cboColFrom.Items.Clear()
        cboColTo.Items.Clear()
        For i = 1 To iTViewColHeaderCount
            cboColFrom.Items.Add(Convert.ToString(i) + "列目")
            cboColTo.Items.Add(Convert.ToString(i) + "列目")
        Next
    End Sub

    'ページロードイベントです。
    Private Sub dlgPrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '固定値を初期設定します。
        setDefault()

        cboOrientation.Items.Add("デフォルト")
        cboOrientation.Items.Add("縦方向")
        cboOrientation.Items.Add("横方向")
        cboOrientation.SelectedIndex = ReadReg("PrinterSetting", "Orientation", enum_Type.er_Integer)

        cboPaperSize.Items.Add("デフォルト")
        cboPaperSize.Items.Add("A4")
        cboPaperSize.Items.Add("A3")
        cboPaperSize.Items.Add("A5")
        cboPaperSize.Items.Add("B4")
        cboPaperSize.Items.Add("B5")
        cboPaperSize.SelectedIndex = ReadReg("PrinterSetting", "PaperSize", enum_Type.er_Integer)

        updateItemCombo()

        If (chkBreak.Checked) Then
            cboNewPage.Enabled = True
        Else
            cboNewPage.Enabled = False
        End If

        updateColumnCombo()

        If (chkCol.Checked) Then
            cboColFrom.Enabled = True
            cboColTo.Enabled = True
        Else
            cboColFrom.Enabled = False
            cboColTo.Enabled = False
        End If
    End Sub

    'cmdOKボタンクリックイベントです。
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        setValue()
        Call WriteReg("PrinterSetting", "Orientation", cboOrientation.SelectedIndex)
        Call WriteReg("PrinterSetting", "PaperSize", cboPaperSize.SelectedIndex)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    'cmdCancelボタンクリックイベントです。
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'getValue()
        'Hide()
        Me.Close()
    End Sub

    '強制改ページのチェックボックスが変化したときのイベントです。
    Private Sub chkBreak_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBreak.CheckedChanged
        If chkBreak.Checked Then
            cboNewPage.Enabled = True
        Else
            cboNewPage.Enabled = False
        End If
    End Sub

    '列指定のチェックボックスが変化したときのイベントです。
    Private Sub chkCol_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCol.CheckedChanged

        If (chkCol.Checked) Then
            cboColFrom.Enabled = True
            cboColTo.Enabled = True
        Else
            cboColFrom.Enabled = False
            cboColTo.Enabled = False
        End If
    End Sub
  
    ''' <summary>
    ''' 印刷プレビュー表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles BtnPreview.Click

        Call setValue()

        Dim DS As Date = Nothing
        Dim DE As Date = Nothing

        If RadioButton1.Checked Then
            DS = _DS
            DE = _DE
        Else
            Select Case True
                Case IsNothing(TxtStartDay.Value)
                    MsgBox("印刷開始日が設定されていません。", 48, "エラー")
                    Return
                Case IsNothing(TxtEndDay.Value)
                    MsgBox("印刷終了日が設定されていません。", 48, "エラー")
                    Return
            End Select

            DS = TxtStartDay.Value ' _DS
            DE = TxtEndDay.Value '  _DE
        End If

        If DS.ToOADate = 0 OrElse DE.ToOADate = 0 Then
            Return
        End If

        Dim pi As New KnTViewLib.PrintInfo()

        pi.HeaderHeight = 1.5 'Single.Parse(HeaderHeight)   'ヘッダー高
        pi.FooterHeight = 1 'Single.Parse(FooterHeight)   'フッター高

        If Orientation <> -1 Then
            pi.Orientation = CType(Orientation, KnTViewLib.TivPrintOrientation) '用紙方向
        Else
            pi.Orientation = KnTViewLib.TivPrintOrientation.tivDefaultOrientation
        End If
        If (PaperSize <> -1) Then
            pi.PaperSize = CType(PaperSize, KnTViewLib.TivPaperSize)  '用紙サイズ
        Else
            pi.PaperSize = KnTViewLib.TivPaperSize.tivDefaultPaperSize
        End If
        'pi.Orientation = KnTViewLib.TivPrintOrientation.tivPrintLandscape
        'pi.PaperSize = KnTViewLib.TivPaperSize.tivPaperA3
        pi.ChartBorder.Style = KnTViewLib.TivLineStyle.tivLineSolid 'タイムビューの外枠の線種：実線

        ''印刷対象の列指定(From-To)
        If (col) Then
            If ColFrom <> -1 Then
                pi.StartColumn = ColFrom
            End If
            If (ColTo <> -1) Then
                pi.FinishColumn = ColTo
            End If
        End If

        ''特定アイテム（行）で強制改頁
        Dim blnNewPage As Boolean = False
        If Break Then
            If BreakItem <> -1 Then
                _TargetTV.Items.Item(BreakItem).PageBreak = True
                blnNewPage = True
            End If
        End If

        ''文字列の色を白か黒にする
        If Mono Then pi.MonochromeText = True

        '倍率
        pi.Magnification = Convert.ToInt16(Magnification)
        pi.JustClippingToScale = Not ChkJustClippingToScale.Checked

        If Not ChkYohoku.Checked Then
            If Not IsNothing(DS) Then
                '最小日付の１週間前から範囲とする
                pi.StartTime = DateAdd(DateInterval.Day, 0 - _PrintDay, DS)
            End If
            If Not IsNothing(DE) Then
                '最大日付から１週間後を範囲とする
                pi.FinishTime = DateAdd(DateInterval.Day, _PrintDay, DE)
            End If
        Else
            pi.StartTime = DS
            pi.FinishTime = DE
        End If

        pi.Title = _Title


        'プレビュー
        _TargetTV.PrintPreview(CType(pi, KnTViewLib.PrintInfo))

        '強制改頁のリセット
        If (blnNewPage) Then
            For Each itm As KnTViewLib.IItem In _TargetTV.Items
                itm.PageBreak = False
            Next
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TxtStartDay.Enabled = RadioButton2.Checked
        TxtEndDay.Enabled = RadioButton2.Checked
    End Sub
End Class