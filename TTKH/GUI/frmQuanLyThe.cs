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
            cbTieuChi_TheoNgay.SelectedIndex = 0;
            cbTieuChi_ThongTin.SelectedIndex = 0;
        }

        void DSTheChuaNhan()
        {
            try
            {
                DataTable dt = TheDAL.TheChuaNhan(dtpTuNgay.Text, dtpDenNgay.Text);
                FillData(dt);
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
                FillData(dt);
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
                FillData(dt);
            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
        }


        void TatCaThe()
        {
            try
            {
                DataTable dt = TheDAL.TatCaThe(dtpTuNgay.Text, dtpDenNgay.Text);
                FillData(dt);
            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
        }

        void DSTheTheoMaKH()
        {
            try
            {
                DataTable dt = TheDAL.TheTheoMaKH(txtThongTin.Text);
                FillData(dt);
            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
        }

        void DSTheTheoCMND()
        {
            try
            {
                DataTable dt = TheDAL.TheTheoCMND(txtThongTin.Text);
                FillData(dt);
            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
        }

        void FillData(DataTable dt)
        {
            BindingSource bindS = new BindingSource();
            bindS.DataSource = dt;
            dgvThongTinThe.DataSource = bindS;
            dgvThongTinThe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongTinThe.Columns[0].Width = 30;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thẻ nào!");
            }
        }

        private void dgvThongTinThe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            frmThongTinThe frm = new frmThongTinThe(
                dgvThongTinThe.Rows[e.RowIndex].Cells[2].Value.ToString(),
                dgvThongTinThe.Rows[e.RowIndex].Cells[4].Value.ToString()
                );
            //frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_TheoNgay_Click(object sender, EventArgs e)
        {
            TimKiem_TheoNgay();
        }

        void TimKiem_TheoNgay()
        {
            switch (cbTieuChi_TheoNgay.SelectedIndex)
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
                case 3:
                    TatCaThe();
                    break;
                default: break;
            }
        }

        private void btnTimKiem_TheoThongTin_Click(object sender, EventArgs e)
        {
            TimKiem_TheoThongTin();
        }

        void TimKiem_TheoThongTin()
        {
            if (string.IsNullOrEmpty(txtThongTin.Text))
            {
                MessageBox.Show("Hãy nhập thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK);
                txtThongTin.Focus();
                return;
            }
            switch (cbTieuChi_TheoNgay.SelectedIndex)
            {
                case 0:
                    DSTheTheoCMND();
                    break;
                case 1:
                    DSTheTheoMaKH();
                    break;
                default: break;
            }
        }

        private void dgvThongTinThe_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add("Xóa", new EventHandler(btnDeleteThe_Click));
                cm.MenuItems.Add("Sửa", new EventHandler(btnSua_Click));
                dgvThongTinThe.ContextMenu = cm;
                dgvThongTinThe.ContextMenu.Show(dgvThongTinThe, e.Location);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvThongTinThe.SelectedRows[0].Index;
            frmThongTinThe frm = new frmThongTinThe(
                dgvThongTinThe.Rows[rowIndex].Cells[2].Value.ToString(),
                dgvThongTinThe.Rows[rowIndex].Cells[4].Value.ToString()
                );
            //frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void btnDeleteThe_Click(object sender, EventArgs e)
        {
            string soThe = dgvThongTinThe.SelectedRows[0].Cells[3].Value.ToString();
            if (string.IsNullOrEmpty(soThe))
            {
                MessageBox.Show("Thẻ chưa được phát hành!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            DialogResult result = MessageBox.Show("Có chắc chắn xóa thẻ " + soThe + "?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    TheDAL.DeleteThe(soThe);
                    MessageBox.Show("Xóa thẻ "+ soThe + " thành công!","Thông báo", MessageBoxButtons.OK);
                }
                catch
                {
                    ErrorMessageDAL.DataAccessError();
                }
            }
        }

        private void txtThongTin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Tim kiem
                TimKiem_TheoThongTin();
            }
        }
    }
}
