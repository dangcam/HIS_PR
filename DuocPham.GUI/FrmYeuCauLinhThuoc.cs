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
    public partial class FrmYeuCauLinhThuoc : RibbonForm
    {
        LinhThuocEntity linhthuoc;
        bool them = false;
        string quyen = "";
        CultureInfo elGR = CultureInfo.CreateSpecificCulture ("el-GR");
        System.Drawing.Font fontB = new System.Drawing.Font ("Times New Roman", 11, System.Drawing.FontStyle.Bold);
        System.Drawing.Font font = new System.Drawing.Font ("Times New Roman", 11);
        Dictionary<string, bool> dsVatTu = new Dictionary<string, bool>();
        public FrmYeuCauLinhThuoc ()
        {
            InitializeComponent ();
            linhthuoc = new LinhThuocEntity ();
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmYeuCauLinhThuoc_Load (object sender, EventArgs e)
        {
            if(linhthuoc.LayKhoXuat())
            {
                txtKhoXuat.Text = linhthuoc.TenKhoXuat;
            }
            if(linhthuoc.LayKhoNhan())
            {
                txtKhoNhan.Text = linhthuoc.TenKhoNhan;
            }
            lookUpLoaiVatTu.Properties.DataSource = linhthuoc.DSLoaiVatTu ();
            lookUpLoaiVatTu.Properties.DisplayMember = "Ten";
            lookUpLoaiVatTu.Properties.ValueMember = "Ma";
            lookUpMaVatTu.Properties.DisplayMember = "TenVatTu";
            cbNoiDung.SelectedIndex = 0;
            checkButton ();
            LoadData ();
            btnIn.Enabled = false;
            btnLuu.Enabled = false;
            cbNguoiLinh.Properties.Items.Clear();
            DataTable dataNV = linhthuoc.DSNV();
            foreach(DataRow dr in dataNV.Rows)
            {
                cbNguoiLinh.Properties.Items.Add(dr["TenNV"]);
            }
        }
        private void LoadData()
        {
            gridControlPhieu.DataSource = linhthuoc.DSPhieu ();
            them = false;
            //btnLuu.Enabled = false;
        }
        private void checkButton ()
        {
            quyen = Utils.GetQuyen (this.Name);
            Enabled_Them ();
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
        private void lookUpLoaiVatTu_EditValueChanged (object sender, EventArgs e)
        {
            lookUpMaVatTu.Properties.DataSource = linhthuoc.DSVatTu (lookUpLoaiVatTu.EditValue.ToString());
        }

        private void btnThem_Click (object sender, EventArgs e)
        {
            them = true;
            dsVatTu.Clear();
            txtSoLuong.Text = "";

            linhthuoc.SoPhieu = 0;
            linhthuoc.NgayXuat = DateTime.Now;
            linhthuoc.NgayCapNhat = DateTime.Now;
            linhthuoc.PheDuyet = false;
            //linhthuoc.NguoiNhan = linhthuoc.LayNguoiNhan ();
            linhthuoc.NoiDung = "Khoa yêu cầu phát thuốc.";
            gridControlDS.DataSource = linhthuoc.DSPhieuVatTu ().AsDataView ();

            lookUpMaVatTu.Focus ();
            Enabled_Luu ();
            btnIn.Enabled = false;
            dateYeuCau.DateTime = DateTime.Now;
            cbNguoiLinh.SelectedItem = 0;
        }

        private void btnLuu_Click (object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty (linhthuoc.KhoNhan))
            {
                XtraMessageBox.Show ("Không tìm thấy kho nhận thuốc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((gridControlDS.DataSource as DataView).Count == 0)
            {
                XtraMessageBox.Show ("Nhập vật tư!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lookUpMaVatTu.Focus ();
                return;
            }
            linhthuoc.NgayXuat = dateYeuCau.DateTime;
            linhthuoc.TKCo = "156" + lookUpLoaiVatTu.EditValue;
            linhthuoc.NoiDung = Utils.ToString(cbNoiDung.EditValue);
            linhthuoc.NguoiNhan = Utils.ToString(cbNguoiLinh.EditValue);
            string err = "";
            DialogResult traloi;
            traloi = XtraMessageBox.Show ("Chắc chắn bạn muốn lưu, những thông tin này sẽ không được chỉnh sửa?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if (them)
                {
                    linhthuoc.NguoiTao = AppConfig.MaNV;
                    if (linhthuoc.SpThemPhieuXuat (ref err))
                    {
                        LuuVatTu ();
                        LoadData ();
                    }
                }
                else
                {
                    linhthuoc.NguoiCapNhat = AppConfig.MaNV;
                    LuuVatTu();
                    LoadData();
                }
                if (!string.IsNullOrEmpty (err))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnIn.Enabled = true;
            }
        }

        private void btnIn_Click (object sender, EventArgs e)
        {
            inPhieuLinh ();
        }
        private void LuuVatTu ()
        {
            DataView dv = (gridControlDS.DataSource as DataView);
            string err = "";
            foreach (DataRowView drv in dv)
            {
                err = "";
                linhthuoc.SoPhieuNhap = int.Parse (drv["SoPhieuNhap"].ToString ());
                linhthuoc.MaVatTu = drv["MaVatTu"].ToString ();
                linhthuoc.SoDangKy = drv["SoDangKy"].ToString ();
                linhthuoc.SoLuong = Utils.ToInt (drv["SoLuong"]);
                linhthuoc.SoLuongDung = 0;
                linhthuoc.DonGiaBHYT = Utils.ToDecimal (drv["DonGiaBHYT"]);
                linhthuoc.DonGiaBV = Utils.ToDecimal(drv["DonGiaBV"]);
                linhthuoc.HetHan = DateTime.Parse (drv["HetHan"].ToString ());
                linhthuoc.ThanhTien = Utils.ToDecimal(drv["ThanhTien"]);
                linhthuoc.LoaiVatTu = drv["LoaiVatTu"].ToString ();
                if (them)
                {
                    linhthuoc.SpThemPhieuNhapChiTiet (ref err);
                }
                else
                {
                    if(dsVatTu.ContainsKey(linhthuoc.SoPhieuNhap+"|"+ linhthuoc.MaVatTu) && 
                        dsVatTu[linhthuoc.SoPhieuNhap + "|" + linhthuoc.MaVatTu]== true)
                    {
                        // insert
                        linhthuoc.SpThemPhieuNhapChiTiet(ref err);
                        dsVatTu[linhthuoc.SoPhieuNhap + "|" + linhthuoc.MaVatTu] = false;
                    }
                    // lưu thêm vật tư
                }
                if (!string.IsNullOrEmpty (err))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSoLuong_KeyPress (object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtSoLuong.Text.Length == 0 || txtSoLuong.Text == "0")
                {
                    XtraMessageBox.Show ("Nhập số lượng!");
                    txtSoLuong.Focus ();
                    e.Handled = true;
                }
                if (gridControlDS.DataSource is DataView && btnLuu.Enabled)
                {
                    DataRowView drview = (lookUpMaVatTu.GetSelectedDataRow () as DataRowView);
                    DataRow[] drv = (gridViewDS.DataSource as DataView).Table.Select ("MaVatTu = '" + drview["MaVatTu"].ToString ()
                        + "' and SoPhieuNhap = '" + drview["SoPhieu"].ToString () + "'");
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
                    dr["SoPhieuNhap"] = drview["SoPhieu"].ToString ();
                    dr["MaVatTu"] = drview["MaVatTu"].ToString ();
                    dr["TenVatTu"] = drview["TenVatTu"];
                    dr["SoDangKy"] = drview["SoDangKy"];
                    dr["SoLuong"] = Utils.ToInt(txtSoLuong.Text);
                    dr["SoLuongDung"] = 0;
                    dr["DonGiaBHYT"] =Utils.ToDecimal( drview["DonGiaBHYT"]);
                    dr["DonGiaBV"] =Utils.ToDecimal( drview["DonGiaBV"]);
                    dr["HetHan"] = drview["HetHan"].ToString ();
                    dr["ThanhTien"] = Utils.ToDecimal (txtSoLuong.Text) * Utils.ToDecimal (dr["DonGiaBV"]);
                    dr["LoaiVatTu"] =  drview["LoaiVatTu"];
                    dr["DonViTinh"] =Utils.ToString( drview["DonViTinh"]);
                    dr.EndEdit();
                    if(them == false)
                    {
                        // chèn thêm vật tư
                        dsVatTu.Add(drview["SoPhieu"] + "|" + drview["MaVatTu"],true);
                    }
                    txtSoLuong.Text = "";
                    lookUpMaVatTu.Focus();
                }
            }
        }

        private void btnXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (them)
            {
                (gridControlDS.DataSource as DataView).Delete(gridViewDS.GetFocusedDataSourceRowIndex());
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
                    linhthuoc.MaVatTu = dr["MaVatTu"].ToString();
                    linhthuoc.SoPhieuNhap = Utils.ToInt(dr["SoPhieuNhap"]);
                    if(dsVatTu.ContainsKey(linhthuoc.SoPhieuNhap+"|"+ linhthuoc.MaVatTu) &&
                        dsVatTu[linhthuoc.SoPhieuNhap + "|" + linhthuoc.MaVatTu] == true)
                    {
                        (gridControlDS.DataSource as DataView).Delete(gridViewDS.GetFocusedDataSourceRowIndex());
                    }
                    else
                    if (linhthuoc.SpXoaPhieuNhapChiTiet(ref err))
                    {
                        // cập nhật được mới xóa nha-> ok
                        (gridControlDS.DataSource as DataView).Delete(gridViewDS.GetFocusedDataSourceRowIndex());
                    }
                    else
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (dsVatTu.ContainsKey(linhthuoc.SoPhieuNhap + "|" + linhthuoc.MaVatTu))
                        dsVatTu.Remove(linhthuoc.SoPhieuNhap + "|" + linhthuoc.MaVatTu);
                }
            }
        }

        private void gridViewPhieu_RowClick (object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridViewPhieu.GetDataRow (e.RowHandle);
            dsVatTu.Clear();
            if (dr != null)
            {
                linhthuoc.SoPhieu = int.Parse(dr["SoPhieu"].ToString ());
                linhthuoc.TKCo = dr["TKCo"].ToString ();
                linhthuoc.NgayXuat =DateTime.Parse( dr["NgayXuat"].ToString ());
                linhthuoc.KhoNhan = dr["KhoNhan"].ToString ();
                linhthuoc.KhoXuat = dr["khoXuat"].ToString ();
                linhthuoc.NguoiNhan = dr["NguoiNhan"].ToString ();
                linhthuoc.NoiDung = dr["NoiDung"].ToString ();

                cbNoiDung.EditValue = dr["NoiDung"];
                cbNguoiLinh.EditValue = linhthuoc.NguoiNhan;

                them = false;
                Enabled_Luu ();

                btnIn.Enabled = true;
                // danh sách
                lookUpMaVatTu.Properties.DataSource = linhthuoc.DSVatTu (linhthuoc.TKCo.Length>4 ?
                    linhthuoc.TKCo.Substring (3, 2): linhthuoc.TKCo.Substring(linhthuoc.TKCo.Length-1, 1));
                gridControlDS.DataSource = linhthuoc.DSPhieuVatTu ().AsDataView ();
            }
        }
        private void inPhieuLinh ()
        {
            RptPhieuLinhThuoc rpt = new RptPhieuLinhThuoc ();
            rpt.lblSoPhieu.Text = linhthuoc.SoPhieu.ToString();
            rpt.lblNgayXuat.Text = "Ngày " + linhthuoc.NgayXuat.Day + " tháng "
                + linhthuoc.NgayXuat.Month + " năm " + linhthuoc.NgayXuat.Year;
            rpt.lblKhoaNhan.Text = linhthuoc.TenKhoNhan;
            rpt.lblNgayIn.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            rpt.xrlblNoiDung.Text = linhthuoc.NoiDung;
            rpt.xrlblNguoiLinh.Text = cbNguoiLinh.EditValue.ToString();
            DataRow drow = linhthuoc.MauPhieu();
            if (drow != null)
            {
                rpt.lblPhieuLinh.Text = "PHIẾU LĨNH " + drow["Ten"].ToString().ToUpper();
                rpt.lblMauSo.Text = "MS: " + drow["Mau"] + "/BV01";
            }
            XRTableRow row;
            XRTableCell cell;
            int stt = 1;
            decimal soluong = 0;
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
                cell.WidthF = 80;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = drview["TenVatTu"].ToString ();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 348;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = drview["DonViTinh"].ToString ();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 50;
                row.Cells.Add (cell);

                decimal sl = Utils.ToDecimal (drview["SoLuong"].ToString ());
                soluong += sl;
                cell = new XRTableCell ();
                cell.Text = sl.ToString ("0,0", elGR);
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 70;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = sl.ToString ("0,0", elGR);
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 70;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = "";
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 108;
                row.Cells.Add (cell);

                stt++;
                rpt.xrTable.Rows.Add (row);
            }
            row = new XRTableRow ();
   
            cell = new XRTableCell ();
            cell.Text = "";
            cell.Font = font;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.WidthF = 40;
            row.Cells.Add (cell);

            cell = new XRTableCell ();
            cell.Text = "";
            cell.Font = font;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            cell.WidthF = 80;
            row.Cells.Add (cell);

            cell = new XRTableCell ();
            cell.Text = "Cộng khoản:";
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            cell.WidthF = 348;
            row.Cells.Add (cell);

            cell = new XRTableCell ();
            cell.Text = "";
            cell.Font = font;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            cell.WidthF = 50;
            row.Cells.Add (cell);

            cell = new XRTableCell ();
            cell.Text = soluong.ToString ("0,0", elGR);
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.WidthF = 70;
            row.Cells.Add (cell);

            cell = new XRTableCell ();
            cell.Text = soluong.ToString ("0,0", elGR);
            cell.Font = fontB;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.WidthF = 70;
            row.Cells.Add (cell);

            cell = new XRTableCell ();
            cell.Text = "";
            cell.Font = font;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.WidthF = 108;
            row.Cells.Add (cell);

            rpt.xrTable.Rows.Add (row);

            rpt.CreateDocument ();
            rpt.ShowPreviewDialog ();
        }

        private void lookUpLoaiVatTu_KeyPress(object sender, KeyPressEventArgs e)
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
