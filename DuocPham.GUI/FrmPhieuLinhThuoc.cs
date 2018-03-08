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
    public partial class FrmPhieuLinhThuoc : RibbonForm
    {
        LinhThuocEntity linhthuoc;
        DataRow dr;
        string quyen = "";
        SortedSet<string> dsLoaiVatTu = new SortedSet<string> ();
        decimal thanhTien = 0;
        CultureInfo elGR = CultureInfo.CreateSpecificCulture ("el-GR");
        System.Drawing.Font fontB = new System.Drawing.Font ("Times New Roman", 11, System.Drawing.FontStyle.Bold);
        System.Drawing.Font font = new System.Drawing.Font ("Times New Roman", 11);
        public FrmPhieuLinhThuoc ()
        {
            InitializeComponent ();
            linhthuoc = new LinhThuocEntity ();
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmPhieuLinhThuoc_Load (object sender, EventArgs e)
        {
            dateDenNgay.DateTime = DateTime.Now;
            dateTuNgay.DateTime = DateTime.Now;
            gridControlDS.DataSource = linhthuoc.DSPhieu (dateTuNgay.DateTime, dateDenNgay.DateTime);
            lookUpKhoaBan.DataSource = linhthuoc.DSKhoaBan ();
            lookUpKhoaBan.DisplayMember = "TenKhoa";
            lookUpKhoaBan.ValueMember = "MaKhoa";

            quyen = Utils.GetQuyen (this.Name);
            btnPheDuyet.Enabled = false;
            btnPhieuLinh.Enabled = false;
            btnXuatKho.Enabled = false;
        }
        private void Enabled_PheDuyet ()
        {
            if (quyen.IndexOf ('2') >= 0)
            {
                btnPheDuyet.Enabled = true;
            }
            else
            {
                btnPheDuyet.Enabled = false;
            }
        }
        private void btnTim_Click (object sender, EventArgs e)
        {
            gridControlDS.DataSource = linhthuoc.DSPhieu (dateTuNgay.DateTime, dateDenNgay.DateTime);
        }

        private void gridViewDS_RowClick (object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dr = gridViewDS.GetDataRow (e.RowHandle);
            txtNoiDung.Text = dr["NoiDung"].ToString ();
            dateNgayXuat.DateTime = DateTime.Parse(dr["NgayXuat"].ToString ());
            checkPheDuyet.Checked = bool.Parse (dr["PheDuyet"].ToString ());
            if(!checkPheDuyet.Checked)
            {
                Enabled_PheDuyet ();
            }
            else
            {
                btnPheDuyet.Enabled = false;
            }
            btnPhieuLinh.Enabled = true;
            btnXuatKho.Enabled = true;
            linhthuoc.SoPhieu = int.Parse (dr["SoPhieu"].ToString ());
            linhthuoc.TKCo = dr["TKCo"].ToString();
            gridControlCT.DataSource = linhthuoc.DSPhieuVatTu ();
        }

        private void btnXuatKho_Click (object sender, EventArgs e)
        {
            inPhieuXuat ();
        }

        private void btnPhieuLinh_Click (object sender, EventArgs e)
        {
            inPhieuLinh ();
        }
        private void inPhieuLinh ()
        {
            RptPhieuLinhThuoc rpt = new RptPhieuLinhThuoc ();
            rpt.lblSoPhieu.Text = linhthuoc.SoPhieu.ToString ();
            rpt.lblNgayXuat.Text = "Ngày " + dateNgayXuat.DateTime.Day + " tháng "
                + dateNgayXuat.DateTime.Month + " năm " + dateNgayXuat.DateTime.Year;
            rpt.lblKhoaNhan.Text = lookUpKhoaBan.GetDisplayValueByKeyValue (dr["KhoNhan"]).ToString ();
            rpt.lblNgayIn.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            rpt.xrlblNguoiLinh.Text = dr["NguoiNhan"].ToString();
            DataRow drow = linhthuoc.MauPhieu();
            if(drow!=null)
            {
                rpt.lblPhieuLinh.Text = "PHIẾU LĨNH "+drow["Ten"].ToString().ToUpper();
                rpt.lblMauSo.Text = "MS: "+ drow["Mau"] +"/BV01";
            }
            XRTableRow row;
            XRTableCell cell;
            int stt = 1;
            decimal soluong = 0;
            foreach (DataRowView drview in (gridViewCT.DataSource as DataView))
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

                decimal sl = decimal.Parse (drview["SoLuong"].ToString ());
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
            //row = new XRTableRow ();

            //cell = new XRTableCell ();
            //cell.Text = "";
            //cell.Font = font;
            //cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //cell.WidthF = 40;
            //row.Cells.Add (cell);

            //cell = new XRTableCell ();
            //cell.Text = "";
            //cell.Font = font;
            //cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //cell.WidthF = 80;
            //row.Cells.Add (cell);

            //cell = new XRTableCell ();
            //cell.Text = "Cộng khoản:";
            //cell.Font = fontB;
            //cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //cell.WidthF = 348;
            //row.Cells.Add (cell);

            //cell = new XRTableCell ();
            //cell.Text = "";
            //cell.Font = font;
            //cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //cell.WidthF = 50;
            //row.Cells.Add (cell);

            //cell = new XRTableCell ();
            //cell.Text = soluong.ToString ("0,0", elGR);
            //cell.Font = fontB;
            //cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //cell.WidthF = 70;
            //row.Cells.Add (cell);

            //cell = new XRTableCell ();
            //cell.Text = soluong.ToString ("0,0", elGR);
            //cell.Font = fontB;
            //cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //cell.WidthF = 70;
            //row.Cells.Add (cell);

            //cell = new XRTableCell ();
            //cell.Text = "";
            //cell.Font = font;
            //cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //cell.WidthF = 108;
            //row.Cells.Add (cell);

            //rpt.xrTable.Rows.Add (row);

            rpt.CreateDocument ();
            rpt.ShowPreviewDialog ();
        }
        private void inPhieuXuat ()
        {
            RptPhieuXuatKho rpt = new RptPhieuXuatKho ();
            rpt.lblSoPhieu.Text = dr["SoPhieu"].ToString ();
            rpt.lblTKNo.Text = "141";
            rpt.lblTKCo.Text = "";
            rpt.lblNgayXuat.Text = "Ngày " + dateNgayXuat.DateTime.Day + " tháng "
                + dateNgayXuat.DateTime.Month + " năm " + dateNgayXuat.DateTime.Year;
            rpt.lblNguoiNhanHang.Text = dr["NguoiNhan"].ToString ();
            rpt.lblKhoNhan.Text = lookUpKhoaBan.GetDisplayValueByKeyValue (dr["KhoNhan"]).ToString ();
            rpt.lblNoiDungXuat.Text = txtNoiDung.Text;
            rpt.lblKhoXuat.Text = lookUpKhoaBan.GetDisplayValueByKeyValue (dr["KhoXuat"]).ToString ();
            rpt.lblNgayIn.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

            this.thanhTien = 0;
            dsLoaiVatTu.Clear ();
            XRTableRow row;
            XRTableCell cell;
            int stt = 1;
            foreach (DataRowView drview in (gridViewCT.DataSource as DataView))
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
                cell.Text = drview["DonViTinh"].ToString ();
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.WidthF = 70;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = decimal.Parse (drview["SoLuong"].ToString ()).ToString ("0,0", elGR);
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 80;
                row.Cells.Add (cell);

                cell = new XRTableCell ();
                cell.Text = Utils.ToDecimal(drview["DonGiaBHYT"]).ToString ("0,0", elGR);
                cell.Font = font;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.WidthF = 80;
                row.Cells.Add (cell);

                this.thanhTien += decimal.Parse (drview["ThanhTien"].ToString ());
                cell = new XRTableCell ();
                cell.Text = decimal.Parse (drview["ThanhTien"].ToString ()).ToString ("0,0", elGR);
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

            rpt.lblTongTien.Text = Utils.ChuyenSo (this.thanhTien.ToString().Split('.')[0]);
            rpt.lblTKCo.Text = "";
            foreach (string loai in dsLoaiVatTu)
            {
                rpt.lblTKCo.Text += "156" + loai + " ";
            }

            rpt.CreateDocument ();
            rpt.ShowPreviewDialog ();
        }

        private void btnPheDuyet_Click (object sender, EventArgs e)
        {
            string err = "";
            if(linhthuoc.SpSuaPheDuyet (ref err))
            {
                btnPheDuyet.Enabled = false;
                checkPheDuyet.Checked = true;
                gridViewDS.SetFocusedRowCellValue ("PheDuyet", true);
            }
            if(!string.IsNullOrEmpty(err))
            {
                XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
