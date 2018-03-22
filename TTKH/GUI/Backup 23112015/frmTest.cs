using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGRIBANKHD.Utilities;
using Novacode;

namespace AGRIBANKHD.GUI
{
    public partial class frmTest : Form
    {
        private List<string> nguon_thong_tin_chung = new List<string>();

        private List<string> dich_thong_tin_chung = new List<string>();
        public frmTest()
        {
            InitializeComponent();
            maskedTextBox1.Text = "";
            //MessageBox.Show(Convert.ToString(richTextBox1.Lines.Count()));
            //richTextBox1.Find("Cộng hòa xã hội chủ nghĩa");
            //richTextBox1.SelectAll();
            //richTextBox1.SelectionProtected = true;
            // Loop over each line
            for (int i = 0; i < richTextBox1.Lines.Count(); i++)
            {
                //Current line text
                string currentLine = richTextBox1.Lines[i];
                //MessageBox.Show(currentLine);
                //MessageBox.Show(Convert.ToString(richTextBox1.GetFirstCharIndexFromLine(i)));
                //MessageBox.Show("Index của dòng thứ "+Convert.ToString(i)+":"+Convert.ToString(currentLine.LastIndexOf(":")));
                // Ignore the non-assembly lines
                //if (currentLine.Substring(0, 2) != ";;")
                //{
                    // Start position
                    //int start = (richTextBox1.GetFirstCharIndexFromLine(i) + currentLine.LastIndexOf(";") + 1);
                    int start = (richTextBox1.GetFirstCharIndexFromLine(i));

                    // Length
                    //int length = currentLine.Substring(currentLine.LastIndexOf(";"), (currentLine.Length - (currentLine.LastIndexOf(";")))).Length;
                    int length = currentLine.Substring(0,currentLine.LastIndexOf(":")+2).Length;
                    //MessageBox.Show(Convert.ToString(length)+"&"+Convert.ToString(currentLine.Length));

                    //MessageBox.Show(Convert.ToString(currentLine.LastIndexOf(":")));

                    // Make the selection
                    richTextBox1.SelectionStart = start;
                    richTextBox1.SelectionLength = length;

                    // Change the colour
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.SelectionProtected = true;
                //}
            }
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
            string currentLine = "";
            for (int i = 0; i < richTextBox1.Lines.Count(); i++)
            {
                currentLine = currentLine + richTextBox1.Lines[i] + "\n";               
            }
            //string rtfText = this.richTextBox1.Rtf;
            this.nguon_thong_tin_chung.Add("<TEST1>");
            this.dich_thong_tin_chung.Add(currentLine);

            

            saveFileDialog1.Filter = "Word Documents|*.docx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string TemplateFileLocation = CommonMethods.TemplateFileLocation(@"TEST\TEST.docx");
                CommonMethods.CreateWordDocument(TemplateFileLocation, saveFileDialog1.FileName, this.nguon_thong_tin_chung, this.dich_thong_tin_chung);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFileDialog1.FileName, "Tạo file thành công");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(richTextBox1.Lines.Count()));
            string currentLine = "";
            for (int i = 0; i < richTextBox1.Lines.Count(); i++)
            {
                currentLine = currentLine + richTextBox1.Lines[i] + "\n";
            }
            currentLine = currentLine.Substring(0, currentLine.Length - 1);
            string[] tokens = currentLine.Split(new[] { "\n" }, StringSplitOptions.None);
            foreach (string substr in tokens)
            {
                MessageBox.Show(substr);
            }
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
