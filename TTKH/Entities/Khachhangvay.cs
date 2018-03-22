using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Globalization;


namespace AGRIBANKHD.Entities
{
    class Khachhangvay
    {
        private string _ma_kh_vay;

        public string ma_kh_vay
        {
            get { return _ma_kh_vay; }
            set { _ma_kh_vay = value; }
        }

        private string _loai_kh;

        public string loai_kh
        {
            get { return _loai_kh; }
            set { _loai_kh = value; }
        }

        private string _ma_cn;

        public string ma_cn
        {
            get { return _ma_cn; }
            set { _ma_cn = value; }
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

        private string _hgd_ten_viet_tat;

        public string hgd_ten_viet_tat
        {
            get { return _hgd_ten_viet_tat; }
            set { _hgd_ten_viet_tat = value; }
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

        private string _cn_ten_viet_tat;

        public string cn_ten_viet_tat
        {
            get { return _cn_ten_viet_tat; }
            set { _cn_ten_viet_tat = value; }
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

        private string _tc_ten_viet_tat;

        public string tc_ten_viet_tat
        {
            get { return _tc_ten_viet_tat; }
            set { _tc_ten_viet_tat = value; }
        }

        public Khachhangvay(string[] thong_tin_kh)
        {
            //Hộ gia đình
            this._ma_kh_vay = thong_tin_kh[0];
            this._loai_kh = thong_tin_kh[1];
            this._ma_cn = thong_tin_kh[2];
            this._hgd_ten_chong = thong_tin_kh[3];
            this._hgd_ns_chong = thong_tin_kh[4];
            this._hgd_cmnd_chong = thong_tin_kh[5];
            this._hgd_ngay_cap_cmnd_chong = thong_tin_kh[6];
            this._hgd_noi_cap_cmnd_chong = thong_tin_kh[7];
            this._hgd_dc_chong = thong_tin_kh[8];
            this._hgd_hktt_chong = thong_tin_kh[9];
            this._hgd_so_hk_chong = thong_tin_kh[10];
            this._hgd_noi_cap_hk_chong = thong_tin_kh[11];
            this._hgd_ngay_cap_hk_chong = thong_tin_kh[12];
            this._hgd_ten_vo = thong_tin_kh[13];
            this._hgd_ns_vo = thong_tin_kh[14];
            this._hgd_cmnd_vo = thong_tin_kh[15];
            this._hgd_ngay_cap_cmnd_vo = thong_tin_kh[16];
            this._hgd_noi_cap_cmnd_vo = thong_tin_kh[17];
            this._hgd_dc_vo = thong_tin_kh[18];
            this._hgd_hktt_vo = thong_tin_kh[19];
            this._hgd_so_hk_vo = thong_tin_kh[20];
            this._hgd_noi_cap_hk_vo = thong_tin_kh[21];
            this._hgd_ngay_cap_hk_vo = thong_tin_kh[22];
            this._hgd_dkkd = thong_tin_kh[23];
            this._hgd_dien_thoai = thong_tin_kh[24];
            this._hgd_fax = thong_tin_kh[25];
            this._hgd_email = thong_tin_kh[26];
            //Cá nhân
            this._cn_danh_xung = thong_tin_kh[27];
            this._cn_ten = thong_tin_kh[28];
            this._cn_ns = thong_tin_kh[29];
            this._cn_cmnd = thong_tin_kh[30];
            this._cn_ngay_cap_cmnd = thong_tin_kh[31];
            this._cn_noi_cap_cmnd = thong_tin_kh[32];
            this._cn_dc = thong_tin_kh[33];
            this._cn_hktt = thong_tin_kh[34];
            this._cn_so_hk = thong_tin_kh[35];
            this._cn_noi_cap_hk = thong_tin_kh[36];
            this._cn_ngay_cap_hk = thong_tin_kh[37];
            this._cn_dkkd = thong_tin_kh[38];
            this._cn_dien_thoai = thong_tin_kh[39];
            this._cn_fax = thong_tin_kh[40];
            this._cn_email = thong_tin_kh[41];
            //Tổ chức
            this._tc_ten = thong_tin_kh[42];
            this._tc_dkkd = thong_tin_kh[43];
            this._tc_dc = thong_tin_kh[44];
            this._tc_danh_xung_dai_dien = thong_tin_kh[45];
            this._tc_dai_dien = thong_tin_kh[46];
            this._tc_ns_dai_dien = thong_tin_kh[47];
            this._tc_chuc_vu_dai_dien = thong_tin_kh[48];
            this._tc_giay_uy_quyen = thong_tin_kh[49];
            this._tc_dc_dai_dien = thong_tin_kh[50];
            this._tc_cmnd_dai_dien = thong_tin_kh[51];
            this._tc_ngay_cap_cmnd_dai_dien = thong_tin_kh[52];
            this._tc_noi_cap_cmnd_dai_dien = thong_tin_kh[53];
            this._tc_hktt_dai_dien = thong_tin_kh[54];
            this._tc_so_hk_dai_dien = thong_tin_kh[55];
            this._tc_noi_cap_hk_dai_dien = thong_tin_kh[56];
            this._tc_ngay_cap_hk_dai_dien = thong_tin_kh[57];
            this._tc_dien_thoai = thong_tin_kh[58];
            this._tc_fax = thong_tin_kh[59];
            this._tc_email = thong_tin_kh[60];
            //Thông tin bổ sung
            this._hgd_dai_dien = thong_tin_kh[61];
            this._hgd_ten_viet_tat = thong_tin_kh[62];
            this._cn_ten_viet_tat = thong_tin_kh[63];
            this._tc_ten_viet_tat = thong_tin_kh[64];
        }
        
        public Khachhangvay(DataRow row)
        {
            // Hộ gia đình
            this._ma_kh_vay = row["MA_KH_VAY"].ToString();
            this._loai_kh = row["LOAI_KH"].ToString();
            this._ma_cn = row["MA_CN"].ToString();
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
            //Cá nhân
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
            //Tổ chức
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
            //Thông tin bổ sung
            this._hgd_dai_dien = row["HGD_DAI_DIEN"].ToString();
            this._hgd_ten_viet_tat = row["HGD_TEN_VIET_TAT"].ToString();
            this._cn_ten_viet_tat = row["CN_TEN_VIET_TAT"].ToString();
            this._tc_ten_viet_tat = row["TC_TEN_VIET_TAT"].ToString();
        }
    }
}
