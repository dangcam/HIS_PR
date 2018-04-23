namespace DuocPham.GUI
{
    partial class FrmChiTietVatTu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChiTietVatTu));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnInTheKho = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaBV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LoaiVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KhoNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NhaCungCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayNhapXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoHoaDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChiTiet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.cbNam = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbThang = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.repLookUpEditKhoNhan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpEditKhoNhan)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 1;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1120, 27);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.btnInTheKho);
            this.layoutControl.Controls.Add(this.gridControl);
            this.layoutControl.Controls.Add(this.btnXem);
            this.layoutControl.Controls.Add(this.cbNam);
            this.layoutControl.Controls.Add(this.cbThang);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 27);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(1120, 418);
            this.layoutControl.TabIndex = 1;
            this.layoutControl.Text = "layoutControl1";
            // 
            // btnInTheKho
            // 
            this.btnInTheKho.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInTheKho.Appearance.Options.UseFont = true;
            this.btnInTheKho.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInTheKho.ImageOptions.Image")));
            this.btnInTheKho.Location = new System.Drawing.Point(1023, 12);
            this.btnInTheKho.Name = "btnInTheKho";
            this.btnInTheKho.Size = new System.Drawing.Size(85, 23);
            this.btnInTheKho.StyleController = this.layoutControl;
            this.btnInTheKho.TabIndex = 8;
            this.btnInTheKho.Text = "In thẻ kho";
            this.btnInTheKho.Click += new System.EventHandler(this.btnInTheKho_Click);
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(12, 39);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpEditKhoNhan});
            this.gridControl.Size = new System.Drawing.Size(1096, 367);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaBV,
            this.TenVatTu,
            this.DonViTinh,
            this.LoaiVatTu,
            this.SoLuong,
            this.GiaBHYT,
            this.DonGia,
            this.NoiDung,
            this.KhoNhan,
            this.NhaCungCap,
            this.NgayNhapXuat,
            this.SoPhieu,
            this.SoHoaDon,
            this.ChiTiet});
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 2;
            this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoLuong", null, "(Tổng = {0:#,###})")});
            this.gridView.Name = "gridView";
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.MaBV, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ChiTiet, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // MaBV
            // 
            this.MaBV.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaBV.AppearanceCell.Options.UseFont = true;
            this.MaBV.Caption = "Mã vật tư";
            this.MaBV.FieldName = "MaBV";
            this.MaBV.Name = "MaBV";
            this.MaBV.Visible = true;
            this.MaBV.VisibleIndex = 0;
            this.MaBV.Width = 62;
            // 
            // TenVatTu
            // 
            this.TenVatTu.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenVatTu.AppearanceCell.Options.UseFont = true;
            this.TenVatTu.Caption = "Tên vật tư";
            this.TenVatTu.FieldName = "TenVatTu";
            this.TenVatTu.Name = "TenVatTu";
            this.TenVatTu.Visible = true;
            this.TenVatTu.VisibleIndex = 0;
            this.TenVatTu.Width = 184;
            // 
            // DonViTinh
            // 
            this.DonViTinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonViTinh.AppearanceCell.Options.UseFont = true;
            this.DonViTinh.Caption = "Đơn vị";
            this.DonViTinh.FieldName = "DonViTinh";
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.Visible = true;
            this.DonViTinh.VisibleIndex = 1;
            this.DonViTinh.Width = 49;
            // 
            // LoaiVatTu
            // 
            this.LoaiVatTu.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoaiVatTu.AppearanceCell.Options.UseFont = true;
            this.LoaiVatTu.Caption = "Loại VT";
            this.LoaiVatTu.FieldName = "LoaiVatTu";
            this.LoaiVatTu.Name = "LoaiVatTu";
            this.LoaiVatTu.Visible = true;
            this.LoaiVatTu.VisibleIndex = 2;
            this.LoaiVatTu.Width = 43;
            // 
            // SoLuong
            // 
            this.SoLuong.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoLuong.AppearanceCell.Options.UseFont = true;
            this.SoLuong.Caption = "Số lượng";
            this.SoLuong.DisplayFormat.FormatString = "#,###";
            this.SoLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.SoLuong.FieldName = "SoLuong";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Visible = true;
            this.SoLuong.VisibleIndex = 3;
            this.SoLuong.Width = 65;
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
            this.GiaBHYT.Visible = true;
            this.GiaBHYT.VisibleIndex = 4;
            this.GiaBHYT.Width = 71;
            // 
            // DonGia
            // 
            this.DonGia.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonGia.AppearanceCell.Options.UseFont = true;
            this.DonGia.Caption = "Đơn giá";
            this.DonGia.DisplayFormat.FormatString = "#,###";
            this.DonGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DonGia.FieldName = "DonGia";
            this.DonGia.Name = "DonGia";
            this.DonGia.Visible = true;
            this.DonGia.VisibleIndex = 5;
            this.DonGia.Width = 68;
            // 
            // NoiDung
            // 
            this.NoiDung.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoiDung.AppearanceCell.Options.UseFont = true;
            this.NoiDung.Caption = "Nội dung";
            this.NoiDung.FieldName = "NoiDung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Visible = true;
            this.NoiDung.VisibleIndex = 6;
            this.NoiDung.Width = 138;
            // 
            // KhoNhan
            // 
            this.KhoNhan.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KhoNhan.AppearanceCell.Options.UseFont = true;
            this.KhoNhan.Caption = "Kho nhận";
            this.KhoNhan.ColumnEdit = this.repLookUpEditKhoNhan;
            this.KhoNhan.FieldName = "KhoNhan";
            this.KhoNhan.Name = "KhoNhan";
            this.KhoNhan.Visible = true;
            this.KhoNhan.VisibleIndex = 7;
            this.KhoNhan.Width = 104;
            // 
            // NhaCungCap
            // 
            this.NhaCungCap.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NhaCungCap.AppearanceCell.Options.UseFont = true;
            this.NhaCungCap.Caption = "Nhà cung cấp";
            this.NhaCungCap.FieldName = "NhaCungCap";
            this.NhaCungCap.Name = "NhaCungCap";
            this.NhaCungCap.Visible = true;
            this.NhaCungCap.VisibleIndex = 8;
            this.NhaCungCap.Width = 137;
            // 
            // NgayNhapXuat
            // 
            this.NgayNhapXuat.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NgayNhapXuat.AppearanceCell.Options.UseFont = true;
            this.NgayNhapXuat.Caption = "Ngày nhập xuất";
            this.NgayNhapXuat.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.NgayNhapXuat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.NgayNhapXuat.FieldName = "NgayNhapXuat";
            this.NgayNhapXuat.Name = "NgayNhapXuat";
            this.NgayNhapXuat.Visible = true;
            this.NgayNhapXuat.VisibleIndex = 9;
            this.NgayNhapXuat.Width = 90;
            // 
            // SoPhieu
            // 
            this.SoPhieu.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoPhieu.AppearanceCell.Options.UseFont = true;
            this.SoPhieu.Caption = "Số phiếu";
            this.SoPhieu.FieldName = "SoPhieu";
            this.SoPhieu.Name = "SoPhieu";
            this.SoPhieu.Visible = true;
            this.SoPhieu.VisibleIndex = 10;
            this.SoPhieu.Width = 74;
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoHoaDon.AppearanceCell.Options.UseFont = true;
            this.SoHoaDon.Caption = "Số hóa đơn";
            this.SoHoaDon.FieldName = "SoHoaDon";
            this.SoHoaDon.Name = "SoHoaDon";
            this.SoHoaDon.Visible = true;
            this.SoHoaDon.VisibleIndex = 11;
            this.SoHoaDon.Width = 55;
            // 
            // ChiTiet
            // 
            this.ChiTiet.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChiTiet.AppearanceCell.Options.UseFont = true;
            this.ChiTiet.Caption = "Chi tiết";
            this.ChiTiet.FieldName = "ChiTiet";
            this.ChiTiet.Name = "ChiTiet";
            this.ChiTiet.Visible = true;
            this.ChiTiet.VisibleIndex = 12;
            this.ChiTiet.Width = 20;
            // 
            // btnXem
            // 
            this.btnXem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXem.ImageOptions.Image")));
            this.btnXem.Location = new System.Drawing.Point(264, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(53, 22);
            this.btnXem.StyleController = this.layoutControl;
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cbNam
            // 
            this.cbNam.Location = new System.Drawing.Point(168, 12);
            this.cbNam.MenuManager = this.ribbonControl;
            this.cbNam.Name = "cbNam";
            this.cbNam.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNam.Properties.Appearance.Options.UseFont = true;
            this.cbNam.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNam.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbNam.Properties.DropDownRows = 10;
            this.cbNam.Size = new System.Drawing.Size(92, 22);
            this.cbNam.StyleController = this.layoutControl;
            this.cbNam.TabIndex = 5;
            // 
            // cbThang
            // 
            this.cbThang.Location = new System.Drawing.Point(49, 12);
            this.cbThang.MenuManager = this.ribbonControl;
            this.cbThang.Name = "cbThang";
            this.cbThang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThang.Properties.Appearance.Options.UseFont = true;
            this.cbThang.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThang.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbThang.Properties.DropDownRows = 10;
            this.cbThang.Properties.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbThang.Size = new System.Drawing.Size(78, 22);
            this.cbThang.StyleController = this.layoutControl;
            this.cbThang.TabIndex = 4;
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
            this.emptySpaceItem1,
            this.layoutControlItem5});
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Size = new System.Drawing.Size(1120, 418);
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cbThang;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(119, 27);
            this.layoutControlItem1.Text = "Tháng:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(34, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cbNam;
            this.layoutControlItem2.Location = new System.Drawing.Point(119, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(133, 27);
            this.layoutControlItem2.Text = "Năm:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(34, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnXem;
            this.layoutControlItem3.Location = new System.Drawing.Point(252, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(57, 27);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1100, 371);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(309, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(702, 27);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnInTheKho;
            this.layoutControlItem5.Location = new System.Drawing.Point(1011, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(89, 27);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // repLookUpEditKhoNhan
            // 
            this.repLookUpEditKhoNhan.AutoHeight = false;
            this.repLookUpEditKhoNhan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpEditKhoNhan.Name = "repLookUpEditKhoNhan";
            // 
            // FrmChiTietVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 445);
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChiTietVatTu";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết vật tư";
            this.Load += new System.EventHandler(this.FrmChiTietVatTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpEditKhoNhan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.ComboBoxEdit cbNam;
        private DevExpress.XtraEditors.ComboBoxEdit cbThang;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn MaBV;
        private DevExpress.XtraGrid.Columns.GridColumn TenVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn DonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn LoaiVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn SoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn GiaBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn DonGia;
        private DevExpress.XtraGrid.Columns.GridColumn NoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn KhoNhan;
        private DevExpress.XtraGrid.Columns.GridColumn NhaCungCap;
        private DevExpress.XtraGrid.Columns.GridColumn NgayNhapXuat;
        private DevExpress.XtraGrid.Columns.GridColumn SoPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn SoHoaDon;
        private DevExpress.XtraGrid.Columns.GridColumn ChiTiet;
        private DevExpress.XtraEditors.SimpleButton btnInTheKho;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpEditKhoNhan;
    }
}