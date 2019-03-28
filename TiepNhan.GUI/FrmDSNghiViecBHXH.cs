using Core.DAL;
using DevExpress.XtraBars.Ribbon;
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
        private void LoadData()
        {
            nghiViecBHXHEntity.TuNgay = dateTuNgay.DateTime;
            nghiViecBHXHEntity.DenNgay = dateDenNgay.DateTime;
            gridControl.DataSource = nghiViecBHXHEntity.DSNghiViec();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            //gridControl.ExportToXlsx("file path");
            string dummyFileName = "NghiBHXH_"+dateTuNgay.DateTime.ToString("ddMMyyyy");

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            string err = "";
            // Hiện hộp thoại hỏi đáp 
            traloi = DevExpress.XtraEditors.XtraMessageBox.Show("Chắc chắn bạn muốn xóa mục này?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DataRow dr = gridView.GetFocusedDataRow();
            if (traloi == DialogResult.Yes && dr != null)
            {
                nghiViecBHXHEntity.MaLK = Utils.ToString(dr["MaLK"]);
                nghiViecBHXHEntity.TuNgay = DateTime.Now;
                nghiViecBHXHEntity.DenNgay = DateTime.Now;
                nghiViecBHXHEntity.NgayCT = DateTime.Now;
                if (!nghiViecBHXHEntity.SpNghiViec(ref err,"DELETE"))
                {
                    MessageBox.Show(err);
                    return;
                }
                nghiViecBHXHEntity.MaLK = null;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView.GetFocusedDataRow();
            if (dr != null)
            {
                FrmNghiViecBHXH frm = new FrmNghiViecBHXH(dr);
                frm.ShowDialog();
                LoadData();

            }
        }
    }
}
