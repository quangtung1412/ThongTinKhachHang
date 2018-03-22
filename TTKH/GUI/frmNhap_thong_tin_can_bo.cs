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
            cboxChi_nhanh.Enabled = false;

            List<Phonggiaodich> dsphonggiaodich = new List<Phonggiaodich>();
            dsphonggiaodich = PhonggiaodichBUS.DS_PGD(ma_cn);
            cboxPhonggiaodich.DataSource = dsphonggiaodich;
            cboxPhonggiaodich.DisplayMember = "TEN_PGD";
            cboxPhonggiaodich.ValueMember = "MA_PGD";
            cboxPhonggiaodich.Text = dsphonggiaodich[0].ten_pgd;

            List<Phongban> dsphongban = new List<Phongban>();
            dsphongban = PhongbanBUS.DS_PB(ma_cn);
            cboxPhongban.DataSource = dsphongban;
            cboxPhongban.DisplayMember = "TEN_PB";
            cboxPhongban.ValueMember = "MA_PB";
            cboxPhongban.Text = dsphongban[0].ten_pb;

            cboxChuc_vu.Items.Clear();
            if (cboxPhongban.Text == "Ban Giám đốc")
            {
                cboxChuc_vu.Items.Add("Giám đốc");
                cboxChuc_vu.Items.Add("Phó Giám đốc");
                cboxChuc_vu.Text = "Giám đốc";
            }
            else if (cboxPhongban.Text == "Khách hàng Doanh nghiệp")
            {
                cboxChuc_vu.Items.Add("Trưởng phòng Khách hàng Doanh nghiệp");
                cboxChuc_vu.Items.Add("Phó phòng Khách hàng Doanh nghiệp");
                cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
                cboxChuc_vu.Text = "Trưởng phòng Khách hàng Doanh nghiệp";
            }
            else if (cboxPhongban.Text == "Khách hàng Hộ sản xuất và Cá nhân")
            {
                cboxChuc_vu.Items.Add("Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân");
                cboxChuc_vu.Items.Add("Phó phòng Khách hàng Hộ sản xuất và Cá nhân");
                cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
                cboxChuc_vu.Text = "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân";
            }
            else if (cboxPhongban.Text == "Kế hoạch & Kinh doanh")
            {
                if (cboxPhonggiaodich.Text == "Hội sở")
                {
                    cboxChuc_vu.Items.Add("Trưởng phòng Kế hoạch & Kinh doanh");
                    cboxChuc_vu.Items.Add("Phó phòng Kế hoạch & Kinh doanh");
                    cboxChuc_vu.Items.Add("Giám đốc phòng giao dịch");
                    cboxChuc_vu.Items.Add("Phó Giám đốc phòng giao dịch");
                    cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
                    cboxChuc_vu.Text = "Trưởng phòng Kế hoạch & Kinh doanh";
                }
                else
                {
                    cboxChuc_vu.Items.Add("Giám đốc phòng giao dịch");
                    cboxChuc_vu.Items.Add("Phó Giám đốc phòng giao dịch");
                    cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
                    cboxChuc_vu.Text = "Giám đốc phòng giao dịch";
                }
            }
            else
            {
                cboxChuc_vu.Items.Add("Nhân viên");
                cboxChuc_vu.Text = "Nhân viên";
            }
            cboxChuc_vu.ResetText();
            
            cboxDanh_xung.Text = "Ông";
            chboxKich_hoat.Checked = true;
        }

        public frmNhap_thong_tin_can_bo(string ma_cn, string ten_cn, string ten_dang_nhap)
        {
            InitializeComponent();
            this._ten_dang_nhap = ten_dang_nhap;

            txtTen_dang_nhap.Text = ten_dang_nhap;
            txtTen_dang_nhap.ReadOnly = true;
            Canbotindung cb = cbbus.CBTD_theo_ten_dang_nhap(ten_dang_nhap);

            List<Chinhanh> dschinhanh = new List<Chinhanh>();
            dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = ma_cn;
            cboxChi_nhanh.Text = ten_cn;
            cboxChi_nhanh.Enabled = false;

            List<Phonggiaodich> dsphonggiaodich = new List<Phonggiaodich>();
            dsphonggiaodich = PhonggiaodichBUS.DS_PGD(ma_cn);
            cboxPhonggiaodich.DataSource = dsphonggiaodich;
            cboxPhonggiaodich.DisplayMember = "TEN_PGD";
            cboxPhonggiaodich.ValueMember = "MA_PGD";
            Phonggiaodich pgd = PhonggiaodichBUS.PGD_THEO_MA(cb.ma_pgd);
            cboxPhonggiaodich.Text = pgd.ten_pgd;

            List<Phongban> dsphongban = new List<Phongban>();
            dsphongban = PhongbanBUS.DS_PB(ma_cn);
            cboxPhongban.DataSource = dsphongban;
            cboxPhongban.DisplayMember = "TEN_PB";
            cboxPhongban.ValueMember = "MA_PB";
            Phongban pb = PhongbanBUS.PB_THEO_MA(cb.ma_pb);
            cboxPhongban.Text = pb.ten_pb;

            txtMat_khau.Text = cb.mat_khau;
            txtMat_khau_go_lai.Text = cb.mat_khau;
            txtho_ten.Text = cb.ho_ten;
            cboxDanh_xung.Text = cb.danh_xung;

            cboxChuc_vu.Items.Clear();
            if (cboxPhongban.Text == "Ban Giám đốc")
            {
                cboxChuc_vu.Items.Add("Giám đốc");
                cboxChuc_vu.Items.Add("Phó Giám đốc");
            }
            else if (cboxPhongban.Text == "Khách hàng Doanh nghiệp")
            {
                cboxChuc_vu.Items.Add("Trưởng phòng Khách hàng Doanh nghiệp");
                cboxChuc_vu.Items.Add("Phó phòng Khách hàng Doanh nghiệp");
                cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
            }
            else if (cboxPhongban.Text == "Khách hàng Hộ sản xuất và Cá nhân")
            {
                cboxChuc_vu.Items.Add("Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân");
                cboxChuc_vu.Items.Add("Phó phòng Khách hàng Hộ sản xuất và Cá nhân");
                cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
            }
            else if (cboxPhongban.Text == "Kế hoạch & Kinh doanh")
            {
                if (cboxPhonggiaodich.Text == "Hội sở")
                {
                    cboxChuc_vu.Items.Add("Trưởng phòng Kế hoạch & Kinh doanh");
                    cboxChuc_vu.Items.Add("Phó phòng Kế hoạch & Kinh doanh");
                    cboxChuc_vu.Items.Add("Giám đốc phòng giao dịch");
                    cboxChuc_vu.Items.Add("Phó Giám đốc phòng giao dịch");
                    cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
                }
                else
                {
                    cboxChuc_vu.Items.Add("Giám đốc phòng giao dịch");
                    cboxChuc_vu.Items.Add("Phó Giám đốc phòng giao dịch");
                    cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
                }
            }
            else
            {
                cboxChuc_vu.Items.Add("Nhân viên");
            }
            cboxChuc_vu.ResetText();

            cboxChuc_vu.Text = cb.chuc_vu;
            txtGiay_uy_quyen.Text = cb.giay_uy_quyen;
            txtDien_thoai.Text = cb.dien_thoai;
            txtFax.Text = cb.fax;
            if (cb.kich_hoat)
            {
                chboxKich_hoat.Checked = true;
            }
            else
            {
                chboxKich_hoat.Checked = false;
            }
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

            Phonggiaodich pgd = PhonggiaodichBUS.PGD_THEO_MA(cb.ma_pgd);
            cboxPhonggiaodich.Text = pgd.ten_pgd;

            Phongban pb = PhongbanBUS.PB_THEO_MA(cb.ma_pb);
            cboxPhongban.Text = pb.ten_pb;

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
            if (string.IsNullOrEmpty(txtTen_dang_nhap.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập!");
                txtTen_dang_nhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtho_ten.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên cán bộ!");
                txtho_ten.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMat_khau.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu!");
                txtMat_khau.Focus();
                return;
            }
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
                    txtMat_khau_go_lai.Focus();
                    return;
                }                   
                string[] thong_tin_cb = new string[13];
                thong_tin_cb[0] = txtma_CN.Text;
                thong_tin_cb[1] = cboxPhonggiaodich.SelectedValue.ToString();
                thong_tin_cb[2] = txtTen_dang_nhap.Text;
                thong_tin_cb[3] = txtho_ten.Text;
                thong_tin_cb[4] = cboxChuc_vu.Text;
                thong_tin_cb[5] = txtGiay_uy_quyen.Text;
                thong_tin_cb[6] = txtDien_thoai.Text ;
                thong_tin_cb[7] = txtFax.Text;
                thong_tin_cb[8] = txtMat_khau.Text;
                thong_tin_cb[10] = cboxDanh_xung.Text;
                thong_tin_cb[11] = cboxPhongban.SelectedValue.ToString();
                if (chboxKich_hoat.Checked)
                {
                    thong_tin_cb[12] = "True";
                }
                else
                {
                    thong_tin_cb[12] = "False";
                }
                Canbotindung cb = new Canbotindung(thong_tin_cb);
                if (cbbus.Them_CBTD(cb))
                {
                    MessageBox.Show("Nhập thông tin cán bộ tín dụng thành công!");
                    //frmThong_tin_can_bo frm = new frmThong_tin_can_bo();
                    //frm.MdiParent = this.MdiParent;
                    this.Close();
                    //frm.Tim_kiem_can_bo();
                    //frm.Show();
                    //frm.BringToFront();
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
                string[] thong_tin_cb = new string[13];
                thong_tin_cb[0] = txtma_CN.Text;
                thong_tin_cb[1] = cboxPhonggiaodich.SelectedValue.ToString();
                thong_tin_cb[2] = txtTen_dang_nhap.Text;
                thong_tin_cb[3] = txtho_ten.Text;
                thong_tin_cb[4] = cboxChuc_vu.Text;
                thong_tin_cb[5] = txtGiay_uy_quyen.Text;
                thong_tin_cb[6] = txtDien_thoai.Text;
                thong_tin_cb[7] = txtFax.Text;
                thong_tin_cb[8] = txtMat_khau.Text;
                thong_tin_cb[10] = cboxDanh_xung.Text;
                thong_tin_cb[11] = cboxPhongban.SelectedValue.ToString();
                if (chboxKich_hoat.Checked)
                {
                    thong_tin_cb[12] = "True";
                }
                else
                {
                    thong_tin_cb[12] = "False";
                }
                Canbotindung cb = new Canbotindung(thong_tin_cb);
                if (cbbus.Capnhat_CBTD(cb,txtTen_dang_nhap.Text))
                {
                    MessageBox.Show("Sửa đổi thông tin cán bộ thành công!");                    
                    //frmThong_tin_can_bo frm = new frmThong_tin_can_bo();
                    //frm.MdiParent = this.MdiParent;
                    this.Close();
                    //frm.Tim_kiem_can_bo();
                    //frm.Show();
                    //frm.BringToFront();
                }
                else MessageBox.Show("Có lỗi xảy ra!");
                
            }
        }

        private void cboxPhongban_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxChuc_vu.Items.Clear();
            if (cboxPhongban.Text == "Ban Giám đốc")
            {                
                cboxChuc_vu.Items.Add("Giám đốc");
                cboxChuc_vu.Items.Add("Phó Giám đốc");                
                cboxChuc_vu.Text = "Giám đốc";
            }
            else if (cboxPhongban.Text == "Khách hàng Doanh nghiệp")
            {
                cboxChuc_vu.Items.Add("Trưởng phòng Khách hàng Doanh nghiệp");
                cboxChuc_vu.Items.Add("Phó phòng Khách hàng Doanh nghiệp");
                cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
                cboxChuc_vu.Text = "Trưởng phòng Khách hàng Doanh nghiệp";
            }
            else if (cboxPhongban.Text == "Khách hàng Hộ sản xuất và Cá nhân")
            {
                cboxChuc_vu.Items.Add("Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân");
                cboxChuc_vu.Items.Add("Phó phòng Khách hàng Hộ sản xuất và Cá nhân");
                cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
                cboxChuc_vu.Text = "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân";
            }
            else if (cboxPhongban.Text == "Kế hoạch & Kinh doanh")
            {
                if (cboxPhonggiaodich.Text == "Hội sở")
                {
                    cboxChuc_vu.Items.Add("Trưởng phòng Kế hoạch & Kinh doanh");
                    cboxChuc_vu.Items.Add("Phó phòng Kế hoạch & Kinh doanh");
                    //cboxChuc_vu.Items.Add("Giám đốc phòng giao dịch");
                    //cboxChuc_vu.Items.Add("Phó Giám đốc phòng giao dịch");
                    cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
                    cboxChuc_vu.Text = "Trưởng phòng Kế hoạch & Kinh doanh";
                }
                else
                {
                    cboxChuc_vu.Items.Add("Giám đốc phòng giao dịch");
                    cboxChuc_vu.Items.Add("Phó Giám đốc phòng giao dịch");
                    cboxChuc_vu.Items.Add("Cán bộ thẩm định và QLKV");
                    cboxChuc_vu.Text = "Giám đốc phòng giao dịch";
                }
            }
            cboxChuc_vu.ResetText();
        }

        private void cboxPhonggiaodich_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboxPhongban.Items.Clear();
            if (cboxPhonggiaodich.Text != "Hội sở")
            {
                List<Phongban> dsphongban = new List<Phongban>();
                dsphongban = PhongbanBUS.DS_PB(txtma_CN.Text);
                Phongban bgd = dsphongban.Find(item => item.ten_pb == "Ban Giám đốc");
                dsphongban.Remove(bgd);
                cboxPhongban.DataSource = dsphongban;
                cboxPhongban.DisplayMember = "TEN_PB";
                cboxPhongban.ValueMember = "MA_PB";                
                cboxPhongban.Text = dsphongban[0].ten_pb;
            }
            else
            {
                List<Phongban> dsphongban = new List<Phongban>();
                dsphongban = PhongbanBUS.DS_PB(txtma_CN.Text);
                cboxPhongban.DataSource = dsphongban;
                cboxPhongban.DisplayMember = "TEN_PB";
                cboxPhongban.ValueMember = "MA_PB";
                cboxPhongban.Text = dsphongban[0].ten_pb;
            }
            cboxPhongban.ResetText();
        }
    }
}
