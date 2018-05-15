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
using DevExpress.XtraEditors;
using Core.DAL;

namespace DanhMuc.GUI
{
    public partial class UC_VatTuYTe : UserControl
    {
        VatTuYTeEntity vatTuYTe;
        bool them = false;
        string quyen;
        public UC_VatTuYTe()
        {
            InitializeComponent();
            vatTuYTe = new VatTuYTeEntity();
        }

        private void UC_VatTuYTe_Load(object sender, EventArgs e)
        {
            lookUpDonViTinh.Properties.DataSource = vatTuYTe.DSDonViTinh();
            lookUpDonViTinh.Properties.ValueMember = "Ten";
            lookUpDonViTinh.Properties.DisplayMember = "Ten";
            LoadData();
            CheckButton();
        }
        private void LoadData()
        {
            gridControl.DataSource = vatTuYTe.DSVatTuYTe();
            them = false;
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            them = true;
            txtMaVatTu.ReadOnly = false;
            txtMaVatTu.Text = "";
            txtTenVatTu.Text = "";
            txtDonGia.Text = "";
            txtQuyetDinh.Text = "QĐ";
            txtCongBo.Text = DateTime.Now.ToString("yyyyMMdd");
            Enabled_Luu();
            btnXoa.Enabled = false;
        }
        private void CheckButton()
        {
            quyen = Core.DAL.Utils.GetQuyen(this.Name);
            Enabled_Them();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void Enabled_Luu()
        {
            if (quyen.IndexOf('2') >= 0 || them)
            {
                btnLuu.Enabled = true;
            }
            else
            {
                btnLuu.Enabled = false;
            }
        }
        private void Enabled_Xoa()
        {
            if (quyen.IndexOf('3') >= 0)
            {
                btnXoa.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }
        private void Enabled_Them()
        {
            if (quyen.IndexOf('1') >= 0)
            {
                btnMoi.Enabled = true;
            }
            else
            {
                btnMoi.Enabled = false;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaVatTu.Text.Length<1)
            {
                XtraMessageBox.Show("Nhập mã vật tư y tế!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string err = "";
            vatTuYTe.MaVatTu = txtMaVatTu.Text;
            vatTuYTe.TenVatTu = txtTenVatTu.Text;
            vatTuYTe.DonViTinh = Utils.ToString(lookUpDonViTinh.EditValue);
            vatTuYTe.DonGiaBV = Utils.ToDecimal(txtDonGia.Text);
            vatTuYTe.CongBo = txtCongBo.Text;
            vatTuYTe.QuyetDinh = txtQuyetDinh.Text;
            if (them)
            {
                if (vatTuYTe.SpVatTuYTe(ref err, "INSERT"))
                    LoadData();
            }
            else
            {
                if (vatTuYTe.SpVatTuYTe(ref err, "UPDATE"))
                    LoadData();
            }
            if(!string.IsNullOrEmpty(err))
            {
                XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            string err = "";
            traloi = XtraMessageBox.Show("Chắc chắn bạn muốn xóa mục này?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if (!vatTuYTe.SpVatTuYTe(ref err, "DELETE"))
                {
                    XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadData();
            }
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridView.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                txtMaVatTu.Text = dr["MaVatTu"].ToString();
                txtTenVatTu.Text = dr["TenVatTu"].ToString();
                txtDonGia.Text = dr["DonGiaBV"].ToString();
                lookUpDonViTinh.EditValue = dr["DonViTinh"];
                txtQuyetDinh.Text = dr["QuyetDinh"].ToString();
                txtCongBo.Text = dr["CongBo"].ToString();

                vatTuYTe.MaVatTu = txtMaVatTu.Text;

                txtMaVatTu.ReadOnly = true;
                them = false;

                Enabled_Xoa();
                Enabled_Luu();
            }
        }
    }
}
