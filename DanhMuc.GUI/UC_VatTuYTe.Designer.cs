namespace DanhMuc.GUI
{
    partial class UC_VatTuYTe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_VatTuYTe));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtCongBo = new DevExpress.XtraEditors.TextEdit();
            this.btnMoi = new DevExpress.XtraEditors.SimpleButton();
            this.txtQuyetDinh = new DevExpress.XtraEditors.TextEdit();
            this.txtDonGia = new DevExpress.XtraEditors.TextEdit();
            this.lookUpDonViTinh = new DevExpress.XtraEditors.LookUpEdit();
            this.txtTenVatTu = new DevExpress.XtraEditors.TextEdit();
            this.txtMaVatTu = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.MaVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonGiaBV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QuyetDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CongBo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCongBo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuyetDinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDonViTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenVatTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaVatTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.gridControl);
            this.layoutControl.Controls.Add(this.btnXoa);
            this.layoutControl.Controls.Add(this.btnLuu);
            this.layoutControl.Controls.Add(this.txtCongBo);
            this.layoutControl.Controls.Add(this.btnMoi);
            this.layoutControl.Controls.Add(this.txtQuyetDinh);
            this.layoutControl.Controls.Add(this.txtDonGia);
            this.layoutControl.Controls.Add(this.lookUpDonViTinh);
            this.layoutControl.Controls.Add(this.txtTenVatTu);
            this.layoutControl.Controls.Add(this.txtMaVatTu);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(800, 400);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(12, 65);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(776, 323);
            this.gridControl.TabIndex = 13;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaVatTu,
            this.TenVatTu,
            this.DonViTinh,
            this.DonGiaBV,
            this.QuyetDinh,
            this.CongBo});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_RowClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(712, 38);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(76, 23);
            this.btnXoa.StyleController = this.layoutControl;
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(632, 38);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(76, 23);
            this.btnLuu.StyleController = this.layoutControl;
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtCongBo
            // 
            this.txtCongBo.Location = new System.Drawing.Point(429, 38);
            this.txtCongBo.Name = "txtCongBo";
            this.txtCongBo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCongBo.Properties.Appearance.Options.UseFont = true;
            this.txtCongBo.Size = new System.Drawing.Size(119, 22);
            this.txtCongBo.StyleController = this.layoutControl;
            this.txtCongBo.TabIndex = 10;
            // 
            // btnMoi
            // 
            this.btnMoi.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoi.Appearance.Options.UseFont = true;
            this.btnMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMoi.ImageOptions.Image")));
            this.btnMoi.Location = new System.Drawing.Point(552, 38);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(76, 23);
            this.btnMoi.StyleController = this.layoutControl;
            this.btnMoi.TabIndex = 9;
            this.btnMoi.Text = "Mới";
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // txtQuyetDinh
            // 
            this.txtQuyetDinh.Location = new System.Drawing.Point(224, 38);
            this.txtQuyetDinh.Name = "txtQuyetDinh";
            this.txtQuyetDinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuyetDinh.Properties.Appearance.Options.UseFont = true;
            this.txtQuyetDinh.Size = new System.Drawing.Size(139, 22);
            this.txtQuyetDinh.StyleController = this.layoutControl;
            this.txtQuyetDinh.TabIndex = 8;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(74, 38);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.Properties.Appearance.Options.UseFont = true;
            this.txtDonGia.Size = new System.Drawing.Size(84, 22);
            this.txtDonGia.StyleController = this.layoutControl;
            this.txtDonGia.TabIndex = 7;
            // 
            // lookUpDonViTinh
            // 
            this.lookUpDonViTinh.Location = new System.Drawing.Point(614, 12);
            this.lookUpDonViTinh.Name = "lookUpDonViTinh";
            this.lookUpDonViTinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpDonViTinh.Properties.Appearance.Options.UseFont = true;
            this.lookUpDonViTinh.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpDonViTinh.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookUpDonViTinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDonViTinh.Properties.NullText = "";
            this.lookUpDonViTinh.Size = new System.Drawing.Size(174, 22);
            this.lookUpDonViTinh.StyleController = this.layoutControl;
            this.lookUpDonViTinh.TabIndex = 6;
            // 
            // txtTenVatTu
            // 
            this.txtTenVatTu.Location = new System.Drawing.Point(224, 12);
            this.txtTenVatTu.Name = "txtTenVatTu";
            this.txtTenVatTu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenVatTu.Properties.Appearance.Options.UseFont = true;
            this.txtTenVatTu.Size = new System.Drawing.Size(324, 22);
            this.txtTenVatTu.StyleController = this.layoutControl;
            this.txtTenVatTu.TabIndex = 5;
            // 
            // txtMaVatTu
            // 
            this.txtMaVatTu.Location = new System.Drawing.Point(74, 12);
            this.txtMaVatTu.Name = "txtMaVatTu";
            this.txtMaVatTu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVatTu.Properties.Appearance.Options.UseFont = true;
            this.txtMaVatTu.Size = new System.Drawing.Size(84, 22);
            this.txtMaVatTu.StyleController = this.layoutControl;
            this.txtMaVatTu.TabIndex = 4;
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
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10});
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Size = new System.Drawing.Size(800, 400);
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMaVatTu;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(150, 26);
            this.layoutControlItem1.Text = "Mã Vật Tư:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTenVatTu;
            this.layoutControlItem2.Location = new System.Drawing.Point(150, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(390, 26);
            this.layoutControlItem2.Text = "Tên Vật Tư:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lookUpDonViTinh;
            this.layoutControlItem3.Location = new System.Drawing.Point(540, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(240, 26);
            this.layoutControlItem3.Text = "Đơn Vị Tính:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtDonGia;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(150, 27);
            this.layoutControlItem4.Text = "Đơn giá:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtQuyetDinh;
            this.layoutControlItem5.Location = new System.Drawing.Point(150, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(205, 27);
            this.layoutControlItem5.Text = "Quyết Định:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnMoi;
            this.layoutControlItem6.Location = new System.Drawing.Point(540, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(80, 27);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtCongBo;
            this.layoutControlItem7.Location = new System.Drawing.Point(355, 26);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(185, 27);
            this.layoutControlItem7.Text = "Công Bố:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnLuu;
            this.layoutControlItem8.Location = new System.Drawing.Point(620, 26);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(80, 27);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnXoa;
            this.layoutControlItem9.Location = new System.Drawing.Point(700, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(80, 27);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.gridControl;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 53);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(780, 327);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // MaVatTu
            // 
            this.MaVatTu.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaVatTu.AppearanceCell.Options.UseFont = true;
            this.MaVatTu.Caption = "Mã vật tư";
            this.MaVatTu.FieldName = "MaVatTu";
            this.MaVatTu.Name = "MaVatTu";
            this.MaVatTu.OptionsColumn.AllowEdit = false;
            this.MaVatTu.Visible = true;
            this.MaVatTu.VisibleIndex = 0;
            this.MaVatTu.Width = 70;
            // 
            // TenVatTu
            // 
            this.TenVatTu.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenVatTu.AppearanceCell.Options.UseFont = true;
            this.TenVatTu.Caption = "Tên vật tư";
            this.TenVatTu.FieldName = "TenVatTu";
            this.TenVatTu.Name = "TenVatTu";
            this.TenVatTu.OptionsColumn.AllowEdit = false;
            this.TenVatTu.Visible = true;
            this.TenVatTu.VisibleIndex = 1;
            this.TenVatTu.Width = 300;
            // 
            // DonViTinh
            // 
            this.DonViTinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonViTinh.AppearanceCell.Options.UseFont = true;
            this.DonViTinh.Caption = "Đơn vị tính";
            this.DonViTinh.FieldName = "DonViTinh";
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.OptionsColumn.AllowEdit = false;
            this.DonViTinh.Visible = true;
            this.DonViTinh.VisibleIndex = 2;
            // 
            // DonGiaBV
            // 
            this.DonGiaBV.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonGiaBV.AppearanceCell.Options.UseFont = true;
            this.DonGiaBV.Caption = "Đơn giá";
            this.DonGiaBV.FieldName = "DonGiaBV";
            this.DonGiaBV.Name = "DonGiaBV";
            this.DonGiaBV.OptionsColumn.AllowEdit = false;
            this.DonGiaBV.Visible = true;
            this.DonGiaBV.VisibleIndex = 3;
            // 
            // QuyetDinh
            // 
            this.QuyetDinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuyetDinh.AppearanceCell.Options.UseFont = true;
            this.QuyetDinh.Caption = "Quyết định";
            this.QuyetDinh.FieldName = "QuyetDinh";
            this.QuyetDinh.Name = "QuyetDinh";
            this.QuyetDinh.OptionsColumn.AllowEdit = false;
            this.QuyetDinh.Visible = true;
            this.QuyetDinh.VisibleIndex = 4;
            // 
            // CongBo
            // 
            this.CongBo.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CongBo.AppearanceCell.Options.UseFont = true;
            this.CongBo.Caption = "Công bố";
            this.CongBo.FieldName = "CongBo";
            this.CongBo.Name = "CongBo";
            this.CongBo.OptionsColumn.AllowEdit = false;
            this.CongBo.Visible = true;
            this.CongBo.VisibleIndex = 5;
            // 
            // UC_VatTuYTe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "UC_VatTuYTe";
            this.Size = new System.Drawing.Size(800, 400);
            this.Load += new System.EventHandler(this.UC_VatTuYTe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCongBo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuyetDinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDonViTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenVatTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaVatTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraEditors.TextEdit txtTenVatTu;
        private DevExpress.XtraEditors.TextEdit txtMaVatTu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtQuyetDinh;
        private DevExpress.XtraEditors.TextEdit txtDonGia;
        private DevExpress.XtraEditors.LookUpEdit lookUpDonViTinh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.TextEdit txtCongBo;
        private DevExpress.XtraEditors.SimpleButton btnMoi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraGrid.Columns.GridColumn MaVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn TenVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn DonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn DonGiaBV;
        private DevExpress.XtraGrid.Columns.GridColumn QuyetDinh;
        private DevExpress.XtraGrid.Columns.GridColumn CongBo;
    }
}
