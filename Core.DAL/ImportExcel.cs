using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core.DAL
{
    public class ImportExcel
    {
        private static string filePath = string.Empty;
        public static DataTable OpenFile ()
        {
            if (!File.Exists (filePath))
            {
                System.Windows.Forms.MessageBox.Show ("Không tìm thấy tập tin.");
                return null;
            }
            string firstSheet = "";
            // excel 2007->
            var connectionString = string.Format ("Provider= Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties=Excel 12.0 Xml;", filePath);
            try
            {
                using (OleDbConnection con = new OleDbConnection (connectionString))
                {
                    con.Open ();
                    DataTable dt = con.GetSchema ("Tables");
                    firstSheet = dt.Rows[0]["TABLE_NAME"].ToString ();
                    con.Close ();
                }
            }
            catch
            {
                try
                {
                    // excel 2003->
                    connectionString = string.Format ("Provider= Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0 Xml;", filePath);
                    using (OleDbConnection con = new OleDbConnection (connectionString))
                    {
                        con.Open ();
                        DataTable dt = con.GetSchema ("Tables");
                        firstSheet = dt.Rows[0]["TABLE_NAME"].ToString ();
                        con.Close ();
                    }
                }
                catch
                {
                    try
                    {
                        // excel 2016->
                        connectionString = string.Format("Provider= Microsoft.ACE.OLEDB.14.0; data source={0}; Extended Properties=Excel 14.0 Xml;", filePath);
                        using (OleDbConnection con = new OleDbConnection(connectionString))
                        {
                            con.Open();
                            DataTable dt = con.GetSchema("Tables");
                            firstSheet = dt.Rows[0]["TABLE_NAME"].ToString();
                            con.Close();
                        }
                    }catch
                    {
                        // excel 2019->
                        connectionString = string.Format("Provider= Microsoft.ACE.OLEDB.16.0; data source={0}; Extended Properties=Excel 16.0 Xml;", filePath);
                        using (OleDbConnection con = new OleDbConnection(connectionString))
                        {
                            con.Open();
                            DataTable dt = con.GetSchema("Tables");
                            firstSheet = dt.Rows[0]["TABLE_NAME"].ToString();
                            con.Close();
                        }
                    }
                }
            }
            var adapter = new OleDbDataAdapter ("select * from [" + firstSheet + "]", connectionString);
            var ds = new DataSet ();
            string tableName = "excelData";
            adapter.Fill (ds, tableName);
            DataTable data = ds.Tables[tableName];
            return data;
        }

        public static DialogResult OpenDialog ()
        {
            OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Filter = "Excel 2007-2013 files (*.xlsx)|*.xlsx|Excel 97-2003 files (*.xls)|*.xls",
                InitialDirectory = System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments),
                Multiselect = false,
                Title = "Chọn tập tin Excel",
                CheckFileExists = true,
                CheckPathExists = true
            };
            DialogResult dr = openfiledialog.ShowDialog ();
            if (dr == System.Windows.Forms.DialogResult.Abort || dr == System.Windows.Forms.DialogResult.Cancel || dr == System.Windows.Forms.DialogResult.Ignore)
            {
                return DialogResult.Cancel;
            }
            else
            {
                filePath = openfiledialog.FileName;
                return DialogResult.OK;
            }
        }
    }
}
