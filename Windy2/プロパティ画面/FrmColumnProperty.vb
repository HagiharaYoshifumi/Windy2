''' <summary>
''' 列プロパティ
''' </summary>
''' <remarks></remarks>
Public Class FrmColumnProperty
    Dim FC As New ClassFormControl
    Dim _CellText As String
    Dim _CellTextAlignment As Integer
    'Dim _CellTextVAlign As Integer
    Dim _BackColor As System.UInt32
    Dim _ForeColor As System.UInt32
    Dim _ColNo As Integer
    Dim _Hidden As Boolean
#Region "Property"
    ''' <summary>
    ''' セル文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CellText() As String
        Get
            Return _CellText
        End Get
        Set(ByVal value As String)

            Edit1.Text = Replace(value, "<CR>", vbCrLf)
        End Set
    End Property
    ''' <summary>
    ''' 背景色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CellBackColor() As System.UInt32
        Get
            Return _BackColor
        End Get
        Set(ByVal value As System.UInt32)
            Try
                Edit1.BackColor = ConvertColorValue(value)
                ColorPicker_Back.SelectedColor = ConvertColorValue(value)
            Catch ex As Exception

            End Try
        End Set
    End Property
    ''' <summary>
    ''' 文字色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CellForeColor() As System.UInt32
        Get
            Return _ForeColor
        End Get
        Set(ByVal value As System.UInt32)
            Try
                Edit1.ForeColor = ConvertColorValue(value)
                ColorPicker_Fore.SelectedColor = ConvertColorValue(value)
            Catch ex As Exception

            End Try
        End Set
    End Property
    ''' <summary>
    ''' 文字配置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CellTextAlign() As ContentAlignment
        Get
            Return _CellTextAlignment
        End Get
        Set(value As ContentAlignment)
            Edit1.ContentAlignment = value
            TextAlignment2.SelectedAlignment = value
        End Set
    End Property
    ''' <summary>
    ''' 列番号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ColNo As Integer
        Get
            Return _ColNo
        End Get
        Set(value As Integer)
            _ColNo = value
        End Set
    End Property
    ''' <summary>
    ''' 表示・非表示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Hidden As Boolean
        Get
            Return _Hidden
        End Get
        Set(value As Boolean)
            _Hidden = value
            ChkHidden.Checked = value
        End Set
    End Property
#End Region
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmEditHeaderCell_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームが閉じられた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmColProperty_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub FrmEditHeaderCell_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FC.TargetForm = Me
        Me.Text = String.Format("{0}({1}列目)", Me.Text, _ColNo)
        FC.Title = Me.Text

        If ColorPicker_Fore.SelectedColor = Color.Empty Then
            ColorPicker_Fore.SelectedColor = ColorPicker_Fore.AutomaticColor
        End If
        If ColorPicker_Back.SelectedColor = Color.Empty Then
            ColorPicker_Back.SelectedColor = ColorPicker_Back.AutomaticColor
        End If

        FC.ScanTargetControl()
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
    ''' ＯＫボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        _CellText = Edit1.Text
        _BackColor = ConvertColorValue(Edit1.BackColor)
        _ForeColor = ConvertColorValue(Edit1.ForeColor)

        _CellTextAlignment = Edit1.ContentAlignment
        _Hidden = ChkHidden.Checked

        FC.Edited = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    ''' <summary>
    ''' 背景色が変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GcColorPicker1_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPicker_Back.SelectedColorChanged
        Edit1.BackColor = ColorPicker_Back.SelectedColor
        ColorPicker_Fore.AutomaticColor = ToBackColor(Edit1.BackColor)
    End Sub
    ''' <summary>
    ''' 文字色が変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GcColorPicker2_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPicker_Fore.SelectedColorChanged
        Edit1.ForeColor = ColorPicker_Fore.SelectedColor
    End Sub
    ''' <summary>
    ''' 文字位置が変更された
    ''' </summary>
    ''' <param name="SelectdAlignment"></param>
    ''' <param name="HAlign"></param>
    ''' <param name="VAlign"></param>
    ''' <remarks></remarks>
    Private Sub TextAlignment_AlignmentChaned(SelectdAlignment As ContentAlignment, HAlign As Integer, VAlign As Integer) Handles TextAlignment2.AlignmentChaned
        Edit1.ContentAlignment = SelectdAlignment
    End Sub
    ''' <summary>
    ''' コマンド１追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        If Edit1.Text = "" Then
            Edit1.Text = "<MINDATE>"
        Else
            Edit1.Text = Edit1.Text & " <MINDATE>"
        End If
    End Sub
    ''' <summary>
    ''' コマンド２追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        If Edit1.Text = "" Then
            Edit1.Text = "<MAXDATE>"
        Else
            Edit1.Text = Edit1.Text & " <MAXDATE>"
        End If
    End Sub
    ''' <summary>
    ''' コマンド３追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        If Edit1.Text = "" Then
            Edit1.Text = "<ROWNO>"
        Else
            Edit1.Text = Edit1.Text & " <ROWNO>"
        End If
    End Sub
End Class