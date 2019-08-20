using BaoCao.DAL;
using Core.DAL;
using DevExpress.XtraBars.Ribbon;
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
    public partial class FrmTongHopKeDon : RibbonForm
    {
        TongHopKeDonEntity tongHopKeDonEntity;
        public FrmTongHopKeDon()
        {
            InitializeComponent();
            tongHopKeDonEntity = new TongHopKeDonEntity();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmTongHopKeDon_Load(object sender, EventArgs e)
        {
            dateTuNgay.DateTime = DateTime.Now;
            dateDenNgay.DateTime = DateTime.Now;
            lookUpMaKhoa.Properties.DataSource = tongHopKeDonEntity.DSKhoaBan(1);
            lookUpMaKhoa.ItemIndex = 0;
        }

        private void btnHomNay_Click(object sender, EventArgs e)
        {
            gridControl.DataSource = tongHopKeDonEntity.DSBacSi(Utils.ToString(lookUpMaKhoa.EditValue).Substring(0, 3), DateTime.Now);
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            gridControl.DataSource = tongHopKeDonEntity.DSBacSi(Utils.ToString(lookUpMaKhoa.EditValue).Substring(0, 3), dateTuNgay.DateTime,dateDenNgay.DateTime);
        }

        private void lookUpMaKhoa_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
