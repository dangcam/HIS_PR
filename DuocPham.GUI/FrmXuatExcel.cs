using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraSplashScreen;
using DuocPham.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DuocPham.GUI
{
    public partial class FrmXuatExcel : RibbonForm
    {
        XuatKhoEntity xuatkho;
        Dictionary<string, string> maVatTu = new Dictionary<string, string>();
        public FrmXuatExcel()
        {
            InitializeComponent();
            xuatkho = new XuatKhoEntity();
        }

        private void FrmXuatExcel_Load(object sender, EventArgs e)
        {
            lookUpKhoa.Properties.DataSource = xuatkho.DSKhoaBan(1);
            lookUpKhoa.Properties.ValueMember = "MaKhoa";
            lookUpKhoa.Properties.DisplayMember = "TenKhoa";
            lookUpKhoa.ItemIndex = 0;
            dateTuNgay.DateTime = DateTime.Now;
            dateDenNgay.DateTime = DateTime.Now;
            txtSoCTu.Text = "10";
            maVatTu = xuatkho.DSMaVatTu().AsEnumerable().ToDictionary(row => row["MaBV"].ToString(), row => row["MaCu"].ToString());
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            DataTable dataTable = xuatkho.DSXuatExcel(dateTuNgay.DateTime,
                dateDenNgay.DateTime,lookUpKhoa.EditValue.ToString());
            //
            // Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = "XuatKho";

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "MaCTu";
            cl1.ColumnWidth = 10.0;
            cl1.Font.Color = ConsoleColor.Red;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "SoCTu";
            cl2.ColumnWidth = 10.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "NgayCTu";
            cl3.ColumnWidth = 15.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "DienGiai";
            cl4.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "MaTKNo";
            cl5.ColumnWidth = 10.0;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "MaTKCo";
            cl6.ColumnWidth = 10.0;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "MaVTHHNo";
            cl7.ColumnWidth = 10.0;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
            cl8.Value2 = "MaVTHHCo";
            cl8.ColumnWidth = 10.0;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
            cl9.Value2 = "TenHangHoa";
            cl9.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
            cl10.Value2 = "DonViTinh";
            cl10.ColumnWidth = 10.0;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
            cl11.Value2 = "SoLuong";
            cl11.ColumnWidth = 10.0;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L1", "L1");
            cl12.Value2 = "VNDDonGia";
            cl12.ColumnWidth = 15.0;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
            cl13.Value2 = "VNDThanhTien";
            cl13.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N1", "N1");
            cl14.Value2 = "KhachHang";
            cl14.ColumnWidth = 10.0;

            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O1", "O1");
            cl15.Value2 = "DiaChi";
            cl15.ColumnWidth = 30.0;

            Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P1", "P1");
            cl16.Value2 = "ThangHoachToan";
            cl16.ColumnWidth = 30.0;

            Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("Q1", "Q1");
            cl17.Value2 = "MaDTPNNo";
            cl17.ColumnWidth = 30.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A1", "Q1");
            rowHead.Font.Bold = true;
            rowHead.Font.Color = ConsoleColor.Red;
            rowHead.Interior.Color = 20;
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 17;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[dataTable.Rows.Count, 17];// dataTable.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            int soctu = Utils.ToInt(txtSoCTu.Text)-1;
            string noiDung = "";
            for (int r = 0; r < dataTable.Rows.Count; r++)
            {

                DataRow dr = dataTable.Rows[r];
                if (noiDung != dr["NoiDung"].ToString())
                {
                    noiDung = dr["NoiDung"].ToString();
                    soctu++;
                }
                arr[r, 0] = "PXK";//MaCTu
                arr[r, 1] = soctu;// dr[""];//SoCTu
                arr[r, 2] = dateDenNgay.DateTime.ToString("dd/MM/yy") + "";//NgayCTu
                arr[r, 3] = dr["NoiDung"] + " " + ((lookUpKhoa.EditValue.Equals("K19_13")) ? "Khoa Ngoại" : "Khoa Nội") + " ngày " +
                        dateTuNgay.DateTime.ToString("dd/MM")+"-"+ dateDenNgay.DateTime.ToString("dd/MM"); //dr[""];//DienGiai
                arr[r, 4] = (lookUpKhoa.EditValue.Equals("K01_13")) ? "161" : "141";// dr[""];//MaTKNo Ngoại trú: 161, Nội trú: 141
                arr[r, 5] = "156" + dr["LoaiVatTu"];//MaTKCo
                arr[r, 6] = "";//dr[""];//MaVTHHNo
                if (maVatTu.ContainsKey(dr["MaVatTu"].ToString()))
                {
                    arr[r, 7] = maVatTu[dr["MaVatTu"].ToString()];//MaVTHHCo
                }
                else
                {
                    arr[r, 7] = dr["MaVatTu"];//MaVTHHCo
                }
                arr[r, 8] = dr["TenVatTu"];//TenHangHoa
                arr[r, 9] = dr["DonViTinh"];//DonViTinh
                arr[r, 10] = dr["SoLuong"];//SoLuong
                arr[r, 11] = dr["DonGia"];//VNDDonGia
                arr[r, 12] = dr["ThanhTien"];//VNDThanhTien
                arr[r, 13] = ((lookUpKhoa.EditValue.Equals("K19_13")) ? "LÊ THỊ THẢO LY" : "NGUYỄN TIẾN DŨNG"); ;// dr[""];//KhachHang
                arr[r, 14] = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue);
                // lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();// dr[""];//DiaChi
                arr[r, 15] = "2";// tháng
                arr[r, 16] = "BVPR";// ngoại trú

            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 1;
            int columnEnd = 17;// dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            //
            SplashScreenManager.CloseForm();
        }
    }
}
