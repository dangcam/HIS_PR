namespace HeThong.GUI
{
    partial class UC_PhanQuyen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.gridControlNhanVien = new DevExpress.XtraGrid.GridControl();
            this.gridViewNhanVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenKhoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.checkXoa = new DevExpress.XtraEditors.CheckEdit();
            this.checkThem = new DevExpress.XtraEditors.CheckEdit();
            this.checkCapNhat = new DevExpress.XtraEditors.CheckEdit();
            this.checkXem = new DevExpress.XtraEditors.CheckEdit();
            this.lookUpChucNang = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControlQuyen = new DevExpress.XtraGrid.GridControl();
            this.gridViewQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaCN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenCN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaQuyen = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkXoa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkThem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCapNhat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkXem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpChucNang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuyen)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlNhanVien
            // 
            this.gridControlNhanVien.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControlNhanVien.Location = new System.Drawing.Point(0, 0);
            this.gridControlNhanVien.MainView = this.gridViewNhanVien;
            this.gridControlNhanVien.Name = "gridControlNhanVien";
            this.gridControlNhanVien.Size = new System.Drawing.Size(307, 499);
            this.gridControlNhanVien.TabIndex = 0;
            this.gridControlNhanVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNhanVien});
            // 
            // gridViewNhanVien
            // 
            this.gridViewNhanVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaNV,
            this.TenNV,
            this.TenKhoa});
            this.gridViewNhanVien.GridControl = this.gridControlNhanVien;
            this.gridViewNhanVien.Name = "gridViewNhanVien";
            this.gridViewNhanVien.OptionsView.ShowGroupPanel = false;
            this.gridViewNhanVien.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewNhanVien_FocusedRowChanged);
            // 
            // MaNV
            // 
            this.MaNV.Caption = "Mã NV";
            this.MaNV.FieldName = "Ma_NV";
            this.MaNV.Name = "MaNV";
            this.MaNV.OptionsColumn.AllowEdit = false;
            // 
            // TenNV
            // 
            this.TenNV.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenNV.AppearanceCell.Options.UseFont = true;
            this.TenNV.Caption = "Tên NV";
            this.TenNV.FieldName = "Ten_NV";
            this.TenNV.Name = "TenNV";
            this.TenNV.OptionsColumn.AllowEdit = false;
            this.TenNV.Visible = true;
            this.TenNV.VisibleIndex = 0;
            // 
            // TenKhoa
            // 
            this.TenKhoa.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenKhoa.AppearanceCell.Options.UseFont = true;
            this.TenKhoa.Caption = "Khoa/Ban";
            this.TenKhoa.FieldName = "TenKhoa";
            this.TenKhoa.Name = "TenKhoa";
            this.TenKhoa.OptionsColumn.AllowEdit = false;
            this.TenKhoa.Visible = true;
            this.TenKhoa.VisibleIndex = 1;
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.btnThem);
            this.layoutControl.Controls.Add(this.btnLuu);
            this.layoutControl.Controls.Add(this.btnXoa);
            this.layoutControl.Controls.Add(this.checkXoa);
            this.layoutControl.Controls.Add(this.checkThem);
            this.layoutControl.Controls.Add(this.checkCapNhat);
            this.layoutControl.Controls.Add(this.checkXem);
            this.layoutControl.Controls.Add(this.lookUpChucNang);
            this.layoutControl.Controls.Add(this.gridControlQuyen);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(307, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(514, 499);
            this.layoutControl.TabIndex = 1;
            this.layoutControl.Text = "layoutControl1";
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.ImageOptions.ImageUri.Uri = "Add;Size16x16";
            this.btnThem.Location = new System.Drawing.Point(240, 62);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 23);
            this.btnThem.StyleController = this.layoutControl;
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btnLuu.Location = new System.Drawing.Point(329, 62);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(88, 23);
            this.btnLuu.StyleController = this.layoutControl;
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.ImageOptions.ImageUri.Uri = "Cancel;Size16x16";
            this.btnXoa.Location = new System.Drawing.Point(421, 62);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(81, 23);
            this.btnXoa.StyleController = this.layoutControl;
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // checkXoa
            // 
            this.checkXoa.Location = new System.Drawing.Point(374, 38);
            this.checkXoa.Name = "checkXoa";
            this.checkXoa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkXoa.Properties.Appearance.Options.UseFont = true;
            this.checkXoa.Properties.Caption = "Xóa";
            this.checkXoa.Size = new System.Drawing.Size(128, 20);
            this.checkXoa.StyleController = this.layoutControl;
            this.checkXoa.TabIndex = 9;
            this.checkXoa.CheckedChanged += new System.EventHandler(this.checkXoa_CheckedChanged);
            // 
            // checkThem
            // 
            this.checkThem.Location = new System.Drawing.Point(136, 38);
            this.checkThem.Name = "checkThem";
            this.checkThem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkThem.Properties.Appearance.Options.UseFont = true;
            this.checkThem.Properties.Caption = "Thêm";
            this.checkThem.Size = new System.Drawing.Size(115, 20);
            this.checkThem.StyleController = this.layoutControl;
            this.checkThem.TabIndex = 8;
            this.checkThem.CheckedChanged += new System.EventHandler(this.checkThem_CheckedChanged);
            // 
            // checkCapNhat
            // 
            this.checkCapNhat.Location = new System.Drawing.Point(255, 38);
            this.checkCapNhat.Name = "checkCapNhat";
            this.checkCapNhat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCapNhat.Properties.Appearance.Options.UseFont = true;
            this.checkCapNhat.Properties.Caption = "Cập nhật";
            this.checkCapNhat.Size = new System.Drawing.Size(115, 20);
            this.checkCapNhat.StyleController = this.layoutControl;
            this.checkCapNhat.TabIndex = 7;
            this.checkCapNhat.CheckedChanged += new System.EventHandler(this.checkCapNhat_CheckedChanged);
            // 
            // checkXem
            // 
            this.checkXem.Location = new System.Drawing.Point(12, 38);
            this.checkXem.Name = "checkXem";
            this.checkXem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkXem.Properties.Appearance.Options.UseFont = true;
            this.checkXem.Properties.Caption = "Xem";
            this.checkXem.Size = new System.Drawing.Size(120, 20);
            this.checkXem.StyleController = this.layoutControl;
            this.checkXem.TabIndex = 6;
            this.checkXem.CheckedChanged += new System.EventHandler(this.checkXem_CheckedChanged);
            // 
            // lookUpChucNang
            // 
            this.lookUpChucNang.Location = new System.Drawing.Point(71, 12);
            this.lookUpChucNang.Name = "lookUpChucNang";
            this.lookUpChucNang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpChucNang.Properties.Appearance.Options.UseFont = true;
            this.lookUpChucNang.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpChucNang.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookUpChucNang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpChucNang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_CN", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_CN", "Tên")});
            this.lookUpChucNang.Properties.NullText = "";
            this.lookUpChucNang.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpChucNang.Size = new System.Drawing.Size(431, 22);
            this.lookUpChucNang.StyleController = this.layoutControl;
            this.lookUpChucNang.TabIndex = 5;
            // 
            // gridControlQuyen
            // 
            this.gridControlQuyen.Location = new System.Drawing.Point(12, 89);
            this.gridControlQuyen.MainView = this.gridViewQuyen;
            this.gridControlQuyen.Name = "gridControlQuyen";
            this.gridControlQuyen.Size = new System.Drawing.Size(490, 398);
            this.gridControlQuyen.TabIndex = 4;
            this.gridControlQuyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewQuyen});
            // 
            // gridViewQuyen
            // 
            this.gridViewQuyen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaCN,
            this.TenCN,
            this.MaQuyen});
            this.gridViewQuyen.GridControl = this.gridControlQuyen;
            this.gridViewQuyen.Name = "gridViewQuyen";
            this.gridViewQuyen.OptionsFind.AlwaysVisible = true;
            this.gridViewQuyen.OptionsView.ShowGroupPanel = false;
            this.gridViewQuyen.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewQuyen_RowClick);
            // 
            // MaCN
            // 
            this.MaCN.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaCN.AppearanceCell.Options.UseFont = true;
            this.MaCN.Caption = "Mã CN";
            this.MaCN.FieldName = "Ma_CN";
            this.MaCN.Name = "MaCN";
            this.MaCN.OptionsColumn.AllowEdit = false;
            this.MaCN.Visible = true;
            this.MaCN.VisibleIndex = 0;
            // 
            // TenCN
            // 
            this.TenCN.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenCN.AppearanceCell.Options.UseFont = true;
            this.TenCN.Caption = "Tên chức năng";
            this.TenCN.FieldName = "Ten_CN";
            this.TenCN.Name = "TenCN";
            this.TenCN.OptionsColumn.AllowEdit = false;
            this.TenCN.Visible = true;
            this.TenCN.VisibleIndex = 1;
            // 
            // MaQuyen
            // 
            this.MaQuyen.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaQuyen.AppearanceCell.Options.UseFont = true;
            this.MaQuyen.Caption = "Mã quyền";
            this.MaQuyen.FieldName = "MaQuyen";
            this.MaQuyen.Name = "MaQuyen";
            this.MaQuyen.OptionsColumn.AllowEdit = false;
            this.MaQuyen.Visible = true;
            this.MaQuyen.VisibleIndex = 2;
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
            this.emptySpaceItem1});
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Size = new System.Drawing.Size(514, 499);
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlQuyen;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 77);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(494, 402);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lookUpChucNang;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(494, 26);
            this.layoutControlItem2.Text = "Chức năng:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.checkXem;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(124, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.checkCapNhat;
            this.layoutControlItem4.Location = new System.Drawing.Point(243, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(119, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.checkThem;
            this.layoutControlItem5.Location = new System.Drawing.Point(124, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(119, 24);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.checkXoa;
            this.layoutControlItem6.Location = new System.Drawing.Point(362, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(132, 24);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnXoa;
            this.layoutControlItem7.Location = new System.Drawing.Point(409, 50);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(85, 27);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(85, 27);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(85, 27);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnLuu;
            this.layoutControlItem8.Location = new System.Drawing.Point(317, 50);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(92, 27);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(92, 27);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(92, 27);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnThem;
            this.layoutControlItem9.Location = new System.Drawing.Point(228, 50);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(89, 27);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(89, 27);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(89, 27);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 50);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(228, 27);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // UC_PhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.gridControlNhanVien);
            this.Name = "UC_PhanQuyen";
            this.Size = new System.Drawing.Size(821, 499);
            this.Load += new System.EventHandler(this.UC_PhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkXoa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkThem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCapNhat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkXem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpChucNang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuyen)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNhanVien;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraGrid.Columns.GridColumn MaNV;
        private DevExpress.XtraGrid.Columns.GridColumn TenNV;
        private DevExpress.XtraGrid.Columns.GridColumn TenKhoa;
        private DevExpress.XtraGrid.GridControl gridControlQuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewQuyen;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.CheckEdit checkXoa;
        private DevExpress.XtraEditors.CheckEdit checkThem;
        private DevExpress.XtraEditors.CheckEdit checkCapNhat;
        private DevExpress.XtraEditors.CheckEdit checkXem;
        private DevExpress.XtraEditors.LookUpEdit lookUpChucNang;
        private DevExpress.XtraGrid.Columns.GridColumn MaCN;
        private DevExpress.XtraGrid.Columns.GridColumn TenCN;
        private DevExpress.XtraGrid.Columns.GridColumn MaQuyen;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
