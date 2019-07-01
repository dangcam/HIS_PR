namespace HeThong.GUI
{
    partial class FrmQuanTriHeThong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuanTriHeThong));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarHeThong = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarChucNang = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarMenu = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSoDoToChuc = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarPhanQuyen = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarNhatKy = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            this.navBarDonThuoc = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.barButtonItem1});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 2;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(890, 27);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 27);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.navBarControl);
            this.splitContainerControl.Panel1.Text = "PanelLeft";
            this.splitContainerControl.Panel2.Controls.Add(this.panelControl);
            this.splitContainerControl.Size = new System.Drawing.Size(890, 468);
            this.splitContainerControl.SplitterPosition = 169;
            this.splitContainerControl.TabIndex = 1;
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.navBarHeThong;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarHeThong});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarChucNang,
            this.navBarMenu,
            this.navBarSoDoToChuc,
            this.navBarPhanQuyen,
            this.navBarNhatKy,
            this.navBarDonThuoc});
            this.navBarControl.Location = new System.Drawing.Point(0, 0);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 169;
            this.navBarControl.Size = new System.Drawing.Size(169, 468);
            this.navBarControl.TabIndex = 0;
            this.navBarControl.Text = "Quản trị";
            // 
            // navBarHeThong
            // 
            this.navBarHeThong.Caption = "Quản trị hệ thống";
            this.navBarHeThong.Expanded = true;
            this.navBarHeThong.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarHeThong.ImageOptions.SmallImage")));
            this.navBarHeThong.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarChucNang),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarMenu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSoDoToChuc),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarPhanQuyen),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarNhatKy),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarDonThuoc)});
            this.navBarHeThong.Name = "navBarHeThong";
            // 
            // navBarChucNang
            // 
            this.navBarChucNang.Caption = "Chức năng";
            this.navBarChucNang.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarChucNang.ImageOptions.SmallImage")));
            this.navBarChucNang.Name = "navBarChucNang";
            this.navBarChucNang.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarChucNang_LinkClicked);
            // 
            // navBarMenu
            // 
            this.navBarMenu.Caption = "Menu";
            this.navBarMenu.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarMenu.ImageOptions.SmallImage")));
            this.navBarMenu.Name = "navBarMenu";
            this.navBarMenu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarMenu_LinkClicked);
            // 
            // navBarSoDoToChuc
            // 
            this.navBarSoDoToChuc.Caption = "Sơ đồ tổ chức";
            this.navBarSoDoToChuc.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarSoDoToChuc.ImageOptions.SmallImage")));
            this.navBarSoDoToChuc.Name = "navBarSoDoToChuc";
            this.navBarSoDoToChuc.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarSoDoToChuc_LinkClicked);
            // 
            // navBarPhanQuyen
            // 
            this.navBarPhanQuyen.Caption = "Phân quyền";
            this.navBarPhanQuyen.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarPhanQuyen.ImageOptions.SmallImage")));
            this.navBarPhanQuyen.Name = "navBarPhanQuyen";
            this.navBarPhanQuyen.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarPhanQuyen_LinkClicked);
            // 
            // navBarNhatKy
            // 
            this.navBarNhatKy.Caption = "Nhật ký";
            this.navBarNhatKy.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarNhatKy.ImageOptions.SmallImage")));
            this.navBarNhatKy.Name = "navBarNhatKy";
            this.navBarNhatKy.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarNhatKy_LinkClicked);
            // 
            // panelControl
            // 
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(716, 468);
            this.panelControl.TabIndex = 0;
            // 
            // navBarDonThuoc
            // 
            this.navBarDonThuoc.Caption = "Đơn thuốc xóa";
            this.navBarDonThuoc.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarDonThuoc.ImageOptions.SmallImage")));
            this.navBarDonThuoc.Name = "navBarDonThuoc";
            this.navBarDonThuoc.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarDonThuoc_LinkClicked);
            // 
            // FrmQuanTriHeThong
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 495);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmQuanTriHeThong";
            this.Ribbon = this.ribbonControl;
            this.Text = "Quản trị hệ thống";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmQuanTriHeThong_Load);
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
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup navBarHeThong;
        private DevExpress.XtraNavBar.NavBarItem navBarChucNang;
        private DevExpress.XtraEditors.PanelControl panelControl;
        private DevExpress.XtraNavBar.NavBarItem navBarMenu;
        private DevExpress.XtraNavBar.NavBarItem navBarSoDoToChuc;
        private DevExpress.XtraNavBar.NavBarItem navBarPhanQuyen;
        private DevExpress.XtraNavBar.NavBarItem navBarNhatKy;
        private DevExpress.XtraNavBar.NavBarItem navBarDonThuoc;
    }
}