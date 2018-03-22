using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Globalization;

namespace AGRIBANKHD.Entities
{
    class Taisanthechap
    {
        #region Instance Properties

        private Int32 _ma_ts_the_chap;
        public Int32 ma_ts_the_chap

        { 
        get { return _ma_ts_the_chap; }
        set { _ma_ts_the_chap = value; }
        } 

        private string _ma_hd_vay;
        public string ma_hd_vay

        { 
        get { return _ma_hd_vay; }
        set { _ma_hd_vay = value; }
        } 

        private string _loai_chu_so_huu;
        public string loai_chu_so_huu

        { 
        get { return _loai_chu_so_huu; }
        set { _loai_chu_so_huu = value; }
        } 

        private string _loai_ts_the_chap;
        public string loai_ts_the_chap

        { 
        get { return _loai_ts_the_chap; }
        set { _loai_ts_the_chap = value; }
        } 

        private string _hinh_thuc_so_huu_cua_kh_vay;
        public string hinh_thuc_so_huu_cua_kh_vay

        { 
        get { return _hinh_thuc_so_huu_cua_kh_vay; }
        set { _hinh_thuc_so_huu_cua_kh_vay = value; }
        } 

        private string _hgd_ten_chong;
        public string hgd_ten_chong

        { 
        get { return _hgd_ten_chong; }
        set { _hgd_ten_chong = value; }
        } 

        private string _hgd_ns_chong;
        public string hgd_ns_chong

        { 
        get { return _hgd_ns_chong; }
        set { _hgd_ns_chong = value; }
        } 

        private string _hgd_cmnd_chong;
        public string hgd_cmnd_chong

        { 
        get { return _hgd_cmnd_chong; }
        set { _hgd_cmnd_chong = value; }
        } 

        private string _hgd_ngay_cap_cmnd_chong;
        public string hgd_ngay_cap_cmnd_chong

        { 
        get { return _hgd_ngay_cap_cmnd_chong; }
        set { _hgd_ngay_cap_cmnd_chong = value; }
        } 

        private string _hgd_noi_cap_cmnd_chong;
        public string hgd_noi_cap_cmnd_chong

        { 
        get { return _hgd_noi_cap_cmnd_chong; }
        set { _hgd_noi_cap_cmnd_chong = value; }
        } 

        private string _hgd_dc_chong;
        public string hgd_dc_chong

        { 
        get { return _hgd_dc_chong; }
        set { _hgd_dc_chong = value; }
        } 

        private string _hgd_hktt_chong;
        public string hgd_hktt_chong

        { 
        get { return _hgd_hktt_chong; }
        set { _hgd_hktt_chong = value; }
        } 

        private string _hgd_so_hk_chong;
        public string hgd_so_hk_chong

        { 
        get { return _hgd_so_hk_chong; }
        set { _hgd_so_hk_chong = value; }
        } 

        private string _hgd_noi_cap_hk_chong;
        public string hgd_noi_cap_hk_chong

        { 
        get { return _hgd_noi_cap_hk_chong; }
        set { _hgd_noi_cap_hk_chong = value; }
        } 

        private string _hgd_ngay_cap_hk_chong;
        public string hgd_ngay_cap_hk_chong

        { 
        get { return _hgd_ngay_cap_hk_chong; }
        set { _hgd_ngay_cap_hk_chong = value; }
        } 

        private string _hgd_ten_vo;
        public string hgd_ten_vo

        { 
        get { return _hgd_ten_vo; }
        set { _hgd_ten_vo = value; }
        } 

        private string _hgd_ns_vo;
        public string hgd_ns_vo

        { 
        get { return _hgd_ns_vo; }
        set { _hgd_ns_vo = value; }
        } 

        private string _hgd_cmnd_vo;
        public string hgd_cmnd_vo

        { 
        get { return _hgd_cmnd_vo; }
        set { _hgd_cmnd_vo = value; }
        } 

        private string _hgd_ngay_cap_cmnd_vo;
        public string hgd_ngay_cap_cmnd_vo

        { 
        get { return _hgd_ngay_cap_cmnd_vo; }
        set { _hgd_ngay_cap_cmnd_vo = value; }
        } 

        private string _hgd_noi_cap_cmnd_vo;
        public string hgd_noi_cap_cmnd_vo

        { 
        get { return _hgd_noi_cap_cmnd_vo; }
        set { _hgd_noi_cap_cmnd_vo = value; }
        } 

        private string _hgd_dc_vo;
        public string hgd_dc_vo

        { 
        get { return _hgd_dc_vo; }
        set { _hgd_dc_vo = value; }
        } 

        private string _hgd_hktt_vo;
        public string hgd_hktt_vo

        { 
        get { return _hgd_hktt_vo; }
        set { _hgd_hktt_vo = value; }
        } 

        private string _hgd_so_hk_vo;
        public string hgd_so_hk_vo

        { 
        get { return _hgd_so_hk_vo; }
        set { _hgd_so_hk_vo = value; }
        } 

        private string _hgd_noi_cap_hk_vo;
        public string hgd_noi_cap_hk_vo

        { 
        get { return _hgd_noi_cap_hk_vo; }
        set { _hgd_noi_cap_hk_vo = value; }
        } 

        private string _hgd_ngay_cap_hk_vo;
        public string hgd_ngay_cap_hk_vo

        { 
        get { return _hgd_ngay_cap_hk_vo; }
        set { _hgd_ngay_cap_hk_vo = value; }
        } 

        private string _hgd_dkkd;
        public string hgd_dkkd

        { 
        get { return _hgd_dkkd; }
        set { _hgd_dkkd = value; }
        } 

        private string _hgd_dien_thoai;
        public string hgd_dien_thoai

        { 
        get { return _hgd_dien_thoai; }
        set { _hgd_dien_thoai = value; }
        } 

        private string _hgd_fax;
        public string hgd_fax

        { 
        get { return _hgd_fax; }
        set { _hgd_fax = value; }
        } 

        private string _hgd_email;
        public string hgd_email

        { 
        get { return _hgd_email; }
        set { _hgd_email = value; }
        } 

        private string _hgd_dai_dien;
        public string hgd_dai_dien

        { 
        get { return _hgd_dai_dien; }
        set { _hgd_dai_dien = value; }
        } 

        private string _hgd_nguoi_so_huu;
        public string hgd_nguoi_so_huu

        { 
        get { return _hgd_nguoi_so_huu; }
        set { _hgd_nguoi_so_huu = value; }
        } 

        private string _cn_danh_xung;
        public string cn_danh_xung

        { 
        get { return _cn_danh_xung; }
        set { _cn_danh_xung = value; }
        } 

        private string _cn_ten;
        public string cn_ten

        { 
        get { return _cn_ten; }
        set { _cn_ten = value; }
        } 

        private string _cn_ns;
        public string cn_ns

        { 
        get { return _cn_ns; }
        set { _cn_ns = value; }
        } 

        private string _cn_cmnd;
        public string cn_cmnd

        { 
        get { return _cn_cmnd; }
        set { _cn_cmnd = value; }
        } 

        private string _cn_ngay_cap_cmnd;
        public string cn_ngay_cap_cmnd

        { 
        get { return _cn_ngay_cap_cmnd; }
        set { _cn_ngay_cap_cmnd = value; }
        } 

        private string _cn_noi_cap_cmnd;
        public string cn_noi_cap_cmnd

        { 
        get { return _cn_noi_cap_cmnd; }
        set { _cn_noi_cap_cmnd = value; }
        } 

        private string _cn_dc;
        public string cn_dc

        { 
        get { return _cn_dc; }
        set { _cn_dc = value; }
        } 

        private string _cn_hktt;
        public string cn_hktt

        { 
        get { return _cn_hktt; }
        set { _cn_hktt = value; }
        } 

        private string _cn_so_hk;
        public string cn_so_hk

        { 
        get { return _cn_so_hk; }
        set { _cn_so_hk = value; }
        } 

        private string _cn_noi_cap_hk;
        public string cn_noi_cap_hk

        { 
        get { return _cn_noi_cap_hk; }
        set { _cn_noi_cap_hk = value; }
        } 

        private string _cn_ngay_cap_hk;
        public string cn_ngay_cap_hk

        { 
        get { return _cn_ngay_cap_hk; }
        set { _cn_ngay_cap_hk = value; }
        } 

        private string _cn_dkkd;
        public string cn_dkkd

        { 
        get { return _cn_dkkd; }
        set { _cn_dkkd = value; }
        } 

        private string _cn_dien_thoai;
        public string cn_dien_thoai

        { 
        get { return _cn_dien_thoai; }
        set { _cn_dien_thoai = value; }
        } 

        private string _cn_fax;
        public string cn_fax

        { 
        get { return _cn_fax; }
        set { _cn_fax = value; }
        } 

        private string _cn_email;
        public string cn_email

        { 
        get { return _cn_email; }
        set { _cn_email = value; }
        } 

        private string _tc_ten;
        public string tc_ten

        { 
        get { return _tc_ten; }
        set { _tc_ten = value; }
        } 

        private string _tc_dkkd;
        public string tc_dkkd

        { 
        get { return _tc_dkkd; }
        set { _tc_dkkd = value; }
        } 

        private string _tc_dc;
        public string tc_dc

        { 
        get { return _tc_dc; }
        set { _tc_dc = value; }
        } 

        private string _tc_danh_xung_dai_dien;
        public string tc_danh_xung_dai_dien

        { 
        get { return _tc_danh_xung_dai_dien; }
        set { _tc_danh_xung_dai_dien = value; }
        } 

        private string _tc_dai_dien;
        public string tc_dai_dien

        { 
        get { return _tc_dai_dien; }
        set { _tc_dai_dien = value; }
        } 

        private string _tc_ns_dai_dien;
        public string tc_ns_dai_dien

        { 
        get { return _tc_ns_dai_dien; }
        set { _tc_ns_dai_dien = value; }
        } 

        private string _tc_chuc_vu_dai_dien;
        public string tc_chuc_vu_dai_dien

        { 
        get { return _tc_chuc_vu_dai_dien; }
        set { _tc_chuc_vu_dai_dien = value; }
        } 

        private string _tc_giay_uy_quyen;
        public string tc_giay_uy_quyen

        { 
        get { return _tc_giay_uy_quyen; }
        set { _tc_giay_uy_quyen = value; }
        } 

        private string _tc_dc_dai_dien;
        public string tc_dc_dai_dien

        { 
        get { return _tc_dc_dai_dien; }
        set { _tc_dc_dai_dien = value; }
        } 

        private string _tc_cmnd_dai_dien;
        public string tc_cmnd_dai_dien

        { 
        get { return _tc_cmnd_dai_dien; }
        set { _tc_cmnd_dai_dien = value; }
        } 

        private string _tc_ngay_cap_cmnd_dai_dien;
        public string tc_ngay_cap_cmnd_dai_dien

        { 
        get { return _tc_ngay_cap_cmnd_dai_dien; }
        set { _tc_ngay_cap_cmnd_dai_dien = value; }
        } 

        private string _tc_noi_cap_cmnd_dai_dien;
        public string tc_noi_cap_cmnd_dai_dien

        { 
        get { return _tc_noi_cap_cmnd_dai_dien; }
        set { _tc_noi_cap_cmnd_dai_dien = value; }
        } 

        private string _tc_hktt_dai_dien;
        public string tc_hktt_dai_dien

        { 
        get { return _tc_hktt_dai_dien; }
        set { _tc_hktt_dai_dien = value; }
        } 

        private string _tc_so_hk_dai_dien;
        public string tc_so_hk_dai_dien

        { 
        get { return _tc_so_hk_dai_dien; }
        set { _tc_so_hk_dai_dien = value; }
        } 

        private string _tc_noi_cap_hk_dai_dien;
        public string tc_noi_cap_hk_dai_dien

        { 
        get { return _tc_noi_cap_hk_dai_dien; }
        set { _tc_noi_cap_hk_dai_dien = value; }
        } 

        private string _tc_ngay_cap_hk_dai_dien;
        public string tc_ngay_cap_hk_dai_dien

        { 
        get { return _tc_ngay_cap_hk_dai_dien; }
        set { _tc_ngay_cap_hk_dai_dien = value; }
        } 

        private string _tc_dien_thoai;
        public string tc_dien_thoai

        { 
        get { return _tc_dien_thoai; }
        set { _tc_dien_thoai = value; }
        } 

        private string _tc_fax;
        public string tc_fax

        { 
        get { return _tc_fax; }
        set { _tc_fax = value; }
        } 

        private string _tc_email;
        public string tc_email

        { 
        get { return _tc_email; }
        set { _tc_email = value; }
        } 

        private string _ds_ten;
        public string ds_ten

        { 
        get { return _ds_ten; }
        set { _ds_ten = value; }
        } 

        private string _ds_nhan_hieu;
        public string ds_nhan_hieu

        { 
        get { return _ds_nhan_hieu; }
        set { _ds_nhan_hieu = value; }
        } 

        private string _ds_thong_tin_chung_rtf;
        public string ds_thong_tin_chung_rtf

        { 
        get { return _ds_thong_tin_chung_rtf; }
        set { _ds_thong_tin_chung_rtf = value; }
        } 

        private string _ds_thong_tin_chung;
        public string ds_thong_tin_chung

        { 
        get { return _ds_thong_tin_chung; }
        set { _ds_thong_tin_chung = value; }
        } 

        private string _ds_giay_to;
        public string ds_giay_to

        { 
        get { return _ds_giay_to; }
        set { _ds_giay_to = value; }
        } 

        private Int64 _ds_gia_tri;
        public Int64 ds_gia_tri

        { 
        get { return _ds_gia_tri; }
        set { _ds_gia_tri = value; }
        } 

        private string _bds_ten;
        public string bds_ten

        { 
        get { return _bds_ten; }
        set { _bds_ten = value; }
        } 

        private decimal _bds_tong_dien_tich;
        public decimal bds_tong_dien_tich

        { 
        get { return _bds_tong_dien_tich; }
        set { _bds_tong_dien_tich = value; }
        } 

        private Int64 _bds_gia_tri_qsd_dat;
        public Int64 bds_gia_tri_qsd_dat

        { 
        get { return _bds_gia_tri_qsd_dat; }
        set { _bds_gia_tri_qsd_dat = value; }
        } 

        private decimal _bds_dien_tich_dat_o;
        public decimal bds_dien_tich_dat_o

        { 
        get { return _bds_dien_tich_dat_o; }
        set { _bds_dien_tich_dat_o = value; }
        } 

        private Int64 _bds_gia_tri_qsd_dat_o_tren_m2;
        public Int64 bds_gia_tri_qsd_dat_o_tren_m2

        { 
        get { return _bds_gia_tri_qsd_dat_o_tren_m2; }
        set { _bds_gia_tri_qsd_dat_o_tren_m2 = value; }
        } 

        private Int64 _bds_gia_tri_qsd_dat_o;
        public Int64 bds_gia_tri_qsd_dat_o

        { 
        get { return _bds_gia_tri_qsd_dat_o; }
        set { _bds_gia_tri_qsd_dat_o = value; }
        } 

        private string _bds_dat_khac_1;
        public string bds_dat_khac_1

        { 
        get { return _bds_dat_khac_1; }
        set { _bds_dat_khac_1 = value; }
        } 

        private decimal _bds_dien_tich_dat_khac_1;
        public decimal bds_dien_tich_dat_khac_1

        { 
        get { return _bds_dien_tich_dat_khac_1; }
        set { _bds_dien_tich_dat_khac_1 = value; }
        } 

        private Int64 _bds_gia_tri_qsd_dat_khac_1_tren_m2;
        public Int64 bds_gia_tri_qsd_dat_khac_1_tren_m2

        { 
        get { return _bds_gia_tri_qsd_dat_khac_1_tren_m2; }
        set { _bds_gia_tri_qsd_dat_khac_1_tren_m2 = value; }
        } 

        private Int64 _bds_gia_tri_qsd_dat_khac_1;
        public Int64 bds_gia_tri_qsd_dat_khac_1

        { 
        get { return _bds_gia_tri_qsd_dat_khac_1; }
        set { _bds_gia_tri_qsd_dat_khac_1 = value; }
        } 

        private string _bds_dat_khac_2;
        public string bds_dat_khac_2

        { 
        get { return _bds_dat_khac_2; }
        set { _bds_dat_khac_2 = value; }
        } 

        private decimal _bds_dien_tich_dat_khac_2;
        public decimal bds_dien_tich_dat_khac_2

        { 
        get { return _bds_dien_tich_dat_khac_2; }
        set { _bds_dien_tich_dat_khac_2 = value; }
        } 

        private Int64 _bds_gia_tri_qsd_dat_khac_2_tren_m2;
        public Int64 bds_gia_tri_qsd_dat_khac_2_tren_m2

        { 
        get { return _bds_gia_tri_qsd_dat_khac_2_tren_m2; }
        set { _bds_gia_tri_qsd_dat_khac_2_tren_m2 = value; }
        } 

        private Int64 _bds_gia_tri_qsd_dat_khac_2;
        public Int64 bds_gia_tri_qsd_dat_khac_2

        { 
        get { return _bds_gia_tri_qsd_dat_khac_2; }
        set { _bds_gia_tri_qsd_dat_khac_2 = value; }
        } 

        private string _bds_dat_khac_3;
        public string bds_dat_khac_3

        { 
        get { return _bds_dat_khac_3; }
        set { _bds_dat_khac_3 = value; }
        } 

        private decimal _bds_dien_tich_dat_khac_3;
        public decimal bds_dien_tich_dat_khac_3

        { 
        get { return _bds_dien_tich_dat_khac_3; }
        set { _bds_dien_tich_dat_khac_3 = value; }
        } 

        private Int64 _bds_gia_tri_qsd_dat_khac_3_tren_m2;
        public Int64 bds_gia_tri_qsd_dat_khac_3_tren_m2

        { 
        get { return _bds_gia_tri_qsd_dat_khac_3_tren_m2; }
        set { _bds_gia_tri_qsd_dat_khac_3_tren_m2 = value; }
        } 

        private Int64 _bds_gia_tri_qsd_dat_khac_3;
        public Int64 bds_gia_tri_qsd_dat_khac_3

        { 
        get { return _bds_gia_tri_qsd_dat_khac_3; }
        set { _bds_gia_tri_qsd_dat_khac_3 = value; }
        } 

        private decimal _bds_dien_tich_su_dung_rieng;
        public decimal bds_dien_tich_su_dung_rieng

        { 
        get { return _bds_dien_tich_su_dung_rieng; }
        set { _bds_dien_tich_su_dung_rieng = value; }
        } 

        private decimal _bds_dien_tich_su_dung_chung;
        public decimal bds_dien_tich_su_dung_chung

        { 
        get { return _bds_dien_tich_su_dung_chung; }
        set { _bds_dien_tich_su_dung_chung = value; }
        } 

        private string _bds_thong_tin_chung_rtf;
        public string bds_thong_tin_chung_rtf

        { 
        get { return _bds_thong_tin_chung_rtf; }
        set { _bds_thong_tin_chung_rtf = value; }
        } 

        private string _bds_thong_tin_chung;
        public string bds_thong_tin_chung

        { 
        get { return _bds_thong_tin_chung; }
        set { _bds_thong_tin_chung = value; }
        } 

        private string _bds_giay_to_rtf;
        public string bds_giay_to_rtf

        { 
        get { return _bds_giay_to_rtf; }
        set { _bds_giay_to_rtf = value; }
        } 

        private string _bds_giay_to;
        public string bds_giay_to

        { 
        get { return _bds_giay_to; }
        set { _bds_giay_to = value; }
        } 

        private string _bds_nha_thong_tin_chung_rtf;
        public string bds_nha_thong_tin_chung_rtf

        { 
        get { return _bds_nha_thong_tin_chung_rtf; }
        set { _bds_nha_thong_tin_chung_rtf = value; }
        } 

        private string _bds_nha_thong_tin_chung;
        public string bds_nha_thong_tin_chung

        { 
        get { return _bds_nha_thong_tin_chung; }
        set { _bds_nha_thong_tin_chung = value; }
        } 

        private Int64 _bds_nha_gia_tri;
        public Int64 bds_nha_gia_tri

        { 
        get { return _bds_nha_gia_tri; }
        set { _bds_nha_gia_tri = value; }
        } 

        private string _bds_ctxd_thong_tin_chung_rtf;
        public string bds_ctxd_thong_tin_chung_rtf

        { 
        get { return _bds_ctxd_thong_tin_chung_rtf; }
        set { _bds_ctxd_thong_tin_chung_rtf = value; }
        } 

        private string _bds_ctxd_thong_tin_chung;
        public string bds_ctxd_thong_tin_chung

        { 
        get { return _bds_ctxd_thong_tin_chung; }
        set { _bds_ctxd_thong_tin_chung = value; }
        } 

        private Int64 _bds_ctxd_gia_tri;
        public Int64 bds_ctxd_gia_tri

        { 
        get { return _bds_ctxd_gia_tri; }
        set { _bds_ctxd_gia_tri = value; }
        } 

        private string _bds_tsgl_khac_thong_tin_chung_rtf;
        public string bds_tsgl_khac_thong_tin_chung_rtf

        { 
        get { return _bds_tsgl_khac_thong_tin_chung_rtf; }
        set { _bds_tsgl_khac_thong_tin_chung_rtf = value; }
        } 

        private string _bds_tsgl_khac_thong_tin_chung;
        public string bds_tsgl_khac_thong_tin_chung

        { 
        get { return _bds_tsgl_khac_thong_tin_chung; }
        set { _bds_tsgl_khac_thong_tin_chung = value; }
        } 

        private Int64 _bds_tsgl_khac_gia_tri;
        public Int64 bds_tsgl_khac_gia_tri

        { 
        get { return _bds_tsgl_khac_gia_tri; }
        set { _bds_tsgl_khac_gia_tri = value; }
        } 

        private Int64 _bds_gia_tri;
        public Int64 bds_gia_tri

        { 
        get { return _bds_gia_tri; }
        set { _bds_gia_tri = value; }
        } 

        private string _tstc_khac_ten;
        public string tstc_khac_ten

        { 
        get { return _tstc_khac_ten; }
        set { _tstc_khac_ten = value; }
        } 

        private string _tstc_khac_thong_tin_chung_rtf;
        public string tstc_khac_thong_tin_chung_rtf

        { 
        get { return _tstc_khac_thong_tin_chung_rtf; }
        set { _tstc_khac_thong_tin_chung_rtf = value; }
        } 

        private string _tstc_khac_thong_tin_chung;
        public string tstc_khac_thong_tin_chung

        { 
        get { return _tstc_khac_thong_tin_chung; }
        set { _tstc_khac_thong_tin_chung = value; }
        } 

        private Int64 _tstc_khac_gia_tri;
        public Int64 tstc_khac_gia_tri

        { 
        get { return _tstc_khac_gia_tri; }
        set { _tstc_khac_gia_tri = value; }
        } 

        private bool _tstc_htttl;
        public bool tstc_htttl

        { 
        get { return _tstc_htttl; }
        set { _tstc_htttl = value; }
        }

        private string _tstc_khac_giay_to;
        public string tstc_khac_giay_to
        {
            get { return _tstc_khac_giay_to; }
            set { _tstc_khac_giay_to = value; }
        }

        private string _bds_ctxd_2;

        public string bds_ctxd_2
        {
            get { return _bds_ctxd_2; }
            set { _bds_ctxd_2 = value; }
        }

        private string _ma_chu_so_huu;

        public string ma_chu_so_huu
        {
            get { return _ma_chu_so_huu; }
            set { _ma_chu_so_huu = value; }
        }

        #endregion Instance Properties

        public Taisanthechap(string[] thong_tin_tstc)
        {
            this._ma_ts_the_chap = Convert.ToInt32(thong_tin_tstc[0]);
            this._ma_hd_vay = thong_tin_tstc[1];
            this._loai_chu_so_huu = thong_tin_tstc[2];
            this._loai_ts_the_chap = thong_tin_tstc[3];
            this._hinh_thuc_so_huu_cua_kh_vay = thong_tin_tstc[4];
            this._hgd_ten_chong = thong_tin_tstc[5];
            this._hgd_ns_chong = thong_tin_tstc[6];
            this._hgd_cmnd_chong = thong_tin_tstc[7];
            this._hgd_ngay_cap_cmnd_chong = thong_tin_tstc[8];
            this._hgd_noi_cap_cmnd_chong = thong_tin_tstc[9];
            this._hgd_dc_chong = thong_tin_tstc[10];
            this._hgd_hktt_chong = thong_tin_tstc[11];
            this._hgd_so_hk_chong = thong_tin_tstc[12];
            this._hgd_noi_cap_hk_chong = thong_tin_tstc[13];
            this._hgd_ngay_cap_hk_chong = thong_tin_tstc[14];
            this._hgd_ten_vo = thong_tin_tstc[15];
            this._hgd_ns_vo = thong_tin_tstc[16];
            this._hgd_cmnd_vo = thong_tin_tstc[17];
            this._hgd_ngay_cap_cmnd_vo = thong_tin_tstc[18];
            this._hgd_noi_cap_cmnd_vo = thong_tin_tstc[19];
            this._hgd_dc_vo = thong_tin_tstc[20];
            this._hgd_hktt_vo = thong_tin_tstc[21];
            this._hgd_so_hk_vo = thong_tin_tstc[22];
            this._hgd_noi_cap_hk_vo = thong_tin_tstc[23];
            this._hgd_ngay_cap_hk_vo = thong_tin_tstc[24];
            this._hgd_dkkd = thong_tin_tstc[25];
            this._hgd_dien_thoai = thong_tin_tstc[26];
            this._hgd_fax = thong_tin_tstc[27];
            this._hgd_email = thong_tin_tstc[28];
            this._hgd_dai_dien = thong_tin_tstc[29];
            this._hgd_nguoi_so_huu = thong_tin_tstc[30];
            this._cn_danh_xung = thong_tin_tstc[31];
            this._cn_ten = thong_tin_tstc[32];
            this._cn_ns = thong_tin_tstc[33];
            this._cn_cmnd = thong_tin_tstc[34];
            this._cn_ngay_cap_cmnd = thong_tin_tstc[35];
            this._cn_noi_cap_cmnd = thong_tin_tstc[36];
            this._cn_dc = thong_tin_tstc[37];
            this._cn_hktt = thong_tin_tstc[38];
            this._cn_so_hk = thong_tin_tstc[39];
            this._cn_noi_cap_hk = thong_tin_tstc[40];
            this._cn_ngay_cap_hk = thong_tin_tstc[41];
            this._cn_dkkd = thong_tin_tstc[42];
            this._cn_dien_thoai = thong_tin_tstc[43];
            this._cn_fax = thong_tin_tstc[44];
            this._cn_email = thong_tin_tstc[45];
            this._tc_ten = thong_tin_tstc[46];
            this._tc_dkkd = thong_tin_tstc[47];
            this._tc_dc = thong_tin_tstc[48];
            this._tc_danh_xung_dai_dien = thong_tin_tstc[49];
            this._tc_dai_dien = thong_tin_tstc[50];
            this._tc_ns_dai_dien = thong_tin_tstc[51];
            this._tc_chuc_vu_dai_dien = thong_tin_tstc[52];
            this._tc_giay_uy_quyen = thong_tin_tstc[53];
            this._tc_dc_dai_dien = thong_tin_tstc[54];
            this._tc_cmnd_dai_dien = thong_tin_tstc[55];
            this._tc_ngay_cap_cmnd_dai_dien = thong_tin_tstc[56];
            this._tc_noi_cap_cmnd_dai_dien = thong_tin_tstc[57];
            this._tc_hktt_dai_dien = thong_tin_tstc[58];
            this._tc_so_hk_dai_dien = thong_tin_tstc[59];
            this._tc_noi_cap_hk_dai_dien = thong_tin_tstc[60];
            this._tc_ngay_cap_hk_dai_dien = thong_tin_tstc[61];
            this._tc_dien_thoai = thong_tin_tstc[62];
            this._tc_fax = thong_tin_tstc[63];
            this._tc_email = thong_tin_tstc[64];
            this._ds_ten = thong_tin_tstc[65];
            this._ds_nhan_hieu = thong_tin_tstc[66];
            this._ds_thong_tin_chung_rtf = thong_tin_tstc[67];
            this._ds_thong_tin_chung = thong_tin_tstc[68];
            this._ds_giay_to = thong_tin_tstc[69];
            this._ds_gia_tri = Convert.ToInt64(thong_tin_tstc[70]);
            this._bds_ten = thong_tin_tstc[71];
            this._bds_tong_dien_tich = Convert.ToDecimal(thong_tin_tstc[72]);
            this._bds_gia_tri_qsd_dat = Convert.ToInt64(thong_tin_tstc[73]);
            this._bds_dien_tich_dat_o = Convert.ToDecimal(thong_tin_tstc[74]);
            this._bds_gia_tri_qsd_dat_o_tren_m2 = Convert.ToInt64(thong_tin_tstc[75]);
            this._bds_gia_tri_qsd_dat_o = Convert.ToInt64(thong_tin_tstc[76]);
            this._bds_dat_khac_1 = thong_tin_tstc[77];
            this._bds_dien_tich_dat_khac_1 = Convert.ToDecimal(thong_tin_tstc[78]);
            this._bds_gia_tri_qsd_dat_khac_1_tren_m2 = Convert.ToInt64(thong_tin_tstc[79]);
            this._bds_gia_tri_qsd_dat_khac_1 = Convert.ToInt64(thong_tin_tstc[80]);
            this._bds_dat_khac_2 = thong_tin_tstc[81];
            this._bds_dien_tich_dat_khac_2 = Convert.ToDecimal(thong_tin_tstc[82]);
            this._bds_gia_tri_qsd_dat_khac_2_tren_m2 = Convert.ToInt64(thong_tin_tstc[83]);
            this._bds_gia_tri_qsd_dat_khac_2 = Convert.ToInt64(thong_tin_tstc[84]);
            this._bds_dat_khac_3 = thong_tin_tstc[85];
            this._bds_dien_tich_dat_khac_3 = Convert.ToDecimal(thong_tin_tstc[86]);
            this._bds_gia_tri_qsd_dat_khac_3_tren_m2 = Convert.ToInt64(thong_tin_tstc[87]);
            this._bds_gia_tri_qsd_dat_khac_3 = Convert.ToInt64(thong_tin_tstc[88]);
            this._bds_dien_tich_su_dung_rieng = Convert.ToDecimal(thong_tin_tstc[89]);
            this._bds_dien_tich_su_dung_chung = Convert.ToDecimal(thong_tin_tstc[90]);
            this._bds_thong_tin_chung_rtf = thong_tin_tstc[91];
            this._bds_thong_tin_chung = thong_tin_tstc[92];
            this._bds_giay_to_rtf = thong_tin_tstc[93];
            this._bds_giay_to = thong_tin_tstc[94];
            this._bds_nha_thong_tin_chung_rtf = thong_tin_tstc[95];
            this._bds_nha_thong_tin_chung = thong_tin_tstc[96];
            this._bds_nha_gia_tri = Convert.ToInt64(thong_tin_tstc[97]);
            this._bds_ctxd_thong_tin_chung_rtf = thong_tin_tstc[98];
            this._bds_ctxd_thong_tin_chung = thong_tin_tstc[99];
            this._bds_ctxd_gia_tri = Convert.ToInt64(thong_tin_tstc[100]);
            this._bds_tsgl_khac_thong_tin_chung_rtf = thong_tin_tstc[101];
            this._bds_tsgl_khac_thong_tin_chung = thong_tin_tstc[102];
            this._bds_tsgl_khac_gia_tri = Convert.ToInt64(thong_tin_tstc[103]);
            this._bds_gia_tri = Convert.ToInt64(thong_tin_tstc[104]);
            this._tstc_khac_ten = thong_tin_tstc[105];
            this._tstc_khac_thong_tin_chung_rtf = thong_tin_tstc[106];
            this._tstc_khac_thong_tin_chung = thong_tin_tstc[107];
            this._tstc_khac_gia_tri = Convert.ToInt64(thong_tin_tstc[108]);
            this._tstc_htttl = Convert.ToBoolean(thong_tin_tstc[109]);
            this._tstc_khac_giay_to = thong_tin_tstc[110];
            this._bds_ctxd_2 = thong_tin_tstc[111];
            this._ma_chu_so_huu = thong_tin_tstc[112];
        }
        public Taisanthechap(DataRow row)
        {
            this._ma_ts_the_chap = Convert.ToInt32(row["MA_TS_THE_CHAP"].ToString());
            this._ma_hd_vay = row["MA_HD_VAY"].ToString();
            this._loai_chu_so_huu = row["LOAI_CHU_SO_HUU"].ToString();
            this._loai_ts_the_chap = row["LOAI_TS_THE_CHAP"].ToString();
            this._hinh_thuc_so_huu_cua_kh_vay = row["HINH_THUC_SO_HUU_CUA_KH_VAY"].ToString();
            this._hgd_ten_chong = row["HGD_TEN_CHONG"].ToString();
            this._hgd_ns_chong = row["HGD_NS_CHONG"].ToString();
            this._hgd_cmnd_chong = row["HGD_CMND_CHONG"].ToString();
            this._hgd_ngay_cap_cmnd_chong = row["HGD_NGAY_CAP_CMND_CHONG"].ToString();
            this._hgd_noi_cap_cmnd_chong = row["HGD_NOI_CAP_CMND_CHONG"].ToString();
            this._hgd_dc_chong = row["HGD_DC_CHONG"].ToString();
            this._hgd_hktt_chong = row["HGD_HKTT_CHONG"].ToString();
            this._hgd_so_hk_chong = row["HGD_SO_HK_CHONG"].ToString();
            this._hgd_noi_cap_hk_chong = row["HGD_NOI_CAP_HK_CHONG"].ToString();
            this._hgd_ngay_cap_hk_chong = row["HGD_NGAY_CAP_HK_CHONG"].ToString();
            this._hgd_ten_vo = row["HGD_TEN_VO"].ToString();
            this._hgd_ns_vo = row["HGD_NS_VO"].ToString();
            this._hgd_cmnd_vo = row["HGD_CMND_VO"].ToString();
            this._hgd_ngay_cap_cmnd_vo = row["HGD_NGAY_CAP_CMND_VO"].ToString();
            this._hgd_noi_cap_cmnd_vo = row["HGD_NOI_CAP_CMND_VO"].ToString();
            this._hgd_dc_vo = row["HGD_DC_VO"].ToString();
            this._hgd_hktt_vo = row["HGD_HKTT_VO"].ToString();
            this._hgd_so_hk_vo = row["HGD_SO_HK_VO"].ToString();
            this._hgd_noi_cap_hk_vo = row["HGD_NOI_CAP_HK_VO"].ToString();
            this._hgd_ngay_cap_hk_vo = row["HGD_NGAY_CAP_HK_VO"].ToString();
            this._hgd_dkkd = row["HGD_DKKD"].ToString();
            this._hgd_dien_thoai = row["HGD_DIEN_THOAI"].ToString();
            this._hgd_fax = row["HGD_FAX"].ToString();
            this._hgd_email = row["HGD_EMAIL"].ToString();
            this._hgd_dai_dien = row["HGD_DAI_DIEN"].ToString();
            this._hgd_nguoi_so_huu = row["HGD_NGUOI_SO_HUU"].ToString();
            this._cn_danh_xung = row["CN_DANH_XUNG"].ToString();
            this._cn_ten = row["CN_TEN"].ToString();
            this._cn_ns = row["CN_NS"].ToString();
            this._cn_cmnd = row["CN_CMND"].ToString();
            this._cn_ngay_cap_cmnd = row["CN_NGAY_CAP_CMND"].ToString();
            this._cn_noi_cap_cmnd = row["CN_NOI_CAP_CMND"].ToString();
            this._cn_dc = row["CN_DC"].ToString();
            this._cn_hktt = row["CN_HKTT"].ToString();
            this._cn_so_hk = row["CN_SO_HK"].ToString();
            this._cn_noi_cap_hk = row["CN_NOI_CAP_HK"].ToString();
            this._cn_ngay_cap_hk = row["CN_NGAY_CAP_HK"].ToString();
            this._cn_dkkd = row["CN_DKKD"].ToString();
            this._cn_dien_thoai = row["CN_DIEN_THOAI"].ToString();
            this._cn_fax = row["CN_FAX"].ToString();
            this._cn_email = row["CN_EMAIL"].ToString();
            this._tc_ten = row["TC_TEN"].ToString();
            this._tc_dkkd = row["TC_DKKD"].ToString();
            this._tc_dc = row["TC_DC"].ToString();
            this._tc_danh_xung_dai_dien = row["TC_DANH_XUNG_DAI_DIEN"].ToString();
            this._tc_dai_dien = row["TC_DAI_DIEN"].ToString();
            this._tc_ns_dai_dien = row["TC_NS_DAI_DIEN"].ToString();
            this._tc_chuc_vu_dai_dien = row["TC_CHUC_VU_DAI_DIEN"].ToString();
            this._tc_giay_uy_quyen = row["TC_GIAY_UY_QUYEN"].ToString();
            this._tc_dc_dai_dien = row["TC_DC_DAI_DIEN"].ToString();
            this._tc_cmnd_dai_dien = row["TC_CMND_DAI_DIEN"].ToString();
            this._tc_ngay_cap_cmnd_dai_dien = row["TC_NGAY_CAP_CMND_DAI_DIEN"].ToString();
            this._tc_noi_cap_cmnd_dai_dien = row["TC_NOI_CAP_CMND_DAI_DIEN"].ToString();
            this._tc_hktt_dai_dien = row["TC_HKTT_DAI_DIEN"].ToString();
            this._tc_so_hk_dai_dien = row["TC_SO_HK_DAI_DIEN"].ToString();
            this._tc_noi_cap_hk_dai_dien = row["TC_NOI_CAP_HK_DAI_DIEN"].ToString();
            this._tc_ngay_cap_hk_dai_dien = row["TC_NGAY_CAP_HK_DAI_DIEN"].ToString();
            this._tc_dien_thoai = row["TC_DIEN_THOAI"].ToString();
            this._tc_fax = row["TC_FAX"].ToString();
            this._tc_email = row["TC_EMAIL"].ToString();
            this._ds_ten = row["DS_TEN"].ToString();
            this._ds_nhan_hieu = row["DS_NHAN_HIEU"].ToString();
            this._ds_thong_tin_chung_rtf = row["DS_THONG_TIN_CHUNG_RTF"].ToString();
            this._ds_thong_tin_chung = row["DS_THONG_TIN_CHUNG"].ToString();
            this._ds_giay_to = row["DS_GIAY_TO"].ToString();
            this._ds_gia_tri = Convert.ToInt64(row["DS_GIA_TRI"].ToString());
            this._bds_ten = row["BDS_TEN"].ToString();
            this._bds_tong_dien_tich = Convert.ToDecimal(row["BDS_TONG_DIEN_TICH"].ToString());
            this._bds_gia_tri_qsd_dat = Convert.ToInt64(row["BDS_GIA_TRI_QSD_DAT"].ToString());
            this._bds_dien_tich_dat_o = Convert.ToDecimal(row["BDS_DIEN_TICH_DAT_O"].ToString());
            this._bds_gia_tri_qsd_dat_o_tren_m2 = Convert.ToInt64(row["BDS_GIA_TRI_QSD_DAT_O_TREN_M2"].ToString());
            this._bds_gia_tri_qsd_dat_o = Convert.ToInt64(row["BDS_GIA_TRI_QSD_DAT_O"].ToString());
            this._bds_dat_khac_1 = row["BDS_DAT_KHAC_1"].ToString();
            this._bds_dien_tich_dat_khac_1 = Convert.ToDecimal(row["BDS_DIEN_TICH_DAT_KHAC_1"].ToString());
            this._bds_gia_tri_qsd_dat_khac_1_tren_m2 = Convert.ToInt64(row["BDS_GIA_TRI_QSD_DAT_KHAC_1_TREN_M2"].ToString());
            this._bds_gia_tri_qsd_dat_khac_1 = Convert.ToInt64(row["BDS_GIA_TRI_QSD_DAT_KHAC_1"].ToString());
            this._bds_dat_khac_2 = row["BDS_DAT_KHAC_2"].ToString();
            this._bds_dien_tich_dat_khac_2 = Convert.ToDecimal(row["BDS_DIEN_TICH_DAT_KHAC_2"].ToString());
            this._bds_gia_tri_qsd_dat_khac_2_tren_m2 = Convert.ToInt64(row["BDS_GIA_TRI_QSD_DAT_KHAC_2_TREN_M2"].ToString());
            this._bds_gia_tri_qsd_dat_khac_2 = Convert.ToInt64(row["BDS_GIA_TRI_QSD_DAT_KHAC_2"].ToString());
            this._bds_dat_khac_3 = row["BDS_DAT_KHAC_3"].ToString();
            this._bds_dien_tich_dat_khac_3 = Convert.ToDecimal(row["BDS_DIEN_TICH_DAT_KHAC_3"].ToString());
            this._bds_gia_tri_qsd_dat_khac_3_tren_m2 = Convert.ToInt64(row["BDS_GIA_TRI_QSD_DAT_KHAC_3_TREN_M2"].ToString());
            this._bds_gia_tri_qsd_dat_khac_3 = Convert.ToInt64(row["BDS_GIA_TRI_QSD_DAT_KHAC_3"].ToString());
            this._bds_dien_tich_su_dung_rieng = Convert.ToDecimal(row["BDS_DIEN_TICH_SU_DUNG_RIENG"].ToString());
            this._bds_dien_tich_su_dung_chung = Convert.ToDecimal(row["BDS_DIEN_TICH_SU_DUNG_CHUNG"].ToString());
            this._bds_thong_tin_chung_rtf = row["BDS_THONG_TIN_CHUNG_RTF"].ToString();
            this._bds_thong_tin_chung = row["BDS_THONG_TIN_CHUNG"].ToString();
            this._bds_giay_to_rtf = row["BDS_GIAY_TO_RTF"].ToString();
            this._bds_giay_to = row["BDS_GIAY_TO"].ToString();
            this._bds_nha_thong_tin_chung_rtf = row["BDS_NHA_THONG_TIN_CHUNG_RTF"].ToString();
            this._bds_nha_thong_tin_chung = row["BDS_NHA_THONG_TIN_CHUNG"].ToString();
            this._bds_nha_gia_tri = Convert.ToInt64(row["BDS_NHA_GIA_TRI"].ToString());
            this._bds_ctxd_thong_tin_chung_rtf = row["BDS_CTXD_THONG_TIN_CHUNG_RTF"].ToString();
            this._bds_ctxd_thong_tin_chung = row["BDS_CTXD_THONG_TIN_CHUNG"].ToString();
            this._bds_ctxd_gia_tri = Convert.ToInt64(row["BDS_CTXD_GIA_TRI"].ToString());
            this._bds_tsgl_khac_thong_tin_chung_rtf = row["BDS_TSGL_KHAC_THONG_TIN_CHUNG_RTF"].ToString();
            this._bds_tsgl_khac_thong_tin_chung = row["BDS_TSGL_KHAC_THONG_TIN_CHUNG"].ToString();
            this._bds_tsgl_khac_gia_tri = Convert.ToInt64(row["BDS_TSGL_KHAC_GIA_TRI"].ToString());
            this._bds_gia_tri = Convert.ToInt64(row["BDS_GIA_TRI"].ToString());
            this._tstc_khac_ten = row["TSTC_KHAC_TEN"].ToString();
            this._tstc_khac_thong_tin_chung_rtf = row["TSTC_KHAC_THONG_TIN_CHUNG_RTF"].ToString();
            this._tstc_khac_thong_tin_chung = row["TSTC_KHAC_THONG_TIN_CHUNG"].ToString();
            this._tstc_khac_gia_tri = Convert.ToInt64(row["TSTC_KHAC_GIA_TRI"].ToString());
            this._tstc_htttl = Convert.ToBoolean(row["TSTC_HTTTL"].ToString());
            this._tstc_khac_giay_to = row["TSTC_KHAC_GIAY_TO"].ToString();
            this._bds_ctxd_2 = row["BDS_CTXD_2"].ToString();
            this._ma_chu_so_huu = row["MA_CHU_SO_HUU"].ToString();
        }
    }
}
