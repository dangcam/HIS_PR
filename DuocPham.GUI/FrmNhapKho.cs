﻿using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DuocPham.DAL;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System;
using System.Linq;
using Core.DAL;

namespace DuocPham.GUI
{
    public partial class FrmNhapKho : RibbonForm
    {
        NhapKhoEntity nhapkho;
        string quyen = "";
        string err = "";
        bool them = false;
        DataView data;
        DataTable dtPhieu;
        DataTable dtVatTu;
        DataTable nvKhoaDuoc;
        Dictionary<string, bool> dsVatTu = new Dictionary<string, bool> ();
        SortedSet<string> dsLoaiVatTu = new SortedSet<string> ();
        decimal thanhTien = 0;
        System.Drawing.Font fontB = new System.Drawing.Font ("Times New Roman", 11, System.Drawing.FontStyle.Bold);
        System.Drawing.Font font = new System.Drawing.Font ("Times New Roman", 11);
        Dictionary<string, string> maVatTu = new Dictionary<string, string>();
        Dictionary<string, string> hamLuong = new Dictionary<string, string>();
        public FrmNhapKho ()
        {
            InitializeComponent ();
            nhapkho = new NhapKhoEntity ();
            DataTable mvt = nhapkho.DSMaVatTu();
            maVatTu = mvt.AsEnumerable().ToDictionary(row => row["MaBV"].ToString(), row => row["MaCu"].ToString());
            hamLuong = mvt.AsEnumerable().ToDictionary(row => row["MaBV"].ToString(), row => row["HamLuong"].ToString());
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmNhapKho_Load (object sender, EventArgs e)
        {
            dtVatTu = nhapkho.DSVatTu();
            nvKhoaDuoc = nhapkho.DSNVKhoaDuoc();
            lookUpKhoNhap.Properties.DataSource = nhapkho.DSKho ();
            lookUpKhoNhap.Properties.DisplayMember = "TenKhoa";
            lookUpKhoNhap.Properties.ValueMember = "MaKhoa";

            lookUpNhaCungCap.Properties.DataSource = nhapkho.DSNhaCungCap ();
            lookUpNhaCungCap.Properties.DisplayMember = "Ten";
            lookUpNhaCungCap.Properties.ValueMember = "ID";

            lookUpNguoiNhan.Properties.DataSource = nhapkho.DSNguoiNhan ();
            lookUpNguoiNhan.Properties.DisplayMember = "Ten_NV";
            lookUpNguoiNhan.Properties.ValueMember = "Ma_NV";

            lookUpMaVatTu.Properties.DisplayMember = "MaBV";
            lookUpMaVatTu.Properties.ValueMember = "MaBV";

            dateTuNgay.EditValue = DateTime.Now;
            dateDenNgay.EditValue = DateTime.Now;

            checkButton ();
            LoadData ();
            btnIn.Enabled = false;
            btnBBGiaoHang.Enabled = false;
            btnBBNghiemThu.Enabled = false;
            btnBBNhapHang.Enabled = false;
        }
        private void LoadData ()
        {
            them = false;
            txtSoPhieu.ReadOnly = true;
            gridControlPhieu.DataSource = nhapkho.DSPhieu (dateTuNgay.DateTime, dateDenNgay.DateTime);
        }

        private void checkButton ()
        {
            quyen = Utils.GetQuyen (this.Name);
            Enabled_Them ();
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;

        }
        private void Enabled_Luu ()
        {
            if (quyen.IndexOf ('2') >= 0 || them)
            {
                btnLuu.Enabled = true;
            }
            else
            {
                btnLuu.Enabled = false;
            }
        }
        private void Enabled_Xoa ()
        {
            if (quyen.IndexOf ('3') >= 0)
            {
                btnXoa.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }
        private void Enabled_Them ()
        {
            if (quyen.IndexOf ('1') >= 0)
            {
                btnThem.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
            }
        }
        private void btnThem_Click (object sender, EventArgs e)
        {
            them = true;
            txtSoPhieu.ReadOnly = false;
            txtSoPhieu.Text = "0";
            txtSoHoaDon.Text = "";
            txtTKNo.Text = "";
            dateNgayNhap.EditValue = DateTime.Now;
            lookUpNhaCungCap.EditValue = "";
            txtNguoiGiaoHang.Text = Utils.ToString(nvKhoaDuoc.Rows[4]["HoTen"]);
            lookUpKhoNhap.EditValue = "";
            lookUpNguoiNhan.EditValue = "";
            txtNoiDung.Text = "";
            lookUpKhoNhap.EditValue = "70013";
            txtNoiDung.Text = "Nhập thuốc tháng "+ dateNgayNhap.DateTime.Month + " Cty ";

            nhapkho.SoPhieu = 0;
            dtPhieu = nhapkho.DSPhieuVatTu ();
            gridControlDS.DataSource = dtPhieu.AsDataView();
            dsVatTu.Clear ();
            txtTongTien.Text = "0";
            txtTKNo.Focus ();
            Enabled_Luu ();
            btnIn.Enabled = false;
            btnBBGiaoHang.Enabled = false;
            btnBBNghiemThu.Enabled = false;
            btnBBNhapHang.Enabled = false;
        }
        private bool checkInput()
        {
            if(txtTKNo.Text.Length ==0)
            {
                txtTKNo.Focus ();
                XtraMessageBox.Show ("Nhập tài khoản nợ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((gridControlDS.DataSource as DataView).Count == 0)
            {
                XtraMessageBox.Show ("Nhập vật tư!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lookUpMaVatTu.Focus ();
                return false;
            }

            return true;
        }
        private void btnLuu_Click (object sender, EventArgs e)
        {
            if(!checkInput())
            {
                return;
            }
            nhapkho.SoPhieu = int.Parse(txtSoPhieu.Text);
            nhapkho.SoHoaDon = txtSoHoaDon.Text;
            nhapkho.TKNo = txtTKNo.Text;
            nhapkho.NgayNhap = dateNgayNhap.DateTime;
            nhapkho.IDNhaCC = lookUpNhaCungCap.EditValue.ToString ();
            nhapkho.NhaCungCap = lookUpNhaCungCap.Properties.GetDisplayValueByKeyValue(lookUpNhaCungCap.EditValue).ToString();
            nhapkho.NguoiGiaoHang = txtNguoiGiaoHang.Text;
            nhapkho.KhoNhap = lookUpKhoNhap.EditValue.ToString ();
            nhapkho.NguoiNhan = lookUpNguoiNhan.EditValue.ToString();
            nhapkho.NoiDung = txtNoiDung.Text;

            nhapkho.NgayCapNhat = DateTime.Now;
            err = "";
            if (them)
            {
                nhapkho.NguoiTao = AppConfig.MaNV;
                if (nhapkho.SpPhieuNhap (ref err, "INSERT"))
                {
                    txtSoPhieu.Text = nhapkho.SoPhieu.ToString();
                    LuuVatTu ();
                    LoadData ();
                }
            }
            else
            {
                nhapkho.NguoiCapNhat = AppConfig.MaNV;

                if (nhapkho.SpPhieuNhap (ref err, "UPDATE"))
                {
                    LuuVatTu ();
                    LoadData ();
                }
            }
            if (!string.IsNullOrEmpty (err))
            {
                XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnIn.Enabled = true;
            btnBBGiaoHang.Enabled = true;
            btnBBNghiemThu.Enabled = true;
            btnBBNhapHang.Enabled = true;
        }
        private void LuuVatTu()
        {
            data = (gridControlDS.DataSource as DataView);

            foreach(DataRowView dr in data)
            {
                err = "";
                nhapkho.MaVatTu = dr["MaVatTu"].ToString ();
                nhapkho.SoDangKy = dr["SoDangKy"].ToString ();
                nhapkho.SoLuong = Utils.ToInt (dr["SoLuong"].ToString ());
                nhapkho.SoLuongQuyDoi = Utils.ToInt (dr["SoLuongQuyDoi"].ToString ());
                nhapkho.SoLuongDung = Utils.ToInt (dr["SoLuongDung"].ToString ());
                nhapkho.DonGiaBHYT = Utils.ToDecimal (dr["DonGiaBHYT"].ToString ());
                nhapkho.DonGiaBV = Utils.ToDecimal (dr["DonGiaBV"].ToString ());
                nhapkho.SoLo = dr["SoLo"].ToString ();
                nhapkho.HetHan = DateTime.Parse (dr["HetHan"].ToString ());
                nhapkho.ThanhTien = Utils.ToDecimal (dr["ThanhTien"].ToString ());
                nhapkho.LoaiVatTu = dr["LoaiVatTu"].ToString ();
                nhapkho.STT = Utils.ToInt(dr["STT"]);
                if(them)
                {
                    dsVatTu.Add(nhapkho.MaVatTu + "|" + nhapkho.SoLo, false);
                    nhapkho.SpPhieuNhapChiTiet (ref err, "INSERT");
                }
                else
                {
                    if(dsVatTu.ContainsKey(nhapkho.MaVatTu + "|" + nhapkho.SoLo))
                    {
                        dsVatTu[nhapkho.MaVatTu + "|" + nhapkho.SoLo] = true;
                        nhapkho.SpPhieuNhapChiTiet (ref err, "UPDATE");
                    }
                    else
                    {
                        dsVatTu.Add (nhapkho.MaVatTu + "|" + nhapkho.SoLo, true);
                        nhapkho.SpPhieuNhapChiTiet (ref err, "INSERT");
                    }
                }
                if(!string.IsNullOrEmpty(err))
                {
                    XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if(!them)
            {
                List<string> keys = new List<string> (dsVatTu.Keys);
                foreach(var key in keys)
                {
                    if(dsVatTu[key]==false)
                    {
                        nhapkho.MaVatTu = key.Split('|')[0];
                        nhapkho.SoLo = key.Split('|')[1];
                        nhapkho.SpPhieuNhapChiTiet (ref err, "DELETE");
                        dsVatTu.Remove (key);
                    }
                    else
                    {
                        dsVatTu[key] = false;
                    }
                }
            }
        }
        private void btnXoa_Click (object sender, EventArgs e)
        {
            DialogResult traloi;
            string err = "";
            traloi = XtraMessageBox.Show ("Chắc chắn bạn muốn xóa mục này?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if (!nhapkho.SpPhieuNhapXoa (ref err))
                {
                    XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadData ();
                btnThem_Click (null, null);
            }
        }

        private void btnIn_Click (object sender, EventArgs e)
        {
            inPhieuNhap ();
        }

        private void lookUpMaVatTu_EditValueChanged (object sender, EventArgs e)
        {
            if(lookUpMaVatTu.EditValue!=null && lookUpMaVatTu.Properties.GetRowByKeyValue(lookUpMaVatTu.EditValue) is DataRowView)
            {
                DataRowView drv = (lookUpMaVatTu.Properties.GetRowByKeyValue (lookUpMaVatTu.EditValue) as DataRowView);
                txtTenVatTu.Text = drv[1].ToString ();
                txtSoDangKy.Text = drv[3].ToString ();
                txtGiaBHYT.Text = drv[4].ToString ();
            }
        }

        private void txtTyLe_Leave (object sender, EventArgs e)
        {
            if(txtSoLuong.Text.Length > 0 && txtTyLe.Text.Length >0)
            {
                txtSoLuongQD.Text = int.Parse (txtSoLuong.Text.Replace (",", "")) * int.Parse (txtTyLe.Text.Replace(",","")) + "";
            }
        }

        private void txtThanhTien_KeyPress (object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtVAT.Focus();
            }
        }
        private void Enter_Thuoc()
        {
            if (lookUpMaVatTu.EditValue == null)
            {
                XtraMessageBox.Show("Chưa chọn mã vật tư!");
                lookUpMaVatTu.Focus();
                return;
            }
            if (txtSoLuongQD.Text.Length == 0 || txtSoLuongQD.Text == "0")
            {
                XtraMessageBox.Show("Nhập số lượng!");
                txtSoLuongQD.Focus();
                return;
            }
            if (dateHetHan.DateTime < DateTime.Now)
            {
                XtraMessageBox.Show("Hạn dùng phải lớn hơn ngày hiện tại!");
                dateHetHan.Focus();
                return;
            }
            if (txtSoLuong.Text.Length == 0)
            {
                txtSoLuong.Text = "0";
            }
            if (gridControlDS.DataSource is DataView && btnLuu.Enabled)
            {
                DataRow[] drv = (gridViewDS.DataSource as DataView).
                    Table.Select("MaVatTu = '" + lookUpMaVatTu.EditValue.ToString() + "' And SoLo = '" + txtSoLo.Text + "'");
                if (drv.Length != 0)
                {
                    XtraMessageBox.Show("Vật tư đã được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataRow drowVT = dtVatTu.Select("MaBV = '" + lookUpMaVatTu.EditValue.ToString() + "'")[0];
                //drow["TenVatTu"] = drowVT[1];

                int stt = 0;
                try
                {
                    stt = Utils.ToInt(dtPhieu.Rows[dtPhieu.Rows.Count - 1]["STT"]);
                }
                catch { }

                DataRowView dr = (gridControlDS.DataSource as DataView).AddNew();
                dr["STT"] = stt + 1;
                dr["MaVatTu"] = lookUpMaVatTu.EditValue;
                dr["TenVatTu"] = txtTenVatTu.Text;
                dr["SoDangKy"] = txtSoDangKy.Text;
                dr["SoLuong"] = txtSoLuong.Text;
                dr["SoLuongQuyDoi"] = txtSoLuongQD.Text;
                dr["SoLuongDung"] = 0;
                dr["DonGiaBHYT"] = Utils.ToDecimal(txtGiaBHYT.Text);
                dr["DonGiaBV"] = Utils.ToDecimal(txtGiaBV.Text);
                dr["SoLo"] = txtSoLo.Text;
                dr["HetHan"] = dateHetHan.DateTime;
                dr["ThanhTien"] = Math.Round(Utils.ToDecimal(txtThanhTien.Text));
                dr["LoaiVatTu"] = txtTKNo.Text.Length > 4 ? txtTKNo.Text.Substring(3, 2) : txtTKNo.Text.Substring(3, 1);
                dr["DonViTinh"] = drowVT[2];
                dr["NuocSanXuat"] = drowVT["NuocSX"];
                dr.EndEdit();

                lookUpMaVatTu.EditValue = null;
                txtTenVatTu.Text = "";
                txtSoDangKy.Text = "";
                txtSoLuong.Text = "0";
                txtSoLuongQD.Text = "0";
                txtGiaBHYT.Text = "0";
                txtGiaBV.Text = "0";
                txtSoLo.Text = "0";
                dateHetHan.EditValue = null;
                txtThanhTien.Text = "0";
                txtVAT.Text = "0";
                txtTyLe.Text = "0";
                lookUpMaVatTu.Focus();
            }
        }
        private void gridViewDS_CellValueChanged (object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName == "SoLuongQuyDoi")
            {
                this.gridViewDS.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler (this.gridViewDS_CellValueChanged);
                var soLuong = Convert.ToDecimal (e.Value);
                var soLuongDung = Convert.ToDecimal (gridViewDS.GetRowCellValue (e.RowHandle, gridViewDS.Columns["SoLuongDung"]));
                if(soLuong<soLuongDung)
                {
                    XtraMessageBox.Show("Không thể chỉnh sửa số lượng nhập kho ("+ soLuong +")  < số lượng vật tư đã sử dụng ("+ soLuongDung + ")!." +
                        " Được gán bằng số lượng vật tư đã sử dụng.",
                        "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    soLuong = soLuongDung;
                    gridViewDS.SetFocusedRowCellValue ("SoLuongQuyDoi", soLuong);
                }
                var donGia = gridViewDS.GetRowCellValue (e.RowHandle, gridViewDS.Columns["DonGiaBV"]);
                gridViewDS.SetFocusedRowCellValue ("ThanhTien",soLuong * Convert.ToDecimal( donGia));
                this.gridViewDS.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler (this.gridViewDS_CellValueChanged);
            }
            if(e.Column.FieldName == "DonGiaBV")
            {
                this.gridViewDS.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler (this.gridViewDS_CellValueChanged);
                var soLuong = gridViewDS.GetRowCellValue (e.RowHandle, gridViewDS.Columns["DonGiaBV"]);
                var donGia = e.Value;
                gridViewDS.SetFocusedRowCellValue ("ThanhTien", Convert.ToDecimal (soLuong) * Convert.ToDecimal (donGia));
                this.gridViewDS.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler (this.gridViewDS_CellValueChanged);
            }
            if (e.Column.FieldName == "ThanhTien")
            {
                this.gridViewDS.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewDS_CellValueChanged);
                var soLuong = gridViewDS.GetRowCellValue(e.RowHandle, gridViewDS.Columns["SoLuongQuyDoi"]);
                gridViewDS.SetFocusedRowCellValue("DonGiaBV", Convert.ToDecimal(e.Value) / Convert.ToDecimal(soLuong));
                this.gridViewDS.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewDS_CellValueChanged);
            }
        }

        private void btnXoaVatu_ButtonClick (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult traloi;
            string err = "";
            traloi = XtraMessageBox.Show("Chắc chắn bạn muốn xóa mục này?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if (them)
                {
                    (gridControlDS.DataSource as DataView).Delete(gridViewDS.GetFocusedDataSourceRowIndex());
                }
                else
                {
                    err = "";
                    DataRow dr = gridViewDS.GetDataRow(gridViewDS.GetFocusedDataSourceRowIndex());
                    nhapkho.MaVatTu = dr["MaVatTu"].ToString();
                    nhapkho.SoDangKy = dr["SoDangKy"].ToString();
                    nhapkho.SpPhieuNhapChiTiet(ref err, "DELETE");
                    if (!string.IsNullOrEmpty(err))
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    (gridControlDS.DataSource as DataView).Delete(gridViewDS.GetFocusedDataSourceRowIndex());
                    dsVatTu.Remove(nhapkho.MaVatTu + "|" + nhapkho.SoLo);
                }
            }
        }

        private void btnTim_Click (object sender, EventArgs e)
        {
            gridControlPhieu.DataSource = nhapkho.DSPhieu (dateTuNgay.DateTime, dateDenNgay.DateTime);
        }

        private void gridViewPhieu_RowClick (object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridViewPhieu.GetDataRow (e.RowHandle);
            if(dr!=null)
            {
                txtTKNo.Text = dr["TKNo"].ToString ();
                txtSoHoaDon.Text = dr["SoHoaDon"].ToString ();
                dateNgayNhap.DateTime = DateTime.Parse (dr["NgayNhap"].ToString ());
                lookUpNhaCungCap.EditValue = dr["IDNhaCC"].ToString ();
                txtNguoiGiaoHang.Text = dr["NguoiGiaoHang"].ToString ();
                lookUpKhoNhap.EditValue = dr["KhoNhap"].ToString ();
                lookUpNguoiNhan.EditValue = dr["NguoiNhan"].ToString ();
                txtNoiDung.Text = dr["NoiDung"].ToString ();
                txtSoPhieu.Text = dr["SoPhieu"].ToString ();
                nhapkho.NguoiTao = dr["NguoiTao"].ToString ();

                them = false;
                txtSoPhieu.ReadOnly = true;
                Enabled_Xoa ();
                Enabled_Luu ();
                // danh sách
                lookUpMaVatTu.Properties.DataSource = dtVatTu.Select ("LoaiVatTu = '"+ txtTKNo.Text.Substring(3, txtTKNo.Text.Length - 3) + "' and TinhTrang = 1").CopyToDataTable(); // data vật tư dataVatTu.Select
                nhapkho.SoPhieu = int.Parse (txtSoPhieu.Text);
                dtPhieu = nhapkho.DSPhieuVatTu ();
                dsVatTu.Clear ();
                foreach(DataRow drow in dtPhieu.Rows)
                {
                    dsVatTu.Add (drow["MaVatTu"].ToString ()+"|"+drow["SoLo"], false);
                    DataRow drowVT = dtVatTu.Select("MaBV = '" + drow["MaVatTu"].ToString() + "'")[0];
                    drow["TenVatTu"] = drowVT[1];
                    drow["DonViTinh"] = drowVT[2];
                    drow["NuocSanXuat"] = drowVT["NuocSX"];
                    //(lookUpMaVatTu.Properties.GetRowByKeyValue (drow["MaVatTu"].ToString ()) as DataRowView)[1];
                    // lấy tên vật tư từ mã vật tư, từ lookUpMaVatTu (thay bằng data vật tư) dataVatTu.Select
                }
                gridControlDS.DataSource = dtPhieu.AsDataView ();
                txtTongTien.EditValue = Utils.ToDecimal((dtPhieu.Compute("SUM(ThanhTien)", "")));
                btnIn.Enabled = true;
                btnBBGiaoHang.Enabled = true;
                btnBBNghiemThu.Enabled = true;
                btnBBNhapHang.Enabled = true;
            }

        }

        private void txtTKNo_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTKNo.Text.Length > 3)
            {
                try
                {
                    dtVatTu = nhapkho.DSVatTu();
                    lookUpMaVatTu.Properties.DataSource = dtVatTu.Select("LoaiVatTu = '" + txtTKNo.Text.Substring(3, txtTKNo.Text.Length - 3) + "' and TinhTrang = 1").CopyToDataTable();
                    //nhapkho.DSVatTu (txtTKNo.Text.Substring (3, txtTKNo.Text.Length-3));// dataVatTu.Select
                }
                catch { }
            }
        }

        private void txtNguoiGiaoHang_Leave (object sender, EventArgs e)
        {
            txtNguoiGiaoHang.Text = Utils.VietHoa (txtNguoiGiaoHang.Text);
        }
        private void inPhieuNhap()
        {
            RptPhieuNhapKho rpt = new RptPhieuNhapKho ();
            rpt.lblSoPhieu.Text = txtSoPhieu.Text.Substring(4, txtSoPhieu.Text.Length - 4);
            rpt.lblTKNo.Text = "";
            rpt.lblTKCo.Text = "331";
            rpt.lblNgayNhap.Text = "Ngày "+dateNgayNhap.DateTime.Day+" tháng "
                +dateNgayNhap.DateTime.Month+" năm "+dateNgayNhap.DateTime.Year;
            rpt.lblNguoiGiaoHang.Text = txtNguoiGiaoHang.Text;
            try
            {
                rpt.lblNhaCungCap.Text = lookUpNhaCungCap.Properties.GetDisplayValueByKeyValue(lookUpNhaCungCap.EditValue).ToString()
                    + ". Hóa đơn số: " + txtSoHoaDon.Text;
                //Công Ty TNHH TM-DV Dược Phẩm Bình Phú. Hóa đơn số 0004153
            }
            catch { }
            rpt.xrlblNguoiGiaoHang.Text = txtNguoiGiaoHang.Text;
            rpt.lblNoiDungNhap.Text = txtNoiDung.Text;//Nhập thuốc tháng 7 cty Bình Phú
            rpt.lblNhapKho.Text = lookUpKhoNhap.Properties.GetDisplayValueByKeyValue(lookUpKhoNhap.EditValue).ToString();
            rpt.lblNgayIn.Text = "Ngày " + dateNgayNhap.DateTime.Day + " tháng "
                + dateNgayNhap.DateTime.Month + " năm " + dateNgayNhap.DateTime.Year;
            //"Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            rpt.xrlblTRKhoaDuoc.Text = Utils.ToString(nvKhoaDuoc.Rows[0]["HoTen"]);
            rpt.xrlblThuKho.Text = Utils.ToString(nvKhoaDuoc.Rows[1]["HoTen"]);
            rpt.xrlblKeToanDuoc.Text = Utils.ToString(nvKhoaDuoc.Rows[3]["HoTen"]);
            rpt.xrlblNguoiGiaoHang.Text = Utils.ToString(nvKhoaDuoc.Rows[4]["HoTen"]);
            this.thanhTien = 0;
            dsLoaiVatTu.Clear ();
            XRTableRow row;
            XRTableCell cell;
            
            foreach(DataRowView drview in (gridViewDS.DataSource as DataView))
            {
                row = new XRTableRow ();

                cell = new XRTableCell ();
                cell.Text = drview["STT"].ToString();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.WidthF = 40;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = drview["MaVatTu"].ToString();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 80;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = drview["TenVatTu"]+ (hamLuong.ContainsKey(drview["MaVatTu"].ToString()) ? " " + hamLuong[drview["MaVatTu"].ToString()] : ""); 
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 280;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = dtVatTu.Select("MaBV = '" + drview["MaVatTu"].ToString() + "'")[0][2].ToString();
                //(lookUpMaVatTu.Properties.GetRowByKeyValue (drview["MaVatTu"].ToString ()) as DataRowView)[2].ToString ();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.WidthF = 100;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = Utils.ToString (drview["SoLuongQuyDoi"].ToString ());
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 60;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = Utils.ToString (drview["DonGiaBV"].ToString (),null, "0,0.00");
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 100;
                row.Cells.Add (cell);

                this.thanhTien += Utils.ToDecimal (drview["ThanhTien"].ToString ());
                cell = new XRTableCell ();
                cell.Text = Utils.ToString (drview["ThanhTien"].ToString (),null, "0,0");
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 106;
                row.Cells.Add (cell);

                rpt.xrTable.Rows.Add (row);
                dsLoaiVatTu.Add (drview["LoaiVatTu"].ToString ());
            }
            row = new XRTableRow ();
            cell = new XRTableCell ();
            cell.Text = "Tổng cộng";
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.WidthF = 660;
            row.Cells.Add (cell);

            cell = new XRTableCell ();
            cell.Text = Utils.ToString (this.thanhTien);
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.WidthF = 106;
            row.Cells.Add (cell);
            rpt.xrTable.Rows.Add (row);

            rpt.lblTongTien.Text = Utils.ChuyenSo(this.thanhTien.ToString().Split(AppConfig.NumberDecimalSeparator)[0]);
            rpt.lblTKNo.Text = "";
            foreach(string loai in dsLoaiVatTu)
            {
                rpt.lblTKNo.Text += "156" + loai +" ";
            }

            rpt.CreateDocument ();
            rpt.ShowPreviewDialog ();
        }

        private void txtThanhTien_EditValueChanged(object sender, EventArgs e)
        {
            if (Utils.ToInt(txtSoLuongQD.Text) > 0 && Utils.ToDouble(txtThanhTien.Text) > 0)
            {
                txtGiaBV.Text = (Utils.ToDouble(txtThanhTien.Text) / Utils.ToDouble(txtSoLuongQD.Text)).ToString();
            }
        }

        private void txtVAT_KeyPress (object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                if (Utils.ToInt(txtVAT.Text) > 0)
                {
                    this.txtThanhTien.EditValueChanged -= new System.EventHandler(this.txtThanhTien_EditValueChanged);
                    txtThanhTien.Text = (Utils.ToDouble(txtThanhTien.Text) * (1 + Utils.ToDouble(txtVAT.Text) / 100)).ToString();
                    txtThanhTien_EditValueChanged(null,null);
                    this.txtThanhTien.EditValueChanged += new System.EventHandler(this.txtThanhTien_EditValueChanged);
                }
                Enter_Thuoc();
            }
        }


        private void txtGiaBV_Leave(object sender, EventArgs e)
        {
            if (txtGiaBV.Text.Length > 0 && txtSoLuongQD.Text.Length > 0)
            {
                this.txtThanhTien.EditValueChanged -= new System.EventHandler(this.txtThanhTien_EditValueChanged);
                txtThanhTien.Text = Utils.ToInt(txtGiaBV.Text.Replace(",", "")) * Utils.ToInt(txtSoLuongQD.Text.Replace(",", "")) + "";
                this.txtThanhTien.EditValueChanged += new System.EventHandler(this.txtThanhTien_EditValueChanged);
            }
        }

        private void gridControlDS_Leave(object sender, EventArgs e)
        {
            if (dtPhieu != null)
            {
                txtTongTien.EditValue =Utils.ToDecimal( (dtPhieu.Compute("SUM(ThanhTien)", "")));
            }
        }

        private void lookUpMaVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtSoDangKy.Focus();
            }
        }

        private void txtSoDangKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSoLuong.Focus();
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTyLe.Focus();
            }
        }

        private void txtTyLe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSoLuongQD.Focus();
            }
        }

        private void txtSoLuongQD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtGiaBHYT.Focus();
            }
        }

        private void txtGiaBHYT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtGiaBV.Focus();
            }
        }

        private void txtGiaBV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSoLo.Focus();
            }
        }

        private void txtSoLo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dateHetHan.Focus();
            }
        }

        private void dateHetHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtThanhTien.Focus();
            }
        }

        private void txtTKNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSoHoaDon.Focus();
            }
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lookUpNhaCungCap.Focus();
            }
        }

        private void lookUpNhaCungCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNguoiGiaoHang.Focus();
            }
        }

        private void txtNguoiGiaoHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lookUpKhoNhap.Focus();
            }
        }

        private void lookUpKhoNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lookUpNguoiNhan.Focus();
            }
        }

        private void lookUpNguoiNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNoiDung.Focus();
            }
        }

        private void txtNoiDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lookUpMaVatTu.Focus();
            }
        }

        private void btnBBGiaoHang_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            RptBienBanGH rpt = new RptBienBanGH();
            DataTable data = new DataTable();
            data = dtPhieu.Copy();
            foreach (DataRow dr in data.Rows)
            {
                dr["TenVatTu"] += (hamLuong.ContainsKey(dr["MaVatTu"].ToString()) ? " " + hamLuong[dr["MaVatTu"].ToString()] : "");
            }
            rpt.DataSource = data;
            try
            {
                rpt.xrlblHomNay.Text = "Hôm nay, ngày " + dateNgayNhap.DateTime.Day + " tháng " + dateNgayNhap.DateTime.Month + " năm " + dateNgayNhap.DateTime.Year + ", chúng tôi gồm:";
                rpt.xrlblBenA.Text = lookUpNhaCungCap.Properties.GetDisplayValueByKeyValue(lookUpNhaCungCap.EditValue).ToString().ToUpper();
                rpt.xrlblDiaChiBenA.Text = (lookUpNhaCungCap.Properties.GetRowByKeyValue(lookUpNhaCungCap.EditValue) as DataRowView)["DiaChi"].ToString();
            }
            catch {
                //SplashScreenManager.CloseForm();
            }
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
            SplashScreenManager.CloseForm();
        }

        private void btnBBNghiemThu_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            RptBienBanNT rpt = new RptBienBanNT();
            DataTable data = dtPhieu.Copy();
            foreach (DataRow dr in data.Rows)
            {
                dr["TenVatTu"] += (hamLuong.ContainsKey(dr["MaVatTu"].ToString()) ? " " + hamLuong[dr["MaVatTu"].ToString()] : "");
            }
            rpt.xrlblTenCty.Text ="TÊN CTY: "+ lookUpNhaCungCap.Properties.GetDisplayValueByKeyValue(lookUpNhaCungCap.EditValue).ToString().ToUpper();
            rpt.xrlblNgayThang.Text = "Ngày " + dateNgayNhap.DateTime.Day + " tháng " + dateNgayNhap.DateTime.Month + " năm " + dateNgayNhap.DateTime.Year;
            rpt.xrlblSoHD.Text = txtSoHoaDon.Text;
            rpt.xrlblTRKhoaDuoc.Text = Utils.ToString( nvKhoaDuoc.Rows[0]["HoTen"]);
            rpt.xrlblThuKho.Text = Utils.ToString(nvKhoaDuoc.Rows[1]["HoTen"]);
            rpt.xrlblKeToanDuoc.Text = Utils.ToString(nvKhoaDuoc.Rows[3]["HoTen"]);
            rpt.xrlblKeToan.Text = Utils.ToString(nvKhoaDuoc.Rows[5]["HoTen"]);
            //
            rpt.xrcellTRKhoaDuoc.Text ="3. Ds "+ Utils.ToString(nvKhoaDuoc.Rows[0]["HoTen"]);
            rpt.xrcellThuKho.Text = "5. Ds " + Utils.ToString(nvKhoaDuoc.Rows[1]["HoTen"]);
            rpt.xrcellKeToanDuoc.Text ="4. Ds "+ Utils.ToString(nvKhoaDuoc.Rows[3]["HoTen"]);
            rpt.xrcellKeToan.Text = "6. CN " + Utils.ToString(nvKhoaDuoc.Rows[5]["HoTen"]);
            rpt.DataSource = data;
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
            SplashScreenManager.CloseForm();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // xuất phiếu nhập vào phần mềm kế toán
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            DataRow[] dr = (gridControlPhieu.DataSource as DataTable).Select("Chon = 1", "");
            XuatExcel(dr);
            SplashScreenManager.CloseForm();
        }
        private void XuatExcel(DataRow[] drows)
        {
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
            cl3.NumberFormat = "dd/MM/yyyy";
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
            cl17.Value2 = "MaDTPNCo";
            cl17.ColumnWidth = 30.0;

            Microsoft.Office.Interop.Excel.Range cl18 = oSheet.get_Range("R1", "R1");
            cl18.Value2 = "TenKH";
            cl18.ColumnWidth = 30.0;

            Microsoft.Office.Interop.Excel.Range cl19 = oSheet.get_Range("S1", "S1");
            cl19.Value2 = "SoHoaDon";
            cl19.ColumnWidth = 30.0;

            Microsoft.Office.Interop.Excel.Range cl20 = oSheet.get_Range("T1", "T1");
            cl20.Value2 = "NgayHoaDon";
            cl20.ColumnWidth = 30.0;

            Microsoft.Office.Interop.Excel.Range cl21 = oSheet.get_Range("U1", "U1");
            cl21.Value2 = "ThueSuat";
            cl21.ColumnWidth = 30.0;

            Microsoft.Office.Interop.Excel.Range cl22 = oSheet.get_Range("V1", "V1");
            cl22.Value2 = "VNDTienThue";
            cl22.ColumnWidth = 30.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A1", "V1");
            rowHead.Font.Bold = true;
            rowHead.Font.Color = ConsoleColor.Red;
            rowHead.Interior.Color = 20;
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 18;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[drows.Length * 50, 22];//object[drows.Length * 30, 15];// dataTable.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            int soctu = Utils.ToInt(txtSoCT.Text);
            int dem = 0;
            foreach (DataRow drow in drows)
            {

                DataTable dataTable = nhapkho.DSPhieuVatTu(Utils.ToInt(drow["SoPhieu"]));
                for (int r = 0; r < dataTable.Rows.Count; r++)
                {

                    DataRow dr = dataTable.Rows[r];
                    arr[dem, 0] = "PNKBV";//MaCTu
                    arr[dem, 1] = soctu;// dr[""];//SoCTu
                    arr[dem, 2] = Utils.ToDateTime(drow["NgayNhap"].ToString()).ToString("dd/MM/yy") + "";//NgayCT
                    arr[dem, 3] = drow["NoiDung"] ; //dr[""];//DienGiai
                    arr[dem, 4] = "156" + dr["LoaiVatTu"];// dr[""];//MaTKNo 
                    arr[dem, 5] = "331";//MaTKCo
                    arr[dem, 7] = "";//dr[""];//MaVTHHNo
                    if (maVatTu.ContainsKey(dr["MaBV"].ToString()))
                    {
                        arr[dem, 6] = maVatTu[dr["MaBV"].ToString()];//MaVTHHCo
                    }
                    else
                    {
                        arr[dem, 6] = dr["MaBV"];//MaVTHHCo
                    }
                    arr[dem, 8] = dr["TenVatTu"]  + (hamLuong.ContainsKey(dr["MaBV"].ToString()) ?" "+ hamLuong[dr["MaBV"].ToString()]:"");//TenHangHoa
                    arr[dem, 9] = dr["DonViTinh"];//DonViTinh
                    arr[dem, 10] = dr["SoLuongQuyDoi"];//SoLuong
                    arr[dem, 11] = dr["DonGiaBV"];//VNDDonGia
                    arr[dem, 12] = dr["ThanhTien"];//Utils.ToInt(dr["SoLuongQuyDoi"]) * Utils.ToDecimal(dr["DonGiaBV"]);////VNDThanhTien
                    arr[dem, 13] = drow["NguoiGiaoHang"];//KhachHang
                    arr[dem, 14] = "BV";//drow["NhaCungCap"];// lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();// dr[""];//DiaChi
                    arr[dem, 15] = Utils.ToDateTime(drow["NgayNhap"].ToString()).Month;//
                    arr[dem, 16] = drow["IDNhaCC"];//MaDTPNCo
                    arr[dem, 17] = drow["NhaCungCap"];//TenKH
                    arr[dem, 18] = drow["SoHoaDon"];//SoHoaDon
                    arr[dem, 19] = arr[dem, 2];//NgayHoaDon
                    arr[dem, 20] = 5;// drow["ThueSuat"];//ThueSuat
                    arr[dem, 21] = Math.Round( 0.05m * Utils.ToDecimal(dr["ThanhTien"]));// drow["VNDTienThue"];//VNDTienThue
                    dem++;
                }
                soctu++;
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dem;
            int columnEnd = 22;// dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void btnBBNhapHang_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            RptBienBanNhapKho rpt = new RptBienBanNhapKho();
            string ten = "";
            DataTable data = new DataTable();
            data = dtPhieu.Copy();
            rpt.xrlblTruongKhoaDuoc.Text = "2. Ds "+ Utils.ToString(nvKhoaDuoc.Rows[0]["HoTen"]) + " - TR Khoa Dược";
            rpt.xrlblThuKho.Text = "3. Ds " + Utils.ToString(nvKhoaDuoc.Rows[1]["HoTen"]) + " - Thủ Kho";
            rpt.xrlblNguoiGiao.Text = "4. " + Utils.ToString(nvKhoaDuoc.Rows[4]["HoTen"]) + " - Người Giao";
            rpt.xrlblThongKe.Text = "5. Ds " + Utils.ToString(nvKhoaDuoc.Rows[3]["HoTen"]) + " - Thống Kê";
            foreach (DataRow dr in data.Rows)
            {
                ten += dr["TenVatTu"] + ", ";
                dr["TenVatTu"]  += (hamLuong.ContainsKey(dr["MaVatTu"].ToString()) ? " " + hamLuong[dr["MaVatTu"].ToString()] : "");
            }
            rpt.xrlblNgayIn.Text = "Ngày " + dateNgayNhap.DateTime.Day + " tháng " + dateNgayNhap.DateTime.Month + " năm " + dateNgayNhap.DateTime.Year;
            rpt.xrlblTenHang.Text ="Đã tiến hành nhập thực tế lô hàng: "+ten+ "theo hóa đơn hàng số: "+txtSoHoaDon.Text;
            rpt.xrlblCongKhoan.Text = "Tổng cộng: "+dtPhieu.Rows.Count + " khoản.";
            rpt.xrlblHomNay.Text = "Hôm nay ngày " + dateNgayNhap.DateTime.Day + " tháng " + dateNgayNhap.DateTime.Month + " năm " + dateNgayNhap.DateTime.Year +
                " tại kho thuốc BVĐK cao su Phú Riềng chúng tôi gồm:";
            rpt.xrlblThangNam.Text = "Tháng " + dateNgayNhap.DateTime.Month + " năm " + dateNgayNhap.DateTime.Year;
            rpt.DataSource = data;
            rpt.ShowPreviewDialog();
            SplashScreenManager.CloseForm();
        }
    }
}
