﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            vattu.LoaiVatTu = (lookUpLoaiVatTu.GetSelectedDataRow () as DataRowView)[0].ToString ();
            lookUpNhomVatTu.Properties.DataSource = vattu.DSNhomVatTu ();
        }

        private void btnThem_Click (object sender, EventArgs e)
        {
            them = true;
            txtMaBV.ReadOnly = false;
            txtMaBV.Text = "";
            txtMaHoatChat.Text = "";
            txtHoatChat.Text = "";
            lookUpDuongDung.EditValue = null;
            txtHamLuong.Text = "";
            txtTenVatTu.Text = "";
            txtSoDK.Text = "";
            lookUpDonViTinh.EditValue = null;
            txtHangSX.Text = "";
            lookUpNuocSX.EditValue = null;
            txtQuyetDinh.Text = "";
            txtCongBo.Text = "";
            cbLoaiThuoc.SelectedIndex = 0;
            checkBHYT.Checked = true;
            checkHieuLuc.Checked = true;

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
            vattu.BHYT = checkBHYT.Checked;
            vattu.TinhTrang = checkHieuLuc.Checked;

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
            vattu.NhomVatTu = (lookUpNhomVatTu.GetSelectedDataRow () as DataRowView)[0].ToString ();
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
                txtHangSX.Text = dr["HangSX"].ToString();
                lookUpNuocSX.EditValue = dr["NuocSX"].ToString();
                txtQuyetDinh.Text = dr["QuyetDinh"].ToString();
                txtCongBo.Text = dr["CongBo"].ToString();
                cbLoaiThuoc.SelectedIndex = int.Parse (dr["LoaiThuoc"].ToString ());
                checkBHYT.Checked = bool.Parse(dr["BHYT"].ToString());
                checkHieuLuc.Checked = bool.Parse(dr["TinhTrang"].ToString());

                them = false;

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
                        vattu.MaBV = dtRow[21].ToString ();
                        vattu.MaHoatChat = dtRow[3].ToString ();
                        vattu.HoatChat = dtRow[4].ToString ();
                        vattu.MaDuongDung = dtRow[5].ToString ();
                        vattu.HamLuong = dtRow[7].ToString ();
                        vattu.TenVatTu = dtRow[8].ToString ();
                        vattu.SoDK = dtRow[9].ToString ();
                        vattu.DonViTinh = dtRow[11].ToString ();
                        vattu.HangSX = dtRow[16].ToString ();
                        vattu.NuocSX = dtRow[17].ToString ();
                        vattu.QuyetDinh = dtRow[19].ToString ();
                        vattu.CongBo = dtRow[20].ToString ();
                        vattu.LoaiThuoc = dtRow[22].ToString ();
                        vattu.BHYT = true;
                        vattu.TinhTrang = true;

                        vattu.SpVatTu(ref err, "INSERT");
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