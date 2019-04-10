using BaoCao.DAL;
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
    public partial class FrmBCTonKho : RibbonForm
    {
        TonKhoEntity tonkho;
        DataTable dataNV;
        DataTable dataTonKho;
        public FrmBCTonKho ()
        {
            InitializeComponent ();
            tonkho = new TonKhoEntity ();
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmBCTonKho_Load (object sender, EventArgs e)
        {
            dateNgay.DateTime = DateTime.Now;
            dataNV = tonkho.DSNVKhoDuoc();
            gridControlDC.DataSource = dataNV;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dataTonKho = tonkho.DSKho();
            gridControl.DataSource = dataTonKho;
            gridView.ExpandAllGroups();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if(dataTonKho!=null)
            {
                SplashScreenManager.ShowForm(typeof(WaitFormLoad));
                //
                System.Drawing.Font fontB = new System.Drawing.Font("Times New Roman", 11, System.Drawing.FontStyle.Bold);
                RptKiemKe rpt = new RptKiemKe();
                rpt.xrlblNgayTonKho.Text = "Ngày "+DateTime.Now.Day+" tháng "+
                    DateTime.Now.Month+" năm "+DateTime.Now.Year;

                rpt.xrlblNoiDung.Text = "Hôm nay "+ rpt.xrlblNgayTonKho.Text.ToLower() + " tại kho thuốc BVĐK Phú Riềng";
                rpt.xrTable.Rows.Clear();
                XRTableRow row;
                XRTableCell cell;
                rpt.DataSource = dataTonKho;
                float UsablePageWidth = rpt.PageWidth - rpt.Margins.Left - rpt.Margins.Right;
                
                float columnWitdh = UsablePageWidth / (dataNV.Rows.Count + 1);
                rpt.xrTableNV.WidthF = columnWitdh;
                int i = 2;
                foreach (DataRow dr in dataNV.Rows)
                {
                    row = new XRTableRow();

                    cell = new XRTableCell();
                    cell.Text = dr["Id"]+". Đ/c "+ dr["HoTen"];
                    cell.WidthF = 200;
                    row.Cells.Add(cell);
                    cell = new XRTableCell();
                    cell.Text = dr["ChucVu"].ToString();
                    cell.WidthF = 200;
                    row.Cells.Add(cell);

                    rpt.xrTable.Rows.Add(row);
                    rpt.xrTableNV.WidthF = columnWitdh * i;
                    cell = new XRTableCell();
                    cell.Text = dr["ChucVu"].ToString().ToUpper();
                    cell.Font = fontB;
                    cell.WidthF =  columnWitdh;
                    rpt.xrTableNV.Rows.FirstRow.Cells.Add(cell);
                    cell = new XRTableCell();
                    cell.Text = dr["HoTen"].ToString();
                    cell.WidthF =  columnWitdh;
                    rpt.xrTableNV.Rows.LastRow.Cells.Add(cell);
                   
                    i++;
                }
                
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
                //
                SplashScreenManager.CloseForm();
            }
        }
    }
}
