using Core.DAL;
using DevExpress.XtraBars.Ribbon;
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
            for(int i = DateTime.Now.Year -5;i<DateTime.Now.Year+5;i++)
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

    }
}
