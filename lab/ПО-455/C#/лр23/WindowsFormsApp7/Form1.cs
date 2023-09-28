using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            progar.Visible = true;
        }

        private void progar_Click(object sender, EventArgs e)
        {
            progar.Visible = false;
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
            this.Refresh();
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
            this.Refresh();
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
            this.Refresh();
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
            this.Refresh();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0) {
                this.BackColor = Color.Pink;
                this.Refresh();
            }
            else
            {
                this.BackColor = Color.Blue;
                this.Refresh();
            }
        }
    }
}
