using Core.DAL;
using DataMining;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraSplashScreen;
using DuocPham.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuocPham.GUI
{
    public partial class FrmPhanTichDonThuoc : RibbonForm
    {
        SplashScreenManager splashScreenManager;
        PhanTichDonThuocEntity donThuocEntity;
        DataTable dataThuoc;
        Dictionary<int, string> dicTen = new Dictionary<int, string>();
        public FrmPhanTichDonThuoc()
        {
            InitializeComponent();
            donThuocEntity = new PhanTichDonThuocEntity();
            splashScreenManager = new SplashScreenManager(this, typeof(WaitFormLoad), true, true);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmPhanTichDonThuoc_Load(object sender, EventArgs e)
        {
            DataTable dataTen = donThuocEntity.DataTen();
            dicTen = dataTen.AsEnumerable().
                ToDictionary<DataRow, int, string>(row =>Utils.ToInt( row[0]), row => row[1].ToString());
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            gridControl.DataSource = null;
            gridView.Columns.Clear();
            if (!splashScreenManager.IsSplashFormVisible)
                splashScreenManager.ShowWaitForm();
            if (checkDinhBenh.Checked)
                dataThuoc = donThuocEntity.DataDinhBenh();
            else
                dataThuoc = donThuocEntity.DataThuoc();
            gridControl.DataSource = dataThuoc;
            LuuData(dataThuoc);
            if (splashScreenManager.IsSplashFormVisible)
                splashScreenManager.CloseWaitForm();

        }
        private void LuuData(DataTable data)
        {
            using (StreamWriter outputFile = new StreamWriter("InputFPGrowth.txt"))
            {
                foreach (DataRow row in data.Rows)
                    if (row[0].ToString().Length > 0)
                        outputFile.WriteLine(row[0]);
            }
        }
        private void btnPhanTich_Click(object sender, EventArgs e)
        {
            if (!splashScreenManager.IsSplashFormVisible)
                splashScreenManager.ShowWaitForm();
            //
            string[] database = System.IO.File.ReadAllLines("InputFPGrowth.txt");
            ItemsetCollection db = new ItemsetCollection();
            Itemset items;

            foreach (string item in database)
            {
                items = new Itemset();
                //items.AddRange(item.Split(','));
                //items.Remove("");
                foreach (string it in item.Split(','))
                {
                    items.Add(int.Parse(it));
                }
                db.Add(items);
            }
            //
            ReturnL();
            try { database = System.IO.File.ReadAllLines("OutputFPGrowth.txt"); }
            catch { }
            ItemsetCollection L = new ItemsetCollection();
            foreach (string item in database)
            {
                items = new Itemset();
                string[] itemsupport = item.Split(':');
                foreach (string it in itemsupport[0].Split(','))
                {
                    items.Add(int.Parse(it));
                }
                items.Support = double.Parse(itemsupport[1]);
                L.Add(items);
            }
            //do mining
            double confidenceThreshold = double.Parse(txtDoTinCay.Text);
            dataThuoc = new DataTable();
            dataThuoc.Columns.Add("KET_QUA", typeof(string));
            gridView.Columns.Clear();
            List<AssociationRule> allRules = Mine(db, L, confidenceThreshold);
            foreach (AssociationRule rule in allRules)
            {
                dataThuoc.Rows.Add(ToString(rule));
            }
            gridControl.DataSource = dataThuoc;
            if (splashScreenManager.IsSplashFormVisible)
                splashScreenManager.CloseWaitForm();
        }
        private string ToString(AssociationRule rule)
        {
            string X = ToStringXY(rule.X);
            string Y = ToStringXY(rule.Y);
            return (X + " => " + Y + " (support: " + Math.Round(rule.Support, 2) + "%, confidence: " + Math.Round(rule.Confidence, 2) + "%)");
        }
        private string ToStringXY(Itemset X)
        {
            string x = ".";
            foreach(int item in X)
            {
                x +=", "+ dicTen[item];
            }
            x = x.Replace("., ", "");
            return x;
        }
        private void ReturnL()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "MPIEXEC";
            startInfo.Arguments = "-n 3 Mpi.NET1.exe \"InputFPGrowth.txt\" \"" + txtDoHoTro.Text + "\" ";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            //return L;
        }
        public List<AssociationRule> Mine(ItemsetCollection db, ItemsetCollection L, double confidenceThreshold)
        {
            List<AssociationRule> allRules = new List<AssociationRule>();

            foreach (Itemset itemset in L)
            {
                ItemsetCollection subsets = Bit.FindSubsets(itemset, 0); //get all subsets
                foreach (Itemset subset in subsets)
                {
                    double confidence = (db.FindSupport(itemset) / db.FindSupport(subset)) * 100.0;
                    if (confidence >= confidenceThreshold)
                    {
                        AssociationRule rule = new AssociationRule();
                        rule.X.AddRange(subset);
                        rule.Y.AddRange(itemset.Remove(subset));
                        rule.Support = db.FindSupport(itemset);//itemset.Support;// db.FindSupport(itemset);
                        rule.Confidence = confidence;
                        if (rule.X.Count > 0 && rule.Y.Count > 0)
                        {
                            allRules.Add(rule);
                        }
                    }
                }
            }

            return (allRules);
        }
    }
}
