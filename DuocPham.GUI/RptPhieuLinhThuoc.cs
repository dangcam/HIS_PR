using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Core.DAL;

namespace DuocPham.GUI
{
    public partial class RptPhieuLinhThuoc : DevExpress.XtraReports.UI.XtraReport
    {
        public RptPhieuLinhThuoc ()
        {
           // SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            InitializeComponent ();
        }

        private void RptPhieuLinhThuoc_ParametersRequestBeforeShow (object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
           // SplashScreenManager.CloseForm();
        }
    }
}
