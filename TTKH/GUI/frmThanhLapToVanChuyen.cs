using AGRIBANKHD.DAL;
using AGRIBANKHD.Entities;
using AGRIBANKHD.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AGRIBANKHD.GUI
{
    public partial class frmThanhLapToVanChuyen : Form
    {
        static string fileNameTLTVC = "QD_THANH_LAP_TO_VAN_CHUYEN_DAC_BIET";
        List<String> listDich, listNguon;
        List<User> users;
        public frmThanhLapToVanChuyen()
        {
            InitializeComponent();
            listDich = new List<string>();
            listNguon = new List<string>();
            users = new List<User>();
            try
            {
                DataTable dt = KiemQuyDAL.DV_DSNhanVien_MaCN(Thong_tin_dang_nhap.ma_cn);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    users.Add(new User(dt.Rows[i]));
                    cbToTruong.Items.Add(users[i].tennv);
                    cbGiamSat1.Items.Add(users[i].tennv);
                    cbGiamSat2.Items.Add(users[i].tennv);
                }
            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
        }

        void KhoiTaoTLTVC()
        {
            listNguon.Clear();
            listDich.Clear();

            listDich.Add("<CHI_NHANH>");
            listNguon.Add(Thong_tin_dang_nhap.ten_cn);
            listDich.Add("<SO>");
            listNguon.Add(txtSo.Text);
            listDich.Add("<NGAY>");
            listNguon.Add(DateTime.Now.Day.ToString());
            listDich.Add("<THANG>");
            listNguon.Add(DateTime.Now.Month.ToString());
            listDich.Add("<NAM>");
            listNguon.Add(DateTime.Now.Year.ToString());
            listDich.Add("<TO_VAN_CHUYEN>");
            //To van chuyen
            string toVanChuyen = "";
            int index = 0;
            if (cbToTruong.SelectedItem != null)
            {
                index++;
                var u = users[cbToTruong.SelectedIndex];
                string gt = "Ông";
                if(!u.gioiTinh) gt = "Bà";
                toVanChuyen += index+". "+ gt + ": " + u.tennv + ", Số hộ chiếu/CMND/CCCD: " + txtCMNDToTruong.Text + " Ngày cấp: " + txtNgayCapToTruong.Text +
                    " Nơi cấp: " + txtNoiCapToTruong.Text + "; Chức vụ: " + u.chucvu + " " + Thong_tin_dang_nhap.ten_cn + "; Chức danh: Tổ trưởng;\n";
            }
            if (cbGiamSat1.SelectedItem != null)
            {
                index++;
                var u = users[cbGiamSat1.SelectedIndex];
                string gt = "Ông";
                if (!u.gioiTinh) gt = "Bà";
                toVanChuyen += index + ". " + gt + ": " + u.tennv + ", Số hộ chiếu/CMND/CCCD: " + txtCMNDGiamSat1.Text + " Ngày cấp: " + txtNgayCapGiamSat1.Text +
                    " Nơi cấp: " + txtNoiCapGiamSat1.Text + "; Chức vụ: " + u.chucvu + " " + Thong_tin_dang_nhap.ten_cn + "; Chức danh: Giám sát;\n";
            }
            if (cbGiamSat2.SelectedItem != null)
            {
                index++;
                var u = users[cbGiamSat2.SelectedIndex];
                string gt = "Ông";
                if (!u.gioiTinh) gt = "Bà";
                toVanChuyen += index + ". " + gt + ": " + u.tennv + ", Số hộ chiếu/CMND/CCCD: " + txtCMNDGiamSat2.Text + " Ngày cấp: " + txtNgayCapGiamSat2.Text +
                    " Nơi cấp: " + txtNoiCapGiamSat2.Text + "; Chức vụ: " + u.chucvu + " " + Thong_tin_dang_nhap.ten_cn + "; Chức danh: Giám sát;\n";
            }
            //Lai xe
            index++;
            toVanChuyen += index + ". " + "Ông/Bà: " + txtHoTenLaiXe.Text + ", Số hộ chiếu/CMND/CCCD: " + txtCMNDLaiXe.Text +
                " Ngày cấp: " + txtNgayCapLaiXe.Text + ",Nơi cấp: " + txtNoiCapLaiXe.Text + ";Chức danh: Lái xe;\n";
            //Bao ve
            index++;
            toVanChuyen += index + ". " + "Ông/Bà: " + txtHoTenLaiXe.Text + ", Số hộ chiếu/CMND/CCCD: " + txtCMNDLaiXe.Text +
                " Ngày cấp: " + txtNgayCapLaiXe.Text + ",Nơi cấp: " + txtNoiCapLaiXe.Text + ";Chức danh: Lái xe;";

            listNguon.Add(toVanChuyen);

            listDich.Add("<HANG_DAC_BIET>");
            listNguon.Add(txtLoaiHang.Text);
            listDich.Add("<BANG_SO>");
            listNguon.Add(txtBangSo.Text);
            listDich.Add("<BANG_CHU>");
            listNguon.Add(CommonMethods.ChuyenSoSangChu(txtBangSo.Text));
            listDich.Add("<SL_AN_CHI>");
            listNguon.Add(txtAnChi.Text);
            listDich.Add("<SL_BI_NIEM_PHONG>");
            listNguon.Add(txtBiNiemPhong.Text);
            listDich.Add("<DIA_CHI_CN>");
            listNguon.Add(Thong_tin_dang_nhap.dia_chi_cn);
            listDich.Add("<NOI_DEN>");
            listNguon.Add(txtNoiDen.Text);
            listDich.Add("<BIEN_SO>");
            listNguon.Add(txtBienSo.Text);
            listDich.Add("<NGAY_THUC_HIEN>");
            listNguon.Add(dtpNgayThucHien.Value.ToString("dd/MM/yyyy"));
        }

        void TaoFileTLTVC()
        {
            saveFileTLTVC.Filter = "Word Documents|*.docx";

            string subFolder = @"BienBanTiepQuy\";
            if (!CommonMethods.SubFolderExist(subFolder))
                CommonMethods.CreateSubFolder(subFolder);

            string TemplateFileLocation = CommonMethods.TemplateFileLocation(fileNameTLTVC + ".docx");
            string saveFileLocation = CommonMethods.SaveFileLocation(subFolder + fileNameTLTVC + "_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".docx");


            if (CommonMethods.CreateWordDocument(TemplateFileLocation, saveFileLocation, listDich, listNguon))
            {
                MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFileLocation, "Tạo file thành công");
                Thread.Sleep(500);
                OpenFileWord(saveFileLocation);
            }

        }

        void OpenFileWord(string fileLocation)
        {
            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document document = ap.Documents.Open(fileLocation);
            ap.Visible = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            KhoiTaoTLTVC();
            Thread th = new Thread(TaoFileTLTVC);
            th.Start();
        }


    }
}
