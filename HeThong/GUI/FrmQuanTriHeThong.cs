﻿using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong.GUI
{
    public partial class FrmQuanTriHeThong : RibbonForm
    {
        public FrmQuanTriHeThong ()
        {
            InitializeComponent ();
        }
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmQuanTriHeThong_Load (object sender, EventArgs e)
        {
            
            
        }
    }
}
