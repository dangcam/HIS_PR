using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Update_HIS
{
    public partial class FrmMain : Form
    {
        XmlDocument xmlfile;
        private string file = "VPN.xml";
        private int versionold = 0;
        private int versionnew = 0;
        private string server = "";
        private string user = "";
        private string pass = "";
        private string folder = "";
        private int len = 0, i = 0;
        BackgroundWorker bw = new BackgroundWorker();
        public FrmMain()
        {
            InitializeComponent();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadXML(file);
                LoadXMLServer();
                if (versionnew > versionold)
                {
                    // download
                    DialogResult traloi;
                    traloi = MessageBox.Show("HIS có phiên bản mới, bạn có muốn cập nhật?", "Trả lời",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (traloi == DialogResult.Yes && bw.IsBusy != true)
                    {
                        TatHIS();
                        bw.RunWorkerAsync();                     
                    }
                    else
                    {
                        ChayLai();
                        this.Close();
                    }
                }
                else
                {
                    ChayLai();
                    this.Close();
                }
            }
            catch (Exception ex) {
                Console.WriteLine("{0}", ex.Message);
                ChayLai();
                this.Close();
            }
           
        }
        private void LoadXML(string file)
        {
            xmlfile = new XmlDocument();
            xmlfile.Load(file);
            this.folder = xmlfile.SelectSingleNode("VPN/Folder").InnerText.ToString();
            this.versionold = int.Parse(xmlfile.SelectSingleNode("VPN/Ver").InnerText.ToString());
            this.server = xmlfile.SelectSingleNode("VPN/Server").InnerText.ToString();
            this.user = xmlfile.SelectSingleNode("VPN/User").InnerText.ToString();
            this.pass = xmlfile.SelectSingleNode("VPN/Pass").InnerText.ToString();

        }
        private void LoadXMLServer()
        {
            using (NetworkConnection.Access(server, user, pass))
            {
                // file upload code here
                xmlfile = new XmlDocument();
                xmlfile.Load(@"\\" + server + @"\" + folder + @"\" + file);
                this.versionnew = int.Parse(xmlfile.SelectSingleNode("VPN/Ver").InnerText.ToString());
            }

        }
        private void TatHIS()
        {
            Process[] processes = Process.GetProcessesByName("HIS_PR");
            foreach (var proc in processes)
            {
                proc.Kill();
            }
            //if (processes.Length > 0)
            //    processes[0].Kill();
        }
        private void ChayLai()
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("HIS_PR.exe");
            p.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            this.Close();
        }
        private void CopyFile(string sourcePath, string startupPath)
        {
            string[] files = System.IO.Directory.GetFiles(sourcePath);
            string[] folder = Directory.GetDirectories(sourcePath);
            string fileName, destFile, folderName;
            len += files.Count();
            System.IO.Directory.CreateDirectory(startupPath);
            // Copy the files and overwrite destination files if they already exist.
            foreach (string f in folder)
            {
                folderName = Path.GetFileName(f);
                CopyFile(f, startupPath + "\\" + folderName);
            }
            foreach (string s in files)
            {
                // Use static Path methods to extract only the file name from the path.
                fileName = System.IO.Path.GetFileName(s);
                destFile = System.IO.Path.Combine(startupPath, fileName);
                try
                {
                    System.IO.File.Copy(s, destFile, true);
                }
                catch { }
                i++;
                bw.ReportProgress((int)(100.0 / len * i));
            }
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string sourcePath = @"\\" + server + @"\" + folder;
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            CopyFile(sourcePath, startupPath);
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblTienTrinh.Text = "Đang tải: " + e.ProgressPercentage + "%";
            progressBar.Value = (e.ProgressPercentage);
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                ChayLai();
            }
            else if (!(e.Error == null))
            {
                ChayLai();
            }
            else
            {
                //DialogResult traloi;
                //traloi = MessageBox.Show("HIS cập nhật hoàn tất, chạy lại ứng dụng?", "Trả lời",
                //  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (traloi == DialogResult.Yes)
                //{
                //    ChayLai();
                //}
                ChayLai();
            }
            this.Close();
        }
    }
}
