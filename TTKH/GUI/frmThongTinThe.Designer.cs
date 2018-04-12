namespace AGRIBANKHD.GUI
{
    partial class frmThongTinThe
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongTinThe));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cRMDataSet = new AGRIBANKHD.CRMDataSet();
            this.tHEODOITHEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tHEODOITHETableAdapter = new AGRIBANKHD.CRMDataSetTableAdapters.THEODOITHETableAdapter();
            this.kHACHHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kHACHHANGTableAdapter = new AGRIBANKHD.CRMDataSetTableAdapters.KHACHHANGTableAdapter();
            this.tHEODOITHEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tHEODOITHEBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tHEODOITHEBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.tHEODOITHEBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.tHEODOITHEBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.tHEODOITHEBindingSource6 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRMDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHACHHANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource6)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 206);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thẻ";
            // 
            // textBox7
            // 
            this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tHEODOITHEBindingSource6, "HINHTHUCNHANTHE", true));
            this.textBox7.Location = new System.Drawing.Point(163, 175);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(133, 20);
            this.textBox7.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Hình thức nhận thẻ:";
            // 
            // textBox6
            // 
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tHEODOITHEBindingSource5, "HINHTHUCPHATHANH", true));
            this.textBox6.Location = new System.Drawing.Point(163, 149);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(133, 20);
            this.textBox6.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Hình thức phát hành:";
            // 
            // textBox5
            // 
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tHEODOITHEBindingSource4, "HANGTHE", true));
            this.textBox5.Location = new System.Drawing.Point(163, 123);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(133, 20);
            this.textBox5.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Hạng thẻ:";
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tHEODOITHEBindingSource3, "LOAITHE", true));
            this.textBox4.Location = new System.Drawing.Point(163, 97);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(133, 20);
            this.textBox4.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Loại thẻ:";
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tHEODOITHEBindingSource2, "SOTHE", true));
            this.textBox3.Location = new System.Drawing.Point(163, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(133, 20);
            this.textBox3.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Số thẻ:";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tHEODOITHEBindingSource1, "SOTK", true));
            this.textBox2.Location = new System.Drawing.Point(163, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(133, 20);
            this.textBox2.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Số tài khoản:";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.kHACHHANGBindingSource, "HOTEN", true));
            this.textBox1.Location = new System.Drawing.Point(163, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 20);
            this.textBox1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Họ tên:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(13, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 99);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dịch vụ";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(19, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "SMS Banking";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(163, 18);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(133, 20);
            this.textBox8.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(116, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "ĐTDĐ:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(116, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "HMGD:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(163, 44);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(133, 20);
            this.textBox9.TabIndex = 32;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.Location = new System.Drawing.Point(6, 46);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 17);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.Text = "Internet Banking";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox3.Location = new System.Drawing.Point(40, 69);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(70, 17);
            this.checkBox3.TabIndex = 34;
            this.checkBox3.Text = "Bảo hiểm";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(121, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 28);
            this.button1.TabIndex = 20;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cRMDataSet
            // 
            this.cRMDataSet.DataSetName = "CRMDataSet";
            this.cRMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tHEODOITHEBindingSource
            // 
            this.tHEODOITHEBindingSource.DataMember = "THEODOITHE";
            this.tHEODOITHEBindingSource.DataSource = this.cRMDataSet;
            // 
            // tHEODOITHETableAdapter
            // 
            this.tHEODOITHETableAdapter.ClearBeforeFill = true;
            // 
            // kHACHHANGBindingSource
            // 
            this.kHACHHANGBindingSource.DataMember = "KHACHHANG";
            this.kHACHHANGBindingSource.DataSource = this.cRMDataSet;
            // 
            // kHACHHANGTableAdapter
            // 
            this.kHACHHANGTableAdapter.ClearBeforeFill = true;
            // 
            // tHEODOITHEBindingSource1
            // 
            this.tHEODOITHEBindingSource1.DataMember = "THEODOITHE";
            this.tHEODOITHEBindingSource1.DataSource = this.cRMDataSet;
            // 
            // tHEODOITHEBindingSource2
            // 
            this.tHEODOITHEBindingSource2.DataMember = "THEODOITHE";
            this.tHEODOITHEBindingSource2.DataSource = this.cRMDataSet;
            // 
            // tHEODOITHEBindingSource3
            // 
            this.tHEODOITHEBindingSource3.DataMember = "THEODOITHE";
            this.tHEODOITHEBindingSource3.DataSource = this.cRMDataSet;
            // 
            // tHEODOITHEBindingSource4
            // 
            this.tHEODOITHEBindingSource4.DataMember = "THEODOITHE";
            this.tHEODOITHEBindingSource4.DataSource = this.cRMDataSet;
            // 
            // tHEODOITHEBindingSource5
            // 
            this.tHEODOITHEBindingSource5.DataMember = "THEODOITHE";
            this.tHEODOITHEBindingSource5.DataSource = this.cRMDataSet;
            // 
            // tHEODOITHEBindingSource6
            // 
            this.tHEODOITHEBindingSource6.DataMember = "THEODOITHE";
            this.tHEODOITHEBindingSource6.DataSource = this.cRMDataSet;
            // 
            // frmThongTinThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 376);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmThongTinThe";
            this.Text = "Thông tin thẻ";
            this.Load += new System.EventHandler(this.frmThongTinThe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRMDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHACHHANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHEODOITHEBindingSource6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private CRMDataSet cRMDataSet;
        private System.Windows.Forms.BindingSource tHEODOITHEBindingSource;
        private CRMDataSetTableAdapters.THEODOITHETableAdapter tHEODOITHETableAdapter;
        private System.Windows.Forms.BindingSource kHACHHANGBindingSource;
        private CRMDataSetTableAdapters.KHACHHANGTableAdapter kHACHHANGTableAdapter;
        private System.Windows.Forms.BindingSource tHEODOITHEBindingSource6;
        private System.Windows.Forms.BindingSource tHEODOITHEBindingSource5;
        private System.Windows.Forms.BindingSource tHEODOITHEBindingSource4;
        private System.Windows.Forms.BindingSource tHEODOITHEBindingSource3;
        private System.Windows.Forms.BindingSource tHEODOITHEBindingSource2;
        private System.Windows.Forms.BindingSource tHEODOITHEBindingSource1;

    }
}