using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AGRIBANKHD.GUI
{
    public partial class frmPhatHanhTheGhiNo : Form
    {
        public frmPhatHanhTheGhiNo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmPhatHanhTheGhiNo_Load(object sender, EventArgs e)
        {

        }

        private void gbThongTinKH_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbNgayCap_Click(object sender, EventArgs e)
        {

        }

        private void lbSoDienThoai_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Entities.Khachhang kh = null;
            try {
                kh = DAL.PhatHanhTheGhiNoDAL.TimKiemKH(txbSoCMT.Text);
                if (kh == null) { 
                    
                }
            }
            catch{
                DAL.ErrorMessageDAL.DataAccessError();
            }
        }


        void KhongTimThayKH() { 
            
        }

        void SetTextBoxStatus_TTKH(bool status) { 
            
        }
    }
}
