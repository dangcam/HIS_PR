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
    public partial class FrmDonThuoc : RibbonForm
    {
        KeDonEntity kedon;
        Dictionary<string, int> listThuoc;
        DataView dvThuoc;
        DataTable thuocNgoaiDM;
        Dictionary<string, string> dicDuongDung = new Dictionary<string, string>();
        public FrmDonThuoc(string khoNhan)
        {
            InitializeComponent();
            kedon = new KeDonEntity();
            kedon.KhoNhan = khoNhan;
            lookUpThuoc.Properties.DisplayMember = "TenVatTu";
            thuocNgoaiDM = kedon.DSKeDonNgoaiDM();
            dicDuongDung = kedon.DSDuongDung().AsEnumerable().ToDictionary<DataRow, string, string>
                (row => row.Field<string>(0), row => row.Field<string>(1));

        }
        public string MaLK { get; set; }
        public string MaKhoa { get; set; }
        public string MaBacSi { get; set; }
        public string TenBacSi { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string MaThe { get; set; }
        public string TenBenh { get; set; }
        public string TheTu { get; set; }
        public string TheDen { get; set; }
        public string TenCoSo { get; set; }
        public string NoiDangKy { get; set; }
        public string STTNgay { get; set; }
        private void FrmDonThuoc_Load(object sender, EventArgs e)
        {
            dateNgayYLenh.DateTime = DateTime.Now;
            kedon.MaLK = this.MaLK;
            kedon.MaKhoa = this.MaKhoa;
            kedon.MaBacSi = this.MaBacSi;
            this.ActiveControl = lookUpThuoc;
            listThuoc = new Dictionary<string, int>();
            dvThuoc = kedon.DSThuoc().AsDataView();
            gridControlThuoc.DataSource = dvThuoc;
            gridViewThuoc.ExpandAllGroups();
            foreach (DataRowView drv in dvThuoc)
            {
                listThuoc.Add(drv["MaVatTu"]+"|"+ drv["NhomYLenh"], 1);
            }
            cbLoaiThuoc.SelectedIndex = 0;
        }

        private void lookUpThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoLuong.Focus();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNgayUong.Focus();
                //txtLieuDung.Focus();
        }
        private void txtLieuDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnChon.Focus();
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

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (lookUpThuoc.EditValue is DataRowView)
            {
                DataRowView dr = (lookUpThuoc.EditValue as DataRowView);
                //kiểm tra số lượng tồn thuốc
                if (listThuoc.ContainsKey(dr["MaVatTu"] + "|" + dateNgayYLenh.DateTime.ToString("yyyy-mm-dd hh:mm:ss")))
                {
                    XtraMessageBox.Show(Library.ThuocDaDuocChon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lookUpThuoc.Focus();
                    return;
                }
                if (cbLoaiThuoc.SelectedIndex == 0 && txtSoLuong.Value > Utils.ToInt(dr["SoLuongTon"]))
                {
                    XtraMessageBox.Show(Library.SoLuongThuocKhongDu, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Focus();
                    return;
                }
                // 2: thuốc mới đc thêm vào, 1 thuốc đã có
                listThuoc.Add(dr["MaVatTu"] + "|" + dateNgayYLenh.DateTime.ToString("yyyy-mm-dd hh:mm:ss"), 2);
                DataRowView drvNew = (gridControlThuoc.DataSource as DataView).AddNew();
                drvNew["MaVatTu"] = dr["MaVatTu"];
                drvNew["MaThuoc"] = dr["MaHoatChat"];
                drvNew["TenThuoc"] = dr["TenVatTu"];
                drvNew["HamLuong"] = dr["HamLuong"];
                drvNew["DonViTinh"] = dr["DonViTinh"];
                drvNew["SoLuong"] = txtSoLuong.Value;
                drvNew["DonGia"] = dr["GiaBHYT"];
                drvNew["ThanhTien"] = Utils.ToDouble(dr["GiaBHYT"].ToString()) *Utils.ToDouble( txtSoLuong.Value.ToString());
                drvNew["LieuDung"] = "Ngày " + dicDuongDung[dr["MaDuongDung"].ToString()].ToLower()
                    + " " + txtNgayUong.Value + " lần, lần " + txtLanUong.Value + " " + dr["DonViTinh"].ToString().ToLower();
                drvNew["NgayYLenh"] = dateNgayYLenh.DateTime;
                drvNew["NhomYLenh"] = dateNgayYLenh.DateTime.ToString("yyyy-mm-dd hh:mm:ss");
                drvNew["MaDuongDung"] = dr["MaDuongDung"];
                drvNew["SoDK"] = dr["SoDK"];
                if (cbLoaiThuoc.SelectedIndex == 0)
                {
                    drvNew["TyLe"] = 100;
                    drvNew["TTinThau"] = dr["QuyetDinh"] + ";" + dr["GoiThau"] + ";" + dr["NhomThau"];
                }
                else
                {
                    drvNew["TyLe"] = dr["TyLeTT"];
                    drvNew["TTinThau"] = dr["TTinThau"];
                }
                drvNew.EndEdit();
                lookUpThuoc.Focus();
                txtSoLuong.ResetText();
                txtLanUong.ResetText();
                txtNgayUong.ResetText();
                //txtLieuDung.Text = "";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LuuDon();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void repbtnXoaThuoc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = gridViewThuoc.GetFocusedDataSourceRowIndex();
            if (index > -1)
            {

                DataRow dr = dvThuoc.ToTable().Rows[index];
                if (listThuoc[dr["MaVatTu"] + "|" + dr["NhomYLenh"]] == 1)
                {
                    string err = "";
                    // tiến hành xóa trong csdl, listThuoc
                    kedon.MaVatTu = dr["MaVatTu"].ToString();
                    kedon.NgayYLenh = Utils.ToDateTime(dr["NhomYLenh"].ToString());
                    if (!kedon.SpKeDonThuoc(ref err, "DELETE_NoiTru"))
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listThuoc[dr["MaVatTu"] + "|" + dr["NhomYLenh"]] = 0;
                        return;
                    }
                    else
                        listThuoc.Remove(dr["MaVatTu"] + "|" + dr["NhomYLenh"]);
                }
                else
                    listThuoc.Remove(dr["MaVatTu"] + "|" + dr["NhomYLenh"]);
                (gridControlThuoc.DataSource as DataView).Delete(index);
            }
        }

        private void txtNgayUong_ValueChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Value > 150)
            {
                XtraMessageBox.Show("Số lượng chọn " + txtSoLuong.Value, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void txtNgayUong_Enter(object sender, EventArgs e)
        //{
        //    txtNgayUong.Select(0, txtSoLuong.Value.ToString().Length);
        //}

        private void txtSoLuong_Enter(object sender, EventArgs e)
        {
            txtSoLuong.Select(0, txtSoLuong.Value.ToString().Length);
        }

        //private void txtLanUong_Enter(object sender, EventArgs e)
        //{
        //    txtLanUong.Select(0, txtSoLuong.Value.ToString().Length);
        //}

        private void btnIn_Click(object sender, EventArgs e)
        {
            LuuDon();
            //InDon();
            TaoDonThuocA4();
        }
        private void LuuDon()
        {
            kedon.MaLK = this.MaLK;
            string err = "";
            // xóa những thuốc đã chọn
            List<string> keys = new List<string>(listThuoc.Keys);
            foreach (var key in keys)
            {
                if (listThuoc[key] == 0)
                {
                    err = "";
                    // tiến hành xóa trong csdl, listThuoc
                    kedon.MaVatTu = key.Split('|')[0];
                    kedon.NgayYLenh =Utils.ToDateTime(key.Split('|')[0], "yyyy-mm-dd hh:mm:ss");
                    if (!kedon.SpKeDonThuoc(ref err, "DELETE_NoiTru"))
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
                kedon.TyLe =Utils.ToInt(drv["TyLe"], 100);
                kedon.ThanhTien = Utils.ToDecimal(drv["ThanhTien"]);
                kedon.MaKhoa = this.MaKhoa;
                kedon.MaBacSi = this.MaBacSi;
                kedon.NgayYLenh = Utils.ToDateTime(drv["NgayYLenh"].ToString());
                kedon.MaPTTT = 0;
                if (listThuoc[drv["MaVatTu"] + "|" + drv["NhomYLenh"]] == 1)
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
                    if (thuocNgoaiDM.Select("MaVatTu = '"+ kedon.MaVatTu + "' and MaHoatChat = '"+kedon.MaThuoc+"'", "").Length > 0)
                    {
                        if (Utils.ToInt(drv["TyLe"], 100) != 100)
                            kedon.MaNhom = 6;// Thuốc thanh toán theo tỷ lệ
                        // insert ngoài danh mục
                        if (kedon.SpKeDonThuoc(ref err, "INSERT_NgoaiDM"))
                        {
                            listThuoc[drv["MaVatTu"] + "|" + drv["NhomYLenh"]] = 1;// đã có nếu lưu thành công
                        }
                        else
                        {
                            XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // insert thuốc danh mục
                        if (kedon.SpKeDonThuoc(ref err, "INSERT_NgoaiDM"))// insert ngoài danh mục luôn, không trừ kho nữa, ứng phiếu tùm lum
                        {
                            listThuoc[drv["MaVatTu"] + "|" + drv["NhomYLenh"]] = 1;// đã có nếu lưu thành công
                        }
                        else
                        {
                            XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void InDon()
        {
            RptDonThuoc rpt = new RptDonThuoc();
            rpt.lblCoSo.Text = this.TenCoSo.ToUpper();
            rpt.lblHoTen.Text = this.HoTen;
            rpt.lblNamSinh.Text = this.NgaySinh;
            rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            rpt.lblDiaChi.Text = this.DiaChi;
            if (!string.IsNullOrEmpty(this.MaThe))
            {
                rpt.lblSoThe.Text = this.MaThe;
                rpt.lblNoiDangKyKCB.Text = this.NoiDangKy;
                rpt.lblHanSuDung.Text = Utils.ToDateTime(TheTu).ToString("dd/MM/yyyy") + " - "
                    + Utils.ToDateTime(TheDen).ToString("dd/MM/yyyy");
            }
            rpt.lblTenBenh.Text = this.TenBenh;
            rpt.lblBacSi.Text = this.TenBacSi;
            rpt.lblNgayKeDon.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
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
        private void TaoDonThuocA4()
        {
            RptDonThuocA4 rpt = new RptDonThuocA4();
            //rpt.lblCoSo.Text = this.TenCoSo.ToUpper();
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
            rpt.lblTenBenh.Text = this.TenBenh;
            rpt.lblBacSi.Text = this.TenBacSi;
            rpt.lblNgayKeDon.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //
            rpt.lblTenBenh1.Text = this.TenBenh;
            rpt.lblBacSi1.Text = this.TenBacSi;
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
        private void cbLoaiThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbLoaiThuoc.SelectedIndex ==0)
            {
                lookUpThuoc.Properties.DataSource = kedon.DSKeVatTuKhoChan("1");
            }
            else
            {
                lookUpThuoc.Properties.DataSource = thuocNgoaiDM; 
            }
        }
    }
}
