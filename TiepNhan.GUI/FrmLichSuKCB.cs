using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
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
    public partial class FrmLichSuKCB : RibbonForm
    {
        public KQNhanLichSuKCBBS ThongTin = new KQNhanLichSuKCBBS();
        FrmThongTinHoSo frmHoSo = new FrmThongTinHoSo();

        public FrmLichSuKCB(DataTable dataCoSo)
        {
            InitializeComponent();
            repositoryItemLookUpEdit.DataSource = dataCoSo;
            repositoryItemLookUpEdit.DisplayMember = "Ten_CS";
            repositoryItemLookUpEdit.ValueMember = "Ma_CS";
        }

        private void FrmLichSuKCB_Load(object sender, EventArgs e)
        {
            gridControl.DataSource = null;
            lblHoTen.Text = ThongTin.hoTen;
            lblNamSinh.Text = ThongTin.ngaySinh;
            lblGioiTinh.Text = ThongTin.gioiTinh;
                     
            // lịch sử theo cổng BHYT
            if(ThongTin.MaBN == null)
            {
                switch (ThongTin.maKetQua)
                {
                    case "000":
                        this.lblThongTin.ForeColor = System.Drawing.Color.Blue;
                        lblThongTin.Text = "Thẻ còn giá trị sử dụng.";
                        break;
                    case "001":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ do BHXH Bộ Quốc Phòng quản lý, đề nghị kiểm tra thẻ và thông tin giấy tờ tùy thân.";
                        break;
                    case "002":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ do BHXH Bộ Công An quản lý, đề nghị kiểm tra thẻ và thông tin giấy tờ tùy thân.";
                        break;
                    case "003":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ cũ hết giá trị sử dụng nhưng đã được cấp thẻ mới.";
                        break;
                    case "004":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ cũ còn giá trị sử dụng nhưng đã được cấp thẻ mới.";
                        break;
                    case "010":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ hết giá trị sử dụng.";
                        break;
                    case "051":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Mã thẻ không đúng.";
                        break;
                    case "052":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Mã tỉnh cấp thẻ (ký tự thứ 4,5 của mã thẻ) không đúng.";
                        break;
                    case "053":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Mã quyền lợi thẻ (ký tự 3 của mã thẻ) không đúng.";
                        break;
                    case "050":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Không thấy thông tin thẻ BHYT.";
                        break;
                    case "060":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ sai họ tên";
                        break;
                    case "061":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ sai họ tên (đúng ký tự đầu)";
                        break;
                    case "070":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ sai ngày sinh.";
                        break;
                    case "080":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ sai giới tính";
                        break;
                    case "090":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ sai nơi đăng ký KCB ban đầu.";
                        break;
                    case "100":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Lỗi khi lấy dữ liệu sổ thẻ.";
                        break;
                    case "101":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Lỗi server.";
                        break;
                    case "110":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ đã thu hồi.";
                        break;
                    case "120":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ báo giảm.";
                        break;
                    case "121":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ báo giảm. Giảm chuyển ngoại tỉnh.";
                        break;
                    case "122":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ báo giảm. Giảm chuyển nội tỉnh.";
                        break;
                    case "123":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ báo giảm. Thu hồi do tăng lại cùng đơn vị.";
                        break;
                    case "124":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Thẻ báo giảm. Ngừng tham gia.";
                        break;
                    case "130":
                        this.lblThongTin.ForeColor = System.Drawing.Color.DarkRed;
                        lblThongTin.Text = "Trẻ em không xuất trình thẻ.";
                        break;
                    default:
                        lblThongTin.Text = "Mã kết quả: " + ThongTin.maKetQua;
                        break;
                }
                if (ThongTin.dsLichSuKCB2018 !=null && ThongTin.dsLichSuKCB2018.Count > 0)
                {
                    //ThongTin.ThongBao = ThongTin.ThongBao.Substring(ThongTin.ThongBao.IndexOf('['),
                    //    ThongTin.ThongBao.IndexOf(']')).Replace("]", "").Replace("[", "");
                    //string[] danhsach = ThongTin.ThongBao.Split('}');
                    DataTable data = new DataTable();
                    data.Columns.Add("maHoSo", typeof(string));
                    data.Columns.Add("maCSKCB", typeof(string));
                    data.Columns.Add("tuNgay", typeof(string));
                    data.Columns.Add("denNgay", typeof(string));
                    data.Columns.Add("tenBenh", typeof(string));
                    data.Columns.Add("tinhTrang", typeof(string));
                    data.Columns.Add("kqDieuTri", typeof(string));
                    foreach (var hoso in ThongTin.dsLichSuKCB2018)
                    {

                        //string[] dulieu = hoso.Replace("}", "").Replace("{", "").Split(',');
                        DataRow dr = data.NewRow();
                        dr["maHoSo"] = hoso.maHoSo;
                        dr["maCSKCB"] = hoso.maCSKCB;
                        dr["tuNgay"] =Utils.ToDateTime( hoso.ngayVao,"yyyyMMddHHmm").ToString("dd/MM/yyyy");
                        dr["denNgay"] = Utils.ToDateTime(hoso.ngayRa, "yyyyMMddHHmm").ToString("dd/MM/yyyy");
                        dr["tenBenh"] = hoso.tenBenh;
                        dr["tinhTrang"] = hoso.tinhTrang;
                        dr["kqDieuTri"] = hoso.kqDieuTri;
                        data.Rows.Add(dr);
                    }
                    gridControl.DataSource = data;
                }
            }
            else
            {
                // Lịch sử theo phần mềm
                this.lblThongTin.ForeColor = System.Drawing.Color.Blue;
                lblThongTin.Text = "Thông tin lịch sử khám chữa bệnh tại bệnh viện.";
                gridControl.DataSource = ThongTin.LichSuPhanMem;
            }
        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "tinhTrang")
            {
                switch (e.DisplayText)
                {
                    case "1":
                        e.DisplayText = "Ra viện";
                        break;
                    case "2":
                        e.DisplayText = "Chuyển viện";
                        break;
                    case "3":
                        e.DisplayText = "Trốn viện";
                        break;
                    case "4":
                        e.DisplayText = "Xin ra viện";
                        break;
                }
            }
            else
            if (e.Column.Name == "kqDieuTri")
            {
                switch (e.DisplayText)
                {
                    case "1":
                        e.DisplayText = "Khỏi";
                        break;
                    case "2":
                        e.DisplayText = "Đỡ";
                        break;
                    case "3":
                        e.DisplayText = "Không thay đổi";
                        break;
                    case "4":
                        e.DisplayText = "Nặng hơn";
                        break;
                    case "5":
                        e.DisplayText = "Tử vong";
                        break;
                }
            }
        }

        private async void btneditChiTiet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string maHoSo = gridView.GetFocusedDataRow()["maHoSo"].ToString();
            if (ThongTin.MaBN == null)
            {
                // Hồ sơ từ BHYT
                Core.DAL.LichSuKCBChiTiet lichSuKCBChiTiet  = await Utils.LayChiTietHoSo(maHoSo);
                if (lichSuKCBChiTiet.maKetQua != "200")
                {
                    XtraMessageBox.Show(lichSuKCBChiTiet.ThongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmHoSo.BHYT = true;
                frmHoSo.XML2 = lichSuKCBChiTiet.hoSoKCB.dsXml2;
                frmHoSo.XML3 = lichSuKCBChiTiet.hoSoKCB.dsXml3;
            }
            else
            {
                // Hồ sơ từ phần mềm
                frmHoSo.BHYT = false;
                frmHoSo.MaHoSo = maHoSo;
            }
            frmHoSo.ShowDialog();
        }
    }
}
