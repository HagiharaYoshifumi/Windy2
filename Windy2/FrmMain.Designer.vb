<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.ContextMenuStone = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMS_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_AddBalloon = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_AddRelatedLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_ChagePeace = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_Move = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_MoveToUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_MoveToDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_CopyFormat = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_Property = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_DeleteStone = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuSheetNothing = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMSN_RowAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSN_ItemPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuRelatedLine = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMRL_Change = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_Position = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_Position0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_Position1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_Position2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_Position3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_Position4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_Position5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_LineType = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_LineType1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_LineType2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_LineType3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_LineType4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_LineType5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMRL_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripBalloon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMSB_Style = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSB_Style0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSB_Style1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSB_Style2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSB_Property = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSB_DeleteBalloon = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuPiecePane = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMNO_Paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMNO_Property = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuCellHeader = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMCH_Merge = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMCH_AddCol = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMCH_AddColToLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMCH_AddColToRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMCD_Move = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMCD_MoveToLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMCD_MoveToRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMCH_Property = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMCH_DelCol = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuCell = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMC_Row = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_RowAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_RowAddToUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_RowAddToDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_RowAddToBottom = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_RowMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_RowMoveToUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_RowMoveToDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_RowDel = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_RowHidden = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_Col = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ColAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ColAddToLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ColAddToRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ColAddToEnd = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ColMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ColMoveToLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ColMoveToRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ColDel = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_CopyFromDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_CopyFromUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ItemCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ItemPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ItemPasteToUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ItemPasteToDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_ItemPasteToBottom = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_Move = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMC_CellProperty = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem17 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuPeace = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMP_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMP_AddBalloon = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMP_AddRelatedLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.CTMP_ChangeStone = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMP_Move = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMP_MoveToUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMP_MoveToDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.CTMP_CopyFormat = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMP_Property = New System.Windows.Forms.ToolStripMenuItem()
        Me.CTMP_DeletePeace = New System.Windows.Forms.ToolStripMenuItem()
        Me.RadialMenuItem12 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_Position0 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_Position1 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_Position2 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_Position3 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_Position4 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_Position5 = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuItem5 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMSB_Style0 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMSB_Style1 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMSB_Style2 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowAddToUp = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowAddToDown = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowAddToBottom = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ColAddToLeft = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ColAddToRight = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ColAddToEnd = New C1.Win.C1Command.RadialMenuItem()
        Me.RMP_Copy = New C1.Win.C1Command.RadialMenuItem()
        Me.RMP_AddBalloon = New C1.Win.C1Command.RadialMenuItem()
        Me.RMP_AddRelatedLine = New C1.Win.C1Command.RadialMenuItem()
        Me.RTMP_ChangeStone = New C1.Win.C1Command.RadialMenuItem()
        Me.RMP_Move = New C1.Win.C1Command.RadialMenuItem()
        Me.RMP_MoveToUp = New C1.Win.C1Command.RadialMenuItem()
        Me.RMP_MoveToDown = New C1.Win.C1Command.RadialMenuItem()
        Me.RMP_PeaceSwap = New C1.Win.C1Command.RadialMenuItem()
        Me.RTMP_CopyFormat = New C1.Win.C1Command.RadialMenuItem()
        Me.RTMP_CopyFormat_Copy = New C1.Win.C1Command.RadialMenuItem()
        Me.RTMP_CopyFormat_Master = New C1.Win.C1Command.RadialMenuItem()
        Me.RTMP_CopyFormat_Template = New C1.Win.C1Command.RadialMenuItem()
        Me.RMP_Property = New C1.Win.C1Command.RadialMenuItem()
        Me.RTMP_DeletePeace = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuItem9 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMS_Copy = New C1.Win.C1Command.RadialMenuItem()
        Me.RMS_AddBalloon = New C1.Win.C1Command.RadialMenuItem()
        Me.RMS_AddRelatedLine = New C1.Win.C1Command.RadialMenuItem()
        Me.RMS_ChagePeace = New C1.Win.C1Command.RadialMenuItem()
        Me.RMS_Move = New C1.Win.C1Command.RadialMenuItem()
        Me.RMS_MoveToUp = New C1.Win.C1Command.RadialMenuItem()
        Me.RMS_MoveToDown = New C1.Win.C1Command.RadialMenuItem()
        Me.RMS_StoneSwap = New C1.Win.C1Command.RadialMenuItem()
        Me.RMS_CopyFormat = New C1.Win.C1Command.RadialMenuItem()
        Me.RMS_Property = New C1.Win.C1Command.RadialMenuItem()
        Me.RMS_DeleteStone = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_Change = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_Position = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_LineType = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_LineType1 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_LineType2 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_LineType3 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_LineType4 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_LineType5 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMRL_Delete = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuStripBalloon = New C1.Win.C1Command.C1RadialMenu()
        Me.RMSB_Style = New C1.Win.C1Command.RadialMenuItem()
        Me.RMSB_Property = New C1.Win.C1Command.RadialMenuItem()
        Me.RMSB_DeleteBalloon = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuItem13 = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuCellHeader = New C1.Win.C1Command.C1RadialMenu()
        Me.RMCH_Merge = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_AddCol = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_AddColToLeft = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_AddColToRight = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCD_Move = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCD_MoveToLeft = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCD_MoveToRight = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_Sort = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_SortAscending = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_SortDescending = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_SortManual = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_AutoNumber = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_Property = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_PropertyHeader = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_PropertyCol = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_HiddenCol = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_HiddenCol_AllCol = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_HiddenCol_SelCol = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_HiddenCol_AllView = New C1.Win.C1Command.RadialMenuItem()
        Me.RMCH_DelCol = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuItem16 = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuRelatedLine = New C1.Win.C1Command.C1RadialMenu()
        Me.RadialMenuItem8 = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuStone = New C1.Win.C1Command.C1RadialMenu()
        Me.RadialMenuItem1 = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuSheetNothing = New C1.Win.C1Command.C1RadialMenu()
        Me.RMSN_RowAdd = New C1.Win.C1Command.RadialMenuItem()
        Me.RMSN_ItemPaste = New C1.Win.C1Command.RadialMenuItem()
        Me.RMSN_MoveToday = New C1.Win.C1Command.RadialMenuItem()
        Me.RMSN_SpecialTimeSetting = New C1.Win.C1Command.RadialMenuItem()
        Me.RMSN_SheetProperty = New C1.Win.C1Command.RadialMenuItem()
        Me.RMSN_F11 = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuItem4 = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuCell = New C1.Win.C1Command.C1RadialMenu()
        Me.RMC_Row = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowAdd = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowMove = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowMoveToUp = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowMoveToDown = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowCopy = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowColor = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowHidden = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowHidden_One = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowHidden_Tree = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowDel = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_RowPeceClear = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_Col = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ColAdd = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ColMove = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ColMoveToLeft = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ColMoveToRight = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ColHidden = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ColDel = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_Cell = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_CellCopy = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_CellPaste1 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_CellPaste2 = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_CellAllCopy = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_CopyFromDown = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_CopyFromUp = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ItemCopy = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ItemPaste = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ItemPasteToUp = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ItemPasteToDown = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_ItemPasteToBottom = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_Move = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_MoveTop = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_MoveLast = New C1.Win.C1Command.RadialMenuItem()
        Me.RMC_CellProperty = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuItem15 = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuPeace = New C1.Win.C1Command.C1RadialMenu()
        Me.RadialMenuItem2 = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuPiecePane = New C1.Win.C1Command.C1RadialMenu()
        Me.RMNO_Paste = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_Property = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_MoveToday = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_RowColor = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_SpecialTimeSetting = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_DataExport = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_DataExport_Grid = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_DataExport_XML = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_Import = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_Import_CSV = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_Import_Clip = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_Import_Merge = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_Seek = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_Hidden = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_HiddenRow = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_HiddenCol = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_Hidden_Hidden = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_Hidden_View = New C1.Win.C1Command.RadialMenuItem()
        Me.RMNO_F11 = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuItem7 = New C1.Win.C1Command.RadialMenuItem()
        Me.TView = New AxKnTViewLib.AxKnTView()
        Me.ContextMenuStone.SuspendLayout()
        Me.ContextMenuSheetNothing.SuspendLayout()
        Me.ContextMenuRelatedLine.SuspendLayout()
        Me.ContextMenuStripBalloon.SuspendLayout()
        Me.ContextMenuPiecePane.SuspendLayout()
        Me.ContextMenuCellHeader.SuspendLayout()
        Me.ContextMenuCell.SuspendLayout()
        Me.ContextMenuPeace.SuspendLayout()
        CType(Me.TView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStone
        '
        Me.ContextMenuStone.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMS_Copy, Me.CMS_AddBalloon, Me.CMS_AddRelatedLine, Me.CMS_ChagePeace, Me.CMS_Move, Me.CMS_CopyFormat, Me.CMS_Property, Me.CMS_DeleteStone})
        Me.ContextMenuStone.Name = "ContextMenuStone"
        Me.ContextMenuStone.Size = New System.Drawing.Size(185, 180)
        '
        'CMS_Copy
        '
        Me.CMS_Copy.Name = "CMS_Copy"
        Me.CMS_Copy.Size = New System.Drawing.Size(184, 22)
        Me.CMS_Copy.Text = "選択ストーンコピー"
        '
        'CMS_AddBalloon
        '
        Me.CMS_AddBalloon.Name = "CMS_AddBalloon"
        Me.CMS_AddBalloon.Size = New System.Drawing.Size(184, 22)
        Me.CMS_AddBalloon.Text = "バルーンの追加"
        '
        'CMS_AddRelatedLine
        '
        Me.CMS_AddRelatedLine.Name = "CMS_AddRelatedLine"
        Me.CMS_AddRelatedLine.Size = New System.Drawing.Size(184, 22)
        Me.CMS_AddRelatedLine.Text = "接続線追加"
        '
        'CMS_ChagePeace
        '
        Me.CMS_ChagePeace.Name = "CMS_ChagePeace"
        Me.CMS_ChagePeace.Size = New System.Drawing.Size(184, 22)
        Me.CMS_ChagePeace.Text = "ピースへ変換"
        '
        'CMS_Move
        '
        Me.CMS_Move.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMS_MoveToUp, Me.CMS_MoveToDown})
        Me.CMS_Move.Name = "CMS_Move"
        Me.CMS_Move.Size = New System.Drawing.Size(184, 22)
        Me.CMS_Move.Text = "ストーンの移動"
        '
        'CMS_MoveToUp
        '
        Me.CMS_MoveToUp.Name = "CMS_MoveToUp"
        Me.CMS_MoveToUp.Size = New System.Drawing.Size(124, 22)
        Me.CMS_MoveToUp.Text = "上へ移動"
        '
        'CMS_MoveToDown
        '
        Me.CMS_MoveToDown.Name = "CMS_MoveToDown"
        Me.CMS_MoveToDown.Size = New System.Drawing.Size(124, 22)
        Me.CMS_MoveToDown.Text = "下へ移動"
        '
        'CMS_CopyFormat
        '
        Me.CMS_CopyFormat.Name = "CMS_CopyFormat"
        Me.CMS_CopyFormat.Size = New System.Drawing.Size(184, 22)
        Me.CMS_CopyFormat.Text = "書式適用"
        '
        'CMS_Property
        '
        Me.CMS_Property.Name = "CMS_Property"
        Me.CMS_Property.Size = New System.Drawing.Size(184, 22)
        Me.CMS_Property.Text = "プロパティ"
        '
        'CMS_DeleteStone
        '
        Me.CMS_DeleteStone.Name = "CMS_DeleteStone"
        Me.CMS_DeleteStone.Size = New System.Drawing.Size(184, 22)
        Me.CMS_DeleteStone.Text = "選択ストーン削除"
        '
        'ContextMenuSheetNothing
        '
        Me.ContextMenuSheetNothing.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMSN_RowAdd, Me.CMSN_ItemPaste})
        Me.ContextMenuSheetNothing.Name = "ContextMenuStrip1"
        Me.ContextMenuSheetNothing.Size = New System.Drawing.Size(137, 48)
        '
        'CMSN_RowAdd
        '
        Me.CMSN_RowAdd.Name = "CMSN_RowAdd"
        Me.CMSN_RowAdd.Size = New System.Drawing.Size(136, 22)
        Me.CMSN_RowAdd.Text = "行追加"
        '
        'CMSN_ItemPaste
        '
        Me.CMSN_ItemPaste.Name = "CMSN_ItemPaste"
        Me.CMSN_ItemPaste.Size = New System.Drawing.Size(136, 22)
        Me.CMSN_ItemPaste.Text = "行貼り付け"
        '
        'ContextMenuRelatedLine
        '
        Me.ContextMenuRelatedLine.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMRL_Change, Me.CMRL_Position, Me.CMRL_LineType, Me.CMRL_Delete, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6})
        Me.ContextMenuRelatedLine.Name = "ContextMenuStrip1"
        Me.ContextMenuRelatedLine.Size = New System.Drawing.Size(196, 136)
        '
        'CMRL_Change
        '
        Me.CMRL_Change.Name = "CMRL_Change"
        Me.CMRL_Change.Size = New System.Drawing.Size(195, 22)
        Me.CMRL_Change.Text = "反転"
        '
        'CMRL_Position
        '
        Me.CMRL_Position.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMRL_Position0, Me.CMRL_Position1, Me.CMRL_Position2, Me.CMRL_Position3, Me.CMRL_Position4, Me.CMRL_Position5})
        Me.CMRL_Position.Name = "CMRL_Position"
        Me.CMRL_Position.Size = New System.Drawing.Size(195, 22)
        Me.CMRL_Position.Text = "接続位置変更"
        '
        'CMRL_Position0
        '
        Me.CMRL_Position0.Name = "CMRL_Position0"
        Me.CMRL_Position0.Size = New System.Drawing.Size(148, 22)
        Me.CMRL_Position0.Tag = "0"
        Me.CMRL_Position0.Text = "先折れ"
        '
        'CMRL_Position1
        '
        Me.CMRL_Position1.Name = "CMRL_Position1"
        Me.CMRL_Position1.Size = New System.Drawing.Size(148, 22)
        Me.CMRL_Position1.Tag = "1"
        Me.CMRL_Position1.Text = "通常"
        '
        'CMRL_Position2
        '
        Me.CMRL_Position2.Name = "CMRL_Position2"
        Me.CMRL_Position2.Size = New System.Drawing.Size(148, 22)
        Me.CMRL_Position2.Tag = "2"
        Me.CMRL_Position2.Text = "直接"
        '
        'CMRL_Position3
        '
        Me.CMRL_Position3.Name = "CMRL_Position3"
        Me.CMRL_Position3.Size = New System.Drawing.Size(148, 22)
        Me.CMRL_Position3.Tag = "3"
        Me.CMRL_Position3.Text = "下から下"
        '
        'CMRL_Position4
        '
        Me.CMRL_Position4.Name = "CMRL_Position4"
        Me.CMRL_Position4.Size = New System.Drawing.Size(148, 22)
        Me.CMRL_Position4.Tag = "4"
        Me.CMRL_Position4.Text = "後折れ"
        '
        'CMRL_Position5
        '
        Me.CMRL_Position5.Name = "CMRL_Position5"
        Me.CMRL_Position5.Size = New System.Drawing.Size(148, 22)
        Me.CMRL_Position5.Tag = "5"
        Me.CMRL_Position5.Text = "下から先折れ"
        '
        'CMRL_LineType
        '
        Me.CMRL_LineType.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMRL_LineType1, Me.CMRL_LineType2, Me.CMRL_LineType3, Me.CMRL_LineType4, Me.CMRL_LineType5})
        Me.CMRL_LineType.Name = "CMRL_LineType"
        Me.CMRL_LineType.Size = New System.Drawing.Size(195, 22)
        Me.CMRL_LineType.Text = "関係線線種"
        '
        'CMRL_LineType1
        '
        Me.CMRL_LineType1.Name = "CMRL_LineType1"
        Me.CMRL_LineType1.Size = New System.Drawing.Size(124, 22)
        Me.CMRL_LineType1.Tag = "1"
        Me.CMRL_LineType1.Text = "実線"
        '
        'CMRL_LineType2
        '
        Me.CMRL_LineType2.Name = "CMRL_LineType2"
        Me.CMRL_LineType2.Size = New System.Drawing.Size(124, 22)
        Me.CMRL_LineType2.Tag = "2"
        Me.CMRL_LineType2.Text = "点線"
        '
        'CMRL_LineType3
        '
        Me.CMRL_LineType3.Name = "CMRL_LineType3"
        Me.CMRL_LineType3.Size = New System.Drawing.Size(124, 22)
        Me.CMRL_LineType3.Tag = "3"
        Me.CMRL_LineType3.Text = "破線"
        '
        'CMRL_LineType4
        '
        Me.CMRL_LineType4.Name = "CMRL_LineType4"
        Me.CMRL_LineType4.Size = New System.Drawing.Size(124, 22)
        Me.CMRL_LineType4.Tag = "4"
        Me.CMRL_LineType4.Text = "一点鎖線"
        '
        'CMRL_LineType5
        '
        Me.CMRL_LineType5.Name = "CMRL_LineType5"
        Me.CMRL_LineType5.Size = New System.Drawing.Size(124, 22)
        Me.CMRL_LineType5.Tag = "5"
        Me.CMRL_LineType5.Text = "二点鎖線"
        '
        'CMRL_Delete
        '
        Me.CMRL_Delete.Name = "CMRL_Delete"
        Me.CMRL_Delete.Size = New System.Drawing.Size(195, 22)
        Me.CMRL_Delete.Text = "選択関係線削除"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(195, 22)
        Me.ToolStripMenuItem5.Text = "ToolStripMenuItem5"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(195, 22)
        Me.ToolStripMenuItem6.Text = "ToolStripMenuItem6"
        '
        'ContextMenuStripBalloon
        '
        Me.ContextMenuStripBalloon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMSB_Style, Me.CMSB_Property, Me.CMSB_DeleteBalloon})
        Me.ContextMenuStripBalloon.Name = "ContextMenuStrip1"
        Me.ContextMenuStripBalloon.Size = New System.Drawing.Size(149, 70)
        '
        'CMSB_Style
        '
        Me.CMSB_Style.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMSB_Style0, Me.CMSB_Style1, Me.CMSB_Style2})
        Me.CMSB_Style.Name = "CMSB_Style"
        Me.CMSB_Style.Size = New System.Drawing.Size(148, 22)
        Me.CMSB_Style.Text = "バルーン形状"
        '
        'CMSB_Style0
        '
        Me.CMSB_Style0.Name = "CMSB_Style0"
        Me.CMSB_Style0.Size = New System.Drawing.Size(124, 22)
        Me.CMSB_Style0.Text = "枠なし"
        '
        'CMSB_Style1
        '
        Me.CMSB_Style1.Name = "CMSB_Style1"
        Me.CMSB_Style1.Size = New System.Drawing.Size(124, 22)
        Me.CMSB_Style1.Text = "矩形"
        '
        'CMSB_Style2
        '
        Me.CMSB_Style2.Name = "CMSB_Style2"
        Me.CMSB_Style2.Size = New System.Drawing.Size(124, 22)
        Me.CMSB_Style2.Text = "角丸矩形"
        '
        'CMSB_Property
        '
        Me.CMSB_Property.Name = "CMSB_Property"
        Me.CMSB_Property.Size = New System.Drawing.Size(148, 22)
        Me.CMSB_Property.Text = "プロパティ"
        '
        'CMSB_DeleteBalloon
        '
        Me.CMSB_DeleteBalloon.Name = "CMSB_DeleteBalloon"
        Me.CMSB_DeleteBalloon.Size = New System.Drawing.Size(148, 22)
        Me.CMSB_DeleteBalloon.Text = "バルーン削除"
        '
        'ContextMenuPiecePane
        '
        Me.ContextMenuPiecePane.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMNO_Paste, Me.CMNO_Property, Me.ToolStripMenuItem3})
        Me.ContextMenuPiecePane.Name = "ContextMenuStrip1"
        Me.ContextMenuPiecePane.Size = New System.Drawing.Size(196, 70)
        '
        'CMNO_Paste
        '
        Me.CMNO_Paste.Name = "CMNO_Paste"
        Me.CMNO_Paste.Size = New System.Drawing.Size(195, 22)
        Me.CMNO_Paste.Text = "貼り付け"
        '
        'CMNO_Property
        '
        Me.CMNO_Property.Name = "CMNO_Property"
        Me.CMNO_Property.Size = New System.Drawing.Size(195, 22)
        Me.CMNO_Property.Text = "シートプロパティ"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(195, 22)
        Me.ToolStripMenuItem3.Text = "ToolStripMenuItem3"
        '
        'ContextMenuCellHeader
        '
        Me.ContextMenuCellHeader.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMCH_Merge, Me.CMCH_AddCol, Me.CMCD_Move, Me.CMCH_Property, Me.CMCH_DelCol, Me.ToolStripMenuItem14})
        Me.ContextMenuCellHeader.Name = "ContextMenuStrip1"
        Me.ContextMenuCellHeader.Size = New System.Drawing.Size(233, 136)
        '
        'CMCH_Merge
        '
        Me.CMCH_Merge.Name = "CMCH_Merge"
        Me.CMCH_Merge.Size = New System.Drawing.Size(232, 22)
        Me.CMCH_Merge.Text = "セル結合する"
        '
        'CMCH_AddCol
        '
        Me.CMCH_AddCol.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMCH_AddColToLeft, Me.CMCH_AddColToRight})
        Me.CMCH_AddCol.Name = "CMCH_AddCol"
        Me.CMCH_AddCol.Size = New System.Drawing.Size(232, 22)
        Me.CMCH_AddCol.Text = "列追加"
        '
        'CMCH_AddColToLeft
        '
        Me.CMCH_AddColToLeft.Name = "CMCH_AddColToLeft"
        Me.CMCH_AddColToLeft.Size = New System.Drawing.Size(124, 22)
        Me.CMCH_AddColToLeft.Text = "左へ追加"
        '
        'CMCH_AddColToRight
        '
        Me.CMCH_AddColToRight.Name = "CMCH_AddColToRight"
        Me.CMCH_AddColToRight.Size = New System.Drawing.Size(124, 22)
        Me.CMCH_AddColToRight.Text = "右へ追加"
        '
        'CMCD_Move
        '
        Me.CMCD_Move.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMCD_MoveToLeft, Me.CMCD_MoveToRight})
        Me.CMCD_Move.Name = "CMCD_Move"
        Me.CMCD_Move.Size = New System.Drawing.Size(232, 22)
        Me.CMCD_Move.Text = "移動"
        '
        'CMCD_MoveToLeft
        '
        Me.CMCD_MoveToLeft.Name = "CMCD_MoveToLeft"
        Me.CMCD_MoveToLeft.Size = New System.Drawing.Size(124, 22)
        Me.CMCD_MoveToLeft.Text = "左へ移動"
        '
        'CMCD_MoveToRight
        '
        Me.CMCD_MoveToRight.Name = "CMCD_MoveToRight"
        Me.CMCD_MoveToRight.Size = New System.Drawing.Size(124, 22)
        Me.CMCD_MoveToRight.Text = "右へ移動"
        '
        'CMCH_Property
        '
        Me.CMCH_Property.Name = "CMCH_Property"
        Me.CMCH_Property.Size = New System.Drawing.Size(232, 22)
        Me.CMCH_Property.Text = "ヘッダータイトルプロパティ"
        '
        'CMCH_DelCol
        '
        Me.CMCH_DelCol.Name = "CMCH_DelCol"
        Me.CMCH_DelCol.Size = New System.Drawing.Size(232, 22)
        Me.CMCH_DelCol.Text = "選択列削除"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuItem14.Text = "ToolStripMenuItem14"
        '
        'ContextMenuCell
        '
        Me.ContextMenuCell.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMC_Row, Me.CMC_Col, Me.CMC_CopyFromDown, Me.CMC_CopyFromUp, Me.CMC_ItemCopy, Me.CMC_ItemPaste, Me.CMC_Move, Me.CMC_CellProperty, Me.ToolStripMenuItem17})
        Me.ContextMenuCell.Name = "ContextMenuStrip1"
        Me.ContextMenuCell.Size = New System.Drawing.Size(203, 202)
        '
        'CMC_Row
        '
        Me.CMC_Row.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMC_RowAdd, Me.CMC_RowMove, Me.CMC_RowDel, Me.CMC_RowHidden})
        Me.CMC_Row.Name = "CMC_Row"
        Me.CMC_Row.Size = New System.Drawing.Size(202, 22)
        Me.CMC_Row.Text = "行操作"
        '
        'CMC_RowAdd
        '
        Me.CMC_RowAdd.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMC_RowAddToUp, Me.CMC_RowAddToDown, Me.CMC_RowAddToBottom})
        Me.CMC_RowAdd.Name = "CMC_RowAdd"
        Me.CMC_RowAdd.Size = New System.Drawing.Size(136, 22)
        Me.CMC_RowAdd.Text = "追加"
        '
        'CMC_RowAddToUp
        '
        Me.CMC_RowAddToUp.Name = "CMC_RowAddToUp"
        Me.CMC_RowAddToUp.Size = New System.Drawing.Size(148, 22)
        Me.CMC_RowAddToUp.Text = "上に追加"
        '
        'CMC_RowAddToDown
        '
        Me.CMC_RowAddToDown.Name = "CMC_RowAddToDown"
        Me.CMC_RowAddToDown.Size = New System.Drawing.Size(148, 22)
        Me.CMC_RowAddToDown.Text = "下に追加"
        '
        'CMC_RowAddToBottom
        '
        Me.CMC_RowAddToBottom.Name = "CMC_RowAddToBottom"
        Me.CMC_RowAddToBottom.Size = New System.Drawing.Size(148, 22)
        Me.CMC_RowAddToBottom.Text = "最下段に追加"
        '
        'CMC_RowMove
        '
        Me.CMC_RowMove.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMC_RowMoveToUp, Me.CMC_RowMoveToDown})
        Me.CMC_RowMove.Name = "CMC_RowMove"
        Me.CMC_RowMove.Size = New System.Drawing.Size(136, 22)
        Me.CMC_RowMove.Text = "移動"
        '
        'CMC_RowMoveToUp
        '
        Me.CMC_RowMoveToUp.Name = "CMC_RowMoveToUp"
        Me.CMC_RowMoveToUp.Size = New System.Drawing.Size(124, 22)
        Me.CMC_RowMoveToUp.Text = "上に移動"
        '
        'CMC_RowMoveToDown
        '
        Me.CMC_RowMoveToDown.Name = "CMC_RowMoveToDown"
        Me.CMC_RowMoveToDown.Size = New System.Drawing.Size(124, 22)
        Me.CMC_RowMoveToDown.Text = "下に移動"
        '
        'CMC_RowDel
        '
        Me.CMC_RowDel.Name = "CMC_RowDel"
        Me.CMC_RowDel.Size = New System.Drawing.Size(136, 22)
        Me.CMC_RowDel.Text = "削除"
        '
        'CMC_RowHidden
        '
        Me.CMC_RowHidden.Name = "CMC_RowHidden"
        Me.CMC_RowHidden.Size = New System.Drawing.Size(136, 22)
        Me.CMC_RowHidden.Text = "非表示設定"
        '
        'CMC_Col
        '
        Me.CMC_Col.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMC_ColAdd, Me.CMC_ColMove, Me.CMC_ColDel})
        Me.CMC_Col.Name = "CMC_Col"
        Me.CMC_Col.Size = New System.Drawing.Size(202, 22)
        Me.CMC_Col.Text = "列操作"
        '
        'CMC_ColAdd
        '
        Me.CMC_ColAdd.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMC_ColAddToLeft, Me.CMC_ColAddToRight, Me.CMC_ColAddToEnd})
        Me.CMC_ColAdd.Name = "CMC_ColAdd"
        Me.CMC_ColAdd.Size = New System.Drawing.Size(100, 22)
        Me.CMC_ColAdd.Text = "追加"
        '
        'CMC_ColAddToLeft
        '
        Me.CMC_ColAddToLeft.Name = "CMC_ColAddToLeft"
        Me.CMC_ColAddToLeft.Size = New System.Drawing.Size(136, 22)
        Me.CMC_ColAddToLeft.Text = "左に追加"
        '
        'CMC_ColAddToRight
        '
        Me.CMC_ColAddToRight.Name = "CMC_ColAddToRight"
        Me.CMC_ColAddToRight.Size = New System.Drawing.Size(136, 22)
        Me.CMC_ColAddToRight.Text = "右に追加"
        '
        'CMC_ColAddToEnd
        '
        Me.CMC_ColAddToEnd.Name = "CMC_ColAddToEnd"
        Me.CMC_ColAddToEnd.Size = New System.Drawing.Size(136, 22)
        Me.CMC_ColAddToEnd.Text = "最右に追加"
        '
        'CMC_ColMove
        '
        Me.CMC_ColMove.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMC_ColMoveToLeft, Me.CMC_ColMoveToRight})
        Me.CMC_ColMove.Name = "CMC_ColMove"
        Me.CMC_ColMove.Size = New System.Drawing.Size(100, 22)
        Me.CMC_ColMove.Text = "移動"
        '
        'CMC_ColMoveToLeft
        '
        Me.CMC_ColMoveToLeft.Name = "CMC_ColMoveToLeft"
        Me.CMC_ColMoveToLeft.Size = New System.Drawing.Size(124, 22)
        Me.CMC_ColMoveToLeft.Text = "左へ移動"
        '
        'CMC_ColMoveToRight
        '
        Me.CMC_ColMoveToRight.Name = "CMC_ColMoveToRight"
        Me.CMC_ColMoveToRight.Size = New System.Drawing.Size(124, 22)
        Me.CMC_ColMoveToRight.Text = "右へ移動"
        '
        'CMC_ColDel
        '
        Me.CMC_ColDel.Name = "CMC_ColDel"
        Me.CMC_ColDel.Size = New System.Drawing.Size(100, 22)
        Me.CMC_ColDel.Text = "削除"
        '
        'CMC_CopyFromDown
        '
        Me.CMC_CopyFromDown.Name = "CMC_CopyFromDown"
        Me.CMC_CopyFromDown.Size = New System.Drawing.Size(202, 22)
        Me.CMC_CopyFromDown.Text = "下セル内容コピー"
        '
        'CMC_CopyFromUp
        '
        Me.CMC_CopyFromUp.Name = "CMC_CopyFromUp"
        Me.CMC_CopyFromUp.Size = New System.Drawing.Size(202, 22)
        Me.CMC_CopyFromUp.Text = "上セル内容コピー"
        '
        'CMC_ItemCopy
        '
        Me.CMC_ItemCopy.Name = "CMC_ItemCopy"
        Me.CMC_ItemCopy.Size = New System.Drawing.Size(202, 22)
        Me.CMC_ItemCopy.Text = "選択行コピー"
        '
        'CMC_ItemPaste
        '
        Me.CMC_ItemPaste.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMC_ItemPasteToUp, Me.CMC_ItemPasteToDown, Me.CMC_ItemPasteToBottom})
        Me.CMC_ItemPaste.Name = "CMC_ItemPaste"
        Me.CMC_ItemPaste.Size = New System.Drawing.Size(202, 22)
        Me.CMC_ItemPaste.Text = "行貼り付け"
        '
        'CMC_ItemPasteToUp
        '
        Me.CMC_ItemPasteToUp.Name = "CMC_ItemPasteToUp"
        Me.CMC_ItemPasteToUp.Size = New System.Drawing.Size(172, 22)
        Me.CMC_ItemPasteToUp.Text = "上へ貼り付け"
        '
        'CMC_ItemPasteToDown
        '
        Me.CMC_ItemPasteToDown.Name = "CMC_ItemPasteToDown"
        Me.CMC_ItemPasteToDown.Size = New System.Drawing.Size(172, 22)
        Me.CMC_ItemPasteToDown.Text = "下へ貼り付け"
        '
        'CMC_ItemPasteToBottom
        '
        Me.CMC_ItemPasteToBottom.Name = "CMC_ItemPasteToBottom"
        Me.CMC_ItemPasteToBottom.Size = New System.Drawing.Size(172, 22)
        Me.CMC_ItemPasteToBottom.Text = "最下段へ貼り付け"
        '
        'CMC_Move
        '
        Me.CMC_Move.Name = "CMC_Move"
        Me.CMC_Move.Size = New System.Drawing.Size(202, 22)
        Me.CMC_Move.Text = "ToolStripMenuItem1"
        '
        'CMC_CellProperty
        '
        Me.CMC_CellProperty.Name = "CMC_CellProperty"
        Me.CMC_CellProperty.Size = New System.Drawing.Size(202, 22)
        Me.CMC_CellProperty.Text = "プロパティ"
        '
        'ToolStripMenuItem17
        '
        Me.ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        Me.ToolStripMenuItem17.Size = New System.Drawing.Size(202, 22)
        Me.ToolStripMenuItem17.Text = "ToolStripMenuItem17"
        '
        'ContextMenuPeace
        '
        Me.ContextMenuPeace.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMP_Copy, Me.CMP_AddBalloon, Me.CMP_AddRelatedLine, Me.CTMP_ChangeStone, Me.CMP_Move, Me.CTMP_CopyFormat, Me.CMP_Property, Me.CTMP_DeletePeace})
        Me.ContextMenuPeace.Name = "ContextMenuStrip1"
        Me.ContextMenuPeace.Size = New System.Drawing.Size(197, 180)
        '
        'CMP_Copy
        '
        Me.CMP_Copy.Name = "CMP_Copy"
        Me.CMP_Copy.Size = New System.Drawing.Size(196, 22)
        Me.CMP_Copy.Text = "選択ピースコピー"
        '
        'CMP_AddBalloon
        '
        Me.CMP_AddBalloon.Name = "CMP_AddBalloon"
        Me.CMP_AddBalloon.Size = New System.Drawing.Size(196, 22)
        Me.CMP_AddBalloon.Text = "バルーンの追加"
        '
        'CMP_AddRelatedLine
        '
        Me.CMP_AddRelatedLine.Name = "CMP_AddRelatedLine"
        Me.CMP_AddRelatedLine.Size = New System.Drawing.Size(196, 22)
        Me.CMP_AddRelatedLine.Text = "接続線追加"
        '
        'CTMP_ChangeStone
        '
        Me.CTMP_ChangeStone.Name = "CTMP_ChangeStone"
        Me.CTMP_ChangeStone.Size = New System.Drawing.Size(196, 22)
        Me.CTMP_ChangeStone.Text = "マイルストーンへ変換"
        '
        'CMP_Move
        '
        Me.CMP_Move.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMP_MoveToUp, Me.CMP_MoveToDown})
        Me.CMP_Move.Name = "CMP_Move"
        Me.CMP_Move.Size = New System.Drawing.Size(196, 22)
        Me.CMP_Move.Text = "ピース移動"
        '
        'CMP_MoveToUp
        '
        Me.CMP_MoveToUp.Name = "CMP_MoveToUp"
        Me.CMP_MoveToUp.Size = New System.Drawing.Size(124, 22)
        Me.CMP_MoveToUp.Text = "上へ移動"
        '
        'CMP_MoveToDown
        '
        Me.CMP_MoveToDown.Name = "CMP_MoveToDown"
        Me.CMP_MoveToDown.Size = New System.Drawing.Size(124, 22)
        Me.CMP_MoveToDown.Text = "下へ移動"
        '
        'CTMP_CopyFormat
        '
        Me.CTMP_CopyFormat.Name = "CTMP_CopyFormat"
        Me.CTMP_CopyFormat.Size = New System.Drawing.Size(196, 22)
        Me.CTMP_CopyFormat.Text = "書式適用"
        '
        'CMP_Property
        '
        Me.CMP_Property.Name = "CMP_Property"
        Me.CMP_Property.Size = New System.Drawing.Size(196, 22)
        Me.CMP_Property.Text = "プロパティ"
        '
        'CTMP_DeletePeace
        '
        Me.CTMP_DeletePeace.Name = "CTMP_DeletePeace"
        Me.CTMP_DeletePeace.Size = New System.Drawing.Size(196, 22)
        Me.CTMP_DeletePeace.Text = "選択ピース削除"
        '
        'RadialMenuItem12
        '
        Me.RadialMenuItem12.Name = "RadialMenuItem12"
        Me.RadialMenuItem12.Text = "閉じる"
        Me.RadialMenuItem12.ToolTip = "閉じる"
        '
        'RMRL_Position0
        '
        Me.RMRL_Position0.BackColor = System.Drawing.Color.White
        Me.RMRL_Position0.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_Position0.Image = CType(resources.GetObject("RMRL_Position0.Image"), System.Drawing.Image)
        Me.RMRL_Position0.Name = "RMRL_Position0"
        Me.RMRL_Position0.Text = "先折れ"
        Me.RMRL_Position0.ToolTip = "先折れ"
        Me.RMRL_Position0.UserData = "0"
        '
        'RMRL_Position1
        '
        Me.RMRL_Position1.BackColor = System.Drawing.Color.White
        Me.RMRL_Position1.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_Position1.Image = CType(resources.GetObject("RMRL_Position1.Image"), System.Drawing.Image)
        Me.RMRL_Position1.Name = "RMRL_Position1"
        Me.RMRL_Position1.Text = "通常"
        Me.RMRL_Position1.ToolTip = "通常"
        Me.RMRL_Position1.UserData = "1"
        '
        'RMRL_Position2
        '
        Me.RMRL_Position2.BackColor = System.Drawing.Color.White
        Me.RMRL_Position2.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_Position2.Image = CType(resources.GetObject("RMRL_Position2.Image"), System.Drawing.Image)
        Me.RMRL_Position2.Name = "RMRL_Position2"
        Me.RMRL_Position2.Text = "直接"
        Me.RMRL_Position2.ToolTip = "直接"
        Me.RMRL_Position2.UserData = "2"
        '
        'RMRL_Position3
        '
        Me.RMRL_Position3.BackColor = System.Drawing.Color.White
        Me.RMRL_Position3.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_Position3.Image = CType(resources.GetObject("RMRL_Position3.Image"), System.Drawing.Image)
        Me.RMRL_Position3.Name = "RMRL_Position3"
        Me.RMRL_Position3.Text = "下から下"
        Me.RMRL_Position3.ToolTip = "下から下"
        Me.RMRL_Position3.UserData = "3"
        '
        'RMRL_Position4
        '
        Me.RMRL_Position4.BackColor = System.Drawing.Color.White
        Me.RMRL_Position4.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_Position4.Image = CType(resources.GetObject("RMRL_Position4.Image"), System.Drawing.Image)
        Me.RMRL_Position4.Name = "RMRL_Position4"
        Me.RMRL_Position4.Text = "後折れ"
        Me.RMRL_Position4.ToolTip = "後折れ"
        Me.RMRL_Position4.UserData = "4"
        '
        'RMRL_Position5
        '
        Me.RMRL_Position5.BackColor = System.Drawing.Color.White
        Me.RMRL_Position5.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_Position5.Image = CType(resources.GetObject("RMRL_Position5.Image"), System.Drawing.Image)
        Me.RMRL_Position5.Name = "RMRL_Position5"
        Me.RMRL_Position5.Text = "下から先折れ"
        Me.RMRL_Position5.ToolTip = "下から先折れ"
        Me.RMRL_Position5.UserData = "5"
        '
        'RadialMenuItem5
        '
        Me.RadialMenuItem5.Name = "RadialMenuItem5"
        Me.RadialMenuItem5.Text = "閉じる"
        Me.RadialMenuItem5.ToolTip = "閉じる"
        '
        'RMSB_Style0
        '
        Me.RMSB_Style0.BackColor = System.Drawing.Color.White
        Me.RMSB_Style0.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSB_Style0.Name = "RMSB_Style0"
        Me.RMSB_Style0.Text = "枠なし"
        Me.RMSB_Style0.ToolTip = "枠なし"
        '
        'RMSB_Style1
        '
        Me.RMSB_Style1.BackColor = System.Drawing.Color.White
        Me.RMSB_Style1.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSB_Style1.Name = "RMSB_Style1"
        Me.RMSB_Style1.Text = "矩形"
        Me.RMSB_Style1.ToolTip = "矩形"
        '
        'RMSB_Style2
        '
        Me.RMSB_Style2.BackColor = System.Drawing.Color.White
        Me.RMSB_Style2.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSB_Style2.Name = "RMSB_Style2"
        Me.RMSB_Style2.Text = "角丸矩形"
        Me.RMSB_Style2.ToolTip = "角丸矩形"
        '
        'RMC_RowAddToUp
        '
        Me.RMC_RowAddToUp.BackColor = System.Drawing.Color.White
        Me.RMC_RowAddToUp.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowAddToUp.Image = CType(resources.GetObject("RMC_RowAddToUp.Image"), System.Drawing.Image)
        Me.RMC_RowAddToUp.Name = "RMC_RowAddToUp"
        Me.RMC_RowAddToUp.Text = "上に追加"
        Me.RMC_RowAddToUp.ToolTip = "上に行を追加します"
        '
        'RMC_RowAddToDown
        '
        Me.RMC_RowAddToDown.BackColor = System.Drawing.Color.White
        Me.RMC_RowAddToDown.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowAddToDown.Image = CType(resources.GetObject("RMC_RowAddToDown.Image"), System.Drawing.Image)
        Me.RMC_RowAddToDown.Name = "RMC_RowAddToDown"
        Me.RMC_RowAddToDown.Text = "下に追加"
        Me.RMC_RowAddToDown.ToolTip = "下に行を追加します"
        '
        'RMC_RowAddToBottom
        '
        Me.RMC_RowAddToBottom.BackColor = System.Drawing.Color.White
        Me.RMC_RowAddToBottom.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowAddToBottom.Image = CType(resources.GetObject("RMC_RowAddToBottom.Image"), System.Drawing.Image)
        Me.RMC_RowAddToBottom.Name = "RMC_RowAddToBottom"
        Me.RMC_RowAddToBottom.Text = "最下段に追加"
        Me.RMC_RowAddToBottom.ToolTip = "最下段に行を追加します"
        '
        'RMC_ColAddToLeft
        '
        Me.RMC_ColAddToLeft.BackColor = System.Drawing.Color.White
        Me.RMC_ColAddToLeft.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ColAddToLeft.Image = CType(resources.GetObject("RMC_ColAddToLeft.Image"), System.Drawing.Image)
        Me.RMC_ColAddToLeft.Name = "RMC_ColAddToLeft"
        Me.RMC_ColAddToLeft.Text = "左に追加"
        Me.RMC_ColAddToLeft.ToolTip = "左に列を追加します"
        '
        'RMC_ColAddToRight
        '
        Me.RMC_ColAddToRight.BackColor = System.Drawing.Color.White
        Me.RMC_ColAddToRight.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ColAddToRight.Image = CType(resources.GetObject("RMC_ColAddToRight.Image"), System.Drawing.Image)
        Me.RMC_ColAddToRight.Name = "RMC_ColAddToRight"
        Me.RMC_ColAddToRight.Text = "右に追加"
        Me.RMC_ColAddToRight.ToolTip = "右に列を追加します"
        '
        'RMC_ColAddToEnd
        '
        Me.RMC_ColAddToEnd.BackColor = System.Drawing.Color.White
        Me.RMC_ColAddToEnd.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ColAddToEnd.Image = CType(resources.GetObject("RMC_ColAddToEnd.Image"), System.Drawing.Image)
        Me.RMC_ColAddToEnd.Name = "RMC_ColAddToEnd"
        Me.RMC_ColAddToEnd.Text = "最右に追加"
        Me.RMC_ColAddToEnd.ToolTip = "最右に列を追加します"
        '
        'RMP_Copy
        '
        Me.RMP_Copy.BackColor = System.Drawing.Color.White
        Me.RMP_Copy.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMP_Copy.Image = CType(resources.GetObject("RMP_Copy.Image"), System.Drawing.Image)
        Me.RMP_Copy.Name = "RMP_Copy"
        Me.RMP_Copy.Text = "コピー"
        Me.RMP_Copy.ToolTip = "選択ピースをコピーします"
        '
        'RMP_AddBalloon
        '
        Me.RMP_AddBalloon.BackColor = System.Drawing.Color.White
        Me.RMP_AddBalloon.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMP_AddBalloon.Image = CType(resources.GetObject("RMP_AddBalloon.Image"), System.Drawing.Image)
        Me.RMP_AddBalloon.Name = "RMP_AddBalloon"
        Me.RMP_AddBalloon.Text = "バルーン"
        Me.RMP_AddBalloon.ToolTip = "バルーンを追加します"
        '
        'RMP_AddRelatedLine
        '
        Me.RMP_AddRelatedLine.BackColor = System.Drawing.Color.White
        Me.RMP_AddRelatedLine.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMP_AddRelatedLine.Image = CType(resources.GetObject("RMP_AddRelatedLine.Image"), System.Drawing.Image)
        Me.RMP_AddRelatedLine.Name = "RMP_AddRelatedLine"
        Me.RMP_AddRelatedLine.Text = "関係線"
        Me.RMP_AddRelatedLine.ToolTip = "関係線を追加します"
        '
        'RTMP_ChangeStone
        '
        Me.RTMP_ChangeStone.BackColor = System.Drawing.Color.White
        Me.RTMP_ChangeStone.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RTMP_ChangeStone.Image = CType(resources.GetObject("RTMP_ChangeStone.Image"), System.Drawing.Image)
        Me.RTMP_ChangeStone.Name = "RTMP_ChangeStone"
        Me.RTMP_ChangeStone.Text = "ストーン"
        Me.RTMP_ChangeStone.ToolTip = "ピースをマイルストーンへ変換します"
        '
        'RMP_Move
        '
        Me.RMP_Move.BackColor = System.Drawing.Color.White
        Me.RMP_Move.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMP_Move.Image = CType(resources.GetObject("RMP_Move.Image"), System.Drawing.Image)
        Me.RMP_Move.Items.Add(Me.RMP_MoveToUp)
        Me.RMP_Move.Items.Add(Me.RMP_MoveToDown)
        Me.RMP_Move.Items.Add(Me.RMP_PeaceSwap)
        Me.RMP_Move.Name = "RMP_Move"
        Me.RMP_Move.Text = "移動"
        Me.RMP_Move.ToolTip = "ピースを移動させます"
        '
        'RMP_MoveToUp
        '
        Me.RMP_MoveToUp.BackColor = System.Drawing.Color.White
        Me.RMP_MoveToUp.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMP_MoveToUp.Image = CType(resources.GetObject("RMP_MoveToUp.Image"), System.Drawing.Image)
        Me.RMP_MoveToUp.Name = "RMP_MoveToUp"
        Me.RMP_MoveToUp.Text = "上へ移動"
        Me.RMP_MoveToUp.ToolTip = "上へ移動"
        '
        'RMP_MoveToDown
        '
        Me.RMP_MoveToDown.BackColor = System.Drawing.Color.White
        Me.RMP_MoveToDown.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMP_MoveToDown.Image = CType(resources.GetObject("RMP_MoveToDown.Image"), System.Drawing.Image)
        Me.RMP_MoveToDown.Name = "RMP_MoveToDown"
        Me.RMP_MoveToDown.Text = "下へ移動"
        Me.RMP_MoveToDown.ToolTip = "下へ移動"
        '
        'RMP_PeaceSwap
        '
        Me.RMP_PeaceSwap.BackColor = System.Drawing.Color.White
        Me.RMP_PeaceSwap.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMP_PeaceSwap.Image = CType(resources.GetObject("RMP_PeaceSwap.Image"), System.Drawing.Image)
        Me.RMP_PeaceSwap.Name = "RMP_PeaceSwap"
        Me.RMP_PeaceSwap.Text = "順序変更"
        Me.RMP_PeaceSwap.ToolTip = "ピースの順序を入れ替えます"
        '
        'RTMP_CopyFormat
        '
        Me.RTMP_CopyFormat.BackColor = System.Drawing.Color.White
        Me.RTMP_CopyFormat.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RTMP_CopyFormat.Image = CType(resources.GetObject("RTMP_CopyFormat.Image"), System.Drawing.Image)
        Me.RTMP_CopyFormat.Items.Add(Me.RTMP_CopyFormat_Copy)
        Me.RTMP_CopyFormat.Items.Add(Me.RTMP_CopyFormat_Master)
        Me.RTMP_CopyFormat.Items.Add(Me.RTMP_CopyFormat_Template)
        Me.RTMP_CopyFormat.Name = "RTMP_CopyFormat"
        Me.RTMP_CopyFormat.Text = "書式適用"
        Me.RTMP_CopyFormat.ToolTip = "ピース書式を適用させます"
        '
        'RTMP_CopyFormat_Copy
        '
        Me.RTMP_CopyFormat_Copy.BackColor = System.Drawing.Color.White
        Me.RTMP_CopyFormat_Copy.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RTMP_CopyFormat_Copy.Image = CType(resources.GetObject("RTMP_CopyFormat_Copy.Image"), System.Drawing.Image)
        Me.RTMP_CopyFormat_Copy.Name = "RTMP_CopyFormat_Copy"
        Me.RTMP_CopyFormat_Copy.Text = "コピーピース"
        Me.RTMP_CopyFormat_Copy.ToolTip = "先にコピーしたピースの書式を適用します"
        '
        'RTMP_CopyFormat_Master
        '
        Me.RTMP_CopyFormat_Master.BackColor = System.Drawing.Color.White
        Me.RTMP_CopyFormat_Master.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RTMP_CopyFormat_Master.Image = CType(resources.GetObject("RTMP_CopyFormat_Master.Image"), System.Drawing.Image)
        Me.RTMP_CopyFormat_Master.Name = "RTMP_CopyFormat_Master"
        Me.RTMP_CopyFormat_Master.Text = "マスタピース"
        Me.RTMP_CopyFormat_Master.ToolTip = "マスターピースの書式を適用します"
        '
        'RTMP_CopyFormat_Template
        '
        Me.RTMP_CopyFormat_Template.BackColor = System.Drawing.Color.White
        Me.RTMP_CopyFormat_Template.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RTMP_CopyFormat_Template.Image = CType(resources.GetObject("RTMP_CopyFormat_Template.Image"), System.Drawing.Image)
        Me.RTMP_CopyFormat_Template.Name = "RTMP_CopyFormat_Template"
        Me.RTMP_CopyFormat_Template.Text = "既定ピース"
        Me.RTMP_CopyFormat_Template.ToolTip = "既定ピースの書式を適用します。"
        '
        'RMP_Property
        '
        Me.RMP_Property.BackColor = System.Drawing.Color.White
        Me.RMP_Property.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMP_Property.Image = CType(resources.GetObject("RMP_Property.Image"), System.Drawing.Image)
        Me.RMP_Property.Name = "RMP_Property"
        Me.RMP_Property.Text = "プロパティ"
        Me.RMP_Property.ToolTip = "ピースのプロパティを表示します"
        '
        'RTMP_DeletePeace
        '
        Me.RTMP_DeletePeace.BackColor = System.Drawing.Color.White
        Me.RTMP_DeletePeace.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RTMP_DeletePeace.Image = CType(resources.GetObject("RTMP_DeletePeace.Image"), System.Drawing.Image)
        Me.RTMP_DeletePeace.Name = "RTMP_DeletePeace"
        Me.RTMP_DeletePeace.Text = "ピース削除"
        Me.RTMP_DeletePeace.ToolTip = "選択ピースを削除します"
        '
        'RadialMenuItem9
        '
        Me.RadialMenuItem9.BackColor = System.Drawing.SystemColors.Control
        Me.RadialMenuItem9.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.RadialMenuItem9.Image = CType(resources.GetObject("RadialMenuItem9.Image"), System.Drawing.Image)
        Me.RadialMenuItem9.Name = "RadialMenuItem9"
        Me.RadialMenuItem9.ToolTip = "閉じる"
        '
        'RMS_Copy
        '
        Me.RMS_Copy.BackColor = System.Drawing.Color.White
        Me.RMS_Copy.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMS_Copy.Image = CType(resources.GetObject("RMS_Copy.Image"), System.Drawing.Image)
        Me.RMS_Copy.Name = "RMS_Copy"
        Me.RMS_Copy.Text = "コピー"
        Me.RMS_Copy.ToolTip = "選択ストーンをコピーします"
        '
        'RMS_AddBalloon
        '
        Me.RMS_AddBalloon.BackColor = System.Drawing.Color.White
        Me.RMS_AddBalloon.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMS_AddBalloon.Image = CType(resources.GetObject("RMS_AddBalloon.Image"), System.Drawing.Image)
        Me.RMS_AddBalloon.Name = "RMS_AddBalloon"
        Me.RMS_AddBalloon.Text = "バルーン"
        Me.RMS_AddBalloon.ToolTip = "バルーンを追加します"
        '
        'RMS_AddRelatedLine
        '
        Me.RMS_AddRelatedLine.BackColor = System.Drawing.Color.White
        Me.RMS_AddRelatedLine.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMS_AddRelatedLine.Image = CType(resources.GetObject("RMS_AddRelatedLine.Image"), System.Drawing.Image)
        Me.RMS_AddRelatedLine.Name = "RMS_AddRelatedLine"
        Me.RMS_AddRelatedLine.Text = "接続線"
        Me.RMS_AddRelatedLine.ToolTip = "接続線を追加します"
        '
        'RMS_ChagePeace
        '
        Me.RMS_ChagePeace.BackColor = System.Drawing.Color.White
        Me.RMS_ChagePeace.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMS_ChagePeace.Image = CType(resources.GetObject("RMS_ChagePeace.Image"), System.Drawing.Image)
        Me.RMS_ChagePeace.Name = "RMS_ChagePeace"
        Me.RMS_ChagePeace.Text = "ピース"
        Me.RMS_ChagePeace.ToolTip = "選択ストーンをピースへ変換します"
        '
        'RMS_Move
        '
        Me.RMS_Move.BackColor = System.Drawing.Color.White
        Me.RMS_Move.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMS_Move.Image = CType(resources.GetObject("RMS_Move.Image"), System.Drawing.Image)
        Me.RMS_Move.Items.Add(Me.RMS_MoveToUp)
        Me.RMS_Move.Items.Add(Me.RMS_MoveToDown)
        Me.RMS_Move.Items.Add(Me.RMS_StoneSwap)
        Me.RMS_Move.Name = "RMS_Move"
        Me.RMS_Move.Text = "移動"
        Me.RMS_Move.ToolTip = "選択ストーンの移動"
        '
        'RMS_MoveToUp
        '
        Me.RMS_MoveToUp.BackColor = System.Drawing.Color.White
        Me.RMS_MoveToUp.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMS_MoveToUp.Image = CType(resources.GetObject("RMS_MoveToUp.Image"), System.Drawing.Image)
        Me.RMS_MoveToUp.Name = "RMS_MoveToUp"
        Me.RMS_MoveToUp.Text = "上へ移動"
        Me.RMS_MoveToUp.ToolTip = "上へ移動"
        '
        'RMS_MoveToDown
        '
        Me.RMS_MoveToDown.BackColor = System.Drawing.Color.White
        Me.RMS_MoveToDown.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMS_MoveToDown.Image = CType(resources.GetObject("RMS_MoveToDown.Image"), System.Drawing.Image)
        Me.RMS_MoveToDown.Name = "RMS_MoveToDown"
        Me.RMS_MoveToDown.Text = "下へ移動"
        Me.RMS_MoveToDown.ToolTip = "下へ移動"
        '
        'RMS_StoneSwap
        '
        Me.RMS_StoneSwap.BackColor = System.Drawing.Color.White
        Me.RMS_StoneSwap.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMS_StoneSwap.Image = CType(resources.GetObject("RMS_StoneSwap.Image"), System.Drawing.Image)
        Me.RMS_StoneSwap.Name = "RMS_StoneSwap"
        Me.RMS_StoneSwap.Text = "順序変更"
        Me.RMS_StoneSwap.ToolTip = "ストーンの順序を変更します"
        '
        'RMS_CopyFormat
        '
        Me.RMS_CopyFormat.BackColor = System.Drawing.Color.White
        Me.RMS_CopyFormat.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMS_CopyFormat.Image = CType(resources.GetObject("RMS_CopyFormat.Image"), System.Drawing.Image)
        Me.RMS_CopyFormat.Name = "RMS_CopyFormat"
        Me.RMS_CopyFormat.Text = "書式適用"
        Me.RMS_CopyFormat.ToolTip = "コピーしたストーンの書式だけを適用します"
        '
        'RMS_Property
        '
        Me.RMS_Property.BackColor = System.Drawing.Color.White
        Me.RMS_Property.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMS_Property.Image = CType(resources.GetObject("RMS_Property.Image"), System.Drawing.Image)
        Me.RMS_Property.Name = "RMS_Property"
        Me.RMS_Property.Text = "プロパティ"
        Me.RMS_Property.ToolTip = "ストーンのプロパティを表示します"
        '
        'RMS_DeleteStone
        '
        Me.RMS_DeleteStone.BackColor = System.Drawing.Color.White
        Me.RMS_DeleteStone.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMS_DeleteStone.Image = CType(resources.GetObject("RMS_DeleteStone.Image"), System.Drawing.Image)
        Me.RMS_DeleteStone.Name = "RMS_DeleteStone"
        Me.RMS_DeleteStone.Text = "削除"
        Me.RMS_DeleteStone.ToolTip = "選択ストーンを削除します"
        '
        'RMRL_Change
        '
        Me.RMRL_Change.BackColor = System.Drawing.Color.White
        Me.RMRL_Change.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_Change.Image = CType(resources.GetObject("RMRL_Change.Image"), System.Drawing.Image)
        Me.RMRL_Change.Name = "RMRL_Change"
        Me.RMRL_Change.Text = "反転"
        Me.RMRL_Change.ToolTip = "矢頭を反転させます"
        '
        'RMRL_Position
        '
        Me.RMRL_Position.BackColor = System.Drawing.Color.White
        Me.RMRL_Position.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_Position.Image = CType(resources.GetObject("RMRL_Position.Image"), System.Drawing.Image)
        Me.RMRL_Position.Items.Add(Me.RMRL_Position0)
        Me.RMRL_Position.Items.Add(Me.RMRL_Position1)
        Me.RMRL_Position.Items.Add(Me.RMRL_Position2)
        Me.RMRL_Position.Items.Add(Me.RMRL_Position3)
        Me.RMRL_Position.Items.Add(Me.RMRL_Position4)
        Me.RMRL_Position.Items.Add(Me.RMRL_Position5)
        Me.RMRL_Position.Name = "RMRL_Position"
        Me.RMRL_Position.Text = "位置変更"
        Me.RMRL_Position.ToolTip = "接続位置変更"
        '
        'RMRL_LineType
        '
        Me.RMRL_LineType.BackColor = System.Drawing.Color.White
        Me.RMRL_LineType.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_LineType.Image = CType(resources.GetObject("RMRL_LineType.Image"), System.Drawing.Image)
        Me.RMRL_LineType.Items.Add(Me.RMRL_LineType1)
        Me.RMRL_LineType.Items.Add(Me.RMRL_LineType2)
        Me.RMRL_LineType.Items.Add(Me.RMRL_LineType3)
        Me.RMRL_LineType.Items.Add(Me.RMRL_LineType4)
        Me.RMRL_LineType.Items.Add(Me.RMRL_LineType5)
        Me.RMRL_LineType.Name = "RMRL_LineType"
        Me.RMRL_LineType.Text = "線種"
        Me.RMRL_LineType.ToolTip = "関係線線種"
        '
        'RMRL_LineType1
        '
        Me.RMRL_LineType1.BackColor = System.Drawing.Color.White
        Me.RMRL_LineType1.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_LineType1.Image = CType(resources.GetObject("RMRL_LineType1.Image"), System.Drawing.Image)
        Me.RMRL_LineType1.Name = "RMRL_LineType1"
        Me.RMRL_LineType1.Text = "実線"
        Me.RMRL_LineType1.ToolTip = "実線"
        Me.RMRL_LineType1.UserData = "1"
        '
        'RMRL_LineType2
        '
        Me.RMRL_LineType2.BackColor = System.Drawing.Color.White
        Me.RMRL_LineType2.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_LineType2.Image = CType(resources.GetObject("RMRL_LineType2.Image"), System.Drawing.Image)
        Me.RMRL_LineType2.Name = "RMRL_LineType2"
        Me.RMRL_LineType2.Text = "点線"
        Me.RMRL_LineType2.ToolTip = "点線"
        Me.RMRL_LineType2.UserData = "2"
        '
        'RMRL_LineType3
        '
        Me.RMRL_LineType3.BackColor = System.Drawing.Color.White
        Me.RMRL_LineType3.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_LineType3.Image = CType(resources.GetObject("RMRL_LineType3.Image"), System.Drawing.Image)
        Me.RMRL_LineType3.Name = "RMRL_LineType3"
        Me.RMRL_LineType3.Text = "破線"
        Me.RMRL_LineType3.ToolTip = "破線"
        Me.RMRL_LineType3.UserData = "3"
        '
        'RMRL_LineType4
        '
        Me.RMRL_LineType4.BackColor = System.Drawing.Color.White
        Me.RMRL_LineType4.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_LineType4.Image = CType(resources.GetObject("RMRL_LineType4.Image"), System.Drawing.Image)
        Me.RMRL_LineType4.Name = "RMRL_LineType4"
        Me.RMRL_LineType4.Text = "一点鎖線"
        Me.RMRL_LineType4.ToolTip = "一点鎖線"
        Me.RMRL_LineType4.UserData = "4"
        '
        'RMRL_LineType5
        '
        Me.RMRL_LineType5.BackColor = System.Drawing.Color.White
        Me.RMRL_LineType5.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_LineType5.Image = CType(resources.GetObject("RMRL_LineType5.Image"), System.Drawing.Image)
        Me.RMRL_LineType5.Name = "RMRL_LineType5"
        Me.RMRL_LineType5.Text = "二点鎖線"
        Me.RMRL_LineType5.ToolTip = "二点鎖線"
        Me.RMRL_LineType5.UserData = "5"
        '
        'RMRL_Delete
        '
        Me.RMRL_Delete.BackColor = System.Drawing.Color.White
        Me.RMRL_Delete.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMRL_Delete.Image = CType(resources.GetObject("RMRL_Delete.Image"), System.Drawing.Image)
        Me.RMRL_Delete.Name = "RMRL_Delete"
        Me.RMRL_Delete.Text = "削除"
        Me.RMRL_Delete.ToolTip = "選択関係線削除"
        '
        'RadialMenuStripBalloon
        '
        Me.RadialMenuStripBalloon.Image = CType(resources.GetObject("RadialMenuStripBalloon.Image"), System.Drawing.Image)
        Me.RadialMenuStripBalloon.Items.Add(Me.RMSB_Style)
        Me.RadialMenuStripBalloon.Items.Add(Me.RMSB_Property)
        Me.RadialMenuStripBalloon.Items.Add(Me.RMSB_DeleteBalloon)
        Me.RadialMenuStripBalloon.Items.Add(Me.RadialMenuItem13)
        Me.RadialMenuStripBalloon.Radius = 200
        Me.RadialMenuStripBalloon.TooltipPosition = C1.Win.C1Command.TooltipPosition.Bottom
        '
        'RMSB_Style
        '
        Me.RMSB_Style.BackColor = System.Drawing.Color.White
        Me.RMSB_Style.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSB_Style.Image = CType(resources.GetObject("RMSB_Style.Image"), System.Drawing.Image)
        Me.RMSB_Style.Items.Add(Me.RMSB_Style0)
        Me.RMSB_Style.Items.Add(Me.RMSB_Style1)
        Me.RMSB_Style.Items.Add(Me.RMSB_Style2)
        Me.RMSB_Style.Name = "RMSB_Style"
        Me.RMSB_Style.Text = "形状変更"
        Me.RMSB_Style.ToolTip = "バルーンの形状を選択します"
        '
        'RMSB_Property
        '
        Me.RMSB_Property.BackColor = System.Drawing.Color.White
        Me.RMSB_Property.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSB_Property.Image = CType(resources.GetObject("RMSB_Property.Image"), System.Drawing.Image)
        Me.RMSB_Property.Name = "RMSB_Property"
        Me.RMSB_Property.Text = "プロパティ"
        Me.RMSB_Property.ToolTip = "バルーンのプロパティを表示します"
        '
        'RMSB_DeleteBalloon
        '
        Me.RMSB_DeleteBalloon.BackColor = System.Drawing.Color.White
        Me.RMSB_DeleteBalloon.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSB_DeleteBalloon.Image = CType(resources.GetObject("RMSB_DeleteBalloon.Image"), System.Drawing.Image)
        Me.RMSB_DeleteBalloon.Name = "RMSB_DeleteBalloon"
        Me.RMSB_DeleteBalloon.Text = "削除"
        Me.RMSB_DeleteBalloon.ToolTip = "選択バルーンを削除します"
        '
        'RadialMenuItem13
        '
        Me.RadialMenuItem13.BorderColor = System.Drawing.Color.DarkOrange
        Me.RadialMenuItem13.Image = CType(resources.GetObject("RadialMenuItem13.Image"), System.Drawing.Image)
        Me.RadialMenuItem13.Name = "RadialMenuItem13"
        Me.RadialMenuItem13.Text = "閉じる"
        Me.RadialMenuItem13.ToolTip = "閉じる"
        '
        'RadialMenuCellHeader
        '
        Me.RadialMenuCellHeader.Image = CType(resources.GetObject("RadialMenuCellHeader.Image"), System.Drawing.Image)
        Me.RadialMenuCellHeader.Items.Add(Me.RMCH_Merge)
        Me.RadialMenuCellHeader.Items.Add(Me.RMCH_AddCol)
        Me.RadialMenuCellHeader.Items.Add(Me.RMCD_Move)
        Me.RadialMenuCellHeader.Items.Add(Me.RMCH_Sort)
        Me.RadialMenuCellHeader.Items.Add(Me.RMCH_AutoNumber)
        Me.RadialMenuCellHeader.Items.Add(Me.RMCH_Property)
        Me.RadialMenuCellHeader.Items.Add(Me.RMCH_DelCol)
        Me.RadialMenuCellHeader.Items.Add(Me.RadialMenuItem16)
        Me.RadialMenuCellHeader.Radius = 200
        Me.RadialMenuCellHeader.TooltipPosition = C1.Win.C1Command.TooltipPosition.Bottom
        '
        'RMCH_Merge
        '
        Me.RMCH_Merge.BackColor = System.Drawing.Color.White
        Me.RMCH_Merge.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_Merge.Image = CType(resources.GetObject("RMCH_Merge.Image"), System.Drawing.Image)
        Me.RMCH_Merge.Name = "RMCH_Merge"
        Me.RMCH_Merge.Text = "セル結合"
        Me.RMCH_Merge.ToolTip = "セル結合"
        '
        'RMCH_AddCol
        '
        Me.RMCH_AddCol.BackColor = System.Drawing.Color.White
        Me.RMCH_AddCol.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_AddCol.Image = CType(resources.GetObject("RMCH_AddCol.Image"), System.Drawing.Image)
        Me.RMCH_AddCol.Items.Add(Me.RMCH_AddColToLeft)
        Me.RMCH_AddCol.Items.Add(Me.RMCH_AddColToRight)
        Me.RMCH_AddCol.Name = "RMCH_AddCol"
        Me.RMCH_AddCol.Text = "列追加"
        Me.RMCH_AddCol.ToolTip = "列を追加します"
        '
        'RMCH_AddColToLeft
        '
        Me.RMCH_AddColToLeft.BackColor = System.Drawing.Color.White
        Me.RMCH_AddColToLeft.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_AddColToLeft.Image = CType(resources.GetObject("RMCH_AddColToLeft.Image"), System.Drawing.Image)
        Me.RMCH_AddColToLeft.Name = "RMCH_AddColToLeft"
        Me.RMCH_AddColToLeft.Text = "左へ追加"
        Me.RMCH_AddColToLeft.ToolTip = "左へ追加します"
        '
        'RMCH_AddColToRight
        '
        Me.RMCH_AddColToRight.BackColor = System.Drawing.Color.White
        Me.RMCH_AddColToRight.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_AddColToRight.Image = CType(resources.GetObject("RMCH_AddColToRight.Image"), System.Drawing.Image)
        Me.RMCH_AddColToRight.Name = "RMCH_AddColToRight"
        Me.RMCH_AddColToRight.Text = "右へ追加"
        Me.RMCH_AddColToRight.ToolTip = "右へ追加します"
        '
        'RMCD_Move
        '
        Me.RMCD_Move.BackColor = System.Drawing.Color.White
        Me.RMCD_Move.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCD_Move.Image = CType(resources.GetObject("RMCD_Move.Image"), System.Drawing.Image)
        Me.RMCD_Move.Items.Add(Me.RMCD_MoveToLeft)
        Me.RMCD_Move.Items.Add(Me.RMCD_MoveToRight)
        Me.RMCD_Move.Name = "RMCD_Move"
        Me.RMCD_Move.Text = "移動"
        Me.RMCD_Move.ToolTip = "選択列を移動させます。"
        '
        'RMCD_MoveToLeft
        '
        Me.RMCD_MoveToLeft.BackColor = System.Drawing.Color.White
        Me.RMCD_MoveToLeft.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCD_MoveToLeft.Image = CType(resources.GetObject("RMCD_MoveToLeft.Image"), System.Drawing.Image)
        Me.RMCD_MoveToLeft.Name = "RMCD_MoveToLeft"
        Me.RMCD_MoveToLeft.Text = "左へ移動"
        Me.RMCD_MoveToLeft.ToolTip = "左へ移動させます"
        '
        'RMCD_MoveToRight
        '
        Me.RMCD_MoveToRight.BackColor = System.Drawing.Color.White
        Me.RMCD_MoveToRight.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCD_MoveToRight.Image = CType(resources.GetObject("RMCD_MoveToRight.Image"), System.Drawing.Image)
        Me.RMCD_MoveToRight.Name = "RMCD_MoveToRight"
        Me.RMCD_MoveToRight.Text = "右へ移動"
        Me.RMCD_MoveToRight.ToolTip = "右へ移動させます"
        '
        'RMCH_Sort
        '
        Me.RMCH_Sort.BackColor = System.Drawing.Color.White
        Me.RMCH_Sort.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_Sort.Image = CType(resources.GetObject("RMCH_Sort.Image"), System.Drawing.Image)
        Me.RMCH_Sort.Items.Add(Me.RMCH_SortAscending)
        Me.RMCH_Sort.Items.Add(Me.RMCH_SortDescending)
        Me.RMCH_Sort.Items.Add(Me.RMCH_SortManual)
        Me.RMCH_Sort.Name = "RMCH_Sort"
        Me.RMCH_Sort.Text = "ソート"
        Me.RMCH_Sort.ToolTip = "行のソートを行います。"
        '
        'RMCH_SortAscending
        '
        Me.RMCH_SortAscending.BackColor = System.Drawing.Color.White
        Me.RMCH_SortAscending.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_SortAscending.Image = CType(resources.GetObject("RMCH_SortAscending.Image"), System.Drawing.Image)
        Me.RMCH_SortAscending.Name = "RMCH_SortAscending"
        Me.RMCH_SortAscending.Text = "昇順"
        Me.RMCH_SortAscending.ToolTip = "選択列を基準に昇順でソートします"
        '
        'RMCH_SortDescending
        '
        Me.RMCH_SortDescending.BackColor = System.Drawing.Color.White
        Me.RMCH_SortDescending.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_SortDescending.Image = CType(resources.GetObject("RMCH_SortDescending.Image"), System.Drawing.Image)
        Me.RMCH_SortDescending.Name = "RMCH_SortDescending"
        Me.RMCH_SortDescending.Text = "降順"
        Me.RMCH_SortDescending.ToolTip = "選択列を基準に降順でソートします"
        '
        'RMCH_SortManual
        '
        Me.RMCH_SortManual.BackColor = System.Drawing.Color.White
        Me.RMCH_SortManual.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_SortManual.Image = CType(resources.GetObject("RMCH_SortManual.Image"), System.Drawing.Image)
        Me.RMCH_SortManual.Name = "RMCH_SortManual"
        Me.RMCH_SortManual.Text = "詳細"
        Me.RMCH_SortManual.ToolTip = "詳細設定によりソートを行います"
        '
        'RMCH_AutoNumber
        '
        Me.RMCH_AutoNumber.BackColor = System.Drawing.Color.White
        Me.RMCH_AutoNumber.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_AutoNumber.Image = CType(resources.GetObject("RMCH_AutoNumber.Image"), System.Drawing.Image)
        Me.RMCH_AutoNumber.Name = "RMCH_AutoNumber"
        Me.RMCH_AutoNumber.Text = "行番号"
        Me.RMCH_AutoNumber.ToolTip = "自動的に行番号を付与します"
        '
        'RMCH_Property
        '
        Me.RMCH_Property.BackColor = System.Drawing.Color.White
        Me.RMCH_Property.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_Property.Image = CType(resources.GetObject("RMCH_Property.Image"), System.Drawing.Image)
        Me.RMCH_Property.Items.Add(Me.RMCH_PropertyHeader)
        Me.RMCH_Property.Items.Add(Me.RMCH_PropertyCol)
        Me.RMCH_Property.Items.Add(Me.RMCH_HiddenCol)
        Me.RMCH_Property.Name = "RMCH_Property"
        Me.RMCH_Property.Text = "プロパティ"
        Me.RMCH_Property.ToolTip = "ヘッダータイトルのプロパティを表示します。"
        '
        'RMCH_PropertyHeader
        '
        Me.RMCH_PropertyHeader.BackColor = System.Drawing.Color.White
        Me.RMCH_PropertyHeader.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_PropertyHeader.Image = CType(resources.GetObject("RMCH_PropertyHeader.Image"), System.Drawing.Image)
        Me.RMCH_PropertyHeader.Name = "RMCH_PropertyHeader"
        Me.RMCH_PropertyHeader.Text = "ヘッダプロパティ"
        Me.RMCH_PropertyHeader.ToolTip = "選択列ヘッダーのプロパティを設定します。"
        '
        'RMCH_PropertyCol
        '
        Me.RMCH_PropertyCol.BackColor = System.Drawing.Color.White
        Me.RMCH_PropertyCol.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_PropertyCol.Image = CType(resources.GetObject("RMCH_PropertyCol.Image"), System.Drawing.Image)
        Me.RMCH_PropertyCol.Name = "RMCH_PropertyCol"
        Me.RMCH_PropertyCol.Text = "列プロパティ"
        Me.RMCH_PropertyCol.ToolTip = "選択列全ての書式を一括設定します"
        '
        'RMCH_HiddenCol
        '
        Me.RMCH_HiddenCol.BackColor = System.Drawing.Color.White
        Me.RMCH_HiddenCol.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_HiddenCol.Image = CType(resources.GetObject("RMCH_HiddenCol.Image"), System.Drawing.Image)
        Me.RMCH_HiddenCol.Items.Add(Me.RMCH_HiddenCol_AllCol)
        Me.RMCH_HiddenCol.Items.Add(Me.RMCH_HiddenCol_SelCol)
        Me.RMCH_HiddenCol.Items.Add(Me.RMCH_HiddenCol_AllView)
        Me.RMCH_HiddenCol.Name = "RMCH_HiddenCol"
        Me.RMCH_HiddenCol.Text = "列非表示"
        Me.RMCH_HiddenCol.ToolTip = "列の表示／非表示を設定します。"
        '
        'RMCH_HiddenCol_AllCol
        '
        Me.RMCH_HiddenCol_AllCol.BackColor = System.Drawing.Color.White
        Me.RMCH_HiddenCol_AllCol.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_HiddenCol_AllCol.Image = CType(resources.GetObject("RMCH_HiddenCol_AllCol.Image"), System.Drawing.Image)
        Me.RMCH_HiddenCol_AllCol.Name = "RMCH_HiddenCol_AllCol"
        Me.RMCH_HiddenCol_AllCol.Text = "全列非表示"
        Me.RMCH_HiddenCol_AllCol.ToolTip = "全ての列を非表示に設定します。"
        '
        'RMCH_HiddenCol_SelCol
        '
        Me.RMCH_HiddenCol_SelCol.BackColor = System.Drawing.Color.White
        Me.RMCH_HiddenCol_SelCol.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_HiddenCol_SelCol.Image = CType(resources.GetObject("RMCH_HiddenCol_SelCol.Image"), System.Drawing.Image)
        Me.RMCH_HiddenCol_SelCol.Name = "RMCH_HiddenCol_SelCol"
        Me.RMCH_HiddenCol_SelCol.Text = "選択列非表示"
        Me.RMCH_HiddenCol_SelCol.ToolTip = "選択されている列を非表示に設定します。"
        '
        'RMCH_HiddenCol_AllView
        '
        Me.RMCH_HiddenCol_AllView.BackColor = System.Drawing.Color.White
        Me.RMCH_HiddenCol_AllView.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_HiddenCol_AllView.Image = CType(resources.GetObject("RMCH_HiddenCol_AllView.Image"), System.Drawing.Image)
        Me.RMCH_HiddenCol_AllView.Name = "RMCH_HiddenCol_AllView"
        Me.RMCH_HiddenCol_AllView.Text = "列再表示"
        Me.RMCH_HiddenCol_AllView.ToolTip = "列の再表示を設定します。"
        '
        'RMCH_DelCol
        '
        Me.RMCH_DelCol.BackColor = System.Drawing.Color.White
        Me.RMCH_DelCol.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMCH_DelCol.Image = CType(resources.GetObject("RMCH_DelCol.Image"), System.Drawing.Image)
        Me.RMCH_DelCol.Name = "RMCH_DelCol"
        Me.RMCH_DelCol.Text = "列削除"
        Me.RMCH_DelCol.ToolTip = "選択列を削除します。"
        '
        'RadialMenuItem16
        '
        Me.RadialMenuItem16.BorderColor = System.Drawing.Color.DarkOrange
        Me.RadialMenuItem16.Image = CType(resources.GetObject("RadialMenuItem16.Image"), System.Drawing.Image)
        Me.RadialMenuItem16.Name = "RadialMenuItem16"
        Me.RadialMenuItem16.Text = "閉じる"
        Me.RadialMenuItem16.ToolTip = "閉じる"
        '
        'RadialMenuRelatedLine
        '
        Me.RadialMenuRelatedLine.Image = CType(resources.GetObject("RadialMenuRelatedLine.Image"), System.Drawing.Image)
        Me.RadialMenuRelatedLine.Items.Add(Me.RMRL_Change)
        Me.RadialMenuRelatedLine.Items.Add(Me.RMRL_Position)
        Me.RadialMenuRelatedLine.Items.Add(Me.RMRL_LineType)
        Me.RadialMenuRelatedLine.Items.Add(Me.RMRL_Delete)
        Me.RadialMenuRelatedLine.Items.Add(Me.RadialMenuItem8)
        Me.RadialMenuRelatedLine.Radius = 200
        Me.RadialMenuRelatedLine.TooltipPosition = C1.Win.C1Command.TooltipPosition.Bottom
        '
        'RadialMenuItem8
        '
        Me.RadialMenuItem8.BorderColor = System.Drawing.Color.DarkOrange
        Me.RadialMenuItem8.Image = CType(resources.GetObject("RadialMenuItem8.Image"), System.Drawing.Image)
        Me.RadialMenuItem8.Name = "RadialMenuItem8"
        Me.RadialMenuItem8.Text = "閉じる"
        Me.RadialMenuItem8.ToolTip = "閉じる"
        '
        'RadialMenuStone
        '
        Me.RadialMenuStone.Image = CType(resources.GetObject("RadialMenuStone.Image"), System.Drawing.Image)
        Me.RadialMenuStone.Items.Add(Me.RMS_Copy)
        Me.RadialMenuStone.Items.Add(Me.RMS_AddBalloon)
        Me.RadialMenuStone.Items.Add(Me.RMS_AddRelatedLine)
        Me.RadialMenuStone.Items.Add(Me.RMS_ChagePeace)
        Me.RadialMenuStone.Items.Add(Me.RMS_Move)
        Me.RadialMenuStone.Items.Add(Me.RMS_CopyFormat)
        Me.RadialMenuStone.Items.Add(Me.RMS_Property)
        Me.RadialMenuStone.Items.Add(Me.RMS_DeleteStone)
        Me.RadialMenuStone.Items.Add(Me.RadialMenuItem1)
        Me.RadialMenuStone.Radius = 200
        Me.RadialMenuStone.TooltipPosition = C1.Win.C1Command.TooltipPosition.Bottom
        '
        'RadialMenuItem1
        '
        Me.RadialMenuItem1.BorderColor = System.Drawing.Color.DarkOrange
        Me.RadialMenuItem1.Image = CType(resources.GetObject("RadialMenuItem1.Image"), System.Drawing.Image)
        Me.RadialMenuItem1.Name = "RadialMenuItem1"
        Me.RadialMenuItem1.Text = "閉じる"
        Me.RadialMenuItem1.ToolTip = "閉じる"
        '
        'RadialMenuSheetNothing
        '
        Me.RadialMenuSheetNothing.Image = CType(resources.GetObject("RadialMenuSheetNothing.Image"), System.Drawing.Image)
        Me.RadialMenuSheetNothing.Items.Add(Me.RMSN_RowAdd)
        Me.RadialMenuSheetNothing.Items.Add(Me.RMSN_ItemPaste)
        Me.RadialMenuSheetNothing.Items.Add(Me.RMSN_MoveToday)
        Me.RadialMenuSheetNothing.Items.Add(Me.RMSN_SpecialTimeSetting)
        Me.RadialMenuSheetNothing.Items.Add(Me.RMSN_SheetProperty)
        Me.RadialMenuSheetNothing.Items.Add(Me.RMSN_F11)
        Me.RadialMenuSheetNothing.Items.Add(Me.RadialMenuItem4)
        Me.RadialMenuSheetNothing.Radius = 200
        Me.RadialMenuSheetNothing.TooltipPosition = C1.Win.C1Command.TooltipPosition.Bottom
        '
        'RMSN_RowAdd
        '
        Me.RMSN_RowAdd.BackColor = System.Drawing.Color.White
        Me.RMSN_RowAdd.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSN_RowAdd.Image = CType(resources.GetObject("RMSN_RowAdd.Image"), System.Drawing.Image)
        Me.RMSN_RowAdd.Name = "RMSN_RowAdd"
        Me.RMSN_RowAdd.Text = "行追加"
        Me.RMSN_RowAdd.ToolTip = "行追加"
        '
        'RMSN_ItemPaste
        '
        Me.RMSN_ItemPaste.BackColor = System.Drawing.Color.White
        Me.RMSN_ItemPaste.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSN_ItemPaste.Image = CType(resources.GetObject("RMSN_ItemPaste.Image"), System.Drawing.Image)
        Me.RMSN_ItemPaste.Name = "RMSN_ItemPaste"
        Me.RMSN_ItemPaste.Text = "行貼付"
        Me.RMSN_ItemPaste.ToolTip = "行貼り付け"
        '
        'RMSN_MoveToday
        '
        Me.RMSN_MoveToday.BackColor = System.Drawing.Color.White
        Me.RMSN_MoveToday.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSN_MoveToday.Image = CType(resources.GetObject("RMSN_MoveToday.Image"), System.Drawing.Image)
        Me.RMSN_MoveToday.Name = "RMSN_MoveToday"
        Me.RMSN_MoveToday.Text = "本日"
        Me.RMSN_MoveToday.ToolTip = "本日へ移動"
        '
        'RMSN_SpecialTimeSetting
        '
        Me.RMSN_SpecialTimeSetting.BackColor = System.Drawing.Color.White
        Me.RMSN_SpecialTimeSetting.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSN_SpecialTimeSetting.Image = CType(resources.GetObject("RMSN_SpecialTimeSetting.Image"), System.Drawing.Image)
        Me.RMSN_SpecialTimeSetting.Name = "RMSN_SpecialTimeSetting"
        Me.RMSN_SpecialTimeSetting.Text = "特別期間"
        Me.RMSN_SpecialTimeSetting.ToolTip = "特別期間設定を行います。"
        '
        'RMSN_SheetProperty
        '
        Me.RMSN_SheetProperty.BackColor = System.Drawing.Color.White
        Me.RMSN_SheetProperty.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSN_SheetProperty.Image = CType(resources.GetObject("RMSN_SheetProperty.Image"), System.Drawing.Image)
        Me.RMSN_SheetProperty.Name = "RMSN_SheetProperty"
        Me.RMSN_SheetProperty.Text = "設定"
        Me.RMSN_SheetProperty.ToolTip = "設定"
        '
        'RMSN_F11
        '
        Me.RMSN_F11.BackColor = System.Drawing.Color.White
        Me.RMSN_F11.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMSN_F11.Image = CType(resources.GetObject("RMSN_F11.Image"), System.Drawing.Image)
        Me.RMSN_F11.Name = "RMSN_F11"
        Me.RMSN_F11.Text = "全面切替"
        Me.RMSN_F11.ToolTip = "全面切替"
        '
        'RadialMenuItem4
        '
        Me.RadialMenuItem4.BorderColor = System.Drawing.Color.DarkOrange
        Me.RadialMenuItem4.Image = CType(resources.GetObject("RadialMenuItem4.Image"), System.Drawing.Image)
        Me.RadialMenuItem4.Name = "RadialMenuItem4"
        Me.RadialMenuItem4.Text = "閉じる"
        Me.RadialMenuItem4.ToolTip = "閉じる"
        '
        'RadialMenuCell
        '
        Me.RadialMenuCell.Image = CType(resources.GetObject("RadialMenuCell.Image"), System.Drawing.Image)
        Me.RadialMenuCell.Items.Add(Me.RMC_Row)
        Me.RadialMenuCell.Items.Add(Me.RMC_Col)
        Me.RadialMenuCell.Items.Add(Me.RMC_Cell)
        Me.RadialMenuCell.Items.Add(Me.RMC_CopyFromDown)
        Me.RadialMenuCell.Items.Add(Me.RMC_CopyFromUp)
        Me.RadialMenuCell.Items.Add(Me.RMC_ItemCopy)
        Me.RadialMenuCell.Items.Add(Me.RMC_ItemPaste)
        Me.RadialMenuCell.Items.Add(Me.RMC_Move)
        Me.RadialMenuCell.Items.Add(Me.RMC_CellProperty)
        Me.RadialMenuCell.Items.Add(Me.RadialMenuItem15)
        Me.RadialMenuCell.Radius = 200
        Me.RadialMenuCell.TooltipPosition = C1.Win.C1Command.TooltipPosition.Bottom
        '
        'RMC_Row
        '
        Me.RMC_Row.BackColor = System.Drawing.Color.White
        Me.RMC_Row.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_Row.Image = CType(resources.GetObject("RMC_Row.Image"), System.Drawing.Image)
        Me.RMC_Row.Items.Add(Me.RMC_RowAdd)
        Me.RMC_Row.Items.Add(Me.RMC_RowMove)
        Me.RMC_Row.Items.Add(Me.RMC_RowCopy)
        Me.RMC_Row.Items.Add(Me.RMC_RowColor)
        Me.RMC_Row.Items.Add(Me.RMC_RowHidden)
        Me.RMC_Row.Items.Add(Me.RMC_RowDel)
        Me.RMC_Row.Items.Add(Me.RMC_RowPeceClear)
        Me.RMC_Row.Name = "RMC_Row"
        Me.RMC_Row.Text = "行操作"
        Me.RMC_Row.ToolTip = "行の操作を行います"
        '
        'RMC_RowAdd
        '
        Me.RMC_RowAdd.BackColor = System.Drawing.Color.White
        Me.RMC_RowAdd.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowAdd.Image = CType(resources.GetObject("RMC_RowAdd.Image"), System.Drawing.Image)
        Me.RMC_RowAdd.Items.Add(Me.RMC_RowAddToUp)
        Me.RMC_RowAdd.Items.Add(Me.RMC_RowAddToDown)
        Me.RMC_RowAdd.Items.Add(Me.RMC_RowAddToBottom)
        Me.RMC_RowAdd.Name = "RMC_RowAdd"
        Me.RMC_RowAdd.Text = "追加"
        Me.RMC_RowAdd.ToolTip = "行を追加します"
        '
        'RMC_RowMove
        '
        Me.RMC_RowMove.BackColor = System.Drawing.Color.White
        Me.RMC_RowMove.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowMove.Image = CType(resources.GetObject("RMC_RowMove.Image"), System.Drawing.Image)
        Me.RMC_RowMove.Items.Add(Me.RMC_RowMoveToUp)
        Me.RMC_RowMove.Items.Add(Me.RMC_RowMoveToDown)
        Me.RMC_RowMove.Name = "RMC_RowMove"
        Me.RMC_RowMove.Text = "移動"
        Me.RMC_RowMove.ToolTip = "選択行を移動させます"
        '
        'RMC_RowMoveToUp
        '
        Me.RMC_RowMoveToUp.BackColor = System.Drawing.Color.White
        Me.RMC_RowMoveToUp.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowMoveToUp.Image = CType(resources.GetObject("RMC_RowMoveToUp.Image"), System.Drawing.Image)
        Me.RMC_RowMoveToUp.Name = "RMC_RowMoveToUp"
        Me.RMC_RowMoveToUp.Text = "上に移動"
        Me.RMC_RowMoveToUp.ToolTip = "上に行を移動させます"
        '
        'RMC_RowMoveToDown
        '
        Me.RMC_RowMoveToDown.BackColor = System.Drawing.Color.White
        Me.RMC_RowMoveToDown.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowMoveToDown.Image = CType(resources.GetObject("RMC_RowMoveToDown.Image"), System.Drawing.Image)
        Me.RMC_RowMoveToDown.Name = "RMC_RowMoveToDown"
        Me.RMC_RowMoveToDown.Text = "下に移動"
        Me.RMC_RowMoveToDown.ToolTip = "下に行を移動させます"
        '
        'RMC_RowCopy
        '
        Me.RMC_RowCopy.BackColor = System.Drawing.Color.White
        Me.RMC_RowCopy.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowCopy.Image = CType(resources.GetObject("RMC_RowCopy.Image"), System.Drawing.Image)
        Me.RMC_RowCopy.Name = "RMC_RowCopy"
        Me.RMC_RowCopy.Text = "行コピー"
        Me.RMC_RowCopy.ToolTip = "選択行をコピーします"
        '
        'RMC_RowColor
        '
        Me.RMC_RowColor.BackColor = System.Drawing.Color.White
        Me.RMC_RowColor.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowColor.Image = CType(resources.GetObject("RMC_RowColor.Image"), System.Drawing.Image)
        Me.RMC_RowColor.Name = "RMC_RowColor"
        Me.RMC_RowColor.Text = "色選択"
        Me.RMC_RowColor.ToolTip = "選択行の背景色を選択・設定します。"
        '
        'RMC_RowHidden
        '
        Me.RMC_RowHidden.BackColor = System.Drawing.Color.White
        Me.RMC_RowHidden.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowHidden.Image = CType(resources.GetObject("RMC_RowHidden.Image"), System.Drawing.Image)
        Me.RMC_RowHidden.Items.Add(Me.RMC_RowHidden_One)
        Me.RMC_RowHidden.Items.Add(Me.RMC_RowHidden_Tree)
        Me.RMC_RowHidden.Name = "RMC_RowHidden"
        Me.RMC_RowHidden.Text = "行非表示"
        Me.RMC_RowHidden.ToolTip = "選択行を非表示に設定します"
        '
        'RMC_RowHidden_One
        '
        Me.RMC_RowHidden_One.BackColor = System.Drawing.Color.White
        Me.RMC_RowHidden_One.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowHidden_One.Image = CType(resources.GetObject("RMC_RowHidden_One.Image"), System.Drawing.Image)
        Me.RMC_RowHidden_One.Name = "RMC_RowHidden_One"
        Me.RMC_RowHidden_One.Text = "選択行"
        Me.RMC_RowHidden_One.ToolTip = "選択行を非表示に設定します"
        '
        'RMC_RowHidden_Tree
        '
        Me.RMC_RowHidden_Tree.BackColor = System.Drawing.Color.White
        Me.RMC_RowHidden_Tree.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowHidden_Tree.Image = CType(resources.GetObject("RMC_RowHidden_Tree.Image"), System.Drawing.Image)
        Me.RMC_RowHidden_Tree.Name = "RMC_RowHidden_Tree"
        Me.RMC_RowHidden_Tree.Text = "子レベル"
        Me.RMC_RowHidden_Tree.ToolTip = "下行の子レベル行を非表示に設定します"
        '
        'RMC_RowDel
        '
        Me.RMC_RowDel.BackColor = System.Drawing.Color.White
        Me.RMC_RowDel.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowDel.Image = CType(resources.GetObject("RMC_RowDel.Image"), System.Drawing.Image)
        Me.RMC_RowDel.Name = "RMC_RowDel"
        Me.RMC_RowDel.Text = "削除"
        Me.RMC_RowDel.ToolTip = "選択行を削除します"
        '
        'RMC_RowPeceClear
        '
        Me.RMC_RowPeceClear.BackColor = System.Drawing.Color.White
        Me.RMC_RowPeceClear.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_RowPeceClear.Image = CType(resources.GetObject("RMC_RowPeceClear.Image"), System.Drawing.Image)
        Me.RMC_RowPeceClear.Name = "RMC_RowPeceClear"
        Me.RMC_RowPeceClear.Text = "ピースクリア"
        Me.RMC_RowPeceClear.ToolTip = "選択行に設置されているピースを全て削除します。"
        '
        'RMC_Col
        '
        Me.RMC_Col.BackColor = System.Drawing.Color.White
        Me.RMC_Col.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_Col.Image = CType(resources.GetObject("RMC_Col.Image"), System.Drawing.Image)
        Me.RMC_Col.Items.Add(Me.RMC_ColAdd)
        Me.RMC_Col.Items.Add(Me.RMC_ColMove)
        Me.RMC_Col.Items.Add(Me.RMC_ColHidden)
        Me.RMC_Col.Items.Add(Me.RMC_ColDel)
        Me.RMC_Col.Name = "RMC_Col"
        Me.RMC_Col.Text = "列操作"
        Me.RMC_Col.ToolTip = "列の操作を行います"
        '
        'RMC_ColAdd
        '
        Me.RMC_ColAdd.BackColor = System.Drawing.Color.White
        Me.RMC_ColAdd.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ColAdd.Image = CType(resources.GetObject("RMC_ColAdd.Image"), System.Drawing.Image)
        Me.RMC_ColAdd.Items.Add(Me.RMC_ColAddToLeft)
        Me.RMC_ColAdd.Items.Add(Me.RMC_ColAddToRight)
        Me.RMC_ColAdd.Items.Add(Me.RMC_ColAddToEnd)
        Me.RMC_ColAdd.Name = "RMC_ColAdd"
        Me.RMC_ColAdd.Text = "追加"
        Me.RMC_ColAdd.ToolTip = "列を追加します"
        '
        'RMC_ColMove
        '
        Me.RMC_ColMove.BackColor = System.Drawing.Color.White
        Me.RMC_ColMove.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ColMove.Image = CType(resources.GetObject("RMC_ColMove.Image"), System.Drawing.Image)
        Me.RMC_ColMove.Items.Add(Me.RMC_ColMoveToLeft)
        Me.RMC_ColMove.Items.Add(Me.RMC_ColMoveToRight)
        Me.RMC_ColMove.Name = "RMC_ColMove"
        Me.RMC_ColMove.Text = "移動"
        Me.RMC_ColMove.ToolTip = "選択列を移動させます"
        '
        'RMC_ColMoveToLeft
        '
        Me.RMC_ColMoveToLeft.BackColor = System.Drawing.Color.White
        Me.RMC_ColMoveToLeft.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ColMoveToLeft.Image = CType(resources.GetObject("RMC_ColMoveToLeft.Image"), System.Drawing.Image)
        Me.RMC_ColMoveToLeft.Name = "RMC_ColMoveToLeft"
        Me.RMC_ColMoveToLeft.Text = "左へ移動"
        Me.RMC_ColMoveToLeft.ToolTip = "左へ列を移動させます"
        '
        'RMC_ColMoveToRight
        '
        Me.RMC_ColMoveToRight.BackColor = System.Drawing.Color.White
        Me.RMC_ColMoveToRight.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ColMoveToRight.Image = CType(resources.GetObject("RMC_ColMoveToRight.Image"), System.Drawing.Image)
        Me.RMC_ColMoveToRight.Name = "RMC_ColMoveToRight"
        Me.RMC_ColMoveToRight.Text = "右へ移動"
        Me.RMC_ColMoveToRight.ToolTip = "右へ列を移動させます"
        '
        'RMC_ColHidden
        '
        Me.RMC_ColHidden.BackColor = System.Drawing.Color.White
        Me.RMC_ColHidden.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ColHidden.Image = CType(resources.GetObject("RMC_ColHidden.Image"), System.Drawing.Image)
        Me.RMC_ColHidden.Name = "RMC_ColHidden"
        Me.RMC_ColHidden.Text = "列非表示"
        Me.RMC_ColHidden.ToolTip = "選択列を非表示に設定します。"
        '
        'RMC_ColDel
        '
        Me.RMC_ColDel.BackColor = System.Drawing.Color.White
        Me.RMC_ColDel.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ColDel.Image = CType(resources.GetObject("RMC_ColDel.Image"), System.Drawing.Image)
        Me.RMC_ColDel.Name = "RMC_ColDel"
        Me.RMC_ColDel.Text = "削除"
        Me.RMC_ColDel.ToolTip = "選択列を削除します"
        '
        'RMC_Cell
        '
        Me.RMC_Cell.BackColor = System.Drawing.Color.White
        Me.RMC_Cell.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_Cell.Image = CType(resources.GetObject("RMC_Cell.Image"), System.Drawing.Image)
        Me.RMC_Cell.Items.Add(Me.RMC_CellCopy)
        Me.RMC_Cell.Items.Add(Me.RMC_CellPaste1)
        Me.RMC_Cell.Items.Add(Me.RMC_CellPaste2)
        Me.RMC_Cell.Items.Add(Me.RMC_CellAllCopy)
        Me.RMC_Cell.Name = "RMC_Cell"
        Me.RMC_Cell.Text = "セル操作"
        Me.RMC_Cell.ToolTip = "セルの操作を行います"
        '
        'RMC_CellCopy
        '
        Me.RMC_CellCopy.BackColor = System.Drawing.Color.White
        Me.RMC_CellCopy.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_CellCopy.Image = CType(resources.GetObject("RMC_CellCopy.Image"), System.Drawing.Image)
        Me.RMC_CellCopy.Name = "RMC_CellCopy"
        Me.RMC_CellCopy.Text = "コピー"
        Me.RMC_CellCopy.ToolTip = "選択セルをコピーします。"
        '
        'RMC_CellPaste1
        '
        Me.RMC_CellPaste1.BackColor = System.Drawing.Color.White
        Me.RMC_CellPaste1.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_CellPaste1.Image = CType(resources.GetObject("RMC_CellPaste1.Image"), System.Drawing.Image)
        Me.RMC_CellPaste1.Name = "RMC_CellPaste1"
        Me.RMC_CellPaste1.Text = "ペースト"
        Me.RMC_CellPaste1.ToolTip = "コピーしたセルを貼り付けます"
        '
        'RMC_CellPaste2
        '
        Me.RMC_CellPaste2.BackColor = System.Drawing.Color.White
        Me.RMC_CellPaste2.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_CellPaste2.Image = CType(resources.GetObject("RMC_CellPaste2.Image"), System.Drawing.Image)
        Me.RMC_CellPaste2.Name = "RMC_CellPaste2"
        Me.RMC_CellPaste2.Text = "書式ペースト"
        Me.RMC_CellPaste2.ToolTip = "コピーしたセルの書式のみを貼り付けます"
        '
        'RMC_CellAllCopy
        '
        Me.RMC_CellAllCopy.BackColor = System.Drawing.Color.White
        Me.RMC_CellAllCopy.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_CellAllCopy.Image = CType(resources.GetObject("RMC_CellAllCopy.Image"), System.Drawing.Image)
        Me.RMC_CellAllCopy.Name = "RMC_CellAllCopy"
        Me.RMC_CellAllCopy.Text = "全コピー"
        Me.RMC_CellAllCopy.ToolTip = "下まで全コピー"
        '
        'RMC_CopyFromDown
        '
        Me.RMC_CopyFromDown.BackColor = System.Drawing.Color.White
        Me.RMC_CopyFromDown.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_CopyFromDown.Image = CType(resources.GetObject("RMC_CopyFromDown.Image"), System.Drawing.Image)
        Me.RMC_CopyFromDown.Name = "RMC_CopyFromDown"
        Me.RMC_CopyFromDown.Text = "下からコピー"
        Me.RMC_CopyFromDown.ToolTip = "下セルの内容をコピーします"
        '
        'RMC_CopyFromUp
        '
        Me.RMC_CopyFromUp.BackColor = System.Drawing.Color.White
        Me.RMC_CopyFromUp.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_CopyFromUp.Image = CType(resources.GetObject("RMC_CopyFromUp.Image"), System.Drawing.Image)
        Me.RMC_CopyFromUp.Name = "RMC_CopyFromUp"
        Me.RMC_CopyFromUp.Text = "上からコピー"
        Me.RMC_CopyFromUp.ToolTip = "上セルの内容をコピーします"
        '
        'RMC_ItemCopy
        '
        Me.RMC_ItemCopy.BackColor = System.Drawing.Color.White
        Me.RMC_ItemCopy.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ItemCopy.Image = CType(resources.GetObject("RMC_ItemCopy.Image"), System.Drawing.Image)
        Me.RMC_ItemCopy.Name = "RMC_ItemCopy"
        Me.RMC_ItemCopy.Text = "行コピー"
        Me.RMC_ItemCopy.ToolTip = "選択行をコピーします"
        '
        'RMC_ItemPaste
        '
        Me.RMC_ItemPaste.BackColor = System.Drawing.Color.White
        Me.RMC_ItemPaste.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ItemPaste.Image = CType(resources.GetObject("RMC_ItemPaste.Image"), System.Drawing.Image)
        Me.RMC_ItemPaste.Items.Add(Me.RMC_ItemPasteToUp)
        Me.RMC_ItemPaste.Items.Add(Me.RMC_ItemPasteToDown)
        Me.RMC_ItemPaste.Items.Add(Me.RMC_ItemPasteToBottom)
        Me.RMC_ItemPaste.Name = "RMC_ItemPaste"
        Me.RMC_ItemPaste.Text = "行貼付"
        Me.RMC_ItemPaste.ToolTip = "コピーした行を貼り付けます"
        '
        'RMC_ItemPasteToUp
        '
        Me.RMC_ItemPasteToUp.BackColor = System.Drawing.Color.White
        Me.RMC_ItemPasteToUp.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ItemPasteToUp.Image = CType(resources.GetObject("RMC_ItemPasteToUp.Image"), System.Drawing.Image)
        Me.RMC_ItemPasteToUp.Name = "RMC_ItemPasteToUp"
        Me.RMC_ItemPasteToUp.Text = "上へ"
        Me.RMC_ItemPasteToUp.ToolTip = "上へ貼り付け"
        '
        'RMC_ItemPasteToDown
        '
        Me.RMC_ItemPasteToDown.BackColor = System.Drawing.Color.White
        Me.RMC_ItemPasteToDown.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ItemPasteToDown.Image = CType(resources.GetObject("RMC_ItemPasteToDown.Image"), System.Drawing.Image)
        Me.RMC_ItemPasteToDown.Name = "RMC_ItemPasteToDown"
        Me.RMC_ItemPasteToDown.Text = "下へ"
        Me.RMC_ItemPasteToDown.ToolTip = "下へ貼り付け"
        '
        'RMC_ItemPasteToBottom
        '
        Me.RMC_ItemPasteToBottom.BackColor = System.Drawing.Color.White
        Me.RMC_ItemPasteToBottom.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_ItemPasteToBottom.Image = CType(resources.GetObject("RMC_ItemPasteToBottom.Image"), System.Drawing.Image)
        Me.RMC_ItemPasteToBottom.Name = "RMC_ItemPasteToBottom"
        Me.RMC_ItemPasteToBottom.Text = "最下段"
        Me.RMC_ItemPasteToBottom.ToolTip = "最下段へ貼り付け"
        '
        'RMC_Move
        '
        Me.RMC_Move.BackColor = System.Drawing.Color.White
        Me.RMC_Move.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_Move.Image = CType(resources.GetObject("RMC_Move.Image"), System.Drawing.Image)
        Me.RMC_Move.Items.Add(Me.RMC_MoveTop)
        Me.RMC_Move.Items.Add(Me.RMC_MoveLast)
        Me.RMC_Move.Name = "RMC_Move"
        Me.RMC_Move.Text = "移動"
        Me.RMC_Move.ToolTip = "設置ピースの先頭・最終まで移動します。"
        '
        'RMC_MoveTop
        '
        Me.RMC_MoveTop.BackColor = System.Drawing.Color.White
        Me.RMC_MoveTop.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_MoveTop.Image = CType(resources.GetObject("RMC_MoveTop.Image"), System.Drawing.Image)
        Me.RMC_MoveTop.Name = "RMC_MoveTop"
        Me.RMC_MoveTop.Text = "先頭へ移動"
        Me.RMC_MoveTop.ToolTip = "設置ピースの先頭日付まで移動します"
        '
        'RMC_MoveLast
        '
        Me.RMC_MoveLast.BackColor = System.Drawing.Color.White
        Me.RMC_MoveLast.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_MoveLast.Image = CType(resources.GetObject("RMC_MoveLast.Image"), System.Drawing.Image)
        Me.RMC_MoveLast.Name = "RMC_MoveLast"
        Me.RMC_MoveLast.Text = "最終へ移動"
        Me.RMC_MoveLast.ToolTip = "設置ピースの最終日付まで移動します"
        '
        'RMC_CellProperty
        '
        Me.RMC_CellProperty.BackColor = System.Drawing.Color.White
        Me.RMC_CellProperty.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMC_CellProperty.Image = CType(resources.GetObject("RMC_CellProperty.Image"), System.Drawing.Image)
        Me.RMC_CellProperty.Name = "RMC_CellProperty"
        Me.RMC_CellProperty.Text = "プロパティ"
        Me.RMC_CellProperty.ToolTip = "セルのプロパティを表示します"
        '
        'RadialMenuItem15
        '
        Me.RadialMenuItem15.BorderColor = System.Drawing.Color.DarkOrange
        Me.RadialMenuItem15.Image = CType(resources.GetObject("RadialMenuItem15.Image"), System.Drawing.Image)
        Me.RadialMenuItem15.Name = "RadialMenuItem15"
        Me.RadialMenuItem15.Text = "閉じる"
        Me.RadialMenuItem15.ToolTip = "閉じる"
        '
        'RadialMenuPeace
        '
        Me.RadialMenuPeace.Image = CType(resources.GetObject("RadialMenuPeace.Image"), System.Drawing.Image)
        Me.RadialMenuPeace.Items.Add(Me.RMP_Copy)
        Me.RadialMenuPeace.Items.Add(Me.RMP_AddBalloon)
        Me.RadialMenuPeace.Items.Add(Me.RMP_AddRelatedLine)
        Me.RadialMenuPeace.Items.Add(Me.RTMP_ChangeStone)
        Me.RadialMenuPeace.Items.Add(Me.RMP_Move)
        Me.RadialMenuPeace.Items.Add(Me.RTMP_CopyFormat)
        Me.RadialMenuPeace.Items.Add(Me.RMP_Property)
        Me.RadialMenuPeace.Items.Add(Me.RTMP_DeletePeace)
        Me.RadialMenuPeace.Items.Add(Me.RadialMenuItem2)
        Me.RadialMenuPeace.Radius = 200
        Me.RadialMenuPeace.TooltipPosition = C1.Win.C1Command.TooltipPosition.Bottom
        '
        'RadialMenuItem2
        '
        Me.RadialMenuItem2.BorderColor = System.Drawing.Color.DarkOrange
        Me.RadialMenuItem2.Image = CType(resources.GetObject("RadialMenuItem2.Image"), System.Drawing.Image)
        Me.RadialMenuItem2.Name = "RadialMenuItem2"
        Me.RadialMenuItem2.Text = "閉じる"
        Me.RadialMenuItem2.ToolTip = "閉じる"
        '
        'RadialMenuPiecePane
        '
        Me.RadialMenuPiecePane.Image = CType(resources.GetObject("RadialMenuPiecePane.Image"), System.Drawing.Image)
        Me.RadialMenuPiecePane.Items.Add(Me.RMNO_Paste)
        Me.RadialMenuPiecePane.Items.Add(Me.RMNO_Property)
        Me.RadialMenuPiecePane.Items.Add(Me.RMNO_MoveToday)
        Me.RadialMenuPiecePane.Items.Add(Me.RMNO_RowColor)
        Me.RadialMenuPiecePane.Items.Add(Me.RMNO_SpecialTimeSetting)
        Me.RadialMenuPiecePane.Items.Add(Me.RMNO_DataExport)
        Me.RadialMenuPiecePane.Items.Add(Me.RMNO_Import)
        Me.RadialMenuPiecePane.Items.Add(Me.RMNO_Seek)
        Me.RadialMenuPiecePane.Items.Add(Me.RMNO_Hidden)
        Me.RadialMenuPiecePane.Items.Add(Me.RMNO_F11)
        Me.RadialMenuPiecePane.Items.Add(Me.RadialMenuItem7)
        Me.RadialMenuPiecePane.Radius = 220
        Me.RadialMenuPiecePane.TooltipPosition = C1.Win.C1Command.TooltipPosition.Bottom
        '
        'RMNO_Paste
        '
        Me.RMNO_Paste.BackColor = System.Drawing.Color.White
        Me.RMNO_Paste.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_Paste.Image = CType(resources.GetObject("RMNO_Paste.Image"), System.Drawing.Image)
        Me.RMNO_Paste.Name = "RMNO_Paste"
        Me.RMNO_Paste.Text = "貼付"
        Me.RMNO_Paste.ToolTip = "貼り付け"
        '
        'RMNO_Property
        '
        Me.RMNO_Property.BackColor = System.Drawing.Color.White
        Me.RMNO_Property.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_Property.Image = CType(resources.GetObject("RMNO_Property.Image"), System.Drawing.Image)
        Me.RMNO_Property.Name = "RMNO_Property"
        Me.RMNO_Property.Text = "設定"
        Me.RMNO_Property.ToolTip = "シート設定が画面を表示します"
        '
        'RMNO_MoveToday
        '
        Me.RMNO_MoveToday.BackColor = System.Drawing.Color.White
        Me.RMNO_MoveToday.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_MoveToday.Image = CType(resources.GetObject("RMNO_MoveToday.Image"), System.Drawing.Image)
        Me.RMNO_MoveToday.Name = "RMNO_MoveToday"
        Me.RMNO_MoveToday.Text = "本日"
        Me.RMNO_MoveToday.ToolTip = "本日へ移動します"
        '
        'RMNO_RowColor
        '
        Me.RMNO_RowColor.BackColor = System.Drawing.Color.White
        Me.RMNO_RowColor.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_RowColor.Image = CType(resources.GetObject("RMNO_RowColor.Image"), System.Drawing.Image)
        Me.RMNO_RowColor.Name = "RMNO_RowColor"
        Me.RMNO_RowColor.Text = "色選択"
        Me.RMNO_RowColor.ToolTip = "選択行の背景色を選択・設定します。"
        '
        'RMNO_SpecialTimeSetting
        '
        Me.RMNO_SpecialTimeSetting.BackColor = System.Drawing.Color.White
        Me.RMNO_SpecialTimeSetting.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_SpecialTimeSetting.Image = CType(resources.GetObject("RMNO_SpecialTimeSetting.Image"), System.Drawing.Image)
        Me.RMNO_SpecialTimeSetting.Name = "RMNO_SpecialTimeSetting"
        Me.RMNO_SpecialTimeSetting.Text = "特別期間"
        Me.RMNO_SpecialTimeSetting.ToolTip = "特別期間設定を行います。"
        '
        'RMNO_DataExport
        '
        Me.RMNO_DataExport.BackColor = System.Drawing.Color.White
        Me.RMNO_DataExport.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_DataExport.Image = CType(resources.GetObject("RMNO_DataExport.Image"), System.Drawing.Image)
        Me.RMNO_DataExport.Items.Add(Me.RMNO_DataExport_Grid)
        Me.RMNO_DataExport.Items.Add(Me.RMNO_DataExport_XML)
        Me.RMNO_DataExport.Name = "RMNO_DataExport"
        Me.RMNO_DataExport.Text = "エクスポート"
        Me.RMNO_DataExport.ToolTip = "ガントデータをエクスポートします"
        '
        'RMNO_DataExport_Grid
        '
        Me.RMNO_DataExport_Grid.BackColor = System.Drawing.Color.White
        Me.RMNO_DataExport_Grid.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_DataExport_Grid.Image = CType(resources.GetObject("RMNO_DataExport_Grid.Image"), System.Drawing.Image)
        Me.RMNO_DataExport_Grid.Name = "RMNO_DataExport_Grid"
        Me.RMNO_DataExport_Grid.Text = "グリッド"
        Me.RMNO_DataExport_Grid.ToolTip = "専用グリッド画面にエクスポートします。"
        '
        'RMNO_DataExport_XML
        '
        Me.RMNO_DataExport_XML.BackColor = System.Drawing.Color.White
        Me.RMNO_DataExport_XML.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_DataExport_XML.Image = CType(resources.GetObject("RMNO_DataExport_XML.Image"), System.Drawing.Image)
        Me.RMNO_DataExport_XML.Name = "RMNO_DataExport_XML"
        Me.RMNO_DataExport_XML.Text = "XMLファイル"
        Me.RMNO_DataExport_XML.ToolTip = "XMLファイルとしてデータをエクスポートします。"
        '
        'RMNO_Import
        '
        Me.RMNO_Import.BackColor = System.Drawing.Color.White
        Me.RMNO_Import.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_Import.Image = CType(resources.GetObject("RMNO_Import.Image"), System.Drawing.Image)
        Me.RMNO_Import.Items.Add(Me.RMNO_Import_CSV)
        Me.RMNO_Import.Items.Add(Me.RMNO_Import_Clip)
        Me.RMNO_Import.Items.Add(Me.RMNO_Import_Merge)
        Me.RMNO_Import.Name = "RMNO_Import"
        Me.RMNO_Import.Text = "インポート"
        Me.RMNO_Import.ToolTip = "データをインポートします"
        '
        'RMNO_Import_CSV
        '
        Me.RMNO_Import_CSV.BackColor = System.Drawing.Color.White
        Me.RMNO_Import_CSV.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_Import_CSV.Image = CType(resources.GetObject("RMNO_Import_CSV.Image"), System.Drawing.Image)
        Me.RMNO_Import_CSV.Name = "RMNO_Import_CSV"
        Me.RMNO_Import_CSV.Text = "CSVファイル"
        Me.RMNO_Import_CSV.ToolTip = "CSVファイルのデータをインポートします"
        '
        'RMNO_Import_Clip
        '
        Me.RMNO_Import_Clip.BackColor = System.Drawing.Color.White
        Me.RMNO_Import_Clip.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_Import_Clip.Image = CType(resources.GetObject("RMNO_Import_Clip.Image"), System.Drawing.Image)
        Me.RMNO_Import_Clip.Name = "RMNO_Import_Clip"
        Me.RMNO_Import_Clip.Text = "クリップボード"
        Me.RMNO_Import_Clip.ToolTip = "クリップボードデータをインポートします"
        '
        'RMNO_Import_Merge
        '
        Me.RMNO_Import_Merge.BackColor = System.Drawing.Color.White
        Me.RMNO_Import_Merge.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_Import_Merge.Image = CType(resources.GetObject("RMNO_Import_Merge.Image"), System.Drawing.Image)
        Me.RMNO_Import_Merge.Name = "RMNO_Import_Merge"
        Me.RMNO_Import_Merge.Text = "マージ"
        Me.RMNO_Import_Merge.ToolTip = "Windyデータをマージします"
        '
        'RMNO_Seek
        '
        Me.RMNO_Seek.BackColor = System.Drawing.Color.White
        Me.RMNO_Seek.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_Seek.Image = CType(resources.GetObject("RMNO_Seek.Image"), System.Drawing.Image)
        Me.RMNO_Seek.Name = "RMNO_Seek"
        Me.RMNO_Seek.Text = "検索"
        Me.RMNO_Seek.ToolTip = "シート内のアイテムを検索しします。"
        '
        'RMNO_Hidden
        '
        Me.RMNO_Hidden.BackColor = System.Drawing.Color.White
        Me.RMNO_Hidden.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_Hidden.Image = CType(resources.GetObject("RMNO_Hidden.Image"), System.Drawing.Image)
        Me.RMNO_Hidden.Items.Add(Me.RMNO_HiddenRow)
        Me.RMNO_Hidden.Items.Add(Me.RMNO_HiddenCol)
        Me.RMNO_Hidden.Name = "RMNO_Hidden"
        Me.RMNO_Hidden.Text = "表示/非表示"
        Me.RMNO_Hidden.ToolTip = "列や行の表示／非表示を設定します。"
        '
        'RMNO_HiddenRow
        '
        Me.RMNO_HiddenRow.BackColor = System.Drawing.Color.White
        Me.RMNO_HiddenRow.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_HiddenRow.Image = CType(resources.GetObject("RMNO_HiddenRow.Image"), System.Drawing.Image)
        Me.RMNO_HiddenRow.Name = "RMNO_HiddenRow"
        Me.RMNO_HiddenRow.Text = "行再表示"
        Me.RMNO_HiddenRow.ToolTip = "行の再表示を設定します"
        '
        'RMNO_HiddenCol
        '
        Me.RMNO_HiddenCol.BackColor = System.Drawing.Color.White
        Me.RMNO_HiddenCol.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_HiddenCol.Image = CType(resources.GetObject("RMNO_HiddenCol.Image"), System.Drawing.Image)
        Me.RMNO_HiddenCol.Items.Add(Me.RMNO_Hidden_Hidden)
        Me.RMNO_HiddenCol.Items.Add(Me.RMNO_Hidden_View)
        Me.RMNO_HiddenCol.Name = "RMNO_HiddenCol"
        Me.RMNO_HiddenCol.Text = "列の表示／非表示"
        Me.RMNO_HiddenCol.ToolTip = "列の表示／非表示を設定します"
        '
        'RMNO_Hidden_Hidden
        '
        Me.RMNO_Hidden_Hidden.BackColor = System.Drawing.Color.White
        Me.RMNO_Hidden_Hidden.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_Hidden_Hidden.Image = CType(resources.GetObject("RMNO_Hidden_Hidden.Image"), System.Drawing.Image)
        Me.RMNO_Hidden_Hidden.Name = "RMNO_Hidden_Hidden"
        Me.RMNO_Hidden_Hidden.Text = "全列非表示"
        Me.RMNO_Hidden_Hidden.ToolTip = "全ての列を非表示に設定します"
        '
        'RMNO_Hidden_View
        '
        Me.RMNO_Hidden_View.BackColor = System.Drawing.Color.White
        Me.RMNO_Hidden_View.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_Hidden_View.Image = CType(resources.GetObject("RMNO_Hidden_View.Image"), System.Drawing.Image)
        Me.RMNO_Hidden_View.Name = "RMNO_Hidden_View"
        Me.RMNO_Hidden_View.Text = "列再表示"
        Me.RMNO_Hidden_View.ToolTip = "列を再表示を設定します"
        '
        'RMNO_F11
        '
        Me.RMNO_F11.BackColor = System.Drawing.Color.White
        Me.RMNO_F11.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RMNO_F11.Image = CType(resources.GetObject("RMNO_F11.Image"), System.Drawing.Image)
        Me.RMNO_F11.Name = "RMNO_F11"
        Me.RMNO_F11.Text = "全面切替"
        Me.RMNO_F11.ToolTip = "全面切替"
        '
        'RadialMenuItem7
        '
        Me.RadialMenuItem7.BorderColor = System.Drawing.Color.DarkOrange
        Me.RadialMenuItem7.Image = CType(resources.GetObject("RadialMenuItem7.Image"), System.Drawing.Image)
        Me.RadialMenuItem7.Name = "RadialMenuItem7"
        Me.RadialMenuItem7.Text = "閉じる"
        Me.RadialMenuItem7.ToolTip = "閉じる"
        '
        'TView
        '
        Me.TView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TView.Location = New System.Drawing.Point(0, 0)
        Me.TView.Name = "TView"
        Me.TView.OcxState = CType(resources.GetObject("TView.OcxState"), System.Windows.Forms.AxHost.State)
        Me.TView.Size = New System.Drawing.Size(1052, 595)
        Me.TView.TabIndex = 8
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 595)
        Me.Controls.Add(Me.TView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMain"
        Me.Text = "FrmMain"
        Me.ContextMenuStone.ResumeLayout(False)
        Me.ContextMenuSheetNothing.ResumeLayout(False)
        Me.ContextMenuRelatedLine.ResumeLayout(False)
        Me.ContextMenuStripBalloon.ResumeLayout(False)
        Me.ContextMenuPiecePane.ResumeLayout(False)
        Me.ContextMenuCellHeader.ResumeLayout(False)
        Me.ContextMenuCell.ResumeLayout(False)
        Me.ContextMenuPeace.ResumeLayout(False)
        CType(Me.TView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStone As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuSheetNothing As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuRelatedLine As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuStripBalloon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuPiecePane As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuCellHeader As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuCell As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuPeace As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CMP_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMP_AddBalloon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMP_AddRelatedLine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CTMP_ChangeStone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMP_Move As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMP_MoveToUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMP_MoveToDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CTMP_CopyFormat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMP_Property As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CTMP_DeletePeace As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_AddBalloon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_AddRelatedLine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_ChagePeace As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_Move As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_MoveToUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_MoveToDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_CopyFormat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_Property As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_DeleteStone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_Change As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_Position As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_Position0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_Position1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_Position2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_Position3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_Position4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_Position5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_LineType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_LineType1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_LineType2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_LineType3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_LineType4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_LineType5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMRL_Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSB_Style As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSB_Style0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSB_Style1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSB_Style2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSB_Property As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSB_DeleteBalloon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMNO_Paste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMNO_Property As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMCH_Merge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMCH_AddCol As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMCH_AddColToLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMCH_AddColToRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMCD_Move As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMCD_MoveToLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMCD_MoveToRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMCH_Property As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMCH_DelCol As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSN_RowAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSN_ItemPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_Row As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_RowAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_RowMove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_RowDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_Col As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ColAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ColMove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ColDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_CopyFromDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_CopyFromUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ItemCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ItemPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ItemPasteToUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ItemPasteToDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ItemPasteToBottom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_CellProperty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem17 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_RowAddToUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_RowAddToDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_RowAddToBottom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_RowMoveToUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_RowMoveToDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ColAddToLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ColAddToRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ColAddToEnd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ColMoveToLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMC_ColMoveToRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RMP_Copy As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMP_AddBalloon As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMP_AddRelatedLine As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RTMP_ChangeStone As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMP_Move As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RTMP_CopyFormat As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMP_Property As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RTMP_DeletePeace As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuItem9 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMP_MoveToUp As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMP_MoveToDown As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMS_Copy As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMS_AddBalloon As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMS_AddRelatedLine As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMS_ChagePeace As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMS_Move As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMS_CopyFormat As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMS_Property As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMS_DeleteStone As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuItem12 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMS_MoveToUp As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMS_MoveToDown As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_Change As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_Position As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_Position0 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_Position1 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_Position2 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_Position3 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_Position4 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_Position5 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_LineType As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_Delete As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuItem5 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuStripBalloon As C1.Win.C1Command.C1RadialMenu
    Friend WithEvents RMSB_Style As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMSB_Style0 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMSB_Style1 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMSB_Style2 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMSB_Property As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMSB_DeleteBalloon As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuItem13 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents CMC_RowHidden As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadialMenuCellHeader As C1.Win.C1Command.C1RadialMenu
    Friend WithEvents RMCH_Merge As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_AddCol As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_AddColToLeft As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_AddColToRight As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCD_Move As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCD_MoveToLeft As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCD_MoveToRight As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_Property As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_DelCol As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuItem16 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuRelatedLine As C1.Win.C1Command.C1RadialMenu
    Friend WithEvents RadialMenuItem8 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_LineType1 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_LineType2 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_LineType3 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_LineType4 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMRL_LineType5 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuStone As C1.Win.C1Command.C1RadialMenu
    Friend WithEvents RadialMenuItem1 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuSheetNothing As C1.Win.C1Command.C1RadialMenu
    Friend WithEvents RMSN_RowAdd As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMSN_ItemPaste As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuItem4 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuCell As C1.Win.C1Command.C1RadialMenu
    Friend WithEvents RMC_Row As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowAdd As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowAddToUp As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowAddToDown As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowAddToBottom As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowMove As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowMoveToUp As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowMoveToDown As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowDel As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_Col As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ColAdd As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ColAddToLeft As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ColAddToRight As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ColAddToEnd As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ColMove As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ColMoveToLeft As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ColMoveToRight As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ColDel As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_CopyFromDown As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_CopyFromUp As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ItemCopy As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ItemPaste As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ItemPasteToUp As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ItemPasteToDown As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ItemPasteToBottom As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_CellProperty As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuItem15 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuPeace As C1.Win.C1Command.C1RadialMenu
    Friend WithEvents RadialMenuItem2 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuPiecePane As C1.Win.C1Command.C1RadialMenu
    Friend WithEvents RMNO_Paste As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_Property As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuItem7 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMSN_SheetProperty As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMSN_MoveToday As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_MoveToday As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowColor As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_RowColor As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_Cell As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_CellCopy As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_CellPaste1 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_CellPaste2 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_CellAllCopy As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_DataExport As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_DataExport_Grid As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_DataExport_XML As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_SpecialTimeSetting As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMSN_SpecialTimeSetting As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowPeceClear As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_Sort As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_SortAscending As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_SortDescending As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_SortManual As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_AutoNumber As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_PropertyHeader As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_PropertyCol As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents CMC_Move As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RMC_Move As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_MoveTop As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_MoveLast As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_Seek As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RTMP_CopyFormat_Copy As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RTMP_CopyFormat_Master As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RTMP_CopyFormat_Template As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_Import As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_Import_CSV As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_Import_Clip As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_Import_Merge As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents TView As AxKnTViewLib.AxKnTView
    Friend WithEvents RMCH_HiddenCol As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_HiddenCol_AllCol As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_HiddenCol_SelCol As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMCH_HiddenCol_AllView As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_ColHidden As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_Hidden As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowHidden As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowHidden_One As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowHidden_Tree As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_HiddenRow As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_HiddenCol As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_Hidden_Hidden As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_Hidden_View As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMP_PeaceSwap As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMS_StoneSwap As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMC_RowCopy As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMSN_F11 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RMNO_F11 As C1.Win.C1Command.RadialMenuItem

End Class
