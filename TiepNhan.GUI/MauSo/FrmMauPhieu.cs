using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiepNhan.GUI.MauSo
{
    public partial class FrmMauPhieu : RibbonForm
    {
        public FrmMauPhieu()
        {
            InitializeComponent();
        }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string SoThe { get; set; }
        public string MaKhoa { get; set; }
        public string ChuanDoan { get; set; }
        public string YeuCau { get; set; }
        public string BSCD { get; set; }
        public string BSCK { get; set; }
        public string MauSo { get; set; }
        public string KetQua { get; set; }
        public string MauFile { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        //
        public string SotRet { get; set; }// mẫu 28
        // mẫu số 33
        public string GTUre { get; set; }
        public string GTGlu { get; set; }
        public string GTCre { get; set; }
        public string GTAci { get; set; }
        public string GTCho { get; set; }
        public string GTTri { get; set; }
        public string GTHDL { get; set; }
        public string GTLDL { get; set; }
        public string GTAST { get; set; }
        public string GTALT { get; set; }
        public string GTGGT { get; set; }
        private void FrmMauPhieu_Load(object sender, EventArgs e)
        {
            snapControl.LoadDocument(MauFile);
            
            DocumentRange[] ranges = snapControl.Document.FindAll("<NgayThangNam>", SearchOptions.None);
            foreach (DocumentRange range in ranges)
            {
                //use following code to change text ForeColor
                //CharacterProperties properties = snapControl1.Document.BeginUpdateCharacters(range);
                //properties.ForeColor = Color.Red;
                //snapControl1.Document.EndUpdateCharacters(properties);
                //or this code to create hyperlink
                //Hyperlink hyperlink = snapControl1.Document.Hyperlinks.Create(range);
                this.snapControl.Document.Replace(range, "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year);
            }
            ranges = snapControl.Document.FindAll("<TenBenhNhan>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], HoTen);
            ranges = snapControl.Document.FindAll("<NamSinh>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], NamSinh);
            ranges = snapControl.Document.FindAll("<GioiTinh>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], GioiTinh);
            ranges = snapControl.Document.FindAll("<DiaChi>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], DiaChi);
            ranges = snapControl.Document.FindAll("<SoThe>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], SoThe);
            ranges = snapControl.Document.FindAll("<TuNgay>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], TuNgay);
            ranges = snapControl.Document.FindAll("<DenNgay>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], DenNgay);
            ranges = snapControl.Document.FindAll("<KhoaBan>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], MaKhoa);
            ranges = snapControl.Document.FindAll("<SoThe>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], SoThe);
            ranges = snapControl.Document.FindAll("<ChuanDoan>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], ChuanDoan);
            ranges = snapControl.Document.FindAll("<YeuCau>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], YeuCau);
            ranges = snapControl.Document.FindAll("<KetQua>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], KetQua);
            ranges = snapControl.Document.FindAll("<ChuanDoan>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], ChuanDoan);
            ranges = snapControl.Document.FindAll("<BSCD>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], BSCD);
            ranges = snapControl.Document.FindAll("<BSCK>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], BSCK);
            ranges = snapControl.Document.FindAll("<GioThangNam>", SearchOptions.None);
            if (ranges.Length > 0)
                this.snapControl.Document.Replace(ranges[0], DateTime.Now.Hour +" giờ "+DateTime.Now.Minute+" phút, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year);
            switch (MauSo)
            {
                //case "19":
                //    //MauSo19();
                //    break;
                //case "22":
                //    //MauSo22();
                //    break;
                //case "23":
                //    //MauSo23();
                //    break;
                //case "25":
                //    //MauSo25();
                //    break;
                case "27":
                    //MauSo27();
                    snapControl.Document.Sections[0].Page.PaperKind = System.Drawing.Printing.PaperKind.A5;
                    break;
                case "28":
                    //MauSo28();
                    ranges = snapControl.Document.FindAll("<SotRet>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], SotRet);
                    break;
                case "33":
                    //MauSo33();
                    ranges = snapControl.Document.FindAll("<GTUre>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], GTUre);
                    ranges = snapControl.Document.FindAll("<GTGlu>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], GTGlu);
                    ranges = snapControl.Document.FindAll("<GTCre>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], GTCre);
                    ranges = snapControl.Document.FindAll("<GTAci>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], GTAci);
                    ranges = snapControl.Document.FindAll("<GTCho>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], GTCho);
                    ranges = snapControl.Document.FindAll("<GTTri>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], GTTri);
                    ranges = snapControl.Document.FindAll("<GTHDL>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], GTHDL);
                    ranges = snapControl.Document.FindAll("<GTLDL>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], GTLDL);
                    ranges = snapControl.Document.FindAll("<GTAST>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], GTAST);
                    ranges = snapControl.Document.FindAll("<GTALT>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], GTALT);
                    ranges = snapControl.Document.FindAll("<GTGGT>", SearchOptions.None);
                    if (ranges.Length > 0)
                        this.snapControl.Document.Replace(ranges[0], GTGGT);
                    break;
                case "340":
                    //MauSo340();
                    snapControl.Document.Sections[0].Page.PaperKind = System.Drawing.Printing.PaperKind.A5;
                    break;
                case "341":
                    //MauSo341();
                    snapControl.Document.Sections[0].Page.PaperKind = System.Drawing.Printing.PaperKind.A5;
                    break;
                case "342":
                    //MauSo342();
                    snapControl.Document.Sections[0].Page.PaperKind = System.Drawing.Printing.PaperKind.A5;
                    break;
            }
        }

    }
}
