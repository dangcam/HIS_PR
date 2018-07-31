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
    public partial class UC_DVKT : UserControl
    {
        DichVuKyThuatEntity dvkt;
        bool them = false;
        string quyen = "";
        public UC_DVKT()
        {
            InitializeComponent();
            dvkt = new DichVuKyThuatEntity();
            lookUpCoSoKCB.Properties.DataSource = dvkt.DSCoSo();
            lookUpCoSoKCB.Properties.ValueMember = "Ma_CS";
            lookUpCoSoKCB.Properties.DisplayMember = "Ten_CS";
            DataTable dataNhom = dvkt.DSNhom();
            lookUpNhom.Properties.DataSource = dataNhom;
            lookUpNhom.Properties.DisplayMember = "TenNhom";
            lookUpNhom.Properties.ValueMember = "MaNhom";

            repLookUpNhom.DataSource = dataNhom;
            repLookUpNhom.DisplayMember = "TenNhom";
            repLookUpNhom.ValueMember = "MaNhom";

            
            lookUpNhomCLS.Properties.ValueMember = "Ma";
            lookUpNhomCLS.Properties.DisplayMember = "Ten";

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
                btnNhapExcel.Enabled = true;
            }
            else
            {
                btnMoi.Enabled = false;
                btnNhapExcel.Enabled = false;
            }
        }
        private void LoadData()
        {
            them = false;
            gridControl.DataSource = dvkt.DSDVKT();
        }
        private void UC_DVKT_Load(object sender, EventArgs e)
        {
            LoadData();
            CheckButton();
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            DialogResult dr = ImportExcel.OpenDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void lookUpCoSoKCB_EditValueChanged(object sender, EventArgs e)
        {
            dvkt.MaCS = lookUpCoSoKCB.EditValue.ToString();
            gridControl.DataSource = dvkt.DSDVKT();
            lookUpNhomCLS.Properties.DataSource = dvkt.DSNhomCanLamSan();
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridView.GetDataRow(e.RowHandle);
            if(dr!=null)
            {
                txtMa.Text = dr["MaDVKT"].ToString();
                txtTen.Text = dr["TenDVKT"].ToString();
                txtDonGia.Text = dr["DonGia"].ToString();
                lookUpNhom.EditValue = dr["MaNhom"];
                lookUpNhomCLS.EditValue = dr["MaNhomCLS"];
                checkTinhTrang.Checked = Utils.ToBoolean(dr["TinhTrang"]);
                lookUpCoSoKCB.EditValue = dr["Ma_CS"];
                txtTT50.Text = dr["TT50"].ToString();
                dvkt.MaDVKT = txtMa.Text;
                dvkt.MaCS = dr["Ma_CS"].ToString();

                txtMa.ReadOnly = true;
                them = false;

                Enabled_Xoa();
                Enabled_Luu();
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            them = true;
            txtDonGia.Text = "";
            txtMa.Text = "";
            txtTen.Text = "";
            txtMa.ReadOnly = false;
            checkTinhTrang.Checked = true;
            Enabled_Luu();
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMa.Text.Length<1)
            {
                XtraMessageBox.Show("Nhập mã dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dvkt.MaDVKT = txtMa.Text;
            dvkt.TenDVKT = txtTen.Text;
            dvkt.MaCS = Utils.ToString(lookUpCoSoKCB.EditValue);
            dvkt.DonGia = Utils.ToDecimal(txtDonGia.Text);
            dvkt.TinhTrang = checkTinhTrang.Checked;
            dvkt.MaNhom = Utils.ToInt(lookUpNhom.EditValue);
            dvkt.MaNhomCLS = Utils.ToString(lookUpNhomCLS.EditValue);
            dvkt.TT50 = txtTT50.Text;
            string err = "";
            if (them)
            {
                if (dvkt.SpDichVuKyThuat(ref err, "INSERT"))
                {
                    LoadData();
                }
            }
            else
            {
                if (dvkt.SpDichVuKyThuat(ref err, "UPDATE"))
                {
                    LoadData();
                }
            }
            if (!string.IsNullOrEmpty(err))
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
                if (!dvkt.SpDichVuKyThuat(ref err, "DELETE"))
                {
                    XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadData();
            }
        }
    }
}
