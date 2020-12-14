using Core.DAL;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using KhamBenh.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiepNhan.GUI
{
    public partial class FrmVatTuChiTiet : RibbonForm
    {
        Dictionary<string, int> listVatTu;
        KeDonEntity kedon;
        DataView dvVatTu;
        public FrmVatTuChiTiet()
        {
            InitializeComponent();
            kedon = new KeDonEntity();
            lookUpVatTu.Properties.DisplayMember = "TenVatTu";
        }
        public string MaLK { get; set; }
        public string MaKhoa { get; set; }
        public string MaBacSi { get; set; }
        private void FrmVatTuChiTiet_Load(object sender, EventArgs e)
        {
            kedon.KhoNhan = this.MaKhoa;
            kedon.MaLK = this.MaLK;
            this.ActiveControl = lookUpVatTu;
            dateNgayYLenh.DateTime = DateTime.Now;
            dvVatTu = kedon.DSVatTu().AsDataView();
            gridControlVTYT.DataSource = dvVatTu;
            listVatTu = new Dictionary<string, int>();
            foreach (DataRowView drv in dvVatTu)
            {
                listVatTu.Add(drv["MaVatTu"].ToString(), 1);
            }
            lookUpVatTu.Properties.DataSource = kedon.DSKeDon("2");
            cbLoaiVatTu.SelectedIndex = 0;
        }

        private void lookUpVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoLuong.Focus();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnChon.Focus();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (lookUpVatTu.EditValue is DataRowView)
            {
                DataRowView dr = (lookUpVatTu.EditValue as DataRowView);
                //kiểm tra số lượng tồn vật tư
                if (listVatTu.ContainsKey(dr["MaVatTu"].ToString()))
                {
                    XtraMessageBox.Show(Library.VatTuDaDuocChon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lookUpVatTu.Focus();
                    return;
                }
                if (txtSoLuong.Value > Utils.ToInt(dr["SoLuongTon"]))
                {
                    XtraMessageBox.Show(Library.VatTuKhongDuSoLuong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Focus();
                    return;
                }
                listVatTu.Add(dr["MaVatTu"].ToString(), 2);
                DataRowView drvNew = (gridControlVTYT.DataSource as DataView).AddNew();
                drvNew["MaVatTu"] = dr["MaVatTu"];
                drvNew["MaVT"] = dr["MaHoatChat"];
                drvNew["TenVatTu"] = dr["TenVatTu"];
                drvNew["DonViTinh"] = dr["DonViTinh"];
                drvNew["SoLuong"] = txtSoLuong.Value;
                if (Utils.ToDecimal(dr["GiaBHYT"]) > 0)
                {
                    drvNew["DonGia"] = dr["GiaBHYT"];
                    drvNew["TyLe"] = 100;
                }
                else
                {
                    drvNew["DonGia"] = dr["DonGiaBV"];
                    drvNew["TyLe"] = 0;
                    if(cbLoaiVatTu.SelectedIndex==2)
                    {
                        drvNew["TyLe"] = -10;// Vật tư khác
                    }
                }
                drvNew["ThanhTien"] = Utils.ToDecimal(drvNew["DonGia"].ToString()) * txtSoLuong.Value;
                drvNew["NgayYLenh"] = dateNgayYLenh.DateTime;
                drvNew["TTinThau"] = (dr["CongBo"].ToString().Length > 3 ? dr["CongBo"].ToString().Substring(4)
                    : DateTime.Now.ToString("yyyy")) + ".00." + dr["QuyetDinh"];
                drvNew.EndEdit();
                lookUpVatTu.Focus();
                txtSoLuong.ResetText();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            // xóa những vật tư đã chọn
            List<string> keys = new List<string>(listVatTu.Keys);
            foreach (var key in keys)
            {
                if (listVatTu[key] == 0)
                {
                    err = "";
                    // tiến hành xóa trong csdl, listVatTu
                    kedon.MaVatTu = key;
                    kedon.NgayYLenh = DateTime.Now;
                    if (!kedon.SpKeVatTu(ref err, "DELETE"))
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        listVatTu.Remove(key);
                }
            }
            // lưu bảng vật tư
            foreach (DataRowView drv in dvVatTu)
            {
                err = "";
                kedon.MaVatTu = drv["MaVatTu"].ToString();
                kedon.MaVT = drv["MaVT"].ToString();
                if (Utils.ToInt(drv["TyLe"]) == 100)
                {
                    kedon.MaNhom = 10;// Vật tư trong danh mục BHYT 
                    kedon.PhamVi = 1;
                }
                else
                {
                    kedon.MaNhom = 11;
                    kedon.PhamVi = 2;
                }
                kedon.GoiVTYT = "G1";
                kedon.TenVatTu = drv["TenVatTu"].ToString();
                kedon.DonViTinh = drv["DonViTinh"].ToString();
                kedon.TTinThau = drv["TTinThau"].ToString();
                
                kedon.SoLuong = Utils.ToInt(drv["SoLuong"]);
                kedon.DonGia = Utils.ToDecimal(drv["DonGia"]);
                kedon.TyLe = Utils.ToInt(drv["TyLe"]);
                kedon.ThanhTien = Utils.ToDecimal(drv["ThanhTien"]);
                kedon.MaKhoa = this.MaKhoa;
                kedon.MaBacSi = this.MaBacSi;
                kedon.NgayYLenh = Utils.ToDateTime(drv["NgayYLenh"].ToString());
                kedon.MaPTTT = 0;
                if (listVatTu[drv["MaVatTu"].ToString()] == 2)
                {
                    // value = 2
                    // thêm mới 
                    if (kedon.TyLe < 0)
                    {
                        // vật tư khác
                        kedon.TyLe = 0;
                        kedon.SpKeVatTu(ref err, "INSERT_NgoaiDM");
                    }
                    else
                    {
                        kedon.SpKeVatTu(ref err, "INSERT");
                    }
                    if (string.IsNullOrEmpty(err))
                    {
                        listVatTu[drv["MaVatTu"].ToString()] = 1;// đã có nếu lưu thành công
                    }
                    else
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void repbtnXoaVT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = gridViewVTYT.GetFocusedDataSourceRowIndex();
            if (index > -1)
            {
                DataRow dr = dvVatTu.ToTable().Rows[index];
                if (listVatTu[dr["MaVatTu"].ToString()] == 1)
                {
                    string err = "";
                    // tiến hành xóa trong csdl, listVatTu
                    kedon.MaVatTu = dr["MaVatTu"].ToString();
                    kedon.NgayYLenh = DateTime.Now;
                    if (!kedon.SpKeVatTu(ref err, "DELETE"))
                    {
                        XtraMessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listVatTu[dr["MaVatTu"].ToString()] = 0;
                    }
                    else
                        listVatTu.Remove(dr["MaVatTu"].ToString());
                }
                else
                    listVatTu.Remove(dr["MaVatTu"].ToString());
                (gridControlVTYT.DataSource as DataView).Delete(index);
            }
        }

        private void txtSoLuong_Enter(object sender, EventArgs e)
        {
            txtSoLuong.Select(0, txtSoLuong.Value.ToString().Length);
        }

        private void cbLoaiVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiVatTu.SelectedIndex == 0)
            {
                lookUpVatTu.Properties.DataSource = kedon.DSKeDon("2");
            }
            else if (cbLoaiVatTu.SelectedIndex == 1)
            {
                lookUpVatTu.Properties.DataSource = kedon.DSKeVatTuKhoChan("2");
            }
            else if (cbLoaiVatTu.SelectedIndex == 2)
            {
                lookUpVatTu.Properties.DataSource = kedon.DSKeDon("3");
            }
            else// Loại vật tư khác
            {
                lookUpVatTu.Properties.DataSource = kedon.DSVatTuYTe();
            }
        }
    }
}
