using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.DAL;
using DevExpress.XtraEditors;
using HeThong.DAL;

namespace HeThong.GUI
{
    public partial class UC_PhanQuyen : UserControl
    {
        PhanQuyenEntity phanquyen;
        bool them = false;
        DataRow dr;
        string quyen = "";
        public UC_PhanQuyen ()
        {
            InitializeComponent ();
            phanquyen = new PhanQuyenEntity ();
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
            }
            else
            {
                btnThem.Enabled = false;
            }
        }
        private void LoadData()
        {
            them = false;
            gridControlQuyen.DataSource = phanquyen.DSQuyen ();
        }
        private void UC_PhanQuyen_Load (object sender, EventArgs e)
        {
            gridControlNhanVien.DataSource = phanquyen.DSNhanVien ();

            lookUpChucNang.Properties.ValueMember = "Ma_CN";
            lookUpChucNang.Properties.DisplayMember = "Ten_CN";

            CheckButton ();
        }

        private void gridViewNhanVien_FocusedRowChanged (object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            dr = gridViewNhanVien.GetFocusedDataRow ();
            if(dr != null)
            {
                phanquyen.MaNV = dr[0].ToString ();
                gridControlQuyen.DataSource = phanquyen.DSQuyen ();
                lookUpChucNang.Properties.DataSource = phanquyen.GetDSChucNang ();
                
            }
        }

        private void btnThem_Click (object sender, EventArgs e)
        {
            them = true;
            Enabled_Luu ();
            btnXoa.Enabled = false;

            checkCapNhat.Checked = false;
            checkThem.Checked = false;
            checkXem.Checked = false;
            checkXoa.Checked = false;

        }

        private void btnLuu_Click (object sender, EventArgs e)
        {
            phanquyen.MaQuyen = "";
            if(checkXem.Checked)
            {
                phanquyen.MaQuyen = "0;";
            }
            if (checkThem.Checked)
            {
                phanquyen.MaQuyen += "1;";
            }
            if (checkCapNhat.Checked)
            {
                phanquyen.MaQuyen += "2;";
            }
            if (checkXoa.Checked)
            {
                phanquyen.MaQuyen += "3";
            }
            if(string.IsNullOrEmpty(phanquyen.MaQuyen))
            {
                XtraMessageBox.Show ("Chọn ít nhất 1 quyền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string err = "";
            if (them)
            {
                try
                {
                    phanquyen.Ma_CN = (lookUpChucNang.GetSelectedDataRow () as DataRowView)[0].ToString ();
                }
                catch
                {
                    XtraMessageBox.Show ("Chọn chức năng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (phanquyen.ThemQuyen (ref err))
                {
                    LoadData ();
                }
            }
            else
            {
                if (phanquyen.SuaQuyen (ref err))
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
                if (!phanquyen.XoaQuyen (ref err))
                {
                    MessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadData ();
            }
        }

       

        private void checkThem_CheckedChanged (object sender, EventArgs e)
        {
            if(checkThem.Checked)
            {
                checkXem.Checked = true;
            }
        }

        private void checkCapNhat_CheckedChanged (object sender, EventArgs e)
        {
            if (checkCapNhat.Checked)
            {
                checkXem.Checked = true;
            }
        }

        private void checkXoa_CheckedChanged (object sender, EventArgs e)
        {
            if (checkXoa.Checked)
            {
                checkXem.Checked = true;
            }
        }

        private void gridViewQuyen_RowClick (object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dr = gridViewQuyen.GetFocusedDataRow ();
            if (dr != null)
            {
                phanquyen.Ma_CN = dr[1].ToString ();
                phanquyen.MaQuyen = dr[2].ToString ();

                lookUpChucNang.EditValue = null;

                string[] quyen = phanquyen.MaQuyen.Split (';');
                checkXem.Checked = false;
                checkThem.Checked = false;
                checkCapNhat.Checked = false;
                checkXoa.Checked = false;
                foreach (string q in quyen)
                {
                    switch (q)
                    {
                        case "0":
                            checkXem.Checked = true;
                            break;
                        case "1":
                            checkThem.Checked = true;
                            break;
                        case "2":
                            checkCapNhat.Checked = true;
                            break;
                        case "3":
                            checkXoa.Checked = true;
                            break;
                    }

                }

                them = false;

                Enabled_Xoa ();
                Enabled_Luu ();
            }
        }

        private void checkXem_CheckedChanged(object sender, EventArgs e)
        {
            if(checkXem.Checked == false)
            {
                checkThem.Checked = false;
                checkXoa.Checked = false;
                checkCapNhat.Checked = false;
            }
        }
    }
}
