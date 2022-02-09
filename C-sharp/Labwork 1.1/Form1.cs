using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labwork_1
{
    public partial class Form1 : Form
    {
        private string path = @"C:\Users\Дима\Desktop\Studying\Labs\Lab.-works.-Basics-of-programming\II term\C-sharp\Labwork 1.1\Files\";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = "0";
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox1.Enabled = false;
            richTextBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Whoever fights monsters should see so that in the process he doesn't become a monster.\n" +
                    "And if you gaze long enough into an abyss, the abyss gaze back to you...";
            using (StreamWriter sourceFile = new StreamWriter(path + "source.txt"))
            {
                sourceFile.Write(textBox1.Text);
            }

            BarTo50();
            textBox1.Enabled = true;
        }

        private void BarTo50()
        {
            progressBar1.Value = 0;
            progressBar1.Value = 50;
            label5.Text = "50%";
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            WriteText();
            progressBar1.Value = 50;
            label5.Text = "50%";
        }
        
        private void WriteText()
        {
            StreamWriter sourceFile = new StreamWriter(path + "source.txt");
            sourceFile.Write(textBox1.Text);
            sourceFile.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (StreamReader first = new StreamReader(path + "source.txt"))
            {
                using (StreamWriter second = new StreamWriter(path + "second.txt"))
                {
                    if (Convert.ToInt32(textBox2.Text) <= 0)
                    {
                        DialogResult message = MessageBox.Show("The length equals to or less than 0.\n Do you want to continue?\n(the text won't change)", "Length exception", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (message == DialogResult.No)
                        {
                            return;
                        }
                    }

                    string text = first.ReadToEnd();
                    text = text.Trim(new char[] { ' ' });
                    
                    
                    List<string> rows = text.Split('\n').ToList();
                    for (int i = 0; i < rows.Count; i++)
                    {
                        rows[i] = FormatToLength(rows[i], Convert.ToInt32(textBox2.Text));
                    }

                    text = string.Join("\n", rows);
                    second.Write(text);
                    richTextBox1.Text = text;
                }
            }
            progressBar1.Value = 50;
            progressBar1.Value = 100;
            label5.Text = "100%";
        }

        private string FormatToLength(string row, int length)
        {
            int i = 0;

            while (row.Length < length && (i = row.IndexOf(" ", i, StringComparison.InvariantCulture)) != -1)
            {
                row = row.Insert(i, " ");
                while (row[i] == ' ') 
                    ++i;
            }

            if (row.Length < length)
            {
                return FormatToLength(row, length);
            }

            return row;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream source = File.Open(path + "source.txt", FileMode.Create);
            source.Close();
            BarTo50();
            textBox1.Clear();
            textBox1.Enabled = true;
        }
    }
}
