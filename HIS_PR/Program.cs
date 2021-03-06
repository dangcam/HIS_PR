﻿using System;
using System.Windows.Forms;

namespace HIS_PR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ()
        {
            DevExpress.UserSkins.BonusSkins.Register ();
            DevExpress.Skins.SkinManager.EnableFormSkins ();
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new FrmDangNhap());
        }
    }
}
