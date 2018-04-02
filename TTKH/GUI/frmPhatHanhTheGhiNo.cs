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
        private List<TextBox> listTxtNotNull;

        public frmPhatHanhTheGhiNo()
        {
            InitializeComponent();
        }

        void MyInit() {
            listTxtNotNull = new List<TextBox>();
            //listTxtNotNull.Add(txt)
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCMT.Text))
                MessageBox.Show("Vui lòng nhập số CMND", "Thông báo", MessageBoxButtons.OK);
            else
            {
                Entities.KhachHangDV kh = null;
                try
                {
                    kh = DAL.PhatHanhTheGhiNoDAL.TimKiemKH(txtCMT.Text);
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
            tCtrDichVu.Enabled = false;
            ClearAllTextBox();
        }

        void TimThayKH(Entities.KhachHangDV kh) {
            SetTextBoxStatus_TTKH(false);
            tCtrDichVu.Enabled = true;
            txtNgayCap.Text = kh.ngay_cap.ToString("MM/dd/yyyy");
            txtNoiCap.Text = kh.noi_cap;
            txtMaKH.Text = kh.ma_KH;
            txtHoTen.Text = kh.ho_ten;
            txtNgaySinh.Text = kh.ngay_sinh.ToString("MM/dd/yyyy");
            txtSoDienThoai.Text = kh.dien_thoai;
            txtEmail.Text = kh.email;
            txtDiaChi.Text = kh.dia_chi;
            if (kh.gioi_tinh)
            {
                cbGioiTinh.SelectedIndex = 0;
            }
            else {
                cbGioiTinh.SelectedIndex = 1;
            }

            //Lay cac so TK cua KH
            try
            {
                DataTable dt = DAL.PhatHanhTheGhiNoDAL.TimSoTK(kh.cmt);

                for (int i = 0; i < dt.Rows.Count; i++) {
                    cbSoTK.Items.Add(dt.Rows[i]["SOTK"]);
                }
                if (cbSoTK.Items.Count > 0)
                    cbSoTK.SelectedIndex = 0;
                if (cbSoTK.Items.Count > 1)
                    cbSoTK.Enabled = true;
            }
            catch {
                DAL.ErrorMessageDAL.DataAccessError();
            }

        }

        void SetTextBoxStatus_TTKH(bool status) {
            txtNgayCap.Enabled = status;
            txtNoiCap.Enabled = status;
            txtMaKH.Enabled = status;
            txtHoTen.Enabled = status;
            txtQuocTich.Enabled = status;
            cbSoTK.Enabled = status;
            txtNgaySinh.Enabled = status;
            txtEmail.Enabled = status;
            txtDiaChi.Enabled = status;
            cbGioiTinh.Enabled = status;
            txtSoDienThoai.Enabled = status;
        }

        void ClearAllTextBox() {
            txtNgayCap.Text = "";
            txtNoiCap.Text = "";
            txtMaKH.Text="";
            txtHoTen.Text = "";
            txtQuocTich.Text = "";
            cbSoTK.SelectedItem = null;
            txtNgaySinh.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            cbGioiTinh.SelectedItem = null;
            txtSoDienThoai.Text = "";
        }

        //Menu Thong tin khach hang
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

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSoTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbSoTK_KeyPress(object sender, KeyPressEventArgs e)
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

       
        //Menu tab Phat hanh moi the ghi no
        private void clbND_Moi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbND_Moi.Items.Count; ++ix)
                if (ix != e.Index) clbND_Moi.SetItemChecked(ix, false);
        }

        private void clbQT_Moi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbQT_Moi.Items.Count; ++ix)
                if (ix != e.Index) clbQT_Moi.SetItemChecked(ix, false);
        }

        private void clbHangThe_Moi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbHangThe_Moi.Items.Count; ++ix)
                if (ix != e.Index) clbHangThe_Moi.SetItemChecked(ix, false);
        }

        private void clbHTPhatHanh_Moi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbHTPhatHanh_Moi.Items.Count; ++ix)
                if (ix != e.Index) clbHTPhatHanh_Moi.SetItemChecked(ix, false);
        }

        private void clbHTNhanThe_Moi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbHTNhanThe_Moi.Items.Count; ++ix)
                if (ix != e.Index) clbHTNhanThe_Moi.SetItemChecked(ix, false);
        }

        private void ckbSMS_Moi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSMS_Moi.Checked) txtDTDD_SMS_Moi.Enabled = true;
            else txtDTDD_SMS_Moi.Enabled = false;
        }

        private void ckbInternet_Moi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbInternet_Moi.Checked) txtHMGD_Moi.Enabled = true;
            else txtHMGD_Moi.Enabled = false;
        }

        //Menu tab phat hanh lai the ghi no
        private void clbND_Lai_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbND_Lai.Items.Count; ++ix)
                if (ix != e.Index) clbND_Lai.SetItemChecked(ix, false);
        }

        private void clbQT_Lai_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbQT_Lai.Items.Count; ++ix)
                if (ix != e.Index) clbQT_Lai.SetItemChecked(ix, false);
        }

        private void clbHangThe_Lai_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbHangThe_Lai.Items.Count; ++ix)
                if (ix != e.Index) clbHangThe_Lai.SetItemChecked(ix, false);
        }

        private void clbHTPhatHanh_Lai_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbHTPhatHanh_Lai.Items.Count; ++ix)
                if (ix != e.Index) clbHTPhatHanh_Lai.SetItemChecked(ix, false);
        }

        private void ckbSMS_Lai_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSMS_Lai.Checked) txtDTDD_SMS_Lai.Enabled = true;
            else txtDTDD_SMS_Lai.Enabled = false;
        }

        private void ckbInternet_Lai_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbInternet_Lai.Checked) txtHMGD_Lai.Enabled = true;
            else txtHMGD_Lai.Enabled = false;
        }

        private void btnLuuHoSo_Click(object sender, EventArgs e)
        {
            //Phat hanh moi the ghi no
            switch (tCtrDichVu.SelectedIndex) { 
                case 0: //Phat hanh moi 

                    break;
                case 1: //Phat hanh lai
                    break;
                case 2: //Hop dong
                    break;
                case 3: //Giay hen
                    break;
                default: break;
            }
        }

        

       

        

        

        

        


        
    }
}
