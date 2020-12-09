''' <summary>
''' ストーンプロパティ
''' </summary>
''' <remarks></remarks>
Public Class FrmStoneProperty
    Dim FC As New ClassFormControl
    Dim _StartDay As Date
    Dim _ImageNo As Integer
    Dim _CaptionLeftText As String
    Dim _CaptionLeftAlignment As ContentAlignment
    Dim _CaptionLeftPosition As Integer = 0

    Dim _CaptionRightText As String
    Dim _CaptionRightAlignment As ContentAlignment
    Dim _CaptionRightPosition As Integer = 0
    Dim _IsSummaryExclusion As Boolean = False
#Region "Property"
    ''' <summary>
    ''' 設置日
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property StartDay() As Date
        Get
            Return _StartDay
        End Get
        Set(value As Date)
            _StartDay = value
            TxtStartDay.Value = value
        End Set
    End Property
    ''' <summary>
    ''' アイコン番号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ImageNo() As Integer
        Get
            Return _ImageNo
        End Get
        Set(ByVal value As Integer)
            _ImageNo = value
        End Set
    End Property
    ''' <summary>
    ''' 左キャプション
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftText() As String
        Get
            Return _CaptionLeftText
        End Get
        Set(ByVal value As String)
            _CaptionLeftText = value
            StonePreview.CaptionLeftText = value
            TxtLeft.Text = Replace(value, vbLf, vbCrLf)
        End Set
    End Property
    ''' <summary>
    ''' 右キャプション
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightText() As String
        Get
            Return _CaptionRightText
        End Get
        Set(ByVal value As String)
            _CaptionRightText = value
            StonePreview.CaptionRightText = ConvCaptionDate(value, Now)
            TxtRight.Text = Replace(value, vbLf, vbCrLf)
        End Set
    End Property
    ''' <summary>
    ''' 左キャプション垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftAlignment() As ContentAlignment
        Get
            Return _CaptionLeftAlignment
        End Get
        Set(ByVal value As ContentAlignment)
            TxtLeft.ContentAlignment = value
            TextAlignment_Left.SelectedAlignment = value
            StonePreview.CaptionLeftHAlign = TextAlignment_Left.GetSetH
            StonePreview.CaptionLeftVAlign = TextAlignment_Left.GetSetV
        End Set
    End Property
    ''' <summary>
    ''' 右キャプション垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightAlignment() As ContentAlignment
        Get
            Return _CaptionRightAlignment
        End Get
        Set(ByVal value As ContentAlignment)
            TxtRight.ContentAlignment = value
            TextAlignment_Right.SelectedAlignment = value
            StonePreview.CaptionRightHAlign = TextAlignment_Right.GetSetH
            StonePreview.CaptionRightVAlign = TextAlignment_Right.GetSetV
        End Set
    End Property
    ''' <summary>
    ''' 左キャプション水平位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionLeftPosition() As Integer
        Get
            Return _CaptionLeftPosition + 1
        End Get
        Set(ByVal value As Integer)
            StonePreview.CaptionLeftPosition = value - 1
            CmbLeftPosition.SelectedIndex = value - 1
        End Set
    End Property
    ''' <summary>
    ''' 右キャプション水平位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CaptionRightPosition() As Integer
        Get
            Return _CaptionRightPosition + 1
        End Get
        Set(ByVal value As Integer)
            StonePreview.CaptionRightPosition = value - 1
            CmbRightPosition.SelectedIndex = value - 1
        End Set
    End Property
    Dim _LockPiece As Integer = 0
    ''' <summary>
    ''' ロックピース設定
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LockPiece As Integer
        Get
            Return _LockPiece
        End Get
        Set(value As Integer)
            _LockPiece = value
        End Set
    End Property
    Property IsSummaryExclusion As Boolean
        Get
            Return _IsSummaryExclusion
        End Get
        Set(value As Boolean)
            _IsSummaryExclusion = value
            ChkSummaryExclusion.Checked = value
        End Set
    End Property

#End Region
    ''' <summary>
    ''' イメージリストの初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddImageListItem()
        Try
            Dim items(IconList.Images.Count - 1) As String
            For i As Int32 = 0 To IconList.Images.Count - 1
                items(i) = "Item " & i.ToString
            Next
            With CmbImage
                .Items.AddRange(items)
                .DropDownStyle = ComboBoxStyle.DropDownList
                .DrawMode = DrawMode.OwnerDrawVariable
                .ItemHeight = IconList.ImageSize.Height
                '.Width = ImageMaster.ImageSize.Width + 28
                .MaxDropDownItems = 20 'ImageMaster.Images.Count
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            Logs.PutErrorEx("ストーンイメージ設定エラー", ex)
        End Try
    End Sub
    ''' <summary>
    ''' フォームの終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmStoneProperty_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームの終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmStoneProperty_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub FrmStoneProperty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FC.TargetForm = Me
        FC.Title = Me.Text

        Call AddImageListItem()
        CmbImage.SelectedIndex = _ImageNo
        If _LockPiece = 0 Then
            OptLock0.Checked = True
        Else
            OptLock2.Checked = True
        End If

        Call FC.ScanTargetControl()
        FC.Edited = False
    End Sub

    Private Sub CmbImage_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles CmbImage.DrawItem
        Try
            If e.Index <> -1 Then
                e.Graphics.DrawImage(IconList.Images(e.Index), e.Bounds.Left, e.Bounds.Top)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbImage_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles CmbImage.MeasureItem
        e.ItemHeight = IconList.ImageSize.Height
        e.ItemWidth = IconList.ImageSize.Width
    End Sub
    ''' <summary>
    ''' OKボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Select Case True
            Case IsNothing(TxtStartDay.Value)
                MsgBox("ストーン設置日が設定されていません", 48, "エラー")
                TxtStartDay.Focus()
                Return
        End Select

        _StartDay = TxtStartDay.Value

        _CaptionLeftText = Replace(TxtLeft.Text, vbCrLf, vbLf)
        _CaptionRightText = Replace(TxtRight.Text, vbCrLf, vbLf)
        _ImageNo = CmbImage.SelectedIndex
        _CaptionLeftAlignment = TxtLeft.ContentAlignment
        _CaptionRightAlignment = TxtRight.ContentAlignment
        _CaptionLeftPosition = CmbLeftPosition.SelectedIndex
        _CaptionRightPosition = CmbRightPosition.SelectedIndex
        _IsSummaryExclusion = ChkSummaryExclusion.Checked
        If OptLock0.Checked Then
            _LockPiece = 0
        Else
            _LockPiece = 2
        End If
        FC.Edited = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
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
    ''' 左文字変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtLeft_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLeft.TextChanged
        StonePreview.CaptionLeftText = TxtLeft.Text
        Call DrawDate()
    End Sub
    ''' <summary>
    ''' 右文字変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtRight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRight.TextChanged
        'StonePreview.CaptionRightText = ConvCaptionDate(TxtRight.Text, Now)
        Call DrawDate()
    End Sub
    ''' <summary>
    ''' 日付の描写
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DrawDate()
        If Not IsNothing(TxtStartDay.Value) Then
            Dim D As Date = CDate(TxtStartDay.Value)
            If Not D.ToOADate = 0 Then
                StonePreview.CaptionRightText = ConvCaptionDate(TxtRight.Text, CDate(TxtStartDay.Value))
            Else
                StonePreview.CaptionRightText = Replace(TxtRight.Text, "<DATE>", "")
            End If
        Else
            StonePreview.CaptionRightText = Replace(TxtRight.Text, "<DATE>", "")
        End If

    End Sub
    ''' <summary>
    ''' 左文字位置変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbLeftPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbLeftPosition.SelectedIndexChanged
        Select Case CmbLeftPosition.SelectedIndex
            Case 0 : StonePreview.CaptionLeftPosition = UserControlStone.enumUCP_Position.Top
            Case 1 : StonePreview.CaptionLeftPosition = UserControlStone.enumUCP_Position.Bottom
            Case 2 : StonePreview.CaptionLeftPosition = UserControlStone.enumUCP_Position.Left
            Case Else : StonePreview.CaptionLeftPosition = UserControlStone.enumUCP_Position.Right
        End Select
    End Sub
    ''' <summary>
    ''' 右文字位置変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbRightPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbRightPosition.SelectedIndexChanged
        Select Case CmbRightPosition.SelectedIndex
            Case 0 : StonePreview.CaptionRightPosition = UserControlStone.enumUCP_Position.Top
            Case 1 : StonePreview.CaptionRightPosition = UserControlStone.enumUCP_Position.Bottom
            Case 2 : StonePreview.CaptionRightPosition = UserControlStone.enumUCP_Position.Left
            Case Else : StonePreview.CaptionRightPosition = UserControlStone.enumUCP_Position.Right
        End Select
    End Sub
    ''' <summary>
    ''' 右文字位置変更
    ''' </summary>
    ''' <param name="SelectdAlignment"></param>
    ''' <param name="HAlign"></param>
    ''' <param name="VAlign"></param>
    ''' <remarks></remarks>
    Private Sub TextAlignment_Right_AlignmentChaned(SelectdAlignment As ContentAlignment, HAlign As Integer, VAlign As Integer) Handles TextAlignment_Right.AlignmentChaned
        TxtRight.ContentAlignment = SelectdAlignment
        StonePreview.CaptionRightHAlign = HAlign
        StonePreview.CaptionRightVAlign = VAlign
    End Sub
    ''' <summary>
    ''' 左文字変更
    ''' </summary>
    ''' <param name="SelectdAlignment"></param>
    ''' <param name="HAlign"></param>
    ''' <param name="VAlign"></param>
    ''' <remarks></remarks>
    Private Sub TextAlignment_Left_AlignmentChaned(SelectdAlignment As ContentAlignment, HAlign As Integer, VAlign As Integer) Handles TextAlignment_Left.AlignmentChaned
        TxtLeft.ContentAlignment = SelectdAlignment
        StonePreview.CaptionLeftHAlign = HAlign
        StonePreview.CaptionLeftVAlign = VAlign
    End Sub
    ''' <summary>
    ''' 日付コマンド挿入
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        TxtRight.Text = TxtRight.Text & LinkLabel1.Tag
    End Sub
    ''' <summary>
    ''' 日付変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtStartDay_ValueChanged(sender As Object, e As EventArgs) Handles TxtStartDay.ValueChanged
        Call DrawDate()
    End Sub
  
End Class