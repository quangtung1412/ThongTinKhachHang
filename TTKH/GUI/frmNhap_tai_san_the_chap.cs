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

        static DataTable ds_rtb_content = rtbcontentBUS.tbl_RTB_CONTENT();
        static DataRow row = ds_rtb_content.Rows[0];

        private string _bds_thong_tin_chung = row["BDS_THONG_TIN_CHUNG"].ToString();
        private string _bds_giay_to = row["BDS_GIAY_TO"].ToString();
        private string _bds_nha_thong_tin_chung = row["BDS_NHA_THONG_TIN_CHUNG"].ToString();
        private string _bds_ctxd_thong_tin_chung = row["BDS_CTXD_THONG_TIN_CHUNG"].ToString();
        private string _bds_tsgl_khac_thong_tin_chung = row["BDS_TSGL_KHAC_THONG_TIN_CHUNG"].ToString();
        private string _ds_thong_tin_chung = row["DS_THONG_TIN_CHUNG"].ToString();
        private string _ds_giay_to = row["DS_GIAY_TO"].ToString();
        private string _tstc_khac_thong_tin_chung = row["TSTC_KHAC_THONG_TIN_CHUNG"].ToString();
        private string _tstc_khac_giay_to = row["TSTC_KHAC_GIAY_TO"].ToString();

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
            txtma_chu_so_huu.Text = tstc.ma_chu_so_huu;
            cboxloai_chu_so_huu.Text = tstc.loai_chu_so_huu;
            //cboxloai_chu_so_huu.Enabled = false;
            cboxLoai_ts_the_chap.Text = tstc.loai_ts_the_chap;
            cboxLoai_ts_the_chap.Enabled = false;
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
            cboxhgd_dai_dien.Text = tstc.hgd_dai_dien;
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
            txtds_nhan_hieu.Text = tstc.ds_nhan_hieu;
            rtbds_thong_tin_chung.Rtf = tstc.ds_thong_tin_chung_rtf;
            //txtds_thong_tin_chung.Text = tstc.ds_thong_tin_chung;
            txtds_giay_to.Text = tstc.ds_giay_to;
            txtds_gia_tri.Text = Convert.ToString(tstc.ds_gia_tri);
            txtbds_ten.Text = tstc.bds_ten;
            txtbds_tong_dien_tich.Text = Convert.ToString(tstc.bds_tong_dien_tich);
            txtbds_gia_tri_qsd_dat.Text = Convert.ToString(tstc.bds_gia_tri_qsd_dat);
            txtbds_dien_tich_dat_o.Text = Convert.ToString(tstc.bds_dien_tich_dat_o);
            txtbds_gia_tri_qsd_dat_o_tren_m2.Text = Convert.ToString(tstc.bds_gia_tri_qsd_dat_o_tren_m2);
            txtbds_gia_tri_qsd_dat_o.Text = Convert.ToString(tstc.bds_gia_tri_qsd_dat_o);
            cboxbds_dat_khac_1.Text = tstc.bds_dat_khac_1;
            txtbds_dien_tich_dat_khac_1.Text = Convert.ToString(tstc.bds_dien_tich_dat_khac_1);
            txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text = Convert.ToString(tstc.bds_gia_tri_qsd_dat_khac_1_tren_m2);
            txtbds_gia_tri_qsd_dat_khac_1.Text = Convert.ToString(tstc.bds_gia_tri_qsd_dat_khac_1);
            cboxbds_dat_khac_2.Text = tstc.bds_dat_khac_2;
            txtbds_dien_tich_dat_khac_2.Text = Convert.ToString(tstc.bds_dien_tich_dat_khac_2);
            txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text = Convert.ToString(tstc.bds_gia_tri_qsd_dat_khac_2_tren_m2);
            txtbds_gia_tri_qsd_dat_khac_2.Text = Convert.ToString(tstc.bds_gia_tri_qsd_dat_khac_2);
            cboxbds_dat_khac_3.Text = tstc.bds_dat_khac_3;
            txtbds_dien_tich_dat_khac_3.Text = Convert.ToString(tstc.bds_dien_tich_dat_khac_3);
            txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text = Convert.ToString(tstc.bds_gia_tri_qsd_dat_khac_3_tren_m2);
            txtbds_gia_tri_qsd_dat_khac_3.Text = Convert.ToString(tstc.bds_gia_tri_qsd_dat_khac_3);
            txtbds_dien_tich_su_dung_rieng.Text = Convert.ToString(tstc.bds_dien_tich_su_dung_rieng);
            txtbds_dien_tich_su_dung_chung.Text = Convert.ToString(tstc.bds_dien_tich_su_dung_chung);
            rtbbds_thong_tin_chung.Rtf = tstc.bds_thong_tin_chung_rtf;
            //txtbds_thong_tin_chung.Text = tstc.bds_thong_tin_chung;
            rtbbds_giay_to.Rtf = tstc.bds_giay_to_rtf;
            //txtbds_giay_to.Text = tstc.bds_giay_to;
            rtbbds_nha_thong_tin_chung.Rtf = tstc.bds_nha_thong_tin_chung_rtf;
            //txtbds_nha_thong_tin_chung.Text = tstc.bds_nha_thong_tin_chung;
            txtbds_nha_gia_tri.Text = Convert.ToString(tstc.bds_nha_gia_tri);
            rtbbds_ctxd_thong_tin_chung.Rtf = tstc.bds_ctxd_thong_tin_chung_rtf;
            //txtbds_ctxd_thong_tin_chung.Text = tstc.bds_ctxd_thong_tin_chung;
            txtbds_ctxd_gia_tri.Text = Convert.ToString(tstc.bds_ctxd_gia_tri);
            rtbbds_tsgl_khac_thong_tin_chung.Rtf = tstc.bds_tsgl_khac_thong_tin_chung_rtf;
            //txtbds_tsgl_khac_thong_tin_chung.Text = tstc.bds_tsgl_khac_thong_tin_chung;
            txtbds_tsgl_khac_gia_tri.Text = Convert.ToString(tstc.bds_tsgl_khac_gia_tri);
            txtbds_gia_tri.Text = Convert.ToString(tstc.bds_gia_tri);
            txttstc_khac_ten.Text = tstc.tstc_khac_ten;
            rtbtstc_khac_thong_tin_chung.Rtf = tstc.tstc_khac_thong_tin_chung_rtf;
            //txttstc_khac_thong_tin_chung.Text = tstc.tstc_khac_thong_tin_chung;
            txttstc_khac_gia_tri.Text = Convert.ToString(tstc.tstc_khac_gia_tri);
            if (tstc.tstc_htttl == true)
            {
                chboxtstc_htttl.Checked = true;
            }
            else
            {
                chboxtstc_htttl.Checked = false;
            }
            txttstc_khac_giay_to.Text = tstc.tstc_khac_giay_to;
            txtbds_ctxd_2.Text = tstc.bds_ctxd_2;
            txtma_chu_so_huu.Text = tstc.ma_chu_so_huu;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                
                List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(txtma_hd_vay.Text, _ma_cn);
                Hopdongvay hd = HD_VAY_theoma_HD[0];
                txtma_kh_vay.Text = hd.ma_kh_vay;
                txtma_chu_so_huu.Text = hd.ma_kh_vay;
                txtma_chu_so_huu.ReadOnly = true;

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
                cboxhgd_dai_dien.Text = kh.hgd_dai_dien;
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
                List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(txtma_hd_vay.Text, _ma_cn);
                Hopdongvay hd = HD_VAY_theoma_HD[0];
                txtma_kh_vay.Text = hd.ma_kh_vay;
                //txtma_kh_vay.Text = "";
                txtma_chu_so_huu.ReadOnly = false;
                txtma_chu_so_huu.Clear();
                if (this._ma_ts_the_chap == 0)
                {
                    cboxloai_chu_so_huu.Enabled = true;
                }
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
            //Kiểm tra nhập mã chủ sở hữu
            if (string.IsNullOrWhiteSpace(txtma_chu_so_huu.Text))
            {
                MessageBox.Show("Chưa nhập mã khách hàng của người chủ sở hữu, đề nghị nhập lại!");
                txtma_chu_so_huu.Focus();
                return;
            }
            //Kiểm tra thông tin về chủ sở hữu
            if (cboxloai_chu_so_huu.Text == "Cá nhân")
            {
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_cmnd.Text) && (txtCn_ngay_cap_cmnd.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtCn_ngay_cap_cmnd.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_hk.Text) && (txtCn_ngay_cap_hk.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtCn_ngay_cap_hk.Focus();
                    return;
                }
                //if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ns.Text) && (txtCn_ns.Text != "  /  /"))
                //{
                //    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                //    txtCn_ns.Focus();
                //    return;
                //}
            }
            else if (cboxloai_chu_so_huu.Text == "Hộ gia đình")
            {
                //if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_chong.Text) && (txtHgd_ns_chong.Text != "  /  /"))
                //{
                //    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                //    txtHgd_ns_chong.Focus();
                //    return;
                //}
                //if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_vo.Text) && (txtHgd_ns_vo.Text != "  /  /"))
                //{
                //    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                //    txtHgd_ns_vo.Focus();
                //    return;
                //}
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_chong.Text) && (txtHgd_ngay_cap_cmnd_chong.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtHgd_ngay_cap_cmnd_chong.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_vo.Text) && (txtHgd_ngay_cap_cmnd_vo.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtHgd_ngay_cap_cmnd_vo.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_chong.Text) && (txtHgd_ngay_cap_hk_chong.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtHgd_ngay_cap_hk_chong.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_vo.Text) && (txtHgd_ngay_cap_hk_vo.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtHgd_ngay_cap_hk_vo.Focus();
                    return;
                }
            }
            else if (cboxloai_chu_so_huu.Text == "Tổ chức")
            {
                //if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ns_dai_dien.Text) && (txtTc_ns_dai_dien.Text != "  /  /"))
                //{
                //    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                //    txtTc_ns_dai_dien.Focus();
                //    return;
                //}
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_cmnd_dai_dien.Text) && (txtTc_ngay_cap_cmnd_dai_dien.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtTc_ngay_cap_cmnd_dai_dien.Focus();
                    return;
                }
                if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_hk_dai_dien.Text) && (txtTc_ngay_cap_hk_dai_dien.Text != "  /  /"))
                {
                    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                    txtTc_ngay_cap_hk_dai_dien.Focus();
                    return;
                }
            }
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
                tabBat_dong_san.SelectedTab = tabQuyen_su_dung_dat;
                rtbbds_thong_tin_chung.Rtf = this._bds_thong_tin_chung;
                rtbbds_giay_to.Rtf = this._bds_giay_to;
                rtbbds_nha_thong_tin_chung.Rtf = this._bds_nha_thong_tin_chung;
                rtbbds_ctxd_thong_tin_chung.Rtf = this._bds_ctxd_thong_tin_chung;
                rtbbds_tsgl_khac_thong_tin_chung.Rtf = this._bds_tsgl_khac_thong_tin_chung;
            }
            else if (cboxLoai_ts_the_chap.Text == "Động sản")
            {
                CommonMethods.ClearTextBoxesInGroupBox(this.grbThong_tin_tstc_bds);
                CommonMethods.ClearTextBoxesInTabPage(tabQuyen_su_dung_dat);
                CommonMethods.ClearTextBoxesInTabPage(tabNha_o);
                CommonMethods.ClearTextBoxesInTabPage(tabCong_trinh_xay_dung);
                CommonMethods.ClearTextBoxesInTabPage(tabTai_san_gan_lien_khac);
                grbThong_tin_tstc_ds.BringToFront();
                rtbds_thong_tin_chung.Rtf = this._ds_thong_tin_chung;
                txtds_giay_to.Text = "Chứng nhận đăng ký xe ô tô số ......,  biển số đăng ký ....., đăng ký lần đầu ngày ....";
                CommonMethods.ClearTextBoxesInGroupBox(this.grbThong_tin_tstc_khac);
            }
            else if (cboxLoai_ts_the_chap.Text == "Khác")
            {
                CommonMethods.ClearTextBoxesInGroupBox(this.grbThong_tin_tstc_bds);
                CommonMethods.ClearTextBoxesInTabPage(this.tabQuyen_su_dung_dat);
                CommonMethods.ClearTextBoxesInTabPage(this.tabNha_o);
                CommonMethods.ClearTextBoxesInTabPage(this.tabCong_trinh_xay_dung);
                CommonMethods.ClearTextBoxesInTabPage(this.tabTai_san_gan_lien_khac);
                CommonMethods.ClearTextBoxesInGroupBox(this.grbThong_tin_tstc_ds);
                grbThong_tin_tstc_khac.BringToFront();
            }
        }

        internal void THEM_TSTC()
        {
            //Kiểm tra thông tin về chủ sở hữu
            //if (cboxloai_chu_so_huu.Text == "Cá nhân")
            //{
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_cmnd.Text) && (txtCn_ngay_cap_cmnd.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtCn_ngay_cap_cmnd.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_hk.Text) && (txtCn_ngay_cap_hk.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtCn_ngay_cap_hk.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ns.Text) && (txtCn_ns.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtCn_ns.Focus();
            //        return;
            //    }
            //}
            //else if (cboxloai_chu_so_huu.Text == "Hộ gia đình")
            //{
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_chong.Text) && (txtHgd_ns_chong.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ns_chong.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_vo.Text) && (txtHgd_ns_vo.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ns_vo.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_chong.Text) && (txtHgd_ngay_cap_cmnd_chong.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ngay_cap_cmnd_chong.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_vo.Text) && (txtHgd_ngay_cap_cmnd_vo.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ngay_cap_cmnd_vo.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_chong.Text) && (txtHgd_ngay_cap_hk_chong.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ngay_cap_hk_chong.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_vo.Text) && (txtHgd_ngay_cap_hk_vo.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ngay_cap_hk_vo.Focus();
            //        return;
            //    }
            //}
            //else if (cboxloai_chu_so_huu.Text == "Tổ chức")
            //{
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ns_dai_dien.Text) && (txtTc_ns_dai_dien.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtTc_ns_dai_dien.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_cmnd_dai_dien.Text) && (txtTc_ngay_cap_cmnd_dai_dien.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtTc_ngay_cap_cmnd_dai_dien.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_hk_dai_dien.Text) && (txtTc_ngay_cap_hk_dai_dien.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtTc_ngay_cap_hk_dai_dien.Focus();
            //        return;
            //    }
            //}
            
            string[] thong_tin_tstc = new string[113];
            //thong_tin_tstc[0] = txtma_ts_the_chap.Text;
            thong_tin_tstc[1] = txtma_hd_vay.Text;
            thong_tin_tstc[2] = cboxloai_chu_so_huu.Text;
            thong_tin_tstc[3] = cboxLoai_ts_the_chap.Text;
            thong_tin_tstc[4] = cboxhinh_thuc_so_huu_cua_kh_vay.Text;
            thong_tin_tstc[5] = txtHgd_ten_chong.Text;
            if (txtHgd_ns_chong.Text == "  /  /")
            {
                thong_tin_tstc[6] = "";
            }
            else
            {
                thong_tin_tstc[6] = txtHgd_ns_chong.Text;
            }
            thong_tin_tstc[7] = txtHgd_cmnd_chong.Text;
            if (txtHgd_ngay_cap_cmnd_chong.Text == "  /  /")
            {
                thong_tin_tstc[8] = "";
            }
            else
            {
                thong_tin_tstc[8] = txtHgd_ngay_cap_cmnd_chong.Text;
            }
            thong_tin_tstc[9] = txtHgd_noi_cap_cmnd_chong.Text;
            thong_tin_tstc[10] = txtHgd_dc_chong.Text;
            thong_tin_tstc[11] = txtHgd_hktt_chong.Text;
            thong_tin_tstc[12] = txtHgd_so_hk_chong.Text;
            thong_tin_tstc[13] = txtHgd_noi_cap_hk_chong.Text;
            if (txtHgd_ngay_cap_hk_chong.Text == "  /  /")
            {
                thong_tin_tstc[14] = "";
            }
            else
            {
                thong_tin_tstc[14] = txtHgd_ngay_cap_hk_chong.Text;
            }
            thong_tin_tstc[15] = txtHgd_ten_vo.Text;
            if (txtHgd_ns_vo.Text == "  /  /")
            {
                thong_tin_tstc[16] = "";
            }
            else
            {
                thong_tin_tstc[16] = txtHgd_ns_vo.Text;
            }
            thong_tin_tstc[17] = txtHgd_cmnd_vo.Text;
            if (txtHgd_ngay_cap_cmnd_vo.Text == "  /  /")
            {
                thong_tin_tstc[18] = "";
            }
            else
            {
                thong_tin_tstc[18] = txtHgd_ngay_cap_cmnd_vo.Text;
            }
            thong_tin_tstc[19] = txtHgd_noi_cap_cmnd_vo.Text;
            thong_tin_tstc[20] = txtHgd_dc_vo.Text;
            thong_tin_tstc[21] = txtHgd_hktt_vo.Text;
            thong_tin_tstc[22] = txtHgd_so_hk_vo.Text;
            thong_tin_tstc[23] = txtHgd_noi_cap_hk_vo.Text;
            if (txtHgd_ngay_cap_hk_vo.Text == "  /  /")
            {
                thong_tin_tstc[24] = "";
            }
            else
            {
                thong_tin_tstc[24] = txtHgd_ngay_cap_hk_vo.Text;
            }
            thong_tin_tstc[25] = txtHgd_dkkd.Text;
            thong_tin_tstc[26] = txtHgd_dien_thoai.Text;
            thong_tin_tstc[27] = txtHgd_fax.Text;
            thong_tin_tstc[28] = txtHgd_email.Text;
            thong_tin_tstc[29] = cboxhgd_dai_dien.Text;
            thong_tin_tstc[30] = cboxhgd_nguoi_so_huu.Text;
            thong_tin_tstc[31] = cboxCn_danh_xung.Text;
            thong_tin_tstc[32] = txtCn_ten.Text;
            if (txtCn_ns.Text == "  /  /")
            {
                thong_tin_tstc[33] = "";
            }
            else
            {
                thong_tin_tstc[33] = txtCn_ns.Text;
            }
            thong_tin_tstc[34] = txtCn_cmnd.Text;
            if (txtCn_ngay_cap_cmnd.Text == "  /  /")
            {
                thong_tin_tstc[35] = "";
            }
            else
            {
                thong_tin_tstc[35] = txtCn_ngay_cap_cmnd.Text;
            }
            thong_tin_tstc[36] = txtCn_noi_cap_cmnd.Text;
            thong_tin_tstc[37] = txtCn_dc.Text;
            thong_tin_tstc[38] = txtCn_hktt.Text;
            thong_tin_tstc[39] = txtCn_so_hk.Text;
            thong_tin_tstc[40] = txtCn_noi_cap_hk.Text;
            if (txtCn_ngay_cap_hk.Text == "  /  /")
            {
                thong_tin_tstc[41] = "";
            }
            else
            {
                thong_tin_tstc[41] = txtCn_ngay_cap_hk.Text;
            }
            thong_tin_tstc[42] = txtCn_dkkd.Text;
            thong_tin_tstc[43] = txtCn_dien_thoai.Text;
            thong_tin_tstc[44] = txtCn_fax.Text;
            thong_tin_tstc[45] = txtCn_email.Text;
            thong_tin_tstc[46] = txtTc_ten.Text;
            thong_tin_tstc[47] = txtTc_dkkd.Text;
            thong_tin_tstc[48] = txtTc_dc.Text;
            thong_tin_tstc[49] = cboxTc_danh_xung_dai_dien.Text;
            thong_tin_tstc[50] = txtTc_dai_dien.Text;
            if (txtTc_ns_dai_dien.Text == "  /  /")
            {
                thong_tin_tstc[51] = "";
            }
            else
            {
                thong_tin_tstc[51] = txtTc_ns_dai_dien.Text;
            }
            thong_tin_tstc[52] = txtTc_chuc_vu_dai_dien.Text;
            thong_tin_tstc[53] = txtTc_giay_uy_quyen.Text;
            thong_tin_tstc[54] = txtTc_dc_dai_dien.Text;
            thong_tin_tstc[55] = txtTc_cmnd_dai_dien.Text;
            if (txtTc_ngay_cap_cmnd_dai_dien.Text == "  /  /")
            {
                thong_tin_tstc[56] = "";
            }
            else
            {
                thong_tin_tstc[56] = txtTc_ngay_cap_cmnd_dai_dien.Text;
            }
            thong_tin_tstc[57] = txtTc_noi_cap_cmnd_dai_dien.Text;
            thong_tin_tstc[58] = txtTc_hktt_dai_dien.Text;
            thong_tin_tstc[59] = txtTc_so_hk_dai_dien.Text;
            thong_tin_tstc[60] = txtTc_noi_cap_hk_dai_dien.Text;
            if (txtTc_ngay_cap_hk_dai_dien.Text == "  /  /")
            {
                thong_tin_tstc[61] = "";
            }
            else
            {
                thong_tin_tstc[61] = txtTc_ngay_cap_hk_dai_dien.Text;
            }
            thong_tin_tstc[62] = txtTc_dien_thoai.Text;
            thong_tin_tstc[63] = txtTc_fax.Text;
            thong_tin_tstc[64] = txtTc_email.Text;
            thong_tin_tstc[65] = txtds_ten.Text;
            thong_tin_tstc[66] = txtds_nhan_hieu.Text;
            thong_tin_tstc[67] = rtbds_thong_tin_chung.Rtf;
            
            string ds_thong_tin_chung = "";
            if ((rtbds_thong_tin_chung.Rtf != this._ds_thong_tin_chung) & (rtbds_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbds_thong_tin_chung.Lines.Count(); i++)
                {
                    //ds_thong_tin_chung = ds_thong_tin_chung + rtbds_thong_tin_chung.Lines[i] + "\n";
                    ds_thong_tin_chung = ds_thong_tin_chung + rtbds_thong_tin_chung.Lines[i] + "\n";
                }
                ds_thong_tin_chung = ds_thong_tin_chung.Substring(0, ds_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[68] = ds_thong_tin_chung;      
            
            thong_tin_tstc[69] = txtds_giay_to.Text;
            if (!string.IsNullOrEmpty(txtds_gia_tri.Text))
            {
                thong_tin_tstc[70] = ControlFormat.skipComma(txtds_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[70] = "0";
            }
            //thong_tin_tstc[70] = txtds_gia_tri.Text;
            thong_tin_tstc[71] = txtbds_ten.Text;
            if (!string.IsNullOrEmpty(txtbds_tong_dien_tich.Text))
            {
                thong_tin_tstc[72] = txtbds_tong_dien_tich.Text;
            }
            else
            {
                thong_tin_tstc[72] = "0";
            }
            //thong_tin_tstc[72] = txtbds_tong_dien_tich.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat.Text))
            {
                thong_tin_tstc[73] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat.Text);
            }
            else
            {
                thong_tin_tstc[73] = "0";
            }
            //thong_tin_tstc[73] = txtbds_gia_tri_qsd_dat.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
            {
                thong_tin_tstc[74] = txtbds_dien_tich_dat_o.Text;
            }
            else
            {
                thong_tin_tstc[74] = "0";
            }
            //thong_tin_tstc[74] = txtbds_dien_tich_dat_o.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_o_tren_m2.Text))
            {
                thong_tin_tstc[75] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o_tren_m2.Text);
            }
            else
            {
                thong_tin_tstc[75] = "0";
            }
            //thong_tin_tstc[75] = txtbds_gia_tri_qsd_dat_o_tren_m2.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_o.Text))
            {
                thong_tin_tstc[76] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o.Text);
            }
            else
            {
                thong_tin_tstc[76] = "0";
            }
            //thong_tin_tstc[76] = txtbds_gia_tri_qsd_dat_o.Text;
            thong_tin_tstc[77] = cboxbds_dat_khac_1.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_1.Text))
            {
                thong_tin_tstc[78] = txtbds_dien_tich_dat_khac_1.Text;
            }
            else
            {
                thong_tin_tstc[78] = "0";
            }
            //thong_tin_tstc[78] = txtbds_dien_tich_dat_khac_1.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text))
            {
                thong_tin_tstc[79] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text);
            }
            else
            {
                thong_tin_tstc[79] = "0";
            }
            //thong_tin_tstc[79] = txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_1.Text))
            {
                thong_tin_tstc[80] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1.Text);
            }
            else
            {
                thong_tin_tstc[80] = "0";
            }
            //thong_tin_tstc[80] = txtbds_gia_tri_qsd_dat_khac_1.Text;
            thong_tin_tstc[81] = cboxbds_dat_khac_2.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_2.Text))
            {
                thong_tin_tstc[82] = txtbds_dien_tich_dat_khac_2.Text;
            }
            else
            {
                thong_tin_tstc[82] = "0";
            }
            //thong_tin_tstc[82] = txtbds_dien_tich_dat_khac_2.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text))
            {
                thong_tin_tstc[83] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text);
            }
            else
            {
                thong_tin_tstc[83] = "0";
            }
            //thong_tin_tstc[83] = txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_2.Text))
            {
                thong_tin_tstc[84] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2.Text);
            }
            else
            {
                thong_tin_tstc[84] = "0";
            }
            //thong_tin_tstc[84] = txtbds_gia_tri_qsd_dat_khac_2.Text;
            thong_tin_tstc[85] = cboxbds_dat_khac_3.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_3.Text))
            {
                thong_tin_tstc[86] = txtbds_dien_tich_dat_khac_3.Text;
            }
            else
            {
                thong_tin_tstc[86] = "0";
            }
            //thong_tin_tstc[86] = txtbds_dien_tich_dat_khac_3.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text))
            {
                thong_tin_tstc[87] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text);
            }
            else
            {
                thong_tin_tstc[87] = "0";
            }
            //thong_tin_tstc[87] = txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_3.Text))
            {
                thong_tin_tstc[88] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3.Text);
            }
            else
            {
                thong_tin_tstc[88] = "0";
            }
            //thong_tin_tstc[88] = txtbds_gia_tri_qsd_dat_khac_3.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_su_dung_rieng.Text))
            {
                thong_tin_tstc[89] = txtbds_dien_tich_su_dung_rieng.Text;
            }
            else
            {
                thong_tin_tstc[89] = "0";
            }
            //thong_tin_tstc[89] = txtbds_dien_tich_su_dung_rieng.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_su_dung_chung.Text))
            {
                thong_tin_tstc[90] = txtbds_dien_tich_su_dung_chung.Text;
            }
            else
            {
                thong_tin_tstc[90] = "0";
            }
            //thong_tin_tstc[90] = txtbds_dien_tich_su_dung_chung.Text;
            thong_tin_tstc[91] = rtbbds_thong_tin_chung.Rtf;

            string bds_thong_tin_chung = "";
            if ((rtbbds_thong_tin_chung.Rtf != this._bds_thong_tin_chung) & (rtbbds_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbbds_thong_tin_chung.Lines.Count(); i++)
                {
                    bds_thong_tin_chung = bds_thong_tin_chung + rtbbds_thong_tin_chung.Lines[i] + "\n";
                }
                bds_thong_tin_chung = bds_thong_tin_chung.Substring(0, bds_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[92] = bds_thong_tin_chung;
            thong_tin_tstc[93] = rtbbds_giay_to.Rtf;
            
            string bds_giay_to = "";
            if ((rtbbds_giay_to.Rtf != this._bds_giay_to) & (rtbbds_giay_to.Text != ""))
            {
                for (int i = 0; i < rtbbds_giay_to.Lines.Count(); i++)
                {
                    bds_giay_to = bds_giay_to + rtbbds_giay_to.Lines[i] + "\n";
                }
                bds_giay_to = bds_giay_to.Substring(0, bds_giay_to.Length - 1);
            }
            thong_tin_tstc[94] = bds_giay_to;
            thong_tin_tstc[95] = rtbbds_nha_thong_tin_chung.Rtf;
            
            string bds_nha_thong_tin_chung = "";
            if ((rtbbds_nha_thong_tin_chung.Rtf != this._bds_nha_thong_tin_chung) & (rtbbds_nha_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbbds_nha_thong_tin_chung.Lines.Count(); i++)
                {
                    bds_nha_thong_tin_chung = bds_nha_thong_tin_chung + rtbbds_nha_thong_tin_chung.Lines[i] + "\n";
                }
                bds_nha_thong_tin_chung = bds_nha_thong_tin_chung.Substring(0, bds_nha_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[96] = bds_nha_thong_tin_chung;
            
            if (!string.IsNullOrEmpty(txtbds_nha_gia_tri.Text))
            {
                thong_tin_tstc[97] = ControlFormat.skipComma(txtbds_nha_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[97] = "0";
            }
            //thong_tin_tstc[97] = txtbds_nha_gia_tri.Text;
            thong_tin_tstc[98] = rtbbds_ctxd_thong_tin_chung.Rtf;

            string bds_ctxd_thong_tin_chung = "";
            if ((rtbbds_ctxd_thong_tin_chung.Rtf != this._bds_ctxd_thong_tin_chung) & (rtbbds_ctxd_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbbds_ctxd_thong_tin_chung.Lines.Count(); i++)
                {
                    bds_ctxd_thong_tin_chung = bds_ctxd_thong_tin_chung + rtbbds_ctxd_thong_tin_chung.Lines[i] + "\n";
                }
                bds_ctxd_thong_tin_chung = bds_ctxd_thong_tin_chung.Substring(0, bds_ctxd_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[99] = bds_ctxd_thong_tin_chung;
            
            if (!string.IsNullOrEmpty(txtbds_ctxd_gia_tri.Text))
            {
                thong_tin_tstc[100] = ControlFormat.skipComma(txtbds_ctxd_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[100] = "0";
            }
            //thong_tin_tstc[100] = txtbds_ctxd_gia_tri.Text;
            
            thong_tin_tstc[101] = rtbbds_tsgl_khac_thong_tin_chung.Rtf;
            
            string bds_tsgl_khac_thong_tin_chung = "";
            if ((rtbbds_tsgl_khac_thong_tin_chung.Rtf != this._bds_tsgl_khac_thong_tin_chung) & (rtbbds_tsgl_khac_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbbds_tsgl_khac_thong_tin_chung.Lines.Count(); i++)
                {
                    bds_tsgl_khac_thong_tin_chung = bds_tsgl_khac_thong_tin_chung + rtbbds_tsgl_khac_thong_tin_chung.Lines[i] + "\n";
                }
                bds_tsgl_khac_thong_tin_chung = bds_tsgl_khac_thong_tin_chung.Substring(0, bds_tsgl_khac_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[102] = bds_tsgl_khac_thong_tin_chung;
            
            if (!string.IsNullOrEmpty(txtbds_tsgl_khac_gia_tri.Text))
            {
                thong_tin_tstc[103] = ControlFormat.skipComma(txtbds_tsgl_khac_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[103] = "0";
            }
            //thong_tin_tstc[103] = txtbds_tsgl_khac_gia_tri.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri.Text))
            {
                thong_tin_tstc[104] = ControlFormat.skipComma(txtbds_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[104] = "0";
            }
            //thong_tin_tstc[104] = txtbds_gia_tri.Text;
            thong_tin_tstc[105] = txttstc_khac_ten.Text;
            thong_tin_tstc[106] = rtbtstc_khac_thong_tin_chung.Rtf;

            string tstc_khac_thong_tin_chung = "";
            if ((rtbtstc_khac_thong_tin_chung.Rtf != this._tstc_khac_thong_tin_chung) & (rtbtstc_khac_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbtstc_khac_thong_tin_chung.Lines.Count(); i++)
                {
                    tstc_khac_thong_tin_chung = tstc_khac_thong_tin_chung + rtbtstc_khac_thong_tin_chung.Lines[i] + "\n";
                }
                tstc_khac_thong_tin_chung = tstc_khac_thong_tin_chung.Substring(0, tstc_khac_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[107] = tstc_khac_thong_tin_chung;
            
            if (!string.IsNullOrEmpty(txttstc_khac_gia_tri.Text))
            {
                thong_tin_tstc[108] = ControlFormat.skipComma(txttstc_khac_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[108] = "0";
            }
            //thong_tin_tstc[108] = txttstc_khac_gia_tri.Text;
            if (chboxtstc_htttl.Checked)
            {
                thong_tin_tstc[109] = "true";
            }
            else
            {
                thong_tin_tstc[109] = "false";
            }
            thong_tin_tstc[110] = txttstc_khac_giay_to.Text;
            thong_tin_tstc[111] = txtbds_ctxd_2.Text;
            thong_tin_tstc[112] = txtma_chu_so_huu.Text;
            Taisanthechap tstc = new Taisanthechap(thong_tin_tstc);
            //MessageBox.Show(tstc.loai_chu_so_huu);
            if (tstc_bus.THEM_TSTC(tstc))
            {
                //MessageBox.Show("Nhập thông tin tài sản thế chấp thành công!");
                //this.Close();
                DialogResult dialogResult = MessageBox.Show("Nhập thông tin TSTC thành công! Bạn có muốn tạo hồ sơ vay bây giờ?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                    frmTao_ho_so_vay frm = new frmTao_ho_so_vay();
                    frm._ma_hd_vay = txtma_hd_vay.Text;
                    frm.Cap_nhat_txtMa_hd_vay();
                    //frm.Lay_thong_tin_ho_so_vay();
                    //frm.MdiParent = this.MdiParent;
                    frm.ShowInTaskbar = false;
                    frm.ShowDialog();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }
            else MessageBox.Show("Có lỗi xảy ra!");
        }

        internal void CAP_NHAT_TSTC()
        {
            //Kiểm tra thông tin về chủ sở hữu
            //if (cboxloai_chu_so_huu.Text == "Cá nhân")
            //{
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_cmnd.Text) && (txtCn_ngay_cap_cmnd.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtCn_ngay_cap_cmnd.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_hk.Text) && (txtCn_ngay_cap_hk.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtCn_ngay_cap_hk.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ns.Text) && (txtCn_ns.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtCn_ns.Focus();
            //        return;
            //    }
            //}
            //else if (cboxloai_chu_so_huu.Text == "Hộ gia đình")
            //{
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_chong.Text) && (txtHgd_ns_chong.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ns_chong.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_vo.Text) && (txtHgd_ns_vo.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ns_vo.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_chong.Text) && (txtHgd_ngay_cap_cmnd_chong.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ngay_cap_cmnd_chong.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_vo.Text) && (txtHgd_ngay_cap_cmnd_vo.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ngay_cap_cmnd_vo.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_chong.Text) && (txtHgd_ngay_cap_hk_chong.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ngay_cap_hk_chong.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_vo.Text) && (txtHgd_ngay_cap_hk_vo.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtHgd_ngay_cap_hk_vo.Focus();
            //        return;
            //    }
            //}
            //else if (cboxloai_chu_so_huu.Text == "Tổ chức")
            //{
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ns_dai_dien.Text) && (txtTc_ns_dai_dien.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtTc_ns_dai_dien.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_cmnd_dai_dien.Text) && (txtTc_ngay_cap_cmnd_dai_dien.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtTc_ngay_cap_cmnd_dai_dien.Focus();
            //        return;
            //    }
            //    if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_hk_dai_dien.Text) && (txtTc_ngay_cap_hk_dai_dien.Text != "  /  /"))
            //    {
            //        MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
            //        txtTc_ngay_cap_hk_dai_dien.Focus();
            //        return;
            //    }
            //}
            string[] thong_tin_tstc = new string[113];
            thong_tin_tstc[0] = Convert.ToString(_ma_ts_the_chap);
            thong_tin_tstc[1] = txtma_hd_vay.Text;
            thong_tin_tstc[2] = cboxloai_chu_so_huu.Text;
            thong_tin_tstc[3] = cboxLoai_ts_the_chap.Text;
            thong_tin_tstc[4] = cboxhinh_thuc_so_huu_cua_kh_vay.Text;
            thong_tin_tstc[5] = txtHgd_ten_chong.Text;
            if (txtHgd_ns_chong.Text == "  /  /")
            {
                thong_tin_tstc[6] = "";
            }
            else
            {
                thong_tin_tstc[6] = txtHgd_ns_chong.Text;
            }
            thong_tin_tstc[7] = txtHgd_cmnd_chong.Text;
            if (txtHgd_ngay_cap_cmnd_chong.Text == "  /  /")
            {
                thong_tin_tstc[8] = "";
            }
            else
            {
                thong_tin_tstc[8] = txtHgd_ngay_cap_cmnd_chong.Text;
            }
            thong_tin_tstc[9] = txtHgd_noi_cap_cmnd_chong.Text;
            thong_tin_tstc[10] = txtHgd_dc_chong.Text;
            thong_tin_tstc[11] = txtHgd_hktt_chong.Text;
            thong_tin_tstc[12] = txtHgd_so_hk_chong.Text;
            thong_tin_tstc[13] = txtHgd_noi_cap_hk_chong.Text;
            if (txtHgd_ngay_cap_hk_chong.Text == "  /  /")
            {
                thong_tin_tstc[14] = "";
            }
            else
            {
                thong_tin_tstc[14] = txtHgd_ngay_cap_hk_chong.Text;
            }
            thong_tin_tstc[15] = txtHgd_ten_vo.Text;
            if (txtHgd_ns_vo.Text == "  /  /")
            {
                thong_tin_tstc[16] = "";
            }
            else
            {
                thong_tin_tstc[16] = txtHgd_ns_vo.Text;
            }
            thong_tin_tstc[17] = txtHgd_cmnd_vo.Text;
            if (txtHgd_ngay_cap_cmnd_vo.Text == "  /  /")
            {
                thong_tin_tstc[18] = "";
            }
            else
            {
                thong_tin_tstc[18] = txtHgd_ngay_cap_cmnd_vo.Text;
            }
            thong_tin_tstc[19] = txtHgd_noi_cap_cmnd_vo.Text;
            thong_tin_tstc[20] = txtHgd_dc_vo.Text;
            thong_tin_tstc[21] = txtHgd_hktt_vo.Text;
            thong_tin_tstc[22] = txtHgd_so_hk_vo.Text;
            thong_tin_tstc[23] = txtHgd_noi_cap_hk_vo.Text;
            if (txtHgd_ngay_cap_hk_vo.Text == "  /  /")
            {
                thong_tin_tstc[24] = "";
            }
            else
            {
                thong_tin_tstc[24] = txtHgd_ngay_cap_hk_vo.Text;
            }
            thong_tin_tstc[25] = txtHgd_dkkd.Text;
            thong_tin_tstc[26] = txtHgd_dien_thoai.Text;
            thong_tin_tstc[27] = txtHgd_fax.Text;
            thong_tin_tstc[28] = txtHgd_email.Text;
            thong_tin_tstc[29] = cboxhgd_dai_dien.Text;
            thong_tin_tstc[30] = cboxhgd_nguoi_so_huu.Text;
            thong_tin_tstc[31] = cboxCn_danh_xung.Text;
            thong_tin_tstc[32] = txtCn_ten.Text;
            if (txtCn_ns.Text == "  /  /")
            {
                thong_tin_tstc[33] = "";
            }
            else
            {
                thong_tin_tstc[33] = txtCn_ns.Text;
            }
            thong_tin_tstc[34] = txtCn_cmnd.Text;
            if (txtCn_ngay_cap_cmnd.Text == "  /  /")
            {
                thong_tin_tstc[35] = "";
            }
            else
            {
                thong_tin_tstc[35] = txtCn_ngay_cap_cmnd.Text;
            }
            thong_tin_tstc[36] = txtCn_noi_cap_cmnd.Text;
            thong_tin_tstc[37] = txtCn_dc.Text;
            thong_tin_tstc[38] = txtCn_hktt.Text;
            thong_tin_tstc[39] = txtCn_so_hk.Text;
            thong_tin_tstc[40] = txtCn_noi_cap_hk.Text;
            if (txtCn_ngay_cap_hk.Text == "  /  /")
            {
                thong_tin_tstc[41] = "";
            }
            else
            {
                thong_tin_tstc[41] = txtCn_ngay_cap_hk.Text;
            }
            thong_tin_tstc[42] = txtCn_dkkd.Text;
            thong_tin_tstc[43] = txtCn_dien_thoai.Text;
            thong_tin_tstc[44] = txtCn_fax.Text;
            thong_tin_tstc[45] = txtCn_email.Text;
            thong_tin_tstc[46] = txtTc_ten.Text;
            thong_tin_tstc[47] = txtTc_dkkd.Text;
            thong_tin_tstc[48] = txtTc_dc.Text;
            thong_tin_tstc[49] = cboxTc_danh_xung_dai_dien.Text;
            thong_tin_tstc[50] = txtTc_dai_dien.Text;
            if (txtTc_ns_dai_dien.Text == "  /  /")
            {
                thong_tin_tstc[51] = "";
            }
            else
            {
                thong_tin_tstc[51] = txtTc_ns_dai_dien.Text;
            }
            thong_tin_tstc[52] = txtTc_chuc_vu_dai_dien.Text;
            thong_tin_tstc[53] = txtTc_giay_uy_quyen.Text;
            thong_tin_tstc[54] = txtTc_dc_dai_dien.Text;
            thong_tin_tstc[55] = txtTc_cmnd_dai_dien.Text;
            if (txtTc_ngay_cap_cmnd_dai_dien.Text == "  /  /")
            {
                thong_tin_tstc[56] = "";
            }
            else
            {
                thong_tin_tstc[56] = txtTc_ngay_cap_cmnd_dai_dien.Text;
            } 
            thong_tin_tstc[57] = txtTc_noi_cap_cmnd_dai_dien.Text;
            thong_tin_tstc[58] = txtTc_hktt_dai_dien.Text;
            thong_tin_tstc[59] = txtTc_so_hk_dai_dien.Text;
            thong_tin_tstc[60] = txtTc_noi_cap_hk_dai_dien.Text;
            if (txtTc_ngay_cap_hk_dai_dien.Text == "  /  /")
            {
                thong_tin_tstc[61] = "";
            }
            else
            {
                thong_tin_tstc[61] = txtTc_ngay_cap_hk_dai_dien.Text;
            }
            thong_tin_tstc[62] = txtTc_dien_thoai.Text;
            thong_tin_tstc[63] = txtTc_fax.Text;
            thong_tin_tstc[64] = txtTc_email.Text;
            thong_tin_tstc[65] = txtds_ten.Text;
            thong_tin_tstc[66] = txtds_nhan_hieu.Text;
            thong_tin_tstc[67] = rtbds_thong_tin_chung.Rtf;

            string ds_thong_tin_chung = "";
            if ((rtbds_thong_tin_chung.Rtf != this._ds_thong_tin_chung) & (rtbds_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbds_thong_tin_chung.Lines.Count(); i++)
                {
                    //ds_thong_tin_chung = ds_thong_tin_chung + rtbds_thong_tin_chung.Lines[i] + "\n";
                    ds_thong_tin_chung = ds_thong_tin_chung + rtbds_thong_tin_chung.Lines[i] + "\n";
                }
                ds_thong_tin_chung = ds_thong_tin_chung.Substring(0, ds_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[68] = ds_thong_tin_chung;

            thong_tin_tstc[69] = txtds_giay_to.Text;
            if (!string.IsNullOrEmpty(txtds_gia_tri.Text))
            {
                thong_tin_tstc[70] = ControlFormat.skipComma(txtds_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[70] = "0";
            }
            //thong_tin_tstc[70] = txtds_gia_tri.Text;
            thong_tin_tstc[71] = txtbds_ten.Text;
            if (!string.IsNullOrEmpty(txtbds_tong_dien_tich.Text))
            {
                thong_tin_tstc[72] = txtbds_tong_dien_tich.Text;
            }
            else
            {
                thong_tin_tstc[72] = "0";
            }
            //thong_tin_tstc[72] = txtbds_tong_dien_tich.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat.Text))
            {
                thong_tin_tstc[73] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat.Text);
            }
            else
            {
                thong_tin_tstc[73] = "0";
            }
            //thong_tin_tstc[73] = txtbds_gia_tri_qsd_dat.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
            {
                thong_tin_tstc[74] = txtbds_dien_tich_dat_o.Text;
            }
            else
            {
                thong_tin_tstc[74] = "0";
            }
            //thong_tin_tstc[74] = txtbds_dien_tich_dat_o.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_o_tren_m2.Text))
            {
                thong_tin_tstc[75] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o_tren_m2.Text);
            }
            else
            {
                thong_tin_tstc[75] = "0";
            }
            //thong_tin_tstc[75] = txtbds_gia_tri_qsd_dat_o_tren_m2.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_o.Text))
            {
                thong_tin_tstc[76] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o.Text);
            }
            else
            {
                thong_tin_tstc[76] = "0";
            }
            //thong_tin_tstc[76] = txtbds_gia_tri_qsd_dat_o.Text;
            thong_tin_tstc[77] = cboxbds_dat_khac_1.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_1.Text))
            {
                thong_tin_tstc[78] = txtbds_dien_tich_dat_khac_1.Text;
            }
            else
            {
                thong_tin_tstc[78] = "0";
            }
            //thong_tin_tstc[78] = txtbds_dien_tich_dat_khac_1.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text))
            {
                thong_tin_tstc[79] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text);
            }
            else
            {
                thong_tin_tstc[79] = "0";
            }
            //thong_tin_tstc[79] = txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_1.Text))
            {
                thong_tin_tstc[80] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1.Text);
            }
            else
            {
                thong_tin_tstc[80] = "0";
            }
            //thong_tin_tstc[80] = txtbds_gia_tri_qsd_dat_khac_1.Text;
            thong_tin_tstc[81] = cboxbds_dat_khac_2.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_2.Text))
            {
                thong_tin_tstc[82] = txtbds_dien_tich_dat_khac_2.Text;
            }
            else
            {
                thong_tin_tstc[82] = "0";
            }
            //thong_tin_tstc[82] = txtbds_dien_tich_dat_khac_2.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text))
            {
                thong_tin_tstc[83] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text);
            }
            else
            {
                thong_tin_tstc[83] = "0";
            }
            //thong_tin_tstc[83] = txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_2.Text))
            {
                thong_tin_tstc[84] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2.Text);
            }
            else
            {
                thong_tin_tstc[84] = "0";
            }
            //thong_tin_tstc[84] = txtbds_gia_tri_qsd_dat_khac_2.Text;
            thong_tin_tstc[85] = cboxbds_dat_khac_3.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_3.Text))
            {
                thong_tin_tstc[86] = txtbds_dien_tich_dat_khac_3.Text;
            }
            else
            {
                thong_tin_tstc[86] = "0";
            }
            //thong_tin_tstc[86] = txtbds_dien_tich_dat_khac_3.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text))
            {
                thong_tin_tstc[87] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text);
            }
            else
            {
                thong_tin_tstc[87] = "0";
            }
            //thong_tin_tstc[87] = txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_3.Text))
            {
                thong_tin_tstc[88] = ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3.Text);
            }
            else
            {
                thong_tin_tstc[88] = "0";
            }
            //thong_tin_tstc[88] = txtbds_gia_tri_qsd_dat_khac_3.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_su_dung_rieng.Text))
            {
                thong_tin_tstc[89] = txtbds_dien_tich_su_dung_rieng.Text;
            }
            else
            {
                thong_tin_tstc[89] = "0";
            }
            //thong_tin_tstc[89] = txtbds_dien_tich_su_dung_rieng.Text;
            if (!string.IsNullOrEmpty(txtbds_dien_tich_su_dung_chung.Text))
            {
                thong_tin_tstc[90] = txtbds_dien_tich_su_dung_chung.Text;
            }
            else
            {
                thong_tin_tstc[90] = "0";
            }
            //thong_tin_tstc[90] = txtbds_dien_tich_su_dung_chung.Text;
            thong_tin_tstc[91] = rtbbds_thong_tin_chung.Rtf;

            string bds_thong_tin_chung = "";
            if ((rtbbds_thong_tin_chung.Rtf != this._bds_thong_tin_chung) & (rtbbds_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbbds_thong_tin_chung.Lines.Count(); i++)
                {
                    bds_thong_tin_chung = bds_thong_tin_chung + rtbbds_thong_tin_chung.Lines[i] + "\n";
                }
                bds_thong_tin_chung = bds_thong_tin_chung.Substring(0, bds_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[92] = bds_thong_tin_chung;
            thong_tin_tstc[93] = rtbbds_giay_to.Rtf;

            string bds_giay_to = "";
            if ((rtbbds_giay_to.Rtf != this._bds_giay_to) & (rtbbds_giay_to.Text != ""))
            {
                for (int i = 0; i < rtbbds_giay_to.Lines.Count(); i++)
                {
                    bds_giay_to = bds_giay_to + rtbbds_giay_to.Lines[i] + "\n";
                }
                bds_giay_to = bds_giay_to.Substring(0, bds_giay_to.Length - 1);
            }
            thong_tin_tstc[94] = bds_giay_to;
            thong_tin_tstc[95] = rtbbds_nha_thong_tin_chung.Rtf;

            string bds_nha_thong_tin_chung = "";
            if ((rtbbds_nha_thong_tin_chung.Rtf != this._bds_nha_thong_tin_chung) & (rtbbds_nha_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbbds_nha_thong_tin_chung.Lines.Count(); i++)
                {
                    bds_nha_thong_tin_chung = bds_nha_thong_tin_chung + rtbbds_nha_thong_tin_chung.Lines[i] + "\n";
                }
                bds_nha_thong_tin_chung = bds_nha_thong_tin_chung.Substring(0, bds_nha_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[96] = bds_nha_thong_tin_chung;

            if (!string.IsNullOrEmpty(txtbds_nha_gia_tri.Text))
            {
                thong_tin_tstc[97] = ControlFormat.skipComma(txtbds_nha_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[97] = "0";
            }
            //thong_tin_tstc[97] = txtbds_nha_gia_tri.Text;
            thong_tin_tstc[98] = rtbbds_ctxd_thong_tin_chung.Rtf;

            string bds_ctxd_thong_tin_chung = "";
            if ((rtbbds_ctxd_thong_tin_chung.Rtf != this._bds_ctxd_thong_tin_chung) & (rtbbds_ctxd_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbbds_ctxd_thong_tin_chung.Lines.Count(); i++)
                {
                    bds_ctxd_thong_tin_chung = bds_ctxd_thong_tin_chung + rtbbds_ctxd_thong_tin_chung.Lines[i] + "\n";
                }
                bds_ctxd_thong_tin_chung = bds_ctxd_thong_tin_chung.Substring(0, bds_ctxd_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[99] = bds_ctxd_thong_tin_chung;

            if (!string.IsNullOrEmpty(txtbds_ctxd_gia_tri.Text))
            {
                thong_tin_tstc[100] = ControlFormat.skipComma(txtbds_ctxd_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[100] = "0";
            }
            //thong_tin_tstc[100] = txtbds_ctxd_gia_tri.Text;

            thong_tin_tstc[101] = rtbbds_tsgl_khac_thong_tin_chung.Rtf;

            string bds_tsgl_khac_thong_tin_chung = "";
            if ((rtbbds_tsgl_khac_thong_tin_chung.Rtf != this._bds_tsgl_khac_thong_tin_chung) & (rtbbds_tsgl_khac_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbbds_tsgl_khac_thong_tin_chung.Lines.Count(); i++)
                {
                    bds_tsgl_khac_thong_tin_chung = bds_tsgl_khac_thong_tin_chung + rtbbds_tsgl_khac_thong_tin_chung.Lines[i] + "\n";
                }
                bds_tsgl_khac_thong_tin_chung = bds_tsgl_khac_thong_tin_chung.Substring(0, bds_tsgl_khac_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[102] = bds_tsgl_khac_thong_tin_chung;

            if (!string.IsNullOrEmpty(txtbds_tsgl_khac_gia_tri.Text))
            {
                thong_tin_tstc[103] = ControlFormat.skipComma(txtbds_tsgl_khac_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[103] = "0";
            }
            //thong_tin_tstc[103] = txtbds_tsgl_khac_gia_tri.Text;
            if (!string.IsNullOrEmpty(txtbds_gia_tri.Text))
            {
                thong_tin_tstc[104] = ControlFormat.skipComma(txtbds_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[104] = "0";
            }
            //thong_tin_tstc[104] = txtbds_gia_tri.Text;
            thong_tin_tstc[105] = txttstc_khac_ten.Text;
            thong_tin_tstc[106] = rtbtstc_khac_thong_tin_chung.Rtf;

            string tstc_khac_thong_tin_chung = "";
            if ((rtbtstc_khac_thong_tin_chung.Rtf != this._tstc_khac_thong_tin_chung) & (rtbtstc_khac_thong_tin_chung.Text != ""))
            {
                for (int i = 0; i < rtbtstc_khac_thong_tin_chung.Lines.Count(); i++)
                {
                    tstc_khac_thong_tin_chung = tstc_khac_thong_tin_chung + rtbtstc_khac_thong_tin_chung.Lines[i] + "\n";
                }
                tstc_khac_thong_tin_chung = tstc_khac_thong_tin_chung.Substring(0, tstc_khac_thong_tin_chung.Length - 1);
            }
            thong_tin_tstc[107] = tstc_khac_thong_tin_chung;

            if (!string.IsNullOrEmpty(txttstc_khac_gia_tri.Text))
            {
                thong_tin_tstc[108] = ControlFormat.skipComma(txttstc_khac_gia_tri.Text);
            }
            else
            {
                thong_tin_tstc[108] = "0";
            }
            //thong_tin_tstc[108] = txttstc_khac_gia_tri.Text;
            if (chboxtstc_htttl.Checked)
            {
                thong_tin_tstc[109] = "true";
            }
            else
            {
                thong_tin_tstc[109] = "false";
            }
            thong_tin_tstc[110] = txttstc_khac_giay_to.Text;
            thong_tin_tstc[111] = txtbds_ctxd_2.Text;
            thong_tin_tstc[112] = txtma_chu_so_huu.Text;
            Taisanthechap tstc = new Taisanthechap(thong_tin_tstc);
            if (tstc_bus.CAP_NHAT_TSTC(tstc))
            {
                MessageBox.Show("Sửa đổi thông tin tài sản thế chấp thành công!");
                this.Close();
            }
            else MessageBox.Show("Có lỗi xảy ra!");
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
                cboxhgd_dai_dien.Text = kh.hgd_dai_dien;
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
                cboxhgd_dai_dien.Text = kh.hgd_dai_dien;
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
                cboxhgd_dai_dien.Text = kh.hgd_dai_dien;
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

        

        //------------------------------------------------------Định dạng số cho các ô giá trị tiền --------------------------------
        //Giá trị quyền sử dụng đất--------------------------------------------
        private void txtbds_gia_tri_qsd_dat_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_gia_tri_qsd_dat.Text == "")
            {
                txtbds_gia_tri_qsd_dat.Text = null;
            }
            else
            {
                if (txtbds_gia_tri_qsd_dat.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat.Text));
                    txtbds_gia_tri_qsd_dat.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_gia_tri_qsd_dat.Select(txtbds_gia_tri_qsd_dat.Text.Length, 0);

            Int64 bds_gia_tri_qsd_dat;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat.Text))
            {
                bds_gia_tri_qsd_dat = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat.Text));
            }

            Int64 bds_nha_gia_tri;
            if (string.IsNullOrEmpty(txtbds_nha_gia_tri.Text))
            {
                bds_nha_gia_tri = 0;
            }
            else
            {
                bds_nha_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_nha_gia_tri.Text));
            }

            Int64 bds_ctxd_gia_tri;
            if (string.IsNullOrEmpty(txtbds_ctxd_gia_tri.Text))
            {
                bds_ctxd_gia_tri = 0;
            }
            else
            {
                bds_ctxd_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_ctxd_gia_tri.Text));
            }

            Int64 bds_tsgl_khac_gia_tri;
            if (string.IsNullOrEmpty(txtbds_tsgl_khac_gia_tri.Text))
            {
                bds_tsgl_khac_gia_tri = 0;
            }
            else
            {
                bds_tsgl_khac_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_tsgl_khac_gia_tri.Text));
            }

            txtbds_gia_tri.Text = Convert.ToString(bds_gia_tri_qsd_dat + bds_nha_gia_tri + bds_ctxd_gia_tri + bds_tsgl_khac_gia_tri);
        }

        private void txtbds_gia_tri_qsd_dat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị quyền sử dụng đất ở trên m2
        private void txtbds_gia_tri_qsd_dat_o_tren_m2_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_gia_tri_qsd_dat_o_tren_m2.Text == "")
            {
                txtbds_gia_tri_qsd_dat_o_tren_m2.Text = null;
            }
            else
            {
                if (txtbds_gia_tri_qsd_dat_o_tren_m2.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o_tren_m2.Text));
                    txtbds_gia_tri_qsd_dat_o_tren_m2.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_gia_tri_qsd_dat_o_tren_m2.Select(txtbds_gia_tri_qsd_dat_o_tren_m2.Text.Length, 0);
        }

        private void txtbds_gia_tri_qsd_dat_o_tren_m2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị quyền sử dụng đất ở
        private void txtbds_gia_tri_qsd_dat_o_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_gia_tri_qsd_dat_o.Text == "")
            {
                txtbds_gia_tri_qsd_dat_o.Text = null;
            }
            else
            {
                if (txtbds_gia_tri_qsd_dat_o.Text != "")
                {
                    Int64 d = Decimal.ToInt64(Convert.ToDecimal(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o.Text)));
                    txtbds_gia_tri_qsd_dat_o.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_gia_tri_qsd_dat_o.Select(txtbds_gia_tri_qsd_dat_o.Text.Length, 0);

            Int64 bds_gia_tri_qsd_dat_o;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_o.Text))
            {
                bds_gia_tri_qsd_dat_o = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_o = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_1;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_1.Text))
            {
                bds_gia_tri_qsd_dat_khac_1 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_1 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_2;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_2.Text))
            {
                bds_gia_tri_qsd_dat_khac_2 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_3;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_3.Text))
            {
                bds_gia_tri_qsd_dat_khac_3 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_3 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3.Text));
            }

            txtbds_gia_tri_qsd_dat.Text = Convert.ToString(bds_gia_tri_qsd_dat_o + bds_gia_tri_qsd_dat_khac_1 + bds_gia_tri_qsd_dat_khac_2 + bds_gia_tri_qsd_dat_khac_3);
        }

        private void txtbds_gia_tri_qsd_dat_o_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //Giá trị quyền sử dụng đất khác 1 trên m2
        private void txtbds_gia_tri_qsd_dat_khac_1_tren_m2_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text == "")
            {
                txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text = null;
            }
            else
            {
                if (txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text));
                    txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Select(txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text.Length, 0);
        }

        private void txtbds_gia_tri_qsd_dat_khac_1_tren_m2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị quyền sử dụng đất khác 1
        private void txtbds_gia_tri_qsd_dat_khac_1_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_gia_tri_qsd_dat_khac_1.Text == "")
            {
                txtbds_gia_tri_qsd_dat_khac_1.Text = null;
            }
            else
            {
                if (txtbds_gia_tri_qsd_dat_khac_1.Text != "")
                {
                    Int64 d = Decimal.ToInt64(Convert.ToDecimal(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1.Text)));
                    txtbds_gia_tri_qsd_dat_khac_1.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_gia_tri_qsd_dat_khac_1.Select(txtbds_gia_tri_qsd_dat_khac_1.Text.Length, 0);

            Int64 bds_gia_tri_qsd_dat_o;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_o.Text))
            {
                bds_gia_tri_qsd_dat_o = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_o = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_1;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_1.Text))
            {
                bds_gia_tri_qsd_dat_khac_1 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_1 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_2;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_2.Text))
            {
                bds_gia_tri_qsd_dat_khac_2 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_3;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_3.Text))
            {
                bds_gia_tri_qsd_dat_khac_3 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_3 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3.Text));
            }

            txtbds_gia_tri_qsd_dat.Text = Convert.ToString(bds_gia_tri_qsd_dat_o + bds_gia_tri_qsd_dat_khac_1 + bds_gia_tri_qsd_dat_khac_2 + bds_gia_tri_qsd_dat_khac_3);
        }

        private void txtbds_gia_tri_qsd_dat_khac_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị quyền sử dụng đất khác 2 trên m2
        private void txtbds_gia_tri_qsd_dat_khac_2_tren_m2_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text == "")
            {
                txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text = null;
            }
            else
            {
                if (txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text));
                    txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Select(txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text.Length, 0);
        }

        private void txtbds_gia_tri_qsd_dat_khac_2_tren_m2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị quyền sử dụng đất khác 2
        private void txtbds_gia_tri_qsd_dat_khac_2_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_gia_tri_qsd_dat_khac_2.Text == "")
            {
                txtbds_gia_tri_qsd_dat_khac_2.Text = null;
            }
            else
            {
                if (txtbds_gia_tri_qsd_dat_khac_2.Text != "")
                {
                    Int64 d = Decimal.ToInt64(Convert.ToDecimal(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2.Text)));
                    txtbds_gia_tri_qsd_dat_khac_2.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_gia_tri_qsd_dat_khac_2.Select(txtbds_gia_tri_qsd_dat_khac_2.Text.Length, 0);

            Int64 bds_gia_tri_qsd_dat_o;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_o.Text))
            {
                bds_gia_tri_qsd_dat_o = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_o = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_1;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_1.Text))
            {
                bds_gia_tri_qsd_dat_khac_1 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_1 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_2;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_2.Text))
            {
                bds_gia_tri_qsd_dat_khac_2 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_3;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_3.Text))
            {
                bds_gia_tri_qsd_dat_khac_3 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_3 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3.Text));
            }

            txtbds_gia_tri_qsd_dat.Text = Convert.ToString(bds_gia_tri_qsd_dat_o + bds_gia_tri_qsd_dat_khac_1 + bds_gia_tri_qsd_dat_khac_2 + bds_gia_tri_qsd_dat_khac_3);
        }

        private void txtbds_gia_tri_qsd_dat_khac_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị quyền sử dụng đất khác 3 trên m2
        private void txtbds_gia_tri_qsd_dat_khac_3_tren_m2_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text == "")
            {
                txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text = null;
            }
            else
            {
                if (txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text));
                    txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Select(txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text.Length, 0);
        }

        private void txtbds_gia_tri_qsd_dat_khac_3_tren_m2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị quyền sử dụng đất khác 3
        private void txtbds_gia_tri_qsd_dat_khac_3_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_gia_tri_qsd_dat_khac_3.Text == "")
            {
                txtbds_gia_tri_qsd_dat_khac_3.Text = null;
            }
            else
            {
                if (txtbds_gia_tri_qsd_dat_khac_3.Text != "")
                {
                    Int64 d = Decimal.ToInt64(Convert.ToDecimal(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3.Text)));
                    txtbds_gia_tri_qsd_dat_khac_3.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_gia_tri_qsd_dat_khac_3.Select(txtbds_gia_tri_qsd_dat_khac_3.Text.Length, 0);

            Int64 bds_gia_tri_qsd_dat_o;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_o.Text))
            {
                bds_gia_tri_qsd_dat_o = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_o = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_1;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_1.Text))
            {
                bds_gia_tri_qsd_dat_khac_1 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_1 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_2;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_2.Text))
            {
                bds_gia_tri_qsd_dat_khac_2 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2.Text));
            }

            Int64 bds_gia_tri_qsd_dat_khac_3;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_3.Text))
            {
                bds_gia_tri_qsd_dat_khac_3 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_3 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3.Text));
            }

            txtbds_gia_tri_qsd_dat.Text = Convert.ToString(bds_gia_tri_qsd_dat_o + bds_gia_tri_qsd_dat_khac_1 + bds_gia_tri_qsd_dat_khac_2 + bds_gia_tri_qsd_dat_khac_3);
        }

        private void txtbds_gia_tri_qsd_dat_khac_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị bất động sản
        private void txtbds_gia_tri_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_gia_tri.Text == "")
            {
                txtbds_gia_tri.Text = null;
            }
            else
            {
                if (txtbds_gia_tri.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri.Text));
                    txtbds_gia_tri.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_gia_tri.Select(txtbds_gia_tri.Text.Length, 0);
        }

        private void txtbds_gia_tri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị nhà
        private void txtbds_nha_gia_tri_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_nha_gia_tri.Text == "")
            {
                txtbds_nha_gia_tri.Text = null;
            }
            else
            {
                if (txtbds_nha_gia_tri.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtbds_nha_gia_tri.Text));
                    txtbds_nha_gia_tri.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_nha_gia_tri.Select(txtbds_nha_gia_tri.Text.Length, 0);

            Int64 bds_gia_tri_qsd_dat;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat.Text))
            {
                bds_gia_tri_qsd_dat = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat.Text));
            }

            Int64 bds_nha_gia_tri;
            if (string.IsNullOrEmpty(txtbds_nha_gia_tri.Text))
            {
                bds_nha_gia_tri = 0;
            }
            else
            {
                bds_nha_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_nha_gia_tri.Text));
            }

            Int64 bds_ctxd_gia_tri;
            if (string.IsNullOrEmpty(txtbds_ctxd_gia_tri.Text))
            {
                bds_ctxd_gia_tri = 0;
            }
            else
            {
                bds_ctxd_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_ctxd_gia_tri.Text));
            }

            Int64 bds_tsgl_khac_gia_tri;
            if (string.IsNullOrEmpty(txtbds_tsgl_khac_gia_tri.Text))
            {
                bds_tsgl_khac_gia_tri = 0;
            }
            else
            {
                bds_tsgl_khac_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_tsgl_khac_gia_tri.Text));
            }

            txtbds_gia_tri.Text = Convert.ToString(bds_gia_tri_qsd_dat + bds_nha_gia_tri + bds_ctxd_gia_tri + bds_tsgl_khac_gia_tri);
        }

        private void txtbds_nha_gia_tri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị công trình xây dựng
        private void txtbds_ctxd_gia_tri_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_ctxd_gia_tri.Text == "")
            {
                txtbds_ctxd_gia_tri.Text = null;
            }
            else
            {
                if (txtbds_ctxd_gia_tri.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtbds_ctxd_gia_tri.Text));
                    txtbds_ctxd_gia_tri.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_ctxd_gia_tri.Select(txtbds_ctxd_gia_tri.Text.Length, 0);

            Int64 bds_gia_tri_qsd_dat;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat.Text))
            {
                bds_gia_tri_qsd_dat = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat.Text));
            }

            Int64 bds_nha_gia_tri;
            if (string.IsNullOrEmpty(txtbds_nha_gia_tri.Text))
            {
                bds_nha_gia_tri = 0;
            }
            else
            {
                bds_nha_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_nha_gia_tri.Text));
            }

            Int64 bds_ctxd_gia_tri;
            if (string.IsNullOrEmpty(txtbds_ctxd_gia_tri.Text))
            {
                bds_ctxd_gia_tri = 0;
            }
            else
            {
                bds_ctxd_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_ctxd_gia_tri.Text));
            }

            Int64 bds_tsgl_khac_gia_tri;
            if (string.IsNullOrEmpty(txtbds_tsgl_khac_gia_tri.Text))
            {
                bds_tsgl_khac_gia_tri = 0;
            }
            else
            {
                bds_tsgl_khac_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_tsgl_khac_gia_tri.Text));
            }

            txtbds_gia_tri.Text = Convert.ToString(bds_gia_tri_qsd_dat + bds_nha_gia_tri + bds_ctxd_gia_tri + bds_tsgl_khac_gia_tri);
        }

        private void txtbds_ctxd_gia_tri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị tài sản gắn liền khác
        private void txtbds_tsgl_khac_gia_tri_TextChanged(object sender, EventArgs e)
        {
            if (txtbds_tsgl_khac_gia_tri.Text == "")
            {
                txtbds_tsgl_khac_gia_tri.Text = null;
            }
            else
            {
                if (txtbds_tsgl_khac_gia_tri.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtbds_tsgl_khac_gia_tri.Text));
                    txtbds_tsgl_khac_gia_tri.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtbds_tsgl_khac_gia_tri.Select(txtbds_tsgl_khac_gia_tri.Text.Length, 0);

            Int64 bds_gia_tri_qsd_dat;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat.Text))
            {
                bds_gia_tri_qsd_dat = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat.Text));
            }

            Int64 bds_nha_gia_tri;
            if (string.IsNullOrEmpty(txtbds_nha_gia_tri.Text))
            {
                bds_nha_gia_tri = 0;
            }
            else
            {
                bds_nha_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_nha_gia_tri.Text));
            }

            Int64 bds_ctxd_gia_tri;
            if (string.IsNullOrEmpty(txtbds_ctxd_gia_tri.Text))
            {
                bds_ctxd_gia_tri = 0;
            }
            else
            {
                bds_ctxd_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_ctxd_gia_tri.Text));
            }

            Int64 bds_tsgl_khac_gia_tri;
            if (string.IsNullOrEmpty(txtbds_tsgl_khac_gia_tri.Text))
            {
                bds_tsgl_khac_gia_tri = 0;
            }
            else
            {
                bds_tsgl_khac_gia_tri = Convert.ToInt64(ControlFormat.skipComma(txtbds_tsgl_khac_gia_tri.Text));
            }

            txtbds_gia_tri.Text = Convert.ToString(bds_gia_tri_qsd_dat + bds_nha_gia_tri + bds_ctxd_gia_tri + bds_tsgl_khac_gia_tri);
        }

        private void txtbds_tsgl_khac_gia_tri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị tài sản thế chấp khác
        private void txttstc_khac_gia_tri_TextChanged(object sender, EventArgs e)
        {
            if (txttstc_khac_gia_tri.Text == "")
            {
                txttstc_khac_gia_tri.Text = null;
            }
            else
            {
                if (txttstc_khac_gia_tri.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txttstc_khac_gia_tri.Text));
                    txttstc_khac_gia_tri.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txttstc_khac_gia_tri.Select(txttstc_khac_gia_tri.Text.Length, 0);
        }

        private void txttstc_khac_gia_tri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Giá trị động sản
        private void txtds_gia_tri_TextChanged(object sender, EventArgs e)
        {
            if (txtds_gia_tri.Text == "")
            {
                txtds_gia_tri.Text = null;
            }
            else
            {
                if (txtds_gia_tri.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtds_gia_tri.Text));
                    txtds_gia_tri.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            txtds_gia_tri.Select(txtds_gia_tri.Text.Length, 0);
        }

        private void txtds_gia_tri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }



        private void txtbds_tong_dien_tich_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbds_tong_dien_tich.Text))
            {
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_tong_dien_tich.Text))
                {
                    MessageBox.Show("Dữ liệu chưa được nhập hoặc nhập chưa đúng định dạng, đề nghị nhập lại!");
                    txtbds_tong_dien_tich.Focus();
                    return;
                }
            }
        }

        private void txtbds_dien_tich_dat_o_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
            {
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_dat_o.Text))
                {
                    MessageBox.Show("Dữ liệu chưa được nhập hoặc nhập chưa đúng định dạng, đề nghị nhập lại!");
                    txtbds_dien_tich_dat_o.Focus();
                    return;
                }

                Decimal bds_dien_tich_dat_o = Convert.ToDecimal(txtbds_dien_tich_dat_o.Text);
                Int64 bds_gia_tri_qsd_dat_o_tren_m2;
                if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_o_tren_m2.Text))
                {
                    bds_gia_tri_qsd_dat_o_tren_m2 = 0;
                }
                else
                {
                    bds_gia_tri_qsd_dat_o_tren_m2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o_tren_m2.Text));
                }
                txtbds_gia_tri_qsd_dat_o.Text = Convert.ToString(bds_dien_tich_dat_o * bds_gia_tri_qsd_dat_o_tren_m2);
                //if (string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
                //{
                //    bds_dien_tich_dat_o = 0;
                //}
                //else
                //{
                //    bds_dien_tich_dat_o = Convert.ToDecimal(txtbds_dien_tich_dat_o.Text);
                //}

                Decimal bds_dien_tich_dat_khac_1;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_1.Text))
                {
                    bds_dien_tich_dat_khac_1 = 0;
                }
                else
                {
                    bds_dien_tich_dat_khac_1 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_1.Text);
                }

                Decimal bds_dien_tich_dat_khac_2;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_2.Text))
                {
                    bds_dien_tich_dat_khac_2 = 0;
                }
                else
                {
                    bds_dien_tich_dat_khac_2 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_2.Text);
                }

                Decimal bds_dien_tich_dat_khac_3;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_3.Text))
                {
                    bds_dien_tich_dat_khac_3 = 0;
                }
                else
                {
                    bds_dien_tich_dat_khac_3 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_3.Text);
                }

                txtbds_tong_dien_tich.Text = Convert.ToString(bds_dien_tich_dat_o + bds_dien_tich_dat_khac_1 + bds_dien_tich_dat_khac_2 + bds_dien_tich_dat_khac_3);          
            }  
        }

        private void txtbds_dien_tich_dat_khac_1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_1.Text))
            {
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_dat_khac_1.Text))
                {
                    MessageBox.Show("Dữ liệu chưa được nhập hoặc nhập chưa đúng định dạng, đề nghị nhập lại!");
                    txtbds_dien_tich_dat_khac_1.Focus();
                    return;
                }

                Decimal bds_dien_tich_dat_khac_1 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_1.Text);
                Int64 bds_gia_tri_qsd_dat_khac_1_tren_m2;
                if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text))
                {
                    bds_gia_tri_qsd_dat_khac_1_tren_m2 = 0;
                }
                else
                {
                    bds_gia_tri_qsd_dat_khac_1_tren_m2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text));
                }
                txtbds_gia_tri_qsd_dat_khac_1.Text = Convert.ToString(bds_dien_tich_dat_khac_1 * bds_gia_tri_qsd_dat_khac_1_tren_m2);

                Decimal bds_dien_tich_dat_o;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
                {
                    bds_dien_tich_dat_o = 0;
                }
                else
                {
                    bds_dien_tich_dat_o = Convert.ToDecimal(txtbds_dien_tich_dat_o.Text);
                }

                //Decimal bds_dien_tich_dat_khac_1;
                //if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_1.Text))
                //{
                //    bds_dien_tich_dat_khac_1 = 0;
                //}
                //else
                //{
                //    bds_dien_tich_dat_khac_1 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_1.Text);
                //}

                Decimal bds_dien_tich_dat_khac_2;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_2.Text))
                {
                    bds_dien_tich_dat_khac_2 = 0;
                }
                else
                {
                    bds_dien_tich_dat_khac_2 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_2.Text);
                }

                Decimal bds_dien_tich_dat_khac_3;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_3.Text))
                {
                    bds_dien_tich_dat_khac_3 = 0;
                }
                else
                {
                    bds_dien_tich_dat_khac_3 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_3.Text);
                }

                txtbds_tong_dien_tich.Text = Convert.ToString(bds_dien_tich_dat_o + bds_dien_tich_dat_khac_1 + bds_dien_tich_dat_khac_2 + bds_dien_tich_dat_khac_3);
            }       
        }

        private void txtbds_dien_tich_dat_khac_2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_2.Text))
            {
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_dat_khac_2.Text))
                {
                    MessageBox.Show("Dữ liệu chưa được nhập hoặc nhập chưa đúng định dạng, đề nghị nhập lại!");
                    txtbds_dien_tich_dat_khac_2.Focus();
                    return;
                }

                Decimal bds_dien_tich_dat_khac_2 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_2.Text);
                Int64 bds_gia_tri_qsd_dat_khac_2_tren_m2;
                if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text))
                {
                    bds_gia_tri_qsd_dat_khac_2_tren_m2 = 0;
                }
                else
                {
                    bds_gia_tri_qsd_dat_khac_2_tren_m2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text));
                }
                txtbds_gia_tri_qsd_dat_khac_2.Text = Convert.ToString(bds_dien_tich_dat_khac_2 * bds_gia_tri_qsd_dat_khac_2_tren_m2);

                Decimal bds_dien_tich_dat_o;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
                {
                    bds_dien_tich_dat_o = 0;
                }
                else
                {
                    bds_dien_tich_dat_o = Convert.ToDecimal(txtbds_dien_tich_dat_o.Text);
                }

                Decimal bds_dien_tich_dat_khac_1;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_1.Text))
                {
                    bds_dien_tich_dat_khac_1 = 0;
                }
                else
                {
                    bds_dien_tich_dat_khac_1 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_1.Text);
                }

                //Decimal bds_dien_tich_dat_khac_2;
                //if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_2.Text))
                //{
                //    bds_dien_tich_dat_khac_2 = 0;
                //}
                //else
                //{
                //    bds_dien_tich_dat_khac_2 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_2.Text);
                //}

                Decimal bds_dien_tich_dat_khac_3;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_3.Text))
                {
                    bds_dien_tich_dat_khac_3 = 0;
                }
                else
                {
                    bds_dien_tich_dat_khac_3 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_3.Text);
                }

                txtbds_tong_dien_tich.Text = Convert.ToString(bds_dien_tich_dat_o + bds_dien_tich_dat_khac_1 + bds_dien_tich_dat_khac_2 + bds_dien_tich_dat_khac_3);
            }
            
        }

        private void txtbds_dien_tich_dat_khac_3_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_3.Text))
            {
                if (!Utilities.CommonMethods.KiemTraNhapSo_Decimal(txtbds_dien_tich_dat_khac_3.Text))
                {
                    MessageBox.Show("Dữ liệu chưa được nhập hoặc nhập chưa đúng định dạng, đề nghị nhập lại!");
                    txtbds_dien_tich_dat_khac_3.Focus();
                    return;
                }
                Decimal bds_dien_tich_dat_khac_3 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_3.Text);
                Int64 bds_gia_tri_qsd_dat_khac_3_tren_m2;
                if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text))
                {
                    bds_gia_tri_qsd_dat_khac_3_tren_m2 = 0;
                }
                else
                {
                    bds_gia_tri_qsd_dat_khac_3_tren_m2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text));
                }
                txtbds_gia_tri_qsd_dat_khac_3.Text = Convert.ToString(bds_dien_tich_dat_khac_3 * bds_gia_tri_qsd_dat_khac_3_tren_m2);

                Decimal bds_dien_tich_dat_o;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
                {
                    bds_dien_tich_dat_o = 0;
                }
                else
                {
                    bds_dien_tich_dat_o = Convert.ToDecimal(txtbds_dien_tich_dat_o.Text);
                }

                Decimal bds_dien_tich_dat_khac_1;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_1.Text))
                {
                    bds_dien_tich_dat_khac_1 = 0;
                }
                else
                {
                    bds_dien_tich_dat_khac_1 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_1.Text);
                }

                Decimal bds_dien_tich_dat_khac_2;
                if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_2.Text))
                {
                    bds_dien_tich_dat_khac_2 = 0;
                }
                else
                {
                    bds_dien_tich_dat_khac_2 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_2.Text);
                }

                //Decimal bds_dien_tich_dat_khac_3;
                //if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_3.Text))
                //{
                //    bds_dien_tich_dat_khac_3 = 0;
                //}
                //else
                //{
                //    bds_dien_tich_dat_khac_3 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_3.Text);
                //}

                txtbds_tong_dien_tich.Text = Convert.ToString(bds_dien_tich_dat_o + bds_dien_tich_dat_khac_1 + bds_dien_tich_dat_khac_2 + bds_dien_tich_dat_khac_3);
            }       
        }

        private void txtbds_gia_tri_qsd_dat_o_tren_m2_Leave(object sender, EventArgs e)
        {
            Decimal bds_dien_tich_dat_o;
            if (string.IsNullOrEmpty(txtbds_dien_tich_dat_o.Text))
            {
                bds_dien_tich_dat_o = 0;
            }
            else
            {
                bds_dien_tich_dat_o = Convert.ToDecimal(txtbds_dien_tich_dat_o.Text);
            }

            Int64 bds_gia_tri_qsd_dat_o_tren_m2;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_o_tren_m2.Text))
            {
                bds_gia_tri_qsd_dat_o_tren_m2 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_o_tren_m2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_o_tren_m2.Text));
            }
            txtbds_gia_tri_qsd_dat_o.Text = Convert.ToString(bds_dien_tich_dat_o * bds_gia_tri_qsd_dat_o_tren_m2);
        }

        private void txtbds_gia_tri_qsd_dat_khac_1_tren_m2_Leave(object sender, EventArgs e)
        {
            Decimal bds_dien_tich_dat_khac_1;
            if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_1.Text))
            {
                bds_dien_tich_dat_khac_1 = 0;
            }
            else
            {
                bds_dien_tich_dat_khac_1 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_1.Text);
            }

            Int64 bds_gia_tri_qsd_dat_khac_1_tren_m2;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text))
            {
                bds_gia_tri_qsd_dat_khac_1_tren_m2 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_1_tren_m2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_1_tren_m2.Text));
            }
            txtbds_gia_tri_qsd_dat_khac_1.Text = Convert.ToString(bds_dien_tich_dat_khac_1 * bds_gia_tri_qsd_dat_khac_1_tren_m2);
        }

        private void txtbds_gia_tri_qsd_dat_khac_2_tren_m2_Leave(object sender, EventArgs e)
        {
            Decimal bds_dien_tich_dat_khac_2;
            if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_2.Text))
            {
                bds_dien_tich_dat_khac_2 = 0;
            }
            else
            {
                bds_dien_tich_dat_khac_2 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_2.Text);
            }

            Int64 bds_gia_tri_qsd_dat_khac_2_tren_m2;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text))
            {
                bds_gia_tri_qsd_dat_khac_2_tren_m2 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_2_tren_m2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_2_tren_m2.Text));
            }
            txtbds_gia_tri_qsd_dat_khac_2.Text = Convert.ToString(bds_dien_tich_dat_khac_2 * bds_gia_tri_qsd_dat_khac_2_tren_m2);
        }

        private void txtbds_gia_tri_qsd_dat_khac_3_tren_m2_Leave(object sender, EventArgs e)
        {
            Decimal bds_dien_tich_dat_khac_3;
            if (string.IsNullOrEmpty(txtbds_dien_tich_dat_khac_3.Text))
            {
                bds_dien_tich_dat_khac_3 = 0;
            }
            else
            {
                bds_dien_tich_dat_khac_3 = Convert.ToDecimal(txtbds_dien_tich_dat_khac_3.Text);
            }

            Int64 bds_gia_tri_qsd_dat_khac_3_tren_m2;
            if (string.IsNullOrEmpty(txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text))
            {
                bds_gia_tri_qsd_dat_khac_3_tren_m2 = 0;
            }
            else
            {
                bds_gia_tri_qsd_dat_khac_3_tren_m2 = Convert.ToInt64(ControlFormat.skipComma(txtbds_gia_tri_qsd_dat_khac_3_tren_m2.Text));
            }
            txtbds_gia_tri_qsd_dat_khac_3.Text = Convert.ToString(bds_dien_tich_dat_khac_3 * bds_gia_tri_qsd_dat_khac_3_tren_m2);
        }

        private void cboxloai_chu_so_huu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxloai_chu_so_huu.Text == "Cá nhân")
            {
                grbCn_thong_tin_csh.BringToFront();
                cboxCn_danh_xung.Text = "Ông";
                //grbHgd_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbHgd_thong_tin_csh);
                cboxhgd_dai_dien.Text = "";
                //cboxhgd_nguoi_so_huu.Text = "";
                //grbTc_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbTc_thong_tin_csh);
                cboxTc_danh_xung_dai_dien.Text = "";

                //if (this._ma_ts_the_chap == 0)
                //{
                    //CommonMethods.ClearTextBoxesInGroupBox(this.grbCn_thong_tin_csh);
                    txtCn_noi_cap_cmnd.Text = "CA tỉnh Hải Dương";
                    txtCn_noi_cap_hk.Text = "CA thành phố Hải Dương";
                //}
                //txtTc_noi_cap_cmnd_dai_dien.Clear();
                //txtTc_noi_cap_hk_dai_dien.Clear();
                //txtHgd_noi_cap_cmnd_chong.Clear();
                //txtHgd_noi_cap_hk_chong.Clear();
                //txtHgd_noi_cap_cmnd_vo.Clear();
                //txtHgd_noi_cap_hk_vo.Clear();
            }
            else if (cboxloai_chu_so_huu.Text == "Hộ gia đình")
            {
                //grbCn_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbCn_thong_tin_csh);
                cboxCn_danh_xung.Text = "";
                grbHgd_thong_tin_csh.BringToFront();
                cboxhgd_dai_dien.Text = "Chồng";
                //grbTc_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbTc_thong_tin_csh);
                cboxTc_danh_xung_dai_dien.Text = "";

                //if (this._ma_ts_the_chap == 0)
                //{
                    //CommonMethods.ClearTextBoxesInGroupBox(this.grbHgd_thong_tin_csh);
                    txtHgd_noi_cap_cmnd_chong.Text = "CA tỉnh Hải Dương";
                    txtHgd_noi_cap_hk_chong.Text = "CA thành phố Hải Dương";
                    txtHgd_noi_cap_cmnd_vo.Text = "CA tỉnh Hải Dương";
                    txtHgd_noi_cap_hk_vo.Text = "CA thành phố Hải Dương";
                //}

                //txtCn_noi_cap_cmnd.Clear();
                //txtCn_noi_cap_hk.Clear();
                //txtTc_noi_cap_cmnd_dai_dien.Clear();
                //txtTc_noi_cap_hk_dai_dien.Clear();

            }
            else if (cboxloai_chu_so_huu.Text == "Tổ chức")
            {
                //grbCn_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbCn_thong_tin_csh);
                cboxCn_danh_xung.Text = "";
                //grbHgd_thong_tin_csh.Visible = false;
                CommonMethods.ClearTextBoxesInGroupBox(this.grbHgd_thong_tin_csh);
                cboxhgd_dai_dien.Text = "";
                //cboxhgd_nguoi_so_huu.Text = "";
                grbTc_thong_tin_csh.BringToFront();
                cboxTc_danh_xung_dai_dien.Text = "Ông";

                //if (this._ma_ts_the_chap == 0)
                //{
                    //CommonMethods.ClearTextBoxesInGroupBox(this.grbTc_thong_tin_csh);
                    txtTc_chuc_vu_dai_dien.Text = "Giám đốc";
                    txtTc_noi_cap_cmnd_dai_dien.Text = "CA tỉnh Hải Dương";
                    txtTc_noi_cap_hk_dai_dien.Text = "CA thành phố Hải Dương";
                //}

                //txtCn_noi_cap_cmnd.Clear();
                //txtCn_noi_cap_hk.Clear();
                //txtHgd_noi_cap_cmnd_chong.Clear();
                //txtHgd_noi_cap_hk_chong.Clear();
                //txtHgd_noi_cap_cmnd_vo.Clear();
                //txtHgd_noi_cap_hk_vo.Clear();
            }

        }

        private void txtCn_dc_TextChanged(object sender, EventArgs e)
        {
            txtCn_hktt.Text = txtCn_dc.Text;
        }

        private void txtTc_dc_TextChanged(object sender, EventArgs e)
        {
            txtTc_dc_dai_dien.Text = txtTc_dc.Text;
            txtTc_hktt_dai_dien.Text = txtTc_dc.Text;
        }

        private void txtbds_dien_tich_dat_o_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar < 48 && e.KeyChar != 46) || e.KeyChar > 57 ) && e.KeyChar != 8)
            if ((e.KeyChar < 45 || e.KeyChar > 57 ) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void txtbds_dien_tich_dat_khac_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 45 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void txtbds_dien_tich_dat_khac_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 45 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void txtbds_dien_tich_dat_khac_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 45 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void txtbds_dien_tich_su_dung_rieng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 45 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void txtbds_dien_tich_su_dung_chung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 45 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void txtCn_ns_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ns.Text) && (txtCn_ns.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtCn_ns.Focus();
                return;
            }
        }

        private void txtCn_ngay_cap_cmnd_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_cmnd.Text) && (txtCn_ngay_cap_cmnd.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtCn_ngay_cap_cmnd.Focus();
                return;
            }
        }

        private void txtCn_ngay_cap_hk_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtCn_ngay_cap_hk.Text) && (txtCn_ngay_cap_hk.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtCn_ngay_cap_hk.Focus();
                return;
            }
        }

        private void txtTc_ns_dai_dien_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ns_dai_dien.Text) && (txtTc_ns_dai_dien.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtTc_ns_dai_dien.Focus();
                return;
            }
        }

        private void txtTc_ngay_cap_cmnd_dai_dien_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_cmnd_dai_dien.Text) && (txtTc_ngay_cap_cmnd_dai_dien.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtTc_ngay_cap_cmnd_dai_dien.Focus();
                return;
            }
        }

        private void txtTc_ngay_cap_hk_dai_dien_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtTc_ngay_cap_hk_dai_dien.Text) && (txtTc_ngay_cap_hk_dai_dien.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtTc_ngay_cap_hk_dai_dien.Focus();
                return;
            }
        }

        private void txtHgd_ns_chong_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_chong.Text) && (txtHgd_ns_chong.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtHgd_ns_chong.Focus();
                return;
            }
        }

        private void txtHgd_ngay_cap_cmnd_chong_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_chong.Text) && (txtHgd_ngay_cap_cmnd_chong.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtHgd_ngay_cap_cmnd_chong.Focus();
                return;
            }
        }

        private void txtHgd_ngay_cap_hk_chong_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_chong.Text) && (txtHgd_ngay_cap_hk_chong.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtHgd_ngay_cap_hk_chong.Focus();
                return;
            }
        }

        private void txtHgd_ns_vo_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ns_vo.Text) && (txtHgd_ns_vo.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtHgd_ns_vo.Focus();
                return;
            }
        }

        private void txtHgd_ngay_cap_cmnd_vo_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_cmnd_vo.Text) && (txtHgd_ngay_cap_cmnd_vo.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtHgd_ngay_cap_cmnd_vo.Focus();
                return;
            }
        }

        private void txtHgd_ngay_cap_hk_vo_Leave(object sender, EventArgs e)
        {
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHgd_ngay_cap_hk_vo.Text) && (txtHgd_ngay_cap_hk_vo.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtHgd_ngay_cap_hk_vo.Focus();
                return;
            }
        }

        private void txtHgd_ns_chong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtHgd_ns_vo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtCn_ns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTc_ns_dai_dien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
