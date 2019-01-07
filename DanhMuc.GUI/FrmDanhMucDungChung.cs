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
    public partial class FrmDanhMucDungChung : RibbonForm
    {
        UC_BenhICDX ucBenhICDX;
        UC_CoSoKCB ucCoSoKCB;
        UC_DonViTinh ucDonViTinh;
        UC_DuongDung ucDuongDung;
        UC_LuongCoSo ucLuongCoSo;
        UC_NuocSX ucNuocSX;
        UC_LoaiVatTu ucLoaiVatTu;
        UC_NhomVatTu ucNhomVatTu;
        UC_NhaCungCap ucNhaCungCap;
        UC_VatTu ucVatTu;
        UC_VatTuDinhBenh ucVatTuDinhBenh;
        public FrmDanhMucDungChung ()
        {
            InitializeComponent ();
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void LoadMenu()
        {
            foreach (NavBarItem navBarItem in navBarControl.Items)
            {
                if (Utils.CheckMenu (navBarItem.Name))
                {
                    navBarItem.Enabled = true;
                }
                else
                {
                    navBarItem.Enabled = false;
                }
            }
        }
        private void FrmDanhMucKhac_Load (object sender, EventArgs e)
        {
            LoadMenu ();
        }

        private void navBarDMBenhICDX_LinkClicked (object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains (ucBenhICDX))
            {
                ucBenhICDX = new UC_BenhICDX ();
                ucBenhICDX.Dock = DockStyle.Fill;
                panelControl.Controls.Add (ucBenhICDX);
            }
            ucBenhICDX.BringToFront ();
        }

        private void navBarDMCSKCB_LinkClicked (object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains (ucCoSoKCB))
            {
                ucCoSoKCB = new UC_CoSoKCB ();
                ucCoSoKCB.Dock = DockStyle.Fill;
                panelControl.Controls.Add (ucCoSoKCB);
            }
            ucCoSoKCB.BringToFront ();
        }

        private void navBarDMDonViTinh_LinkClicked (object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains (ucDonViTinh))
            {
                ucDonViTinh = new UC_DonViTinh ();
                ucDonViTinh.Dock = DockStyle.Fill;
                panelControl.Controls.Add (ucDonViTinh);
            }
            ucDonViTinh.BringToFront ();
        }

        private void navBarDMDuongDung_LinkClicked (object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains (ucDuongDung))
            {
                ucDuongDung = new UC_DuongDung ();
                ucDuongDung.Dock = DockStyle.Fill;
                panelControl.Controls.Add (ucDuongDung);
            }
            ucDuongDung.BringToFront ();
        }

        private void navBarDMLuongCoSo_LinkClicked (object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains (ucLuongCoSo))
            {
                ucLuongCoSo = new UC_LuongCoSo ();
                ucLuongCoSo.Dock = DockStyle.Fill;
                panelControl.Controls.Add (ucLuongCoSo);
            }
            ucLuongCoSo.BringToFront ();
        }

        private void navBarDMNuocSX_LinkClicked (object sender, NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains (ucNuocSX))
            {
                ucNuocSX = new UC_NuocSX ();
                ucNuocSX.Dock = DockStyle.Fill;
                panelControl.Controls.Add (ucNuocSX);
            }
            ucNuocSX.BringToFront ();
        }

        private void navBarDMLoaiVatTu_LinkClicked (object sender, NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains (ucLoaiVatTu))
            {
                ucLoaiVatTu = new UC_LoaiVatTu ();
                ucLoaiVatTu.Dock = DockStyle.Fill;
                panelControl.Controls.Add (ucLoaiVatTu);
            }
            ucLoaiVatTu.BringToFront ();
        }

        private void navBarDMNhomVatTu_LinkClicked (object sender, NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains (ucNhomVatTu))
            {
                ucNhomVatTu = new UC_NhomVatTu ();
                ucNhomVatTu.Dock = DockStyle.Fill;
                panelControl.Controls.Add (ucNhomVatTu);
            }
            ucNhomVatTu.BringToFront ();
        }

        private void navBarDMNhaCC_LinkClicked (object sender, NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains (ucNhaCungCap))
            {
                ucNhaCungCap = new UC_NhaCungCap ();
                ucNhaCungCap.Dock = DockStyle.Fill;
                panelControl.Controls.Add (ucNhaCungCap);
            }
            ucNhaCungCap.BringToFront ();
        }

        private void navBarDMVatTu_LinkClicked (object sender, NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains (ucVatTu))
            {
                ucVatTu = new UC_VatTu ();
                ucVatTu.Dock = DockStyle.Fill;
                panelControl.Controls.Add (ucVatTu);
            }
            ucVatTu.BringToFront ();
        }

        private void navBIVatTuDinhBenh_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!panelControl.Controls.Contains(ucVatTuDinhBenh))
            {
                ucVatTuDinhBenh = new UC_VatTuDinhBenh();
                ucVatTuDinhBenh.Dock = DockStyle.Fill;
                panelControl.Controls.Add(ucVatTuDinhBenh);
            }
            ucVatTuDinhBenh.BringToFront();
        }
    }
}
