using DevExpress.XtraBars.Ribbon;
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
    public partial class FrmDSNghiViecBHXH : RibbonForm
    {
        NghiViecBHXHEntity nghiViecBHXHEntity;
        public FrmDSNghiViecBHXH()
        {
            InitializeComponent();
            nghiViecBHXHEntity = new NghiViecBHXHEntity();
        }

        private void FrmDSNghiViecBHXH_Load(object sender, EventArgs e)
        {            
            dateDenNgay.DateTime = DateTime.Now;
            dateTuNgay.DateTime = DateTime.Now;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            //gridControl.ExportToXlsx("file path");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
