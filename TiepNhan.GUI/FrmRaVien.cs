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
    public partial class FrmRaVien : RibbonForm
    {
        NghiViecBHXHEntity nghiViecBHXHEntity;
        DataRow dataRow;
        private bool them = true;
        public FrmRaVien(DataRow dr)
        {
            InitializeComponent();
            dataRow = dr;
            nghiViecBHXHEntity = new NghiViecBHXHEntity();
        }
        public int KetQuaDieuTri { get; set; }
        public int TinhTrangRaVien { get; set; }
        private void FrmRaVien_Load(object sender, EventArgs e)
        {
            cbTinhTrangRaVien.SelectedIndex = 0;
            cbKetQua.SelectedIndex = 0;          
            txtHoTen.Text = Utils.ToString(dataRow["HoTen"]);
            
            nghiViecBHXHEntity.MaLK = Utils.ToString(dataRow["MaLK"]);
            DataTable data = nghiViecBHXHEntity.ThongTin(1);
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
            }
            else
            {
                them = true;
                txtSoPhieu.Text = Utils.ToString(nghiViecBHXHEntity.SoChungTu(1));
                txtBHXH.Text = Utils.LaySoBHXH(dataRow["MaThe"]);
                txtNgayChungTu.DateTime = DateTime.Now;
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
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
            nghiViecBHXHEntity.DenNgay = DateTime.Now;
            nghiViecBHXHEntity.NgayCT = txtNgayChungTu.DateTime;
            nghiViecBHXHEntity.NguoiDaiDien = txtNguoiDaiDien.Text;
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
