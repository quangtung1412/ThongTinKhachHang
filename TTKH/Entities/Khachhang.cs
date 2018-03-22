using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Globalization;

namespace AGRIBANKHD.Entities
{
    class Khachhang
    {
        private string _ma_KH;

        public string ma_KH
        {
            get { return _ma_KH; }
            set { _ma_KH = value; }
        }

        private string _ho_ten;

        public string ho_ten
        {
            get { return _ho_ten; }
            set { _ho_ten = value; }
        }

        private string _cmt;

        public string cmt
        {
            get { return _cmt; }
            set { _cmt = value; }
        } 

        private DateTime _ngay_cap;

        public DateTime ngay_cap
        {
            get { return _ngay_cap; }
            set { _ngay_cap = value; }
        }

        private string _noi_cap;

        public string noi_cap
        {
            get { return _noi_cap; }
            set { _noi_cap = value; }
        }

        private string _quoc_tich;

        public string quoc_tich
        {
            get { return _quoc_tich; }
            set { _quoc_tich = value; }
        }

        private string _co_dinh;

        public string co_dinh
        {
            get { return _co_dinh; }
            set { _co_dinh = value; }
        }

        private string _di_dong;

        public string di_dong
        {
            get { return _di_dong; }
            set { _di_dong = value; }
        }

        private string _dia_chi;

        public string dia_chi
        {
            get { return _dia_chi; }
            set { _dia_chi = value; }
        }

        public Khachhang()
        {

        }

        public Khachhang(string ma_KH, string ho_ten, string cmt, DateTime ngay_cap, string noi_cap, string quoc_tich, string co_dinh, string di_dong, string dia_chi)
        {
            this._ma_KH = ma_KH;
            this._ho_ten = ho_ten;
            this._cmt = cmt;
            this._ngay_cap = ngay_cap;
            this._noi_cap=noi_cap;
            this._quoc_tich=quoc_tich;
            this._co_dinh=co_dinh;
            this._di_dong=di_dong;
            this._dia_chi=dia_chi;
        }

        public Khachhang(DataRow row)
        {
            this._ma_KH = row["ma_KH"].ToString();
            this._ho_ten = row["ho_ten"].ToString();
            this._cmt = row["cmt"].ToString();
            this._ngay_cap = DateTime.ParseExact(row["ngay_cap"].ToString(),"dd/MM/yyyy", CultureInfo.InvariantCulture);
            //this._ngay_cap = row["ngay_cap"].ToString();
            this._noi_cap = row["noi_cap"].ToString();
            this._quoc_tich = row["quoc_tich"].ToString();
            this._co_dinh = row["co_dinh"].ToString();
            this._di_dong = row["di_dong"].ToString();
            this._dia_chi = row["dia_chi"].ToString();
        }

    }
}
