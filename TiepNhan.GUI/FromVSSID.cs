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
        string Server, VSSID,BHXH;
        public FromVSSID(string maBN,string bhxh,string hoTen, string server, string vssid)
        {
            InitializeComponent();
            maBenhNhan = maBN;
            this.hoTen = hoTen;
            vSSIDEntity = new VSSIDEntity();
            Server = server;
            VSSID = vssid;
            BHXH = bhxh;
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
                string link = Utils.ToString(dt.Rows[0]["ChanDung"]);
                if (link.Length > 0)
                    picChanDung.Image = Image.FromFile(link);
                else
                    picChanDung.Image = null;
                //
                link = Utils.ToString(dt.Rows[0]["MatTruoc"]);
                if (link.Length > 0)
                    picMatTruoc.Image = Image.FromFile(link);
                else
                    picMatTruoc.Image = null;
                //
                link = Utils.ToString(dt.Rows[0]["MatSau"]);
                if (link.Length > 0)
                    picMatSau.Image = Image.FromFile(link);
                else
                    picMatSau.Image = null;
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
            string link = "";
            if (picChanDung.Image != null)
            {
                link = @"\\" + Server + @"\" + VSSID + @"\" + maBenhNhan +"_ChanDung";
                vSSIDEntity.ChanDung = link;
                if (System.IO.File.Exists(link))
                    System.IO.File.Delete(link);
                picChanDung.Image.Save(link);//ImageFormat
            }
            else
                vSSIDEntity.ChanDung = null;
            //
            if (picMatTruoc.Image != null)
            {
                link = @"\\" + Server + @"\" + VSSID + @"\" + maBenhNhan + "_" + txtSDT.Text;
                vSSIDEntity.MatTruoc = link;
                if (System.IO.File.Exists(link))
                    System.IO.File.Delete(link);
                picMatTruoc.Image.Save(link);
            }
            else
                vSSIDEntity.MatTruoc = null;
            //
            if (picMatSau.Image != null)
            {
                link = @"\\" + Server + @"\" + VSSID + @"\" + maBenhNhan + "_" + BHXH;
                vSSIDEntity.MatSau = link;
                if (System.IO.File.Exists(link))
                    System.IO.File.Delete(link);
                picMatSau.Image.Save(link);
            }
            else
                vSSIDEntity.MatSau = null;
            string err = "";
            if (!vSSIDEntity.SpVSSID(ref err, action))
            {
                XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}
