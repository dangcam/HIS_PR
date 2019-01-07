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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_VatTuDinhBenh));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlDinhBenh = new DevExpress.XtraGrid.GridControl();
            this.gridViewDinhBenh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlVatTu = new DevExpress.XtraGrid.GridControl();
            this.gridViewVatTu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lookUpLoaiVatTu = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpDinhBenh = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDinhBenh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDinhBenh)).BeginInit();
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
            this.gridControlDinhBenh.Location = new System.Drawing.Point(12, 261);
            this.gridControlDinhBenh.MainView = this.gridViewDinhBenh;
            this.gridControlDinhBenh.Name = "gridControlDinhBenh";
            this.gridControlDinhBenh.Size = new System.Drawing.Size(676, 127);
            this.gridControlDinhBenh.TabIndex = 8;
            this.gridControlDinhBenh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDinhBenh});
            // 
            // gridViewDinhBenh
            // 
            this.gridViewDinhBenh.GridControl = this.gridControlDinhBenh;
            this.gridViewDinhBenh.Name = "gridViewDinhBenh";
            this.gridViewDinhBenh.OptionsView.ShowGroupPanel = false;
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.Location = new System.Drawing.Point(627, 234);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(61, 23);
            this.btnThem.StyleController = this.layoutControl;
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            // 
            // gridControlVatTu
            // 
            this.gridControlVatTu.Location = new System.Drawing.Point(12, 38);
            this.gridControlVatTu.MainView = this.gridViewVatTu;
            this.gridControlVatTu.Name = "gridControlVatTu";
            this.gridControlVatTu.Size = new System.Drawing.Size(676, 192);
            this.gridControlVatTu.TabIndex = 5;
            this.gridControlVatTu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewVatTu});
            // 
            // gridViewVatTu
            // 
            this.gridViewVatTu.GridControl = this.gridControlVatTu;
            this.gridViewVatTu.Name = "gridViewVatTu";
            this.gridViewVatTu.OptionsFind.AlwaysVisible = true;
            this.gridViewVatTu.OptionsView.ShowAutoFilterRow = true;
            this.gridViewVatTu.OptionsView.ShowGroupPanel = false;
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
            this.lookUpLoaiVatTu.Size = new System.Drawing.Size(617, 22);
            this.lookUpLoaiVatTu.StyleController = this.layoutControl;
            this.lookUpLoaiVatTu.TabIndex = 4;
            this.lookUpLoaiVatTu.EditValueChanged += new System.EventHandler(this.lookUpLoaiVatTu_EditValueChanged);
            // 
            // lookUpDinhBenh
            // 
            this.lookUpDinhBenh.Location = new System.Drawing.Point(71, 234);
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
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
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
            this.layoutControlItem5});
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Size = new System.Drawing.Size(700, 400);
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookUpLoaiVatTu;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(680, 26);
            this.layoutControlItem1.Text = "Loại vật tư:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControlVatTu;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(680, 196);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lookUpDinhBenh;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 222);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(615, 27);
            this.layoutControlItem3.Text = "Định bệnh:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnThem;
            this.layoutControlItem4.Location = new System.Drawing.Point(615, 222);
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
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 249);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(680, 131);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
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
    }
}
