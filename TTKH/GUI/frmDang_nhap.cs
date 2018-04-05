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
        //CanbotindungBUS cbbus = new CanbotindungBUS();
        UserBUS userBus = new UserBUS();
        public frmDang_nhap()
        {
            InitializeComponent();
            //List<Chinhanh> dschinhanh = new List<Chinhanh>();
            //dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            this.AcceptButton = btnDang_nhap;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDang_nhap_Click(object sender, EventArgs e)
        {
            string uid = this.txtTen_dang_nhap.Text.Trim();
            string pass = this.txtMat_khau.Text.Trim();
            //string pass_mahoa = mahoa.mahoa(pass);
            //string group_list = "";

            if (uid == "")
            {
                MessageBox.Show("Chưa nhập tên đăng nhập.");
                txtTen_dang_nhap.Focus();
                return;
            }
            else if (pass == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu.");
                txtMat_khau.Focus();
                return;
            }

            DataTable userDt = userBus.XAC_THUC_USER(uid, pass);

            if (userDt.Rows.Count <= 0)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu. Đề nghị kiểm tra lại!");
                return;
            }
            else
            {
                Chinhanh cn = ChinhanhBUS.CN_theo_ma(userDt.Rows[0]["MACN"].ToString());
                Thong_tin_dang_nhap.ten_dang_nhap = uid;
                Thong_tin_dang_nhap.mat_khau = pass;
                Thong_tin_dang_nhap.ma_cn = cn.ma_CN;
                Thong_tin_dang_nhap.ten_cn = cn.ten_CN;
                Thong_tin_dang_nhap.mst_cn = cn.mst;
                Thong_tin_dang_nhap.dia_chi_cn = cn.dia_chi;
                Thong_tin_dang_nhap.ten_cn_day_du = cn.ten_cn_day_du;
                Thong_tin_dang_nhap.ho_ten = userDt.Rows[0]["TENNV"].ToString();
                Thong_tin_dang_nhap.chuc_vu = userDt.Rows[0]["CHUCVU"].ToString();
                Thong_tin_dang_nhap.ma_pb = userDt.Rows[0]["MAPB"].ToString();
                this.DialogResult = DialogResult.OK;
                this.Dispose();           
            }
        }

    }
}
