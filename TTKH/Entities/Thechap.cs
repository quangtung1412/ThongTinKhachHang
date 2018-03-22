using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Globalization;
namespace AGRIBANKHD.Entities
{
    class Thechap
    {
        private string _ten_chong;

        public string ten_chong
        {
            get { return _ten_chong; }
            set { _ten_chong = value; }
        }

        private DateTime _ns_chong;

        public DateTime ns_chong
        {
            get { return _ns_chong; }
            set { _ns_chong = value; }
        }

        private string _cmnd_chong;

        public string cmnd_chong
        {
            get { return _cmnd_chong; }
            set { _cmnd_chong = value; }
        }

        private DateTime _ngay_cap_cmnd_chong;

        public DateTime ngay_cap_cmnd_chong
        {
            get { return _ngay_cap_cmnd_chong; }
            set { _ngay_cap_cmnd_chong = value; }
        }

        private string _noi_cap_cmnd_chong;

        public string noi_cap_cmnd_chong
        {
            get { return _noi_cap_cmnd_chong; }
            set { _noi_cap_cmnd_chong = value; }
        }

        private string _dc_chong;

        public string dc_chong
        {
            get { return _dc_chong; }
            set { _dc_chong = value; }
        }

        private string _hktt_chong;

        public string hktt_chong
        {
            get { return _hktt_chong; }
            set { _hktt_chong = value; }
        }

        private string _so_hk_chong;

        public string so_hk_chong
        {
            get { return _so_hk_chong; }
            set { _so_hk_chong = value; }
        }

        private string _noi_cap_hk_chong;

        public string noi_cap_hk_chong
        {
            get { return _noi_cap_hk_chong; }
            set { _noi_cap_hk_chong = value; }
        }

        private DateTime _ngay_cap_hk_chong;

        public DateTime ngay_cap_hk_chong
        {
            get { return _ngay_cap_hk_chong; }
            set { _ngay_cap_hk_chong = value; }
        }

        private string _ten_vo;

        public string ten_vo
        {
            get { return _ten_vo; }
            set { _ten_vo = value; }
        }

        private DateTime _ns_vo;

        public DateTime ns_vo
        {
            get { return _ns_vo; }
            set { _ns_vo = value; }
        }

        private string _cmnd_vo;

        public string cmnd_vo
        {
            get { return _cmnd_vo; }
            set { _cmnd_vo = value; }
        }

        private DateTime _ngay_cap_cmnd_vo;

        public DateTime ngay_cap_cmnd_vo
        {
            get { return _ngay_cap_cmnd_vo; }
            set { _ngay_cap_cmnd_vo = value; }
        }

        private string _noi_cap_cmnd_vo;

        public string noi_cap_cmnd_vo
        {
            get { return _noi_cap_cmnd_vo; }
            set { _noi_cap_cmnd_vo = value; }
        }

        private string _dc_vo;

        public string dc_vo
        {
            get { return _dc_vo; }
            set { _dc_vo = value; }
        }

        private string _hktt_vo;

        public string hktt_vo
        {
            get { return _hktt_vo; }
            set { _hktt_vo = value; }
        }

        private string _so_hk_vo;

        public string so_hk_vo
        {
            get { return _so_hk_vo; }
            set { _so_hk_vo = value; }
        }

        private string _noi_cap_hk_vo;

        public string noi_cap_hk_vo
        {
            get { return _noi_cap_hk_vo; }
            set { _noi_cap_hk_vo = value; }
        }

        private DateTime _ngay_cap_hk_vo;

        public DateTime ngay_cap_hk_vo
        {
            get { return _ngay_cap_hk_vo; }
            set { _ngay_cap_hk_vo = value; }
        }

        private string _tstc;

        public string tstc
        {
            get { return _tstc; }
            set { _tstc = value; }
        }

        private string _loai_ts;

        public string loai_ts
        {
            get { return _loai_ts; }
            set { _loai_ts = value; }
        }

        private string _dia_chi;

        public string dia_chi
        {
            get { return _dia_chi; }
            set { _dia_chi = value; }
        }

        private Decimal _dien_tich;

        public Decimal dien_tich
        {
            get { return _dien_tich; }
            set { _dien_tich = value; }
        }

        private string _vi_tri;

        public string vi_tri
        {
            get { return _vi_tri; }
            set { _vi_tri = value; }
        }

        private string _muc_dich;

        public string muc_dich
        {
            get { return _muc_dich; }
            set { _muc_dich = value; }
        }

        private string _hinh_thuc;

        public string hinh_thuc
        {
            get { return _hinh_thuc; }
            set { _hinh_thuc = value; }
        }

        private string _thoi_han;

        public string thoi_han
        {
            get { return _thoi_han; }
            set { _thoi_han = value; }
        }

        private string _nguon_goc;

        public string nguon_goc
        {
            get { return _nguon_goc; }
            set { _nguon_goc = value; }
        }

        private Int64 _gia_tri;

        public Int64 gia_tri
        {
            get { return _gia_tri; }
            set { _gia_tri = value; }
        }

        private string _ts_gan_lien;

        public string ts_gan_lien
        {
            get { return _ts_gan_lien; }
            set { _ts_gan_lien = value; }
        }

        private string _giay_to;

        public string giay_to
        {
            get { return _giay_to; }
            set { _giay_to = value; }
        }

         public Thechap(DataRow row)
        {
            this._ten_chong = row["TEN_CHONG"].ToString();
            this._ns_chong = DateTime.ParseExact(row["NS_CHONG"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this._cmnd_chong = row["CMND_CHONG"].ToString();
            this._ngay_cap_cmnd_chong = DateTime.ParseExact(row["NGAY_CAP_CMND_CHONG"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this._noi_cap_cmnd_chong = row["NOI_CAP_CMND_CHONG"].ToString();
            this._dc_chong = row["DC_CHONG"].ToString();
            this._hktt_chong = row["HKTT_CHONG"].ToString();
            this._so_hk_chong = row["SO_HK_CHONG"].ToString();
            this._noi_cap_hk_chong = row["NOI_CAP_HK_CHONG"].ToString();
            this._ngay_cap_hk_chong = DateTime.ParseExact(row["NGAY_CAP_HK_CHONG"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this._ten_vo = row["TEN_VO"].ToString();
            this._ns_vo = DateTime.ParseExact(row["NS_VO"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this._cmnd_vo = row["CMND_VO"].ToString();
            this._ngay_cap_cmnd_vo = DateTime.ParseExact(row["NGAY_CAP_CMND_VO"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this._noi_cap_cmnd_vo = row["NOI_CAP_CMND_VO"].ToString();
            this._dc_vo = row["DC_VO"].ToString();
            this._hktt_vo = row["HKTT_VO"].ToString();
            this._so_hk_vo = row["SO_HK_VO"].ToString();
            this._noi_cap_hk_vo = row["NOI_CAP_HK_VO"].ToString();
            this._ngay_cap_hk_vo = DateTime.ParseExact(row["NGAY_CAP_HK_VO"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this._tstc = row["TSTC"].ToString();
            this._loai_ts = row["LOAI_TS"].ToString();
            this._dia_chi = row["DIA_CHI"].ToString();
            this._dien_tich = (decimal)row["DIEN_TICH"];
            this._vi_tri = row["VI_TRI"].ToString();
            this._muc_dich = row["MUC_DICH"].ToString();
            this._hinh_thuc = row["HINH_THUC"].ToString();
            this._thoi_han = row["THOI_HAN"].ToString();
            this._nguon_goc = row["NGUON_GOC"].ToString();
            this._gia_tri = (Int64)row["GIA_TRI"];
            this._ts_gan_lien = row["TS_GAN_LIEN"].ToString();
            this._giay_to = row["GIAY_TO"].ToString();
        }
    }
}
