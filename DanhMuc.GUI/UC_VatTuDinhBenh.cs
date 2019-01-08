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
using DevExpress.XtraEditors;

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
            lookUpDinhBenh.Properties.DataSource = vatTuDinhBenhEntity.DSBenhIDC();
            lookUpDinhBenh.Properties.DisplayMember = "TenBenh";
            lookUpDinhBenh.Properties.ValueMember = "MaBenh";
        }
        private void LoadDinhBenh()
        {
            gridControlDinhBenh.DataSource = vatTuDinhBenhEntity.DSVatTuDinhBenh();
        }

        private void lookUpLoaiVatTu_EditValueChanged(object sender, EventArgs e)
        {
            vatTuDinhBenhEntity.LoaiVatTu = Utils.ToString(lookUpLoaiVatTu.EditValue);
            gridControlVatTu.DataSource = vatTuDinhBenhEntity.DSVatTu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (vatTuDinhBenhEntity.LoaiVatTu != null && vatTuDinhBenhEntity.MaVatTu != null)
            {
                vatTuDinhBenhEntity.MaBenh = Utils.ToString(lookUpDinhBenh.EditValue);
                string err = "";
                if(!vatTuDinhBenhEntity.SpVatTuDinhBenh(ref err,"INSERT"))
                {
                    XtraMessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadDinhBenh();
            }
        }

        private void gridViewVatTu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridViewVatTu.GetFocusedDataRow();
            if(dr!=null)
            {
                string MaBV = Utils.ToString(dr["MaBV"]);
                vatTuDinhBenhEntity.MaVatTu = MaBV;
                LoadDinhBenh();
            }
        }

        private void repbtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = gridViewDinhBenh.GetFocusedDataRow();
            if (dr != null)
            {
                string err = "";
                // tiến hành xóa trong csdl
                vatTuDinhBenhEntity.MaBenh = Utils.ToString(dr["MaBenh"]);
                if (!vatTuDinhBenhEntity.SpVatTuDinhBenh(ref err, "DELETE"))
                {
                    XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadDinhBenh();
            }
            
        }
    }
}
