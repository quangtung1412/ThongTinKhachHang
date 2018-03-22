using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;

namespace AGRIBANKHD.BUS
{
    class TaisanthechapBUS
    {
        taisanthechapDAL dal = new taisanthechapDAL();

        public static DataTable DS_TSTC(string ma_hd_vay)
        {
            return taisanthechapDAL.DS_TSTC(ma_hd_vay);
        }

        public static Taisanthechap TSTC_THEO_MA_TSTC(int ma_ts_the_chap)
        {
            return taisanthechapDAL.TSTC_THEO_MA_TSTC(ma_ts_the_chap);
        }

        public bool THEM_TSTC(Taisanthechap tstc)
        {
            return dal.THEM_TSTC(tstc);
        }

        public bool CAP_NHAT_TSTC(Taisanthechap tstc)
        {
            return dal.CAP_NHAT_TSTC(tstc);
        }

        public bool XOA_TSTC(int ma_ts_the_chap)
        {
            return dal.XOA_TSTC(ma_ts_the_chap);
        }

        public bool XOA_TSTC_THEO_MA_HD_VAY(string ma_hd_vay)
        {
            return dal.XOA_TSTC_THEO_MA_HD_VAY(ma_hd_vay);
        }
    }
}
