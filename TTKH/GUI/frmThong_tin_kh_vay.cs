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
    public partial class frmThong_tin_kh_vay : Form
    {
        private frmNhap_thong_tin_hop_dong_vay _frmNhap_TTHD = null;
        
        //ChinhanhBUS cnbus = new ChinhanhBUS();
        KhachhangvayBUS khbus = new KhachhangvayBUS();
        TaisanthechapBUS tstcbus = new TaisanthechapBUS();
        HopdongvayBUS hdvaybus = new HopdongvayBUS();

        public frmThong_tin_kh_vay(frmNhap_thong_tin_hop_dong_vay frmNhap_TTHD)
        {
            this._frmNhap_TTHD = frmNhap_TTHD;
            InitializeComponent();
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            cboxLoai_kh.Text = "Cá nhân";
            this.AcceptButton = btnTim_kiem;
        }
        public frmThong_tin_kh_vay()
        {
            InitializeComponent();
            //List<Chinhanh> dschinhanh = new List<Chinhanh>();
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            cboxLoai_kh.Text = "Cá nhân";
            btnChon.Enabled = false;
            if (!Thong_tin_dang_nhap.admin)
            {
                txtma_CN.Text = Thong_tin_dang_nhap.ma_cn;
                cboxChi_nhanh.Enabled = false;
                cboxChi_nhanh.Text = Thong_tin_dang_nhap.ten_cn;
            }
            if (!Thong_tin_dang_nhap.admin && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Kế hoạch & Kinh doanh" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Doanh nghiệp" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân")
            {
                btnXoa.Enabled = false;
            }
            this.AcceptButton = btnTim_kiem;
        }

        private void cboxChi_nhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
        }

        private void btnTim_kiem_Click(object sender, EventArgs e)
        {

            Utilities.ControlFormat.DataGridView_ShowAllColumn(dgvDanh_sach_kh);
            if (cboxLoai_kh.Text == "Cá nhân")
            {
                    //List<string> columns = new List<string>();
                    //columns.Add("ma_cn");
                    //columns.Add("ten_tc");
                    //columns.Add("dkkd");
                    //columns.Add("dia_chi_tc");
                    //columns.Add("dai_dien");
                    //columns.Add("chuc_vu_dai_dien");
                    //columns.Add("dc_dai_dien");
                    //columns.Add("cmnd_dai_dien");
                    //columns.Add("ngay_cap_cmnd_dai_dien");
                    //columns.Add("noi_cap_cmnd_dai_dien");
                    if (string.IsNullOrEmpty(cboxTieu_chi.Text))
                    {
                        DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.CN_DS_KH_VAY(txtma_CN.Text,cboxLoai_kh.Text);
                        dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                    }
                    else if (cboxTieu_chi.Text == "Mã khách hàng")
                    {
                        DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.CN_DS_KH_VAY_THEO_MA(txtma_CN.Text,cboxLoai_kh.Text,txtTu_khoa.Text);
                        dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                    }
                    else if (cboxTieu_chi.Text == "Họ tên")
                    {
                        DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.CN_DS_KH_VAY_THEO_TEN(txtma_CN.Text, cboxLoai_kh.Text, txtTu_khoa.Text);
                        dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                    }
                    else if (cboxTieu_chi.Text == "Số chứng minh thư")
                    {
                        DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.CN_DS_KH_VAY_THEO_CMND(txtma_CN.Text, cboxLoai_kh.Text, txtTu_khoa.Text);
                        dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                    }
            }
            else if (cboxLoai_kh.Text == "Hộ gia đình")
            {
                    //List<string> columns = new List<string>();
                    //columns.Add("ma_cn");
                    //columns.Add("ten_chong");
                    //columns.Add("ns_chong");
                    //columns.Add("cmnd_chong");
                    //columns.Add("ngay_cap_cmnd_chong");
                    //columns.Add("noi_cap_cmnd_chong");
                    //columns.Add("dc_chong");
                    //columns.Add("hktt_chong");
                    //columns.Add("so_hk_chong");
                    //columns.Add("noi_cap_hk_chong");
                    //columns.Add("ngay_cap_hk_chong");
                    //columns.Add("ten_vo");
                    //columns.Add("ns_vo");
                    //columns.Add("cmnd_vo");
                    //columns.Add("ngay_cap_cmnd_vo");
                    //columns.Add("noi_cap_cmnd_vo");
                    //columns.Add("dc_vo");
                    //columns.Add("hktt_vo");
                    //columns.Add("so_hk_vo");
                    //columns.Add("noi_cap_hk_vo");
                    //columns.Add("ngay_cap_hk_vo");
                    if (string.IsNullOrEmpty(cboxTieu_chi.Text))
                    {
                        DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.HGD_DS_KH_VAY(txtma_CN.Text, cboxLoai_kh.Text);
                        dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                    }
                    else if (cboxTieu_chi.Text=="Mã khách hàng")
                    {
                        DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.HGD_DS_KH_VAY_THEO_MA(txtma_CN.Text, cboxLoai_kh.Text, txtTu_khoa.Text);
                        dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                    }
                    else if (cboxTieu_chi.Text == "Họ tên chồng")
                    {
                        DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.HGD_DS_KH_VAY_THEO_TEN_CHONG(txtma_CN.Text, cboxLoai_kh.Text, txtTu_khoa.Text);
                        dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                    }
                    else if (cboxTieu_chi.Text == "Họ tên vợ")
                    {
                        DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.HGD_DS_KH_VAY_THEO_TEN_VO(txtma_CN.Text, cboxLoai_kh.Text, txtTu_khoa.Text);
                        dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                    }
                    else if (cboxTieu_chi.Text == "Số chứng minh thư chồng")
                    {
                        DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.HGD_DS_KH_VAY_THEO_CMND_CHONG(txtma_CN.Text, cboxLoai_kh.Text, txtTu_khoa.Text);
                        dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                    }
                    else if (cboxTieu_chi.Text == "Số chứng minh thư vợ")
                    {
                        DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.HGD_DS_KH_VAY_THEO_CMND_VO(txtma_CN.Text, cboxLoai_kh.Text, txtTu_khoa.Text);
                        dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                    }
            }
            else if (cboxLoai_kh.Text == "Tổ chức")
            {
                if (string.IsNullOrEmpty(cboxTieu_chi.Text))
                {
                    DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.TC_DS_KH_VAY(txtma_CN.Text, cboxLoai_kh.Text);
                    dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                }
                else if (cboxTieu_chi.Text == "Mã khách hàng")
                {
                    DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.TC_DS_KH_VAY_THEO_MA(txtma_CN.Text, cboxLoai_kh.Text, txtTu_khoa.Text);
                    dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                }
                else if (cboxTieu_chi.Text == "Tên tổ chức")
                {
                    DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.TC_DS_KH_VAY_THEO_TEN(txtma_CN.Text, cboxLoai_kh.Text, txtTu_khoa.Text);
                    dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                }
                else if (cboxTieu_chi.Text == "Tên người đại diện")
                {
                    DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.TC_DS_KH_VAY_THEO_TEN_DAI_DIEN(txtma_CN.Text, cboxLoai_kh.Text, txtTu_khoa.Text);
                    dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                }
                else if (cboxTieu_chi.Text == "Số chứng minh thư người đại diện")
                {
                    DataTable TBL_KH_VAY = AGRIBANKHD.BUS.KhachhangvayBUS.TC_DS_KH_VAY_THEO_CMND_DAI_DIEN(txtma_CN.Text, cboxLoai_kh.Text, txtTu_khoa.Text);
                    dgvDanh_sach_kh.DataSource = TBL_KH_VAY;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_kh);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmNhap_thong_tin_kh_vay frm = new frmNhap_thong_tin_kh_vay(txtma_CN.Text, cboxChi_nhanh.Text);
            //frm.MdiParent = this.ParentForm;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanh_sach_kh.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvDanh_sach_kh.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvDanh_sach_kh.Rows[selectedrowindex];
                string ma_kh_vay = Convert.ToString(selectedRow.Cells["ma_kh_vay"].Value);
                frmNhap_thong_tin_kh_vay frm = new frmNhap_thong_tin_kh_vay(txtma_CN.Text,cboxChi_nhanh.Text, ma_kh_vay);
                //frm.MdiParent = this.ParentForm;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
                //frm.BringToFront();
            }
            else
            {
                MessageBox.Show("Chưa có khách hàng nào được chọn để cập nhật thông tin");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanh_sach_kh.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Xóa khách hàng sẽ xóa tất cả các hợp đồng vay kèm tài sản thế chấp liên quan đến khách hàng này. Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int selectedrowindex = dgvDanh_sach_kh.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvDanh_sach_kh.Rows[selectedrowindex];
                    string ma_kh_vay = Convert.ToString(selectedRow.Cells["ma_kh_vay"].Value);
                    List<Hopdongvay> list_hdvay = HopdongvayBUS.HD_VAY_theoma_KH(ma_kh_vay, txtma_CN.Text);
                    for (int i = 0; i < list_hdvay.Count; i++)
                    {
                        Hopdongvay hdvay = list_hdvay[i];
                        tstcbus.XOA_TSTC_THEO_MA_HD_VAY(list_hdvay[i].ma_hd_vay);
                    }
                    hdvaybus.XOA_HD_VAY_THEO_MA_KH(ma_kh_vay);
                    if (khbus.XOA_KH_VAY(ma_kh_vay))
                    {
                        MessageBox.Show("Xóa thông tin khách hàng thành công!");
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
                MessageBox.Show("Chưa có khách hàng nào được chọn để xóa thông tin");
            }
        }

        private void cboxLoai_kh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxTieu_chi.Items.Clear();
            if (cboxLoai_kh.Text=="Cá nhân")
            {
                cboxTieu_chi.Items.Add("");
                cboxTieu_chi.Items.Add("Mã khách hàng");
                cboxTieu_chi.Items.Add("Họ tên");
                cboxTieu_chi.Items.Add("Số chứng minh thư");
                txtTu_khoa.ResetText();
            }
            else if (cboxLoai_kh.Text=="Hộ gia đình")
            {
                cboxTieu_chi.Items.Add("");
                cboxTieu_chi.Items.Add("Mã khách hàng");
                cboxTieu_chi.Items.Add("Họ tên chồng");
                cboxTieu_chi.Items.Add("Họ tên vợ");
                cboxTieu_chi.Items.Add("Số chứng minh thư chồng");
                cboxTieu_chi.Items.Add("Số chứng minh thư vợ");
                txtTu_khoa.ResetText();
            }
            else if (cboxLoai_kh.Text=="Tổ chức")
            {
                cboxTieu_chi.Items.Add("");
                cboxTieu_chi.Items.Add("Mã khách hàng");
                cboxTieu_chi.Items.Add("Tên tổ chức");
                cboxTieu_chi.Items.Add("Tên người đại diện");
                cboxTieu_chi.Items.Add("Số chứng minh thư người đại diện");
                txtTu_khoa.ResetText();
            }
            cboxTieu_chi.ResetText();
        }
       
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvDanh_sach_kh.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvDanh_sach_kh.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvDanh_sach_kh.Rows[selectedrowindex];
                _frmNhap_TTHD._ma_kh_vay = Convert.ToString(selectedRow.Cells["ma_kh_vay"].Value);
                _frmNhap_TTHD.Cap_nhat_txtMa_kh_vay();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Chưa có khách hàng nào được chọn");
            }
        }       
        
        internal void Chon_kh_vay(string ma_cn, string chi_nhanh)
        {
            this.btnSua.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnChon.Enabled = true;
            this.cboxChi_nhanh.Enabled = false;
            this.txtma_CN.Text = ma_cn;
            this.cboxChi_nhanh.Text = chi_nhanh;
        }

        private void cboxTieu_chi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxTieu_chi.Text))
            {
                txtTu_khoa.Enabled = false;
            }
            else
            {
                txtTu_khoa.Enabled = true;
            }
        }

    }
}
