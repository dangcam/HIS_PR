using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DuocPham.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace DuocPham.GUI
{
    public partial class FrmNhapKhoaTra : RibbonForm
    {
        System.Drawing.Font fontB = new System.Drawing.Font ("Times New Roman", 11, System.Drawing.FontStyle.Bold);
        System.Drawing.Font font = new System.Drawing.Font ("Times New Roman", 11);
        NhapKhoEntity nhapkho = new NhapKhoEntity ();
        string quyen = "";
        bool them = false;
        DataTable nvKhoaDuoc;
        public FrmNhapKhoaTra ()
        {
            InitializeComponent ();
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmNhapKhoaTra_Load (object sender, EventArgs e)
        {
            dateTuNgay.DateTime = DateTime.Now;
            dateDenNgay.DateTime = DateTime.Now;
            nvKhoaDuoc = nhapkho.DSNVKhoaDuoc();

            lookUpKhoNhan.Properties.DataSource = nhapkho.DSKho ();
            lookUpKhoNhan.Properties.DisplayMember = "TenKhoa";
            lookUpKhoNhan.Properties.ValueMember = "MaKhoa";
            lookUpKhoNhan.ItemIndex = 0;

            DataTable khoaTra = nhapkho.DSKhoTra();
            lookUpKhoaTra.Properties.DataSource = khoaTra;
            lookUpKhoaTra.Properties.DisplayMember = "TenKhoa";
            lookUpKhoaTra.Properties.ValueMember = "MaKhoa";
            repLookupKhoXuat.DataSource = khoaTra;
            repLookupKhoXuat.DisplayMember = "TenKhoa";
            repLookupKhoXuat.ValueMember = "MaKhoa";

            lookUpMaVatTu.Properties.DisplayMember = "TenVatTu";

            checkButton ();
            LoadData ();
            btnIn.Enabled = false;
        }
        private void LoadData()
        {
            them = false;
            btnLuu.Enabled = false;
            gridControlPhieu.DataSource = nhapkho.DSPhieuTra (dateTuNgay.DateTime, dateDenNgay.DateTime);
        }
        private void checkButton ()
        {
            quyen = Utils.GetQuyen (this.Name);
            Enabled_Them ();
            btnLuu.Enabled = false;

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
        private void txtNguoiTra_Leave (object sender, EventArgs e)
        {
            txtNguoiTra.Text = Utils.VietHoa (txtNguoiTra.Text);
        }

        private void btnThem_Click (object sender, EventArgs e)
        {
            dateNgayNhap.DateTime = DateTime.Now;
            lookUpKhoaTra.EditValue = AppConfig.MaKhoa;
            txtSoPhieu.Text = "0";

            nhapkho.SoPhieu = 0;
            gridControlDS.DataSource = nhapkho.DSPhieuVatTuTra ().AsDataView ();

            txtTKNo.Focus ();
            Enabled_Luu ();
            btnIn.Enabled = false;
            them = true;
        }


        private void lookUpKhoaTra_EditValueChanged (object sender, EventArgs e)
        {
            if(txtTKNo.Text.Length ==4 && lookUpKhoaTra.EditValue !=null)
            {
                lookUpMaVatTu.Properties.DataSource = nhapkho.DSVatTu (txtTKNo.Text.Substring (3, 1),lookUpKhoaTra.EditValue.ToString());
            }
        }

        private void txtSoLuong_KeyPress (object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13 )
            {
                if(lookUpMaVatTu.EditValue !=null && Utils.ToInt (txtSoLuong.Text) > 0)
                {
                    if (gridControlDS.DataSource is DataView && btnLuu.Enabled)
                    {
                        DataRowView drview = (lookUpMaVatTu.GetSelectedDataRow () as DataRowView);
                        DataRow[] drv = (gridViewDS.DataSource as DataView).Table.Select ("MaVatTu = '" + drview["MaVatTu"].ToString ()  + "'");
                        if (drv.Length != 0)
                        {
                            XtraMessageBox.Show ("Vật tư đã được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (Utils.ToInt (txtSoLuong.Text) > Utils.ToInt (drview["SoLuongTon"].ToString ()))
                        {
                            XtraMessageBox.Show ("Số lượng tồn kho không đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DataRowView dr = (gridControlDS.DataSource as DataView).AddNew ();
                        dr["MaVatTu"] = drview["MaVatTu"].ToString ();
                        dr["TenVatTu"] = drview["TenVatTu"].ToString ();
                        //dr["SoDangKy"] = drview["SoDangKy"].ToString ();
                        dr["SoLuong"] = txtSoLuong.Text;
                        //dr["SoLuongQuyDoi"] = txtSoLuong.Text;
                        //dr["SoLuongDung"] = 0;
                        //dr["DonGiaBHYT"] = drview["DonGiaBHYT"].ToString ();
                        dr["DonGia"] = drview["DonGiaBV"].ToString ();
                        //dr["SoLo"] = drview["SoPhieu"].ToString ()+","+drview["SoPhieuNhap"].ToString ();
                        dr["HetHan"] = drview["HetHan"].ToString ();
                        dr["ThanhTien"] = Utils.ToDecimal (txtSoLuong.Text) * Utils.ToDecimal (drview["DonGiaBHYT"].ToString ());
                        dr["LoaiVatTu"] = drview["LoaiVatTu"].ToString ();
                        dr["DonViTinh"] = drview["DonViTinh"].ToString ();
                        dr["SoPhieuXuat"] = drview["SoPhieu"].ToString ();
                        dr["SoPhieuNhap"] = drview["SoPhieuNhap"].ToString ();
                        dr.EndEdit();
                        txtSoLuong.Text = "0";
                        lookUpMaVatTu.Focus();
                    }
                }
                else
                    XtraMessageBox.Show ("Chọn vật tư và nhập số lượng!");
            }
        }
        private bool checkInput ()
        {
            if (txtTKNo.Text.Length == 0)
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
            if (!checkInput ())
            {
                return;
            }
            DialogResult traloi;
            traloi = XtraMessageBox.Show("Chắc chắn bạn muốn lưu?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                string err = "";
                nhapkho.SoPhieu = Utils.ToInt(txtSoPhieu.Text);
                nhapkho.SoHoaDon = null;
                nhapkho.TKNo = txtTKNo.Text;
                nhapkho.NgayNhap = dateNgayNhap.DateTime;
                nhapkho.NhaCungCap = (lookUpKhoaTra.EditValue).ToString();
                nhapkho.NguoiGiaoHang = txtNguoiTra.Text;
                nhapkho.KhoNhap = lookUpKhoNhan.EditValue.ToString();
                nhapkho.NguoiNhan = AppConfig.MaNV;
                nhapkho.NoiDung = txtNoiDung.Text;

                nhapkho.NgayCapNhat = DateTime.Now;
                err = "";
                if (them)
                {
                    nhapkho.NguoiTao = AppConfig.MaNV;
                    if (nhapkho.SpPhieuTra(ref err, "INSERT"))
                    {
                        txtSoPhieu.Text = nhapkho.SoPhieu.ToString();
                        LuuVatTu();
                        LoadData();
                    }
                }
                if (!string.IsNullOrEmpty(err))
                {
                    XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnIn.Enabled = true;
            }
        }
        private void LuuVatTu ()
        {
            DataView data = (gridControlDS.DataSource as DataView);
            string err = "";
            foreach (DataRowView dr in data)
            {
                err = "";
                nhapkho.MaVatTu = dr["MaVatTu"].ToString ();
                //nhapkho.SoDangKy = dr["SoDangKy"].ToString ();
                nhapkho.SoLuong = Utils.ToInt (dr["SoLuong"].ToString ());
                //nhapkho.SoLuongQuyDoi = Utils.ToInt (dr["SoLuongQuyDoi"].ToString ());
                //nhapkho.SoLuongDung = Utils.ToInt (dr["SoLuongDung"].ToString ());
                //nhapkho.DonGiaBHYT = Utils.ToDecimal (dr["DonGiaBHYT"].ToString ());
                nhapkho.DonGiaBV = Utils.ToDecimal (dr["DonGia"].ToString ());
                //nhapkho.SoLo = dr["SoLo"].ToString ();
                nhapkho.HetHan = DateTime.Parse (dr["HetHan"].ToString ());
                nhapkho.ThanhTien = Utils.ToDecimal (dr["ThanhTien"].ToString ());
                nhapkho.LoaiVatTu = dr["LoaiVatTu"].ToString ();
                nhapkho.SoPhieuNhap = Utils.ToInt (dr["SoPhieuNhap"].ToString ());
                nhapkho.SoPhieuXuat = Utils.ToInt (dr["SoPhieuXuat"].ToString ());
                if (them)
                {
                    nhapkho.SpPhieuChiTietTra (ref err, "INSERT");
                }
                if (!string.IsNullOrEmpty (err))
                {
                    XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnIn_Click (object sender, EventArgs e)
        {
            inPhieuTra ();
        }

        private void btnXoaVatTu_ButtonClick (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (them)
            {
                (gridControlDS.DataSource as DataView).Delete (gridViewDS.GetFocusedDataSourceRowIndex ());
            }
        }

        private void btnTim_Click (object sender, EventArgs e)
        {
            gridControlPhieu.DataSource = nhapkho.DSPhieuTra (dateTuNgay.DateTime, dateDenNgay.DateTime);
        }
        private void inPhieuTra ()
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            RptPhieuTra rpt = new RptPhieuTra();
            rpt.xrlblSoPhieu.Text = txtSoPhieu.Text;
            rpt.xrlblNgayIn.Text = "Ngày " + dateNgayNhap.DateTime.Day + " tháng "
                + dateNgayNhap.DateTime.Month + " năm " + dateNgayNhap.DateTime.Year;
            rpt.xrlblNgayThangNam.Text = rpt.xrlblNgayIn.Text;
            rpt.xrlblNoiDung.Text = "Nội dung: "+ txtNoiDung.Text;
            rpt.xrlblKhoa.Text = lookUpKhoaTra.Properties.GetDisplayValueByKeyValue(lookUpKhoaTra.EditValue).ToString();
            rpt.xrlblNguoiLinh.Text = Utils.ToString(nvKhoaDuoc.Rows[1]["HoTen"]);
            rpt.xrlblNguoiTra.Text = txtNguoiTra.Text;
            rpt.DataSource = (gridControlDS.DataSource as DataView);
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();

            SplashScreenManager.CloseForm();
            //RptPhieuNhapKho rpt = new RptPhieuNhapKho ();
            //rpt.lblSoPhieu.Text = txtSoPhieu.Text;
            //rpt.lblTKNo.Text = "";
            //rpt.lblTKCo.Text = "331";
            //rpt.lblNgayNhap.Text = "Ngày " + dateNgayNhap.DateTime.Day + " tháng "
            //    + dateNgayNhap.DateTime.Month + " năm " + dateNgayNhap.DateTime.Year;
            //rpt.lblNguoiGiaoHang.Text = txtNguoiTra.Text;
            //rpt.lblNhaCungCap.Text = lookUpKhoaTra.Properties.GetDisplayValueByKeyValue (lookUpKhoaTra.EditValue).ToString ();
            //rpt.lblNoiDungNhap.Text = txtNoiDung.Text;
            //rpt.lblNhapKho.Text = lookUpKhoNhan.Properties.GetDisplayValueByKeyValue (lookUpKhoNhan.EditValue).ToString ();
            //rpt.xrlblNgayIn.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

            //XRTableRow row;
            //XRTableCell cell;
            //int stt = 0;
            //decimal thanhTien = 0;
            //foreach (DataRowView drview in (gridViewDS.DataSource as DataView))
            //{
            //    row = new XRTableRow ();

            //    cell = new XRTableCell ();
            //    cell.Text = stt.ToString ();
            //    cell.Font = font;
            //    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //    cell.WidthF = 40;
            //    row.Cells.Add (cell);

            //    cell = new XRTableCell ();
            //    cell.Text = drview["MaVatTu"].ToString ();
            //    cell.Font = font;
            //    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //    cell.WidthF = 100;
            //    row.Cells.Add (cell);

            //    cell = new XRTableCell ();
            //    cell.Text = drview["TenVatTu"].ToString ();
            //    cell.Font = font;
            //    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //    cell.WidthF = 280;
            //    row.Cells.Add (cell);

            //    cell = new XRTableCell ();
            //    cell.Text = drview["DonViTinh"].ToString ();
            //    cell.Font = font;
            //    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //    cell.WidthF = 100;
            //    row.Cells.Add (cell);

            //    cell = new XRTableCell ();
            //    cell.Text = Utils.ToString (drview["SoLuong"].ToString ());
            //    cell.Font = font;
            //    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //    cell.WidthF = 70;
            //    row.Cells.Add (cell);

            //    cell = new XRTableCell ();
            //    cell.Text = Utils.ToString (drview["DonGia"].ToString ());
            //    cell.Font = font;
            //    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //    cell.WidthF = 80;
            //    row.Cells.Add (cell);

            //    thanhTien += Utils.ToDecimal (drview["ThanhTien"].ToString ());
            //    cell = new XRTableCell ();
            //    cell.Text = Utils.ToString (drview["ThanhTien"].ToString ());
            //    cell.Font = font;
            //    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //    cell.WidthF = 96;
            //    row.Cells.Add (cell);

            //    stt++;
            //    rpt.xrTable.Rows.Add (row);
            //}
            //row = new XRTableRow ();
            //cell = new XRTableCell ();
            //cell.Text = "Tổng cộng";
            //cell.Font = font;
            //cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //cell.WidthF = 670;
            //row.Cells.Add (cell);

            //cell = new XRTableCell ();
            //cell.Text = Utils.ToString (thanhTien);
            //cell.Font = fontB;
            //cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //cell.WidthF = 96;
            //row.Cells.Add (cell);
            //rpt.xrTable.Rows.Add (row);

            //rpt.lblTongTien.Text = Utils.ChuyenSo (thanhTien.ToString ().Replace(',','.').Split('.')[0]);
            //rpt.lblTKNo.Text = txtTKNo.Text;


            //rpt.CreateDocument ();
            //rpt.ShowPreviewDialog ();
        }

        private void gridViewPhieu_RowClick (object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridViewPhieu.GetDataRow (e.RowHandle);
            if (dr != null)
            {
                txtTKNo.Text = dr["TKNo"].ToString ();
                dateNgayNhap.DateTime = DateTime.Parse (dr["NgayXuat"].ToString ());
                lookUpKhoaTra.EditValue = dr["KhoXuat"];
                txtNguoiTra.Text = dr["NguoiTra"].ToString ();
                lookUpKhoNhan.EditValue = dr["KhoNhan"].ToString ();
                txtNoiDung.Text = dr["NoiDung"].ToString ();
                txtSoPhieu.Text = dr["SoPhieu"].ToString ();

                nhapkho.NguoiTao = dr["MaNV"].ToString ();

                them = false;
                // danh sách
                lookUpMaVatTu.Properties.DataSource = nhapkho.DSVatTu (txtTKNo.Text.Substring (3, 1));
                nhapkho.SoPhieu = int.Parse (txtSoPhieu.Text);

                gridControlDS.DataSource = nhapkho.DSPhieuVatTuTra ().AsDataView ();
                btnIn.Enabled = true;
            }
        }

        private void txtTKNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtNguoiTra.Focus();
            }
        }

        private void txtNguoiTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtNoiDung.Focus();
            }
        }

        private void txtNoiDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                lookUpMaVatTu.Focus();
            }
        }

        private void lookUpMaVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtSoLuong.Focus();
            }
        }
    }
}
