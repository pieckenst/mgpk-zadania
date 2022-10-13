using Bevel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bevel;
using BevelStyle = ClassLibrary1.BevelStyle;
using BevelType = ClassLibrary1.BevelType;

namespace BevelWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool red = false;
        public bool black = false;
        public bool white = false;
        private void bevelControl1_Click(object sender, EventArgs e)
        {

            if (red == true)
            {
                bevelControl1.BackColor = Color.Red;
                bevelControl1.Refresh();
            }
            else if (black == true)
            {
                bevelControl1.BackColor = Color.Black;
                bevelControl1.Refresh();
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            red = true;
            bevelControl1.BackColor = Color.Red;
            bevelControl1.Refresh();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            black = true;
            bevelControl1.BackColor = Color.Black;
            bevelControl1.Refresh();
        }

        private void rd2_Click(object sender, EventArgs e)
        {
            white = true;
            bevelControl1.BackColor = Color.White;
            bevelControl1.Refresh();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bevelControl1.BevelStyle = BevelStyle.Raised;
            bevelControl1.Refresh();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bevelControl1.BevelStyle = BevelStyle.Lowered;
            bevelControl1.Refresh();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            bevelControl1.BevelType = BevelType.Box;
            bevelControl1.Refresh();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            bevelControl1.BevelType = BevelType.Frame;
            bevelControl1.Refresh();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            bevelControl1.BevelType = BevelType.TopLine;
            bevelControl1.Refresh();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            bevelControl1.BevelType = BevelType.BottomLine;
            bevelControl1.Refresh();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            bevelControl1.BevelType = BevelType.LeftLine;
            bevelControl1.Refresh();
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            bevelControl1.BevelType = BevelType.RightLine;
            bevelControl1.Refresh();
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            bevelControl1.BevelType = BevelType.Spacer;
            bevelControl1.Refresh();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;
            label1.ForeColor = Color.White;
            label1.Refresh();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label1.BackColor = Color.Black;
            label1.ForeColor = Color.White;
            label1.Refresh();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Black;
            label1.Refresh();
        }
    }
}
