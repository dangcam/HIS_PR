using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using KhamBenh.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TiepNhan.GUI.MauSo;

namespace TiepNhan.GUI
{
    public partial class FrmKQCanLamSan : RibbonForm
    {
        CanLamSanEntity canLamSan;
        DataView dvDichVu;
        Dictionary<string, int> listDichVu;
        string ketQua;
        FrmMauPhieu frmMauPhieu;
        public FrmKQCanLamSan()
        {
            InitializeComponent();
            canLamSan = new CanLamSanEntity();
            frmMauPhieu = new FrmMauPhieu();
            lookUpMaKhoa.Properties.DataSource = canLamSan.DSKhoaBan(1);
            lookUpMaKhoa.Properties.ValueMember = "MaKhoa";
            lookUpMaKhoa.Properties.DisplayMember = "TenKhoa";
            lookUpBacSi.Properties.DataSource = canLamSan.DSBacSi();
            lookUpBacSi.Properties.ValueMember = "Ma_BS";
            lookUpBacSi.Properties.DisplayMember = "Ten_NV";
        }
        public string HoTen { get; set; }
        public string TenCanLamSan { get; set; }
        public string ChuanDoan { get; set; }
        public string YeuCau { get; set; }
        public int MaNhom { get; set; }
        public string MaLK { get; set; }
        public string MaCSL { get; set; }
        public string MaBacSi { get; set; }
        public string MaMay { get; set; }
        public string MauSo { get; set; }
        public string NamSinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoThe { get; set; }
        public string DiaChi { get; set; }
        public string MaKhoa { get; set; }

        private void FrmKQCanLamSan_Load(object sender, EventArgs e)
        {
            canLamSan.MaCLS = this.MaCSL;
            canLamSan.MaLK = this.MaLK;
            lookUpMaKhoa.EditValue = MaKhoa;
            txtHoTen.Text = this.HoTen;
            txtCanLamSan.Text = this.TenCanLamSan;
            txtYeuCau.Text = this.YeuCau;
            txtChuanDoan.Text = this.ChuanDoan;
            lookUpDichVu.Properties.DataSource = canLamSan.DSDichVu(this.MaNhom);

            this.ActiveControl = this.lookUpDichVu;
            // load data
            dvDichVu = canLamSan.DSDichVuChiTiet().AsDataView();
            gridControl.DataSource = dvDichVu;
            listDichVu = new Dictionary<string, int>();
            foreach(DataRowView dr in dvDichVu)
            {
                // 0. xóa, 1. đã có, 2. thêm mới
                listDichVu.Add(dr["MaDichVu"].ToString(), 1);
            }
            lookUpBacSi.EditValue = this.MaBacSi;
        }

        private void txtSoLuong_Enter(object sender, EventArgs e)
        {
            txtSoLuong.Select(0, txtSoLuong.Value.ToString().Length);
        }

        private void lookUpDichVu_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtSoLuong.Focus();
            }
        }

        private void txtSoLuong_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtGiaTri.Focus();
            }
        }

        private void txtGiaTri_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtMoTa.Focus();
            }
        }

        private void txtMoTa_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtKetLuan.Focus();
            }
        }

        private void txtKetLuan_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                btnChon.Focus();
            }
        }

        private void repBtnXoa_ButtonClick(object sender, 
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = gridView.GetFocusedDataSourceRowIndex();
            if (index > -1)
            {
                // 0. xóa
                string key = (dvDichVu.ToTable().Rows[index]["MaDichVu"].ToString());
                if (listDichVu[key] == 1)
                    listDichVu[key] = 0;
                else
                    listDichVu.Remove(key);
                (gridControl.DataSource as DataView).Delete(index);
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (lookUpDichVu.EditValue is DataRowView)
            {
                DataRowView dr = (lookUpDichVu.EditValue as DataRowView);
                string maDichVu = dr["MaDVKT"].ToString();
                if (listDichVu.ContainsKey(maDichVu))
                {
                    if (listDichVu[maDichVu] > 0)// đã có và 1 hoặc 2
                    {
                        XtraMessageBox.Show(Library.DichVuDaDuocChon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lookUpDichVu.Focus();
                    }
                    else//listDichVu[maDichVu] ==0
                    {
                        listDichVu[maDichVu] = 1;// đã có và đánh dấu 0. xóa, cập nhật lại
                    }
                }
                else
                {
                    listDichVu.Add(maDichVu, 2);// 2. thêm mới
                }
                DataRowView drvNew = (gridControl.DataSource as DataView).AddNew();
                drvNew["MaDichVu"] = maDichVu;
                drvNew["TenDichVu"] = dr["TenDVKT"];
                drvNew["SoLuong"] = txtSoLuong.Value;
                drvNew["DonGia"] = dr["DonGia"];
                drvNew["ThanhTien"] = txtSoLuong.Value * Utils.ToDecimal(dr["DonGia"]);
                drvNew["NgayKQ"] = DateTime.Now;
                drvNew["GiaTri"] = txtGiaTri.Text;
                drvNew["MoTa"] = txtMoTa.Text;
                drvNew["KetLuan"] = txtKetLuan.Text;
                drvNew["NgayYLenh"] = DateTime.Now;
                drvNew["MaChiSo"] = dr["TT50"];
                drvNew.EndEdit();
                lookUpDichVu.Focus();
                txtGiaTri.Text = "";
                txtMoTa.Text = "";
                txtKetLuan.Text = "";
            }
        }

        private void txtKetLuan_Enter(object sender, EventArgs e)
        {
            txtKetLuan.Text = "Bình thường";
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.Name =="SoLuong")
            {
                this.gridView.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
                var dongia = gridView.GetRowCellValue(e.RowHandle, gridView.Columns["DonGia"]);
                gridView.SetFocusedRowCellValue("ThanhTien", Utils.ToInt(e.Value) * Utils.ToDecimal(dongia));
                this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
            }
        }
        private void LuuKetQua()
        {
            string err = "";
            this.ketQua = "";
            if (dvDichVu.Count > 0)
            {
                //cập nhật đã cận lâm sàn
                canLamSan.CapNhatCDCanLamSan(ref err, 1);
            }
            else
            {
                canLamSan.CapNhatCDCanLamSan(ref err, 0);
            }
            List<string> keys = new List<string>(listDichVu.Keys);
            canLamSan.MaLK = this.MaLK;
            canLamSan.MaCLS = this.MaCSL;
            canLamSan.MaNhom = this.MaNhom;
            canLamSan.MaBacSi = Utils.ToString(lookUpBacSi.EditValue);
            canLamSan.MaMay = this.MaMay;
            foreach (string key in keys)
            {
                if (listDichVu[key] == 0)
                {
                    // xóa
                    err = "";
                    canLamSan.MaDichVu = key;
                    canLamSan.NgayKQ = DateTime.Now;
                    canLamSan.NgayYLenh = DateTime.Now;
                    if (canLamSan.SpDichVuChiTiet(ref err, "DELETE"))
                    {
                        listDichVu.Remove(key);
                    }
                }
            }
            foreach (DataRowView drv in dvDichVu)
            {
                err = "";

                canLamSan.MaDichVu = drv["MaDichVu"].ToString();
                canLamSan.TenDichVu = drv["TenDichVu"].ToString();
                canLamSan.DonViTinh = "Lần";
                canLamSan.SoLuong = Utils.ToInt(drv["SoLuong"]);
                canLamSan.DonGia = Utils.ToDecimal(drv["DonGia"]);
                canLamSan.TyLe = 100;
                canLamSan.ThanhTien = Utils.ToDecimal(drv["ThanhTien"]);
                canLamSan.MaKhoa = Utils.ToString(lookUpMaKhoa.EditValue);
                //canLamSan.MaBacSi = Utils.ToString(lookUpBacSi.EditValue);
                canLamSan.NgayYLenh = Utils.ToDateTime(drv["NgayYLenh"].ToString());
                canLamSan.NgayKQ = Utils.ToDateTime(drv["NgayKQ"].ToString());
                canLamSan.MaPTTT = 0;
                canLamSan.MaChiSo = drv["MaChiSo"].ToString(); ;
                canLamSan.GiaTri = drv["GiaTri"].ToString();
                canLamSan.MoTa = drv["MoTa"].ToString();
                canLamSan.KetLuan = drv["KetLuan"].ToString();
                ketQua = ketQua == "" ? canLamSan.KetLuan : ketQua + "; " + canLamSan.KetLuan;
                if (listDichVu[canLamSan.MaDichVu] == 1)
                {
                    // cập nhật
                    canLamSan.SpDichVuChiTiet(ref err, "UPDATE");
                }
                else if (listDichVu[canLamSan.MaDichVu] == 2)
                {
                    // thêm mới
                    if (canLamSan.SpDichVuChiTiet(ref err, "INSERT"))
                        listDichVu[canLamSan.MaDichVu] = 1;
                }
                if (!string.IsNullOrEmpty(err))
                {
                    XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            LuuKetQua();
        }

        private void btnLuuIn_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            LuuKetQua();
            InPhieu();
            SplashScreenManager.CloseForm();
        }
        private void InPhieu()
        {
            frmMauPhieu.HoTen = this.HoTen;
            frmMauPhieu.NamSinh = this.NamSinh;
            frmMauPhieu.GioiTinh = this.GioiTinh == "0" ? "Nam" : "Nữ";
            frmMauPhieu.ChuanDoan = this.ChuanDoan;
            frmMauPhieu.YeuCau = this.YeuCau;
            frmMauPhieu.BSCD =Utils.ToString( lookUpBacSi.Properties.GetDisplayValueByKeyValue(this.MaBacSi));
            frmMauPhieu.BSCK = Utils.ToString(lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue));
            frmMauPhieu.MauSo = MauSo;
            frmMauPhieu.DiaChi = DiaChi;
            frmMauPhieu.SoThe = SoThe;
            frmMauPhieu.MaKhoa = Utils.ToString(lookUpMaKhoa.Properties.GetDisplayValueByKeyValue(lookUpMaKhoa.EditValue));
            frmMauPhieu.KetQua = ketQua;
            switch (MauSo)
            {
                case "14":
                    MauSo14();
                    break;
                case "19":
                    MauSo19();
                    break;
                case "22":
                    MauSo22();
                    break;
                case "23":
                    MauSo23();
                    break;
                case "25":
                    MauSo25();
                    break;
                case "27":
                    MauSo27();
                    break;
                case "28":
                    MauSo28();
                    break;
                case "33":
                    MauSo33();
                    break;
                case "340":
                    MauSo340();
                    break;
                case "341":
                    MauSo341();
                    break;
                case "342":
                    MauSo342();
                    break;
            }
            frmMauPhieu.ShowDialog();
        }
        private void MauSo19()
        {
            frmMauPhieu.MauFile = @"FileWord\19_Phieu-chieu-chup-X-quang.doc";
            //rptMauSo_19 rpt = new rptMauSo_19();

            //rpt.lblHoTen.Text = this.HoTen;
            //rpt.lblNamSinh.Text = this.NamSinh;
            //rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            //rpt.lblChuanDoan.Text = this.ChuanDoan;
            //rpt.lblYeuCau.Text = this.YeuCau;
            //rpt.lblNgay.Text = "Ngày " + DateTime.Now.Day + " tháng " +
            //    DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //rpt.lblHoTenBS.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue);
            //rpt.cellKetQua.Text = ketQua;
            //rpt.CreateDocument();
            //rpt.ShowPreviewDialog();
        }
        private void MauSo22()
        {
            frmMauPhieu.MauFile = @"FileWord\22_Phieu-sieu-am.doc";
            //rptMauSo_22 rpt = new rptMauSo_22();
            //rpt.lblMauSo.Text = "MS: " + this.MauSo + "/BV-01";
            //rpt.lblHoTen.Text = this.HoTen;
            //rpt.lblNamSinh.Text = this.NamSinh;
            //rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            //rpt.lblChuanDoan.Text = this.ChuanDoan;
            //rpt.lblYeuCau.Text = this.YeuCau;
            //rpt.lblNgay.Text = "Ngày " + DateTime.Now.Day + " tháng " +
            //    DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //rpt.lblHoTenBS.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue);
            //rpt.lblKetQua.Text = ketQua;
            //rpt.lblKhoa.Text = lookUpMaKhoa.Properties.GetDisplayValueByKeyValue(lookUpMaKhoa.EditValue).ToString();
            //rpt.CreateDocument();
            //rpt.ShowPreviewDialog();
        }
        private void MauSo23()
        {
            frmMauPhieu.MauFile = @"FileWord\23_Phieu-dien-tim.doc";
            //rptMauSo_23 rpt = new rptMauSo_23();
            //rpt.lblMauSo.Text = "MS: " + this.MauSo + "/BV-01";
            //rpt.lblHoTen.Text = this.HoTen;
            //rpt.lblNamSinh.Text = this.NamSinh;
            //rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            //rpt.lblChuanDoan.Text = this.ChuanDoan;
            //rpt.lblYeuCau.Text = this.YeuCau;
            //rpt.lblNgay.Text = "Ngày " + DateTime.Now.Day + " tháng " +
            //    DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //rpt.lblHoTenBS.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue);
            //rpt.lblKetQua.Text = ketQua;
            //rpt.lblKhoa.Text = lookUpMaKhoa.Properties.GetDisplayValueByKeyValue(lookUpMaKhoa.EditValue).ToString();
            //rpt.CreateDocument();
            //rpt.ShowPreviewDialog();
        }
        private void MauSo25()
        {
            frmMauPhieu.MauFile = @"FileWord\25_Phieu-noi-soi.doc";
            //rptMauSo_25 rpt = new rptMauSo_25();
            //rpt.lblHoTenBS.Text = this.HoTen;
            //rpt.lblNamSinh.Text = this.NamSinh;
            //rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            //rpt.lblChuanDoan.Text = this.ChuanDoan;
            //rpt.lblYeuCau.Text = this.YeuCau;
            //rpt.lblNgay.Text = "Ngày " + DateTime.Now.Day + " tháng " +
            //    DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //rpt.lblHoTenBS.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue);
            //rpt.lblKetQua.Text = ketQua;
            //rpt.CreateDocument();
            //rpt.ShowPreviewDialog();
        }
        private void MauSo27()
        {
            frmMauPhieu.MauFile = @"FileWord\27_Phieu-xet-nghiem.doc";
            //rptMauSo_27 rpt = new rptMauSo_27();

            //rpt.lblHoTen.Text = this.HoTen;
            //rpt.lblNamSinh.Text = this.NamSinh;
            //rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            //rpt.lblChuanDoan.Text = this.ChuanDoan;
            //rpt.lblYeuCau.Text = this.YeuCau;
            //rpt.lblNgay.Text = "Ngày " + DateTime.Now.Day + " tháng " +
            //    DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //rpt.lblHoTenBS.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue);
            //rpt.cellKetQua.Text = ketQua;
            //rpt.CreateDocument();
            //rpt.ShowPreviewDialog();
        }
        private void MauSo28()
        {
            frmMauPhieu.MauFile = @"FileWord\28_Phieu-xet-nghiem-huyet-hoc.doc";
            //rptMauSo_28 rpt = new rptMauSo_28();
            //rpt.lblHoTen.Text = this.HoTen;
            //rpt.lblNamSinh.Text = this.NamSinh;
            //rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            //rpt.lblChuanDoan.Text = this.ChuanDoan;
            //rpt.lblDiaChi.Text = this.DiaChi;
            //rpt.lblSoThe.Text = this.SoThe;
            //rpt.lblNgay.Text = DateTime.Now.Hour + " giờ " + DateTime.Now.Minute + " ngày " + DateTime.Now.Day + " tháng " +
            //    DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //rpt.lblHoTenBS.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue);
            //rpt.lblKhoa.Text = lookUpMaKhoa.Properties.GetDisplayValueByKeyValue(lookUpMaKhoa.EditValue).ToString();
            foreach (DataRowView drv in dvDichVu)
            {
                switch (drv["MaDichVu"].ToString())
                {
                    case "22.0138.1362":
                        //rpt.cellSotRet.Text = drv["GiaTri"].ToString();
                        frmMauPhieu.SotRet = drv["GiaTri"].ToString();
                        break;
                }
            }
            //    rpt.CreateDocument();
            //rpt.ShowPreviewDialog();
        }
        private void MauSo33()
        {
            frmMauPhieu.MauFile = @"FileWord\33_Phieu-xet-nghiem-hoa-sinh-mau.doc";
            //rptMauSo_33 rpt = new rptMauSo_33();
            //rpt.lblHoTen.Text = this.HoTen;
            //rpt.lblNamSinh.Text = this.NamSinh;
            //rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            //rpt.lblChuanDoan.Text = this.ChuanDoan;
            //rpt.lblDiaChi.Text = this.DiaChi;
            //rpt.lblSoThe.Text = this.SoThe;
            //rpt.lblNgay.Text = DateTime.Now.Hour + " giờ " + DateTime.Now.Minute + " ngày " + DateTime.Now.Day + " tháng " +
            //    DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //rpt.lblHoTenBS.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue);
            //rpt.lblKhoa.Text = Utils.ToString(lookUpMaKhoa.Properties.GetDisplayValueByKeyValue(lookUpMaKhoa.EditValue));
            foreach (DataRowView dr in dvDichVu)
            {
                switch (dr["MaDichVu"].ToString())
                {
                    case "23.0166.1494":
                        //rpt.cellUre.Text = dr["GiaTri"].ToString();
                        frmMauPhieu.GTUre = dr["GiaTri"].ToString();
                        break;
                    case "23.0075.1494":
                        //rpt.cellGluco.Text = dr["GiaTri"].ToString();
                        frmMauPhieu.GTGlu = dr["GiaTri"].ToString();
                        break;
                    case "23.0051.1494":
                        //rpt.cellCrea.Text = dr["GiaTri"].ToString();
                        frmMauPhieu.GTCre = dr["GiaTri"].ToString();
                        break;
                    case "23.0003.1494":
                        //rpt.cellAcid.Text = dr["GiaTri"].ToString();
                        frmMauPhieu.GTAci = dr["GiaTri"].ToString();
                        break;
                    case "23.0041.1506":
                        //rpt.cellCholes.Text = dr["GiaTri"].ToString();
                        frmMauPhieu.GTCho = dr["GiaTri"].ToString();
                        break;
                    case "23.0158.1506":
                        //rpt.cellTrigly.Text = dr["GiaTri"].ToString();
                        frmMauPhieu.GTTri = dr["GiaTri"].ToString();
                        break;
                    case "23.0084.1506":
                        //rpt.cellHDL.Text = dr["GiaTri"].ToString();
                        frmMauPhieu.GTHDL = dr["GiaTri"].ToString();
                        break;
                    case "23.0112.1506":
                        //rpt.cellLDL.Text = dr["GiaTri"].ToString();
                        frmMauPhieu.GTLDL = dr["GiaTri"].ToString();
                        break;
                    case "23.0020.1493":
                        //rpt.cellAST.Text = dr["GiaTri"].ToString();
                        frmMauPhieu.GTAST = dr["GiaTri"].ToString();
                        break;
                    case "23.0019.1493":
                        //rpt.cellALT.Text = dr["GiaTri"].ToString();
                        frmMauPhieu.GTALT = dr["GiaTri"].ToString();
                        break;
                    case "23.0077.1518":
                        //rpt.cellGGT.Text = dr["GiaTri"].ToString();
                        frmMauPhieu.GTGGT = dr["GiaTri"].ToString();
                        break;
                }
            }
            //rpt.CreateDocument();
            //rpt.ShowPreviewDialog();
        }
        private void MauSo340()
        {
            frmMauPhieu.MauFile = @"FileWord\34_0Phieu-xet-nghiem-hoa-sinh-nuoc-tieu.doc";
            //rptMauSo_340 rpt = new rptMauSo_340();
            //rpt.lblHoTen.Text = this.HoTen;
            //rpt.lblNamSinh.Text = this.NamSinh;
            //rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            //rpt.lblChuanDoan.Text = this.ChuanDoan;
            //rpt.lblDiaChi.Text = this.DiaChi;
            //rpt.lblSoThe.Text = this.SoThe;
            //rpt.lblNgay.Text = DateTime.Now.Hour + " giờ " + DateTime.Now.Minute + " ngày " + DateTime.Now.Day + " tháng " +
            //    DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //rpt.lblHoTenBS.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue);
            //rpt.lblKhoa.Text = lookUpMaKhoa.Properties.GetDisplayValueByKeyValue(lookUpMaKhoa.EditValue).ToString();
            //rpt.CreateDocument();
            //rpt.ShowPreviewDialog();
        }
        private void MauSo341()
        {
            frmMauPhieu.MauFile = @"FileWord\34_1Phieu-xet-nghiem-phan.doc";
            //rptMauSo_341 rpt = new rptMauSo_341();
            //rpt.lblHoTen.Text = this.HoTen;
            //rpt.lblNamSinh.Text = this.NamSinh;
            //rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            //rpt.lblChuanDoan.Text = this.ChuanDoan;
            //rpt.lblDiaChi.Text = this.DiaChi;
            //rpt.lblSoThe.Text = this.SoThe;
            //rpt.lblNgay.Text = DateTime.Now.Hour + " giờ " + DateTime.Now.Minute + " ngày " + DateTime.Now.Day + " tháng " +
            //    DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //rpt.lblHoTenBS.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue);
            //rpt.lblKhoa.Text = lookUpMaKhoa.Properties.GetDisplayValueByKeyValue(lookUpMaKhoa.EditValue).ToString();
            //rpt.CreateDocument();
            //rpt.ShowPreviewDialog();
        }
        private void MauSo342()
        {
            frmMauPhieu.MauFile = @"FileWord\34_2Phieu-xet-nghiem-hoa-sinh-dich-choc-do.doc";
            //rptMauSo_342 rpt = new rptMauSo_342();
            //rpt.lblHoTen.Text = this.HoTen;
            //rpt.lblNamSinh.Text = this.NamSinh;
            //rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            //rpt.lblChuanDoan.Text = this.ChuanDoan;
            //rpt.lblDiaChi.Text = this.DiaChi;
            //rpt.lblSoThe.Text = this.SoThe;
            //rpt.lblNgay.Text = DateTime.Now.Hour + " giờ " + DateTime.Now.Minute + " ngày " + DateTime.Now.Day + " tháng " +
            //    DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //rpt.lblHoTenBS.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue);
            //rpt.lblKhoa.Text = lookUpMaKhoa.Properties.GetDisplayValueByKeyValue(lookUpMaKhoa.EditValue).ToString();
            //rpt.CreateDocument();
            //rpt.ShowPreviewDialog();
        }
        private void MauSo14()
        {
            frmMauPhieu.MauFile = @"FileWord\14_Phieu-phau-thuat-thu-thuat.doc";
        }
    }
}
