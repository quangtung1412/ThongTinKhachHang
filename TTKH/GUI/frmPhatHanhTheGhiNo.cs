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
using AGRIBANKHD.Entities;
using System.Threading;

namespace AGRIBANKHD.GUI
{
    public partial class frmPhatHanhTheGhiNo : Form
    {
        private const string fileNamePhatHanhMoi = "PHAT_HANH_MOI";
        private const string fileNamePhatHanhLai = "PHAT_HANH_LAI";
        private const string fileNameHopDong = "HOP_DONG";
        private const string fileNameGiayHen = "GIAY_HEN";

        private List<TextBox> listTxtNotNull;

        private NguoiDaiDien[] dsNguoiDaiDien;

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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

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

            //Phat hanh moi
            clbND_Moi.SetItemChecked(0, true);
            clbQT_Moi.SetItemChecked(0, true);
            clbHangThe_Moi.SetItemChecked(0, true);
            clbHTPhatHanh_Moi.SetItemChecked(0, true);
            clbHTNhanThe_Moi.SetItemChecked(0, true);

            //Phat hanh lai
            clbND_Lai.SetItemChecked(0, true);
            clbQT_Lai.SetItemChecked(0, true);
            clbHangThe_Lai.SetItemChecked(0, true);
            clbHTPhatHanh_Lai.SetItemChecked(0, true);

            //Hop dong
            //Lay thong tin nguoi dai dien
            dsNguoiDaiDien = DAL.PhatHanhTheGhiNoDAL.DanhSachNguoiDaiDien(Thong_tin_dang_nhap.ma_cn);
            
            if (dsNguoiDaiDien != null)
            {
                //sap xep dsNguoiDaiDien
                for (int i = 0; i < dsNguoiDaiDien.Length; i++)
                {
                    var temp = dsNguoiDaiDien[0];
                    if (dsNguoiDaiDien[i].chucVu == "Branch General Manager")
                    {
                        dsNguoiDaiDien[0] = dsNguoiDaiDien[i];
                        dsNguoiDaiDien[i] = temp;
                    }
                }

                for (int i = 0; i < dsNguoiDaiDien.Length; i++)
                {
                    cbNguoiDaiDien_BenA.Items.Add(dsNguoiDaiDien[i].hoTen);
                }
                cbNguoiDaiDien_BenA.SelectedIndex = 0;
            }

            //TTKH
            cbTimKiem.SelectedIndex = 0;
            txtTimKiem.Focus();
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
            if (string.IsNullOrEmpty(txtTimKiem.Text))
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK);
            else
            {
                Entities.KhachHangDV kh = null;
                try
                {
                    if (cbTimKiem.SelectedIndex == 0)
                        kh = DAL.PhatHanhTheGhiNoDAL.TimKiemKH_TheoMaKH(txtTimKiem.Text);
                    else
                        kh = DAL.PhatHanhTheGhiNoDAL.TimKiemKH_TheoCMND(txtTimKiem.Text);
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
            MessageBox.Show(@"Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK);
            //SetTextBoxStatus_TTKH(true);
            tCtrDichVu.Enabled = false;
            ClearAllTextBox();
        }

        void TimThayKH(Entities.KhachHangDV kh) {
            cbSoTK.Items.Clear();
            SetTextBoxStatus_TTKH(false);
            txtNgayCap.Text = kh.ngay_cap.ToString("dd/MM/yyyy");
            txtNoiCap.Text = kh.noi_cap;
            txtTimKiem.Text = kh.ma_KH;
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
                DataTable dt = DAL.PhatHanhTheGhiNoDAL.TimSoTK(kh.ma_KH);
                for (int i = 0; i < dt.Rows.Count; i++) {
                    string soTK = dt.Rows[i]["SOTK"].ToString();
                    char loaiTK = soTK[4];
                    if (loaiTK == '1' || loaiTK == '2')
                        cbSoTK.Items.Add(soTK);
                }
                if (cbSoTK.Items.Count > 0)
                {
                    SetTabControlStatus(true);
                    cbSoTK.SelectedIndex = 0;
                }
                else
                    MessageBox.Show("Khách hàng chưa có số tài khoản!\nLiên hệ bộ phận Kế toán để có thêm thông tin!", "Thông báo", MessageBoxButtons.OK);
                if (cbSoTK.Items.Count > 1)
                    cbSoTK.Enabled = true;
            }
            catch {
                DAL.ErrorMessageDAL.DataAccessError();
            }

        }

        void SetTabControlStatus(bool status) {
            tCtrDichVu.Enabled = status;
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

        private void txtDTDD_SMS_Moi_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHMGD_Moi_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDTDD_SMS_Lai_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHMGD_Lai_KeyPress(object sender, KeyPressEventArgs e)
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
        
        //EMenu tab Hop Dong
        private void cbNguoiDaiDien_BenA_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbNguoiDaiDien_BenA.SelectedIndex;
            if (dsNguoiDaiDien[index].chucVu == "Branch General Manager")
                txtChucVu_BenA.Text = "Giám đốc";
            else txtChucVu_BenA.Text = "Phó giám đốc";
            txtDienThoai_BenA.Text = dsNguoiDaiDien[index].Sdt;
            txtFax_BenA.Text = dsNguoiDaiDien[index].Fax;
            txtDiaChi_BenA.Text = dsNguoiDaiDien[index].diaChi;
            txtGiayUyQuyen_BenA.Text = dsNguoiDaiDien[index].giayUQ;
        }

        private void txtCMT_BenB_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNgayCap_BenB_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNgayDeNghi_BenB_KeyPress(object sender, KeyPressEventArgs e)
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

        //Luu ho so
        private void btnLuuHoSo_Click(object sender, EventArgs e)
        {
            KhoiTaoTTChung();
            //Phat hanh moi the ghi no
            switch (tCtrDichVu.SelectedIndex)
            {
                case 0: //Phat hanh moi 
                    KhoiTaoPhatHanhMoi();
                    Thread tMoi = new Thread(PhatHanhMoi);
                    tMoi.Start();
                    break;
                case 1: //Phat hanh lai
                    KhoiTaoPhatHanhLai();
                    Thread tLai = new Thread(PhatHanhLai);
                    tLai.Start();
                    break;
                case 2: //Hop dong
                    KhoiTaoHopDong();
                    Thread tHD = new Thread(HopDong);
                    tHD.Start();
                    break;
                case 3: //Giay hen
                    break;
                default: break;
            }
        }

        //Procedures
        private void KhoiTaoTTChung() {
            ttchung_nguon.Clear();
            ttchung_dich.Clear();

            ttchung_nguon.Add(DateTime.Now.Day.ToString());
            ttchung_nguon.Add(DateTime.Now.Month.ToString());
            ttchung_nguon.Add(DateTime.Now.Year.ToString());
            ttchung_nguon.Add(DateTime.Now.ToString("dd/MM/yyyy"));
            ttchung_nguon.Add(Utilities.Thong_tin_dang_nhap.ten_cn);
            ttchung_nguon.Add(txtCMT.Text);
            ttchung_nguon.Add(txtHoTen.Text);
            ttchung_nguon.Add(txtTimKiem.Text);
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
            ttchung_dich.Add("<HOM_NAY>");
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

        private void KhoiTaoPhatHanhMoi()
        {
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
            for (int i = 0; i < 26; i++) //Ten in the
            {
                phat_hanh_moi_dich.Add("<" + (i+1) + ">");
            }


            //Noi dia
            CheckedListBoxToString(clbND_Moi, phat_hanh_moi_nguon);
            //Quoc te
            CheckedListBoxToString(clbQT_Moi, phat_hanh_moi_nguon);
            //Hang the
            CheckedListBoxToString(clbHangThe_Moi, phat_hanh_moi_nguon);
            //Hinh thuc phat hanh
            CheckedListBoxToString(clbHTPhatHanh_Moi, phat_hanh_moi_nguon);
            //Hinh thuc nhan the
            CheckedListBoxToString(clbHTNhanThe_Moi, phat_hanh_moi_nguon);
            //SMS
            if (ckbSMS_Moi.Checked)
            {
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

            //Ten in the
            string sTenInThe = CommonMethods.RemoveUnicode(txtHoTen.Text);
            sTenInThe = sTenInThe.ToUpper();
            char[] cTenInThe = new char[26];
            for (int i = 0; i < sTenInThe.Length; i++)
                cTenInThe[i] = sTenInThe[i];
            for (int i = 0; i < cTenInThe.Length; i++)
            {
                if(cTenInThe[i] != '\0'){
                    phat_hanh_moi_nguon.Add(cTenInThe[i].ToString());
                }
                else
                    phat_hanh_moi_nguon.Add("");
            }
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

            CheckedListBoxToString(clbND_Lai, phat_hanh_lai_nguon);
            //Ghi no quoc te
            phat_hanh_lai_dich.Add("<GNQT>");
            phat_hanh_lai_dich.Add("<TDQT>");
            phat_hanh_lai_dich.Add("<VS>");
            phat_hanh_lai_dich.Add("<MC>");
            phat_hanh_lai_dich.Add("<JCB>");

            CheckedListBoxToString(clbQT_Lai, phat_hanh_lai_nguon);
            //Hang The
            phat_hanh_lai_dich.Add("<C>");
            phat_hanh_lai_dich.Add("<V>");
            phat_hanh_lai_dich.Add("<BK>");

            CheckedListBoxToString(clbHangThe_Lai, phat_hanh_lai_nguon);
            //Hinh thuc phat hanh
            phat_hanh_lai_dich.Add("<PHT>");
            phat_hanh_lai_dich.Add("<PHN>");

            CheckedListBoxToString(clbHTPhatHanh_Lai, phat_hanh_lai_nguon);

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

        private void KhoiTaoHopDong()
        {
            hop_dong_nguon.Clear();
            hop_dong_dich.Clear();

            hop_dong_dich.Add("<CHI_NHANH_0>");
            hop_dong_nguon.Add(Thong_tin_dang_nhap.ten_cn.ToUpper());

            //Ben A
            hop_dong_dich.Add("<DAI_DIEN>");
            hop_dong_nguon.Add(cbNguoiDaiDien_BenA.SelectedItem.ToString());

            hop_dong_dich.Add("<CHUC_VU>");
            hop_dong_nguon.Add(txtChucVu_BenA.Text);

            hop_dong_dich.Add("<SDT_CN>");
            hop_dong_nguon.Add(txtDienThoai_BenA.Text);

            hop_dong_dich.Add("<FAX>");
            hop_dong_nguon.Add(txtFax_BenA.Text);

            hop_dong_dich.Add("<DIACHI_CN>");
            hop_dong_nguon.Add(txtDienThoai_BenA.Text);

            hop_dong_dich.Add("<UY_QUYEN>");
            hop_dong_nguon.Add(txtGiayUyQuyen_BenA.Text);

            //Ben B
            hop_dong_dich.Add("<HOTEN_KH>");
            hop_dong_nguon.Add(txtHoTen_BenB.Text);

            hop_dong_dich.Add("<DIACHI_KH>");
            hop_dong_nguon.Add(txtDiaChi_BenB.Text);

            hop_dong_dich.Add("<CMND_KH>");
            hop_dong_nguon.Add(txtCMT_BenB.Text);

            hop_dong_dich.Add("<NGAY_CAP_KH>");
            hop_dong_nguon.Add(txtNgayCap_BenB.Text);

            hop_dong_dich.Add("<NOI_CAP_KH>");
            hop_dong_nguon.Add(txtNoiCap_BenB.Text);

            hop_dong_dich.Add("<NGAY_DE_NGHI>");
            hop_dong_nguon.Add(txtNgayDeNghi_BenB.Text);
        }
        void PhatHanhMoi() {
            if (CheckNullPhatHanhMoi()) return;
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
                Thread.Sleep(500);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFilePhatHanhMoi.FileName, "Tạo file thành công");
                OpenFileWord(saveFileLocation);
            }
            catch
            {
                MessageBox.Show("Không thể tạo file!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        void PhatHanhLai()
        {
            if (CheckNullPhatHanhLai()) return;
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
                Thread.Sleep(500);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFilePhatHanhLai.FileName, "Tạo file thành công");
                OpenFileWord(saveFilePhatHanhLai.FileName);
            }
            catch
            {
                MessageBox.Show("Không thể tạo file!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        void HopDong()
        {
            if (CheckNullHopDong()) return;
            var listNguon = ttchung_nguon;
            listNguon.AddRange(hop_dong_nguon);
            var listDich = ttchung_dich;
            listDich.AddRange(hop_dong_dich);
            saveFileHopDong.Filter = "Word Documents|*.docx";
            try
            {
                string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"DV\" + fileNameHopDong + ".docx");
                string saveFileLocation = CommonMethods.SaveFileLocation(@"DV\" + fileNameHopDong + "_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".docx");
                CommonMethods.CreateWordDocument(TemplateFileLocation, saveFileLocation, listDich, listNguon);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFileHopDong.FileName, "Tạo file thành công");
                Thread.Sleep(500);
                OpenFileWord(saveFileHopDong.FileName);
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

        void CheckedListBoxToString(CheckedListBox clb, List<string> lNguon)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (clb.GetItemChecked(i))
                {
                    lNguon.Add(((char)0x2611).ToString());
                }
                else
                    lNguon.Add(((char)0x2610).ToString());
            }
        }

        bool CheckNullPhatHanhMoi()
        {
            if (ckbSMS_Moi.Checked && string.IsNullOrEmpty(txtDTDD_SMS_Moi.Text))
            {
                MessageBox.Show("Vui Lòng nhập số điện thoại nhận SMS!", "Thông báo", MessageBoxButtons.OK);
                txtDTDD_SMS_Moi.Focus();
                return true;
            }

            if (ckbInternet_Moi.Checked && string.IsNullOrEmpty(txtHMGD_Moi.Text))
            {
                MessageBox.Show("Vui Lòng nhập hạn mức giao dịch trên Internet!", "Thông báo", MessageBoxButtons.OK);
                txtHMGD_Moi.Focus();
                return true;
            }

            return false;
        }

        bool CheckNullPhatHanhLai()
        {
            if (ckbSMS_Moi.Checked && string.IsNullOrEmpty(txtDTDD_SMS_Moi.Text))
            {
                MessageBox.Show("Vui Lòng nhập số điện thoại nhận SMS!", "Thông báo", MessageBoxButtons.OK);
                txtDTDD_SMS_Moi.Focus();
                return true;
            }

            if (ckbInternet_Moi.Checked && string.IsNullOrEmpty(txtHMGD_Moi.Text))
            {
                MessageBox.Show("Vui Lòng nhập hạn mức giao dịch trên Internet!", "Thông báo", MessageBoxButtons.OK);
                txtHMGD_Moi.Focus();
                return true;
            }
            return false;
        }

        bool CheckNullHopDong()
        {
            if (string.IsNullOrEmpty(txtHoTen_BenB.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                txtHoTen_BenB.Focus();
                return true;
            }

            if (string.IsNullOrEmpty(txtCMT_BenB.Text))
            {
                MessageBox.Show("Vui lòng nhập số CMND!");
                txtCMT_BenB.Focus();
                return true;
            }

            if (string.IsNullOrEmpty(txtNgayCap_BenB.Text))
            {
                MessageBox.Show("Vui lòng nhập ngày cấp CMND!");
                txtNgayCap_BenB.Focus();
                return true;
            }

            if (string.IsNullOrEmpty(txtNoiCap_BenB.Text))
            {
                MessageBox.Show("Vui lòng nhập nơi cấp CMND!");
                txtNoiCap_BenB.Focus();
                return true;
            }
            return false;
        }

    }
}
