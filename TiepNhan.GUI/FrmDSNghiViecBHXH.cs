﻿using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using KhamBenh.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiepNhan.GUI
{
    public partial class FrmDSNghiViecBHXH : RibbonForm
    {

        NghiViecBHXHEntity nghiViecBHXHEntity;
        public FrmDSNghiViecBHXH()
        {
            InitializeComponent();
            nghiViecBHXHEntity = new NghiViecBHXHEntity();
        }

        private void FrmDSNghiViecBHXH_Load(object sender, EventArgs e)
        {            
            dateDenNgay.DateTime = DateTime.Now;
            dateTuNgay.DateTime = DateTime.Now;
            cbLoaiCT.SelectedIndex = 0;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void LoadData()
        {
            nghiViecBHXHEntity.TuNgay = dateTuNgay.DateTime;
            nghiViecBHXHEntity.DenNgay = dateDenNgay.DateTime;
            this.gridView.Columns.Clear();
            if (cbLoaiCT.SelectedIndex == 0)
            {
                this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.STT,
                this.MaCT,
                this.SoPhieu,
                this.MaCoSoKCB,
                this.MaBS,
                this.MaSoBHXH,
                this.MaThe,
                this.HoTen,
                this.NgaySinh,
                this.GioiTinh,
                this.PPDieuTri,
                this.MaDonVi,
                this.TenDonVi,
                this.TuNgay,
                this.DenNgay,
                this.SoNgay,
                this.TenCha,
                this.TenMe,
                this.NgayCT,
                this.NguoiDaiDien,
                this.MaBenh,
                this.NgayVao,
                this.MaLK,
                this.TenBS,
                this.SERI,
                this.MAU_SO});
                this.STT.VisibleIndex = 0;
                this.MaCT.VisibleIndex = 1;
                this.SoPhieu.VisibleIndex = 2;
                this.MaCoSoKCB.VisibleIndex = 3;
                this.MaBS.VisibleIndex = 4;
                this.MaSoBHXH.VisibleIndex = 5;
                this.MaThe.VisibleIndex = 6;
                this.HoTen.VisibleIndex = 7;
                this.NgaySinh.VisibleIndex = 8;
                this.GioiTinh.VisibleIndex = 9;
                this.PPDieuTri.VisibleIndex = 10;
                this.MaDonVi.VisibleIndex = 11;
                this.TenDonVi.VisibleIndex = 12;
                this.TuNgay.VisibleIndex = 13;
                this.DenNgay.VisibleIndex = 14;
                this.SoNgay.VisibleIndex = 15;
                this.TenCha.VisibleIndex = 16;
                this.TenMe.VisibleIndex = 17;
                this.NgayCT.VisibleIndex = 18;
                this.NguoiDaiDien.VisibleIndex = 19;
                this.MaBenh.VisibleIndex = -1;
                this.NgayVao.VisibleIndex = -1;
                this.MaLK.VisibleIndex = -1;
                this.TenBS.VisibleIndex = 20;
                this.SERI.VisibleIndex = 21;
                this.MAU_SO.VisibleIndex = 22;
                //
                gridControl.DataSource = nghiViecBHXHEntity.DSChungTuBHXH();
            }
            else
            if (cbLoaiCT.SelectedIndex == 1)
            {
                this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.STT,
                this.MaCT,
                this.MaCSKCB,
                this.SERI,
                this.MaKhoa,
                this.MaSoBHXH,
                this.MaThe,
                this.HoTen,
                this.DiaChi,
                this.NgaySinh,
                this.GioiTinh,
                this.NgheNghiep,
                this.NgayVao,
                this.NgayRa,
                this.TuoiThai,
                this.TenBenh,
                this.PPDieuTri,
                this.GhiChu,
                this.NguoiDaiDien,
                this.MaTruongKhoa,
                this.NgayCT,
                this.TenTruongKhoa});
                this.STT.VisibleIndex = 0;
                this.MaCT.VisibleIndex = 1;
                this.MaCSKCB.VisibleIndex = 2;
                this.SERI.VisibleIndex = 3;
                this.MaKhoa.VisibleIndex = 4;
                this.MaSoBHXH.VisibleIndex = 5;
                this.MaThe.VisibleIndex = 6;
                this.HoTen.VisibleIndex = 7;
                this.DiaChi.VisibleIndex = 8;
                this.NgaySinh.VisibleIndex = 9;
                this.GioiTinh.VisibleIndex = 10;
                this.NgheNghiep.VisibleIndex = 11;
                this.NgayVao.VisibleIndex = 12;
                this.NgayRa.VisibleIndex = 13;
                this.TuoiThai.VisibleIndex = 14;
                this.TenBenh.VisibleIndex = 15;
                this.PPDieuTri.VisibleIndex = 16;
                this.GhiChu.VisibleIndex = 17;
                this.NguoiDaiDien.VisibleIndex = 18;
                this.MaTruongKhoa.VisibleIndex = 19;
                this.NgayCT.VisibleIndex = 20;
                this.TenTruongKhoa.VisibleIndex = 21;
                gridControl.DataSource = nghiViecBHXHEntity.DSChungTuRaVien();
            }
            else
            {
                this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.STT,
                this.MaCT,
                this.MaCSKCB,
                this.MaThe,
                this.SERI,
                this.MaSoBHXH,
                this.TenMe,
                this.NgaySinh,
                this.DiaChi,
                this.CMND,
                this.NgayCapCMND,
                this.NoiCapCMND,
                this.DanToc,
                this.TenCha,
                this.NgaySinhCon,
                this.NoiSinhCon,
                this.TenCon,
                this.SoCon,
                this.GioiTinhCon,
                this.CanNangCon,
                this.TinhTrangCon,
                this.GhiChu,
                this.NguoiDoDe,
                this.NguoiGhiPhieu,
                this.NguoiDaiDien,
                this.NgayCT,
                this.SinhConPhauThuat,
                this.SinhConDuoi32Tuan,
                this.HoTen});
                this.STT.VisibleIndex = 0;
                this.MaCT.VisibleIndex = 1;
                this.MaCSKCB.VisibleIndex = 2;
                this.MaThe.VisibleIndex = 3;
                this.SERI.VisibleIndex = 4;
                this.MaSoBHXH.VisibleIndex = 5;
                this.TenMe.VisibleIndex = 6;
                this.NgaySinh.VisibleIndex = 7;
                this.DiaChi.VisibleIndex = 8;
                this.CMND.VisibleIndex = 9;
                this.NgayCapCMND.VisibleIndex = 10;
                this.NoiCapCMND.VisibleIndex = 11;
                this.DanToc.VisibleIndex = 12;
                this.TenCha.VisibleIndex = 13;
                this.NgaySinhCon.VisibleIndex = 14;
                this.NoiSinhCon.VisibleIndex = 15;
                this.TenCon.VisibleIndex = 16;
                this.SoCon.VisibleIndex = 17;
                this.GioiTinhCon.VisibleIndex = 18;
                this.CanNangCon.VisibleIndex = 19;
                this.TinhTrangCon.VisibleIndex = 20;
                this.GhiChu.VisibleIndex = 21;
                this.NguoiDoDe.VisibleIndex = 22;
                this.NguoiGhiPhieu.VisibleIndex = 23;
                this.NguoiDaiDien.VisibleIndex = 24;
                this.NgayCT.VisibleIndex = 25;
                this.SinhConPhauThuat.VisibleIndex = 26;
                this.SinhConDuoi32Tuan.VisibleIndex = 27;
                this.HoTen.VisibleIndex = -1;
                gridControl.DataSource = nghiViecBHXHEntity.DSChungTuChungSinh();
            }


        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            //gridControl.ExportToXlsx("file path");
            string dummyFileName;
            if (cbLoaiCT.SelectedIndex == 0)
            {
                dummyFileName = "NghiBHXH_" + dateTuNgay.DateTime.ToString("ddMMyyyy");
            }else
            if (cbLoaiCT.SelectedIndex == 1)
            {
                dummyFileName = "RaVien_" + dateTuNgay.DateTime.ToString("ddMMyyyy");
            }
            else
            {
                dummyFileName = "ChungSinh_" + dateTuNgay.DateTime.ToString("ddMMyyyy");
            }

            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = dummyFileName;
            sf.Filter = "Excel (.xlsx)|*.xlsx";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                //string savePath = Path.GetDirectoryName(sf.FileName);
                // Do whatever
                gridControl.ExportToXlsx(sf.FileName);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            string err = "";
            // Hiện hộp thoại hỏi đáp 
            traloi = DevExpress.XtraEditors.XtraMessageBox.Show("Chắc chắn bạn muốn xóa mục này?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DataRow dr = gridView.GetFocusedDataRow();
            if (traloi == DialogResult.Yes && dr != null)
            {
                nghiViecBHXHEntity.MaLK = Utils.ToString(dr["MaLK"]);
                nghiViecBHXHEntity.TuNgay = DateTime.Now;
                nghiViecBHXHEntity.DenNgay = DateTime.Now;
                nghiViecBHXHEntity.NgayCT = DateTime.Now;
                if (!nghiViecBHXHEntity.SpNghiViec(ref err,"DELETE"))
                {
                    MessageBox.Show(err);
                    return;
                }
                nghiViecBHXHEntity.MaLK = null;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView.GetFocusedDataRow();
            if (dr != null)
            {
                if (cbLoaiCT.SelectedIndex == 0)
                {
                    FrmNghiViecBHXH frm = new FrmNghiViecBHXH(dr);
                    frm.ShowDialog();
                }else
                if (cbLoaiCT.SelectedIndex == 1)
                {
                    FrmRaVien frm = new FrmRaVien(dr);
                    frm.ShowDialog();
                }else
                {
                    FrmGiayChungSinh frm = new FrmGiayChungSinh(dr);
                    frm.ShowDialog();
                }

                LoadData();

            }
        }
    }
}
