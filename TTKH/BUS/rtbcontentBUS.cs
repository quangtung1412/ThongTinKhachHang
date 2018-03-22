using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;
using System.Data;

namespace AGRIBANKHD.BUS
{
    class rtbcontentBUS       
    {
        rtbcontentDAL dal = new rtbcontentDAL();
        public static DataTable tbl_RTB_CONTENT()
        {
            return rtbcontentDAL.tbl_RTB_CONTENT();
        }

        public bool Them_RTB_CONTENT(RtbContent rtb)
        {
            return dal.Them_RTB_CONTENT(rtb);
        }
    }
}
