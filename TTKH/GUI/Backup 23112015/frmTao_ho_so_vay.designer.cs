namespace AGRIBANKHD.GUI
{
    partial class frmTao_ho_so_vay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTao_ho_so_vay));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTim_kiem_hop_dong_vay = new System.Windows.Forms.Button();
            this.txtMa_hd_vay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxChi_nhanh = new System.Windows.Forms.ComboBox();
            this.txtma_CN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.savefileTao_hop_dong_the_chap = new System.Windows.Forms.SaveFileDialog();
            this.savefileTao_bien_ban_dinh_gia = new System.Windows.Forms.SaveFileDialog();
            this.savefileTao_don_the_chap = new System.Windows.Forms.SaveFileDialog();
            this.savefileTao_de_xuat_giai_ngan = new System.Windows.Forms.SaveFileDialog();
            this.tabHo_so_vay = new System.Windows.Forms.TabControl();
            this.tabHop_dong_tin_dung = new System.Windows.Forms.TabPage();
            this.tabHop_dong_the_chap = new System.Windows.Forms.TabPage();
            this.tabBien_ban_dinh_gia = new System.Windows.Forms.TabPage();
            this.tabDon_the_chap = new System.Windows.Forms.TabPage();
            this.tabDe_xuat_giai_ngan = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoai_hop_dong_tin_dung = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNgay_hop_dong_tin_dung = new System.Windows.Forms.MaskedTextBox();
            this.btnTao_hop_dong_tin_dung = new System.Windows.Forms.Button();
            this.savefileTao_hop_dong_tin_dung = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.tabHo_so_vay.SuspendLayout();
            this.tabHop_dong_tin_dung.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabHo_so_vay);
            this.groupBox1.Controls.Add(this.btnTim_kiem_hop_dong_vay);
            this.groupBox1.Controls.Add(this.txtMa_hd_vay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboxChi_nhanh);
            this.groupBox1.Controls.Add(this.txtma_CN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(969, 622);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiêu chí tìm kiếm";
            // 
            // btnTim_kiem_hop_dong_vay
            // 
            this.btnTim_kiem_hop_dong_vay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim_kiem_hop_dong_vay.Location = new System.Drawing.Point(938, 22);
            this.btnTim_kiem_hop_dong_vay.Name = "btnTim_kiem_hop_dong_vay";
            this.btnTim_kiem_hop_dong_vay.Size = new System.Drawing.Size(25, 23);
            this.btnTim_kiem_hop_dong_vay.TabIndex = 15;
            this.btnTim_kiem_hop_dong_vay.Text = "...";
            this.btnTim_kiem_hop_dong_vay.UseVisualStyleBackColor = true;
            this.btnTim_kiem_hop_dong_vay.Click += new System.EventHandler(this.btnTim_kiem_hop_dong_vay_Click);
            // 
            // txtMa_hd_vay
            // 
            this.txtMa_hd_vay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_hd_vay.Location = new System.Drawing.Point(666, 22);
            this.txtMa_hd_vay.Name = "txtMa_hd_vay";
            this.txtMa_hd_vay.ReadOnly = true;
            this.txtMa_hd_vay.Size = new System.Drawing.Size(266, 23);
            this.txtMa_hd_vay.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(535, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã hợp đồng vay";
            // 
            // cboxChi_nhanh
            // 
            this.cboxChi_nhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxChi_nhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxChi_nhanh.FormattingEnabled = true;
            this.cboxChi_nhanh.Location = new System.Drawing.Point(246, 21);
            this.cboxChi_nhanh.Margin = new System.Windows.Forms.Padding(2);
            this.cboxChi_nhanh.Name = "cboxChi_nhanh";
            this.cboxChi_nhanh.Size = new System.Drawing.Size(285, 24);
            this.cboxChi_nhanh.TabIndex = 2;
            this.cboxChi_nhanh.SelectedIndexChanged += new System.EventHandler(this.cboxChi_nhanh_SelectedIndexChanged);
            // 
            // txtma_CN
            // 
            this.txtma_CN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtma_CN.Location = new System.Drawing.Point(161, 22);
            this.txtma_CN.Name = "txtma_CN";
            this.txtma_CN.ReadOnly = true;
            this.txtma_CN.Size = new System.Drawing.Size(70, 23);
            this.txtma_CN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi nhánh";
            // 
            // tabHo_so_vay
            // 
            this.tabHo_so_vay.Controls.Add(this.tabHop_dong_tin_dung);
            this.tabHo_so_vay.Controls.Add(this.tabHop_dong_the_chap);
            this.tabHo_so_vay.Controls.Add(this.tabBien_ban_dinh_gia);
            this.tabHo_so_vay.Controls.Add(this.tabDon_the_chap);
            this.tabHo_so_vay.Controls.Add(this.tabDe_xuat_giai_ngan);
            this.tabHo_so_vay.Location = new System.Drawing.Point(6, 67);
            this.tabHo_so_vay.Name = "tabHo_so_vay";
            this.tabHo_so_vay.SelectedIndex = 0;
            this.tabHo_so_vay.Size = new System.Drawing.Size(957, 549);
            this.tabHo_so_vay.TabIndex = 16;
            // 
            // tabHop_dong_tin_dung
            // 
            this.tabHop_dong_tin_dung.Controls.Add(this.btnTao_hop_dong_tin_dung);
            this.tabHop_dong_tin_dung.Controls.Add(this.txtNgay_hop_dong_tin_dung);
            this.tabHop_dong_tin_dung.Controls.Add(this.label4);
            this.tabHop_dong_tin_dung.Controls.Add(this.txtLoai_hop_dong_tin_dung);
            this.tabHop_dong_tin_dung.Controls.Add(this.label3);
            this.tabHop_dong_tin_dung.Location = new System.Drawing.Point(4, 25);
            this.tabHop_dong_tin_dung.Name = "tabHop_dong_tin_dung";
            this.tabHop_dong_tin_dung.Padding = new System.Windows.Forms.Padding(3);
            this.tabHop_dong_tin_dung.Size = new System.Drawing.Size(949, 520);
            this.tabHop_dong_tin_dung.TabIndex = 0;
            this.tabHop_dong_tin_dung.Text = "Hợp đồng tín dụng";
            this.tabHop_dong_tin_dung.UseVisualStyleBackColor = true;
            // 
            // tabHop_dong_the_chap
            // 
            this.tabHop_dong_the_chap.Location = new System.Drawing.Point(4, 25);
            this.tabHop_dong_the_chap.Name = "tabHop_dong_the_chap";
            this.tabHop_dong_the_chap.Padding = new System.Windows.Forms.Padding(3);
            this.tabHop_dong_the_chap.Size = new System.Drawing.Size(946, 481);
            this.tabHop_dong_the_chap.TabIndex = 1;
            this.tabHop_dong_the_chap.Text = "Hợp đồng thế chấp";
            this.tabHop_dong_the_chap.UseVisualStyleBackColor = true;
            // 
            // tabBien_ban_dinh_gia
            // 
            this.tabBien_ban_dinh_gia.Location = new System.Drawing.Point(4, 25);
            this.tabBien_ban_dinh_gia.Name = "tabBien_ban_dinh_gia";
            this.tabBien_ban_dinh_gia.Size = new System.Drawing.Size(946, 481);
            this.tabBien_ban_dinh_gia.TabIndex = 2;
            this.tabBien_ban_dinh_gia.Text = "Biên bản định giá";
            this.tabBien_ban_dinh_gia.UseVisualStyleBackColor = true;
            // 
            // tabDon_the_chap
            // 
            this.tabDon_the_chap.Location = new System.Drawing.Point(4, 25);
            this.tabDon_the_chap.Name = "tabDon_the_chap";
            this.tabDon_the_chap.Size = new System.Drawing.Size(946, 481);
            this.tabDon_the_chap.TabIndex = 3;
            this.tabDon_the_chap.Text = "Đơn thế chấp";
            this.tabDon_the_chap.UseVisualStyleBackColor = true;
            // 
            // tabDe_xuat_giai_ngan
            // 
            this.tabDe_xuat_giai_ngan.Location = new System.Drawing.Point(4, 25);
            this.tabDe_xuat_giai_ngan.Name = "tabDe_xuat_giai_ngan";
            this.tabDe_xuat_giai_ngan.Size = new System.Drawing.Size(946, 481);
            this.tabDe_xuat_giai_ngan.TabIndex = 4;
            this.tabDe_xuat_giai_ngan.Text = "Đề xuất giải ngân";
            this.tabDe_xuat_giai_ngan.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Loại hợp đồng tín dụng";
            // 
            // txtLoai_hop_dong_tin_dung
            // 
            this.txtLoai_hop_dong_tin_dung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoai_hop_dong_tin_dung.Location = new System.Drawing.Point(182, 18);
            this.txtLoai_hop_dong_tin_dung.Name = "txtLoai_hop_dong_tin_dung";
            this.txtLoai_hop_dong_tin_dung.ReadOnly = true;
            this.txtLoai_hop_dong_tin_dung.Size = new System.Drawing.Size(740, 23);
            this.txtLoai_hop_dong_tin_dung.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày hợp đồng tín dụng";
            // 
            // txtNgay_hop_dong_tin_dung
            // 
            this.txtNgay_hop_dong_tin_dung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgay_hop_dong_tin_dung.Location = new System.Drawing.Point(182, 68);
            this.txtNgay_hop_dong_tin_dung.Mask = "00/00/0000";
            this.txtNgay_hop_dong_tin_dung.Name = "txtNgay_hop_dong_tin_dung";
            this.txtNgay_hop_dong_tin_dung.Size = new System.Drawing.Size(90, 23);
            this.txtNgay_hop_dong_tin_dung.TabIndex = 3;
            this.txtNgay_hop_dong_tin_dung.ValidatingType = typeof(System.DateTime);
            // 
            // btnTao_hop_dong_tin_dung
            // 
            this.btnTao_hop_dong_tin_dung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTao_hop_dong_tin_dung.Location = new System.Drawing.Point(9, 118);
            this.btnTao_hop_dong_tin_dung.Name = "btnTao_hop_dong_tin_dung";
            this.btnTao_hop_dong_tin_dung.Size = new System.Drawing.Size(209, 29);
            this.btnTao_hop_dong_tin_dung.TabIndex = 4;
            this.btnTao_hop_dong_tin_dung.Text = "Tạo hợp đồng tín dụng";
            this.btnTao_hop_dong_tin_dung.UseVisualStyleBackColor = true;
            this.btnTao_hop_dong_tin_dung.Click += new System.EventHandler(this.btnTao_hop_dong_tin_dung_Click_1);
            // 
            // frmTao_ho_so_vay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(994, 644);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTao_ho_so_vay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo hồ sơ vay";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabHo_so_vay.ResumeLayout(false);
            this.tabHop_dong_tin_dung.ResumeLayout(false);
            this.tabHop_dong_tin_dung.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtma_CN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxChi_nhanh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMa_hd_vay;
        private System.Windows.Forms.Button btnTim_kiem_hop_dong_vay;
        private System.Windows.Forms.SaveFileDialog savefileTao_hop_dong_the_chap;
        private System.Windows.Forms.SaveFileDialog savefileTao_bien_ban_dinh_gia;
        private System.Windows.Forms.SaveFileDialog savefileTao_don_the_chap;
        private System.Windows.Forms.SaveFileDialog savefileTao_de_xuat_giai_ngan;
        private System.Windows.Forms.TabControl tabHo_so_vay;
        private System.Windows.Forms.TabPage tabHop_dong_tin_dung;
        private System.Windows.Forms.TabPage tabHop_dong_the_chap;
        private System.Windows.Forms.TabPage tabBien_ban_dinh_gia;
        private System.Windows.Forms.TabPage tabDon_the_chap;
        private System.Windows.Forms.TabPage tabDe_xuat_giai_ngan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoai_hop_dong_tin_dung;
        private System.Windows.Forms.MaskedTextBox txtNgay_hop_dong_tin_dung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTao_hop_dong_tin_dung;
        private System.Windows.Forms.SaveFileDialog savefileTao_hop_dong_tin_dung;
    }
}