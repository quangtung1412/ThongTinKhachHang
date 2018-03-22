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
    public partial class frmThong_tin_can_bo : Form
    {
                
        //ChinhanhBUS cnbus = new ChinhanhBUS();
        CanbotindungBUS cbbus = new CanbotindungBUS();
        public frmThong_tin_can_bo()
        {
            InitializeComponent();
            //List<Chinhanh> dschinhanh = new List<Chinhanh>();
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            if (!Thong_tin_dang_nhap.admin)
            {
                txtma_CN.Text = Thong_tin_dang_nhap.ma_cn;
                cboxChi_nhanh.Enabled = false;
                cboxChi_nhanh.Text = Thong_tin_dang_nhap.ten_cn;
                btnXoa.Enabled = false;
            }
            rdbKich_hoat.Checked = true;
        }   

        private void cboxChi_nhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            cboxChuc_vu.Items.Clear();
            if (cboxChi_nhanh.SelectedValue.ToString() == "2300")
            {
                cboxChuc_vu.Items.Add("");
                cboxChuc_vu.Items.Add("Giám đốc");
                cboxChuc_vu.Items.Add("Phó Giám đốc");
                cboxChuc_vu.Items.Add("Trưởng phòng Khách hàng Doanh nghiệp");
                cboxChuc_vu.Items.Add("Phó phòng Khách hàng Doanh nghiệp");
                cboxChuc_vu.Items.Add("Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân");
                cboxChuc_vu.Items.Add("Phó phòng Khách hàng Hộ sản xuất và Cá nhân");
                cboxChuc_vu.Items.Add("Giám đốc phòng giao dịch");
                cboxChuc_vu.Items.Add("Phó Giám đốc phòng giao dịch");
                cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
            }
            else
            {
                cboxChuc_vu.Items.Add("");
                cboxChuc_vu.Items.Add("Giám đốc");
                cboxChuc_vu.Items.Add("Phó Giám đốc");
                cboxChuc_vu.Items.Add("Trưởng phòng Kế hoạch & Kinh doanh");
                cboxChuc_vu.Items.Add("Phó phòng Kế hoạch & Kinh doanh");
                cboxChuc_vu.Items.Add("Giám đốc phòng giao dịch");
                cboxChuc_vu.Items.Add("Phó Giám đốc phòng giao dịch");
                cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
            }
            cboxChuc_vu.ResetText();
        }

        private void btnTim_kiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxChuc_vu.Text))
            {
               List<string> columns = new List<string>();
               columns.Add("mat_khau");
                if (rdbKich_hoat.Checked)
                {
                    DataTable tbl_CBTD = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD(txtma_CN.Text);
                    dgvDanh_sach_can_bo.DataSource = tbl_CBTD;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_can_bo);
                    Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_can_bo, columns);
                }
                else
                {
                    DataTable tbl_CBTD = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_chua_kich_hoat(txtma_CN.Text);
                    dgvDanh_sach_can_bo.DataSource = tbl_CBTD;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_can_bo);
                    Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_can_bo, columns);
                }
               
           }
           else
           {
               List<string> columns = new List<string>();
               columns.Add("mat_khau");
                if (rdbKich_hoat.Checked)
                {
                    DataTable tbl_CBTD_CV = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, cboxChuc_vu.Text);
                    dgvDanh_sach_can_bo.DataSource = tbl_CBTD_CV;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_can_bo);
                    Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_can_bo, columns);
                }
                else
                {
                    DataTable tbl_CBTD_CV = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_chua_kich_hoat(txtma_CN.Text, cboxChuc_vu.Text);
                    dgvDanh_sach_can_bo.DataSource = tbl_CBTD_CV;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_can_bo);
                    Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_can_bo, columns);
                }
           }
        }

        public void Tim_kiem_can_bo()
        {
            this.btnTim_kiem.PerformClick();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //string ma_CN_temp = txtma_CN.Text;
            //string Chi_nhanh_temp = cboxChi_nhanh.Text;
            //this.Close();
            //frmNhap_thong_tin_can_bo frm = new frmNhap_thong_tin_can_bo(ma_CN_temp,Chi_nhanh_temp);
            frmNhap_thong_tin_can_bo frm = new frmNhap_thong_tin_can_bo(txtma_CN.Text,cboxChi_nhanh.Text);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        { 
            if (dgvDanh_sach_can_bo.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvDanh_sach_can_bo.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvDanh_sach_can_bo.Rows[selectedrowindex];  
                string ten_dang_nhap = Convert.ToString(selectedRow.Cells["TEN_DANG_NHAP"].Value);
                frmNhap_thong_tin_can_bo frm = new frmNhap_thong_tin_can_bo(txtma_CN.Text,cboxChi_nhanh.Text, ten_dang_nhap);
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa có cán bộ nào được chọn để cập nhật thông tin");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanh_sach_can_bo.SelectedCells.Count > 0)
            { 
                if (MessageBox.Show("Bạn có chắc muốn xóa cán bộ này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int selectedrowindex = dgvDanh_sach_can_bo.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvDanh_sach_can_bo.Rows[selectedrowindex];
                    string ten_dang_nhap = Convert.ToString(selectedRow.Cells["TEN_DANG_NHAP"].Value);
                    if (cbbus.Xoa_CBTD(ten_dang_nhap))
                    {
                        MessageBox.Show("Xóa cán bộ tín dụng thành công!");
                        btnTim_kiem.PerformClick();
                        //this.Close();
                    }
                    else MessageBox.Show("Có lỗi xảy ra. Đề nghị liên hệ phòng Điện toán!");
                }
                else
                {
                    this.Activate();
                }
            }
            else
            {
                MessageBox.Show("Chưa có cán bộ nào được chọn để xóa thông tin");
            }
        }
    }
}
