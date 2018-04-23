using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;
using AGRIBANKHD.Utilities;
namespace AGRIBANKHD.GUI
{
    public partial class frmKiemQuy : Form
    {
        List<User> users, usersKiemQuy;

        public frmKiemQuy()
        {
            InitializeComponent();
            LayTTCanBo();
            
        }

        void LayTTCanBo()
        {
            users = new List<User>();
            usersKiemQuy = new List<User>();

            try
            {
                DataTable dt = KiemQuyDAL.DV_DSNhanVien_MaCN(Thong_tin_dang_nhap.ma_cn);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new User(dt.Rows[i]);
                    users.Add(u);
                    cbCanBo.Items.Add(u.tennv);
                }
            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbCanBo.SelectedIndex < 0) return;
            foreach (var c in usersKiemQuy)
                if (c == users[cbCanBo.SelectedIndex]) return;
            usersKiemQuy.Add(users[cbCanBo.SelectedIndex]);
            txtCanBoKiemQuy.Text += users[cbCanBo.SelectedIndex].tennv + "; ";
        }


        private void txtFIMI50_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThuc50_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFIMI100_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThuc100_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFIMI200_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThuc200_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFIMI500_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThuc500_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
