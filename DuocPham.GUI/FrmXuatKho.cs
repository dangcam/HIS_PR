using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DuocPham.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuocPham.GUI
{
    public partial class FrmXuatKho : RibbonForm
    {
        //Dictionary<string, bool> dsVatTu = new Dictionary<string, bool> ();
        XuatKhoEntity xuatkho;
        bool them = false;
        string quyen = "";
        DataRow dr;
        DataView dtPhieu;
        DataTable dataPhieu;
        SortedSet<string> dsLoaiVatTu = new SortedSet<string> ();
        decimal thanhTien = 0;
        CultureInfo elGR = CultureInfo.CreateSpecificCulture ("el-GR");
        System.Drawing.Font fontB = new System.Drawing.Font ("Times New Roman", 11, System.Drawing.FontStyle.Bold);
        System.Drawing.Font font = new System.Drawing.Font ("Times New Roman", 11);
        Dictionary<string, string> maVatTu = new Dictionary<string, string>();
        DataTable dataKhoLe, dataNhaCC;
        Dictionary<string, bool> dsVatTu = new Dictionary<string, bool>();
        public FrmXuatKho ()
        {
            InitializeComponent ();
            xuatkho = new XuatKhoEntity ();
            maVatTu = xuatkho.DSMaVatTu().AsEnumerable().ToDictionary(row => row["MaBV"].ToString(), row => row["MaCu"].ToString());
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmXuatKho_Load(object sender, EventArgs e)
        {

            dataNhaCC = xuatkho.DSTraNhaCungCap();

            dataKhoLe = xuatkho.DSKhoNhan();

            lookUpKhoXuat.Properties.DataSource = xuatkho.DSKhoXuat();
            lookUpKhoXuat.Properties.ValueMember = "MaKhoa";
            lookUpKhoXuat.Properties.DisplayMember = "TenKhoa";
            lookUpKhoXuat.EditValue = "70013";

            repLookUpEditKhoNhan.DataSource = dataKhoLe;
            repLookUpEditKhoNhan.ValueMember = "MaKhoa";
            repLookUpEditKhoNhan.DisplayMember = "TenKhoa";

            lookUpKhoNhan.Properties.DataSource = xuatkho.DSKhoNhan();
            lookUpKhoNhan.Properties.ValueMember = "MaKhoa";
            lookUpKhoNhan.Properties.DisplayMember = "TenKhoa";

            lookUpMaVatTu.Properties.DisplayMember = "TenVatTu";

            dateTuNgay.EditValue = DateTime.Now;
            dateDenNgay.EditValue = DateTime.Now;

            checkButton();
            LoadData();
            btnIn.Enabled = false;
        }
        private void LoadData ()
        {
            them = false;
            btnLuu.Enabled = false;
            dataPhieu = xuatkho.DSPhieu(dateTuNgay.DateTime, dateDenNgay.DateTime);
            gridControl.DataSource = dataPhieu;
        }
        private void checkButton ()
        {
            quyen = Utils.GetQuyen (this.Name);
            Enabled_Them ();
            //btnXoa.Enabled = false;
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
                //btnXoa.Enabled = true;
            }
            else
            {
                //btnXoa.Enabled = false;
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
        private void txtTKCo_EditValueChanged (object sender, EventArgs e)
        {
            if(txtTKCo.Text.Length>3)
            {
                //xuatkho.TKCo = txtTKCo.Text;
                xuatkho.KhoXuat = lookUpKhoXuat.EditValue.ToString ();
                lookUpMaVatTu.Properties.DataSource = xuatkho.DSVatTu (txtTKCo.Text.Substring (3, txtTKCo.Text.Length-3));
            }
        }

        private void txtSoLuong_KeyPress (object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if(txtSoLuong.Text.Length == 0 || txtSoLuong.Text == "0")
                {
                    XtraMessageBox.Show ("Nhập số lượng!");
                    txtSoLuong.Focus ();
                    e.Handled = true;
                }
                if (gridControlDS.DataSource is DataView && btnLuu.Enabled)
                {
                    DataRowView drview = (lookUpMaVatTu.GetSelectedDataRow () as DataRowView);
                    DataRow[] drv = dtPhieu.Table.Select ("MaVatTu = '" + drview["MaVatTu"].ToString ()
                        + "' and SoPhieuNhap = '" + drview["SoPhieu"].ToString () + "'");
                    if (drv.Length != 0)
                    {
                        XtraMessageBox.Show ("Vật tư đã được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Utils.ToInt (txtSoLuong.Text) > Utils.ToInt (drview["SoLuongTon"].ToString()))
                    {
                        XtraMessageBox.Show ("Số lượng tồn kho không đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataRowView dr = dtPhieu.AddNew ();
                    dr["SoPhieuNhap"] = drview["SoPhieu"].ToString ();
                    dr["MaVatTu"] = drview["MaVatTu"].ToString ();
                    dr["TenVatTu"] = drview["TenVatTu"].ToString();
                    dr["SoDangKy"] = drview["SoDangKy"].ToString ();
                    dr["SoLuong"] = Utils.ToInt(txtSoLuong.Text);
                    dr["SoLuongDung"] = 0;
                    dr["DonGiaBHYT"] = Utils.ToDecimal( drview["DonGiaBHYT"]);
                    dr["DonGiaBV"] =Utils.ToDecimal( drview["DonGiaBV"]);
                    dr["HetHan"] = drview["HetHan"].ToString ();
                    if (checkGiaBV.Checked|| Utils.ToDecimal(drview["DonGiaBHYT"])==0)
                    {
                        dr["ThanhTien"] = Utils.ToDecimal(txtSoLuong.Text) * Utils.ToDecimal(drview["DonGiaBV"]);
                    }
                    else
                    {
                        dr["ThanhTien"] = Utils.ToDecimal(txtSoLuong.Text) * Utils.ToDecimal(drview["DonGiaBHYT"]);
                    }
                    dr["LoaiVatTu"] = drview["LoaiVatTu"].ToString ();
                    dr["DonViTinh"] = drview["DonViTinh"].ToString ();
                    dr.EndEdit();
                    if (them == false)
                    {
                        // chèn thêm vật tư
                        dsVatTu.Add(drview["SoPhieu"] + "|" + drview["MaVatTu"], true);
                    }
                    lookUpMaVatTu.EditValue = null;
                    txtSoLuong.Text = "";
                    lookUpMaVatTu.Focus();
                }
            }
        }

        private void btnThem_Click (object sender, EventArgs e)
        {
            them = true;
            dsVatTu.Clear();
            checkGiaBV.Checked = true;
            txtSoPhieu.Text = "0";
            txtTKCo.Text = "";
            dateNgayXuat.EditValue = DateTime.Now;
            lookUpKhoNhan.EditValue = "";
            txtNguoiNhan.Text = "";
            txtNoiDung.Text = "";

            xuatkho.SoPhieu = 0;
            dtPhieu = xuatkho.DSPhieuVatTu ().AsDataView();
            gridControlDS.DataSource = dtPhieu;
            //dsVatTu.Clear ();

            txtTKCo.Focus ();
            Enabled_Luu ();
            btnIn.Enabled = false;
        }
        private bool checkInput ()
        {
            if (lookUpKhoXuat.EditValue == null)
            {
                lookUpKhoXuat.Focus ();
                XtraMessageBox.Show ("Chưa chọn kho xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (lookUpKhoNhan.EditValue ==null)
            {
                lookUpKhoNhan.Focus ();
                XtraMessageBox.Show ("Chưa chọn kho nhận!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            traloi = XtraMessageBox.Show ("Chắc chắn bạn muốn lưu, những thông tin này sẽ không được chỉnh sửa?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                xuatkho.SoPhieu = Utils.ToInt (txtSoPhieu.Text);
                xuatkho.TKCo = txtTKCo.Text;

                xuatkho.NgayXuat = dateNgayXuat.DateTime;
                xuatkho.PheDuyet = true;
                xuatkho.KhoXuat = lookUpKhoXuat.EditValue.ToString ();
                xuatkho.KhoNhan = lookUpKhoNhan.EditValue.ToString ();
                xuatkho.NguoiNhan = txtNguoiNhan.Text;
                xuatkho.NoiDung = txtNoiDung.Text;
                xuatkho.NgayCapNhat = DateTime.Now;
                string err = "";
                if (them)
                {
                    xuatkho.NguoiTao = AppConfig.MaNV;
                    if (xuatkho.SpThemPhieuXuat (ref err))
                    {
                        txtSoPhieu.Text = xuatkho.SoPhieu.ToString ();
                        LuuVatTu ();
                        LoadData ();
                    }
                }
                else
                {
                    // cập nhật giá
                    xuatkho.NguoiCapNhat = AppConfig.MaNV;
                    LuuVatTu();
                }
                if (!string.IsNullOrEmpty (err))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //btnIn.Enabled = true;
                them = false;
                dsVatTu.Clear();
            }
        }
        private void LuuVatTu()
        {
            DataView dv = (gridControlDS.DataSource as DataView);
            string err = "";
            xuatkho.SoPhieu = Utils.ToInt (txtSoPhieu.Text);
            xuatkho.KhoNhan = lookUpKhoNhan.EditValue.ToString ();
            xuatkho.KhoXuat = lookUpKhoXuat.EditValue.ToString ();
            foreach(DataRowView drv in dv)
            {
                err = "";
                xuatkho.SoPhieuNhap = Utils.ToInt(drv["SoPhieuNhap"].ToString ());
                xuatkho.MaVatTu = drv["MaVatTu"].ToString ();
                xuatkho.SoDangKy = drv["SoDangKy"].ToString ();
                xuatkho.SoLuong = Utils.ToInt (drv["SoLuong"].ToString ());
                xuatkho.SoLuongDung = 0;
                xuatkho.DonGiaBHYT = Utils.ToDecimal (drv["DonGiaBHYT"].ToString ());
                xuatkho.DonGiaBV = Utils.ToDecimal (drv["DonGiaBV"].ToString ());
                xuatkho.HetHan = DateTime.Parse (drv["HetHan"].ToString ());
                xuatkho.ThanhTien = Utils.ToDecimal (drv["ThanhTien"].ToString ());
                xuatkho.LoaiVatTu = drv["LoaiVatTu"].ToString ();
                if(them)
                {
                    xuatkho.SpThemPhieuNhapChiTiet (ref err);// insert vào số lô, 
                    
                }
                else
                {
                    if (dsVatTu.ContainsKey(xuatkho.SoPhieuNhap + "|" + xuatkho.MaVatTu) &&
                        dsVatTu[xuatkho.SoPhieuNhap + "|" + xuatkho.MaVatTu] == true)
                    {
                        // insert
                        xuatkho.SpThemPhieuNhapChiTiet(ref err);
                        dsVatTu[xuatkho.SoPhieuNhap + "|" + xuatkho.MaVatTu] = false;
                    }
                    //xuatkho.SpSuaPhieuNhapChiTiet(ref err);
                }
                if (!string.IsNullOrEmpty (err))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnXoa_Click (object sender, EventArgs e)
        {

        }

        private void btnIn_Click (object sender, EventArgs e)
        {
            inPhieuXuat ();
        }

        private void btnTim_Click (object sender, EventArgs e)
        {
            dataPhieu = xuatkho.DSPhieu(dateTuNgay.DateTime, dateDenNgay.DateTime);
            gridControl.DataSource = dataPhieu;
        }

        private void gridView_RowClick (object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dr = gridView.GetDataRow (e.RowHandle);
            if (dr != null)
            {
                if(dataKhoLe.Select("MaKHoa = '"+ dr["KhoNhan"] + "'").Length>0)
                {
                    checkTraNhaCC.Checked = false;
                }
                else
                {
                    checkTraNhaCC.Checked = true;
                }
                txtSoPhieu.Text = dr["SoPhieu"].ToString ();
                txtTKCo.Text = dr["TKCo"].ToString ();
                dateNgayXuat.DateTime = DateTime.Parse(dr["NgayXuat"].ToString ());
                lookUpKhoNhan.EditValue = dr["KhoNhan"].ToString ();
                lookUpKhoXuat.EditValue = dr["khoXuat"].ToString ();
                txtNguoiNhan.Text = dr["NguoiNhan"].ToString ();
                txtNoiDung.Text = dr["NoiDung"].ToString ();

                them = false;
                dsVatTu.Clear();
                //Enabled_Xoa ();
                Enabled_Luu ();
                //btnLuu.Enabled = false;

                btnIn.Enabled = true;
                // danh sách
                lookUpMaVatTu.Properties.DataSource = xuatkho.DSVatTu (txtTKCo.Text.Substring (3, 1));
                xuatkho.SoPhieu = Utils.ToInt (txtSoPhieu.Text);
                dtPhieu = xuatkho.DSPhieuVatTu ().AsDataView();
                if (Utils.ToInt(dr["KhoNhan"]) == 0)
                {
                    checkGiaBV.Checked = true;
                    checkGiaBHYT.Checked = false;
                }
                else
                {
                    checkGiaBV.Checked = false;
                    checkGiaBHYT.Checked = true;
                }
                gridControlDS.DataSource = dtPhieu;
            }
        }
        private void inPhieuXuat ()
        {
            RptPhieuXuatKho rpt = new RptPhieuXuatKho ();
            rpt.lblSoPhieu.Text = txtSoPhieu.Text;
            rpt.lblTKNo.Text = "141";
            rpt.lblTKCo.Text = "";
            rpt.lblNgayXuat.Text = "Ngày " + dateNgayXuat.DateTime.Day + " tháng "
                + dateNgayXuat.DateTime.Month + " năm " + dateNgayXuat.DateTime.Year;
            rpt.lblNguoiNhanHang.Text = txtNguoiNhan.Text;
            rpt.lblKhoNhan.Text = lookUpKhoNhan.EditValue.ToString(); //lookUpKhoNhan.Properties.GetDisplayValueByKeyValue (lookUpKhoNhan.EditValue).ToString ();
            rpt.lblNoiDungXuat.Text = txtNoiDung.Text;
            rpt.lblKhoXuat.Text = lookUpKhoXuat.Properties.GetDisplayValueByKeyValue (lookUpKhoXuat.EditValue).ToString ();
            rpt.lblNgayIn.Text = rpt.lblNgayXuat.Text;// "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

            this.thanhTien = 0;
            dsLoaiVatTu.Clear ();
            XRTableRow row;
            XRTableCell cell;
            int stt = 1;
            int soLuong = 0;
            decimal donGia = 0;
            foreach (DataRowView drview in (gridViewDS.DataSource as DataView))
            {
                soLuong = 0;
                donGia = 0;
                row = new XRTableRow ();

                cell = new XRTableCell ();
                cell.Text = stt.ToString ();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.WidthF = 40;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = drview["MaVatTu"].ToString ();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 100;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = drview["TenVatTu"].ToString ();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 280;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = drview["DonViTinh"].ToString();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 100;
                row.Cells.Add (cell);

                soLuong = Utils.ToInt(drview["SoLuong"]);
                cell = new XRTableCell ();
                cell.Text = Utils.ToString (drview["SoLuong"].ToString ());
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 70;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                if (checkGiaBV.Checked || Utils.ToDecimal(drview["DonGiaBHYT"]) == 0)
                {
                    //dr["ThanhTien"] = Utils.ToDecimal(txtSoLuong.Text) * Utils.ToDecimal(drview["DonGiaBV"]);
                    cell.Text = Utils.ToString(drview["DonGiaBV"].ToString(), null, "0,0.00");
                    donGia = Utils.ToDecimal(drview["DonGiaBV"]);
                }
                else
                {
                    //dr["ThanhTien"] = Utils.ToDecimal(txtSoLuong.Text) * Utils.ToDecimal(drview["DonGiaBHYT"]);
                    cell.Text = Utils.ToString(drview["DonGiaBHYT"].ToString(), null, "0,0.00");
                    donGia = Utils.ToDecimal(drview["DonGiaBHYT"]);
                }
                //cell.Text = Utils.ToString (drview["DonGiaBHYT"].ToString (),null, "0,0.00");
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 80;
                row.Cells.Add (cell);

                this.thanhTien += Utils.ToDecimal(drview["ThanhTien"]); //soLuong * donGia;
                cell = new XRTableCell ();
                cell.Text = Utils.ToString (Utils.ToDecimal(drview["ThanhTien"]));
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

            rpt.lblTongTien.Text = Utils.ChuyenSo (this.thanhTien.ToString ().Split('.')[0]);
            rpt.lblTKCo.Text = "";
            foreach (string loai in dsLoaiVatTu)
            {
                rpt.lblTKCo.Text += "156" + loai + " ";
            }

            rpt.CreateDocument ();
            rpt.ShowPreviewDialog ();
        }

        private void repositoryItemButtonEdit_ButtonClick (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (them)
            {
                (gridControlDS.DataSource as DataView).Delete (gridViewDS.GetFocusedDataSourceRowIndex ());
            }
            else
            {
                // tiến hành xóa, cập nhật lại kho nhập
                DialogResult traloi;
                string err = "";
                traloi = XtraMessageBox.Show("Chắc chắn bạn muốn xóa mục này?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    DataRow dr = gridViewDS.GetFocusedDataRow();
                    xuatkho.MaVatTu = dr["MaVatTu"].ToString();
                    xuatkho.SoPhieuNhap = Utils.ToInt(dr["SoPhieuNhap"]);
                    //if (xuatkho.SpXoaPhieuNhapChiTiet(ref err))
                    //{
                    //    // cập nhật được mới xóa nha-> ok
                    //    (gridControlDS.DataSource as DataView).Delete(gridViewDS.GetFocusedDataSourceRowIndex());
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //
                    if (dsVatTu.ContainsKey(xuatkho.SoPhieuNhap + "|" + xuatkho.MaVatTu) &&
                        dsVatTu[xuatkho.SoPhieuNhap + "|" + xuatkho.MaVatTu] == true)
                    {
                        (gridControlDS.DataSource as DataView).Delete(gridViewDS.GetFocusedDataSourceRowIndex());
                    }
                    else
                    if (xuatkho.SpXoaPhieuNhapChiTiet(ref err))
                    {
                        // cập nhật được mới xóa nha-> ok
                        (gridControlDS.DataSource as DataView).Delete(gridViewDS.GetFocusedDataSourceRowIndex());
                    }
                    else
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (dsVatTu.ContainsKey(xuatkho.SoPhieuNhap + "|" + xuatkho.MaVatTu))
                        dsVatTu.Remove(xuatkho.SoPhieuNhap + "|" + xuatkho.MaVatTu);
                }
            }
        }

        private void txtNguoiNhan_Leave (object sender, EventArgs e)
        {
            txtNguoiNhan.Text = Utils.VietHoa (txtNguoiNhan.Text);
        }

        private void lookUpMaVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtSoLuong.Focus();
            }
        }

        private void txtTKCo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lookUpKhoXuat.Focus();
            }
        }

        private void lookUpKhoXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lookUpKhoNhan.Focus();
            }
        }

        private void lookUpKhoNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNguoiNhan.Focus();
            }
        }

        private void txtNguoiNhan_KeyPress(object sender, KeyPressEventArgs e)
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

        private void checkGiaBV_CheckedChanged(object sender, EventArgs e)
        {
            if(checkGiaBV.Checked)
            {
                checkGiaBHYT.Checked = false;
            }
        }

        private void checkGiaBHYT_CheckedChanged(object sender, EventArgs e)
        {
            if(checkGiaBHYT.Checked)
            {
                checkGiaBV.Checked = false;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            DataRow[] dr = dataPhieu.Select("Chon = 1", "");
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
            cl3.ColumnWidth = 15.0;
            cl3.NumberFormat = "dd/MM/yyyy";

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

            object[,] arr = new object[drows.Length * 40, 17];//object[drows.Length * 30, 15];// dataTable.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            int soctu = Utils.ToInt(txtSoCTu.Text);
            int dem = 0;
            foreach (DataRow drow in drows)
            {
               
                DataTable dataTable = xuatkho.DSPhieuVatTu(Utils.ToInt(drow["SoPhieu"]));
                for (int r = 0; r < dataTable.Rows.Count; r++)
                {
                    
                    DataRow dr = dataTable.Rows[r];
                    arr[dem, 0] = "PXK";//MaCTu
                    arr[dem, 1] = soctu;// dr[""];//SoCTu
                    arr[dem, 2] = Utils.ToDateTime(drow["NgayXuat"].ToString()).ToString("dd/MM/yy")+"";//NgayCTu
                                                                                                        //

                    arr[dem, 3] = drow["NoiDung"];// +" "+((drow["KhoNhan"].Equals("K19_13")) ? "Khoa Ngoại" : "Khoa Nội") + " ngày " +
                    //    Utils.ToDateTime(drow["NgayXuat"].ToString()).ToString("dd/MM"); //dr[""];//DienGiai
                    arr[dem, 4] = (drow["KhoNhan"].Equals("K01_13")) ? "161" : "141";// dr[""];//MaTKNo Ngoại trú: 161, Nội trú: 141
                    arr[dem, 5] = "156" + dr["LoaiVatTu"];//MaTKCo
                    arr[dem, 6] = "";//dr[""];//MaVTHHNo
                    if (maVatTu.ContainsKey(dr["MaBV"].ToString()))
                    {
                        arr[dem, 7] = maVatTu[dr["MaBV"].ToString()];//MaVTHHCo
                    }
                    else
                    {
                        arr[dem, 7] = dr["MaBV"];//MaVTHHCo
                    }
                    arr[dem, 8] = dr["TenVatTu"];//TenHangHoa
                    arr[dem, 9] = dr["DonViTinh"];//DonViTinh
                    arr[dem, 10] = dr["SoLuong"];//SoLuong
                    arr[dem, 11] = dr["DonGiaBV"];//VNDDonGia
                    arr[dem, 12] = Utils.ToInt(dr["SoLuong"]) * Utils.ToDecimal(dr["DonGiaBV"]);//dr["ThanhTien"];//VNDThanhTien
                    arr[dem, 13] = ((drow["KhoNhan"].Equals("K19_13")) ? "LÊ THỊ THẢO LY" : "NGUYỄN TIẾN DŨNG");//drow["NguoiNhan"];//KhachHang
                    arr[dem, 14] = lookUpKhoNhan.Properties.GetDisplayValueByKeyValue(drow["KhoNhan"]);// lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();// dr[""];//DiaChi
                    arr[dem, 15] = Utils.ToDateTime(drow["NgayXuat"].ToString()).Month;//
                    arr[dem, 16] = "BVDK";//
                    //TenKH
                    dem++;
                }
                soctu++;
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dem;
            int columnEnd = 17;// dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void lookUpKhoNhan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpKhoNhan.EditValue != null && !string.IsNullOrEmpty(lookUpKhoNhan.EditValue.ToString()))
                txtNoiDung.Text = lookUpKhoNhan.Properties.GetDisplayValueByKeyValue(lookUpKhoNhan.EditValue).ToString();
        }

        private void checkTraNhaCC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTraNhaCC.Checked)// Khoa trả khoa Duoc, khoa nhận nhà cung cấp
            {
                lookUpKhoNhan.Properties.DataSource = dataNhaCC;
            }
            else
            {
                lookUpKhoNhan.Properties.DataSource = dataKhoLe;
            }
        }
    }
}
