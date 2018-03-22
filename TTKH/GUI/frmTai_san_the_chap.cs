using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGRIBANKHD.BUS;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;
using AGRIBANKHD.Utilities;

namespace AGRIBANKHD.GUI
{
    public partial class frmTai_san_the_chap : Form
    {

        internal string _ma_hd_vay { get; set; }

        TaisanthechapBUS tstcbus = new TaisanthechapBUS();

        public frmTai_san_the_chap()
        {
            InitializeComponent();
            //List<Chinhanh> dschinhanh = new List<Chinhanh>();
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            this.AcceptButton = btnTim_kiem;
            if (!Thong_tin_dang_nhap.admin)
            {
                txtma_CN.Text = Thong_tin_dang_nhap.ma_cn;
                cboxChi_nhanh.Enabled = false;
                cboxChi_nhanh.Text = Thong_tin_dang_nhap.ten_cn;
            }
        }

        private void cboxChi_nhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
        }

        private void btnTim_kiem_Click(object sender, EventArgs e)
        {
            List<string> number_columns = new List<string>();
            number_columns.Add("DS_GIA_TRI");
            number_columns.Add("BDS_GIA_TRI");
            number_columns.Add("TSTC_KHAC_GIA_TRI");
            ControlFormat.DataGridView_ShowAllColumn(dgvDanh_sach_tstc);
            if (!string.IsNullOrEmpty(txtMa_hd_vay.Text))
            {
                DataTable DS_TSTC = AGRIBANKHD.BUS.TaisanthechapBUS.DS_TSTC(txtMa_hd_vay.Text);
                dgvDanh_sach_tstc.DataSource = DS_TSTC;
                Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_tstc);
                ControlFormat.DataGridView_RemoveEmptyColumns(dgvDanh_sach_tstc);
                ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_tstc, number_columns);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn mã hợp đồng.");
                txtMa_hd_vay.Focus();
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMa_hd_vay.Text))
            { 
            frmNhap_tai_san_the_chap frm = new frmNhap_tai_san_the_chap(txtMa_hd_vay.Text, txtma_CN.Text);
            //frm.MdiParent = this.MdiParent;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            //frm.BringToFront();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn mã hợp đồng.");
                txtMa_hd_vay.Focus();
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanh_sach_tstc.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvDanh_sach_tstc.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvDanh_sach_tstc.Rows[selectedrowindex];
                //string ma_ts_the_chap = Convert.ToString(selectedRow.Cells["ma_ts_the_chap"].Value);
                int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
                frmNhap_tai_san_the_chap frm = new frmNhap_tai_san_the_chap(txtMa_hd_vay.Text, txtma_CN.Text, ma_ts_the_chap);
                //frm.Sua_tai_san_the_chap(ma_ts_the_chap);
                //frm.MdiParent = this.MdiParent;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa có tài sản thế chấp nào được chọn để sửa đổi thông tin");
            }
        }

        private void btnTim_kiem_hop_dong_vay_Click(object sender, EventArgs e)
        {
            frmThong_tin_hop_dong_vay frm = new frmThong_tin_hop_dong_vay(this, txtma_CN.Text, cboxChi_nhanh.Text);
            //frm.MdiParent = this.ParentForm;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            //frm.BringToFront();
        }

        internal void Cap_nhat_txtMa_hd_vay()
        {
            txtMa_hd_vay.Text = _ma_hd_vay;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {           
            if (dgvDanh_sach_tstc.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa tài sản thế chấp này này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int selectedrowindex = dgvDanh_sach_tstc.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvDanh_sach_tstc.Rows[selectedrowindex];
                    //string ma_ts_the_chap = Convert.ToString(selectedRow.Cells["ma_ts_the_chap"].Value);
                    int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
                    tstcbus.XOA_TSTC(ma_ts_the_chap);
                    btnTim_kiem.PerformClick();
                }
                {
                    this.Activate();
                }
            }
            else
            {
                MessageBox.Show("Chưa có tài sản thế chấp nào được chọn xóa thông tin");
            }
        }
    }
}
