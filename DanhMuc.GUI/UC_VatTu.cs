using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Core.DAL;

namespace DanhMuc.GUI
{
    public partial class UC_VatTu : UserControl
    {
        DAL.VatTuEntity vattu;
        string quyen = "";
        bool them = false;
        DataRow dr;
        DataTable dt;
        public UC_VatTu ()
        {
            InitializeComponent ();
            vattu = new DAL.VatTuEntity ();
        }

        private void UC_VatTu_Load (object sender, EventArgs e)
        {
            lookUpLoaiVatTu.Properties.DataSource = vattu.DSLoaiVatTu ();
            lookUpLoaiVatTu.Properties.DisplayMember = "Ten";
            lookUpLoaiVatTu.Properties.ValueMember = "Ma";

            lookUpNhomVatTu.Properties.DisplayMember = "Ten";
            lookUpNhomVatTu.Properties.ValueMember = "Ma";

            lookUpDuongDung.Properties.DataSource = vattu.DSDuongDung ();
            lookUpDuongDung.Properties.DisplayMember = "Ten";
            lookUpDuongDung.Properties.ValueMember = "Ma";

            lookUpDonViTinh.Properties.DataSource = vattu.DSDonViTinh ();
            lookUpDonViTinh.Properties.DisplayMember = "Ten";
            lookUpDonViTinh.Properties.ValueMember = "Ten";

            lookUpNuocSX.Properties.DataSource = vattu.DSNuocSX ();
            lookUpNuocSX.Properties.DisplayMember = "Ten";
            lookUpNuocSX.Properties.ValueMember = "Ten";

            lookUpGoiThau.Properties.DataSource = vattu.DSGoiThau();
            lookUpGoiThau.Properties.ValueMember = "Ma";
            lookUpGoiThau.Properties.DisplayMember = "Ten";

            checkButton ();
            LoadData ();
        }
        private void LoadData ()
        {
            them = false;
            dt = vattu.DSVatTu ();
            gridControl.DataSource = dt;
            lblSoLuong.Text = dt.Rows.Count.ToString();
        }

        private void checkButton ()
        {
            quyen = Core.DAL.Utils.GetQuyen (this.Name);
            Enabled_Them ();
            Enabled_NhapExcel ();
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
        private void Enabled_NhapExcel ()
        {
            if (quyen.IndexOf ('1') >= 0)
            {
                btnNhapExcel.Enabled = true;
            }
            else
            {
                btnNhapExcel.Enabled = false;
            }
        }

        private void lookUpLoaiVatTu_EditValueChanged (object sender, EventArgs e)
        {
            if (lookUpLoaiVatTu.GetSelectedDataRow() is DataRowView)
            {
                vattu.LoaiVatTu = (lookUpLoaiVatTu.GetSelectedDataRow() as DataRowView)[0].ToString();
                vattu.NhomVatTu = null;
                LoadData();
                lookUpNhomVatTu.Properties.DataSource = vattu.DSNhomVatTu();
            }
        }

        private void btnThem_Click (object sender, EventArgs e)
        {
            them = true;
            txtMaBV.ReadOnly = false;
            txtMaBV.Text = null;
            txtMaHoatChat.Text = null;
            txtHoatChat.Text = null;
            lookUpDuongDung.EditValue = null;
            txtHamLuong.Text = null;
            txtTenVatTu.Text = null;
            txtSoDK.Text = null;
            lookUpDonViTinh.EditValue = null;
            txtHangSX.Text = "";
            lookUpNuocSX.EditValue = null;
            txtQuyetDinh.Text = null;
            txtCongBo.Text = null;
            cbLoaiThuoc.SelectedIndex = 0;
            txtGiaBHYT.Text = null;
            checkHieuLuc.Checked = true;
            txtQuyCach.Text = null;
            txtNhomThau.Text = null;
            cbLoaiThau.SelectedIndex = 0;
            checkKeDon.Checked = true;
            Enabled_Luu ();
        }

        private void btnLuu_Click (object sender, EventArgs e)
        {
            if (txtMaBV.Text.Length == 0)
            {
                XtraMessageBox.Show ("Nhập mã vật tư (mã thuốc tại BV)");
                txtMaBV.Focus ();
                return;
            }
            if (lookUpLoaiVatTu.EditValue != null)
            {
                vattu.LoaiVatTu = (lookUpLoaiVatTu.EditValue).ToString ();
            }
            else
            {
                lookUpLoaiVatTu.ItemIndex = 0;
                vattu.LoaiVatTu = lookUpLoaiVatTu.EditValue.ToString ();
            }
            vattu.NhomVatTu = null;
            if (lookUpNhomVatTu.EditValue!=null)
            {
                vattu.NhomVatTu = lookUpNhomVatTu.EditValue.ToString ();
            }
            vattu.MaBV = txtMaBV.Text;
            vattu.MaHoatChat = txtMaHoatChat.Text;
            vattu.HoatChat = txtHoatChat.Text;
            vattu.MaDuongDung = null;
            if (lookUpDuongDung.EditValue != null)
            {
                vattu.MaDuongDung = lookUpDuongDung.EditValue.ToString ();
            }
            vattu.HamLuong = txtHamLuong.Text;
            vattu.TenVatTu = txtTenVatTu.Text;
            vattu.SoDK = txtSoDK.Text;
            vattu.DonViTinh = null;
            if (lookUpDonViTinh.EditValue!=null)
            {
                vattu.DonViTinh = lookUpDonViTinh.EditValue.ToString ();
            }
            vattu.HangSX = txtHangSX.Text;
            vattu.NuocSX = null;
            if (lookUpNuocSX.EditValue !=null)
            {
                vattu.NuocSX = lookUpNuocSX.EditValue.ToString ();
            }
            vattu.QuyetDinh = txtQuyetDinh.Text;
            vattu.CongBo = txtCongBo.Text;
            vattu.LoaiThuoc = cbLoaiThuoc.SelectedIndex.ToString();
            vattu.GiaBHYT = Utils.ToDecimal(txtGiaBHYT.Text);
            vattu.TinhTrang = checkHieuLuc.Checked;
            vattu.GoiThau = Utils.ToString(lookUpGoiThau.EditValue,"");
            vattu.LoaiThau = cbLoaiThau.SelectedIndex;
            vattu.NhomThau = txtNhomThau.Text;
            vattu.QuyCach = txtQuyCach.Text;
            vattu.KeDon = checkKeDon.Checked;
            string err = "";
            if (them)
            {
                if (vattu.SpVatTu(ref err,"INSERT"))
                {
                    LoadData ();
                }
            }
            else
            {
                if (vattu.SpVatTu(ref err,"UPDATE"))
                {
                    LoadData ();
                }
            }
            if (!string.IsNullOrEmpty (err))
            {
                XtraMessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XtraMessageBox.Show("Đã lưu thành công!");
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
                if (!vattu.SpVatTu (ref err,"DELETE"))
                {
                    MessageBox.Show (err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadData ();
            }
        }

        private void lookUpNhomVatTu_EditValueChanged (object sender, EventArgs e)
        {
            if (lookUpNhomVatTu.GetSelectedDataRow() is DataRowView)
            {
                vattu.NhomVatTu = (lookUpNhomVatTu.GetSelectedDataRow() as DataRowView)[0].ToString();
            }
            LoadData ();
        }

        private void gridView_RowClick (object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dr = gridView.GetFocusedDataRow ();
            if(dr!=null)
            {
                txtMaBV.ReadOnly = true;
                lookUpLoaiVatTu.EditValue = dr["LoaiVatTu"].ToString ();
                lookUpNhomVatTu.EditValue = dr["NhomVatTu"].ToString ();
                txtMaBV.Text = dr["MaBV"].ToString();
                txtMaHoatChat.Text = dr["MaHoatChat"].ToString();
                txtHoatChat.Text = dr["HoatChat"].ToString();
                lookUpDuongDung.EditValue = dr["MaDuongDung"].ToString();
                txtHamLuong.Text = dr["HamLuong"].ToString();
                txtTenVatTu.Text = dr["TenVatTu"].ToString();
                txtSoDK.Text = dr["SoDK"].ToString();
                lookUpDonViTinh.EditValue = dr["DonViTinh"].ToString();
                txtQuyCach.Text = dr["QuyCach"].ToString ();
                txtHangSX.Text = dr["HangSX"].ToString();
                lookUpNuocSX.EditValue = dr["NuocSX"].ToString();
                txtQuyetDinh.Text = dr["QuyetDinh"].ToString();
                txtCongBo.Text = dr["CongBo"].ToString();
                cbLoaiThuoc.SelectedIndex = Utils.ToInt (dr["LoaiThuoc"]);
                txtGiaBHYT.Text = dr["GiaBHYT"].ToString();
                checkHieuLuc.Checked = bool.Parse(dr["TinhTrang"].ToString());
                lookUpGoiThau.EditValue = dr["GoiThau"];
                cbLoaiThau.SelectedIndex = Utils.ToInt(dr["LoaiThau"]);
                txtNhomThau.Text = dr["NhomThau"].ToString();
                checkKeDon.Checked = Utils.ToBoolean(dr["KeDon"]);
                them = false;

                vattu.MaBV = txtMaBV.Text;

                Enabled_Xoa ();
                Enabled_Luu ();
            }
        }

        private void btnNhapExcel_Click (object sender, EventArgs e)
        {
            DialogResult dr = ImportExcel.OpenDialog ();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string err = "";
                    DataTable data = ImportExcel.OpenFile ();
                    foreach (DataRow dtRow in data.Rows)
                    {
                        err = "";
                        vattu.LoaiVatTu = dtRow[1].ToString ();
                        vattu.NhomVatTu = dtRow[2].ToString ();
                        vattu.MaBV = dtRow[20].ToString ();
                        vattu.MaHoatChat = dtRow[3].ToString ();
                        vattu.HoatChat = dtRow[4].ToString ();
                        vattu.MaDuongDung = dtRow[5].ToString ();
                        vattu.HamLuong = dtRow[7].ToString ();
                        vattu.TenVatTu = dtRow[8].ToString ();
                        vattu.SoDK = dtRow[9].ToString ();
                        vattu.DonViTinh = dtRow[11].ToString ();
                        vattu.QuyCach = dtRow[10].ToString ();
                        vattu.HangSX = dtRow[15].ToString ();
                        vattu.NuocSX = dtRow[16].ToString ();
                        vattu.QuyetDinh = dtRow[18].ToString ();
                        vattu.CongBo = dtRow[19].ToString ();
                        vattu.LoaiThuoc = dtRow[21].ToString ();
                        vattu.LoaiThau = Utils.ToInt(dtRow[22]);
                        vattu.NhomThau = dtRow[23].ToString();
                        vattu.GoiThau = dtRow[24].ToString();
                        vattu.GiaBHYT = Utils.ToDecimal(dtRow[12]);
                        vattu.TinhTrang = true;

                        if(!vattu.SpVatTu(ref err, "INSERT"))
                        {
                            err = "";
                            vattu.SpVatTu (ref err, "UPDATE");
                        }

                        if (!string.IsNullOrEmpty (err))
                        {
                            XtraMessageBox.Show (err);
                        }
                    }
                    LoadData ();
                }
                catch(Exception ex) {
                    XtraMessageBox.Show (ex.Message);
                }
            }
        }
    }
}
