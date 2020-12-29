using DevExpress.XtraBars.Ribbon;
using KhamBenh.DAL;
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Core.DAL;
using System.Threading.Tasks;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace TiepNhan.GUI
{
    public partial class FrmTiepNhan : RibbonForm
    {
        TiepNhanEntity tiepnhan;
        DataTable dataCoso,dataTinh,dataMucHuong,dataDanhSach, dataDanhSach2;
        private bool themMoi = true;
        FrmLichSuKCB lichSuKCB;
        private List<int> listPhongKham = new List<int>();
        RptSoPhieu rptSoPhieu = new RptSoPhieu();
        private string quyen = "";
        SplashScreenManager splashScreenManager;
        public FrmTiepNhan()
        {
            
            InitializeComponent();
            tiepnhan = new TiepNhanEntity();;
            lookUpTaiNan.Properties.DataSource = tiepnhan.DSTaiNan();
            lookUpTaiNan.Properties.DisplayMember = "Ten";
            lookUpTaiNan.Properties.ValueMember = "Ma";
            dataCoso = tiepnhan.DSCoSoKCB();
            lookUpNoiChuyenDen.Properties.DataSource = dataCoso;
            lookUpNoiChuyenDen.Properties.ValueMember = "Ma_CS";
            lookUpNoiChuyenDen.Properties.DisplayMember = "Ten_CS";
            lookUpMaKhoa.Properties.DataSource = tiepnhan.DSKhoaBan(1);
            lookUpMaKhoa.Properties.ValueMember = "MaKhoa";
            lookUpMaKhoa.Properties.DisplayMember = "TenKhoa";
            checkButton();
            lichSuKCB = new FrmLichSuKCB(dataCoso);
            DataTable phongkham = tiepnhan.DSKhoaBan(2);
            if(phongkham!=null)
            {
                foreach(DataRow dr in phongkham.Rows)
                {
                    SimpleButton b = new SimpleButton();
                    b.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    b.Appearance.Options.UseFont = true;
                    b.ImageUri.Uri = "Forward;Size16x16;Office2013";
                    b.Name = dr["MaKhoa"].ToString();
                    b.Size = new System.Drawing.Size(120, 27);
                    b.Text = dr["TenKhoa"].ToString();
                    b.Click += btnNew_Click;
                    flowLayoutPanel.Controls.Add(b);
                    listPhongKham.Add(Utils.ToInt(b.Name.Substring(b.Name.Length - 2, 2)));
                    if (quyen.IndexOf('1') >= 0)
                    {
                        b.Enabled = true;
                    }
                    else
                    {
                        b.Enabled = false;
                    }
                }
            }
            // Data Tỉnh, Mức hưởng
            dataTinh = tiepnhan.DSTinh();
            dataMucHuong = tiepnhan.DSMucHuong();
            dateTuNgay.DateTime = DateTime.Now;
            dateDenNgay.DateTime = DateTime.Now;
            splashScreenManager = new SplashScreenManager(this, typeof(WaitFormLoad), true, true);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (KiemTraThongTinTiepNhan(true) && themMoi)
            {
                SimpleButton clickedButton = (SimpleButton)sender;
                ChuyenPhong(Utils.ToInt(clickedButton.Name.Substring(clickedButton.Name.Length-2,2)));
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmTiepNhan_Load(object sender, EventArgs e)
        {
            ResetForm();
            this.ActiveControl = txtMaQR;
            this.LoadData();
        }
        private void checkButton()
        {
            quyen = Core.DAL.Utils.GetQuyen(this.Name);
        }
        private void Enabled_Luu()
        {
            if (quyen.IndexOf('2') >= 0)
            {
                btnLuu.Enabled = true;
            }
            else
            {
                btnLuu.Enabled = false;
            }
        }
        private void LoadData()
        {
            // load data danh sách
            dataDanhSach = tiepnhan.DSTiepNhan(DateTime.Now.ToShortDateString());
            GanSoLuongPhongKham(dataDanhSach);
        }
        private void GanSoLuongPhongKham(DataTable data)
        {
            lblPhongKham.Text = "";
            if (data != null && data.Rows.Count > 0)
            {
                foreach (var t in listPhongKham)
                {
                    lblPhongKham.Text += "Phòng khám " + t + ": " + data.Select("Phong = " + t).Length + "     ";
                }
            }
            else
            {

                foreach (var t in listPhongKham)
                {
                    lblPhongKham.Text += "Phòng khám " + t + ": 0     ";
                }
            }
            gridControl.DataSource = data;
        }
        private void ResetForm()
        {
            checkBHYT.Checked = true;
            txtNgayTN.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            cbGioiTinh.SelectedIndex = 0;
            cbLyDoVaoVien.SelectedIndex = 0;
            lookUpTaiNan.ItemIndex = 0;
            lookUpMaKhoa.ItemIndex = 0;
            checkCapCuu.Checked = false;
            checkChiTra.Checked = false;
            checkUuTien.Checked = false;
            themMoi = true;
            tiepnhan.TinhTrangRaVien = null;
            // thông tin bệnh nhân
            txtMaQR.Text = null;
            cbKhuVuc.SelectedItem = null;
            txtTheBHYT.Text = null;
            txtTheTu.Text = null;
            txtTheDen.Text = null;
            txtTyLe.Text = null;
            txtTenDKKCB.Text = null;
            txtSTTNgay.Text = null;
            txtMaBN.Text = null;
            txtNgaySinh.Text = null;
            txtMucHuong.Text = null;
            txtMaDKKCB.Text = null;
            txtHoTen.Text = null;
            txtDu5Nam.Text = null;
            txtCanNang.Text = null;
            txtDiaChi.Text = null;
            txtMaQR.Focus();
            //
            btnLuu.Enabled = false;
            btnInLai.Enabled = false;
        }
        private void checkBHYT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBHYT.Checked == true)
            {
                txtMaQR.ReadOnly = false;
                txtTheBHYT.ReadOnly = false;
                txtTheTu.ReadOnly = false;
                txtTheDen.ReadOnly = false;
                txtMaDKKCB.ReadOnly = false;
                txtTenDKKCB.ReadOnly = false;
                txtDu5Nam.ReadOnly = false;
                cbKhuVuc.ReadOnly = false;
                txtMaBN.ReadOnly = true;
                btnKtraThongTuyen.Enabled = true;
                txtMaQR.Focus();
            }
            else
            {
                txtMaQR.ReadOnly = true;
                txtMaQR.Text = null;
                txtTheBHYT.ReadOnly = true;
                txtTheBHYT.Text = null;
                txtTheTu.ReadOnly = true;
                txtTheTu.Text = null;
                txtTheDen.ReadOnly = true;
                txtTheDen.Text = null;
                txtMaDKKCB.ReadOnly = true;
                txtMaDKKCB.Text = null;
                txtTenDKKCB.ReadOnly = true;
                txtTenDKKCB.Text = null;
                txtDu5Nam.ReadOnly = true;
                txtDu5Nam.Text = null;
                cbKhuVuc.ReadOnly = true;
                cbKhuVuc.SelectedItem = null;
                if (themMoi == true)
                    txtMaBN.ReadOnly = false;
                else
                    txtMaBN.ReadOnly = true;
                txtMucHuong.Text = "0";
                txtTyLe.Text = "0";
                btnKtraThongTuyen.Enabled = false;
                txtMaBN.Focus();
            }
        }

        private void checkCapCuu_CheckedChanged(object sender, EventArgs e)
        {
            if(checkCapCuu.Checked == true)
            {
                checkUuTien.Checked = false;
                cbLyDoVaoVien.SelectedIndex = 1;
            }
            else
            {
                cbLyDoVaoVien.SelectedIndex = 0;
            }
        }

        private void checkUuTien_CheckedChanged(object sender, EventArgs e)
        {
            if(checkUuTien.Checked == true)
            {
                checkCapCuu.Checked = false;
            }
        }
        private void ChuyenPhong(int phongKham, bool chuyenTuyen=true)
        {
            // chuyển phòng
            // chưa có mã bệnh nhân
            if(string.IsNullOrEmpty(txtMaBN.Text))
            {
                tiepnhan.MaBN = null;
            }
            else
            {
                tiepnhan.MaBN = txtMaBN.Text;
            }
            tiepnhan.CoThe = checkBHYT.Checked;
            if (tiepnhan.CoThe)
            {
                tiepnhan.MaThe = txtTheBHYT.Text;
                tiepnhan.TheTu = Utils.ToDateTime(txtTheTu.Text, "dd/MM/yyyy");
                tiepnhan.TheDen = Utils.ToDateTime(txtTheDen.Text, "dd/MM/yyyy");
                tiepnhan.MaCS = txtMaDKKCB.Text;
                tiepnhan.Du5Nam = Utils.ToDateTime(txtDu5Nam.Text, "dd/MM/yyyy");
                tiepnhan.MaKhuVuc = Utils.ToString( cbKhuVuc.SelectedItem);
            }
            else
            {
                tiepnhan.MaThe = null;
                tiepnhan.TheTu = DateTime.Now;
                tiepnhan.TheDen =DateTime.Now;
                tiepnhan.MaCS = null;
                tiepnhan.Du5Nam = DateTime.Now;
                tiepnhan.MaKhuVuc = null;
            }
            tiepnhan.HoTen = txtHoTen.Text;
            tiepnhan.NgaySinh = txtNgaySinh.Text;
            tiepnhan.GioiTinh = cbGioiTinh.SelectedIndex;
            tiepnhan.DiaChi = txtDiaChi.Text;
            // tạo mã hoặc cập nhật lại thông tin
            string err = "";
            if(tiepnhan.SpThongTinTiepNhan(ref err))
            {
                txtMaBN.Text = tiepnhan.MaBN;
            }
            // insert dữ liệu tiếp nhận vào ThongTinBNChiTiet
            tiepnhan.MaLK = null;
            tiepnhan.LyDoVaoVien = cbLyDoVaoVien.SelectedIndex + 1;
            tiepnhan.TinhTrang = 0;
            if (checkCapCuu.Checked)
                tiepnhan.TinhTrang = 2;
            if (checkUuTien.Checked)
                tiepnhan.TinhTrang = 1;
            tiepnhan.MaNoiChuyenDen =Utils.ToString( lookUpNoiChuyenDen.EditValue);
            tiepnhan.MaTaiNan = lookUpTaiNan.ItemIndex;
            tiepnhan.NgayVao = Utils.ToDateTime(txtNgayTN.Text, "dd/MM/yyyy HH:mm"); ;
            tiepnhan.MaKhoa = Utils.ToString(lookUpMaKhoa.EditValue);// lúc xuất ra nhớ bỏ dấu _ file XML
            tiepnhan.MaCoSoKCB = AppConfig.CoSoKCB;
            tiepnhan.CanNang = Utils.ToDouble(txtCanNang.Text);
            tiepnhan.STTNgay = null;
            tiepnhan.STTPhong = 0;
            tiepnhan.Phong = phongKham;
            tiepnhan.MucHuong = Utils.ToInt(txtTyLe.Text);
            if (phongKham == 0)
            {
                if(chuyenTuyen == true)
                    tiepnhan.MaLoaiKCB = 1;
                else
                    tiepnhan.MaLoaiKCB = 3;
            }
            else
                tiepnhan.MaLoaiKCB = 1;
            tiepnhan.MienCungCT = null;
            if(txtDu5Nam.Text.Length>0)
            {
                tiepnhan.MienCungCT = Utils.ToDateTime(txtDu5Nam.Text,"dd/MM/yyyy").ToShortDateString();
            }
            // out STTNgay, STTPhong
            err = "";
            if(!tiepnhan.SpThongTinChiTietTiepNhan(ref err))
            {
                XtraMessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtSTTNgay.Text = tiepnhan.STTNgay;
            // in phiếu và tạo mới
            if (phongKham != 0)
                InPhieu();
            LoadData();
            ResetForm();
        }
        private void InPhieu()
        {
            rptSoPhieu.xrlblHoTen.Text = tiepnhan.HoTen + " - " + 
                tiepnhan.NgaySinh.Substring(tiepnhan.NgaySinh.Length - 4, 4);
            rptSoPhieu.xrlblSoPhong.Text = "Phòng " + tiepnhan.Phong;
            rptSoPhieu.xrlblSTT.Text = tiepnhan.STTPhong.ToString();
            rptSoPhieu.xrlblNgay.Text = tiepnhan.NgayVao.ToString("HH:mm dd/MM/yyyy");
            rptSoPhieu.CreateDocument();
            rptSoPhieu.PrintDialog();
        }
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private async void btnKtraThongTuyen_Click(object sender, EventArgs e)
        {
            if (KiemTraThongTinTiepNhan() == false)
                return;
            ThongTinThe thongtin = await Utils.KiemTraThongTuyen(txtTheBHYT.Text, txtHoTen.Text, txtNgaySinh.Text);
            switch (thongtin.Code)
            {
                case "1":
                    // chỉnh thông tin

                    txtHoTen.Text = thongtin.HoTen;
                    txtNgaySinh.Text = thongtin.NgaySinh;
                    cbGioiTinh.SelectedIndex = thongtin.GioiTinh;
                    txtDiaChi.Text = thongtin.DiaChi;
                    if (txtMaDKKCB.Text != thongtin.MaCoSoDKKCB)
                    {
                        txtMaDKKCB.Text = thongtin.MaCoSoDKKCB;
                        object ten = lookUpNoiChuyenDen.Properties.GetDisplayValueByKeyValue(thongtin.MaCoSoDKKCB);
                        if (ten != null)
                            txtTenDKKCB.Text = ten.ToString();
                        else
                            txtTenDKKCB.Text = null;
                    }
                    txtTheTu.Text = thongtin.TheTu;
                    txtTheDen.Text = thongtin.TheDen;
                    txtDu5Nam.Text = thongtin.Du5Nam;
                    btnLichSuKCB.Focus();
                    break;
                default:
                    XtraMessageBox.Show(thongtin.ThongBao.Replace(":", ""), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private async void btnLichSuKCB_Click(object sender, EventArgs e)
        {
            if (!splashScreenManager.IsSplashFormVisible)
            {
                splashScreenManager.ShowWaitForm();

                //   SplashScreenManager.ShowForm(this,typeof(WaitFormLoad),true,true);
                if (checkBHYT.Checked == true)
                {
                    // Lấy danh sách lịch sử trên cổng (trên phần mềm nếu cổng lỗi)
                    if (KiemTraThongTinTiepNhan())//KiemTraThongTinTiepNhan(True)
                    {
                        //ThongTinThe thongtin = new ThongTinThe();
                        //thongtin.MaBN = null;
                        //thongtin.MaThe = txtTheBHYT.Text;
                        //thongtin.HoTen = txtHoTen.Text;
                        //thongtin.NgaySinh = txtNgaySinh.Text;
                        //thongtin.GioiTinh = cbGioiTinh.SelectedIndex;
                        //thongtin.MaCoSoDKKCB = txtMaDKKCB.Text;
                        //thongtin.TheTu = txtTheTu.Text;
                        //thongtin.TheDen = txtTheDen.Text;
                        //ThongTinLichSu thongTinLichSu = await Utils.LichSuKhamChuaBenhBHYT(thongtin);
                        ApiTheBHYT2018 apiTheBHYT2018 = new ApiTheBHYT2018();
                        apiTheBHYT2018.maThe = txtTheBHYT.Text;
                        apiTheBHYT2018.hoTen = txtHoTen.Text;
                        apiTheBHYT2018.ngaySinh = txtNgaySinh.Text;
                        KQLichSuKCB kQNhanLichSu = await Utils.NhanLichSuKCBBS2019(apiTheBHYT2018);
                        if (kQNhanLichSu.maKetQua == "false")
                        {
                            // lỗi hệ thống
                            splashScreenManager.CloseWaitForm();
                            XtraMessageBox.Show(kQNhanLichSu.ghiChu, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            // hiện thông báo, lịch sử
                            //thongTinLichSu.ngaySinh = thongtin.NgaySinh;
                            tiepnhan.MaBN = txtMaBN.Text;
                            kQNhanLichSu.LichSuPhanMem = tiepnhan.DSLichSuPhanMem(txtTheBHYT.Text);
                            lichSuKCB.ThongTin = kQNhanLichSu;
                            lichSuKCB.ShowDialog();
                            txtTheBHYT.Text = kQNhanLichSu.maThe;// Utils.StringToString(kQNhanLichSu.maTheMoi, "").Length > 0 ? kQNhanLichSu.maTheMoi : kQNhanLichSu.maThe;
                            txtHoTen.Text = kQNhanLichSu.hoTen;
                            txtNgaySinh.Text = kQNhanLichSu.ngaySinh;
                            cbGioiTinh.SelectedIndex = kQNhanLichSu.gioiTinh == "Nam" ? 0 : 1;
                            txtDiaChi.Text = kQNhanLichSu.diaChi;
                            txtMaDKKCB.Text = kQNhanLichSu.maDKBDMoi;// Utils.StringToString(kQNhanLichSu.maDKBDMoi, "").Length > 0 ? kQNhanLichSu.maDKBDMoi : kQNhanLichSu.maDKBD;
                            txtDu5Nam.Text = kQNhanLichSu.ngayDu5Nam;
                            cbKhuVuc.SelectedItem = kQNhanLichSu.maKV;
                            txtTheTu.Text = kQNhanLichSu.gtTheTu;// Utils.StringToString( kQNhanLichSu.gtTheTuMoi,"").Length > 0 ? kQNhanLichSu.gtTheTuMoi : kQNhanLichSu.gtTheTu;
                            txtTheDen.Text = kQNhanLichSu.gtTheDen; //Utils.StringToString(kQNhanLichSu.gtTheDenMoi,"").Length > 0 ? kQNhanLichSu.gtTheDenMoi : kQNhanLichSu.gtTheDen;
                        }
                    }
                }
                else
                if (KiemTraThongTinTiepNhan())
                {
                    // Lấy danh sách lịch sử từ phần mềm, dựa vào họ tên, ngày sinh, giới tính -> mã bệnh nhân
                    KQLichSuKCB thongtin = new KQLichSuKCB();
                    thongtin.MaBN = txtMaBN.Text;
                    thongtin.hoTen = txtHoTen.Text;
                    thongtin.ngaySinh = txtNgaySinh.Text;
                    thongtin.gioiTinh = cbGioiTinh.SelectedIndex == 0 ? "Nam" : "Nữ";
                    // lấy lịch sử
                    tiepnhan.MaBN = thongtin.MaBN;
                    tiepnhan.HoTen = thongtin.hoTen;
                    tiepnhan.NgaySinh = thongtin.ngaySinh;
                    tiepnhan.GioiTinh = cbGioiTinh.SelectedIndex;
                    thongtin.LichSuPhanMem = tiepnhan.DSLichSuPhanMem();
                    lichSuKCB.ThongTin = thongtin;
                    lichSuKCB.ShowDialog();
                }
            }
            if (splashScreenManager.IsSplashFormVisible)
            {
                splashScreenManager.CloseWaitForm();
            }
            //SplashScreenManager.CloseForm();
        }

        private void btnInLai_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView.GetFocusedDataRow();
            if(dr!=null)
            {
                string ngaySinh = dr["NgaySinh"].ToString();
                rptSoPhieu.xrlblHoTen.Text = dr["HoTen"] + " - " + ngaySinh.Substring(ngaySinh.Length - 4, 4);
                rptSoPhieu.xrlblSoPhong.Text = "Phòng " + dr["Phong"];
                rptSoPhieu.xrlblSTT.Text = dr["STTPhong"].ToString();
                rptSoPhieu.xrlblNgay.Text = Utils.ToDateTime(dr["NgayVao"].ToString()).ToString("HH:mm dd/MM/yyyy");

                rptSoPhieu.CreateDocument();
                //rptSoPhieu.ShowPreviewDialog();
                rptSoPhieu.PrintDialog();
            }
        }

        private void txtMaQR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                kiemTraQR();
            }
        }

        private void txtTheBHYT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTheTu.Focus();
            }
        }

        private void txtTheTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTheDen.Focus();
            }
        }

        private void txtTheDen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMaDKKCB.Focus();
            }
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtHoTen.Text = Utils.VietHoaTuDong(txtHoTen.Text);
                cbGioiTinh.Focus();
            }
        }

        private void cbGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNgaySinh.Focus();
            }
        }

        private void txtNgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDiaChi.Focus();
            }
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDiaChi.Text = Utils.VietHoaTuDong(txtDiaChi.Text);
                if (checkBHYT.Checked)
                    btnKtraThongTuyen.Focus();
                else
                    btnLichSuKCB.Focus();
            }
        }

        private void txtMaDKKCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                // lấy tên CoSo
                object ten = lookUpNoiChuyenDen.Properties.GetDisplayValueByKeyValue(txtMaDKKCB.Text);
                if (ten != null)
                    txtTenDKKCB.Text = ten.ToString();
                else
                    txtTenDKKCB.Text = null;
                txtHoTen.Focus();
            }
        }
        private void kiemTraQR()
        {
            if (txtMaQR.Text.Length > 0)
            {
                string[] qr = null;
                if (txtMaQR.Text.Split('~').Length > 1)
                {
                    qr = txtMaQR.Text.Split('~');
                }
                if (txtMaQR.Text.Split('|').Length > 1)
                {
                    qr = txtMaQR.Text.Split('|');
                }
                if (qr != null && qr.Length == 15)
                {
                    
                    txtTheBHYT.Text = qr[0];
                    
                    txtHoTen.Text = Utils.HexToText(qr[1]);
                    txtNgaySinh.Text = qr[2];
                    if (int.Parse(qr[3]) == 1)
                    {
                        cbGioiTinh.SelectedIndex = 0;
                    }
                    else
                    {
                        cbGioiTinh.SelectedIndex = 1;
                    }
                    txtDiaChi.Text = Utils.HexToText(qr[4]);
                    txtMaDKKCB.Text = qr[5].Remove(2, 3);
                    // lấy tên CoSo
                    object ten = lookUpNoiChuyenDen.Properties.GetDisplayValueByKeyValue(txtMaDKKCB.Text);
                    if (ten != null)
                        txtTenDKKCB.Text = ten.ToString();
                    else
                        txtTenDKKCB.Text = null;
                    txtTheTu.Text = qr[6];
                    txtTheDen.Text = qr[7];
                    txtDu5Nam.Text = qr[12];

                    if (qr[11] == "5")
                    {
                        cbKhuVuc.SelectedIndex = 0;
                    }
                    else
                    if (qr[11] == "6")
                    {
                        cbKhuVuc.SelectedIndex = 1;
                    }
                    else
                    if (qr[11] == "7")
                    {
                        cbKhuVuc.SelectedIndex = 2;
                    }
                    btnKtraThongTuyen.Focus();

                    return;
                }
                else
                {
                    XtraMessageBox.Show("Sai mã QR!","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaQR.SelectAll();
                    txtMaQR.Focus();
                }
            }
            txtTheBHYT.Focus();
        }

        private void txtTheBHYT_Leave(object sender, EventArgs e)
        {
            this.txtTheBHYT.Leave -= new System.EventHandler(this.txtTheBHYT_Leave);
            if (checkBHYT.Checked == true && txtTheBHYT.Text.Length > 0)
            {
                if (txtTheBHYT.Text.Length != 15)
                {
                    XtraMessageBox.Show(Library.KyTuTheBHYT, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheBHYT.Focus();
                    this.txtTheBHYT.Leave += new System.EventHandler(this.txtTheBHYT_Leave);
                    return;
                }
                LayThongTinBenhNhan(themMoi);
            }
            this.txtTheBHYT.Leave += new System.EventHandler(this.txtTheBHYT_Leave);
        }

        private void txtTheBHYT_EditValueChanged(object sender, EventArgs e)
        {
                LayThongTinBenhNhan(true);
        }
        private void LayThongTinBenhNhan(bool KiemTra = true)
        {
            if (txtTheBHYT.Text.Length == 15 && KiemTra)
            {
                // kiểm tra thông tin thẻ (3 ký tự đầu)
                if (CheckMaThe(txtTheBHYT.Text) == false)
                {
                    txtTheBHYT.Focus();
                    return;
                }
                //lưu lại MaLK, MaBN
                string MaLKcu = tiepnhan.MaLK;
                string MaBNcu = tiepnhan.MaBN;
                // Lấy thông tin thẻ nếu có trong csdl
                // Hồ sơ bệnh án khám trong ngày, kiểm tra lại nội trú
                // Lấy mã bệnh nhân
                tiepnhan.LayThongTinCoThe(txtTheBHYT.Text,
                        Utils.ToDateTime(txtNgayTN.Text, "dd/MM/yyyy").ToShortDateString());
                // Kiểm tra đã tiếp nhận hay chưa, ngày khám 1 lần
                if(!string.IsNullOrEmpty(tiepnhan.MaLK))
                {
                    XtraMessageBox.Show(Library.BenhNhanDaTiepNhan , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheBHYT.Text = null;
                    return;
                }
                // lấy lại MaLK
                if (themMoi == false)
                {
                    tiepnhan.MaLK = MaLKcu;
                    tiepnhan.MaBN = MaBNcu;
                }
                txtMaBN.Text = tiepnhan.MaBN;

                if (string.IsNullOrEmpty(txtMaQR.Text) && !string.IsNullOrEmpty(tiepnhan.MaBN))
                {
                    // gán thông tin, nếu không quyét bằng mã QR
                    //txtMaBN.Text = tiepnhan.MaBN;
                    txtHoTen.Text = tiepnhan.HoTen;
                    txtNgaySinh.Text = tiepnhan.NgaySinh;
                    cbGioiTinh.SelectedIndex = tiepnhan.GioiTinh;
                    txtDiaChi.Text = tiepnhan.DiaChi;
                    txtTheTu.Text = tiepnhan.TheTu.ToString("dd/MM/yyyy");
                    txtTheDen.Text = tiepnhan.TheDen.ToString("dd/MM/yyyy");
                    txtMaDKKCB.Text = tiepnhan.MaCS;
                    object ten = lookUpNoiChuyenDen.Properties.GetDisplayValueByKeyValue(txtMaDKKCB.Text);
                    if (ten != null)
                        txtTenDKKCB.Text = ten.ToString();
                    else
                        txtTenDKKCB.Text = null;
                    txtDu5Nam.Text = tiepnhan.Du5Nam.ToString("dd/MM/yyyy");
                    cbKhuVuc.SelectedItem = tiepnhan.MaKhuVuc;
                    btnKtraThongTuyen.Focus();
                    return;
                }
            }
        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "GioiTinh")
            {
                if (Utils.ToInt(e.Value) == 0)
                    e.DisplayText = "Nam";
                else
                    e.DisplayText = "Nữ";
            }
            else
                if (e.Column.Name == "TinhTrang")
            {
                switch (Utils.ToInt(e.Value))
                {
                    case 2:
                        e.DisplayText = "Cấp cứu";
                        break;
                    case 1:
                        e.DisplayText = "Ưu tiên";
                        break;
                    default:
                        e.DisplayText = "Thường";
                        break;
                }
            }
        }
        // radio check
        private void checkChoKham_CheckedChanged(object sender, EventArgs e)
        {
            if(checkChoKham.Checked)
            {
                var data = dataDanhSach.Select(Library.SqlChoKham);
                if (data.Length > 0)
                    GanSoLuongPhongKham(data.CopyToDataTable());
                else
                    GanSoLuongPhongKham(null);
            }
        }

        private void checkTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTatCa.Checked)
                GanSoLuongPhongKham(dataDanhSach);
        }

        private void checkDaKham_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDaKham.Checked)
            {
                var data = dataDanhSach.Select(Library.SqlDaKham);
                if (data.Length > 0)
                    GanSoLuongPhongKham(data.CopyToDataTable());
                else
                    GanSoLuongPhongKham(null);
            }
        }

        private void checkChuyenTuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkChuyenTuyen.Checked)
            {
                var data = dataDanhSach.Select(Library.SqlChuyenTuyen);
                if (data.Length > 0)
                    GanSoLuongPhongKham(data.CopyToDataTable());
                else
                    GanSoLuongPhongKham(null);
            }
        }

        private void checkNhapVien_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNhapVien.Checked)
            {
                var data = dataDanhSach.Select(Library.SqlNhapVien);
                if (data.Length > 0)
                    GanSoLuongPhongKham(data.CopyToDataTable());
                else
                    GanSoLuongPhongKham(null);
            }
        }

        private void checkRaVien_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRaVien.Checked)
            {
                var data = dataDanhSach.Select(Library.SqlRaVien);
                if (data.Length > 0)
                    GanSoLuongPhongKham(data.CopyToDataTable());
                else
                    GanSoLuongPhongKham(null);
            }
        }

        private void checkTatCaDS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTatCaDS.Checked && dataDanhSach2!=null)
            {
                gridControlDS.DataSource = dataDanhSach2;
                lblSoLuong.Text = Utils.ToString(dataDanhSach2.Rows.Count);
            }
        }

        private void checkChoKhamDS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkChoKhamDS.Checked && dataDanhSach2!=null)
            {
                var data = dataDanhSach2.Select(Library.SqlChoKham);
                if (data.Length > 0)
                    gridControlDS.DataSource = data.CopyToDataTable();
                else
                    gridControlDS.DataSource = null;
                lblSoLuong.Text = data.Length.ToString();
            }
        }

        private void checkDaKhamDS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDaKhamDS.Checked && dataDanhSach2 != null)
            {
                var data = dataDanhSach2.Select(Library.SqlDaKham);
                if (data.Length > 0)
                    gridControlDS.DataSource = data.CopyToDataTable();
                else
                    gridControlDS.DataSource = null;
                lblSoLuong.Text = data.Length.ToString();
            }
        }

        private void checkChuyenTuyenDS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkChuyenTuyenDS.Checked && dataDanhSach2 != null)
            {
                var data = dataDanhSach2.Select(Library.SqlChuyenTuyen);
                if (data.Length > 0)
                    gridControlDS.DataSource = data.CopyToDataTable();
                else
                    gridControlDS.DataSource = null;
                lblSoLuong.Text = data.Length.ToString();
            }
        }

        private void checkNhapVienDS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNhapVienDS.Checked && dataDanhSach2 != null)
            {
                var data = dataDanhSach2.Select(Library.SqlNhapVien);
                if (data.Length > 0)
                    gridControlDS.DataSource = data.CopyToDataTable();
                else
                    gridControlDS.DataSource = null;
                lblSoLuong.Text = data.Length.ToString();
            }
        }

        private void checkRaVienDS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRaVienDS.Checked && dataDanhSach2 != null)
            {
                var data = dataDanhSach2.Select(Library.SqlRaVien);
                if (data.Length > 0)
                    gridControlDS.DataSource = data.CopyToDataTable();
                else
                    gridControlDS.DataSource = null;
                lblSoLuong.Text = data.Length.ToString();
            }
        }
        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridView.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                themMoi = false;
                btnInLai.Enabled = true;
                Enabled_Luu();
                tiepnhan.MaLK = dr["MaLK"].ToString();
                //
                txtMaBN.Text = dr["MaBN"].ToString();
                txtHoTen.Text = dr["HoTen"].ToString();
                txtNgayTN.Text = Utils.ToDateTime(dr["NgayVao"].ToString()).ToString("dd/MM/yyyy HH:mm");
                txtNgaySinh.Text = dr["NgaySinh"].ToString();
                txtDiaChi.Text = dr["DiaChi"].ToString();
                cbGioiTinh.SelectedIndex = Utils.ToInt(dr["GioiTinh"]);
                txtSTTNgay.Text = dr["STTNgay"].ToString();
                cbLyDoVaoVien.SelectedIndex = Utils.ToInt(dr["MaLyDoVaoVien"]) - 1;
                int tinhTrang = Utils.ToInt(dr["TinhTrang"]);
                checkUuTien.Checked = false;
                checkCapCuu.Checked = false;
                if (tinhTrang == 1)
                    checkUuTien.Checked = true;
                if (tinhTrang == 2)
                    checkCapCuu.Checked = true;
                txtCanNang.Text = dr["CanNang"].ToString();
                lookUpTaiNan.EditValue = dr["MaTaiNan"];
                lookUpNoiChuyenDen.EditValue = dr["MaNoiChuyenDen"];
                checkBHYT.Checked = Utils.ToBoolean(dr["CoThe"]);
                if (checkBHYT.Checked)
                {
                    this.txtTheBHYT.EditValueChanged -= new System.EventHandler(this.txtTheBHYT_EditValueChanged);
                    txtTheBHYT.Text = dr["MaThe"].ToString();
                    this.txtTheBHYT.EditValueChanged += new System.EventHandler(this.txtTheBHYT_EditValueChanged);
                    txtTheTu.Text = Utils.ToDateTime(dr["TheTu"].ToString()).ToString("dd/MM/yyyy");
                    txtTheDen.Text = Utils.ToDateTime(dr["TheDen"].ToString()).ToString("dd/MM/yyyy");
                    txtTyLe.Text = dr["MucHuong"].ToString();
                    txtMucHuong.Text = txtTheBHYT.Text.Substring(2, 1);
                    cbKhuVuc.SelectedItem = dr["MaKhuVuc"];
                    txtMaDKKCB.Text = dr["MaDKBD"].ToString();
                    // lấy tên cơ sở
                    object ten = lookUpNoiChuyenDen.Properties.GetDisplayValueByKeyValue(txtMaDKKCB.Text);
                    if (ten != null)
                        txtTenDKKCB.Text = ten.ToString();
                    else
                        txtTenDKKCB.Text = null;
                    txtDu5Nam.Text = null;
                    if (!string.IsNullOrEmpty(dr["MienCungCT"].ToString()))
                    {
                        txtDu5Nam.Text = Utils.ToDateTime(dr["MienCungCT"].ToString()).ToString("dd/MM/yyyy");
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(themMoi == false && !string.IsNullOrEmpty(tiepnhan.MaLK))
            {
                // lưu lại thông tin trừ trường hợp không có internet
                // kiểm tra thông tuyến và lưu lại
                tiepnhan.MaBN = txtMaBN.Text;
                tiepnhan.CoThe = checkBHYT.Checked;
                if (tiepnhan.CoThe)
                {
                    tiepnhan.MaThe = txtTheBHYT.Text;
                    tiepnhan.TheTu = Utils.ToDateTime(txtTheTu.Text, "dd/MM/yyyy");
                    tiepnhan.TheDen = Utils.ToDateTime(txtTheDen.Text, "dd/MM/yyyy");
                    tiepnhan.MaCS = txtMaDKKCB.Text;
                    tiepnhan.Du5Nam = Utils.ToDateTime(txtDu5Nam.Text, "dd/MM/yyyy");
                    tiepnhan.MaKhuVuc = Utils.ToString(cbKhuVuc.SelectedItem);
                    tiepnhan.MienCungCT = null;
                    if (txtDu5Nam.Text.Length>0)
                    {
                        tiepnhan.MienCungCT = Utils.ToDateTime(txtDu5Nam.Text, "dd/MM/yyyy").ToShortDateString();
                    }
                }
                else
                {
                    tiepnhan.MaThe = null;
                    tiepnhan.TheTu = DateTime.Now;
                    tiepnhan.TheDen = DateTime.Now;
                    tiepnhan.MaCS = null;
                    tiepnhan.Du5Nam = DateTime.Now;
                    tiepnhan.MaKhuVuc = null;
                }
                tiepnhan.HoTen = txtHoTen.Text;
                tiepnhan.NgaySinh = txtNgaySinh.Text;
                tiepnhan.GioiTinh = cbGioiTinh.SelectedIndex;
                tiepnhan.DiaChi = txtDiaChi.Text;
                tiepnhan.LyDoVaoVien = cbLyDoVaoVien.SelectedIndex + 1;
                tiepnhan.TinhTrang = 0;
                if (checkCapCuu.Checked)
                    tiepnhan.TinhTrang = 2;
                if (checkUuTien.Checked)
                    tiepnhan.TinhTrang = 1;
                tiepnhan.MaNoiChuyenDen = Utils.ToString(lookUpNoiChuyenDen.EditValue);
                tiepnhan.MaTaiNan = lookUpTaiNan.ItemIndex;
                tiepnhan.NgayVao = Utils.ToDateTime( txtNgayTN.Text,"dd/MM/yyyy HH:mm");
                tiepnhan.MaKhoa = Utils.ToString(lookUpMaKhoa.EditValue);// lúc xuất ra nhớ bỏ dấu _ file XML
                tiepnhan.MaCoSoKCB = AppConfig.CoSoKCB;
                tiepnhan.CanNang = Utils.ToDouble(txtCanNang.Text);
                //tiepnhan.STTNgay = null;
                //tiepnhan.STTPhong = 0;
                //tiepnhan.Phong = phongKham;
                tiepnhan.MucHuong = Utils.ToInt(txtTyLe.Text);
                //tiepnhan.MaLoaiKCB = 1;
                string err = "";
                //
                //tiepnhan.MaBN = null;
                //if (tiepnhan.SpThongTinTiepNhan(ref err))
                //{
                //    txtMaBN.Text = tiepnhan.MaBN;
                //}
                //tiepnhan.MaBN = txtMaBN.Text;
                //
                if (!tiepnhan.SpThongTinChiTietTiepNhan(ref err, "UpdateTiepNhan"))
                {
                    XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    XtraMessageBox.Show(Library.LuuThanhCong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    LoadData();
                }
            }
        }

        private void btnNhapVien_Click(object sender, EventArgs e)
        {
            if (KiemTraThongTinTiepNhan(true) && themMoi)
            {
                FrmChonKhoa frm = new FrmChonKhoa(tiepnhan.DSKhoaBan(1));
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    lookUpMaKhoa.EditValue = frm.MaKhoa;
                    ChuyenPhong(0,false);
                }
            }
        }

        private void btnChuyenTuyen_Click(object sender, EventArgs e)
        {
            if (KiemTraThongTinTiepNhan(true) && themMoi)
            {
                // chuyển tuyến : Tình trạng ra viện 2: Chuyển viện
                DataRow dr = gridView.GetFocusedDataRow();
                if (dr != null)
                {
                    DialogResult traloi;
                    traloi = XtraMessageBox.Show(Library.ChuyenTuyenBenhNhan, "Trả lời",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (traloi == DialogResult.Yes)
                    {
                        tiepnhan.TinhTrangRaVien = "2";
                        ChuyenPhong(0);
                    }
                }
            }
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            DataRow dr = gridViewDS.GetFocusedDataRow();
            if (dr != null)
            {
                themMoi = false;
                btnInLai.Enabled = true;
                Enabled_Luu();
                tiepnhan.MaLK = dr["MaLK"].ToString();
                tiepnhan.MaBN = dr["MaBN"].ToString();
                //
                txtMaBN.Text = dr["MaBN"].ToString();
                txtHoTen.Text = dr["HoTen"].ToString();
                txtNgaySinh.Text = dr["NgaySinh"].ToString();
                txtDiaChi.Text = dr["DiaChi"].ToString();
                txtNgayTN.Text = Utils.ToDateTime(dr["NgayVao"].ToString()).ToString("dd/MM/yyyy HH:mm");
                cbGioiTinh.SelectedIndex = Utils.ToInt(dr["GioiTinh"]);
                txtSTTNgay.Text = dr["STTNgay"].ToString();
                cbLyDoVaoVien.SelectedIndex = Utils.ToInt(dr["MaLyDoVaoVien"]) - 1;
                int tinhTrang = Utils.ToInt(dr["TinhTrang"]);
                checkUuTien.Checked = false;
                checkCapCuu.Checked = false;
                if (tinhTrang == 1)
                    checkUuTien.Checked = true;
                if (tinhTrang == 2)
                    checkCapCuu.Checked = true;
                txtCanNang.Text = dr["CanNang"].ToString();
                lookUpTaiNan.EditValue = dr["MaTaiNan"];
                lookUpNoiChuyenDen.EditValue = dr["MaNoiChuyenDen"];
                checkBHYT.Checked = Utils.ToBoolean(dr["CoThe"]);
                lookUpMaKhoa.EditValue = dr["MaKhoa"];
                if (checkBHYT.Checked)
                {
                    this.txtTheBHYT.EditValueChanged -= new System.EventHandler(this.txtTheBHYT_EditValueChanged);
                    txtTheBHYT.Text = dr["MaThe"].ToString();
                    this.txtTheBHYT.EditValueChanged += new System.EventHandler(this.txtTheBHYT_EditValueChanged);
                    txtTheTu.Text = Utils.ToDateTime(dr["TheTu"].ToString()).ToString("dd/MM/yyyy");
                    txtTheDen.Text = Utils.ToDateTime(dr["TheDen"].ToString()).ToString("dd/MM/yyyy");
                    txtTyLe.Text = dr["MucHuong"].ToString();
                    txtMucHuong.Text = txtTheBHYT.Text.Substring(2, 1);
                    cbKhuVuc.SelectedItem = dr["MaKhuVuc"];
                    txtMaDKKCB.Text = dr["MaDKBD"].ToString();
                    // lấy tên cơ sở
                    object ten = lookUpNoiChuyenDen.Properties.GetDisplayValueByKeyValue(txtMaDKKCB.Text);
                    if (ten != null)
                        txtTenDKKCB.Text = ten.ToString();
                    else
                        txtTenDKKCB.Text = null;
                    txtDu5Nam.Text = null;
                    if (!string.IsNullOrEmpty(dr["MienCungCT"].ToString()))
                    {
                        txtDu5Nam.Text = Utils.ToDateTime(dr["MienCungCT"].ToString()).ToString("dd/MM/yyyy");
                    }
                }
                xtraTabControl.SelectedTabPageIndex = 0;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dataDanhSach2 = tiepnhan.DSTiepNhan(dateTuNgay.DateTime.ToShortDateString(), 
                dateDenNgay.DateTime.ToShortDateString());
            lblSoLuong.Text =Utils.ToString(dataDanhSach2.Rows.Count);
            gridControlDS.DataSource = dataDanhSach2;
        }

        // radio check
        private void txtMaBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13 )
            {
                // lấy thông tin bệnh nhân, không có thẻ
                if(checkBHYT.Checked == false)
                {
                    if(txtMaBN.Text.Length > 11 && tiepnhan.LayThongTinKhongThe(txtMaBN.Text))
                    {
                        txtMaBN.Text = tiepnhan.MaBN;
                        txtHoTen.Text = tiepnhan.HoTen;
                        txtNgaySinh.Text = tiepnhan.NgaySinh;
                        cbGioiTinh.SelectedIndex = tiepnhan.GioiTinh;
                        txtDiaChi.Text = tiepnhan.DiaChi;
                        if(tiepnhan.CoThe)
                        {
                            checkBHYT.Checked = true;
                            //this.txtTheBHYT.EditValueChanged -= new System.EventHandler(this.txtTheBHYT_EditValueChanged);
                            txtTheBHYT.Text = tiepnhan.MaThe;
                            return;
                        }
                        btnLichSuKCB.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show(Library.MaBNKhongTonTai, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMaBN.Text = null;
                    }
                }
                txtHoTen.Focus();
            }
        }

        private bool CheckMaThe(string maThe)
        {

            DataRow[] dr = null;
            dr = dataMucHuong.Select("Ma = '"+maThe.Substring(0,3)+"'", "");
            if(dr!=null && dr.Length >0)
            {
                txtTyLe.Text = dr[0]["TyLe"].ToString();
                txtMucHuong.Text = dr[0]["MaHieu"].ToString();
            }
            else
            {
                XtraMessageBox.Show(Library.BaKyTuDau, "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            dr = null;
            dr = dataTinh.Select("Ma = '"+maThe.Substring(3,2)+"'", "");
            if(dr == null || dr.Length == 0)
            {
                XtraMessageBox.Show(Library.HaiKyTuTinh, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool KiemTraThongTinTiepNhan(bool ktraChiTiet = false)
        {
            if (checkBHYT.Checked)
            {
                if (string.IsNullOrEmpty(txtTheBHYT.Text))
                {
                    XtraMessageBox.Show(Library.NhapMaThe, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheBHYT.Focus();
                    return false;
                }
                if (ktraChiTiet && string.IsNullOrEmpty(txtTheTu.Text))
                {
                    XtraMessageBox.Show(Library.NhapTheTu, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheTu.Focus();
                    return false;
                }
                if (ktraChiTiet && string.IsNullOrEmpty(txtTheDen.Text))
                {
                    XtraMessageBox.Show(Library.NhapTheDen, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheDen.Focus();
                    return false;
                }
                DateTime theTu = Utils.ToDateTime(txtTheTu.Text, "dd/MM/yyyy");
                DateTime theDen = Utils.ToDateTime(txtTheDen.Text, "dd/MM/yyyy");
                if (ktraChiTiet && theTu > DateTime.Now)
                {
                    XtraMessageBox.Show(Library.TheTuLonHonHienTai, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheTu.Focus();
                    return false;
                }
                if (ktraChiTiet && theTu > theDen)
                {
                    XtraMessageBox.Show(Library.TheTuLonHonTheDen, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheDen.Focus();
                    return false;
                }
                if(ktraChiTiet && theDen <= DateTime.Now)
                {
                    XtraMessageBox.Show(Library.TheHetHan, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheDen.Focus();
                    return false;
                }
                if (ktraChiTiet && string.IsNullOrEmpty(txtMaDKKCB.Text))
                {
                    XtraMessageBox.Show(Library.NhapKCBBD, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaDKKCB.Focus();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                XtraMessageBox.Show(Library.NhapHoTen, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNgaySinh.Text))
            {
                XtraMessageBox.Show(Library.NhapNgaySinh, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgaySinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text) && ktraChiTiet)
            {
                XtraMessageBox.Show(Library.NhapDiaChi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }
    }
}
