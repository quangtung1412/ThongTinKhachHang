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

        internal string _ma_hd_vay { get; set; }

        TaisanthechapBUS tstcbus = new TaisanthechapBUS();

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
            btnTim_kiem_hop_dong_vay.Enabled = false;
            //Bật nút tìm kiếm tài sản thế chấp
            //btnTim_kiem.Enabled = true;
            txtMa_hd_vay.Text = _ma_hd_vay;
            //grbHop_dong_tin_dung.Enabled = true;
            List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(_ma_hd_vay, txtma_CN.Text);
            Hopdongvay hd = HD_VAY_theoma_HD[0];
            //txtNgay_hop_dong_tin_dung.Text = hd.ngay_hd_vay;
            DataTable ds_kh_vay_theo_ma = AGRIBANKHD.BUS.KhachhangvayBUS.DS_KH_VAY_THEO_MA(hd.ma_kh_vay);
            DataRow row = ds_kh_vay_theo_ma.Rows[0];
            Khachhangvay khv = new Khachhangvay(row);
            txtLoai_hop_dong_tin_dung.Clear();
            //cboxLoai_hop_dong_tin_dung.Items.Clear();
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
            //cboxLoai_hop_dong_tin_dung.ResetText();
            //grbDe_xuat_giai_ngan.Enabled = true;
            //cboxLoai_de_xuat_giai_ngan.Items.Clear();
            //if (khv.loai_kh == "Tổ chức")
            //{
            //    cboxLoai_de_xuat_giai_ngan.Items.Add("Đề xuất giải ngân đối với khách hàng là doanh nghiệp");
            //}
            //cboxLoai_de_xuat_giai_ngan.ResetText();
        }

        internal void Lay_thong_tin_ho_so_vay()
        {
            this.nguon_thong_tin_chung.Clear();
            this.dich_thong_tin_chung.Clear();

            CanbotindungBUS cbbus = new CanbotindungBUS();
            //Thông tin chi nhánh
            Chinhanh chi_nhanh = AGRIBANKHD.BUS.ChinhanhBUS.CN_theo_ma(txtma_CN.Text);
            this.nguon_thong_tin_chung.Add("<CHI_NHANH_MA_CN>");
            this.dich_thong_tin_chung.Add(chi_nhanh.ma_CN);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_TEN_CN>");
            this.dich_thong_tin_chung.Add(chi_nhanh.ten_CN);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_TEN_CN_DAY_DU_VIET_THUONG>");
            this.dich_thong_tin_chung.Add(chi_nhanh.ten_cn_day_du);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_TEN_CN_DAY_DU>");
            this.dich_thong_tin_chung.Add(chi_nhanh.ten_cn_day_du.ToUpper());

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_DIA_CHI>");
            this.dich_thong_tin_chung.Add(chi_nhanh.dia_chi);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_MST>");
            this.dich_thong_tin_chung.Add(chi_nhanh.mst);

            this.nguon_thong_tin_chung.Add("<CHI_NHANH_DKKD>");
            this.dich_thong_tin_chung.Add(chi_nhanh.dkkd);
            
            //Thông tin hợp đồng vay
            List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(_ma_hd_vay, txtma_CN.Text);
            Hopdongvay hd = HD_VAY_theoma_HD[0];
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

            this.nguon_thong_tin_chung.Add("<HDV_TONG_HAN_MUC_TIN_DUNG_BANG_CHU>");
            this.dich_thong_tin_chung.Add(CommonMethods.ChuyenSoSangChu(Convert.ToString(hd.tong_han_muc_tin_dung)));

            this.nguon_thong_tin_chung.Add("<HDV_HAN_MUC_TIN_DUNG>");
            this.dich_thong_tin_chung.Add(Convert.ToString(hd.han_muc_tin_dung));

            this.nguon_thong_tin_chung.Add("<HDV_HAN_MUC_TIN_DUNG_BANG_CHU>");
            this.dich_thong_tin_chung.Add(CommonMethods.ChuyenSoSangChu(Convert.ToString(hd.han_muc_tin_dung)));

            this.nguon_thong_tin_chung.Add("<HDV_HAN_MUC_BAO_LANH>");
            this.dich_thong_tin_chung.Add(Convert.ToString(hd.han_muc_bao_lanh));

            this.nguon_thong_tin_chung.Add("<HDV_HAN_MUC_BAO_LANH_BANG_CHU>");
            this.dich_thong_tin_chung.Add(CommonMethods.ChuyenSoSangChu(Convert.ToString(hd.han_muc_bao_lanh)));

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

            this.nguon_thong_tin_chung.Add("<HDV_THOI_GIAN_AN_HAN>");
            this.dich_thong_tin_chung.Add(hd.thoi_gian_an_han);

            this.nguon_thong_tin_chung.Add("<HDV_BAO_DAM_TIEN_VAY>");
            this.dich_thong_tin_chung.Add(hd.bao_dam_tien_vay);

            this.nguon_thong_tin_chung.Add("<HDV_HINH_THUC_BAO_DAM>");
            this.dich_thong_tin_chung.Add(hd.hinh_thuc_bao_dam);

            this.nguon_thong_tin_chung.Add("<HDV_TAI_SAN_BAO_DAM>");
            this.dich_thong_tin_chung.Add(hd.tai_san_bao_dam);

            this.nguon_thong_tin_chung.Add("<HDV_GIA_TRI_TAI_SAN_BAO_DAM>");
            this.dich_thong_tin_chung.Add(ControlFormat.ToFormatPrice(hd.gia_tri_tai_san_bao_dam));

            this.nguon_thong_tin_chung.Add("<HDV_GIA_TRI_TAI_SAN_BAO_DAM_BANG_CHU>");
            this.dich_thong_tin_chung.Add(CommonMethods.ChuyenSoSangChu(Convert.ToString(hd.gia_tri_tai_san_bao_dam)));

            //Liệt kê các hợp đồng thế chấp
            this.nguon_thong_tin_chung.Add("<HDV_HOP_DONG_THE_CHAP>");
            DataTable DS_TSTC = AGRIBANKHD.BUS.TaisanthechapBUS.DS_TSTC(txtMa_hd_vay.Text);
            string hdv_hop_dong_the_chap = "";
            foreach (DataRow tstc_row in DS_TSTC.Rows)
            {
                //string ma_ts_the_chap = Convert.ToString(row["MA_TS_THE_CHAP"]);
                hdv_hop_dong_the_chap = hdv_hop_dong_the_chap + "Hợp đồng thế chấp tài sản số " + CommonMethods.TachMaHopDong(hd.ma_hd_vay) + "-" + Convert.ToString(tstc_row["MA_TS_THE_CHAP"])+"/HĐTC,";
            }
            this.dich_thong_tin_chung.Add(hdv_hop_dong_the_chap);

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
            if (dai_dien_agribank.giay_uy_quyen=="")
            {
                this.dich_thong_tin_chung.Add(dai_dien_agribank.giay_uy_quyen);
            }
            else
            {
                this.dich_thong_tin_chung.Add(" và " + dai_dien_agribank.giay_uy_quyen);
            }          

            //Thông tin kiểm soát tín dụng
            this.nguon_thong_tin_chung.Add("<HDV_KIEM_SOAT_TIN_DUNG>");
            Canbotindung kiem_soat_tin_dung = cbbus.CBTD_theo_ten_dang_nhap(hd.kiem_soat_tin_dung);
            this.dich_thong_tin_chung.Add(kiem_soat_tin_dung.ho_ten);

            this.nguon_thong_tin_chung.Add("<HDV_DANH_XUNG_KIEM_SOAT_TIN_DUNG>");
            this.dich_thong_tin_chung.Add(kiem_soat_tin_dung.danh_xung);

            this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_KIEM_SOAT_TIN_DUNG>");
            this.dich_thong_tin_chung.Add(kiem_soat_tin_dung.chuc_vu);

            //Thông tin cán bộ tín dụng
            this.nguon_thong_tin_chung.Add("<HDV_CAN_BO_TIN_DUNG>");            
            Canbotindung can_bo_tin_dung = cbbus.CBTD_theo_ten_dang_nhap(hd.can_bo_tin_dung);
            this.dich_thong_tin_chung.Add(can_bo_tin_dung.ho_ten);

            this.nguon_thong_tin_chung.Add("<HDV_DANH_XUNG_CAN_BO_TIN_DUNG>");
            this.dich_thong_tin_chung.Add(can_bo_tin_dung.danh_xung);

            this.nguon_thong_tin_chung.Add("<HDV_CHUC_VU_CAN_BO_TIN_DUNG>");
            this.dich_thong_tin_chung.Add(can_bo_tin_dung.chuc_vu);

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
            }
            else if (khv.hgd_dai_dien == "Vợ")
            {
                this.nguon_thong_tin_chung.Add("<KHV_HGD_DAI_DIEN>");
                this.dich_thong_tin_chung.Add("bà " + khv.hgd_ten_vo);
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

        }

        //Lấy thông tin về tài sản thế chấp
        internal void Lay_thong_tin_tstc(int ma_ts_the_chap)
        {
            this.nguon_tstc.Clear();
            this.dich_tstc.Clear();

            Taisanthechap tstc = AGRIBANKHD.BUS.TaisanthechapBUS.TSTC_THEO_MA_TSTC(ma_ts_the_chap);
            this.nguon_tstc.Add("<TSTC_MA_TS_THE_CHAP>");
            this.dich_tstc.Add(Convert.ToString(tstc.ma_ts_the_chap));

            this.nguon_tstc.Add("<TSTC_MA_HD_VAY>");
            this.dich_tstc.Add(tstc.ma_hd_vay);

            this.nguon_tstc.Add("<TSTC_MA_HD_THE_CHAP>");
            this.dich_tstc.Add(CommonMethods.TachMaHopDong(tstc.ma_hd_vay) + "-" + Convert.ToString(tstc.ma_ts_the_chap));

            this.nguon_tstc.Add("<TSTC_LOAI_CHU_SO_HUU>");
            this.dich_tstc.Add(tstc.loai_chu_so_huu);

            this.nguon_tstc.Add("<TSTC_LOAI_TS_THE_CHAP>");
            this.dich_tstc.Add(tstc.loai_ts_the_chap);

            this.nguon_tstc.Add("<TSTC_HINH_THUC_SO_HUU_CUA_KH_VAY>");
            this.dich_tstc.Add(tstc.hinh_thuc_so_huu_cua_kh_vay);

            this.nguon_tstc.Add("<TSTC_HGD_TEN_CHONG>");
            this.dich_tstc.Add(tstc.hgd_ten_chong);

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

            this.nguon_tstc.Add("<TSTC_CN_DANH_XUNG>");
            this.dich_tstc.Add(tstc.cn_danh_xung);

            this.nguon_tstc.Add("<TSTC_CN_TEN>");
            this.dich_tstc.Add(tstc.cn_ten);

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

            this.nguon_tstc.Add("<TSTC_TC_TEN>");
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

            this.nguon_tstc.Add("<TSTC_DS_TEN>");
            this.dich_tstc.Add(tstc.ds_ten);

            this.nguon_tstc.Add("<TSTC_DS_SO_LUONG>");
            this.dich_tstc.Add(Convert.ToString(tstc.ds_so_luong));

            this.nguon_tstc.Add("<TSTC_DS_GIA_TRI>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.ds_gia_tri));

            this.nguon_tstc.Add("<TSTC_DS_GIA_TRI_BANG_CHU>");
            this.dich_tstc.Add(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.ds_gia_tri)));

            this.nguon_tstc.Add("<TSTC_DS_NHAN_HIEU>");
            this.dich_tstc.Add(tstc.ds_nhan_hieu);

            this.nguon_tstc.Add("<TSTC_DS_LOAI_XE>");
            this.dich_tstc.Add(tstc.ds_loai_xe);

            this.nguon_tstc.Add("<TSTC_DS_MAU_SON>");
            this.dich_tstc.Add(tstc.ds_mau_son);

            this.nguon_tstc.Add("<TSTC_DS_TAI_TRONG>");
            this.dich_tstc.Add(tstc.ds_tai_trong);

            this.nguon_tstc.Add("<TSTC_DS_SO_CHO>");
            this.dich_tstc.Add(tstc.ds_so_cho);

            this.nguon_tstc.Add("<TSTC_DS_SO_MAY>");
            this.dich_tstc.Add(tstc.ds_so_may);

            this.nguon_tstc.Add("<TSTC_DS_SO_KHUNG>");
            this.dich_tstc.Add(tstc.ds_so_khung);

            this.nguon_tstc.Add("<TSTC_DS_SO_LOAI>");
            this.dich_tstc.Add(tstc.ds_so_loai);

            this.nguon_tstc.Add("<TSTC_DS_DUNG_TICH>");
            this.dich_tstc.Add(tstc.ds_dung_tich);

            this.nguon_tstc.Add("<TSTC_DS_NAM_SAN_XUAT>");
            this.dich_tstc.Add(tstc.ds_nam_san_xuat);

            this.nguon_tstc.Add("<TSTC_DS_BIEN_SO>");
            this.dich_tstc.Add(tstc.ds_bien_so);

            this.nguon_tstc.Add("<TSTC_DS_GIAY_SO_HUU>");
            this.dich_tstc.Add(tstc.ds_giay_so_huu);

            this.nguon_tstc.Add("<TSTC_DS_THONG_TIN_KHAC>");
            this.dich_tstc.Add(tstc.ds_thong_tin_khac);

            this.nguon_tstc.Add("<TSTC_BDS_TEN>");
            this.dich_tstc.Add(tstc.bds_ten);

            this.nguon_tstc.Add("<TSTC_BDS_SO_THUA_DAT>");
            this.dich_tstc.Add(tstc.bds_so_thua_dat);

            this.nguon_tstc.Add("<TSTC_BDS_SO_BAN_DO>");
            this.dich_tstc.Add(tstc.bds_so_ban_do);

            this.nguon_tstc.Add("<TSTC_BDS_DIA_CHI>");
            this.dich_tstc.Add(tstc.bds_dia_chi);

            this.nguon_tstc.Add("<TSTC_BDS_TONG_DIEN_TICH>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_tong_dien_tich));

            this.nguon_tstc.Add("<TSTC_BDS_TONG_DIEN_TICH_BANG_CHU>");
            this.dich_tstc.Add(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.bds_tong_dien_tich)));

            this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_DAT_O>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_o));

            this.nguon_tstc.Add("<TSTC_BDS_DAT_KHAC>");
            this.dich_tstc.Add(tstc.bds_dat_khac);

            this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_DAT_KHAC>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_dien_tich_dat_khac));

            this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_SU_DUNG_RIENG>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_dien_tich_su_dung_rieng));

            this.nguon_tstc.Add("<TSTC_BDS_DIEN_TICH_SU_DUNG_CHUNG>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_dien_tich_su_dung_chung));

            this.nguon_tstc.Add("<TSTC_BDS_MUC_DICH_SU_DUNG>");
            this.dich_tstc.Add(tstc.bds_muc_dich_su_dung);

            this.nguon_tstc.Add("<TSTC_BDS_THOI_HAN_SU_DUNG>");
            this.dich_tstc.Add(tstc.bds_thoi_han_su_dung);

            this.nguon_tstc.Add("<TSTC_BDS_NGUON_GOC_SU_DUNG>");
            this.dich_tstc.Add(tstc.bds_nguon_goc_su_dung);

            this.nguon_tstc.Add("<TSTC_BDS_HAN_CHE_SU_DUNG>");
            this.dich_tstc.Add(tstc.bds_han_che_su_dung);

            this.nguon_tstc.Add("<TSTC_BDS_NHA_LOAI_NHA>");
            this.dich_tstc.Add(tstc.bds_nha_loai_nha);

            this.nguon_tstc.Add("<TSTC_BDS_NHA_DIEN_TICH_SU_DUNG>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_nha_dien_tich_su_dung));

            this.nguon_tstc.Add("<TSTC_BDS_NHA_DIEN_TICH_XAY_DUNG>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_nha_dien_tich_xay_dung));

            this.nguon_tstc.Add("<TSTC_BDS_NHA_KET_CAU>");
            this.dich_tstc.Add(tstc.bds_nha_ket_cau);

            this.nguon_tstc.Add("<TSTC_BDS_NHA_SO_TANG>");
            this.dich_tstc.Add(tstc.bds_nha_so_tang);

            this.nguon_tstc.Add("<TSTC_BDS_NHA_GIA_TRI>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_nha_gia_tri));

            this.nguon_tstc.Add("<TSTC_BDS_NHA_GIA_TRI_BANG_CHU>");
            this.dich_tstc.Add(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.bds_nha_gia_tri)));

            this.nguon_tstc.Add("<TSTC_BDS_CTXD_LOAI_CONG_TRINH>");
            this.dich_tstc.Add(tstc.bds_ctxd_loai_cong_trinh);

            this.nguon_tstc.Add("<TSTC_BDS_CTXD_DIEN_TICH_XAY_DUNG>");
            this.dich_tstc.Add(ControlFormat.ToFormatDientich(tstc.bds_ctxd_dien_tich_xay_dung));

            this.nguon_tstc.Add("<TSTC_BDS_CTXD_KET_CAU>");
            this.dich_tstc.Add(tstc.bds_ctxd_ket_cau);

            this.nguon_tstc.Add("<TSTC_BDS_CTXD_SO_TANG>");
            this.dich_tstc.Add(tstc.bds_ctxd_so_tang);

            this.nguon_tstc.Add("<TSTC_BDS_CTXD_GIA_TRI>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_ctxd_gia_tri));

            this.nguon_tstc.Add("<TSTC_BDS_CTXD_GIA_TRI_BANG_CHU>");
            this.dich_tstc.Add(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.bds_ctxd_gia_tri)));

            this.nguon_tstc.Add("<TSTC_BDS_TS_GAN_LIEN_KHAC>");
            this.dich_tstc.Add(tstc.bds_ts_gan_lien_khac);

            this.nguon_tstc.Add("<TSTC_BDS_TS_GAN_LIEN_KHAC_GIA_TRI");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_ts_gan_lien_khac_gia_tri));

            this.nguon_tstc.Add("<TSTC_BDS_TS_GAN_LIEN_KHAC_GIA_TRI_BANG_CHU>");
            this.dich_tstc.Add(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.bds_ts_gan_lien_khac_gia_tri)));

            this.nguon_tstc.Add("<TSTC_BDS_QUYET_DINH_CAP_DAT>");
            this.dich_tstc.Add(tstc.bds_quyet_dinh_cap_dat);

            this.nguon_tstc.Add("<TSTC_BDS_QUYEN_SU_DUNG_DAT>");
            this.dich_tstc.Add(tstc.bds_quyen_su_dung_dat);

            this.nguon_tstc.Add("<TSTC_BDS_GIAY_PHEP_XAY_DUNG>");
            this.dich_tstc.Add(tstc.bds_giay_phep_xay_dung);

            this.nguon_tstc.Add("<TSTC_BDS_THIET_KE_KY_THUAT>");
            this.dich_tstc.Add(tstc.bds_thiet_ke_ky_thuat);

            this.nguon_tstc.Add("<TSTC_BDS_GIAY_TO_KHAC>");
            this.dich_tstc.Add(tstc.bds_giay_to_khac);

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.bds_gia_tri));

            this.nguon_tstc.Add("<TSTC_BDS_GIA_TRI_BANG_CHU>");
            this.dich_tstc.Add(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.bds_gia_tri)));

            this.nguon_tstc.Add("<TSTC_TSTC_KHAC_TEN>");
            this.dich_tstc.Add(tstc.tstc_khac_ten);

            this.nguon_tstc.Add("<TSTC_TSTC_KHAC_MO_TA>");
            this.dich_tstc.Add(tstc.tstc_khac_mo_ta);

            this.nguon_tstc.Add("<TSTC_TSTC_KHAC_GIAY_TO>");
            this.dich_tstc.Add(tstc.tstc_khac_giay_to);

            this.nguon_tstc.Add("<TSTC_TSTC_KHAC_GIA_TRI>");
            this.dich_tstc.Add(ControlFormat.ToFormatPrice(tstc.tstc_khac_gia_tri));

            this.nguon_tstc.Add("<TSTC_TSTC_KHAC_GIA_TRI_BANG_CHU>");
            this.dich_tstc.Add(CommonMethods.ChuyenSoSangChu(Convert.ToString(tstc.tstc_khac_gia_tri)));

            this.nguon_tstc.Add("<TSTC_TSTC_HTTTL>");
            this.dich_tstc.Add(Convert.ToString(tstc.tstc_htttl));

            //Lấy thông tin số biên bản định giá
            this.nguon_tstc.Add("<BBDG_MA_BBDG>");
            this.dich_tstc.Add(CommonMethods.TachMaHopDong(tstc.ma_hd_vay) + "-" + Convert.ToString(tstc.ma_ts_the_chap));
        }
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

             this.nguon_thong_tin_chung.Add("<HDV_NGAY>");
             this.dich_thong_tin_chung.Add(txtNgay_hop_dong_tin_dung.Text);

             this.HOP_DONG_TIN_DUNG(txtLoai_hop_dong_tin_dung.Text);
         }
        //private void btnTao_hop_dong_tin_dung_Click(object sender, EventArgs e)
        //{
            //Kiểm tra đã chọn loại hợp đồng chưa
            //if (string.IsNullOrEmpty(cboxLoai_hop_dong_tin_dung.Text))
            //{
            //    MessageBox.Show("Bạn chưa chọn loại hợp đồng");
            //    cboxLoai_hop_dong_tin_dung.Focus();
            //    return;
            //}
            //Kiểm tra xem đã chọn hợp đồng vay hay chưa
            //if (string.IsNullOrEmpty(txtMa_hd_vay.Text))
            //{
            //    MessageBox.Show("Bạn chưa chọn hợp đồng (trường bắt buộc)");
            //    txtMa_hd_vay.Focus();
            //    return;
            //}
            ////Kiểm tra dữ liệu ngày hợp đồng đã đúng định dạng hay chưa
            //if (txtNgay_hop_dong_tin_dung.Text == "  /  /")
            //{
            //    MessageBox.Show("Bạn chưa nhập ngày hợp đồng (trường bắt buộc)");
            //    txtNgay_hop_dong_tin_dung.Focus();
            //    return;
            //}
            //else if (!CommonMethods.KiemTraNhapNgay(txtNgay_hop_dong_tin_dung.Text))
            //{
            //    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
            //    txtNgay_hop_dong_tin_dung.Focus();
            //    return;
            //}

            //this.nguon_thong_tin_chung.Add("<HDV_NGAY>");
            //this.dich_thong_tin_chung.Add(txtNgay_hop_dong_tin_dung.Text);

            //this.HOP_DONG_TIN_DUNG(txtLoai_hop_dong_tin_dung.Text);
            
            //Lấy dữ liệu ngày trên hợp đồng vay
            //Specify exactly how to interpret the string.
            //IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            //DateTime dt = DateTime.Parse(txtNgay_hop_dong_tin_dung.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            //this.nguon_thong_tin_chung.Add("<HDV_NGAY>");
            //this.dich_thong_tin_chung.Add(Convert.ToString(dt.Day));

            //this.nguon_thong_tin_chung.Add("<HDV_THANG>");
            //this.dich_thong_tin_chung.Add(Convert.ToString(dt.Month));

            //this.nguon_thong_tin_chung.Add("<HDV_NAM>");
            //this.dich_thong_tin_chung.Add(Convert.ToString(dt.Year));

            //switch (txtLoai_hop_dong_tin_dung.Text)
            //{
            //    case "Hợp đồng cấp tín dụng từng lần cho doanh nghiệp - TUNG_LAN_TC":
            //        this.HOP_DONG_TIN_DUNG("TO_CHUC_HDTD_TUNG_LAN_TC");
            //        break;
            //    case "Hợp đồng cấp tín dụng hạn mức cho doanh nghiệp (không bảo lãnh) - HMTD_KBL_TC":
            //        this.HOP_DONG_TIN_DUNG("TO_CHUC_HDTD_HMTD_KBL_TC");
            //        break;
            //    case "Hợp đồng cấp tín dụng hạn mức cho doanh nghiệp (có bảo lãnh) - HMTD_CBL_TC":
            //        this.HOP_DONG_TIN_DUNG("TO_CHUC_HDTD_HMTD_CBL_TC");
            //        break;
            //    case "Hợp đồng cấp tín dụng từng lần cho hộ gia đình - TUNG_LAN_CHC":
            //        this.HOP_DONG_TIN_DUNG("HO_GIA_DINH_HDTD_TUNG_LAN_CHC");
            //        break;
            //    case "Hợp đồng cấp tín dụng từng lần cho hộ gia đình - TUNG_LAN_CHV":
            //        this.HOP_DONG_TIN_DUNG("HO_GIA_DINH_HDTD_TUNG_LAN_CHV");
            //        break;
            //    case "Hợp đồng cấp tín dụng hạn mức cho hộ gia đình (không bảo lãnh) - HMTD_KBL_CHC":
            //        this.HOP_DONG_TIN_DUNG("HO_GIA_DINH_HDTD_HMTD_KBL_CHC");
            //        break;
            //    case "Hợp đồng cấp tín dụng hạn mức cho hộ gia đình (không bảo lãnh) - HMTD_KBL_CHV":
            //        this.HOP_DONG_TIN_DUNG("HO_GIA_DINH_HDTD_HMTD_KBL_CHV");
            //        break;
            //    case "Hợp đồng cấp tín dụng hạn mức cho hộ gia đình (có bảo lãnh) - HMTD_CBL_CHC":
            //        this.HOP_DONG_TIN_DUNG("HO_GIA_DINH_HDTD_HMTD_CBL_CHC");
            //        break;
            //    case "Hợp đồng cấp tín dụng hạn mức cho hộ gia đình (có bảo lãnh) - HMTD_CBL_CHV":
            //        this.HOP_DONG_TIN_DUNG("HO_GIA_DINH_HDTD_HMTD_CBL_CHV");
            //        break;
            //    case "Hợp đồng cấp tín dụng từng lần cho cá nhân - TUNG_LAN_CN":
            //        this.HOP_DONG_TIN_DUNG("CA_NHAN_HDTD_TUNG_LAN_CN");
            //        break;
            //    case "Hợp đồng cấp tín dụng hạn mức cho cá nhân (không bảo lãnh) - HMTD_KBL_CN":
            //        this.HOP_DONG_TIN_DUNG("CA_NHAN_HDTD_HMTD_KBL_CN");
            //        break;
            //    case "Hợp đồng cấp tín dụng hạn mức cho cá nhân (có bảo lãnh) - HMTD_CBL_CN":
            //        this.HOP_DONG_TIN_DUNG("CA_NHAN_HDTD_HMTD_CBL_CN");
            //        break;
            //    default:
            //        MessageBox.Show("Chưa có mẫu hợp đồng tín dụng ứng với trường hợp này. Dề nghị liên hệ với phòng Điện toán (03203.890972)");
            //        break;
            //}
        //}
//-------------------------------------------------------------------------------------------------------------------------
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

        //private void dgvDanh_sach_tstc_SelectionChanged_1(object sender, EventArgs e)
        //{
        //    grbHop_dong_the_chap.Enabled = true;
        //    cboxLoai_hop_dong_the_chap.Items.Clear();
        //    grbBien_ban_dinh_gia.Enabled = true;           
        //    cboxLoai_bien_ban_dinh_gia.Items.Clear();
        //    grbDon_the_chap.Enabled = true;
        //    cboxLoai_don_the_chap.Items.Clear();
        //    int selectedrowindex = dgvDanh_sach_tstc.SelectedCells[0].RowIndex;
        //    DataGridViewRow selectedRow = dgvDanh_sach_tstc.Rows[selectedrowindex];
        //    int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
        //    Taisanthechap tstc = AGRIBANKHD.BUS.TaisanthechapBUS.TSTC_THEO_MA_TSTC(ma_ts_the_chap);
        //    //-----------------------------Tạo dữ liệu cho combo box Loại hợp đồng thế chấp---------------------------------------------------------------------------
        //    if (tstc.hinh_thuc_so_huu_cua_kh_vay == "Tài sản chính chủ")
        //    {
        //        if (!tstc.tstc_htttl)
        //        {
        //            if (tstc.loai_chu_so_huu == "Hộ gia đình")
        //            {
        //                if (tstc.loai_ts_the_chap == "Bất động sản")
        //                {
        //                    if (!string.IsNullOrEmpty(tstc.bds_nha_loai_nha) || !string.IsNullOrEmpty(tstc.bds_ctxd_loai_cong_trinh) || !string.IsNullOrEmpty(tstc.bds_ts_gan_lien_khac))
        //                    {
        //                        if (tstc.hgd_chu_ho == "Chồng")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền cho hộ gia đình - HGD-QSD-TSGL-CHC-TSCC");
        //                        }
        //                        else if (tstc.hgd_chu_ho == "Vợ")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền cho hộ gia đình - HGD-QSD-TSGL-CHV-TSCC");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (tstc.hgd_chu_ho == "Chồng")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất cho hộ gia đình - HGD-QSD-CHC-TSCC");
        //                        }
        //                        else if (tstc.hgd_chu_ho == "Vợ")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất cho hộ gia đình - HGD-QSD-CHV-TSCC");
        //                        }
        //                    }
        //                }
        //                else if (tstc.loai_ts_the_chap == "Động sản")
        //                {
        //                    if (tstc.hgd_chu_ho == "Chồng")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản cho hộ gia đình - HGD-DS-CHC-TSCC");
        //                    }
        //                    else if (tstc.hgd_chu_ho == "Vợ")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản cho hộ gia đình - HGD-DS-CHV-TSCC");
        //                    }

        //                }
        //                else if (tstc.loai_ts_the_chap == "Khác")
        //                {
        //                    if (tstc.hgd_chu_ho == "Chồng")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản khác cho hộ gia đình - HGD-TSK-CHC-TSCC");
        //                    }
        //                    else if (tstc.hgd_chu_ho == "Vợ")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản khác cho hộ gia đình - HGD-TSK-CHV-TSCC");
        //                    }
        //                }
        //            }
        //            else if (tstc.loai_chu_so_huu == "Cá nhân")
        //            {
        //                if (tstc.loai_ts_the_chap == "Bất động sản")
        //                {
        //                    if (!string.IsNullOrEmpty(tstc.bds_nha_loai_nha) || !string.IsNullOrEmpty(tstc.bds_ctxd_loai_cong_trinh) || !string.IsNullOrEmpty(tstc.bds_ts_gan_lien_khac))
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền cho cá nhân - CN-QSD-TSGL-TSCC");
        //                    }
        //                    else
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất cho cá nhân - CN-QSD-TSCC");
        //                    }
        //                }
        //                else if (tstc.loai_ts_the_chap == "Động sản")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản cho cá nhân - CN-DS-TSCC");
        //                }
        //                else if (tstc.loai_ts_the_chap == "Khác")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản khác cho cá nhân - CN-TSK-TSCC");
        //                }
        //            }
        //            else if (tstc.loai_chu_so_huu == "Tổ chức")
        //            {
        //                if (tstc.loai_ts_the_chap == "Bất động sản")
        //                {
        //                    if (!string.IsNullOrEmpty(tstc.bds_nha_loai_nha) || !string.IsNullOrEmpty(tstc.bds_ctxd_loai_cong_trinh) || !string.IsNullOrEmpty(tstc.bds_ts_gan_lien_khac))
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền cho tổ chức - TC-QSD-TSGL-TSCC");
        //                    }
        //                    else
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất cho tổ chức - TC-QSD-TSCC");
        //                    }
        //                }
        //                else if (tstc.loai_ts_the_chap == "Động sản")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản cho tổ chức - TC-DS-TSCC");
        //                }
        //                else if (tstc.loai_ts_the_chap == "Khác")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản khác cho tổ chức - TC-TSK-TSCC");
        //                }
        //            }    
        //        }
        //        else if(tstc.tstc_htttl)
        //        {
        //            //LATER;
        //        }                            
        //    }
        //    else if (tstc.hinh_thuc_so_huu_cua_kh_vay == "Tài sản bên thứ ba")
        //    {
        //        List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(CommonMethods.TachMaHopDong(_ma_hd_vay), txtma_CN.Text);
        //        Hopdongvay hd = HD_VAY_theoma_HD[0];
        //        DataTable ds_kh_vay_theo_ma = AGRIBANKHD.BUS.KhachhangvayBUS.DS_KH_VAY_THEO_MA(hd.ma_kh_vay);
        //        DataRow row = ds_kh_vay_theo_ma.Rows[0];
        //        Khachhangvay khv = new Khachhangvay(row);
        //        if (tstc.loai_chu_so_huu == "Hộ gia đình")
        //        {
        //            if (tstc.loai_ts_the_chap == "Bất động sản")
        //            {
        //                if (!string.IsNullOrEmpty(tstc.bds_nha_loai_nha) || !string.IsNullOrEmpty(tstc.bds_ctxd_loai_cong_trinh) || !string.IsNullOrEmpty(tstc.bds_ts_gan_lien_khac))
        //                {
        //                    if (tstc.hgd_chu_ho == "Chồng")                               
        //                    {
        //                        if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHC_TSBTB_CHC");
        //                        }
        //                        else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHC_TSBTB_CHV");
        //                        }
        //                        else if (khv.loai_kh == "Cá nhân")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHC_TSBTB_CN");
        //                        }
        //                        else if (khv.loai_kh == "Tổ chức")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHC_TSBTB_TC");
        //                        }
        //                    }
        //                    else if (tstc.hgd_chu_ho == "Vợ")
        //                    {
        //                        if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHV_TSBTB_CHC");
        //                        }
        //                        else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHV_TSBTB_CHC");
        //                        }
        //                        else if (khv.loai_kh == "Cá nhân")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHV_TSBTB_CN");
        //                        }
        //                        else if (khv.loai_kh == "Tổ chức")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHV_TSBTB_TC");
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (tstc.hgd_chu_ho == "Chồng")
        //                    {
        //                        if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHC_TSBTB_CHC");
        //                        }
        //                        else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHC_TSBTB_CHV");
        //                        }
        //                        else if (khv.loai_kh == "Cá nhân")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHC_TSBTB_CN");
        //                        }
        //                        else if (khv.loai_kh == "Tổ chức")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHC_TSBTB_TC");
        //                        }
        //                    }
        //                    else if (tstc.hgd_chu_ho == "Vợ")
        //                    {
        //                        if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHV_TSBTB_CHC");
        //                        }
        //                        else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHV_TSBTB_CHV");
        //                        }
        //                        else if (khv.loai_kh == "Cá nhân")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHV_TSBTB_CN");
        //                        }
        //                        else if (khv.loai_kh == "Tổ chức")
        //                        {
        //                            cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHV_TSBTB_TC");
        //                        }
        //                    }
        //                }
        //            }
        //            else if (tstc.loai_ts_the_chap == "Động sản")
        //            {
        //                if (tstc.hgd_chu_ho == "Chồng")
        //                {
        //                    if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHC_TSBTB_CHC");
        //                    }
        //                    else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHC_TSBTB_CHV");
        //                    }
        //                    else if (khv.loai_kh == "Cá nhân")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHC_TSBTB_CN");
        //                    }
        //                    else if (khv.loai_kh == "Tổ chức")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHC_TSBTB_TC");
        //                    }
        //                }
        //                else if (tstc.hgd_chu_ho == "Vợ")
        //                {
        //                    if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHV_TSBTB_CHC");
        //                    }
        //                    else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHV_TSBTB_CHV");
        //                    }
        //                    else if (khv.loai_kh == "Cá nhân")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHV_TSBTB_CN");
        //                    }
        //                    else if (khv.loai_kh == "Tổ chức")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHV_TSBTB_TC");
        //                    }
        //                }
        //            }
        //            else if (tstc.loai_ts_the_chap == "Khác")
        //            {
        //                if (tstc.hgd_chu_ho == "Chồng")
        //                {
        //                    if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHC_TSBTB_CHC");
        //                    }
        //                    else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHC_TSBTB_CHV");
        //                    }
        //                    else if (khv.loai_kh == "Cá nhân")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHC_TSBTB_CN");
        //                    }
        //                    else if (khv.loai_kh == "Tổ chức")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHC_TSBTB_TC");
        //                    }
        //                }
        //                else if (tstc.hgd_chu_ho == "Vợ")
        //                {
        //                    if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHV_TSBTB_CHC");
        //                    }
        //                    else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHV_TSBTB_CHV");
        //                    }
        //                    else if (khv.loai_kh == "Cá nhân")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHV_TSBTB_CN");
        //                    }
        //                    else if (khv.loai_kh == "Tổ chức")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHV_TSBTB_TC");
        //                    }
        //                }
        //            }
        //        }
        //        else if (tstc.loai_chu_so_huu == "Cá nhân")
        //        {
        //            if (tstc.loai_ts_the_chap == "Bất động sản")
        //            {
        //                if (!string.IsNullOrEmpty(tstc.bds_nha_loai_nha) || !string.IsNullOrEmpty(tstc.bds_ctxd_loai_cong_trinh) || !string.IsNullOrEmpty(tstc.bds_ts_gan_lien_khac))
        //                {
        //                    if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CN_TSBTB_CHC");
        //                    }
        //                    else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CN_TSBTB_CHV");
        //                    }
        //                    else if (khv.loai_kh == "Cá nhân")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CN_TSBTB_CN");
        //                    }
        //                    else if (khv.loai_kh == "Tổ chức")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CN_TSBTB_TC");
        //                    }
        //                }
        //                else
        //                {
        //                    if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CN_TSBTB_CHC");
        //                    }
        //                    else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CN_TSBTB_CHV");
        //                    }
        //                    else if (khv.loai_kh == "Cá nhân")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CN_TSBTB_CN");
        //                    }
        //                    else if (khv.loai_kh == "Tổ chức")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CN_TSBTB_TC");
        //                    }
        //                }
        //            }
        //            else if (tstc.loai_ts_the_chap == "Động sản")
        //            {
        //                if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CN_TSBTB_CHC");
        //                }
        //                else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CN_TSBTB_CHV");
        //                }
        //                else if (khv.loai_kh == "Cá nhân")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CN_TSBTB_CN");
        //                }
        //                else if (khv.loai_kh == "Tổ chức")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CN_TSBTB_TC");
        //                }
        //            }
        //            else if (tstc.loai_ts_the_chap == "Khác")
        //            {
        //                if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CN_TSBTB_CHC");
        //                }
        //                else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CN_TSBTB_CHV");
        //                }
        //                else if (khv.loai_kh == "Cá nhân")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CN_TSBTB_CN");
        //                }
        //                else if (khv.loai_kh == "Tổ chức")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_CN_TSBTB_TC");
        //                }
        //            }
        //        }
        //        else if (tstc.loai_chu_so_huu == "Tổ chức")
        //        {
        //            if (tstc.loai_ts_the_chap == "Bất động sản")
        //            {
        //                if (!string.IsNullOrEmpty(tstc.bds_nha_loai_nha) || !string.IsNullOrEmpty(tstc.bds_ctxd_loai_cong_trinh) || !string.IsNullOrEmpty(tstc.bds_ts_gan_lien_khac))
        //                {
        //                    if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_TC_TSBTB_CHC");
        //                    }
        //                    else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_TC_TSBTB_CHV");
        //                    }
        //                    else if (khv.loai_kh == "Cá nhân")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_TC_TSBTB_CN");
        //                    }
        //                    else if (khv.loai_kh == "Tổ chức")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_TC_TSBTB_TC");
        //                    }
        //                }
        //                else
        //                {
        //                    if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_TC_TSBTB_CHC");
        //                    }
        //                    else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_TC_TSBTB_CHV");
        //                    }
        //                    else if (khv.loai_kh == "Cá nhân")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_TC_TSBTB_CN");
        //                    }
        //                    else if (khv.loai_kh == "Tổ chức")
        //                    {
        //                        cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_TC_TSBTB_TC");
        //                    }
        //                }
        //            }
        //            else if (tstc.loai_ts_the_chap == "Động sản")
        //            {
        //                if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_TC_TSBTB_CHC");
        //                }
        //                else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_TC_TSBTB_CHV");
        //                }
        //                else if (khv.loai_kh == "Cá nhân")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_TC_TSBTB_CN");
        //                }
        //                else if (khv.loai_kh == "Tổ chức")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_TC_TSBTB_TC");
        //                }
        //            }
        //            else if (tstc.loai_ts_the_chap == "Khác")
        //            {
        //                if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Chồng")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_TC_TSBTB_CHC");
        //                }
        //                else if (khv.loai_kh == "Hộ gia đình" && khv.hgd_dai_dien == "Vợ")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_TC_TSBTB_CHV");
        //                }
        //                else if (khv.loai_kh == "Cá nhân")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_TC_TSBTB_CN");
        //                }
        //                else if (khv.loai_kh == "Tổ chức")
        //                {
        //                    cboxLoai_hop_dong_the_chap.Items.Add("Hợp đồng thế chấp tài sản bên thứ ba - TSK_TC_TSBTB_TC");
        //                }
        //            }
        //        }
        //    }
        //    cboxLoai_hop_dong_the_chap.ResetText();
        //    //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //    //-----------------------------Tạo dữ liệu cho combo box Loại biên bản định giá---------------------------------------------------------------------------
        //    if (tstc.loai_ts_the_chap == "Bất động sản")
        //    {
        //        if (!string.IsNullOrEmpty(tstc.bds_nha_loai_nha) || !string.IsNullOrEmpty(tstc.bds_ctxd_loai_cong_trinh) || !string.IsNullOrEmpty(tstc.bds_ts_gan_lien_khac))
        //        {
        //            if (tstc.loai_chu_so_huu == "Hộ gia đình" && tstc.hgd_chu_ho == "Chồng")
        //            {
        //                cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - BDS_CHC_QSD_TSGL");
        //            }
        //            else if (tstc.loai_chu_so_huu == "Hộ gia đình" && tstc.hgd_chu_ho == "Vợ")
        //            {
        //                cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - BDS_CHV_QSD_TSGL");
        //            }
        //            else if (tstc.loai_chu_so_huu == "Cá nhân")
        //            {
        //                cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - BDS_CN_QSD_TSGL");
        //            }
        //            else if (tstc.loai_chu_so_huu == "Tổ chức")
        //            {
        //                cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - BDS_TC_QSD_TSGL");
        //            }
        //        }
        //        else
        //        {
        //            if (tstc.loai_chu_so_huu == "Hộ gia đình" && tstc.hgd_chu_ho == "Chồng")
        //            {
        //                cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - BDS_CHC_QSD");
        //            }
        //            else if (tstc.loai_chu_so_huu == "Hộ gia đình" && tstc.hgd_chu_ho == "Vợ")
        //            {
        //                cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - BDS_CHV_QSD");
        //            }
        //            else if (tstc.loai_chu_so_huu == "Cá nhân")
        //            {
        //                cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - BDS_CN_QSD");
        //            }
        //            else if (tstc.loai_chu_so_huu == "Tổ chức")
        //            {
        //                cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - BDS_TC_QSD");
        //            }
        //        }              
        //    }
        //    else if (tstc.loai_ts_the_chap == "Động sản")
        //    {
        //        if (tstc.loai_chu_so_huu == "Hộ gia đình" && tstc.hgd_chu_ho == "Chồng")
        //        {
        //            cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - DS_CHC");
        //        }
        //        else if (tstc.loai_chu_so_huu == "Hộ gia đình" && tstc.hgd_chu_ho == "Vợ")
        //        {
        //            cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - DS_CHV");
        //        }
        //        else if (tstc.loai_chu_so_huu == "Cá nhân")
        //        {
        //            cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - DS_CN");
        //        }
        //        else if (tstc.loai_chu_so_huu == "Tổ chức")
        //        {
        //            cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - DS_TC");
        //        }
        //    }
        //    else if (tstc.loai_ts_the_chap == "Khác")
        //    {
        //        if (tstc.loai_chu_so_huu == "Hộ gia đình" && tstc.hgd_chu_ho == "Chồng")
        //        {
        //            cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - TSK_CHC");
        //        }
        //        else if (tstc.loai_chu_so_huu == "Hộ gia đình" && tstc.hgd_chu_ho == "Vợ")
        //        {
        //            cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - TSK_CHV");
        //        }
        //        else if (tstc.loai_chu_so_huu == "Cá nhân")
        //        {
        //            cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - TSK_CN");
        //        }
        //        else if (tstc.loai_chu_so_huu == "Tổ chức")
        //        {
        //            cboxLoai_bien_ban_dinh_gia.Items.Add("Biên bản định giá tài sản bảo đảm - TSK_TC");
        //        }
        //    }
        //    cboxLoai_bien_ban_dinh_gia.ResetText();

        //    //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //    //-----------------------------Tạo dữ liệu cho combobox loại đơn thế chấp---------------------------------------------------------------------------
        //    if (tstc.loai_ts_the_chap == "Bất động sản")
        //    {
        //        if (tstc.loai_chu_so_huu == "Hộ gia đình" && tstc.hgd_chu_ho == "Chồng")
        //        {
        //            cboxLoai_don_the_chap.Items.Add("Đơn thế chấp - BDS_CHC");
        //        }
        //        else if (tstc.loai_chu_so_huu == "Hộ gia đình" && tstc.hgd_chu_ho == "Vợ")
        //        {
        //            cboxLoai_don_the_chap.Items.Add("Đơn thế chấp - BDS_CHC");
        //        }
        //        else if (tstc.loai_chu_so_huu == "Cá nhân")
        //        {
        //            cboxLoai_don_the_chap.Items.Add("Đơn thế chấp - BDS_CHC");
        //        }
        //        else if (tstc.loai_chu_so_huu == "Tổ chức")
        //        {
        //            cboxLoai_don_the_chap.Items.Add("Đơn thế chấp - BDS_CHC");
        //        }
        //    }
        //    cboxLoai_don_the_chap.ResetText();
        //}        

        //private void btnTao_hop_dong_the_chap_Click(object sender, EventArgs e)
        //{
        //    //Kiểm tra đã chọn loại hợp đồng thế chấp hay chưa
        //    if (string.IsNullOrEmpty(cboxLoai_hop_dong_the_chap.Text))
        //    {
        //        MessageBox.Show("Bạn chưa chọn loại hợp đồng thế chấp");
        //        cboxLoai_hop_dong_the_chap.Focus();
        //        return;
        //    }
            
        //    //Kiểm tra dữ liệu ngày hợp đồng thế chấp đã đúng định dạng hay chưa
        //    if (string.IsNullOrEmpty(txtNgay_hop_dong_the_chap.Text))
        //    {
        //        MessageBox.Show("Bạn chưa nhập ngày hợp đồng thế chấp(trường bắt buộc)");
        //        txtNgay_hop_dong_the_chap.Focus();
        //        return;
        //    }
        //    else if (!CommonMethods.KiemTraNhapNgay(txtNgay_hop_dong_the_chap.Text))
        //    {
        //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
        //        txtNgay_hop_dong_the_chap.Focus();
        //        return;
        //    }
        //    //savefileTao_hop_dong_the_chap.Filter = "Word Documents|*.docx";
        //    //savefileTao_hop_dong_the_chap.ShowDialog();
        //    //Lấy dữ liệu ngày trên hợp đồng vay
        //    // Specify exactly how to interpret the string.
        //    IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
        //    DateTime dt = DateTime.Parse(txtNgay_hop_dong_the_chap.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        //    this.nguon_thong_tin_chung.Add("<HDTC_NGAY>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Day));

        //    this.nguon_thong_tin_chung.Add("<HDTC_THANG>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Month));

        //    this.nguon_thong_tin_chung.Add("<HDTC_NAM>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Year));

        //    int selectedrowindex = dgvDanh_sach_tstc.SelectedCells[0].RowIndex;
        //    DataGridViewRow selectedRow = dgvDanh_sach_tstc.Rows[selectedrowindex];
        //    int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
        //    this.Lay_thong_tin_tstc(ma_ts_the_chap);
        //    switch (cboxLoai_hop_dong_the_chap.Text)
        //    {
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền cho hộ gia đình - HGD-QSD-TSGL-CHC-TSCC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_TSGL_CHC_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền cho hộ gia đình - HGD-QSD-TSGL-CHV-TSCC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_TSGL_CHV_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất cho hộ gia đình - HGD-QSD-CHC-TSCC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_CHC_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất cho hộ gia đình - HGD-QSD-CHV-TSCC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_CHV_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền cho cá nhân - CN-QSD-TSGL-TSCC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_BDS_QSD_TSGL_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất cho cá nhân - CN-QSD-TSCC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_BDS_QSD_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền cho tổ chức - TC-QSD-TSGL-TSCC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_BDS_QSD_TSGL_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất cho tổ chức - TC-QSD-TSCC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_BDS_QSD_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp động sản cho hộ gia đình - HGD-DS-CHC-TSCC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_DS_CHC_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp động sản cho hộ gia đình - HGD-DS-CHV-TSCC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_DS_CHV_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp động sản cho cá nhân - CN-DS-TSCC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_DS_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp động sản cho tổ chức - TC-DS-TSCC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_DS_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản khác cho hộ gia đình - HGD-TSK-CHC-TSCC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_TSK_CHC_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản khác cho hộ gia đình - HGD-TSK-CHV-TSCC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_TSK_CHV_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản khác cho cá nhân - CN-TSK-TSCC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_TSK_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản khác cho tổ chức - TC-TSK-TSCC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_TSK_TSCC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHC_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_TSGL_CHC_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHC_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_TSGL_CHC_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHV_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_TSGL_CHV_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHV_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_TSGL_CHV_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHC_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_TSGL_CHC_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHV_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_TSGL_CHV_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHC_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_TSGL_CHC_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CHV_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_TSGL_CHV_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHC_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_CHC_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHC_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_CHC_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHV_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_CHV_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHV_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_CHV_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHC_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_CHC_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHC_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_CHC_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHV_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_CHV_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CHV_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_BDS_QSD_CHV_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHC_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_DS_CHC_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHC_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_DS_CHC_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHC_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_DS_CHC_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHC_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_DS_CHC_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHV_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_DS_CHV_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHV_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_DS_CHV_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHV_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_DS_CHV_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CHV_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_DS_CHV_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHC_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_TSK_CHC_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHC_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_TSK_CHC_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHC_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_TSK_CHC_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHC_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_TSK_CHC_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHV_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_TSK_CHV_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHV_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_TSK_CHV_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHV_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_TSK_CHV_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CHV_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("HO_GIA_DINH_HDTC_TSK_CHV_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CN_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_BDS_QSD_TSGL_CN_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CN_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_BDS_QSD_TSGL_CN_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CN_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_BDS_QSD_TSGL_CN_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_CN_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_BDS_QSD_TSGL_CN_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CN_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_BDS_QSD_CN_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CN_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_BDS_QSD_CN_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CN_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_BDS_QSD_CN_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_CN_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_BDS_QSD_CN_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CN_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_DS_CN_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CN_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_DS_CN_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CN_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_DS_CN_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_CN_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_DS_CN_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CN_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_TSK_CN_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CN_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_TSK_CN_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CN_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_TSK_CN_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_CN_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("CA_NHAN_HDTC_TSK_CN_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_TC_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_BDS_QSD_TSGL_TC_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_TC_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_BDS_QSD_TSGL_TC_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_TC_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_BDS_QSD_TSGL_TC_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất và tài sản gắn liền tài sản bên thứ ba - QSD_TSGL_TC_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_BDS_QSD_TSGL_TC_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_TC_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_BDS_QSD_TC_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_TC_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_BDS_QSD_TC_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_TC_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_BDS_QSD_TC_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp quyền sử dụng đất tài sản bên thứ ba - QSD_TC_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_BDS_QSD_TC_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_TC_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_DS_TC_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_TC_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_DS_TC_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_TC_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_DS_TC_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp động sản tài sản bên thứ ba - DS_TC_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_DS_TC_TSBTB_TC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_TC_TSBTB_CHC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_TSK_TC_TSBTB_CHC");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_TC_TSBTB_CHV":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_TSK_TC_TSBTB_CHV");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_TC_TSBTB_CN":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_TSK_TC_TSBTB_CN");
        //            break;
        //        case "Hợp đồng thế chấp tài sản bên thứ ba - TSK_TC_TSBTB_TC":
        //            this.HOP_DONG_THE_CHAP("TO_CHUC_HDTC_TSK_TC_TSBTB_TC");
        //            break;
        //        default:
        //            MessageBox.Show("Chưa có mẫu hợp đồng thế chấp ứng với trường hợp này. Dề nghị liên hệ với phòng Điện toán (03203.890972)");
        //            break;
        //    }
        //}

        //-------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------TẠO BIÊN BẢN ĐỊNH GIÁ --------------------------------------------------------------
        //internal void BIEN_BAN_DINH_GIA(string loai_bien_ban_dinh_gia)
        //{
        //    savefileTao_bien_ban_dinh_gia.Filter = "Word Documents|*.docx";
        //    if (savefileTao_bien_ban_dinh_gia.ShowDialog() == DialogResult.OK)
        //    {
        //        string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"BBDG\" + loai_bien_ban_dinh_gia + ".docx");
        //        CommonMethods.CreateWordDocument2(TemplateFileLocation, savefileTao_bien_ban_dinh_gia.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung, this.nguon_tstc, this.dich_tstc);
        //        MessageBox.Show("File đã được tạo tại đường dẫn: " + savefileTao_bien_ban_dinh_gia.FileName, "Tạo file thành công");
        //    }
        //}

        //private void btnTao_bien_ban_dinh_gia_Click(object sender, EventArgs e)
        //{
        //    //Kiểm tra đã chọn loại biên bản định giá hay chưa
        //    if (string.IsNullOrEmpty(cboxLoai_bien_ban_dinh_gia.Text))
        //    {
        //        MessageBox.Show("Bạn chưa chọn loại biên bản định giá");
        //        cboxLoai_bien_ban_dinh_gia.Focus();
        //        return;
        //    }
            
        //    //Kiểm tra dữ liệu ngày biên bản định giá đã đúng định dạng hay chưa
        //    if (string.IsNullOrEmpty(txtNgay_bien_ban_dinh_gia.Text))
        //    {
        //        MessageBox.Show("Bạn chưa nhập ngày của biên bản định giá(trường bắt buộc)");
        //        txtNgay_bien_ban_dinh_gia.Focus();
        //        return;
        //    }
        //    else if (!CommonMethods.KiemTraNhapNgay(txtNgay_bien_ban_dinh_gia.Text))
        //    {
        //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
        //        txtNgay_bien_ban_dinh_gia.Focus();
        //        return;
        //    }

        //    //Lấy dữ liệu ngày trên biên bản định giá
        //    // Specify exactly how to interpret the string.
        //    IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
        //    DateTime dt = DateTime.Parse(txtNgay_bien_ban_dinh_gia.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        //    this.nguon_thong_tin_chung.Add("<BBDG_NGAY>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Day));

        //    this.nguon_thong_tin_chung.Add("<BBDG_THANG>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Month));

        //    this.nguon_thong_tin_chung.Add("<BBDG_NAM>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Year));

            ////Lấy thông tin đánh giá tài sản bảo đảm
            //this.nguon_thong_tin_chung.Add("<BBDG_DANH_GIA_TSBD>");
            //this.dich_thong_tin_chung.Add(txtDanh_gia_tai_san_bao_dam.Text);
           
            ////---------------------------------------------------------------------
            //int selectedrowindex = dgvDanh_sach_tstc.SelectedCells[0].RowIndex;
            //DataGridViewRow selectedRow = dgvDanh_sach_tstc.Rows[selectedrowindex];
            //int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
            //this.Lay_thong_tin_tstc(ma_ts_the_chap);
            //switch (cboxLoai_bien_ban_dinh_gia.Text)
            //{
            //    case "Biên bản định giá tài sản bảo đảm - BDS_CHC_QSD_TSGL":
            //        this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_BDS_CHC_QSD_TSGL");
            //        break;
            //    case "Biên bản định giá tài sản bảo đảm - BDS_CHV_QSD_TSGL":
            //        this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_BDS_CHV_QSD_TSGL");
            //        break;
            //    case "Biên bản định giá tài sản bảo đảm - BDS_CN_QSD_TSGL":
            //        this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_BDS_CN_QSD_TSGL");
            //        break;
            //    case "Biên bản định giá tài sản bảo đảm - BDS_TC_QSD_TSGL":
            //        this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_BDS_TC_QSD_TSGL");
            //        break;
            //    case "Biên bản định giá tài sản bảo đảm - BDS_CHC_QSD":
            //        this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_BDS_CHC_QSD");
            //        break;
            //    case "Biên bản định giá tài sản bảo đảm - BDS_CHV_QSD":
            //        this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_BDS_CHV_QSD");
        //            break;
        //        case "Biên bản định giá tài sản bảo đảm - BDS_CN_QSD":
        //            this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_BDS_CN_QSD");
        //            break;
        //        case "Biên bản định giá tài sản bảo đảm - BDS_TC_QSD":
        //            this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_BDS_TC_QSD");
        //            break;
        //        case "Biên bản định giá tài sản bảo đảm - DS_CHC":
        //            this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_DS_CHC");
        //            break;
        //        case "Biên bản định giá tài sản bảo đảm - DS_CHV":
        //            this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_DS_CHV");
        //            break;
        //        case "Biên bản định giá tài sản bảo đảm - DS_CN":
        //            this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_DS_CN");
        //            break;
        //        case "Biên bản định giá tài sản bảo đảm - DS_TC":
        //            this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_DS_TC");
        //            break;
        //        case "Biên bản định giá tài sản bảo đảm - TSK_CHC":
        //            this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_TSK_CHC");
        //            break;
        //        case "Biên bản định giá tài sản bảo đảm - TSK_CHV":
        //            this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_TSK_CHV");
        //            break;
        //        case "Biên bản định giá tài sản bảo đảm - TSK_CN":
        //            this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_TSK_CN");
        //            break;
        //        case "Biên bản định giá tài sản bảo đảm - TSK_TC":
        //            this.BIEN_BAN_DINH_GIA("HO_GIA_DINH_BBDG_TSK_TC");
        //            break;
        //        default:
        //            MessageBox.Show("Chưa có mẫu biên bản định giá ứng với trường hợp này. Dề nghị liên hệ với phòng Điện toán (03203.890972)");
        //            break;
        //    }
        //}

        ////-------------------------------------------------------------------------------------------------------------------------
        ////-------------------------------------TẠO ĐƠN THẾ CHẤP --------------------------------------------------------------
        //internal void DON_THE_CHAP(string loai_don_the_chap)
        //{
        //    savefileTao_don_the_chap.Filter = "Word Documents|*.docx";
        //    if (savefileTao_don_the_chap.ShowDialog() == DialogResult.OK)
        //    {
        //        string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"DTC\" + loai_don_the_chap + ".docx");
        //        CommonMethods.CreateWordDocument2(TemplateFileLocation, savefileTao_don_the_chap.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung, this.nguon_tstc, this.dich_tstc);
        //        MessageBox.Show("File đã được tạo tại đường dẫn: " + savefileTao_don_the_chap.FileName, "Tạo file thành công");
        //    }
        //}
        //private void btnTao_don_the_chap_Click(object sender, EventArgs e)
        //{
        //    //Kiểm tra đã chọn loại đơn thế chấp hay chưa
        //    if (string.IsNullOrEmpty(cboxLoai_don_the_chap.Text))
        //    {
        //        MessageBox.Show("Bạn chưa chọn loại đơn thế chấp");
        //        cboxLoai_don_the_chap.Focus();
        //        return;
        //    }

        //    //Kiểm tra dữ liệu ngày trên đơn thế chấp đã đúng định dạng hay chưa
        //    if (string.IsNullOrEmpty(txtNgay_don_the_chap.Text))
        //    {
        //        MessageBox.Show("Bạn chưa nhập ngày của đơn thế chấp (trường bắt buộc)");
        //        txtNgay_don_the_chap.Focus();
        //        return;
        //    }
        //    else if (!CommonMethods.KiemTraNhapNgay(txtNgay_don_the_chap.Text))
        //    {
        //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
        //        txtNgay_don_the_chap.Focus();
        //        return;
        //    }

        //    //Lấy dữ liệu ngày trên dơn thế chấp
        //    // Specify exactly how to interpret the string.
        //    IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
        //    DateTime dt = DateTime.Parse(txtNgay_don_the_chap.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        //    this.nguon_thong_tin_chung.Add("<DTC_NGAY>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Day));

        //    this.nguon_thong_tin_chung.Add("<DTC_THANG>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Month));

        //    this.nguon_thong_tin_chung.Add("<DTC_NAM>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Year));

        //    //---------------------------------------------------------------------
        //    int selectedrowindex = dgvDanh_sach_tstc.SelectedCells[0].RowIndex;
        //    DataGridViewRow selectedRow = dgvDanh_sach_tstc.Rows[selectedrowindex];
        //    int ma_ts_the_chap = Convert.ToInt32(selectedRow.Cells["MA_TS_THE_CHAP"].Value);
        //    this.Lay_thong_tin_tstc(ma_ts_the_chap);
        //    switch (cboxLoai_don_the_chap.Text)
        //    {
        //        case "Đơn thế chấp - BDS_CHC":
        //            this.DON_THE_CHAP("HO_GIA_DINH_DTC_BDS_CHC");
        //            break;
        //        case "Đơn thế chấp - BDS_CHV":
        //            this.DON_THE_CHAP("HO_GIA_DINH_DTC_BDS_CHV");
        //            break;
        //        case "Đơn thế chấp - BDS_CN":
        //            this.DON_THE_CHAP("HO_GIA_DINH_DTC_BDS_CN");
        //            break;
        //        case "Đơn thế chấp - BDS_TC":
        //            this.DON_THE_CHAP("HO_GIA_DINH_DTC_BDS_TC");
        //            break;
        //        default:
        //            MessageBox.Show("Chưa có mẫu đơn thế chấp ứng với trường hợp này. Dề nghị liên hệ với phòng Điện toán (03203.890972)");
        //            break;
        //    }
        //}

        ////-------------------------------------------------------------------------------------------------------------------------
        ////-------------------------------------TẠO ĐỀ XUẤT GIẢI NGÂN --------------------------------------------------------------
        //internal void DE_XUAT_GIAI_NGAN(string loai_de_xuat_giai_ngan)
        //{
        //    savefileTao_de_xuat_giai_ngan.Filter = "Word Documents|*.docx";
        //    if (savefileTao_de_xuat_giai_ngan.ShowDialog() == DialogResult.OK)
        //    {
        //        string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"DXGN\" + loai_de_xuat_giai_ngan + ".docx");
        //        CommonMethods.CreateWordDocument2(TemplateFileLocation, savefileTao_de_xuat_giai_ngan.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung, this.nguon_tstc, this.dich_tstc);
        //        MessageBox.Show("File đã được tạo tại đường dẫn: " + savefileTao_de_xuat_giai_ngan.FileName, "Tạo file thành công");
        //    }
        //}

        //private void btnTao_de_xuat_giai_ngan_Click(object sender, EventArgs e)
        //{
        //    //Kiểm tra đã chọn ngày đề xuất giải ngân hay chưa
        //    if (string.IsNullOrEmpty(cboxLoai_de_xuat_giai_ngan.Text))
        //    {
        //        MessageBox.Show("Bạn chưa chọn loại đề xuất giải ngân");
        //        cboxLoai_de_xuat_giai_ngan.Focus();
        //        return;
        //    }

        //    //Kiểm tra dữ liệu ngày trên đơn thế chấp đã đúng định dạng hay chưa
        //    if (string.IsNullOrEmpty(txtNgay_de_xuat_giai_ngan.Text))
        //    {
        //        MessageBox.Show("Bạn chưa nhập ngày đề xuất giải ngân (trường bắt buộc)");
        //        txtNgay_de_xuat_giai_ngan.Focus();
        //        return;
        //    }
        //    else if (!CommonMethods.KiemTraNhapNgay(txtNgay_de_xuat_giai_ngan.Text))
        //    {
        //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
        //        txtNgay_de_xuat_giai_ngan.Focus();
        //        return;
        //    }

        //    //Kiểm tra đã nhập dư nợ đến thời điểm giải ngân hay chưa
        //    if (string.IsNullOrEmpty(txtDu_no_den_thoi_diem_giai_ngan.Text))
        //    {
        //        MessageBox.Show("Bạn chưa nhập dư nợ hiện tại");
        //        txtDu_no_den_thoi_diem_giai_ngan.Focus();
        //        return;
        //    }
        //    else if (!CommonMethods.KiemTraNhapSo_Int64(txtDu_no_den_thoi_diem_giai_ngan.Text))
        //    {
        //        MessageBox.Show("Dữ liệu nhập tại ô Dư nợ hiện tại chưa đúng, đề nghị kiểm tra lại!");
        //        txtDu_no_den_thoi_diem_giai_ngan.Focus();
        //        return;
        //    }

        //    //Kiểm tra đã nhập số tiền giải ngân hay chưa
        //    if (string.IsNullOrEmpty(txtSo_tien_de_nghi_giai_ngan.Text))
        //    {
        //        MessageBox.Show("Bạn chưa nhập số tiền đề nghị giải ngân");
        //        txtSo_tien_de_nghi_giai_ngan.Focus();
        //        return;
        //    }
        //    else if (!CommonMethods.KiemTraNhapSo_Int64(txtSo_tien_de_nghi_giai_ngan.Text))
        //    {
        //        MessageBox.Show("Dữ liệu nhập tại ô Số tiền đề nghị giải ngân chưa đúng, đề nghị kiểm tra lại!");
        //        txtSo_tien_de_nghi_giai_ngan.Focus();
        //        return;
        //    }

        //    //Kiểm tra đã nhập mục đích sử dụng vốn hay chưa
        //    if (string.IsNullOrEmpty(txtMuc_dich_su_dung_von.Text))
        //    {
        //        MessageBox.Show("Bạn chưa nhập số tiền đề nghị giải ngân");
        //        txtMuc_dich_su_dung_von.Focus();
        //        return;
        //    }

        //    //Kiểm tra đã nhập phương tiện thanh toán hay chưa
        //    if (string.IsNullOrEmpty(txtPhuong_tien_thanh_toan.Text))
        //    {
        //        MessageBox.Show("Bạn chưa nhập phương tiện thanh toán");
        //        txtPhuong_tien_thanh_toan.Focus();
        //        return;
        //    }

        //    //Kiểm tra đã nhập đơn vị thụ hưởng hay chưa
        //    if (string.IsNullOrEmpty(txtDon_vi_thu_huong.Text))
        //    {
        //        MessageBox.Show("Bạn chưa nhập đơn vị thụ hưởng");
        //        txtDon_vi_thu_huong.Focus();
        //        return;
        //    }

        //    //Lấy thông tin cho đề xuất giải ngân
        //    IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
        //    DateTime dt = DateTime.Parse(txtNgay_de_xuat_giai_ngan.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        //    this.nguon_thong_tin_chung.Add("<DXGN_NGAY>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Day));

        //    this.nguon_thong_tin_chung.Add("<DXGN_THANG>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Month));

        //    this.nguon_thong_tin_chung.Add("<DXGN_NAM>");
        //    this.dich_thong_tin_chung.Add(Convert.ToString(dt.Year));

        //    this.nguon_thong_tin_chung.Add("<DXGN_DU_NO_DEN_THOI_DIEM_GIAI_NGAN>");
        //    this.dich_thong_tin_chung.Add(ControlFormat.ToFormatPrice(Convert.ToInt64(txtDu_no_den_thoi_diem_giai_ngan.Text)));

        //    this.nguon_thong_tin_chung.Add("<DXGN_SO_TIEN_DE_NGHI_GIAI_NGAN>");
        //    this.dich_thong_tin_chung.Add(ControlFormat.ToFormatPrice(Convert.ToInt64(txtSo_tien_de_nghi_giai_ngan.Text)));

        //    this.nguon_thong_tin_chung.Add("<DXGN_SO_TIEN_DE_NGHI_GIAI_NGAN_BANG_CHU>");
        //    this.dich_thong_tin_chung.Add(CommonMethods.ChuyenSoSangChu(txtSo_tien_de_nghi_giai_ngan.Text));

        //    this.nguon_thong_tin_chung.Add("<DXGN_MUC_DICH_SU_DUNG_VONG>");
        //    this.dich_thong_tin_chung.Add(txtMuc_dich_su_dung_von.Text);

        //    this.nguon_thong_tin_chung.Add("<DXGN_PHUONG_TIEN_THANH_TOAN>");
        //    this.dich_thong_tin_chung.Add(txtPhuong_tien_thanh_toan.Text);

        //    this.nguon_thong_tin_chung.Add("<DXGN_DON_VI_THU_HUONG>");
        //    this.dich_thong_tin_chung.Add(txtDon_vi_thu_huong.Text);

        //    this.nguon_thong_tin_chung.Add("<DXGN_SO_TAI_KHOAN>");
        //    this.dich_thong_tin_chung.Add(txtSo_tai_khoan.Text);

        //    this.nguon_thong_tin_chung.Add("<DXGN_NGAN_HANG>");
        //    this.dich_thong_tin_chung.Add(txtNgan_hang.Text);

        //    switch (cboxLoai_de_xuat_giai_ngan.Text)
        //    {
        //        case "Đề xuất giải ngân đối với khách hàng là doanh nghiệp":
        //            this.DE_XUAT_GIAI_NGAN("TO_CHUC_DE_XUAT_GIAI_NGAN");
        //            break;
        //        default:
        //            MessageBox.Show("Chưa có mẫu đề xuất giải ngân ứng với trường hợp này. Dề nghị liên hệ với phòng Điện toán (03203.890972)");
        //            break;
        //    }
        //}
    }
}
