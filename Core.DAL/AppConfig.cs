using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core.DAL
{
    public class AppConfig
    {
        XmlDocument xmlfile;
        private static string theme = "";
        private static string serverName = "";
        private static string database = "";
        private static string userName = "";
        private static string password = "";
        private static string coSoKCB = "70013";
        private static string tenCoSoKCB = "";
        private static string maNV = "";
        private static string matKhau = "";
        private static string loginMaNV = "";
        private static string loginPass = "";
        private static bool nhoTT = false;
        private static string userLogin = "";
        private static string passWord = "";
        private static string maKhoa = null;
        public AppConfig()
        {
            xmlfile = new XmlDocument ();
            xmlfile.Load ("AppConfig.xml");
        }
        public static string Theme
        {
            get
            {
                return theme;
            }

            set
            {
                theme = value;
            }
        }

        public static string ServerName
        {
            get
            {
                return serverName;
            }

            set
            {
                serverName = value;
            }
        }

        public static string Database
        {
            get
            {
                return database;
            }

            set
            {
                database = value;
            }
        }

        public static string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public static string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public static string CoSoKCB
        {
            get
            {
                return coSoKCB;
            }

            set
            {
                coSoKCB = value;
            }
        }
        public static string TenCoSoKCB
        {
            get
            {
                return tenCoSoKCB;
            }

            set
            {
                tenCoSoKCB = value;
            }
        }
        public static string MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
            }
        }

        public static string MatKhau
        {
            get
            {
                return matKhau;
            }

            set
            {
                matKhau = value;
            }
        }

        public static string LoginMaNV
        {
            get
            {
                return loginMaNV;
            }

            set
            {
                loginMaNV = value;
            }
        }

        public static string LoginPass
        {
            get
            {
                return loginPass;
            }

            set
            {
                loginPass = value;
            }
        }

        public static bool NhoTT
        {
            get
            {
                return nhoTT;
            }

            set
            {
                nhoTT = value;
            }
        }

        public static string UserLoginBHYT
        {
            get
            {
                return userLogin;
            }

            set
            {
                userLogin = value;
            }
        }

        public static string PassWordBHYT
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
            }
        }

        public static string MaKhoa
        {
            get
            {
                return maKhoa;
            }

            set
            {
                maKhoa = value;
            }
        }

        public void Read ()
        {
            
            AppConfig.Theme = xmlfile.SelectSingleNode ("AppConfig/ThemeConfig/Theme").InnerText.ToString ();
            AppConfig.ServerName = xmlfile.SelectSingleNode ("AppConfig/Connection/ServerName").InnerText.ToString ();
            AppConfig.Database = xmlfile.SelectSingleNode ("AppConfig/Connection/Database").InnerText.ToString ();
            AppConfig.UserName = xmlfile.SelectSingleNode ("AppConfig/Connection/UserName").InnerText.ToString ();
            AppConfig.Password = xmlfile.SelectSingleNode ("AppConfig/Connection/Password").InnerText.ToString ();
            AppConfig.LoginMaNV = xmlfile.SelectSingleNode ("AppConfig/Config/LoginMaNV").InnerText.ToString ();
            AppConfig.LoginPass = xmlfile.SelectSingleNode ("AppConfig/Config/LoginPass").InnerText.ToString ();
            AppConfig.NhoTT = bool.Parse(xmlfile.SelectSingleNode ("AppConfig/Config/NhoTT").InnerText.ToString ());
            AppConfig.UserLoginBHYT = xmlfile.SelectSingleNode("AppConfig/BHYT/UserLogin").InnerText.ToString();
            AppConfig.PassWordBHYT = (xmlfile.SelectSingleNode("AppConfig/BHYT/PassWord").InnerText.ToString());
        }
        public void WriteTheme()
        {
            xmlfile.SelectSingleNode ("AppConfig/ThemeConfig/Theme").InnerText = AppConfig.Theme;
            xmlfile.Save ("AppConfig.xml");
        }
        public void WriteLogin ()
        {
            xmlfile.SelectSingleNode ("AppConfig/Config/LoginMaNV").InnerText = AppConfig.LoginMaNV;
            xmlfile.SelectSingleNode ("AppConfig/Config/LoginPass").InnerText = AppConfig.LoginPass;
            xmlfile.SelectSingleNode ("AppConfig/Config/NhoTT").InnerText = AppConfig.NhoTT.ToString();
            xmlfile.Save ("AppConfig.xml");
        }
        public void WriteCauHinh()
        {
            xmlfile.SelectSingleNode("AppConfig/Connection/ServerName").InnerText = AppConfig.ServerName;
            xmlfile.SelectSingleNode("AppConfig/Connection/Database").InnerText = AppConfig.Database;
            xmlfile.SelectSingleNode("AppConfig/Connection/UserName").InnerText = AppConfig.UserName;
            xmlfile.SelectSingleNode("AppConfig/Connection/Password").InnerText = AppConfig.Password;
            xmlfile.SelectSingleNode("AppConfig/BHYT/UserLogin").InnerText = AppConfig.UserLoginBHYT;
            xmlfile.SelectSingleNode("AppConfig/BHYT/PassWord").InnerText = AppConfig.PassWordBHYT;
            xmlfile.Save("AppConfig.xml");
        }
    }
}
