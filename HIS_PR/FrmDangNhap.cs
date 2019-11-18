using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace HIS_PR
{
    public partial class FrmDangNhap : RibbonForm
    {
        FrmMain frmMain;
        AppConfig appConfig = new AppConfig ();
        DangNhapEntity dangnhap;
        public FrmDangNhap ()
        {
            InitializeComponent ();
            appConfig.Read ();
            dangnhap = new DangNhapEntity ();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(AppConfig.Theme);
        }

        private void FrmDangNhap_Load (object sender, EventArgs e)
        {
            txtTenDN.Text = AppConfig.LoginMaNV;
            txtMatKhau.Text = AppConfig.LoginPass;
            checkLuu.Checked = AppConfig.NhoTT;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text.Length == 0)
            {
                txtTenDN.Focus();
                return;
            }
            if (txtMatKhau.Text.Length == 0)
            {
                txtMatKhau.Focus();
                return;
            }
            dangnhap.MaNV = txtTenDN.Text;
            dangnhap.MatKhau = Utils.ToMD5(txtMatKhau.Text);
            AppConfig.LoginMaNV = "";
            AppConfig.LoginPass = "";
            AppConfig.NhoTT = false;
            if (checkLuu.Checked == true)
            {
                AppConfig.LoginMaNV = txtTenDN.Text;
                AppConfig.LoginPass = txtMatKhau.Text;
                AppConfig.NhoTT = true;
            }
            appConfig.WriteLogin();
            int login = dangnhap.CheckLogin();
            if (login == 1)
            {
                this.Hide();
                frmMain = new FrmMain(this);
                frmMain.Show();
            }
            else
            if (login == 0)
            {
                XtraMessageBox.Show("Sai thông tin đăng nhập", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click (object sender, EventArgs e)
        {
            this.Close ();
        }

        private void txtTenDN_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar == 13 && txtTenDN.Text.Length >0)
            {
                txtMatKhau.Focus ();
            }
        }

        private void txtMatKhau_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMatKhau.Text.Length > 0)
            {
                btnOK.Focus ();
            }
        }
    }
}
