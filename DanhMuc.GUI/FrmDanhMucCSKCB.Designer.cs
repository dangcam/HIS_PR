namespace DanhMuc.GUI
{
    partial class FrmDanhMucCSKCB
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDanhMucCSKCB));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupDMCSKCB = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGiuongBenh = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarCongKham = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarDVKT = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarNhomCanLamSan = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarThuocNgoaiDM = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            this.navBarVatTuYTe = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
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
            this.ribbonControl.Size = new System.Drawing.Size(864, 27);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 27);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.navBarControl);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.panelControl);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(864, 456);
            this.splitContainerControl.SplitterPosition = 178;
            this.splitContainerControl.TabIndex = 1;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.navBarGroupDMCSKCB;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupDMCSKCB});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarGiuongBenh,
            this.navBarCongKham,
            this.navBarDVKT,
            this.navBarNhomCanLamSan,
            this.navBarThuocNgoaiDM,
            this.navBarVatTuYTe});
            this.navBarControl.Location = new System.Drawing.Point(0, 0);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 178;
            this.navBarControl.Size = new System.Drawing.Size(178, 456);
            this.navBarControl.TabIndex = 0;
            this.navBarControl.Text = "navBarControl1";
            // 
            // navBarGroupDMCSKCB
            // 
            this.navBarGroupDMCSKCB.Caption = "Danh mục tại CSKCB";
            this.navBarGroupDMCSKCB.Expanded = true;
            this.navBarGroupDMCSKCB.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupDMCSKCB.ImageOptions.SmallImage")));
            this.navBarGroupDMCSKCB.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarGiuongBenh),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarCongKham),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarDVKT),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarNhomCanLamSan),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarThuocNgoaiDM),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarVatTuYTe)});
            this.navBarGroupDMCSKCB.Name = "navBarGroupDMCSKCB";
            // 
            // navBarGiuongBenh
            // 
            this.navBarGiuongBenh.Caption = "Danh mục Giường bệnh";
            this.navBarGiuongBenh.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGiuongBenh.ImageOptions.SmallImage")));
            this.navBarGiuongBenh.Name = "navBarGiuongBenh";
            this.navBarGiuongBenh.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarGiuongBenh_LinkClicked);
            // 
            // navBarCongKham
            // 
            this.navBarCongKham.Caption = "Danh mục Công khám";
            this.navBarCongKham.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarCongKham.ImageOptions.SmallImage")));
            this.navBarCongKham.Name = "navBarCongKham";
            this.navBarCongKham.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarCongKham_LinkClicked);
            // 
            // navBarDVKT
            // 
            this.navBarDVKT.Caption = "Danh mục DVKT";
            this.navBarDVKT.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarDVKT.ImageOptions.SmallImage")));
            this.navBarDVKT.Name = "navBarDVKT";
            this.navBarDVKT.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarDVKT_LinkClicked);
            // 
            // navBarNhomCanLamSan
            // 
            this.navBarNhomCanLamSan.Caption = "Nhóm Cận lâm sàn";
            this.navBarNhomCanLamSan.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarNhomCanLamSan.ImageOptions.SmallImage")));
            this.navBarNhomCanLamSan.Name = "navBarNhomCanLamSan";
            this.navBarNhomCanLamSan.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarNhomCanLamSan_LinkClicked);
            // 
            // navBarThuocNgoaiDM
            // 
            this.navBarThuocNgoaiDM.Caption = "Thuốc ngoài danh mục";
            this.navBarThuocNgoaiDM.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarThuocNgoaiDM.ImageOptions.SmallImage")));
            this.navBarThuocNgoaiDM.Name = "navBarThuocNgoaiDM";
            this.navBarThuocNgoaiDM.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarThuocNgoaiDM_LinkClicked);
            // 
            // panelControl
            // 
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(681, 456);
            this.panelControl.TabIndex = 0;
            // 
            // navBarVatTuYTe
            // 
            this.navBarVatTuYTe.Caption = "Vật tư y tế";
            this.navBarVatTuYTe.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarVatTuYTe.ImageOptions.SmallImage")));
            this.navBarVatTuYTe.Name = "navBarVatTuYTe";
            this.navBarVatTuYTe.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarVatTuYTe_LinkClicked);
            // 
            // FrmDanhMucCSKCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 483);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDanhMucCSKCB";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục tại Cơ sở KCB";
            this.Load += new System.EventHandler(this.FrmDanhMucCSKCB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.PanelControl panelControl;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupDMCSKCB;
        private DevExpress.XtraNavBar.NavBarItem navBarGiuongBenh;
        private DevExpress.XtraNavBar.NavBarItem navBarCongKham;
        private DevExpress.XtraNavBar.NavBarItem navBarDVKT;
        private DevExpress.XtraNavBar.NavBarItem navBarNhomCanLamSan;
        private DevExpress.XtraNavBar.NavBarItem navBarThuocNgoaiDM;
        private DevExpress.XtraNavBar.NavBarItem navBarVatTuYTe;
    }
}