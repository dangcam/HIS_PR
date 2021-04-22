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
    public partial class FrmTongHop7980A : RibbonForm
    {
        public FrmTongHop7980A()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmTongHop7980A_Load(object sender, EventArgs e)
        {
            cbThang.SelectedIndex = DateTime.Now.Month - 1;
            int nam = DateTime.Now.Year;
            for(int i = nam - 5; i < nam + 6; i++)
            {
                cbNam.Properties.Items.Add(i);
            }
            cbNam.SelectedIndex = 5;
            cbBaoCao.SelectedIndex = 0;
        }
    }
}
