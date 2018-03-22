namespace AGRIBANKHD.GUI
{
    partial class frmThong_tin_hop_dong_vay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThong_tin_hop_dong_vay));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxLoai_khach_hang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTen_dang_nhap = new System.Windows.Forms.TextBox();
            this.btnChon = new System.Windows.Forms.Button();
            this.cboxCan_bo_tin_dung = new System.Windows.Forms.ComboBox();
            this.lblCan_bo_tin_dung = new System.Windows.Forms.Label();
            this.txtTu_khoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxTieu_chi = new System.Windows.Forms.ComboBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTim_kiem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxChi_nhanh = new System.Windows.Forms.ComboBox();
            this.txtma_CN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDanh_sach_hop_dong = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanh_sach_hop_dong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboxLoai_khach_hang);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTen_dang_nhap);
            this.groupBox1.Controls.Add(this.btnChon);
            this.groupBox1.Controls.Add(this.cboxCan_bo_tin_dung);
            this.groupBox1.Controls.Add(this.lblCan_bo_tin_dung);
            this.groupBox1.Controls.Add(this.txtTu_khoa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboxTieu_chi);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.btnTim_kiem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboxChi_nhanh);
            this.groupBox1.Controls.Add(this.txtma_CN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(969, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiêu chí tìm kiếm";
            // 
            // cboxLoai_khach_hang
            // 
            this.cboxLoai_khach_hang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxLoai_khach_hang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxLoai_khach_hang.FormattingEnabled = true;
            this.cboxLoai_khach_hang.Items.AddRange(new object[] {
            "Cá nhân",
            "Tổ chức",
            "Hộ gia đình"});
            this.cboxLoai_khach_hang.Location = new System.Drawing.Point(161, 71);
            this.cboxLoai_khach_hang.Name = "cboxLoai_khach_hang";
            this.cboxLoai_khach_hang.Size = new System.Drawing.Size(131, 24);
            this.cboxLoai_khach_hang.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loại khách hàng";
            // 
            // txtTen_dang_nhap
            // 
            this.txtTen_dang_nhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen_dang_nhap.Location = new System.Drawing.Point(161, 172);
            this.txtTen_dang_nhap.Name = "txtTen_dang_nhap";
            this.txtTen_dang_nhap.ReadOnly = true;
            this.txtTen_dang_nhap.Size = new System.Drawing.Size(131, 23);
            this.txtTen_dang_nhap.TabIndex = 10;
            // 
            // btnChon
            // 
            this.btnChon.Location = new System.Drawing.Point(437, 203);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(75, 30);
            this.btnChon.TabIndex = 12;
            this.btnChon.Text = "Chọn";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // cboxCan_bo_tin_dung
            // 
            this.cboxCan_bo_tin_dung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCan_bo_tin_dung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxCan_bo_tin_dung.FormattingEnabled = true;
            this.cboxCan_bo_tin_dung.Location = new System.Drawing.Point(297, 171);
            this.cboxCan_bo_tin_dung.Name = "cboxCan_bo_tin_dung";
            this.cboxCan_bo_tin_dung.Size = new System.Drawing.Size(361, 24);
            this.cboxCan_bo_tin_dung.TabIndex = 11;
            this.cboxCan_bo_tin_dung.SelectedIndexChanged += new System.EventHandler(this.cboxCan_bo_tin_dung_SelectedIndexChanged);
            // 
            // lblCan_bo_tin_dung
            // 
            this.lblCan_bo_tin_dung.AutoSize = true;
            this.lblCan_bo_tin_dung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCan_bo_tin_dung.Location = new System.Drawing.Point(21, 175);
            this.lblCan_bo_tin_dung.Name = "lblCan_bo_tin_dung";
            this.lblCan_bo_tin_dung.Size = new System.Drawing.Size(108, 17);
            this.lblCan_bo_tin_dung.TabIndex = 9;
            this.lblCan_bo_tin_dung.Text = "Cán bộ tín dụng";
            // 
            // txtTu_khoa
            // 
            this.txtTu_khoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTu_khoa.Location = new System.Drawing.Point(161, 139);
            this.txtTu_khoa.Name = "txtTu_khoa";
            this.txtTu_khoa.Size = new System.Drawing.Size(497, 23);
            this.txtTu_khoa.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Từ khóa";
            // 
            // cboxTieu_chi
            // 
            this.cboxTieu_chi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTieu_chi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxTieu_chi.FormattingEnabled = true;
            this.cboxTieu_chi.Items.AddRange(new object[] {
            "",
            "Mã hợp đồng",
            "Mã khách hàng",
            "Tên khách hàng",
            "Số CMTND"});
            this.cboxTieu_chi.Location = new System.Drawing.Point(161, 105);
            this.cboxTieu_chi.Name = "cboxTieu_chi";
            this.cboxTieu_chi.Size = new System.Drawing.Size(497, 24);
            this.cboxTieu_chi.TabIndex = 6;
            this.cboxTieu_chi.SelectedIndexChanged += new System.EventHandler(this.cboxTieuchi_SelectedIndexChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(879, 203);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 30);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(788, 203);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(86, 30);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(697, 203);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(86, 30);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(607, 203);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(86, 30);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTim_kiem
            // 
            this.btnTim_kiem.Location = new System.Drawing.Point(517, 203);
            this.btnTim_kiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTim_kiem.Name = "btnTim_kiem";
            this.btnTim_kiem.Size = new System.Drawing.Size(86, 30);
            this.btnTim_kiem.TabIndex = 13;
            this.btnTim_kiem.Text = "Tìm kiếm";
            this.btnTim_kiem.UseVisualStyleBackColor = true;
            this.btnTim_kiem.Click += new System.EventHandler(this.btnTim_kiem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tiêu chí tìm kiếm";
            // 
            // cboxChi_nhanh
            // 
            this.cboxChi_nhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxChi_nhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxChi_nhanh.FormattingEnabled = true;
            this.cboxChi_nhanh.Location = new System.Drawing.Point(297, 37);
            this.cboxChi_nhanh.Margin = new System.Windows.Forms.Padding(2);
            this.cboxChi_nhanh.Name = "cboxChi_nhanh";
            this.cboxChi_nhanh.Size = new System.Drawing.Size(361, 24);
            this.cboxChi_nhanh.TabIndex = 2;
            this.cboxChi_nhanh.SelectedIndexChanged += new System.EventHandler(this.cboxChi_nhanh_SelectedIndexChanged);
            // 
            // txtma_CN
            // 
            this.txtma_CN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtma_CN.Location = new System.Drawing.Point(161, 38);
            this.txtma_CN.Name = "txtma_CN";
            this.txtma_CN.ReadOnly = true;
            this.txtma_CN.Size = new System.Drawing.Size(131, 23);
            this.txtma_CN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi nhánh";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDanh_sach_hop_dong);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 256);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(969, 408);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách hợp đồng";
            // 
            // dgvDanh_sach_hop_dong
            // 
            this.dgvDanh_sach_hop_dong.AllowUserToAddRows = false;
            this.dgvDanh_sach_hop_dong.AllowUserToDeleteRows = false;
            this.dgvDanh_sach_hop_dong.AllowUserToResizeColumns = false;
            this.dgvDanh_sach_hop_dong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanh_sach_hop_dong.Location = new System.Drawing.Point(4, 20);
            this.dgvDanh_sach_hop_dong.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDanh_sach_hop_dong.MultiSelect = false;
            this.dgvDanh_sach_hop_dong.Name = "dgvDanh_sach_hop_dong";
            this.dgvDanh_sach_hop_dong.ReadOnly = true;
            this.dgvDanh_sach_hop_dong.RowTemplate.Height = 24;
            this.dgvDanh_sach_hop_dong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanh_sach_hop_dong.Size = new System.Drawing.Size(959, 384);
            this.dgvDanh_sach_hop_dong.TabIndex = 0;
            // 
            // frmThong_tin_hop_dong_vay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(994, 675);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThong_tin_hop_dong_vay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin hợp đồng vay";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanh_sach_hop_dong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtma_CN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxChi_nhanh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTim_kiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDanh_sach_hop_dong;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cboxTieu_chi;
        private System.Windows.Forms.TextBox txtTu_khoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxCan_bo_tin_dung;
        private System.Windows.Forms.Label lblCan_bo_tin_dung;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.TextBox txtTen_dang_nhap;
        private System.Windows.Forms.ComboBox cboxLoai_khach_hang;
        private System.Windows.Forms.Label label4;
    }
}