using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
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
    public partial class FrmBCTonThucTe : RibbonForm
    {
        DAL.NhapXuatEntity nhapxuat;
        DataTable dataTonKho;
        DataTable dtLoaiVatTu;
        public FrmBCTonThucTe()
        {
            InitializeComponent();
            nhapxuat = new DAL.NhapXuatEntity();
            dtLoaiVatTu = nhapxuat.DSLoaiVatTuChon();
        }
        
        string txtThoiGian = "";
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmBCTonThucTe_Load(object sender, EventArgs e)
        {
            dateTuNgay.DateTime = DateTime.Now;
            dateDenNgay.DateTime = DateTime.Now;

            cbThoiGian.SelectedIndex = 0;
            cbThang.SelectedIndex = DateTime.Now.Month - 1;
            cbNam.SelectedIndex = 0;
            cbQuy.SelectedIndex = DateTime.Now.Month / 4;

            layctrlNam.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layctrlQuy.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layctrlThang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            this.cbNam.Properties.Items.Clear();
            string[] nam = new string[30];
            int j = 0;
            for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 30; i--)
            {
                nam[j] = i.ToString();
                j++;
            }
            this.cbNam.Properties.Items.AddRange(nam);
            cbNam.SelectedIndex = 0;
            //
            gridControlLoaiVT.DataSource = dtLoaiVatTu;
        }

        private void cbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThoiGian.SelectedIndex != 0)
            {
                layctrlTuNgay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layctrlDenNgay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layctrlQuy.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layctrlThang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layctrlNam.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                if (cbThoiGian.SelectedIndex == 1)
                {
                    layctrlThang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                if (cbThoiGian.SelectedIndex == 2)
                {
                    layctrlQuy.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }
            else
            {
                layctrlNam.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layctrlQuy.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layctrlThang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                layctrlTuNgay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layctrlDenNgay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }
        private int lastDay(int y, int m)
        {
            return DateTime.DaysInMonth(y, m);
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            DateTime ngayBD;
            DateTime ngayKT;
            if (cbThoiGian.SelectedIndex == 0)
            {
                ngayBD = dateTuNgay.DateTime;
                ngayKT = dateDenNgay.DateTime;
                txtThoiGian = "Từ ngày " + ngayBD.Day + "/" + ngayBD.Month + "/" + ngayBD.Year +
               " đến " + ngayKT.Day + "/" + ngayKT.Month + "/" + ngayKT.Year;
            }
            else
            if (cbThoiGian.SelectedIndex == 1)
            {
                ngayBD = DateTime.ParseExact("01/" + cbThang.SelectedItem + "/" + cbNam.SelectedItem,
                    "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ngayKT = DateTime.ParseExact(lastDay(Convert.ToInt32(cbNam.SelectedItem), Convert.ToInt32(cbThang.SelectedItem)) +
                    "/" + cbThang.SelectedItem + "/" + cbNam.SelectedItem,
                    "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                txtThoiGian = "Tháng " + cbThang.SelectedItem + " năm " + cbNam.SelectedItem.ToString();
            }
            else
            if (cbThoiGian.SelectedIndex == 2)
            {
                string thangDau = "01";
                string thangCuoi = "12";
                if (cbQuy.SelectedIndex == 0)
                {
                    thangDau = "01";
                    thangCuoi = "03";
                }
                else
                    if (cbQuy.SelectedIndex == 1)
                {
                    thangDau = "04";
                    thangCuoi = "06";
                }
                else
                    if (cbQuy.SelectedIndex == 2)
                {
                    thangDau = "07";
                    thangCuoi = "09";
                }
                else
                {
                    thangDau = "10";
                    thangCuoi = "12";
                }
                ngayBD = DateTime.ParseExact("01/" + thangDau + "/" + cbNam.SelectedItem,
                    "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                ngayKT = DateTime.ParseExact(lastDay(Convert.ToInt32(cbNam.SelectedItem), Convert.ToInt32(thangCuoi)) +
                    "/" + thangCuoi + "/" + cbNam.SelectedItem,
                    "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                txtThoiGian = "Quý " + (cbQuy.SelectedIndex + 1) + " năm " + cbNam.SelectedItem.ToString();
            }
            else
            {
                ngayBD = DateTime.ParseExact("01/01/" + cbNam.SelectedItem,
                    "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ngayKT = DateTime.ParseExact(lastDay(Convert.ToInt32(cbNam.SelectedItem), 12) +
                    "/12/" + cbNam.SelectedItem,
                    "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                txtThoiGian = "Năm " + cbNam.SelectedItem.ToString();
            }
            //
            nhapxuat.TuNgay = ngayBD;
            nhapxuat.DenNgay = ngayKT;
            //
            DataRow[] dr = dtLoaiVatTu.Select("Chon = 1", "");
            if (dr.Length > 0)
            {
                string sql = "";
                for (int i = 0; i < dr.Length; i++)
                {
                    sql += sql.Length > 0 ? " Or LoaiVatTu ='" + dr[i]["Ma"] + "'" :
                        "LoaiVatTu = '" + dr[i]["Ma"] + "'";
                }
                // lấy dữ liệu từ sql
                sql = "(" + sql + ")";
                dataTonKho = nhapxuat.DSTonKhoThuc(sql); //dataDS = tonKhoLe.DSTonKhoVatTu(sql);
            }
            else
            {
                dataTonKho = null;
            }
            //
            
            gridControl.DataSource = dataTonKho;
            gridView.ExpandAllGroups();
            SplashScreenManager.CloseForm();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            RptBCTonThucTe rpt = new RptBCTonThucTe();
            rpt.lblThoiGian.Text = txtThoiGian;
            rpt.lblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            rpt.DataSource = dataTonKho;
            //
            //rpt.lblGiaTriCuoiKy.Text = dataTonKho.Compute("SUM(GTTonCuoi)", "").ToString();
            //rpt.lblGiaTriDauKy.Text = Utils.ToString(dataTonKho.Compute("SUM(GTTonDau)", "").ToString());
            //rpt.lblGiaTriNhap.Text = Utils.ToString(dataTonKho.Compute("SUM(GTNhap)", "").ToString());
            //rpt.lblGiaTriXuat.Text = Utils.ToString(dataTonKho.Compute("SUM(GTXuat)", "").ToString());
            ////
            //rpt.xrCellGTNhap.Text = rpt.lblGiaTriNhap.Text;
            //rpt.xrCellGTTonCuoi.Text = rpt.lblGiaTriCuoiKy.Text;
            //rpt.xrCellGTTonDau.Text = rpt.lblGiaTriDauKy.Text;
            //rpt.xrCellGTXuat.Text = rpt.lblGiaTriXuat.Text;
            //
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
            SplashScreenManager.CloseForm();
        }
    }
}
