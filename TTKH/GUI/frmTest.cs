using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Novacode;
using AGRIBANKHD.BUS;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;
using AGRIBANKHD.Utilities;
using System.IO;

namespace AGRIBANKHD.GUI
{
    public partial class frmTest : Form
    {
        private List<string> nguon_thong_tin_chung = new List<string>();

        private List<string> dich_thong_tin_chung = new List<string>();

        rtbcontentBUS rtbbus = new rtbcontentBUS();
        public frmTest()
        {
            InitializeComponent();
            maskedTextBox1.Text = "";
            //MessageBox.Show(Convert.ToString(richTextBox1.Lines.Count()));
            //richTextBox1.Find("Cộng hòa xã hội chủ nghĩa");
            //richTextBox1.SelectAll();
            //richTextBox1.SelectionProtected = true;
            // Loop over each line
            for (int i = 0; i < rtbbds_thong_tin_chung.Lines.Count(); i++)
            {
                //Current line text
                string currentLine = rtbbds_thong_tin_chung.Lines[i];
                //MessageBox.Show(currentLine);
                //MessageBox.Show(Convert.ToString(richTextBox1.GetFirstCharIndexFromLine(i)));
                //MessageBox.Show("Index của dòng thứ "+Convert.ToString(i)+":"+Convert.ToString(currentLine.LastIndexOf(":")));
                // Ignore the non-assembly lines
                //if (currentLine.Substring(0, 2) != ";;")
                //{
                    // Start position
                    //int start = (richTextBox1.GetFirstCharIndexFromLine(i) + currentLine.LastIndexOf(";") + 1);
                    int start = (rtbbds_thong_tin_chung.GetFirstCharIndexFromLine(i));

                    // Length
                    //int length = currentLine.Substring(currentLine.LastIndexOf(";"), (currentLine.Length - (currentLine.LastIndexOf(";")))).Length;
                    int length = currentLine.Substring(0,currentLine.LastIndexOf(":")+2).Length;
                    //int length = currentLine.Substring(0, currentLine.LastIndexOf(":") + 2).Length;
                    //int length = currentLine.Length;
                    //MessageBox.Show(Convert.ToString(length)+"&"+Convert.ToString(currentLine.Length));

                    //MessageBox.Show(Convert.ToString(currentLine.LastIndexOf(":")));

                    // Make the selection
                    rtbbds_thong_tin_chung.SelectionStart = start;
                    rtbbds_thong_tin_chung.SelectionLength = length;

                    // Change the colour
                    rtbbds_thong_tin_chung.SelectionColor = Color.Blue;
                    rtbbds_thong_tin_chung.SelectionProtected = true;
                //}
            }

            for (int i = 0; i < rtbbds_ctxd_thong_tin_chung.Lines.Count(); i++)
            {
                string currentLine = rtbbds_ctxd_thong_tin_chung.Lines[i];
                int start = (rtbbds_ctxd_thong_tin_chung.GetFirstCharIndexFromLine(i));
                int length = currentLine.Substring(0, currentLine.LastIndexOf(":") + 2).Length;
                rtbbds_ctxd_thong_tin_chung.SelectionStart = start;
                rtbbds_ctxd_thong_tin_chung.SelectionLength = length;
                rtbbds_ctxd_thong_tin_chung.SelectionColor = Color.Blue;
                rtbbds_ctxd_thong_tin_chung.SelectionProtected = true;
            }

            for (int i = 0; i < rtbbds_nha_thong_tin_chung.Lines.Count(); i++)
            {
                string currentLine = rtbbds_nha_thong_tin_chung.Lines[i];
                int start = (rtbbds_nha_thong_tin_chung.GetFirstCharIndexFromLine(i));
                int length = currentLine.Substring(0, currentLine.LastIndexOf(":") + 2).Length;
                rtbbds_nha_thong_tin_chung.SelectionStart = start;
                rtbbds_nha_thong_tin_chung.SelectionLength = length;
                rtbbds_nha_thong_tin_chung.SelectionColor = Color.Blue;
                rtbbds_nha_thong_tin_chung.SelectionProtected = true;
            }

            for (int i = 0; i < rtbds_thong_tin_chung.Lines.Count(); i++)
            {
                string currentLine = rtbds_thong_tin_chung.Lines[i];
                int start = (rtbds_thong_tin_chung.GetFirstCharIndexFromLine(i));
                int length = currentLine.Substring(0, currentLine.LastIndexOf(":") + 2).Length;
                rtbds_thong_tin_chung.SelectionStart = start;
                rtbds_thong_tin_chung.SelectionLength = length;
                rtbds_thong_tin_chung.SelectionColor = Color.Blue;
                rtbds_thong_tin_chung.SelectionProtected = true;
            }
            
            //richTextBox2.Rtf = richTextBox1.Rtf;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string rtfText = this.richTextBox1.Rtf;
            // process formatted RTF text - i.e. save to database etc.
            // ...
            // reload formatted RTF text
            //this.richTextBox2.Rtf = rtfText;
            //if (maskedTextBox1.Text == "  /  /")
            //{
            //    MessageBox.Show("Rong");
            //}
            //else
            //{
            //    MessageBox.Show(maskedTextBox1.Text);
            //}
            //string currentLine = "";
            //for (int i = 0; i < richTextBox1.Lines.Count(); i++)
            //{
            //    currentLine = currentLine + richTextBox1.Lines[i] + "\n";               
            //}
            
            string[] thong_tin_rtb = new string[10];
            //thong_tin_rtb[0] = rtbid.Rtf;
            thong_tin_rtb[1] = rtbbds_thong_tin_chung.Rtf;
            thong_tin_rtb[2] = rtbbds_giay_to.Rtf;
            thong_tin_rtb[3] = rtbbds_nha_thong_tin_chung.Rtf;
            thong_tin_rtb[4] = rtbbds_ctxd_thong_tin_chung.Rtf;
            thong_tin_rtb[5] = rtbbds_tsgl_khac_thong_tin_chung.Rtf;
            thong_tin_rtb[6] = rtbds_thong_tin_chung.Rtf;
            thong_tin_rtb[7] = rtbds_giay_to.Rtf;
            thong_tin_rtb[8] = rtbtstc_khac_thong_tin_chung.Rtf;
            thong_tin_rtb[9] = rtbtstc_khac_giay_to.Rtf;

            //MessageBox.Show(rtfText);
            //this.nguon_thong_tin_chung.Add("<TEST1>");
            //this.dich_thong_tin_chung.Add(rtfText);
            RtbContent rtb = new RtbContent(thong_tin_rtb);
            if (rtbbus.Them_RTB_CONTENT(rtb))
            {
                MessageBox.Show("Nhập thông tin thành công!");
                this.Close();
            }
            else MessageBox.Show("Có lỗi xảy ra!");

            

            //saveFileDialog1.Filter = "Word Documents|*.docx";
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"TEST\TEST.docx");
            //    CommonMethods.CreateWordDocument(TemplateFileLocation, saveFileDialog1.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung);
            //    MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFileDialog1.FileName, "Tạo file thành công");
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(rtbbds_thong_tin_chung.Lines.Count()));
            string currentLine = "";
            for (int i = 0; i < rtbbds_thong_tin_chung.Lines.Count(); i++)
            {
                currentLine = currentLine + rtbbds_thong_tin_chung.Lines[i] + "\n";
            }
            currentLine = currentLine.Substring(0, currentLine.Length - 1);
            string[] tokens = currentLine.Split(new[] { "\n" }, StringSplitOptions.None);
            //foreach (string substr in tokens)
            //{
            //    MessageBox.Show(substr);
            //}
            int index1 = tokens[2].IndexOf(" thửa đất");
            string newtoken = tokens[2].Remove(index1,9);
            //MessageBox.Show(tokens[2].Remove(index1, 9));
            MessageBox.Show(Convert.ToString(tokens.Length));
            for (int i = 3; i <= 4; i++)
            {
                MessageBox.Show(Convert.ToString(i));
            }
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.Control == true & e.KeyCode == Keys.Enter)
            //// User Pushed Enter Key and Control, 
            //// We don't want the body of Rich TextBox to capture the new line 
            //// and need to remove the new line somehow. 
            //// However only when Control and Enter are pushed at the same time. 
            //{
            //    //Some Function here to remove the extra line made by Enter Key
            //    //msg.Body = richTextBox1.Text;
            //    richTextBox1.Text = "";
            //}
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable ds_rtb_content = rtbcontentBUS.tbl_RTB_CONTENT();
            DataRow row = ds_rtb_content.Rows[0];
            MessageBox.Show(row["RTF_BDS_QSD_DAT"].ToString());
            rtbbds_giay_to.Rtf = row["RTF_BDS_QSD_DAT"].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rtbbds_thong_tin_chung.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Decimal s1 = Convert.ToDecimal(txtDecimal.Text);
            Int64 s2 = Convert.ToInt64(txtInt64.Text);
            Decimal s3 = s1 * s2;
            txtKetqua.Text = Convert.ToString(s3);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            MessageBox.Show(appPath);
            MessageBox.Show(CommonMethods.TemplateFileLocation(@"DTC\DTC_CA_NHAN_BDS.docx"));
            MessageBox.Show(Path.GetDirectoryName(Application.ExecutablePath) + @"\Word_template\" + @"DTC\DTC_CA_NHAN_BDS.docx");
        }

        //private void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        //{
        //    // This event is raised when the enclosing window is closed.
        //    // ... We show a MessageBox that details the DateTime.
        //    DateTime value = (DateTime)e.ReturnValue;
        //    MessageBox.Show("Validated: " + value.ToLongDateString());
        //}
    }
}
