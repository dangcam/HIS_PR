namespace BaoCao.GUI
{
    partial class FrmTongHopKeDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTongHopKeDon));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.lookUpMaKhoa = new DevExpress.XtraEditors.LookUpEdit();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Ma_BS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ten_NV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DuocKe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DaKe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KeDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTongHop = new DevExpress.XtraEditors.SimpleButton();
            this.dateDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.dateTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.btnHomNay = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpMaKhoa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.lookUpMaKhoa);
            this.layoutControl.Controls.Add(this.gridControl);
            this.layoutControl.Controls.Add(this.btnTongHop);
            this.layoutControl.Controls.Add(this.dateDenNgay);
            this.layoutControl.Controls.Add(this.dateTuNgay);
            this.layoutControl.Controls.Add(this.btnHomNay);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 27);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(784, 384);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // lookUpMaKhoa
            // 
            this.lookUpMaKhoa.Location = new System.Drawing.Point(60, 12);
            this.lookUpMaKhoa.MenuManager = this.ribbonControl;
            this.lookUpMaKhoa.Name = "lookUpMaKhoa";
            this.lookUpMaKhoa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpMaKhoa.Properties.Appearance.Options.UseFont = true;
            this.lookUpMaKhoa.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpMaKhoa.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookUpMaKhoa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpMaKhoa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaKhoa", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenKhoa", "Tên", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpMaKhoa.Properties.DisplayMember = "TenKhoa";
            this.lookUpMaKhoa.Properties.NullText = "";
            this.lookUpMaKhoa.Properties.ValueMember = "MaKhoa";
            this.lookUpMaKhoa.Size = new System.Drawing.Size(98, 22);
            this.lookUpMaKhoa.StyleController = this.layoutControl;
            this.lookUpMaKhoa.TabIndex = 13;
            this.lookUpMaKhoa.EditValueChanged += new System.EventHandler(this.lookUpMaKhoa_EditValueChanged);
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
            this.ribbonControl.Size = new System.Drawing.Size(784, 27);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(12, 39);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(760, 333);
            this.gridControl.TabIndex = 8;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Ma_BS,
            this.Ten_NV,
            this.DuocKe,
            this.DaKe,
            this.KeDon});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // Ma_BS
            // 
            this.Ma_BS.Caption = "Mã BS";
            this.Ma_BS.FieldName = "Ma_BS";
            this.Ma_BS.Name = "Ma_BS";
            this.Ma_BS.Visible = true;
            this.Ma_BS.VisibleIndex = 0;
            this.Ma_BS.Width = 150;
            // 
            // Ten_NV
            // 
            this.Ten_NV.Caption = "Tên bác sĩ";
            this.Ten_NV.FieldName = "Ten_NV";
            this.Ten_NV.Name = "Ten_NV";
            this.Ten_NV.Visible = true;
            this.Ten_NV.VisibleIndex = 1;
            this.Ten_NV.Width = 250;
            // 
            // DuocKe
            // 
            this.DuocKe.Caption = "Được kê trong ngày";
            this.DuocKe.FieldName = "DuocKe";
            this.DuocKe.Name = "DuocKe";
            this.DuocKe.Visible = true;
            this.DuocKe.VisibleIndex = 2;
            this.DuocKe.Width = 117;
            // 
            // DaKe
            // 
            this.DaKe.Caption = "Đã kê";
            this.DaKe.FieldName = "DaKe";
            this.DaKe.Name = "DaKe";
            this.DaKe.Visible = true;
            this.DaKe.VisibleIndex = 3;
            this.DaKe.Width = 117;
            // 
            // KeDon
            // 
            this.KeDon.Caption = "Lần kê còn lại";
            this.KeDon.FieldName = "KeDon";
            this.KeDon.Name = "KeDon";
            this.KeDon.Visible = true;
            this.KeDon.VisibleIndex = 4;
            // 
            // btnTongHop
            // 
            this.btnTongHop.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTongHop.Appearance.Options.UseFont = true;
            this.btnTongHop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTongHop.ImageOptions.Image")));
            this.btnTongHop.Location = new System.Drawing.Point(554, 12);
            this.btnTongHop.Name = "btnTongHop";
            this.btnTongHop.Size = new System.Drawing.Size(82, 23);
            this.btnTongHop.StyleController = this.layoutControl;
            this.btnTongHop.TabIndex = 7;
            this.btnTongHop.Text = "Tổng hợp";
            this.btnTongHop.Click += new System.EventHandler(this.btnTongHop_Click);
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.EditValue = null;
            this.dateDenNgay.Location = new System.Drawing.Point(452, 12);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDenNgay.Properties.Appearance.Options.UseFont = true;
            this.dateDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateDenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateDenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateDenNgay.Size = new System.Drawing.Size(98, 22);
            this.dateDenNgay.StyleController = this.layoutControl;
            this.dateDenNgay.TabIndex = 6;
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.EditValue = null;
            this.dateTuNgay.Location = new System.Drawing.Point(302, 12);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTuNgay.Properties.Appearance.Options.UseFont = true;
            this.dateTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateTuNgay.Size = new System.Drawing.Size(98, 22);
            this.dateTuNgay.StyleController = this.layoutControl;
            this.dateTuNgay.TabIndex = 5;
            // 
            // btnHomNay
            // 
            this.btnHomNay.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomNay.Appearance.Options.UseFont = true;
            this.btnHomNay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHomNay.ImageOptions.Image")));
            this.btnHomNay.Location = new System.Drawing.Point(162, 12);
            this.btnHomNay.Name = "btnHomNay";
            this.btnHomNay.Size = new System.Drawing.Size(78, 23);
            this.btnHomNay.StyleController = this.layoutControl;
            this.btnHomNay.TabIndex = 4;
            this.btnHomNay.Text = "Hôm nay";
            this.btnHomNay.Click += new System.EventHandler(this.btnHomNay_Click);
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
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Size = new System.Drawing.Size(784, 384);
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnHomNay;
            this.layoutControlItem1.Location = new System.Drawing.Point(150, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(82, 27);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(82, 27);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(82, 27);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateTuNgay;
            this.layoutControlItem2.Location = new System.Drawing.Point(242, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(150, 27);
            this.layoutControlItem2.Text = "Từ ngày";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateDenNgay;
            this.layoutControlItem3.Location = new System.Drawing.Point(392, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(150, 27);
            this.layoutControlItem3.Text = "đến ngày";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnTongHop;
            this.layoutControlItem4.Location = new System.Drawing.Point(542, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(86, 27);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(86, 27);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(86, 27);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(628, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(136, 27);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(232, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(10, 27);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControl;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(764, 337);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lookUpMaKhoa;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(150, 27);
            this.layoutControlItem6.Text = "Khoa:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(45, 13);
            // 
            // FrmTongHopKeDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTongHopKeDon";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp kê đơn Bác sĩ";
            this.Load += new System.EventHandler(this.FrmTongHopKeDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpMaKhoa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraEditors.SimpleButton btnTongHop;
        private DevExpress.XtraEditors.DateEdit dateDenNgay;
        private DevExpress.XtraEditors.DateEdit dateTuNgay;
        private DevExpress.XtraEditors.SimpleButton btnHomNay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LookUpEdit lookUpMaKhoa;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn Ma_BS;
        private DevExpress.XtraGrid.Columns.GridColumn Ten_NV;
        private DevExpress.XtraGrid.Columns.GridColumn DuocKe;
        private DevExpress.XtraGrid.Columns.GridColumn DaKe;
        private DevExpress.XtraGrid.Columns.GridColumn KeDon;
    }
}