Imports System
Imports System.Windows.Forms

''' <summary>
''' DataGridViewMaskedTextBoxCellオブジェクトの列を表します。
''' </summary>
''' <remarks></remarks>
Public Class DataGridViewMaskedTextBoxColumn
    Inherits DataGridViewColumn
    ''' <summary>
    ''' 基本クラスのコンストラクタを呼び出す
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New(New DataGridViewMaskedTextBoxCell())
    End Sub

    Private maskValue As String = ""
    ''' <summary>
    ''' MaskedTextBoxのMaskプロパティに適用する値
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Mask() As String
        Get
            Return Me.maskValue
        End Get
        Set(ByVal value As String)
            Me.maskValue = value
        End Set
    End Property

    ''' <summary>
    ''' 新しいプロパティを追加しているため Cloneメソッドをオーバーライドする必要がある
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function Clone() As Object
        Dim col As DataGridViewMaskedTextBoxColumn = _
            DirectCast(MyBase.Clone(), DataGridViewMaskedTextBoxColumn)
        col.Mask = Me.Mask
        Return col
    End Function

    ''' <summary>
    ''' CellTemplateの取得と設定
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            'DataGridViewMaskedTextBoxCellしか
            ' CellTemplateに設定できないようにする
            If Not (TypeOf value Is DataGridViewMaskedTextBoxCell) Then
                Throw New InvalidCastException( _
                    "DataGridViewMaskedTextBoxCellオブジェクトを" & _
                    "指定してください。")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class

''' <summary>
''' MaskedTextBoxで編集できるテキスト情報をDataGridViewコントロールに表示します。
''' </summary>
''' <remarks></remarks>
Public Class DataGridViewMaskedTextBoxCell
    Inherits DataGridViewTextBoxCell

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' 編集コントロールを初期化する
    ''' </summary>
    ''' <param name="rowIndex"></param>
    ''' <param name="initialFormattedValue"></param>
    ''' <param name="dataGridViewCellStyle"></param>
    ''' <remarks>編集コントロールは別のセルや列でも使いまわされるため、初期化の必要がある</remarks>
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
                                        dataGridViewCellStyle)

        '編集コントロールの取得
        Dim maskedBox As DataGridViewMaskedTextBoxEditingControl = _
            TryCast(Me.DataGridView.EditingControl,  _
                DataGridViewMaskedTextBoxEditingControl)
        If maskedBox IsNot Nothing Then
            'Textを設定
            Dim maskedText As String = TryCast(initialFormattedValue, String)
            maskedBox.Text = IIf(maskedText IsNot Nothing, maskedText, "")
            'カスタム列のプロパティを反映させる
            Dim column As DataGridViewMaskedTextBoxColumn = _
                TryCast(Me.OwningColumn, DataGridViewMaskedTextBoxColumn)
            If column IsNot Nothing Then
                maskedBox.Mask = column.Mask
            End If
        End If
    End Sub

    ''' <summary>
    ''' 編集コントロールの型を指定する
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(DataGridViewMaskedTextBoxEditingControl)
        End Get
    End Property
    ''' <summary>
    ''' セルの値のデータ型を指定する　ここでは、Object型とする　基本クラスと同じなので、オーバーライドの必要なし
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property ValueType() As Type
        Get
            Return GetType(Object)
        End Get
    End Property

    ''' <summary>
    ''' 新しいレコード行のセルの既定値を指定する
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            Return MyBase.DefaultNewRowValue
        End Get
    End Property
End Class

''' <summary>
''' DataGridViewMaskedTextBoxCellでホストされる
''' MaskedTextBoxコントロールを表します。
''' </summary>
'''  <remarks></remarks>
Public Class DataGridViewMaskedTextBoxEditingControl
    Inherits MaskedTextBox
    Implements IDataGridViewEditingControl

    '編集コントロールが表示されているDataGridView
    Private dataGridView As DataGridView
    '編集コントロールが表示されている行
    Private rowIndex As Integer
    '編集コントロールの値とセルの値が違うかどうか
    Private valueChanged As Boolean

    'コンストラクタ
    Public Sub New()
        Me.TabStop = False
    End Sub

#Region "IDataGridViewEditingControl メンバ"

    ''' <summary>
    ''' 編集コントロールで変更されたセルの値
    ''' </summary>
    ''' <param name="context"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEditingControlFormattedValue( _
        ByVal context As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Text
    End Function

    ''' <summary>
    ''' 編集コントロールで変更されたセルの値
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.GetEditingControlFormattedValue( _
                DataGridViewDataErrorContexts.Formatting)
        End Get
        Set(ByVal value As Object)
            Me.Text = DirectCast(value, String)
        End Set
    End Property

    ''' <summary>
    ''' セルスタイルを編集コントロールに適用する
    ''' </summary>
    ''' <param name="dataGridViewCellStyle"></param>
    ''' <remarks>編集コントロールの前景色、背景色、フォントなどをセルスタイルに合わせる</remarks>
    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.BackColor = dataGridViewCellStyle.BackColor
        Select Case dataGridViewCellStyle.Alignment
            Case DataGridViewContentAlignment.BottomCenter, _
                DataGridViewContentAlignment.MiddleCenter, _
                DataGridViewContentAlignment.TopCenter

                Me.TextAlign = HorizontalAlignment.Center
                Exit Select
            Case DataGridViewContentAlignment.BottomRight, _
                DataGridViewContentAlignment.MiddleRight, _
                DataGridViewContentAlignment.TopRight

                Me.TextAlign = HorizontalAlignment.Right
                Exit Select
            Case Else
                Me.TextAlign = HorizontalAlignment.Left
                Exit Select
        End Select
    End Sub

    ''' <summary>
    ''' 編集するセルがあるDataGridView
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return Me.dataGridView
        End Get
        Set(ByVal value As DataGridView)
            Me.dataGridView = value
        End Set
    End Property

    ''' <summary>
    '''  編集している行のインデックス
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return Me.rowIndex
        End Get
        Set(ByVal value As Integer)
            Me.rowIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 値が変更されたかどうか
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>編集コントロールの値とセルの値が違うかどうか</remarks>
    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return Me.valueChanged
        End Get
        Set(ByVal value As Boolean)
            Me.valueChanged = value
        End Set
    End Property

    ''' <summary>
    ''' 指定されたキーをDataGridViewが処理するか、編集コントロールが処理するか
    ''' </summary>
    ''' <param name="keyData"></param>
    ''' <param name="dataGridViewWantsInputKey"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Trueを返すと、編集コントロールが処理する
    ''' dataGridViewWantsInputKeyがTrueの時は、DataGridViewが処理できる
    ''' </remarks>
    Public Function EditingControlWantsInputKey(ByVal keyData As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        'Keys.Left、Right、Home、Endの時は、Trueを返す
        'このようにしないと、これらのキーで別のセルにフォーカスが移ってしまう
        Select Case keyData And Keys.KeyCode
            Case Keys.Right, Keys.[End], Keys.Left, Keys.Home
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey
        End Select
    End Function

    ''' <summary>
    ''' マウスカーソルがEditingPanel上にあるときのカーソルを指定する
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>EditingPanelは編集コントロールをホストするパネルで、編集コントロールがセルより小さいとコントロール以外の部分がパネルとなる</remarks>
    Public ReadOnly Property EditingPanelCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get
    End Property

    ''' <summary>
    ''' コントロールで編集する準備をする
    ''' </summary>
    ''' <param name="selectAll"></param>
    ''' <remarks>テキストを選択状態にしたり、挿入ポインタを末尾にしたりする</remarks>
    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        If selectAll Then
            '選択状態にする
            Me.SelectAll()
        Else
            '挿入ポインタを末尾にする
            Me.SelectionStart = Me.TextLength
        End If
    End Sub

    ''' <summary>
    ''' 値が変更した時に、セルの位置を変更するかどうか
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>値が変更された時に編集コントロールの大きさが変更される時はTrue</remarks>
    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean _
        Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get
    End Property

#End Region


    ''' <summary>
    '''  値が変更された時
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        '値が変更されたことをDataGridViewに通知する
        Me.valueChanged = True
        Me.dataGridView.NotifyCurrentCellDirty(True)
    End Sub
End Class

