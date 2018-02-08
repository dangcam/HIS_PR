using BaoCao.DAL;
using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaoCao.GUI
{
    public partial class FrmTongHopBaoCao : RibbonForm
    {
        TongHopEntity tongHop;
        DataTable dataTongHop;
        public FrmTongHopBaoCao()
        {
            InitializeComponent();
            tongHop = new TongHopEntity();
            lookUpKhoa.Properties.DataSource = tongHop.DSKhoaBan(1);
            lookUpKhoa.Properties.ValueMember = "MaKhoa";
            lookUpKhoa.Properties.DisplayMember = "TenKhoa";
        }

        private void FrmTongHopBaoCao_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cbLoaiBaoCao;
            for(int i = DateTime.Now.Year-10;i<DateTime.Now.Year+10;i++)
            {
                cbNam.Properties.Items.Add(i);
            }
            dateDenNgay.DateTime = DateTime.Now;
            dateTuNgay.DateTime = DateTime.Now;
            cbThang.SelectedIndex = DateTime.Now.Month - 1;
            cbNam.SelectedItem = DateTime.Now.Year;
            cbLoaiBaoCao.SelectedIndex = 0;
            lookUpKhoa.ItemIndex = 0;
            cbQuy.SelectedIndex = (DateTime.Now.Month+5) / 3-2;
            cbThoiGian.SelectedIndex = 0;
        }
        private void cbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThoiGian.SelectedIndex == 0)
            {
                // giai đoạn
                cbNam.Hide();
                cbThang.Hide();
                cbQuy.Hide();
                dateDenNgay.Show();
                dateTuNgay.Show();
            }
            else
                if (cbThoiGian.SelectedIndex == 1)
            {
                // tháng
                cbNam.Show();
                cbThang.Show();
                cbQuy.Hide();
                dateDenNgay.Hide();
                dateTuNgay.Hide();
            }
            else
                if (cbThoiGian.SelectedIndex == 2)
            {
                // quý
                cbNam.Show();
                cbQuy.Show();
                cbThang.Hide();
                dateDenNgay.Hide();
                dateTuNgay.Hide();
            }
            else
            {
                // năm
                cbNam.Show();
                cbThang.Hide();
                cbQuy.Hide();
                dateDenNgay.Hide();
                dateTuNgay.Hide();
            }
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad));
            string maKhoa = lookUpKhoa.EditValue.ToString();
            DateTime tuNgay, denNgay;
            if (cbThoiGian.SelectedIndex == 0)
            {
                //Giai đoạn
                tuNgay = dateTuNgay.DateTime;
                denNgay = dateDenNgay.DateTime;
            }
            else if (cbThoiGian.SelectedIndex == 1)
            {
                //Tháng
                tuNgay = Utils.ToDateTime("01/"+cbThang.SelectedItem+"/"+cbNam.SelectedItem, "dd/MM/yyyy");
                denNgay = Utils.ToDateTime(Utils.LastDay(Utils.ToInt(cbNam.SelectedItem),cbThang.SelectedIndex+1) +
                    "/" + cbThang.SelectedItem + "/" + cbNam.SelectedItem, "dd/MM/yyyy");
            }
            else if (cbThoiGian.SelectedIndex == 2)
            {
                string thangDau, thangCuoi;
                //Quý
                if(cbQuy.SelectedIndex==0)
                {
                    // Quý 1
                    thangDau = "01";
                    thangCuoi = "03";
                }else
                    if(cbQuy.SelectedIndex==1)
                {
                    // Quý 2
                    thangDau = "04";
                    thangCuoi = "06";
                }
                else if(cbQuy.SelectedIndex==2)
                {
                    // Quý 3
                    thangDau = "07";
                    thangCuoi = "10";
                }
                else
                {
                    // Quý 4
                    thangDau = "11";
                    thangCuoi = "12";
                }
                tuNgay = Utils.ToDateTime("01/" + thangDau + "/" + cbNam.SelectedItem, "dd/MM/yyyy");
                denNgay = Utils.ToDateTime(Utils.LastDay(Utils.ToInt(cbNam.SelectedItem), Utils.ToInt(thangCuoi)) +
                    "/" + thangCuoi + "/" + cbNam.SelectedItem, "dd/MM/yyyy");
            }
            else
            {
                //Năm
                tuNgay = Utils.ToDateTime("01/01/" + cbNam.SelectedItem, "dd/MM/yyyy");
                denNgay = Utils.ToDateTime(Utils.LastDay(Utils.ToInt(cbNam.SelectedItem),12) + 
                    "/12/" + cbNam.SelectedItem, "dd/MM/yyyy");
            }
            if (cbLoaiBaoCao.SelectedIndex==0)
            {
                //Tổng hợp tiền bệnh nhân thanh toán
                dataTongHop = tongHop.DSBenhNhan(maKhoa, tuNgay, denNgay);
                RptTongHopBNTT rpt = new RptTongHopBNTT();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if(cbLoaiBaoCao.SelectedIndex==1)
            {
                //Tổng hợp vật tư y tế
                dataTongHop = tongHop.DSVatTu(maKhoa, tuNgay, denNgay);
                RptTongHopVatTu rpt = new RptTongHopVatTu();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if(cbLoaiBaoCao.SelectedIndex==2)
            {
                //Tổng hợp thuốc
                dataTongHop = tongHop.DSDonThuoc(maKhoa, tuNgay, denNgay);
                RptTongHopThuoc rpt = new RptTongHopThuoc();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if (cbLoaiBaoCao.SelectedIndex == 3)
            {
                //Tổng hợp dịch vụ kỹ thuật
                dataTongHop = tongHop.DSDichVuKyThuat(maKhoa, tuNgay, denNgay);
                RptTongHopDichVu rpt = new RptTongHopDichVu();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if(cbLoaiBaoCao.SelectedIndex == 4)
            {
                // Tổng hợp viện phí
                RptTongHopVienPhi rpt = new RptTongHopVienPhi();
                dataTongHop = tongHop.DSVienPhi(maKhoa, tuNgay, denNgay);
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if(cbLoaiBaoCao.SelectedIndex ==5)
            {
                //Tổng hợp số lượng thuốc
                dataTongHop = tongHop.DSSoLuongThuoc(maKhoa, tuNgay, denNgay);
                RptSoLuongThuoc rpt = new RptSoLuongThuoc();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else if(cbLoaiBaoCao.SelectedIndex == 6)
            {
                // số liệu mẫu 7980A
                dataTongHop = tongHop.DSMauSo7980A(maKhoa,tuNgay,denNgay);
                RptSoLieuMau7980A rpt = new RptSoLieuMau7980A();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                rpt.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }
            else
            {
                // chi tiết thuốc
                dataTongHop = tongHop.DSChiTietThuoc(maKhoa, tuNgay, denNgay);
                RptTongHopChiTietThuoc rpt = new RptTongHopChiTietThuoc();
                rpt.xrlblCoSo.Text = AppConfig.CoSoKCB;
                rpt.xrlblTuNgayDenNgay.Text = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") +
                    " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                rpt.xrlblKhoa.Text = lookUpKhoa.Properties.GetDisplayValueByKeyValue(lookUpKhoa.EditValue).ToString();
                //rpt.xrlblNgayLap.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                //rpt.DataSource = dataTongHop;
                rpt.xrPivotGrid.DataSource = dataTongHop;
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
            }

            SplashScreenManager.CloseForm();
        }
        private void TaoBaoCao()
        {
            //dataTongHop;
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
