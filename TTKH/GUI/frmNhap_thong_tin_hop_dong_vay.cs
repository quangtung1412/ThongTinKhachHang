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

namespace AGRIBANKHD.GUI
{
    public partial class frmNhap_thong_tin_hop_dong_vay : Form
    {
        CanbotindungBUS cbbus = new CanbotindungBUS();
        internal string _ma_kh_vay { get; set; }

        private string _ma_hd_vay = "";

        HopdongvayBUS hdbus = new HopdongvayBUS();

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public frmNhap_thong_tin_hop_dong_vay(string ma_cn, string ten_cn,string ma_hd_vay)
        {
            InitializeComponent();
            this._ma_hd_vay = ma_hd_vay;
            txtMa_hd_vay.Text = ma_hd_vay;
            txtMa_hd_vay.ReadOnly = true;
            List<Hopdongvay> HD_VAY_theoma_HD = HopdongvayBUS.HD_VAY_theoma_HD(ma_hd_vay,ma_cn);
            Hopdongvay hd = HD_VAY_theoma_HD[0];
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            txtma_CN.Text = ma_cn;
            cboxChi_nhanh.Enabled = false;
            cboxChi_nhanh.Text = ten_cn;
            cboxPhuong_thuc.Text = hd.phuong_thuc;
            txtTong_han_muc_tin_dung.Text = Convert.ToString(hd.tong_han_muc_tin_dung);
            txtHan_muc_tin_dung.Text = Convert.ToString(hd.han_muc_tin_dung);
            txtHan_muc_bao_lanh.Text = Convert.ToString(hd.han_muc_bao_lanh);
            txtMa_kh_vay.Text = hd.ma_kh_vay;
            btnTim_kiem_khach_hang.Enabled = false;
            txtMuc_dich_vay.Text = hd.muc_dich_vay;
            txtLai_suat.Text = hd.lai_suat;
            txtPhuong_thuc_tra_lai.Text = hd.phuong_thuc_tra_lai;
            txtPhuong_thuc_tra_goc.Text = hd.phuong_thuc_tra_goc;
            txtThoi_han_vay.Text = hd.thoi_han_vay;
            txtHan_tro_no_cuoi.Text = hd.han_tra_no_cuoi;
            txtThoi_han_rut_von.Enabled = false;            
            txtThoi_han_rut_von.Text = hd.thoi_han_rut_von;
            txtThoi_gian_an_han.Enabled = false;
            txtThoi_gian_an_han.Text = hd.thoi_gian_an_han;
            txtBao_dam_tien_vay.Text = hd.bao_dam_tien_vay;
            txtHinh_thuc_bao_dam.Text = hd.hinh_thuc_bao_dam;
            txtTai_san_bao_dam.Text = hd.tai_san_bao_dam;
            txtGia_tri_tai_san_bao_dam.Text = Convert.ToString(hd.gia_tri_tai_san_bao_dam);     

            Canbotindung dai_dien_agribank = cbbus.CBTD_theo_ten_dang_nhap(hd.dai_dien_agribank);
            //cboxDai_dien_agribank.Text = dai_dien_agribank.ho_ten;

            Canbotindung kiem_soat_tin_dung = cbbus.CBTD_theo_ten_dang_nhap(hd.kiem_soat_tin_dung);
            //cboxKiem_soat_tin_dung.Text = kiem_soat_tin_dung.ho_ten;

            Canbotindung can_bo_tin_dung = cbbus.CBTD_theo_ten_dang_nhap(hd.can_bo_tin_dung);
            //cboxCan_bo_tin_dung.Text = can_bo_tin_dung.ho_ten;

            txtMa_hd_vay_cu.Text = hd.ma_hd_vay_cu;
            txtNgay_hd_vay_cu.Text = hd.ngay_hd_vay_cu;

            if (dai_dien_agribank.kich_hoat && kiem_soat_tin_dung.kich_hoat && can_bo_tin_dung.kich_hoat)
            {
                DataTable dsdaidienagribank = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Giám đốc");
                DataTable dsdaidienagribank_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó Giám đốc");
                dsdaidienagribank.Merge(dsdaidienagribank_temp1);
                cboxDai_dien_agribank.DataSource = dsdaidienagribank;
                cboxDai_dien_agribank.DisplayMember = "HO_TEN";
                cboxDai_dien_agribank.ValueMember = "TEN_DANG_NHAP";
                cboxDai_dien_agribank.Text = hd.dai_dien_agribank;

                DataTable dsdaidienagribank_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Giám đốc phòng giao dịch");
                dsdaidienagribank.Merge(dsdaidienagribank_temp2);
                if (Thong_tin_dang_nhap.admin)
                {
                    DataTable kiemsoattindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Trưởng phòng Khách hàng Doanh nghiệp");

                    DataTable kiemsoattindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân");
                    kiemsoattindung.Merge(kiemsoattindung_temp1);

                    DataTable kiemsoattindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Khách hàng Doanh nghiệp");
                    kiemsoattindung.Merge(kiemsoattindung_temp2);

                    DataTable kiemsoattindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân");
                    kiemsoattindung.Merge(kiemsoattindung_temp3);

                    DataTable kiemsoattindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Trưởng phòng Kế hoạch & Kinh doanh");
                    kiemsoattindung.Merge(kiemsoattindung_temp4);

                    DataTable kiemsoattindung_temp5 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Kế hoạch & Kinh doanh");
                    kiemsoattindung.Merge(kiemsoattindung_temp5);

                    DataTable kiemsoattindung_temp6 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó Giám đốc phòng giao dịch");
                    kiemsoattindung.Merge(kiemsoattindung_temp6);

                    cboxKiem_soat_tin_dung.DataSource = kiemsoattindung;
                    cboxKiem_soat_tin_dung.DisplayMember = "HO_TEN";
                    cboxKiem_soat_tin_dung.ValueMember = "TEN_DANG_NHAP";
                    //Canbotindung kiem_soat_tin_dung = cbbus.CBTD_theo_ten_dang_nhap(hd.kiem_soat_tin_dung);
                    //cboxKiem_soat_tin_dung.Text = kiem_soat_tin_dung.ho_ten;
                }
                else
                {
                    DataTable kiemsoattindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Trưởng phòng Khách hàng Doanh nghiệp", Thong_tin_dang_nhap.ma_pb);

                    DataTable kiemsoattindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân", Thong_tin_dang_nhap.ma_pb);
                    kiemsoattindung.Merge(kiemsoattindung_temp1);

                    DataTable kiemsoattindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Khách hàng Doanh nghiệp", Thong_tin_dang_nhap.ma_pb);
                    kiemsoattindung.Merge(kiemsoattindung_temp2);

                    DataTable kiemsoattindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân", Thong_tin_dang_nhap.ma_pb);
                    kiemsoattindung.Merge(kiemsoattindung_temp3);

                    DataTable kiemsoattindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Trưởng phòng Kế hoạch & Kinh doanh", Thong_tin_dang_nhap.ma_pb);
                    kiemsoattindung.Merge(kiemsoattindung_temp4);

                    DataTable kiemsoattindung_temp5 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Kế hoạch & Kinh doanh", Thong_tin_dang_nhap.ma_pb);
                    kiemsoattindung.Merge(kiemsoattindung_temp5);

                    DataTable kiemsoattindung_temp6 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó Giám đốc phòng giao dịch", Thong_tin_dang_nhap.ma_pb);
                    kiemsoattindung.Merge(kiemsoattindung_temp6);

                    cboxKiem_soat_tin_dung.DataSource = kiemsoattindung;
                    cboxKiem_soat_tin_dung.DisplayMember = "HO_TEN";
                    cboxKiem_soat_tin_dung.ValueMember = "TEN_DANG_NHAP";
                    //Canbotindung kiem_soat_tin_dung = cbbus.CBTD_theo_ten_dang_nhap(hd.kiem_soat_tin_dung);
                    //cboxKiem_soat_tin_dung.Text = kiem_soat_tin_dung.ho_ten;
                }

                if (Thong_tin_dang_nhap.admin)
                {
                    DataTable dscanbotindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Khách hàng Doanh nghiệp");

                    DataTable dscanbotindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân");
                    dscanbotindung.Merge(dscanbotindung_temp1);

                    DataTable dscanbotindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Kế hoạch & Kinh doanh");
                    dscanbotindung.Merge(dscanbotindung_temp2);

                    DataTable dscanbotindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó Giám đốc phòng giao dịch");
                    dscanbotindung.Merge(dscanbotindung_temp3);

                    DataTable dscanbotindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Cán bộ thẩm định và QLKV");
                    dscanbotindung.Merge(dscanbotindung_temp4);
                    cboxCan_bo_tin_dung.DataSource = dscanbotindung;
                    cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                    cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                    txtTen_dang_nhap.Text = cboxCan_bo_tin_dung.SelectedValue.ToString();
                    txtTen_dang_nhap.Text = hd.can_bo_tin_dung;
                    //Canbotindung can_bo_tin_dung = cbbus.CBTD_theo_ten_dang_nhap(hd.can_bo_tin_dung);
                    cboxCan_bo_tin_dung.Text = can_bo_tin_dung.ho_ten;
                }
                else
                {
                    DataTable dscanbotindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Khách hàng Doanh nghiệp", Thong_tin_dang_nhap.ma_pb);

                    DataTable dscanbotindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân", Thong_tin_dang_nhap.ma_pb);
                    dscanbotindung.Merge(dscanbotindung_temp1);

                    DataTable dscanbotindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Kế hoạch & Kinh doanh", Thong_tin_dang_nhap.ma_pb);
                    dscanbotindung.Merge(dscanbotindung_temp2);

                    DataTable dscanbotindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó Giám đốc phòng giao dịch", Thong_tin_dang_nhap.ma_pb);
                    dscanbotindung.Merge(dscanbotindung_temp3);

                    DataTable dscanbotindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Cán bộ thẩm định và QLKV", Thong_tin_dang_nhap.ma_pb);
                    dscanbotindung.Merge(dscanbotindung_temp4);
                    cboxCan_bo_tin_dung.DataSource = dscanbotindung;
                    cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                    cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                    txtTen_dang_nhap.Text = cboxCan_bo_tin_dung.SelectedValue.ToString();
                    txtTen_dang_nhap.Text = hd.can_bo_tin_dung;
                    //Canbotindung can_bo_tin_dung = cbbus.CBTD_theo_ten_dang_nhap(hd.can_bo_tin_dung);
                    cboxCan_bo_tin_dung.Text = can_bo_tin_dung.ho_ten;
                }

                if (!Thong_tin_dang_nhap.admin && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Kế hoạch & Kinh doanh" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Doanh nghiệp" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân")
                {
                    cboxCan_bo_tin_dung.Enabled = false;
                }
            }
            else
            {
                cboxDai_dien_agribank.DataSource = null;
                cboxDai_dien_agribank.Items.Clear();
                // Here create a DataTable with 2 columns.
                DataTable table_Dai_dien_agribank = new DataTable();
                table_Dai_dien_agribank.Columns.Add("HO_TEN", typeof(string));
                table_Dai_dien_agribank.Columns.Add("TEN_DANG_NHAP", typeof(string));
                // Here add DataRows.
                table_Dai_dien_agribank.Rows.Add(dai_dien_agribank.ho_ten, dai_dien_agribank.ten_dang_nhap);
                cboxDai_dien_agribank.DataSource = table_Dai_dien_agribank;
                cboxDai_dien_agribank.DisplayMember = "HO_TEN";
                cboxDai_dien_agribank.ValueMember = "TEN_DANG_NHAP";
                cboxDai_dien_agribank.Text = dai_dien_agribank.ho_ten;

                //ComboboxItem item1 = new ComboboxItem();
                //item1.Text = dai_dien_agribank.ho_ten;
                //item1.Value = dai_dien_agribank.ten_dang_nhap;
                //cboxDai_dien_agribank.Items.Add(item1);
                //cboxDai_dien_agribank.SelectedIndex = 0;
                //cboxDai_dien_agribank.Text = dai_dien_agribank.ho_ten;

                cboxKiem_soat_tin_dung.DataSource = null;
                cboxKiem_soat_tin_dung.Items.Clear();
                // Here create a DataTable with 2 columns.
                DataTable table_Kiem_soat_tin_dung = new DataTable();
                table_Kiem_soat_tin_dung.Columns.Add("HO_TEN", typeof(string));
                table_Kiem_soat_tin_dung.Columns.Add("TEN_DANG_NHAP", typeof(string));
                // Here add DataRows.
                table_Kiem_soat_tin_dung.Rows.Add(kiem_soat_tin_dung.ho_ten, kiem_soat_tin_dung.ten_dang_nhap);
                cboxKiem_soat_tin_dung.DataSource = table_Kiem_soat_tin_dung;
                cboxKiem_soat_tin_dung.DisplayMember = "HO_TEN";
                cboxKiem_soat_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxKiem_soat_tin_dung.Text = kiem_soat_tin_dung.ho_ten;

                //ComboboxItem item2 = new ComboboxItem();
                //item2.Text = kiem_soat_tin_dung.ho_ten;
                //item2.Value = kiem_soat_tin_dung.ten_dang_nhap;
                //cboxKiem_soat_tin_dung.Items.Add(item2);
                //cboxKiem_soat_tin_dung.SelectedIndex = 0;
                //cboxKiem_soat_tin_dung.Text = kiem_soat_tin_dung.ho_ten;

                cboxCan_bo_tin_dung.DataSource = null;
                cboxCan_bo_tin_dung.Items.Clear();
                // Here create a DataTable with 2 columns.
                DataTable table_Can_bo_tin_dung = new DataTable();
                table_Can_bo_tin_dung.Columns.Add("HO_TEN", typeof(string));
                table_Can_bo_tin_dung.Columns.Add("TEN_DANG_NHAP", typeof(string));
                // Here add DataRows.
                table_Can_bo_tin_dung.Rows.Add(can_bo_tin_dung.ho_ten, can_bo_tin_dung.ten_dang_nhap);
                cboxCan_bo_tin_dung.DataSource = table_Can_bo_tin_dung;
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxCan_bo_tin_dung.Text = can_bo_tin_dung.ho_ten;
                txtTen_dang_nhap.Text = hd.can_bo_tin_dung;
                //cboxCan_bo_tin_dung.SelectedIndex = 0;
                //txtTen_dang_nhap.Text = cboxCan_bo_tin_dung.SelectedValue.ToString();

                //ComboboxItem item3 = new ComboboxItem();
                //item3.Text = can_bo_tin_dung.ho_ten;
                //item3.Value = can_bo_tin_dung.ten_dang_nhap;
                //cboxCan_bo_tin_dung.Items.Add(item3);
                //cboxCan_bo_tin_dung.SelectedIndex = 0;
                //cboxCan_bo_tin_dung.Text = can_bo_tin_dung.ho_ten;

                CommonMethods.SetReadOnlyToTextBoxesInGroupBox(grbThong_tin_hop_dong_vay);
                CommonMethods.DisableAllComboBoxInGroupBox(grbThong_tin_hop_dong_vay);
                btnCap_nhat.Enabled = false;
                btnXoa_man_hinh.Enabled = false;
            }
            
            txtNgay_hd_vay.Text = hd.ngay_hd_vay;

            //Khóa hết các input trong trường hợp đại diện, kiểm soát, cán bộ cho vay đã bị khóa
            //if (!dai_dien_agribank.kich_hoat || !kiem_soat_tin_dung.kich_hoat || !can_bo_tin_dung.kich_hoat)
            //{
                
            //}
        }
            
        public frmNhap_thong_tin_hop_dong_vay(string ma_cn, string ten_cn)
        {
            InitializeComponent();
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            cboxChi_nhanh.Enabled = false;
            cboxChi_nhanh.Text = ten_cn;
            txtma_CN.Text = ma_cn;
            cboxPhuong_thuc.Text = "Từng lần";
            txtThoi_han_rut_von.Enabled = false;
            txtThoi_gian_an_han.Enabled = false;
            
            DataTable dsdaidienagribank = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text,"Giám đốc");
            DataTable dsdaidienagribank_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó Giám đốc");
            dsdaidienagribank.Merge(dsdaidienagribank_temp1);
            DataTable dsdaidienagribank_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Giám đốc phòng giao dịch");
            dsdaidienagribank.Merge(dsdaidienagribank_temp2);
            //DataTable dsdaidienagribank_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó Giám đốc phòng giao dịch");
            //dsdaidienagribank.Merge(dsdaidienagribank_temp3);
            cboxDai_dien_agribank.DataSource = dsdaidienagribank;
            cboxDai_dien_agribank.DisplayMember = "HO_TEN";
            cboxDai_dien_agribank.ValueMember = "TEN_DANG_NHAP";

            if (Thong_tin_dang_nhap.admin)
            {
                DataTable kiemsoattindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Trưởng phòng Khách hàng Doanh nghiệp");

                DataTable kiemsoattindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân");
                kiemsoattindung.Merge(kiemsoattindung_temp1);

                DataTable kiemsoattindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Khách hàng Doanh nghiệp");
                kiemsoattindung.Merge(kiemsoattindung_temp2);

                DataTable kiemsoattindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân");
                kiemsoattindung.Merge(kiemsoattindung_temp3);

                DataTable kiemsoattindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Trưởng phòng Kế hoạch & Kinh doanh");
                kiemsoattindung.Merge(kiemsoattindung_temp4);

                DataTable kiemsoattindung_temp5 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Kế hoạch & Kinh doanh");
                kiemsoattindung.Merge(kiemsoattindung_temp5);

                //DataTable kiemsoattindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Giám đốc phòng giao dịch");
                //kiemsoattindung.Merge(kiemsoattindung_temp2);
                DataTable kiemsoattindung_temp6 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó Giám đốc phòng giao dịch");
                kiemsoattindung.Merge(kiemsoattindung_temp6);

                cboxKiem_soat_tin_dung.DataSource = kiemsoattindung;
                cboxKiem_soat_tin_dung.DisplayMember = "HO_TEN";
                cboxKiem_soat_tin_dung.ValueMember = "TEN_DANG_NHAP";
            }
            else
            {
                DataTable kiemsoattindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Trưởng phòng Khách hàng Doanh nghiệp", Thong_tin_dang_nhap.ma_pb);

                DataTable kiemsoattindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân", Thong_tin_dang_nhap.ma_pb);
                kiemsoattindung.Merge(kiemsoattindung_temp1);

                DataTable kiemsoattindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Khách hàng Doanh nghiệp", Thong_tin_dang_nhap.ma_pb);
                kiemsoattindung.Merge(kiemsoattindung_temp2);

                DataTable kiemsoattindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân", Thong_tin_dang_nhap.ma_pb);
                kiemsoattindung.Merge(kiemsoattindung_temp3);

                DataTable kiemsoattindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Trưởng phòng Kế hoạch & Kinh doanh", Thong_tin_dang_nhap.ma_pb);
                kiemsoattindung.Merge(kiemsoattindung_temp4);

                DataTable kiemsoattindung_temp5 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Kế hoạch & Kinh doanh", Thong_tin_dang_nhap.ma_pb);
                kiemsoattindung.Merge(kiemsoattindung_temp5);

                DataTable kiemsoattindung_temp6 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó Giám đốc phòng giao dịch", Thong_tin_dang_nhap.ma_pb);
                kiemsoattindung.Merge(kiemsoattindung_temp6);

                cboxKiem_soat_tin_dung.DataSource = kiemsoattindung;
                cboxKiem_soat_tin_dung.DisplayMember = "HO_TEN";
                cboxKiem_soat_tin_dung.ValueMember = "TEN_DANG_NHAP";
            }

            if (Thong_tin_dang_nhap.admin)
            {
                DataTable dscanbotindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Khách hàng Doanh nghiệp");

                DataTable dscanbotindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân");
                dscanbotindung.Merge(dscanbotindung_temp1);

                DataTable dscanbotindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó phòng Kế hoạch & Kinh doanh");
                dscanbotindung.Merge(dscanbotindung_temp2);

                DataTable dscanbotindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Phó Giám đốc phòng giao dịch");
                dscanbotindung.Merge(dscanbotindung_temp3);

                DataTable dscanbotindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV(txtma_CN.Text, "Cán bộ thẩm định và QLKV");
                dscanbotindung.Merge(dscanbotindung_temp4);

                cboxCan_bo_tin_dung.DataSource = dscanbotindung;
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                txtTen_dang_nhap.Text = cboxCan_bo_tin_dung.SelectedValue.ToString();
            }
            else
            {
                DataTable dscanbotindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Khách hàng Doanh nghiệp", Thong_tin_dang_nhap.ma_pb);

                DataTable dscanbotindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp1);

                DataTable dscanbotindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó phòng Kế hoạch & Kinh doanh", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp2);

                DataTable dscanbotindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Phó Giám đốc phòng giao dịch", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp3);

                DataTable dscanbotindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(txtma_CN.Text, "Cán bộ thẩm định và QLKV", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp4);
                cboxCan_bo_tin_dung.DataSource = dscanbotindung;
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                txtTen_dang_nhap.Text = cboxCan_bo_tin_dung.SelectedValue.ToString();
            }

            //Cho phép trưởng phòng tín dụng hoặc admin lựa chọn cán bộ tín dụng, các user khác chỉ được chọn cán bộ tín dụng là bản thân
            if (!Thong_tin_dang_nhap.admin && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Kế hoạch & Kinh doanh" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Doanh nghiệp" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân")
            {
                cboxCan_bo_tin_dung.Enabled = false;
                cboxCan_bo_tin_dung.Text = Thong_tin_dang_nhap.ho_ten;
                txtTen_dang_nhap.Text = Thong_tin_dang_nhap.ten_dang_nhap;
            }
        }

        private void cboxChi_nhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCap_nhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_ma_hd_vay))
            {
                this.THEM_HD_VAY();
            }
            else
            {
                this.CAP_NHAT_HD_VAY();
            }
        }

        internal void THEM_HD_VAY()
        {
            if (string.IsNullOrEmpty(txtMa_hd_vay.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã hợp đồng (trường bắt buộc)");
                txtMa_hd_vay.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTong_han_muc_tin_dung.Text))
            {
                MessageBox.Show("Dữ liệu bắt buộc, đề nghị nhập!");
                txtTong_han_muc_tin_dung.Focus();
                return;
            }
            //if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(ControlFormat.skipComma(txtTong_han_muc_tin_dung.Text)))
            //{
            //    MessageBox.Show("Dữ liệu chưa được nhập hoặc nhập chưa đúng định dạng, đề nghị nhập lại!");
            //    txtTong_han_muc_tin_dung.Focus();
            //    return;
            //}
            //if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(ControlFormat.skipComma(txtHan_muc_tin_dung.Text)) && !string.IsNullOrEmpty(txtHan_muc_tin_dung.Text))
            //{
            //    MessageBox.Show("Dữ liệu nhập chưa đúng định dạng, đề nghị nhập lại!");
            //    txtHan_muc_tin_dung.Focus();
            //    return;
            //}
            //if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(ControlFormat.skipComma(txtHan_muc_bao_lanh.Text)) && !string.IsNullOrEmpty(txtHan_muc_bao_lanh.Text))
            //{
            //    MessageBox.Show("Dữ liệu nhập chưa đúng định dạng, đề nghị nhập lại!");
            //    txtHan_muc_bao_lanh.Focus();
            //    return;
            //}
            if (string.IsNullOrEmpty(txtMa_kh_vay.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng (trường bắt buộc)");
                txtMa_kh_vay.Focus();
                return;
            }
            if (hdbus.Kiem_tra_trung_ma_hd(txtMa_hd_vay.Text))
            {
                MessageBox.Show("Mã hợp đồng đã có trong hệ thống. Đề nghị kiểm tra lại thông tin!");
                return;
            }
            //if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(ControlFormat.skipComma(txtGia_tri_tai_san_bao_dam.Text)))
            //{
            //    MessageBox.Show("Bạn chưa nhập Giá trị tải sản bảo đảm hoặc dữ liệu nhập tại ô Giá trị tài sản bảo đảm chưa đúng, chỉ chấp nhận số, đề nghị nhập lại!");
            //    txtGia_tri_tai_san_bao_dam.Focus();
            //    return;
            //}
            if (string.IsNullOrEmpty(txtGia_tri_tai_san_bao_dam.Text))
            {
                MessageBox.Show("Dữ liệu bắt buộc, đề nghị nhập!");
                txtGia_tri_tai_san_bao_dam.Focus();
                return;
            }
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtNgay_hd_vay_cu.Text) && (txtNgay_hd_vay_cu.Text!="  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtNgay_hd_vay_cu.Focus();
                return;
            }
            if (txtHan_tro_no_cuoi.Text == "  /  /")
            {
                MessageBox.Show("Dữ liệu chưa được nhập, đề nghị nhập!");
                txtHan_tro_no_cuoi.Focus();
                return;
            }
            else if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHan_tro_no_cuoi.Text))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtHan_tro_no_cuoi.Focus();
                return;
            }
            //if (string.IsNullOrEmpty(txtNgay_hd_vay.Text))
            //{
            //    MessageBox.Show("Bạn chưa nhập ngày hợp đồng vay (trường bắt buộc)");
            //    txtNgay_hd_vay.Focus();
            //    return;
            //}
            //else if (!CommonMethods.KiemTraNhapNgay(txtNgay_hd_vay.Text))
            //{
            //    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
            //    txtNgay_hd_vay.Focus();
            //    return;
            //}        
            string[] hop_dong_vay = new string[25];
            //hop_dong_vay[0] = CommonMethods.NhapMaHopDong(txtMa_hd_vay.Text);
            hop_dong_vay[0] = txtMa_hd_vay.Text;
            hop_dong_vay[1] = txtma_CN.Text;
            hop_dong_vay[2] = txtMa_kh_vay.Text;
            hop_dong_vay[3] = cboxPhuong_thuc.Text;
            hop_dong_vay[4] = ControlFormat.skipComma(txtTong_han_muc_tin_dung.Text);
            if (!string.IsNullOrEmpty(txtHan_muc_tin_dung.Text))
            {
                hop_dong_vay[5] = ControlFormat.skipComma(txtHan_muc_tin_dung.Text);
            }
            else
            {
                hop_dong_vay[5] = "0";
            }
            if (!string.IsNullOrEmpty(txtHan_muc_bao_lanh.Text))
            {
                hop_dong_vay[6] = ControlFormat.skipComma(txtHan_muc_bao_lanh.Text);
            }
            else
            {
                hop_dong_vay[6] = "0";
            }
            hop_dong_vay[7] = txtMuc_dich_vay.Text;
            hop_dong_vay[8] = txtLai_suat.Text;
            hop_dong_vay[9] = txtPhuong_thuc_tra_lai.Text;
            hop_dong_vay[10] = txtPhuong_thuc_tra_goc.Text;
            hop_dong_vay[11] = txtThoi_han_vay.Text;
            hop_dong_vay[12] = txtHan_tro_no_cuoi.Text;
            hop_dong_vay[13] = txtThoi_han_rut_von.Text;
            hop_dong_vay[14] = txtThoi_gian_an_han.Text;
            hop_dong_vay[15] = txtBao_dam_tien_vay.Text;
            hop_dong_vay[16] = txtHinh_thuc_bao_dam.Text;
            hop_dong_vay[17] = txtTai_san_bao_dam.Text;
            hop_dong_vay[18] = ControlFormat.skipComma(txtGia_tri_tai_san_bao_dam.Text);
            //hop_dong_vay[19] = cboxDai_dien_agribank.Text;
            //Tên đăng nhập của đại diện Agribank
            hop_dong_vay[19] = cboxDai_dien_agribank.SelectedValue.ToString();
            //Tên đăng nhập của kiểm soát tín dụng
            hop_dong_vay[20] = cboxKiem_soat_tin_dung.SelectedValue.ToString();
            //Tên đăng nhập của cán bộ tín dụng quản lý khoản vay
            hop_dong_vay[21] = cboxCan_bo_tin_dung.SelectedValue.ToString();
            hop_dong_vay[22] = txtMa_hd_vay_cu.Text;
            if (txtNgay_hd_vay_cu.Text == "  /  /")
            {
                hop_dong_vay[23] = "";
            }
            else
            {
                hop_dong_vay[23] = txtNgay_hd_vay_cu.Text;
            }
            if (txtNgay_hd_vay.Text == "  /  /")
            {
                hop_dong_vay[24] = "";
            }
            else
            {
                hop_dong_vay[24] = txtNgay_hd_vay.Text;
            }       
            Hopdongvay hd = new Hopdongvay(hop_dong_vay);
            if (hdbus.THEM_HD_VAY(hd))
            {
                DialogResult dialogResult = MessageBox.Show("Nhập thông tin hợp đồng vay thành công! Bạn có muốn tiếp tục nhập thông tin về tài sản thế chấp cho món vay này?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                    frmNhap_tai_san_the_chap frm = new frmNhap_tai_san_the_chap(txtMa_hd_vay.Text, txtma_CN.Text);
                    //frm.MdiParent = this.MdiParent;
                    frm.ShowInTaskbar = false;
                    frm.ShowDialog();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        internal void CAP_NHAT_HD_VAY()
        {
            if (string.IsNullOrEmpty(txtMa_hd_vay.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã hợp đồng (trường bắt buộc)");
                txtMa_hd_vay.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTong_han_muc_tin_dung.Text))
            {
                MessageBox.Show("Dữ liệu bắt buộc, đề nghị nhập!");
                txtTong_han_muc_tin_dung.Focus();
                return;
            }
            //if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(ControlFormat.skipComma(txtTong_han_muc_tin_dung.Text)))
            //{
            //    MessageBox.Show("Dữ liệu chưa được nhập hoặc nhập chưa đúng định dạng, đề nghị nhập lại!");
            //    txtTong_han_muc_tin_dung.Focus();
            //    return;
            //}
            //if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(ControlFormat.skipComma(txtHan_muc_tin_dung.Text)) && !string.IsNullOrEmpty(txtHan_muc_tin_dung.Text))
            //{
            //    MessageBox.Show("Dữ liệu nhập chưa đúng định dạng, đề nghị nhập lại!");
            //    txtHan_muc_tin_dung.Focus();
            //    return;
            //}
            //if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(ControlFormat.skipComma(txtHan_muc_bao_lanh.Text)) && !string.IsNullOrEmpty(txtHan_muc_bao_lanh.Text))
            //{
            //    MessageBox.Show("Dữ liệu nhập chưa đúng định dạng, đề nghị nhập lại!");
            //    txtHan_muc_bao_lanh.Focus();
            //    return;
            //}
            if (string.IsNullOrEmpty(txtMa_kh_vay.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng (trường bắt buộc)");
                txtMa_kh_vay.Focus();
                return;
            }
            //if (hdbus.Kiem_tra_trung_ma_hd(txtMa_hd_vay.Text))
            //{
            //    MessageBox.Show("Mã hợp đồng đã có trong hệ thống. Đề nghị kiểm tra lại thông tin!");
            //    return;
            //}

            //if (!Utilities.CommonMethods.KiemTraNhapSo_Int64(ControlFormat.skipComma(txtGia_tri_tai_san_bao_dam.Text)))
            //{
            //    MessageBox.Show("Bạn chưa nhập Giá trị tải sản bảo đảm hoặc dữ liệu nhập tại ô Giá trị tài sản bảo đảm chưa đúng, chỉ chấp nhận số, đề nghị nhập lại!");
            //    txtGia_tri_tai_san_bao_dam.Focus();
            //    return;
            //}
            if (string.IsNullOrEmpty(txtGia_tri_tai_san_bao_dam.Text))
            {
                MessageBox.Show("Dữ liệu bắt buộc, đề nghị nhập!");
                txtGia_tri_tai_san_bao_dam.Focus();
                return;
            }
            if (!Utilities.CommonMethods.KiemTraNhapNgay(txtNgay_hd_vay_cu.Text) && (txtNgay_hd_vay_cu.Text != "  /  /"))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtNgay_hd_vay_cu.Focus();
                return;
            }
            if (txtHan_tro_no_cuoi.Text == "  /  /")
            {
                MessageBox.Show("Dữ liệu chưa được nhập, đề nghị nhập!");
                txtHan_tro_no_cuoi.Focus();
                return;
            }
            else if (!Utilities.CommonMethods.KiemTraNhapNgay(txtHan_tro_no_cuoi.Text))
            {
                MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy, đề nghị nhập lại!");
                txtHan_tro_no_cuoi.Focus();
                return;
            }
            
            //if (string.IsNullOrEmpty(txtNgay_hd_vay.Text))
            //{
            //    MessageBox.Show("Bạn chưa nhập ngày hợp đồng vay (trường bắt buộc)");
            //    txtNgay_hd_vay.Focus();
            //    return;
            //}
            //else if (!CommonMethods.KiemTraNhapNgay(txtNgay_hd_vay.Text))
            //{
            //    MessageBox.Show("Dữ liệu ngày chưa đúng định dạng dd/mm/yyyy hoặc chưa được nhập, đề nghị nhập lại!");
            //    txtNgay_hd_vay.Focus();
            //    return;
            //}

            string[] hop_dong_vay = new string[25];
            hop_dong_vay[0] = txtMa_hd_vay.Text;
            hop_dong_vay[1] = txtma_CN.Text;
            hop_dong_vay[2] = txtMa_kh_vay.Text;
            hop_dong_vay[3] = cboxPhuong_thuc.Text;
            hop_dong_vay[4] = ControlFormat.skipComma(txtTong_han_muc_tin_dung.Text);
            if (!string.IsNullOrEmpty(txtHan_muc_tin_dung.Text))
            {
                hop_dong_vay[5] = ControlFormat.skipComma(txtHan_muc_tin_dung.Text);
            }
            else
            {
                hop_dong_vay[5] = "0";
            }
            if (!string.IsNullOrEmpty(txtHan_muc_bao_lanh.Text))
            {
                hop_dong_vay[6] = ControlFormat.skipComma(txtHan_muc_bao_lanh.Text);
            }
            else
            {
                hop_dong_vay[6] = "0";
            }
            hop_dong_vay[7] = txtMuc_dich_vay.Text;
            hop_dong_vay[8] = txtLai_suat.Text;
            hop_dong_vay[9] = txtPhuong_thuc_tra_lai.Text;
            hop_dong_vay[10] = txtPhuong_thuc_tra_goc.Text;
            hop_dong_vay[11] = txtThoi_han_vay.Text;
            hop_dong_vay[12] = txtHan_tro_no_cuoi.Text;
            hop_dong_vay[13] = txtThoi_han_rut_von.Text;
            hop_dong_vay[14] = txtThoi_gian_an_han.Text;
            hop_dong_vay[15] = txtBao_dam_tien_vay.Text;
            hop_dong_vay[16] = txtHinh_thuc_bao_dam.Text;
            hop_dong_vay[17] = txtTai_san_bao_dam.Text;
            hop_dong_vay[18] = ControlFormat.skipComma(txtGia_tri_tai_san_bao_dam.Text);
            //Tên đăng nhập của đại diện Agribank
            hop_dong_vay[19] = cboxDai_dien_agribank.SelectedValue.ToString();
            //Tên đăng nhập của kiểm soát tín dụng
            hop_dong_vay[20] = cboxKiem_soat_tin_dung.SelectedValue.ToString();
            //Tên đăng nhập của cán bộ tín dụng quản lý khoản vay
            hop_dong_vay[21] = cboxCan_bo_tin_dung.SelectedValue.ToString();
            hop_dong_vay[22] = txtMa_hd_vay_cu.Text;
            if (txtNgay_hd_vay_cu.Text == "  /  /")
            {
                hop_dong_vay[23] = "";
            }
            else
            {
                hop_dong_vay[23] = txtNgay_hd_vay_cu.Text;
            }
            if (txtNgay_hd_vay.Text == "  /  /")
            {
                hop_dong_vay[24] = "";
            }
            else
            {
                hop_dong_vay[24] = txtNgay_hd_vay.Text;
            }
            //hop_dong_vay[22] = txtNgay_hd_vay.Text;
            Hopdongvay hd = new Hopdongvay(hop_dong_vay);
            if (hdbus.CAP_NHAT_HD_VAY(hd))
            {
                MessageBox.Show("Sửa đổi thông tin hợp đồng thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }
        private void btnXoa_man_hinh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_ma_hd_vay))
            {
                string[] name_of_textbox = { "txtma_CN" };
                CommonMethods.ClearTextBoxes(this, name_of_textbox);
            }
            else
            {
                string[] name_of_textbox = { "txtma_CN", "txtMa_hd_vay" };
                CommonMethods.ClearTextBoxes(this, name_of_textbox);
            }
        }

        private void btnTim_kiem_khach_hang_Click(object sender, EventArgs e)
        {
            frmThong_tin_kh_vay frm = new frmThong_tin_kh_vay(this);
            //frm.MdiParent = this.ParentForm;
            frm.Chon_kh_vay(txtma_CN.Text,cboxChi_nhanh.Text);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            //frm.BringToFront();
        }

        internal void Cap_nhat_txtMa_kh_vay()
        {
            txtMa_kh_vay.Text = _ma_kh_vay;
        }

        private void cboxCan_bo_tin_dung_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTen_dang_nhap.Text = cboxCan_bo_tin_dung.SelectedValue.ToString();
        }

        private void cboxPhuong_thuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxPhuong_thuc.Text=="Từng lần")
            {
                lblTong_han_muc_tin_dung.Text = "Số tiền cho vay";
                txtHan_muc_tin_dung.Clear();
                txtHan_muc_tin_dung.Enabled = false;
                txtHan_muc_bao_lanh.Clear();
                txtHan_muc_bao_lanh.Enabled = false;
                lblThoi_han_cho_vay.Text = "Thời hạn cho vay";
                lblHan_tro_no_cuoi.Text = "Hạn trả nợ cuối";
                txtThoi_han_rut_von.Clear();
                txtThoi_han_rut_von.Enabled = true;
                txtThoi_gian_an_han.Clear();
                txtThoi_gian_an_han.Enabled = true;
            }
            else if (cboxPhuong_thuc.Text == "Cho vay theo dự án đầu tư")
            {
                lblTong_han_muc_tin_dung.Text = "Số tiền cho vay";
                txtHan_muc_tin_dung.Clear();
                txtHan_muc_tin_dung.Enabled = false;
                txtHan_muc_bao_lanh.Clear();
                txtHan_muc_bao_lanh.Enabled = false;
                lblThoi_han_cho_vay.Text = "Thời hạn hiệu lực";
                lblHan_tro_no_cuoi.Text = "Hạn trả nợ cuối";
                txtThoi_han_rut_von.Clear();
                txtThoi_han_rut_von.Enabled = true;
                txtThoi_gian_an_han.Clear();
                txtThoi_gian_an_han.Enabled = true;
            }
            else if (cboxPhuong_thuc.Text == "Hạn mức tín dụng không bảo lãnh")
            {
                lblTong_han_muc_tin_dung.Text = "Mức dư nợ cao nhất";
                txtHan_muc_tin_dung.Clear();
                txtHan_muc_tin_dung.Enabled = true;
                txtHan_muc_bao_lanh.Clear();
                txtHan_muc_bao_lanh.Enabled = false;
                lblThoi_han_cho_vay.Text = "Thời hạn hiệu lực";
                lblHan_tro_no_cuoi.Text = "Ngày hiệu lực cuối";
                txtThoi_han_rut_von.Clear();
                //txtThoi_han_rut_von.Enabled = false;
                txtThoi_gian_an_han.Clear();
                //txtThoi_gian_an_han.Enabled = false;
            }
            else if (cboxPhuong_thuc.Text == "Hạn mức tín dụng có bảo lãnh")
            {
                lblTong_han_muc_tin_dung.Text = "Tổng hạn mức tín dụng";
                txtHan_muc_tin_dung.Enabled = true;
                txtHan_muc_bao_lanh.Enabled = true;
                lblThoi_han_cho_vay.Text = "Thời hạn hiệu lực";
                lblHan_tro_no_cuoi.Text = "Ngày hiệu lực cuối";
                txtThoi_han_rut_von.Clear();
                //txtThoi_han_rut_von.Enabled = false;
                txtThoi_gian_an_han.Clear();
                //txtThoi_gian_an_han.Enabled = false;
            }
        }

        //Định dạng số cho ô nhập giá trị tài sản bảo đảm
        private void txtGia_tri_tai_san_bao_dam_TextChanged(object sender, EventArgs e)
        {
            if (txtGia_tri_tai_san_bao_dam.Text == "")
            {
                txtGia_tri_tai_san_bao_dam.Text = null;
                //textWithcomma = "0"; //this property maintain the content of textbox with comma
                //textWithoutcomma = "0";  //this property maintain the content of textbox without comma

            }
            else
            {

                if (txtGia_tri_tai_san_bao_dam.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtGia_tri_tai_san_bao_dam.Text));
                    txtGia_tri_tai_san_bao_dam.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                    //textWithcomma = textBox1.Text; //this property maintain the content of textbox with comma
                    //textWithoutcomma = skipComma(textBox1.Text);  //this property maintain the content of textbox without comma
                }


            }
            txtGia_tri_tai_san_bao_dam.Select(txtGia_tri_tai_san_bao_dam.Text.Length, 0);
        }

        private void txtGia_tri_tai_san_bao_dam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //Định dạng số cho ô tổng hạn mức tín dụng
        private void txtTong_han_muc_tin_dung_TextChanged(object sender, EventArgs e)
        {
            if (txtTong_han_muc_tin_dung.Text == "")
            {
                txtTong_han_muc_tin_dung.Text = null;
                //textWithcomma = "0"; //this property maintain the content of textbox with comma
                //textWithoutcomma = "0";  //this property maintain the content of textbox without comma

            }
            else
            {

                if (txtTong_han_muc_tin_dung.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtTong_han_muc_tin_dung.Text));
                    txtTong_han_muc_tin_dung.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                    //textWithcomma = textBox1.Text; //this property maintain the content of textbox with comma
                    //textWithoutcomma = skipComma(textBox1.Text);  //this property maintain the content of textbox without comma
                }


            }
            txtTong_han_muc_tin_dung.Select(txtTong_han_muc_tin_dung.Text.Length, 0);
        }

        private void txtTong_han_muc_tin_dung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //Định dạng số cho ô hạn mức tín dụng
        private void txtHan_muc_tin_dung_TextChanged(object sender, EventArgs e)
        {
            if (txtHan_muc_tin_dung.Text == "")
            {
                txtHan_muc_tin_dung.Text = null;
                //textWithcomma = "0"; //this property maintain the content of textbox with comma
                //textWithoutcomma = "0";  //this property maintain the content of textbox without comma
            }
            else
            {
                if (txtHan_muc_tin_dung.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtHan_muc_tin_dung.Text));
                    txtHan_muc_tin_dung.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                    //textWithcomma = textBox1.Text; //this property maintain the content of textbox with comma
                    //textWithoutcomma = skipComma(textBox1.Text);  //this property maintain the content of textbox without comma
                }
            }
            txtHan_muc_tin_dung.Select(txtHan_muc_tin_dung.Text.Length, 0);
        }

        private void txtHan_muc_tin_dung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //Định dạng số cho ô hạn mức bảo lãnh
        private void txtHan_muc_bao_lanh_TextChanged(object sender, EventArgs e)
        {
            if (txtHan_muc_bao_lanh.Text == "")
            {
                txtHan_muc_bao_lanh.Text = null;
                //textWithcomma = "0"; //this property maintain the content of textbox with comma
                //textWithoutcomma = "0";  //this property maintain the content of textbox without comma
            }
            else
            {
                if (txtHan_muc_bao_lanh.Text != "")
                {
                    Int64 d = Convert.ToInt64(ControlFormat.skipComma(txtHan_muc_bao_lanh.Text));
                    txtHan_muc_bao_lanh.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                    //textWithcomma = textBox1.Text; //this property maintain the content of textbox with comma
                    //textWithoutcomma = skipComma(textBox1.Text);  //this property maintain the content of textbox without comma
                }
            }
            txtHan_muc_bao_lanh.Select(txtHan_muc_bao_lanh.Text.Length, 0);
        }

        private void txtHan_muc_bao_lanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        

    }
}
