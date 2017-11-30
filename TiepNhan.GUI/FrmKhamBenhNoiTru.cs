﻿using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using KhamBenh.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiepNhan.GUI
{
    public partial class FrmKhamBenhNoiTru : RibbonForm
    {
        KhamBenhEntity khambenh;
        FrmCDCanLamSan frmCanLamSan;
        DataRow drThongTin;
        private string maBenhChinh = null;
        DataTable dtBenh;
        DataTable dataCoSo;
        public FrmKhamBenhNoiTru()
        {
            InitializeComponent();
            frmCanLamSan = new FrmCDCanLamSan(khambenh);
            khambenh = new KhamBenhEntity();
            lookUpKhoa.Properties.DataSource = khambenh.DSKhoaBan(1);
            lookUpKhoa.Properties.ValueMember = "MaKhoa";
            lookUpKhoa.Properties.DisplayMember = "TenKhoa";
            lookUpBacSi.Properties.DataSource = this.khambenh.DSBacSi();
            lookUpBacSi.Properties.ValueMember = "Ma_BS";
            lookUpBacSi.Properties.DisplayMember = "Ten_NV";
            dtBenh = khambenh.DSBenh();
            lookUpMaBenh.Properties.DataSource = dtBenh;
            lookUpMaBenh.Properties.DisplayMember = "MaBenh";
            lookUpMaBenhKhac.Properties.DisplayMember = "MaBenh";
            lookUpMaBenhKhac.Properties.DataSource = dtBenh;
            dataCoSo = khambenh.DSCoSoKCB();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmKhamBenhNoiTru_Load(object sender, EventArgs e)
        {
            lookUpBacSi.ItemIndex = 0;
            lookUpKhoa.EditValue = AppConfig.MaKhoa;
            dateTuNgay.DateTime = dateDenNgay.DateTime = DateTime.Now;
            LoadData();
        }
        private void LoadData()
        {
            gridControl.DataSource = khambenh.DSBenhNhanNoiTru(dateTuNgay.DateTime.ToShortDateString(),
                dateDenNgay.DateTime.ToShortDateString(),lookUpKhoa.EditValue.ToString());
        }
        private void LoadDataChiTiet()
        {
            khambenh.MaLK = drThongTin["MaLK"].ToString();
            gridControlThuoc.DataSource = khambenh.DSThuocChiTiet();
            gridControlDVKT.DataSource = khambenh.DSDichVuChiTiet();
            gridControlVTYT.DataSource = khambenh.DSVatTuChiTiet();
        }
        private void xtraTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
           if(xtraTabControl.SelectedTabPageIndex ==0)
            {
                btnTim.Enabled = true;
                btnNhapHoSo.Enabled = true;
            }
           else
            {
                btnTim.Enabled = false;
                btnNhapHoSo.Enabled = false;
                if(drThongTin==null)
                {
                    txtTenBenh.Text = null;
                    txtNgaySinh.Text = null;
                    txtMaBenhKhac.Text = null;
                    txtHoTen.Text = null;
                    gridControlThuoc.DataSource = null;
                    gridControlDVKT.DataSource = null;
                    gridControlVTYT.DataSource = null;
                    lblHanThe.Text = null;
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCanLamSan_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView.GetFocusedDataRow();
            if (dr != null)
            {
                if (!string.IsNullOrEmpty(dr["NgayThanhToan"].ToString()))
                {
                    XtraMessageBox.Show(Library.BenhNhanDaKhamRaVien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmCanLamSan.HoTen = dr["HoTen"].ToString();
                frmCanLamSan.MaLK = dr["MaLK"].ToString();
                frmCanLamSan.GioiTinh = dr["GioiTinh"].ToString();
                frmCanLamSan.TheBHYT = dr["MaThe"].ToString();
                frmCanLamSan.DiaChi = dr["DiaChi"].ToString();
                frmCanLamSan.NamSinh = dr["NgaySinh"].ToString();
                frmCanLamSan.ShowDialog();
            }
        }

        private void btnNhapHoSo_Click(object sender, EventArgs e)
        {
            drThongTin  = gridView.GetFocusedDataRow();
            if(drThongTin != null)
            {
                xtraTabControl.SelectedTabPageIndex = 1;
                txtHoTen.Text = drThongTin["HoTen"].ToString();
                txtNgaySinh.Text = drThongTin["NgaySinh"].ToString();
                txtMaBenhKhac.Text = drThongTin["MaBenhKhac"].ToString();
                txtTenBenh.Text = drThongTin["TenBenh"].ToString();
                if (Utils.ToBoolean(drThongTin["CoThe"]))
                {
                    lblHanThe.Text = "Hạn thẻ BHYT còn: " + (Utils.ToDateTime(drThongTin["TheDen"].ToString()) - DateTime.Now).Days + " ngày";
                }
                else
                {
                    lblHanThe.Text = "Bệnh nhân không có thẻ BHYT";
                }
                maBenhChinh = drThongTin["MaBenh"].ToString();
                //lookUpMaBenh.EditValue = maBenhChinh;// lỗi
                //
                LoadDataChiTiet();
            }
        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "GioiTinh")
            {
                if (Utils.ToInt(e.Value) == 0)
                    e.DisplayText = "Nam";
                else
                    e.DisplayText = "Nữ";
            }
            else
               if (e.Column.Name == "MaLyDoVaoVien")
            {
                switch (Utils.ToInt(e.Value))
                {
                    case 1:
                        e.DisplayText = "Đúng tuyến";
                        break;
                    case 2:
                        e.DisplayText = "Cấp cứu";
                        break;
                    case 3:
                        e.DisplayText = "Trái tuyến";
                        break;
                    default:
                        e.DisplayText = "Thông tuyến";
                        break;
                }
            }
        }

        

        private void btnChuyenKhoa_Click(object sender, EventArgs e)
        {
            // MaLoaiKCB 1. Khám bệnh, 2. Điều trị ngoại trú, 3. Điều trị nội trú
            // chọn khoa: MaKhoa
            DataRow dr = gridView.GetFocusedDataRow();
            if (dr != null)
            {
                FrmChonKhoa frm = new FrmChonKhoa(khambenh.DSKhoaBan(1));
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    string err = "";
                    khambenh.MaLK = dr["MaLK"].ToString();
                    khambenh.MaLoaiKCB = 3;
                    khambenh.MaKhoa = frm.MaKhoa;
                    if (!khambenh.SpNhapVien(ref err))
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LoadData();
                }
            }
        }

        private void btnRaVien_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView.GetFocusedDataRow();
            if (dr != null)
            {
                FrmRaVien frm = new FrmRaVien();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    string err = "";
                    khambenh.MaLK = dr["MaLK"].ToString();
                    khambenh.TinhTrangRaVien = frm.TinhTrangRaVien;
                    khambenh.KetQuaDieuTri = frm.KetQuaDieuTri;
                    khambenh.NgayRa = DateTime.Now;
                    if (!khambenh.SpRaVien(ref err))
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LoadData();
                }
            }
        }
        private bool KiemTraBenhBacSi()
        {
            if(string.IsNullOrEmpty(maBenhChinh))
            {
                XtraMessageBox.Show("Chưa chọn bệnh chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpMaBenh.Focus();
                return false;
            }
            if(lookUpBacSi.ItemIndex<0)
            {
                XtraMessageBox.Show("Chưa chọn bác sĩ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpBacSi.Focus();
                return false;
            }
            return true;
        }

        private void lookUpMaBenh_EditValueChanged(object sender, EventArgs e)
        {
            object dr = lookUpMaBenh.GetSelectedDataRow();
            if (dr is DataRowView)
            {
                txtMaBenhKhac.Text = null;
                maBenhChinh = (dr as DataRowView)[0].ToString();
                txtTenBenh.Text = (dr as DataRowView)[1].ToString();
            }
            else
            {
                txtMaBenhKhac.Text = null;
                txtTenBenh.Text = null;
                maBenhChinh = null;
            }
        }

        private void lookUpMaBenhKhac_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(maBenhChinh))
            {
                object dr = lookUpMaBenhKhac.GetSelectedDataRow();
                if (dr is DataRowView && txtMaBenhKhac.Text.Split(';').Length < 10)
                {
                    string maBenhKhac = (dr as DataRowView)[0].ToString();
                    if (maBenhKhac != maBenhChinh && !txtMaBenhKhac.Text.Contains(maBenhKhac))
                    {
                        txtMaBenhKhac.Text += maBenhKhac + "; ";
                        txtTenBenh.Text += "; " + (dr as DataRowView)[1].ToString();
                    }
                    else
                    {
                        XtraMessageBox.Show("Mã bệnh đã được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa chọn bệnh chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpMaBenh.Focus();
            }
        }

        private void txtMaBenhKhac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(maBenhChinh))
                {
                    List<string> list = new List<string>();
                    foreach (string item in txtMaBenhKhac.Text.Split(';'))
                    {
                        if (!string.IsNullOrEmpty(item.Trim()) && !item.Trim().Equals(maBenhChinh)
                            && !list.Contains(item.Trim()))
                        {
                            list.Add(item.Trim());
                        }
                    }
                    txtMaBenhKhac.Text = "";
                    txtTenBenh.Text = dtBenh.Select("MaBenh = '" + maBenhChinh + "'", "")[0][1].ToString();
                    foreach (string item in list)
                    {
                        txtMaBenhKhac.Text += item + "; ";
                        var dr = dtBenh.Select("MaBenh = '" + item + "'", "");
                        if (dr != null)
                            txtTenBenh.Text += "; " + dr[0][1].ToString();

                    }
                    lookUpBacSi.Focus();
                }
                else
                {
                    lookUpMaBenh.Focus();
                }
            }
        }

        private void lookUpMaBenh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                lookUpMaBenhKhac.Focus();
        }

        private void lookUpMaBenhKhac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                lookUpBacSi.Focus();
        }

        private void btnGiuongBenh_Click(object sender, EventArgs e)
        {

            if (KiemTraBenhBacSi()&&drThongTin != null)
            {
                FrmGiuongBenh frm = new FrmGiuongBenh();
                frm.MaLK = drThongTin["MaLK"].ToString();
                frm.MaKhoa = lookUpKhoa.EditValue.ToString();
                frm.MaBacSi = lookUpBacSi.EditValue.ToString();
                frm.ShowDialog();
                LoadDataChiTiet();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (drThongTin != null)
            {
                // kiểm tra nhập mã bệnh
                if (string.IsNullOrEmpty(maBenhChinh))
                {
                    XtraMessageBox.Show("Chưa chọn bệnh chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpMaBenh.Focus();
                    return;
                }
                string err = "";
                // cập nhật mã bệnh, bảng thông tin chi tiết
                khambenh.MaLK = drThongTin["MaLK"].ToString();
                if (!khambenh.SpCapNhatBenh(ref err,
                    txtTenBenh.Text, maBenhChinh, txtMaBenhKhac.Text))
                {
                    XtraMessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDVKT_Click(object sender, EventArgs e)
        {
            if (KiemTraBenhBacSi() && drThongTin != null)
            {
                FrmDichVuChiTiet frm = new FrmDichVuChiTiet();
                frm.MaLK = drThongTin["MaLK"].ToString();
                frm.MaKhoa = lookUpKhoa.EditValue.ToString();
                frm.MaBacSi = lookUpBacSi.EditValue.ToString();
                frm.ShowDialog();
                LoadDataChiTiet();
            }
        }

        private void btnKeDon_Click(object sender, EventArgs e)
        {
            if (KiemTraBenhBacSi() && drThongTin != null)
            {
                FrmDonThuoc frm = new FrmDonThuoc(Utils.ToString(lookUpKhoa.EditValue));
                frm.MaLK = drThongTin["MaLK"].ToString();
                frm.MaKhoa = lookUpKhoa.EditValue.ToString();
                frm.MaBacSi = lookUpBacSi.EditValue.ToString();
                frm.HoTen = drThongTin["HoTen"].ToString();
                frm.NgaySinh = drThongTin["NgaySinh"].ToString();
                frm.GioiTinh = drThongTin["GioiTinh"].ToString();
                frm.DiaChi = drThongTin["DiaChi"].ToString();
                frm.MaThe = drThongTin["MaThe"].ToString();
                frm.TenBenh = txtTenBenh.Text;
                frm.TheTu = drThongTin["TheTu"].ToString();
                frm.TheDen = drThongTin["TheDen"].ToString(); 
                frm.TenBacSi = lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue).ToString();
                try
                {
                    frm.TenCoSo = dataCoSo.Select("Ma_CS = '" + AppConfig.CoSoKCB + "'", "")[0]["Ten_CS"].ToString();
                    frm.NoiDangKy = drThongTin["MaDKBD"] + "-" + dataCoSo.Select("Ma_CS = '" + drThongTin["MaDKBD"] + "'", "")[0]["Ten_CS"].ToString();
                }
                catch { }
                frm.ShowDialog();
                LoadDataChiTiet();
            }
        }

        private void btnVTYT_Click(object sender, EventArgs e)
        {
            if (KiemTraBenhBacSi() && drThongTin != null)
            {
                FrmVatTuChiTiet frm = new FrmVatTuChiTiet();
                frm.MaLK = drThongTin["MaLK"].ToString();
                frm.MaKhoa = lookUpKhoa.EditValue.ToString();
                frm.MaBacSi = lookUpBacSi.EditValue.ToString();
                frm.ShowDialog();
                LoadDataChiTiet();
            }
        }
    }
}
