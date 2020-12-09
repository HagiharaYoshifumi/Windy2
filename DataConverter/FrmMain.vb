
Imports System.IO
Public Class FrmMain
    Dim _IsWork As Boolean = False
    Private Sub TxtWindyFile_DragDrop(sender As Object, e As DragEventArgs) Handles TxtWindyFile.DragDrop
        Dim fileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        If fileName.Length > 0 Then
            Dim FL As String = fileName(0)
            If Path.GetExtension(FL).ToUpper = ".WDF" Then
                TxtWindyFile.Text = FL
                TxtXMLFile.Text = String.Format("{0}.xml", FL)
            End If
        End If
    End Sub

    Private Sub TxtWindyFile_DragEnter(sender As Object, e As DragEventArgs) Handles TxtWindyFile.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TxtXMLFile_DragDrop(sender As Object, e As DragEventArgs) Handles TxtXMLFile.DragDrop
        Dim fileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        If fileName.Length > 0 Then
            Dim FL As String = fileName(0)
            If Path.GetExtension(FL).ToUpper = ".XML" Then
                TxtXMLFile.Text = FL
                TxtWindyFile.Text = String.Format("{0}.wdf", FL)
            End If
        End If

    End Sub

    Private Sub TxtXMLFile_DragEnter(sender As Object, e As DragEventArgs) Handles TxtXMLFile.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub MenuAPPEnd_Click(sender As Object, e As EventArgs) Handles MenuAPPEnd.Click
        Application.Exit()
    End Sub

    Private Sub FrmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("データコンバータを終了してもいいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnToXml_Click(sender As Object, e As EventArgs) Handles BtnToXml.Click
        Select Case True
            Case String.IsNullOrWhiteSpace(TxtWindyFile.Text)
                MsgBox("変換するWindyファイルが指定されていません", 48, "エラー")
                Return
            Case String.IsNullOrWhiteSpace(TxtXMLFile.Text)
                MsgBox("変換先のXMLファイルが指定されていません", 48, "エラー")
                Return
            Case (Not File.Exists(TxtWindyFile.Text))
                MsgBox("変換するWindyファイルがありません", 48, "エラー")
                Return

        End Select
        If MsgBox("XMLファイルへ変換を開始してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            If File.Exists(TxtXMLFile.Text) Then
                If MsgBox("XMLファイルを上書きしますか？", 4 + 32, "確認") = MsgBoxResult.No Then
                    Return
                End If
            End If
            If FileDecode(TxtWindyFile.Text, TxtXMLFile.Text) Then
                LblMessage.Text = "XMLファイルへの変換完了"
                MsgBox("XMLファイルへの変換完了", 64, "情報")
            Else
                LblMessage.Text = "XMLファイルへの変換失敗"
                MsgBox("XMLファイルへの変換に失敗しました", 48, "エラー")
            End If
        End If
    End Sub
   
    Private Sub BtnToWindy_Click(sender As Object, e As EventArgs) Handles BtnToWindy.Click
        Select Case True
            Case String.IsNullOrWhiteSpace(TxtWindyFile.Text)
                MsgBox("変換するWindyファイルが指定されていません", 48, "エラー")
                Return
            Case String.IsNullOrWhiteSpace(TxtXMLFile.Text)
                MsgBox("変換先のXMLファイルが指定されていません", 48, "エラー")
                Return
            Case (Not File.Exists(TxtXMLFile.Text))
                MsgBox("変換するWindyファイルがありません", 48, "エラー")
                Return

        End Select
        If MsgBox("Windyファイルへ変換を開始してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            If File.Exists(TxtWindyFile.Text) Then
                If MsgBox("Windyファイルを上書きしますか？", 4 + 32, "確認") = MsgBoxResult.No Then
                    Return
                End If
            End If
            If FileEncode(TxtXMLFile.Text, TxtWindyFile.Text) Then
                LblMessage.Text = "Windyファイルへの変換完了"
                MsgBox("Windyファイルへの変換完了", 64, "情報")
            Else
                LblMessage.Text = "Windyファイルへの変換失敗"
                MsgBox("Windyファイルへの変換に失敗しました", 48, "エラー")
            End If
        End If
    End Sub
End Class
