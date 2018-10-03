using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OpenSave_Parity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] lines;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/SHine221B");
        }

        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void infoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 Window2 = new Form2();
            Window2.ShowDialog();
        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    sw.Write(textBox1.Text + " " + textBox2.Text + '\n');
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    lines = File.ReadAllLines(openFileDialog1.FileName);
                    foreach (string line in lines)
                        textBox1.AppendText(line + '\n');
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Form1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void runToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                int number;
                foreach (string line in lines)
                {
                    number = Convert.ToInt32(line);

                    if (number % 2 == 0)
                    {
                        textBox2.AppendText("Yes" + '\n');
                    }
                    else
                    {
                        textBox2.AppendText("No" + '\n');
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Form1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
