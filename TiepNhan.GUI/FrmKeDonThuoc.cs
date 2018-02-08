using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
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
    public partial class FrmKeDonThuoc : RibbonForm
    {
        public string MaLK { get; set; }
        public string HoTen { get; set; }
        public string TheDen { get; set; }
        public string TheTu { get; set; }
        public string MaThe { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string TenCoSo { get; set; }
        public string NoiDangKy { get; set; }
        public string STTNgay { get; set; }

        private KeDonEntity kedon;
        private string maBenhChinh = null;
        DataTable dtBenh;
        Dictionary<string, int> listThuoc;// 0. xóa, 1. đã có, 2. thêm mới
        Dictionary<string, int> listVatTu;
        Dictionary<string, string> dicDuongDung = new Dictionary<string, string>();
        DataView dvThuoc,dvVatTu;
        DataTable thuocNgoaiDM;
        public FrmKeDonThuoc()
        {
            InitializeComponent();
            kedon = new KeDonEntity();
            lookUpBacSi.Properties.DataSource = kedon.DSBacSi();
            lookUpBacSi.Properties.DisplayMember = "Ten_NV";
            lookUpBacSi.Properties.ValueMember = "Ma_BS";
            lookUpMaKhoa.Properties.DataSource = kedon.DSKhoaBan(1);
            lookUpMaKhoa.Properties.ValueMember = "MaKhoa";
            lookUpMaKhoa.Properties.DisplayMember = "TenKhoa";
            dtBenh = kedon.DSBenh();
            lookUpMaBenh.Properties.DataSource = dtBenh;
            lookUpMaBenh.Properties.DisplayMember = "MaBenh";
            lookUpMaBenhKhac.Properties.DisplayMember = "MaBenh";
            lookUpMaBenhKhac.Properties.DataSource = dtBenh;
            lookUpVatTu.Properties.DisplayMember = "TenVatTu";
            dicDuongDung = kedon.DSDuongDung().AsEnumerable().ToDictionary<DataRow, string, string>
                (row => row.Field<string>(0), row => row.Field<string>(1));
        }

        private void FrmKeDonThuoc_Load(object sender, EventArgs e)
        {
            cbLoaiChiPhi.SelectedIndex = -1;
            maBenhChinh = null;
            txtMaBenhKhac.Text = null;
            txtTenBenh.Text = null;
            lookUpMaKhoa.ItemIndex = 0;
            this.ActiveControl = lookUpMaBenh;
            //if(lookUpBacSi.ItemIndex <0)
            //{
            //    lookUpBacSi.ItemIndex = 0;
            //}
            txtHoTen.Text = this.HoTen;
            lblHanThe.Text = "Hạn thẻ BHYT còn: " + (Utils.ToDateTime(this.TheDen) - DateTime.Now).Days + " ngày";
            dateYLenh.DateTime = DateTime.Now;
            cbLoaiChiPhi.SelectedIndex = 0;
            listThuoc = new Dictionary<string, int>();
            listVatTu = new Dictionary<string, int>();
            if(!string.IsNullOrEmpty(MaLK))
            {
                kedon.MaLK = MaLK;
                if(kedon.LayThongTinMaBenh() && !string.IsNullOrEmpty(kedon.MaBenh))
                {
                    maBenhChinh = this.kedon.MaBenh;
                    txtMaBenhKhac.Text = this.kedon.MaBenhKhac;
                    txtTenBenh.Text = this.kedon.TenBenh;
                }
                // lấy danh sách thuốc
                dvThuoc = kedon.DSThuoc().AsDataView();
                gridControlThuoc.DataSource = dvThuoc;
                foreach(DataRowView drv in dvThuoc)
                {
                    listThuoc.Add(drv["MaVatTu"].ToString(), 1);
                }
                // lấy danh sách vật tư
                dvVatTu = kedon.DSVatTu().AsDataView();
                gridControlVTYT.DataSource = dvVatTu;
                foreach (DataRowView drv in dvVatTu)
                {
                    listVatTu.Add(drv["MaVatTu"].ToString(), 1);
                }
                // dịch vụ kỹ thuật
                gridControlDVKT.DataSource = kedon.DSDichVuKyThuat();
            }
            thuocNgoaiDM = kedon.DSKeDonNgoaiDM();
        }

        private void txtSoLuong_Enter(object sender, EventArgs e)
        {
            txtSoLuong.Select(0,txtSoLuong.Value.ToString().Length);
        }

        private void txtNgayUong_Enter(object sender, EventArgs e)
        {
            txtNgayUong.Select(0, txtNgayUong.Value.ToString().Length);
        }

        private void txtLanUong_Enter(object sender, EventArgs e)
        {
            txtLanUong.Select(0, txtLanUong.Value.ToString().Length);
        }

        private void txtSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if(txtSoLuong.Value > 150)
            {
                XtraMessageBox.Show("Số lượng chọn "+txtSoLuong.Value,"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lookUpMaBenh_EditValueChanged(object sender, EventArgs e)
        {
            object dr = lookUpMaBenh.GetSelectedDataRow();
            if(dr is DataRowView)
            {
                txtMaBenhKhac.Text = null;
                maBenhChinh = (dr as DataRowView)[0].ToString();
                txtTenBenh.Text = (dr as DataRowView)[1].ToString();
            }
            else
            {
                txtMaBenhKhac.Text = null;
                txtTenBenh.Text = null;
                maBenhChinh = null;
            }
        }

        private void lookUpMaBenhKhac_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(maBenhChinh))
            {
                object dr = lookUpMaBenhKhac.GetSelectedDataRow();
                if (dr is DataRowView && txtMaBenhKhac.Text.Split(';').Length < 10)
                {
                    string maBenhKhac = (dr as DataRowView)[0].ToString();
                    if (maBenhKhac != maBenhChinh && !txtMaBenhKhac.Text.Contains(maBenhKhac))
                    {
                        txtMaBenhKhac.Text += maBenhKhac + "; ";
                        txtTenBenh.Text += "; " + (dr as DataRowView)[1].ToString();
                    }
                    else
                    {
                        XtraMessageBox.Show("Mã bệnh đã được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa chọn bệnh chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpMaBenh.Focus();
            }
        }

        private void txtMaBenhKhac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(maBenhChinh))
                {
                    List<string> list = new List<string>();
                    foreach(string item in txtMaBenhKhac.Text.Split(';'))
                    {
                        if(!string.IsNullOrEmpty(item.Trim())&&!item.Trim().Equals(maBenhChinh)
                            &&!list.Contains(item.Trim()))
                        {
                            list.Add(item.Trim());
                        }
                    }
                    txtMaBenhKhac.Text = "";
                    txtTenBenh.Text = dtBenh.Select("MaBenh = '"+maBenhChinh+"'","")[0][1].ToString();
                    foreach(string item in list)
                    {
                        txtMaBenhKhac.Text += item + "; ";
                        var dr = dtBenh.Select("MaBenh = '" + item + "'", "");
                        if (dr != null)
                            txtTenBenh.Text += "; " + dr[0][1].ToString();
                        
                    }
                    lookUpBacSi.Focus();
                }
                else
                {
                    lookUpMaBenh.Focus();
                }
            }
        }

        private void lookUpMaBenh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                lookUpMaBenhKhac.Focus();
        }

        private void lookUpMaBenhKhac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                lookUpBacSi.Focus();
        }

        private void lookUpBacSi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                lookUpVatTu.Focus();
        }

        private void lookUpVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoLuong.Focus();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNgayUong.Focus();
        }

        private void txtNgayUong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtLanUong.Focus();
        }

        private void txtLanUong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnChon.Focus();
        }

        private void cbLoaiChiPhi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gridViewVatTu.Columns.Clear();
            // dựa theo mã khoa để xác định kho lấy thuốc
            // Khoa khám bệnh, khoa nội, khoa ngoại,
            // vật tư nào có mã hoạt chất mới cho kê đơn
            kedon.KhoNhan = lookUpMaKhoa.EditValue.ToString();
            if (cbLoaiChiPhi.SelectedIndex == 0)
            {
                // thuốc
                this.gridViewVatTu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.MaVatTu,
                this.MaHoatChat,
                this.TenVatTu,
                this.HamLuong,
                this.DonViTinh,
                this.GiaBHYT,
                this.SoLuongTon});
                this.MaVatTu.VisibleIndex = 0;
                this.MaHoatChat.VisibleIndex = 1;
                this.TenVatTu.VisibleIndex = 2;
                this.HamLuong.VisibleIndex = 3;
                this.DonViTinh.VisibleIndex = 4;
                this.GiaBHYT.VisibleIndex = 5;
                this.SoLuongTon.VisibleIndex = 6;
                lookUpVatTu.Properties.DataSource =
                    kedon.DSKeDon( "1");
            }
            else if (cbLoaiChiPhi.SelectedIndex == 1)
            {
                // vật tư
                this.gridViewVatTu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.MaVatTu,
                this.MaHoatChat,
                this.TenVatTu,
                this.DonViTinh,
                this.GiaBHYT,
                this.SoLuongTon});
                this.MaVatTu.VisibleIndex = 0;
                this.MaHoatChat.VisibleIndex = 1;
                this.TenVatTu.VisibleIndex = 2;
                this.DonViTinh.VisibleIndex = 3;
                this.GiaBHYT.VisibleIndex = 4;
                this.SoLuongTon.VisibleIndex = 5;
                lookUpVatTu.Properties.DataSource =
                    kedon.DSKeDon("2");
            }
            else
            {
                // thuốc ngoài DM
                this.gridViewVatTu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.MaVatTu,
                this.TenVatTu,
                this.GiaBHYT,
                this.TyLeTT});
                this.MaVatTu.VisibleIndex = 0;
                this.TenVatTu.VisibleIndex = 1;
                this.GiaBHYT.VisibleIndex = 2;
                this.TyLeTT.VisibleIndex = 3;
                lookUpVatTu.Properties.DataSource = thuocNgoaiDM;
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            // kiểm tra nhập mã bệnh
            if(string.IsNullOrEmpty(maBenhChinh))
            {
                XtraMessageBox.Show("Chưa chọn bệnh chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpMaBenh.Focus();
                return;
            }
            if (lookUpVatTu.EditValue is DataRowView)
            {
                DataRowView dr = (lookUpVatTu.EditValue as DataRowView);
                if (cbLoaiChiPhi.SelectedIndex == 0 || cbLoaiChiPhi.SelectedIndex ==2)
                {
                    //kiểm tra số lượng tồn thuốc
                    if(listThuoc.ContainsKey(dr["MaVatTu"].ToString()))
                    {
                        XtraMessageBox.Show(Library.ThuocDaDuocChon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lookUpVatTu.Focus();
                        return;
                    }
                    if(cbLoaiChiPhi.SelectedIndex == 0 && txtSoLuong.Value > Utils.ToInt( dr["SoLuongTon"]))
                    {
                        XtraMessageBox.Show(Library.SoLuongThuocKhongDu, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoLuong.Focus();
                        return;
                    }
                    // 2: thuốc mới đc thêm vào, 1 thuốc đã có
                    listThuoc.Add(dr["MaVatTu"].ToString(), 2);
                    DataRowView drvNew = (gridControlThuoc.DataSource as DataView).AddNew();
                    drvNew["MaVatTu"] = dr["MaVatTu"];
                    drvNew["MaThuoc"] = dr["MaHoatChat"];
                    drvNew["TenThuoc"] = dr["TenVatTu"];
                    drvNew["HamLuong"] = dr["HamLuong"];
                    drvNew["DonViTinh"] = dr["DonViTinh"];
                    drvNew["SoLuong"] = txtSoLuong.Value;
                    drvNew["DonGia"] = dr["GiaBHYT"];
                    drvNew["ThanhTien"] = Utils.ToDecimal(dr["GiaBHYT"].ToString()) * txtSoLuong.Value;
                    drvNew["LieuDung"] = "Ngày "+dicDuongDung[dr["MaDuongDung"].ToString()].ToLower()
                        +" "+txtNgayUong.Value+ " lần, lần "+txtLanUong.Value+" "+ dr["DonViTinh"].ToString().ToLower();
                    drvNew["NgayYLenh"] = dateYLenh.DateTime;
                    drvNew["MaDuongDung"] = dr["MaDuongDung"];
                    drvNew["SoDK"] = dr["SoDK"];
                    //drvNew["TTinThau"] = dr["QuyetDinh"]+";"+dr["GoiThau"] + ";" + dr["NhomThau"];
                    if (cbLoaiChiPhi.SelectedIndex == 0)
                    {
                        drvNew["TTinThau"] = dr["QuyetDinh"] + ";" + dr["GoiThau"] + ";" + dr["NhomThau"];
                        drvNew["TyLe"] = 100;
                    }
                    else
                    {
                        drvNew["TTinThau"] = dr["TTinThau"];
                        drvNew["TyLe"] = dr["TyLeTT"];
                    }
                    drvNew.EndEdit();
                }
                else if (cbLoaiChiPhi.SelectedIndex == 1)
                {
                    //kiểm tra số lượng tồn vật tư
                    if(listVatTu.ContainsKey(dr["MaVatTu"].ToString()))
                    {
                        XtraMessageBox.Show(Library.VatTuDaDuocChon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lookUpVatTu.Focus();
                        return;
                    }
                    if (txtSoLuong.Value > Utils.ToInt(dr["SoLuongTon"]))
                    {
                        XtraMessageBox.Show(Library.VatTuKhongDuSoLuong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoLuong.Focus();
                        return;
                    }
                    listVatTu.Add(dr["MaVatTu"].ToString(), 2);
                    DataRowView drvNew = (gridControlVTYT.DataSource as DataView).AddNew();
                    drvNew["MaVatTu"] = dr["MaVatTu"];
                    drvNew["MaVT"] = dr["MaHoatChat"];
                    drvNew["TenVatTu"] = dr["TenVatTu"];
                    drvNew["DonViTinh"] = dr["DonViTinh"];
                    drvNew["SoLuong"] = txtSoLuong.Value;
                    drvNew["DonGia"] = dr["GiaBHYT"];
                    drvNew["ThanhTien"] = Utils.ToDecimal(dr["GiaBHYT"].ToString()) * txtSoLuong.Value;
                    drvNew["NgayYLenh"] = dateYLenh.DateTime;
                    drvNew["TTinThau"] =( dr["CongBo"].ToString().Length>3 ? dr["CongBo"].ToString().Substring(4)
                        : DateTime.Now.ToString("yyyy"))+ ".00." + dr["QuyetDinh"];
                    drvNew["TyLe"] = 100;
                    drvNew.EndEdit();
                }
                else
                {
                    // mục khác
                }
                lookUpVatTu.Focus();
                txtSoLuong.ResetText();
                txtLanUong.ResetText();
                txtNgayUong.ResetText();
            }
            // không cho chỉnh sửa số lượng, chỉ cho xóa rồi thêm mới,
            // thêm mới sẽ tự tìm thuốc, có thể 1 thuốc có nhiều dòng
            // xóa sẽ tìm và xóa các dòng
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LuuKeDon();
        }
        private void LuuKeDon()
        {
            // kiểm tra nhập mã bệnh
            if (string.IsNullOrEmpty(maBenhChinh))
            {
                XtraMessageBox.Show("Chưa chọn bệnh chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpMaBenh.Focus();
                return;
            }
            if(string.IsNullOrEmpty(Utils.ToString(lookUpBacSi.EditValue)))
            {
                XtraMessageBox.Show("Chưa chọn bác sĩ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpBacSi.Focus();
                return;
            }
            string err = "";
            // cập nhật mã bệnh, bảng thông tin chi tiết
            kedon.MaBenh = maBenhChinh;
            kedon.TenBenh = txtTenBenh.Text;
            kedon.MaBenhKhac = txtMaBenhKhac.Text;
            if (!kedon.SpCapNhatBenh(ref err))
            {
                XtraMessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // xóa những thuốc đã chọn
            List<string> keys = new List<string>(listThuoc.Keys);
            foreach (var key in keys)
            {
                if (listThuoc[key] == 0)
                {
                    err = "";
                    // tiến hành xóa trong csdl, listThuoc
                    kedon.MaVatTu = key;
                    kedon.NgayYLenh = DateTime.Now;
                    if (!kedon.SpKeDonThuoc(ref err, "DELETE"))
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        listThuoc.Remove(key);
                }
            }
            // lưu bảng thuốc
            foreach (DataRowView drv in dvThuoc)
            {
                err = "";
                kedon.MaVatTu = drv["MaVatTu"].ToString();
                kedon.MaThuoc = drv["MaThuoc"].ToString();
                kedon.MaNhom = 4;// Thuốc trong danh mục BHYT 
                kedon.TenThuoc = drv["TenThuoc"].ToString();
                kedon.DonViTinh = drv["DonViTinh"].ToString();
                kedon.HamLuong = drv["HamLuong"].ToString();
                kedon.MaDuongDung = drv["MaDuongDung"].ToString();
                kedon.LieuDung = drv["LieuDung"].ToString();
                kedon.SoDK = drv["SoDK"].ToString();
                kedon.TTinThau = drv["TTinThau"].ToString();
                kedon.PhamVi = 1;
                kedon.SoLuong = Utils.ToInt(drv["SoLuong"]);
                kedon.DonGia = Utils.ToDecimal(drv["DonGia"]);
                kedon.TyLe = Utils.ToInt(drv["TyLe"],100);
                kedon.ThanhTien = Utils.ToDecimal(drv["ThanhTien"]);
                kedon.MaKhoa = Utils.ToString(lookUpMaKhoa.EditValue);
                kedon.MaBacSi = Utils.ToString(lookUpBacSi.EditValue);
                kedon.NgayYLenh = Utils.ToDateTime(drv["NgayYLenh"].ToString());
                kedon.MaPTTT = 0;
                if (listThuoc[drv["MaVatTu"].ToString()] == 1)
                {
                    //lưu lại đường dùng, không lưu lại số lượng
                    if (!kedon.SpKeDonThuoc(ref err, "UPDATE"))
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // value = 2
                    // thêm mới 
                    if (thuocNgoaiDM.Select("MaVatTu = '" + kedon.MaVatTu + "' and MaHoatChat = '" + kedon.MaThuoc + "'", "").Length > 0)
                    {
                        if (Utils.ToInt(drv["TyLe"], 100) != 100)
                        {
                            kedon.MaNhom = 6;// Thuốc thanh toán theo tỷ lệ
                            kedon.PhamVi = 2;
                        }
                        // insert ngoài danh mục
                        if (kedon.SpKeDonThuoc(ref err, "INSERT_NgoaiDM"))
                        {
                            listThuoc[drv["MaVatTu"].ToString()] = 1;// đã có nếu lưu thành công
                        }
                        else
                        {
                            XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        
                        // thuốc trong kho
                        if (kedon.SpKeDonThuoc(ref err, "INSERT"))
                        {
                            listThuoc[drv["MaVatTu"].ToString()] = 1;// đã có nếu lưu thành công
                        }
                        else
                        {
                            XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            // xóa những vật tư đã chọn
            keys = new List<string>(listVatTu.Keys);
            foreach (var key in keys)
            {
                if (listVatTu[key] == 0)
                {
                    err = "";
                    // tiến hành xóa trong csdl, listVatTu
                    kedon.MaVatTu = key;
                    kedon.NgayYLenh = DateTime.Now;
                    if (!kedon.SpKeVatTu(ref err, "DELETE"))
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        listVatTu.Remove(key);
                }
            }
            // lưu bảng vật tư
            foreach (DataRowView drv in dvVatTu)
            {
                err = "";
                kedon.MaVatTu = drv["MaVatTu"].ToString();
                kedon.MaVT = drv["MaVT"].ToString();
                kedon.MaNhom = 10;// Vật tư trong danh mục BHYT 
                kedon.GoiVTYT = "G1";
                kedon.TenVatTu = drv["TenVatTu"].ToString();
                kedon.DonViTinh = drv["DonViTinh"].ToString();
                kedon.TTinThau = drv["TTinThau"].ToString();
                kedon.PhamVi = 1;
                kedon.SoLuong = Utils.ToInt(drv["SoLuong"]);
                kedon.DonGia = Utils.ToDecimal(drv["DonGia"]);
                kedon.TyLe = 100;
                kedon.ThanhTien = Utils.ToDecimal(drv["ThanhTien"]);
                kedon.MaKhoa = Utils.ToString(lookUpMaKhoa.EditValue);
                kedon.MaBacSi = Utils.ToString(lookUpBacSi.EditValue);
                kedon.NgayYLenh = Utils.ToDateTime(drv["NgayYLenh"].ToString());
                kedon.MaPTTT = 0;
                if (listVatTu[drv["MaVatTu"].ToString()] == 2)
                {
                    // value = 2
                    // thêm mới 
                    if (kedon.SpKeVatTu(ref err, "INSERT"))
                    {
                        listVatTu[drv["MaVatTu"].ToString()] = 1;// đã có nếu lưu thành công
                    }
                    else
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void TaoDonThuocA5()
        {
            RptDonThuoc rpt = new RptDonThuoc();
            rpt.lblCoSo.Text = this.TenCoSo.ToUpper();
            rpt.xrlblSoHoSo.Text = "Số hồ sơ:" + STTNgay ;
            rpt.lblHoTen.Text = this.HoTen;
            rpt.lblNamSinh.Text = this.NgaySinh;
            rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            rpt.lblDiaChi.Text = this.DiaChi;
            if(!string.IsNullOrEmpty(this.MaThe))
            {
                rpt.lblSoThe.Text = this.MaThe;
                rpt.lblNoiDangKyKCB.Text = this.NoiDangKy;
                rpt.lblHanSuDung.Text = Utils.ToDateTime(TheTu).ToString("dd/MM/yyyy") + " - " 
                    + Utils.ToDateTime(TheDen).ToString("dd/MM/yyyy");
            }
            rpt.lblTenBenh.Text = txtTenBenh.Text;
            rpt.lblBacSi.Text = lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue).ToString();
            rpt.lblNgayKeDon.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            DataTable dtThuoc = dvThuoc.ToTable();
            dtThuoc.Columns.Add("STT", typeof(string));
            int i = 1;
            foreach(DataRow dr in dtThuoc.Rows)
            {
                dr["STT"] = i+")";
                i++;
                string hamLuong = dr["HamLuong"].ToString();
                int index = 0;
                int space = hamLuong.Length;
                while(index>-1&&hamLuong.Length>15)
                {
                    index = hamLuong.IndexOf(' ', index+1);
                    if(index > 15 || index == -1)
                    {
                        index = -1;
                    }
                    else
                    {
                        space = index;
                    }
                }
                dr["HamLuong"] = hamLuong.Substring(0, space);
            }

            rpt.DataSource = dtThuoc;
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
        }
        private void TaoDonThuocA4()
        {
            RptDonThuocA4 rpt = new RptDonThuocA4();
            rpt.lblCoSo.Text = this.TenCoSo.ToUpper();
            rpt.xrlblSoHoSo.Text = "Số hồ sơ:" + STTNgay;
            rpt.lblHoTen.Text = this.HoTen;
            rpt.lblNamSinh.Text = this.NgaySinh;
            rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            rpt.lblDiaChi.Text = this.DiaChi;
            //rpt.lblCoSo.Text = this.TenCoSo.ToUpper();
            rpt.xrlblSoHoSo1.Text = "Số hồ sơ:" + STTNgay;
            rpt.lblHoTen1.Text = this.HoTen;
            rpt.lblNamSinh1.Text = this.NgaySinh;
            rpt.lblGioiTinh1.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            rpt.lblDiaChi1.Text = this.DiaChi;
            //
            if (!string.IsNullOrEmpty(this.MaThe))
            {
                rpt.lblSoThe.Text = this.MaThe;
                rpt.lblNoiDangKyKCB.Text = this.NoiDangKy;
                rpt.lblHanSuDung.Text = Utils.ToDateTime(TheTu).ToString("dd/MM/yyyy") + " - "
                    + Utils.ToDateTime(TheDen).ToString("dd/MM/yyyy");
                //
                rpt.lblSoThe1.Text = this.MaThe;
                rpt.lblNoiDangKyKCB1.Text = this.NoiDangKy;
                rpt.lblHanSuDung1.Text = Utils.ToDateTime(TheTu).ToString("dd/MM/yyyy") + " - "
                    + Utils.ToDateTime(TheDen).ToString("dd/MM/yyyy");
            }
            rpt.lblTenBenh.Text = txtTenBenh.Text;
            rpt.lblBacSi.Text = lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue).ToString();
            rpt.lblNgayKeDon.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //
            rpt.lblTenBenh1.Text = txtTenBenh.Text;
            rpt.lblBacSi1.Text = lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue).ToString();
            rpt.lblNgayKeDon1.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //
            DataTable dtThuoc = dvThuoc.ToTable();
            dtThuoc.Columns.Add("STT", typeof(string));
            int i = 1;
            foreach (DataRow dr in dtThuoc.Rows)
            {
                dr["STT"] = i + ")";
                i++;
                string hamLuong = dr["HamLuong"].ToString();
                int index = 0;
                int space = hamLuong.Length;
                while (index > -1 && hamLuong.Length > 15)
                {
                    index = hamLuong.IndexOf(' ', index + 1);
                    if (index > 15 || index == -1)
                    {
                        index = -1;
                    }
                    else
                    {
                        space = index;
                    }
                }
                dr["HamLuong"] = hamLuong.Substring(0, space);
            }

            rpt.DataSource = dtThuoc;
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
        }
        private void repbtnXoaVT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = gridViewVTYT.GetFocusedDataSourceRowIndex();
            if (index > -1)
            {
                DataRow dr = dvVatTu.ToTable().Rows[index];
                if (listVatTu[dr["MaVatTu"].ToString()] == 1)
                {
                    string err = "";
                    // tiến hành xóa trong csdl, listVatTu
                    kedon.MaVatTu = dr["MaVatTu"].ToString();
                    kedon.NgayYLenh = DateTime.Now;
                    if (!kedon.SpKeVatTu(ref err, "DELETE"))
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listVatTu[dr["MaVatTu"].ToString()] = 0;
                    }
                    else
                        listVatTu.Remove(dr["MaVatTu"].ToString());
                }
                else
                    listVatTu.Remove(dr["MaVatTu"].ToString());
                (gridControlVTYT.DataSource as DataView).Delete(index);
            }
        }

        private void btnLuuIn_Click(object sender, EventArgs e)
        {
            LuuKeDon();
            TaoDonThuocA4();
        }

        private void repbtnXoaThuoc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = gridViewThuoc.GetFocusedDataSourceRowIndex();
            if (index > -1)
            {
                DataRow dr = dvThuoc.ToTable().Rows[index];
                if (listThuoc[dr["MaVatTu"].ToString()] == 1)
                {
                    string err = "";
                    // tiến hành xóa trong csdl, listThuoc
                    kedon.MaVatTu = dr["MaVatTu"].ToString();
                    kedon.NgayYLenh = DateTime.Now;
                    if (!kedon.SpKeDonThuoc(ref err, "DELETE"))
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listThuoc[dr["MaVatTu"].ToString()] = 0;
                    }
                    else
                        listThuoc.Remove(dr["MaVatTu"].ToString());
                }
                else
                    listThuoc.Remove(dr["MaVatTu"].ToString());
                (gridControlThuoc.DataSource as DataView).Delete(index);
            }
        }
    }
}
