﻿using DevExpress.XtraBars.Ribbon;
using DuocPham.DAL;
using System;
using System.Windows.Forms;
using Core.DAL;
using DevExpress.XtraEditors;
using System.Data;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using System.Globalization;

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
        Dictionary<string, bool> dsVatTu = new Dictionary<string, bool> ();
        SortedSet<string> dsLoaiVatTu = new SortedSet<string> ();
        decimal thanhTien = 0;
        CultureInfo elGR = CultureInfo.CreateSpecificCulture ("el-GR");
        System.Drawing.Font fontB = new System.Drawing.Font ("Times New Roman", 11, System.Drawing.FontStyle.Bold);
        System.Drawing.Font font = new System.Drawing.Font ("Times New Roman", 11);
        public FrmNhapKho ()
        {
            InitializeComponent ();
            nhapkho = new NhapKhoEntity ();
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmNhapKho_Load (object sender, EventArgs e)
        {
            lookUpKhoNhap.Properties.DataSource = nhapkho.DSKho ();
            lookUpKhoNhap.Properties.DisplayMember = "TenKhoa";
            lookUpKhoNhap.Properties.ValueMember = "MaKhoa";

            lookUpNhaCungCap.Properties.DataSource = nhapkho.DSNhaCungCap ();
            lookUpNhaCungCap.Properties.DisplayMember = "Ten";
            lookUpNhaCungCap.Properties.ValueMember = "Ten";

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
        }
        private void LoadData ()
        {
            them = false;

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

            txtSoPhieu.Text = "0";
            txtSoHoaDon.Text = "";
            txtTKNo.Text = "";
            cbLoaiThau.SelectedIndex = 0;
            txtNhomThau.Text = "";
            dateNgayNhap.EditValue = DateTime.Now;
            lookUpNhaCungCap.EditValue = "";
            txtNguoiGiaoHang.Text = "";
            lookUpKhoNhap.EditValue = "";
            lookUpNguoiNhan.EditValue = "";
            txtNoiDung.Text = "";

            nhapkho.SoPhieu = 0;
            dtPhieu = nhapkho.DSPhieuVatTu ();
            gridControlDS.DataSource = dtPhieu.AsDataView();
            dsVatTu.Clear ();

            txtTKNo.Focus ();
            Enabled_Luu ();
            btnIn.Enabled = false;
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
            nhapkho.LoaiThau = cbLoaiThau.SelectedIndex;
            nhapkho.NhomThau = txtNhomThau.Text;
            nhapkho.NgayNhap = dateNgayNhap.DateTime;
            nhapkho.NhaCungCap = lookUpNhaCungCap.EditValue.ToString ();
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
        }
        private void LuuVatTu()
        {
            data = (gridControlDS.DataSource as DataView);

            foreach(DataRowView dr in data)
            {
                err = "";
                nhapkho.MaVatTu = dr["MaVatTu"].ToString ();
                nhapkho.QuyCach = dr["QuyCach"].ToString ();
                nhapkho.SoLuong = int.Parse(dr["SoLuong"].ToString ());
                nhapkho.SoLuongQuyDoi = int.Parse (dr["SoLuongQuyDoi"].ToString ());
                nhapkho.SoLuongDung = int.Parse (dr["SoLuongDung"].ToString ());
                nhapkho.DonGiaBHYT = decimal.Parse (dr["DonGiaBHYT"].ToString ());
                nhapkho.DonGiaBV = decimal.Parse (dr["DonGiaBV"].ToString ());
                nhapkho.SoLo = dr["SoLo"].ToString ();
                nhapkho.HetHan = DateTime.Parse (dr["HetHan"].ToString ());
                nhapkho.ThanhTien = decimal.Parse (dr["ThanhTien"].ToString ());
                if(them)
                {
                    dsVatTu.Add (nhapkho.MaVatTu, false);
                    nhapkho.SpPhieuNhapChiTiet (ref err, "INSERT");
                }
                else
                {
                    if(dsVatTu.ContainsKey(nhapkho.MaVatTu))
                    {
                        dsVatTu[nhapkho.MaVatTu] = true;
                        nhapkho.SpPhieuNhapChiTiet (ref err, "UPDATE");
                    }
                    else
                    {
                        dsVatTu.Add (nhapkho.MaVatTu, true);
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
                        nhapkho.MaVatTu = key;
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
                    MessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtTenVatTu.Text = (lookUpMaVatTu.Properties.GetRowByKeyValue (lookUpMaVatTu.EditValue)  as DataRowView)[1].ToString ();
            }
        }

        private void txtTyLe_Leave (object sender, EventArgs e)
        {
            if(txtSoLuong.Text.Length > 0 && txtTyLe.Text.Length >0)
            {
                txtSoLuongQD.Text = int.Parse (txtSoLuong.Text.Replace (",", "")) * int.Parse (txtTyLe.Text.Replace(",","")) + "";
            }
        }

        private void txtGiaBHYT_Leave (object sender, EventArgs e)
        {
            txtGiaBV.Text = txtGiaBHYT.Text.Replace(",","");
            if(txtGiaBHYT.Text.Length>0&&txtSoLuongQD.Text.Length>0)
            {
                txtThanhTien.Text = int.Parse (txtGiaBHYT.Text.Replace (",", "")) * int.Parse (txtSoLuongQD.Text.Replace (",", "")) + "";
            }
        }

        private void txtThanhTien_KeyPress (object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (lookUpMaVatTu.EditValue == null)
                {
                    XtraMessageBox.Show ("Chưa chọn mã vật tư!");
                    lookUpMaVatTu.Focus ();
                    return;
                }
                if (txtSoLuongQD.Text.Length == 0)
                {
                    XtraMessageBox.Show ("Nhập số lượng!");
                    txtSoLuongQD.Focus ();
                    return;
                }
                if (txtGiaBHYT.Text.Length == 0)
                {
                    XtraMessageBox.Show ("Nhập đơn giá!");
                    txtGiaBHYT.Focus ();
                    return;
                }
                if (dateHetHan.DateTime < DateTime.Now)
                {
                    XtraMessageBox.Show ("Hạn dùng phải lớn hơn ngày hiện tại!");
                    dateHetHan.Focus ();
                    return;
                }
                if (txtSoLuong.Text.Length == 0)
                {
                    txtSoLuong.Text = "0";
                }
                if (gridControlDS.DataSource is DataView && btnLuu.Enabled)
                {
                    DataRow[] drv = (gridViewDS.DataSource as DataView).Table.Select ("MaVatTu = '" + lookUpMaVatTu.EditValue.ToString () + "'");
                    if (drv.Length != 0)
                    {
                        XtraMessageBox.Show ("Vật tư đã được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataRowView dr = (gridControlDS.DataSource as DataView).AddNew ();
                    dr["MaVatTu"] = lookUpMaVatTu.EditValue;
                    dr["TenVatTu"] = txtTenVatTu.Text;
                    dr["QuyCach"] = txtQuyCach.Text;
                    dr["SoLuong"] = txtSoLuong.Text;
                    dr["SoLuongQuyDoi"] = txtSoLuongQD.Text;
                    dr["SoLuongDung"] = 0;
                    dr["DonGiaBHYT"] = txtGiaBHYT.Text;
                    dr["DonGiaBV"] = txtGiaBV.Text;
                    dr["SoLo"] = txtSoLo.Text;
                    dr["HetHan"] = dateHetHan.DateTime;
                    dr["ThanhTien"] = txtThanhTien.Text;
                    dr["LoaiVatTu"] = txtTKNo.Text.Substring (3, 1);

                    lookUpMaVatTu.EditValue = null;
                    txtTenVatTu.Text = "";
                    txtQuyCach.Text = "";
                    txtSoLuong.Text = "0";
                    txtSoLuongQD.Text = "0";
                    txtGiaBHYT.Text = "0";
                    txtGiaBV.Text = "0";
                    txtSoLo.Text = "0";
                    dateHetHan.EditValue = null;
                    txtThanhTien.Text = "0";
                }
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
                    XtraMessageBox.Show("Không thể chỉnh sửa số lượng nhập kho < số lượng vật tư đã sử dụng!","Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    soLuong = soLuongDung;
                    gridViewDS.SetFocusedRowCellValue ("SoLuongQuyDoi", soLuong);
                }
                var donGia = gridViewDS.GetRowCellValue (e.RowHandle, gridViewDS.Columns["DonGiaBHYT"]);
                gridViewDS.SetFocusedRowCellValue ("ThanhTien",soLuong * Convert.ToDecimal( donGia));
                this.gridViewDS.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler (this.gridViewDS_CellValueChanged);
            }
            if(e.Column.FieldName == "DonGiaBHYT")
            {
                this.gridViewDS.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler (this.gridViewDS_CellValueChanged);
                var soLuong = gridViewDS.GetRowCellValue (e.RowHandle, gridViewDS.Columns["DonGiaBHYT"]);
                var donGia = e.Value;
                gridViewDS.SetFocusedRowCellValue ("ThanhTien", Convert.ToDecimal (soLuong) * Convert.ToDecimal (donGia));
                this.gridViewDS.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler (this.gridViewDS_CellValueChanged);
            }
        }

        private void btnXoaVatu_ButtonClick (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (them)
            {
                (gridControlDS.DataSource as DataView).Delete (gridViewDS.GetFocusedDataSourceRowIndex ());
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
                cbLoaiThau.SelectedIndex = int.Parse (dr["LoaiThau"].ToString ());
                txtNhomThau.Text = dr["NhomThau"].ToString ();
                dateNgayNhap.EditValue = DateTime.Parse(dr["NgayNhap"].ToString ()).ToShortDateString();
                lookUpNhaCungCap.EditValue = dr["NhaCungCap"].ToString ();
                txtNguoiGiaoHang.Text = dr["NguoiGiaoHang"].ToString ();
                lookUpKhoNhap.EditValue = dr["KhoNhap"].ToString ();
                lookUpNguoiNhan.EditValue = dr["NguoiNhan"].ToString ();
                txtNoiDung.Text = dr["NoiDung"].ToString ();
                txtSoPhieu.Text = dr["SoPhieu"].ToString ();

                nhapkho.NguoiTao = dr["NguoiTao"].ToString ();

                them = false;
                Enabled_Xoa ();
                Enabled_Luu ();
                // danh sách
                lookUpMaVatTu.Properties.DataSource = nhapkho.DSVatTu (txtTKNo.Text.Substring (3, 1));
                nhapkho.SoPhieu = int.Parse (txtSoPhieu.Text);
                dtPhieu = nhapkho.DSPhieuVatTu ();
                dsVatTu.Clear ();
                foreach(DataRow drow in dtPhieu.Rows)
                {
                    dsVatTu.Add (drow["MaVatTu"].ToString (), false);
                    drow["TenVatTu"] = (lookUpMaVatTu.Properties.GetRowByKeyValue (drow["MaVatTu"].ToString ()) as DataRowView)[1];
                }
                gridControlDS.DataSource = dtPhieu.AsDataView ();
                btnIn.Enabled = true;
            }

        }

        private void txtTKNo_EditValueChanged (object sender, EventArgs e)
        {
            if (txtTKNo.Text.Length == 4)
            {
                lookUpMaVatTu.Properties.DataSource = nhapkho.DSVatTu (txtTKNo.Text.Substring (3, 1));
            }
        }

        private void txtNguoiGiaoHang_Leave (object sender, EventArgs e)
        {
            txtNguoiGiaoHang.Text = Utils.VietHoa (txtNguoiGiaoHang.Text);
        }
        private void inPhieuNhap()
        {
            RptPhieuNhapKho rpt = new RptPhieuNhapKho ();
            rpt.lblSoPhieu.Text = txtSoPhieu.Text;
            rpt.lblTKNo.Text = txtTKNo.Text;
            rpt.lblTKCo.Text = "331";
            rpt.lblNgayNhap.Text = "Ngày "+dateNgayNhap.DateTime.Day+" tháng "
                +dateNgayNhap.DateTime.Month+" năm "+dateNgayNhap.DateTime.Year;
            rpt.lblNguoiGiaoHang.Text = txtNguoiGiaoHang.Text;
            rpt.lblNhaCungCap.Text = lookUpNhaCungCap.EditValue.ToString()+ ". Hóa đơn số: "+txtSoHoaDon.Text;
            rpt.lblNoiDungNhap.Text = txtNoiDung.Text;
            rpt.lblNhapKho.Text = lookUpKhoNhap.Properties.GetDisplayValueByKeyValue(lookUpKhoNhap.EditValue).ToString();
            rpt.lblNgayIn.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

            this.thanhTien = 0;
            dsLoaiVatTu.Clear ();
            XRTableRow row;
            XRTableCell cell;
            int stt = 0;
            foreach(DataRowView drview in (gridViewDS.DataSource as DataView))
            {
                row = new XRTableRow ();

                cell = new XRTableCell ();
                cell.Text = stt.ToString();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.WidthF = 40;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = drview["MaVatTu"].ToString();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 100;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = drview["TenVatTu"].ToString ();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 300;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = (lookUpMaVatTu.Properties.GetRowByKeyValue (drview["MaVatTu"].ToString ()) as DataRowView)[2].ToString ();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 70;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = decimal.Parse (drview["SoLuongQuyDoi"].ToString ()).ToString ("0,0", elGR);
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 80;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = decimal.Parse( drview["DonGiaBHYT"].ToString ()).ToString("0,0",elGR);
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 80;
                row.Cells.Add (cell);

                this.thanhTien += decimal.Parse (drview["ThanhTien"].ToString ());
                cell = new XRTableCell ();
                cell.Text = decimal.Parse (drview["ThanhTien"].ToString ()).ToString ("0,0",elGR);
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 96;
                row.Cells.Add (cell);

                stt++;
                rpt.xrTable.Rows.Add (row);
                dsLoaiVatTu.Add (drview["LoaiVatTu"].ToString ());
            }
            row = new XRTableRow ();
            cell = new XRTableCell ();
            cell.Text = "Tổng cộng";
            cell.Font = font;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.WidthF = 670;
            row.Cells.Add (cell);

            cell = new XRTableCell ();
            cell.Text = this.thanhTien.ToString ("0,0", elGR);
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.WidthF = 96;
            row.Cells.Add (cell);
            rpt.xrTable.Rows.Add (row);

            rpt.lblTongTien.Text = Utils.ChuyenSo (this.thanhTien.ToString ());
            rpt.lblTKNo.Text = "";
            foreach(string loai in dsLoaiVatTu)
            {
                rpt.lblTKNo.Text += "156" + loai +" ";
            }

            rpt.CreateDocument ();
            rpt.ShowPreviewDialog ();
        }
    }
}
