using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
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
    public partial class FrmBaoCaoTonKho : RibbonForm
    {
        DAL.NhapXuatEntity nhapxuat;
        DataTable dtLoaiVatTu;
        DataTable dataTonKho;
        DataTable dataNV;
        public FrmBaoCaoTonKho()
        {
            InitializeComponent();
            nhapxuat = new DAL.NhapXuatEntity();
            dtLoaiVatTu = nhapxuat.DSLoaiVatTuChon();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            dataNV = nhapxuat.DSNVKhoDuoc();
            for (int i = DateTime.Now.Year - 5;i<DateTime.Now.Year+5;i++)
            {
                cbNam.Properties.Items.Add(i);
                cbNamXuLy.Properties.Items.Add(i);
            }
            cbTuThang.SelectedIndex = DateTime.Now.Month - 1;
            cbThangBD.SelectedIndex = DateTime.Now.Month - 1;
            cbThangKT.SelectedIndex = DateTime.Now.Month - 1;
            cbNam.SelectedIndex = 5;
            cbNamXuLy.SelectedIndex = 5;
            //
            gridControlLoaiVT.DataSource = dtLoaiVatTu;
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            int namXuLy = Utils.ToInt(cbNamXuLy.EditValue);
            int thangXuLy = cbTuThang.SelectedIndex +1;
            bool flag = false;
            if(namXuLy<DateTime.Now.Year)
            {
                flag = true;
                for(int month = thangXuLy;month<13;month++)
                {
                    XuLyDuLieu(month, namXuLy);
                }
                namXuLy++;
            }
            if (namXuLy < DateTime.Now.Year)
            {
                int year = namXuLy;
                for (year = namXuLy; year < DateTime.Now.Year; year++)
                {
                    for (int month = 1; month < 13; month++)
                    {
                        XuLyDuLieu(month, namXuLy);
                    }
                }
                namXuLy = year++;
            }
            if (namXuLy == DateTime.Now.Year && flag)
            {
                for (int month = 1; month <= DateTime.Now.Month; month++)
                {
                    XuLyDuLieu(month, namXuLy);
                }
            }
            if (namXuLy == DateTime.Now.Year && !flag)
            {
                for (int month = thangXuLy; month <= DateTime.Now.Month; month++)
                {
                     XuLyDuLieu(month, namXuLy);
                }
            }
            SplashScreenManager.CloseForm();
        }
        private void XuLyDuLieu(int month, int year)
         {
            // Xóa dữ liệu theo tháng, năm
            // lấy tồn tháng trước + nhập trong tháng - xuất = tồn cuối cuối tháng
            // (giá trị tồn + giá trị nhập)/(Sl tồn + sl Nhập) * tồn cuối tháng = giá trị tồn
            // giá trị xuất = (giá trị tồn + giá trị nhập) - giá trị tồn
            string err = "";
            if(!nhapxuat.XuLyTonKho(ref err,month,year))
            {
                XtraMessageBox.Show(err, "Lỗi: "+month+"/"+year, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            // chuyển qua dạng date
            int nam = Utils.ToInt(cbNam.EditValue);
            int thangBD = cbThangBD.SelectedIndex + 1;
            int thangKT = cbThangKT.SelectedIndex + 1;
            DateTime dateKT = Utils.ToDateTime(Utils.ToInt(txtNgayKT.Text,lastDay(nam, thangKT)) + "/" + cbThangKT.EditValue + "/" + cbNam.EditValue, "dd/MM/yyyy");
            //Utils.ToDateTime(lastDay(nam,thangKT)+"/"+cbThangKT.EditValue+"/"+cbNam.EditValue, "dd/MM/yyyy");
            DateTime dateBD = Utils.ToDateTime("01/" + cbThangBD.EditValue + "/" + cbNam.EditValue, "dd/MM/yyyy");
            DataRow[] dr = dtLoaiVatTu.Select("Chon = 1", "");
           
            nhapxuat.TuNgay = dateBD;
            nhapxuat.DenNgay = dateKT;
            thangBD--;
            if(thangBD<1)
            {
                thangBD = 12;
                nam--;
            }
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
                dataTonKho = nhapxuat.DSTonKhoThucLuyKe(sql, thangBD, nam); //dataDS = tonKhoLe.DSTonKhoVatTu(sql);
            }
            else
            {
                dataTonKho = null;
            }
            //

            gridControl.DataSource = dataTonKho;
            gridView.ExpandAllGroups();
        }
        private int lastDay(int y, int m)
        {
            return DateTime.DaysInMonth(y, m);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            RptBCTonThucTe rpt = new RptBCTonThucTe();
            rpt.lblThoiGian.Text = nhapxuat.TuNgay.ToString("dd/MM/yy") + " đến " + nhapxuat.DenNgay.ToString("dd/MM/yy");
            rpt.lblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            rpt.DataSource = dataTonKho;
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
            SplashScreenManager.CloseForm();
        }

        private void btnKiemKe_Click(object sender, EventArgs e)
        {
            if (dataTonKho != null)
            {
                SplashScreenManager.ShowForm(typeof(WaitFormLoad));
                //
                System.Drawing.Font fontB = new System.Drawing.Font("Times New Roman", 11, System.Drawing.FontStyle.Bold);
                RptKiemKe rpt = new RptKiemKe();
                rpt.xrlblNgayTonKho.Text = "Ngày " + nhapxuat.DenNgay.Day + " tháng " +
                    nhapxuat.DenNgay.Month + " năm " + nhapxuat.DenNgay.Year;
                rpt.xrlblNoiDung.Text = "Hôm nay " + rpt.xrlblNgayTonKho.Text.ToLower() + " tại kho thuốc BVĐK Phú Riềng";
                rpt.xrlblNgayKy.Text = rpt.xrlblNgayTonKho.Text;
                rpt.xrTable.Rows.Clear();
                XRTableRow row;
                XRTableCell cell;
                rpt.xrTableCell36.ExpressionBindings.Clear();
                rpt.xrTableCell36.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SLTonCuoi]")});
                rpt.xrTableCell2.ExpressionBindings.Clear();

                rpt.DataSource = dataTonKho.Select("SLTonCuoi > 0","STT ASC").CopyToDataTable();
                float UsablePageWidth = rpt.PageWidth - rpt.Margins.Left - rpt.Margins.Right;

                float columnWitdh = UsablePageWidth / (dataNV.Rows.Count + 1);
                rpt.xrTableNV.WidthF = columnWitdh;
                int i = 2;
                foreach (DataRow dr in dataNV.Rows)
                {
                    row = new XRTableRow();

                    cell = new XRTableCell();
                    cell.Text = dr["Id"] + ". " + dr["HoTen"];
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
                    cell.WidthF = columnWitdh;
                    rpt.xrTableNV.Rows.FirstRow.Cells.Add(cell);
                    cell = new XRTableCell();
                    cell.Text = dr["HoTen"].ToString().Replace("Đ/c ", "");
                    cell.WidthF = columnWitdh;
                    rpt.xrTableNV.Rows.LastRow.Cells.Add(cell);

                    i++;
                }

                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
                //
                SplashScreenManager.CloseForm();
            }
        }

        private void btnBangKe_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            RptBCTonThucTe rpt = new RptBCTonThucTe();
            rpt.lblThoiGian.Text = nhapxuat.TuNgay.ToString("dd/MM/yy") + " đến " + nhapxuat.DenNgay.ToString("dd/MM/yy");
            rpt.lblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            if (dataTonKho.Select("SLTonCuoi=0").Count() > 0)
                rpt.DataSource = dataTonKho.Select("SLTonCuoi=0").CopyToDataTable();
            else
                rpt.DataSource = null;
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
            SplashScreenManager.CloseForm();
        }
    }
}
