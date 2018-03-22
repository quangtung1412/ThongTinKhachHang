using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGRIBANKHD.BUS;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;
using AGRIBANKHD.Utilities;
using AGRIBANKHD.Properties;

namespace AGRIBANKHD.GUI
{
    public partial class frmKhai_bao_diem_giao_dich : Form
    {

        public frmKhai_bao_diem_giao_dich()
        {
            InitializeComponent();
            //List<Chinhanh> dschinhanh = new List<Chinhanh>();
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            //this.AcceptButton = btnTim_kiem;            
        }

        private void cboxChi_nhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
        }

        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
