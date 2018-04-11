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
        private DateTime _ngayDK;
        private DateTime _ngayNhan;
        private DateTime _ngayGiao;

        public The(DataRow row)
        {
            _soThe = row["SOTHE"].ToString();
            _hoTen = row["HOTEN"].ToString();
            _soTK = row["SOTK"].ToString();
            _loaiThe = row["LOAITHE"].ToString();
            _ngayDK = (DateTime)row["NGAYDANGKY"];
            _ngayNhan = (DateTime)row["NGAYNHANTHE"];
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
