using Core.DAL;
using DevExpress.XtraBars.Ribbon;
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

namespace DuocPham.GUI
{
    public partial class FrmTuTruc : RibbonForm
    {
        TuTrucEntity tuTrucEntity;
        DataTable dt;
        public FrmTuTruc()
        {
            InitializeComponent();
            tuTrucEntity = new TuTrucEntity();
        }

        private void FrmTuTruc_Load(object sender, EventArgs e)
        {
            lookUpKhoa.Properties.DataSource = tuTrucEntity.DSKhoaBan(1);
            lookUpKhoa.Properties.ValueMember = "MaKhoa";
            lookUpKhoa.Properties.DisplayMember = "TenKhoa";
            lookUpKhoa.EditValue = AppConfig.MaKhoa;
        }
        private void LoadData()
        {
            tuTrucEntity.MaKhoa = Utils.ToString(lookUpKhoa.EditValue);
            dt = tuTrucEntity.DSThuoc();
            gridControl.DataSource = dt;
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(dt!=null)
            {
                string err;
                foreach(DataRow dr in dt.Rows)
                {
                    err = "";
                    tuTrucEntity.SoLuong = Utils.ToInt(dr["SoLuong"]);
                    tuTrucEntity.MaBV = Utils.ToString(dr["MaBV"]);
                    if(tuTrucEntity.SoLuong == 0 &&Utils.ToString( dr["MaBVTu"]).Length>0)
                    {
                        tuTrucEntity.SpTuTruc(ref err, "DELETE");
                    }
                    if(tuTrucEntity.SoLuong>0)
                    {
                        if (Utils.ToString(dr["MaBVTu"]).Length>0)
                            tuTrucEntity.SpTuTruc(ref err, "UPDATE");
                        else
                            tuTrucEntity.SpTuTruc(ref err, "INSERT");
                    }
                    if(!string.IsNullOrEmpty(err))
                    {
                        MessageBox.Show(err);
                    }
                }
            }
            LoadData();
        }
    }
}
