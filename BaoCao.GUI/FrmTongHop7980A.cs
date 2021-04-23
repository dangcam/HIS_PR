using BaoCao.DAL;
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

namespace BaoCao.GUI
{
    public partial class FrmTongHop7980A : RibbonForm
    {
        TongHopEntity tongHopEntity;
        public FrmTongHop7980A()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmTongHop7980A_Load(object sender, EventArgs e)
        {
            cbThang.SelectedIndex = DateTime.Now.Month - 1;
            int nam = DateTime.Now.Year;
            for(int i = nam - 5; i < nam + 6; i++)
            {
                cbNam.Properties.Items.Add(i);
            }
            cbNam.SelectedIndex = 5;
            cbBaoCao.SelectedIndex = 0;
            tongHopEntity = new TongHopEntity();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            // 79A Ngoại trú, 80A Nội trú
            string makhoa01 = "";
            string makhoa03 = "";
            string makhoa19 = "";
            if(cbBaoCao.SelectedIndex == 0)
            {
                makhoa01 = "K01";
            }
            else
            {
                makhoa19 = "K19";
                makhoa03 = "K03";
            }
            string maCS = AppConfig.CoSoKCB;
            int thang = Utils.ToInt(cbThang.SelectedItem);
            int nam = Utils.ToInt(cbNam.SelectedItem);
            int chan = thang / 3;
            int du = thang % 3;
            int quy = 1;
            if (du > 0)
                quy = chan + 1;
            else
                quy = chan;
            DataTable dt = tongHopEntity.TongHop7980A(makhoa01,makhoa03,makhoa19,maCS,thang,nam,quy);
            gridControl.DataSource = dt;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string dummyFileName;
            if (cbBaoCao.SelectedIndex == 0)
            {
                dummyFileName = "79A_" + AppConfig.CoSoKCB + "_" + cbNam.SelectedItem + "_" + cbThang.SelectedItem;
            }
            else
            {
                dummyFileName = "80A_" + AppConfig.CoSoKCB + "_" + cbNam.SelectedItem + "_" + cbThang.SelectedItem;
            }

            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = dummyFileName;
            sf.Filter = "Excel (.xlsx)|*.xlsx";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                //string savePath = Path.GetDirectoryName(sf.FileName);
                // Do whatever
                gridControl.ExportToXlsx(sf.FileName);
            }
        }
    }
}
