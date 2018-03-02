using DevExpress.XtraBars.Ribbon;
using DuocPham.DAL;
using System;
using System.Windows.Forms;
using Core.DAL;
using DevExpress.XtraEditors;
using System.Data;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

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
        Dictionary<string, bool> dsVatTu = new Dictionary<string, bool> ();
        SortedSet<string> dsLoaiVatTu = new SortedSet<string> ();
        decimal thanhTien = 0;
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
            dtVatTu = nhapkho.DSVatTu();

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
            dateNgayNhap.EditValue = DateTime.Now;
            lookUpNhaCungCap.EditValue = "";
            txtNguoiGiaoHang.Text = "Lý Văn Thép";
            lookUpKhoNhap.EditValue = "";
            lookUpNguoiNhan.EditValue = "";
            txtNoiDung.Text = "";

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
                DataRowView dr = (gridControlDS.DataSource as DataView).AddNew();
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
                dateNgayNhap.DateTime = DateTime.Parse (dr["NgayNhap"].ToString ());
                lookUpNhaCungCap.EditValue = dr["IDNhaCC"].ToString ();
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
                    //(lookUpMaVatTu.Properties.GetRowByKeyValue (drow["MaVatTu"].ToString ()) as DataRowView)[1];
                    // lấy tên vật tư từ mã vật tư, từ lookUpMaVatTu (thay bằng data vật tư) dataVatTu.Select
                }
                gridControlDS.DataSource = dtPhieu.AsDataView ();
                txtTongTien.EditValue = Utils.ToDecimal((dtPhieu.Compute("SUM(ThanhTien)", "")));
                btnIn.Enabled = true;
                btnBBGiaoHang.Enabled = true;
                btnBBNghiemThu.Enabled = true;
            }

        }

        private void txtTKNo_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTKNo.Text.Length > 3)
            {
                try
                {
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
            rpt.lblSoPhieu.Text = txtSoPhieu.Text;
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
            rpt.lblNoiDungNhap.Text = txtNoiDung.Text;//Nhập thuốc tháng 7 cty Bình Phú
            rpt.lblNhapKho.Text = lookUpKhoNhap.Properties.GetDisplayValueByKeyValue(lookUpKhoNhap.EditValue).ToString();
            rpt.lblNgayIn.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

            this.thanhTien = 0;
            dsLoaiVatTu.Clear ();
            XRTableRow row;
            XRTableCell cell;
            int stt = 1;
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
                cell.Text = dtVatTu.Select("MaBV = '" + drview["MaVatTu"].ToString() + "'")[0][2].ToString();
                //(lookUpMaVatTu.Properties.GetRowByKeyValue (drview["MaVatTu"].ToString ()) as DataRowView)[2].ToString ();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 70;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = Utils.ToString (drview["SoLuongQuyDoi"].ToString ());
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 80;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = Utils.ToString (drview["DonGiaBV"].ToString (),null, "0,0.00");
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 80;
                row.Cells.Add (cell);

                this.thanhTien += Utils.ToDecimal (drview["ThanhTien"].ToString ());
                cell = new XRTableCell ();
                cell.Text = Utils.ToString (drview["ThanhTien"].ToString (),null, "0,0");
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
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.WidthF = 670;
            row.Cells.Add (cell);

            cell = new XRTableCell ();
            cell.Text = Utils.ToString (this.thanhTien);
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.WidthF = 96;
            row.Cells.Add (cell);
            rpt.xrTable.Rows.Add (row);

            rpt.lblTongTien.Text = Utils.ChuyenSo (this.thanhTien.ToString ().Split('.')[0]);
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
            rpt.DataSource = dtPhieu;
            try
            {
                rpt.xrlblHomNay.Text = "Hôm nay, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + ", chúng tôi gồm:";
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
            rpt.xrlblTenCty.Text ="TÊN CTY: "+ lookUpNhaCungCap.Properties.GetDisplayValueByKeyValue(lookUpNhaCungCap.EditValue).ToString().ToUpper();
            rpt.xrlblNgayThang.Text = "Ngày "+DateTime.Now.Day+" tháng "+DateTime.Now.Month+" năm "+DateTime.Now.Year;
            rpt.xrlblSoHD.Text = txtSoHoaDon.Text;

            rpt.DataSource = dtPhieu;
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
            SplashScreenManager.CloseForm();
        }
    }
}
