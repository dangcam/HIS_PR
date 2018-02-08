using BaoCao.GUI;
using Core.DAL;
using DanhMuc.GUI;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DuocPham.GUI;
using HeThong.GUI;
using System;
using System.Windows.Forms;
using TiepNhan.GUI;

namespace HIS_PR
{
    public partial class FrmMain : RibbonForm
    {
        Form frm;
        AppConfig appConfig = new AppConfig ();
        DangNhapEntity dangnhap = new DangNhapEntity ();
        bool dangxuat = false;
        public FrmMain (Form frm)
        {
            InitializeComponent ();
            this.frm = frm;
            this.WindowState = FormWindowState.Maximized;
            
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinPopupMenu (barLinkSkin);
            //foreach (RibbonControlColorScheme color in Enum.GetValues (typeof (RibbonControlColorScheme)))
            //{
            //    barListColor.Strings.Add (color.ToString());
            //}

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle (AppConfig.Theme);
        }
        private void LoadMenu ()
        {
            foreach(RibbonPage page in ribbonControlMain.Pages)
            {
               foreach(RibbonPageGroup pageGroup in page.Groups)
                {
                    foreach(BarButtonItemLink barButton in pageGroup.ItemLinks)
                    {
                        if(Utils.CheckMenu(barButton.Item.Name))
                        {
                            barButton.Item.Enabled = true;
                        }
                        else
                        {
                            barButton.Item.Enabled = false;
                        }
                    }
                }
            }
        }
        private void FrmMain_Load (object sender, EventArgs e)
        {
            barlblMaNV.Caption = AppConfig.MaNV;
            LoadMenu ();
        }

        private void FrmMain_FormClosing (object sender, FormClosingEventArgs e)
        {
            if (!dangxuat)
            {
                DialogResult traloi;
                traloi = XtraMessageBox.Show ("Thoát ứng dụng?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (AppConfig.Theme != DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName)
                    {
                        AppConfig.Theme = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
                        appConfig.WriteTheme ();       
                    }
                    Utils.ThemHoatDong (Library.DANGXUAT);
                    frm.Close ();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void barQuanTriHeThong_ItemClick (object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.GetType()==typeof(FrmQuanTriHeThong))
                {
                    frm.Activate ();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmQuanTriHeThong frmQTHeThong = new FrmQuanTriHeThong ();
            frmQTHeThong.MdiParent = this;
            frmQTHeThong.Show ();
        }

        private void barDanhMucNhanVien_ItemClick (object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType () == typeof (FrmNhanVien))
                {
                    frm.Activate ();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmNhanVien frmNhanVien = new FrmNhanVien ();
            frmNhanVien.MdiParent = this;
            frmNhanVien.Show ();
        }

        private void barbtnLogout_ItemClick (object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utils.ThemHoatDong (Library.DANGXUAT);

            AppConfig.MaNV = "";
            AppConfig.MatKhau = "";
            AppConfig.CoSoKCB = "";       

            dangxuat = true;

            this.Close ();
            frm.Show ();

        }

        private void barDanhMucKhac_ItemClick (object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType () == typeof (FrmDanhMucDungChung))
                {
                    frm.Activate ();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmDanhMucDungChung frmDMKhac = new FrmDanhMucDungChung ();
            frmDMKhac.MdiParent = this;
            frmDMKhac.Show ();
        }

        private void barButtonNhapKho_ItemClick (object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType () == typeof (FrmNhapKho))
                {
                    frm.Activate ();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmNhapKho frmNhapKho = new FrmNhapKho ();
            frmNhapKho.MdiParent = this;
            frmNhapKho.Show ();
        }

        private void barButtonXuatKho_ItemClick (object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType () == typeof (FrmXuatKho))
                {
                    frm.Activate ();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmXuatKho frmXuatKho = new FrmXuatKho ();
            frmXuatKho.MdiParent = this;
            frmXuatKho.Show ();
        }

        private void barButtonYCLinhThuoc_ItemClick (object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType () == typeof (FrmYeuCauLinhThuoc))
                {
                    frm.Activate ();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmYeuCauLinhThuoc frmYCLinhThuoc = new FrmYeuCauLinhThuoc ();
            frmYCLinhThuoc.MdiParent = this;
            frmYCLinhThuoc.Show ();
        }

        private void barButtonPLinhThuoc_ItemClick (object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType () == typeof (FrmPhieuLinhThuoc))
                {
                    frm.Activate ();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmPhieuLinhThuoc frmPhieuLinhDuoc = new FrmPhieuLinhThuoc ();
            frmPhieuLinhDuoc.MdiParent = this;
            frmPhieuLinhDuoc.Show ();
        }

        private void barBaoCaoNhapXuat_ItemClick (object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType () == typeof (FrmBCNhapXuat))
                {
                    frm.Activate ();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmBCNhapXuat frmBCNhapXuat = new FrmBCNhapXuat ();
            frmBCNhapXuat.MdiParent = this;
            frmBCNhapXuat.Show ();
        }

        private void barDanhMucCSKCB_ItemClick (object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType () == typeof (FrmDanhMucCSKCB))
                {
                    frm.Activate ();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmDanhMucCSKCB frmCSKCB = new FrmDanhMucCSKCB ();
            frmCSKCB.MdiParent = this;
            frmCSKCB.Show ();
        }

        private void barButtonNhapKhaTra_ItemClick (object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType () == typeof (FrmNhapKhoaTra))
                {
                    frm.Activate ();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmNhapKhoaTra frmNhapKhoa = new FrmNhapKhoaTra ();
            frmNhapKhoa.MdiParent = this;
            frmNhapKhoa.Show ();
        }

        private void barTonKho_ItemClick (object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType () == typeof (FrmBCTonKho))
                {
                    frm.Activate ();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmBCTonKho frmTonKho = new FrmBCTonKho ();
            frmTonKho.MdiParent = this;
            frmTonKho.Show ();
        }
        private void barButtonTiepNhan_ItemClick(object sender, ItemClickEventArgs e)
        {  
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == typeof(FrmTiepNhan))
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            FrmTiepNhan frmTiepNhan = new FrmTiepNhan();
            frmTiepNhan.MdiParent = this;
            frmTiepNhan.Show();
            SplashScreenManager.CloseForm();
        }

        private void barButtonKhamBenh_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == typeof(FrmKhamBenhNgoaiTru))
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            FrmKhamBenhNgoaiTru frmKhamBenh = new FrmKhamBenhNgoaiTru();
            frmKhamBenh.MdiParent = this;
            frmKhamBenh.Show();
            SplashScreenManager.CloseForm();
        }

        private void barButtonCauHinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmThamSoHeThong frmThamSo = new FrmThamSoHeThong();
            frmThamSo.ShowDialog();
        }

        private void barButtonCanLamSan_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == typeof(FrmCanLamSan))
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmCanLamSan frmCanLamSan = new FrmCanLamSan();
            frmCanLamSan.MdiParent = this;
            frmCanLamSan.Show();
        }

        private void barButtonNoiTru_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == typeof(FrmKhamBenhNoiTru))
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            FrmKhamBenhNoiTru frmKhamBenhNoiTru = new FrmKhamBenhNoiTru();
            frmKhamBenhNoiTru.MdiParent = this;
            frmKhamBenhNoiTru.Show();
            SplashScreenManager.CloseForm();
        }

        private void barButtonTTVienPhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == typeof(FrmThanhToan))
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            FrmThanhToan frmThanhToan = new FrmThanhToan();
            frmThanhToan.MdiParent = this;
            frmThanhToan.Show();
            SplashScreenManager.CloseForm();
        }

        private void barButtonHSBenhAn_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == typeof(FrmHoSoBenhNhan))
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmHoSoBenhNhan frmHoSoBenhNhan = new FrmHoSoBenhNhan();
            frmHoSoBenhNhan.MdiParent = this;
            frmHoSoBenhNhan.Show();
        }

        private void barButtonTonKhoLe_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == typeof(FrmTonKhoLe))
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmTonKhoLe frmTonKhoLe = new FrmTonKhoLe();
            frmTonKhoLe.MdiParent = this;
            frmTonKhoLe.Show();
        }

        private void barButtonNguonNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == typeof(FrmNguonNhap))
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmNguonNhap frmNguonNhap = new FrmNguonNhap();
            frmNguonNhap.MdiParent = this;
            frmNguonNhap.Show();
        }

        private void barButtonTongHopBC_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTongHopBaoCao frmTongHop = new FrmTongHopBaoCao();
            frmTongHop.ShowDialog();
        }

        private void barButtonTHXuatKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == typeof(FrmTongHopXuatKho))
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmTongHopXuatKho frmTongHopXuatKho = new FrmTongHopXuatKho();
            frmTongHopXuatKho.MdiParent = this;
            frmTongHopXuatKho.Show();
        }

        private void barBtnTonThucTe_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == typeof(FrmBCTonThucTe))
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            FrmBCTonThucTe frmBCTonThucTe = new FrmBCTonThucTe();
            frmBCTonThucTe.MdiParent = this;
            frmBCTonThucTe.Show();
        }
    }
}
