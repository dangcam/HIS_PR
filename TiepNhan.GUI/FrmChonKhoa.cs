using Core.DAL;
using DevExpress.XtraBars.Ribbon;
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
    public partial class FrmChonKhoa : RibbonForm
    {
        public string MaKhoa;
        public int MaLoaiKCB;
        DataTable dataKhoa;
        public FrmChonKhoa(DataTable data)
        {
            InitializeComponent();
            dataKhoa = data;
        }

        private void FrmChonKhoa_Load(object sender, EventArgs e)
        {
            lookUpKhoaBan.Properties.DisplayMember = "TenKhoa";
            lookUpKhoaBan.Properties.ValueMember = "MaKhoa";
            lookUpKhoaBan.Properties.DataSource = dataKhoa;
            if (dataKhoa.Rows.Count > 1)
                lookUpKhoaBan.ItemIndex = dataKhoa.Rows.Count - 1;
            else

                lookUpKhoaBan.ItemIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MaKhoa = Utils.ToString(lookUpKhoaBan.EditValue);
            if (MaKhoa.Substring(0,3) == "K01")
            {
                MaLoaiKCB = 1;
            }
            else
                MaLoaiKCB = 3;
            this.DialogResult = DialogResult.OK;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
