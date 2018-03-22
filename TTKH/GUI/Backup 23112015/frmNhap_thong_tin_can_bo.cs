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
    public partial class frmNhap_thong_tin_can_bo : Form
    {
        //public string ma_nv;

        private string _ten_dang_nhap="";
        
        CanbotindungBUS cbbus = new CanbotindungBUS();
        public frmNhap_thong_tin_can_bo(string ma_cn, string ten_cn)
        {
            InitializeComponent();
            List<Chinhanh> dschinhanh = new List<Chinhanh>();
            dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = ma_cn;
            cboxChi_nhanh.Text = ten_cn;
            cboxChuc_vu.Text = "Giám đốc";
            cboxChi_nhanh.Enabled = false;
            cboxDanh_xung.Text = "Ông";
        }

        internal void Sua_thong_tin_can_bo(String ten_dang_nhap)
        {
            this._ten_dang_nhap = ten_dang_nhap;
            txtTen_dang_nhap.Text = ten_dang_nhap;
            txtTen_dang_nhap.ReadOnly = true;
            Canbotindung cb = cbbus.CBTD_theo_ten_dang_nhap(ten_dang_nhap);
            txtma_CN.Text = cb.ma_cn;
            Chinhanh cn = AGRIBANKHD.BUS.ChinhanhBUS.CN_theo_ma(cb.ma_cn);
            cboxChi_nhanh.Text = cn.ten_CN;
            cboxChi_nhanh.Enabled = false;
            txtMat_khau.Text = cb.mat_khau;
            txtMat_khau_go_lai.Text = cb.mat_khau;
            txtho_ten.Text = cb.ho_ten;
            cboxDanh_xung.Text = cb.danh_xung;
            cboxChuc_vu.Text = cb.chuc_vu;
            txtGiay_uy_quyen.Text = cb.giay_uy_quyen;
            txtDien_thoai.Text = cb.dien_thoai;
            txtFax.Text = cb.fax;
            
        }

        private void cboxChi_nhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
        }

        private void btnTim_kiem_Click(object sender, EventArgs e)
        {
            List<Thechap> danhsach_tc = AGRIBANKHD.BUS.ThechapBUS.Danhsach_TC("", "", "");
            //dgvTSTC.DataSource = danhsach_tc;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_ten_dang_nhap))
            {
                string[] name_of_textbox = { "txtma_CN", "txtTen_dang_nhap" };
                CommonMethods.ClearTextBoxes(this, name_of_textbox);
            }
            else
            {
                string[] name_of_textbox = { "txtma_CN" };
                CommonMethods.ClearTextBoxes(this, name_of_textbox);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_ten_dang_nhap))
            {
                if (cbbus.Kiem_tra_trung_ten_dang_nhap(txtTen_dang_nhap.Text))
                {               
                    MessageBox.Show("Tên đăng nhập đã tồn tại trong hệ thống. Đề nghị kiểm tra lại thông tin!");
                    txtTen_dang_nhap.Focus();
                    return;
                }

                if (txtMat_khau.Text != txtMat_khau_go_lai.Text)
                {
                    MessageBox.Show("Mật khẩu nhập tại ô 'Mật khẩu' và 'Gõ lại mật khẩu' không trùng nhau. Đề nghị kiểm tra lại!");
                    txtMat_khau.Focus();
                    return;
                }                   
                string[] thong_tin_cb = new string[10];
                thong_tin_cb[0] = txtma_CN.Text;
                thong_tin_cb[1] = txtTen_dang_nhap.Text;
                thong_tin_cb[2] = txtho_ten.Text;
                thong_tin_cb[3] = cboxChuc_vu.Text;
                thong_tin_cb[4] = txtGiay_uy_quyen.Text;
                thong_tin_cb[5] = txtDien_thoai.Text ;
                thong_tin_cb[6] = txtFax.Text;
                thong_tin_cb[7] = txtMat_khau.Text;
                thong_tin_cb[9] = cboxDanh_xung.Text;
                Canbotindung cb = new Canbotindung(thong_tin_cb);
                if (cbbus.Them_CBTD(cb))
                {
                    MessageBox.Show("Nhập thông tin cán bộ tín dụng thành công!");
                    this.Close();
                }
                else MessageBox.Show("Có lỗi xảy ra!");                
            }
            else
            {
                if (txtMat_khau.Text != txtMat_khau_go_lai.Text)
                {
                    MessageBox.Show("Mật khẩu nhập tại ô 'Mật khẩu' và 'Gõ lại mật khẩu' không trùng nhau. Đề nghị kiểm tra lại!");
                    txtMat_khau.Focus();
                    return;
                }
                string[] thong_tin_cb = new string[10];
                thong_tin_cb[0] = txtma_CN.Text;
                thong_tin_cb[1] = txtTen_dang_nhap.Text;
                thong_tin_cb[2] = txtho_ten.Text;
                thong_tin_cb[3] = cboxChuc_vu.Text;
                thong_tin_cb[4] = txtGiay_uy_quyen.Text;
                thong_tin_cb[5] = txtDien_thoai.Text;
                thong_tin_cb[6] = txtFax.Text;
                thong_tin_cb[7] = txtMat_khau.Text;
                thong_tin_cb[9] = cboxDanh_xung.Text;
                Canbotindung cb = new Canbotindung(thong_tin_cb);
                if (cbbus.Capnhat_CBTD(cb,txtTen_dang_nhap.Text))
                {
                    MessageBox.Show("Sửa đổi thông tin cán bộ thành công!");
                    this.Close();
                }
                else MessageBox.Show("Có lỗi xảy ra!");
            }
        }

    }
}
