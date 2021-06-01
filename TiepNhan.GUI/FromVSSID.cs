using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using KhamBenh.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        VSSIDEntity vSSIDEntity;
        string action;
        public FromVSSID(string maBN,string hoTen)
        {
            InitializeComponent();
            maBenhNhan = maBN;
            this.hoTen = hoTen;
            vSSIDEntity = new VSSIDEntity();
        }

        private void FromVSSID_Load(object sender, EventArgs e)
        {
            txtHoTen.Text = hoTen;
            vSSIDEntity.MaBN = maBenhNhan;
            DataTable dt = vSSIDEntity.DSVSSID();
            if(dt!=null && dt.Rows.Count > 0)
            {
                action = "UPDATE";
                txtCCCD.Text = Utils.ToString(dt.Rows[0]["CCCD"]);
                txtSDT.Text = Utils.ToString(dt.Rows[0]["SDT"]);
                picChanDung.Image = byteArrayToImage((byte[])dt.Rows[0]["ChanDung"]);
                picMatTruoc.Image = byteArrayToImage((byte[])dt.Rows[0]["MatTruoc"]);
                picMatSau.Image = byteArrayToImage((byte[])dt.Rows[0]["MatSau"]);
            }
            else
            {
                action = "INSERT";
                txtCCCD.Text = "";
                txtSDT.Text = "";
                picChanDung.Image = null;
                picMatTruoc.Image = null;
                picMatSau.Image = null;
            }

        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                returnImage = Image.FromStream(ms);
            }
            return returnImage;
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
            vSSIDEntity.CCCD = txtCCCD.Text;
            vSSIDEntity.SDT = txtSDT.Text;
            vSSIDEntity.ChanDung = ImageToByteArray(picChanDung.Image);
            vSSIDEntity.MatTruoc = ImageToByteArray(picMatTruoc.Image);
            vSSIDEntity.MatSau = ImageToByteArray(picMatSau.Image);
            string err = "";
            if (!vSSIDEntity.SpVSSID(ref err, action))
            {
                XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }
    }
}
