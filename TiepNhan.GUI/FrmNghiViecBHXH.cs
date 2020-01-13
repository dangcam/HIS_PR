using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class FrmNghiViecBHXH : RibbonForm
    {
        DataRow dataRow;
        NghiViecBHXHEntity nghiViecBHXHEntity;
        bool them = true;
        public FrmNghiViecBHXH(DataRow dr)
        {
            InitializeComponent();
            this.dataRow = dr;
            nghiViecBHXHEntity = new NghiViecBHXHEntity();
        }

        private void FrmNghiViecBHXH_Load(object sender, EventArgs e)
        {
            lookUpBenh.Properties.DataSource = nghiViecBHXHEntity.DSBenh();
            lookUpBacSi.Properties.DataSource = nghiViecBHXHEntity.DSBacSi();
            
            txtHoTen.Text = Utils.ToString(dataRow["HoTen"]);
            lookUpBenh.EditValue = dataRow["MaBenh"];
            txtTuNgay.DateTime = Utils.ToDateTime(dataRow["NgayVao"].ToString());
            txtDenNgay.DateTime = txtTuNgay.DateTime.AddDays(1);
            txtNgayChungTu.DateTime = txtTuNgay.DateTime;
            nghiViecBHXHEntity.MaLK = Utils.ToString(dataRow["MaLK"]);
            nghiViecBHXHEntity.NgayCT = txtNgayChungTu.DateTime;
            txtBHXH.Text = Utils.LaySoBHXH(dataRow["MaThe"]);
            DataTable data = nghiViecBHXHEntity.ThongTin(0);
            if(data!=null && data.Rows.Count>0)
            {
                them = false;
                txtMaCT.Text = Utils.ToString(data.Rows[0]["MaCT"]);
                txtSoPhieu.Text = Utils.ToString(data.Rows[0]["SoPhieu"]);
                lookUpBacSi.EditValue = data.Rows[0]["MaBS"];
                txtBHXH.Text = Utils.ToString(data.Rows[0]["MaSoBHXH"]);
                txtTenCha.Text = Utils.ToString(data.Rows[0]["TenCha"]);
                txtTenMe.Text = Utils.ToString(data.Rows[0]["TenMe"]);
                txtPPDieuTri.Text = Utils.ToString(data.Rows[0]["PPDieuTri"]);
                txtMaDonVi.Text = Utils.ToString(data.Rows[0]["MaDonVi"]);
                txtTenDonVi.Text = Utils.ToString(data.Rows[0]["TenDonVi"]);
                txtTuNgay.DateTime = Utils.ToDateTime(data.Rows[0]["TuNgay"].ToString());
                txtDenNgay.DateTime = Utils.ToDateTime(data.Rows[0]["DenNgay"].ToString());
                txtSoNgayNghi.Text = Utils.ToString(data.Rows[0]["SoNgay"]);
                txtNgayChungTu.DateTime = Utils.ToDateTime(data.Rows[0]["NgayCT"].ToString());
                txtNguoiDaiDien.Text = Utils.ToString(data.Rows[0]["NguoiDaiDien"]);
            }
            else
            {
                them = true;
                txtSoPhieu.Text = Utils.ToString(nghiViecBHXHEntity.SoChungTu(0));
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // số seri là số chứng từ
            RptCNNghiViec rpt = new RptCNNghiViec();
            rpt.xrlblHoTen.Text = Utils.ToString(dataRow["HoTen"]);
            rpt.xrlblNgaySinh.Text = Utils.ToString(dataRow["NgaySinh"]);
            rpt.xrlblGioiTinh.Text = Utils.ToString(dataRow["GioiTinh"]) == "0" ? "Nam" : "Nữ";
            rpt.xrlblBHYT.Text = Utils.ToString(dataRow["MaThe"]);
            rpt.xrlblChuanDoan.Text = Utils.ToString(lookUpBenh.Properties.GetDisplayValueByKeyValue(lookUpBenh.EditValue)) + ". "+ txtPPDieuTri.Text;
            DateTime ngayIn = Utils.ToDateTime(txtNgayChungTu.Text,"dd/MM/yyyy");
            rpt.xrlblNgayThangNam.Text = "Ngày " + ngayIn.Day + " tháng " + ngayIn.Month + " năm " + ngayIn.Year;// ngày chứng từ
            rpt.xrlblTenCha.Text = txtTenCha.Text;
            rpt.xrlblTenMe.Text = txtTenMe.Text;
            rpt.xrlblSoCT.Text = txtMaCT.Text;
            rpt.xrtxtSoPhieu.Text = "Số: "+txtSoPhieu.Text + "/ KCB";
            rpt.xrlblSoNgayNghi.Text = txtSoNgayNghi.Text;
            rpt.xrlblTuNgay.Text = txtTuNgay.DateTime.ToString("dd/MM/yyyy");
            rpt.xrlblDenNgay.Text = txtDenNgay.DateTime.ToString("dd/MM/yyyy");
            rpt.xrlblDonVi.Text =txtMaDonVi.Text +" "+ txtTenDonVi.Text;
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
        }

        private void txtDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            txtSoNgayNghi.Text = ((txtDenNgay.DateTime - txtTuNgay.DateTime).Days + 1).ToString();
        }

        private void lookUpBacSi_EditValueChanged(object sender, EventArgs e)
        {
            txtNguoiDaiDien.Text = Utils.ToString(lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue));
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            nghiViecBHXHEntity.MaCT = txtMaCT.Text;
            nghiViecBHXHEntity.SoPhieu = Utils.ToInt(txtSoPhieu.Text);
            nghiViecBHXHEntity.MaBS = Utils.ToString(lookUpBacSi.EditValue);
            nghiViecBHXHEntity.TenBS = Utils.ToString(lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue)); ;
            nghiViecBHXHEntity.MaSoBHXH = txtBHXH.Text;
            nghiViecBHXHEntity.TenCha = txtTenCha.Text;
            nghiViecBHXHEntity.TenMe = txtTenMe.Text;
            nghiViecBHXHEntity.PPDieuTri = txtPPDieuTri.Text;
            nghiViecBHXHEntity.MaDonVi = txtMaDonVi.Text;
            nghiViecBHXHEntity.TenDonVi = txtTenDonVi.Text;
            nghiViecBHXHEntity.TuNgay = txtTuNgay.DateTime;
            nghiViecBHXHEntity.DenNgay = txtDenNgay.DateTime;
            nghiViecBHXHEntity.SoNgay = Utils.ToInt(txtSoNgayNghi.Text);
            nghiViecBHXHEntity.NgayCT = txtNgayChungTu.DateTime;
            nghiViecBHXHEntity.NguoiDaiDien = txtNguoiDaiDien.Text;
            nghiViecBHXHEntity.MaBenh = Utils.ToString(lookUpBenh.EditValue);
            nghiViecBHXHEntity.LoaiCT = 0;
            string err = "";
            if(!nghiViecBHXHEntity.SpCapNhatMaBenh(ref err))
            {
                XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string action = "UPDATE";
            if (them)
                action = "INSERT";
            if(!nghiViecBHXHEntity.SpNghiViec(ref err,action))
            {
                XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            them = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLaySoCT_Click(object sender, EventArgs e)
        {
            txtSoPhieu.Text = Utils.ToString(nghiViecBHXHEntity.SoChungTu());
        }
    }
}
