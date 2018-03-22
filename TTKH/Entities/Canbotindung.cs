using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Globalization;

namespace AGRIBANKHD.Entities
{
    class Canbotindung
    {
        private string _ma_cn;

        public string ma_cn
        {
            get { return _ma_cn; }
            set { _ma_cn = value; }
        }

        private string _ma_pgd;

        public string ma_pgd
        {
            get { return _ma_pgd; }
            set { _ma_pgd = value; }
        }

        private string _ten_dang_nhap;

        public string ten_dang_nhap
        {
            get { return _ten_dang_nhap; }
            set { _ten_dang_nhap = value; }
        }

        private string _ho_ten;

        public string ho_ten
        {
            get { return _ho_ten; }
            set { _ho_ten = value; }
        }

        private string _chuc_vu;

        public string chuc_vu
        {
            get { return _chuc_vu; }
            set { _chuc_vu = value; }
        }

        private string _giay_uy_quyen;

        public string giay_uy_quyen
        {
            get { return _giay_uy_quyen; }
            set { _giay_uy_quyen = value; }
        }

        private string _dien_thoai;

        public string dien_thoai
        {
            get { return _dien_thoai; }
            set { _dien_thoai = value; }
        }

        private string _fax;

        public string fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        private string _mat_khau;

        public string mat_khau
        {
            get { return _mat_khau; }
            set { _mat_khau = value; }
        }

        private bool _admin;

        public bool admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        private string _danh_xung;

        public string danh_xung
        {
            get { return _danh_xung; }
            set { _danh_xung = value; }
        }

        private string _ma_pb;

        public string ma_pb
        {
            get { return _ma_pb; }
            set { _ma_pb = value; }
        }

        private bool _kich_hoat;

        public bool kich_hoat
        {
            get { return _kich_hoat; }
            set { _kich_hoat = value; }
        }

         public Canbotindung(DataRow row)
        {
            //this._ma_cn = row["MA_CN"].ToString();
            this._ma_pgd = row["MA_PGD"].ToString();
            this._ten_dang_nhap = row["TEN_DANG_NHAP"].ToString();
            this._ho_ten = row["HO_TEN"].ToString();
            this._chuc_vu = row["CHUC_VU"].ToString();
            this._giay_uy_quyen = row["GIAY_UY_QUYEN"].ToString();
            this._dien_thoai = row["DIEN_THOAI"].ToString();
            this._fax = row["FAX"].ToString();
            this._mat_khau = row["MAT_KHAU"].ToString();
            this._admin = Convert.ToBoolean(row["ADMIN"].ToString());
            this._danh_xung = row["DANH_XUNG"].ToString();
            this._ma_pb = row["MA_PB"].ToString();
            this._kich_hoat = Convert.ToBoolean(row["KICH_HOAT"].ToString());
        }

         public Canbotindung(string[] thong_tin_cb)
         {
             this._ma_cn = thong_tin_cb[0];
             this._ma_pgd = thong_tin_cb[1];
             this._ten_dang_nhap = thong_tin_cb[2];
             this._ho_ten = thong_tin_cb[3];
             this._chuc_vu = thong_tin_cb[4];
             this._giay_uy_quyen = thong_tin_cb[5];
             this._dien_thoai = thong_tin_cb[6];
             this._fax = thong_tin_cb[7];
             this._mat_khau = thong_tin_cb[8];
             this._admin = Convert.ToBoolean(thong_tin_cb[9]);
             this._danh_xung = thong_tin_cb[10];
             this._ma_pb = thong_tin_cb[11];
             this._kich_hoat = Convert.ToBoolean(thong_tin_cb[12]);
         }
    }
}
