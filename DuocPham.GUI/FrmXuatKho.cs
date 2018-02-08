using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
        SortedSet<string> dsLoaiVatTu = new SortedSet<string> ();
        decimal thanhTien = 0;
        CultureInfo elGR = CultureInfo.CreateSpecificCulture ("el-GR");
        System.Drawing.Font fontB = new System.Drawing.Font ("Times New Roman", 11, System.Drawing.FontStyle.Bold);
        System.Drawing.Font font = new System.Drawing.Font ("Times New Roman", 11);
        public FrmXuatKho ()
        {
            InitializeComponent ();
            xuatkho = new XuatKhoEntity ();
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmXuatKho_Load (object sender, EventArgs e)
        {
            lookUpKhoXuat.Properties.DataSource = xuatkho.DSKhoXuat ();
            lookUpKhoXuat.Properties.ValueMember = "MaKhoa";
            lookUpKhoXuat.Properties.DisplayMember = "TenKhoa";
            lookUpKhoXuat.EditValue = "70013";

            lookUpKhoNhan.Properties.DataSource = xuatkho.DSKhoNhan ();
            lookUpKhoNhan.Properties.ValueMember = "MaKhoa";
            lookUpKhoNhan.Properties.DisplayMember = "TenKhoa";

            lookUpMaVatTu.Properties.DisplayMember = "TenVatTu";

            dateTuNgay.EditValue = DateTime.Now;
            dateDenNgay.EditValue = DateTime.Now;

            checkButton ();
            LoadData ();
            btnIn.Enabled = false;
        }
        private void LoadData ()
        {
            them = false;
            btnLuu.Enabled = false;
            gridControl.DataSource = xuatkho.DSPhieu (dateTuNgay.DateTime, dateDenNgay.DateTime);
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
                    lookUpMaVatTu.EditValue = null;
                    txtSoLuong.Text = "";
                    lookUpMaVatTu.Focus();
                }
            }
        }

        private void btnThem_Click (object sender, EventArgs e)
        {
            them = true;
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
                    xuatkho.NguoiCapNhat = AppConfig.MaNV;
                }
                if (!string.IsNullOrEmpty (err))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnIn.Enabled = true;
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
                    //fffgfg;// tạo lỗi để nhớ
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
            gridControl.DataSource = xuatkho.DSPhieu (dateTuNgay.DateTime, dateDenNgay.DateTime);
        }

        private void gridView_RowClick (object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dr = gridView.GetDataRow (e.RowHandle);
            if (dr != null)
            {
                txtSoPhieu.Text = dr["SoPhieu"].ToString ();
                txtTKCo.Text = dr["TKCo"].ToString ();
                dateNgayXuat.DateTime = DateTime.Parse(dr["NgayXuat"].ToString ());
                lookUpKhoNhan.EditValue = dr["KhoNhan"].ToString ();
                lookUpKhoXuat.EditValue = dr["khoXuat"].ToString ();
                txtNguoiNhan.Text = dr["NguoiNhan"].ToString ();
                txtNoiDung.Text = dr["NoiDung"].ToString ();

                them = false;
                //Enabled_Xoa ();
                //Enabled_Luu ();
                btnLuu.Enabled = false;

                btnIn.Enabled = true;
                // danh sách
                lookUpMaVatTu.Properties.DataSource = xuatkho.DSVatTu (txtTKCo.Text.Substring (3, 1));
                xuatkho.SoPhieu = Utils.ToInt (txtSoPhieu.Text);
                dtPhieu = xuatkho.DSPhieuVatTu ().AsDataView();

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
            rpt.lblKhoNhan.Text = lookUpKhoNhan.Properties.GetDisplayValueByKeyValue (lookUpKhoNhan.EditValue).ToString ();
            rpt.lblNoiDungXuat.Text = txtNoiDung.Text;
            rpt.lblKhoXuat.Text = lookUpKhoXuat.Properties.GetDisplayValueByKeyValue (lookUpKhoXuat.EditValue).ToString ();
            rpt.lblNgayIn.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

            this.thanhTien = 0;
            dsLoaiVatTu.Clear ();
            XRTableRow row;
            XRTableCell cell;
            int stt = 1;
            foreach (DataRowView drview in (gridViewDS.DataSource as DataView))
            {
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
                cell.WidthF = 300;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = drview["DonViTinh"].ToString();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 70;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = Utils.ToString (drview["SoLuong"].ToString ());
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 80;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = Utils.ToString (drview["DonGiaBHYT"].ToString (),null, "0,0.00");
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 80;
                row.Cells.Add (cell);

                this.thanhTien += Utils.ToDecimal (drview["ThanhTien"].ToString ());
                cell = new XRTableCell ();
                cell.Text = Utils.ToString (drview["ThanhTien"].ToString (), null, "0,0.00");
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
                    if (xuatkho.SpXoaPhieuNhapChiTiet(ref err))
                    {
                        // cập nhật được mới xóa nha-> ok
                        (gridControlDS.DataSource as DataView).Delete(gridViewDS.GetFocusedDataSourceRowIndex());
                    }
                    else
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
    }
}
