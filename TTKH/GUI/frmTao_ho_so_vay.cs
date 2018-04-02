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
using AGRIBANKHD.Properties;

namespace AGRIBANKHD.GUI
{
    public partial class frmTao_ho_so_vay : Form
    {

        private List<string> nguon_thong_tin_chung = new List<string>();

        private List<string> dich_thong_tin_chung = new List<string>();

        private List<string> nguon_tstc = new List<string>();

        private List<string> dich_tstc = new List<string>();

        private Int64 gia_tri_tsbd;

        private Int64 tong_han_muc_tin_dung;

        //private string ma_pgd;

        internal string _ma_hd_vay { get; set; }

        TaisanthechapBUS tstcbus = new TaisanthechapBUS();

        HopdongvayBUS hdbus = new HopdongvayBUS();

        public frmTao_ho_so_vay()
        {
            InitializeComponent();
            //List<Chinhanh> dschinhanh = new List<Chinhanh>();
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            //this.AcceptButton = btnTim_kiem;
            if (!Thong_tin_dang_nhap.admin)
            {
                txtma_CN.Text = Thong_tin_dang_nhap.ma_cn;
                cboxChi_nhanh.Enabled = false;
                cboxChi_nhanh.Text = Thong_tin_dang_nhap.ten_cn;
            }
            //cboxLoai_hop_dong_tin_dung.Enabled = false;
            //btnTao_hop_dong_tin_dung.Enabled = false;
            //cboxLoai_hop_dong_the_chap.Enabled = false;
            //btnTao_hop_dong_the_chap.Enabled = false;
            //btnTim_kiem.Enabled = false;
            //cboxLoai_bien_ban_dinh_gia.Enabled = false;
            //btnTao_bien_ban_dinh_gia.Enabled = false;
            //txtDanh_gia_tai_san_bao_dam.Enabled = false;
            //grbHop_dong_tin_dung.Enabled = false;
            //txtNgay_hop_dong_tin_dung.ReadOnly = true;
            //grbHop_dong_the_chap.Enabled = false;
            //grbBien_ban_dinh_gia.Enabled = false;
            //grbDon_the_chap.Enabled = false;
            //grbDe_xuat_giai_ngan.Enabled = false;
            tabHo_so_vay.Enabled = false;
            tabHo_so_vay.SelectedTab = tabHop_dong_tin_dung;
        }

        private void cboxChi_nhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
        }

        //private void btnTim_kiem_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtMa_hd_vay.Text))
        //    {
        //        DataTable DS_TSTC = AGRIBANKHD.BUS.TaisanthechapBUS.DS_TSTC(txtMa_hd_vay.Text);
        //        dgvDanh_sach_tstc.DataSource = DS_TSTC;
        //        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_tstc);
        //        ControlFormat.DataGridView_RemoveEmptyColumns(dgvDanh_sach_tstc);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Bạn chưa chọn mã hợp đồng.");
        //        txtMa_hd_vay.Focus();
        //        return;
        //    }
        //    btnTim_kiem.Enabled = false;
        //}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_kiem_hop_dong_vay_Click(object sender, EventArgs e)
        {
            frmThong_tin_hop_dong_vay frm = new frmThong_tin_hop_dong_vay(this, txtma_CN.Text, cboxChi_nhanh.Text);
            //frm.MdiParent = this.ParentForm;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            //frm.BringToFront();
        }

        internal void Cap_nhat_txtMa_hd_vay()
        {            
            //Khóa nút tìm kiếm hợp đồng vay
            //btnTim_kiem_hop_dong_vay.Enabled = false;
            //Kích hoạt tab hồ sơ vay
            tabHo_so_vay.Enabled = true;
            //Bật nút tìm kiếm tài sản thế chấp
            //btnTim_kiem.Enabled = true; 
            //Gán mã hợp đồng vay vào txtMa_hd_vay
            txtMa_hd_vay.Text = _ma_hd_vay;
            //grbHop_dong_tin_dung.Enabled = true;
            List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(_ma_hd_vay, txtma_CN.Text);
            Hopdongvay hd = HD_VAY_theoma_HD[0];
            //txtNgay_hop_dong_tin_dung.Text = hd.ngay_hd_vay;
            DataTable ds_kh_vay_theo_ma = AGRIBANKHD.BUS.KhachhangvayBUS.DS_KH_VAY_THEO_MA(hd.ma_kh_vay);
            DataRow row = ds_kh_vay_theo_ma.Rows[0];
            Khachhangvay khv = new Khachhangvay(row);
            txtLoai_hop_dong_tin_dung.Clear();
            txtNgay_hop_dong_tin_dung.Clear();
            txtNgay_hop_dong_tin_dung.Text = hd.ngay_hd_vay;
            #region Lay thong tin hop dong tin dung
            //----------------------------Lấy thông tin hợp đồng tín dụng-------------------------------
            if (khv.loai_kh == "Tổ chức")
            {
                if (hd.phuong_thuc == "Từng lần")
                {
                    txtLoai_hop_dong_tin_dung.Text = "TO_CHUC_TUNG_LAN";
                }
                else if (hd.phuong_thuc == "Hạn mức tín dụng không bảo lãnh")
                {
                    txtLoai_hop_dong_tin_dung.Text = "TO_CHUC_HAN_MUC_KHONG_BAO_LANH";
                }
                else if (hd.phuong_thuc == "Hạn mức tín dụng có bảo lãnh")
                {
                    txtLoai_hop_dong_tin_dung.Text = "TO_CHUC_HAN_MUC_CO_BAO_LANH";
                }
                else if (hd.phuong_thuc == "Theo dự án đầu tư")
                {
                    txtLoai_hop_dong_tin_dung.Text = "TO_CHUC_DU_AN_DAU_TU";
                }
            }
            else if (khv.loai_kh == "Hộ gia đình")
            {
                if (hd.phuong_thuc == "Từng lần")
                {
                    txtLoai_hop_dong_tin_dung.Text = "HO_GIA_DINH_TUNG_LAN";
                }
                else if (hd.phuong_thuc == "Hạn mức tín dụng không bảo lãnh")
                {
                    txtLoai_hop_dong_tin_dung.Text = "HO_GIA_DINH_HAN_MUC_KHONG_BAO_LANH";
                }
                else if (hd.phuong_thuc == "Hạn mức tín dụng có bảo lãnh")
                {
                    txtLoai_hop_dong_tin_dung.Text = "HO_GIA_DINH_HAN_MUC_CO_BAO_LANH";
                }
                else if (hd.phuong_thuc == "Theo dự án đầu tư")
                {
                    txtLoai_hop_dong_tin_dung.Text = "HO_GIA_DINH_DU_AN_DAU_TU";
                }
            }
            else if (khv.loai_kh == "Cá nhân")
            {
                if (hd.phuong_thuc == "Từng lần")
                {
                    txtLoai_hop_dong_tin_dung.Text = "CA_NHAN_TUNG_LAN";
                }
                else if (hd.phuong_thuc == "Hạn mức tín dụng không bảo lãnh")
                {
                    txtLoai_hop_dong_tin_dung.Text = "CA_NHAN_HAN_MUC_KHONG_BAO_LANH";
                }
                else if (hd.phuong_thuc == "Hạn mức tín dụng có bảo lãnh")
                {
                    txtLoai_hop_dong_tin_dung.Text = "CA_NHAN_HAN_MUC_CO_BAO_LANH";
                }
                else if (hd.phuong_thuc == "Theo dự án đầu tư")
                {
                    txtLoai_hop_dong_tin_dung.Text = "CA_NHAN_DU_AN_DAU_TU";
                }
            }
            //------------------------------------------------------------------------------------
            #endregion
            List<string> number_columns = new List<string>();
            number_columns.Add("DS_GIA_TRI");
            number_columns.Add("BDS_GIA_TRI");
            number_columns.Add("TSTC_KHAC_GIA_TRI");
            dgvDanh_sach_tstc_1.DataSource = null;
            dgvDanh_sach_tstc_1.Rows.Clear();
            //dgvDanh_sach_tstc_2.DataSource = null;
            //dgvDanh_sach_tstc_2.Rows.Clear();
            //dgvDanh_sach_tstc_3.DataSource = null;
            //dgvDanh_sach_tstc_3.Rows.Clear();
            
            DataTable DS_TSTC = TaisanthechapBUS.DS_TSTC(txtMa_hd_vay.Text);
            
            dgvDanh_sach_tstc_1.DataSource = DS_TSTC;
            ControlFormat.DataGridView_ShowAllColumn(dgvDanh_sach_tstc_1);
            ControlFormat.DataGridViewFormat(dgvDanh_sach_tstc_1);
            ControlFormat.DataGridView_RemoveEmptyColumns(dgvDanh_sach_tstc_1);
            ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_tstc_1, number_columns);

            if (dgvDanh_sach_tstc_1.Rows.Count == 0)
            {
                txtLoai_hop_dong_the_chap.Clear();
                txtLoai_bien_ban_dinh_gia.Clear();
                txtDon_the_chap.Clear();
            }
            //dgvDanh_sach_tstc_2.DataSource = DS_TSTC;
            //ControlFormat.DataGridView_ShowAllColumn(dgvDanh_sach_tstc_2);
            //ControlFormat.DataGridViewFormat(dgvDanh_sach_tstc_2);
            //ControlFormat.DataGridView_RemoveEmptyColumns(dgvDanh_sach_tstc_2);
            //ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_tstc_2, number_columns);
            
            //dgvDanh_sach_tstc_3.DataSource = DS_TSTC;
            //ControlFormat.DataGridView_ShowAllColumn(dgvDanh_sach_tstc_3);
            //ControlFormat.DataGridViewFormat(dgvDanh_sach_tstc_3);
            //ControlFormat.DataGridView_RemoveEmptyColumns(dgvDanh_sach_tstc_3);
            //ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_tstc_3, number_columns);
            //Lấy thông tin hồ sơ vay
            this.Lay_thong_tin_ho_so_vay();
        }

        #region Lay_thong_tin_ho_so_vay
        internal void Lay_thong_tin_ho_so_vay()
        {
            this.nguon_thong_tin_chung.Clear();
            this.dich_thong_tin_chung.Clear();

            List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(_ma_hd_vay, txtma_CN.Text);
            Hopdongvay hd = HD_VAY_theoma_HD[0];

            CanbotindungBUS cbbus = new CanbotindungBUS();
            //Thông tin đại diện Agribank
            Canbotindung dai_dien_agribank = cbbus.CBTD_theo_ten_dang_nhap(hd.dai_dien_agribank);
            this.nguon_thong_tin_chung.Add("<HDV_DANH_XUNG_DAI_DIEN_AGRIBANK>");
            this.dich_thong_tin_chung.Add(dai_dien_agribank.danh_xung);

            this.nguon_thong_tin_chung.Add("<HDV_DAI_DIEN_AGRIBANK>");
            this.dich_thong_tin_chung.Add(dai_dien_agribank.ho_ten);

            this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_DAI_DIEN_AGRIBANK>");
            this.dich_thong_tin_chung.Add(dai_dien_agribank.chuc_vu);

            this.nguon_thong_tin_chung.Add("<HDV_DIEN_THOAI_DAI_DIEN_AGRIBANK>");
            this.dich_thong_tin_chung.Add(dai_dien_agribank.dien_thoai);

            this.nguon_thong_tin_chung.Add("<HDV_FAX_DAI_DIEN_AGRIBANK>");
            this.dich_thong_tin_chung.Add(dai_dien_agribank.fax);

            this.nguon_thong_tin_chung.Add("<HDV_GIAY_UY_QUYEN_AGRIBANK>");
            if (dai_dien_agribank.giay_uy_quyen == "")
            {
                this.dich_thong_tin_chung.Add(dai_dien_agribank.giay_uy_quyen);
            }
            else
            {
                this.dich_thong_tin_chung.Add(" và " + dai_dien_agribank.giay_uy_quyen);
            }

            //Thông tin chi nhánh
            Chinhanh chi_nhanh = AGRIBANKHD.BUS.ChinhanhBUS.CN_theo_ma(txtma_CN.Text);
            this.nguon_thong_tin_chung.Add("<CHI_NHANH_MA_CN>");
            this.dich_thong_tin_chung.Add(chi_nhanh.ma_CN);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_TEN_CN_VIET_THUONG>");
            this.dich_thong_tin_chung.Add(chi_nhanh.ten_CN);

            this.nguon_thong_tin_chung.Add("<TIEU_DE_TEN_CN_VIET_HOA>");
            this.dich_thong_tin_chung.Add(chi_nhanh.ten_CN.Substring(9).ToUpper());

            Phonggiaodich phong_giao_dich = PhonggiaodichBUS.PGD_THEO_MA(dai_dien_agribank.ma_pgd);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_TEN_CN>");
            this.dich_thong_tin_chung.Add(phong_giao_dich.ten_CN.ToUpper());

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_TEN_PGD_VIET_THUONG>");
            this.dich_thong_tin_chung.Add(phong_giao_dich.ten_CN);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_TEN_CN_DAY_DU_VIET_THUONG>");
            this.dich_thong_tin_chung.Add(phong_giao_dich.ten_cn_day_du);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_TEN_CN_DAY_DU>");
            this.dich_thong_tin_chung.Add(phong_giao_dich.ten_cn_day_du.ToUpper());

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_DIA_CHI>");
            this.dich_thong_tin_chung.Add(phong_giao_dich.dia_chi);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_MST>");
            this.dich_thong_tin_chung.Add(phong_giao_dich.mst);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_DKKD>");
            this.dich_thong_tin_chung.Add(phong_giao_dich.dkkd);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_DKKD_1>");
            this.dich_thong_tin_chung.Add(phong_giao_dich.dkkd.Substring(26));

            this.nguon_thong_tin_chung.Add("<HDV_GIAY_UY_QUYEN_HDTV>");
            this.dich_thong_tin_chung.Add(phong_giao_dich.guq);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_MA_KHTX>");
            this.dich_thong_tin_chung.Add(phong_giao_dich.ma_khtx);

            //Thông tin kiểm soát tín dụng
            this.nguon_thong_tin_chung.Add("<HDV_KIEM_SOAT_TIN_DUNG>");
            Canbotindung kiem_soat_tin_dung = cbbus.CBTD_theo_ten_dang_nhap(hd.kiem_soat_tin_dung);
            this.dich_thong_tin_chung.Add(kiem_soat_tin_dung.ho_ten);

            this.nguon_thong_tin_chung.Add("<HDV_DANH_XUNG_KIEM_SOAT_TIN_DUNG>");
            this.dich_thong_tin_chung.Add(kiem_soat_tin_dung.danh_xung);

            if (kiem_soat_tin_dung.chuc_vu == "Trưởng phòng Kế hoạch & Kinh doanh")
            {
                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("Trưởng phòng KH & KD");

                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG_VIET_HOA>");
                this.dich_thong_tin_chung.Add("TRƯỞNG PHÒNG");

                this.nguon_thong_tin_chung.Add("<HDV_TEN_PHONG_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("PHÒNG KẾ HOẠCH & KINH DOANH");
            }
            else if (kiem_soat_tin_dung.chuc_vu == "Phó phòng Kế hoạch & Kinh doanh")
            {
                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("Phó phòng KH & KD");

                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG_VIET_HOA>");
                this.dich_thong_tin_chung.Add("PHÓ PHÒNG");

                this.nguon_thong_tin_chung.Add("<HDV_TEN_PHONG_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("PHÒNG KẾ HOẠCH & KINH DOANH");
            }
            else if (kiem_soat_tin_dung.chuc_vu == "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân")
            {
                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("Trưởng phòng KH HSX & CN");

                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG_VIET_HOA>");
                this.dich_thong_tin_chung.Add("TRƯỞNG PHÒNG");

                this.nguon_thong_tin_chung.Add("<HDV_TEN_PHONG_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("PHÒNG KHÁCH HÀNG HSX & CÁ NHÂN");
            }
            else if (kiem_soat_tin_dung.chuc_vu == "Phó phòng Khách hàng Hộ sản xuất và Cá nhân")
            {
                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("Phó phòng KH HSX & CN");

                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG_VIET_HOA>");
                this.dich_thong_tin_chung.Add("PHÓ PHÒNG");

                this.nguon_thong_tin_chung.Add("<HDV_TEN_PHONG_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("PHÒNG KHÁCH HÀNG HSX & CÁ NHÂN");
            }
            else if (kiem_soat_tin_dung.chuc_vu == "Trưởng phòng Khách hàng Doanh nghiệp")
            {
                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("Trưởng phòng KH DN");

                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG_VIET_HOA>");
                this.dich_thong_tin_chung.Add("TRƯỞNG PHÒNG");

                this.nguon_thong_tin_chung.Add("<HDV_TEN_PHONG_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("PHÒNG KHÁCH HÀNG DOANH NGHIỆP");
            }
            else if (kiem_soat_tin_dung.chuc_vu == "Phó phòng Khách hàng Doanh nghiệp")
            {
                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("Phó phòng KH DN");

                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG_VIET_HOA>");
                this.dich_thong_tin_chung.Add("PHÓ PHÒNG");

                this.nguon_thong_tin_chung.Add("<HDV_TEN_PHONG_TIN_DUNG>");
                this.dich_thong_tin_chung.Add("PHÒNG KHÁCH HÀNG DOANH NGHIỆP");
            }
            else
            {
                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG>");
                this.dich_thong_tin_chung.Add(kiem_soat_tin_dung.chuc_vu);

                this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG_VIET_HOA>");
                this.dich_thong_tin_chung.Add(kiem_soat_tin_dung.chuc_vu.ToUpper());

                this.nguon_thong_tin_chung.Add("<HDV_TEN_PHONG_TIN_DUNG>");
                this.dich_thong_tin_chung.Add(phong_giao_dich.ten_pgd.ToUpper());
            }            

            //this.nguon_thong_tin_chung.Add("<HDV_TEN_PHONG_TIN_DUNG>");
            //this.dich_thong_tin_chung.Add(kiem_soat_tin_dung.chuc_vu.Substring(7,kiem_soat_tin_dung.chuc_vu.Length-7).ToUpper());

            //Thông tin cán bộ tín dụng
            this.nguon_thong_tin_chung.Add("<HDV_CAN_BO_TIN_DUNG>");
            Canbotindung can_bo_tin_dung = cbbus.CBTD_theo_ten_dang_nhap(hd.can_bo_tin_dung);
            this.dich_thong_tin_chung.Add(can_bo_tin_dung.ho_ten);

            this.nguon_thong_tin_chung.Add("<HDV_DANH_XUNG_CAN_BO_TIN_DUNG>");
            this.dich_thong_tin_chung.Add(can_bo_tin_dung.danh_xung);

            this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_CAN_BO_TIN_DUNG>");
            //this.dich_thong_tin_chung.Add(can_bo_tin_dung.chuc_vu);
            this.dich_thong_tin_chung.Add("Cán bộ TĐ & QLKV");

            this.nguon_thong_tin_chung.Add("<HDV_DIEN_THOAI_CAN_BO_TIN_DUNG>");
            this.dich_thong_tin_chung.Add(can_bo_tin_dung.dien_thoai);

            //Lấy tên phòng ban
            if (can_bo_tin_dung.ma_pb == "2300-KHDN")
            {
                this.nguon_thong_tin_chung.Add("<TEN_PHONG_HS>");
                this.dich_thong_tin_chung.Add("Phòng Khách hàng Doanh nghiệp");
            }
            else if (can_bo_tin_dung.ma_pb == "2300-KHHSXCN")
            {
                this.nguon_thong_tin_chung.Add("<TEN_PHONG_HS>");
                this.dich_thong_tin_chung.Add("Phòng Khách hàng Hộ sản xuất và cá nhân");
            }
            else
            {
                this.nguon_thong_tin_chung.Add("<TEN_PHONG_HS>");
                this.dich_thong_tin_chung.Add("Phòng Kế hoạch và Kinh doanh");
            }
            //Lấy tên đề nghị thế chấp tài sản bảo đảm
            #region Lay ten de nghi the chap tai san bao dam
            //------------------------Lấy tên đề nghị thế chấp tài sản bảo đảm--------------------------------------
            if (can_bo_tin_dung.ma_pgd.Substring(5) == "00")
            {
                txtDe_nghi_the_chap_TSBD.Text = "HS_DNTC_TSBD";
            }
            else
            {
                txtDe_nghi_the_chap_TSBD.Text = "PGD_DNTC_TSBD";
            }
            //------------------------------------------------------------------------------------------------------
            #endregion
            
            this.nguon_thong_tin_chung.Add("<HDV_MA_HD_VAY>");
            this.dich_thong_tin_chung.Add(hd.ma_hd_vay);

            this.nguon_thong_tin_chung.Add("<HDV_MA_CN>");
            this.dich_thong_tin_chung.Add(hd.ma_cn);

            this.nguon_thong_tin_chung.Add("<HDV_MA_KH_VAY>");
            this.dich_thong_tin_chung.Add(hd.ma_kh_vay);

            this.nguon_thong_tin_chung.Add("<HDV_PHUONG_THUC>");
            this.dich_thong_tin_chung.Add(hd.phuong_thuc);

            this.nguon_thong_tin_chung.Add("<HDV_TONG_HAN_MUC_TIN_DUNG>");
            //this.dich_thong_tin_chung.Add(Convert.ToString(hd.tong_han_muc_tin_dung));
            this.dich_thong_tin_chung.Add(ControlFormat.ToFormatPrice(hd.tong_han_muc_tin_dung));
            tong_han_muc_tin_dung = hd.tong_han_muc_tin_dung;

            this.nguon_thong_tin_chung.Add("<HDV_TONG_HAN_MUC_TIN_DUNG_BANG_CHU>");
            this.dich_thong_tin_chung.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(hd.tong_han_muc_tin_dung))));

            this.nguon_thong_tin_chung.Add("<HDV_HAN_MUC_TIN_DUNG>");
            this.dich_thong_tin_chung.Add(ControlFormat.ToFormatPrice(hd.han_muc_tin_dung));

            this.nguon_thong_tin_chung.Add("<HDV_HAN_MUC_TIN_DUNG_BANG_CHU>");
            this.dich_thong_tin_chung.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(hd.han_muc_tin_dung))));

            this.nguon_thong_tin_chung.Add("<HDV_HAN_MUC_BAO_LANH>");
            this.dich_thong_tin_chung.Add(ControlFormat.ToFormatPrice(hd.han_muc_bao_lanh));

            this.nguon_thong_tin_chung.Add("<HDV_HAN_MUC_BAO_LANH_BANG_CHU>");
            this.dich_thong_tin_chung.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(hd.han_muc_bao_lanh))));

            this.nguon_thong_tin_chung.Add("<HDV_MUC_DICH_VAY>");
            this.dich_thong_tin_chung.Add(hd.muc_dich_vay);

            this.nguon_thong_tin_chung.Add("<HDV_LAI_SUAT>");
            this.dich_thong_tin_chung.Add(hd.lai_suat);

            this.nguon_thong_tin_chung.Add("<HDV_PHUONG_THUC_TRA_LAI>");
            this.dich_thong_tin_chung.Add(hd.phuong_thuc_tra_lai);

            this.nguon_thong_tin_chung.Add("<HDV_PHUONG_THUC_TRA_GOC>");
            this.dich_thong_tin_chung.Add(hd.phuong_thuc_tra_goc);

            this.nguon_thong_tin_chung.Add("<HDV_THOI_HAN_VAY>");
            this.dich_thong_tin_chung.Add(hd.thoi_han_vay);

            this.nguon_thong_tin_chung.Add("<HDV_HAN_TRA_NO_CUOI>");
            this.dich_thong_tin_chung.Add(hd.han_tra_no_cuoi);

            this.nguon_thong_tin_chung.Add("<HDV_THOI_HAN_RUT_VON>");
            this.dich_thong_tin_chung.Add(hd.thoi_han_rut_von);

            if (!string.IsNullOrEmpty(hd.thoi_gian_an_han))
            {
                this.nguon_thong_tin_chung.Add("<HDV_THOI_GIAN_AN_HAN>");
                this.dich_thong_tin_chung.Add("- Thời gian ân hạn: " + hd.thoi_gian_an_han + ">.");
            }
            else
            {
                this.nguon_thong_tin_chung.Add("<HDV_THOI_GIAN_AN_HAN>");
            this.dich_thong_tin_chung.Add("");
            }

            this.nguon_thong_tin_chung.Add("<HDV_BAO_DAM_TIEN_VAY>");
            this.dich_thong_tin_chung.Add(hd.bao_dam_tien_vay);

            this.nguon_thong_tin_chung.Add("<HDV_HINH_THUC_BAO_DAM>");
            this.dich_thong_tin_chung.Add(hd.hinh_thuc_bao_dam);

            this.nguon_thong_tin_chung.Add("<HDV_TAI_SAN_BAO_DAM>");
            this.dich_thong_tin_chung.Add(hd.tai_san_bao_dam);

            this.nguon_thong_tin_chung.Add("<HDV_GIA_TRI_TAI_SAN_BAO_DAM>");
            this.dich_thong_tin_chung.Add(ControlFormat.ToFormatPrice(hd.gia_tri_tai_san_bao_dam));

            this.nguon_thong_tin_chung.Add("<HDV_GIA_TRI_TAI_SAN_BAO_DAM_BANG_CHU>");
            this.dich_thong_tin_chung.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(hd.gia_tri_tai_san_bao_dam))));

            //Liệt kê các hợp đồng thế chấp            
            if (string.IsNullOrEmpty(hd.ma_hd_vay_cu)) //Hợp đồng vay mới
            {
                DataTable DS_TSTC = TaisanthechapBUS.DS_TSTC(hd.ma_hd_vay);
                if (DS_TSTC.Rows.Count > 0)
                {
                    string hdv_hop_dong_the_chap = "";
                    if (DS_TSTC.Rows.Count > 1)
                    {
                        foreach (DataRow tstc_row in DS_TSTC.Rows)
                        {
                            //string ma_ts_the_chap = Convert.ToString(row["MA_TS_THE_CHAP"]);
                            hdv_hop_dong_the_chap = hdv_hop_dong_the_chap + "Hợp đồng bảo đảm số " + hd.ma_hd_vay + "-" + Convert.ToString(DS_TSTC.Rows.IndexOf(tstc_row)) + "/HĐTC, ";
                        }
                        hdv_hop_dong_the_chap = hdv_hop_dong_the_chap.Substring(0, hdv_hop_dong_the_chap.Length - 2);
                    }
                    else
                    {
                        hdv_hop_dong_the_chap = hdv_hop_dong_the_chap + "Hợp đồng bảo đảm số " + hd.ma_hd_vay + "/HĐTC, ";
                        hdv_hop_dong_the_chap = hdv_hop_dong_the_chap.Substring(0, hdv_hop_dong_the_chap.Length - 2);
                    }
                    this.nguon_thong_tin_chung.Add("<HDV_HOP_DONG_THE_CHAP>");
                    this.dich_thong_tin_chung.Add(hdv_hop_dong_the_chap);
                }
                else
                {
                    this.nguon_thong_tin_chung.Add("<HDV_HOP_DONG_THE_CHAP>");
                    this.dich_thong_tin_chung.Add("");
                }
            }
            else //---------Hợp đồng vay mới thay thế cho hợp đồng cũ
            {
                DataTable DS_TSTC = TaisanthechapBUS.DS_TSTC(hd.ma_hd_vay);
                if (DS_TSTC.Rows.Count > 0) //Hợp đồng vay mới có tài sản thế chấp mới
                {
                    string hdv_hop_dong_the_chap = "";
                    if (DS_TSTC.Rows.Count > 1)
                    {
                        foreach (DataRow tstc_row in DS_TSTC.Rows)
                        {
                            //string ma_ts_the_chap = Convert.ToString(row["MA_TS_THE_CHAP"]);
                            hdv_hop_dong_the_chap = hdv_hop_dong_the_chap + "Hợp đồng bảo đảm số " + hd.ma_hd_vay + "-" + Convert.ToString(DS_TSTC.Rows.IndexOf(tstc_row)) + "/HĐTC, ";
                        }
                        hdv_hop_dong_the_chap = hdv_hop_dong_the_chap.Substring(0, hdv_hop_dong_the_chap.Length - 2);
                    }
                    else
                    {
                        hdv_hop_dong_the_chap = hdv_hop_dong_the_chap + "Hợp đồng bảo đảm số " + hd.ma_hd_vay + "/HĐTC, ";
                        hdv_hop_dong_the_chap = hdv_hop_dong_the_chap.Substring(0, hdv_hop_dong_the_chap.Length - 2);
                    }
                    this.nguon_thong_tin_chung.Add("<HDV_HOP_DONG_THE_CHAP>");
                    this.dich_thong_tin_chung.Add(hdv_hop_dong_the_chap);
                }
                else  //Hợp đồng vay mới sử dụng tài sản thế chấp từ hợp đồng vay cũ
                {
                    DataTable DS_TSTC_CU = TaisanthechapBUS.DS_TSTC(hd.ma_hd_vay_cu);
                    if (DS_TSTC_CU.Rows.Count > 0)
                    {
                        string hdv_hop_dong_the_chap = "";
                        if (DS_TSTC_CU.Rows.Count > 1 )
                        {
                            foreach (DataRow tstc_row in DS_TSTC_CU.Rows)
                            {
                                hdv_hop_dong_the_chap = hdv_hop_dong_the_chap + "Hợp đồng bảo đảm số " + hd.ma_hd_vay_cu + "-" + Convert.ToString(DS_TSTC.Rows.IndexOf(tstc_row)) + "/HĐTC, ";
                            }
                            hdv_hop_dong_the_chap = hdv_hop_dong_the_chap.Substring(0, hdv_hop_dong_the_chap.Length - 2);
                        }
                        else
                        {
                            hdv_hop_dong_the_chap = hdv_hop_dong_the_chap + "Hợp đồng bảo đảm số " + hd.ma_hd_vay_cu + "/HĐTC, ";
                            hdv_hop_dong_the_chap = hdv_hop_dong_the_chap.Substring(0, hdv_hop_dong_the_chap.Length - 2);
                        }
                        this.nguon_thong_tin_chung.Add("<HDV_HOP_DONG_THE_CHAP>");
                        this.dich_thong_tin_chung.Add(hdv_hop_dong_the_chap);
                    }
                    else
                    {
                        this.nguon_thong_tin_chung.Add("<HDV_HOP_DONG_THE_CHAP>");
                        this.dich_thong_tin_chung.Add("");
                    }                    
                }
            }
            
            //----------------------------------------------------------------------------------------
            if (hd.ma_hd_vay_cu == "")
            {
                this.nguon_thong_tin_chung.Add("<HDV_HD_VAY_CU>");
                this.dich_thong_tin_chung.Add("");
            }
            else
            {
                this.nguon_thong_tin_chung.Add("<HDV_HD_VAY_CU>");
                this.dich_thong_tin_chung.Add("Toàn bộ dư nợ của hợp đồng tín dụng số "+hd.ma_hd_vay_cu+" ngày "+hd.ngay_hd_vay_cu+" được chuyển sang theo dõi tại hợp đồng tín dụng này.");
            }

            //IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            //DateTime dt = DateTime.Parse(hd.ngay_hd_vay, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            //this.nguon_thong_tin_chung.Add("<HDV_NGAY>");
            //this.dich_thong_tin_chung.Add(Convert.ToString(dt.Day));

            //this.nguon_thong_tin_chung.Add("<HDV_THANG>");
            //this.dich_thong_tin_chung.Add(Convert.ToString(dt.Month));

            //this.nguon_thong_tin_chung.Add("<HDV_NAM>");
            //this.dich_thong_tin_chung.Add(Convert.ToString(dt.Year));

            //Thông tin về khách hàng vay
            DataTable ds_kh_vay_theo_ma = AGRIBANKHD.BUS.KhachhangvayBUS.DS_KH_VAY_THEO_MA(hd.ma_kh_vay);
            DataRow row = ds_kh_vay_theo_ma.Rows[0];
            Khachhangvay khv = new Khachhangvay(row);
            this.nguon_thong_tin_chung.Add("<KHV_MA_KH_VAY>");
            this.dich_thong_tin_chung.Add(khv.ma_kh_vay);

            this.nguon_thong_tin_chung.Add("<KHV_LOAI_KH>");
            this.dich_thong_tin_chung.Add(khv.loai_kh);

            this.nguon_thong_tin_chung.Add("<KHV_MA_CN>");
            this.dich_thong_tin_chung.Add(khv.ma_cn);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_TEN_CHONG>");
            this.dich_thong_tin_chung.Add(khv.hgd_ten_chong);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_NS_CHONG>");
            this.dich_thong_tin_chung.Add(khv.hgd_ns_chong);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_CMND_CHONG>");
            this.dich_thong_tin_chung.Add(khv.hgd_cmnd_chong);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_NGAY_CAP_CMND_CHONG>");
            this.dich_thong_tin_chung.Add(khv.hgd_ngay_cap_cmnd_chong);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_NOI_CAP_CMND_CHONG>");
            this.dich_thong_tin_chung.Add(khv.hgd_noi_cap_cmnd_chong);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_DC_CHONG>");
            this.dich_thong_tin_chung.Add(khv.hgd_dc_chong);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_HKTT_CHONG>");
            this.dich_thong_tin_chung.Add(khv.hgd_hktt_chong);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_SO_HK_CHONG>");
            this.dich_thong_tin_chung.Add(khv.hgd_so_hk_chong);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_NOI_CAP_HK_CHONG>");
            this.dich_thong_tin_chung.Add(khv.hgd_noi_cap_hk_chong);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_NGAY_CAP_HK_CHONG>");
            this.dich_thong_tin_chung.Add(khv.hgd_ngay_cap_hk_chong);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_TEN_VO>");
            this.dich_thong_tin_chung.Add(khv.hgd_ten_vo);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_NS_VO>");
            this.dich_thong_tin_chung.Add(khv.hgd_ns_vo);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_CMND_VO>");
            this.dich_thong_tin_chung.Add(khv.hgd_cmnd_vo);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_NGAY_CAP_CMND_VO>");
            this.dich_thong_tin_chung.Add(khv.hgd_ngay_cap_cmnd_vo);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_NOI_CAP_CMND_VO>");
            this.dich_thong_tin_chung.Add(khv.hgd_noi_cap_cmnd_vo);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_DC_VO>");
            this.dich_thong_tin_chung.Add(khv.hgd_dc_vo);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_HKTT_VO>");
            this.dich_thong_tin_chung.Add(khv.hgd_hktt_vo);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_SO_HK_VO>");
            this.dich_thong_tin_chung.Add(khv.hgd_so_hk_vo);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_NOI_CAP_HK_VO>");
            this.dich_thong_tin_chung.Add(khv.hgd_noi_cap_hk_vo);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_NGAY_CAP_HK_VO>");
            this.dich_thong_tin_chung.Add(khv.hgd_ngay_cap_hk_vo);

            if (khv.hgd_dai_dien == "Chồng")
            {
                this.nguon_thong_tin_chung.Add("<KHV_HGD_DAI_DIEN>");
                this.dich_thong_tin_chung.Add("ông " + khv.hgd_ten_chong);

                this.nguon_thong_tin_chung.Add("<KHV_HGD_DAI_DIEN_CMND>");
                this.dich_thong_tin_chung.Add(khv.hgd_cmnd_chong);
            }
            else if (khv.hgd_dai_dien == "Vợ")
            {
                this.nguon_thong_tin_chung.Add("<KHV_HGD_DAI_DIEN>");
                this.dich_thong_tin_chung.Add("bà " + khv.hgd_ten_vo);

                this.nguon_thong_tin_chung.Add("<KHV_HGD_DAI_DIEN_CMND>");
                this.dich_thong_tin_chung.Add(khv.hgd_cmnd_vo);
            }

            if (khv.hgd_dkkd == "")
            {
                this.nguon_thong_tin_chung.Add("<KHV_HGD_DKKD>");
                this.dich_thong_tin_chung.Add(khv.hgd_dkkd);
            }
            else
            {
                this.nguon_thong_tin_chung.Add("<KHV_HGD_DKKD>");
                this.dich_thong_tin_chung.Add(khv.hgd_dkkd + ".");
            }

            this.nguon_thong_tin_chung.Add("<KHV_HGD_DIEN_THOAI>");
            this.dich_thong_tin_chung.Add(khv.hgd_dien_thoai);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_FAX>");
            this.dich_thong_tin_chung.Add(khv.hgd_fax);

            this.nguon_thong_tin_chung.Add("<KHV_HGD_EMAIL>");
            this.dich_thong_tin_chung.Add(khv.hgd_email);

            this.nguon_thong_tin_chung.Add("<KHV_CN_DANH_XUNG>");
            this.dich_thong_tin_chung.Add(khv.cn_danh_xung);

            this.nguon_thong_tin_chung.Add("<KHV_CN_TEN>");
            this.dich_thong_tin_chung.Add(khv.cn_ten);

            this.nguon_thong_tin_chung.Add("<KHV_CN_NS>");
            this.dich_thong_tin_chung.Add(khv.cn_ns);

            this.nguon_thong_tin_chung.Add("<KHV_CN_CMND>");
            this.dich_thong_tin_chung.Add(khv.cn_cmnd);

            this.nguon_thong_tin_chung.Add("<KHV_CN_NGAY_CAP_CMND>");
            this.dich_thong_tin_chung.Add(khv.cn_ngay_cap_cmnd);

            this.nguon_thong_tin_chung.Add("<KHV_CN_NOI_CAP_CMND>");
            this.dich_thong_tin_chung.Add(khv.cn_noi_cap_cmnd);

            this.nguon_thong_tin_chung.Add("<KHV_CN_DC>");
            this.dich_thong_tin_chung.Add(khv.cn_dc);

            this.nguon_thong_tin_chung.Add("<KHV_CN_HKTT>");
            this.dich_thong_tin_chung.Add(khv.cn_hktt);

            this.nguon_thong_tin_chung.Add("<KHV_CN_SO_HK>");
            this.dich_thong_tin_chung.Add(khv.cn_so_hk);

            this.nguon_thong_tin_chung.Add("<KHV_CN_NOI_CAP_HK>");
            this.dich_thong_tin_chung.Add(khv.cn_noi_cap_hk);

            this.nguon_thong_tin_chung.Add("<KHV_CN_NGAY_CAP_HK>");
            this.dich_thong_tin_chung.Add(khv.cn_ngay_cap_hk);

            if (khv.cn_dkkd == "")
            {
                this.nguon_thong_tin_chung.Add("<KHV_CN_DKKD>");
                this.dich_thong_tin_chung.Add(khv.cn_dkkd);
            }
            else
            {
                this.nguon_thong_tin_chung.Add("<KHV_CN_DKKD>");
                this.dich_thong_tin_chung.Add(khv.cn_dkkd + ".");
            }

            this.nguon_thong_tin_chung.Add("<KHV_CN_DIEN_THOAI>");
            this.dich_thong_tin_chung.Add(khv.cn_dien_thoai);

            this.nguon_thong_tin_chung.Add("<KHV_CN_FAX>");
            this.dich_thong_tin_chung.Add(khv.cn_fax);

            this.nguon_thong_tin_chung.Add("<KHV_CN_EMAIL>");
            this.dich_thong_tin_chung.Add(khv.cn_email);

            this.nguon_thong_tin_chung.Add("<KHV_TC_TEN>");
            this.dich_thong_tin_chung.Add(khv.tc_ten);

            this.nguon_thong_tin_chung.Add("<KHV_TC_DKKD>");
            this.dich_thong_tin_chung.Add(khv.tc_dkkd);

            this.nguon_thong_tin_chung.Add("<KHV_TC_DC>");
            this.dich_thong_tin_chung.Add(khv.tc_dc);

            this.nguon_thong_tin_chung.Add("<KHV_TC_DANH_XUNG_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_danh_xung_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_NS_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_ns_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_CHUC_VU_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_chuc_vu_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_GIAY_UY_QUYEN>");
            this.dich_thong_tin_chung.Add(khv.tc_giay_uy_quyen);

            this.nguon_thong_tin_chung.Add("<KHV_TC_DC_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_dc_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_CMND_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_cmnd_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_NGAY_CAP_CMND_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_ngay_cap_cmnd_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_NOI_CAP_CMND_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_noi_cap_cmnd_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_HKTT_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_hktt_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_SO_HK_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_so_hk_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_NOI_CAP_HK_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_noi_cap_hk_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_NGAY_CAP_HK_DAI_DIEN>");
            this.dich_thong_tin_chung.Add(khv.tc_ngay_cap_hk_dai_dien);

            this.nguon_thong_tin_chung.Add("<KHV_TC_DIEN_THOAI>");
            this.dich_thong_tin_chung.Add(khv.tc_dien_thoai);

            this.nguon_thong_tin_chung.Add("<KHV_TC_FAX>");
            this.dich_thong_tin_chung.Add(khv.tc_fax);

            this.nguon_thong_tin_chung.Add("<KHV_TC_EMAIL>");
            this.dich_thong_tin_chung.Add(khv.tc_email);

            //----------------------Khai báo tên viết tắt của khách hàng vay--------------------------------------
            if (khv.loai_kh == "Cá nhân")
            {
                this.nguon_thong_tin_chung.Add("<KHV_TEN_VIET_TAT>");
                this.dich_thong_tin_chung.Add("Bên vay");
            }
            else if (khv.loai_kh == "Hộ gia đình")
            {
                this.nguon_thong_tin_chung.Add("<KHV_TEN_VIET_TAT>");
                this.dich_thong_tin_chung.Add("Bên vay");
            }
            else
            {
                this.nguon_thong_tin_chung.Add("<KHV_TEN_VIET_TAT>");
                this.dich_thong_tin_chung.Add(khv.tc_ten_viet_tat);
            }
            //----------------------------------------------------------------------------------------------------
            //----------------------Khai báo tên khách hàng trong đề nghị thế chấp tài sản bảo đảm-----------------
            if (!string.IsNullOrEmpty(khv.hgd_ten_chong) && string.IsNullOrEmpty(khv.cn_ten) && string.IsNullOrEmpty(khv.tc_ten))
            {
                if (khv.hgd_dai_dien == "Chồng")
                {
                    this.nguon_thong_tin_chung.Add("<DNTC_KHV>");
                    this.dich_thong_tin_chung.Add(khv.hgd_ten_chong);
                }
                else
                {
                    this.nguon_thong_tin_chung.Add("<DNTC_KHV>");
                    this.dich_thong_tin_chung.Add(khv.hgd_ten_vo);
                }
            }
            else if (string.IsNullOrEmpty(khv.hgd_ten_chong) && !string.IsNullOrEmpty(khv.cn_ten) && string.IsNullOrEmpty(khv.tc_ten))
            {
                this.nguon_thong_tin_chung.Add("<DNTC_KHV>");
                this.dich_thong_tin_chung.Add(khv.cn_ten);
            }
            else if (string.IsNullOrEmpty(khv.hgd_ten_chong) && string.IsNullOrEmpty(khv.cn_ten) && !string.IsNullOrEmpty(khv.tc_ten))
            {
                this.nguon_thong_tin_chung.Add("<DNTC_KHV>");
                this.dich_thong_tin_chung.Add(khv.tc_ten);
            }
            //----------------------------------------------------------------------------------------------------

        }
        #endregion

        //Lấy thông tin về tài sản thế chấp
        internal void Lay_thong_tin_tstc(int ma_ts_the_chap, int tstc_selectedrowindex)
        {
            this.nguon_tstc.Clear();
            this.dich_tstc.Clear();

            Taisanthechap tstc = AGRIBANKHD.BUS.TaisanthechapBUS.TSTC_THEO_MA_TSTC(ma_ts_the_chap);

            //this.nguon_tstc.Add("<TSTC_MA_TS_THE_CHAP>");
            //this.dich_tstc.Add(tstc.ma_ts_the_chap);

            DataTable DS_TSTC = TaisanthechapBUS.DS_TSTC(tstc.ma_hd_vay);
            if (DS_TSTC.Rows.Count > 1)
            {
                this.nguon_tstc.Add("<TSTC_MA_HD_THE_CHAP>");
                this.dich_tstc.Add(tstc.ma_hd_vay + "-" + Convert.ToString(tstc_selectedrowindex));
            }
            else
            {
                this.nguon_tstc.Add("<TSTC_MA_HD_THE_CHAP>");
                this.dich_tstc.Add(tstc.ma_hd_vay);
                //this.dich_tstc.Add(tstc.ma_hd_vay);
            }
            this.nguon_tstc.Add("<TSTC_MA_HD_VAY>");
            this.dich_tstc.Add(tstc.ma_hd_vay);

            this.nguon_tstc.Add("<TSTC_LOAI_CHU_SO_HUU>");
            this.dich_tstc.Add(tstc.loai_chu_so_huu);

            this.nguon_tstc.Add("<TSTC_LOAI_TS_THE_CHAP>");
            this.dich_tstc.Add(tstc.loai_ts_the_chap);

            this.nguon_tstc.Add("<TSTC_HINH_THUC_SO_HUU_CUA_KH_VAY>");
            this.dich_tstc.Add(tstc.hinh_thuc_so_huu_cua_kh_vay);

            #region Thong_tin_ho_gia_dinh
            //-----------Thông tin hộ gia đình---------------------------------------

            this.nguon_tstc.Add("<TSTC_HGD_TEN_CHONG>");
            this.dich_tstc.Add(tstc.hgd_ten_chong);

            this.nguon_tstc.Add("<TSTC_HGD_TEN_CHONG_VIET_HOA>");
            this.dich_tstc.Add(tstc.hgd_ten_chong.ToUpper());

            this.nguon_tstc.Add("<TSTC_HGD_NS_CHONG>");
            this.dich_tstc.Add(tstc.hgd_ns_chong);

            this.nguon_tstc.Add("<TSTC_HGD_CMND_CHONG>");
            this.dich_tstc.Add(tstc.hgd_cmnd_chong);

            this.nguon_tstc.Add("<TSTC_HGD_NGAY_CAP_CMND_CHONG>");
            this.dich_tstc.Add(tstc.hgd_ngay_cap_cmnd_chong);

            this.nguon_tstc.Add("<TSTC_HGD_NOI_CAP_CMND_CHONG>");
            this.dich_tstc.Add(tstc.hgd_noi_cap_cmnd_chong);

            this.nguon_tstc.Add("<TSTC_HGD_DC_CHONG>");
            this.dich_tstc.Add(tstc.hgd_dc_chong);

            this.nguon_tstc.Add("<TSTC_HGD_HKTT_CHONG>");
            this.dich_tstc.Add(tstc.hgd_hktt_chong);

            this.nguon_tstc.Add("<TSTC_HGD_SO_HK_CHONG>");
            this.dich_tstc.Add(tstc.hgd_so_hk_chong);

            this.nguon_tstc.Add("<TSTC_HGD_NOI_CAP_HK_CHONG>");
            this.dich_tstc.Add(tstc.hgd_noi_cap_hk_chong);

            this.nguon_tstc.Add("<TSTC_HGD_NGAY_CAP_HK_CHONG>");
            this.dich_tstc.Add(tstc.hgd_ngay_cap_hk_chong);

            this.nguon_tstc.Add("<TSTC_HGD_TEN_VO>");
            this.dich_tstc.Add(tstc.hgd_ten_vo);

            this.nguon_tstc.Add("<TSTC_HGD_TEN_VO_VIET_HOA>");
            this.dich_tstc.Add(tstc.hgd_ten_vo.ToUpper());

            this.nguon_tstc.Add("<TSTC_HGD_NS_VO>");
            this.dich_tstc.Add(tstc.hgd_ns_vo);

            this.nguon_tstc.Add("<TSTC_HGD_CMND_VO>");
            this.dich_tstc.Add(tstc.hgd_cmnd_vo);

            this.nguon_tstc.Add("<TSTC_HGD_NGAY_CAP_CMND_VO>");
            this.dich_tstc.Add(tstc.hgd_ngay_cap_cmnd_vo);

            this.nguon_tstc.Add("<TSTC_HGD_NOI_CAP_CMND_VO>");
            this.dich_tstc.Add(tstc.hgd_noi_cap_cmnd_vo);

            this.nguon_tstc.Add("<TSTC_HGD_DC_VO>");
            this.dich_tstc.Add(tstc.hgd_dc_vo);

            this.nguon_tstc.Add("<TSTC_HGD_HKTT_VO>");
            this.dich_tstc.Add(tstc.hgd_hktt_vo);

            this.nguon_tstc.Add("<TSTC_HGD_SO_HK_VO>");
            this.dich_tstc.Add(tstc.hgd_so_hk_vo);

            this.nguon_tstc.Add("<TSTC_HGD_NOI_CAP_HK_VO>");
            this.dich_tstc.Add(tstc.hgd_noi_cap_hk_vo);

            this.nguon_tstc.Add("<TSTC_HGD_NGAY_CAP_HK_VO>");
            this.dich_tstc.Add(tstc.hgd_ngay_cap_hk_vo);

            this.nguon_tstc.Add("<TSTC_HGD_DKKD>");
            this.dich_tstc.Add(tstc.hgd_dkkd);

            this.nguon_tstc.Add("<TSTC_HGD_DIEN_THOAI>");
            this.dich_tstc.Add(tstc.hgd_dien_thoai);

            this.nguon_tstc.Add("<TSTC_HGD_FAX>");
            this.dich_tstc.Add(tstc.hgd_fax);

            this.nguon_tstc.Add("<TSTC_HGD_EMAIL>");
            this.dich_tstc.Add(tstc.hgd_email);

            this.nguon_tstc.Add("<TSTC_HGD_DAI_DIEN>");
            this.dich_tstc.Add(tstc.hgd_dai_dien);

            this.nguon_tstc.Add("<TSTC_HGD_NGUOI_SO_HUU>");
            this.dich_tstc.Add(tstc.hgd_nguoi_so_huu);

            //----------------------Thông tin trong hợp đồng thế chấp chính chủ--------------------------
            if (!string.IsNullOrEmpty(tstc.hgd_ten_chong))
            {
                this.nguon_tstc.Add("<TSTC_THONG_TIN_CHONG_1>");
                this.dich_tstc.Add("Ông " + tstc.hgd_ten_chong + "   Năm sinh: " + tstc.hgd_ns_chong + ".");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_CHONG_2>");
                this.dich_tstc.Add("CMTND số: " + tstc.hgd_cmnd_chong + " do " + tstc.hgd_noi_cap_cmnd_chong + " cấp ngày " + tstc.hgd_ngay_cap_cmnd_chong + ".");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_CHONG_3>");
                this.dich_tstc.Add("Hộ khẩu thường trú: " + tstc.hgd_hktt_chong + ".");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_CHONG_4>");
                this.dich_tstc.Add("Địa chỉ liên hệ: " + tstc.hgd_dc_chong + ".");
            }
            else
            {
                this.nguon_tstc.Add("<TSTC_THONG_TIN_CHONG_1>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_CHONG_2>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_CHONG_3>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_CHONG_4>");
                this.dich_tstc.Add("");
            }

            if (!string.IsNullOrEmpty(tstc.hgd_ten_vo))
            {
                this.nguon_tstc.Add("<TSTC_THONG_TIN_VO_1>");
                this.dich_tstc.Add("Bà " + tstc.hgd_ten_vo + "   Năm sinh: " + tstc.hgd_ns_vo + ".");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_VO_2>");
                this.dich_tstc.Add("CMTND số: " + tstc.hgd_cmnd_vo + " do " + tstc.hgd_noi_cap_cmnd_vo + " cấp ngày " + tstc.hgd_ngay_cap_cmnd_vo + ".");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_VO_3>");
                this.dich_tstc.Add("Hộ khẩu thường trú: " + tstc.hgd_hktt_vo + ".");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_VO_4>");
                this.dich_tstc.Add("Địa chỉ liên hệ: " + tstc.hgd_dc_vo + ".");
            }
            else
            {
                this.nguon_tstc.Add("<TSTC_THONG_TIN_VO_1>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_VO_2>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_VO_3>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_THONG_TIN_VO_4>");
                this.dich_tstc.Add("");
            }
            //--------------------------------------------------------------------------------
            #endregion

            #region Thong_tin_ca_nhan
            //----------------------Thông tin cá nhân---------------------------------------
            this.nguon_tstc.Add("<TSTC_CN_DANH_XUNG>");
            this.dich_tstc.Add(tstc.cn_danh_xung);

            this.nguon_tstc.Add("<TSTC_CN_TEN>");
            this.dich_tstc.Add(tstc.cn_ten);

            this.nguon_tstc.Add("<TSTC_CN_TEN_VIET_HOA>");
            this.dich_tstc.Add(tstc.cn_ten.ToUpper());

            this.nguon_tstc.Add("<TSTC_CN_NS>");
            this.dich_tstc.Add(tstc.cn_ns);

            this.nguon_tstc.Add("<TSTC_CN_CMND>");
            this.dich_tstc.Add(tstc.cn_cmnd);

            this.nguon_tstc.Add("<TSTC_CN_NGAY_CAP_CMND>");
            this.dich_tstc.Add(tstc.cn_ngay_cap_cmnd);

            this.nguon_tstc.Add("<TSTC_CN_NOI_CAP_CMND>");
            this.dich_tstc.Add(tstc.cn_noi_cap_cmnd);

            this.nguon_tstc.Add("<TSTC_CN_DC>");
            this.dich_tstc.Add(tstc.cn_dc);

            this.nguon_tstc.Add("<TSTC_CN_HKTT>");
            this.dich_tstc.Add(tstc.cn_hktt);

            this.nguon_tstc.Add("<TSTC_CN_SO_HK>");
            this.dich_tstc.Add(tstc.cn_so_hk);

            this.nguon_tstc.Add("<TSTC_CN_NOI_CAP_HK>");
            this.dich_tstc.Add(tstc.cn_noi_cap_hk);

            this.nguon_tstc.Add("<TSTC_CN_NGAY_CAP_HK>");
            this.dich_tstc.Add(tstc.cn_ngay_cap_hk);

            this.nguon_tstc.Add("<TSTC_CN_DKKD>");
            this.dich_tstc.Add(tstc.cn_dkkd);

            this.nguon_tstc.Add("<TSTC_CN_DIEN_THOAI>");
            this.dich_tstc.Add(tstc.cn_dien_thoai);

            this.nguon_tstc.Add("<TSTC_CN_FAX>");
            this.dich_tstc.Add(tstc.cn_fax);

            this.nguon_tstc.Add("<TSTC_CN_EMAIL>");
            this.dich_tstc.Add(tstc.cn_email);

            //--------------------------------------------------------------------------------------
            #endregion

            #region Thong_tin_to_chuc
            //-------------------------Thông tin tổ chức-------------------------------------------

            this.nguon_tstc.Add("<TSTC_TC_TEN>");
            this.dich_tstc.Add(tstc.tc_ten);

            this.nguon_tstc.Add("<TSTC_TC_TEN_VIET_HOA>");
            this.dich_tstc.Add(tstc.tc_ten.ToUpper());

            this.nguon_tstc.Add("<TSTC_TC_DKKD>");
            this.dich_tstc.Add(tstc.tc_dkkd);

            this.nguon_tstc.Add("<TSTC_TC_DC>");
            this.dich_tstc.Add(tstc.tc_dc);

            this.nguon_tstc.Add("<TSTC_TC_DANH_XUNG_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_danh_xung_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_NS_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_ns_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_CHUC_VU_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_chuc_vu_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_GIAY_UY_QUYEN>");
            this.dich_tstc.Add(tstc.tc_giay_uy_quyen);

            this.nguon_tstc.Add("<TSTC_TC_DC_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_dc_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_CMND_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_cmnd_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_NGAY_CAP_CMND_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_ngay_cap_cmnd_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_NOI_CAP_CMND_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_noi_cap_cmnd_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_HKTT_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_hktt_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_SO_HK_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_so_hk_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_NOI_CAP_HK_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_noi_cap_hk_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_NGAY_CAP_HK_DAI_DIEN>");
            this.dich_tstc.Add(tstc.tc_ngay_cap_hk_dai_dien);

            this.nguon_tstc.Add("<TSTC_TC_DIEN_THOAI>");
            this.dich_tstc.Add(tstc.tc_dien_thoai);

            this.nguon_tstc.Add("<TSTC_TC_FAX>");
            this.dich_tstc.Add(tstc.tc_fax);

            this.nguon_tstc.Add("<TSTC_TC_EMAIL>");
            this.dich_tstc.Add(tstc.tc_email);

            //------------------------------------------------------------------------
            #endregion
            
            #region Dong_san
            this.nguon_tstc.Add("<TSTC_DS_TEN>");
            this.dich_tstc.Add(tstc.ds_ten);

            this.nguon_tstc.Add("<TSTC_DS_NHAN_HIEU>");
            this.dich_tstc.Add(tstc.ds_nhan_hieu);

            //-----------------------------------Thông tin về động sản---------------------------
            this.nguon_tstc.Add("<TSTC_DS_THONG_TIN_CHUNG_RTF>");
            this.dich_tstc.Add(tstc.ds_thong_tin_chung_rtf);

            this.nguon_tstc.Add("<TSTC_DS_THONG_TIN_CHUNG>");
            this.dich_tstc.Add(tstc.ds_thong_tin_chung);

            if (!string.IsNullOrEmpty(tstc.ds_thong_tin_chung))
            {
                string[] tstc_ds_thong_tin_chung = tstc.ds_thong_tin_chung.Split(new[] { "\n" }, StringSplitOptions.None);
                for (int i = 0; i <= tstc_ds_thong_tin_chung.Length - 1; i++)
                {
                    this.nguon_tstc.Add("<TSTC_DS_THONG_TIN_CHUNG_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add(tstc_ds_thong_tin_chung[i]);

                    this.nguon_tstc.Add("<TSTC_DS_SO_KHUNG>");
                    this.dich_tstc.Add(tstc_ds_thong_tin_chung[5].Substring(12));
                }
            }
            else
            {
                for (int i = 0; i <= 9; i++)
                {
                    this.nguon_tstc.Add("<TSTC_DS_THONG_TIN_CHUNG_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add("");
                }

                this.nguon_tstc.Add("<TSTC_DS_SO_KHUNG>");
                this.dich_tstc.Add("");
            }
            
            

            //-----------------------------------------------------------------------------------------
            this.nguon_tstc.Add("<TSTC_DS_GIAY_TO>");
            this.dich_tstc.Add(tstc.ds_giay_to);

            this.nguon_tstc.Add("<TSTC_DS_GIA_TRI>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.ds_gia_tri));

            this.nguon_tstc.Add("<TSTC_DS_GIA_TRI_BANG_CHU>");
            this.dich_tstc.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.ds_gia_tri))));
            #endregion

            #region Bat_dong_san
            this.nguon_tstc.Add("<TSTC_BDS_TEN>");
            this.dich_tstc.Add(tstc.bds_ten);

            this.nguon_tstc.Add("<TSTC_BDS_TONG_DIEN_TICH>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_tong_dien_tich));

            if ((tstc.bds_tong_dien_tich % 1) == 0)
            {
                this.nguon_tstc.Add("<TSTC_BDS_TONG_DIEN_TICH_BANG_CHU>");
                this.dich_tstc.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString((int)Decimal.ToInt32(tstc.bds_tong_dien_tich)))) + "mét vuông");
            }
            else
            {
                this.nguon_tstc.Add("<TSTC_BDS_TONG_DIEN_TICH_BANG_CHU>");
                this.dich_tstc.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.bds_tong_dien_tich))) + "mét vuông");
            }
            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_QSD_DAT>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat));

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_QSD_DAT_BANG_CHU>");
            this.dich_tstc.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.bds_gia_tri_qsd_dat))));

            this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_DAT_O>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_o));

            if ((tstc.bds_dien_tich_dat_o % 1) == 0)
            {
                this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_DAT_O_BANG_CHU>");
                this.dich_tstc.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString((int)Decimal.ToInt32(tstc.bds_dien_tich_dat_o)))) + "mét vuông");
            }
            else
            {
                this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_DAT_O_BANG_CHU>");
                this.dich_tstc.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.bds_dien_tich_dat_o))) + "mét vuông");
            }

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_QSD_DAT_O_TREN_M2>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_o_tren_m2));

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_QSD_DAT_O>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_o));

            this.nguon_tstc.Add("<TSTC_BDS_DAT_KHAC_1>");
            this.dich_tstc.Add(tstc.bds_dat_khac_1);

            this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_DAT_KHAC_1>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_khac_1));

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_QSD_DAT_KHAC_1_TREN_M2>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_1_tren_m2));

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_QSD_DAT_KHAC_1>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_1));

            this.nguon_tstc.Add("<TSTC_BDS_DAT_KHAC_2>");
            this.dich_tstc.Add(tstc.bds_dat_khac_2);

            this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_DAT_KHAC_2>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_khac_2));

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_QSD_DAT_KHAC_2_TREN_M2>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_2_tren_m2));

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_QSD_DAT_KHAC_2>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_2));

            this.nguon_tstc.Add("<TSTC_BDS_DAT_KHAC_3>");
            this.dich_tstc.Add(tstc.bds_dat_khac_3);

            this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_DAT_KHAC_3>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_khac_3));

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_QSD_DAT_KHAC_3_TREN_M2>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_3_tren_m2));

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_QSD_DAT_KHAC_3>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_3));

            this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_SU_DUNG_RIENG>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_dien_tich_su_dung_rieng));

            this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_SU_DUNG_CHUNG>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_dien_tich_su_dung_chung));

            //--------------------------Thông tin chung về bất động sản-----------------------
            this.nguon_tstc.Add("<TSTC_BDS_THONG_TIN_CHUNG_RTF>");
            this.dich_tstc.Add(tstc.bds_thong_tin_chung_rtf);

            
            this.nguon_tstc.Add("<TSTC_BDS_THONG_TIN_CHUNG>");
            this.dich_tstc.Add(tstc.bds_thong_tin_chung);

            if (!string.IsNullOrEmpty(tstc.bds_thong_tin_chung))
            {
                string[] tstc_bds_thong_tin_chung = tstc.bds_thong_tin_chung.Split(new[] { "\n" }, StringSplitOptions.None);
                this.nguon_tstc.Add("<TSTC_BDS_THONG_TIN_CHUNG_1>");
                this.dich_tstc.Add(tstc_bds_thong_tin_chung[0]);

                this.nguon_tstc.Add("<TSTC_BDS_THONG_TIN_CHUNG_2>");
                this.dich_tstc.Add(tstc_bds_thong_tin_chung[1]);

                this.nguon_tstc.Add("<TSTC_BDS_THONG_TIN_CHUNG_3>");
                this.dich_tstc.Add(tstc_bds_thong_tin_chung[2]);

                this.nguon_tstc.Add("<TSTC_BDS_THONG_TIN_CHUNG_4>");
                this.dich_tstc.Add(tstc_bds_thong_tin_chung[3]);

                this.nguon_tstc.Add("<TSTC_BDS_THONG_TIN_CHUNG_5>");
                this.dich_tstc.Add(tstc_bds_thong_tin_chung[4]);

                this.nguon_tstc.Add("<TSTC_BDS_THONG_TIN_CHUNG_6>");
                this.dich_tstc.Add(tstc_bds_thong_tin_chung[5].Substring(2));

                if (tstc_bds_thong_tin_chung[6] == "- Những hạn chế về quyền sử dụng đất: ")
                {
                    this.nguon_tstc.Add("<TSTC_BDS_THONG_TIN_CHUNG_7>");
                    this.dich_tstc.Add("");
                }
                else
                {
                    this.nguon_tstc.Add("<TSTC_BDS_THONG_TIN_CHUNG_7>");
                    this.dich_tstc.Add(tstc_bds_thong_tin_chung[6]);
                }
            }
            else
            {
                for (int i = 0; i <= 6; i++)
                {
                    this.nguon_tstc.Add("<TSTC_BDS_THONG_TIN_CHUNG_" + Convert.ToString(i+1) + ">");
                    this.dich_tstc.Add("");
                }
            }

            string tstc_bds_dien_tich_chi_tiet = "";
            if (tstc.bds_dien_tich_dat_o != 0)
            {
                tstc_bds_dien_tich_chi_tiet = tstc_bds_dien_tich_chi_tiet + ", Đất ở: " + ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_o) + " m\xB2";
            }
            if (!string.IsNullOrEmpty(tstc.bds_dat_khac_1))
            {
                tstc_bds_dien_tich_chi_tiet = tstc_bds_dien_tich_chi_tiet + ", " + tstc.bds_dat_khac_1 + ": " + ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_khac_1) + " m\xB2";
            }
            if (!string.IsNullOrEmpty(tstc.bds_dat_khac_2))
            {
                tstc_bds_dien_tich_chi_tiet = tstc_bds_dien_tich_chi_tiet + ", " + tstc.bds_dat_khac_2 + ": " + ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_khac_2) + " m\xB2";
            }
            if (!string.IsNullOrEmpty(tstc.bds_dat_khac_3))
            {
                tstc_bds_dien_tich_chi_tiet = tstc_bds_dien_tich_chi_tiet + ", " + tstc.bds_dat_khac_3 + ": " + ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_khac_3) + " m\xB2";
            }
            if (!string.IsNullOrEmpty(tstc_bds_dien_tich_chi_tiet))
            {
                tstc_bds_dien_tich_chi_tiet = tstc_bds_dien_tich_chi_tiet.Substring(2);
            }            
            this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_CHI_TIET>");
            this.dich_tstc.Add(tstc_bds_dien_tich_chi_tiet);

            //------------------------------------------------------------------------------------------
            //------------------------Giấy tờ sở hữu bất động sản-------------------------------------
            this.nguon_tstc.Add("<TSTC_BDS_GIAY_TO_RTF>");
            this.dich_tstc.Add(tstc.bds_giay_to_rtf);

            this.nguon_tstc.Add("<TSTC_BDS_GIAY_TO>");
            this.dich_tstc.Add(tstc.bds_giay_to);

            if (!string.IsNullOrEmpty(tstc.bds_giay_to))
            {
                string[] tstc_bds_giay_to = tstc.bds_giay_to.Split(new[] { "\n" }, StringSplitOptions.None);
                for (int i = 0; i <= tstc_bds_giay_to.Length - 1; i++)
                {
                    this.nguon_tstc.Add("<TSTC_BDS_GIAY_TO_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add(tstc_bds_giay_to[i]);
                }

                for (int i = tstc_bds_giay_to.Length; i <= 4; i++)
                {
                    this.nguon_tstc.Add("<TSTC_BDS_GIAY_TO_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add("");
                }
            }
            else
            {
                for (int i = 0; i <= 4; i++)
                {
                    this.nguon_tstc.Add("<TSTC_BDS_GIAY_TO_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add("");
                }
            }
            //-----------------------------Thông tin chung về bất động sản - tài sản gắn liền nhà-----------------------------------------
            this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_RTF>");
            this.dich_tstc.Add(tstc.bds_nha_thong_tin_chung_rtf);

            this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG>");
            this.dich_tstc.Add(tstc.bds_nha_thong_tin_chung);

            string[] tstc_bds_nha_thong_tin_chung = tstc.bds_nha_thong_tin_chung.Split(new[] { "\n" }, StringSplitOptions.None);

            if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung))
            {
                this.nguon_tstc.Add("<TSTC_BDS_NHA>");
                this.dich_tstc.Add("- Nhà ở");

                if (!string.IsNullOrEmpty(tstc.bds_thong_tin_chung))
                {
                    string[] tstc_bds_thong_tin_chung_1 = tstc.bds_thong_tin_chung.Split(new[] { "\n" }, StringSplitOptions.None);
                    string tstc_dia_chi_nha = tstc_bds_thong_tin_chung_1[2].Remove(tstc_bds_thong_tin_chung_1[2].IndexOf(" thửa đất"), 9);
                    tstc_dia_chi_nha = "+ " + tstc_dia_chi_nha.Substring(2);

                    this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_1>");
                    this.dich_tstc.Add(tstc_dia_chi_nha);
                    //this.dich_tstc.Add(tstc_bds_thong_tin_chung_1[2].Remove(tstc_bds_thong_tin_chung_1[2].IndexOf(" thửa đất"), 9));                    
                }
                else
                {
                    this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_1>");
                    this.dich_tstc.Add("");
                }

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_2>");
                this.dich_tstc.Add(tstc_bds_nha_thong_tin_chung[0].Replace("m2", "m\xB2"));

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_3>");
                this.dich_tstc.Add(tstc_bds_nha_thong_tin_chung[1].Replace("m2","m\xB2"));
                //this.dich_tstc.Add(tstc_bds_nha_thong_tin_chung[1]);

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_4>");
                this.dich_tstc.Add(tstc_bds_nha_thong_tin_chung[2]);
                //this.dich_tstc.Add(tstc_bds_nha_thong_tin_chung[2]);

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_5>");
                this.dich_tstc.Add(tstc_bds_nha_thong_tin_chung[3]);

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_6>");
                this.dich_tstc.Add(tstc_bds_nha_thong_tin_chung[4]);

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_7>");
                this.dich_tstc.Add(tstc_bds_nha_thong_tin_chung[5]);
            }
            else
            {
                this.nguon_tstc.Add("<TSTC_BDS_NHA>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_1>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_2>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_3>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_4>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_5>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_6>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<TSTC_BDS_NHA_THONG_TIN_CHUNG_7>");
                this.dich_tstc.Add("");
            }
            //-----------------------------------------------------------------------------------------------------------

            this.nguon_tstc.Add("<TSTC_BDS_NHA_GIA_TRI>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_nha_gia_tri));

            //------------------Thông tin chung về tài sản gắn liền - công trình xây dựng--------------------------------------------------
            this.nguon_tstc.Add("<TSTC_BDS_CTXD_THONG_TIN_CHUNG_RTF>");
            this.dich_tstc.Add(tstc.bds_ctxd_thong_tin_chung_rtf);

            this.nguon_tstc.Add("<TSTC_BDS_CTXD_THONG_TIN_CHUNG>");
            this.dich_tstc.Add(tstc.bds_ctxd_thong_tin_chung);        

            string[] tstc_bds_ctxd_thong_tin_chung = tstc.bds_ctxd_thong_tin_chung.Split(new[] { "\n" }, StringSplitOptions.None);

            if (!string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung))
            {
                this.nguon_tstc.Add("<TSTC_BDS_CTXD>");
                this.dich_tstc.Add("- Công trình xây dựng");

                for (int i = 0; i <= tstc_bds_ctxd_thong_tin_chung.Length-1; i++)
                {
                    if ( i == 1 )
                    {
                        this.nguon_tstc.Add("<TSTC_BDS_CTXD_THONG_TIN_CHUNG_" + Convert.ToString(i + 1) + ">");
                        this.dich_tstc.Add(tstc_bds_ctxd_thong_tin_chung[i].Replace("m2", "m\xB2"));
                    }
                    else
                    {
                        this.nguon_tstc.Add("<TSTC_BDS_CTXD_THONG_TIN_CHUNG_" + Convert.ToString(i + 1) + ">");
                        this.dich_tstc.Add(tstc_bds_ctxd_thong_tin_chung[i]);
                    }
                }

                for (int i = tstc_bds_ctxd_thong_tin_chung.Length; i <= 5; i++)
                {
                    this.nguon_tstc.Add("<<TSTC_BDS_CTXD_THONG_TIN_CHUNG_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add("");
                }
            }
            else
            {
                this.nguon_tstc.Add("<TSTC_BDS_CTXD>");
                this.dich_tstc.Add("");

                for (int i = 0; i <= 5; i++)
                {
                    this.nguon_tstc.Add("<TSTC_BDS_CTXD_THONG_TIN_CHUNG_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add("");
                }
            }
            //---------------------------------------------------------------------------------------------------------
            this.nguon_tstc.Add("<TSTC_BDS_CTXD_GIA_TRI>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_ctxd_gia_tri));

            //---------------------Thông tin chung về tài sản gắn liền khac --------------------------------------------
            this.nguon_tstc.Add("<TSTC_BDS_TSGL_KHAC_THONG_TIN_CHUNG_RTF>");
            this.dich_tstc.Add(tstc.bds_tsgl_khac_thong_tin_chung_rtf);

            this.nguon_tstc.Add("<TSTC_BDS_TSGL_KHAC_THONG_TIN_CHUNG>");
            this.dich_tstc.Add(tstc.bds_tsgl_khac_thong_tin_chung);

            string[] tstc_bds_tsgl_khac_thong_tin_chung = tstc.bds_tsgl_khac_thong_tin_chung.Split(new[] { "\n" }, StringSplitOptions.None);

            if (!string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
            {
                this.nguon_tstc.Add("<TSTC_BDS_TSGL_KHAC>");
                this.dich_tstc.Add("- Tài sản gắn liền khác");

                for (int i = 0; i <= tstc_bds_tsgl_khac_thong_tin_chung.Length -1; i++)
                {
                    this.nguon_tstc.Add("<TSTC_BDS_TSGL_KHAC_THONG_TIN_CHUNG_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add(tstc_bds_tsgl_khac_thong_tin_chung[i]);
                }

                for (int i = tstc_bds_tsgl_khac_thong_tin_chung.Length ; i <= 5; i++)
                {
                    this.nguon_tstc.Add("<TSTC_BDS_TSGL_KHAC_THONG_TIN_CHUNG_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add("");
                }
            }
            else
            {
                this.nguon_tstc.Add("<TSTC_BDS_TSGL_KHAC>");
                this.dich_tstc.Add("");

                for (int i=0; i<=5; i++)
                {
                    this.nguon_tstc.Add("<TSTC_BDS_TSGL_KHAC_THONG_TIN_CHUNG_" + Convert.ToString(i+1) + ">");
                    this.dich_tstc.Add("");
                }
            }
            //----------------------------------------------------------------------------------------------------------

            this.nguon_tstc.Add("<TSTC_BDS_TSGL_KHAC_GIA_TRI>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_tsgl_khac_gia_tri));

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri));

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_BANG_CHU>");
            this.dich_tstc.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.bds_gia_tri))));

            //---------------Thông tin về công trình xây dựng trên đất chưa được chứng nhận quyền sở hữu------------------
            this.nguon_tstc.Add("<TSTC_BDS_CTXD_2>");
            this.dich_tstc.Add(tstc.bds_ctxd_2);
            //----------------------------------------------------------------------------------------------------------
            #endregion
            #region Tai_san_the_chap_khac
            this.nguon_tstc.Add("<TSTC_TSTC_KHAC_TEN>");
            this.dich_tstc.Add(tstc.tstc_khac_ten);
         
            //---------------------------Thông tin chung về tài sản thế chấp khác --------------------------------
            this.nguon_tstc.Add("<TSTC_TSTC_KHAC_THONG_TIN_CHUNG_RTF>");
            this.dich_tstc.Add(tstc.tstc_khac_thong_tin_chung_rtf);

            this.nguon_tstc.Add("<TSTC_TSTC_KHAC_THONG_TIN_CHUNG>");
            this.dich_tstc.Add(tstc.tstc_khac_thong_tin_chung);

            if (!string.IsNullOrEmpty(tstc.tstc_khac_thong_tin_chung))
            {
                string[] tstc_tstc_khac_thong_tin_chung = tstc.tstc_khac_thong_tin_chung.Split(new[] { "\n" }, StringSplitOptions.None);

                for (int i = 0; i <= tstc_tstc_khac_thong_tin_chung.Length - 1; i++)
                {
                    this.nguon_tstc.Add("<TSTC_TSTC_KHAC_THONG_TIN_CHUNG_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add(tstc_tstc_khac_thong_tin_chung[i]);
                }

                for (int i = tstc_tstc_khac_thong_tin_chung.Length; i <= 9; i++)
                {
                    this.nguon_tstc.Add("<TSTC_TSTC_KHAC_THONG_TIN_CHUNG_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add("");
                }
            }
            else
            {
                for (int i = 0; i <= 9; i++)
                {
                    this.nguon_tstc.Add("<TSTC_TSTC_KHAC_THONG_TIN_CHUNG_" + Convert.ToString(i + 1) + ">");
                    this.dich_tstc.Add("");
                }
            }
            //---------------------------------------------------------------------------------------------------
            this.nguon_tstc.Add("<TSTC_TSTC_KHAC_GIA_TRI>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.tstc_khac_gia_tri));

            this.nguon_tstc.Add("<TSTC_TSTC_KHAC_GIA_TRI_BANG_CHU>");
            this.dich_tstc.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.tstc_khac_gia_tri))));

            //this.nguon_tstc.Add("<TSTC_TSTC_HTTTL>");
            //this.dich_tstc.Add(tstc.tstc_htttl);

            this.nguon_tstc.Add("<TSTC_TSTC_KHAC_GIAY_TO>");
            this.dich_tstc.Add(tstc.tstc_khac_giay_to);
            #endregion
            //---------------------------------KHAI BÁO THÔNG TIN CHUNG CHỦ SỞ HỮU VÀ TÀI SẢN THẾ CHẤP------------------
            #region Thong_tin_chung_chu_so_huu
            //----------------------Khai báo mã chủ sở hữu trong đề nghị thế chấp tài sản bảo đảm--------------
            this.nguon_tstc.Add("<TSTC_MA_CHU_SO_HUU>");
            this.dich_tstc.Add(tstc.ma_chu_so_huu);
            //--------------------------------------------------------------------------------------------------
            //--------------------------------------------Khai báo tên chủ sở hữu chung-------------------------
            if (!string.IsNullOrEmpty(tstc.hgd_ten_chong) && string.IsNullOrEmpty(tstc.hgd_ten_vo) && string.IsNullOrEmpty(tstc.cn_ten) && string.IsNullOrEmpty(tstc.tc_ten))
            {
                this.nguon_tstc.Add("<TEN_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.hgd_ten_chong);
            }
            else if (string.IsNullOrEmpty(tstc.hgd_ten_chong) && !string.IsNullOrEmpty(tstc.hgd_ten_vo) && string.IsNullOrEmpty(tstc.cn_ten) && string.IsNullOrEmpty(tstc.tc_ten))
            {
                this.nguon_tstc.Add("<TEN_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.hgd_ten_vo);
            }
            else if (!string.IsNullOrEmpty(tstc.hgd_ten_chong) && !string.IsNullOrEmpty(tstc.hgd_ten_vo) && string.IsNullOrEmpty(tstc.cn_ten) && string.IsNullOrEmpty(tstc.tc_ten))
            {
                if (tstc.hgd_dai_dien == "Chồng")
                {
                    this.nguon_tstc.Add("<TEN_CHU_SO_HUU>");
                    this.dich_tstc.Add(tstc.hgd_ten_chong);
                }
                else
                {
                    this.nguon_tstc.Add("<TEN_CHU_SO_HUU>");
                    this.dich_tstc.Add(tstc.hgd_ten_vo);
                }
            }
            else if (string.IsNullOrEmpty(tstc.hgd_ten_chong) && string.IsNullOrEmpty(tstc.hgd_ten_vo) && !string.IsNullOrEmpty(tstc.cn_ten) && string.IsNullOrEmpty(tstc.tc_ten))
            {
                this.nguon_tstc.Add("<TEN_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.cn_ten);
            }
            else if (string.IsNullOrEmpty(tstc.hgd_ten_chong) && string.IsNullOrEmpty(tstc.hgd_ten_vo) && string.IsNullOrEmpty(tstc.cn_ten) && !string.IsNullOrEmpty(tstc.tc_ten))
            {
                this.nguon_tstc.Add("<TEN_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.tc_ten);
            }
            //--------------------------------------------------------------------------------------------------
            //----------------------------------------Khai báo địa chỉ và điện thoại chủ sở hữu chung-------------------------
            if (!string.IsNullOrEmpty(tstc.hgd_dc_chong) && string.IsNullOrEmpty(tstc.hgd_dc_vo) && string.IsNullOrEmpty(tstc.cn_dc) && string.IsNullOrEmpty(tstc.tc_dc))
            {
                this.nguon_tstc.Add("<DIA_CHI_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.hgd_dc_chong);

                this.nguon_tstc.Add("<DIEN_THOAI_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.hgd_dien_thoai);
            }
            else if (string.IsNullOrEmpty(tstc.hgd_dc_chong) && !string.IsNullOrEmpty(tstc.hgd_dc_vo) && string.IsNullOrEmpty(tstc.cn_dc) && string.IsNullOrEmpty(tstc.tc_dc))
            {
                this.nguon_tstc.Add("<DIA_CHI_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.hgd_dc_vo);

                this.nguon_tstc.Add("<DIEN_THOAI_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.hgd_dien_thoai);
            }
            else if (!string.IsNullOrEmpty(tstc.hgd_dc_chong) && !string.IsNullOrEmpty(tstc.hgd_dc_vo) && string.IsNullOrEmpty(tstc.cn_dc) && string.IsNullOrEmpty(tstc.tc_dc))
            {
                if (tstc.hgd_dai_dien == "Chồng")
                {
                    this.nguon_tstc.Add("<DIA_CHI_CHU_SO_HUU>");
                    this.dich_tstc.Add(tstc.hgd_dc_chong);
                }
                else if (tstc.hgd_dai_dien == "Vợ")
                {
                    this.nguon_tstc.Add("<DIA_CHI_CHU_SO_HUU>");
                    this.dich_tstc.Add(tstc.hgd_dc_vo);
                }

                this.nguon_tstc.Add("<DIEN_THOAI_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.hgd_dien_thoai);
            }
            else if (string.IsNullOrEmpty(tstc.hgd_dc_chong) && string.IsNullOrEmpty(tstc.hgd_dc_vo) && !string.IsNullOrEmpty(tstc.cn_dc) && string.IsNullOrEmpty(tstc.tc_dc))
            {
                this.nguon_tstc.Add("<DIA_CHI_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.cn_dc);

                this.nguon_tstc.Add("<DIEN_THOAI_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.cn_dien_thoai);
            }
            else if (string.IsNullOrEmpty(tstc.hgd_dc_chong) && string.IsNullOrEmpty(tstc.hgd_dc_vo) && string.IsNullOrEmpty(tstc.cn_dc) && !string.IsNullOrEmpty(tstc.tc_dc))
            {
                this.nguon_tstc.Add("<DIA_CHI_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.tc_dc);

                this.nguon_tstc.Add("<DIEN_THOAI_CHU_SO_HUU>");
                this.dich_tstc.Add(tstc.tc_dien_thoai);
            }
            //--------------------------------------------------------------------------------------------------
            //----------------------------------------Khai báo tên tài sản, số lượng, giấy tờ sở hữu------------
            if (tstc.loai_ts_the_chap == "Bất động sản")
            {
                this.nguon_tstc.Add("<TSTC_TEN_TAI_SAN>");
                this.dich_tstc.Add(tstc.bds_ten);

                this.nguon_tstc.Add("<TSTC_SO_LUONG>");
                this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_tong_dien_tich) + "m2");

                this.nguon_tstc.Add("<TSTC_GIAY_TO>");
                this.dich_tstc.Add(tstc.bds_giay_to);

            }
            else if (tstc.loai_ts_the_chap == "Động sản")
            {
                this.nguon_tstc.Add("<TSTC_TEN_TAI_SAN>");
                this.dich_tstc.Add(tstc.ds_ten);

                this.nguon_tstc.Add("<TSTC_SO_LUONG>");
                this.dich_tstc.Add("1");

                this.nguon_tstc.Add("<TSTC_GIAY_TO>");
                this.dich_tstc.Add(tstc.ds_giay_to);
            }
            else if (tstc.loai_ts_the_chap == "Khác")
            {
                this.nguon_tstc.Add("<TSTC_TEN_TAI_SAN>");
                this.dich_tstc.Add(tstc.tstc_khac_ten);

                this.nguon_tstc.Add("<TSTC_SO_LUONG>");
                this.dich_tstc.Add("1");

                this.nguon_tstc.Add("<TSTC_GIAY_TO>");
                this.dich_tstc.Add(tstc.tstc_khac_giay_to);
            }
            //--------------------------------------------------------------------------------------------------
            //--------------------------------Khai báo giá trị tài sản thế chấp chung-----------------------------------
            if ((tstc.bds_gia_tri != 0) && (tstc.ds_gia_tri == 0) && (tstc.tstc_khac_gia_tri == 0))
            {
                this.nguon_tstc.Add("<TSTC_GIA_TRI>");
                this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri));
                gia_tri_tsbd = tstc.bds_gia_tri;

                this.nguon_tstc.Add("<TSTC_GIA_TRI_BANG_CHU>");
                this.dich_tstc.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.bds_gia_tri))));
            }
            else if ((tstc.bds_gia_tri == 0) && (tstc.ds_gia_tri != 0) && (tstc.tstc_khac_gia_tri == 0))
            {
                this.nguon_tstc.Add("<TSTC_GIA_TRI>");
                this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.ds_gia_tri));
                gia_tri_tsbd = tstc.ds_gia_tri;

                this.nguon_tstc.Add("<TSTC_GIA_TRI_BANG_CHU>");
                this.dich_tstc.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.ds_gia_tri))));
            }
            else if ((tstc.bds_gia_tri == 0) && (tstc.ds_gia_tri == 0) && (tstc.tstc_khac_gia_tri != 0))
            {
                this.nguon_tstc.Add("<TSTC_GIA_TRI>");
                this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.tstc_khac_gia_tri));
                gia_tri_tsbd = tstc.tstc_khac_gia_tri;

                this.nguon_tstc.Add("<TSTC_GIA_TRI_BANG_CHU>");
                this.dich_tstc.Add(CommonMethods.FirstCharToUpper(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.tstc_khac_gia_tri))));
            }
            //---------------------------------------------------------------------------------------------------------
            #endregion
            //----------------------------------------------------------------------------------------------------------
            //---------------------------------KHAI BÁO TRONG ĐƠN THẾ CHẤP----------------------------------------------
            #region Don_the_chap
            //---------------------------Thông tin trên đơn thế chấp----------------------------------------------
            //---------------------------Thông tin về chủ sở hữu là hộ gia đình--------------------------------------------------
            if (!string.IsNullOrEmpty(tstc.hgd_ten_chong) && !string.IsNullOrEmpty(tstc.hgd_ten_vo))
            {
                this.nguon_tstc.Add("<DTC_THONG_TIN_CHONG_1>");
                this.dich_tstc.Add("1.1.1 Tên đầy đủ: " + tstc.hgd_ten_chong.ToUpper());
                
                this.nguon_tstc.Add("<DTC_THONG_TIN_CHONG_2>");
                this.dich_tstc.Add("1.1.2 Địa chỉ liên hệ: " + tstc.hgd_dc_chong);
                //this.dich_tstc.Add("1.1.2 Hộ khẩu thường trú: " + tstc.hgd_hktt_chong);

                this.nguon_tstc.Add("<DTC_THONG_TIN_CHONG_3>");
                this.dich_tstc.Add("1.1.3 Số điện thoại: " + tstc.hgd_dien_thoai);
                
                this.nguon_tstc.Add("<DTC_THONG_TIN_CHONG_4>");
                this.dich_tstc.Add("1.1.4 CMND/Căn cước công dân/Hộ chiếu số: " + tstc.hgd_cmnd_chong + ", ngày cấp " + tstc.hgd_ngay_cap_cmnd_chong + ", nơi cấp: " + tstc.hgd_noi_cap_cmnd_chong);
                
                this.nguon_tstc.Add("<DTC_THONG_TIN_VO_1>");
                this.dich_tstc.Add("1.2.1 Tên đầy đủ: " + tstc.hgd_ten_vo.ToUpper());
                
                this.nguon_tstc.Add("<DTC_THONG_TIN_VO_2>");
                this.dich_tstc.Add("1.2.2 Địa chỉ liên hệ: " + tstc.hgd_dc_vo);
                //this.dich_tstc.Add("1.2.2 Hộ khẩu thường trú: " + tstc.hgd_hktt_vo);

                this.nguon_tstc.Add("<DTC_THONG_TIN_VO_3>");
                this.dich_tstc.Add("1.2.3 Số điện thoại: " + tstc.hgd_dien_thoai);

                this.nguon_tstc.Add("<DTC_THONG_TIN_VO_4>");
                this.dich_tstc.Add("1.2.4 CMND/Căn cước công dân/Hộ chiếu số: " + tstc.hgd_cmnd_vo + ", ngày cấp " + tstc.hgd_ngay_cap_cmnd_vo + ", nơi cấp: " + tstc.hgd_noi_cap_cmnd_vo);

                this.nguon_tstc.Add("<DTC_THONG_TIN_HGD>");
                this.dich_tstc.Add("ông " + tstc.hgd_ten_chong + " và bà " + tstc.hgd_ten_vo);

            }
            else if (!string.IsNullOrEmpty(tstc.hgd_ten_chong) && string.IsNullOrEmpty(tstc.hgd_ten_vo))
            {
                this.nguon_tstc.Add("<DTC_THONG_TIN_CHONG_1>");
                this.dich_tstc.Add("1.1.1 Tên đầy đủ: " + tstc.hgd_ten_chong.ToUpper());

                this.nguon_tstc.Add("<DTC_THONG_TIN_CHONG_2>");
                this.dich_tstc.Add("1.1.2 Hộ khẩu thường trú: " + tstc.hgd_hktt_chong);

                this.nguon_tstc.Add("<DTC_THONG_TIN_CHONG_3>");
                this.dich_tstc.Add("1.1.3 CMND số: " + tstc.hgd_cmnd_chong + ", ngày cấp " + tstc.hgd_ngay_cap_cmnd_chong + ", nơi cấp: " + tstc.hgd_noi_cap_cmnd_chong);

                this.nguon_tstc.Add("<DTC_THONG_TIN_VO_1>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<DTC_THONG_TIN_VO_2>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<DTC_THONG_TIN_VO_3>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<DTC_THONG_TIN_HGD>");
                this.dich_tstc.Add("ông " + tstc.hgd_ten_chong);
            }
            else if (string.IsNullOrEmpty(tstc.hgd_ten_chong) && !string.IsNullOrEmpty(tstc.hgd_ten_vo))
            {
                this.nguon_tstc.Add("<DTC_THONG_TIN_CHONG_1>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<DTC_THONG_TIN_CHONG_2>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<DTC_THONG_TIN_CHONG_3>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<DTC_THONG_TIN_VO_1>");
                this.dich_tstc.Add("1.1.1 Tên đầy đủ: " + tstc.hgd_ten_vo.ToUpper());

                this.nguon_tstc.Add("<DTC_THONG_TIN_VO_2>");
                this.dich_tstc.Add("1.1.2 Hộ khẩu thường trú: " + tstc.hgd_hktt_vo);

                this.nguon_tstc.Add("<DTC_THONG_TIN_VO_3>");
                this.dich_tstc.Add("1.1.3 CMND số: " + tstc.hgd_cmnd_vo + ", ngày cấp " + tstc.hgd_ngay_cap_cmnd_vo + ", nơi cấp: " + tstc.hgd_noi_cap_cmnd_vo);

                this.nguon_tstc.Add("<DTC_THONG_TIN_HGD>");
                this.dich_tstc.Add("bà " + tstc.hgd_ten_vo);
            }
            //---------------------------------------------------------------------------------------------------
            //--------------------Số hợp đồng thế chấp---------------------------------------------------------

            if (DS_TSTC.Rows.Count > 1)
            {
                this.nguon_tstc.Add("<SO_HDTC>");
                this.dich_tstc.Add(tstc.ma_hd_vay + "-" + Convert.ToString(tstc_selectedrowindex) + "/HĐTC");
                //this.dich_tstc.Add(tstc.ma_hd_vay + "/HĐTC");
            }
            else
            {
                this.nguon_tstc.Add("<SO_HDTC>");
                this.dich_tstc.Add(tstc.ma_hd_vay + "/HĐTC");
            }
            //---------------------------------------------------------------------------------------------------
            //-------------------Thông tin về địa bàn-----------------------------------------------------------
            if (txtma_CN.Text == "2300" || txtma_CN.Text == "2301" || txtma_CN.Text == "2313")
            {
                this.nguon_tstc.Add("<DTC_DIA_BAN>");
                this.dich_tstc.Add("Thành phố Hải Dương");

                this.nguon_tstc.Add("<DTC_DIA_BAN_VIET_HOA>");
                this.dich_tstc.Add("THÀNH PHỐ HẢI DƯƠNG");

                this.nguon_tstc.Add("<DTC_DIA_BAN_1>");
                this.dich_tstc.Add("Hải Dương");
            }
            else
            {
                Chinhanh chi_nhanh1 = ChinhanhBUS.CN_theo_ma(txtma_CN.Text);
                this.nguon_tstc.Add("<DTC_DIA_BAN>");
                this.dich_tstc.Add(chi_nhanh1.ten_CN.Substring(19));

                this.nguon_tstc.Add("<DTC_DIA_BAN_VIET_HOA>");
                this.dich_tstc.Add(chi_nhanh1.ten_CN.Substring(19).ToUpper());

                this.nguon_tstc.Add("<DTC_DIA_BAN_1>");
                this.dich_tstc.Add(chi_nhanh1.ten_CN.Substring(25));
            }

            //--------------------------------------------------------------------------------------------------
            //-------------------Thông tin về quyền sử dụng đất--------------------------------------------------

            if (!string.IsNullOrEmpty(tstc.bds_thong_tin_chung))
            {
                string[] tstc_bds_thong_tin_chung_2 = tstc.bds_thong_tin_chung.Split(new[] { "\n" }, StringSplitOptions.None);
                this.nguon_tstc.Add("<DTC_THONG_TIN_QSD_DAT_1>");
                this.dich_tstc.Add(tstc_bds_thong_tin_chung_2[0].Substring(2) + "; " + tstc_bds_thong_tin_chung_2[1].Substring(2) + "; " + tstc_bds_thong_tin_chung_2[3].Substring(2) + "; " + tstc_bds_thong_tin_chung_2[4].Substring(2));

                this.nguon_tstc.Add("<DTC_THONG_TIN_QSD_DAT_2>");
                string dtc_thong_tin_qsd_dat_2 = tstc_bds_thong_tin_chung_2[2].Remove(tstc_bds_thong_tin_chung_2[2].IndexOf(" thửa đất"), 9);
                dtc_thong_tin_qsd_dat_2 = dtc_thong_tin_qsd_dat_2.Substring(2);
                this.dich_tstc.Add(dtc_thong_tin_qsd_dat_2);
                //this.dich_tstc.Add(tstc_bds_thong_tin_chung_2[2].Remove(tstc_bds_thong_tin_chung_2[2].IndexOf(" thửa đất"), 9));
            }
            else
            {
                this.nguon_tstc.Add("<DTC_THONG_TIN_QSD_DAT_1>");
                this.dich_tstc.Add("");

                this.nguon_tstc.Add("<DTC_THONG_TIN_QSD_DAT_2>");
                this.dich_tstc.Add("");
            }
            
            //---------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------
            #endregion
            //----------------------------------------------------------------------------------------------------------
            //---------------------------------KHAI BÁO TRONG BIÊN BẢN ĐỊNH GIÁ-----------------------------------------
            #region Bien_ban_dinh_gia
            //-------------------Thông tin trên biên bản định giá-----------------------------------------

            if (DS_TSTC.Rows.Count > 1)
            {
                this.nguon_tstc.Add("<BBDG_MA_BBDG>");
                this.dich_tstc.Add(tstc.ma_hd_vay + "-" + Convert.ToString(tstc_selectedrowindex));
                //this.dich_tstc.Add(tstc.ma_hd_vay);

                this.nguon_tstc.Add("<SO_BBDG>");
                this.dich_tstc.Add(tstc.ma_hd_vay + "-" + Convert.ToString(tstc_selectedrowindex) + "/BBĐG");
                //this.dich_tstc.Add(tstc.ma_hd_vay + "/BBĐG");
            }
            else
            {
                this.nguon_tstc.Add("<BBDG_MA_BBDG>");
                this.dich_tstc.Add(tstc.ma_hd_vay);

                this.nguon_tstc.Add("<SO_BBDG>");
                this.dich_tstc.Add(tstc.ma_hd_vay + "/BBĐG");
            }

            if (tstc.bds_gia_tri_qsd_dat_o != 0)
            {
                this.nguon_tstc.Add("<BBDG_GIA_TRI_QSD_DAT_1>");
                //this.dich_tstc.Add("Giá trị QSD đất ở: " + ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_o_tren_m2) + " m\xB2 x " + ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_o) + " đ/m\xB2 = " + ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_o) + " đồng");
                this.dich_tstc.Add("Giá trị QSD đất ở: " + ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_o) + " m\xB2 x " + ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_o_tren_m2) + " đ/m\xB2 = " + ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_o) + " đồng");
            }
            else
            {
                this.nguon_tstc.Add("<BBDG_GIA_TRI_QSD_DAT_1>");
                this.dich_tstc.Add("");
            }

            if (tstc.bds_gia_tri_qsd_dat_khac_1 != 0)
            {
                this.nguon_tstc.Add("<BBDG_GIA_TRI_QSD_DAT_2>");
                this.dich_tstc.Add("Giá trị QSD " + tstc.bds_dat_khac_1 + ": " + ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_khac_1) + " m\xB2 x " + ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_1_tren_m2) + " đ/m\xB2 = " + ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_1) + " đồng");
            }
            else
            {
                this.nguon_tstc.Add("<BBDG_GIA_TRI_QSD_DAT_2>");
                this.dich_tstc.Add("");
            }

            if (tstc.bds_gia_tri_qsd_dat_khac_2 != 0)
            {
                this.nguon_tstc.Add("<BBDG_GIA_TRI_QSD_DAT_3>");
                this.dich_tstc.Add("Giá trị QSD " + tstc.bds_dat_khac_2 + ": " + ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_khac_2) + " m\xB2 x " + ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_2_tren_m2) + " đ/m\xB2 = " + ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_2) + " đồng");
            }
            else
            {
                this.nguon_tstc.Add("<BBDG_GIA_TRI_QSD_DAT_3>");
                this.dich_tstc.Add("");
            }

            if (tstc.bds_gia_tri_qsd_dat_khac_3 != 0)
            {
                this.nguon_tstc.Add("<BBDG_GIA_TRI_QSD_DAT_4>");
                this.dich_tstc.Add("Giá trị QSD " + tstc.bds_dat_khac_3 + ": " + ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_khac_3) + " m\xB2 x " + ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_3_tren_m2) + " đ/m\xB2 = " + ControlFormat.ToFormatPrice(tstc.bds_gia_tri_qsd_dat_khac_3) + " đồng");
            }
            else
            {
                this.nguon_tstc.Add("<BBDG_GIA_TRI_QSD_DAT_4>");
                this.dich_tstc.Add("");
            }

            this.nguon_tstc.Add("<BBDG_GIA_TRI_TSGL>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_nha_gia_tri+tstc.bds_ctxd_gia_tri+tstc.bds_tsgl_khac_gia_tri));

            //--------------------------------------------------------------------------------------------
            #endregion       
            //----------------------------------------------------------------------------------------------------------
        }
        #region Tao_hop_dong_tin_dung
        //-------------------------------------TẠO HỢP ĐỒNG TÍN DỤNG --------------------------------------------------------------
        
         internal void HOP_DONG_TIN_DUNG(string loai_hd_tin_dung)
        {
            savefileTao_hop_dong_tin_dung.Filter = "Word Documents|*.docx";
            if (savefileTao_hop_dong_tin_dung.ShowDialog() == DialogResult.OK)
            {
                string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"HDTD\"+loai_hd_tin_dung+".docx");
                CommonMethods.CreateWordDocument(TemplateFileLocation, savefileTao_hop_dong_tin_dung.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + savefileTao_hop_dong_tin_dung.FileName, "Tạo file thành công");
            }
        }

         private void btnTao_hop_dong_tin_dung_Click_1(object sender, EventArgs e)
         {
             if (string.IsNullOrEmpty(txtMa_hd_vay.Text))
             {
                 MessageBox.Show("Bạn chưa chọn hợp đồng (trường bắt buộc)");
                 txtMa_hd_vay.Focus();
                 return;
             }
             //Kiểm tra dữ liệu ngày hợp đồng đã đúng định dạng hay chưa
             if (txtNgay_hop_dong_tin_dung.Text == "  /  /")
             {
                 MessageBox.Show("Bạn chưa nhập ngày hợp đồng (trường bắt buộc)");
                 txtNgay_hop_dong_tin_dung.Focus();
                 return;
             }
             else if (!CommonMethods.KiemTraNhapNgay(txtNgay_hop_dong_tin_dung.Text))
             {
                 MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                 txtNgay_hop_dong_tin_dung.Focus();
                 return;
             }
             hdbus.CAP_NHAT_NGAY_HD_VAY(txtMa_hd_vay.Text, txtNgay_hop_dong_tin_dung.Text);
             this.nguon_thong_tin_chung.Add("<HDV_NGAY>");
             this.dich_thong_tin_chung.Add(txtNgay_hop_dong_tin_dung.Text);

             this.HOP_DONG_TIN_DUNG(txtLoai_hop_dong_tin_dung.Text);
         }
         //-------------------------------------------------------------------------------------------------------------------------
        #endregion
         private void dgvDanh_sach_tstc_1_SelectionChanged(object sender, EventArgs e)
         {
             if (dgvDanh_sach_tstc_1.Rows.Count == 0)
             {
                 txtLoai_hop_dong_the_chap.Clear();
                 txtLoai_bien_ban_dinh_gia.Clear();
                 txtDon_the_chap.Clear();
                 txtXoa_the_chap.Clear();
                 txtDe_nghi_the_chap_TSBD.Clear();
                 txtSo_dang_ky_TSBD.Clear();
                 txtPhieu_nhap_kho.Clear();
             }
             else
             {
                 int selectedrowindex = dgvDanh_sach_tstc_1.CurrentCell.RowIndex;
                 //int selectedrowindex = dgvDanh_sach_tstc_1.SelectedCells[0].RowIndex;
                 DataGridViewRow selectedRow = dgvDanh_sach_tstc_1.Rows[selectedrowindex];
                 int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
                 Taisanthechap tstc = AGRIBANKHD.BUS.TaisanthechapBUS.TSTC_THEO_MA_TSTC(ma_ts_the_chap);
                 #region Lay ten bien ban dinh gia
                 //------------------------------Lấy tên biên bản định giá--------------------------------------
                 if (tstc.loai_chu_so_huu == "Hộ gia đình")
                 {
                     if (tstc.loai_ts_the_chap == "Bất động sản")
                     {
                         if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                         {
                             txtLoai_bien_ban_dinh_gia.Text = "BBDG_HO_GIA_DINH_BDS_TSGL";
                         }
                         else
                         {
                             txtLoai_bien_ban_dinh_gia.Text = "BBDG_HO_GIA_DINH_BDS";
                         }
                     }
                     else if (tstc.loai_ts_the_chap == "Động sản")
                     {
                         txtLoai_bien_ban_dinh_gia.Text = "BBDG_HO_GIA_DINH_DS";
                     }
                     else if (tstc.loai_ts_the_chap == "Khác")
                     {
                         txtLoai_bien_ban_dinh_gia.Text = "BBDG_HO_GIA_DINH_TSTC_KHAC";
                     }
                 }
                 else if (tstc.loai_chu_so_huu == "Cá nhân")
                 {
                     if (tstc.loai_ts_the_chap == "Bất động sản")
                     {
                         if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                         {
                             txtLoai_bien_ban_dinh_gia.Text = "BBDG_CA_NHAN_BDS_TSGL";
                         }
                         else
                         {
                             txtLoai_bien_ban_dinh_gia.Text = "BBDG_CA_NHAN_BDS";
                         }
                     }
                     else if (tstc.loai_ts_the_chap == "Động sản")
                     {
                         txtLoai_bien_ban_dinh_gia.Text = "BBDG_CA_NHAN_DS";
                     }
                     else if (tstc.loai_ts_the_chap == "Khác")
                     {
                         txtLoai_bien_ban_dinh_gia.Text = "BBDG_CA_NHAN_TSTC_KHAC";
                     }
                 }
                 else if (tstc.loai_chu_so_huu == "Tổ chức")
                 {
                     if (tstc.loai_ts_the_chap == "Bất động sản")
                     {
                         if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                         {
                             txtLoai_bien_ban_dinh_gia.Text = "BBDG_TO_CHUC_BDS_TSGL";
                         }
                         else
                         {
                             txtLoai_bien_ban_dinh_gia.Text = "BBDG_TO_CHUC_BDS";
                         }
                     }
                     else if (tstc.loai_ts_the_chap == "Động sản")
                     {
                         txtLoai_bien_ban_dinh_gia.Text = "BBDG_TO_CHUC_DS";
                     }
                     else if (tstc.loai_ts_the_chap == "Khác")
                     {
                         txtLoai_bien_ban_dinh_gia.Text = "BBDG_TO_CHUC_TSTC_KHAC";
                     }
                 }
                 //----------------------------------------------------------------------------------------------------------
                 #endregion
                 #region Lay ten hop dong the chap
                 //-----------------------------------------Lấy tên hợp đồng thế chấp----------------------------------------
                 if (tstc.hinh_thuc_so_huu_cua_kh_vay == "Tài sản chính chủ")
                 {
                     if (tstc.loai_chu_so_huu == "Hộ gia đình")
                     {
                         if (tstc.loai_ts_the_chap == "Bất động sản")
                         {
                             if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtLoai_hop_dong_the_chap.Text = "08_HO_GIA_DINH_BDS_TSGL_CHINH_CHU";
                             }
                             else
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "09B_HO_GIA_DINH_BDS_CHINH_CHU";
                                 }
                                 else
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "09A_HO_GIA_DINH_BDS_CHINH_CHU";
                                 }
                             }
                         }
                         else if (tstc.loai_ts_the_chap == "Động sản")
                         {
                             txtLoai_hop_dong_the_chap.Text = "HO_GIA_DINH_DS_CHINH_CHU";
                         }
                         else if (tstc.loai_ts_the_chap == "Khác")
                         {
                             txtLoai_hop_dong_the_chap.Text = "HO_GIA_DINH_TSTC_KHAC_CHINH_CHU";
                         }
                     }
                     else if (tstc.loai_chu_so_huu == "Cá nhân")
                     {
                         if (tstc.loai_ts_the_chap == "Bất động sản")
                         {
                             if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtLoai_hop_dong_the_chap.Text = "08_CA_NHAN_BDS_TSGL_CHINH_CHU";
                             }
                             else
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "09B_CA_NHAN_BDS_CHINH_CHU";
                                 }
                                 else
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "09A_CA_NHAN_BDS_CHINH_CHU";
                                 }
                             }
                         }
                         else if (tstc.loai_ts_the_chap == "Động sản")
                         {
                             txtLoai_hop_dong_the_chap.Text = "CA_NHAN_DS_CHINH_CHU";
                         }
                         else if (tstc.loai_ts_the_chap == "Khác")
                         {
                             txtLoai_hop_dong_the_chap.Text = "CA_NHAN_TSTC_KHAC_CHINH_CHU";
                         }
                     }
                     else if (tstc.loai_chu_so_huu == "Tổ chức")
                     {
                         if (tstc.loai_ts_the_chap == "Bất động sản")
                         {
                             if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtLoai_hop_dong_the_chap.Text = "08_TO_CHUC_BDS_TSGL_CHINH_CHU";
                             }
                             else
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "09B_TO_CHUC_BDS_CHINH_CHU";
                                 }
                                 else
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "09A_TO_CHUC_BDS_CHINH_CHU";
                                 }
                             }
                         }
                         else if (tstc.loai_ts_the_chap == "Động sản")
                         {
                             txtLoai_hop_dong_the_chap.Text = "TO_CHUC_DS_CHINH_CHU";
                         }
                         else if (tstc.loai_ts_the_chap == "Khác")
                         {
                             txtLoai_hop_dong_the_chap.Text = "TO_CHUC_TSTC_KHAC_CHINH_CHU";
                         }
                     }
                 }
                 else if (tstc.hinh_thuc_so_huu_cua_kh_vay == "Tài sản bên thứ ba")
                 {
                     List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(_ma_hd_vay, txtma_CN.Text);
                     Hopdongvay hd = HD_VAY_theoma_HD[0];
                     DataTable ds_kh_vay_theo_ma = AGRIBANKHD.BUS.KhachhangvayBUS.DS_KH_VAY_THEO_MA(hd.ma_kh_vay);
                     DataRow row = ds_kh_vay_theo_ma.Rows[0];
                     Khachhangvay khv = new Khachhangvay(row);
                     if (tstc.loai_chu_so_huu == "Hộ gia đình")
                     {
                         if (tstc.loai_ts_the_chap == "Bất động sản")
                         {
                             if (khv.loai_kh == "Hộ gia đình")
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "15A_HO_GIA_DINH_BDS_TSGL_2B_HO_GIA_DINH";
                                 }
                                 else
                                 {
                                     if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15C_HO_GIA_DINH_BDS_2B_HO_GIA_DINH";
                                     }
                                     else
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15B_HO_GIA_DINH_BDS_2B_HO_GIA_DINH";
                                     }
                                 }
                             }
                             else if (khv.loai_kh == "Cá nhân")
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "15A_CA_NHAN_BDS_TSGL_2B_HO_GIA_DINH";
                                 }
                                 else
                                 {
                                     if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15C_CA_NHAN_BDS_2B_HO_GIA_DINH";
                                     }
                                     else
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15B_CA_NHAN_BDS_2B_HO_GIA_DINH";
                                     }
                                 }
                             }
                             else if (khv.loai_kh == "Tổ chức")
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "15A_TO_CHUC_BDS_TSGL_2B_HO_GIA_DINH";
                                     //txtLoai_hop_dong_the_chap.Text = "TO_CHUC_BDS_TSGL_BTB_HO_GIA_DINH";
                                     //txtLoai_hop_dong_the_chap_2_ben.Text = "TO_CHUC_BDS_TSGL_2B_HO_GIA_DINH";
                                 }
                                 else
                                 {
                                     if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15C_TO_CHUC_BDS_2B_HO_GIA_DINH";
                                     }
                                     else
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15B_TO_CHUC_BDS_2B_HO_GIA_DINH";
                                     }
                                     //txtLoai_hop_dong_the_chap.Text = "TO_CHUC_BDS_BTB_HO_GIA_DINH";
                                     //txtLoai_hop_dong_the_chap_2_ben.Text = "TO_CHUC_BDS_2B_HO_GIA_DINH";
                                 }
                             }
                         }
                         else if (tstc.loai_ts_the_chap == "Động sản")
                         {
                             if (khv.loai_kh == "Hộ gia đình")
                             {
                                 txtLoai_hop_dong_the_chap.Text = "HO_GIA_DINH_DS_BTB_HO_GIA_DINH";
                             }
                             else if (khv.loai_kh == "Cá nhân")
                             {
                                 txtLoai_hop_dong_the_chap.Text = "CA_NHAN_DS_BTB_HO_GIA_DINH";
                             }
                             else if (khv.loai_kh == "Tổ chức")
                             {
                                 txtLoai_hop_dong_the_chap.Text = "TO_CHUC_DS_BTB_HO_GIA_DINH";
                             }
                         }
                         else if (tstc.loai_ts_the_chap == "Khác")
                         {
                             txtLoai_hop_dong_the_chap.Text = "";
                         }
                     }
                     else if (tstc.loai_chu_so_huu == "Cá nhân")
                     {
                         if (tstc.loai_ts_the_chap == "Bất động sản")
                         {
                             if (khv.loai_kh == "Hộ gia đình")
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "15A_HO_GIA_DINH_BDS_TSGL_2B_CA_NHAN";
                                 }
                                 else
                                 {
                                     if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15C_HO_GIA_DINH_BDS_2B_CA_NHAN";
                                     }
                                     else
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15B_HO_GIA_DINH_BDS_2B_CA_NHAN";
                                     }
                                 }
                             }
                             else if (khv.loai_kh == "Cá nhân")
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "15A_CA_NHAN_BDS_TSGL_2B_CA_NHAN";
                                 }
                                 else
                                 {
                                     if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15C_CA_NHAN_BDS_2B_CA_NHAN";
                                     }
                                     else
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15B_CA_NHAN_BDS_2B_CA_NHAN";
                                     }
                                 }
                             }
                             else if (khv.loai_kh == "Tổ chức")
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "15A_TO_CHUC_BDS_TSGL_2B_CA_NHAN";
                                     //txtLoai_hop_dong_the_chap.Text = "TO_CHUC_BDS_TSGL_BTB_CA_NHAN";
                                     //txtLoai_hop_dong_the_chap_2_ben.Text = "TO_CHUC_BDS_TSGL_2B_CA_NHAN";
                                 }
                                 else
                                 {
                                     if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15C_TO_CHUC_BDS_2B_CA_NHAN";
                                     }
                                     else
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15B_TO_CHUC_BDS_2B_CA_NHAN";
                                     }
                                     //txtLoai_hop_dong_the_chap.Text = "TO_CHUC_BDS_BTB_CA_NHAN";
                                     //txtLoai_hop_dong_the_chap_2_ben.Text = "TO_CHUC_BDS_2B_CA_NHAN";
                                 }
                             }
                         }
                         else if (tstc.loai_ts_the_chap == "Động sản")
                         {
                             if (khv.loai_kh == "Hộ gia đình")
                             {
                                 txtLoai_hop_dong_the_chap.Text = "HO_GIA_DINH_DS_BTB_CA_NHAN";
                             }
                             else if (khv.loai_kh == "Cá nhân")
                             {
                                 txtLoai_hop_dong_the_chap.Text = "CA_NHAN_DS_BTB_CA_NHAN";
                             }
                             else if (khv.loai_kh == "Tổ chức")
                             {
                                 txtLoai_hop_dong_the_chap.Text = "TO_CHUC_DS_BTB_CA_NHAN";
                             }
                         }
                         else if (tstc.loai_ts_the_chap == "Khác")
                         {
                             txtLoai_hop_dong_the_chap.Text = "";
                         }
                     }
                     else if (tstc.loai_chu_so_huu == "Tổ chức")
                     {
                         if (tstc.loai_ts_the_chap == "Bất động sản")
                         {
                             if (khv.loai_kh == "Hộ gia đình")
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "15A_HO_GIA_DINH_BDS_TSGL_2B_TO_CHUC";
                                 }
                                 else
                                 {
                                     if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15C_HO_GIA_DINH_BDS_2B_TO_CHUC";
                                     }
                                     else
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15B_HO_GIA_DINH_BDS_2B_TO_CHUC";
                                     }
                                 }
                             }
                             else if (khv.loai_kh == "Cá nhân")
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "15A_CA_NHAN_BDS_TSGL_2B_TO_CHUC";
                                 }
                                 else
                                 {
                                     if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15C_CA_NHAN_BDS_2B_TO_CHUC";
                                     }
                                     else
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15B_CA_NHAN_BDS_2B_TO_CHUC";
                                     }
                                 }
                             }
                             else if (khv.loai_kh == "Tổ chức")
                             {
                                 if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                                 {
                                     txtLoai_hop_dong_the_chap.Text = "15A_TO_CHUC_BDS_TSGL_2B_TO_CHUC";
                                     //txtLoai_hop_dong_the_chap.Text = "TO_CHUC_BDS_TSGL_BTB_HO_GIA_DINH";
                                     //txtLoai_hop_dong_the_chap_2_ben.Text = "TO_CHUC_BDS_TSGL_2B_HO_GIA_DINH";
                                 }
                                 else
                                 {
                                     if (!string.IsNullOrEmpty(tstc.bds_ctxd_2))
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15C_TO_CHUC_BDS_2B_TO_CHUC";
                                     }
                                     else
                                     {
                                         txtLoai_hop_dong_the_chap.Text = "15B_TO_CHUC_BDS_2B_TO_CHUC";
                                     }
                                     //txtLoai_hop_dong_the_chap.Text = "TO_CHUC_BDS_BTB_HO_GIA_DINH";
                                     //txtLoai_hop_dong_the_chap_2_ben.Text = "TO_CHUC_BDS_2B_HO_GIA_DINH";
                                 }
                             }
                         }
                         else
                         {
                             txtLoai_hop_dong_the_chap.Text = "";
                         }
                     }
                 }
                 //--------------------------------------------------------------------------------------------------
                 #endregion
                 #region Lay ten don the chap
                 //------------------------Lấy tên đơn thế chấp -----------------------------------------------------
                 if (tstc.loai_chu_so_huu == "Hộ gia đình")
                 {
                     if (tstc.loai_ts_the_chap == "Bất động sản")
                     {
                         if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                         {
                             if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtDon_the_chap.Text = "DTC_HO_GIA_DINH_BDS_TSGL_NHA";
                             }
                             else if (string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtDon_the_chap.Text = "DTC_HO_GIA_DINH_BDS_TSGL_CTXD";
                             }
                             else if (string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtDon_the_chap.Text = "DTC_HO_GIA_DINH_BDS_TSGL_KHAC";
                             }
                             else
                             {
                                 txtDon_the_chap.Text = "";
                             }
                         }
                         else
                         {
                             txtDon_the_chap.Text = "DTC_HO_GIA_DINH_BDS";
                         }
                     }
                     else if (tstc.loai_ts_the_chap == "Động sản")
                     {
                         if (tstc.hgd_ten_chong != "" & tstc.hgd_ten_vo != "")
                         {
                             txtDon_the_chap.Text = "DTC_HO_GIA_DINH_DS";
                         }
                         else if (tstc.hgd_ten_chong != "" & tstc.hgd_ten_vo == "")
                         {
                             txtDon_the_chap.Text = "DTC_HO_GIA_DINH_DS_C";
                         }
                         else if (tstc.hgd_ten_chong == "" & tstc.hgd_ten_vo != "")
                         {
                             txtDon_the_chap.Text = "DTC_HO_GIA_DINH_DS_V";
                         }
                     }
                     else if (tstc.loai_ts_the_chap == "Khác")
                     {
                         txtDon_the_chap.Text = "";
                     }
                 }
                 else if (tstc.loai_chu_so_huu == "Cá nhân")
                 {
                     if (tstc.loai_ts_the_chap == "Bất động sản")
                     {
                         if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                         {
                             if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtDon_the_chap.Text = "DTC_CA_NHAN_BDS_TSGL_NHA";
                             }
                             else if (string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtDon_the_chap.Text = "DTC_CA_NHAN_BDS_TSGL_CTXD";
                             }
                             else if (string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtDon_the_chap.Text = "DTC_CA_NHAN_BDS_TSGL_KHAC";
                             }
                             else
                             {
                                 txtDon_the_chap.Text = "";
                             }
                         }
                         else
                         {
                             txtDon_the_chap.Text = "DTC_CA_NHAN_BDS";
                         }
                     }
                     else if (tstc.loai_ts_the_chap == "Động sản")
                     {
                         txtDon_the_chap.Text = "DTC_CA_NHAN_DS";
                     }
                     else if (tstc.loai_ts_the_chap == "Khác")
                     {
                         txtDon_the_chap.Text = "";
                     }
                 }
                 else if (tstc.loai_chu_so_huu == "Tổ chức")
                 {
                     if (tstc.loai_ts_the_chap == "Bất động sản")
                     {
                         txtDon_the_chap.Text = "";
                     }
                     else if (tstc.loai_ts_the_chap == "Động sản")
                     {
                         txtDon_the_chap.Text = "DTC_TO_CHUC_DS";
                     }
                     else if (tstc.loai_ts_the_chap == "Khác")
                     {
                         txtDon_the_chap.Text = "";
                     }
                 }
                 //------------------------------------------------------------------------------------------------------
                 #endregion
                 #region Lay ten yeu cau xoa the chap
                 //------------------------Lấy tên yêu cầu xóa thế chấp -------------------------------------------------
                 if (tstc.loai_chu_so_huu == "Hộ gia đình")
                 { 
                     if (tstc.loai_ts_the_chap == "Bất động sản")
                     {
                         if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                         {
                             if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtXoa_the_chap.Text = "XTC_HO_GIA_DINH_BDS_TSGL_NHA";
                             }
                             else if (string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtXoa_the_chap.Text = "XTC_HO_GIA_DINH_BDS_TSGL_CTXD";
                             }
                             else if (string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtXoa_the_chap.Text = "XTC_HO_GIA_DINH_BDS_TSGL_KHAC";
                             }
                             else
                             {
                                 txtXoa_the_chap.Text = "";
                             }
                         }
                         else
                         {
                             txtXoa_the_chap.Text = "XTC_HO_GIA_DINH_BDS";
                         }
                     }
                     else
                     {
                         txtXoa_the_chap.Text = "";
                     }
                 }
                 else if (tstc.loai_chu_so_huu == "Cá nhân")
                 {
                     if (tstc.loai_ts_the_chap == "Bất động sản")
                     {
                         if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                         {
                             if (!string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtXoa_the_chap.Text = "XTC_CA_NHAN_BDS_TSGL_NHA";
                             }
                             else if (string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && !string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtXoa_the_chap.Text = "XTC_CA_NHAN_BDS_TSGL_CTXD";
                             }
                             else if (string.IsNullOrEmpty(tstc.bds_nha_thong_tin_chung) && string.IsNullOrEmpty(tstc.bds_ctxd_thong_tin_chung) || !string.IsNullOrEmpty(tstc.bds_tsgl_khac_thong_tin_chung))
                             {
                                 txtXoa_the_chap.Text = "XTC_CA_NHAN_BDS_TSGL_KHAC";
                             }
                             else
                             {
                                 txtXoa_the_chap.Text = "";
                             }
                         }
                         else
                         {
                             txtXoa_the_chap.Text = "XTC_CA_NHAN_BDS";
                         }
                     }
                     else
                     {
                         txtXoa_the_chap.Text = "";
                     }
                 }
                 else
                 {
                     txtXoa_the_chap.Text = "";
                 }
                 //------------------------------------------------------------------------------------------------------
                 #endregion
                 #region Lay_ten_phieu_nhap_kho
                 txtPhieu_nhap_kho.Text = "PHIEU_NHAP_KHO";
                 #endregion
             }         
         }
         #region Tao_bien_ban_dinh_gia
         internal void BIEN_BAN_DINH_GIA(string loai_bien_ban_dinh_gia)
         {
             savefileTao_bien_ban_dinh_gia.Filter = "Word Documents|*.docx";
             if (savefileTao_bien_ban_dinh_gia.ShowDialog() == DialogResult.OK)
             {
                 string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"BBDG\" + loai_bien_ban_dinh_gia + ".docx");
                 CommonMethods.CreateWordDocument2(TemplateFileLocation, savefileTao_bien_ban_dinh_gia.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung, this.nguon_tstc, this.dich_tstc);
                 MessageBox.Show("File đã được tạo tại đường dẫn: " + savefileTao_bien_ban_dinh_gia.FileName, "Tạo file thành công");
             }
         }

         private void btnTao_bien_ban_dinh_gia_Click(object sender, EventArgs e)
         {
             //Kiểm tra dữ liệu ngày biên bản định giá đã đúng định dạng hay chưa
             if (txtNgay_bien_ban_dinh_gia.Text == "  /  /")
             {
                 MessageBox.Show("Bạn chưa nhập ngày biên bản định giá (trường bắt buộc)");
                 txtNgay_bien_ban_dinh_gia.Focus();
                 return;
             }
             else if (!CommonMethods.KiemTraNhapNgay(txtNgay_bien_ban_dinh_gia.Text))
             {
                 MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                 txtNgay_bien_ban_dinh_gia.Focus();
                 return;
             }
             if (string.IsNullOrEmpty(txtLoai_bien_ban_dinh_gia.Text))
             {
                 MessageBox.Show("Chưa có mẫu biểu cho loại biên bản này. Đề nghị liên hệ vể Phòng Điện toán Agribank tỉnh để bổ sung!");
                 return;
             }
             int selectedrowindex = dgvDanh_sach_tstc_1.CurrentCell.RowIndex;
             //int selectedrowindex = dgvDanh_sach_tstc_1.SelectedCells[0].RowIndex;
             DataGridViewRow selectedRow = dgvDanh_sach_tstc_1.Rows[selectedrowindex];
             int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);

             this.Lay_thong_tin_tstc(ma_ts_the_chap, selectedrowindex);

             this.nguon_tstc.Add("<BBDG_NGAY>");
             this.dich_tstc.Add(txtNgay_bien_ban_dinh_gia.Text);

             this.nguon_tstc.Add("<BBDG_DANH_GIA_TSBD>");
             this.dich_tstc.Add(txtDanh_gia_TSTC.Text);

             if (!string.IsNullOrEmpty(txtLoai_bien_ban_dinh_gia.Text))
             {
                 this.BIEN_BAN_DINH_GIA(txtLoai_bien_ban_dinh_gia.Text);
             }
             else
             {
                 MessageBox.Show("Chưa có mẫu biểu cho loại biên bản này. Đề nghị liên hệ vể Phòng Điện toán Agribank tỉnh để bổ sung!");
             }
         }
         //-----------------------------------------------------------------------------------------------------------------------------
         #endregion
         
        #region Tao_hop_dong_the_chap
         //-------------------------------------TẠO HỢP ĐỒNG THẾ CHẤP --------------------------------------------------------------
        
        internal void HOP_DONG_THE_CHAP(string loai_hd_the_chap)
        {
            savefileTao_hop_dong_the_chap.Filter = "Word Documents|*.docx";
            if (savefileTao_hop_dong_the_chap.ShowDialog() == DialogResult.OK)
            {
                string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"HDTC\"+loai_hd_the_chap+".docx");
                CommonMethods.CreateWordDocument2(TemplateFileLocation, savefileTao_hop_dong_the_chap.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung, this.nguon_tstc, this.dich_tstc);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + savefileTao_hop_dong_the_chap.FileName, "Tạo file thành công");
            }
        }

        private void btnTao_hop_dong_the_chap_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu ngày hợp đồng thế chấp đã đúng định dạng hay chưa
            //if (txtNgay_hop_dong_the_chap.Text == "  /  /")
            //{
            //    MessageBox.Show("Bạn chưa nhập ngày hợp đồng thế chấp (trường bắt buộc)");
            //    txtNgay_hop_dong_the_chap.Focus();
            //    return;
            //}
            //else if (!CommonMethods.KiemTraNhapNgay(txtNgay_hop_dong_the_chap.Text))
            //{
            //    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
            //    txtNgay_hop_dong_the_chap.Focus();
            //    return;
            //}
            if (txtNgay_bien_ban_dinh_gia.Text == "  /  /")
            {
                MessageBox.Show("Đề nghị nhập ngày trên biên bản định giá.");
                txtNgay_bien_ban_dinh_gia.Focus();
                return;
            }
            else if (!CommonMethods.KiemTraNhapNgay(txtNgay_bien_ban_dinh_gia.Text))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                txtNgay_bien_ban_dinh_gia.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtLoai_hop_dong_the_chap.Text))
            {
                MessageBox.Show("Chưa có mẫu biểu cho loại hợp đồng này. Đề nghị liên hệ vể Phòng Điện toán Agribank tỉnh để bổ sung!");
                return;
            }
            int selectedrowindex = dgvDanh_sach_tstc_1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dgvDanh_sach_tstc_1.Rows[selectedrowindex];
            int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
            this.Lay_thong_tin_tstc(ma_ts_the_chap, selectedrowindex);

            this.nguon_tstc.Add("<NGAY_BBDG>");
            this.dich_tstc.Add(txtNgay_bien_ban_dinh_gia.Text);

            this.nguon_tstc.Add("<HDTC_NGAY>");
            //this.dich_tstc.Add(txtNgay_hop_dong_the_chap.Text);
            this.dich_tstc.Add(".........................");

            //if (!string.IsNullOrEmpty(txtLoai_hop_dong_the_chap.Text))
            //{
            this.HOP_DONG_THE_CHAP(txtLoai_hop_dong_the_chap.Text);
            //}
            //else
            //{
            //    MessageBox.Show("Chưa có mẫu biểu cho loại hợp đồng này. Đề nghị liên hệ vể Phòng Điện toán Agribank tỉnh để bổ sung!");
            //}           
        }
        //----------------------------------------------------------------------------------------------------------------------------
        #endregion

        //-----------------------------------TẠO ĐƠN THẾ CHẤP-------------------------------------------------------------------------
        #region Tao_don_the_chap
        internal void DON_THE_CHAP(string loai_don_the_chap)
        {
            savefileTao_don_the_chap.Filter = "Word Documents|*.docx";
            if (savefileTao_don_the_chap.ShowDialog() == DialogResult.OK)
            {
                string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"DTC\" + loai_don_the_chap + ".docx");
                CommonMethods.CreateWordDocument2(TemplateFileLocation, savefileTao_don_the_chap.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung, this.nguon_tstc, this.dich_tstc);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + savefileTao_don_the_chap.FileName, "Tạo file thành công");
            }
        }

        private void btnTao_don_the_chap_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu ngày đơn thế chấp đã đúng định dạng hay chưa
            //if (txtNgay_don_the_chap.Text == "  /  /")
            //{
            //    MessageBox.Show("Bạn chưa nhập ngày đơn thế chấp (trường bắt buộc)");
            //    txtNgay_don_the_chap.Focus();
            //    return;
            //}
            //else if (!CommonMethods.KiemTraNhapNgay(txtNgay_don_the_chap.Text))
            //{
            //    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
            //    txtNgay_don_the_chap.Focus();
            //    return;
            //}
            if (string.IsNullOrEmpty(txtDon_the_chap.Text))
            {
                MessageBox.Show("Chưa có mẫu biểu cho loại đơn này. Đề nghị liên hệ vể Phòng Điện toán Agribank tỉnh để bổ sung!");
                return;
            }
            //if (txtNgay_hop_dong_the_chap.Text == "  /  /")
            //{
            //    MessageBox.Show("Đề nghị nhập ngày trên hợp đồng thế chấp.");
            //    txtNgay_hop_dong_the_chap.Focus();
            //    return;
            //}
            //else if (!CommonMethods.KiemTraNhapNgay(txtNgay_hop_dong_the_chap.Text))
            //{
            //    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
            //    txtNgay_hop_dong_the_chap.Focus();
            //    return;
            //}

            int selectedrowindex = dgvDanh_sach_tstc_1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dgvDanh_sach_tstc_1.Rows[selectedrowindex];
            int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
            this.Lay_thong_tin_tstc(ma_ts_the_chap, selectedrowindex);

            this.nguon_tstc.Add("<NGAY_HDTC>");
            //this.dich_tstc.Add(txtNgay_hop_dong_the_chap.Text);
            this.dich_tstc.Add("ngày.....tháng.....năm..........");

            //IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            //DateTime dt = DateTime.Parse(txtNgay_don_the_chap.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            this.nguon_tstc.Add("<DTC_NGAY>");
            //this.dich_tstc.Add(Convert.ToString(dt.Day));
            this.dich_tstc.Add("     ");

            this.nguon_tstc.Add("<DTC_THANG>");
            //this.dich_tstc.Add(Convert.ToString(dt.Month));
            this.dich_tstc.Add("     ");

            this.nguon_tstc.Add("<DTC_NAM>");
            //this.dich_tstc.Add(Convert.ToString(dt.Year));
            this.dich_tstc.Add("          ");

            this.nguon_tstc.Add("<DTC_MST_TO_CHUC>");
            this.dich_tstc.Add(txtmst_to_chuc.Text);

            //if (!string.IsNullOrEmpty(txtDon_the_chap.Text))
            //{
            this.DON_THE_CHAP(txtDon_the_chap.Text);
            //}
            //else
            //{
            //    MessageBox.Show("Chưa có mẫu biểu cho loại đơn này. Đề nghị liên hệ vể Phòng Điện toán Agribank tỉnh để bổ sung!");
            //}
        }
        //--------------------------------------------------------------------------------------------------------------------------
        #endregion

        //-----------------------------------TẠO XÓA THẾ CHẤP-------------------------------------------------------------------------
        #region Tao_yeu_cau_xoa_the_chap

        internal void XOA_THE_CHAP(string loai_xoa_the_chap)
        {
            savefileTao_xoa_the_chap.Filter = "Word Documents|*.docx";
            if (savefileTao_xoa_the_chap.ShowDialog() == DialogResult.OK)
            {
                string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"XTC\" + loai_xoa_the_chap + ".docx");
                CommonMethods.CreateWordDocument2(TemplateFileLocation, savefileTao_xoa_the_chap.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung, this.nguon_tstc, this.dich_tstc);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + savefileTao_xoa_the_chap.FileName, "Tạo file thành công");
            }
        }

        private void btnTao_xoa_the_chap_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtXoa_the_chap.Text))
            {
                MessageBox.Show("Chưa có mẫu biểu cho loại đơn này. Đề nghị liên hệ vể Phòng Điện toán Agribank tỉnh để bổ sung!");
                return;
            }
            int selectedrowindex = dgvDanh_sach_tstc_1.CurrentCell.RowIndex;
            //int selectedrowindex = dgvDanh_sach_tstc_1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvDanh_sach_tstc_1.Rows[selectedrowindex];
            int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
            this.Lay_thong_tin_tstc(ma_ts_the_chap, selectedrowindex);

            //if (!string.IsNullOrEmpty(txtXoa_the_chap.Text))
            //{
            this.XOA_THE_CHAP(txtXoa_the_chap.Text);
            //}
            //else
            //{
            //    MessageBox.Show("Chưa có mẫu biểu cho loại yêu cầu xóa thế chấp này. Đề nghị liên hệ vể Phòng Điện toán Agribank tỉnh để bổ sung!");
            //}
        }
        //--------------------------------------------------------------------------------------------------------------------------
        #endregion

        //-----------------------------------TẠO ĐỀ NGHỊ THẾ CHẤP TÀI SẢN BẢO ĐẢM-------------------------------------------------------------------------
        #region Tao_de_nghi_the_chap_tai_san_bao_dam

        internal void DE_NGHI_THE_CHAP_TSBD(string de_nghi_the_chap_TSBD)
        {
            savefileTao_de_nghi_the_chap_TSBD.Filter = "Word Documents|*.docx";
            if (savefileTao_de_nghi_the_chap_TSBD.ShowDialog() == DialogResult.OK)
            {
                string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"DNTC\" + de_nghi_the_chap_TSBD + ".docx");
                CommonMethods.CreateWordDocument2(TemplateFileLocation, savefileTao_de_nghi_the_chap_TSBD.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung, this.nguon_tstc, this.dich_tstc);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + savefileTao_de_nghi_the_chap_TSBD.FileName, "Tạo file thành công");
            }
        }
        private void btnTao_de_nghi_the_chap_TSBD_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu ngày đề nghị thế chấp TSBD đã đúng định dạng hay chưa
            if (txtNgay_de_nghi_the_chap_TSBD.Text == "  /  /")
            {
                MessageBox.Show("Bạn chưa nhập ngày đề nghị thế chấp TSBĐ(trường bắt buộc)");
                txtNgay_de_nghi_the_chap_TSBD.Focus();
                return;
            }
            else if (!CommonMethods.KiemTraNhapNgay(txtNgay_de_nghi_the_chap_TSBD.Text))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                txtNgay_de_nghi_the_chap_TSBD.Focus();
                return;
            }
            //Kiểm tra đã nhập số đăng ký TSBĐ hay chưa
            if (string.IsNullOrEmpty(txtSo_dang_ky_TSBD.Text))
            {
                MessageBox.Show("Bạn chưa nhập số đăng ký TSBĐ (trường bắt buộc). Đề nghị nhập!");
                txtSo_dang_ky_TSBD.Focus();
                return;
            }
            //Kiểm tra xem có loại mẫu biểu theo yêu cầu hay không
            if (string.IsNullOrEmpty(txtDe_nghi_the_chap_TSBD.Text))
            {
                MessageBox.Show("Chưa có mẫu biểu cho loại đề nghị này. Đề nghị liên hệ vể Phòng Điện toán Agribank tỉnh để bổ sung!");
                return;
            }

            int selectedrowindex = dgvDanh_sach_tstc_1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dgvDanh_sach_tstc_1.Rows[selectedrowindex];
            int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
            this.Lay_thong_tin_tstc(ma_ts_the_chap, selectedrowindex);

            this.nguon_tstc.Add("<DNTC_NGAY_THE_CHAP>");
            this.dich_tstc.Add(txtNgay_de_nghi_the_chap_TSBD.Text);

            this.nguon_tstc.Add("<DNTC_SO_DK_TSBD>");
            this.dich_tstc.Add(txtSo_dang_ky_TSBD.Text);

            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            DateTime dt = DateTime.Parse(txtNgay_de_nghi_the_chap_TSBD.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            this.nguon_tstc.Add("<DNTC_NGAY>");
            this.dich_tstc.Add(Convert.ToString(dt.Day));

            this.nguon_tstc.Add("<DNTC_THANG>");
            this.dich_tstc.Add(Convert.ToString(dt.Month));

            this.nguon_tstc.Add("<DNTC_NAM>");
            this.dich_tstc.Add(Convert.ToString(dt.Year));

            Int64 muc_cho_vay_tren_gia_tri_tsbd;
            muc_cho_vay_tren_gia_tri_tsbd = tong_han_muc_tin_dung *100 / gia_tri_tsbd;
            this.nguon_tstc.Add("<DNTC_MUC_CHO_VAY_TREN_GIA_TRI_TSBD>");
            this.dich_tstc.Add(Convert.ToString(muc_cho_vay_tren_gia_tri_tsbd)+"%");

            this.DE_NGHI_THE_CHAP_TSBD(txtDe_nghi_the_chap_TSBD.Text);
        }  
        //--------------------------------------------------------------------------------------------------------------------------
        #endregion

        //-----------------------------------TẠO PHIẾU NHẬP KHO-------------------------------------------------------------------------
        #region Tao_phieu_nhap_kho
        internal void PHIEU_NHAP_KHO(string phieu_nhap_kho)
        {
            savefileTao_phieu_nhap_kho.Filter = "Word Documents|*.docx";
            if (savefileTao_phieu_nhap_kho.ShowDialog() == DialogResult.OK)
            {
                string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"PNK\" + phieu_nhap_kho + ".docx");
                CommonMethods.CreateWordDocument2(TemplateFileLocation, savefileTao_phieu_nhap_kho.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung, this.nguon_tstc, this.dich_tstc);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + savefileTao_phieu_nhap_kho.FileName, "Tạo file thành công");
            }
        }

        private void btnTao_phieu_nhap_kho_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu ngày nhập kho  đã đúng định dạng hay chưa
            if (txtNgay_nhap_kho.Text == "  /  /")
            {
                MessageBox.Show("Bạn chưa nhập ngày nhập kho TSTC(trường bắt buộc). Đề nghị nhập!");
                txtPhieu_nhap_kho.Focus();
                return;
            }
            else if (!CommonMethods.KiemTraNhapNgay(txtNgay_nhap_kho.Text))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                txtPhieu_nhap_kho.Focus();
                return;
            }
            //Kiểm tra xem có loại mẫu biểu theo yêu cầu hay không
            if (string.IsNullOrEmpty(txtPhieu_nhap_kho.Text))
            {
                MessageBox.Show("Chưa có mẫu biểu cho loại đề nghị này. Đề nghị liên hệ vể Phòng Điện toán Agribank tỉnh để bổ sung!");
                return;
            }

            int selectedrowindex = dgvDanh_sach_tstc_1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dgvDanh_sach_tstc_1.Rows[selectedrowindex];
            int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
            this.Lay_thong_tin_tstc(ma_ts_the_chap, selectedrowindex);

            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            DateTime dt = DateTime.Parse(txtNgay_nhap_kho.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            this.nguon_tstc.Add("<PNK_NGAY>");
            this.dich_tstc.Add(Convert.ToString(dt.Day));

            this.nguon_tstc.Add("<PNK_THANG>");
            this.dich_tstc.Add(Convert.ToString(dt.Month));

            this.nguon_tstc.Add("<PNK_NAM>");
            this.dich_tstc.Add(Convert.ToString(dt.Year));

            this.PHIEU_NHAP_KHO(txtPhieu_nhap_kho.Text);
        }

        #endregion
        //--------------------------------------------------------------------------------------------------------------------------
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTao_ho_so_vay_Load(object sender, EventArgs e)
        {


        }

        
    }
}
