''' <summary>
''' フォーム内容が変更されたかどうか確認クラス
''' </summary>
''' <remarks></remarks>
Public Class ClassFormControl
    Public Event EditStatusChanged(ByVal Edited As Boolean)
    Dim _TargetFrm As Windows.Forms.Form = Nothing
    Dim _Flg As Boolean = False
    Dim _Title As String = ""
    Dim _Enable As Boolean = True
    ''' <summary>
    ''' 描写ターゲットフォーム
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    WriteOnly Property TargetForm() As Windows.Forms.Form
        Set(ByVal value As Windows.Forms.Form)
            _TargetFrm = value
        End Set
    End Property
    ''' <summary>
    ''' 表示タイトル
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
            Call DrawAster()
        End Set
    End Property
    ''' <summary>
    ''' 変更スイッチ
    ''' </summary>
    ''' <value>TRUE:変更された</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Edited() As Boolean
        Get
            Return _Flg
        End Get
        Set(ByVal value As Boolean)
            _Flg = value
            RaiseEvent EditStatusChanged(value)
            Call DrawAster()
        End Set
    End Property
    ''' <summary>
    ''' このクラスの有効・無効
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Enable As Boolean
        Get
            Return _Enable
        End Get
        Set(value As Boolean)
            _Enable = value
        End Set
    End Property

    ''' <summary>
    ''' 変更されたかどうか確認メソッド
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsEdited() As Boolean
        Return _Flg
    End Function
    ''' <summary>
    ''' 変更をフォームのタイトルに描写する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DrawAster()
        Try
            If _Flg Then
                'If _TargetFrm.Text.IndexOf("*") < 0 Then
                '    _TargetFrm.Text = _Title & "*"
                'End If

                _TargetFrm.Text = _Title & "*"
            Else
                _TargetFrm.Text = _Title
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' フォームの全てのコントロール列挙
    ''' </summary>
    ''' <param name="top"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAllControls(ByVal top As Control) As Control()
        Dim buf As ArrayList = New ArrayList
        For Each c As Control In top.Controls
            buf.Add(c)
            buf.AddRange(GetAllControls(c))
        Next
        Return CType(buf.ToArray(GetType(Control)), Control())
    End Function
    ''' <summary>
    ''' 各コントロールの変更イベントを追加する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ScanTargetControl()

        Dim AllControls As Control() = GetAllControls(_TargetFrm)

        For Each Ctr As Control In AllControls
            Select Case True
                '------------標準コントロール
                Case (TypeOf Ctr Is TextBox) 'テキストボックス
                    Dim Obj As TextBox = CType(Ctr, TextBox)
                    AddHandler Obj.TextChanged, AddressOf _Edited

                Case (TypeOf Ctr Is CheckBox) 'チェックボックス
                    Dim Obj As CheckBox = CType(Ctr, CheckBox)
                    AddHandler Obj.CheckedChanged, AddressOf _Edited

                Case (TypeOf Ctr Is RadioButton) 'ラジオボタン
                    Dim Obj As RadioButton = CType(Ctr, RadioButton)
                    AddHandler Obj.CheckedChanged, AddressOf _Edited

                Case (TypeOf Ctr Is NumericUpDown) 'アップダウン
                    Dim Obj As NumericUpDown = CType(Ctr, NumericUpDown)
                    AddHandler Obj.ValueChanged, AddressOf _Edited

                Case (TypeOf Ctr Is ComboBox) 'コンボボックス
                    Dim Obj As ComboBox = CType(Ctr, ComboBox)
                    AddHandler Obj.SelectedIndexChanged, AddressOf _Edited

                    '------------GrapeCityコントロール

                Case (TypeOf Ctr Is GrapeCity.Win.Editors.GcTextBox) 'エディットボックス
                    Dim Obj As GrapeCity.Win.Editors.GcTextBox = CType(Ctr, GrapeCity.Win.Editors.GcTextBox)
                    AddHandler Obj.TextChanged, AddressOf _Edited

                Case (TypeOf Ctr Is GrapeCity.Win.Editors.GcDate) '日付ボックス
                    Dim Obj As GrapeCity.Win.Editors.GcDate = CType(Ctr, GrapeCity.Win.Editors.GcDate)
                    AddHandler Obj.ValueChanged, AddressOf _Edited

                Case (TypeOf Ctr Is GrapeCity.Win.Editors.GcNumber) '数値ボックス
                    Dim Obj As GrapeCity.Win.Editors.GcNumber = CType(Ctr, GrapeCity.Win.Editors.GcNumber)
                    AddHandler Obj.ValueChanged, AddressOf _Edited

                Case (TypeOf Ctr Is GrapeCity.Win.Pickers.GcColorPicker) 'カラーピッカー
                    Dim Obj As GrapeCity.Win.Pickers.GcColorPicker = CType(Ctr, GrapeCity.Win.Pickers.GcColorPicker)
                    AddHandler Obj.SelectedColorChanged, AddressOf _Edited


                Case (TypeOf Ctr Is Windy2.UserControlTextAlignment) '専用位置設定１
                    Dim Obj As Windy2.UserControlTextAlignment = CType(Ctr, Windy2.UserControlTextAlignment)
                    AddHandler Obj.AlignmentChaned, AddressOf _Edited

                Case (TypeOf Ctr Is Windy2.UserControlTextAlignment2) '専用位置設定２
                    Dim Obj As Windy2.UserControlTextAlignment2 = CType(Ctr, Windy2.UserControlTextAlignment2)
                    AddHandler Obj.AlignmentChaned, AddressOf _Edited

            End Select
        Next

    End Sub

    Private Sub _Edited()
        If _Enable Then
            _Flg = True
            RaiseEvent EditStatusChanged(True)
            Call DrawAster()
        End If
    End Sub
End Class
