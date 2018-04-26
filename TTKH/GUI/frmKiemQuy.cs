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
using System.Threading;
namespace AGRIBANKHD.GUI
{
    public partial class frmKiemQuy : Form
    {
        public static string fileNameKiemQuy = "BIEN_BAN_KIEM_QUY";

        List<User> users, usersKiemQuy;
        List<string> listNguon, listDich;

        int fimiCE50, fimiCE100, fimiCE200, fimiCE500, fimiCETong,
            demB50, demB100, demB200, demB500,
            demCC50, demCC100, demCC200, demCC500,
            demCL50, demCL100, demCL200, demCL500,
            demTong;

        public frmKiemQuy()
        {
            InitializeComponent();
            listNguon = new List<string>();
            listDich = new List<string>();
            LayTTCanBo();
            try
            {
                DataTable dt = KiemQuyDAL.DV_ATM_MACN();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbATMID.Items.Add(dt.Rows[i]["ID"].ToString());
                }
                if (cbATMID.Items.Count > 0)
                    cbATMID.SelectedIndex = 0;
            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
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


        void KhoiTaoKiemQuy()
        {
            listNguon.Clear();
            listDich.Clear();

            //TT CHUNG
            listDich.Add("<CHI_NHANH>");
            listNguon.Add(Thong_tin_dang_nhap.ten_cn.ToUpper());

            listDich.Add("<NGAY>");
            listNguon.Add(DateTime.Now.Day.ToString());
            listDich.Add("<THANG>");
            listNguon.Add(DateTime.Now.Month.ToString());
            listDich.Add("<NAM>");
            listNguon.Add(DateTime.Now.Year.ToString());

            listDich.Add("<TU_NGAY>");
            listNguon.Add(dtpTuNgay.Value.ToString("dd/MM/yyyy"));
            listDich.Add("<DEN_NGAY>");
            listNguon.Add(dtpDenNgay.Value.ToString("dd/MM/yyyy"));

            listDich.Add("<ATM_ID>");
            listNguon.Add(cbATMID.SelectedItem.ToString());
            
            //THANH PHAN KIEM QUY
            string hoTen = "";
            string chucVu = "";
            foreach (var c in usersKiemQuy)
            {
                //string gt = "Bà: ";
                //if (c.gioiTinh)
                //    gt = "Ông: ";
                hoTen += "- " + c.tennv + "\n";
                chucVu += "- " + c.chucvu + "\n";
            }

            listDich.Add("<HO_TEN>");
            listNguon.Add(hoTen);
            listDich.Add("<CHUC_VU>");
            listNguon.Add(chucVu);

            //GD Quoc te/NAPAS
            listDich.Add("<TIEN_GDTQT_THT>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtNAPAS1.Text));
            listDich.Add("<MON_GDTQT_CHT>");
            listNguon.Add(txtNAPAS2.Text);
            listDich.Add("<TIEN_GQTQT_CHT>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtNAPAS3.Text));

            //IPCAS
            listDich.Add("<T_CO>");
            listNguon.Add(txtTimeIPCAS1.Text);
            listDich.Add("<CO>");
            listNguon.Add(txtTimeIPCAS2.Text);
            listDich.Add("<CI>");
            listNguon.Add(txtTimeIPCAS3.Text);
            listDich.Add("<DU_T_CO>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtSoDuIPCAS1.Text));
            listDich.Add("<DU_CO>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtSoDuIPCAS2.Text));
            listDich.Add("<DU_CI>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtSoDuIPCAS3.Text));
            listDich.Add("<GC1>");
            listNguon.Add(txtGhiChuIPCAS1.Text);
            listDich.Add("<GC2>");
            listNguon.Add(txtGhiChuIPCAS2.Text);
            listDich.Add("<GC3>");
            listNguon.Add(txtGhiChuIPCAS3.Text);

            //FIMI

            //STARTING CASH
            listDich.Add("<TIME_SC>"); //TIME
            listNguon.Add(txtTimeFIMIStart.Text);
            listDich.Add("<FIMI_SC50>"); //SO TO
            listNguon.Add(CommonMethods.ThemDauPhay(txtFIMIStart50.Text));
            listDich.Add("<FIMI_SC100>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtFIMIStart100.Text));
            listDich.Add("<FIMI_SC200>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtFIMIStart200.Text));
            listDich.Add("<FIMI_SC500>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtFIMIStart500.Text));
            listDich.Add("<FIMI_SC_TONG>");
            listNguon.Add(CommonMethods.ThemDauPhay(
            (Convert.ToInt32(txtFIMIStart50.Text) +
            Convert.ToInt32(txtFIMIStart100.Text) +
            Convert.ToInt32(txtFIMIStart200.Text) +
            Convert.ToInt32(txtFIMIStart500.Text)
            ).ToString()
            ));

            listDich.Add("<FIMI_SC_TT50>");// THANH TIEN
            listNguon.Add(CommonMethods.ThemDauPhay((Convert.ToInt32(txtFIMIStart50.Text) * 50000).ToString()));
            listDich.Add("<FIMI_SC_TT100>");
            listNguon.Add(CommonMethods.ThemDauPhay((Convert.ToInt32(txtFIMIStart100.Text) * 100000).ToString()));
            listDich.Add("<FIMI_SC_TT200>");
            listNguon.Add(CommonMethods.ThemDauPhay((Convert.ToInt32(txtFIMIStart200.Text) * 200000).ToString()));
            listDich.Add("<FIMI_SC_TT500>");
            listNguon.Add(CommonMethods.ThemDauPhay((Convert.ToInt32(txtFIMIStart500.Text) * 500000).ToString()));
            listDich.Add("<FIMI_SC_TT_TONG>");
            listNguon.Add(CommonMethods.ThemDauPhay((
            Convert.ToInt32(txtFIMIStart50.Text) * 50000 +
            Convert.ToInt32(txtFIMIStart100.Text) * 100000 +
            Convert.ToInt32(txtFIMIStart200.Text) * 200000 +
            Convert.ToInt32(txtFIMIStart500.Text) * 500000
            ).ToString()
            ));

            //CASH END
            listDich.Add("<TIME_CE>"); //TIME
            listNguon.Add(txtTimeFIMIEnd.Text);
            listDich.Add("<FIMI_CE50>");//SO TO
            listNguon.Add(CommonMethods.ThemDauPhay(txtFIMIEnd50.Text));
            listDich.Add("<FIMI_CE100>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtFIMIEnd100.Text));
            listDich.Add("<FIMI_CE200>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtFIMIEnd200.Text));
            listDich.Add("<FIMI_CE500>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtFIMIEnd500.Text));
            listDich.Add("<FIMI_CE_TONG>");
            listNguon.Add(CommonMethods.ThemDauPhay(
            (Convert.ToInt32(txtFIMIEnd50.Text) +
            Convert.ToInt32(txtFIMIEnd100.Text) +
            Convert.ToInt32(txtFIMIEnd200.Text) +
            Convert.ToInt32(txtFIMIEnd500.Text)
            ).ToString()
            ));

            listDich.Add("<FIMI_CE_TT50>");
            listNguon.Add(CommonMethods.ThemDauPhay((Convert.ToInt32(txtFIMIEnd50.Text) * 50000).ToString()));
            listDich.Add("<FIMI_CE_TT100>");
            listNguon.Add(CommonMethods.ThemDauPhay((Convert.ToInt32(txtFIMIEnd50.Text) * 100000).ToString()));
            listDich.Add("<FIMI_CE_TT200>");
            listNguon.Add(CommonMethods.ThemDauPhay((Convert.ToInt32(txtFIMIEnd50.Text) * 200000).ToString()));
            listDich.Add("<FIMI_CE_TT500>");
            listNguon.Add(CommonMethods.ThemDauPhay((Convert.ToInt32(txtFIMIEnd50.Text) * 500000).ToString()));
            listDich.Add("<FIMI_CE_TT_TONG>");
            int cashEnd = Convert.ToInt32(txtFIMIEnd50.Text) * 50000 +
            Convert.ToInt32(txtFIMIEnd100.Text) * 100000 +
            Convert.ToInt32(txtFIMIEnd200.Text) * 200000 +
            Convert.ToInt32(txtFIMIEnd500.Text) * 500000;
            listNguon.Add(CommonMethods.ThemDauPhay(cashEnd.ToString()));
            

            //KIEM DEM THUC TE

            //HOP TIEN CHINH
            listDich.Add("<B50>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemChinh50.Text));
            listDich.Add("<B100>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemChinh100.Text));
            listDich.Add("<B200>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemChinh200.Text));
            listDich.Add("<B500>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemChinh500.Text));
            listDich.Add("<BTONG>");
            listNguon.Add(CommonMethods.ThemDauPhay((
                Convert.ToInt32(txtDemChinh50.Text) +
                Convert.ToInt32(txtDemChinh100.Text) +
                Convert.ToInt32(txtDemChinh200.Text) +
                Convert.ToInt32(txtDemChinh500.Text)).ToString()
                ));

            //HOP TIEN LOAI
            listDich.Add("<C_NC50>"); //NGAN CHINH
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemLoaiChinh50.Text));
            listDich.Add("<C_NC100>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemLoaiChinh100.Text));
            listDich.Add("<C_NC200>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemLoaiChinh200.Text));
            listDich.Add("<C_NC500>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemLoaiChinh500.Text));
            listDich.Add("<C_NCTONG>");
            listNguon.Add(CommonMethods.ThemDauPhay((
               Convert.ToInt32(txtDemLoaiChinh50.Text) +
               Convert.ToInt32(txtDemLoaiChinh100.Text) +
               Convert.ToInt32(txtDemLoaiChinh200.Text) +
               Convert.ToInt32(txtDemLoaiChinh500.Text)).ToString()
               ));

            listDich.Add("<C_TH50>");//NGAN THU HOI
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemLoaiThuHoi50.Text));
            listDich.Add("<C_TH100>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemLoaiThuHoi100.Text));
            listDich.Add("<C_TH200>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemLoaiThuHoi200.Text));
            listDich.Add("<C_TH500>");
            listNguon.Add(CommonMethods.ThemDauPhay(txtDemLoaiThuHoi500.Text));
            listDich.Add("<C_THTONG>");
            listNguon.Add(CommonMethods.ThemDauPhay((
               Convert.ToInt32(txtDemLoaiThuHoi50.Text) +
               Convert.ToInt32(txtDemLoaiThuHoi100.Text) +
               Convert.ToInt32(txtDemLoaiThuHoi200.Text) +
               Convert.ToInt32(txtDemLoaiThuHoi500.Text)).ToString()
               ));

            //TONG TIEN
            listDich.Add("<TONG50>");
            int tong50 =
                (Convert.ToInt32(txtDemChinh50.Text) +
                Convert.ToInt32(txtDemLoaiChinh50.Text) +
                Convert.ToInt32(txtDemLoaiThuHoi50.Text)) * 50000;
            listNguon.Add(CommonMethods.ThemDauPhay(tong50.ToString()));

            listDich.Add("<TONG100>");
            int tong100 = (
                Convert.ToInt32(txtDemChinh100.Text) +
                Convert.ToInt32(txtDemLoaiChinh100.Text) +
                Convert.ToInt32(txtDemLoaiThuHoi100.Text)) * 100000;
            listNguon.Add(CommonMethods.ThemDauPhay(tong100.ToString()));

            listDich.Add("<TONG200>");
            int tong200 = (
               Convert.ToInt32(txtDemChinh200.Text) +
               Convert.ToInt32(txtDemLoaiChinh200.Text) +
               Convert.ToInt32(txtDemLoaiThuHoi200.Text)) * 200000;
            listNguon.Add(CommonMethods.ThemDauPhay(tong200.ToString()));

            listDich.Add("<TONG500>");
            int tong500 = (
               Convert.ToInt32(txtDemChinh500.Text) +
               Convert.ToInt32(txtDemLoaiChinh500.Text) +
               Convert.ToInt32(txtDemLoaiThuHoi500.Text)) * 500000;
            listNguon.Add(CommonMethods.ThemDauPhay(tong500.ToString()));

            listDich.Add("<TONG>");
            int tong = tong50 + tong100 + tong200 + tong500;
            listNguon.Add(CommonMethods.ThemDauPhay(tong.ToString()));

            listDich.Add("<TONG_BANGCHU>");
            listNguon.Add(CommonMethods.ChuyenSoSangChu(tong.ToString()));

            //KET LUAN
            int tienThuaThieu = Math.Abs(tong - cashEnd);
            listDich.Add("<TIEN_THUA_THIEU>");
            listNguon.Add(CommonMethods.ThemDauPhay(tienThuaThieu.ToString()));
            listDich.Add("<NGUYEN_NHAN>");
            listNguon.Add(txtNguyenNhan.Text);
            listDich.Add("<HUONG_XL>");
            listNguon.Add(txtKhacPhuc.Text);
        }

        void TaoFileKiemQuy()
        {
            saveFileKiemQuy.Filter = "Word Documents|*.docx";

            string subFolder = @"BienBanKiemQuy\";
            if (!CommonMethods.SubFolderExist(subFolder))
                CommonMethods.CreateSubFolder(subFolder);

            string TemplateFileLocation = CommonMethods.TemplateFileLocation(fileNameKiemQuy + ".docx");
            string saveFileLocation = CommonMethods.SaveFileLocation(subFolder + fileNameKiemQuy + "_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".docx");


            if (CommonMethods.CreateWordDocument(TemplateFileLocation, saveFileLocation, listDich, listNguon))
            {
                MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFileLocation, "Tạo file thành công");
                Thread.Sleep(500);
                OpenFileWord(saveFileKiemQuy.FileName);

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
            KhoiTaoKiemQuy();
            Thread th = new Thread(TaoFileKiemQuy);
            th.Start();
        }

        private void frmKiemQuy_Load(object sender, EventArgs e)
        {

        }

        private void txtDemLoaiThuHoi500_Leave(object sender, EventArgs e)
        {
            fimiCE50 = Convert.ToInt32(txtFIMIEnd50.Text);
            fimiCE100 = Convert.ToInt32(txtFIMIEnd100.Text);
            fimiCE200 = Convert.ToInt32(txtFIMIEnd200.Text);
            fimiCE500 = Convert.ToInt32(txtFIMIEnd500.Text);

            fimiCETong = (fimiCE50 + fimiCE100 * 2 + fimiCE200 * 4 + fimiCE500 * 10) * 50000;

            demB50 = Convert.ToInt32(txtDemChinh50.Text);
            demB100 = Convert.ToInt32(txtDemChinh100.Text);
            demB200 = Convert.ToInt32(txtDemChinh200.Text);
            demB500 = Convert.ToInt32(txtDemChinh500.Text);

            demCC50 = Convert.ToInt32(txtDemLoaiChinh50.Text);
            demCC100 = Convert.ToInt32(txtDemLoaiChinh100.Text);
            demCC200 = Convert.ToInt32(txtDemLoaiChinh200.Text);
            demCC500 = Convert.ToInt32(txtDemLoaiChinh500.Text);

            demCL50 = Convert.ToInt32(txtDemLoaiThuHoi50.Text);
            demCL100 = Convert.ToInt32(txtDemLoaiThuHoi100.Text);
            demCL200 = Convert.ToInt32(txtDemLoaiThuHoi200.Text);
            demCL500 = Convert.ToInt32(txtDemLoaiThuHoi500.Text);

            demTong = 50000 * (
                (demB50 + demCC50 + demCL50) +
                (demB100 + demCC100 + demCL100) * 2 +
                (demB200 + demCC200 + demCL200) * 4 +
                (demB500 + demCC500 + demCL500) * 10
                );
            txtThuaThieu.Text = Math.Abs(demTong - fimiCETong).ToString();
        }

    
    }
}
