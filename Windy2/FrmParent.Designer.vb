<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParent))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuNewFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_NewFile_Temprate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuOpenFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSaveFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSaveFileAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSaveFileAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuDataExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDataExport_Grid = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDataExport_XML = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuImport_CSV = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuImport_Clip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuImport_Windy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSnapshot = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuProperty = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuSet0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSet1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSet2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSet3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSet4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSet5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTimeNarrow = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTimeWide = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTimeDefault = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuZoomIn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuZoomOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuPeaceWide = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPeaceNarrow = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuFront7Day = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTopPiace = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToday = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuLastPiace = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBack7Day = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuSheetReflesh = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemScan = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSheetSync = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAddRowUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAddRowDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAddRowLast = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMoveRowUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMoveRowDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDeleteRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAddColumnLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAddColumnRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAddColumnLast = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMoveColumnLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMoveColumnRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDeleteColumn = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSetToday2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSetTodaySet = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSetTodayClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuSyncScale = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAllScreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolbarHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuGideNoVisible = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolButton_NewFile = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolButton_NewFile_Temprate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_OpenFile = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_SaveFile = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolButton_Snapshot = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_Print = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolButton_AddRow = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolButton_AddRow_ToUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_AddRow_ToDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_AddCol = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolButton_AddCol_ToLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_AddCol_ToRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_DelRow = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolButton_DelRowEx = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_DelCol = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolButton_ToUp = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_ToDown = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_ToLeft = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_ToRight = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_HiddenCol = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolButton_DisHiddenCol = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_HiddenRow = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolButton_HiddenRowTree = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolButton_DisHiddenRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolButton_AddLink = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_AddBalloon = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_ItemChange = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_CopyPiece = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_PastePiece = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolButton_Undo = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_SheetProperty = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_ItemScan = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_ZoomOut = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolButton_ZoomOut_2Day = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_ZoomOut_5Day = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_ZoomOut_Week = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_ZoomIn = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolButton_ZoomIn_1Day = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_TimeNarrow = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_TimeDefault = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_TimeWide = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_TopPiace = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolButton_TopPiace_Row = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_Front7Day = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_Today = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolButton_SaveDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_SelDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_Back7Day = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_LastPiace = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolButton_LastPiace_Row = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_PeaceWide = New System.Windows.Forms.ToolStripButton()
        Me.ToolButton_PeaceNarrow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolButton_SpecialTimeSetting = New System.Windows.Forms.ToolStripButton()
        Me.ToolSheetRefresh = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolSheetReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolButton_ProgressLine = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.LblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblSpecialTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblItemObject = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblOwner = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblToday = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblTempLock = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel10 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblRendou = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblTabletMode = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblUndoLevel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblLockFile = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel11 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.LblF11 = New System.Windows.Forms.Label()
        Me.LblF10 = New System.Windows.Forms.Label()
        Me.LblF9 = New System.Windows.Forms.Label()
        Me.LblF8 = New System.Windows.Forms.Label()
        Me.LblF7 = New System.Windows.Forms.Label()
        Me.LblF6 = New System.Windows.Forms.Label()
        Me.LblF5 = New System.Windows.Forms.Label()
        Me.LblF4 = New System.Windows.Forms.Label()
        Me.LblF3 = New System.Windows.Forms.Label()
        Me.LblF2 = New System.Windows.Forms.Label()
        Me.LblF1 = New System.Windows.Forms.Label()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.LblF12 = New System.Windows.Forms.Label()
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.EditMenu, Me.ToolsMenu, Me.WindowsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1364, 26)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuNewFile, Me.Menu_NewFile_Temprate, Me.ToolStripSeparator19, Me.MenuOpenFile, Me.MenuSaveFile, Me.MenuSaveFileAll, Me.MenuSaveFileAs, Me.ToolStripSeparator16, Me.MenuDataExport, Me.ToolStripMenuItem5, Me.MenuReload, Me.ToolStripSeparator4, Me.MenuPrint, Me.MenuSnapshot, Me.MenuProperty, Me.ToolStripSeparator11, Me.MenuSet0, Me.MenuSet1, Me.MenuSet2, Me.MenuSet3, Me.MenuSet4, Me.MenuSet5, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(85, 22)
        Me.FileMenu.Text = "ファイル(&F)"
        '
        'MenuNewFile
        '
        Me.MenuNewFile.Image = CType(resources.GetObject("MenuNewFile.Image"), System.Drawing.Image)
        Me.MenuNewFile.ImageTransparentColor = System.Drawing.Color.Black
        Me.MenuNewFile.Name = "MenuNewFile"
        Me.MenuNewFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.MenuNewFile.Size = New System.Drawing.Size(213, 22)
        Me.MenuNewFile.Text = "新規作成(&N)"
        '
        'Menu_NewFile_Temprate
        '
        Me.Menu_NewFile_Temprate.Image = CType(resources.GetObject("Menu_NewFile_Temprate.Image"), System.Drawing.Image)
        Me.Menu_NewFile_Temprate.Name = "Menu_NewFile_Temprate"
        Me.Menu_NewFile_Temprate.Size = New System.Drawing.Size(213, 22)
        Me.Menu_NewFile_Temprate.Text = "テンプレートファイル(&L)"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(210, 6)
        '
        'MenuOpenFile
        '
        Me.MenuOpenFile.Image = CType(resources.GetObject("MenuOpenFile.Image"), System.Drawing.Image)
        Me.MenuOpenFile.ImageTransparentColor = System.Drawing.Color.Black
        Me.MenuOpenFile.Name = "MenuOpenFile"
        Me.MenuOpenFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.MenuOpenFile.Size = New System.Drawing.Size(213, 22)
        Me.MenuOpenFile.Text = "開く(&O)"
        '
        'MenuSaveFile
        '
        Me.MenuSaveFile.Image = CType(resources.GetObject("MenuSaveFile.Image"), System.Drawing.Image)
        Me.MenuSaveFile.ImageTransparentColor = System.Drawing.Color.Black
        Me.MenuSaveFile.Name = "MenuSaveFile"
        Me.MenuSaveFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MenuSaveFile.Size = New System.Drawing.Size(213, 22)
        Me.MenuSaveFile.Tag = "1"
        Me.MenuSaveFile.Text = "保存(&S)"
        '
        'MenuSaveFileAll
        '
        Me.MenuSaveFileAll.Image = CType(resources.GetObject("MenuSaveFileAll.Image"), System.Drawing.Image)
        Me.MenuSaveFileAll.Name = "MenuSaveFileAll"
        Me.MenuSaveFileAll.Size = New System.Drawing.Size(213, 22)
        Me.MenuSaveFileAll.Text = "全てのシートを保存(&B)"
        '
        'MenuSaveFileAs
        '
        Me.MenuSaveFileAs.Image = CType(resources.GetObject("MenuSaveFileAs.Image"), System.Drawing.Image)
        Me.MenuSaveFileAs.Name = "MenuSaveFileAs"
        Me.MenuSaveFileAs.Size = New System.Drawing.Size(213, 22)
        Me.MenuSaveFileAs.Tag = "1"
        Me.MenuSaveFileAs.Text = "名前を付けて保存(&A)"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(210, 6)
        '
        'MenuDataExport
        '
        Me.MenuDataExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuDataExport_Grid, Me.MenuDataExport_XML})
        Me.MenuDataExport.Image = CType(resources.GetObject("MenuDataExport.Image"), System.Drawing.Image)
        Me.MenuDataExport.Name = "MenuDataExport"
        Me.MenuDataExport.Size = New System.Drawing.Size(213, 22)
        Me.MenuDataExport.Tag = "1"
        Me.MenuDataExport.Text = "データエクスポート(&T)"
        '
        'MenuDataExport_Grid
        '
        Me.MenuDataExport_Grid.Image = CType(resources.GetObject("MenuDataExport_Grid.Image"), System.Drawing.Image)
        Me.MenuDataExport_Grid.Name = "MenuDataExport_Grid"
        Me.MenuDataExport_Grid.Size = New System.Drawing.Size(229, 22)
        Me.MenuDataExport_Grid.Text = "グリッドへ出力する(&G)"
        '
        'MenuDataExport_XML
        '
        Me.MenuDataExport_XML.Image = CType(resources.GetObject("MenuDataExport_XML.Image"), System.Drawing.Image)
        Me.MenuDataExport_XML.Name = "MenuDataExport_XML"
        Me.MenuDataExport_XML.Size = New System.Drawing.Size(229, 22)
        Me.MenuDataExport_XML.Text = "XMLファイルに出力する(&M)"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuImport_CSV, Me.MenuImport_Clip, Me.ToolStripSeparator15, Me.MenuImport_Windy})
        Me.ToolStripMenuItem5.Image = CType(resources.GetObject("ToolStripMenuItem5.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(213, 22)
        Me.ToolStripMenuItem5.Text = "データインポート(&I)"
        '
        'MenuImport_CSV
        '
        Me.MenuImport_CSV.Image = CType(resources.GetObject("MenuImport_CSV.Image"), System.Drawing.Image)
        Me.MenuImport_CSV.Name = "MenuImport_CSV"
        Me.MenuImport_CSV.Size = New System.Drawing.Size(244, 22)
        Me.MenuImport_CSV.Text = "CSVファイルからインポート"
        '
        'MenuImport_Clip
        '
        Me.MenuImport_Clip.Image = CType(resources.GetObject("MenuImport_Clip.Image"), System.Drawing.Image)
        Me.MenuImport_Clip.Name = "MenuImport_Clip"
        Me.MenuImport_Clip.Size = New System.Drawing.Size(244, 22)
        Me.MenuImport_Clip.Text = "クリップボードからインポート"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(241, 6)
        '
        'MenuImport_Windy
        '
        Me.MenuImport_Windy.Image = CType(resources.GetObject("MenuImport_Windy.Image"), System.Drawing.Image)
        Me.MenuImport_Windy.Name = "MenuImport_Windy"
        Me.MenuImport_Windy.Size = New System.Drawing.Size(244, 22)
        Me.MenuImport_Windy.Text = "Windyファイルのマージ"
        '
        'MenuReload
        '
        Me.MenuReload.Image = CType(resources.GetObject("MenuReload.Image"), System.Drawing.Image)
        Me.MenuReload.Name = "MenuReload"
        Me.MenuReload.Size = New System.Drawing.Size(213, 22)
        Me.MenuReload.Text = "データリロード(&R)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(210, 6)
        '
        'MenuPrint
        '
        Me.MenuPrint.Image = CType(resources.GetObject("MenuPrint.Image"), System.Drawing.Image)
        Me.MenuPrint.ImageTransparentColor = System.Drawing.Color.Black
        Me.MenuPrint.Name = "MenuPrint"
        Me.MenuPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MenuPrint.Size = New System.Drawing.Size(213, 22)
        Me.MenuPrint.Text = "印刷(&P)"
        '
        'MenuSnapshot
        '
        Me.MenuSnapshot.Image = CType(resources.GetObject("MenuSnapshot.Image"), System.Drawing.Image)
        Me.MenuSnapshot.Name = "MenuSnapshot"
        Me.MenuSnapshot.Size = New System.Drawing.Size(213, 22)
        Me.MenuSnapshot.Text = "スナップショット(&H)"
        '
        'MenuProperty
        '
        Me.MenuProperty.Image = CType(resources.GetObject("MenuProperty.Image"), System.Drawing.Image)
        Me.MenuProperty.ImageTransparentColor = System.Drawing.Color.Black
        Me.MenuProperty.Name = "MenuProperty"
        Me.MenuProperty.Size = New System.Drawing.Size(213, 22)
        Me.MenuProperty.Tag = "1"
        Me.MenuProperty.Text = "シート設定(&R)"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(210, 6)
        '
        'MenuSet0
        '
        Me.MenuSet0.Name = "MenuSet0"
        Me.MenuSet0.Size = New System.Drawing.Size(213, 22)
        Me.MenuSet0.Text = "----"
        '
        'MenuSet1
        '
        Me.MenuSet1.Name = "MenuSet1"
        Me.MenuSet1.Size = New System.Drawing.Size(213, 22)
        Me.MenuSet1.Text = "-----"
        '
        'MenuSet2
        '
        Me.MenuSet2.Name = "MenuSet2"
        Me.MenuSet2.Size = New System.Drawing.Size(213, 22)
        Me.MenuSet2.Text = "ToolStripMenuItem3"
        '
        'MenuSet3
        '
        Me.MenuSet3.Name = "MenuSet3"
        Me.MenuSet3.Size = New System.Drawing.Size(213, 22)
        Me.MenuSet3.Text = "ToolStripMenuItem4"
        '
        'MenuSet4
        '
        Me.MenuSet4.Name = "MenuSet4"
        Me.MenuSet4.Size = New System.Drawing.Size(213, 22)
        Me.MenuSet4.Text = "ToolStripMenuItem5"
        '
        'MenuSet5
        '
        Me.MenuSet5.Name = "MenuSet5"
        Me.MenuSet5.Size = New System.Drawing.Size(213, 22)
        Me.MenuSet5.Text = "ToolStripMenuItem6"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(210, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ExitToolStripMenuItem.Text = "終了(&X)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuTimeNarrow, Me.MenuTimeWide, Me.MenuTimeDefault, Me.ToolStripSeparator12, Me.MenuZoomIn, Me.MenuZoomOut, Me.ToolStripSeparator13, Me.MenuPeaceWide, Me.MenuPeaceNarrow, Me.MenuFront7Day, Me.MenuTopPiace, Me.MenuToday, Me.MenuLastPiace, Me.MenuBack7Day, Me.ToolStripSeparator14, Me.MenuSheetReflesh, Me.MenuItemScan, Me.MenuSheetSync})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem1.Text = "シート操作(&S)"
        '
        'MenuTimeNarrow
        '
        Me.MenuTimeNarrow.Image = CType(resources.GetObject("MenuTimeNarrow.Image"), System.Drawing.Image)
        Me.MenuTimeNarrow.Name = "MenuTimeNarrow"
        Me.MenuTimeNarrow.Size = New System.Drawing.Size(202, 22)
        Me.MenuTimeNarrow.Text = "日付幅を狭める(&N)"
        '
        'MenuTimeWide
        '
        Me.MenuTimeWide.Image = CType(resources.GetObject("MenuTimeWide.Image"), System.Drawing.Image)
        Me.MenuTimeWide.Name = "MenuTimeWide"
        Me.MenuTimeWide.Size = New System.Drawing.Size(202, 22)
        Me.MenuTimeWide.Text = "日付幅を広げる(&W)"
        '
        'MenuTimeDefault
        '
        Me.MenuTimeDefault.Image = CType(resources.GetObject("MenuTimeDefault.Image"), System.Drawing.Image)
        Me.MenuTimeDefault.Name = "MenuTimeDefault"
        Me.MenuTimeDefault.Size = New System.Drawing.Size(202, 22)
        Me.MenuTimeDefault.Text = "日付幅標準に戻す(&D)"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(199, 6)
        '
        'MenuZoomIn
        '
        Me.MenuZoomIn.Image = CType(resources.GetObject("MenuZoomIn.Image"), System.Drawing.Image)
        Me.MenuZoomIn.Name = "MenuZoomIn"
        Me.MenuZoomIn.Size = New System.Drawing.Size(202, 22)
        Me.MenuZoomIn.Text = "シート拡大(&Z)"
        '
        'MenuZoomOut
        '
        Me.MenuZoomOut.Image = CType(resources.GetObject("MenuZoomOut.Image"), System.Drawing.Image)
        Me.MenuZoomOut.Name = "MenuZoomOut"
        Me.MenuZoomOut.Size = New System.Drawing.Size(202, 22)
        Me.MenuZoomOut.Text = "シート縮小(&O)"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(199, 6)
        '
        'MenuPeaceWide
        '
        Me.MenuPeaceWide.Image = CType(resources.GetObject("MenuPeaceWide.Image"), System.Drawing.Image)
        Me.MenuPeaceWide.Name = "MenuPeaceWide"
        Me.MenuPeaceWide.Size = New System.Drawing.Size(202, 22)
        Me.MenuPeaceWide.Text = "ピース拡大(&K)"
        '
        'MenuPeaceNarrow
        '
        Me.MenuPeaceNarrow.Image = CType(resources.GetObject("MenuPeaceNarrow.Image"), System.Drawing.Image)
        Me.MenuPeaceNarrow.Name = "MenuPeaceNarrow"
        Me.MenuPeaceNarrow.Size = New System.Drawing.Size(202, 22)
        Me.MenuPeaceNarrow.Text = "ピース縮小(&O)"
        '
        'MenuFront7Day
        '
        Me.MenuFront7Day.Image = CType(resources.GetObject("MenuFront7Day.Image"), System.Drawing.Image)
        Me.MenuFront7Day.Name = "MenuFront7Day"
        Me.MenuFront7Day.Size = New System.Drawing.Size(202, 22)
        Me.MenuFront7Day.Text = "７日前へ移動(&1)"
        '
        'MenuTopPiace
        '
        Me.MenuTopPiace.Image = CType(resources.GetObject("MenuTopPiace.Image"), System.Drawing.Image)
        Me.MenuTopPiace.Name = "MenuTopPiace"
        Me.MenuTopPiace.Size = New System.Drawing.Size(202, 22)
        Me.MenuTopPiace.Text = "先頭ピースへ移動(&2)"
        '
        'MenuToday
        '
        Me.MenuToday.Image = CType(resources.GetObject("MenuToday.Image"), System.Drawing.Image)
        Me.MenuToday.Name = "MenuToday"
        Me.MenuToday.Size = New System.Drawing.Size(202, 22)
        Me.MenuToday.Text = "今日へ移動(&3)"
        '
        'MenuLastPiace
        '
        Me.MenuLastPiace.Image = CType(resources.GetObject("MenuLastPiace.Image"), System.Drawing.Image)
        Me.MenuLastPiace.Name = "MenuLastPiace"
        Me.MenuLastPiace.Size = New System.Drawing.Size(202, 22)
        Me.MenuLastPiace.Text = "最終ピースへ移動(&4)"
        '
        'MenuBack7Day
        '
        Me.MenuBack7Day.Image = CType(resources.GetObject("MenuBack7Day.Image"), System.Drawing.Image)
        Me.MenuBack7Day.Name = "MenuBack7Day"
        Me.MenuBack7Day.Size = New System.Drawing.Size(202, 22)
        Me.MenuBack7Day.Text = "７日後へ移動(&5)"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(199, 6)
        '
        'MenuSheetReflesh
        '
        Me.MenuSheetReflesh.Image = CType(resources.GetObject("MenuSheetReflesh.Image"), System.Drawing.Image)
        Me.MenuSheetReflesh.Name = "MenuSheetReflesh"
        Me.MenuSheetReflesh.Size = New System.Drawing.Size(202, 22)
        Me.MenuSheetReflesh.Text = "シートリフレッシュ(&R)"
        '
        'MenuItemScan
        '
        Me.MenuItemScan.Image = CType(resources.GetObject("MenuItemScan.Image"), System.Drawing.Image)
        Me.MenuItemScan.Name = "MenuItemScan"
        Me.MenuItemScan.Size = New System.Drawing.Size(202, 22)
        Me.MenuItemScan.Text = "アイテム検索(&I)"
        '
        'MenuSheetSync
        '
        Me.MenuSheetSync.Image = CType(resources.GetObject("MenuSheetSync.Image"), System.Drawing.Image)
        Me.MenuSheetSync.Name = "MenuSheetSync"
        Me.MenuSheetSync.Size = New System.Drawing.Size(202, 22)
        Me.MenuSheetSync.Text = "表示日付同期(&Y)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.MenuDeleteRow, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.MenuDeleteColumn})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem2.Tag = "1"
        Me.ToolStripMenuItem2.Text = "行・列操作(&C)"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAddRowUp, Me.MenuAddRowDown, Me.MenuAddRowLast})
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(155, 22)
        Me.ToolStripMenuItem3.Text = "行追加(&R)"
        '
        'MenuAddRowUp
        '
        Me.MenuAddRowUp.Image = CType(resources.GetObject("MenuAddRowUp.Image"), System.Drawing.Image)
        Me.MenuAddRowUp.Name = "MenuAddRowUp"
        Me.MenuAddRowUp.Size = New System.Drawing.Size(166, 22)
        Me.MenuAddRowUp.Text = "上へ追加(&U)"
        '
        'MenuAddRowDown
        '
        Me.MenuAddRowDown.Image = CType(resources.GetObject("MenuAddRowDown.Image"), System.Drawing.Image)
        Me.MenuAddRowDown.Name = "MenuAddRowDown"
        Me.MenuAddRowDown.Size = New System.Drawing.Size(166, 22)
        Me.MenuAddRowDown.Text = "下へ追加(&D)"
        '
        'MenuAddRowLast
        '
        Me.MenuAddRowLast.Image = CType(resources.GetObject("MenuAddRowLast.Image"), System.Drawing.Image)
        Me.MenuAddRowLast.Name = "MenuAddRowLast"
        Me.MenuAddRowLast.Size = New System.Drawing.Size(166, 22)
        Me.MenuAddRowLast.Text = "最下段へ追加(&B)"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuMoveRowUp, Me.MenuMoveRowDown})
        Me.ToolStripMenuItem4.Image = CType(resources.GetObject("ToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(155, 22)
        Me.ToolStripMenuItem4.Text = "行移動(&M)"
        '
        'MenuMoveRowUp
        '
        Me.MenuMoveRowUp.Image = CType(resources.GetObject("MenuMoveRowUp.Image"), System.Drawing.Image)
        Me.MenuMoveRowUp.Name = "MenuMoveRowUp"
        Me.MenuMoveRowUp.Size = New System.Drawing.Size(143, 22)
        Me.MenuMoveRowUp.Text = "上へ移動(&U)"
        '
        'MenuMoveRowDown
        '
        Me.MenuMoveRowDown.Image = CType(resources.GetObject("MenuMoveRowDown.Image"), System.Drawing.Image)
        Me.MenuMoveRowDown.Name = "MenuMoveRowDown"
        Me.MenuMoveRowDown.Size = New System.Drawing.Size(143, 22)
        Me.MenuMoveRowDown.Text = "下へ移動(&D)"
        '
        'MenuDeleteRow
        '
        Me.MenuDeleteRow.Image = CType(resources.GetObject("MenuDeleteRow.Image"), System.Drawing.Image)
        Me.MenuDeleteRow.Name = "MenuDeleteRow"
        Me.MenuDeleteRow.Size = New System.Drawing.Size(155, 22)
        Me.MenuDeleteRow.Text = "選択行削除(&D)"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAddColumnLeft, Me.MenuAddColumnRight, Me.MenuAddColumnLast})
        Me.ToolStripMenuItem6.Image = CType(resources.GetObject("ToolStripMenuItem6.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(155, 22)
        Me.ToolStripMenuItem6.Text = "列追加(&C)"
        '
        'MenuAddColumnLeft
        '
        Me.MenuAddColumnLeft.Image = CType(resources.GetObject("MenuAddColumnLeft.Image"), System.Drawing.Image)
        Me.MenuAddColumnLeft.Name = "MenuAddColumnLeft"
        Me.MenuAddColumnLeft.Size = New System.Drawing.Size(153, 22)
        Me.MenuAddColumnLeft.Text = "左へ追加(&L)"
        '
        'MenuAddColumnRight
        '
        Me.MenuAddColumnRight.Image = CType(resources.GetObject("MenuAddColumnRight.Image"), System.Drawing.Image)
        Me.MenuAddColumnRight.Name = "MenuAddColumnRight"
        Me.MenuAddColumnRight.Size = New System.Drawing.Size(153, 22)
        Me.MenuAddColumnRight.Text = "右へ追加(&R)"
        '
        'MenuAddColumnLast
        '
        Me.MenuAddColumnLast.Image = CType(resources.GetObject("MenuAddColumnLast.Image"), System.Drawing.Image)
        Me.MenuAddColumnLast.Name = "MenuAddColumnLast"
        Me.MenuAddColumnLast.Size = New System.Drawing.Size(153, 22)
        Me.MenuAddColumnLast.Text = "最終へ追加(&L)"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuMoveColumnLeft, Me.MenuMoveColumnRight})
        Me.ToolStripMenuItem7.Image = CType(resources.GetObject("ToolStripMenuItem7.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(155, 22)
        Me.ToolStripMenuItem7.Text = "列移動(&V)"
        '
        'MenuMoveColumnLeft
        '
        Me.MenuMoveColumnLeft.Image = CType(resources.GetObject("MenuMoveColumnLeft.Image"), System.Drawing.Image)
        Me.MenuMoveColumnLeft.Name = "MenuMoveColumnLeft"
        Me.MenuMoveColumnLeft.Size = New System.Drawing.Size(142, 22)
        Me.MenuMoveColumnLeft.Text = "左へ移動(&L)"
        '
        'MenuMoveColumnRight
        '
        Me.MenuMoveColumnRight.Image = CType(resources.GetObject("MenuMoveColumnRight.Image"), System.Drawing.Image)
        Me.MenuMoveColumnRight.Name = "MenuMoveColumnRight"
        Me.MenuMoveColumnRight.Size = New System.Drawing.Size(142, 22)
        Me.MenuMoveColumnRight.Text = "右へ移動(&R)"
        '
        'MenuDeleteColumn
        '
        Me.MenuDeleteColumn.Image = CType(resources.GetObject("MenuDeleteColumn.Image"), System.Drawing.Image)
        Me.MenuDeleteColumn.Name = "MenuDeleteColumn"
        Me.MenuDeleteColumn.Size = New System.Drawing.Size(155, 22)
        Me.MenuDeleteColumn.Text = "選択列削除(&T)"
        '
        'EditMenu
        '
        Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PasteToolStripMenuItem, Me.ToolStripSeparator7})
        Me.EditMenu.Name = "EditMenu"
        Me.EditMenu.Size = New System.Drawing.Size(61, 22)
        Me.EditMenu.Text = "編集(&E)"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = CType(resources.GetObject("PasteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.PasteToolStripMenuItem.Text = "貼り付け(&P)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(185, 6)
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuSetting, Me.MenuSetToday2})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(74, 22)
        Me.ToolsMenu.Text = "ツール(&T)"
        '
        'MenuSetting
        '
        Me.MenuSetting.Image = CType(resources.GetObject("MenuSetting.Image"), System.Drawing.Image)
        Me.MenuSetting.Name = "MenuSetting"
        Me.MenuSetting.Size = New System.Drawing.Size(215, 22)
        Me.MenuSetting.Text = "Windy設定(&S)"
        '
        'MenuSetToday2
        '
        Me.MenuSetToday2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuSetTodaySet, Me.MenuSetTodayClear})
        Me.MenuSetToday2.Image = CType(resources.GetObject("MenuSetToday2.Image"), System.Drawing.Image)
        Me.MenuSetToday2.Name = "MenuSetToday2"
        Me.MenuSetToday2.Size = New System.Drawing.Size(215, 22)
        Me.MenuSetToday2.Text = "この位置を本日とする(&H)"
        '
        'MenuSetTodaySet
        '
        Me.MenuSetTodaySet.Name = "MenuSetTodaySet"
        Me.MenuSetTodaySet.Size = New System.Drawing.Size(196, 22)
        Me.MenuSetTodaySet.Text = "この位置を本日とする"
        '
        'MenuSetTodayClear
        '
        Me.MenuSetTodayClear.Name = "MenuSetTodayClear"
        Me.MenuSetTodayClear.Size = New System.Drawing.Size(196, 22)
        Me.MenuSetTodayClear.Text = "補正値をクリアする"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewWindowToolStripMenuItem, Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem, Me.ToolStripSeparator18, Me.MenuSyncScale, Me.MenuAllScreen, Me.MenuToolbarHide, Me.MenuGideNoVisible})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(102, 22)
        Me.WindowsMenu.Text = "ウィンドウ(&W)"
        '
        'NewWindowToolStripMenuItem
        '
        Me.NewWindowToolStripMenuItem.Image = CType(resources.GetObject("NewWindowToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewWindowToolStripMenuItem.Name = "NewWindowToolStripMenuItem"
        Me.NewWindowToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.NewWindowToolStripMenuItem.Text = "新しいウィンドウを開く(&N)"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Image = CType(resources.GetObject("CascadeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.CascadeToolStripMenuItem.Text = "重ねて表示(&C)"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Image = CType(resources.GetObject("TileVerticalToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.TileVerticalToolStripMenuItem.Text = "左右に並べて表示(&V)"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Image = CType(resources.GetObject("TileHorizontalToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "上下に並べて表示(&H)"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Image = CType(resources.GetObject("CloseAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.CloseAllToolStripMenuItem.Text = "すべて閉じる(&L)"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Image = CType(resources.GetObject("ArrangeIconsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "アイコンの整列(&A)"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(289, 6)
        '
        'MenuSyncScale
        '
        Me.MenuSyncScale.Image = CType(resources.GetObject("MenuSyncScale.Image"), System.Drawing.Image)
        Me.MenuSyncScale.Name = "MenuSyncScale"
        Me.MenuSyncScale.Size = New System.Drawing.Size(292, 22)
        Me.MenuSyncScale.Text = "日付間隔・幅を揃える(&F)"
        '
        'MenuAllScreen
        '
        Me.MenuAllScreen.Image = CType(resources.GetObject("MenuAllScreen.Image"), System.Drawing.Image)
        Me.MenuAllScreen.Name = "MenuAllScreen"
        Me.MenuAllScreen.Size = New System.Drawing.Size(292, 22)
        Me.MenuAllScreen.Text = "全画面(&A)"
        '
        'MenuToolbarHide
        '
        Me.MenuToolbarHide.Image = CType(resources.GetObject("MenuToolbarHide.Image"), System.Drawing.Image)
        Me.MenuToolbarHide.Name = "MenuToolbarHide"
        Me.MenuToolbarHide.Size = New System.Drawing.Size(292, 22)
        Me.MenuToolbarHide.Text = "ツールバー表示・非表示"
        '
        'MenuGideNoVisible
        '
        Me.MenuGideNoVisible.Image = CType(resources.GetObject("MenuGideNoVisible.Image"), System.Drawing.Image)
        Me.MenuGideNoVisible.Name = "MenuGideNoVisible"
        Me.MenuGideNoVisible.Size = New System.Drawing.Size(292, 22)
        Me.MenuGideNoVisible.Text = "ファンクションキーガイド表示・非表示"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(75, 22)
        Me.HelpMenu.Text = "ヘルプ(&H)"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Image = CType(resources.GetObject("ContentsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ContentsToolStripMenuItem.Text = "ヘルプ(&H)"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(187, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.AboutToolStripMenuItem.Text = "バージョン情報(&A)..."
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_NewFile, Me.ToolButton_OpenFile, Me.ToolButton_SaveFile, Me.ToolStripSeparator2, Me.ToolButton_Snapshot, Me.ToolButton_Print, Me.ToolStripSeparator3, Me.ToolButton_AddRow, Me.ToolButton_AddCol, Me.ToolButton_DelRow, Me.ToolButton_DelCol, Me.ToolStripSeparator5, Me.ToolButton_ToUp, Me.ToolButton_ToDown, Me.ToolButton_ToLeft, Me.ToolButton_ToRight, Me.ToolButton_HiddenCol, Me.ToolButton_HiddenRow, Me.ToolStripSeparator6, Me.ToolButton_AddLink, Me.ToolButton_AddBalloon, Me.ToolButton_ItemChange, Me.ToolButton_CopyPiece, Me.ToolButton_PastePiece, Me.ToolStripSeparator9, Me.ToolButton_Undo, Me.ToolButton_SheetProperty, Me.ToolButton_ItemScan, Me.ToolButton_ZoomOut, Me.ToolButton_ZoomIn, Me.ToolButton_TimeNarrow, Me.ToolButton_TimeDefault, Me.ToolButton_TimeWide, Me.ToolButton_TopPiace, Me.ToolButton_Front7Day, Me.ToolButton_Today, Me.ToolButton_Back7Day, Me.ToolButton_LastPiace, Me.ToolButton_PeaceWide, Me.ToolButton_PeaceNarrow, Me.ToolStripSeparator10, Me.ToolButton_SpecialTimeSetting, Me.ToolSheetRefresh, Me.ToolButton_ProgressLine})
        Me.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip.Location = New System.Drawing.Point(0, 26)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1364, 39)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolButton_NewFile
        '
        Me.ToolButton_NewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_NewFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_NewFile_Temprate})
        Me.ToolButton_NewFile.Image = CType(resources.GetObject("ToolButton_NewFile.Image"), System.Drawing.Image)
        Me.ToolButton_NewFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_NewFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_NewFile.Name = "ToolButton_NewFile"
        Me.ToolButton_NewFile.Size = New System.Drawing.Size(48, 36)
        Me.ToolButton_NewFile.Text = "新規作成"
        '
        'ToolButton_NewFile_Temprate
        '
        Me.ToolButton_NewFile_Temprate.Image = CType(resources.GetObject("ToolButton_NewFile_Temprate.Image"), System.Drawing.Image)
        Me.ToolButton_NewFile_Temprate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_NewFile_Temprate.Name = "ToolButton_NewFile_Temprate"
        Me.ToolButton_NewFile_Temprate.Size = New System.Drawing.Size(212, 38)
        Me.ToolButton_NewFile_Temprate.Text = "テンプレートファイル"
        '
        'ToolButton_OpenFile
        '
        Me.ToolButton_OpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_OpenFile.Image = CType(resources.GetObject("ToolButton_OpenFile.Image"), System.Drawing.Image)
        Me.ToolButton_OpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_OpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_OpenFile.Name = "ToolButton_OpenFile"
        Me.ToolButton_OpenFile.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_OpenFile.Text = "開く"
        '
        'ToolButton_SaveFile
        '
        Me.ToolButton_SaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_SaveFile.Image = CType(resources.GetObject("ToolButton_SaveFile.Image"), System.Drawing.Image)
        Me.ToolButton_SaveFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_SaveFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_SaveFile.Name = "ToolButton_SaveFile"
        Me.ToolButton_SaveFile.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_SaveFile.Tag = "1"
        Me.ToolButton_SaveFile.Text = "上書き保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolButton_Snapshot
        '
        Me.ToolButton_Snapshot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_Snapshot.Image = CType(resources.GetObject("ToolButton_Snapshot.Image"), System.Drawing.Image)
        Me.ToolButton_Snapshot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_Snapshot.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_Snapshot.Name = "ToolButton_Snapshot"
        Me.ToolButton_Snapshot.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_Snapshot.Text = "スナップショット作成"
        '
        'ToolButton_Print
        '
        Me.ToolButton_Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_Print.Image = CType(resources.GetObject("ToolButton_Print.Image"), System.Drawing.Image)
        Me.ToolButton_Print.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_Print.Name = "ToolButton_Print"
        Me.ToolButton_Print.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_Print.Text = "印刷"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'ToolButton_AddRow
        '
        Me.ToolButton_AddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_AddRow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_AddRow_ToUp, Me.ToolButton_AddRow_ToDown})
        Me.ToolButton_AddRow.Image = CType(resources.GetObject("ToolButton_AddRow.Image"), System.Drawing.Image)
        Me.ToolButton_AddRow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_AddRow.Name = "ToolButton_AddRow"
        Me.ToolButton_AddRow.Size = New System.Drawing.Size(48, 36)
        Me.ToolButton_AddRow.Text = "最下段に行を追加"
        '
        'ToolButton_AddRow_ToUp
        '
        Me.ToolButton_AddRow_ToUp.Image = CType(resources.GetObject("ToolButton_AddRow_ToUp.Image"), System.Drawing.Image)
        Me.ToolButton_AddRow_ToUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_AddRow_ToUp.Name = "ToolButton_AddRow_ToUp"
        Me.ToolButton_AddRow_ToUp.Size = New System.Drawing.Size(164, 38)
        Me.ToolButton_AddRow_ToUp.Text = "上に行を追加"
        '
        'ToolButton_AddRow_ToDown
        '
        Me.ToolButton_AddRow_ToDown.Image = CType(resources.GetObject("ToolButton_AddRow_ToDown.Image"), System.Drawing.Image)
        Me.ToolButton_AddRow_ToDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_AddRow_ToDown.Name = "ToolButton_AddRow_ToDown"
        Me.ToolButton_AddRow_ToDown.Size = New System.Drawing.Size(164, 38)
        Me.ToolButton_AddRow_ToDown.Text = "下に行を追加"
        '
        'ToolButton_AddCol
        '
        Me.ToolButton_AddCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_AddCol.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_AddCol_ToLeft, Me.ToolButton_AddCol_ToRight})
        Me.ToolButton_AddCol.Image = CType(resources.GetObject("ToolButton_AddCol.Image"), System.Drawing.Image)
        Me.ToolButton_AddCol.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_AddCol.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_AddCol.Name = "ToolButton_AddCol"
        Me.ToolButton_AddCol.Size = New System.Drawing.Size(48, 36)
        Me.ToolButton_AddCol.Text = "最右に列を追加"
        '
        'ToolButton_AddCol_ToLeft
        '
        Me.ToolButton_AddCol_ToLeft.Image = CType(resources.GetObject("ToolButton_AddCol_ToLeft.Image"), System.Drawing.Image)
        Me.ToolButton_AddCol_ToLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_AddCol_ToLeft.Name = "ToolButton_AddCol_ToLeft"
        Me.ToolButton_AddCol_ToLeft.Size = New System.Drawing.Size(164, 38)
        Me.ToolButton_AddCol_ToLeft.Text = "左に列を追加"
        '
        'ToolButton_AddCol_ToRight
        '
        Me.ToolButton_AddCol_ToRight.Image = CType(resources.GetObject("ToolButton_AddCol_ToRight.Image"), System.Drawing.Image)
        Me.ToolButton_AddCol_ToRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_AddCol_ToRight.Name = "ToolButton_AddCol_ToRight"
        Me.ToolButton_AddCol_ToRight.Size = New System.Drawing.Size(164, 38)
        Me.ToolButton_AddCol_ToRight.Text = "右に列を追加"
        '
        'ToolButton_DelRow
        '
        Me.ToolButton_DelRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_DelRow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_DelRowEx})
        Me.ToolButton_DelRow.Image = CType(resources.GetObject("ToolButton_DelRow.Image"), System.Drawing.Image)
        Me.ToolButton_DelRow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_DelRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_DelRow.Name = "ToolButton_DelRow"
        Me.ToolButton_DelRow.Size = New System.Drawing.Size(48, 36)
        Me.ToolButton_DelRow.Text = "行削除"
        '
        'ToolButton_DelRowEx
        '
        Me.ToolButton_DelRowEx.Image = CType(resources.GetObject("ToolButton_DelRowEx.Image"), System.Drawing.Image)
        Me.ToolButton_DelRowEx.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_DelRowEx.Name = "ToolButton_DelRowEx"
        Me.ToolButton_DelRowEx.Size = New System.Drawing.Size(140, 38)
        Me.ToolButton_DelRowEx.Text = "拡張削除"
        '
        'ToolButton_DelCol
        '
        Me.ToolButton_DelCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_DelCol.Image = CType(resources.GetObject("ToolButton_DelCol.Image"), System.Drawing.Image)
        Me.ToolButton_DelCol.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_DelCol.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_DelCol.Name = "ToolButton_DelCol"
        Me.ToolButton_DelCol.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_DelCol.Tag = "1"
        Me.ToolButton_DelCol.Text = "列削除"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 39)
        '
        'ToolButton_ToUp
        '
        Me.ToolButton_ToUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_ToUp.Image = CType(resources.GetObject("ToolButton_ToUp.Image"), System.Drawing.Image)
        Me.ToolButton_ToUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_ToUp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_ToUp.Name = "ToolButton_ToUp"
        Me.ToolButton_ToUp.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_ToUp.Tag = "1"
        Me.ToolButton_ToUp.Text = "行を上へ移動"
        '
        'ToolButton_ToDown
        '
        Me.ToolButton_ToDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_ToDown.Image = CType(resources.GetObject("ToolButton_ToDown.Image"), System.Drawing.Image)
        Me.ToolButton_ToDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_ToDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_ToDown.Name = "ToolButton_ToDown"
        Me.ToolButton_ToDown.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_ToDown.Tag = "1"
        Me.ToolButton_ToDown.Text = "行を下へ移動"
        '
        'ToolButton_ToLeft
        '
        Me.ToolButton_ToLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_ToLeft.Image = CType(resources.GetObject("ToolButton_ToLeft.Image"), System.Drawing.Image)
        Me.ToolButton_ToLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_ToLeft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_ToLeft.Name = "ToolButton_ToLeft"
        Me.ToolButton_ToLeft.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_ToLeft.Tag = "1"
        Me.ToolButton_ToLeft.Text = "表列を左へ移動"
        '
        'ToolButton_ToRight
        '
        Me.ToolButton_ToRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_ToRight.Image = CType(resources.GetObject("ToolButton_ToRight.Image"), System.Drawing.Image)
        Me.ToolButton_ToRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_ToRight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_ToRight.Name = "ToolButton_ToRight"
        Me.ToolButton_ToRight.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_ToRight.Tag = "1"
        Me.ToolButton_ToRight.Text = "表列を右へ移動"
        '
        'ToolButton_HiddenCol
        '
        Me.ToolButton_HiddenCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_HiddenCol.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_DisHiddenCol})
        Me.ToolButton_HiddenCol.Image = CType(resources.GetObject("ToolButton_HiddenCol.Image"), System.Drawing.Image)
        Me.ToolButton_HiddenCol.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_HiddenCol.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_HiddenCol.Name = "ToolButton_HiddenCol"
        Me.ToolButton_HiddenCol.Size = New System.Drawing.Size(48, 36)
        Me.ToolButton_HiddenCol.Text = "選択列非表示"
        '
        'ToolButton_DisHiddenCol
        '
        Me.ToolButton_DisHiddenCol.Image = CType(resources.GetObject("ToolButton_DisHiddenCol.Image"), System.Drawing.Image)
        Me.ToolButton_DisHiddenCol.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_DisHiddenCol.Name = "ToolButton_DisHiddenCol"
        Me.ToolButton_DisHiddenCol.Size = New System.Drawing.Size(152, 38)
        Me.ToolButton_DisHiddenCol.Text = "列表示管理"
        '
        'ToolButton_HiddenRow
        '
        Me.ToolButton_HiddenRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_HiddenRow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_HiddenRowTree, Me.ToolStripSeparator17, Me.ToolButton_DisHiddenRow})
        Me.ToolButton_HiddenRow.Image = CType(resources.GetObject("ToolButton_HiddenRow.Image"), System.Drawing.Image)
        Me.ToolButton_HiddenRow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_HiddenRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_HiddenRow.Name = "ToolButton_HiddenRow"
        Me.ToolButton_HiddenRow.Size = New System.Drawing.Size(48, 36)
        Me.ToolButton_HiddenRow.Text = "選択行非表示"
        '
        'ToolButton_HiddenRowTree
        '
        Me.ToolButton_HiddenRowTree.Image = CType(resources.GetObject("ToolButton_HiddenRowTree.Image"), System.Drawing.Image)
        Me.ToolButton_HiddenRowTree.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_HiddenRowTree.Name = "ToolButton_HiddenRowTree"
        Me.ToolButton_HiddenRowTree.Size = New System.Drawing.Size(228, 38)
        Me.ToolButton_HiddenRowTree.Text = "子レベル行 表示・非表示"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(225, 6)
        '
        'ToolButton_DisHiddenRow
        '
        Me.ToolButton_DisHiddenRow.Image = CType(resources.GetObject("ToolButton_DisHiddenRow.Image"), System.Drawing.Image)
        Me.ToolButton_DisHiddenRow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_DisHiddenRow.Name = "ToolButton_DisHiddenRow"
        Me.ToolButton_DisHiddenRow.Size = New System.Drawing.Size(228, 38)
        Me.ToolButton_DisHiddenRow.Text = "行表示管理"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 39)
        '
        'ToolButton_AddLink
        '
        Me.ToolButton_AddLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_AddLink.Image = CType(resources.GetObject("ToolButton_AddLink.Image"), System.Drawing.Image)
        Me.ToolButton_AddLink.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_AddLink.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_AddLink.Name = "ToolButton_AddLink"
        Me.ToolButton_AddLink.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_AddLink.Tag = "1"
        Me.ToolButton_AddLink.Text = "関係線追加"
        '
        'ToolButton_AddBalloon
        '
        Me.ToolButton_AddBalloon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_AddBalloon.Image = CType(resources.GetObject("ToolButton_AddBalloon.Image"), System.Drawing.Image)
        Me.ToolButton_AddBalloon.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_AddBalloon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_AddBalloon.Name = "ToolButton_AddBalloon"
        Me.ToolButton_AddBalloon.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_AddBalloon.Tag = "1"
        Me.ToolButton_AddBalloon.Text = "バルーン追加"
        '
        'ToolButton_ItemChange
        '
        Me.ToolButton_ItemChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_ItemChange.Image = CType(resources.GetObject("ToolButton_ItemChange.Image"), System.Drawing.Image)
        Me.ToolButton_ItemChange.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_ItemChange.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_ItemChange.Name = "ToolButton_ItemChange"
        Me.ToolButton_ItemChange.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_ItemChange.Text = "アイテム変更"
        '
        'ToolButton_CopyPiece
        '
        Me.ToolButton_CopyPiece.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_CopyPiece.Image = CType(resources.GetObject("ToolButton_CopyPiece.Image"), System.Drawing.Image)
        Me.ToolButton_CopyPiece.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_CopyPiece.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_CopyPiece.Name = "ToolButton_CopyPiece"
        Me.ToolButton_CopyPiece.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_CopyPiece.Text = "アイテムコピー"
        '
        'ToolButton_PastePiece
        '
        Me.ToolButton_PastePiece.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_PastePiece.Enabled = False
        Me.ToolButton_PastePiece.Image = CType(resources.GetObject("ToolButton_PastePiece.Image"), System.Drawing.Image)
        Me.ToolButton_PastePiece.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_PastePiece.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_PastePiece.Name = "ToolButton_PastePiece"
        Me.ToolButton_PastePiece.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_PastePiece.Text = "アイテム貼付"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 39)
        '
        'ToolButton_Undo
        '
        Me.ToolButton_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_Undo.Enabled = False
        Me.ToolButton_Undo.Image = CType(resources.GetObject("ToolButton_Undo.Image"), System.Drawing.Image)
        Me.ToolButton_Undo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_Undo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_Undo.Name = "ToolButton_Undo"
        Me.ToolButton_Undo.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_Undo.Text = "元に戻す"
        '
        'ToolButton_SheetProperty
        '
        Me.ToolButton_SheetProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_SheetProperty.Image = CType(resources.GetObject("ToolButton_SheetProperty.Image"), System.Drawing.Image)
        Me.ToolButton_SheetProperty.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_SheetProperty.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_SheetProperty.Name = "ToolButton_SheetProperty"
        Me.ToolButton_SheetProperty.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_SheetProperty.Tag = "1"
        Me.ToolButton_SheetProperty.Text = "シートプロパティ"
        '
        'ToolButton_ItemScan
        '
        Me.ToolButton_ItemScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_ItemScan.Image = CType(resources.GetObject("ToolButton_ItemScan.Image"), System.Drawing.Image)
        Me.ToolButton_ItemScan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_ItemScan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_ItemScan.Name = "ToolButton_ItemScan"
        Me.ToolButton_ItemScan.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_ItemScan.Text = "アイテム検索"
        '
        'ToolButton_ZoomOut
        '
        Me.ToolButton_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_ZoomOut.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_ZoomOut_2Day, Me.ToolButton_ZoomOut_5Day, Me.ToolButton_ZoomOut_Week})
        Me.ToolButton_ZoomOut.Image = CType(resources.GetObject("ToolButton_ZoomOut.Image"), System.Drawing.Image)
        Me.ToolButton_ZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_ZoomOut.Name = "ToolButton_ZoomOut"
        Me.ToolButton_ZoomOut.Size = New System.Drawing.Size(48, 36)
        Me.ToolButton_ZoomOut.Text = "日付間隔縮小"
        '
        'ToolButton_ZoomOut_2Day
        '
        Me.ToolButton_ZoomOut_2Day.Name = "ToolButton_ZoomOut_2Day"
        Me.ToolButton_ZoomOut_2Day.Size = New System.Drawing.Size(136, 22)
        Me.ToolButton_ZoomOut_2Day.Text = "２日ごと"
        '
        'ToolButton_ZoomOut_5Day
        '
        Me.ToolButton_ZoomOut_5Day.Name = "ToolButton_ZoomOut_5Day"
        Me.ToolButton_ZoomOut_5Day.Size = New System.Drawing.Size(136, 22)
        Me.ToolButton_ZoomOut_5Day.Text = "５日ごと"
        '
        'ToolButton_ZoomOut_Week
        '
        Me.ToolButton_ZoomOut_Week.Name = "ToolButton_ZoomOut_Week"
        Me.ToolButton_ZoomOut_Week.Size = New System.Drawing.Size(136, 22)
        Me.ToolButton_ZoomOut_Week.Text = "１週間ごと"
        '
        'ToolButton_ZoomIn
        '
        Me.ToolButton_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_ZoomIn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_ZoomIn_1Day})
        Me.ToolButton_ZoomIn.Image = CType(resources.GetObject("ToolButton_ZoomIn.Image"), System.Drawing.Image)
        Me.ToolButton_ZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_ZoomIn.Name = "ToolButton_ZoomIn"
        Me.ToolButton_ZoomIn.Size = New System.Drawing.Size(48, 36)
        Me.ToolButton_ZoomIn.Text = "日付間隔拡大"
        '
        'ToolButton_ZoomIn_1Day
        '
        Me.ToolButton_ZoomIn_1Day.Name = "ToolButton_ZoomIn_1Day"
        Me.ToolButton_ZoomIn_1Day.Size = New System.Drawing.Size(124, 22)
        Me.ToolButton_ZoomIn_1Day.Text = "１日ごと"
        '
        'ToolButton_TimeNarrow
        '
        Me.ToolButton_TimeNarrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_TimeNarrow.Image = CType(resources.GetObject("ToolButton_TimeNarrow.Image"), System.Drawing.Image)
        Me.ToolButton_TimeNarrow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_TimeNarrow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_TimeNarrow.Name = "ToolButton_TimeNarrow"
        Me.ToolButton_TimeNarrow.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_TimeNarrow.Text = "日付幅縮小"
        '
        'ToolButton_TimeDefault
        '
        Me.ToolButton_TimeDefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_TimeDefault.Image = CType(resources.GetObject("ToolButton_TimeDefault.Image"), System.Drawing.Image)
        Me.ToolButton_TimeDefault.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_TimeDefault.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_TimeDefault.Name = "ToolButton_TimeDefault"
        Me.ToolButton_TimeDefault.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_TimeDefault.Text = "日付幅標準に戻す"
        '
        'ToolButton_TimeWide
        '
        Me.ToolButton_TimeWide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_TimeWide.Image = CType(resources.GetObject("ToolButton_TimeWide.Image"), System.Drawing.Image)
        Me.ToolButton_TimeWide.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_TimeWide.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_TimeWide.Name = "ToolButton_TimeWide"
        Me.ToolButton_TimeWide.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_TimeWide.Text = "日付幅拡大"
        '
        'ToolButton_TopPiace
        '
        Me.ToolButton_TopPiace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_TopPiace.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_TopPiace_Row})
        Me.ToolButton_TopPiace.Image = CType(resources.GetObject("ToolButton_TopPiace.Image"), System.Drawing.Image)
        Me.ToolButton_TopPiace.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_TopPiace.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_TopPiace.Name = "ToolButton_TopPiace"
        Me.ToolButton_TopPiace.Size = New System.Drawing.Size(48, 36)
        Me.ToolButton_TopPiace.Text = "全体先頭へ"
        '
        'ToolButton_TopPiace_Row
        '
        Me.ToolButton_TopPiace_Row.Image = CType(resources.GetObject("ToolButton_TopPiace_Row.Image"), System.Drawing.Image)
        Me.ToolButton_TopPiace_Row.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_TopPiace_Row.Name = "ToolButton_TopPiace_Row"
        Me.ToolButton_TopPiace_Row.Size = New System.Drawing.Size(188, 38)
        Me.ToolButton_TopPiace_Row.Text = "選択行の先頭日へ"
        '
        'ToolButton_Front7Day
        '
        Me.ToolButton_Front7Day.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_Front7Day.Image = CType(resources.GetObject("ToolButton_Front7Day.Image"), System.Drawing.Image)
        Me.ToolButton_Front7Day.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_Front7Day.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_Front7Day.Name = "ToolButton_Front7Day"
        Me.ToolButton_Front7Day.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_Front7Day.Text = "７日前へ移動"
        '
        'ToolButton_Today
        '
        Me.ToolButton_Today.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_Today.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_SaveDate, Me.ToolButton_SelDate})
        Me.ToolButton_Today.Image = CType(resources.GetObject("ToolButton_Today.Image"), System.Drawing.Image)
        Me.ToolButton_Today.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_Today.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_Today.Name = "ToolButton_Today"
        Me.ToolButton_Today.Size = New System.Drawing.Size(48, 36)
        Me.ToolButton_Today.Text = "今日へ移動"
        '
        'ToolButton_SaveDate
        '
        Me.ToolButton_SaveDate.Image = CType(resources.GetObject("ToolButton_SaveDate.Image"), System.Drawing.Image)
        Me.ToolButton_SaveDate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_SaveDate.Name = "ToolButton_SaveDate"
        Me.ToolButton_SaveDate.Size = New System.Drawing.Size(200, 38)
        Me.ToolButton_SaveDate.Text = "保存時の表示日付へ"
        '
        'ToolButton_SelDate
        '
        Me.ToolButton_SelDate.Image = CType(resources.GetObject("ToolButton_SelDate.Image"), System.Drawing.Image)
        Me.ToolButton_SelDate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_SelDate.Name = "ToolButton_SelDate"
        Me.ToolButton_SelDate.Size = New System.Drawing.Size(200, 38)
        Me.ToolButton_SelDate.Text = "指定日付へ"
        '
        'ToolButton_Back7Day
        '
        Me.ToolButton_Back7Day.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_Back7Day.Image = CType(resources.GetObject("ToolButton_Back7Day.Image"), System.Drawing.Image)
        Me.ToolButton_Back7Day.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_Back7Day.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_Back7Day.Name = "ToolButton_Back7Day"
        Me.ToolButton_Back7Day.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_Back7Day.Text = "７日後へ移動"
        '
        'ToolButton_LastPiace
        '
        Me.ToolButton_LastPiace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_LastPiace.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton_LastPiace_Row})
        Me.ToolButton_LastPiace.Image = CType(resources.GetObject("ToolButton_LastPiace.Image"), System.Drawing.Image)
        Me.ToolButton_LastPiace.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_LastPiace.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_LastPiace.Name = "ToolButton_LastPiace"
        Me.ToolButton_LastPiace.Size = New System.Drawing.Size(48, 36)
        Me.ToolButton_LastPiace.Text = "全体最終日へ"
        '
        'ToolButton_LastPiace_Row
        '
        Me.ToolButton_LastPiace_Row.Image = CType(resources.GetObject("ToolButton_LastPiace_Row.Image"), System.Drawing.Image)
        Me.ToolButton_LastPiace_Row.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_LastPiace_Row.Name = "ToolButton_LastPiace_Row"
        Me.ToolButton_LastPiace_Row.Size = New System.Drawing.Size(200, 38)
        Me.ToolButton_LastPiace_Row.Text = "選択行の再最終日へ"
        '
        'ToolButton_PeaceWide
        '
        Me.ToolButton_PeaceWide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_PeaceWide.Image = CType(resources.GetObject("ToolButton_PeaceWide.Image"), System.Drawing.Image)
        Me.ToolButton_PeaceWide.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_PeaceWide.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_PeaceWide.Name = "ToolButton_PeaceWide"
        Me.ToolButton_PeaceWide.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_PeaceWide.Text = "ピース拡大"
        '
        'ToolButton_PeaceNarrow
        '
        Me.ToolButton_PeaceNarrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_PeaceNarrow.Image = CType(resources.GetObject("ToolButton_PeaceNarrow.Image"), System.Drawing.Image)
        Me.ToolButton_PeaceNarrow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_PeaceNarrow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_PeaceNarrow.Name = "ToolButton_PeaceNarrow"
        Me.ToolButton_PeaceNarrow.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_PeaceNarrow.Text = "ピース縮小"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 39)
        '
        'ToolButton_SpecialTimeSetting
        '
        Me.ToolButton_SpecialTimeSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_SpecialTimeSetting.Image = CType(resources.GetObject("ToolButton_SpecialTimeSetting.Image"), System.Drawing.Image)
        Me.ToolButton_SpecialTimeSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_SpecialTimeSetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_SpecialTimeSetting.Name = "ToolButton_SpecialTimeSetting"
        Me.ToolButton_SpecialTimeSetting.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_SpecialTimeSetting.Tag = "1"
        Me.ToolButton_SpecialTimeSetting.Text = "特別期間設定"
        '
        'ToolSheetRefresh
        '
        Me.ToolSheetRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolSheetRefresh.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolSheetReload})
        Me.ToolSheetRefresh.Image = CType(resources.GetObject("ToolSheetRefresh.Image"), System.Drawing.Image)
        Me.ToolSheetRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolSheetRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSheetRefresh.Name = "ToolSheetRefresh"
        Me.ToolSheetRefresh.Size = New System.Drawing.Size(48, 36)
        Me.ToolSheetRefresh.Text = "シートリフレッシュ"
        '
        'ToolSheetReload
        '
        Me.ToolSheetReload.Image = CType(resources.GetObject("ToolSheetReload.Image"), System.Drawing.Image)
        Me.ToolSheetReload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolSheetReload.Name = "ToolSheetReload"
        Me.ToolSheetReload.Size = New System.Drawing.Size(176, 38)
        Me.ToolSheetReload.Text = "データリロード"
        '
        'ToolButton_ProgressLine
        '
        Me.ToolButton_ProgressLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolButton_ProgressLine.Image = CType(resources.GetObject("ToolButton_ProgressLine.Image"), System.Drawing.Image)
        Me.ToolButton_ProgressLine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolButton_ProgressLine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton_ProgressLine.Name = "ToolButton_ProgressLine"
        Me.ToolButton_ProgressLine.Size = New System.Drawing.Size(36, 36)
        Me.ToolButton_ProgressLine.Text = "稲妻線表示・非表示"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblMessage, Me.ToolStripStatusLabel2, Me.LblSpecialTime, Me.ToolStripStatusLabel4, Me.LblItemObject, Me.ToolStripStatusLabel6, Me.LblOwner, Me.ToolStripStatusLabel8, Me.LblToday, Me.ToolStripStatusLabel1, Me.LblTempLock, Me.ToolStripStatusLabel10, Me.LblRendou, Me.ToolStripStatusLabel3, Me.LblTabletMode, Me.LblUndoLevel, Me.LblLockFile, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel11})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 629)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1364, 23)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'LblMessage
        '
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(753, 18)
        Me.LblMessage.Spring = True
        Me.LblMessage.Text = "状態"
        Me.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(20, 18)
        Me.ToolStripStatusLabel2.Text = "｜"
        '
        'LblSpecialTime
        '
        Me.LblSpecialTime.Name = "LblSpecialTime"
        Me.LblSpecialTime.Size = New System.Drawing.Size(68, 18)
        Me.LblSpecialTime.Text = "特別期間："
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(20, 18)
        Me.ToolStripStatusLabel4.Text = "｜"
        '
        'LblItemObject
        '
        Me.LblItemObject.Name = "LblItemObject"
        Me.LblItemObject.Size = New System.Drawing.Size(68, 18)
        Me.LblItemObject.Text = "アイテム："
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(20, 18)
        Me.ToolStripStatusLabel6.Text = "｜"
        '
        'LblOwner
        '
        Me.LblOwner.Name = "LblOwner"
        Me.LblOwner.Size = New System.Drawing.Size(56, 18)
        Me.LblOwner.Text = "制作者："
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(20, 18)
        Me.ToolStripStatusLabel8.Text = "｜"
        '
        'LblToday
        '
        Me.LblToday.Name = "LblToday"
        Me.LblToday.Size = New System.Drawing.Size(20, 18)
        Me.LblToday.Text = "．"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(20, 18)
        Me.ToolStripStatusLabel1.Text = "｜"
        '
        'LblTempLock
        '
        Me.LblTempLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LblTempLock.Image = Global.Windy2.My.Resources.Resources.lock_open_16
        Me.LblTempLock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LblTempLock.Name = "LblTempLock"
        Me.LblTempLock.Size = New System.Drawing.Size(16, 18)
        Me.LblTempLock.Text = "一時ピースロック"
        Me.LblTempLock.ToolTipText = "一時ピースロック"
        '
        'ToolStripStatusLabel10
        '
        Me.ToolStripStatusLabel10.Name = "ToolStripStatusLabel10"
        Me.ToolStripStatusLabel10.Size = New System.Drawing.Size(20, 18)
        Me.ToolStripStatusLabel10.Text = "｜"
        '
        'LblRendou
        '
        Me.LblRendou.IsLink = True
        Me.LblRendou.Name = "LblRendou"
        Me.LblRendou.Size = New System.Drawing.Size(18, 18)
        Me.LblRendou.Text = "--"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(20, 18)
        Me.ToolStripStatusLabel3.Text = "｜"
        '
        'LblTabletMode
        '
        Me.LblTabletMode.Image = Global.Windy2.My.Resources.Resources.terminal
        Me.LblTabletMode.Name = "LblTabletMode"
        Me.LblTabletMode.Size = New System.Drawing.Size(16, 18)
        '
        'LblUndoLevel
        '
        Me.LblUndoLevel.Name = "LblUndoLevel"
        Me.LblUndoLevel.Size = New System.Drawing.Size(12, 18)
        Me.LblUndoLevel.Text = "."
        '
        'LblLockFile
        '
        Me.LblLockFile.Name = "LblLockFile"
        Me.LblLockFile.Size = New System.Drawing.Size(12, 18)
        Me.LblLockFile.Text = "."
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(20, 18)
        Me.ToolStripStatusLabel5.Text = "｜"
        '
        'ToolStripStatusLabel11
        '
        Me.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11"
        Me.ToolStripStatusLabel11.Size = New System.Drawing.Size(150, 18)
        Me.ToolStripStatusLabel11.Text = "[Alt]+{←][→]：時間移動"
        '
        'LblF11
        '
        Me.LblF11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF11.Location = New System.Drawing.Point(1136, 4)
        Me.LblF11.Name = "LblF11"
        Me.LblF11.Size = New System.Drawing.Size(110, 24)
        Me.LblF11.TabIndex = 0
        Me.LblF11.Text = "F11：全画面"
        Me.LblF11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.LblF11, "Windyを全画面に切り替えます")
        '
        'LblF10
        '
        Me.LblF10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF10.Location = New System.Drawing.Point(1024, 4)
        Me.LblF10.Name = "LblF10"
        Me.LblF10.Size = New System.Drawing.Size(108, 24)
        Me.LblF10.TabIndex = 0
        Me.LblF10.Tag = "1"
        Me.LblF10.Text = "F10：Item移動(下)"
        Me.LblF10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.LblF10, "選択アイテムを１つ下の行に移動させます")
        '
        'LblF9
        '
        Me.LblF9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF9.Location = New System.Drawing.Point(909, 4)
        Me.LblF9.Name = "LblF9"
        Me.LblF9.Size = New System.Drawing.Size(111, 24)
        Me.LblF9.TabIndex = 0
        Me.LblF9.Tag = "1"
        Me.LblF9.Text = "F9：Item移動(上)"
        Me.LblF9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.LblF9, "選択アイテムを１つ上の行に移動させます")
        '
        'LblF8
        '
        Me.LblF8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF8.Location = New System.Drawing.Point(795, 4)
        Me.LblF8.Name = "LblF8"
        Me.LblF8.Size = New System.Drawing.Size(110, 24)
        Me.LblF8.TabIndex = 0
        Me.LblF8.Tag = "1"
        Me.LblF8.Text = "F8：行移動(下)"
        Me.LblF8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.LblF8, "選択行を１つ下に移動させます")
        '
        'LblF7
        '
        Me.LblF7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF7.Location = New System.Drawing.Point(683, 4)
        Me.LblF7.Name = "LblF7"
        Me.LblF7.Size = New System.Drawing.Size(108, 24)
        Me.LblF7.TabIndex = 0
        Me.LblF7.Tag = "1"
        Me.LblF7.Text = "F７：行移動(上)"
        Me.LblF7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.LblF7, "選択行を１つ上に移動させます")
        '
        'LblF6
        '
        Me.LblF6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF6.Location = New System.Drawing.Point(570, 4)
        Me.LblF6.Name = "LblF6"
        Me.LblF6.Size = New System.Drawing.Size(109, 24)
        Me.LblF6.TabIndex = 0
        Me.LblF6.Text = "F6：リロード"
        Me.LblF6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.LblF6, "シートを再読み込みします")
        '
        'LblF5
        '
        Me.LblF5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF5.Location = New System.Drawing.Point(456, 4)
        Me.LblF5.Name = "LblF5"
        Me.LblF5.Size = New System.Drawing.Size(110, 24)
        Me.LblF5.TabIndex = 0
        Me.LblF5.Text = "F5：リフレッシュ"
        Me.LblF5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.LblF5, "シートをリフレッシュします")
        '
        'LblF4
        '
        Me.LblF4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF4.Location = New System.Drawing.Point(343, 4)
        Me.LblF4.Name = "LblF4"
        Me.LblF4.Size = New System.Drawing.Size(109, 24)
        Me.LblF4.TabIndex = 0
        Me.LblF4.Text = "F4：アイテム検索"
        Me.LblF4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.LblF4, "アイテムを検索します")
        '
        'LblF3
        '
        Me.LblF3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF3.Location = New System.Drawing.Point(230, 4)
        Me.LblF3.Name = "LblF3"
        Me.LblF3.Size = New System.Drawing.Size(109, 24)
        Me.LblF3.TabIndex = 0
        Me.LblF3.Tag = "1"
        Me.LblF3.Text = "F3：アイテムコピー"
        Me.LblF3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.LblF3, "選択アイテムをコピーし同行に追加します")
        '
        'LblF2
        '
        Me.LblF2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF2.Location = New System.Drawing.Point(117, 4)
        Me.LblF2.Name = "LblF2"
        Me.LblF2.Size = New System.Drawing.Size(109, 24)
        Me.LblF2.TabIndex = 0
        Me.LblF2.Text = "F2：保存"
        Me.LblF2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.LblF2, "シートを保存します")
        '
        'LblF1
        '
        Me.LblF1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF1.Location = New System.Drawing.Point(4, 4)
        Me.LblF1.Name = "LblF1"
        Me.LblF1.Size = New System.Drawing.Size(109, 24)
        Me.LblF1.TabIndex = 0
        Me.LblF1.Text = "F1：ヘルプ"
        Me.LblF1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.LblF1, "ヘルプを表示します")
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "flag.png")
        Me.ImageList.Images.SetKeyName(1, "chain--plus.png")
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.C1Sizer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 597)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1364, 32)
        Me.Panel1.TabIndex = 9
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.LblF12)
        Me.C1Sizer1.Controls.Add(Me.LblF11)
        Me.C1Sizer1.Controls.Add(Me.LblF10)
        Me.C1Sizer1.Controls.Add(Me.LblF9)
        Me.C1Sizer1.Controls.Add(Me.LblF8)
        Me.C1Sizer1.Controls.Add(Me.LblF7)
        Me.C1Sizer1.Controls.Add(Me.LblF6)
        Me.C1Sizer1.Controls.Add(Me.LblF5)
        Me.C1Sizer1.Controls.Add(Me.LblF4)
        Me.C1Sizer1.Controls.Add(Me.LblF3)
        Me.C1Sizer1.Controls.Add(Me.LblF2)
        Me.C1Sizer1.Controls.Add(Me.LblF1)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(1364, 32)
        Me.C1Sizer1.TabIndex = 0
        Me.C1Sizer1.Text = "C1Sizer1"
        '
        'LblF12
        '
        Me.LblF12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblF12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblF12.Location = New System.Drawing.Point(1250, 4)
        Me.LblF12.Name = "LblF12"
        Me.LblF12.Size = New System.Drawing.Size(110, 24)
        Me.LblF12.TabIndex = 0
        Me.LblF12.Text = "F12：プロパティ"
        Me.LblF12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmParent
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 652)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.MinimumSize = New System.Drawing.Size(298, 273)
        Me.Name = "FrmParent"
        Me.Text = "Windy2(ガントチャーター)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuProperty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuSet1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSet0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSaveFileAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuNewFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuOpenFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSaveFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents EditMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSet2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSet3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSet4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSet5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuZoomIn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuZoomOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPeaceWide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPeaceNarrow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuFront7Day As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuTopPiace As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuToday As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuLastPiace As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBack7Day As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSheetReflesh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAddRowUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAddRowDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAddRowLast As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMoveRowUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMoveRowDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuDeleteRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAddColumnLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAddColumnRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAddColumnLast As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMoveColumnLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMoveColumnRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuDeleteColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSetting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSetToday2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblSpecialTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblItemObject As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblOwner As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblToday As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel10 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel11 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents ToolButton_OpenFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_SaveFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_DelCol As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_ToUp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_ToDown As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_ToLeft As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_ToRight As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_AddLink As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_AddBalloon As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_SheetProperty As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_Front7Day As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_Back7Day As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_PeaceWide As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_PeaceNarrow As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_SpecialTimeSetting As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolButton_ProgressLine As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_TimeNarrow As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_TimeWide As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_TimeDefault As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_Snapshot As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuSnapshot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuDataExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuTimeNarrow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuTimeWide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuTimeDefault As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuDataExport_Grid As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuDataExport_XML As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSheetSync As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSyncScale As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemScan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_ItemScan As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuSetTodaySet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSetTodayClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuImport_CSV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuImport_Clip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuImport_Windy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolSheetRefresh As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolSheetReload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuReload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAllScreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents LblF12 As System.Windows.Forms.Label
    Friend WithEvents LblF11 As System.Windows.Forms.Label
    Friend WithEvents LblF10 As System.Windows.Forms.Label
    Friend WithEvents LblF9 As System.Windows.Forms.Label
    Friend WithEvents LblF8 As System.Windows.Forms.Label
    Friend WithEvents LblF7 As System.Windows.Forms.Label
    Friend WithEvents LblF6 As System.Windows.Forms.Label
    Friend WithEvents LblF5 As System.Windows.Forms.Label
    Friend WithEvents LblF4 As System.Windows.Forms.Label
    Friend WithEvents LblF3 As System.Windows.Forms.Label
    Friend WithEvents LblF2 As System.Windows.Forms.Label
    Friend WithEvents LblF1 As System.Windows.Forms.Label
    Friend WithEvents MenuGideNoVisible As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblRendou As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LblTempLock As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolButton_ZoomOut As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolButton_ZoomOut_2Day As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_ZoomOut_5Day As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_ZoomOut_Week As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_ZoomIn As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolButton_ZoomIn_1Day As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_TopPiace As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolButton_LastPiace As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolButton_TopPiace_Row As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_LastPiace_Row As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_Today As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolButton_SaveDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_SelDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblTabletMode As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolButton_Undo As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblUndoLevel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolButton_CopyPiece As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_PastePiece As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_ItemChange As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolButton_HiddenRow As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolButton_HiddenRowTree As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_DisHiddenRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolButton_HiddenCol As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolButton_DisHiddenCol As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblLockFile As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolButton_DelRow As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolButton_DelRowEx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuToolbarHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolButton_AddRow As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolButton_AddCol As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolButton_AddRow_ToUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_AddRow_ToDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_AddCol_ToLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_AddCol_ToRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_NewFile As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents Menu_NewFile_Temprate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolButton_NewFile_Temprate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuSaveFileAll As System.Windows.Forms.ToolStripMenuItem

End Class
