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
    class GiaynhannoBUS
    {
        giaynhannoDAL dal = new giaynhannoDAL();

        public bool THEM_GIAY_NHAN_NO(Giaynhanno gnn)
        {
            return dal.THEM_GIAY_NHAN_NO(gnn);
        }

        public bool CAP_NHAT_GIAY_NHAN_NO(Giaynhanno gnn)
        {
            return dal.CAP_NHAT_GIAY_NHAN_NO(gnn);
        }

        public bool XOA_GIAY_NHAN_NO(Int32 id_giay_nhan_no)
        {
            return dal.XOA_GIAY_NHAN_NO(id_giay_nhan_no);
        }

        public static DataTable DS_GIAY_NHAN_NO_THEO_MA_HD_VAY(string ma_hd_vay)
        {
            return giaynhannoDAL.DS_GIAY_NHAN_NO_THEO_MA_HD_VAY(ma_hd_vay);
        }

        public static Giaynhanno GIAY_NHAN_NO_THEO_ID(Int32 id_giay_nhan_no)
        {
            return giaynhannoDAL.GIAY_NHAN_NO_THEO_ID(id_giay_nhan_no);
        }
    }
}
