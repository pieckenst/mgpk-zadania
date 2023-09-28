using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
       
        
        int count = 0;
        int size = 20;
        TextBox texBox = new TextBox();
        public Form1()
        {

            this.Size = new Size(400, 250);
            this.Paint += new PaintEventHandler(Form1_Paint);
            texBox.Parent = this;
            texBox.Bounds = new Rectangle(5, 5, 60, 20);
            texBox.TextChanged += new EventHandler(texBox_TextChanged);

        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < count; i++)
                Draw(e.Graphics, 20 * i, 40);
        }
        void Draw(Graphics g, int x, int y)
        {
            g.FillEllipse(Brushes.Black, x, y, size, size);
            g.FillEllipse(Brushes.Black,(int)(x - size / 2), y + size, 2 * size, 2 * size);
            g.FillEllipse(Brushes.Black, x - size, y + 3 * size, 3 * size, 3 * size);
        }
        void texBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                count = int.Parse(texBox.Text);
            }
            catch
            {
                count = 0;
            }
            Invalidate();
        }
    }
}

