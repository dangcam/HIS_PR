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
    public partial class UC_NhaCungCap : UserControl
    {
        NhaCungCapEntity nhacungcap;
        string quyen = "";
        bool them = false;
        DataRow dr;
        public UC_NhaCungCap ()
        {
            InitializeComponent ();
            nhacungcap = new NhaCungCapEntity ();
        }
        private void LoadData ()
        {
            them = false;
            gridControl.DataSource = nhacungcap.DSNhaCungCap();
        }
        private void CheckButton ()
        {
            quyen = Core.DAL.Utils.GetQuyen (this.Name);
            Enabled_Them ();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
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
                btnExcel.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
                btnExcel.Enabled = false;
            }
        }
        private void UC_NhaCungCap_Load (object sender, EventArgs e)
        {
            LoadData ();
            CheckButton ();
        }

        private void btnThem_Click (object sender, EventArgs e)
        {
            txtTen.Text = "";
            txtMa.ReadOnly = false;
            txtMa.Text = "";
            txtDiaChi.Text = "";
            them = true;

            Enabled_Luu ();
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click (object sender, EventArgs e)
        {
            nhacungcap.Ten = txtTen.Text;
            nhacungcap.TinhTrang = checkTinhTrang.Checked;
            nhacungcap.DiaChi = txtDiaChi.Text;
            string err = "";
            if (them)
            {
                nhacungcap.ID = txtMa.Text;
                if (nhacungcap.ThemNhaCungCap (ref err))
                {
                    LoadData ();
                }
            }
            else
            {
                if (nhacungcap.SuaNhaCungCap (ref err))
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
            traloi = XtraMessageBox.Show ("Chắc chắn bạn muốn xóa mục này?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if (!nhacungcap.XoaNhaCungCap (ref err))
                {
                    XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadData ();
            }
        }

        private void gridView_RowClick (object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dr = gridView.GetFocusedDataRow ();
            if (dr != null)
            {
                nhacungcap.ID = dr["ID"].ToString ();
                txtTen.Text = dr["Ten"].ToString ();
                txtMa.Text = nhacungcap.ID;
                checkTinhTrang.Checked = bool.Parse (dr["TinhTrang"].ToString ());
                txtDiaChi.Text = dr["DiaChi"].ToString();
                them = false;
                txtMa.ReadOnly = true;

                Enabled_Xoa ();
                Enabled_Luu ();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DialogResult dr = ImportExcel.OpenDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string err = "";
                    DataTable data = ImportExcel.OpenFile();
                    foreach (DataRow dtRow in data.Rows)
                    {
                        err = "";
                        nhacungcap.ID = dtRow[0].ToString();
                        nhacungcap.Ten = dtRow[1].ToString();
                        nhacungcap.DiaChi = dtRow[2].ToString();
                        nhacungcap.TinhTrang = true;

                        if (!nhacungcap.ThemNhaCungCap(ref err))
                        {
                            //nhacungcap.SuaNhaCungCap(ref err);
                        }

                        if (!string.IsNullOrEmpty(err))
                        {
                            XtraMessageBox.Show(err);
                        }
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }
    }
}
