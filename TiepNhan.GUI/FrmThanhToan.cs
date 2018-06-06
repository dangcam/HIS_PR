using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
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
using System.Xml;

namespace TiepNhan.GUI
{
    public partial class FrmThanhToan : RibbonForm
    {
        ThanhToanEntity thanhtoan;
        DataTable dataDanhSach, dataLoc, dataTinh, dataMucHuong;
        string maBenh,maBenhKhac, maBacSi;
        int index = -1;
        DataTable dataDichVu, dataThuoc, dataCongKham, dataVTYT, dataChiTiet;
        FrmCongKham frmCongKham;
        Dictionary<int, NhomChiPhi> nhomChiPhi = new Dictionary<int, NhomChiPhi>();
        decimal tienthuoc = 0, tiendichvu = 0, tienvattu = 0, tienbntt = 0;
        int mucHuong = 0;
        System.Drawing.Font fontB = new System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Bold);
        System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 10);
        public FrmThanhToan()
        {
            InitializeComponent();
            thanhtoan = new ThanhToanEntity();
            dataTinh = thanhtoan.DSTinh();
            dataMucHuong = thanhtoan.DSMucHuong();
            dataChiTiet = new DataTable();
            frmCongKham = new FrmCongKham(thanhtoan);
            // add column dataChiTiet
            dataChiTiet.Columns.Add("MaDichVu", typeof(string));
            dataChiTiet.Columns.Add("TenDichVu", typeof(string));
            dataChiTiet.Columns.Add("DonViTinh", typeof(string));
            dataChiTiet.Columns.Add("SoLuong", typeof(int));
            dataChiTiet.Columns.Add("DonGia", typeof(decimal));
            dataChiTiet.Columns.Add("ThanhTien", typeof(decimal));
            dataChiTiet.Columns.Add("TenNhom", typeof(string));
            dataChiTiet.Columns.Add("Mau01", typeof(float));
            dataChiTiet.Columns.Add("Mau02", typeof(float));
            dataChiTiet.Columns.Add("TyLe", typeof(string));
            foreach (DataRow dr in thanhtoan.DSNhom().Rows)
            {
                nhomChiPhi.Add(Utils.ToInt(dr["MaNhom"]),
                    new NhomChiPhi(dr["TenNhom"].ToString(), dr["Mau01"].ToString(), dr["Mau02"].ToString()));
            }
        }

        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            DataTable dtKhoa = thanhtoan.DSKhoaBan(1);
            repLookUpKhoa.DataSource = dtKhoa;
            repLookUpKhoa.DisplayMember = "TenKhoa";
            repLookUpKhoa.ValueMember = "MaKhoa";
            lookUpKhoa.Properties.DataSource = dtKhoa;
            lookUpKhoa.Properties.DisplayMember = "TenKhoa";
            lookUpKhoa.Properties.ValueMember = "MaKhoa";

            lookUpTaiNan.Properties.DataSource = thanhtoan.DSTaiNan();
            lookUpTaiNan.Properties.DisplayMember = "Ten";
            lookUpTaiNan.Properties.ValueMember = "Ma";

            lookUpNoiChuyenDen.Properties.DataSource = thanhtoan.DSCoSoKCB();
            lookUpNoiChuyenDen.Properties.ValueMember = "Ma_CS";
            lookUpNoiChuyenDen.Properties.DisplayMember = "Ten_CS";

            lookUpMaBenh.Properties.DataSource = thanhtoan.DSBenh();
            lookUpMaBenh.Properties.DisplayMember = "MaBenh";

            lookUpBacSi.Properties.DataSource = thanhtoan.DSBacSi();
            lookUpBacSi.Properties.DisplayMember = "Ten_NV";
            lookUpBacSi.Properties.ValueMember = "Ma_BS";

            cbLoaiKCB.SelectedIndex = 0;
            cbTimTheo.SelectedIndex = 0;
            dateDenNgay.DateTime = DateTime.Now;
            dateTuNgay.DateTime = DateTime.Now;

            thanhtoan.MaLK = null;
            maBacSi = null;
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            checkDaKham.Checked = false;
            checkRaVien.Checked = false;
            dataDanhSach = thanhtoan.DSBenhNhan(dateTuNgay.DateTime,dateDenNgay.DateTime,
                cbLoaiKCB.SelectedIndex,cbTimTheo.SelectedIndex);
            if(cbLoaiKCB.SelectedIndex==0)
            {
                checkDaKham.Checked = true;
            }
            else
            {
                checkRaVien.Checked = true;
            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            index = gridView.GetFocusedDataSourceRowIndex();
            if(index>-1)
            {
                xtraTabControl.SelectedTabPageIndex = 1;
                this.ActiveControl = btnKtraTT;
                LoadThongTin(index);
            }

        }
        private void LoadThongTin(int index)
        {
           if(dataLoc!=null && dataLoc.Rows.Count>0)
            {
                DataRow dr = dataLoc.Rows[index];
                if(Utils.ToBoolean(dr["CoThe"]))
                {

                    checkCoThe.Checked = true;
                    this.txtTheBHYT.EditValueChanged -= new System.EventHandler(this.txtTheBHYT_EditValueChanged);
                    txtTheBHYT.Text = dr["MaThe"].ToString().Trim();
                    this.txtTheBHYT.EditValueChanged += new System.EventHandler(this.txtTheBHYT_EditValueChanged);
                    txtTheTu.Text = Utils.ToDateTime(dr["TheTu"].ToString()).ToString("dd/MM/yyyy");
                    txtTheDen.Text = Utils.ToDateTime(dr["TheDen"].ToString()).ToString("dd/MM/yyyy");
                    txtMucHuong.Text = dr["MucHuong"].ToString();
                    //txtMucHuong.Text = txtTheBHYT.Text.Substring(2, 1);
                    cbKhuVuc.SelectedItem = dr["MaKhuVuc"];
                    txtMaCoSoDKKCB.Text = dr["MaDKBD"].ToString();
                    // lấy tên cơ sở
                    object ten = lookUpNoiChuyenDen.Properties.GetDisplayValueByKeyValue(txtMaCoSoDKKCB.Text);
                    if (ten != null)
                        txtTenCoSoDKKCB.Text = ten.ToString();
                    else
                        txtTenCoSoDKKCB.Text = null;
                    txtDu5Nam.Text = null;
                    if (!string.IsNullOrEmpty(dr["MienCungCT"].ToString()))
                    {
                        txtDu5Nam.Text = Utils.ToDateTime(dr["MienCungCT"].ToString()).ToString("dd/MM/yyyy");
                    }
                    //
                    btnKtraTT.Enabled = true;
                }
                else
                {
                    checkCoThe.Checked = false;
                    btnKtraTT.Enabled = false;
                }
                txtHoTen.Text = dr["HoTen"].ToString();
                txtNgaySinh.Text = dr["NgaySinh"].ToString();
                cbGioiTinh.SelectedIndex = Utils.ToInt(dr["GioiTinh"]);
                txtDiaChi.Text = dr["DiaChi"].ToString();
                maBenh = dr["MaBenh"].ToString();
                maBenhKhac = dr["MaBenhKhac"].ToString();
                txtTenBenh.Text = dr["TenBenh"].ToString();
                cbLyDoVVien.SelectedIndex = Utils.ToInt(dr["MaLyDoVaoVien"]) - 1;
                lookUpNoiChuyenDen.EditValue = dr["MaNoiChuyenDen"];
                lookUpTaiNan.EditValue = dr["MaTaiNan"];
                dateNgayVao.DateTime = Utils.ToDateTime(dr["NgayVao"].ToString());
                dateNgayRa.DateTime = Utils.ToDateTime(dr["NgayRa"].ToString());
                txtSoNgayDTri.Text = Utils.ToInt(dr["SoNgayDieuTri"], (dateNgayRa.DateTime - dateNgayVao.DateTime).Days + 1).ToString();
                cbKQDieuTri.SelectedIndex = Utils.ToInt(dr["KetQuaDieuTri"],1) - 1;
                cbTTRaVien.SelectedIndex = Utils.ToInt(dr["TinhTrangRaVien"],1) - 1;
                if (cbKQDieuTri.SelectedIndex < 0)
                    cbKQDieuTri.SelectedIndex = 0;
                if (cbTTRaVien.SelectedIndex < 0)
                    cbTTRaVien.SelectedIndex = 0;
                dateNgayTToan.DateTime = Utils.ToDateTime(dr["NgayThanhToan"].ToString());
                txtMaBN.Text = dr["MaBN"].ToString();
                txtSTTNgay.Text = dr["STTNgay"].ToString();
                lookUpKhoa.EditValue = dr["MaKhoa"];
                //
                thanhtoan.MaLK = dr["MaLK"].ToString();
                LoadChiTiet();
            }
           else
            {
                thanhtoan.MaLK = null;
            }
        }
        private void LoadChiTiet()
        {
            
            dataDichVu = thanhtoan.DSDichVuChiTiet();
            dataThuoc = thanhtoan.DSThuocChiTiet();
            dataVTYT = thanhtoan.DSVTYTChiTiet();
            LoadCongKham();
        }
        private void LoadCongKham()
        {
            dataChiTiet.Rows.Clear();
            dataCongKham = thanhtoan.DSCongKhamChiTiet();
            tienthuoc = 0; tiendichvu = 0; tienvattu = 0 ;
            tienbntt = 0;
            DataRow dataRow;
            maBacSi = null;
            
            foreach (DataRow dr in dataVTYT.Rows)
            {
                if(Utils.ToInt(dr["TyLe"],100) == 0)
                {
                    tienbntt+= Utils.ToDecimal(dr["ThanhTien"]);
                }
                tienvattu += Utils.ToDecimal(dr["ThanhTien"]);
                dataRow = dataChiTiet.NewRow();
                dataRow["MaDichVu"] = dr["MaVT"];
                dataRow["TenDichVu"] = dr["TenVatTu"];
                dataRow["DonViTinh"] = dr["DonViTinh"];
                dataRow["SoLuong"] = dr["SoLuong"];
                dataRow["DonGia"] = dr["DonGia"];
                dataRow["ThanhTien"] = dr["ThanhTien"];
                dataRow["TenNhom"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Ten;
                dataRow["Mau01"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Mau1;
                dataRow["Mau02"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Mau2;
                dataRow["TyLe"] = dr["TyLe"];//
                maBacSi = dr["MaBacSi"].ToString();
                dataChiTiet.Rows.Add(dataRow);
            }
            foreach (DataRow dr in dataDichVu.Rows)
            {
                if (Utils.ToInt(dr["TyLe"], 100) == 0)
                {
                    tienbntt += Utils.ToDecimal(dr["ThanhTien"]);
                }
                tiendichvu += Utils.ToDecimal(dr["ThanhTien"]);
                dataRow = dataChiTiet.NewRow();
                dataRow["MaDichVu"] = dr["MaDichVu"];
                dataRow["TenDichVu"] = dr["TenDichVu"];
                dataRow["DonViTinh"] = dr["DonViTinh"];
                dataRow["SoLuong"] = dr["SoLuong"];
                dataRow["DonGia"] = dr["DonGia"];
                dataRow["ThanhTien"] = dr["ThanhTien"];
                dataRow["Mau01"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Mau1;
                dataRow["Mau02"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Mau2;
                dataRow["TenNhom"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Ten;
                dataRow["TyLe"] = dr["TyLe"];//
                maBacSi = dr["MaBacSi"].ToString();
                dataChiTiet.Rows.Add(dataRow);
            }
            foreach (DataRow dr in dataCongKham.Rows)
            {
                if (Utils.ToInt(dr["TyLe"], 100) == 0)
                {
                    tienbntt += Utils.ToDecimal(dr["ThanhTien"]);
                }
                tiendichvu += Utils.ToDecimal(dr["ThanhTien"]);
                dataRow = dataChiTiet.NewRow();
                dataRow["MaDichVu"] = dr["MaDichVu"];
                dataRow["TenDichVu"] = dr["TenDichVu"];
                dataRow["DonViTinh"] = dr["DonViTinh"];
                dataRow["SoLuong"] = dr["SoLuong"];
                dataRow["DonGia"] = dr["DonGia"];
                dataRow["ThanhTien"] = dr["ThanhTien"];
                dataRow["Mau01"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Mau1;
                dataRow["Mau02"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Mau2;
                dataRow["TenNhom"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Ten;
                dataRow["TyLe"] = dr["TyLe"];//
                maBacSi = dr["MaBacSi"].ToString();
                dataChiTiet.Rows.Add(dataRow);
            }
            foreach (DataRow dr in dataThuoc.Rows)
            {
                if (Utils.ToInt(dr["TyLe"], 100) == 0)
                {
                    tienbntt += Utils.ToDecimal(dr["ThanhTien"]);
                }
                tienthuoc += Utils.ToDecimal(dr["ThanhTien"]);
                dataRow = dataChiTiet.NewRow();
                dataRow["MaDichVu"] = dr["MaThuoc"];
                dataRow["TenDichVu"] = dr["TenThuoc"];
                dataRow["DonViTinh"] = dr["DonViTinh"];
                dataRow["SoLuong"] = dr["SoLuong"];
                dataRow["DonGia"] = dr["DonGia"];
                dataRow["ThanhTien"] = dr["ThanhTien"];
                dataRow["Mau01"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Mau1;
                dataRow["Mau02"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Mau2;
                dataRow["TenNhom"] = nhomChiPhi[Utils.ToInt(dr["MaNhom"])].Ten;
                dataRow["TyLe"] = dr["TyLe"];//
                maBacSi = dr["MaBacSi"].ToString();
                dataChiTiet.Rows.Add(dataRow);
            }          
            lookUpBacSi.EditValue = maBacSi;
            gridControlCT.DataSource = dataChiTiet;
            gridViewCT.ExpandAllGroups();

            mucHuong =Utils.ToInt( txtMucHuong.Text);
            decimal tt = tienvattu + tienthuoc + tiendichvu;
            if (checkCoThe.Checked)
            {
                DataRow[] dr = null;
                dr = dataMucHuong.Select("Ma = '" + txtTheBHYT.Text.Substring(0, 3) + "'", "");
                if (dr != null && dr.Length > 0)
                {
                    mucHuong = Utils.ToInt(dr[0]["TyLe"].ToString());
                }
                decimal luongCoSo =Utils.ToDecimal( thanhtoan.LuongCoSo());
                if (luongCoSo > 0 && ((luongCoSo * 0.15m) > (tt)))
                {
                    mucHuong = 100;
                }
            }
            else
            {
                // không có thẻ
                mucHuong = 0;
            }
            txtMucHuong.Text = mucHuong.ToString();
            txtTongTien.Text = Utils.ToString(tt);
            txtBHTT.Text = Utils.ToString((tt-tienbntt) * (mucHuong / 100m));
            txtBNCCT.Text = Utils.ToString((tt - tienbntt) * (1m - (mucHuong / 100m)) + tienbntt);
        }
        private void checkTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if(checkTatCa.Checked)
            {
                dataLoc = dataDanhSach;
                gridControl.DataSource = dataLoc;
            }
        }

        private void checkDaKham_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDaKham.Checked)
            {
                var data = dataDanhSach.Select(Library.SqlDaKham);
                if (data.Length > 0)
                    dataLoc = data.CopyToDataTable();
                else
                    dataLoc = null;
                gridControl.DataSource = dataLoc;
            }
        }

        private void btnCongKham_Click(object sender, EventArgs e)
        {
            if(KiemTraBenhBacSi())
            {
                frmCongKham.MaLK = thanhtoan.MaLK;
                frmCongKham.MaBacSi = Utils.ToString(lookUpBacSi.EditValue);
                frmCongKham.MaKhoa = Utils.ToString(lookUpKhoa.EditValue);
                frmCongKham.ShowDialog();
                LoadCongKham();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LuuHoSo();
        }
        private void LuuHoSo(bool inHoSo = false,bool xemHoSo = false)
        {
            // lưu 3 bảng, thông tin, vật tư, dịch vụ
            if (KiemTraBenhBacSi())
            {
                string err = "";
                thanhtoan.HoTen = txtHoTen.Text;
                thanhtoan.NgaySinh = txtNgaySinh.Text;
                thanhtoan.GioiTinh = cbGioiTinh.SelectedIndex;
                thanhtoan.DiaChi = txtDiaChi.Text;
                if (checkCoThe.Checked)
                {
                    thanhtoan.CoThe = true;
                    thanhtoan.MaThe = txtTheBHYT.Text.Trim();
                    thanhtoan.TheTu = Utils.ToDateTime(txtTheTu.Text, "dd/MM/yyyy");
                    thanhtoan.TheDen = Utils.ToDateTime(txtTheDen.Text, "dd/MM/yyyy");
                    thanhtoan.MaDKBD = txtMaCoSoDKKCB.Text;
                    thanhtoan.MaKhuVuc = Utils.ToString(cbKhuVuc.SelectedItem);
                    thanhtoan.MienCungCT = null;
                    if (txtDu5Nam.Text.Length > 0)
                    {
                        thanhtoan.MienCungCT = Utils.ToDateTime(txtDu5Nam.Text, "dd/MM/yyyy").ToShortDateString();
                    }
                    thanhtoan.TyLe = 100;// chưa chắc là 100
                }
                else
                {
                    thanhtoan.CoThe = false;
                    thanhtoan.MaThe = null;
                    thanhtoan.TheTu = DateTime.Now;
                    thanhtoan.TheDen = DateTime.Now;
                    thanhtoan.MaDKBD = null;
                    thanhtoan.MienCungCT = null;
                    thanhtoan.MaKhuVuc = null;
                    //
                    mucHuong = 0;
                    thanhtoan.TyLe = 0;
                }
                thanhtoan.MaBenh = maBenh;
                thanhtoan.TenBenh = txtTenBenh.Text;
                
                thanhtoan.NgayRa = dateNgayRa.DateTime;
                thanhtoan.NgayVao = dateNgayVao.DateTime;
                thanhtoan.SoNgayDieuTri = Utils.ToInt(txtSoNgayDTri.Text);
                thanhtoan.KetQuaDieuTri = cbKQDieuTri.SelectedIndex + 1;
                thanhtoan.TinhTrangRaVien = cbTTRaVien.SelectedIndex + 1;
                thanhtoan.NgayThanhToan = dateNgayTToan.DateTime;
                thanhtoan.MucHuong = mucHuong;
                thanhtoan.TienThuoc = tienthuoc;
                thanhtoan.TienVTYT = tienvattu;
                thanhtoan.TongChi = tienvattu + tienthuoc + tiendichvu;
                thanhtoan.TienBNTT = tienbntt;
                thanhtoan.TienBNCCT = (thanhtoan.TongChi-tienbntt) * (1m - (mucHuong / 100m));
                thanhtoan.TienBHTT = (thanhtoan.TongChi - tienbntt) * (mucHuong / 100m);
                thanhtoan.TienNguonKhac = 0;
                thanhtoan.TienNgoaiDS = 0;
                thanhtoan.NamQT = dateNgayTToan.DateTime.ToString("yyyy");
                thanhtoan.ThangQT = dateNgayTToan.DateTime.ToString("MM");
                thanhtoan.CanNang = Utils.ToFloat(txtCanNang.Text);
                // cập nhật thông tin
                if (!thanhtoan.SpThanhToan(ref err, "Update_TT"))
                {
                    XtraMessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // cập nhật thuốc
                foreach(DataRow dr in dataThuoc.Rows)
                {
                    err = null;
                    thanhtoan.SoPhieu = Utils.ToInt(dr["SoPhieu"]);
                    thanhtoan.SoPhieuNhap = Utils.ToInt(dr["SoPhieuNhap"]);
                    thanhtoan.MaVatTu = dr["MaVatTu"].ToString();
                    thanhtoan.TongChi = Utils.ToDecimal(dr["ThanhTien"]);
                    if (mucHuong != 0 && Utils.ToInt(dr["TyLe"], 100) == 0)
                    {
                        thanhtoan.TyLe = 0;
                        thanhtoan.TienBNTT = thanhtoan.TongChi;
                        thanhtoan.TienBNCCT = 0;// thanhtoan.TongChi * (1m - (mucHuong / 100m));
                        thanhtoan.TienBHTT = 0;// thanhtoan.TongChi * (mucHuong / 100m);
                    }
                    else
                    {
                        thanhtoan.TyLe = 100;
                        thanhtoan.TienBNTT = 0;
                        thanhtoan.TienBNCCT = thanhtoan.TongChi * (1m - (mucHuong / 100m));
                        thanhtoan.TienBHTT = thanhtoan.TongChi * (mucHuong / 100m);
                    }
                    thanhtoan.TienNguonKhac = 0;
                    thanhtoan.TienNgoaiDS = 0;
                    if (!thanhtoan.SpThanhToan(ref err, "Update_TH"))
                    {
                        XtraMessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // cập nhật vật tư
                foreach (DataRow dr in dataVTYT.Rows)
                {
                    err = null;
                    thanhtoan.SoPhieu = Utils.ToInt(dr["SoPhieu"]);
                    thanhtoan.SoPhieuNhap = Utils.ToInt(dr["SoPhieuNhap"]);
                    thanhtoan.MaVatTu = dr["MaVatTu"].ToString();
                    thanhtoan.TongChi = Utils.ToDecimal(dr["ThanhTien"]);
                    if (mucHuong != 0 && Utils.ToInt(dr["TyLe"], 100) == 0)
                    {
                        thanhtoan.TyLe = 0;
                        thanhtoan.TienBNTT = thanhtoan.TongChi;
                        thanhtoan.TienBNCCT = 0;// thanhtoan.TongChi * (1m - (mucHuong / 100m));
                        thanhtoan.TienBHTT = 0;// thanhtoan.TongChi * (mucHuong / 100m);
                    }
                    else
                    {
                        thanhtoan.TyLe = 100;
                        thanhtoan.TienBNTT = 0;
                        thanhtoan.TienBNCCT = thanhtoan.TongChi * (1m - (mucHuong / 100m));
                        thanhtoan.TienBHTT = thanhtoan.TongChi * (mucHuong / 100m);
                    }
                    thanhtoan.TienNguonKhac = 0;
                    thanhtoan.TienNgoaiDS = 0;
                    if (!thanhtoan.SpThanhToan(ref err, "Update_VT"))
                    {
                        XtraMessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (checkCoThe.Checked)
                {
                    thanhtoan.TyLe = 100;
                }
                else
                {
                    thanhtoan.TyLe = 0;
                }
                // cập nhật dịch vụ
                foreach (DataRow dr in dataDichVu.Rows)
                {
                    err = null;
                    thanhtoan.MaVatTu = dr["MaDichVu"].ToString();
                    thanhtoan.TongChi = Utils.ToDecimal(dr["ThanhTien"]);
                    if (mucHuong != 0 && Utils.ToInt(dr["TyLe"], 100) == 0)
                    {
                        thanhtoan.TienBNTT = thanhtoan.TongChi;
                        thanhtoan.TienBNCCT = 0;// thanhtoan.TongChi * (1m - (mucHuong / 100m));
                        thanhtoan.TienBHTT = 0;// thanhtoan.TongChi * (mucHuong / 100m);
                    }
                    else
                    {
                        thanhtoan.TienBNTT = 0;
                        thanhtoan.TienBNCCT = thanhtoan.TongChi * (1m - (mucHuong / 100m));
                        thanhtoan.TienBHTT = thanhtoan.TongChi * (mucHuong / 100m);
                    }
                    thanhtoan.TienNguonKhac = 0;
                    thanhtoan.TienNgoaiDS = 0;
                    if (!thanhtoan.SpThanhToan(ref err, "Update_DV"))
                    {
                        XtraMessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }// công khám
                foreach (DataRow dr in dataCongKham.Rows)
                {
                    err = null;
                    thanhtoan.MaVatTu = dr["MaDichVu"].ToString();
                    thanhtoan.TongChi = Utils.ToDecimal(dr["ThanhTien"]);
                    thanhtoan.TienBNTT = 0;
                    thanhtoan.TienBNCCT = thanhtoan.TongChi * (1m - (mucHuong / 100m));
                    thanhtoan.TienBHTT = thanhtoan.TongChi * (mucHuong / 100m);
                    thanhtoan.TienNguonKhac = 0;
                    thanhtoan.TienNgoaiDS = 0;
                    if (!thanhtoan.SpThanhToan(ref err, "Update_DV"))
                    {
                        XtraMessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (inHoSo)
                    InHoSo(xemHoSo);
            }

        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if(dataLoc!=null && dataLoc.Rows.Count>0)
            {
                index = 0;
                LoadThongTin(index);
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dataLoc != null && dataLoc.Rows.Count > 0)
            {
                index = dataLoc.Rows.Count - 1;
                LoadThongTin(index);
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (dataLoc != null && dataLoc.Rows.Count > 0)
            {
                if (index > 0)
                {
                    if (index > dataLoc.Rows.Count - 1)
                        index = dataLoc.Rows.Count - 1;
                    else
                        index--;
                    LoadThongTin(index);
                }
            }
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (dataLoc != null && dataLoc.Rows.Count > 0)
            {
                if(index< dataLoc.Rows.Count-1)
                {
                    index++;
                    LoadThongTin(index);
                }
            }
        }

        private void btnLuuIn_Click(object sender, EventArgs e)
        {
            LuuHoSo(true,true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //
            DialogResult traloi;
            string err = "";
            // Hiện hộp thoại hỏi đáp 
            traloi = XtraMessageBox.Show("Chắc chắn bạn muốn xóa hồ sơ này?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if (!thanhtoan.XoaHoSo(ref err))
                {
                    MessageBox.Show(err);
                    return;
                }
                thanhtoan.MaLK = null;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            LuuHoSo(true);
        }

        private void cbLoaiKCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cbLoaiKCB.SelectedIndex==0)
            //{
            //    btnCongKham.Enabled = true;
            //    btnNgayGiuong.Enabled = false;
            //}
            //else
            //{
            //    btnCongKham.Enabled = false;
            //    btnNgayGiuong.Enabled = true;
            //}
        }

        private void btnNgayGiuong_Click(object sender, EventArgs e)
        {
            if (KiemTraBenhBacSi())
            {
                FrmGiuongBenh frm = new FrmGiuongBenh();
                frm.MaLK = thanhtoan.MaLK;
                frm.MaKhoa = Utils.ToString(lookUpKhoa.EditValue);
                frm.MaBacSi = Utils.ToString(lookUpBacSi.EditValue);
                frm.ShowDialog();
                dataDichVu = thanhtoan.DSDichVuChiTiet();
                LoadCongKham();
            }
        }

        private void btnDVKyThuat_Click(object sender, EventArgs e)
        {
            if (KiemTraBenhBacSi())
            {
                FrmDichVuChiTiet frm = new FrmDichVuChiTiet();
                frm.MaLK = thanhtoan.MaLK;
                frm.MaKhoa = lookUpKhoa.EditValue.ToString();
                frm.MaBacSi = lookUpBacSi.EditValue.ToString();
                frm.ShowDialog();
                dataDichVu = thanhtoan.DSDichVuChiTiet();
                //dataThuoc = thanhtoan.DSThuocChiTiet();
                //dataVTYT = thanhtoan.DSVTYTChiTiet();
                LoadCongKham();
            }
        }

        private void btnVatTuYTe_Click(object sender, EventArgs e)
        {
            if (KiemTraBenhBacSi())
            {
                FrmVatTuChiTiet frm = new FrmVatTuChiTiet();
                frm.MaLK = thanhtoan.MaLK;
                frm.MaKhoa = lookUpKhoa.EditValue.ToString();
                frm.MaBacSi = lookUpBacSi.EditValue.ToString();
                frm.ShowDialog();
                //dataDichVu = thanhtoan.DSDichVuChiTiet();
                //dataThuoc = thanhtoan.DSThuocChiTiet();
                dataVTYT = thanhtoan.DSVTYTChiTiet();
                LoadCongKham();
            }
        }

        private void TaoFileXML()
        {
            try
            {
                DanhSachHoSo danhSachHoSo = new DanhSachHoSo();
                //
                //dataDichVu = thanhtoan.DSDichVuChiTiet();
                //dataThuoc = thanhtoan.DSThuocChiTiet();
                //dataVTYT = thanhtoan.DSVTYTChiTiet();
                DataTable dataXML3 = thanhtoan.DSDichVu(thanhtoan.MaLK);
                foreach (DataRow dtrow in thanhtoan.DSVatTu(thanhtoan.MaLK).Rows)
                {
                    dataXML3.Rows.Add(dtrow.ItemArray);
                }
                //
                XmlDocument XML1 = ConvertXML.XML1_4210(thanhtoan.ThongTinBN(thanhtoan.MaLK).Rows[0]);// xem lại cd kết quả điều trị
                XmlDocument XML2 = ConvertXML.XML2_4210(thanhtoan.DSThuoc(thanhtoan.MaLK), maBenh);
                XmlDocument XML4 = ConvertXML.XML4_4210(thanhtoan.DSHoSoCanLamSan(thanhtoan.MaLK));
                XmlDocument XML3 = ConvertXML.XML3_4210(dataXML3, maBenh);
                //
                HoSo hoSo = new HoSo();
                hoSo.Add(new FileHoSo { LoaiHoSo = "XML1", NoiDungFile = Convert.ToBase64String(Utils.XmlToByte(XML1)) });
                if (XML2 != null)
                    hoSo.Add(new FileHoSo { LoaiHoSo = "XML2", NoiDungFile = Convert.ToBase64String(Utils.XmlToByte(XML2)) });
                if (XML3 != null)
                    hoSo.Add(new FileHoSo { LoaiHoSo = "XML3", NoiDungFile = Convert.ToBase64String(Utils.XmlToByte(XML3)) });
                if (XML4 != null)
                    hoSo.Add(new FileHoSo { LoaiHoSo = "XML4", NoiDungFile = Convert.ToBase64String(Utils.XmlToByte(XML4)) });
                danhSachHoSo.Add(hoSo);
                string filePath = "D:\\BHYT\\BYT_4210\\";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                XmlDocument giamDinhHoSo = ConvertXML.GIAMDINH(danhSachHoSo,dateDenNgay.DateTime);
                string name = txtTheBHYT.Text+"_"+ DateTime.Now.ToString("yyyyMMdd_HHmmss");
                giamDinhHoSo.Save(filePath + "FileHS_" + name + ".xml");
            }
            catch
            { }
        }
        private void InHoSo(bool view = false)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            TaoFileXML();
            rptChiPhi rpt = new rptChiPhi();
            rpt.DataSource = null;
            string mau  = "Mau01";
            if (cbLoaiKCB.SelectedIndex > 0)
            {
                rpt.xrLabelDeMuc.Text = "BẢNG KÊ CHI PHÍ KHÁM, CHỮA BỆNH NỘI TRÚ";
                rpt.xrLabelMauSo.Text = "Mẫu số 02/BV";
                mau = "Mau02";
            }
            else
            {
                rpt.xrLabelDeMuc.Text = "BẢNG KÊ CHI PHÍ KHÁM BỆNH, CHỮA BỆNH NGOẠI TRÚ";
                rpt.xrLabelMauSo.Text = "Mẫu số 01/BV";
                mau = "Mau01";
            }
            if (lookUpKhoa.EditValue.ToString().Split('_')[0] == "K01")
            {
                rpt.xrLabelKhoa.Text = "Khoa Khám bệnh";
            }
            else
                rpt.xrLabelKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
            rpt.xrLabelMaSoBN.Text = txtMaBN.Text;
            rpt.xrLabelSoBenhAn.Text = txtSTTNgay.Text;
            rpt.xrLabelHoTen.Text = txtHoTen.Text;
            rpt.xrLabelDiaChi.Text = txtDiaChi.Text;
            rpt.xrLabelNgaySinh.Text = txtNgaySinh.Text;
            rpt.xrLabelMaKCBBanDau.Text = txtMaCoSoDKKCB.Text;
            rpt.xrLabelKCBBanDau.Text = txtTenCoSoDKKCB.Text;
            //rpt.lblCosoKCB.Text = (lookUpNoiChuyenDen.Properties.GetDisplayValueByKeyValue(AppConfig.CoSoKCB)).ToString().ToUpper();
            if (cbGioiTinh.SelectedIndex == 0)
            {
                rpt.xrCheckBoxNu.Checked = false;
            }
            else
            {
                rpt.xrCheckBoxNu.Checked = true;
            }
            rpt.xrCheckBoxNam.Checked = !rpt.xrCheckBoxNu.Checked;
            rpt.xrCheckBoxCBHYT.Checked = checkCoThe.Checked;
            rpt.xrCheckBoxKBHYT.Checked = !rpt.xrCheckBoxCBHYT.Checked;
            if (rpt.xrCheckBoxCBHYT.Checked)
            {
                rpt.xrTableBHYT.Rows[0].Cells[0].Text = txtTheBHYT.Text.Substring(0, 2);
                rpt.xrTableBHYT.Rows[0].Cells[1].Text = txtTheBHYT.Text.Substring(2, 1);
                rpt.xrTableBHYT.Rows[0].Cells[2].Text = txtTheBHYT.Text.Substring(3, 2);
                rpt.xrTableBHYT.Rows[0].Cells[3].Text = txtTheBHYT.Text.Substring(5, 2);
                rpt.xrTableBHYT.Rows[0].Cells[4].Text = txtTheBHYT.Text.Substring(7, 3);
                rpt.xrTableBHYT.Rows[0].Cells[5].Text = txtTheBHYT.Text.Substring(10, 5);
                rpt.xrLabelGTTu.Text = txtTheTu.Text;
                rpt.xrLabelGTDen.Text = txtTheDen.Text;
            }
            else
            {
                rpt.xrTableBHYT.Rows[0].Cells[0].Text = "";
                rpt.xrTableBHYT.Rows[0].Cells[1].Text = "";
                rpt.xrTableBHYT.Rows[0].Cells[2].Text = "";
                rpt.xrTableBHYT.Rows[0].Cells[3].Text = "";
                rpt.xrTableBHYT.Rows[0].Cells[4].Text = "";
                rpt.xrTableBHYT.Rows[0].Cells[5].Text = "";
                rpt.xrLabelGTTu.Text = "";
                rpt.xrLabelGTDen.Text = "";
            }
            rpt.xrLabelDenKham.Text = dateNgayVao.Text;
            rpt.xrLabelDi.Text = dateNgayRa.Text;
            if (cbLyDoVVien.SelectedIndex == 0)
            {
                rpt.xrCheckBoxDungTuyen.Checked = true;
                rpt.xrCheckBoxCapCuu.Checked = false;
                rpt.xrCheckBoxTraiTuyen.Checked = false;
            }
            if (cbLyDoVVien.SelectedIndex == 1)
            {
                rpt.xrCheckBoxDungTuyen.Checked = false;
                rpt.xrCheckBoxCapCuu.Checked = true;
                rpt.xrCheckBoxTraiTuyen.Checked = false;
            }
            if (cbLyDoVVien.SelectedIndex == 2)
            {
                rpt.xrCheckBoxDungTuyen.Checked = false;
                rpt.xrCheckBoxCapCuu.Checked = false;
                rpt.xrCheckBoxTraiTuyen.Checked = true;
                rpt.xrLabelNoiChuyenDen.Text = lookUpNoiChuyenDen.EditValue.ToString();
            }
            else
            {
                rpt.xrLabelNoiChuyenDen.Text = "";
            }
            rpt.xrLabelSoNgay.Text = txtSoNgayDTri.Text;
            rpt.xrLabelTenBenh.Text = txtTenBenh.Text;
            rpt.xrLabelMaBenh.Text = string.IsNullOrEmpty(maBenhKhac) ? maBenh : maBenh + ";" + maBenhKhac;
            try
            {
                rpt.xrLabelNgayLapHD1.Text = "Ngày " + dateNgayTToan.DateTime.Day + " tháng " + dateNgayTToan.DateTime.Month
                    + " năm " + dateNgayTToan.DateTime.Year;
                //20170512  "Ngày " +DateTime.Now.Day + " tháng "+DateTime.Now.Month + " năm "+DateTime.Now.Year;
            }
            catch
            {
                rpt.xrLabelNgayLapHD1.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            }
            rpt.xrLabelNgayLapHD2.Text = rpt.xrLabelNgayLapHD1.Text;
            // chèn dữ liệu
            //DataRow[] dataRow = dataChiTiet.Select("", "Mau01,Mau02 ASC");
            DataTable dataTable = dataChiTiet.AsEnumerable()
                .GroupBy(r => new { col1 = r["MaDichVu"],
                    col2 = r["TenDichVu"],
                    col3 = r["DonViTinh"],
                    col4 = r["DonGia"],
                    col5 = r["TenNhom"],
                    col6 = r["Mau01"],
                    col7 = r["Mau02"],
                    col8 = r["TyLe"]
                })
                .Select(g =>
                {
                    DataRow dtrow = dataChiTiet.NewRow();
                    dtrow["MaDichVu"] = g.Key.col1;
                    dtrow["TenDichVu"] = g.Key.col2;
                    dtrow["DonViTinh"] = g.Key.col3;
                    dtrow["SoLuong"] = g.Sum(r => r.Field<int>("SoLuong"));
                    dtrow["DonGia"] = g.Key.col4;
                    dtrow["ThanhTien"] = g.Sum(r => r.Field<decimal>("ThanhTien"));
                    dtrow["TenNhom"] = g.Key.col5;
                    dtrow["Mau01"] = g.Key.col6;
                    dtrow["Mau02"] = g.Key.col7;
                    dtrow["TyLe"] = g.Key.col8;
                    return dtrow;
                }).CopyToDataTable();
            DataRow[] dataRow = dataTable.Select("", "Mau01,Mau02 ASC");
            string tennhom = null;
            XRTableRow row = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            decimal tongTien = 0, tienBNTT = 0, tienBHTT = 0, tienNgoaiBH = 0;
            for (int i=0;i<dataRow.Length;i++)
            {
                if(tennhom != dataRow[i]["TenNhom"].ToString())
                {
                    if(!string.IsNullOrEmpty(tennhom))
                    {
                        row = new XRTableRow();
                        cell = new XRTableCell();
                        cell.Text = "Cộng "+Utils.ToInt( dataRow[i-1][mau]);
                        cell.Font = font;
                        cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                        cell.WidthF = 360;
                        row.Cells.Add(cell);

                        cell = new XRTableCell();
                        cell.Text = Utils.ToString(tongTien);
                        cell.Font = fontB;
                        cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                        cell.WidthF = 100;
                        row.Cells.Add(cell);

                        cell = new XRTableCell();
                        cell.Text = Utils.ToString(tienBHTT);
                        cell.Font = fontB;
                        cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                        cell.WidthF = 100;
                        row.Cells.Add(cell);

                        cell = new XRTableCell();
                        cell.Text = "00";
                        cell.Font = fontB;
                        cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                        cell.WidthF = 90;
                        row.Cells.Add(cell);

                        cell = new XRTableCell();
                        cell.Text = Utils.ToString(tienBNTT+tienNgoaiBH);
                        cell.Font = fontB;
                        cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                        cell.WidthF = 99;
                        row.Cells.Add(cell);

                        rpt.xrTableChiPhi.Rows.Add(row);
                    }
                    // tạo tên nhóm
                    tennhom = dataRow[i]["TenNhom"].ToString();
                    tongTien = 0;
                    tienBHTT = 0;
                    tienBNTT = 0;
                    tienNgoaiBH = 0;
                    //
                    row = new XRTableRow();
                    cell = new XRTableCell();
                    cell.Text = dataRow[i][mau] + ". " + tennhom;
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                    cell.Font = fontB;
                    cell.WidthF = 749;
                    row.Cells.Add(cell);
                    rpt.xrTableChiPhi.Rows.Add(row);
                }
                // dữ liệu
                row = new XRTableRow();

                cell = new XRTableCell();
                cell.Text = dataRow[i]["TenDichVu"].ToString();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 170;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = dataRow[i]["DonViTinh"].ToString();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 50;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = dataRow[i]["SoLuong"].ToString();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 60;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = Utils.ToString(Utils.ToDecimal(dataRow[i]["DonGia"]));
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 80;
                row.Cells.Add(cell);

                decimal t = Utils.ToDecimal(dataRow[i]["ThanhTien"]);
                tongTien += t;
                cell = new XRTableCell();
                cell.Text = Utils.ToString(t);
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 100;
                row.Cells.Add(cell);
                if (Utils.ToInt(dataRow[i]["TyLe"], 100) == 0)
                {
                    t = Utils.ToDecimal(dataRow[i]["ThanhTien"]);
                    tienNgoaiBH += t;
                    t = 0;
                }
                else
                {
                    t = Utils.ToDecimal(dataRow[i]["ThanhTien"]) * (mucHuong / 100m);
                    tienBHTT += t;
                }
                cell = new XRTableCell();
                cell.Text = Utils.ToString(t);
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 100;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = "00";
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 90;
                row.Cells.Add(cell);
                if (Utils.ToInt(dataRow[i]["TyLe"], 100) == 0)
                {
                    t = Utils.ToDecimal(dataRow[i]["ThanhTien"]);
                }
                else
                {
                    t = Utils.ToDecimal(dataRow[i]["ThanhTien"]) * (1m - (mucHuong / 100m));
                    tienBNTT += t;
                }
                cell = new XRTableCell();
                cell.Text = Utils.ToString(t);
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 99;
                row.Cells.Add(cell);

                rpt.xrTableChiPhi.Rows.Add(row);
            }
            if(dataRow.Length>0)
            {
                row = new XRTableRow();
                cell = new XRTableCell();
                cell.Text = "Cộng " + Utils.ToInt(dataRow[dataRow.Length - 1][mau]);
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.WidthF = 360;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = Utils.ToString(tongTien);
                cell.Font = fontB;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 100;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = Utils.ToString(tienBHTT);
                cell.Font = fontB;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 100;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = "00";
                cell.Font = fontB;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 90;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = Utils.ToString(tienBNTT+tienNgoaiBH);
                cell.Font = fontB;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 99;
                row.Cells.Add(cell);

                rpt.xrTableChiPhi.Rows.Add(row);
            }
            //
            tongTien = tiendichvu + tienthuoc + tienvattu;
            tienBHTT = (tiendichvu + tienthuoc + tienvattu - tienbntt) * (mucHuong / 100m);
            tienBNTT = (tiendichvu + tienthuoc + tienvattu - tienbntt) * (1m - (mucHuong / 100m))+tienbntt;
            row = new XRTableRow();
            cell = new XRTableCell();
            cell.Text = "Tổng Cộng";
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.WidthF = 360;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text =Utils.ToString (tongTien);
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.WidthF = 100;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = Utils.ToString(tienBHTT);
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.WidthF = 100;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = "00";
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.WidthF = 90;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = Utils.ToString(tongTien - tienBHTT);
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.WidthF = 99;
            row.Cells.Add(cell);

            rpt.xrTableChiPhi.Rows.Add(row);

            rpt.xrLabelChuTongTien.Text = Utils.ChuyenSo(String.Format("{0:0}", tongTien));
            rpt.xrLabelChuBHTT.Text = Utils.ChuyenSo(String.Format("{0:0}", tienBHTT));
            rpt.xrLabelChuBNTT.Text = Utils.ChuyenSo(String.Format("{0:0}", tongTien - tienBHTT));
            //
            rpt.CreateDocument();
            if (view)
            {
                rpt.ShowPreviewDialog();
            }
            else
            {
                rpt.PrintDialog();
            }
            SplashScreenManager.CloseForm();
        }
        private bool KiemTraBenhBacSi()
        {
            if (string.IsNullOrEmpty(maBenh))
            {
                XtraMessageBox.Show("Chưa chọn bệnh chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpMaBenh.Focus();
                return false;
            }
            if (lookUpBacSi.ItemIndex < 0)
            {
                XtraMessageBox.Show("Chưa chọn bác sĩ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpBacSi.Focus();
                return false;
            }
            return true;
        }

        private void lookUpMaBenh_EditValueChanged(object sender, EventArgs e)
        {
            object dr = lookUpMaBenh.GetSelectedDataRow();
            if (dr is DataRowView)
            {
                maBenh = (dr as DataRowView)[0].ToString();
                txtTenBenh.Text = (dr as DataRowView)[1].ToString();
            }
        }

        private void checkChuyenT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkChuyenT.Checked)
            {
                var data = dataDanhSach.Select(Library.SqlChuyenTuyen);
                if (data.Length > 0)
                    dataLoc = data.CopyToDataTable();
                else
                    dataLoc = null;
                gridControl.DataSource = dataLoc;
            }
        }

        private void checkRaVien_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRaVien.Checked)
            {
                var data = dataDanhSach.Select(Library.SqlYCRaVien);
                if (data.Length > 0)
                    dataLoc = data.CopyToDataTable();
                else
                    dataLoc = null;
                gridControl.DataSource = dataLoc;
            }
        }

        private async void btnKtraTT_ClickAsync(object sender, EventArgs e)
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
                    if (txtMaCoSoDKKCB.Text != thongtin.MaCoSoDKKCB)
                    {
                        txtMaCoSoDKKCB.Text = thongtin.MaCoSoDKKCB;
                        object ten = lookUpNoiChuyenDen.Properties.GetDisplayValueByKeyValue(thongtin.MaCoSoDKKCB);
                        if (ten != null)
                            txtTenCoSoDKKCB.Text = ten.ToString();
                        else
                            txtTenCoSoDKKCB.Text = null;
                    }
                    txtTheTu.Text = thongtin.TheTu;
                    txtTheDen.Text = thongtin.TheDen;
                    txtDu5Nam.Text = thongtin.Du5Nam;
                    btnCongKham.Focus();
                    break;
                default:
                    XtraMessageBox.Show(thongtin.ThongBao.Replace(":", ""), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void checkCoThe_CheckedChanged(object sender, EventArgs e)
        {
            if(!checkCoThe.Checked)
            {
                txtTheBHYT.ReadOnly = true;
                txtTheDen.ReadOnly = true;
                txtTheTu.ReadOnly = true;
                txtDu5Nam.ReadOnly = true;
                txtMucHuong.ReadOnly = true;
                cbKhuVuc.ReadOnly = true;
                txtMaCoSoDKKCB.ReadOnly = true;
                txtTenCoSoDKKCB.ReadOnly = true;
                //
                txtTheBHYT.Text = null;
                txtTheDen.Text = null;
                txtTheTu.Text = null;
                txtDu5Nam.Text = null;
                txtMucHuong.Text = null;
                cbKhuVuc.Text = null;
                txtMaCoSoDKKCB.Text = null;
                txtTenCoSoDKKCB.Text = null;
                mucHuong = 0;// mức hưởng = 0;
            }
            else
            {
                txtTheBHYT.ReadOnly = false;
                txtTheDen.ReadOnly = false;
                txtTheTu.ReadOnly = false;
                txtDu5Nam.ReadOnly = false;
                txtMucHuong.ReadOnly = false;
                cbKhuVuc.ReadOnly = false;
                txtMaCoSoDKKCB.ReadOnly = false;
                txtTenCoSoDKKCB.ReadOnly = false;
                
            }
        }

        private void txtTheBHYT_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTheBHYT.Text.Length == 15)
            {
                if (CheckMaThe(txtTheBHYT.Text) == false)
                {
                    txtTheBHYT.Focus();
                }
            }
        }
        private bool CheckMaThe(string maThe)
        {

            DataRow[] dr = null;
            dr = dataMucHuong.Select("Ma = '" + maThe.Substring(0, 3) + "'", "");
            if (dr != null && dr.Length > 0)
            {
                txtMucHuong.Text = dr[0]["TyLe"].ToString();
                //txtMucHuong.Text = dr[0]["MaHieu"].ToString();
            }
            else
            {
                XtraMessageBox.Show(Library.BaKyTuDau, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            dr = null;
            dr = dataTinh.Select("Ma = '" + maThe.Substring(3, 2) + "'", "");
            if (dr == null || dr.Length == 0)
            {
                XtraMessageBox.Show(Library.HaiKyTuTinh, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void checkDaTT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDaTT.Checked)
            {
                var data = dataDanhSach.Select(Library.SqlDaThanhToan);
                if (data.Length > 0)
                    dataLoc = data.CopyToDataTable();
                else
                    dataLoc = null;
                gridControl.DataSource = dataLoc;
            }
        }
        private bool KiemTraThongTinTiepNhan(bool ktraChiTiet = false)
        {
            if (string.IsNullOrEmpty(txtTheBHYT.Text) && checkCoThe.Checked)
            {
                XtraMessageBox.Show(Library.NhapMaThe, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTheBHYT.Focus();
                return false;
            }
            if (ktraChiTiet && checkCoThe.Checked)
            {
                if (string.IsNullOrEmpty(txtTheTu.Text))
                {
                    XtraMessageBox.Show(Library.NhapTheTu, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheTu.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtTheDen.Text))
                {
                    XtraMessageBox.Show(Library.NhapTheDen, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheDen.Focus();
                    return false;
                }
                DateTime theTu = Utils.ToDateTime(txtTheTu.Text, "dd/MM/yyyy");
                DateTime theDen = Utils.ToDateTime(txtTheDen.Text, "dd/MM/yyyy");
                if (theTu > DateTime.Now)
                {
                    XtraMessageBox.Show(Library.TheTuLonHonHienTai, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheTu.Focus();
                    return false;
                }
                if (theTu > theDen)
                {
                    XtraMessageBox.Show(Library.TheTuLonHonTheDen, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheDen.Focus();
                    return false;
                }
                if (theDen <= DateTime.Now)
                {
                    XtraMessageBox.Show(Library.TheHetHan, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTheDen.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMaCoSoDKKCB.Text))
                {
                    XtraMessageBox.Show(Library.NhapKCBBD, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaCoSoDKKCB.Focus();
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
