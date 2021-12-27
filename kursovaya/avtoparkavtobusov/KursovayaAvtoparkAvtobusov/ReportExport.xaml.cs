using FastReport;
using FastReport.Data;

using FastReport.Export.Image;
using FastReport.Export.PdfSimple;
using FastReport.Format;
using FastReport.Table;
using FastReport.Utils;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows;

namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    /// Interaction logic for ReportExport.xaml
    /// </summary>
    public partial class ReportExport : Window
    {
        private static string outFolder = @"..\..\..\out\";
        private static string inFolder = @"..\..\..\in\";

        public ReportExport()
        {
            InitializeComponent();
        }

        /*private void Fucttardmethod()
        {
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            Report report = new Report();

            MsSqlDataConnection sqlConnection = new MsSqlDataConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();
            sqlConnection.CreateAllTables();
            report.Report.Dictionary.Connections.Add(sqlConnection);
            var select = "SELECT * FROM Employees; SELECT* FROM Maintenance; SELECT* FROM Marshuti; SELECT* FROM Prodazhi";

            report.GetDataSource("Employees").Enabled = true;
            report.GetDataSource("Maintenance").Enabled = true;
            report.GetDataSource("Marshuti").Enabled = true;
            report.GetDataSource("Prodazhi").Enabled = true;

            report.Prepare();
            PDFSimpleExport pdf = new PDFSimpleExport();
            // Save the report 
            report.Export(pdf, "ExportedPDF.pdf");
        }*/

        private void SimpleRepExport_Click(object sender, RoutedEventArgs e)
        {
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            Report report = new Report();

            MsSqlDataConnection connection = new MsSqlDataConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();
            connection.CreateAllTables();
            report.Dictionary.Connections.Add(connection);
            report.RegisterData(connection.DataSet, "mssql");
            report.GetDataSource("Employees").Enabled = true;
            report.GetDataSource("Maintenance").Enabled = true;
            report.GetDataSource("Marshuti").Enabled = true;
            report.GetDataSource("Prodazhi").Enabled = true;
            ReportPage page = new ReportPage();

            report.Pages.Add(page);
            page.CreateUniqueName();
            page.TopMargin = 10.0f;
            page.LeftMargin = 10.0f;
            page.RightMargin = 10.0f;
            page.BottomMargin = 10.0f;
            DataBand data = new DataBand();

            data.CreateUniqueName();
            page.AddChild(data);
            data.DataSource = report.GetDataSource("Employees"); //adding a table to a bend
            data.Height = Units.Centimeters * 1.5f;
            // Creating report title
            page.ReportTitle = new ReportTitleBand();
            page.ReportTitle.CreateUniqueName();
            page.ReportTitle.Height = 4.0f * Units.Centimeters;
            TextObject titleText = new TextObject();
            titleText.CreateUniqueName();
            titleText.Left = 1.0f * Units.Centimeters;
            titleText.Top = 1.0f * Units.Centimeters;
            titleText.Width = 17.0f * Units.Centimeters;
            titleText.Height = 2.0f * Units.Centimeters;
            titleText.HorzAlign = HorzAlign.Center;
            titleText.VertAlign = VertAlign.Center;
            titleText.Font = new Font("Times New Roman", 32.0f);
            titleText.TextColor = Color.Black;
            titleText.FillColor = Color.Wheat;
            titleText.Border.Color = Color.Black;
            titleText.Border.Lines = BorderLines.All;
            titleText.Border.Width = 4.0f;
            titleText.Text = "Avtopark Report";
            page.ReportTitle.Objects.Add(titleText);
            // Header object
            TextObject headerText = new TextObject();
            headerText.CreateUniqueName();
            headerText.Bounds = new RectangleF(0.0f, 2.7f * Units.Centimeters,
                19.0f * Units.Centimeters, 0.8f * Units.Centimeters);
            headerText.HorzAlign = HorzAlign.Center;
            headerText.VertAlign = VertAlign.Center;
            headerText.Font = new Font("Times New Roman", 16.0f);
            headerText.TextColor = Color.Black;
            headerText.FillColor = Color.Wheat;
            headerText.Border.Color = Color.Black;
            headerText.Border.Lines = BorderLines.All;
            headerText.Border.Width = 4.0f;
            headerText.Text = "Employees" + " Table";
            page.ReportTitle.Objects.Add(headerText);

            // Employee Table Text bands
            TextObject textx = new TextObject();
            textx.Parent = data;
            textx.CreateUniqueName();
            textx.Bounds = new RectangleF(0 * Units.Centimeters, 0, 1.0f * Units.Centimeters, Units.Centimeters * 0.5f);

            textx.Text = "Num"; //table and its field
            textx.Border.Lines = BorderLines.All;
            TextObject textxx = new TextObject();
            textxx.Parent = data;
            textxx.CreateUniqueName();
            textxx.Bounds = new RectangleF(1 * Units.Centimeters, 0, Units.Centimeters * 3, Units.Centimeters * 0.5f);

            textxx.Text = "Surname"; //table and its field
            textxx.Border.Lines = BorderLines.All;
            TextObject textxxx = new TextObject();
            textxxx.Parent = data;
            textxxx.CreateUniqueName();
            textxxx.Bounds = new RectangleF(4 * Units.Centimeters, 0, Units.Centimeters * 20, Units.Centimeters * 0.5f);

            textxxx.Text = "Name"; //table and its field
            textxxx.Border.Lines = BorderLines.All;
            TextObject textxxxx = new TextObject();
            textxxxx.Parent = data;
            textxxxx.CreateUniqueName();
            textxxxx.Bounds = new RectangleF(10 * Units.Centimeters, 0, Units.Centimeters * 25, Units.Centimeters * 0.5f);

            textxxxx.Text = "Patronym"; //table and its field
            textxxxx.Border.Lines = BorderLines.All;
            TextObject te = new TextObject();
            te.Parent = data;
            te.CreateUniqueName();
            te.Bounds = new RectangleF(13 * Units.Centimeters, 0, Units.Centimeters * 3, Units.Centimeters * 0.5f);
            te.Font = new Font("Times New Roman", 5.0f);
            te.Text = "Employed_Since"; //table and its field
            te.Border.Lines = BorderLines.All;
            TextObject ter = new TextObject();
            ter.Parent = data;
            ter.CreateUniqueName();
            ter.Bounds = new RectangleF(16 * Units.Centimeters, 0, Units.Centimeters * 20, Units.Centimeters * 0.5f);

            ter.Text = "Job"; //table and its field
            ter.Border.Lines = BorderLines.All;
            TextObject teXR = new TextObject();
            teXR.Parent = data;
            teXR.CreateUniqueName();
            teXR.Bounds = new RectangleF(18 * Units.Centimeters, 0, Units.Centimeters * 20, Units.Centimeters * 0.5f);

            teXR.Text = "Internship"; //table and its field
            teXR.Border.Lines = BorderLines.All;
            // Employee Table Fields
            TextObject bandText = new TextObject();
            bandText.CreateUniqueName();
            bandText.HorzAlign = HorzAlign.Center;
            bandText.Bounds = new RectangleF(0.0f * Units.Centimeters, 25,
                1.0f * Units.Centimeters, 0.5f * Units.Centimeters);

            bandText.Border.Lines = BorderLines.All;

            bandText.Text = "[Employees.Num]";
            data.AddChild(bandText);

            TextObject text1 = new TextObject();
            text1.Parent = data;
            text1.CreateUniqueName();
            text1.Bounds = new RectangleF(1 * Units.Centimeters, 25, Units.Centimeters * 3, Units.Centimeters * 0.5f);

            text1.Text = "[Employees.Surname]"; //table and its field
            text1.Border.Lines = BorderLines.All;
            TextObject text2 = new TextObject();
            text2.Parent = data;
            text2.CreateUniqueName();
            text2.Bounds = new RectangleF(4 * Units.Centimeters, 25, Units.Centimeters * 20, Units.Centimeters * 0.5f);

            text2.Text = "[Employees.Name]"; //table and its field
            text2.Border.Lines = BorderLines.All;
            TextObject text3 = new TextObject();
            text3.Parent = data;
            text3.CreateUniqueName();
            text3.Bounds = new RectangleF(10 * Units.Centimeters, 25, Units.Centimeters * 15, Units.Centimeters * 0.5f);

            text3.Text = "[Employees.Patronym]"; //table and its field
            text3.Border.Lines = BorderLines.All;
            TextObject text4 = new TextObject();
            text4.Parent = data;
            text4.CreateUniqueName();
            text4.Bounds = new RectangleF(13 * Units.Centimeters, 25, Units.Centimeters * 5, Units.Centimeters * 0.5f);

            text4.Text = "[Employees.Employed_Since]"; //table and its field
            text4.Border.Lines = BorderLines.All;
            TextObject text5 = new TextObject();
            text5.Parent = data;
            text5.CreateUniqueName();
            text5.Bounds = new RectangleF(15 * Units.Centimeters, 25, Units.Centimeters * 5, Units.Centimeters * 0.5f);

            text5.Text = "[Employees.Job]"; //table and its field
            text5.Border.Lines = BorderLines.All;
            TextObject text6 = new TextObject();
            text6.Parent = data;
            text6.CreateUniqueName();
            text6.Bounds = new RectangleF(18 * Units.Centimeters, 25, Units.Centimeters * 5, Units.Centimeters * 0.5f);

            text6.Text = "[Employees.Internship]"; //table and its field
            text6.Border.Lines = BorderLines.All;
            // Maintenance table things\
            DataBand datax = new DataBand();

            datax.CreateUniqueName();
            page.AddChild(datax);
            datax.DataSource = report.GetDataSource("Maintenance"); //adding a table to a bend

            datax.Height = Units.Centimeters * 5f;
            //Maintenance Header object
            TextObject headerSText = new TextObject();
            headerSText.CreateUniqueName();
            headerSText.Bounds = new RectangleF(0.0f, 7.1f * Units.Centimeters,
                19.0f * Units.Centimeters, 0.8f * Units.Centimeters);
            headerSText.HorzAlign = HorzAlign.Center;
            headerSText.VertAlign = VertAlign.Center;
            headerSText.Font = new Font("Times New Roman", 16.0f);
            headerSText.TextColor = Color.Black;
            headerSText.FillColor = Color.Wheat;
            headerSText.Border.Color = Color.Black;
            headerSText.Border.Lines = BorderLines.All;
            headerSText.Border.Width = 4.0f;
            headerSText.Text = "Maintenance" + " Table";
            page.ReportTitle.Objects.Add(headerSText);
            //Maintenance Table Text bands
            TextObject textxxrx = new TextObject();
            textxxrx.Parent = datax;
            textxxrx.CreateUniqueName();
            textxxrx.Bounds = new RectangleF(0 * Units.Centimeters, 39.9f, 0.7f * Units.Centimeters, Units.Centimeters * 0.5f);
            textxxrx.Font = new Font("Times New Roman", 6.0f);
            textxxrx.Text = "Num"; //table and its field
            textxxrx.Border.Lines = BorderLines.All;
            TextObject textxxxr = new TextObject();
            textxxxr.Parent = datax;
            textxxxr.CreateUniqueName();
            textxxxr.Font = new Font("Times New Roman", 6.0f);
            textxxxr.Bounds = new RectangleF(0.7f * Units.Centimeters, 39.9f, Units.Centimeters * 7, Units.Centimeters * 0.5f);

            textxxxr.Text = "Model_Avtobusa"; //table and its field
            textxxxr.Border.Lines = BorderLines.All;
            TextObject textxxxxr = new TextObject();
            textxxxxr.Parent = datax;
            textxxxxr.CreateUniqueName();
            textxxxxr.Bounds = new RectangleF(4.5f * Units.Centimeters, 39.9f, Units.Centimeters * 15, Units.Centimeters * 0.5f);
            textxxxxr.Font = new Font("Times New Roman", 5.0f);
            textxxxxr.Text = "Data_Poslednego_Obsluzhivania"; //table and its field
            textxxxxr.Border.Lines = BorderLines.All;
            TextObject textxxxxx = new TextObject();
            textxxxxx.Parent = datax;
            textxxxxx.Font = new Font("Times New Roman", 5.0f);
            textxxxxx.CreateUniqueName();
            textxxxxx.Bounds = new RectangleF(7.7f * Units.Centimeters, 39.9f, Units.Centimeters * 20, Units.Centimeters * 0.5f);

            textxxxxx.Text = "Ingener_Obsluzhivania"; //table and its field
            textxxxxx.Border.Lines = BorderLines.All;
            TextObject terzx = new TextObject();
            terzx.Parent = datax;
            terzx.CreateUniqueName();
            terzx.Bounds = new RectangleF(10.4f * Units.Centimeters, 39.9f, Units.Centimeters * 20, Units.Centimeters * 0.5f);
            terzx.Font = new Font("Times New Roman", 5.0f);
            terzx.Text = "Problemi_Avtobusa"; //table and its field
            terzx.Border.Lines = BorderLines.All;
            TextObject terxr = new TextObject();
            terxr.Parent = datax;
            terxr.CreateUniqueName();
            terxr.Bounds = new RectangleF(15 * Units.Centimeters, 39.9f, Units.Centimeters * 15, Units.Centimeters * 0.5f);
            terxr.Font = new Font("Times New Roman", 3.0f);
            terxr.Text = "Data_Sledueschego_Obsluzivania"; //table and its field
            terxr.Border.Lines = BorderLines.All;
            TextObject teXRr = new TextObject();
            teXRr.Parent = datax;
            teXRr.CreateUniqueName();
            teXRr.Bounds = new RectangleF(17.5f * Units.Centimeters, 39.9f, Units.Centimeters * 26, Units.Centimeters * 0.5f);
            teXRr.Font = new Font("Times New Roman", 6.0f);
            teXRr.Text = "Goden_K_Doroge"; //table and its field
            teXRr.Border.Lines = BorderLines.All;
            // Footer
            page.PageFooter = new PageFooterBand();
            page.PageFooter.CreateUniqueName();
            page.PageFooter.Height = 0.5f * Units.Centimeters;

            TextObject footerText = new TextObject();
            footerText.CreateUniqueName();
            footerText.HorzAlign = HorzAlign.Right;
            footerText.VertAlign = VertAlign.Center;
            footerText.Bounds = new RectangleF(0.0f, 0.0f,
                19.0f * Units.Centimeters, 0.5f * Units.Centimeters);
            footerText.TextColor = Color.Black;
            footerText.FillColor = Color.Wheat;
            titleText.Border.Color = Color.Black;
            titleText.Border.Lines = BorderLines.All;
            titleText.Border.Width = 4.0f;
            footerText.Text = "Page [Page]";
            page.PageFooter.Objects.Add(footerText);
            // Exporting the report
            report.Prepare();

            PDFSimpleExport pdf = new PDFSimpleExport();
            // Save the report 
            report.Export(pdf, "ExportedPDF.pdf");
        }
    }
}
