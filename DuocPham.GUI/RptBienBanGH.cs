using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Globalization;

namespace DuocPham.GUI
{
    public partial class RptBienBanGH : DevExpress.XtraReports.UI.XtraReport
    {
        public RptBienBanGH()
        {
            InitializeComponent();
            CultureInfo c = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            c.NumberFormat.NumberDecimalSeparator = ",";
            c.NumberFormat.NumberGroupSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = c;

        }

      
    }
}
