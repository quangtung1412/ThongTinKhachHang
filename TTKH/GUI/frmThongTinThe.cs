using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AGRIBANKHD.GUI
{
    public partial class frmThongTinThe : Form
    {
        public frmThongTinThe()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frmThongTinThe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cRMDataSet.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter.Fill(this.cRMDataSet.KHACHHANG);
            // TODO: This line of code loads data into the 'cRMDataSet.THEODOITHE' table. You can move, or remove it, as needed.
            this.tHEODOITHETableAdapter.Fill(this.cRMDataSet.THEODOITHE);

        }
    }
}
