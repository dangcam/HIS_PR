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
    public partial class FrmCDCanLamSan : RibbonForm
    {
        KhamBenhEntity khambenh;
        public string MaLK { get; set; }
        public string HoTen { get; set; }
        public string NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string TheBHYT { get; set; }
        public string GioiTinh { get; set; }
        private DataView data;
        public FrmCDCanLamSan(KhamBenhEntity khambenh=null)
        {
            InitializeComponent();
            this.khambenh = khambenh;
            if(this.khambenh == null)
            {
                this.khambenh = new KhamBenhEntity();
            }
            lookUpBacSi.Properties.DataSource = this.khambenh.DSBacSi();
            lookUpBacSi.Properties.ValueMember = "Ma_BS";
            lookUpBacSi.Properties.DisplayMember = "Ten_NV";
           
        }

        private void FrmCDCanLamSan_Load(object sender, EventArgs e)
        {
            if (lookUpBacSi.ItemIndex <0)
            {
                lookUpBacSi.ItemIndex = 0;
            }
            this.ActiveControl = lookUpBacSi;
            txtHoTen.Text = this.HoTen;
            khambenh.MaLK = MaLK;
            data = khambenh.DSChiDinhCanLamSan(this.MaLK).AsDataView();
            gridControl.DataSource = data;
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.Name == "Chon")
            {
                bool chon = Utils.ToBoolean(e.Value);
                khambenh.MaCSL = gridView.GetRowCellValue(e.RowHandle, gridView.Columns["Ma"]).ToString();
                khambenh.NgayChiDinh = DateTime.Now.ToShortDateString();
                khambenh.MaBS = lookUpBacSi.EditValue.ToString();
                gridView.SetFocusedRowCellValue("NgayChiDinh", khambenh.NgayChiDinh);
                gridView.SetFocusedRowCellValue("MaBS", khambenh.MaBS);
                string err = null;
                if(chon)
                {
                    khambenh.SpCDCanLamSan(ref err, "INSERT");
                }
                else
                {
                    if (!Utils.ToBoolean(gridView.GetRowCellValue(e.RowHandle, gridView.Columns["KetQua"])))
                    {
                        khambenh.SpCDCanLamSan(ref err, "DELETE");
                    }
                    else
                    {
                        this.gridView.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
                        XtraMessageBox.Show("Cận lâm sàn đã có kết quả, không thể xóa!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        gridView.SetFocusedRowCellValue("Chon",true);
                        this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LuuCanLamSan();
        }
        private void LuuCanLamSan(bool inPhieu = false)
        {
            string chuanDoan = "";
            string yeuCau = "";
            int i = 1;
            foreach(DataRowView dr in data)
            {
                if (Utils.ToBoolean(dr["Chon"]))
                {
                    khambenh.MaCSL = dr["Ma"].ToString();
                    khambenh.MaBS = dr["MaBS"].ToString();
                    khambenh.ChuanDoan = dr["ChuanDoan"].ToString();
                    khambenh.YeuCau = dr["YeuCau"].ToString();
                    khambenh.NgayChiDinh = dr["NgayChiDinh"].ToString();
                    string err = null;
                    if(khambenh.SpCDCanLamSan(ref err, "UPDATE"))
                    {
                        // in phiếu
                        chuanDoan += khambenh.ChuanDoan+", ";
                        yeuCau += i+". "+dr["Ten"].ToString() + ": " + khambenh.YeuCau + "\n";
                        i++;
                    }
                }
            }
            if(inPhieu)
            {
                TaoPhieu(chuanDoan,yeuCau);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            LuuCanLamSan(true);
        }
        private void TaoPhieu(string chuanDoan,string yeuCau)
        {
            RptPhieuYeuCau rpt = new RptPhieuYeuCau();
            rpt.lblHoTen.Text = this.HoTen;
            rpt.lblNamSinh.Text = this.NamSinh;
            rpt.lblGioiTinh.Text = this.GioiTinh == "0" ? "Nam" : "Nữ";
            //rpt.lblMauSo.Text = "MS:" + dr["MauSo"] + "/BV-01";
            rpt.lblDiaChi.Text = this.DiaChi;
            rpt.lblSoThe.Text = this.TheBHYT;
            rpt.lblChuanDoan.Text = chuanDoan;//khambenh.ChuanDoan;
            rpt.xrRTYeuCau.Text = yeuCau;//khambenh.YeuCau;
            rpt.lblNgayThang.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //rpt.lblTenPhieu.Text= "PHIẾU " + dr["Ten"].ToString().ToUpper();
            //rpt.lblTenBacSi.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(dr["MaBS"]);
            rpt.lblTenBacSi.Text = "Họ tên: " + lookUpBacSi.Properties.GetDisplayValueByKeyValue(lookUpBacSi.EditValue);
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
        }
    }
}
