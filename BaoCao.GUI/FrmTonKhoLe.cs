using BaoCao.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
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
    public partial class FrmTonKhoLe : RibbonForm
    {
        TonKhoLeEntity tonKhoLe;
        DataTable dtLoaiVatTu;
        DataTable dataDS;
        string maKho = "";
        public FrmTonKhoLe()
        {
            InitializeComponent();
            tonKhoLe = new TonKhoLeEntity();
            lookUpKho.Properties.DataSource = tonKhoLe.DSKhoLe();
            lookUpKho.Properties.ValueMember = "MaKhoa";
            lookUpKho.Properties.DisplayMember = "TenKhoa";
            dtLoaiVatTu = tonKhoLe.DSLoaiVatTu();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmTonKhoLe_Load(object sender, EventArgs e)
        {
            gridControlNhom.DataSource = dtLoaiVatTu;
            lookUpKho.ItemIndex = 0;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataRow[] dr = dtLoaiVatTu.Select("Chon = 1", "");
            maKho = lookUpKho.EditValue.ToString();
            if (dr.Length>0)
            {
                string sql = "";
                for(int i=0;i<dr.Length;i++)
                {
                    sql += sql.Length > 0 ? " Or Ma ='" + dr[i]["Ma"] + "'" :
                        "Ma = '" + dr[i]["Ma"] + "'";
                }
                // lấy dữ liệu từ sql
                sql = "KhoNhan='"+ maKho + "' And (" + sql + ")";
                dataDS = tonKhoLe.DSTonKhoVatTu(sql);
            }
            else
            {
                dataDS = null;
            }
            gridControl.DataSource = dataDS;
            gridView.ExpandAllGroups();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maKho))
                maKho = lookUpKho.EditValue.ToString();
            RptTonKhoLe rpt = new RptTonKhoLe();
            rpt.DataSource = dataDS;
            rpt.xrlblKhoa.Text = lookUpKho.Properties.GetDisplayValueByKeyValue(maKho).ToString();
            rpt.xrlblNgay.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
        }
    }
}
