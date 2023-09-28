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

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                this.BackColor = colorDialog1.Color;
                statlbl.Text = "Цвет Изменен";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файлы изображений(*.jpeg ; *.jpg; *.gif; *.bmp)| *.jpeg ; *.jpg; *.gif; *.bmp ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                statlbl.Text = "Открыто изображение";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String lbl1 = textBox1.Text;
            String lbl2 = textBox2.Text;
            TextWriter tw = new StreamWriter("ctx.txt");
            tw.WriteLine(lbl1);
            tw.WriteLine(lbl2);
            tw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextReader tr = new StreamReader("ctx.txt");
            String lbl1 = tr.ReadLine();
            String lbl2 = tr.ReadLine();
            textBox1.Text = lbl1;
            textBox2.Text = lbl2;
        }
    }
}
