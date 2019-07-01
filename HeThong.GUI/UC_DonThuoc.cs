using DevExpress.XtraEditors;
using HeThong.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace HeThong.GUI
{
    public partial class UC_DonThuoc : UserControl
    {
        NhatKyEntity nhatky;
        DataRow dr;
        string quyen = "";
        public UC_DonThuoc()
        {
            InitializeComponent ();
            nhatky = new NhatKyEntity ();
        }
        private void LoadData(DateTime tuNgay, DateTime denNgay)
        {
            gridControl.DataSource = nhatky.DSDonThuoc(tuNgay,denNgay);
        }
        private void UC_DonThuoc_Load (object sender, EventArgs e)
        {
            quyen = Core.DAL.Utils.GetQuyen (this.Name);
            Enabled_Xoa ();
            dateTuNgay.DateTime = DateTime.Now;
            dateDenNgay.DateTime = DateTime.Now;
            LoadData (DateTime.Now, DateTime.Now);
        }
        private void Enabled_Xoa ()
        {
            if (quyen.IndexOf ('3') >= 0)
            {
                btnXoa.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }
        private void btnTim_Click (object sender, EventArgs e)
        {
            LoadData (dateTuNgay.DateTime, dateDenNgay.DateTime);
        }

    }
}
