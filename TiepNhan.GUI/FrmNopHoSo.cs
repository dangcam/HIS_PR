using BaoCao.GUI;
using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
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
    public partial class FrmNopHoSo : RibbonForm
    {
        KhamBenhEntity khambenh;
        public FrmNopHoSo()
        {
            InitializeComponent();
            khambenh = new KhamBenhEntity();
        }

        private void FrmNopHoSo_Load(object sender, EventArgs e)
        {
            dateDenNgay.DateTime = DateTime.Now;
            //dateDenNgayIn.DateTime = DateTime.Now;
            dateTuNgay.DateTime = DateTime.Now;
            //dateTuNgayIn.DateTime = DateTime.Now;
            //lookUpKhoa.Properties.DataSource = khambenh.DSKhoaBan(1);
            //lookUpKhoa.Properties.ValueMember = "MaKhoa";
            //lookUpKhoa.Properties.DisplayMember = "TenKhoa";
            //lookUpKhoa.EditValue = AppConfig.MaKhoa;
            cbLoaiIn.SelectedIndex = 0;
            cbKhoa.SelectedIndex = 0;
            cbChonNgay.SelectedIndex = 0;
        }
        private string GetMaKhoa()
        {
            string sql = "";
            if (cbKhoa.SelectedIndex == 0)
                sql = "K03_13' or MaKhoa = 'K19_13";
            else if (cbKhoa.SelectedIndex == 1)
                sql = "K03_13";
            else
                sql = "K19_13";
            return sql;
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            gridControl.DataSource = khambenh.DSNopBenhAn(GetMaKhoa(),
                dateTuNgay.DateTime,dateDenNgay.DateTime,cbChonNgay.SelectedIndex);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable data = khambenh.DSNopBenhAn(//checkCoThe.Checked == true ? 1 : 0,
                dateTuNgay.DateTime, dateDenNgay.DateTime, GetMaKhoa(), cbLoaiIn.SelectedIndex, cbChonNgay.SelectedIndex);
            RptTheoDoiRaVaoVien rpt = new RptTheoDoiRaVaoVien();
            rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + dateTuNgay.DateTime.ToString("dd/MM/yyyy") +
                " đến ngày " + dateDenNgay.DateTime.ToString("dd/MM/yyyy");
            //rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            rpt.xrlblKhoa.Text = Utils.ToString(cbKhoa.SelectedItem);//lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
            rpt.DataSource = data;
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            int index = gridView.GetFocusedDataSourceRowIndex();
            try
            {
                string err = "";
                string MaLK = (gridView.DataSource as DataView)[index]["MaLK"].ToString();
                bool tinhTrang = bool.Parse((gridView.DataSource as DataView)[index]["Nop"].ToString());
                if (tinhTrang)
                {
                    // them
                    if (!khambenh.SpNopBenhAn(ref err, "INSERT", MaLK))
                    {
                        MessageBox.Show(err);
                        return;
                    }
                }
                else
                {
                    // xoa
                    if (!khambenh.SpNopBenhAn(ref err, "DELETE", MaLK))
                    {
                        MessageBox.Show(err);
                        return;
                    }
                }

            }
            catch { }
        }

        private void FrmNopHoSo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gridView.IsEditing)
                gridView.CloseEditor();

            if (gridView.FocusedRowModified)
                gridView.UpdateCurrentRow();
        }
    }
}
