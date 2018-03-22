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
    public partial class frmNhap_thong_tin_kh_vay : Form
    {

        //ChinhanhBUS kh_vaybus = new ChinhanhBUS();
        KhachhangvayBUS kh_vaybus = new KhachhangvayBUS();
        private string _ma_kh_vay = "";

        public frmNhap_thong_tin_kh_vay(string ma_cn, string ten_cn)
        {
            InitializeComponent();
            //List<Chinhanh> dschinhanh = new List<Chinhanh>();
            //List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            List<Chinhanh> dschinhanh = ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            cboxLoai_kh.Text = "Cá nhân";
            grbCn_thong_tin_kh.Visible = true;
            cboxCn_danh_xung.Text = "Ông";
            grbHgd_thong_tin_kh.Visible = false;
            grbTc_thong_tin_kh.Visible = false;
            cboxChi_nhanh.Enabled = false;
            txtma_CN.Text = ma_cn;           
            cboxChi_nhanh.Text = ten_cn;          
        }

        public frmNhap_thong_tin_kh_vay(string ma_cn, string ten_cn, string ma_kh_vay)
        {
            InitializeComponent();
            this._ma_kh_vay = ma_kh_vay;
            DataTable DS_KH_VAY_THEO_MA = KhachhangvayBUS.DS_KH_VAY_THEO_MA(ma_kh_vay);
            DataRow row = DS_KH_VAY_THEO_MA.Rows[0];
            Khachhangvay kh = new Khachhangvay(row);
                        
            txtMa_kh_vay.Text = ma_kh_vay;
            txtMa_kh_vay.ReadOnly = true;

            List<Chinhanh> dschinhanh = ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            cboxChi_nhanh.Enabled = false;
            txtma_CN.Text = ma_cn;
            cboxChi_nhanh.Text = ten_cn;

            cboxLoai_kh.Enabled = false;
            cboxLoai_kh.Text = kh.loai_kh;

            if (kh.loai_kh == "Cá nhân")
            {
                grbCn_thong_tin_kh.Visible = true;
                grbHgd_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbHgd_thong_tin_kh);
                grbTc_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbTc_thong_tin_kh);
            }
            else if (kh.loai_kh == "Hộ gia đình")
            {
                grbCn_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbCn_thong_tin_kh);
                grbHgd_thong_tin_kh.Visible = true;
                grbTc_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbTc_thong_tin_kh);
            }
            else if (kh.loai_kh == "Tổ chức")
            {
                grbCn_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbCn_thong_tin_kh);
                grbHgd_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbHgd_thong_tin_kh);
                grbTc_thong_tin_kh.Visible = true;
            }

            txtHgd_ten_chong.Text = kh.hgd_ten_chong;
            txtHgd_ns_chong.Text = kh.hgd_ns_chong;
            txtHgd_cmnd_chong.Text = kh.hgd_cmnd_chong;
            txtHgd_ngay_cap_cmnd_chong.Text = kh.hgd_ngay_cap_cmnd_chong;
            txtHgd_noi_cap_cmnd_chong.Text = kh.hgd_noi_cap_cmnd_chong;
            txtHgd_dc_chong.Text = kh.hgd_dc_chong;
            txtHgd_hktt_chong.Text = kh.hgd_hktt_chong;
            txtHgd_so_hk_chong.Text = kh.hgd_so_hk_chong;
            txtHgd_noi_cap_hk_chong.Text = kh.hgd_noi_cap_hk_chong;
            txtHgd_ngay_cap_hk_chong.Text = kh.hgd_ngay_cap_hk_chong;
            txtHgd_ten_vo.Text = kh.hgd_ten_vo;
            txtHgd_ns_vo.Text = kh.hgd_ns_vo;
            txtHgd_cmnd_vo.Text = kh.hgd_cmnd_vo;
            txtHgd_ngay_cap_cmnd_vo.Text = kh.hgd_ngay_cap_cmnd_vo;
            txtHgd_noi_cap_cmnd_vo.Text = kh.hgd_noi_cap_cmnd_vo;
            txtHgd_dc_vo.Text = kh.hgd_dc_vo;
            txtHgd_hktt_vo.Text = kh.hgd_hktt_vo;
            txtHgd_so_hk_vo.Text = kh.hgd_so_hk_vo;
            txtHgd_noi_cap_hk_vo.Text = kh.hgd_noi_cap_hk_vo;
            txtHgd_ngay_cap_hk_vo.Text = kh.hgd_ngay_cap_hk_vo;
            txtHgd_dkkd.Text = kh.hgd_dkkd;
            cboxHgd_dai_dien.Text = kh.hgd_dai_dien;
            txtHgd_dien_thoai.Text = kh.hgd_dien_thoai;
            txtHgd_fax.Text = kh.hgd_fax;
            txtHgd_email.Text = kh.hgd_email;
            cboxCn_danh_xung.Text = kh.cn_danh_xung;
            txtCn_ten.Text = kh.cn_ten;
            txtCn_ns.Text = kh.cn_ns;
            txtCn_cmnd.Text = kh.cn_cmnd;
            txtCn_ngay_cap_cmnd.Text = kh.cn_ngay_cap_cmnd;
            txtCn_noi_cap_cmnd.Text = kh.cn_noi_cap_cmnd;
            txtCn_dc.Text = kh.cn_dc;
            txtCn_hktt.Text = kh.cn_hktt;
            txtCn_so_hk.Text = kh.cn_so_hk;
            txtCn_noi_cap_hk.Text = kh.cn_noi_cap_hk;
            txtCn_ngay_cap_hk.Text = kh.cn_ngay_cap_hk;
            txtCn_dkkd.Text = kh.cn_dkkd;
            txtCn_dien_thoai.Text = kh.cn_dien_thoai;
            txtCn_fax.Text = kh.cn_fax;
            txtCn_email.Text = kh.cn_email;
            txtTc_ten.Text = kh.tc_ten;
            txtTc_dkkd.Text = kh.tc_dkkd;
            txtTc_dc.Text = kh.tc_dc;
            cboxTc_danh_xung_dai_dien.Text = kh.tc_danh_xung_dai_dien;
            txtTc_dai_dien.Text = kh.tc_dai_dien;
            txtTc_ns_dai_dien.Text = kh.tc_ns_dai_dien;
            txtTc_chuc_vu_dai_dien.Text = kh.tc_chuc_vu_dai_dien;
            txtTc_giay_uy_quyen.Text = kh.tc_giay_uy_quyen;
            txtTc_dc_dai_dien.Text = kh.tc_dc_dai_dien;
            txtTc_cmnd_dai_dien.Text = kh.tc_cmnd_dai_dien;
            txtTc_ngay_cap_cmnd_dai_dien.Text = kh.tc_ngay_cap_cmnd_dai_dien;
            txtTc_noi_cap_cmnd_dai_dien.Text = kh.tc_noi_cap_cmnd_dai_dien;
            txtTc_hktt_dai_dien.Text = kh.tc_hktt_dai_dien;
            txtTc_so_hk_dai_dien.Text = kh.tc_so_hk_dai_dien;
            txtTc_noi_cap_hk_dai_dien.Text = kh.tc_noi_cap_hk_dai_dien;
            txtTc_ngay_cap_hk_dai_dien.Text = kh.tc_ngay_cap_hk_dai_dien;
            txtTc_dien_thoai.Text = kh.tc_dien_thoai;
            txtTc_fax.Text = kh.tc_fax;
            txtTc_email.Text = kh.tc_email;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_man_hinhClick(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(_ma_kh_vay))
            {
                string[] name_of_textbox = { "txtma_CN" };
                CommonMethods.ClearTextBoxes(this, name_of_textbox);
            }
            else
            {
                string[] name_of_textbox = { "txtma_CN", "txtMa_kh_vay" };
                CommonMethods.ClearTextBoxes(this, name_of_textbox);
            }
        }

        private void cboxChi_nhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
        }

        private void cboxLoai_kh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxLoai_kh.Text=="Cá nhân")
            {
                grbCn_thong_tin_kh.Visible = true;
                cboxCn_danh_xung.Text = "Ông";
                grbHgd_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbHgd_thong_tin_kh);
                cboxHgd_dai_dien.Text = "";
                grbTc_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbTc_thong_tin_kh);
                cboxTc_danh_xung_dai_dien.Text = "";
                
                txtCn_noi_cap_cmnd.Text = "CA tỉnh Hải Dương";
                txtCn_noi_cap_hk.Text = "CA thành phố Hải Dương";
                txtTc_noi_cap_cmnd_dai_dien.Clear();
                txtTc_noi_cap_hk_dai_dien.Clear();
                txtHgd_noi_cap_cmnd_chong.Clear();
                txtHgd_noi_cap_hk_chong.Clear();
                txtHgd_noi_cap_cmnd_vo.Clear();
                txtHgd_noi_cap_hk_vo.Clear();
            }
            else if (cboxLoai_kh.Text=="Hộ gia đình")
            {
                grbCn_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbCn_thong_tin_kh);
                cboxCn_danh_xung.Text = "";
                grbHgd_thong_tin_kh.Visible = true;
                cboxHgd_dai_dien.Text = "Chồng";
                grbTc_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbTc_thong_tin_kh);
                cboxTc_danh_xung_dai_dien.Text = "";

                txtCn_noi_cap_cmnd.Clear();
                txtCn_noi_cap_hk.Clear();
                txtTc_noi_cap_cmnd_dai_dien.Clear();
                txtTc_noi_cap_hk_dai_dien.Clear();
                txtHgd_noi_cap_cmnd_chong.Text = "CA tỉnh Hải Dương";
                txtHgd_noi_cap_hk_chong.Text = "CA thành phố Hải Dương";
                txtHgd_noi_cap_cmnd_vo.Text = "CA tỉnh Hải Dương";
                txtHgd_noi_cap_hk_vo.Text = "CA thành phố Hải Dương";
            }
            else if (cboxLoai_kh.Text == "Tổ chức")
            {
                grbCn_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbCn_thong_tin_kh);
                cboxCn_danh_xung.Text = "";
                grbHgd_thong_tin_kh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbHgd_thong_tin_kh);
                cboxHgd_dai_dien.Text = "";
                grbTc_thong_tin_kh.Visible = true;
                cboxTc_danh_xung_dai_dien.Text = "Ông";

                txtCn_noi_cap_cmnd.Clear();
                txtCn_noi_cap_hk.Clear();
                txtTc_noi_cap_cmnd_dai_dien.Text = "CA tỉnh Hải Dương";
                txtTc_noi_cap_hk_dai_dien.Text = "CA thành phố Hải Dương";
                txtHgd_noi_cap_cmnd_chong.Clear();
                txtHgd_noi_cap_hk_chong.Clear();
                txtHgd_noi_cap_cmnd_vo.Clear();
                txtHgd_noi_cap_hk_vo.Clear();
            }
        }

        private void btnCap_nhat_Click(object sender, EventArgs e)
        {
            if (cboxLoai_kh.Text == "Cá nhân")
            {
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_cmnd.Text) && (txtCn_ngay_cap_cmnd.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtCn_ngay_cap_cmnd.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_hk.Text) && (txtCn_ngay_cap_hk.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtCn_ngay_cap_hk.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ns.Text) && (txtCn_ns.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtCn_ns.Focus();
                    return;
                }
            }
            else if (cboxLoai_kh.Text == "Hộ gia đình")
            {
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_chong.Text) && (txtHgd_ns_chong.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtHgd_ns_chong.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_vo.Text) && (txtHgd_ns_vo.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtHgd_ns_vo.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_chong.Text) && (txtHgd_ngay_cap_cmnd_chong.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtHgd_ngay_cap_cmnd_chong.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_vo.Text) && (txtHgd_ngay_cap_cmnd_vo.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtHgd_ngay_cap_cmnd_vo.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_chong.Text) && (txtHgd_ngay_cap_hk_chong.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtHgd_ngay_cap_hk_chong.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_vo.Text) && (txtHgd_ngay_cap_hk_vo.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtHgd_ngay_cap_hk_vo.Focus();
                    return;
                }
            }
            else if (cboxLoai_kh.Text == "Tổ chức")
            {
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ns_dai_dien.Text) && (txtTc_ns_dai_dien.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtTc_ns_dai_dien.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_cmnd_dai_dien.Text) && (txtTc_ngay_cap_cmnd_dai_dien.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtTc_ngay_cap_cmnd_dai_dien.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_hk_dai_dien.Text) && (txtTc_ngay_cap_hk_dai_dien.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtTc_ngay_cap_hk_dai_dien.Focus();
                    return;
                }
            }
            
            if (string.IsNullOrEmpty(_ma_kh_vay))
            //Start - Thêm mới khách hàng
            {
                if (string.IsNullOrEmpty(txtMa_kh_vay.Text))
                {
                    MessageBox.Show("Bạn chưa nhập mã khách hàng (trường bắt buộc)");
                    txtMa_kh_vay.Focus();
                    return;
                }
                //Start - Kiểm tra trùng mã khách hàng hay không
                if (kh_vaybus.KIEM_TRA_TRUNG_MA_KH(txtMa_kh_vay.Text))
                {
                    MessageBox.Show("Mã khách hàng đã có trong hệ thống. Đề nghị kiểm tra lại thông tin!");
                    txtMa_kh_vay.Focus();
                    return;
                }
                //End - Kiểm tra trùng mã khách hàng hay không

                string[] thong_tin_kh = new string[62];
                thong_tin_kh[0] = txtMa_kh_vay .Text;
                thong_tin_kh[1] = cboxLoai_kh.Text;
                thong_tin_kh[2] = txtma_CN.Text;
                thong_tin_kh[3] = txtHgd_ten_chong.Text;
                if (txtHgd_ns_chong.Text == "  /  /")
                {
                    thong_tin_kh[4] = "";
                }
                else
                {
                    thong_tin_kh[4] = txtHgd_ns_chong.Text;
                }
                thong_tin_kh[5] = txtHgd_cmnd_chong.Text;
                if (txtHgd_ngay_cap_cmnd_chong.Text == "  /  /")
                {
                    thong_tin_kh[6] = "";
                }
                else
                {
                    thong_tin_kh[6] = txtHgd_ngay_cap_cmnd_chong.Text;
                }                
                thong_tin_kh[7] = txtHgd_noi_cap_cmnd_chong .Text;
                thong_tin_kh[8] = txtHgd_dc_chong .Text;
                thong_tin_kh[9] = txtHgd_hktt_chong .Text;
                thong_tin_kh[10] = txtHgd_so_hk_chong .Text;
                thong_tin_kh[11] = txtHgd_noi_cap_hk_chong.Text;
                if (txtHgd_ngay_cap_hk_chong.Text == "  /  /")
                {
                    thong_tin_kh[12] = "";
                }
                else
                {
                    thong_tin_kh[12] = txtHgd_ngay_cap_hk_chong.Text;
                }                
                thong_tin_kh[13] = txtHgd_ten_vo.Text;
                if (txtHgd_ns_vo.Text == "  /  /")
                {
                    thong_tin_kh[14] = "";
                }
                else
                {
                    thong_tin_kh[14] = txtHgd_ns_vo.Text;
                }                
                thong_tin_kh[15] = txtHgd_cmnd_vo.Text;
                if (txtHgd_ngay_cap_cmnd_vo.Text == "  /  /")
                {
                    thong_tin_kh[16] = "";
                }
                else
                {
                    thong_tin_kh[16] = txtHgd_ngay_cap_cmnd_vo.Text;
                }                
                thong_tin_kh[17] = txtHgd_noi_cap_cmnd_vo.Text;
                thong_tin_kh[18] = txtHgd_dc_vo.Text;
                thong_tin_kh[19] = txtHgd_hktt_vo.Text;
                thong_tin_kh[20] = txtHgd_so_hk_vo.Text;
                thong_tin_kh[21] = txtHgd_noi_cap_hk_vo.Text;
                if (txtHgd_ngay_cap_hk_vo.Text == "  /  /")
                {
                    thong_tin_kh[22] = "";
                }
                else
                {
                    thong_tin_kh[22] = txtHgd_ngay_cap_hk_vo.Text;
                }                
                thong_tin_kh[23] = txtHgd_dkkd.Text;
                thong_tin_kh[24] = txtHgd_dien_thoai.Text;
                thong_tin_kh[25] = txtHgd_fax.Text;
                thong_tin_kh[26] = txtHgd_email.Text;
                thong_tin_kh[27] = cboxCn_danh_xung.Text;
                thong_tin_kh[28] = txtCn_ten.Text;
                if (txtCn_ns.Text == "  /  /")
                {
                    thong_tin_kh[29] = "";
                }
                else
                {
                    thong_tin_kh[29] = txtCn_ns.Text;
                }                
                thong_tin_kh[30] = txtCn_cmnd.Text;
                if (txtCn_ngay_cap_cmnd.Text == "  /  /")
                {
                    thong_tin_kh[31] = "";
                }
                else
                {
                    thong_tin_kh[31] = txtCn_ngay_cap_cmnd.Text;
                }                
                thong_tin_kh[32] = txtCn_noi_cap_cmnd.Text;
                thong_tin_kh[33] = txtCn_dc.Text;
                thong_tin_kh[34] = txtCn_hktt.Text;
                thong_tin_kh[35] = txtCn_so_hk.Text;
                thong_tin_kh[36] = txtCn_noi_cap_hk.Text;
                if (txtCn_ngay_cap_hk.Text == "  /  /")
                {
                    thong_tin_kh[37] = "";
                }
                else
                {
                    thong_tin_kh[37] = txtCn_ngay_cap_hk.Text;
                }                
                thong_tin_kh[38] = txtCn_dkkd.Text;
                thong_tin_kh[39] = txtCn_dien_thoai.Text;
                thong_tin_kh[40] = txtCn_fax.Text;
                thong_tin_kh[41] = txtCn_email.Text;
                thong_tin_kh[42] = txtTc_ten.Text;
                thong_tin_kh[43] = txtTc_dkkd.Text;
                thong_tin_kh[44] = txtTc_dc.Text;
                thong_tin_kh[45] = cboxTc_danh_xung_dai_dien.Text;
                thong_tin_kh[46] = txtTc_dai_dien.Text;
                if (txtTc_ns_dai_dien.Text == "  /  /")
                {
                    thong_tin_kh[47] = "";
                }
                else
                {
                    thong_tin_kh[47] = txtTc_ns_dai_dien.Text;
                }                
                thong_tin_kh[48] = txtTc_chuc_vu_dai_dien.Text;
                thong_tin_kh[49] = txtTc_giay_uy_quyen.Text;
                thong_tin_kh[50] = txtTc_dc_dai_dien.Text;
                thong_tin_kh[51] = txtTc_cmnd_dai_dien.Text;
                if (txtTc_ngay_cap_cmnd_dai_dien.Text == "  /  /")
                {
                    thong_tin_kh[52] = "";
                }
                else
                {
                    thong_tin_kh[52] = txtTc_ngay_cap_cmnd_dai_dien.Text;
                }               
                thong_tin_kh[53] = txtTc_noi_cap_cmnd_dai_dien.Text;
                thong_tin_kh[54] = txtTc_hktt_dai_dien.Text;
                thong_tin_kh[55] = txtTc_so_hk_dai_dien.Text;
                thong_tin_kh[56] = txtTc_noi_cap_hk_dai_dien.Text;
                if (txtTc_ngay_cap_hk_dai_dien.Text == "  /  /")
                {
                    thong_tin_kh[57] = "";
                }
                else
                {
                    thong_tin_kh[57] = txtTc_ngay_cap_hk_dai_dien.Text;
                }                
                thong_tin_kh[58] = txtTc_dien_thoai.Text;
                thong_tin_kh[59] = txtTc_fax.Text;
                thong_tin_kh[60] = txtTc_email.Text;
                thong_tin_kh[61] = cboxHgd_dai_dien.Text;
                Khachhangvay kh = new Khachhangvay(thong_tin_kh);
                if (kh_vaybus.THEM_KH_VAY(kh))
                {
                    MessageBox.Show("Nhập thông tin khách hàng thành công!");
                    this.Close();
                }
                else MessageBox.Show("Có lỗi xảy ra!");
            }
            //End - Thêm mới khách hàng
            else
            //Start - Sửa thông tin khách hàng
            {
                string[] thong_tin_kh = new string[62];
                thong_tin_kh[0] = txtMa_kh_vay.Text;
                thong_tin_kh[1] = cboxLoai_kh.Text;
                thong_tin_kh[2] = txtma_CN.Text;
                thong_tin_kh[3] = txtHgd_ten_chong.Text;
                if (txtHgd_ns_chong.Text == "  /  /")
                {
                    thong_tin_kh[4] = "";
                }
                else
                {
                    thong_tin_kh[4] = txtHgd_ns_chong.Text;
                }
                thong_tin_kh[5] = txtHgd_cmnd_chong.Text;
                if (txtHgd_ngay_cap_cmnd_chong.Text == "  /  /")
                {
                    thong_tin_kh[6] = "";
                }
                else
                {
                    thong_tin_kh[6] = txtHgd_ngay_cap_cmnd_chong.Text;
                }
                thong_tin_kh[7] = txtHgd_noi_cap_cmnd_chong.Text;
                thong_tin_kh[8] = txtHgd_dc_chong.Text;
                thong_tin_kh[9] = txtHgd_hktt_chong.Text;
                thong_tin_kh[10] = txtHgd_so_hk_chong.Text;
                thong_tin_kh[11] = txtHgd_noi_cap_hk_chong.Text;
                if (txtHgd_ngay_cap_hk_chong.Text == "  /  /")
                {
                    thong_tin_kh[12] = "";
                }
                else
                {
                    thong_tin_kh[12] = txtHgd_ngay_cap_hk_chong.Text;
                }
                thong_tin_kh[13] = txtHgd_ten_vo.Text;
                if (txtHgd_ns_vo.Text == "  /  /")
                {
                    thong_tin_kh[14] = "";
                }
                else
                {
                    thong_tin_kh[14] = txtHgd_ns_vo.Text;
                }
                thong_tin_kh[15] = txtHgd_cmnd_vo.Text;
                if (txtHgd_ngay_cap_cmnd_vo.Text == "  /  /")
                {
                    thong_tin_kh[16] = "";
                }
                else
                {
                    thong_tin_kh[16] = txtHgd_ngay_cap_cmnd_vo.Text;
                }
                thong_tin_kh[17] = txtHgd_noi_cap_cmnd_vo.Text;
                thong_tin_kh[18] = txtHgd_dc_vo.Text;
                thong_tin_kh[19] = txtHgd_hktt_vo.Text;
                thong_tin_kh[20] = txtHgd_so_hk_vo.Text;
                thong_tin_kh[21] = txtHgd_noi_cap_hk_vo.Text;
                if (txtHgd_ngay_cap_hk_vo.Text == "  /  /")
                {
                    thong_tin_kh[22] = "";
                }
                else
                {
                    thong_tin_kh[22] = txtHgd_ngay_cap_hk_vo.Text;
                }
                thong_tin_kh[23] = txtHgd_dkkd.Text;
                thong_tin_kh[24] = txtHgd_dien_thoai.Text;
                thong_tin_kh[25] = txtHgd_fax.Text;
                thong_tin_kh[26] = txtHgd_email.Text;
                thong_tin_kh[27] = cboxCn_danh_xung.Text;
                thong_tin_kh[28] = txtCn_ten.Text;
                if (txtCn_ns.Text == "  /  /")
                {
                    thong_tin_kh[29] = "";
                }
                else
                {
                    thong_tin_kh[29] = txtCn_ns.Text;
                }
                thong_tin_kh[30] = txtCn_cmnd.Text;
                if (txtCn_ngay_cap_cmnd.Text == "  /  /")
                {
                    thong_tin_kh[31] = "";
                }
                else
                {
                    thong_tin_kh[31] = txtCn_ngay_cap_cmnd.Text;
                }
                thong_tin_kh[32] = txtCn_noi_cap_cmnd.Text;
                thong_tin_kh[33] = txtCn_dc.Text;
                thong_tin_kh[34] = txtCn_hktt.Text;
                thong_tin_kh[35] = txtCn_so_hk.Text;
                thong_tin_kh[36] = txtCn_noi_cap_hk.Text;
                if (txtCn_ngay_cap_hk.Text == "  /  /")
                {
                    thong_tin_kh[37] = "";
                }
                else
                {
                    thong_tin_kh[37] = txtCn_ngay_cap_hk.Text;
                }
                thong_tin_kh[38] = txtCn_dkkd.Text;
                thong_tin_kh[39] = txtCn_dien_thoai.Text;
                thong_tin_kh[40] = txtCn_fax.Text;
                thong_tin_kh[41] = txtCn_email.Text;
                thong_tin_kh[42] = txtTc_ten.Text;
                thong_tin_kh[43] = txtTc_dkkd.Text;
                thong_tin_kh[44] = txtTc_dc.Text;
                thong_tin_kh[45] = cboxTc_danh_xung_dai_dien.Text;
                thong_tin_kh[46] = txtTc_dai_dien.Text;
                if (txtTc_ns_dai_dien.Text == "  /  /")
                {
                    thong_tin_kh[47] = "";
                }
                else
                {
                    thong_tin_kh[47] = txtTc_ns_dai_dien.Text;
                }
                thong_tin_kh[48] = txtTc_chuc_vu_dai_dien.Text;
                thong_tin_kh[49] = txtTc_giay_uy_quyen.Text;
                thong_tin_kh[50] = txtTc_dc_dai_dien.Text;
                thong_tin_kh[51] = txtTc_cmnd_dai_dien.Text;
                if (txtTc_ngay_cap_cmnd_dai_dien.Text == "  /  /")
                {
                    thong_tin_kh[52] = "";
                }
                else
                {
                    thong_tin_kh[52] = txtTc_ngay_cap_cmnd_dai_dien.Text;
                }
                thong_tin_kh[53] = txtTc_noi_cap_cmnd_dai_dien.Text;
                thong_tin_kh[54] = txtTc_hktt_dai_dien.Text;
                thong_tin_kh[55] = txtTc_so_hk_dai_dien.Text;
                thong_tin_kh[56] = txtTc_noi_cap_hk_dai_dien.Text;
                if (txtTc_ngay_cap_hk_dai_dien.Text == "  /  /")
                {
                    thong_tin_kh[57] = "";
                }
                else
                {
                    thong_tin_kh[57] = txtTc_ngay_cap_hk_dai_dien.Text;
                }
                thong_tin_kh[58] = txtTc_dien_thoai.Text;
                thong_tin_kh[59] = txtTc_fax.Text;
                thong_tin_kh[60] = txtTc_email.Text;
                thong_tin_kh[61] = cboxHgd_dai_dien.Text;
                Khachhangvay kh = new Khachhangvay(thong_tin_kh);
                if (kh_vaybus.CAP_NHAT_KH_VAY(kh,txtMa_kh_vay.Text))
                {
                    MessageBox.Show("Sửa đổi thông tin khách hàng thành công");
                    this.Close();
                }
                else MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void txtHgd_dc_chong_TextChanged(object sender, EventArgs e)
        {
            txtHgd_hktt_chong.Text = txtHgd_dc_chong.Text;
        }

        private void txtHgd_dc_vo_TextChanged(object sender, EventArgs e)
        {
            txtHgd_hktt_vo.Text = txtHgd_dc_vo.Text;
        }

        private void txtCn_dc_TextChanged(object sender, EventArgs e)
        {
            txtCn_hktt.Text = txtCn_dc.Text;
        }

        private void txtTc_dc_dai_dien_TextChanged(object sender, EventArgs e)
        {
            txtTc_hktt_dai_dien.Text = txtTc_dc_dai_dien.Text;
        }
    }
}
