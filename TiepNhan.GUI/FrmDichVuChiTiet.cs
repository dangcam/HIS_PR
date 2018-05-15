using Core.DAL;
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
    public partial class FrmDichVuChiTiet : RibbonForm
    {
        HoSoEntity hoso ;
        Dictionary<string, int> listDichVu;
        DataView dvDichVu;
        public FrmDichVuChiTiet()
        {
            InitializeComponent();
            hoso = new HoSoEntity();
        }
        public string MaLK { get; set; }
        public string MaKhoa { get; set; }
        public string MaBacSi { get; set; }

        private void FrmDichVuChiTiet_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lookUpDichVu;
            dateNgayYLenh.DateTime = DateTime.Now;
            hoso.MaLK = this.MaLK;
            dvDichVu = hoso.DSDichVuChiTiet().AsDataView();
            gridControl.DataSource = dvDichVu;
            lookUpDichVu.Properties.DisplayMember = "TenDVKT";
            
            lookUpDichVu.Properties.DataSource = hoso.DSDichVu();
            listDichVu = new Dictionary<string, int>();
            foreach (DataRowView dr in dvDichVu)
            {
                // 0. xóa, 1. đã có, 2. thêm mới
                listDichVu.Add(dr["MaDichVu"].ToString(), 1);
            }
        }

        private void lookUpDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoLuong.Focus();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaTri.Focus();
        }

        private void txtGiaTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMoTa.Focus();
        }

        private void txtMoTa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtKetLuan.Focus();
        }

        private void txtKetLuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnChon.Focus();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (lookUpDichVu.EditValue is DataRowView)
            {
                DataRowView dr = (lookUpDichVu.EditValue as DataRowView);
                string maDichVu = dr["MaDVKT"].ToString();
                if (listDichVu.ContainsKey(maDichVu))
                {
                    if (listDichVu[maDichVu] > 0)// đã có và 1 hoặc 2
                    {
                        XtraMessageBox.Show(Library.DichVuDaDuocChon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lookUpDichVu.Focus();
                    }
                    else//listDichVu[maDichVu] ==0
                    {
                        listDichVu[maDichVu] = 1;// đã có và đánh dấu 0. xóa, cập nhật lại
                    }
                }
                else
                {
                    listDichVu.Add(maDichVu, 2);// 2. thêm mới
                }
                DataRowView drvNew = (gridControl.DataSource as DataView).AddNew();
                drvNew["MaDichVu"] = maDichVu;
                drvNew["TenDichVu"] = dr["TenDVKT"];
                drvNew["SoLuong"] = txtSoLuong.Value;
                drvNew["DonGia"] = dr["DonGia"];
                drvNew["ThanhTien"] = txtSoLuong.Value * Utils.ToDecimal(dr["DonGia"]);
                drvNew["NgayKQ"] = DateTime.Now;
                drvNew["GiaTri"] = txtGiaTri.Text;
                drvNew["MoTa"] = txtMoTa.Text;
                drvNew["KetLuan"] = txtKetLuan.Text;
                drvNew["NgayYLenh"] = DateTime.Now;
                drvNew["MaChiSo"] = dr["TT50"];
                drvNew["MaMay"] = dr["MaMay"];
                drvNew["MaNhom"] = dr["MaNhom"];
                drvNew.EndEdit();
                lookUpDichVu.Focus();
                txtGiaTri.Text = "";
                txtMoTa.Text = "";
                txtKetLuan.Text = "";
            }
        }

        private void repBtnXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = gridView.GetFocusedDataSourceRowIndex();
            if (index > -1)
            {
                // 0. xóa
                string key = (dvDichVu.ToTable().Rows[index]["MaDichVu"].ToString());
                if (listDichVu[key] == 1)
                    listDichVu[key] = 0;
                else
                    listDichVu.Remove(key);
                (gridControl.DataSource as DataView).Delete(index);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            List<string> keys = new List<string>(listDichVu.Keys);
            hoso.MaLK = this.MaLK;
            hoso.MaKhoa = this.MaKhoa;
            hoso.MaBacSi = this.MaBacSi;
            foreach (string key in keys)
            {
                if (listDichVu[key] == 0)
                {
                    // xóa
                    err = "";
                    hoso.MaDichVu = key;
                    hoso.NgayKQ = DateTime.Now;
                    hoso.NgayYLenh = DateTime.Now;
                    if (hoso.SpDichVuChiTiet(ref err, "DELETE"))
                    {
                        listDichVu.Remove(key);
                    }
                }
            }
            foreach (DataRowView drv in dvDichVu)
            {
                err = "";

                hoso.MaDichVu = drv["MaDichVu"].ToString();
                hoso.TenDichVu = drv["TenDichVu"].ToString();
                hoso.DonViTinh = "Lần";
                hoso.SoLuong = Utils.ToInt(drv["SoLuong"]);
                hoso.DonGia = Utils.ToDecimal(drv["DonGia"]);
                hoso.TyLe = 100;
                hoso.ThanhTien = Utils.ToDecimal(drv["ThanhTien"]);
                hoso.MaNhom =Utils.ToInt(drv["MaNhom"]);
                hoso.NgayYLenh = Utils.ToDateTime(drv["NgayYLenh"].ToString());
                hoso.NgayKQ = Utils.ToDateTime(drv["NgayKQ"].ToString());
                hoso.MaChiSo = drv["MaChiSo"].ToString(); ;
                hoso.GiaTri = drv["GiaTri"].ToString();
                hoso.MoTa = drv["MoTa"].ToString();
                hoso.KetLuan = drv["KetLuan"].ToString();
                hoso.MaMay = drv["MaMay"].ToString();
                if (listDichVu[hoso.MaDichVu] == 1)
                {
                    // cập nhật
                    hoso.SpDichVuChiTiet(ref err, "UPDATE");
                }
                else if (listDichVu[hoso.MaDichVu] == 2)
                {
                    // thêm mới
                    if (hoso.SpDichVuChiTiet(ref err, "INSERT"))
                        listDichVu[hoso.MaDichVu] = 1;
                }
                if (!string.IsNullOrEmpty(err))
                {
                    XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
