namespace HeThong.GUI
{
    partial class UC_ChucNang
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
            this.layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Ma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChoPhep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkTinhTrang = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.MoTa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkChoPhep = new DevExpress.XtraEditors.CheckEdit();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.txtLop = new DevExpress.XtraEditors.TextEdit();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.txtMa = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroupMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTinhTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChoPhep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlMain
            // 
            this.layoutControlMain.Controls.Add(this.btnThem);
            this.layoutControlMain.Controls.Add(this.btnLuu);
            this.layoutControlMain.Controls.Add(this.btnXoa);
            this.layoutControlMain.Controls.Add(this.gridControl);
            this.layoutControlMain.Controls.Add(this.checkChoPhep);
            this.layoutControlMain.Controls.Add(this.txtMoTa);
            this.layoutControlMain.Controls.Add(this.txtLop);
            this.layoutControlMain.Controls.Add(this.txtTen);
            this.layoutControlMain.Controls.Add(this.txtMa);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.Location = new System.Drawing.Point(0, 0);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.Root = this.layoutControlGroupMain;
            this.layoutControlMain.Size = new System.Drawing.Size(800, 500);
            this.layoutControlMain.TabIndex = 0;
            this.layoutControlMain.Text = "layoutControl1";
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.ImageOptions.ImageUri.Uri = "Add;Size16x16";
            this.btnThem.Location = new System.Drawing.Point(597, 64);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(60, 23);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btnLuu.Location = new System.Drawing.Point(661, 64);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(57, 23);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.ImageOptions.ImageUri.Uri = "Cancel;Size16x16";
            this.btnXoa.Location = new System.Drawing.Point(722, 64);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(66, 22);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(12, 104);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.checkTinhTrang});
            this.gridControl.Size = new System.Drawing.Size(776, 384);
            this.gridControl.TabIndex = 8;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Ma,
            this.Ten,
            this.Lop,
            this.ChoPhep,
            this.MoTa});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_RowClick);
            // 
            // Ma
            // 
            this.Ma.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ma.AppearanceCell.Options.UseFont = true;
            this.Ma.Caption = "Mã";
            this.Ma.FieldName = "Ma_CN";
            this.Ma.Name = "Ma";
            this.Ma.OptionsColumn.AllowEdit = false;
            this.Ma.Visible = true;
            this.Ma.VisibleIndex = 0;
            this.Ma.Width = 151;
            // 
            // Ten
            // 
            this.Ten.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ten.AppearanceCell.Options.UseFont = true;
            this.Ten.Caption = "Tên";
            this.Ten.FieldName = "Ten_CN";
            this.Ten.Name = "Ten";
            this.Ten.OptionsColumn.AllowEdit = false;
            this.Ten.Visible = true;
            this.Ten.VisibleIndex = 1;
            this.Ten.Width = 151;
            // 
            // Lop
            // 
            this.Lop.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lop.AppearanceCell.Options.UseFont = true;
            this.Lop.Caption = "Lớp";
            this.Lop.FieldName = "Lop_CN";
            this.Lop.Name = "Lop";
            this.Lop.OptionsColumn.AllowEdit = false;
            this.Lop.Visible = true;
            this.Lop.VisibleIndex = 2;
            this.Lop.Width = 151;
            // 
            // ChoPhep
            // 
            this.ChoPhep.Caption = "#";
            this.ChoPhep.ColumnEdit = this.checkTinhTrang;
            this.ChoPhep.FieldName = "TinhTrang";
            this.ChoPhep.Name = "ChoPhep";
            this.ChoPhep.OptionsColumn.AllowEdit = false;
            this.ChoPhep.Visible = true;
            this.ChoPhep.VisibleIndex = 3;
            this.ChoPhep.Width = 40;
            // 
            // checkTinhTrang
            // 
            this.checkTinhTrang.AutoHeight = false;
            this.checkTinhTrang.Name = "checkTinhTrang";
            // 
            // MoTa
            // 
            this.MoTa.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoTa.AppearanceCell.Options.UseFont = true;
            this.MoTa.Caption = "Mô Tả";
            this.MoTa.FieldName = "MoTa";
            this.MoTa.Name = "MoTa";
            this.MoTa.OptionsColumn.AllowEdit = false;
            this.MoTa.Visible = true;
            this.MoTa.VisibleIndex = 4;
            this.MoTa.Width = 265;
            // 
            // checkChoPhep
            // 
            this.checkChoPhep.Location = new System.Drawing.Point(379, 64);
            this.checkChoPhep.Name = "checkChoPhep";
            this.checkChoPhep.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkChoPhep.Properties.Appearance.Options.UseFont = true;
            this.checkChoPhep.Properties.Caption = "";
            this.checkChoPhep.Size = new System.Drawing.Size(119, 20);
            this.checkChoPhep.TabIndex = 4;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(379, 12);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.Properties.Appearance.Options.UseFont = true;
            this.txtMoTa.Size = new System.Drawing.Size(409, 48);
            this.txtMoTa.TabIndex = 3;
            // 
            // txtLop
            // 
            this.txtLop.Location = new System.Drawing.Point(57, 64);
            this.txtLop.Name = "txtLop";
            this.txtLop.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLop.Properties.Appearance.Options.UseFont = true;
            this.txtLop.Size = new System.Drawing.Size(273, 22);
            this.txtLop.TabIndex = 2;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(57, 38);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Properties.Appearance.Options.UseFont = true;
            this.txtTen.Size = new System.Drawing.Size(273, 22);
            this.txtTen.TabIndex = 1;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(57, 12);
            this.txtMa.Name = "txtMa";
            this.txtMa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.Properties.Appearance.Options.UseFont = true;
            this.txtMa.Size = new System.Drawing.Size(273, 22);
            this.txtMa.TabIndex = 0;
            // 
            // layoutControlGroupMain
            // 
            this.layoutControlGroupMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupMain.GroupBordersVisible = false;
            this.layoutControlGroupMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem9,
            this.emptySpaceItem3,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.layoutControlGroupMain.Name = "Root";
            this.layoutControlGroupMain.Size = new System.Drawing.Size(800, 500);
            this.layoutControlGroupMain.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMa;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(322, 26);
            this.layoutControlItem1.Text = "Mã:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(42, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 79);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(322, 13);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(322, 13);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(780, 13);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTen;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(322, 26);
            this.layoutControlItem2.Text = "Tên:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtLop;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(322, 27);
            this.layoutControlItem3.Text = "Lớp:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtMoTa;
            this.layoutControlItem4.Location = new System.Drawing.Point(322, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(458, 52);
            this.layoutControlItem4.Text = "Mô tả:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.checkChoPhep;
            this.layoutControlItem5.Location = new System.Drawing.Point(322, 52);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(168, 27);
            this.layoutControlItem5.Text = "Enabled:";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.gridControl;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(780, 388);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnXoa;
            this.layoutControlItem9.Location = new System.Drawing.Point(710, 52);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(70, 26);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(70, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(70, 27);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(490, 52);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(95, 27);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnLuu;
            this.layoutControlItem7.Location = new System.Drawing.Point(649, 52);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(61, 27);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(61, 27);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(61, 27);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnThem;
            this.layoutControlItem8.Location = new System.Drawing.Point(585, 52);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(64, 27);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(64, 27);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(64, 27);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // UC_ChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControlMain);
            this.Name = "UC_ChucNang";
            this.Size = new System.Drawing.Size(800, 500);
            this.Load += new System.EventHandler(this.UC_ChucNang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTinhTrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChoPhep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupMain;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.CheckEdit checkChoPhep;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private DevExpress.XtraEditors.TextEdit txtLop;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.TextEdit txtMa;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.Columns.GridColumn Ma;
        private DevExpress.XtraGrid.Columns.GridColumn Ten;
        private DevExpress.XtraGrid.Columns.GridColumn Lop;
        private DevExpress.XtraGrid.Columns.GridColumn ChoPhep;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkTinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn MoTa;
    }
}
