using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TTKH.GUI
{
    public partial class frmMainRibbon : Telerik.WinControls.UI.RadRibbonForm
    {
        public frmMainRibbon()
        {
            InitializeComponent();
        }

        private void radRibbonBarGroup3_Click(object sender, EventArgs e)
        {
            frmNhapTTKH frm = new frmNhapTTKH();
            frm.ShowDialog();
        }

    }
}
