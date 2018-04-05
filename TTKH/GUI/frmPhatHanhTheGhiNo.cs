using AGRIBANKHD.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AGRIBANKHD.GUI
{
    public partial class frmPhatHanhTheGhiNo : Form
    {
        private List<TextBox> listTxtNotNull;
        private bool canSaveTTKH = false;

        private const string fileNamePhatHanhMoi = "PHAT_HANH_MOI";
        private const string fileNamePhatHanhLai = "PHAT_HANH_LAI";
        private const string fileNameHopDong = "HOP_DONG";
        private const string fileNameGiayHen = "GIAY_HEN";


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

            clbND_Moi.SetItemChecked(0, true);
            clbQT_Moi.SetItemChecked(0, true);
            clbHangThe_Moi.SetItemChecked(0, true);
            clbHTPhatHanh_Moi.SetItemChecked(0, true);
            clbHTNhanThe_Moi.SetItemChecked(0, true);

            clbND_Moi.BackColor = Color.Empty;
        }

        void MyInit() {
            listTxtNotNull = new List<TextBox>();
            //listTxtNotNull.Add(txt)
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemKH();
        }

        private void txtCMT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                TimKiemKH();
        }

        void TimKiemKH() {
            if (string.IsNullOrEmpty(txtMaKH.Text))
                MessageBox.Show("Vui lòng nhập mã khách hàng!", "Thông báo", MessageBoxButtons.OK);
            else
            {
                Entities.KhachHangDV kh = null;
                try
                {
                    kh = DAL.PhatHanhTheGhiNoDAL.TimKiemKH(txtMaKH.Text);
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
            //SetTextBoxStatus_TTKH(true);
            tCtrDichVu.Enabled = false;
            ClearAllTextBox();
            canSaveTTKH = true;
        }

        void TimThayKH(Entities.KhachHangDV kh) {
            cbSoTK.Items.Clear();
            SetTextBoxStatus_TTKH(false);
            SetTabControlStatus(true);
            txtNgayCap.Text = kh.ngay_cap.ToString("dd/MM/yyyy");
            txtNoiCap.Text = kh.noi_cap;
            txtMaKH.Text = kh.ma_KH;
            txtHoTen.Text = kh.ho_ten;
            txtNgaySinh.Text = kh.ngay_sinh.ToString("dd/MM/yyyy");
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

        void SetTabControlStatus(bool status) {
            tCtrDichVu.Enabled = status;
            btnInHoSo.Enabled = status;
            btnLuuHoSo.Enabled = status;
        }

        void SetTextBoxStatus_TTKH(bool status) {
            txtNgayCap.Enabled = status;
            txtNoiCap.Enabled = status;
            //txtMaKH.Enabled = status;
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
            //txtMaKH.Text="";
            txtCMT.Text = "";
            txtHoTen.Text = "";
            txtQuocTich.Text = "";
            cbSoTK.SelectedItem = null;
            cbSoTK.Items.Clear();
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
            if (((sender as ComboBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        private void btnLuuTTKH_Click(object sender, EventArgs e)
        {
            if (!canSaveTTKH) return;
            bool gt = true;
            if (cbGioiTinh.SelectedIndex != 0) gt = false;

            Entities.KhachHangDV kh = new Entities.KhachHangDV(
                txtMaKH.Text,
                txtHoTen.Text,
                txtCMT.Text,
                DateTime.ParseExact(txtNgayCap.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                txtNoiCap.Text,
                txtQuocTich.Text,
                txtSoDienThoai.Text,
                txtEmail.Text,
                txtDiaChi.Text,
                DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                gt);
            if (DAL.PhatHanhTheGhiNoDAL.TimKiemKH(txtCMT.Text) != null)
                try
                {
                    DAL.PhatHanhTheGhiNoDAL.SuaKH(kh, cbSoTK.SelectedItem.ToString());
                    MessageBox.Show("Sửa thông tin khách hàng thành công", "Thông báo", MessageBoxButtons.OK);
                    canSaveTTKH = false;
                    SetTextBoxStatus_TTKH(false);
                }
                catch {
                    DAL.ErrorMessageDAL.DataAccessError();
                }
            else
                try
                {
                    DAL.PhatHanhTheGhiNoDAL.ThemKH(kh, cbSoTK.SelectedItem.ToString());
                    MessageBox.Show("Thêm thông tin khách hàng thành công", "Thông báo", MessageBoxButtons.OK);
                    canSaveTTKH = false;
                    SetTextBoxStatus_TTKH(false);
                }
                catch {
                    DAL.ErrorMessageDAL.DataAccessError();
                }
        }

        private void btnSuaTTKH_Click(object sender, EventArgs e)
        {
            SetTextBoxStatus_TTKH(true);
            canSaveTTKH = true;
        }

        private void btnXoaTTKH_Click(object sender, EventArgs e)
        {

        }

        private void cbSoTK_Validated(object sender, EventArgs e)
        {
            foreach (var c in cbSoTK.Items)
            {
                if (c.ToString() == cbSoTK.Text) return;
            }
            cbSoTK.Items.Add(cbSoTK.Text);
            cbSoTK.SelectedIndex = cbSoTK.Items.Count - 1;
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
            KhoiTaoTTChung();
            //Phat hanh moi the ghi no
            switch (tCtrDichVu.SelectedIndex) { 
                case 0: //Phat hanh moi 
                    KhoiTaoPhatHanhMoi();
                    PhatHanhMoi();
                    break;
                case 1: //Phat hanh lai
                    KhoiTaoPhatHanhLai();
                    PhatHanhLai();
                    break;
                case 2: //Hop dong
                    break;
                case 3: //Giay hen
                    break;
                default: break;
            }
        }

        private void KhoiTaoTTChung() {
            ttchung_nguon.Clear();
            ttchung_dich.Clear();

            ttchung_nguon.Add(DateTime.Now.Day.ToString());
            ttchung_nguon.Add(DateTime.Now.Month.ToString());
            ttchung_nguon.Add(DateTime.Now.Year.ToString());
            ttchung_nguon.Add(Utilities.Thong_tin_dang_nhap.ten_cn);
            ttchung_nguon.Add(txtCMT.Text);
            ttchung_nguon.Add(txtHoTen.Text);
            ttchung_nguon.Add(txtMaKH.Text);
            ttchung_nguon.Add(txtSoDienThoai.Text);
            ttchung_nguon.Add(txtEmail.Text);
            ttchung_nguon.Add(txtDiaChi.Text);
            ttchung_nguon.Add(txtNgaySinh.Text);
            ttchung_nguon.Add(txtNgayCap.Text);
            ttchung_nguon.Add(txtNoiCap.Text);
            ttchung_nguon.Add(txtQuocTich.Text);
            ttchung_nguon.Add(cbSoTK.SelectedText);

            ttchung_dich.Add("<NGAY>");
            ttchung_dich.Add("<THANG>");
            ttchung_dich.Add("<NAM>");
            ttchung_dich.Add("<CHI_NHANH>");
            ttchung_dich.Add("<CMND>");
            ttchung_dich.Add("<HO_TEN>");
            ttchung_dich.Add("<MA_KH>");
            ttchung_dich.Add("<DIEN_THOAI>");
            ttchung_dich.Add("<EMAIL>");
            ttchung_dich.Add("<DIA_CHI>");
            ttchung_dich.Add("<NGAY_SINH>");
            ttchung_dich.Add("<NGAY_CAP>");
            ttchung_dich.Add("<NOI_CAP>");
            ttchung_dich.Add("<QUOC_TICH>");
            ttchung_dich.Add("<SO_TK>");

            if (cbGioiTinh.SelectedIndex == 0) { //gioi tinh NAM
                ttchung_nguon.Add(((char)0x2611).ToString());
                ttchung_dich.Add("<GT_0>");
                ttchung_nguon.Add(((char)0x2610).ToString());
                ttchung_dich.Add("<GT_1>");
            }
            else if (cbGioiTinh.SelectedIndex == 1) { //gioi tinh NU
                ttchung_nguon.Add(((char)0x2611).ToString());
                ttchung_dich.Add("<GT_1>");
                ttchung_nguon.Add(((char)0x2610).ToString());
                ttchung_dich.Add("<GT_0>");
            }
        }

        private void KhoiTaoPhatHanhMoi() {
            phat_hanh_moi_nguon.Clear();
            phat_hanh_moi_dich.Clear();

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
            phat_hanh_moi_dich.Add("<INTERNET>");
            phat_hanh_moi_dich.Add("<HMGD>"); //Han muc giao dich
            phat_hanh_moi_dich.Add("<HMGD_BANG_CHU>");
            phat_hanh_moi_dich.Add("<OTP_DTDD>");
            phat_hanh_moi_dich.Add("<OTP_EMAIL>");
            phat_hanh_moi_dich.Add("<BAO_HIEM>");


            //Noi dia
            if (clbND_Moi.GetItemChecked(2)) {
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
            }
            else if (clbND_Moi.GetItemChecked(1))
            {
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
            }
            else
            {
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
            }
            
            //Quoc te
            if (clbQT_Moi.GetItemChecked(1))
            {
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
            }
            else {
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
            }

            //Hang the
            if (clbHangThe_Moi.GetItemChecked(1))
            {
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
            }
            else
            {
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
            }

            //Hinh thuc phat hanh
            if (clbHTPhatHanh_Moi.GetItemChecked(1))
            {
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
            }
            else
            {
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
            }

            //Hinh thuc nhan the
            if (clbHTNhanThe_Moi.GetItemChecked(1))
            {
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
            }
            else
            {
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
            }

            //SMS
            if (ckbSMS_Moi.Checked) {
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
                phat_hanh_moi_nguon.Add(txtDTDD_SMS_Moi.Text);
            }
            else
            {
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add("");
            }

            //Internet
            if (ckbInternet_Moi.Checked)
            {
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
                phat_hanh_moi_nguon.Add(txtHMGD_Moi.Text);
                phat_hanh_moi_nguon.Add(Utilities.CommonMethods.ChuyenSoSangChu(txtHMGD_Moi.Text));
            }
            else
            {
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add("");
                phat_hanh_moi_nguon.Add("");
            }

            phat_hanh_moi_nguon.Add(txtDTDD_SMS_Moi.Text);
            phat_hanh_moi_nguon.Add(txtEmail.Text);

            //Bao hiem
            if (ckbBaoHiem_Moi.Checked)
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
            else phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
        }

        private void KhoiTaoPhatHanhLai() 
        {
            phat_hanh_lai_nguon.Clear();
            phat_hanh_lai_dich.Clear();

            // Ghi no noi dia
            phat_hanh_lai_dich.Add("<GNND>");
            phat_hanh_lai_dich.Add("<LN>");
            phat_hanh_lai_dich.Add("<SV>");
            phat_hanh_lai_dich.Add("<LKTH>");

            if (clbND_Lai.GetItemChecked(3)) {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
            }
            else if (clbND_Lai.GetItemChecked(2))
            {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
            }
            else if (clbND_Lai.GetItemChecked(1))
            {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
            }
            else 
            {
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
            }

            //Ghi no quoc te
            phat_hanh_lai_dich.Add("<GNQT>");
            phat_hanh_lai_dich.Add("<TDQT>");
            phat_hanh_lai_dich.Add("<VS>");
            phat_hanh_lai_dich.Add("<MC>");
            phat_hanh_lai_dich.Add("<JCB>");

            if (clbQT_Lai.GetItemChecked(4))
            {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
            }
            else if (clbQT_Lai.GetItemChecked(3))
            {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
            }
            else if (clbQT_Lai.GetItemChecked(2))
            {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
            }
            else if (clbQT_Lai.GetItemChecked(1))
            {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
            }
            else
            {
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
            }

            //Hang The
            phat_hanh_lai_dich.Add("<C>");
            phat_hanh_lai_dich.Add("<V>");
            phat_hanh_lai_dich.Add("<BK>");

            if (clbHangThe_Lai.GetItemChecked(2))
            {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
            }
            else if (clbHangThe_Lai.GetItemChecked(1))
            {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
            }
            else
            {
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
            }

            //Hinh thuc phat hanh
            phat_hanh_lai_dich.Add("<PHT>");
            phat_hanh_lai_dich.Add("<PHN>");

            if (clbHangThe_Lai.GetItemChecked(0))
            {
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
            }
            else
            {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
            }

            //Dang ky dich vu
            phat_hanh_lai_dich.Add("<SMS>");
            phat_hanh_lai_dich.Add("<DTDD_OTP>");
            phat_hanh_lai_dich.Add("<EMAIL_OTP>");
            phat_hanh_lai_dich.Add("<INTERNET>");
            phat_hanh_lai_dich.Add("<HMGD>");
            phat_hanh_lai_dich.Add("<BANG_CHU>");
            phat_hanh_lai_dich.Add("<BAO_HIEM>");


            if (ckbSMS_Lai.Checked)
            {
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(txtDTDD_SMS_Lai.Text);
                phat_hanh_lai_nguon.Add(txtEmail.Text);
            }
            else {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add("");
                phat_hanh_lai_nguon.Add("");
            }

            if (ckbInternet_Lai.Checked)
            {
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(txtHMGD_Lai.Text);
                phat_hanh_lai_nguon.Add(Utilities.CommonMethods.ChuyenSoSangChu(txtHMGD_Lai.Text));
            }
            else {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add("");
                phat_hanh_lai_nguon.Add("");
            }

            if(ckbBaoHiem_Lai.Checked)
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
            else
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());

        }

        void PhatHanhMoi() {
            var listNguon = ttchung_nguon;
            listNguon.AddRange(phat_hanh_moi_nguon);
            var listDich = ttchung_dich;
            listDich.AddRange(phat_hanh_moi_dich);
            saveFilePhatHanhMoi.Filter = "Word Documents|*.docx";
            try
            {
                string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"DV\" + fileNamePhatHanhMoi + ".docx");
                string saveFileLocation = CommonMethods.SaveFileLocation(@"DV\" + fileNamePhatHanhMoi +"_"+ DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".docx");
                CommonMethods.CreateWordDocument(TemplateFileLocation, saveFileLocation, listDich, listNguon);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFilePhatHanhMoi.FileName, "Tạo file thành công");
                OpenFileWord(saveFilePhatHanhMoi.FileName);
            }
            catch
            {
                MessageBox.Show("Không thể tạo file!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        void PhatHanhLai()
        {
            var listNguon = ttchung_nguon;
            listNguon.AddRange(phat_hanh_lai_nguon);
            var listDich = ttchung_dich;
            listDich.AddRange(phat_hanh_lai_dich);
            saveFilePhatHanhLai.Filter = "Word Documents|*.docx";
            try
            {
                string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"DV\" + fileNamePhatHanhLai + ".docx");
                string saveFileLocation = CommonMethods.SaveFileLocation(@"DV\" + fileNamePhatHanhMoi + "_"+ DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".docx");
                CommonMethods.CreateWordDocument(TemplateFileLocation, saveFileLocation, listDich, listNguon);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFilePhatHanhLai.FileName, "Tạo file thành công");
                OpenFileWord(saveFilePhatHanhLai.FileName);
            }
            catch
            {
                MessageBox.Show("Không thể tạo file!", "Thông báo", MessageBoxButtons.OK);
            }
        }


        void OpenFileWord(string fileLocation)
        {
            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document document = ap.Documents.Open(fileLocation);
            ap.Visible = true;
        }

        private void gbThongTinKH_Enter(object sender, EventArgs e)
        {

        }
    }
}
