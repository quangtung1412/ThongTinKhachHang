using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Globalization;
namespace AGRIBANKHD.Entities
{
    class RtbContent
    {
        private Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _bds_thong_tin_chung;
        public string bds_thong_tin_chung
        {
            get { return _bds_thong_tin_chung; }
            set { _bds_thong_tin_chung = value; }
        }

        private string _bds_giay_to;
        public string bds_giay_to
        {
            get { return _bds_giay_to; }
            set { _bds_giay_to = value; }
        }

        private string _bds_nha_thong_tin_chung;
        public string bds_nha_thong_tin_chung
        {
            get { return _bds_nha_thong_tin_chung; }
            set { _bds_nha_thong_tin_chung = value; }
        }

        private string _bds_ctxd_thong_tin_chung;
        public string bds_ctxd_thong_tin_chung
        {
            get { return _bds_ctxd_thong_tin_chung; }
            set { _bds_ctxd_thong_tin_chung = value; }
        }

        private string _bds_tsgl_khac_thong_tin_chung;
        public string bds_tsgl_khac_thong_tin_chung
        {
            get { return _bds_tsgl_khac_thong_tin_chung; }
            set { _bds_tsgl_khac_thong_tin_chung = value; }
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

        private string _tstc_khac_thong_tin_chung;
        public string tstc_khac_thong_tin_chung
        {
            get { return _tstc_khac_thong_tin_chung; }
            set { _tstc_khac_thong_tin_chung = value; }
        }

        private string _tstc_khac_giay_to;
        public string tstc_khac_giay_to
        {
            get { return _tstc_khac_giay_to; }
            set { _tstc_khac_giay_to = value; }
        }

        public RtbContent(DataRow row)
        {
            this._id = Convert.ToInt32(row["ID"].ToString());
            this._bds_thong_tin_chung = row["BDS_THONG_TIN_CHUNG"].ToString();
            this._bds_giay_to = row["BDS_GIAY_TO"].ToString();
            this._bds_nha_thong_tin_chung = row["BDS_NHA_THONG_TIN_CHUNG"].ToString();
            this._bds_ctxd_thong_tin_chung = row["BDS_CTXD_THONG_TIN_CHUNG"].ToString();
            this._bds_tsgl_khac_thong_tin_chung = row["BDS_TSGL_KHAC_THONG_TIN_CHUNG"].ToString();
            this._ds_thong_tin_chung = row["DS_THONG_TIN_CHUNG"].ToString();
            this._ds_giay_to = row["DS_GIAY_TO"].ToString();
            this._tstc_khac_thong_tin_chung = row["TSTC_KHAC_THONG_TIN_CHUNG"].ToString();
            this._tstc_khac_giay_to = row["TSTC_KHAC_GIAY_TO"].ToString();
        }

        public RtbContent(string[] thong_tin_rtb)
        {
            this._id = Convert.ToInt32(thong_tin_rtb[0]);            this._bds_thong_tin_chung = thong_tin_rtb[1];            this._bds_giay_to = thong_tin_rtb[2];            this._bds_nha_thong_tin_chung = thong_tin_rtb[3];            this._bds_ctxd_thong_tin_chung = thong_tin_rtb[4];            this._bds_tsgl_khac_thong_tin_chung = thong_tin_rtb[5];            this._ds_thong_tin_chung = thong_tin_rtb[6];            this._ds_giay_to = thong_tin_rtb[7];            this._tstc_khac_thong_tin_chung = thong_tin_rtb[8];
            this._tstc_khac_giay_to = thong_tin_rtb[9];
        }
    }
}
