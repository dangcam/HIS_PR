using Core.DAL;
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
    public partial class FrmGiayChungSinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataRow dataRow;
        NghiViecBHXHEntity nghiViecBHXHEntity;
        private bool them;
        public FrmGiayChungSinh(DataRow dr)
        {
            InitializeComponent();
            dataRow = dr;
            nghiViecBHXHEntity = new NghiViecBHXHEntity();
        }

        private void FrmGiayChungSinh_Load(object sender, EventArgs e)
        {
            nghiViecBHXHEntity.MaLK = Utils.ToString(dataRow["MaLK"]);
            DataTable data = nghiViecBHXHEntity.ThongTin(2);
            txtHoTen.Text = Utils.ToString(dataRow["HoTen"]);
            lookupDanToc.Properties.DataSource = nghiViecBHXHEntity.DSDanToc();
            if (data != null && data.Rows.Count > 0)
            {
                them = false;
                txtBHXH.Text = Utils.ToString(data.Rows[0]["MaSoBHXH"]);
                txtMaCT.Text = Utils.ToString(data.Rows[0]["MaCT"]);
                txtSoPhieu.Text = Utils.ToString(data.Rows[0]["SoPhieu"]);
                txtCMND.Text = Utils.ToString(data.Rows[0]["CMND"]);
                txtNgayCap.DateTime = Utils.ToDateTime(data.Rows[0]["TuNgay"].ToString());
                txtNoiCap.Text = Utils.ToString(data.Rows[0]["NoiCap"]);
                lookupDanToc.EditValue = data.Rows[0]["DanToc"];
                txtHoTenCha.Text = Utils.ToString(data.Rows[0]["TenCha"]);
                txtHoTenMe.Text = Utils.ToString(data.Rows[0]["TenMe"]);
                txtTenCon.Text = Utils.ToString(data.Rows[0]["TenCon"]);
                dateNgaySinhCon.DateTime = Utils.ToDateTime(data.Rows[0]["DenNgay"].ToString());
                txtNoiSinhCon.Text = Utils.ToString(data.Rows[0]["NoiSinhCon"]);
                txtSoCon.Text = Utils.ToString(data.Rows[0]["SoCon"]);
                txtGioiTinhCon.SelectedIndex = Utils.ToInt(data.Rows[0]["GioiTinhCon"],1)-1;
                txtCanNang.Text = Utils.ToString(data.Rows[0]["CanNangCon"]);
                txtTinhTrangCon.Text = Utils.ToString(data.Rows[0]["TinhTrangCon"]);
                txtGhiChu.Text = Utils.ToString(data.Rows[0]["GhiChu"]);
                txtNguoiDoDe.Text = Utils.ToString(data.Rows[0]["nguoiDoDe"]);
                txtNguoiGhiPhieu.Text = Utils.ToString(data.Rows[0]["NguoiGhiPhieu"]);
                txtNguoiDaiDien.Text = Utils.ToString(data.Rows[0]["NguoiDaiDien"]);
                dateNgayCT.DateTime = Utils.ToDateTime(data.Rows[0]["NgayCT"].ToString());
                checkDuoi32Tuan.Checked = Utils.ToBoolean(data.Rows[0]["SinhConDuoi32Tuan"]);
                checkPhauThuat.Checked = Utils.ToBoolean(data.Rows[0]["SinhConPhauThuat"]);
            }
            else
            {
                them = true;
                dateNgayCT.DateTime = DateTime.Now;
                txtSoCon.Text = "1";
                txtSoPhieu.Text = Utils.ToString(nghiViecBHXHEntity.SoChungTu(1));
                txtNoiSinhCon.Text = AppConfig.TenCoSoKCB;
                txtBHXH.Text = Utils.LaySoBHXH(dataRow["MaThe"]);
                txtHoTenMe.Text = Utils.ToString(dataRow["HoTen"]);
                lookupDanToc.EditValue = 1;
            }
        }
        private void Luu()
        {
            nghiViecBHXHEntity.MaCT = txtMaCT.Text;
            nghiViecBHXHEntity.SoPhieu = Utils.ToInt(txtSoPhieu.Text);
            nghiViecBHXHEntity.MaSoBHXH = txtBHXH.Text;
            nghiViecBHXHEntity.TenCha = txtHoTenCha.Text;
            nghiViecBHXHEntity.TenMe = txtHoTenMe.Text;
            nghiViecBHXHEntity.TuNgay = txtNgayCap.DateTime;
            nghiViecBHXHEntity.DenNgay = dateNgaySinhCon.DateTime;
            nghiViecBHXHEntity.CMND = txtCMND.Text;
            nghiViecBHXHEntity.NoiCap = txtNoiCap.Text;
            nghiViecBHXHEntity.DanToc = Utils.ToInt(lookupDanToc.EditValue);
            nghiViecBHXHEntity.NoiSinhCon = txtNoiSinhCon.Text;
            nghiViecBHXHEntity.TenCon = txtTenCon.Text;
            nghiViecBHXHEntity.SoCon = Utils.ToInt(txtSoCon.Text,1);
            nghiViecBHXHEntity.GioiTinhCon = txtGioiTinhCon.SelectedIndex + 1;
            nghiViecBHXHEntity.CanNangCon = Utils.ToInt(txtCanNang.Text);
            nghiViecBHXHEntity.TinhTrangCon = txtTinhTrangCon.Text;
            nghiViecBHXHEntity.GhiChu = txtGhiChu.Text;
            nghiViecBHXHEntity.NguoiDoDe = txtNguoiDoDe.Text;
            nghiViecBHXHEntity.NguoiGhiPhieu = txtNguoiGhiPhieu.Text;
            nghiViecBHXHEntity.NgayCT = dateNgayCT.DateTime;
            nghiViecBHXHEntity.NguoiDaiDien = txtNguoiDaiDien.Text;
            nghiViecBHXHEntity.SinhConPhauThuat = checkPhauThuat.Checked;
            nghiViecBHXHEntity.SinhConDuoi32Tuan = checkDuoi32Tuan.Checked;
            nghiViecBHXHEntity.LoaiCT = 2;
            string err = "";
            //if (!nghiViecBHXHEntity.SpCapNhatMaBenh(ref err))
            //{
            //    XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            string action = "UPDATE_ChungSinh";
            if (them)
                action = "INSERT";
            if (!nghiViecBHXHEntity.SpNghiViec(ref err, action))
            {
                XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            them = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Luu();
        }

        private void btnLuuIn_Click(object sender, EventArgs e)
        {
            Luu();
        }
    }
}
