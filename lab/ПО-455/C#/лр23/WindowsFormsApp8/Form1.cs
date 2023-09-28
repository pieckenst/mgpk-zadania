using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
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
            int formul = trackBar1.Value * trackBar1.Value / 2 * int.Parse(textBox2.Text);

            string resulset = formul.ToString();
            textBox3.Text = resulset;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int formul = int.Parse(textBox1.Text)  *int.Parse(textBox2.Text)* trackBar1.Value;

            string resulset = formul.ToString();
            textBox3.Text = resulset;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int formul = int.Parse(textBox1.Text) *  trackBar1.Value;

            string resulset = formul.ToString();
            textBox3.Text = resulset;
        }
    }
}
