using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DuocPham.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuocPham.GUI
{
    public partial class FrmBangKeNhapThuoc : RibbonForm
    {
        NhapKhoEntity nhapkho;
        public FrmBangKeNhapThuoc()
        {
            InitializeComponent();
            nhapkho = new NhapKhoEntity();
        }

        private void FrmBangKeNhapThuoc_Load(object sender, EventArgs e)
        {
            cbThang.SelectedIndex = DateTime.Now.Month - 1;
            for(int y = DateTime.Now.Year - 5; y< DateTime.Now.Year + 5;y++)
            {
                cbNam.Properties.Items.Add(y);
            }
            cbNam.SelectedIndex = 5;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            RptBangKeNhapThuoc rpt = new RptBangKeNhapThuoc();
            int thang = cbThang.SelectedIndex + 1;
            int nam = Utils.ToInt(cbNam.SelectedText);
            rpt.xrlblThangNam.Text = "Tháng " + thang + " năm " + nam;
            DataTable data = nhapkho.BKNhapThuoc(thang,nam);
            rpt.DataSource = data;
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();

            SplashScreenManager.CloseForm();
        }
    }
}
