using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
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
    public partial class FrmRaVien : RibbonForm
    {
        NghiViecBHXHEntity nghiViecBHXHEntity;
        DataRow dataRow;
        private bool them = true;
        Dictionary<string, string> khoaBan = new Dictionary<string, string>();
        public FrmRaVien(DataRow dr)
        {
            InitializeComponent();
            dataRow = dr;
            nghiViecBHXHEntity = new NghiViecBHXHEntity();
            khoaBan = nghiViecBHXHEntity.DSKhoaBan(1).AsEnumerable().ToDictionary<DataRow, string, string>
                (row=>row["MaKhoa"].ToString(),row=>row["TenKhoa"].ToString());
        }
        public int KetQuaDieuTri { get; set; }
        public int TinhTrangRaVien { get; set; }
        private void FrmRaVien_Load(object sender, EventArgs e)
        {
            cbTinhTrangRaVien.SelectedIndex = 0;
            cbKetQua.SelectedIndex = 0;          
            txtHoTen.Text = Utils.ToString(dataRow["HoTen"]);
            txtDanToc.EditValue = 1;
            
            nghiViecBHXHEntity.MaLK = Utils.ToString(dataRow["MaLK"]);
            DataTable data = nghiViecBHXHEntity.ThongTin();//nghiViecBHXHEntity.ThongTin(1);
            txtDanToc.Properties.DataSource = nghiViecBHXHEntity.DSDanToc();
            lookUpBacSi.Properties.DataSource = nghiViecBHXHEntity.DSBacSi();
            if (data != null && data.Rows.Count > 0)
            {
                them = false;
                txtBHXH.Text = Utils.ToString(data.Rows[0]["MaSoBHXH"]);
                txtDanToc.EditValue = data.Rows[0]["DanToc"];
                txtMaCT.Text = Utils.ToString(data.Rows[0]["MaCT"]);
                txtSoPhieu.Text = Utils.ToString(data.Rows[0]["SoPhieu"]);
                txtNgheNghiep.Text = Utils.ToString(data.Rows[0]["NgheNghiep"]);
                txtPPDieuTri.Text = Utils.ToString(data.Rows[0]["PPDieuTri"]);
                txtNgayChungTu.DateTime = Utils.ToDateTime(data.Rows[0]["NgayCT"].ToString());
                txtNguoiDaiDien.Text = Utils.ToString(data.Rows[0]["NguoiDaiDien"]);
                txtGhiChu.Text = Utils.ToString(data.Rows[0]["GhiChu"]);
                lookUpBacSi.EditValue = data.Rows[0]["MaBS"];
                txtTuoiThai.Text = Utils.ToString(data.Rows[0]["TuoiThai"]);
                dateNgayRa.DateTime = Utils.ToDateTime(dataRow["NgayRa"]);
            }
            else
            {
                them = true;
                txtSoPhieu.Text = Utils.ToString(nghiViecBHXHEntity.SoChungTu(1));
                txtBHXH.Text = Utils.LaySoBHXH(dataRow["MaThe"]);
                txtNgayChungTu.DateTime = DateTime.Now;
                dateNgayRa.DateTime = DateTime.Now;
            }
        }
        private void Luu()
        {
            this.KetQuaDieuTri = cbKetQua.SelectedIndex + 1;
            this.TinhTrangRaVien = cbTinhTrangRaVien.SelectedIndex + 1;
            nghiViecBHXHEntity.MaCT = txtMaCT.Text;
            nghiViecBHXHEntity.SoPhieu = Utils.ToInt(txtSoPhieu.Text);
            nghiViecBHXHEntity.MaBS = Utils.ToString(lookUpBacSi.EditValue);
            nghiViecBHXHEntity.MaSoBHXH = txtBHXH.Text;
            nghiViecBHXHEntity.PPDieuTri = txtPPDieuTri.Text;
            nghiViecBHXHEntity.DanToc = Utils.ToInt(txtDanToc.EditValue, 1);
            nghiViecBHXHEntity.NgheNghiep = txtNgheNghiep.Text;
            nghiViecBHXHEntity.TenBS = Utils.ToString(lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue));
            nghiViecBHXHEntity.GhiChu = txtGhiChu.Text;
            nghiViecBHXHEntity.TuNgay = Utils.ToDateTime(dataRow["NgayVao"].ToString());
            nghiViecBHXHEntity.DenNgay = dateNgayRa.DateTime;
            nghiViecBHXHEntity.NgayCT = txtNgayChungTu.DateTime;
            nghiViecBHXHEntity.NguoiDaiDien = txtNguoiDaiDien.Text;
            nghiViecBHXHEntity.TuoiThai = Utils.ToInt(txtTuoiThai.Text);
            nghiViecBHXHEntity.LoaiCT = 1;//
            string err = "";
            string action = "UPDATE_RaVien";
            if (them)
                action = "INSERT";
            if (!nghiViecBHXHEntity.SpNghiViec(ref err, action))
            {
                XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            them = false;
            this.DialogResult = DialogResult.OK;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            Luu();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnLuuIn_Click(object sender, EventArgs e)
        {
            Luu();
            //In();
            InA5();
        }
        private void In()
        {
            RptRaVien rpt = new RptRaVien();
            rpt.xrlblHoTen.Text = "Họ tên người bệnh :"+Utils.ToString(dataRow["HoTen"]);
            rpt.xrlblTuoi.Text = "Tuổi: " + (DateTime.Now.Year - Utils.ToNgaySinh(dataRow["NgaySinh"]).Year);
            rpt.xrlblGioiTinh.Text = Utils.ToString(dataRow["GioiTinh"]) == "0" ? "Nam" : "Nữ";
            rpt.xrlblSoBHYT.Text = "Số: "+ Utils.ToString(dataRow["MaThe"]);
            rpt.xrlblDanToc.Text ="- Dân tộc: "+ Utils.ToString(txtDanToc.Properties.GetDisplayValueByKeyValue(txtDanToc.EditValue));
            rpt.xrlblNgheNghiep.Text = "Nghề nghiệp: " + txtNgheNghiep.Text;
            rpt.xrlblChuanDoan.Text = "- Chuẩn đoán: "+ Utils.ToString(dataRow["TenBenh"]);// + ". " + txtPPDieuTri.Text;
            //DateTime ngayIn = Utils.ToDateTime(txtNgayChungTu.Text,"dd/MM/yyyy");
            rpt.xrlblNgayRa.Text = "Ngày " + txtNgayChungTu.DateTime.Day + " tháng "
                + txtNgayChungTu.DateTime.Month + " năm " + txtNgayChungTu.DateTime.Year;// ngày chứng từ
            rpt.xrlblNgayRa2.Text = rpt.xrlblNgayRa.Text;
            rpt.xrlblGiatriBHYT.Text = "- BHYT: giá trị từ "+ Utils.ToDateTime(dataRow["TheTu"]).ToString("dd/MM/yyyy") + " đến " 
                + Utils.ToDateTime(dataRow["TheDen"]).ToString("dd/MM/yyyy");
            rpt.xrlblDiaChi.Text = "- Địa chỉ: "+ Utils.ToString(dataRow["DiaChi"]);
            DateTime ngayVao = Utils.ToDateTime(dataRow["NgayVao"]);
            rpt.xrlblVaoVien.Text = "- Vào viện lúc: "+ngayVao.Hour+" giờ "+ngayVao.Minute+" phút, ngày " 
                + ngayVao.Day + " tháng " + ngayVao.Month + " năm " + ngayVao.Year;
            DateTime ngayRa;
            if (Utils.ToString(dataRow["NgayRa"]).Length > 0)
            {
                ngayRa = Utils.ToDateTime(dataRow["NgayRa"]);
            }
            else
                ngayRa = DateTime.Now;
            rpt.xrlblRaVien.Text = "- Ra viện lúc: " + ngayRa.Hour + " giờ " + ngayRa.Minute + " phút, ngày "
                + ngayRa.Day + " tháng " + ngayRa.Month + " năm " + ngayRa.Year;
            rpt.xrlblSoPhieu.Text = "Số lưu trữ: " + txtSoPhieu.Text;
            rpt.xrlblTenCoSo.Text = AppConfig.TenCoSoKCB.ToUpper();
            string makhoa = Utils.ToString(dataRow["MaKhoa"]);
            if(khoaBan.ContainsKey(makhoa))
            {
                rpt.xrlblKhoa.Text = "Khoa: " + khoaBan[makhoa];
            }
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
        }
        private void InA5()
        {
            RptRaVienA5 rpt = new RptRaVienA5();
            rpt.xrlblHoTen.Text = "Họ tên người bệnh :" + Utils.ToString(dataRow["HoTen"]);
            rpt.xrlblTuoi.Text = "Tuổi: " + (DateTime.Now.Year - Utils.ToNgaySinh(dataRow["NgaySinh"]).Year);
            rpt.xrlblGioiTinh.Text = Utils.ToString(dataRow["GioiTinh"]) == "0" ? "Nam" : "Nữ";
            rpt.xrlblMaSoBHXH.Text = "- Mã số BHXH: " + txtBHXH.Text;
            rpt.xrlblDanToc.Text = "- Dân tộc: " + Utils.ToString(txtDanToc.Properties.GetDisplayValueByKeyValue(txtDanToc.EditValue));
            rpt.xrlblNgheNghiep.Text = "Nghề nghiệp: " + txtNgheNghiep.Text;
            rpt.xrlblChuanDoan.Text = "- Chẩn đoán: " + Utils.ToString(dataRow["TenBenh"]);// + ". " + txtPPDieuTri.Text;
            //DateTime ngayIn = Utils.ToDateTime(txtNgayChungTu.Text,"dd/MM/yyyy");
            rpt.xrlblNgayRa.Text = "Ngày " + txtNgayChungTu.DateTime.Day + " tháng "
                + txtNgayChungTu.DateTime.Month + " năm " + txtNgayChungTu.DateTime.Year;// ngày chứng từ
            rpt.xrlblNgayRa2.Text = rpt.xrlblNgayRa.Text;
            //
            string maThe = Utils.ToString(dataRow["MaThe"]);
            if (maThe.Length > 1)
            {
                rpt.xrTableBHYT.Rows[0].Cells[0].Text = maThe.Substring(0, 2);
                rpt.xrTableBHYT.Rows[0].Cells[1].Text = maThe.Substring(2, 1);
                rpt.xrTableBHYT.Rows[0].Cells[2].Text = maThe.Substring(3, 2);
                rpt.xrTableBHYT.Rows[0].Cells[3].Text = maThe.Substring(5, 10);
            }
            //
            rpt.xrlblDiaChi.Text = "- Địa chỉ: " + Utils.ToString(dataRow["DiaChi"]);
            DateTime ngayVao = Utils.ToDateTime(dataRow["NgayVao"]);
            rpt.xrlblVaoVien.Text = "- Vào viện lúc: " + ngayVao.Hour + " giờ " + ngayVao.Minute + " phút, ngày "
                + ngayVao.Day + " tháng " + ngayVao.Month + " năm " + ngayVao.Year;
            DateTime ngayRa;
                ngayRa = dateNgayRa.DateTime;
            rpt.xrlblRaVien.Text = "- Ra viện lúc: " + ngayRa.Hour + " giờ " + ngayRa.Minute + " phút, ngày "
                + ngayRa.Day + " tháng " + ngayRa.Month + " năm " + ngayRa.Year;
            rpt.xrlblSoPhieu.Text = "Số lưu trữ: " + txtSoPhieu.Text;
            rpt.xrlblTenCoSo.Text = AppConfig.TenCoSoKCB.ToUpper();
            rpt.xrlblGhiChu.Text ="- Ghi chú: "+ txtGhiChu.Text;
            string makhoa = Utils.ToString(dataRow["MaKhoa"]);
            if (khoaBan.ContainsKey(makhoa))
            {
                rpt.xrlblKhoa.Text = "Khoa: " + khoaBan[makhoa];
            }
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
        }
    }
}
