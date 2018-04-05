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
    public partial class frmDang_nhap : Form
    {
        CanbotindungBUS cbbus = new CanbotindungBUS();
        public frmDang_nhap()
        {
            InitializeComponent();
            List<Chinhanh> dschinhanh = new List<Chinhanh>();
            dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            this.AcceptButton = btnDang_nhap;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDang_nhap_Click(object sender, EventArgs e)
        {
            if (!cbbus.Xac_thuc_dang_nhap(txtTen_dang_nhap.Text, txtMat_khau.Text))
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu. Đề nghị kiểm tra lại!");
                return;
            }
            else
            {
                Canbotindung cb = cbbus.CBTD_theo_ten_dang_nhap(txtTen_dang_nhap.Text);
                Thong_tin_dang_nhap.ma_cn = cb.ma_cn;
                Chinhanh cn = ChinhanhBUS.CN_theo_ma(cb.ma_cn);
                Thong_tin_dang_nhap.ten_cn = cn.ten_CN;
                Thong_tin_dang_nhap.ten_cn_day_du = cn.ten_cn_day_du;
                Thong_tin_dang_nhap.dia_chi_cn = cn.dia_chi;
                Thong_tin_dang_nhap.mst_cn = cn.mst;
                Thong_tin_dang_nhap.ho_ten = cb.ho_ten;
                Thong_tin_dang_nhap.chuc_vu = cb.chuc_vu;
                Thong_tin_dang_nhap.ten_dang_nhap = cb.ten_dang_nhap;
                Thong_tin_dang_nhap.mat_khau = cb.mat_khau;
                Thong_tin_dang_nhap.admin = cb.admin;
                Thong_tin_dang_nhap.ma_pb = cb.ma_pb;
                this.DialogResult = DialogResult.OK;
                this.Dispose();           
            }
        }

    }
}
