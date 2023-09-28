using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 wind2 = new Form2();
            wind2.MdiParent = this;
            wind2.Show();
        }

        private void выхолToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void каскадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void горизонтальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void вертикальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activechild = this.ActiveMdiChild;
            if(activechild != null)
            {
                RichTextBox editbox = (RichTextBox)activechild.ActiveControl;
                if( editbox != null)
                {
                    Clipboard.SetDataObject(editbox.SelectedText);
                }
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activechild = this.ActiveMdiChild;
            if (activechild != null)
            {
                RichTextBox editbox = (RichTextBox)activechild.ActiveControl;
                if (editbox != null)
                {
                    IDataObject data = Clipboard.GetDataObject();
                    if (data.GetDataPresent(DataFormats.Text)) {
                        editbox.SelectedText = data.GetData(DataFormats.Text).ToString();
                    }
                }
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activechild = this.ActiveMdiChild;
            if (activechild != null)
            {
                activechild.Close();
            }
        }
    }
}
