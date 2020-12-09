Public Class FrmExclusion
    Enum enum_OpenMode As Integer
        ''' <summary>
        ''' 通常で開く
        ''' </summary>
        ''' <remarks></remarks>
        IsOK = 0
        ''' <summary>
        ''' 閲覧モードで開く
        ''' </summary>
        ''' <remarks></remarks>
        IsView = 1
        ''' <summary>
        ''' キャンセル
        ''' </summary>
        ''' <remarks></remarks>
        IsCancel = 2
    End Enum
    Dim _Ret As enum_OpenMode
    Dim _Password As String
    ''' <summary>
    ''' ファイルオープンモード
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property OpenMode As enum_OpenMode
        Get
            Return _Ret
        End Get
    End Property
    ''' <summary>
    ''' 設定されているパスワード
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    WriteOnly Property DefPassword As String
        Set(value As String)
            _Password = value
        End Set
    End Property

    Private Sub FrmExclusion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmExclusion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Select Case True
            Case String.IsNullOrWhiteSpace(TxtPassword.Text)
                MsgBox("開封パスワードが未入力です", 48, "エラー")
                TxtPassword.Focus()
                Logs.PutInformation("開封パスワードが未入力です")
                Return
            Case TxtPassword.Text <> _Password
                MsgBox("開封パスワードが違います", 48, "エラー")
                TxtPassword.Text = ""
                Logs.PutInformation("開封パスワードが違います", TxtPassword.Text)
                TxtPassword.Focus()
                Return
        End Select

        _Ret = enum_OpenMode.IsOK
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub BtnIsView_Click(sender As Object, e As EventArgs) Handles BtnIsView.Click
        If MsgBox("閲覧モードで開いてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            _Ret = enum_OpenMode.IsView
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        If MsgBox("キャンセルしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            _Ret = enum_OpenMode.IsCancel
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class