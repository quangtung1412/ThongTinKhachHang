namespace AGRIBANKHD.GUI
{
    partial class frmKhai_bao_diem_giao_dich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhai_bao_diem_giao_dich));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvDanh_sach_diem_giao_dich = new System.Windows.Forms.DataGridView();
            this.cboxChi_nhanh = new System.Windows.Forms.ComboBox();
            this.txtma_CN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.savefileTao_hop_dong_tin_dung = new System.Windows.Forms.SaveFileDialog();
            this.savefileTao_hop_dong_the_chap = new System.Windows.Forms.SaveFileDialog();
            this.savefileTao_don_the_chap = new System.Windows.Forms.SaveFileDialog();
            this.savefileTao_bien_ban_dinh_gia = new System.Windows.Forms.SaveFileDialog();
            this.savefileTao_hop_dong_the_chap_2_ben = new System.Windows.Forms.SaveFileDialog();
            this.savefileTao_xoa_the_chap = new System.Windows.Forms.SaveFileDialog();
            this.savefileTao_de_nghi_the_chap_TSBD = new System.Windows.Forms.SaveFileDialog();
            this.savefileTao_phieu_nhap_kho = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxHe_thong_ung_dung = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanh_sach_diem_giao_dich)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboxHe_thong_ung_dung);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.dgvDanh_sach_diem_giao_dich);
            this.groupBox1.Controls.Add(this.cboxChi_nhanh);
            this.groupBox1.Controls.Add(this.txtma_CN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(969, 622);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khai báo điểm giao dịch";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(828, 584);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(128, 32);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click_1);
            // 
            // dgvDanh_sach_diem_giao_dich
            // 
            this.dgvDanh_sach_diem_giao_dich.AllowUserToAddRows = false;
            this.dgvDanh_sach_diem_giao_dich.AllowUserToDeleteRows = false;
            this.dgvDanh_sach_diem_giao_dich.AllowUserToResizeColumns = false;
            this.dgvDanh_sach_diem_giao_dich.AllowUserToResizeRows = false;
            this.dgvDanh_sach_diem_giao_dich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanh_sach_diem_giao_dich.Location = new System.Drawing.Point(6, 424);
            this.dgvDanh_sach_diem_giao_dich.Name = "dgvDanh_sach_diem_giao_dich";
            this.dgvDanh_sach_diem_giao_dich.ReadOnly = true;
            this.dgvDanh_sach_diem_giao_dich.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanh_sach_diem_giao_dich.Size = new System.Drawing.Size(957, 154);
            this.dgvDanh_sach_diem_giao_dich.TabIndex = 5;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Hệ thống";
            // 
            // cboxHe_thong_ung_dung
            // 
            this.cboxHe_thong_ung_dung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHe_thong_ung_dung.FormattingEnabled = true;
            this.cboxHe_thong_ung_dung.Location = new System.Drawing.Point(161, 70);
            this.cboxHe_thong_ung_dung.Name = "cboxHe_thong_ung_dung";
            this.cboxHe_thong_ung_dung.Size = new System.Drawing.Size(121, 24);
            this.cboxHe_thong_ung_dung.TabIndex = 19;
            // 
            // frmKhai_bao_diem_giao_dich
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(994, 644);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKhai_bao_diem_giao_dich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo điểm giao dịch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanh_sach_diem_giao_dich)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtma_CN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxChi_nhanh;
        private System.Windows.Forms.SaveFileDialog savefileTao_hop_dong_tin_dung;
        private System.Windows.Forms.DataGridView dgvDanh_sach_diem_giao_dich;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.SaveFileDialog savefileTao_hop_dong_the_chap;
        private System.Windows.Forms.SaveFileDialog savefileTao_don_the_chap;
        private System.Windows.Forms.SaveFileDialog savefileTao_bien_ban_dinh_gia;
        private System.Windows.Forms.SaveFileDialog savefileTao_hop_dong_the_chap_2_ben;
        private System.Windows.Forms.SaveFileDialog savefileTao_xoa_the_chap;
        private System.Windows.Forms.SaveFileDialog savefileTao_de_nghi_the_chap_TSBD;
        private System.Windows.Forms.SaveFileDialog savefileTao_phieu_nhap_kho;
        private System.Windows.Forms.ComboBox cboxHe_thong_ung_dung;
        private System.Windows.Forms.Label label2;
    }
}