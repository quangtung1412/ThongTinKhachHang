﻿namespace AGRIBANKHD.GUI
{
    partial class frmTai_san_the_chap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTai_san_the_chap));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTim_kiem_hop_dong_vay = new System.Windows.Forms.Button();
            this.txtMa_hd_vay = new System.Windows.Forms.TextBox();
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
            this.dgvDanh_sach_tstc = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanh_sach_tstc)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTim_kiem_hop_dong_vay);
            this.groupBox1.Controls.Add(this.txtMa_hd_vay);
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
            this.groupBox1.Size = new System.Drawing.Size(969, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiêu chí tìm kiếm";
            // 
            // btnTim_kiem_hop_dong_vay
            // 
            this.btnTim_kiem_hop_dong_vay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim_kiem_hop_dong_vay.Location = new System.Drawing.Point(433, 75);
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
            this.txtMa_hd_vay.Location = new System.Drawing.Point(161, 75);
            this.txtMa_hd_vay.Name = "txtMa_hd_vay";
            this.txtMa_hd_vay.ReadOnly = true;
            this.txtMa_hd_vay.Size = new System.Drawing.Size(266, 23);
            this.txtMa_hd_vay.TabIndex = 14;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(878, 126);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 30);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(787, 126);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(86, 30);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(696, 126);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(86, 30);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(606, 126);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(86, 30);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTim_kiem
            // 
            this.btnTim_kiem.Location = new System.Drawing.Point(516, 126);
            this.btnTim_kiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTim_kiem.Name = "btnTim_kiem";
            this.btnTim_kiem.Size = new System.Drawing.Size(86, 30);
            this.btnTim_kiem.TabIndex = 9;
            this.btnTim_kiem.Text = "Tìm kiếm";
            this.btnTim_kiem.UseVisualStyleBackColor = true;
            this.btnTim_kiem.Click += new System.EventHandler(this.btnTim_kiem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 81);
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
            this.cboxChi_nhanh.Location = new System.Drawing.Point(246, 37);
            this.cboxChi_nhanh.Margin = new System.Windows.Forms.Padding(2);
            this.cboxChi_nhanh.Name = "cboxChi_nhanh";
            this.cboxChi_nhanh.Size = new System.Drawing.Size(212, 24);
            this.cboxChi_nhanh.TabIndex = 2;
            this.cboxChi_nhanh.SelectedIndexChanged += new System.EventHandler(this.cboxChi_nhanh_SelectedIndexChanged);
            // 
            // txtma_CN
            // 
            this.txtma_CN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtma_CN.Location = new System.Drawing.Point(161, 38);
            this.txtma_CN.Name = "txtma_CN";
            this.txtma_CN.ReadOnly = true;
            this.txtma_CN.Size = new System.Drawing.Size(70, 23);
            this.txtma_CN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi nhánh";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDanh_sach_tstc);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 197);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(969, 467);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách tài sản thế chấp";
            // 
            // dgvDanh_sach_tstc
            // 
            this.dgvDanh_sach_tstc.AllowUserToAddRows = false;
            this.dgvDanh_sach_tstc.AllowUserToDeleteRows = false;
            this.dgvDanh_sach_tstc.AllowUserToResizeColumns = false;
            this.dgvDanh_sach_tstc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanh_sach_tstc.Location = new System.Drawing.Point(6, 20);
            this.dgvDanh_sach_tstc.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDanh_sach_tstc.MultiSelect = false;
            this.dgvDanh_sach_tstc.Name = "dgvDanh_sach_tstc";
            this.dgvDanh_sach_tstc.ReadOnly = true;
            this.dgvDanh_sach_tstc.RowTemplate.Height = 24;
            this.dgvDanh_sach_tstc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanh_sach_tstc.Size = new System.Drawing.Size(959, 443);
            this.dgvDanh_sach_tstc.TabIndex = 0;
            // 
            // frmTai_san_the_chap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(994, 675);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTai_san_the_chap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tài sản thế chấp";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanh_sach_tstc)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvDanh_sach_tstc;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtMa_hd_vay;
        private System.Windows.Forms.Button btnTim_kiem_hop_dong_vay;
    }
}