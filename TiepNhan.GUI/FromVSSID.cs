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
    public partial class FromVSSID : RibbonForm
    {
        string maBenhNhan;
        string hoTen;
        public FromVSSID(string maBN,string hoTen)
        {
            InitializeComponent();
            maBenhNhan = maBN;
            this.hoTen = hoTen;
        }

        private void FromVSSID_Load(object sender, EventArgs e)
        {
            txtHoTen.Text = hoTen;
        }

        private void btnAnhChanDung_Click(object sender, EventArgs e)
        {
            picChanDung.ShowTakePictureDialog();
        }

        private void btnMatSau_Click(object sender, EventArgs e)
        {
            picMatSau.ShowTakePictureDialog();
        }

        private void btnMatTruoc_Click(object sender, EventArgs e)
        {
            picMatTruoc.ShowTakePictureDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
