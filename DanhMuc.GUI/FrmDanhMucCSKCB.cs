using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanhMuc.GUI
{
    public partial class FrmDanhMucCSKCB : RibbonForm
    {
        UC_GiuongBenh ucTienKham;
        UC_CongKham ucCongKham;
        UC_DVKT ucDVKT;
        UC_NhomCanLamSan ucNhomCanLamSan;
        UC_ThuocNgoaiDM ucThuocNgoaiDM;
        UC_VatTuYTe ucVatTuYTe;
        public FrmDanhMucCSKCB ()
        {
            InitializeComponent ();
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmDanhMucCSKCB_Load (object sender, EventArgs e)
        {
            LoadMenu();
        }
        private void LoadMenu()
        {
            foreach (NavBarItem navBarItem in navBarControl.Items)
            {
                if (Utils.CheckMenu(navBarItem.Name))
                {
                    navBarItem.Enabled = true;
                }
                else
                {
                    navBarItem.Enabled = false;
                }
            }
        }
        private void navBarGiuongBenh_LinkClicked (object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains (ucTienKham))
            {
                ucTienKham = new UC_GiuongBenh ();
                ucTienKham.Dock = DockStyle.Fill;
                panelControl.Controls.Add (ucTienKham);
            }
            ucTienKham.BringToFront ();
        }

        private void navBarCongKham_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains(ucCongKham))
            {
                ucCongKham = new UC_CongKham();
                ucCongKham.Dock = DockStyle.Fill;
                panelControl.Controls.Add(ucCongKham);
            }
            ucCongKham.BringToFront();
        }

        private void navBarDVKT_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains(ucDVKT))
            {
                ucDVKT = new UC_DVKT();
                ucDVKT.Dock = DockStyle.Fill;
                panelControl.Controls.Add(ucDVKT);
            }
            ucDVKT.BringToFront();
        }

        private void navBarNhomCanLamSan_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains(ucNhomCanLamSan))
            {
                ucNhomCanLamSan = new UC_NhomCanLamSan();
                ucNhomCanLamSan.Dock = DockStyle.Fill;
                panelControl.Controls.Add(ucNhomCanLamSan);
            }
            ucNhomCanLamSan.BringToFront();
        }

        private void navBarThuocNgoaiDM_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains(ucThuocNgoaiDM))
            {
                ucThuocNgoaiDM = new UC_ThuocNgoaiDM();
                ucThuocNgoaiDM.Dock = DockStyle.Fill;
                panelControl.Controls.Add(ucThuocNgoaiDM);
            }
            ucThuocNgoaiDM.BringToFront();
        }

        private void navBarVatTuYTe_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains(ucVatTuYTe))
            {
                ucVatTuYTe = new UC_VatTuYTe();
                ucVatTuYTe.Dock = DockStyle.Fill;
                panelControl.Controls.Add(ucVatTuYTe);
            }
            ucVatTuYTe.BringToFront();
        }
    }
}
