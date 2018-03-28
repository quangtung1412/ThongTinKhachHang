using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AGRIBANKHD.GUI
{
    public partial class frmPhatHanhTheGhiNo : Form
    {
        public frmPhatHanhTheGhiNo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmPhatHanhTheGhiNo_Load(object sender, EventArgs e)
        {

        }

        private void gbThongTinKH_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbNgayCap_Click(object sender, EventArgs e)
        {

        }

        private void lbSoDienThoai_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSoCMT.Text))
                MessageBox.Show("Vui lòng nhập số CMND", "Thông báo", MessageBoxButtons.OK);
            else
            {
                Entities.KhachHangDV kh = null;
                try
                {
                    kh = DAL.PhatHanhTheGhiNoDAL.TimKiemKH(txbSoCMT.Text);
                    if (kh == null)
                    {
                        KhongTimThayKH();
                    }
                    else
                    {
                        TimThayKH(kh);
                    }
                }
                catch
                {
                    DAL.ErrorMessageDAL.DataAccessError();
                }
            }
        }


        void KhongTimThayKH() {
            MessageBox.Show(@"Không tìm thấy khách hàng!\n Hãy nhập thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK);
            SetTextBoxStatus_TTKH(true);
            ClearAllTextBox();
        }

        void TimThayKH(Entities.KhachHangDV kh) {
            SetTextBoxStatus_TTKH(false);
            txbNgayCap.Text = kh.ngay_cap.ToString("MM/dd/yyyy");
            txbNoiCap.Text = kh.noi_cap;
            txbMaKH.Text = kh.ma_KH;
            txbHoTen.Text = kh.ho_ten;
            txbNgaySinh.Text = kh.ngay_sinh.ToString("MM/dd/yyyy");
            txbSoDienThoai.Text = kh.dien_thoai;
            txbEmail.Text = kh.email;
            txbDiaChi.Text = kh.dia_chi;
            if (kh.gioi_tinh)
            {
                cbGioiTinh.SelectedIndex = 0;
            }
            else {
                cbGioiTinh.SelectedIndex = 1;
            }
        }

        void SetTextBoxStatus_TTKH(bool status) {
            txbNgayCap.Enabled = status;
            txbNoiCap.Enabled = status;
            txbMaKH.Enabled = status;
            txbHoTen.Enabled = status;
            txbQuocTich.Enabled = status;
            txbSoTaiKhoan.Enabled = status;
            txbNgaySinh.Enabled = status;
            txbEmail.Enabled = status;
            txbDiaChi.Enabled = status;
            cbGioiTinh.Enabled = status;
            txbSoDienThoai.Enabled = status;
        }

        void ClearAllTextBox() {
            txbNgayCap.Text = "";
            txbNoiCap.Text = "";
            txbMaKH.Text="";
            txbHoTen.Text = "";
            txbQuocTich.Text = "";
            txbSoTaiKhoan.Text ="";
            txbNgaySinh.Text = "";
            txbEmail.Text = "";
            txbDiaChi.Text = "";
            cbGioiTinh.SelectedItem = null;
            txbSoDienThoai.Text = "";
        }

        private void txbSoCMT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbSoCMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void ckbLapNghiep1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
