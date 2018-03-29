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
    public partial class FrmTongHopBaoCao : RibbonForm
    {
        TongHopEntity tongHop;
        DataTable dataTongHop;
        Dictionary<string, string> maVatTu = new Dictionary<string, string>();
        public FrmTongHopBaoCao()
        {
            InitializeComponent();
            tongHop = new TongHopEntity();
            lookUpKhoa.Properties.DataSource = tongHop.DSKhoaBan(1);
            lookUpKhoa.Properties.ValueMember = "MaKhoa";
            lookUpKhoa.Properties.DisplayMember = "TenKhoa";
        }

        private void FrmTongHopBaoCao_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cbLoaiBaoCao;
            for(int i = DateTime.Now.Year-10;i<DateTime.Now.Year+10;i++)
            {
                cbNam.Properties.Items.Add(i);
            }
            dateDenNgay.DateTime = DateTime.Now;
            dateTuNgay.DateTime = DateTime.Now;
            cbThang.SelectedIndex = DateTime.Now.Month - 1;
            cbNam.SelectedItem = DateTime.Now.Year;
            cbLoaiBaoCao.SelectedIndex = 0;
            lookUpKhoa.ItemIndex = 0;
            cbQuy.SelectedIndex = (DateTime.Now.Month+5) / 3-2;
            cbThoiGian.SelectedIndex = 0;
            maVatTu = tongHop.DSMaVatTu().AsEnumerable().ToDictionary(row=>row["MaBV"].ToString(),row=>row["MaCu"].ToString());
        }
        private void cbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThoiGian.SelectedIndex == 0)
            {
                // giai đoạn
                cbNam.Hide();
                cbThang.Hide();
                cbQuy.Hide();
                dateDenNgay.Show();
                dateTuNgay.Show();
            }
            else
                if (cbThoiGian.SelectedIndex == 1)
            {
                // tháng
                cbNam.Show();
                cbThang.Show();
                cbQuy.Hide();
                dateDenNgay.Hide();
                dateTuNgay.Hide();
            }
            else
                if (cbThoiGian.SelectedIndex == 2)
            {
                // quý
                cbNam.Show();
                cbQuy.Show();
                cbThang.Hide();
                dateDenNgay.Hide();
                dateTuNgay.Hide();
            }
            else
            {
                // năm
                cbNam.Show();
                cbThang.Hide();
                cbQuy.Hide();
                dateDenNgay.Hide();
                dateTuNgay.Hide();
            }
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            string maKhoa = lookUpKhoa.EditValue.ToString();
            if(checkCoSoCon.Checked)
            {
                maKhoa = lookUpKhoa.EditValue.ToString().Split('_')[0];
                //maKhoa = maKhoa + "_13' or MaKhoa = '"+maKhoa+ "_74' or MaKhoa = '" + maKhoa + "_75' or MaKhoa = '"
                //    + maKhoa + "_76' or MaKhoa = '" + maKhoa + "_77' or MaKhoa = '" + maKhoa+"_78";
                maKhoa = maKhoa + "_13','" + maKhoa + "_74','" + maKhoa + "_75','"
                    + maKhoa + "_76','" + maKhoa + "_77','" + maKhoa + "_78";
            }
            DateTime tuNgay, denNgay;
            if (cbThoiGian.SelectedIndex == 0)
            {
                //Giai đoạn
                tuNgay = dateTuNgay.DateTime;
                denNgay = dateDenNgay.DateTime;
            }
            else if (cbThoiGian.SelectedIndex == 1)
            {
                //Tháng
                tuNgay = Utils.ToDateTime("01/"+cbThang.SelectedItem+"/"+cbNam.SelectedItem, "dd/MM/yyyy");
                denNgay = Utils.ToDateTime(Utils.LastDay(Utils.ToInt(cbNam.SelectedItem),cbThang.SelectedIndex+1) +
                    "/" + cbThang.SelectedItem + "/" + cbNam.SelectedItem, "dd/MM/yyyy");
            }
            else if (cbThoiGian.SelectedIndex == 2)
            {
                string thangDau, thangCuoi;
                //Quý
                if(cbQuy.SelectedIndex==0)
                {
                    // Quý 1
                    thangDau = "01";
                    thangCuoi = "03";
                }else
                    if(cbQuy.SelectedIndex==1)
                {
                    // Quý 2
                    thangDau = "04";
                    thangCuoi = "06";
                }
                else if(cbQuy.SelectedIndex==2)
                {
                    // Quý 3
                    thangDau = "07";
                    thangCuoi = "10";
                }
                else
                {
                    // Quý 4
                    thangDau = "11";
                    thangCuoi = "12";
                }
                tuNgay = Utils.ToDateTime("01/" + thangDau + "/" + cbNam.SelectedItem, "dd/MM/yyyy");
                denNgay = Utils.ToDateTime(Utils.LastDay(Utils.ToInt(cbNam.SelectedItem), Utils.ToInt(thangCuoi)) +
                    "/" + thangCuoi + "/" + cbNam.SelectedItem, "dd/MM/yyyy");
            }
            else
            {
                //Năm
                tuNgay = Utils.ToDateTime("01/01/" + cbNam.SelectedItem, "dd/MM/yyyy");
                denNgay = Utils.ToDateTime(Utils.LastDay(Utils.ToInt(cbNam.SelectedItem),12) + 
                    "/12/" + cbNam.SelectedItem, "dd/MM/yyyy");
            }
            if (cbLoaiBaoCao.SelectedIndex==0)
            {
                //Tổng hợp tiền bệnh nhân thanh toán
                dataTongHop = tongHop.DSBenhNhan(maKhoa, tuNgay, denNgay);
                RptTongHopBNTT rpt = new RptTongHopBNTT();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if(cbLoaiBaoCao.SelectedIndex==1)
            {
                //Tổng hợp vật tư y tế
                dataTongHop = tongHop.DSVatTu(maKhoa, tuNgay, denNgay);
                RptTongHopVatTu rpt = new RptTongHopVatTu();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if(cbLoaiBaoCao.SelectedIndex==2)
            {
                //Tổng hợp thuốc
                dataTongHop = tongHop.DSDonThuoc(maKhoa, tuNgay, denNgay);
                RptTongHopThuoc rpt = new RptTongHopThuoc();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if (cbLoaiBaoCao.SelectedIndex == 3)
            {
                //Tổng hợp dịch vụ kỹ thuật
                dataTongHop = tongHop.DSDichVuKyThuat(maKhoa, tuNgay, denNgay);
                RptTongHopDichVu rpt = new RptTongHopDichVu();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if(cbLoaiBaoCao.SelectedIndex == 4)
            {
                // Tổng hợp viện phí
                RptTongHopVienPhi rpt = new RptTongHopVienPhi();
                dataTongHop = tongHop.DSVienPhi(maKhoa, tuNgay, denNgay);
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if(cbLoaiBaoCao.SelectedIndex ==5)
            {
                //Tổng hợp số lượng thuốc
                dataTongHop = tongHop.DSSoLuongThuoc(maKhoa, tuNgay, denNgay);
                RptSoLuongThuoc rpt = new RptSoLuongThuoc();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if(cbLoaiBaoCao.SelectedIndex == 6)
            {
                // số liệu mẫu 7980A
                dataTongHop = tongHop.DSMauSo7980A(maKhoa,tuNgay,denNgay);
                RptSoLieuMau7980A rpt = new RptSoLieuMau7980A();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if(cbLoaiBaoCao.SelectedIndex==7)               
            {
                // chi tiết thuốc
                dataTongHop = tongHop.DSChiTietThuoc(maKhoa, tuNgay, denNgay);
                RptTongHopChiTietThuoc rpt = new RptTongHopChiTietThuoc();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                //rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                //rpt.DataSource = dataTongHop;
                rpt.xrPivotGrid.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if (cbLoaiBaoCao.SelectedIndex == 8)
            {
                // xuất excel sang phần mềm kế toán
                dataTongHop = tongHop.DSSoLuongVatTu(maKhoa, tuNgay, denNgay);
                XuatExcel(dataTongHop);           
            }
            else
            {
                // tổng hợp viện phí dân
                RptTongHopVienPhi rpt = new RptTongHopVienPhi();
                dataTongHop = tongHop.DSVienPhiDan(maKhoa, tuNgay, denNgay);
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }

            SplashScreenManager.CloseForm();
        }
        private void XuatExcel(DataTable dataTable)
        {
            //dataTongHop;
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
            string ngayYLenh="";
            for (int r = 0; r < dataTable.Rows.Count; r++)
            {
              
                DataRow dr = dataTable.Rows[r];
                if (ngayYLenh != dr["NgayYLenh"].ToString())
                {
                    ngayYLenh = dr["NgayYLenh"].ToString();
                    soctu++;
                }
                arr[r, 0] = "PXK";//MaCTu
                arr[r, 1] = soctu;// dr[""];//SoCTu
                arr[r, 2] = Utils.ToDateTime(dr["NgayYLenh"].ToString()).ToString("dd/MM/yy")+"";//NgayCTu
                arr[r, 3] = "Xuất thuốc điều trị BN " + ((lookUpKhoa.EditValue.Equals("K01_13")) ? "Ngoại trú" : "Nội Trú")+ " ngày "+
                    Utils.ToDateTime(dr["NgayYLenh"].ToString()).ToString("dd/MM"); ;//dr[""];//DienGiai
                arr[r, 4] = (lookUpKhoa.EditValue.Equals("K01_13"))? "161":"141";// dr[""];//MaTKNo Ngoại trú: 161, Nội trú: 141
                arr[r, 5] = "156"+ dr["LoaiVatTu"];//MaTKCo
                arr[r, 6] = "";//dr[""];//MaVTHHNo
                arr[r, 7] = maVatTu[dr["MaBV"].ToString()];//MaVTHHCo
                arr[r, 8] = dr["TenVatTu"];//TenHangHoa
                arr[r, 9] = dr["DonViTinh"];//DonViTinh
                arr[r, 10] = dr["SoLuong"];//SoLuong
                arr[r, 11] = Math.Round(Utils.ToDecimal(dr["DonGia"]),2); //dr["DonGia"];//VNDDonGia
                arr[r, 12] = Math.Round(Utils.ToDecimal(dr["ThanhTien"]));//VNDThanhTien
                arr[r, 13] = "NGUYỄN THỊ MAI";// dr[""];//KhachHang
                arr[r, 14] = "KHOA DƯỢC";// lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();// dr[""];//DiaChi
                arr[r, 15] = Utils.ToDateTime(dr["NgayYLenh"].ToString()).Month;// tháng
                arr[r, 16] = "NGT";// ngoại trú

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

            ////
            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            //Microsoft.Office.Interop.Excel.Range c4 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            //Microsoft.Office.Interop.Excel.Range rg = oSheet.get_Range(c3, c4);
            //rg.NumberFormat = "dd/MM/yyyy";
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
