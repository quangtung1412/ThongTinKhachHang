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
                    DSTheChuaNhan();
                    break;
                case 1:
                    DSTheDaNhanChuaGiao();
                    break;
                case 2:
                    DSTheDaGiao();
                    break;
                default: break;
            }
        }

        void DSTheChuaNhan()
        {
            try
            {
                DataTable dt = TheDAL.TheChuaNhan(dtpTuNgay.Text, dtpDenNgay.Text);
                BindingSource bindS = new BindingSource();
                bindS.DataSource = dt;
                dgvThongTinThe.DataSource = bindS;
                dgvThongTinThe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvThongTinThe.Columns[0].Width = 30;
            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
        }

        void DSTheDaNhanChuaGiao()
        {
            try
            {
                DataTable dt = TheDAL.TheDaNhanChuaGiao(dtpTuNgay.Text, dtpDenNgay.Text);
                BindingSource bindS = new BindingSource();
                bindS.DataSource = dt;
                dgvThongTinThe.DataSource = bindS;
                dgvThongTinThe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvThongTinThe.Columns[0].Width = 30;

            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
        }

        void DSTheDaGiao()
        {
            try
            {
                DataTable dt = TheDAL.TheDaGiao(dtpTuNgay.Text, dtpDenNgay.Text);
                BindingSource bindS = new BindingSource();
                bindS.DataSource = dt;
                dgvThongTinThe.DataSource = bindS;
                dgvThongTinThe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvThongTinThe.Columns[0].Width = 30;
            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
        }
    }
}
