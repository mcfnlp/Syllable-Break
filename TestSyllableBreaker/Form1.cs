using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TestSyllableBreaker
{
    public partial class Form1 : Form
    {
        //MMNLPTeam.SyllableCluster syllableBreaker;
        SyllableCluster syllableBreaker;

        public Form1()
        {
            InitializeComponent();
            syllableBreaker = new SyllableCluster();
        }

        private void button1_Click(object sender, EventArgs e)
        {//syllableBreaker.OrthographicBreaker
            String inputTxt = textBox1.Text;
           // string[] strarr = syllableBreaker.GetPhonoArray(inputTxt);
            //String[] outputSbl = syllableBreaker.GetOrthoArray(inputTxt);            
            //foreach (String s in outputSbl)
            //{
            //    textBox2.Text += s + "+";
            //}
            //inputTxt = inputTxt.Replace("့်","့်");
            String output = syllableBreaker.OrthographicBreaker(inputTxt, '+');
            String op = syllableBreaker.PhonologicalBreaker(inputTxt, '+');
            textBox2.Text = output;
            textBox3.Text = op;
        }
StringBuilder InStrBil = new StringBuilder();
        private void btnOpen_Click(object sender, EventArgs e)
        {
            
            // string readstring = string.Empty; int i = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOpenFilePath.Text = openFileDialog1.FileName;
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                InStrBil.Append(sr.ReadToEnd()); 
                //InStrBil = InStrBil.Replace("\r\n", "\n");
                //InStrBil = InStrBil.Replace("့်", "့်");
                //while((readstring=sr.ReadLine())!=null)
                //{
                //    InStrArray[i] = readstring;
                //    i++;
                //}
                //ForSyllable(StrBil);
                //ForWord(StrBil);
                sr.Close();
                fs.Close();
            }
        }

        private void btnSaveSyllable_Click(object sender, EventArgs e)
        {
            if (txtOpenFilePath.Text == "")
            {
                MessageBox.Show("Please Open File!");
            }
                else if(radiobtnOrtho.Checked==false && radiobtnPhono.Checked==false)
            {
                MessageBox.Show("Please Check Break Option!");
                radiobtnPhono.ForeColor = Color.Red;
                radiobtnOrtho.ForeColor = Color.Red;
                }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    picBoxLoading.Visible = true;
                    toolStripLblSuccess.Visible = false;
                    txtSaveSyllable.Text = saveFileDialog1.FileName;
                    StringBuilder Outstrbil = new StringBuilder();
                    if (radiobtnOrtho.Checked == true)
                    {
                       Outstrbil.Append(syllableBreaker.OrthographicBreaker(InStrBil.ToString()));
                    }
                    else
                    {
                        Outstrbil.Append(syllableBreaker.PhonologicalBreaker(InStrBil.ToString()));
                    }
             Outstrbil = Outstrbil.Replace('\u200B', ' ');
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    sw.WriteLine(Outstrbil);
                    sw.Close();
                    picBoxLoading.Visible = false;
                    toolStripLblSuccess.Text = "Successfully Finished!";
                    toolStripLblSuccess.Visible = true;
                    //lblSyllableCount.Text = fqc.ForSyllable(InStrBil, saveFileDialog1.FileName);
                    //lblStatus.Text = "Successfully Save Syllable Count File!";
                }
            }
        }

        private void radiobtnPhono_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnPhono.ForeColor == Color.Red && radiobtnOrtho.ForeColor==Color.Red)
            {
                radiobtnOrtho.ForeColor = Color.Black;
                radiobtnPhono.ForeColor = Color.Black;
            }

        }

        private void radiobtnOrtho_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnPhono.ForeColor == Color.Red && radiobtnOrtho.ForeColor == Color.Red)
            {
                radiobtnOrtho.ForeColor = Color.Black;
                radiobtnPhono.ForeColor = Color.Black;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
