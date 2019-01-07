using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DanhMuc.DAL;
using Core.DAL;

namespace DanhMuc.GUI
{
    public partial class UC_VatTuDinhBenh : UserControl
    {
        VatTuDinhBenhEntity vatTuDinhBenhEntity;
        public UC_VatTuDinhBenh()
        {
            InitializeComponent();
            vatTuDinhBenhEntity = new VatTuDinhBenhEntity();
        }

        private void UC_VatTuDinhBenh_Load(object sender, EventArgs e)
        {
            lookUpLoaiVatTu.Properties.DataSource = vatTuDinhBenhEntity.DSLoaiVatTu();
            lookUpLoaiVatTu.Properties.DisplayMember = "Ten";
            lookUpLoaiVatTu.Properties.ValueMember = "Ma";
        }

        private void lookUpLoaiVatTu_EditValueChanged(object sender, EventArgs e)
        {
            vatTuDinhBenhEntity.LoaiVatTu = Utils.ToString(lookUpLoaiVatTu.EditValue);
            gridControlVatTu.DataSource = vatTuDinhBenhEntity.DSVatTu();
        }
    }
}
