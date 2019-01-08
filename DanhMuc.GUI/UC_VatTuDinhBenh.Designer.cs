namespace DanhMuc.GUI
{
    partial class UC_VatTuDinhBenh
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_VatTuDinhBenh));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlDinhBenh = new DevExpress.XtraGrid.GridControl();
            this.gridViewDinhBenh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repbtnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.MaBenh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenBenh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlVatTu = new DevExpress.XtraGrid.GridControl();
            this.gridViewVatTu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaBV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaHoatChat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoatChat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HamLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpLoaiVatTu = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpDinhBenh = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaBenhLookUp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenBenhLookUp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDinhBenh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDinhBenh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repbtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpLoaiVatTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDinhBenh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.gridControlDinhBenh);
            this.layoutControl.Controls.Add(this.btnThem);
            this.layoutControl.Controls.Add(this.gridControlVatTu);
            this.layoutControl.Controls.Add(this.lookUpLoaiVatTu);
            this.layoutControl.Controls.Add(this.lookUpDinhBenh);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(700, 400);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // gridControlDinhBenh
            // 
            this.gridControlDinhBenh.Location = new System.Drawing.Point(12, 267);
            this.gridControlDinhBenh.MainView = this.gridViewDinhBenh;
            this.gridControlDinhBenh.Name = "gridControlDinhBenh";
            this.gridControlDinhBenh.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repbtnDelete});
            this.gridControlDinhBenh.Size = new System.Drawing.Size(676, 121);
            this.gridControlDinhBenh.TabIndex = 8;
            this.gridControlDinhBenh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDinhBenh});
            // 
            // gridViewDinhBenh
            // 
            this.gridViewDinhBenh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Delete,
            this.MaBenh,
            this.TenBenh});
            this.gridViewDinhBenh.GridControl = this.gridControlDinhBenh;
            this.gridViewDinhBenh.Name = "gridViewDinhBenh";
            this.gridViewDinhBenh.OptionsView.ShowGroupPanel = false;
            // 
            // Delete
            // 
            this.Delete.Caption = "#";
            this.Delete.ColumnEdit = this.repbtnDelete;
            this.Delete.Name = "Delete";
            this.Delete.Visible = true;
            this.Delete.VisibleIndex = 0;
            this.Delete.Width = 30;
            // 
            // repbtnDelete
            // 
            this.repbtnDelete.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repbtnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repbtnDelete.Name = "repbtnDelete";
            this.repbtnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repbtnDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repbtnDelete_ButtonClick);
            // 
            // MaBenh
            // 
            this.MaBenh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaBenh.AppearanceCell.Options.UseFont = true;
            this.MaBenh.Caption = "Mã Bệnh";
            this.MaBenh.FieldName = "MaBenh";
            this.MaBenh.Name = "MaBenh";
            this.MaBenh.OptionsColumn.AllowEdit = false;
            this.MaBenh.Visible = true;
            this.MaBenh.VisibleIndex = 1;
            this.MaBenh.Width = 65;
            // 
            // TenBenh
            // 
            this.TenBenh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenBenh.AppearanceCell.Options.UseFont = true;
            this.TenBenh.Caption = "Tên Bệnh";
            this.TenBenh.FieldName = "TenBenh";
            this.TenBenh.Name = "TenBenh";
            this.TenBenh.OptionsColumn.AllowEdit = false;
            this.TenBenh.Visible = true;
            this.TenBenh.VisibleIndex = 2;
            this.TenBenh.Width = 563;
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.Location = new System.Drawing.Point(627, 240);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(61, 23);
            this.btnThem.StyleController = this.layoutControl;
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // gridControlVatTu
            // 
            this.gridControlVatTu.Location = new System.Drawing.Point(12, 38);
            this.gridControlVatTu.MainView = this.gridViewVatTu;
            this.gridControlVatTu.Name = "gridControlVatTu";
            this.gridControlVatTu.Size = new System.Drawing.Size(676, 198);
            this.gridControlVatTu.TabIndex = 5;
            this.gridControlVatTu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewVatTu});
            // 
            // gridViewVatTu
            // 
            this.gridViewVatTu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaBV,
            this.MaHoatChat,
            this.HoatChat,
            this.HamLuong,
            this.TenVatTu,
            this.DonViTinh,
            this.GiaBHYT});
            this.gridViewVatTu.GridControl = this.gridControlVatTu;
            this.gridViewVatTu.Name = "gridViewVatTu";
            this.gridViewVatTu.OptionsFind.AlwaysVisible = true;
            this.gridViewVatTu.OptionsView.ShowAutoFilterRow = true;
            this.gridViewVatTu.OptionsView.ShowGroupPanel = false;
            this.gridViewVatTu.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewVatTu_RowClick);
            // 
            // MaBV
            // 
            this.MaBV.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaBV.AppearanceCell.Options.UseFont = true;
            this.MaBV.Caption = "Mã";
            this.MaBV.FieldName = "MaBV";
            this.MaBV.Name = "MaBV";
            this.MaBV.OptionsColumn.AllowEdit = false;
            this.MaBV.Visible = true;
            this.MaBV.VisibleIndex = 0;
            this.MaBV.Width = 50;
            // 
            // MaHoatChat
            // 
            this.MaHoatChat.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaHoatChat.AppearanceCell.Options.UseFont = true;
            this.MaHoatChat.Caption = "Mã Hoạt Chất";
            this.MaHoatChat.FieldName = "MaHoatChat";
            this.MaHoatChat.Name = "MaHoatChat";
            this.MaHoatChat.OptionsColumn.AllowEdit = false;
            this.MaHoatChat.Visible = true;
            this.MaHoatChat.VisibleIndex = 1;
            this.MaHoatChat.Width = 50;
            // 
            // HoatChat
            // 
            this.HoatChat.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoatChat.AppearanceCell.Options.UseFont = true;
            this.HoatChat.Caption = "Hoạt Chất";
            this.HoatChat.FieldName = "HoatChat";
            this.HoatChat.Name = "HoatChat";
            this.HoatChat.OptionsColumn.AllowEdit = false;
            this.HoatChat.Visible = true;
            this.HoatChat.VisibleIndex = 2;
            this.HoatChat.Width = 170;
            // 
            // HamLuong
            // 
            this.HamLuong.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HamLuong.AppearanceCell.Options.UseFont = true;
            this.HamLuong.Caption = "Hàm Lượng";
            this.HamLuong.FieldName = "HamLuong";
            this.HamLuong.Name = "HamLuong";
            this.HamLuong.OptionsColumn.AllowEdit = false;
            this.HamLuong.Visible = true;
            this.HamLuong.VisibleIndex = 3;
            this.HamLuong.Width = 150;
            // 
            // TenVatTu
            // 
            this.TenVatTu.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenVatTu.AppearanceCell.Options.UseFont = true;
            this.TenVatTu.Caption = "Tên Vật Tư";
            this.TenVatTu.FieldName = "TenVatTu";
            this.TenVatTu.Name = "TenVatTu";
            this.TenVatTu.OptionsColumn.AllowEdit = false;
            this.TenVatTu.Visible = true;
            this.TenVatTu.VisibleIndex = 4;
            this.TenVatTu.Width = 170;
            // 
            // DonViTinh
            // 
            this.DonViTinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonViTinh.AppearanceCell.Options.UseFont = true;
            this.DonViTinh.Caption = "Đơn Vị Tính";
            this.DonViTinh.FieldName = "DonViTinh";
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.OptionsColumn.AllowEdit = false;
            this.DonViTinh.Visible = true;
            this.DonViTinh.VisibleIndex = 5;
            this.DonViTinh.Width = 30;
            // 
            // GiaBHYT
            // 
            this.GiaBHYT.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GiaBHYT.AppearanceCell.Options.UseFont = true;
            this.GiaBHYT.Caption = "Giá BHYT";
            this.GiaBHYT.DisplayFormat.FormatString = "#,###";
            this.GiaBHYT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.GiaBHYT.FieldName = "GiaBHYT";
            this.GiaBHYT.Name = "GiaBHYT";
            this.GiaBHYT.OptionsColumn.AllowEdit = false;
            this.GiaBHYT.Visible = true;
            this.GiaBHYT.VisibleIndex = 6;
            this.GiaBHYT.Width = 38;
            // 
            // lookUpLoaiVatTu
            // 
            this.lookUpLoaiVatTu.Location = new System.Drawing.Point(71, 12);
            this.lookUpLoaiVatTu.Name = "lookUpLoaiVatTu";
            this.lookUpLoaiVatTu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpLoaiVatTu.Properties.Appearance.Options.UseFont = true;
            this.lookUpLoaiVatTu.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpLoaiVatTu.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookUpLoaiVatTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpLoaiVatTu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Tên", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpLoaiVatTu.Properties.NullText = "";
            this.lookUpLoaiVatTu.Size = new System.Drawing.Size(372, 22);
            this.lookUpLoaiVatTu.StyleController = this.layoutControl;
            this.lookUpLoaiVatTu.TabIndex = 4;
            this.lookUpLoaiVatTu.EditValueChanged += new System.EventHandler(this.lookUpLoaiVatTu_EditValueChanged);
            // 
            // lookUpDinhBenh
            // 
            this.lookUpDinhBenh.Location = new System.Drawing.Point(71, 240);
            this.lookUpDinhBenh.Name = "lookUpDinhBenh";
            this.lookUpDinhBenh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpDinhBenh.Properties.Appearance.Options.UseFont = true;
            this.lookUpDinhBenh.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpDinhBenh.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookUpDinhBenh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDinhBenh.Properties.NullText = "";
            this.lookUpDinhBenh.Properties.PopupView = this.searchLookUpEdit1View;
            this.lookUpDinhBenh.Size = new System.Drawing.Size(552, 22);
            this.lookUpDinhBenh.StyleController = this.layoutControl;
            this.lookUpDinhBenh.TabIndex = 6;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaBenhLookUp,
            this.TenBenhLookUp});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // MaBenhLookUp
            // 
            this.MaBenhLookUp.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaBenhLookUp.AppearanceCell.Options.UseFont = true;
            this.MaBenhLookUp.Caption = "Mã Bệnh";
            this.MaBenhLookUp.FieldName = "MaBenh";
            this.MaBenhLookUp.Name = "MaBenhLookUp";
            this.MaBenhLookUp.OptionsColumn.AllowEdit = false;
            this.MaBenhLookUp.Visible = true;
            this.MaBenhLookUp.VisibleIndex = 0;
            this.MaBenhLookUp.Width = 60;
            // 
            // TenBenhLookUp
            // 
            this.TenBenhLookUp.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenBenhLookUp.AppearanceCell.Options.UseFont = true;
            this.TenBenhLookUp.Caption = "Tên Bệnh";
            this.TenBenhLookUp.FieldName = "TenBenh";
            this.TenBenhLookUp.Name = "TenBenhLookUp";
            this.TenBenhLookUp.OptionsColumn.AllowEdit = false;
            this.TenBenhLookUp.Visible = true;
            this.TenBenhLookUp.VisibleIndex = 1;
            this.TenBenhLookUp.Width = 324;
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Size = new System.Drawing.Size(700, 400);
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookUpLoaiVatTu;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(435, 26);
            this.layoutControlItem1.Text = "Loại vật tư:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControlVatTu;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(680, 202);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lookUpDinhBenh;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 228);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(615, 27);
            this.layoutControlItem3.Text = "Định bệnh:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnThem;
            this.layoutControlItem4.Location = new System.Drawing.Point(615, 228);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(65, 27);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(65, 27);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(65, 27);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControlDinhBenh;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 255);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(680, 125);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(435, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(245, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // UC_VatTuDinhBenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "UC_VatTuDinhBenh";
            this.Size = new System.Drawing.Size(700, 400);
            this.Load += new System.EventHandler(this.UC_VatTuDinhBenh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDinhBenh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDinhBenh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repbtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpLoaiVatTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDinhBenh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraEditors.LookUpEdit lookUpLoaiVatTu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControlVatTu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewVatTu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SearchLookUpEdit lookUpDinhBenh;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl gridControlDinhBenh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDinhBenh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn MaBV;
        private DevExpress.XtraGrid.Columns.GridColumn MaHoatChat;
        private DevExpress.XtraGrid.Columns.GridColumn HoatChat;
        private DevExpress.XtraGrid.Columns.GridColumn HamLuong;
        private DevExpress.XtraGrid.Columns.GridColumn TenVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn DonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn GiaBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn MaBenh;
        private DevExpress.XtraGrid.Columns.GridColumn TenBenh;
        private DevExpress.XtraGrid.Columns.GridColumn MaBenhLookUp;
        private DevExpress.XtraGrid.Columns.GridColumn TenBenhLookUp;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Delete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repbtnDelete;
    }
}
