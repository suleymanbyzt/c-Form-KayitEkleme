using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7Kasim1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            verioku();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("defter.txt",FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(textBox1.Text + ":" + textBox2.Text);

            sw.Close();
            fs.Close();
            textBox1.ResetText();
            textBox2.ResetText();
            verioku();
        }
       private void verioku()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            string[] veriler = File.ReadAllLines("defter.txt");
            for (int i = 0; i < veriler.Length; i++)
            {
                if (veriler[i].Length>0)
                {
                    char[] ch = { ':' };

                    string[] parca = veriler[i].Split(ch, StringSplitOptions.RemoveEmptyEntries);

                    if (parca.Length==2)
                    {
                        listBox1.Items.Add(parca[0].ToString());
                        listBox2.Items.Add(parca[1].ToString());
                    }
                }
            }

        }

       private void button2_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void Form1_Load(object sender, EventArgs e)
       {

       }

       private void textBox1_TextChanged(object sender, EventArgs e)
       {
           if (textBox1.Text.Length>=2 && textBox2.Text.Length==11)
           {
               button1.Enabled = true;
           }
           else
           {
               button1.Enabled = false;
           }
       }

       private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
       {
           listBox2.SelectedIndex = listBox1.SelectedIndex;
       }

       private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
       {
           listBox1.SelectedIndex = listBox2.SelectedIndex;
       }
    }
}
