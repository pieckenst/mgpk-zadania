using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BiblioDiagAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[2].Points.Clear();
                chart1.Series[0].ChartType = SeriesChartType.Pie;
                chart1.Series[1].ChartType = SeriesChartType.Pie;
                chart1.Series[2].ChartType = SeriesChartType.Pie;
                chart1.Series[1].Color = Color.Gold;
                chart1.Series[2].Color = Color.DarkRed;
                double number = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);
                double num3 = double.Parse(textBox3.Text);
                chart1.Series[0].Points.AddXY("Библиотека 1", number);

                chart1.Series[0].Points.AddXY("Библиотека 2", num2);

                chart1.Series[0].Points.AddXY("Библиотека 3", num3);

            }
            else
            {
                double number = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);
                double num3 = double.Parse(textBox3.Text);
                chart1.Series[0].Points.AddY(number);
                chart1.Series[0].LegendText = "Библиотека 1";
                chart1.Series[1].Points.AddY(num2);
                chart1.Series[1].LegendText = "Библиотека 2";
                chart1.Series[2].Points.AddY(num3);
                chart1.Series[2].LegendText = "Библиотека 3";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[0].ChartType = SeriesChartType.Pie;
            chart1.Series[1].ChartType = SeriesChartType.Pie;
            chart1.Series[2].ChartType = SeriesChartType.Pie;
            chart1.Series[1].Color = Color.Gold;
            chart1.Series[2].Color = Color.DarkRed;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.Series[1].ChartType = SeriesChartType.Column;
            chart1.Series[2].ChartType = SeriesChartType.Column;
        }
    }
}
