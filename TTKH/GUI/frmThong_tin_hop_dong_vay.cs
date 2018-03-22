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
    public partial class frmThong_tin_hop_dong_vay : Form
    {
        private frmTai_san_the_chap _frmTSTC = null;

        private frmTao_ho_so_vay _frmTao_ho_so = null;

        private frmGNN_DXGN_KBTT _frmGNN_DXGN = null;
        
        HopdongvayBUS hd = new HopdongvayBUS();

        //Gọi hợp đồng vay từ form Tạo hồ sơ
        public frmThong_tin_hop_dong_vay(frmTao_ho_so_vay frmTao_ho_so, string ma_cn, string chi_nhanh)
        {
            _frmTao_ho_so = frmTao_ho_so;
            InitializeComponent();
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnChon.Enabled = true;

            //Lấy dữ liệu cho combobox Chi nhánh
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            cboxChi_nhanh.Text = chi_nhanh;
            cboxChi_nhanh.Enabled = false;
            txtma_CN.Text = ma_cn;
            cboxLoai_khach_hang.Text = "Cá nhân";
            txtTu_khoa.Enabled = false;
            
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
                DataRow top_row = dscanbotindung.NewRow();
                top_row[0] = "Tất cả";
                top_row[1] = "Tất cả";
                top_row[2] = "Tất cả";
                top_row[3] = "Tất cả";
                top_row[4] = "Tất cả";
                top_row[5] = "Tất cả";
                dscanbotindung.Rows.InsertAt(top_row, 0);
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxCan_bo_tin_dung.Text = "Tất cả";
            }
            else
            {
                DataTable dscanbotindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Khách hàng Doanh nghiệp", Thong_tin_dang_nhap.ma_pb);

                DataTable dscanbotindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp1);

                DataTable dscanbotindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Kế hoạch & Kinh doanh", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp2);

                DataTable dscanbotindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó Giám đốc phòng giao dịch", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp3);

                DataTable dscanbotindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Cán bộ thẩm định và QLKV", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp4);

                cboxCan_bo_tin_dung.DataSource = dscanbotindung;
                DataRow top_row = dscanbotindung.NewRow();
                top_row[0] = "Tất cả";
                top_row[1] = "Tất cả";
                top_row[2] = "Tất cả";
                top_row[3] = "Tất cả";
                top_row[4] = "Tất cả";
                top_row[5] = "Tất cả";
                dscanbotindung.Rows.InsertAt(top_row, 0);
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxCan_bo_tin_dung.Text = "Tất cả";
            }
            if (!Thong_tin_dang_nhap.admin)
            {
                cboxChi_nhanh.Enabled = false;
                cboxChi_nhanh.Text = Thong_tin_dang_nhap.ten_cn;
                txtma_CN.Text = Thong_tin_dang_nhap.ma_cn;

                if (Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Kế hoạch & Kinh doanh" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Doanh nghiệp" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân")
                {
                    cboxCan_bo_tin_dung.Enabled = false;
                    cboxCan_bo_tin_dung.Text = Thong_tin_dang_nhap.ho_ten;
                    cboxCan_bo_tin_dung.SelectedValue = Thong_tin_dang_nhap.ten_dang_nhap;
                    txtTen_dang_nhap.Text = Thong_tin_dang_nhap.ten_dang_nhap;
                }
            }
            this.AcceptButton = btnTim_kiem;
        }

        //Gọi hợp đồng vay từ form tài sản thế chấp
        public frmThong_tin_hop_dong_vay(frmTai_san_the_chap frmTSTC, string ma_cn, string chi_nhanh)
        {
            _frmTSTC = frmTSTC;
            InitializeComponent();
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnChon.Enabled = true;            

            //Lấy dữ liệu cho combobox Chi nhánh
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            cboxChi_nhanh.Text = chi_nhanh;
            cboxChi_nhanh.Enabled = false;
            txtma_CN.Text = ma_cn;
            cboxLoai_khach_hang.Text = "Cá nhân";
            txtTu_khoa.Enabled = false;
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
                DataRow top_row = dscanbotindung.NewRow();
                top_row[0] = "Tất cả";
                top_row[1] = "Tất cả";
                top_row[2] = "Tất cả";
                top_row[3] = "Tất cả";
                top_row[4] = "Tất cả";
                top_row[5] = "Tất cả";
                dscanbotindung.Rows.InsertAt(top_row, 0);
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxCan_bo_tin_dung.Text = "Tất cả";
            }
            else
            {
                DataTable dscanbotindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Khách hàng Doanh nghiệp", Thong_tin_dang_nhap.ma_pb);

                DataTable dscanbotindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp1);

                DataTable dscanbotindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Kế hoạch & Kinh doanh", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp2);

                DataTable dscanbotindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó Giám đốc phòng giao dịch", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp3);

                DataTable dscanbotindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Cán bộ thẩm định và QLKV", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp4);

                cboxCan_bo_tin_dung.DataSource = dscanbotindung;
                DataRow top_row = dscanbotindung.NewRow();
                top_row[0] = "Tất cả";
                top_row[1] = "Tất cả";
                top_row[2] = "Tất cả";
                top_row[3] = "Tất cả";
                top_row[4] = "Tất cả";
                top_row[5] = "Tất cả";
                dscanbotindung.Rows.InsertAt(top_row, 0);
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxCan_bo_tin_dung.Text = "Tất cả";
            }
            if (!Thong_tin_dang_nhap.admin)
            {
                cboxChi_nhanh.Enabled = false;
                cboxChi_nhanh.Text = Thong_tin_dang_nhap.ten_cn;
                txtma_CN.Text = Thong_tin_dang_nhap.ma_cn;

                if (Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Kế hoạch & Kinh doanh" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Doanh nghiệp" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân")
                {
                    cboxCan_bo_tin_dung.Enabled = false;
                    cboxCan_bo_tin_dung.Text = Thong_tin_dang_nhap.ho_ten;
                    cboxCan_bo_tin_dung.SelectedValue = Thong_tin_dang_nhap.ten_dang_nhap;
                    txtTen_dang_nhap.Text = Thong_tin_dang_nhap.ten_dang_nhap;
                }
            }
            this.AcceptButton = btnTim_kiem;
        }
        
        //Gọi hợp đồng vay từ form Giấy nhận nợ - Đề xuất giải ngân - Khai báo thông tin
        public frmThong_tin_hop_dong_vay(frmGNN_DXGN_KBTT frmGNN_DXGN, string ma_cn, string chi_nhanh)
        {
            _frmGNN_DXGN = frmGNN_DXGN;
            InitializeComponent();
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnChon.Enabled = true;

            //Lấy dữ liệu cho combobox Chi nhánh
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            cboxChi_nhanh.Text = chi_nhanh;
            cboxChi_nhanh.Enabled = false;
            txtma_CN.Text = ma_cn;
            cboxLoai_khach_hang.Text = "Cá nhân";
            txtTu_khoa.Enabled = false;
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
                DataRow top_row = dscanbotindung.NewRow();
                top_row[0] = "Tất cả";
                top_row[1] = "Tất cả";
                top_row[2] = "Tất cả";
                top_row[3] = "Tất cả";
                top_row[4] = "Tất cả";
                top_row[5] = "Tất cả";
                dscanbotindung.Rows.InsertAt(top_row, 0);
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxCan_bo_tin_dung.Text = "Tất cả";
            }
            else
            {
                DataTable dscanbotindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Khách hàng Doanh nghiệp", Thong_tin_dang_nhap.ma_pb);

                DataTable dscanbotindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp1);

                DataTable dscanbotindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Kế hoạch & Kinh doanh", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp2);

                DataTable dscanbotindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó Giám đốc phòng giao dịch", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp3);

                DataTable dscanbotindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Cán bộ thẩm định và QLKV", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp4);

                cboxCan_bo_tin_dung.DataSource = dscanbotindung;
                DataRow top_row = dscanbotindung.NewRow();
                top_row[0] = "Tất cả";
                top_row[1] = "Tất cả";
                top_row[2] = "Tất cả";
                top_row[3] = "Tất cả";
                top_row[4] = "Tất cả";
                top_row[5] = "Tất cả";
                dscanbotindung.Rows.InsertAt(top_row, 0);
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxCan_bo_tin_dung.Text = "Tất cả";
            }
            if (!Thong_tin_dang_nhap.admin)
            {
                cboxChi_nhanh.Enabled = false;
                cboxChi_nhanh.Text = Thong_tin_dang_nhap.ten_cn;
                txtma_CN.Text = Thong_tin_dang_nhap.ma_cn;

                if (Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Kế hoạch & Kinh doanh" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Doanh nghiệp" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân")
                {
                    cboxCan_bo_tin_dung.Enabled = false;
                    cboxCan_bo_tin_dung.Text = Thong_tin_dang_nhap.ho_ten;
                    cboxCan_bo_tin_dung.SelectedValue = Thong_tin_dang_nhap.ten_dang_nhap;
                    txtTen_dang_nhap.Text = Thong_tin_dang_nhap.ten_dang_nhap;
                }
            }
            this.AcceptButton = btnTim_kiem;
        }
        //Gọi hợp đồng vay từ menu
        public frmThong_tin_hop_dong_vay()
        {
            InitializeComponent();

            //Lấy dữ liệu cho combobox Chi nhánh
            List<Chinhanh> dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            cboxChi_nhanh.DataSource = dschinhanh;
            cboxChi_nhanh.DisplayMember = "ten_CN";
            cboxChi_nhanh.ValueMember = "ma_CN";
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
            //txtma_CN.Text = Thong_tin_dang_nhap.ma_cn;
            cboxLoai_khach_hang.Text = "Cá nhân";

            //Lấy dữ liệu cho combobox Cán bộ tín dụng
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
                DataRow top_row = dscanbotindung.NewRow();
                top_row[0] = "Tất cả";
                top_row[1] = "Tất cả";
                top_row[2] = "Tất cả";
                top_row[3] = "Tất cả";
                top_row[4] = "Tất cả";
                top_row[5] = "Tất cả";
                dscanbotindung.Rows.InsertAt(top_row, 0);
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxCan_bo_tin_dung.Text = "Tất cả";
            }
            else
            {
                DataTable dscanbotindung = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Khách hàng Doanh nghiệp", Thong_tin_dang_nhap.ma_pb);

                DataTable dscanbotindung_temp1 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Khách hàng Hộ sản xuất và Cá nhân", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp1);

                DataTable dscanbotindung_temp2 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó phòng Kế hoạch & Kinh doanh", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp2);

                DataTable dscanbotindung_temp3 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Phó Giám đốc phòng giao dịch", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp3);

                DataTable dscanbotindung_temp4 = AGRIBANKHD.BUS.CanbotindungBUS.tbl_CBTD_CV_MA_PB(Thong_tin_dang_nhap.ma_cn, "Cán bộ thẩm định và QLKV", Thong_tin_dang_nhap.ma_pb);
                dscanbotindung.Merge(dscanbotindung_temp4);

                cboxCan_bo_tin_dung.DataSource = dscanbotindung;
                DataRow top_row = dscanbotindung.NewRow();
                top_row[0] = "Tất cả";
                top_row[1] = "Tất cả";
                top_row[2] = "Tất cả";
                top_row[3] = "Tất cả";
                top_row[4] = "Tất cả";
                top_row[5] = "Tất cả";
                dscanbotindung.Rows.InsertAt(top_row, 0);
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxCan_bo_tin_dung.Text = "Tất cả";
            }

            if (!Thong_tin_dang_nhap.admin)
            {
                cboxChi_nhanh.Enabled = false;
                cboxChi_nhanh.Text = Thong_tin_dang_nhap.ten_cn;
                txtma_CN.Text = Thong_tin_dang_nhap.ma_cn;

                if (Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Doanh nghiệp" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Khách hàng Hộ sản xuất và Cá nhân" && Thong_tin_dang_nhap.chuc_vu != "Trưởng phòng Kế hoạch & Kinh doanh")
                {
                    cboxCan_bo_tin_dung.Enabled = false;
                    cboxCan_bo_tin_dung.Text = Thong_tin_dang_nhap.ho_ten;
                    cboxCan_bo_tin_dung.SelectedValue = Thong_tin_dang_nhap.ten_dang_nhap;
                    txtTen_dang_nhap.Text = Thong_tin_dang_nhap.ten_dang_nhap;
                }
            }

            btnChon.Enabled = false;
            txtTu_khoa.Enabled = false;
            this.AcceptButton = btnTim_kiem;
        }

        private void cboxChi_nhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtma_CN.Text = cboxChi_nhanh.SelectedValue.ToString();
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
                DataRow top_row = dscanbotindung.NewRow();
                top_row[0] = "Tất cả";
                top_row[1] = "Tất cả";
                top_row[2] = "Tất cả";
                top_row[3] = "Tất cả";
                top_row[4] = "Tất cả";
                top_row[5] = "Tất cả";
                dscanbotindung.Rows.InsertAt(top_row, 0);
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxCan_bo_tin_dung.Text = "Tất cả";
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
                DataRow top_row = dscanbotindung.NewRow();
                top_row[0] = "Tất cả";
                top_row[1] = "Tất cả";
                top_row[2] = "Tất cả";
                top_row[3] = "Tất cả";
                top_row[4] = "Tất cả";
                top_row[5] = "Tất cả";
                dscanbotindung.Rows.InsertAt(top_row, 0);
                cboxCan_bo_tin_dung.DisplayMember = "HO_TEN";
                cboxCan_bo_tin_dung.ValueMember = "TEN_DANG_NHAP";
                cboxCan_bo_tin_dung.Text = "Tất cả";
            }
        }

        private void btnTim_kiem_Click(object sender, EventArgs e)
        {
            ControlFormat.DataGridView_ShowAllColumn(dgvDanh_sach_hop_dong);
            List<string> columns = new List<string>();
            List<string> number_columns = new List<string>();
            number_columns.Add("TONG_HAN_MUC_TIN_DUNG");
            number_columns.Add("HAN_MUC_TIN_DUNG");
            number_columns.Add("HAN_MUC_BAO_LANH");
            number_columns.Add("GIA_TRI_TAI_SAN_BAO_DAM");
            //Tìm kiếm hợp đồng vay của tất cả cán bộ tín dụng

            if (cboxLoai_khach_hang.Text == "Cá nhân")
            {
                columns.Clear();
                columns.Add("HGD_TEN_CHONG");
                columns.Add("HGD_CMND_CHONG");
                columns.Add("HGD_TEN_VO");
                columns.Add("HGD_CMND_VO");
                columns.Add("TC_TEN");
                columns.Add("TC_CMND_DAI_DIEN");
            }
            else if (cboxLoai_khach_hang.Text == "Tổ chức")
            {
                columns.Clear();
                columns.Add("CN_TEN");
                columns.Add("CN_CMND");
                columns.Add("HGD_TEN_CHONG");
                columns.Add("HGD_CMND_CHONG");
                columns.Add("HGD_TEN_VO");
                columns.Add("HGD_CMND_VO");
            }
            else if (cboxLoai_khach_hang.Text == "Hộ gia đình")
            {
                columns.Clear();
                columns.Add("CN_TEN");
                columns.Add("CN_CMND");
                columns.Add("TC_TEN");
                columns.Add("TC_CMND_DAI_DIEN");
            }

            if (cboxCan_bo_tin_dung.Text == "Tất cả")
            {
                if (string.IsNullOrEmpty(cboxTieu_chi.Text))
                {
                    if (Thong_tin_dang_nhap.admin)
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_MACN(txtma_CN.Text, cboxLoai_khach_hang.Text);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                    }
                    else
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_MACN_MAPB(txtma_CN.Text, cboxLoai_khach_hang.Text, Thong_tin_dang_nhap.ma_pb);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                    }                    
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                    Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                    Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                }
                else if (cboxTieu_chi.Text == "Mã hợp đồng")
                {
                    if (Thong_tin_dang_nhap.admin)
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_MAHD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                    }
                    else
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_MAHD_MAPB(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, Thong_tin_dang_nhap.ma_pb);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                    }                    
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                    Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                    Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                }
                else if (cboxTieu_chi.Text == "Mã khách hàng")
                {
                    if (Thong_tin_dang_nhap.admin)
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_MAKH(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                    }
                    else
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_MAKH_MAPB(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, Thong_tin_dang_nhap.ma_pb);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                    }                    
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                    Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                    Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                }
                else if (cboxTieu_chi.Text == "Tên khách hàng")
                {
                    if (cboxLoai_khach_hang.Text == "Cá nhân")
                    {
                        if (Thong_tin_dang_nhap.admin)
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_TENKH_CN(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }
                        else
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_TENKH_CN_MAPB(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, Thong_tin_dang_nhap.ma_pb);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }                        
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }
                    else if (cboxLoai_khach_hang.Text == "Tổ chức")
                    {
                        if (Thong_tin_dang_nhap.admin)
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_TENKH_TC(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }
                        else
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_TENKH_TC_MAPB(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, Thong_tin_dang_nhap.ma_pb);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }
                    else if (cboxLoai_khach_hang.Text == "Hộ gia đình")
                    {
                        if (Thong_tin_dang_nhap.admin)
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_TENKH_HGD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }
                        else
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_TENKH_HGD_MAPB(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, Thong_tin_dang_nhap.ma_pb);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }                        
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }                    
                }
                else if (cboxTieu_chi.Text == "Số CMTND")
                {
                    if (cboxLoai_khach_hang.Text == "Cá nhân")
                    {
                        if (Thong_tin_dang_nhap.admin)
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_CMT_CN(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }
                        else
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_CMT_CN_MAPB(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, Thong_tin_dang_nhap.ma_pb);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }
                    else if (cboxLoai_khach_hang.Text == "Tổ chức")
                    {
                        if (Thong_tin_dang_nhap.admin)
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_CMT_TC(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }
                        else
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_CMT_TC_MAPB(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, Thong_tin_dang_nhap.ma_pb);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }                        
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }
                    else if (cboxLoai_khach_hang.Text == "Hộ gia đình")
                    {
                        if (Thong_tin_dang_nhap.admin)
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_CMT_HGD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }
                        else
                        {
                            DataTable hd_vay = HopdongvayBUS.HD_VAY_CMT_HGD_MAPB(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, Thong_tin_dang_nhap.ma_pb);
                            dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        }                        
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(cboxTieu_chi.Text))
                {
                    DataTable hd_vay = HopdongvayBUS.HD_VAY_MACN_CBTD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTen_dang_nhap.Text);
                    dgvDanh_sach_hop_dong.DataSource = hd_vay;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                    Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                    Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                }
                else if (cboxTieu_chi.Text == "Mã hợp đồng")
                {
                    DataTable hd_vay = HopdongvayBUS.HD_VAY_MAHD_CBTD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, txtTen_dang_nhap.Text);
                    dgvDanh_sach_hop_dong.DataSource = hd_vay;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                    Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                    Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                }
                else if (cboxTieu_chi.Text == "Mã khách hàng")
                {
                    DataTable hd_vay = HopdongvayBUS.HD_VAY_MAKH_CBTD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, txtTen_dang_nhap.Text);
                    dgvDanh_sach_hop_dong.DataSource = hd_vay;
                    Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                    Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                    Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                }
                else if (cboxTieu_chi.Text == "Tên khách hàng")
                {
                    if (cboxLoai_khach_hang.Text == "Cá nhân")
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_TENKH_CN_CBTD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, txtTen_dang_nhap.Text);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }
                    else if (cboxLoai_khach_hang.Text == "Tổ chức")
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_TENKH_TC_CBTD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, txtTen_dang_nhap.Text);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }
                    else if (cboxLoai_khach_hang.Text == "Hộ gia đình")
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_TENKH_HGD_CBTD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, txtTen_dang_nhap.Text);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }
                }
                else if (cboxTieu_chi.Text == "Số CMTND")
                {
                    if (cboxLoai_khach_hang.Text == "Cá nhân")
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_CMT_CN_CBTD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, txtTen_dang_nhap.Text);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }
                    else if (cboxLoai_khach_hang.Text == "Tổ chức")
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_CMT_TC_CBTD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, txtTen_dang_nhap.Text);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }
                    else if (cboxLoai_khach_hang.Text == "Hộ gia đình")
                    {
                        DataTable hd_vay = HopdongvayBUS.HD_VAY_CMT_HGD_CBTD(txtma_CN.Text, cboxLoai_khach_hang.Text, txtTu_khoa.Text, txtTen_dang_nhap.Text);
                        dgvDanh_sach_hop_dong.DataSource = hd_vay;
                        Utilities.ControlFormat.DataGridViewFormat(dgvDanh_sach_hop_dong);
                        Utilities.ControlFormat.DataGridViewColumnFormat(dgvDanh_sach_hop_dong, columns);
                        Utilities.ControlFormat.DataGridView_NumberColumnFormat(dgvDanh_sach_hop_dong, number_columns);
                    }
                }
            }                  
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmNhap_thong_tin_hop_dong_vay frm = new frmNhap_thong_tin_hop_dong_vay(txtma_CN.Text, cboxChi_nhanh.Text);
            //frm.MdiParent = this.ParentForm;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanh_sach_hop_dong.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvDanh_sach_hop_dong.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvDanh_sach_hop_dong.Rows[selectedrowindex];
                string ma_hd_vay = Convert.ToString(selectedRow.Cells["MA_HD_VAY"].Value);
                frmNhap_thong_tin_hop_dong_vay frm = new frmNhap_thong_tin_hop_dong_vay(txtma_CN.Text, cboxChi_nhanh.Text, ma_hd_vay);              
                //frm.MdiParent = this.MdiParent;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
                //frm.BringToFront();
            }
            else
            {
                MessageBox.Show("Chưa có hợp đồng nào được chọn để cập nhật thông tin");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanh_sach_hop_dong.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa hợp đồng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int selectedrowindex = dgvDanh_sach_hop_dong.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvDanh_sach_hop_dong.Rows[selectedrowindex];
                    string ma_hd_vay = Convert.ToString(selectedRow.Cells["ma_hd_vay"].Value);
                    if (hd.XOA_HD_VAY(ma_hd_vay,txtma_CN.Text))
                    {
                        MessageBox.Show("Xóa hợp đồng thành công!");
                        btnTim_kiem.PerformClick();
                        //this.Close();
                    }
                    else MessageBox.Show("Có lỗi xảy ra. Đề nghị liên hệ phòng Điện toán!");
                }
                else
                {
                    this.Activate();
                }
            }
            else
            {
                MessageBox.Show("Chưa có hợp đồng nào được chọn để xóa thông tin");
            }
        }

        private void cboxTieuchi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxTieu_chi.Text == "")
            {
                txtTu_khoa.ResetText();
                txtTu_khoa.Enabled = false;
            }
            else 
            {
                txtTu_khoa.Enabled = true;
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvDanh_sach_hop_dong.SelectedCells.Count > 0)
            {
                if (_frmTSTC != null)
                {
                    int selectedrowindex = dgvDanh_sach_hop_dong.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvDanh_sach_hop_dong.Rows[selectedrowindex];
                    _frmTSTC._ma_hd_vay = Convert.ToString(selectedRow.Cells["ma_hd_vay"].Value);
                    _frmTSTC.Cap_nhat_txtMa_hd_vay();
                    this.Close();
                }
                if (_frmTao_ho_so != null)
                {
                    int selectedrowindex = dgvDanh_sach_hop_dong.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvDanh_sach_hop_dong.Rows[selectedrowindex];
                    _frmTao_ho_so._ma_hd_vay = Convert.ToString(selectedRow.Cells["ma_hd_vay"].Value);
                    _frmTao_ho_so.Cap_nhat_txtMa_hd_vay();
                    this.Close();
                }
                if (_frmGNN_DXGN != null)
                {
                    int selectedrowindex = dgvDanh_sach_hop_dong.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvDanh_sach_hop_dong.Rows[selectedrowindex];
                    _frmGNN_DXGN._ma_hd_vay = Convert.ToString(selectedRow.Cells["ma_hd_vay"].Value);
                    _frmGNN_DXGN.Cap_nhat_txtMa_hd_vay();
                    this.Close();
                }
                             
            }
            else MessageBox.Show("Chưa có hợp đồng nào được chọn");
        }

        private void cboxCan_bo_tin_dung_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTen_dang_nhap.Text = cboxCan_bo_tin_dung.SelectedValue.ToString();
        }

        //private void cboxLoai_khach_hang_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    cboxTieu_chi.Items.Clear();
        //    if (cboxLoai_khach_hang.Text == "")
        //    {
        //        cboxTieu_chi.Items.Add("");
        //        cboxTieu_chi.Items.Add("Mã hợp đồng");
        //        cboxTieu_chi.Items.Add("Mã khách hàng");
        //    }
        //    else
        //    {
        //        cboxTieu_chi.Items.Add("");
        //        cboxTieu_chi.Items.Add("Mã hợp đồng");
        //        cboxTieu_chi.Items.Add("Mã khách hàng");
        //        cboxTieu_chi.Items.Add("Tên khách hàng");
        //        cboxTieu_chi.Items.Add("Số CMTND");
        //    }
        //    cboxTieu_chi.ResetText();
        //}
    }
}
