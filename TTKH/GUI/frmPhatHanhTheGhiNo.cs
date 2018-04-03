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

        private List<string>
            ttchung_nguon,
            ttchung_dich,
            phat_hanh_moi_nguon,
            phat_hanh_moi_dich,
            phat_hanh_lai_nguon,
            phat_hanh_lai_dich,
            hop_dong_nguon,
            hop_dong_dich,
            giay_hen_nguon,
            giay_hen_dich;

        public frmPhatHanhTheGhiNo()
        {
            InitializeComponent();
            ttchung_dich = new List<string>();
            ttchung_nguon = new List<string>();
            phat_hanh_moi_dich = new List<string>();
            phat_hanh_moi_nguon = new List<string>();
            phat_hanh_lai_dich = new List<string>();
            phat_hanh_lai_nguon = new List<string>();
            hop_dong_dich = new List<string>();
            hop_dong_nguon = new List<string>();
            giay_hen_dich = new List<string>();
            giay_hen_nguon = new List<string>();
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

        private void KhoiTaoTTChung() {
            ttchung_nguon.Add(txtCMT.Text);
            ttchung_nguon.Add(txtHoTen.Text);
            ttchung_nguon.Add(txtMaKH.Text);
            ttchung_nguon.Add(txtEmail.Text);
            ttchung_nguon.Add(txtDiaChi.Text);
            ttchung_nguon.Add(txtNgaySinh.Text);
            ttchung_nguon.Add(txtNgayCap.Text);
            ttchung_nguon.Add(txtNoiCap.Text);
            ttchung_nguon.Add(txtQuocTich.Text);
            ttchung_nguon.Add(cbSoTK.SelectedText);

            ttchung_dich.Add("<CMND>");
            ttchung_dich.Add("<HO_TEN>");
            ttchung_dich.Add("<MA_KH>");
            ttchung_dich.Add("<EMAIL>");
            ttchung_dich.Add("<DIA_CHI>");
            ttchung_dich.Add("<NGAY_SINH>");
            ttchung_dich.Add("<NGAY_CAP>");
            ttchung_dich.Add("<NOI_CAP>");
            ttchung_dich.Add("<QUOC_TICH>");
            ttchung_dich.Add("SO_TK");

            if (cbGioiTinh.SelectedIndex == 0) { //gioi tinh NAM
                ttchung_nguon.Add("0x2611");
                ttchung_dich.Add("<GT_0>");
                ttchung_nguon.Add("0x2610");
                ttchung_dich.Add("<GT_1>");
            }
            else if (cbGioiTinh.SelectedIndex == 1) { //gioi tinh NU
                ttchung_nguon.Add("0x2611");
                ttchung_dich.Add("<GT_1>");
                ttchung_nguon.Add("0x2610");
                ttchung_dich.Add("<GT_0>");
            }
        }

        private void KhoiTaoPhatHanhMoi() {
            phat_hanh_moi_dich.Add("<GN>"); //Ghi no noi dia
            phat_hanh_moi_dich.Add("<LN>"); //Lap nghiep
            phat_hanh_moi_dich.Add("<LKTH>"); //Lien ket thuong hieu
            phat_hanh_moi_dich.Add("<VS>"); //Visa
            phat_hanh_moi_dich.Add("<MC>"); //MasterCard
            phat_hanh_moi_dich.Add("<C>"); //Chuan
            phat_hanh_moi_dich.Add("<V>"); //Vang
            phat_hanh_moi_dich.Add("<PHT>"); //Phat hanh thuong
            phat_hanh_moi_dich.Add("<PHN>"); //Phat hanh nhanh
            phat_hanh_moi_dich.Add("<TNH>"); //Tai ngan hang
            phat_hanh_moi_dich.Add("<TNR>"); //Tai nha rieng
            phat_hanh_moi_dich.Add("<SMS>"); //SMS
            phat_hanh_moi_dich.Add("<SMS_DTDD>");
            phat_hanh_moi_dich.Add("INTERNET");
            phat_hanh_moi_dich.Add("HMGD"); //Han muc giao dich
            phat_hanh_moi_dich.Add("<HMGD_BANG_CHU>");
            phat_hanh_moi_dich.Add("<OTP_DTDD>");
            phat_hanh_moi_dich.Add("<OTP_EMAIL>");

            //Noi dia
            if (clbND_Moi.SelectedIndex == 2) {
                phat_hanh_moi_nguon.Add("0x2610");
                phat_hanh_moi_nguon.Add("0x2610");
                phat_hanh_moi_nguon.Add("0x2611");
            }
            else if (clbND_Moi.SelectedIndex == 1)
            {
                phat_hanh_moi_nguon.Add("0x2610");
                phat_hanh_moi_nguon.Add("0x2611");
                phat_hanh_moi_nguon.Add("0x2610");
            }
            else
            {
                phat_hanh_moi_nguon.Add("0x2611");
                phat_hanh_moi_nguon.Add("0x2610");
                phat_hanh_moi_nguon.Add("0x2610");
            }
            
            //Quoc te
            if (clbQT_Moi.SelectedIndex == 1)
            {
                phat_hanh_moi_nguon.Add("0x2610");
                phat_hanh_moi_nguon.Add("0x2611");
            }
            else {
                phat_hanh_moi_nguon.Add("0x2611");
                phat_hanh_moi_nguon.Add("0x2610");
            }

            //Hang the
            if (clbHangThe_Moi.SelectedIndex == 1)
            {
                phat_hanh_moi_nguon.Add("0x2610");
                phat_hanh_moi_nguon.Add("0x2611");
            }
            else
            {
                phat_hanh_moi_nguon.Add("0x2611");
                phat_hanh_moi_nguon.Add("0x2610");
            }

            //Hinh thuc phat hanh
            if (clbHTPhatHanh_Moi.SelectedIndex == 1)
            {
                phat_hanh_moi_nguon.Add("0x2610");
                phat_hanh_moi_nguon.Add("0x2611");
            }
            else
            {
                phat_hanh_moi_nguon.Add("0x2611");
                phat_hanh_moi_nguon.Add("0x2610");
            }

            //Hinh thuc nhan the
            if (clbHTNhanThe_Moi.SelectedIndex == 1)
            {
                phat_hanh_moi_nguon.Add("0x2610");
                phat_hanh_moi_nguon.Add("0x2611");
            }
            else
            {
                phat_hanh_moi_nguon.Add("0x2611");
                phat_hanh_moi_nguon.Add("0x2610");
            }

            //SMS
        }
    }
}
