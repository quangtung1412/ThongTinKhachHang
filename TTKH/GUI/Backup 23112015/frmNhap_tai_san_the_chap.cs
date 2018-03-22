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
    public partial class frmNhap_tai_san_the_chap : Form
    {

        TaisanthechapBUS tstc_bus = new TaisanthechapBUS();
        //private string _ma_kh_vay = "";
        private string _ma_cn;

        private int _ma_ts_the_chap = 0;

        public frmNhap_tai_san_the_chap(string ma_hd_vay, string ma_cn)
        {
            InitializeComponent();
            txtma_hd_vay.Text = ma_hd_vay;
            this._ma_cn = ma_cn;
            cboxhinh_thuc_so_huu_cua_kh_vay.Text = "Tài sản bên thứ ba";
            cboxloai_chu_so_huu.Text = "Cá nhân";
            grbCn_thong_tin_csh.BringToFront();
            grbCn_thong_tin_csh.Visible = true;
            grbHgd_thong_tin_csh.Visible = true;
            grbTc_thong_tin_csh.Visible = true;
            grbThong_tin_tstc_bds.Visible = false;
            grbThong_tin_tstc_ds.Visible = false;
            grbThong_tin_tstc_khac.Visible = false;
            cboxLoai_ts_the_chap.Enabled = false;
            chboxtstc_htttl.Enabled = false;
            btnCap_nhat.Enabled = false;
            lblTai_san_cua.Visible = false;
            cboxhgd_nguoi_so_huu.Text = "Chung";
            cboxhgd_nguoi_so_huu.Visible = false;
            //Căn chỉnh các groupbox
            grbHgd_thong_tin_csh.Left = grbCn_thong_tin_csh.Left;
            grbHgd_thong_tin_csh.Top = grbCn_thong_tin_csh.Top;

            grbTc_thong_tin_csh.Left = grbCn_thong_tin_csh.Left;
            grbTc_thong_tin_csh.Top = grbTc_thong_tin_csh.Top;

            grbThong_tin_tstc_bds.Left = grbCn_thong_tin_csh.Left;
            grbThong_tin_tstc_bds.Top = grbCn_thong_tin_csh.Top;

            grbThong_tin_tstc_ds.Left = grbCn_thong_tin_csh.Left;
            grbThong_tin_tstc_ds.Top = grbCn_thong_tin_csh.Top;

            grbThong_tin_tstc_khac.Left = grbCn_thong_tin_csh.Left;
            grbThong_tin_tstc_khac.Top = grbCn_thong_tin_csh.Top;
        }

        public frmNhap_tai_san_the_chap(string ma_hd_vay, string ma_cn, int ma_ts_the_chap)
        {
            InitializeComponent();
            btnCap_nhat.Enabled = false;
            this._ma_ts_the_chap = ma_ts_the_chap;
            this._ma_cn = ma_cn;
            Taisanthechap tstc = TaisanthechapBUS.TSTC_THEO_MA_TSTC(ma_ts_the_chap);

            //Căn chỉnh các groupbox
            grbHgd_thong_tin_csh.Left = grbCn_thong_tin_csh.Left;
            grbHgd_thong_tin_csh.Top = grbCn_thong_tin_csh.Top;

            grbTc_thong_tin_csh.Left = grbCn_thong_tin_csh.Left;
            grbTc_thong_tin_csh.Top = grbTc_thong_tin_csh.Top;

            grbThong_tin_tstc_bds.Left = grbCn_thong_tin_csh.Left;
            grbThong_tin_tstc_bds.Top = grbCn_thong_tin_csh.Top;

            grbThong_tin_tstc_ds.Left = grbCn_thong_tin_csh.Left;
            grbThong_tin_tstc_ds.Top = grbCn_thong_tin_csh.Top;

            grbThong_tin_tstc_khac.Left = grbCn_thong_tin_csh.Left;
            grbThong_tin_tstc_khac.Top = grbCn_thong_tin_csh.Top;

            //Hiển thị groupbox chứa thông tin chủ sở hữu

            grbCn_thong_tin_csh.Visible = true;
            grbHgd_thong_tin_csh.Visible = true;
            grbTc_thong_tin_csh.Visible = true;
            
            //if (tstc.hinh_thuc_so_huu_cua_kh_vay == "Tài sản chính chủ")
            //{
            //    grbCn_thong_tin_csh.Enabled = false;
            //    grbHgd_thong_tin_csh.Enabled = false;
            //    grbTc_thong_tin_csh.Enabled = false;
            //}
            //else if (tstc.hinh_thuc_so_huu_cua_kh_vay == "Tài sản bên thứ ba")
            //{
            //    grbCn_thong_tin_csh.Enabled = true;
            //    grbHgd_thong_tin_csh.Enabled = true;
            //    grbTc_thong_tin_csh.Enabled = true;
            //}

            if (tstc.loai_chu_so_huu == "Cá nhân")
            {
                grbCn_thong_tin_csh.BringToFront();
            }
            else if (tstc.loai_chu_so_huu == "Hộ gia đình")
            {
                grbHgd_thong_tin_csh.BringToFront();
            }
            else if (tstc.loai_chu_so_huu == "Tổ chức")
            {
                grbTc_thong_tin_csh.BringToFront();
            }

            grbThong_tin_tstc_bds.Visible = false;
            grbThong_tin_tstc_ds.Visible = false;
            grbThong_tin_tstc_khac.Visible = false;
            cboxLoai_ts_the_chap.Enabled = false;
            cboxloai_chu_so_huu.Enabled = false;
            chboxtstc_htttl.Enabled = false;

            //Nạp thông tin vào groupbox

            //txtma_ts_the_chap.Text = tstc.ma_ts_the_chap;
            //if (tstc.hinh_thuc_so_huu_cua_kh_vay == "Tài sản chính chủ")
            //{
                //List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(CommonMethods.TachMaHopDong(tstc.ma_hd_vay), _ma_cn);
                //Hopdongvay hd = HD_VAY_theoma_HD[0];

                //DataTable DS_KH_VAY_THEO_MA = KhachhangvayBUS.DS_KH_VAY_THEO_MA(hd.ma_kh_vay);
                //DataRow row = DS_KH_VAY_THEO_MA.Rows[0];
                //Khachhangvay kh = new Khachhangvay(row);

            txtma_hd_vay.Text = tstc.ma_hd_vay;
            cboxloai_chu_so_huu.Text = tstc.loai_chu_so_huu;
            cboxLoai_ts_the_chap.Text = tstc.loai_ts_the_chap;
            cboxhinh_thuc_so_huu_cua_kh_vay.Text = tstc.hinh_thuc_so_huu_cua_kh_vay;
            cboxhinh_thuc_so_huu_cua_kh_vay.Enabled = false;

            cboxhgd_nguoi_so_huu.Text = tstc.hgd_nguoi_so_huu;
            if (tstc.hinh_thuc_so_huu_cua_kh_vay == "Tài sản chính chủ" && tstc.loai_chu_so_huu == "Hộ gia đình")
            {
                lblTai_san_cua.Visible = true;
                cboxhgd_nguoi_so_huu.Visible = true;
            }
            else
            {
                lblTai_san_cua.Visible = false;
                cboxhgd_nguoi_so_huu.Visible = false;
            }
            txtHgd_ten_chong.Text = tstc.hgd_ten_chong;
            txtHgd_ns_chong.Text = tstc.hgd_ns_chong;
            txtHgd_cmnd_chong.Text = tstc.hgd_cmnd_chong;
            txtHgd_ngay_cap_cmnd_chong.Text = tstc.hgd_ngay_cap_cmnd_chong;
            txtHgd_noi_cap_cmnd_chong.Text = tstc.hgd_noi_cap_cmnd_chong;
            txtHgd_dc_chong.Text = tstc.hgd_dc_chong;
            txtHgd_hktt_chong.Text = tstc.hgd_hktt_chong;
            txtHgd_so_hk_chong.Text = tstc.hgd_so_hk_chong;
            txtHgd_noi_cap_hk_chong.Text = tstc.hgd_noi_cap_hk_chong;
            txtHgd_ngay_cap_hk_chong.Text = tstc.hgd_ngay_cap_hk_chong;
            txtHgd_ten_vo.Text = tstc.hgd_ten_vo;
            txtHgd_ns_vo.Text = tstc.hgd_ns_vo;
            txtHgd_cmnd_vo.Text = tstc.hgd_cmnd_vo;
            txtHgd_ngay_cap_cmnd_vo.Text = tstc.hgd_ngay_cap_cmnd_vo;
            txtHgd_noi_cap_cmnd_vo.Text = tstc.hgd_noi_cap_cmnd_vo;
            txtHgd_dc_vo.Text = tstc.hgd_dc_vo;
            txtHgd_hktt_vo.Text = tstc.hgd_hktt_vo;
            txtHgd_so_hk_vo.Text = tstc.hgd_so_hk_vo;
            txtHgd_noi_cap_hk_vo.Text = tstc.hgd_noi_cap_hk_vo;
            txtHgd_ngay_cap_hk_vo.Text = tstc.hgd_ngay_cap_hk_vo;
            txtHgd_dkkd.Text = tstc.hgd_dkkd;
            txtHgd_dien_thoai.Text = tstc.hgd_dien_thoai;
            txtHgd_fax.Text = tstc.hgd_fax;
            txtHgd_email.Text = tstc.hgd_email;
            cboxhgd_chu_ho.Text = tstc.hgd_chu_ho;
            cboxCn_danh_xung.Text = tstc.cn_danh_xung;
            txtCn_ten.Text = tstc.cn_ten;
            txtCn_ns.Text = tstc.cn_ns;
            txtCn_cmnd.Text = tstc.cn_cmnd;
            txtCn_ngay_cap_cmnd.Text = tstc.cn_ngay_cap_cmnd;
            txtCn_noi_cap_cmnd.Text = tstc.cn_noi_cap_cmnd;
            txtCn_dc.Text = tstc.cn_dc;
            txtCn_hktt.Text = tstc.cn_hktt;
            txtCn_so_hk.Text = tstc.cn_so_hk;
            txtCn_noi_cap_hk.Text = tstc.cn_noi_cap_hk;
            txtCn_ngay_cap_hk.Text = tstc.cn_ngay_cap_hk;
            txtCn_dkkd.Text = tstc.cn_dkkd;
            txtCn_dien_thoai.Text = tstc.cn_dien_thoai;
            txtCn_fax.Text = tstc.cn_fax;
            txtCn_email.Text = tstc.cn_email;
            txtTc_ten.Text = tstc.tc_ten;
            txtTc_dkkd.Text = tstc.tc_dkkd;
            txtTc_dc.Text = tstc.tc_dc;
            cboxTc_danh_xung_dai_dien.Text = tstc.tc_danh_xung_dai_dien;
            txtTc_dai_dien.Text = tstc.tc_dai_dien;
            txtTc_ns_dai_dien.Text = tstc.tc_ns_dai_dien;
            txtTc_chuc_vu_dai_dien.Text = tstc.tc_chuc_vu_dai_dien;
            txtTc_giay_uy_quyen.Text = tstc.tc_giay_uy_quyen;
            txtTc_dc_dai_dien.Text = tstc.tc_dc_dai_dien;
            txtTc_cmnd_dai_dien.Text = tstc.tc_cmnd_dai_dien;
            txtTc_ngay_cap_cmnd_dai_dien.Text = tstc.tc_ngay_cap_cmnd_dai_dien;
            txtTc_noi_cap_cmnd_dai_dien.Text = tstc.tc_noi_cap_cmnd_dai_dien;
            txtTc_hktt_dai_dien.Text = tstc.tc_hktt_dai_dien;
            txtTc_so_hk_dai_dien.Text = tstc.tc_so_hk_dai_dien;
            txtTc_noi_cap_hk_dai_dien.Text = tstc.tc_noi_cap_hk_dai_dien;
            txtTc_ngay_cap_hk_dai_dien.Text = tstc.tc_ngay_cap_hk_dai_dien;
            txtTc_dien_thoai.Text = tstc.tc_dien_thoai;
            txtTc_fax.Text = tstc.tc_fax;
            txtTc_email.Text = tstc.tc_email;
            txtds_ten.Text = tstc.ds_ten;
            txtds_so_luong.Text = Convert.ToString(tstc.ds_so_luong);
            txtds_gia_tri.Text = Convert.ToString(tstc.ds_gia_tri);
            txtds_nhan_hieu.Text = tstc.ds_nhan_hieu;
            txtds_loai_xe.Text = tstc.ds_loai_xe;
            txtds_mau_son.Text = tstc.ds_mau_son;
            txtds_tai_trong.Text = tstc.ds_tai_trong;
            txtds_so_cho.Text = tstc.ds_so_cho;
            txtds_so_may.Text = tstc.ds_so_may;
            txtds_so_khung.Text = tstc.ds_so_khung;
            txtds_so_loai.Text = tstc.ds_so_loai;
            txtds_dung_tich.Text = tstc.ds_dung_tich;
            txtds_nam_san_xuat.Text = tstc.ds_nam_san_xuat;
            txtds_bien_so.Text = tstc.ds_bien_so;
            txtds_giay_so_huu.Text = tstc.ds_giay_so_huu;
            txtds_thong_tin_khac.Text = tstc.ds_thong_tin_khac;
            txtbds_ten.Text = tstc.bds_ten;
            txtbds_so_thua_dat.Text = tstc.bds_so_thua_dat;
            txtbds_so_ban_do.Text = tstc.bds_so_ban_do;
            txtbds_dia_chi.Text = tstc.bds_dia_chi;
            txtbds_tong_dien_tich.Text = Convert.ToString(tstc.bds_tong_dien_tich);
            txtbds_dien_tich_dat_o.Text = Convert.ToString(tstc.bds_dien_tich_dat_o);
            txtbds_dat_khac.Text = tstc.bds_dat_khac;
            txtbds_dien_tich_dat_khac.Text = Convert.ToString(tstc.bds_dien_tich_dat_khac);
            txtbds_dien_tich_su_dung_rieng.Text = Convert.ToString(tstc.bds_dien_tich_su_dung_rieng);
            txtbds_dien_tich_su_dung_chung.Text = Convert.ToString(tstc.bds_dien_tich_su_dung_chung);
            txtbds_muc_dich_su_dung.Text = tstc.bds_muc_dich_su_dung;
            txtbds_thoi_han_su_dung.Text = tstc.bds_thoi_han_su_dung;
            txtbds_nguon_goc_su_dung.Text = tstc.bds_nguon_goc_su_dung;
            txtbds_han_che_su_dung.Text = tstc.bds_han_che_su_dung;
            txtbds_nha_loai_nha.Text = tstc.bds_nha_loai_nha;
            txtbds_nha_dien_tich_su_dung.Text = Convert.ToString(tstc.bds_nha_dien_tich_su_dung);
            txtbds_nha_dien_tich_xay_dung.Text = Convert.ToString(tstc.bds_nha_dien_tich_xay_dung);
            txtbds_nha_ket_cau.Text = tstc.bds_nha_ket_cau;
            txtbds_nha_so_tang.Text = tstc.bds_nha_so_tang;
            txtbds_nha_gia_tri.Text = Convert.ToString(tstc.bds_nha_gia_tri);
            txtbds_ctxd_loai_cong_trinh.Text = tstc.bds_ctxd_loai_cong_trinh;
            txtbds_ctxd_dien_tich_xay_dung.Text = Convert.ToString(tstc.bds_ctxd_dien_tich_xay_dung);
            txtbds_ctxd_ket_cau.Text = tstc.bds_ctxd_ket_cau;
            txtbds_ctxd_so_tang.Text = tstc.bds_ctxd_so_tang;
            txtbds_ctxd_gia_tri.Text = Convert.ToString(tstc.bds_ctxd_gia_tri);
            txtbds_ts_gan_lien_khac.Text = tstc.bds_ts_gan_lien_khac;
            txtbds_ts_gan_lien_khac_gia_tri.Text = Convert.ToString(tstc.bds_ts_gan_lien_khac_gia_tri);
            txtbds_quyet_dinh_cap_dat.Text = tstc.bds_quyet_dinh_cap_dat;
            txtbds_quyen_su_dung_dat.Text = tstc.bds_quyen_su_dung_dat;
            txtbds_giay_phep_xay_dung.Text = tstc.bds_giay_phep_xay_dung;
            txtbds_thiet_ke_ky_thuat.Text = tstc.bds_thiet_ke_ky_thuat;
            txtbds_giay_to_khac.Text = tstc.bds_giay_to_khac;
            txtbds_gia_tri.Text = Convert.ToString(tstc.bds_gia_tri);
            txttstc_khac_ten.Text = tstc.tstc_khac_ten;
            txttstc_khac_mo_ta.Text = tstc.tstc_khac_mo_ta;
            txttstc_khac_giay_to.Text = tstc.tstc_khac_giay_to;
            txttstc_khac_gia_tri.Text = Convert.ToString(tstc.tstc_khac_gia_tri);
            txtbds_gia_tri_qsd_dat_tren_m2.Text = Convert.ToString(tstc.bds_gia_tri_qsd_dat_tren_m2);
            txtbds_gia_tri_qsd_dat.Text = Convert.ToString(tstc.bds_gia_tri_qsd_dat);
            txtbds_gia_tri_tsgl_tren_m2.Text = Convert.ToString(tstc.bds_gia_tri_tsgl_tren_m2);
            txtbds_dien_tich_tsgl.Text = Convert.ToString(tstc.bds_dien_tich_tsgl);
            txtbds_gia_tri_tsgl.Text = Convert.ToString(tstc.bds_gia_tri_tsgl);
            //}
            //else if (tstc.hinh_thuc_so_huu_cua_kh_vay == "Tài sản bên thứ ba")
            //{
            //    txtma_hd_vay.Text = tstc.ma_hd_vay;
            //    cboxloai_chu_so_huu.Text = tstc.loai_chu_so_huu;
            //    cboxLoai_ts_the_chap.Text = tstc.loai_ts_the_chap;
            //    cboxhinh_thuc_so_huu_cua_kh_vay.Text = tstc.hinh_thuc_so_huu_cua_kh_vay;
            //    cboxhinh_thuc_so_huu_cua_kh_vay.Enabled = false;
            //    txtHgd_ten_chong.Text = tstc.hgd_ten_chong;
            //    txtHgd_ns_chong.Text = tstc.hgd_ns_chong;
            //    txtHgd_cmnd_chong.Text = tstc.hgd_cmnd_chong;
            //    txtHgd_ngay_cap_cmnd_chong.Text = tstc.hgd_ngay_cap_cmnd_chong;
            //    txtHgd_noi_cap_cmnd_chong.Text = tstc.hgd_noi_cap_cmnd_chong;
            //    txtHgd_dc_chong.Text = tstc.hgd_dc_chong;
            //    txtHgd_hktt_chong.Text = tstc.hgd_hktt_chong;
            //    txtHgd_so_hk_chong.Text = tstc.hgd_so_hk_chong;
            //    txtHgd_noi_cap_hk_chong.Text = tstc.hgd_noi_cap_hk_chong;
            //    txtHgd_ngay_cap_hk_chong.Text = tstc.hgd_ngay_cap_hk_chong;
            //    txtHgd_ten_vo.Text = tstc.hgd_ten_vo;
            //    txtHgd_ns_vo.Text = tstc.hgd_ns_vo;
            //    txtHgd_cmnd_vo.Text = tstc.hgd_cmnd_vo;
            //    txtHgd_ngay_cap_cmnd_vo.Text = tstc.hgd_ngay_cap_cmnd_vo;
            //    txtHgd_noi_cap_cmnd_vo.Text = tstc.hgd_noi_cap_cmnd_vo;
            //    txtHgd_dc_vo.Text = tstc.hgd_dc_vo;
            //    txtHgd_hktt_vo.Text = tstc.hgd_hktt_vo;
            //    txtHgd_so_hk_vo.Text = tstc.hgd_so_hk_vo;
            //    txtHgd_noi_cap_hk_vo.Text = tstc.hgd_noi_cap_hk_vo;
            //    txtHgd_ngay_cap_hk_vo.Text = tstc.hgd_ngay_cap_hk_vo;
            //    txtHgd_dkkd.Text = tstc.hgd_dkkd;
            //    txtHgd_dien_thoai.Text = tstc.hgd_dien_thoai;
            //    txtHgd_fax.Text = tstc.hgd_fax;
            //    txtHgd_email.Text = tstc.hgd_email;
            //    cboxhgd_chu_ho.Text = tstc.hgd_chu_ho;
            //    cboxCn_danh_xung.Text = tstc.cn_danh_xung;
            //    txtCn_ten.Text = tstc.cn_ten;
            //    txtCn_ns.Text = tstc.cn_ns;
            //    txtCn_cmnd.Text = tstc.cn_cmnd;
            //    txtCn_ngay_cap_cmnd.Text = tstc.cn_ngay_cap_cmnd;
            //    txtCn_noi_cap_cmnd.Text = tstc.cn_noi_cap_cmnd;
            //    txtCn_dc.Text = tstc.cn_dc;
            //    txtCn_hktt.Text = tstc.cn_hktt;
            //    txtCn_so_hk.Text = tstc.cn_so_hk;
            //    txtCn_noi_cap_hk.Text = tstc.cn_noi_cap_hk;
            //    txtCn_ngay_cap_hk.Text = tstc.cn_ngay_cap_hk;
            //    txtCn_dkkd.Text = tstc.cn_dkkd;
            //    txtCn_dien_thoai.Text = tstc.cn_dien_thoai;
            //    txtCn_fax.Text = tstc.cn_fax;
            //    txtCn_email.Text = tstc.cn_email;
            //    txtTc_ten.Text = tstc.tc_ten;
            //    txtTc_dkkd.Text = tstc.tc_dkkd;
            //    txtTc_dc.Text = tstc.tc_dc;
            //    cboxTc_danh_xung_dai_dien.Text = tstc.tc_danh_xung_dai_dien;
            //    txtTc_dai_dien.Text = tstc.tc_dai_dien;
            //    txtTc_ns_dai_dien.Text = tstc.tc_ns_dai_dien;
            //    txtTc_chuc_vu_dai_dien.Text = tstc.tc_chuc_vu_dai_dien;
            //    txtTc_giay_uy_quyen.Text = tstc.tc_giay_uy_quyen;
            //    txtTc_dc_dai_dien.Text = tstc.tc_dc_dai_dien;
            //    txtTc_cmnd_dai_dien.Text = tstc.tc_cmnd_dai_dien;
            //    txtTc_ngay_cap_cmnd_dai_dien.Text = tstc.tc_ngay_cap_cmnd_dai_dien;
            //    txtTc_noi_cap_cmnd_dai_dien.Text = tstc.tc_noi_cap_cmnd_dai_dien;
            //    txtTc_hktt_dai_dien.Text = tstc.tc_hktt_dai_dien;
            //    txtTc_so_hk_dai_dien.Text = tstc.tc_so_hk_dai_dien;
            //    txtTc_noi_cap_hk_dai_dien.Text = tstc.tc_noi_cap_hk_dai_dien;
            //    txtTc_ngay_cap_hk_dai_dien.Text = tstc.tc_ngay_cap_hk_dai_dien;
            //    txtTc_dien_thoai.Text = tstc.tc_dien_thoai;
            //    txtTc_fax.Text = tstc.tc_fax;
            //    txtTc_email.Text = tstc.tc_email;
            //    txtds_ten.Text = tstc.ds_ten;
            //    txtds_so_luong.Text = Convert.ToString(tstc.ds_so_luong);
            //    txtds_gia_tri.Text = Convert.ToString(tstc.ds_gia_tri);
            //    txtds_nhan_hieu.Text = tstc.ds_nhan_hieu;
            //    txtds_loai_xe.Text = tstc.ds_loai_xe;
            //    txtds_mau_son.Text = tstc.ds_mau_son;
            //    txtds_tai_trong.Text = tstc.ds_tai_trong;
            //    txtds_so_cho.Text = tstc.ds_so_cho;
            //    txtds_so_may.Text = tstc.ds_so_may;
            //    txtds_so_khung.Text = tstc.ds_so_khung;
            //    txtds_so_loai.Text = tstc.ds_so_loai;
            //    txtds_dung_tich.Text = tstc.ds_dung_tich;
            //    txtds_nam_san_xuat.Text = tstc.ds_nam_san_xuat;
            //    txtds_bien_so.Text = tstc.ds_bien_so;
            //    txtds_giay_so_huu.Text = tstc.ds_giay_so_huu;
            //    txtds_thong_tin_khac.Text = tstc.ds_thong_tin_khac;
            //    txtbds_ten.Text = tstc.bds_ten;
            //    txtbds_so_thua_dat.Text = tstc.bds_so_thua_dat;
            //    txtbds_so_ban_do.Text = tstc.bds_so_ban_do;
            //    txtbds_dia_chi.Text = tstc.bds_dia_chi;
            //    txtbds_tong_dien_tich.Text = Convert.ToString(tstc.bds_tong_dien_tich);
            //    txtbds_dien_tich_dat_o.Text = Convert.ToString(tstc.bds_dien_tich_dat_o);
            //    txtbds_dat_khac.Text = tstc.bds_dat_khac;
            //    txtbds_dien_tich_dat_khac.Text = Convert.ToString(tstc.bds_dien_tich_dat_khac);
            //    txtbds_dien_tich_su_dung_rieng.Text = Convert.ToString(tstc.bds_dien_tich_su_dung_rieng);
            //    txtbds_dien_tich_su_dung_chung.Text = Convert.ToString(tstc.bds_dien_tich_su_dung_chung);
            //    txtbds_muc_dich_su_dung.Text = tstc.bds_muc_dich_su_dung;
            //    txtbds_thoi_han_su_dung.Text = tstc.bds_thoi_han_su_dung;
            //    txtbds_nguon_goc_su_dung.Text = tstc.bds_nguon_goc_su_dung;
            //    txtbds_han_che_su_dung.Text = tstc.bds_han_che_su_dung;
            //    txtbds_nha_loai_nha.Text = tstc.bds_nha_loai_nha;
            //    txtbds_nha_dien_tich_su_dung.Text = Convert.ToString(tstc.bds_nha_dien_tich_su_dung);
            //    txtbds_nha_dien_tich_xay_dung.Text = Convert.ToString(tstc.bds_nha_dien_tich_xay_dung);
            //    txtbds_nha_ket_cau.Text = tstc.bds_nha_ket_cau;
            //    txtbds_nha_so_tang.Text = tstc.bds_nha_so_tang;
            //    txtbds_nha_gia_tri.Text = Convert.ToString(tstc.bds_nha_gia_tri);
            //    txtbds_ctxd_loai_cong_trinh.Text = tstc.bds_ctxd_loai_cong_trinh;
            //    txtbds_ctxd_dien_tich_xay_dung.Text = Convert.ToString(tstc.bds_ctxd_dien_tich_xay_dung);
            //    txtbds_ctxd_ket_cau.Text = tstc.bds_ctxd_ket_cau;
            //    txtbds_ctxd_so_tang.Text = tstc.bds_ctxd_so_tang;
            //    txtbds_ctxd_gia_tri.Text = Convert.ToString(tstc.bds_ctxd_gia_tri);
            //    txtbds_ts_gan_lien_khac.Text = tstc.bds_ts_gan_lien_khac;
            //    txtbds_ts_gan_lien_khac_gia_tri.Text = Convert.ToString(tstc.bds_ts_gan_lien_khac_gia_tri);
            //    txtbds_quyet_dinh_cap_dat.Text = tstc.bds_quyet_dinh_cap_dat;
            //    txtbds_quyen_su_dung_dat.Text = tstc.bds_quyen_su_dung_dat;
            //    txtbds_giay_phep_xay_dung.Text = tstc.bds_giay_phep_xay_dung;
            //    txtbds_thiet_ke_ky_thuat.Text = tstc.bds_thiet_ke_ky_thuat;
            //    txtbds_giay_to_khac.Text = tstc.bds_giay_to_khac;
            //    txtbds_gia_tri.Text = Convert.ToString(tstc.bds_gia_tri);
            //    txttstc_khac_ten.Text = tstc.tstc_khac_ten;
            //    txttstc_khac_mo_ta.Text = tstc.tstc_khac_mo_ta;
            //    txttstc_khac_giay_to.Text = tstc.tstc_khac_giay_to;
            //    txttstc_khac_gia_tri.Text = Convert.ToString(tstc.tstc_khac_gia_tri);
            //}
            
            if (tstc.tstc_htttl == true)
            {
                chboxtstc_htttl.Checked = true;
            }
            else
            {
                chboxtstc_htttl.Checked = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboxLoai_kh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxloai_chu_so_huu.Text == "Cá nhân")
            {
                grbCn_thong_tin_csh.BringToFront();
                cboxCn_danh_xung.Text = "Ông";
                //grbHgd_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbHgd_thong_tin_csh);
                cboxhgd_chu_ho.Text = "";
                //grbTc_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbTc_thong_tin_csh);
                cboxTc_danh_xung_dai_dien.Text = "";
            }
            else if (cboxloai_chu_so_huu.Text == "Hộ gia đình")
            {
                //grbCn_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbCn_thong_tin_csh);
                cboxCn_danh_xung.Text = "";
                grbHgd_thong_tin_csh.BringToFront();
                cboxhgd_chu_ho.Text = "Chồng";
                //grbTc_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbTc_thong_tin_csh);
                cboxTc_danh_xung_dai_dien.Text = "";
            }
            else if (cboxloai_chu_so_huu.Text == "Tổ chức")
            {
                //grbCn_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbCn_thong_tin_csh);
                cboxCn_danh_xung.Text = "";
                //grbHgd_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbHgd_thong_tin_csh);
                cboxhgd_chu_ho.Text = "";
                grbTc_thong_tin_csh.BringToFront();
                cboxTc_danh_xung_dai_dien.Text = "Ông";
            }
        }

        private void btnCap_nhat_Click(object sender, EventArgs e)
        {
            if (_ma_ts_the_chap == 0)
            {
                this.THEM_TSTC();
            }
            else
            {
                this.CAP_NHAT_TSTC();
            }
        }

        private void cboxhinh_thuc_so_huu_cua_kh_vay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxhinh_thuc_so_huu_cua_kh_vay.Text == "Tài sản chính chủ")
            {
                //grbCn_thong_tin_csh.Enabled = false;
                //grbHgd_thong_tin_csh.Enabled = false;
                //grbTc_thong_tin_csh.Enabled = false;
                cboxloai_chu_so_huu.Enabled = false;
                
                List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(CommonMethods.TachMaHopDong(txtma_hd_vay.Text), _ma_cn);
                Hopdongvay hd = HD_VAY_theoma_HD[0];
                txtma_kh_vay.Text = hd.ma_kh_vay;

                DataTable DS_KH_VAY_THEO_MA = KhachhangvayBUS.DS_KH_VAY_THEO_MA(hd.ma_kh_vay);
                DataRow row = DS_KH_VAY_THEO_MA.Rows[0];
                Khachhangvay kh = new Khachhangvay(row);

                cboxloai_chu_so_huu.Text = kh.loai_kh;

                if (cboxloai_chu_so_huu.Text == "Hộ gia đình")
                {
                    lblTai_san_cua.Visible = true;
                    cboxhgd_nguoi_so_huu.Visible = true;
                }
                else
                {
                    lblTai_san_cua.Visible = false;
                    cboxhgd_nguoi_so_huu.Visible = false;
                }

                txtHgd_ten_chong.Text = kh.hgd_ten_chong;
                txtHgd_ns_chong.Text = kh.hgd_ns_chong;
                txtHgd_cmnd_chong.Text = kh.hgd_cmnd_chong;
                txtHgd_ngay_cap_cmnd_chong.Text = kh.hgd_ngay_cap_cmnd_chong;
                txtHgd_noi_cap_cmnd_chong.Text = kh.hgd_noi_cap_cmnd_chong;
                txtHgd_dc_chong.Text = kh.hgd_dc_chong;
                txtHgd_hktt_chong.Text = kh.hgd_hktt_chong;
                txtHgd_so_hk_chong.Text = kh.hgd_so_hk_chong;
                txtHgd_noi_cap_hk_chong.Text = kh.hgd_noi_cap_hk_chong;
                txtHgd_ngay_cap_hk_chong.Text = kh.hgd_ngay_cap_hk_chong;
                txtHgd_ten_vo.Text = kh.hgd_ten_vo;
                txtHgd_ns_vo.Text = kh.hgd_ns_vo;
                txtHgd_cmnd_vo.Text = kh.hgd_cmnd_vo;
                txtHgd_ngay_cap_cmnd_vo.Text = kh.hgd_ngay_cap_cmnd_vo;
                txtHgd_noi_cap_cmnd_vo.Text = kh.hgd_noi_cap_cmnd_vo;
                txtHgd_dc_vo.Text = kh.hgd_dc_vo;
                txtHgd_hktt_vo.Text = kh.hgd_hktt_vo;
                txtHgd_so_hk_vo.Text = kh.hgd_so_hk_vo;
                txtHgd_noi_cap_hk_vo.Text = kh.hgd_noi_cap_hk_vo;
                txtHgd_ngay_cap_hk_vo.Text = kh.hgd_ngay_cap_hk_vo;
                txtHgd_dkkd.Text = kh.hgd_dkkd;
                txtHgd_dien_thoai.Text = kh.hgd_dien_thoai;
                txtHgd_fax.Text = kh.hgd_fax;
                txtHgd_email.Text = kh.hgd_email;
                cboxhgd_chu_ho.Text = kh.hgd_dai_dien;
                cboxCn_danh_xung.Text = kh.cn_danh_xung;
                txtCn_ten.Text = kh.cn_ten;
                txtCn_ns.Text = kh.cn_ns;
                txtCn_cmnd.Text = kh.cn_cmnd;
                txtCn_ngay_cap_cmnd.Text = kh.cn_ngay_cap_cmnd;
                txtCn_noi_cap_cmnd.Text = kh.cn_noi_cap_cmnd;
                txtCn_dc.Text = kh.cn_dc;
                txtCn_hktt.Text = kh.cn_hktt;
                txtCn_so_hk.Text = kh.cn_so_hk;
                txtCn_noi_cap_hk.Text = kh.cn_noi_cap_hk;
                txtCn_ngay_cap_hk.Text = kh.cn_ngay_cap_hk;
                txtCn_dkkd.Text = kh.cn_dkkd;
                txtCn_dien_thoai.Text = kh.cn_dien_thoai;
                txtCn_fax.Text = kh.cn_fax;
                txtCn_email.Text = kh.cn_email;
                txtTc_ten.Text = kh.tc_ten;
                txtTc_dkkd.Text = kh.tc_dkkd;
                txtTc_dc.Text = kh.tc_dc;
                cboxTc_danh_xung_dai_dien.Text = kh.tc_danh_xung_dai_dien;
                txtTc_dai_dien.Text = kh.tc_dai_dien;
                txtTc_ns_dai_dien.Text = kh.tc_ns_dai_dien;
                txtTc_chuc_vu_dai_dien.Text = kh.tc_chuc_vu_dai_dien;
                txtTc_giay_uy_quyen.Text = kh.tc_giay_uy_quyen;
                txtTc_dc_dai_dien.Text = kh.tc_dc_dai_dien;
                txtTc_cmnd_dai_dien.Text = kh.tc_cmnd_dai_dien;
                txtTc_ngay_cap_cmnd_dai_dien.Text = kh.tc_ngay_cap_cmnd_dai_dien;
                txtTc_noi_cap_cmnd_dai_dien.Text = kh.tc_noi_cap_cmnd_dai_dien;
                txtTc_hktt_dai_dien.Text = kh.tc_hktt_dai_dien;
                txtTc_so_hk_dai_dien.Text = kh.tc_so_hk_dai_dien;
                txtTc_noi_cap_hk_dai_dien.Text = kh.tc_noi_cap_hk_dai_dien;
                txtTc_ngay_cap_hk_dai_dien.Text = kh.tc_ngay_cap_hk_dai_dien;
                txtTc_dien_thoai.Text = kh.tc_dien_thoai;
                txtTc_fax.Text = kh.tc_fax;
                txtTc_email.Text = kh.tc_email;
            }
            else if (cboxhinh_thuc_so_huu_cua_kh_vay.Text == "Tài sản bên thứ ba")
            {
                txtma_kh_vay.Text = "";
                cboxloai_chu_so_huu.Enabled = true;
                grbCn_thong_tin_csh.Enabled = true;
                grbHgd_thong_tin_csh.Enabled = true;
                grbTc_thong_tin_csh.Enabled = true;
                lblTai_san_cua.Visible = false;
                cboxhgd_nguoi_so_huu.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbCn_thong_tin_csh);
                CommonMethods.ClearTextBoxesInGroupBox(this.grbHgd_thong_tin_csh);
                CommonMethods.ClearTextBoxesInGroupBox(this.grbTc_thong_tin_csh);
            }
        }

        private void btnNhap_thong_tin_Click(object sender, EventArgs e)
        {
            grbCn_thong_tin_csh.Visible = false;
            grbHgd_thong_tin_csh.Visible = false;
            grbTc_thong_tin_csh.Visible = false;
            grbThong_tin_tstc_bds.Visible = true;
            grbThong_tin_tstc_ds.Visible = true;
            grbThong_tin_tstc_khac.Visible = true;
            btnNhap_thong_tin.Enabled = false;
            btnCap_nhat.Enabled = true;

            if (_ma_ts_the_chap == 0)
            { 
                cboxLoai_ts_the_chap.Enabled = true;
                cboxLoai_ts_the_chap.Text = "Bất động sản";
                chboxtstc_htttl.Enabled = true;  
                cboxhinh_thuc_so_huu_cua_kh_vay.Enabled = false;
                cboxloai_chu_so_huu.Enabled = false;
            }
            else
            {
                cboxLoai_ts_the_chap.Enabled = false;
                if (cboxLoai_ts_the_chap.Text == "Bất động sản")
                {
                    grbThong_tin_tstc_bds.BringToFront();
                }
                else if (cboxLoai_ts_the_chap.Text == "Động sản")
                {
                    grbThong_tin_tstc_ds.BringToFront();
                }
                else if (cboxLoai_ts_the_chap.Text == "Khác")
                {
                    grbThong_tin_tstc_khac.BringToFront();
                }
            }
        }

        private void cboxLoai_ts_the_chap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxLoai_ts_the_chap.Text == "Bất động sản")
            {
                //grbThong_tin_tstc_bds.Visible = true;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbThong_tin_tstc_ds);
                CommonMethods.ClearTextBoxesInGroupBox(this.grbThong_tin_tstc_khac);
                grbThong_tin_tstc_bds.BringToFront();
            }
            else if (cboxLoai_ts_the_chap.Text == "Động sản")
            {
                CommonMethods.ClearTextBoxesInGroupBox(this.grbThong_tin_tstc_bds);
                grbThong_tin_tstc_ds.BringToFront();
                CommonMethods.ClearTextBoxesInGroupBox(this.grbThong_tin_tstc_khac);
            }
            else if (cboxLoai_ts_the_chap.Text == "Khác")
            {
                CommonMethods.ClearTextBoxesInGroupBox(this.grbThong_tin_tstc_bds);
                CommonMethods.ClearTextBoxesInGroupBox(this.grbThong_tin_tstc_ds);
                grbThong_tin_tstc_khac.BringToFront();
            }
        }

        internal void THEM_TSTC()
        {
            //Kiểm tra thông tin về chủ sở hữu
            if (cboxloai_chu_so_huu.Text == "Cá nhân")
            {
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_cmnd.Text) && !string.IsNullOrEmpty(txtCn_ngay_cap_cmnd.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtCn_ngay_cap_cmnd.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_hk.Text) && !string.IsNullOrEmpty(txtCn_ngay_cap_hk.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtCn_ngay_cap_hk.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ns.Text) && !string.IsNullOrEmpty(txtCn_ns.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtCn_ns.Focus();
                    return;
                }
            }
            else if (cboxloai_chu_so_huu.Text == "Hộ gia đình")
            {
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_chong.Text) && !string.IsNullOrEmpty(txtHgd_ns_chong.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ns_chong.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_vo.Text) && !string.IsNullOrEmpty(txtHgd_ns_vo.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ns_vo.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_chong.Text) && !string.IsNullOrEmpty(txtHgd_ngay_cap_cmnd_chong.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ngay_cap_cmnd_chong.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_vo.Text) && !string.IsNullOrEmpty(txtHgd_ngay_cap_cmnd_vo.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ngay_cap_cmnd_vo.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_chong.Text) && !string.IsNullOrEmpty(txtHgd_ngay_cap_hk_chong.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ngay_cap_hk_chong.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_vo.Text) && !string.IsNullOrEmpty(txtHgd_ngay_cap_hk_vo.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ngay_cap_hk_vo.Focus();
                    return;
                }
            }
            else if (cboxloai_chu_so_huu.Text == "Tổ chức")
            {
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_cmnd_dai_dien.Text) && !string.IsNullOrEmpty(txtTc_ngay_cap_cmnd_dai_dien.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtTc_ngay_cap_cmnd_dai_dien.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_hk_dai_dien.Text) && !string.IsNullOrEmpty(txtTc_ngay_cap_hk_dai_dien.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtTc_ngay_cap_hk_dai_dien.Focus();
                    return;
                }
            }
            //Kiểm tra thông tin tài sản thế chấp
            if (cboxLoai_ts_the_chap.Text == "Bất động sản")
            {
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_tong_dien_tich.Text) && !string.IsNullOrEmpty(txtbds_tong_dien_tich.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtTc_ngay_cap_cmnd_dai_dien.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_dat_o.Text) && !string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_dien_tich_dat_o.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_dat_khac.Text) && !string.IsNullOrEmpty(txtbds_dien_tich_dat_khac.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_dien_tich_dat_khac.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_su_dung_rieng.Text) && !string.IsNullOrEmpty(txtbds_dien_tich_su_dung_rieng.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_dien_tich_su_dung_rieng.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_su_dung_chung.Text) && !string.IsNullOrEmpty(txtbds_dien_tich_su_dung_chung.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_dien_tich_su_dung_chung.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_nha_dien_tich_su_dung.Text) && !string.IsNullOrEmpty(txtbds_nha_dien_tich_su_dung.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_nha_dien_tich_su_dung.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_nha_dien_tich_xay_dung.Text) && !string.IsNullOrEmpty(txtbds_nha_dien_tich_xay_dung.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_nha_dien_tich_xay_dung.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_nha_gia_tri.Text) && !string.IsNullOrEmpty(txtbds_nha_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_nha_gia_tri.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_ctxd_dien_tich_xay_dung.Text) && !string.IsNullOrEmpty(txtbds_ctxd_dien_tich_xay_dung.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_ctxd_dien_tich_xay_dung.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_ctxd_gia_tri.Text) && !string.IsNullOrEmpty(txtbds_ctxd_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_ctxd_gia_tri.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_ts_gan_lien_khac_gia_tri.Text) && !string.IsNullOrEmpty(txtbds_ts_gan_lien_khac_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_ts_gan_lien_khac_gia_tri.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_gia_tri.Text) && !string.IsNullOrEmpty(txtbds_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_gia_tri.Focus();
                    return;
                }
            }
            else if (cboxLoai_ts_the_chap.Text == "Động sản")
            {
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int32(txtds_so_luong.Text) && !string.IsNullOrEmpty(txtds_so_luong.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtds_so_luong.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtds_gia_tri.Text) && !string.IsNullOrEmpty(txtds_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtds_gia_tri.Focus();
                    return;
                }
            }
            else if (cboxLoai_ts_the_chap.Text == "Khác")
            {
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txttstc_khac_gia_tri.Text) && !string.IsNullOrEmpty(txttstc_khac_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txttstc_khac_gia_tri.Focus();
                    return;
                }
            }

            
            string[] thong_tin_tstc = new string[124];
            //thong_tin_tstc[0] = txtma_ts_the_chap.Text;
            thong_tin_tstc[1] = txtma_hd_vay.Text;
            thong_tin_tstc[2] = cboxloai_chu_so_huu.Text;
            thong_tin_tstc[3] = cboxLoai_ts_the_chap.Text;
            thong_tin_tstc[4] = cboxhinh_thuc_so_huu_cua_kh_vay.Text;
            thong_tin_tstc[5] = txtHgd_ten_chong.Text;
            thong_tin_tstc[6] = txtHgd_ns_chong.Text;
            thong_tin_tstc[7] = txtHgd_cmnd_chong.Text;
            thong_tin_tstc[8] = txtHgd_ngay_cap_cmnd_chong.Text;
            thong_tin_tstc[9] = txtHgd_noi_cap_cmnd_chong.Text;
            thong_tin_tstc[10] = txtHgd_dc_chong.Text;
            thong_tin_tstc[11] = txtHgd_hktt_chong.Text;
            thong_tin_tstc[12] = txtHgd_so_hk_chong.Text;
            thong_tin_tstc[13] = txtHgd_noi_cap_hk_chong.Text;
            thong_tin_tstc[14] = txtHgd_ngay_cap_hk_chong.Text;
            thong_tin_tstc[15] = txtHgd_ten_vo.Text;
            thong_tin_tstc[16] = txtHgd_ns_vo.Text;
            thong_tin_tstc[17] = txtHgd_cmnd_vo.Text;
            thong_tin_tstc[18] = txtHgd_ngay_cap_cmnd_vo.Text;
            thong_tin_tstc[19] = txtHgd_noi_cap_cmnd_vo.Text;
            thong_tin_tstc[20] = txtHgd_dc_vo.Text;
            thong_tin_tstc[21] = txtHgd_hktt_vo.Text;
            thong_tin_tstc[22] = txtHgd_so_hk_vo.Text;
            thong_tin_tstc[23] = txtHgd_noi_cap_hk_vo.Text;
            thong_tin_tstc[24] = txtHgd_ngay_cap_hk_vo.Text;
            thong_tin_tstc[25] = txtHgd_dkkd.Text;
            thong_tin_tstc[26] = txtHgd_dien_thoai.Text;
            thong_tin_tstc[27] = txtHgd_fax.Text;
            thong_tin_tstc[28] = txtHgd_email.Text;
            thong_tin_tstc[29] = cboxCn_danh_xung.Text;
            thong_tin_tstc[30] = txtCn_ten.Text;
            thong_tin_tstc[31] = txtCn_ns.Text;
            thong_tin_tstc[32] = txtCn_cmnd.Text;
            thong_tin_tstc[33] = txtCn_ngay_cap_cmnd.Text;
            thong_tin_tstc[34] = txtCn_noi_cap_cmnd.Text;
            thong_tin_tstc[35] = txtCn_dc.Text;
            thong_tin_tstc[36] = txtCn_hktt.Text;
            thong_tin_tstc[37] = txtCn_so_hk.Text;
            thong_tin_tstc[38] = txtCn_noi_cap_hk.Text;
            thong_tin_tstc[39] = txtCn_ngay_cap_hk.Text;
            thong_tin_tstc[40] = txtCn_dkkd.Text;
            thong_tin_tstc[41] = txtCn_dien_thoai.Text;
            thong_tin_tstc[42] = txtCn_fax.Text;
            thong_tin_tstc[43] = txtCn_email.Text;
            thong_tin_tstc[44] = txtTc_ten.Text;
            thong_tin_tstc[45] = txtTc_dkkd.Text;
            thong_tin_tstc[46] = txtTc_dc.Text;
            thong_tin_tstc[47] = cboxTc_danh_xung_dai_dien.Text;
            thong_tin_tstc[48] = txtTc_dai_dien.Text;
            thong_tin_tstc[49] = txtTc_ns_dai_dien.Text;
            thong_tin_tstc[50] = txtTc_chuc_vu_dai_dien.Text;
            thong_tin_tstc[51] = txtTc_giay_uy_quyen.Text;
            thong_tin_tstc[52] = txtTc_dc_dai_dien.Text;
            thong_tin_tstc[53] = txtTc_cmnd_dai_dien.Text;
            thong_tin_tstc[54] = txtTc_ngay_cap_cmnd_dai_dien.Text;
            thong_tin_tstc[55] = txtTc_noi_cap_cmnd_dai_dien.Text;
            thong_tin_tstc[56] = txtTc_hktt_dai_dien.Text;
            thong_tin_tstc[57] = txtTc_so_hk_dai_dien.Text;
            thong_tin_tstc[58] = txtTc_noi_cap_hk_dai_dien.Text;
            thong_tin_tstc[59] = txtTc_ngay_cap_hk_dai_dien.Text;
            thong_tin_tstc[60] = txtTc_dien_thoai.Text;
            thong_tin_tstc[61] = txtTc_fax.Text;
            thong_tin_tstc[62] = txtTc_email.Text;
            thong_tin_tstc[63] = txtds_ten.Text;
            if (!string.IsNullOrEmpty(txtds_so_luong.Text))
            {
                thong_tin_tstc[64] = txtds_so_luong.Text;
            }
            else
            {
                thong_tin_tstc[64] = "0";
            }
            if (!string.IsNullOrEmpty(txtds_gia_tri.Text))
            {
                thong_tin_tstc[65] = txtds_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[65] = "0";
            }
            thong_tin_tstc[66] = txtds_nhan_hieu.Text;
            thong_tin_tstc[67] = txtds_loai_xe.Text;
            thong_tin_tstc[68] = txtds_mau_son.Text;
            thong_tin_tstc[69] = txtds_tai_trong.Text;
            thong_tin_tstc[70] = txtds_so_cho.Text;
            thong_tin_tstc[71] = txtds_so_may.Text;
            thong_tin_tstc[72] = txtds_so_khung.Text;
            thong_tin_tstc[73] = txtds_so_loai.Text;
            thong_tin_tstc[74] = txtds_dung_tich.Text;
            thong_tin_tstc[75] = txtds_nam_san_xuat.Text;
            thong_tin_tstc[76] = txtds_bien_so.Text;
            thong_tin_tstc[77] = txtds_giay_so_huu.Text;
            thong_tin_tstc[78] = txtds_thong_tin_khac.Text;
            thong_tin_tstc[79] = txtbds_ten.Text;
            thong_tin_tstc[80] = txtbds_so_thua_dat.Text;
            thong_tin_tstc[81] = txtbds_so_ban_do.Text;
            thong_tin_tstc[82] = txtbds_dia_chi.Text;
            if (!string.IsNullOrEmpty(txtbds_tong_dien_tich.Text))
            {
                thong_tin_tstc[83] = txtbds_tong_dien_tich.Text;
            }
            else
            {
                thong_tin_tstc[83] = "0";
            }
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
            {
                thong_tin_tstc[84] = txtbds_dien_tich_dat_o.Text;
            }
            else
            {
                thong_tin_tstc[84] = "0";
            }
            thong_tin_tstc[85] = txtbds_dat_khac.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_khac.Text))
            {
                thong_tin_tstc[86] = txtbds_dien_tich_dat_khac.Text;
            }
            else
            {
                thong_tin_tstc[86] = "0";
            }
            if (!string.IsNullOrEmpty(txtbds_dien_tich_su_dung_rieng.Text))
            {
                thong_tin_tstc[87] = txtbds_dien_tich_su_dung_rieng.Text;
            }
            else
            {
                thong_tin_tstc[87] = "0";
            }
            if (!string.IsNullOrEmpty(txtbds_dien_tich_su_dung_chung.Text))
            {
                thong_tin_tstc[88] = txtbds_dien_tich_su_dung_chung.Text;
            }
            else
            {
                thong_tin_tstc[88] = "0";
            }
            thong_tin_tstc[89] = txtbds_muc_dich_su_dung.Text;
            thong_tin_tstc[90] = txtbds_thoi_han_su_dung.Text;
            thong_tin_tstc[91] = txtbds_nguon_goc_su_dung.Text;
            thong_tin_tstc[92] = txtbds_han_che_su_dung.Text;
            thong_tin_tstc[93] = txtbds_nha_loai_nha.Text;
            if (!string.IsNullOrEmpty(txtbds_nha_dien_tich_su_dung.Text))
            {
                thong_tin_tstc[94] = txtbds_nha_dien_tich_su_dung.Text;
            }
            else
            {
                thong_tin_tstc[94] = "0";
            }
            if (!string.IsNullOrEmpty(txtbds_nha_dien_tich_xay_dung.Text))
            {
                thong_tin_tstc[95] = txtbds_nha_dien_tich_xay_dung.Text;
            }
            else
            {
                thong_tin_tstc[95] = "0";
            }
            thong_tin_tstc[96] = txtbds_nha_ket_cau.Text;
            thong_tin_tstc[97] = txtbds_nha_so_tang.Text;
            if (!string.IsNullOrEmpty(txtbds_nha_gia_tri.Text))
            {
                thong_tin_tstc[98] = txtbds_nha_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[98] = "0";
            }
            thong_tin_tstc[99] = txtbds_ctxd_loai_cong_trinh.Text;
            if (!string.IsNullOrEmpty(txtbds_ctxd_dien_tich_xay_dung.Text))
            {
                thong_tin_tstc[100] = txtbds_ctxd_dien_tich_xay_dung.Text;
            }
            else
            {
                thong_tin_tstc[100] = "0";
            }
            thong_tin_tstc[101] = txtbds_ctxd_ket_cau.Text;
            thong_tin_tstc[102] = txtbds_ctxd_so_tang.Text;
            if (!string.IsNullOrEmpty(txtbds_ts_gan_lien_khac_gia_tri.Text))
            {
                thong_tin_tstc[103] = txtbds_ctxd_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[103] = "0";
            }
            thong_tin_tstc[104] = txtbds_ts_gan_lien_khac.Text;
            if (!string.IsNullOrEmpty(txtbds_ts_gan_lien_khac_gia_tri.Text))
            {
                thong_tin_tstc[105] = txtbds_ts_gan_lien_khac_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[105] = "0";
            }
            thong_tin_tstc[106] = txtbds_quyet_dinh_cap_dat.Text;
            thong_tin_tstc[107] = txtbds_quyen_su_dung_dat.Text;
            thong_tin_tstc[108] = txtbds_giay_phep_xay_dung.Text;
            thong_tin_tstc[109] = txtbds_thiet_ke_ky_thuat.Text;
            thong_tin_tstc[110] = txtbds_giay_to_khac.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri.Text))
            {
                thong_tin_tstc[111] = txtbds_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[111] = "0";
            }
            thong_tin_tstc[112] = txttstc_khac_ten.Text;
            thong_tin_tstc[113] = txttstc_khac_mo_ta.Text;
            thong_tin_tstc[114] = txttstc_khac_giay_to.Text;
            if (!string.IsNullOrEmpty(txttstc_khac_gia_tri.Text))
            {
                thong_tin_tstc[115] = txttstc_khac_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[115] = "0";
            }
            if (chboxtstc_htttl.Checked)
            {
                thong_tin_tstc[116] = "true";
            }
            else
            {
                thong_tin_tstc[116] = "false";
            }
            thong_tin_tstc[117] = cboxhgd_chu_ho.Text;
            thong_tin_tstc[118] = cboxhgd_nguoi_so_huu.Text;
            thong_tin_tstc[119] = txtbds_gia_tri_qsd_dat_tren_m2.Text;
            thong_tin_tstc[120] = txtbds_gia_tri_qsd_dat.Text;
            thong_tin_tstc[121] = txtbds_gia_tri_tsgl_tren_m2.Text;
            thong_tin_tstc[122] = txtbds_dien_tich_tsgl.Text;
            thong_tin_tstc[123] = txtbds_gia_tri_tsgl.Text;
            Taisanthechap tstc = new Taisanthechap(thong_tin_tstc);
            //MessageBox.Show(tstc.loai_chu_so_huu);
            if (tstc_bus.THEM_TSTC(tstc))
            {
                MessageBox.Show("Nhập thông tin tài sản thế chấp thành công!");
                this.Close();
            }
            else MessageBox.Show("Có lỗi xảy ra!");


        }

        internal void CAP_NHAT_TSTC()
        {
            //Kiểm tra thông tin về chủ sở hữu
            if (cboxloai_chu_so_huu.Text == "Cá nhân")
            {
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_cmnd.Text) && !string.IsNullOrEmpty(txtCn_ngay_cap_cmnd.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtCn_ngay_cap_cmnd.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_hk.Text) && !string.IsNullOrEmpty(txtCn_ngay_cap_hk.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtCn_ngay_cap_hk.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ns.Text) && !string.IsNullOrEmpty(txtCn_ns.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtCn_ns.Focus();
                    return;
                }
            }
            else if (cboxloai_chu_so_huu.Text == "Hộ gia đình")
            {
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_chong.Text) && !string.IsNullOrEmpty(txtHgd_ns_chong.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ns_chong.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_vo.Text) && !string.IsNullOrEmpty(txtHgd_ns_vo.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ns_vo.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_chong.Text) && !string.IsNullOrEmpty(txtHgd_ngay_cap_cmnd_chong.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ngay_cap_cmnd_chong.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_vo.Text) && !string.IsNullOrEmpty(txtHgd_ngay_cap_cmnd_vo.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ngay_cap_cmnd_vo.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_chong.Text) && !string.IsNullOrEmpty(txtHgd_ngay_cap_hk_chong.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ngay_cap_hk_chong.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_vo.Text) && !string.IsNullOrEmpty(txtHgd_ngay_cap_hk_vo.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtHgd_ngay_cap_hk_vo.Focus();
                    return;
                }
            }
            else if (cboxloai_chu_so_huu.Text == "Tổ chức")
            {
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_cmnd_dai_dien.Text) && !string.IsNullOrEmpty(txtTc_ngay_cap_cmnd_dai_dien.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtTc_ngay_cap_cmnd_dai_dien.Focus();
                    return;
                }

                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_hk_dai_dien.Text) && !string.IsNullOrEmpty(txtTc_ngay_cap_hk_dai_dien.Text))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
                    txtTc_ngay_cap_hk_dai_dien.Focus();
                    return;
                }
            }
            //Kiểm tra thông tin tài sản thế chấp
            if (cboxLoai_ts_the_chap.Text == "Bất động sản")
            {
                if (string.IsNullOrEmpty(txtbds_tong_dien_tich.Text))
                {
                    MessageBox.Show("Bạn chưa nhập tổng diện tích bất động sản, đề nghị nhập!");
                    txtbds_tong_dien_tich.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_tong_dien_tich.Text) && !string.IsNullOrEmpty(txtbds_tong_dien_tich.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_tong_dien_tich.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_dat_o.Text) && !string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_dien_tich_dat_o.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_dat_khac.Text) && !string.IsNullOrEmpty(txtbds_dien_tich_dat_khac.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_dien_tich_dat_khac.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_su_dung_rieng.Text) && !string.IsNullOrEmpty(txtbds_dien_tich_su_dung_rieng.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_dien_tich_su_dung_rieng.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_su_dung_chung.Text) && !string.IsNullOrEmpty(txtbds_dien_tich_su_dung_chung.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_dien_tich_su_dung_chung.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_nha_dien_tich_su_dung.Text) && !string.IsNullOrEmpty(txtbds_nha_dien_tich_su_dung.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_nha_dien_tich_su_dung.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_nha_dien_tich_xay_dung.Text) && !string.IsNullOrEmpty(txtbds_nha_dien_tich_xay_dung.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_nha_dien_tich_xay_dung.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_nha_gia_tri.Text) && !string.IsNullOrEmpty(txtbds_nha_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_nha_gia_tri.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_ctxd_dien_tich_xay_dung.Text) && !string.IsNullOrEmpty(txtbds_ctxd_dien_tich_xay_dung.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_ctxd_dien_tich_xay_dung.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_ctxd_gia_tri.Text) && !string.IsNullOrEmpty(txtbds_ctxd_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_ctxd_gia_tri.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_ts_gan_lien_khac_gia_tri.Text) && !string.IsNullOrEmpty(txtbds_ts_gan_lien_khac_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_ts_gan_lien_khac_gia_tri.Focus();
                    return;
                }               
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_gia_tri.Text) && !string.IsNullOrEmpty(txtbds_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_gia_tri.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_tren_m2.Text))
                {
                    MessageBox.Show("Bạn chưa nhập giá trị quyền sử dụng đất/m2, đề nghị nhập!");
                    txtbds_gia_tri_qsd_dat_tren_m2.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_gia_tri_qsd_dat_tren_m2.Text) && !string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_tren_m2.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_gia_tri_qsd_dat_tren_m2.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtbds_gia_tri_tsgl_tren_m2.Text))
                {
                    MessageBox.Show("Bạn chưa nhập giá trị tài sản gắn liền/m2, đề nghị nhập!");
                    txtbds_gia_tri_tsgl_tren_m2.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_gia_tri_tsgl_tren_m2.Text) && !string.IsNullOrEmpty(txtbds_gia_tri_tsgl_tren_m2.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_gia_tri_tsgl_tren_m2.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtbds_dien_tich_tsgl.Text))
                {
                    MessageBox.Show("Bạn chưa nhập diện tích tài sản gắn liền, đề nghị nhập!");
                    txtbds_dien_tich_tsgl.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_tsgl.Text) && !string.IsNullOrEmpty(txtbds_dien_tich_tsgl.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtbds_dien_tich_tsgl.Focus();
                    return;
                }
            }
            else if (cboxLoai_ts_the_chap.Text == "Động sản")
            {
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int32(txtds_so_luong.Text) && !string.IsNullOrEmpty(txtds_so_luong.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtds_so_luong.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtds_gia_tri.Text) && !string.IsNullOrEmpty(txtds_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txtds_gia_tri.Focus();
                    return;
                }
            }
            else if (cboxLoai_ts_the_chap.Text == "Khác")
            {
                if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txttstc_khac_gia_tri.Text) && !string.IsNullOrEmpty(txttstc_khac_gia_tri.Text))
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                    txttstc_khac_gia_tri.Focus();
                    return;
                }
            }
            string[] thong_tin_tstc = new string[124];
            thong_tin_tstc[0] = Convert.ToString(_ma_ts_the_chap);
            thong_tin_tstc[1] = txtma_hd_vay.Text;
            thong_tin_tstc[2] = cboxloai_chu_so_huu.Text;
            thong_tin_tstc[3] = cboxLoai_ts_the_chap.Text;
            thong_tin_tstc[4] = cboxhinh_thuc_so_huu_cua_kh_vay.Text;
            thong_tin_tstc[5] = txtHgd_ten_chong.Text;
            thong_tin_tstc[6] = txtHgd_ns_chong.Text;
            thong_tin_tstc[7] = txtHgd_cmnd_chong.Text;
            thong_tin_tstc[8] = txtHgd_ngay_cap_cmnd_chong.Text;
            thong_tin_tstc[9] = txtHgd_noi_cap_cmnd_chong.Text;
            thong_tin_tstc[10] = txtHgd_dc_chong.Text;
            thong_tin_tstc[11] = txtHgd_hktt_chong.Text;
            thong_tin_tstc[12] = txtHgd_so_hk_chong.Text;
            thong_tin_tstc[13] = txtHgd_noi_cap_hk_chong.Text;
            thong_tin_tstc[14] = txtHgd_ngay_cap_hk_chong.Text;
            thong_tin_tstc[15] = txtHgd_ten_vo.Text;
            thong_tin_tstc[16] = txtHgd_ns_vo.Text;
            thong_tin_tstc[17] = txtHgd_cmnd_vo.Text;
            thong_tin_tstc[18] = txtHgd_ngay_cap_cmnd_vo.Text;
            thong_tin_tstc[19] = txtHgd_noi_cap_cmnd_vo.Text;
            thong_tin_tstc[20] = txtHgd_dc_vo.Text;
            thong_tin_tstc[21] = txtHgd_hktt_vo.Text;
            thong_tin_tstc[22] = txtHgd_so_hk_vo.Text;
            thong_tin_tstc[23] = txtHgd_noi_cap_hk_vo.Text;
            thong_tin_tstc[24] = txtHgd_ngay_cap_hk_vo.Text;
            thong_tin_tstc[25] = txtHgd_dkkd.Text;
            thong_tin_tstc[26] = txtHgd_dien_thoai.Text;
            thong_tin_tstc[27] = txtHgd_fax.Text;
            thong_tin_tstc[28] = txtHgd_email.Text;
            thong_tin_tstc[29] = cboxCn_danh_xung.Text;
            thong_tin_tstc[30] = txtCn_ten.Text;
            thong_tin_tstc[31] = txtCn_ns.Text;
            thong_tin_tstc[32] = txtCn_cmnd.Text;
            thong_tin_tstc[33] = txtCn_ngay_cap_cmnd.Text;
            thong_tin_tstc[34] = txtCn_noi_cap_cmnd.Text;
            thong_tin_tstc[35] = txtCn_dc.Text;
            thong_tin_tstc[36] = txtCn_hktt.Text;
            thong_tin_tstc[37] = txtCn_so_hk.Text;
            thong_tin_tstc[38] = txtCn_noi_cap_hk.Text;
            thong_tin_tstc[39] = txtCn_ngay_cap_hk.Text;
            thong_tin_tstc[40] = txtCn_dkkd.Text;
            thong_tin_tstc[41] = txtCn_dien_thoai.Text;
            thong_tin_tstc[42] = txtCn_fax.Text;
            thong_tin_tstc[43] = txtCn_email.Text;
            thong_tin_tstc[44] = txtTc_ten.Text;
            thong_tin_tstc[45] = txtTc_dkkd.Text;
            thong_tin_tstc[46] = txtTc_dc.Text;
            thong_tin_tstc[47] = cboxTc_danh_xung_dai_dien.Text;
            thong_tin_tstc[48] = txtTc_dai_dien.Text;
            thong_tin_tstc[49] = txtTc_ns_dai_dien.Text;
            thong_tin_tstc[50] = txtTc_chuc_vu_dai_dien.Text;
            thong_tin_tstc[51] = txtTc_giay_uy_quyen.Text;
            thong_tin_tstc[52] = txtTc_dc_dai_dien.Text;
            thong_tin_tstc[53] = txtTc_cmnd_dai_dien.Text;
            thong_tin_tstc[54] = txtTc_ngay_cap_cmnd_dai_dien.Text;
            thong_tin_tstc[55] = txtTc_noi_cap_cmnd_dai_dien.Text;
            thong_tin_tstc[56] = txtTc_hktt_dai_dien.Text;
            thong_tin_tstc[57] = txtTc_so_hk_dai_dien.Text;
            thong_tin_tstc[58] = txtTc_noi_cap_hk_dai_dien.Text;
            thong_tin_tstc[59] = txtTc_ngay_cap_hk_dai_dien.Text;
            thong_tin_tstc[60] = txtTc_dien_thoai.Text;
            thong_tin_tstc[61] = txtTc_fax.Text;
            thong_tin_tstc[62] = txtTc_email.Text;
            thong_tin_tstc[63] = txtds_ten.Text;
            if (!string.IsNullOrEmpty(txtds_so_luong.Text))
            {
                thong_tin_tstc[64] = txtds_so_luong.Text;
            }
            else
            {
                thong_tin_tstc[64] = "0";
            }
            if (!string.IsNullOrEmpty(txtds_gia_tri.Text))
            {
                thong_tin_tstc[65] = txtds_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[65] = "0";
            }
            thong_tin_tstc[66] = txtds_nhan_hieu.Text;
            thong_tin_tstc[67] = txtds_loai_xe.Text;
            thong_tin_tstc[68] = txtds_mau_son.Text;
            thong_tin_tstc[69] = txtds_tai_trong.Text;
            thong_tin_tstc[70] = txtds_so_cho.Text;
            thong_tin_tstc[71] = txtds_so_may.Text;
            thong_tin_tstc[72] = txtds_so_khung.Text;
            thong_tin_tstc[73] = txtds_so_loai.Text;
            thong_tin_tstc[74] = txtds_dung_tich.Text;
            thong_tin_tstc[75] = txtds_nam_san_xuat.Text;
            thong_tin_tstc[76] = txtds_bien_so.Text;
            thong_tin_tstc[77] = txtds_giay_so_huu.Text;
            thong_tin_tstc[78] = txtds_thong_tin_khac.Text;
            thong_tin_tstc[79] = txtbds_ten.Text;
            thong_tin_tstc[80] = txtbds_so_thua_dat.Text;
            thong_tin_tstc[81] = txtbds_so_ban_do.Text;
            thong_tin_tstc[82] = txtbds_dia_chi.Text;
            if (!string.IsNullOrEmpty(txtbds_tong_dien_tich.Text))
            {
                thong_tin_tstc[83] = txtbds_tong_dien_tich.Text;
            }
            else
            {
                thong_tin_tstc[83] = "0";
            }
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
            {
                thong_tin_tstc[84] = txtbds_dien_tich_dat_o.Text;
            }
            else
            {
                thong_tin_tstc[84] = "0";
            }
            thong_tin_tstc[85] = txtbds_dat_khac.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_khac.Text))
            {
                thong_tin_tstc[86] = txtbds_dien_tich_dat_khac.Text;
            }
            else
            {
                thong_tin_tstc[86] = "0";
            }
            if (!string.IsNullOrEmpty(txtbds_dien_tich_su_dung_rieng.Text))
            {
                thong_tin_tstc[87] = txtbds_dien_tich_su_dung_rieng.Text;
            }
            else
            {
                thong_tin_tstc[87] = "0";
            }
            if (!string.IsNullOrEmpty(txtbds_dien_tich_su_dung_chung.Text))
            {
                thong_tin_tstc[88] = txtbds_dien_tich_su_dung_chung.Text;
            }
            else
            {
                thong_tin_tstc[88] = "0";
            }
            thong_tin_tstc[89] = txtbds_muc_dich_su_dung.Text;
            thong_tin_tstc[90] = txtbds_thoi_han_su_dung.Text;
            thong_tin_tstc[91] = txtbds_nguon_goc_su_dung.Text;
            thong_tin_tstc[92] = txtbds_han_che_su_dung.Text;
            thong_tin_tstc[93] = txtbds_nha_loai_nha.Text;
            if (!string.IsNullOrEmpty(txtbds_nha_dien_tich_su_dung.Text))
            {
                thong_tin_tstc[94] = txtbds_nha_dien_tich_su_dung.Text;
            }
            else
            {
                thong_tin_tstc[94] = "0";
            }
            if (!string.IsNullOrEmpty(txtbds_nha_dien_tich_xay_dung.Text))
            {
                thong_tin_tstc[95] = txtbds_nha_dien_tich_xay_dung.Text;
            }
            else
            {
                thong_tin_tstc[95] = "0";
            }
            thong_tin_tstc[96] = txtbds_nha_ket_cau.Text;
            thong_tin_tstc[97] = txtbds_nha_so_tang.Text;
            if (!string.IsNullOrEmpty(txtbds_nha_gia_tri.Text))
            {
                thong_tin_tstc[98] = txtbds_nha_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[98] = "0";
            }
            thong_tin_tstc[99] = txtbds_ctxd_loai_cong_trinh.Text;
            if (!string.IsNullOrEmpty(txtbds_ctxd_dien_tich_xay_dung.Text))
            {
                thong_tin_tstc[100] = txtbds_ctxd_dien_tich_xay_dung.Text;
            }
            else
            {
                thong_tin_tstc[100] = "0";
            }
            thong_tin_tstc[101] = txtbds_ctxd_ket_cau.Text;
            thong_tin_tstc[102] = txtbds_ctxd_so_tang.Text;
            if (!string.IsNullOrEmpty(txtbds_ts_gan_lien_khac_gia_tri.Text))
            {
                thong_tin_tstc[103] = txtbds_ctxd_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[103] = "0";
            }
            thong_tin_tstc[104] = txtbds_ts_gan_lien_khac.Text;
            if (!string.IsNullOrEmpty(txtbds_ts_gan_lien_khac_gia_tri.Text))
            {
                thong_tin_tstc[105] = txtbds_ts_gan_lien_khac_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[105] = "0";
            }
            thong_tin_tstc[106] = txtbds_quyet_dinh_cap_dat.Text;
            thong_tin_tstc[107] = txtbds_quyen_su_dung_dat.Text;
            thong_tin_tstc[108] = txtbds_giay_phep_xay_dung.Text;
            thong_tin_tstc[109] = txtbds_thiet_ke_ky_thuat.Text;
            thong_tin_tstc[110] = txtbds_giay_to_khac.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri.Text))
            {
                thong_tin_tstc[111] = txtbds_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[111] = "0";
            }
            thong_tin_tstc[112] = txttstc_khac_ten.Text;
            thong_tin_tstc[113] = txttstc_khac_mo_ta.Text;
            thong_tin_tstc[114] = txttstc_khac_giay_to.Text;
            if (!string.IsNullOrEmpty(txttstc_khac_gia_tri.Text))
            {
                thong_tin_tstc[115] = txttstc_khac_gia_tri.Text;
            }
            else
            {
                thong_tin_tstc[115] = "0";
            }
            if (chboxtstc_htttl.Checked)
            {
                thong_tin_tstc[116] = "true";
            }
            else
            {
                thong_tin_tstc[116] = "false";
            }
            thong_tin_tstc[117] = cboxhgd_chu_ho.Text;
            thong_tin_tstc[118] = cboxhgd_nguoi_so_huu.Text;
            thong_tin_tstc[119] = txtbds_gia_tri_qsd_dat_tren_m2.Text;
            thong_tin_tstc[120] = txtbds_gia_tri_qsd_dat.Text;
            thong_tin_tstc[121] = txtbds_gia_tri_tsgl_tren_m2.Text;
            thong_tin_tstc[122] = txtbds_dien_tich_tsgl.Text;
            thong_tin_tstc[123] = txtbds_gia_tri_tsgl.Text;
            Taisanthechap tstc = new Taisanthechap(thong_tin_tstc);
            if (tstc_bus.CAP_NHAT_TSTC(tstc))
            {
                MessageBox.Show("Sửa đổi thông tin tài sản thế chấp thành công!");
                this.Close();
            }
            else MessageBox.Show("Có lỗi xảy ra!");
        }

        private void txtbds_gia_tri_qsd_dat_tren_m2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_tren_m2.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá trị quyền sử dụng đất/m2, đề nghị nhập!");
                txtbds_gia_tri_qsd_dat_tren_m2.Focus();
                return;
            }
            if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_gia_tri_qsd_dat_tren_m2.Text) && !string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_tren_m2.Text))
            {
                MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                txtbds_gia_tri_qsd_dat_tren_m2.Focus();
                return;
            }
            Int64 bds_gia_tri_qsd_dat;
            bds_gia_tri_qsd_dat = Decimal.ToInt64(Decimal.Parse(txtbds_tong_dien_tich.Text) * Int64.Parse(txtbds_gia_tri_qsd_dat_tren_m2.Text));
            txtbds_gia_tri_qsd_dat.Text = bds_gia_tri_qsd_dat.ToString();

            Int64 bds_gia_tri;
            bds_gia_tri = Int64.Parse(txtbds_gia_tri_qsd_dat.Text) + Int64.Parse(txtbds_gia_tri_tsgl.Text);
            txtbds_gia_tri.Text = bds_gia_tri.ToString();
        }

        private void txtbds_tong_dien_tich_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbds_tong_dien_tich.Text))
            {
                MessageBox.Show("Bạn chưa nhập tổng diện tích bất động sản, đề nghị nhập!");
                txtbds_tong_dien_tich.Focus();
                return;
            }
            if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_tong_dien_tich.Text) && !string.IsNullOrEmpty(txtbds_tong_dien_tich.Text))
            {
                MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                txtbds_tong_dien_tich.Focus();
                return;
            }
            Int64 bds_gia_tri_qsd_dat;
            bds_gia_tri_qsd_dat = Decimal.ToInt64(Decimal.Parse(txtbds_tong_dien_tich.Text) * Int64.Parse(txtbds_gia_tri_qsd_dat_tren_m2.Text));
            txtbds_gia_tri_qsd_dat.Text = bds_gia_tri_qsd_dat.ToString();

            Int64 bds_gia_tri;
            bds_gia_tri = Int64.Parse(txtbds_gia_tri_qsd_dat.Text) + Int64.Parse(txtbds_gia_tri_tsgl.Text);
            txtbds_gia_tri.Text = bds_gia_tri.ToString();
        }

        private void txtbds_gia_tri_tsgl_tren_m2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbds_gia_tri_tsgl_tren_m2.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá trị tài sản gắn liền/m2, đề nghị nhập!");
                txtbds_gia_tri_tsgl_tren_m2.Focus();
                return;
            }
            if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(txtbds_gia_tri_tsgl_tren_m2.Text) && !string.IsNullOrEmpty(txtbds_gia_tri_tsgl_tren_m2.Text))
            {
                MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                txtbds_gia_tri_tsgl_tren_m2.Focus();
                return;
            }

            Int64 bds_gia_tri_tsgl;
            bds_gia_tri_tsgl = Decimal.ToInt64(Int64.Parse(txtbds_gia_tri_tsgl_tren_m2.Text) * Decimal.Parse(txtbds_dien_tich_tsgl.Text));
            txtbds_gia_tri_tsgl.Text = bds_gia_tri_tsgl.ToString();

            Int64 bds_gia_tri;
            bds_gia_tri = Int64.Parse(txtbds_gia_tri_qsd_dat.Text) + Int64.Parse(txtbds_gia_tri_tsgl.Text);
            txtbds_gia_tri.Text = bds_gia_tri.ToString();
        }

        private void txtbds_dien_tich_tsgl_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbds_dien_tich_tsgl.Text))
            {
                MessageBox.Show("Bạn chưa nhập diện tích tài sản gắn liền, đề nghị nhập!");
                txtbds_dien_tich_tsgl.Focus();
                return;
            }
            if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_tsgl.Text) && !string.IsNullOrEmpty(txtbds_dien_tich_tsgl.Text))
            {
                MessageBox.Show("Dữ liệu nhập chưa đúng, đề nghị nhập lại!");
                txtbds_dien_tich_tsgl.Focus();
                return;
            }

            Int64 bds_gia_tri_tsgl;
            bds_gia_tri_tsgl = Decimal.ToInt64(Int64.Parse(txtbds_gia_tri_tsgl_tren_m2.Text) * Decimal.Parse(txtbds_dien_tich_tsgl.Text));
            txtbds_gia_tri_tsgl.Text = bds_gia_tri_tsgl.ToString();

            Int64 bds_gia_tri;
            bds_gia_tri = Int64.Parse(txtbds_gia_tri_qsd_dat.Text) + Int64.Parse(txtbds_gia_tri_tsgl.Text);
            txtbds_gia_tri.Text = bds_gia_tri.ToString();
        }

        private void cboxhgd_nguoi_so_huu_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(txtma_hd_vay.Text, _ma_cn);
            Hopdongvay hd = HD_VAY_theoma_HD[0];
            txtma_kh_vay.Text = hd.ma_kh_vay;

            DataTable DS_KH_VAY_THEO_MA = KhachhangvayBUS.DS_KH_VAY_THEO_MA(hd.ma_kh_vay);
            DataRow row = DS_KH_VAY_THEO_MA.Rows[0];
            Khachhangvay kh = new Khachhangvay(row);

            if (cboxhgd_nguoi_so_huu.Text == "Chung")
            {
                txtHgd_ten_chong.Text = kh.hgd_ten_chong;
                txtHgd_ns_chong.Text = kh.hgd_ns_chong;
                txtHgd_cmnd_chong.Text = kh.hgd_cmnd_chong;
                txtHgd_ngay_cap_cmnd_chong.Text = kh.hgd_ngay_cap_cmnd_chong;
                txtHgd_noi_cap_cmnd_chong.Text = kh.hgd_noi_cap_cmnd_chong;
                txtHgd_dc_chong.Text = kh.hgd_dc_chong;
                txtHgd_hktt_chong.Text = kh.hgd_hktt_chong;
                txtHgd_so_hk_chong.Text = kh.hgd_so_hk_chong;
                txtHgd_noi_cap_hk_chong.Text = kh.hgd_noi_cap_hk_chong;
                txtHgd_ngay_cap_hk_chong.Text = kh.hgd_ngay_cap_hk_chong;
                txtHgd_ten_vo.Text = kh.hgd_ten_vo;
                txtHgd_ns_vo.Text = kh.hgd_ns_vo;
                txtHgd_cmnd_vo.Text = kh.hgd_cmnd_vo;
                txtHgd_ngay_cap_cmnd_vo.Text = kh.hgd_ngay_cap_cmnd_vo;
                txtHgd_noi_cap_cmnd_vo.Text = kh.hgd_noi_cap_cmnd_vo;
                txtHgd_dc_vo.Text = kh.hgd_dc_vo;
                txtHgd_hktt_vo.Text = kh.hgd_hktt_vo;
                txtHgd_so_hk_vo.Text = kh.hgd_so_hk_vo;
                txtHgd_noi_cap_hk_vo.Text = kh.hgd_noi_cap_hk_vo;
                txtHgd_ngay_cap_hk_vo.Text = kh.hgd_ngay_cap_hk_vo;
                txtHgd_dkkd.Text = kh.hgd_dkkd;
                txtHgd_dien_thoai.Text = kh.hgd_dien_thoai;
                txtHgd_fax.Text = kh.hgd_fax;
                txtHgd_email.Text = kh.hgd_email;
                cboxhgd_chu_ho.Text = kh.hgd_dai_dien;
            }
            else if (cboxhgd_nguoi_so_huu.Text == "Chồng")
            {
                txtHgd_ten_chong.Text = kh.hgd_ten_chong;
                txtHgd_ns_chong.Text = kh.hgd_ns_chong;
                txtHgd_cmnd_chong.Text = kh.hgd_cmnd_chong;
                txtHgd_ngay_cap_cmnd_chong.Text = kh.hgd_ngay_cap_cmnd_chong;
                txtHgd_noi_cap_cmnd_chong.Text = kh.hgd_noi_cap_cmnd_chong;
                txtHgd_dc_chong.Text = kh.hgd_dc_chong;
                txtHgd_hktt_chong.Text = kh.hgd_hktt_chong;
                txtHgd_so_hk_chong.Text = kh.hgd_so_hk_chong;
                txtHgd_noi_cap_hk_chong.Text = kh.hgd_noi_cap_hk_chong;
                txtHgd_ngay_cap_hk_chong.Text = kh.hgd_ngay_cap_hk_chong;
                txtHgd_ten_vo.Clear();
                txtHgd_ns_vo.Clear();
                txtHgd_cmnd_vo.Clear();
                txtHgd_ngay_cap_cmnd_vo.Clear();
                txtHgd_noi_cap_cmnd_vo.Clear();
                txtHgd_dc_vo.Clear();
                txtHgd_hktt_vo.Clear();
                txtHgd_so_hk_vo.Clear();
                txtHgd_noi_cap_hk_vo.Clear();
                txtHgd_ngay_cap_hk_vo.Clear();
                txtHgd_dkkd.Text = kh.hgd_dkkd;
                txtHgd_dien_thoai.Text = kh.hgd_dien_thoai;
                txtHgd_fax.Text = kh.hgd_fax;
                txtHgd_email.Text = kh.hgd_email;
                cboxhgd_chu_ho.Text = kh.hgd_dai_dien;
            }
            else if (cboxhgd_nguoi_so_huu.Text == "Vợ")
            {
                txtHgd_ten_chong.Clear();
                txtHgd_ns_chong.Clear();
                txtHgd_cmnd_chong.Clear();
                txtHgd_ngay_cap_cmnd_chong.Clear();
                txtHgd_noi_cap_cmnd_chong.Clear();
                txtHgd_dc_chong.Clear();
                txtHgd_hktt_chong.Clear();
                txtHgd_so_hk_chong.Clear();
                txtHgd_noi_cap_hk_chong.Clear();
                txtHgd_ngay_cap_hk_chong.Clear();
                txtHgd_ten_vo.Text = kh.hgd_ten_vo;
                txtHgd_ns_vo.Text = kh.hgd_ns_vo;
                txtHgd_cmnd_vo.Text = kh.hgd_cmnd_vo;
                txtHgd_ngay_cap_cmnd_vo.Text = kh.hgd_ngay_cap_cmnd_vo;
                txtHgd_noi_cap_cmnd_vo.Text = kh.hgd_noi_cap_cmnd_vo;
                txtHgd_dc_vo.Text = kh.hgd_dc_vo;
                txtHgd_hktt_vo.Text = kh.hgd_hktt_vo;
                txtHgd_so_hk_vo.Text = kh.hgd_so_hk_vo;
                txtHgd_noi_cap_hk_vo.Text = kh.hgd_noi_cap_hk_vo;
                txtHgd_ngay_cap_hk_vo.Text = kh.hgd_ngay_cap_hk_vo;
                txtHgd_dkkd.Text = kh.hgd_dkkd;
                txtHgd_dien_thoai.Text = kh.hgd_dien_thoai;
                txtHgd_fax.Text = kh.hgd_fax;
                txtHgd_email.Text = kh.hgd_email;
                cboxhgd_chu_ho.Text = kh.hgd_dai_dien;
            }
        }

        private void txtTc_dc_dai_dien_TextChanged(object sender, EventArgs e)
        {
            txtTc_hktt_dai_dien.Text = txtTc_dc_dai_dien.Text;
        }

        private void txtHgd_dc_chong_TextChanged(object sender, EventArgs e)
        {
            txtHgd_hktt_chong.Text = txtHgd_dc_chong.Text;
        }

        private void txtHgd_dc_vo_TextChanged(object sender, EventArgs e)
        {
            txtHgd_hktt_vo.Text = txtHgd_dc_vo.Text;
        }

        
    }
}
