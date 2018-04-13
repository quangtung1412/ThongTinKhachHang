using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AGRIBANKHD.Entities
{
    class The
    {
        private string _soThe;
        private string _hoTen;
        private string _soTK;
        private string _loaiThe;
        private string _hangThe;
        private string _hinhThucPhatHanh;
        private string _hinhThucNhanThe;
        private string _dtdd;
        private int _hmgd;
        private bool _baoHiem;
        private DateTime _ngayDK;
        private DateTime _ngayNhan;
        private DateTime _ngayGiao;

        public The(DataRow row)
        {
            _soThe = row["SOTHE"].ToString();
            _hoTen = row["HOTEN"].ToString();
            _soTK = row["SOTK"].ToString();
            _loaiThe = row["LOAITHE"].ToString();
            _hangThe = row["HANGTHE"].ToString();
            _hinhThucPhatHanh = row["HINHTHUCPHATHANH"].ToString();
            _hinhThucNhanThe = row["HINHTHUCNHANTHE"].ToString();
            _dtdd = row["DTDDSMS"].ToString();
            _hmgd = (int)row["HMGD"];
            _baoHiem = (bool)row["BAOHIEM"];
            if (!string.IsNullOrEmpty(row["NGAYDANGKY"].ToString()))
                _ngayDK = (DateTime)row["NGAYDANGKY"];
            if (!string.IsNullOrEmpty(row["NGAYNHANTHE"].ToString()))
                _ngayNhan = (DateTime)row["NGAYNHANTHE"];
            if (!string.IsNullOrEmpty(row["NGAYGIAOTHE"].ToString()))
                _ngayGiao = (DateTime)row["NGAYGIAOTHE"];
        }

        public string soThe
        {
            get { return _soThe; }
            set { _soThe = value; }
        }

        public string hoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        public string soTK
        {
            get { return _soTK; }
            set { _soTK = value; }
        }

        public string loaiThe
        {
            get { return _loaiThe; }
            set { _loaiThe = value; }
        }

        public string hangThe
        {
            get { return _hangThe; }
            set { _hangThe = value; }
        }

        public string hinhThucPhatHanh
        {
            get { return _hinhThucPhatHanh; }
            set { _hinhThucPhatHanh = value; }
        }

        public string hinhThucNhanThe
        {
            get { return _hinhThucNhanThe; }
            set { _hinhThucNhanThe = value; }
        }

        public string dtdd
        {
            get { return _dtdd; }
            set { _dtdd = value; }
        }

        public int hmgd
        {
            get { return _hmgd; }
            set { _hmgd = value; }
        }

        public bool baoHiem
        {
            get { return _baoHiem; }
            set { _baoHiem = value; }
        }

        public DateTime ngayDK
        {
            get { return _ngayDK; }
            set { _ngayDK = value; }
        }

        public DateTime ngayNhan
        {
            get { return _ngayNhan; }
            set { _ngayNhan = value; }
        }

        public DateTime ngayGiao
        {
            get { return _ngayGiao; }
            set { _ngayGiao = value; }
        }
    }
}
