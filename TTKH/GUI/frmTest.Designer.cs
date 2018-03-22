namespace AGRIBANKHD.GUI
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rtbbds_thong_tin_chung = new System.Windows.Forms.RichTextBox();
            this.rtbbds_giay_to = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.rtbbds_nha_thong_tin_chung = new System.Windows.Forms.RichTextBox();
            this.rtbbds_ctxd_thong_tin_chung = new System.Windows.Forms.RichTextBox();
            this.rtbbds_tsgl_khac_thong_tin_chung = new System.Windows.Forms.RichTextBox();
            this.rtbds_thong_tin_chung = new System.Windows.Forms.RichTextBox();
            this.rtbds_giay_to = new System.Windows.Forms.RichTextBox();
            this.rtbtstc_khac_thong_tin_chung = new System.Windows.Forms.RichTextBox();
            this.rtbtstc_khac_giay_to = new System.Windows.Forms.RichTextBox();
            this.txtDecimal = new System.Windows.Forms.TextBox();
            this.txtInt64 = new System.Windows.Forms.TextBox();
            this.txtKetqua = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(62, 54);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(76, 20);
            this.maskedTextBox1.TabIndex = 0;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cập nhật";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbbds_thong_tin_chung
            // 
            this.rtbbds_thong_tin_chung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbbds_thong_tin_chung.Location = new System.Drawing.Point(62, 132);
            this.rtbbds_thong_tin_chung.Name = "rtbbds_thong_tin_chung";
            this.rtbbds_thong_tin_chung.Size = new System.Drawing.Size(308, 127);
            this.rtbbds_thong_tin_chung.TabIndex = 2;
            this.rtbbds_thong_tin_chung.Text = "- Thửa đất số: \n- Tờ bản đồ số: \n- Địa chỉ thửa đất: \n- Mục đích sử dụng: Đất ở\n-" +
    " Thời hạn sử dụng: Lâu dài\n- Nguồn gốc sử dụng: \n- Những hạn chế về quyền sử dụn" +
    "g đất: ";
            this.rtbbds_thong_tin_chung.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyUp);
            // 
            // rtbbds_giay_to
            // 
            this.rtbbds_giay_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbbds_giay_to.Location = new System.Drawing.Point(62, 265);
            this.rtbbds_giay_to.Name = "rtbbds_giay_to";
            this.rtbbds_giay_to.Size = new System.Drawing.Size(807, 49);
            this.rtbbds_giay_to.TabIndex = 3;
            this.rtbbds_giay_to.Text = resources.GetString("rtbbds_giay_to.Text");
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 90);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Cap nhat";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(156, 79);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // rtbbds_nha_thong_tin_chung
            // 
            this.rtbbds_nha_thong_tin_chung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbbds_nha_thong_tin_chung.Location = new System.Drawing.Point(406, 132);
            this.rtbbds_nha_thong_tin_chung.Name = "rtbbds_nha_thong_tin_chung";
            this.rtbbds_nha_thong_tin_chung.Size = new System.Drawing.Size(253, 114);
            this.rtbbds_nha_thong_tin_chung.TabIndex = 7;
            this.rtbbds_nha_thong_tin_chung.Text = "+ Diện tích sàn: ...  m2.\n+ Diện tích xây dựng: ... m2.\n+ Kết cấu: ....\n+ Số tầng" +
    ": ...\n+ Cấp (hạng): ....\n+ Năm hoàn thành: ";
            // 
            // rtbbds_ctxd_thong_tin_chung
            // 
            this.rtbbds_ctxd_thong_tin_chung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbbds_ctxd_thong_tin_chung.Location = new System.Drawing.Point(561, 9);
            this.rtbbds_ctxd_thong_tin_chung.Name = "rtbbds_ctxd_thong_tin_chung";
            this.rtbbds_ctxd_thong_tin_chung.Size = new System.Drawing.Size(308, 80);
            this.rtbbds_ctxd_thong_tin_chung.TabIndex = 8;
            this.rtbbds_ctxd_thong_tin_chung.Text = "+ Loại công trình: \n+ Diện tích xây dựng: ...  m2.\n+ Kết cấu: \n+ Số tầng: ";
            // 
            // rtbbds_tsgl_khac_thong_tin_chung
            // 
            this.rtbbds_tsgl_khac_thong_tin_chung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbbds_tsgl_khac_thong_tin_chung.Location = new System.Drawing.Point(277, 12);
            this.rtbbds_tsgl_khac_thong_tin_chung.Name = "rtbbds_tsgl_khac_thong_tin_chung";
            this.rtbbds_tsgl_khac_thong_tin_chung.Size = new System.Drawing.Size(253, 79);
            this.rtbbds_tsgl_khac_thong_tin_chung.TabIndex = 9;
            this.rtbbds_tsgl_khac_thong_tin_chung.Text = "";
            // 
            // rtbds_thong_tin_chung
            // 
            this.rtbds_thong_tin_chung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbds_thong_tin_chung.Location = new System.Drawing.Point(62, 320);
            this.rtbds_thong_tin_chung.Name = "rtbds_thong_tin_chung";
            this.rtbds_thong_tin_chung.Size = new System.Drawing.Size(263, 171);
            this.rtbds_thong_tin_chung.TabIndex = 10;
            this.rtbds_thong_tin_chung.Text = "+ Nhãn hiệu: \n+ Loại xe: \n+ Màu sơn: \n+ Số chỗ ngồi: \n+ Số máy: \n+ Số khung: \n+ S" +
    "ố loại: \n+ Dung tích: \n+ Tải trọng: .... kg\n+ Năm, nước sản xuất: ......";
            // 
            // rtbds_giay_to
            // 
            this.rtbds_giay_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbds_giay_to.Location = new System.Drawing.Point(688, 132);
            this.rtbds_giay_to.Name = "rtbds_giay_to";
            this.rtbds_giay_to.Size = new System.Drawing.Size(100, 96);
            this.rtbds_giay_to.TabIndex = 11;
            this.rtbds_giay_to.Text = "";
            // 
            // rtbtstc_khac_thong_tin_chung
            // 
            this.rtbtstc_khac_thong_tin_chung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbtstc_khac_thong_tin_chung.Location = new System.Drawing.Point(351, 322);
            this.rtbtstc_khac_thong_tin_chung.Name = "rtbtstc_khac_thong_tin_chung";
            this.rtbtstc_khac_thong_tin_chung.Size = new System.Drawing.Size(100, 96);
            this.rtbtstc_khac_thong_tin_chung.TabIndex = 12;
            this.rtbtstc_khac_thong_tin_chung.Text = "";
            // 
            // rtbtstc_khac_giay_to
            // 
            this.rtbtstc_khac_giay_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbtstc_khac_giay_to.Location = new System.Drawing.Point(475, 322);
            this.rtbtstc_khac_giay_to.Name = "rtbtstc_khac_giay_to";
            this.rtbtstc_khac_giay_to.Size = new System.Drawing.Size(100, 96);
            this.rtbtstc_khac_giay_to.TabIndex = 13;
            this.rtbtstc_khac_giay_to.Text = "";
            // 
            // txtDecimal
            // 
            this.txtDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecimal.Location = new System.Drawing.Point(621, 322);
            this.txtDecimal.Name = "txtDecimal";
            this.txtDecimal.Size = new System.Drawing.Size(100, 23);
            this.txtDecimal.TabIndex = 14;
            // 
            // txtInt64
            // 
            this.txtInt64.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInt64.Location = new System.Drawing.Point(621, 366);
            this.txtInt64.Name = "txtInt64";
            this.txtInt64.Size = new System.Drawing.Size(100, 23);
            this.txtInt64.TabIndex = 15;
            // 
            // txtKetqua
            // 
            this.txtKetqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetqua.Location = new System.Drawing.Point(621, 417);
            this.txtKetqua.Name = "txtKetqua";
            this.txtKetqua.Size = new System.Drawing.Size(100, 23);
            this.txtKetqua.TabIndex = 16;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(785, 343);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "Tính toán";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(394, 439);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 18;
            this.button6.Text = "Show path";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 554);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtKetqua);
            this.Controls.Add(this.txtInt64);
            this.Controls.Add(this.txtDecimal);
            this.Controls.Add(this.rtbtstc_khac_giay_to);
            this.Controls.Add(this.rtbtstc_khac_thong_tin_chung);
            this.Controls.Add(this.rtbds_giay_to);
            this.Controls.Add(this.rtbds_thong_tin_chung);
            this.Controls.Add(this.rtbbds_tsgl_khac_thong_tin_chung);
            this.Controls.Add(this.rtbbds_ctxd_thong_tin_chung);
            this.Controls.Add(this.rtbbds_nha_thong_tin_chung);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rtbbds_giay_to);
            this.Controls.Add(this.rtbbds_thong_tin_chung);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.maskedTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtbbds_thong_tin_chung;
        private System.Windows.Forms.RichTextBox rtbbds_giay_to;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox rtbbds_nha_thong_tin_chung;
        private System.Windows.Forms.RichTextBox rtbbds_ctxd_thong_tin_chung;
        private System.Windows.Forms.RichTextBox rtbbds_tsgl_khac_thong_tin_chung;
        private System.Windows.Forms.RichTextBox rtbds_thong_tin_chung;
        private System.Windows.Forms.RichTextBox rtbds_giay_to;
        private System.Windows.Forms.RichTextBox rtbtstc_khac_thong_tin_chung;
        private System.Windows.Forms.RichTextBox rtbtstc_khac_giay_to;
        private System.Windows.Forms.TextBox txtDecimal;
        private System.Windows.Forms.TextBox txtInt64;
        private System.Windows.Forms.TextBox txtKetqua;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}