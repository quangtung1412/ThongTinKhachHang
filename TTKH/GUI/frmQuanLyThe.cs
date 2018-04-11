using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGRIBANKHD.DAL;
using AGRIBANKHD.Entities;

namespace AGRIBANKHD.GUI
{
    public partial class frmQuanLyThe : Form
    {
        public frmQuanLyThe()
        {
            InitializeComponent();
            cbTieuChi.SelectedIndex = 0;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            switch (cbTieuChi.SelectedIndex)
            {
                case 0:
                    break;
                case 1: 
                    break;
                case 2:
                    break;
                default: break;
            }
        }

        void TheChuaNhan()
        {
            try
            {
                DataTable dt = TheDAL.TheChuaNhan(dtpTuNgay.Text, dtpDenNgay.Text);
                dgvThongTinThe.DataSource = dt;
            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
        }
    }
}
