using System;
using DevExpress.XtraBars.Ribbon;
using System.Windows.Forms;
using DanhMuc.DAL;
using System.Data;
using Core.DAL;

namespace DanhMuc.GUI
{
    public partial class FrmNhanVien : RibbonForm
    {
        NhanVienEntity nhanvien;
        DataRow dr;
        bool them = false;
        string quyen = "";
        public FrmNhanVien ()
        {
            InitializeComponent ();
            nhanvien = new NhanVienEntity ();
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmNhanVien_Load (object sender, EventArgs e)
        {
            lookUpChucVu.Properties.DataSource = nhanvien.DSChucVu ();
            lookUpChucVu.Properties.DisplayMember = "Ten_CV";
            lookUpChucVu.Properties.ValueMember = "Ma_CV";
            lookUpChucVu.ItemIndex = 0;

            lookUpCoSoKCB.Properties.DataSource = nhanvien.DSKhoaBanCap(1);
            lookUpCoSoKCB.Properties.ValueMember = "Ma_CS";
            lookUpCoSoKCB.Properties.DisplayMember = "Ten_CS";
            lookUpCoSoKCB.ItemIndex = 0;

            lookUpHocHamHocVi.Properties.DataSource = nhanvien.DSHocHamHocVi ();
            lookUpHocHamHocVi.Properties.DisplayMember = "Ten_HHHV";
            lookUpHocHamHocVi.Properties.ValueMember = "Ma_HHHV";
            lookUpHocHamHocVi.ItemIndex =0;

            
            lookUpKhoaBoPhan.Properties.ValueMember = "MaKhoa";
            lookUpKhoaBoPhan.Properties.DisplayMember = "TenKhoa";
            lookUpKhoaBoPhan.ItemIndex = 0;

            lookUpChuyenMon.Properties.DataSource = nhanvien.DSChuyenMon ();
            lookUpChuyenMon.Properties.ValueMember = "Ma_CM";
            lookUpChuyenMon.Properties.DisplayMember = "Ten_CM";
            lookUpChuyenMon.ItemIndex = 0;

            
            checkButton ();
            LoadData ();

        }
        private void LoadData()
        {
            them = false;
            gridControl.DataSource = nhanvien.DSNhanVien ();
        }
        private void checkButton ()
        {
            quyen = Core.DAL.Utils.GetQuyen (this.Name);
            Enabled_Them ();
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
        }
        private void Enabled_Luu ()
        {
            if (quyen.IndexOf ('2') >= 0 || them)
            {
                btnLuu.Enabled = true;
            }
            else
            {
                btnLuu.Enabled = false;
            }
        }
        private void Enabled_Xoa ()
        {
            if (quyen.IndexOf ('3') >= 0)
            {
                btnXoa.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = false;
            }  
        }
        private void Enabled_Them ()
        {
            if (quyen.IndexOf ('1') >= 0)
            {
                btnThem.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
            }
        }

        private void btnThem_Click (object sender, EventArgs e)
        {
            them = true;
            txtMa.ReadOnly = false;
            txtMa.Text = "";
            txtTen.Text = "";
            txtMatKhau.Text = "";
            txtMaBS.Text = "";
            checkTinhTrang.Checked = true;
            txtCCHN.Text = "";
            Enabled_Luu ();
        }
        private bool checkInput()
        {
            if(string.IsNullOrEmpty(txtMa.Text))
            {
                txtMa.Focus ();
                return false;
            }
            if(string.IsNullOrEmpty(txtTen.Text))
            {
                txtTen.Focus ();
                return false;
            }
            return true;
        }
        private void btnLuu_Click (object sender, EventArgs e)
        {
            if(!checkInput())
            {
                return;
            }
            nhanvien.MaNV = txtMa.Text;
            nhanvien.TenNV = txtTen.Text;
            nhanvien.GioiTinh = cbGioiTinh.SelectedIndex;
            nhanvien.NamSinh = dateNgaySinh.DateTime;
            nhanvien.MaKhoa = (lookUpKhoaBoPhan.GetSelectedDataRow () as DataRowView)[0].ToString ();
            nhanvien.MaCV = (lookUpChucVu.GetSelectedDataRow () as DataRowView)[0].ToString ();
            nhanvien.HocHamHocVi = (lookUpHocHamHocVi.GetSelectedDataRow () as DataRowView)[0].ToString ();
            nhanvien.ChuyenMon = (lookUpChuyenMon.GetSelectedDataRow () as DataRowView)[0].ToString ();
            nhanvien.NgayVao = dateNgayVao.DateTime;
            nhanvien.TinhTrang = checkTinhTrang.Checked;
            nhanvien.MaBS = txtMaBS.Text;
            nhanvien.MaCC = txtCCHN.Text;
            nhanvien.KeDon = Utils.ToInt(txtKeDon.Text);
            if (txtMatKhau.Text.Length > 0)
            {
                nhanvien.MatKhau = Core.DAL.Utils.ToMD5 (txtMatKhau.Text);
            }
            else
            if(string.IsNullOrEmpty(nhanvien.MatKhau))
            {
                nhanvien.MatKhau = "";
            }
            nhanvien.CoSoKCB = (lookUpCoSoKCB.GetSelectedDataRow () as DataRowView)[0].ToString ();
            string err = "";
            if (them)
            {
                if (nhanvien.ThemNhanVien (ref err))
                {
                    LoadData ();
                }
            }
            else
            {
                if (nhanvien.SuaNhanVien (ref err))
                {
                    LoadData ();
                }
            }
            if (!string.IsNullOrEmpty (err))
            {
                MessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click (object sender, EventArgs e)
        {
            DialogResult traloi;
            string err = "";
            traloi = MessageBox.Show ("Chắc chắn bạn muốn xóa mục này?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if (!nhanvien.XoaNhanVien (ref err))
                {
                    MessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadData ();
            }
        }

        private void gridView_FocusedRowChanged (object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            dr = gridView.GetFocusedDataRow ();
            if (dr != null)
            {

                txtMa.Text = dr["Ma_NV"].ToString ();
                txtTen.Text = dr["Ten_NV"].ToString ();
                cbGioiTinh.SelectedIndex = int.Parse (dr["GioiTinh"].ToString ());
                dateNgaySinh.DateTime = DateTime.Parse(dr["NamSinh"].ToString ());
                lookUpKhoaBoPhan.EditValue = dr["MaKhoa"].ToString ();
                lookUpChucVu.EditValue = dr["Ma_CV"].ToString ();
                lookUpHocHamHocVi.EditValue = dr["HocHamHocVi"].ToString ();
                lookUpChuyenMon.EditValue = dr["ChuyenMon"].ToString ();
                dateNgayVao.DateTime = DateTime.Parse(dr["NgayVao"].ToString ());
                checkTinhTrang.Checked = bool.Parse (dr["TinhTrang"].ToString ());
                txtMaBS.Text = dr["Ma_BS"].ToString ();
                lookUpCoSoKCB.EditValue = dr["CoSoKCB"].ToString ();
                txtCCHN.Text = Utils.ToString(dr["MaCC"]);
                txtKeDon.Text = Utils.ToString(dr["KeDon"]);
                nhanvien.MaNV = txtMa.Text;
                nhanvien.MatKhau = dr["MatKhau"].ToString ();
                txtMa.ReadOnly = true;
                them = false;

                Enabled_Xoa ();
                Enabled_Luu ();
            }
        }

        private void lookUpCoSoKCB_EditValueChanged(object sender, EventArgs e)
        {
            lookUpKhoaBoPhan.Properties.DataSource = nhanvien.DSKhoaBan(0, lookUpCoSoKCB.EditValue.ToString());
        }
    }
}