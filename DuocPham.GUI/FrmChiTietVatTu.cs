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
    public partial class FrmChiTietVatTu : RibbonForm
    {
        XuatKhoEntity xuatkho;
        public FrmChiTietVatTu()
        {
            InitializeComponent();
            xuatkho = new XuatKhoEntity();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmChiTietVatTu_Load(object sender, EventArgs e)
        {
            repLookUpEditKhoNhan.DataSource = xuatkho.DSKho(); ;
            repLookUpEditKhoNhan.ValueMember = "MaKhoa";
            repLookUpEditKhoNhan.DisplayMember = "TenKhoa";
            for (int i = DateTime.Now.Year -5;i<DateTime.Now.Year+5;i++)
            {
                cbNam.Properties.Items.Add(i);
            }
            cbNam.SelectedIndex = 5;
            cbThang.SelectedIndex = DateTime.Now.Month-1;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            int nam = Utils.ToInt(cbNam.SelectedItem);
            gridControl.DataSource = xuatkho.ChiTietVatTu(cbThang.SelectedIndex + 1, nam);
            gridView.ExpandAllGroups();
            SplashScreenManager.CloseForm();
        }

        private void btnInTheKho_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            // lấy số tồn đầu tháng
            // tồn cuối  ( tồn đầu + nhập ) - xuất
            DataRow dr = gridView.GetFocusedDataRow();
            if (dr != null)
            {

                int nam = Utils.ToInt(cbNam.SelectedItem);
                DataTable data = xuatkho.ChiTietTheKho(dr["MaVatTu"].ToString(),cbThang.SelectedIndex + 1, nam);
                RptTheKho rpt = new RptTheKho();
                rpt.xrlblThangNam.Text = "Tháng " + cbThang.SelectedIndex + 1 + " năm " + nam;
                if(data.Rows.Count>0)
                {
                    rpt.xrlblDonVi.Text = data.Rows[0]["DonViTinh"].ToString();
                    rpt.xrlblMaThuoc.Text = data.Rows[0]["MaBV"].ToString();
                    rpt.xrlblTenVatTu.Text = data.Rows[0]["TenVatTu"].ToString();
                    rpt.xrlblTonDau.Text = data.Rows[0]["SoLuongTonDau"].ToString();
                    rpt.xrlblHamLuong.Text = data.Rows[0]["HamLuong"].ToString();
                }
                rpt.DataSource = data;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            SplashScreenManager.CloseForm();
        }
    }
}
