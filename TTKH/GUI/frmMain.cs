using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGRIBANKHD.GUI
{
    public partial class frmMain : Form
    {
        
        public frmMain(bool admin, string chuc_vu)
        {
            if (admin || chuc_vu == "Trưởng phòng Kế hoạch & Kinh doanh" || chuc_vu == "Trưởng phòng Khách hàng Doanh nghiệp" || chuc_vu == "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân")
            {
                InitializeComponent();
            }
            else
            {
                InitializeComponent();
                quaToolStripMenuItem.Visible = false;
            }

            if (admin)
            {
                testToolStripMenuItem.Visible = true;
            }
            else
            {
                testToolStripMenuItem.Visible = false;
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void longToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTai_san_the_chap frm = new frmTai_san_the_chap();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        //private void lamToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmThong_tin_can_bo frm = new frmThong_tin_can_bo();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        private void tuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThong_tin_kh_vay frm=new frmThong_tin_kh_vay();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void hợpĐồngVayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThong_tin_hop_dong_vay frm = new frmThong_tin_hop_dong_vay();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void taToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTao_ho_so_vay frm = new frmTao_ho_so_vay();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDang_nhap frm = new frmDang_nhap();
            frm.Show();
        }

        private void quaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThong_tin_can_bo frm = new frmThong_tin_can_bo();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoi_mat_khau frm = new frmDoi_mat_khau();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTest frm = new frmTest();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void giấyNhậnNợĐềXuấtGiảiNgânKhaiBáoThôngInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGNN_DXGN_KBTT frm = new frmGNN_DXGN_KBTT();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }
    }
}
