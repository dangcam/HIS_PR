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
    public partial class FrmCanLamSan : RibbonForm
    {
        DataTable data;
        CanLamSanEntity canLamSan;
        FrmKQCanLamSan frmKQCanLamSan;
        public FrmCanLamSan()
        {
            InitializeComponent();
            canLamSan = new CanLamSanEntity();
            frmKQCanLamSan = new FrmKQCanLamSan();
            lookUpKhoa.Properties.DataSource = canLamSan.DSKhoaBan(3);
            lookUpKhoa.Properties.DisplayMember = "TenKhoa";
            lookUpKhoa.Properties.ValueMember = "MaKhoa";
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmCanLamSan_Load(object sender, EventArgs e)
        {
            if(lookUpKhoa.ItemIndex <0)
            {
                lookUpKhoa.EditValue = AppConfig.MaKhoa;
            }
            dateYLenh.DateTime = DateTime.Now;
            
            LoadData();
        }
        private void LoadData()
        {
            checkChuaKQ.Checked = false;
            data = canLamSan.DSBNCanLamSan(dateYLenh.DateTime,lookUpKhoa.EditValue.ToString());
            checkChuaKQ.Checked = true;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void checkChuaKQ_CheckedChanged(object sender, EventArgs e)
        {
            if(checkChuaKQ.Checked)
            {
                var dt = data.Select("KetQua = 0", "");
                gridControl.DataSource = dt.Length > 0 ? dt.CopyToDataTable() : null;
            }
        }

        private void checkCoKQ_CheckedChanged(object sender, EventArgs e)
        {
            if(checkCoKQ.Checked)
            {
                var dt = data.Select("KetQua = 1", "");
                gridControl.DataSource = dt.Length > 0 ? dt.CopyToDataTable() : null;
            }
        }

        private void checkTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTatCa.Checked)
                gridControl.DataSource = data;
        }

        private void btnNhapKQ_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView.GetFocusedDataRow();
            if (dr != null)
            {
                //if (!string.IsNullOrEmpty(dr["NgayThanhToan"].ToString()))
                //{
                //    XtraMessageBox.Show(Library.BenhNhanDaKhamRaVien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                frmKQCanLamSan.HoTen = dr["HoTen"].ToString();
                frmKQCanLamSan.TenCanLamSan = dr["Ten"].ToString();
                frmKQCanLamSan.YeuCau = dr["YeuCau"].ToString();
                frmKQCanLamSan.ChuanDoan = dr["ChuanDoan"].ToString();
                frmKQCanLamSan.MaNhom = Utils.ToInt(dr["MaNhom"]);
                frmKQCanLamSan.MaLK = dr["MaLK"].ToString();
                frmKQCanLamSan.MaCSL = dr["MaCLS"].ToString();
                frmKQCanLamSan.MaBacSi = dr["MaBS"].ToString();
                frmKQCanLamSan.MaMay = dr["MaMay"].ToString();
                frmKQCanLamSan.MauSo = dr["MauSo"].ToString();
                frmKQCanLamSan.NamSinh = dr["NgaySinh"].ToString();
                frmKQCanLamSan.GioiTinh = dr["GioiTinh"].ToString();
                frmKQCanLamSan.SoThe = dr["MaThe"].ToString();
                frmKQCanLamSan.DiaChi = dr["DiaChi"].ToString();
                frmKQCanLamSan.MaKhoa = dr["KhoaBan"].ToString();
                frmKQCanLamSan.ShowDialog();
                LoadData();
            }
        }
    }
}
