using BaoCao.DAL;
using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaoCao.GUI
{
    public partial class FrmNguonNhap : RibbonForm
    {
        TonKhoEntity tonKho;
        DataTable dataDS;
        public FrmNguonNhap()
        {
            InitializeComponent();
            tonKho = new TonKhoEntity();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        //https://www.devexpress.com/Support/Center/Question/Details/T326869/displaying-sum-of-groupings-in-group-header
        //https://www.devexpress.com/Support/Center/Example/Details/T317187/how-to-use-aggregate-functions-in-calculated-field-expressions
        private void FrmNguonNhap_Load(object sender, EventArgs e)
        {
            dateDenNgay.DateTime = DateTime.Now;
            dateTuNgay.DateTime = DateTime.Now;
            btnIn.Enabled = false;
            btnInDuTru.Enabled = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.SoPhieu.Visible = true;
            this.NgayNhap.Visible = true;
            this.SoHoaDon.Visible = true;
            this.NguoiGiaoHang.Visible = true;
            //
            this.DonViTinh.Visible = false;
            this.DonGia.Visible = false;
            this.TenVatTu.Visible = false;
            this.SoLuongQuyDoi.Visible = false;
            this.ThanhTien.VisibleIndex = 5;
            //
            dataDS = tonKho.DSKhoNhap(dateTuNgay.DateTime,dateDenNgay.DateTime);
            gridControl.DataSource = dataDS;
            gridView.ExpandAllGroups();
            btnIn.Enabled = true;
            btnInDuTru.Enabled = false;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if(dataDS!=null)
            {
                SplashScreenManager.ShowForm(typeof(WaitFormLoad));
                RptNguonNhap rpt = new RptNguonNhap();
                rpt.xrlblThangNam.Text = "Từ ngày " + dateTuNgay.DateTime.ToString("dd/MM/yyyy") +
                    " đến ngày " + dateDenNgay.DateTime.ToString("dd/MM/yyyy");
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.xrlblKeToan.Text = txtKeToan.Text;
                rpt.xrlblKhoaDuoc.Text = txtKhoaDuoc.Text;
                rpt.xrlblNguoiLap.Text = txtNguoiLap.Text;
                rpt.DataSource = dataDS;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
                SplashScreenManager.CloseForm();
            }
        }

        private void btnTimDuTru_Click(object sender, EventArgs e)
        {
            btnIn.Enabled = false;
            btnInDuTru.Enabled = true;
            //
            this.SoPhieu.Visible = false;
            this.NgayNhap.Visible = false;
            this.SoHoaDon.Visible = false;
            this.NguoiGiaoHang.Visible = false;
            //
            this.TenVatTu.Visible = true;
            this.DonViTinh.Visible = true;
            this.DonGia.Visible = true;
            this.SoLuongQuyDoi.Visible = true;
            this.ThanhTien.VisibleIndex = 6;
            //
            dataDS = tonKho.DSDuTru(dateTuNgay.DateTime, dateDenNgay.DateTime);
            gridControl.DataSource = dataDS;
            gridView.ExpandAllGroups();
        }

        private void btnInDuTru_Click(object sender, EventArgs e)
        {
            if (dataDS != null)
            {
                SplashScreenManager.ShowForm(typeof(WaitFormLoad));
                RptDuTru rpt = new RptDuTru();
                rpt.xrlblThangNam.Text = "Từ ngày " + dateTuNgay.DateTime.ToString("dd/MM/yyyy") +
                    " đến ngày " + dateDenNgay.DateTime.ToString("dd/MM/yyyy");
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.xrlblKeToan.Text = txtKeToan.Text;
                rpt.xrlblKhoaDuoc.Text = txtKhoaDuoc.Text;
                rpt.xrlblNguoiLap.Text = txtNguoiLap.Text;
                rpt.DataSource = dataDS;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
                SplashScreenManager.CloseForm();
            }
        }
    }
}
