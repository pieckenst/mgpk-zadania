using FastReport;
using FastReport.Data;
using FastReport.Export.Image;
using FastReport.Export.PdfSimple;
using FastReport.Format;
using FastReport.Table;
using FastReport.Utils;
using MsgBoxEx;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
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
            textx.Font = new Font("Times New Roman", 5.0f);
            textx.Text = "Num"; //table and its field
            textx.Border.Lines = BorderLines.All;
            TextObject textxx = new TextObject();
            textxx.Parent = data;
            textxx.CreateUniqueName();
            textxx.Bounds = new RectangleF(1 * Units.Centimeters, 0, Units.Centimeters * 3, Units.Centimeters * 0.5f);
            textxx.Font = new Font("Times New Roman", 5.0f);
            textxx.Text = "Surname"; //table and its field
            textxx.Border.Lines = BorderLines.All;
            TextObject textxxx = new TextObject();
            textxxx.Parent = data;
            textxxx.CreateUniqueName();
            textxxx.Bounds = new RectangleF(4.0f * Units.Centimeters, 0, Units.Centimeters * 20, Units.Centimeters * 0.5f);
            textxxx.Font = new Font("Times New Roman", 5.0f);
            textxxx.Text = "Name"; //table and its field
            textxxx.Border.Lines = BorderLines.All;
            TextObject textxxxx = new TextObject();
            textxxxx.Parent = data;
            textxxxx.CreateUniqueName();
            textxxxx.Bounds = new RectangleF(7.4f * Units.Centimeters, 0, Units.Centimeters * 25, Units.Centimeters * 0.5f);
            textxxxx.Font = new Font("Times New Roman", 5.0f);
            textxxxx.Text = "Patronym"; //table and its field
            textxxxx.Border.Lines = BorderLines.All;
            TextObject te = new TextObject();
            te.Parent = data;
            te.CreateUniqueName();
            te.Bounds = new RectangleF(9.9f * Units.Centimeters, 0, Units.Centimeters * 20, Units.Centimeters * 0.5f);
            te.Font = new Font("Times New Roman", 5.0f);
            te.Text = "Employed_Since"; //table and its field
            te.Border.Lines = BorderLines.All;
            TextObject ter = new TextObject();
            ter.Parent = data;
            ter.CreateUniqueName();
            ter.Bounds = new RectangleF(14 * Units.Centimeters, 0, Units.Centimeters * 30, Units.Centimeters * 0.5f);
            ter.Font = new Font("Times New Roman", 5.0f);
            ter.Text = "Job"; //table and its field
            ter.Border.Lines = BorderLines.All;
            TextObject teXR = new TextObject();
            teXR.Parent = data;
            teXR.CreateUniqueName();
            teXR.Bounds = new RectangleF(17.5f * Units.Centimeters, 0, Units.Centimeters * 25, Units.Centimeters * 0.5f);
            teXR.Font = new Font("Times New Roman", 5.0f);
            teXR.Text = "Internship"; //table and its field
            teXR.Border.Lines = BorderLines.All;
            // Employee Table Fields
            TextObject bandText = new TextObject();
            bandText.CreateUniqueName();
            bandText.HorzAlign = HorzAlign.Center;
            bandText.Bounds = new RectangleF(0 * Units.Centimeters, 25,
                1.0f * Units.Centimeters, 0.5f * Units.Centimeters);
            bandText.Font = new Font("Times New Roman", 5.0f);
            bandText.Border.Lines = BorderLines.All;

            bandText.Text = "[Employees.Num]";
            data.AddChild(bandText);

            TextObject text1 = new TextObject();
            text1.Parent = data;
            text1.CreateUniqueName();
            text1.Bounds = new RectangleF(1 * Units.Centimeters, 25, Units.Centimeters * 3, Units.Centimeters * 0.5f);
            text1.Font = new Font("Times New Roman", 5.0f);
            text1.Text = "[Employees.Surname]"; //table and its field
            text1.Border.Lines = BorderLines.All;
            TextObject text2 = new TextObject();
            text2.Parent = data;
            text2.CreateUniqueName();
            text2.Bounds = new RectangleF(4.0f * Units.Centimeters, 25, Units.Centimeters * 20, Units.Centimeters * 0.5f);
            text2.Font = new Font("Times New Roman", 5.0f);
            text2.Text = "[Employees.Name]"; //table and its field
            text2.Border.Lines = BorderLines.All;
            TextObject text3 = new TextObject();
            text3.Parent = data;
            text3.CreateUniqueName();
            text3.Bounds = new RectangleF(7.4f * Units.Centimeters, 25, Units.Centimeters * 20, Units.Centimeters * 0.5f);
            text3.Font = new Font("Times New Roman", 5.0f);
            text3.Text = "[Employees.Patronym]"; //table and its field
            text3.Border.Lines = BorderLines.All;
            TextObject text4 = new TextObject();
            text4.Parent = data;
            text4.CreateUniqueName();
            text4.Bounds = new RectangleF(9.9f * Units.Centimeters, 25, Units.Centimeters * 30, Units.Centimeters * 0.5f);
            text4.Font = new Font("Times New Roman", 5.0f);
            text4.Text = "[Employees.Employed_Since]"; //table and its field
            text4.Border.Lines = BorderLines.All;
            TextObject text5 = new TextObject();
            text5.Parent = data;
            text5.CreateUniqueName();
            text5.Bounds = new RectangleF(14 * Units.Centimeters, 25, Units.Centimeters * 5, Units.Centimeters * 0.5f);
            text5.Font = new Font("Times New Roman", 5.0f);
            text5.Text = "[Employees.Job]"; //table and its field
            text5.Border.Lines = BorderLines.All;
            TextObject text6 = new TextObject();
            text6.Parent = data;
            text6.CreateUniqueName();
            text6.Bounds = new RectangleF(17.5f * Units.Centimeters, 25, Units.Centimeters * 5, Units.Centimeters * 0.5f);
            text6.Font = new Font("Times New Roman", 5.0f);
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
            terxr.Font = new Font("Times New Roman", 4.0f);
            terxr.Text = "Data_Sledueschego_Obsluzivania"; //table and its field
            terxr.Border.Lines = BorderLines.All;
            TextObject teXRr = new TextObject();
            teXRr.Parent = datax;
            teXRr.CreateUniqueName();
            teXRr.Bounds = new RectangleF(17.5f * Units.Centimeters, 39.9f, Units.Centimeters * 26, Units.Centimeters * 0.5f);
            teXRr.Font = new Font("Times New Roman", 6.0f);
            teXRr.Text = "Goden_K_Doroge"; //table and its field
            teXRr.Border.Lines = BorderLines.All;
            //Maintenance table fields
            TextObject textxxrxx = new TextObject();
            textxxrxx.Parent = datax;
            textxxrxx.CreateUniqueName();
            textxxrxx.Bounds = new RectangleF(0 * Units.Centimeters, 60.9f, 0.7f * Units.Centimeters, Units.Centimeters * 0.5f);
            textxxrxx.Font = new Font("Times New Roman", 6.0f);
            textxxrxx.Text = "[Maintenance.Num]"; //table and its field
            textxxrxx.Border.Lines = BorderLines.All;
            TextObject textxxxrx = new TextObject();
            textxxxrx.Parent = datax;
            textxxxrx.CreateUniqueName();
            textxxxrx.Font = new Font("Times New Roman", 6.0f);
            textxxxrx.Bounds = new RectangleF(0.7f * Units.Centimeters, 60.9f, Units.Centimeters * 7, Units.Centimeters * 0.5f);

            textxxxrx.Text = "[Maintenance.Model_Avtobusa]"; //table and its field
            textxxxrx.Border.Lines = BorderLines.All;
            TextObject textxxxxrx = new TextObject();
            textxxxxrx.Parent = datax;
            textxxxxrx.CreateUniqueName();
            textxxxxrx.Bounds = new RectangleF(4.5f * Units.Centimeters, 60.9f, Units.Centimeters * 15, Units.Centimeters * 0.5f);
            textxxxxrx.Font = new Font("Times New Roman", 5.0f);
            textxxxxrx.Text = "[Maintenance.Data_Poslednego_Obsluzhivania]"; //table and its field
            textxxxxrx.Border.Lines = BorderLines.All;
            TextObject textxxxxxx = new TextObject();
            textxxxxxx.Parent = datax;
            textxxxxxx.Font = new Font("Times New Roman", 5.0f);
            textxxxxxx.CreateUniqueName();
            textxxxxxx.Bounds = new RectangleF(7.7f * Units.Centimeters, 60.9f, Units.Centimeters * 20, Units.Centimeters * 0.5f);

            textxxxxxx.Text = "[Maintenance.Ingener_Obsluzhivania]"; //table and its field
            textxxxxxx.Border.Lines = BorderLines.All;
            TextObject terzxx = new TextObject();
            terzxx.Parent = datax;
            terzxx.CreateUniqueName();
            terzxx.Bounds = new RectangleF(10.4f * Units.Centimeters, 60.9f, Units.Centimeters * 20, Units.Centimeters * 0.5f);
            terzxx.Font = new Font("Times New Roman", 5.0f);
            terzxx.Text = "[Maintenance.Problemi_Avtobusa]"; //table and its field
            terzxx.Border.Lines = BorderLines.All;
            TextObject terxrx = new TextObject();
            terxrx.Parent = datax;
            terxrx.CreateUniqueName();
            terxrx.Bounds = new RectangleF(15 * Units.Centimeters, 60.9f, Units.Centimeters * 15, Units.Centimeters * 0.5f);
            terxrx.Font = new Font("Times New Roman", 6.0f);
            terxrx.Text = "[Maintenance.Data_Sledueschego_Obsluzivania]"; //table and its field
            terxrx.Border.Lines = BorderLines.All;
            TextObject teXRrr = new TextObject();
            teXRrr.Parent = datax;
            teXRrr.CreateUniqueName();
            teXRrr.Bounds = new RectangleF(17.5f * Units.Centimeters, 60.9f, Units.Centimeters * 26, Units.Centimeters * 0.5f);
            teXRrr.Font = new Font("Times New Roman", 6.0f);
            teXRrr.Text = "[Maintenance.Goden_K_Doroge]"; //table and its field
            teXRrr.Border.Lines = BorderLines.All;
            // Prodazhi Header
            TextObject headersSText = new TextObject();
            headersSText.CreateUniqueName();
            headersSText.Bounds = new RectangleF(0.0f, 11.1f * Units.Centimeters,
                19.0f * Units.Centimeters, 0.8f * Units.Centimeters);
            headersSText.HorzAlign = HorzAlign.Center;
            headersSText.VertAlign = VertAlign.Center;
            headersSText.Font = new Font("Times New Roman", 16.0f);
            headersSText.TextColor = Color.Black;
            headersSText.FillColor = Color.Wheat;
            headersSText.Border.Color = Color.Black;
            headersSText.Border.Lines = BorderLines.All;
            headersSText.Border.Width = 4.0f;
            headersSText.Text = "Prodazhi" + " Table";
            page.ReportTitle.Objects.Add(headersSText);
            // Prodazhi Table Info

            DataBand dataxr = new DataBand();

            dataxr.CreateUniqueName();
            page.AddChild(dataxr);
            dataxr.DataSource = report.GetDataSource("Prodazhi"); //adding a table to a bend

            dataxr.Height = Units.Centimeters * 5f;
            TextObject texrxx = new TextObject();
            texrxx.Parent = dataxr;
            texrxx.CreateUniqueName();
            texrxx.Bounds = new RectangleF(0 * Units.Centimeters, 43.99f, 0.7f * Units.Centimeters, Units.Centimeters * 0.5f);
            texrxx.Font = new Font("Times New Roman", 6.0f);
            texrxx.Text = "Num"; //table and its field
            texrxx.Border.Lines = BorderLines.All;
            TextObject texrxs = new TextObject();
            texrxs.Parent = dataxr;
            texrxs.CreateUniqueName();
            texrxs.Font = new Font("Times New Roman", 6.0f);
            texrxs.Bounds = new RectangleF(0.7f * Units.Centimeters, 43.99f, Units.Centimeters * 7, Units.Centimeters * 0.5f);

            texrxs.Text = "Sale_Date"; //table and its field
            texrxs.Border.Lines = BorderLines.All;
            TextObject terscw = new TextObject();
            terscw.Parent = dataxr;
            terscw.CreateUniqueName();
            terscw.Bounds = new RectangleF(4.5f * Units.Centimeters, 43.99f, Units.Centimeters * 15, Units.Centimeters * 0.5f);
            terscw.Font = new Font("Times New Roman", 5.0f);
            terscw.Text = "Nomer_Avtobusa"; //table and its field
            terscw.Border.Lines = BorderLines.All;
            TextObject terscwx = new TextObject();
            terscwx.Parent = dataxr;
            terscwx.Font = new Font("Times New Roman", 5.0f);
            terscwx.CreateUniqueName();
            terscwx.Bounds = new RectangleF(7.7f * Units.Centimeters, 43.99f, Units.Centimeters * 20, Units.Centimeters * 0.5f);

            terscwx.Text = "Punkt_Posadki"; //table and its field
            terscwx.Border.Lines = BorderLines.All;
            TextObject terzrx = new TextObject();
            terzrx.Parent = dataxr;
            terzrx.CreateUniqueName();
            terzrx.Bounds = new RectangleF(10.4f * Units.Centimeters, 43.99f, Units.Centimeters * 20, Units.Centimeters * 0.5f);
            terzrx.Font = new Font("Times New Roman", 5.0f);
            terzrx.Text = "Stoimost"; //table and its field
            terzrx.Border.Lines = BorderLines.All;
            // Table Fields For Prodazhi
            TextObject texrxxx = new TextObject();
            texrxxx.Parent = dataxr;
            texrxxx.CreateUniqueName();
            texrxxx.Bounds = new RectangleF(0 * Units.Centimeters, 53.99f, 0.7f * Units.Centimeters, Units.Centimeters * 0.5f);
            texrxxx.Font = new Font("Times New Roman", 6.0f);
            texrxxx.Text = "[Prodazhi.Num]"; //table and its field
            texrxxx.Border.Lines = BorderLines.All;
            TextObject texrxss = new TextObject();
            texrxss.Parent = dataxr;
            texrxss.CreateUniqueName();
            texrxss.Font = new Font("Times New Roman", 6.0f);
            texrxss.Bounds = new RectangleF(0.7f * Units.Centimeters, 53.99f, Units.Centimeters * 7, Units.Centimeters * 0.5f);

            texrxss.Text = "[Prodazhi.Sale_Date]"; //table and its field
            texrxss.Border.Lines = BorderLines.All;
            TextObject terscwxxxr = new TextObject();
            terscwxxxr.Parent = dataxr;
            terscwxxxr.CreateUniqueName();
            terscwxxxr.Bounds = new RectangleF(4.5f * Units.Centimeters, 53.99f, Units.Centimeters * 15, Units.Centimeters * 0.5f);
            terscwxxxr.Font = new Font("Times New Roman", 5.0f);
            terscwxxxr.Text = "[Prodazhi.Nomer_Avtobusa]"; //table and its field
            terscwxxxr.Border.Lines = BorderLines.All;
            TextObject terscwxxr = new TextObject();
            terscwxxr.Parent = dataxr;
            terscwxxr.Font = new Font("Times New Roman", 5.0f);
            terscwxxr.CreateUniqueName();
            terscwxxr.Bounds = new RectangleF(7.7f * Units.Centimeters, 53.99f, Units.Centimeters * 20, Units.Centimeters * 0.5f);

            terscwxxr.Text = "[Prodazhi.Punkt_Posadki]"; //table and its field
            terscwxxr.Border.Lines = BorderLines.All;
            TextObject terzrxr = new TextObject();
            terzrxr.Parent = dataxr;
            terzrxr.CreateUniqueName();
            terzrxr.Bounds = new RectangleF(10.4f * Units.Centimeters, 53.99f, Units.Centimeters * 20, Units.Centimeters * 0.5f);
            terzrxr.Font = new Font("Times New Roman", 5.0f);
            terzrxr.Text = "[Prodazhi.Stoimost]"; //table and its field
            terzrxr.Border.Lines = BorderLines.All;
            // Marshuti table header
            TextObject headersrSText = new TextObject();
            headersrSText.CreateUniqueName();
            headersrSText.Bounds = new RectangleF(0.0f, 15.1f * Units.Centimeters,
                19.0f * Units.Centimeters, 0.8f * Units.Centimeters);
            headersrSText.HorzAlign = HorzAlign.Center;
            headersrSText.VertAlign = VertAlign.Center;
            headersrSText.Font = new Font("Times New Roman", 16.0f);
            headersrSText.TextColor = Color.Black;
            headersrSText.FillColor = Color.Wheat;
            headersrSText.Border.Color = Color.Black;
            headersrSText.Border.Lines = BorderLines.All;
            headersrSText.Border.Width = 4.0f;
            headersrSText.Text = "Marshuti" + " Table";
            page.ReportTitle.Objects.Add(headersrSText);
            // Marshuti fields
            DataBand datarxr = new DataBand();

            datarxr.CreateUniqueName();
            page.AddChild(datarxr);
            datarxr.DataSource = report.GetDataSource("Marshuti"); //adding a table to a bend

            datarxr.Height = Units.Centimeters * 2f;
            TextObject txtef = new TextObject();
            txtef.Parent = datarxr;
            txtef.CreateUniqueName();
            txtef.Bounds = new RectangleF(0 * Units.Centimeters, 58.9f, 0.7f * Units.Centimeters, Units.Centimeters * 0.5f);
            txtef.Font = new Font("Times New Roman", 6.0f);
            txtef.Text = "Nomer_Marshuta"; //table and its field
            txtef.Border.Lines = BorderLines.All;
            TextObject tfeqa = new TextObject();
            tfeqa.Parent = datarxr;
            tfeqa.CreateUniqueName();
            tfeqa.Font = new Font("Times New Roman", 6.0f);
            tfeqa.Bounds = new RectangleF(0.7f * Units.Centimeters, 58.9f, Units.Centimeters * 7, Units.Centimeters * 0.5f);

            tfeqa.Text = "Nachalni_Punkt"; //table and its field
            tfeqa.Border.Lines = BorderLines.All;
            TextObject tcqqcq = new TextObject();
            tcqqcq.Parent = datarxr;
            tcqqcq.CreateUniqueName();
            tcqqcq.Bounds = new RectangleF(4.5f * Units.Centimeters, 58.9f, Units.Centimeters * 15, Units.Centimeters * 0.5f);
            tcqqcq.Font = new Font("Times New Roman", 5.0f);
            tcqqcq.Text = "Konechni_Punkt"; //table and its field
            tcqqcq.Border.Lines = BorderLines.All;
            TextObject txtweq = new TextObject();
            txtweq.Parent = datarxr;
            txtweq.Font = new Font("Times New Roman", 5.0f);
            txtweq.CreateUniqueName();
            txtweq.Bounds = new RectangleF(7.7f * Units.Centimeters, 58.9f, Units.Centimeters * 20, Units.Centimeters * 0.5f);

            txtweq.Text = "Voditel"; //table and its field
            txtweq.Border.Lines = BorderLines.All;
            TextObject terrzx = new TextObject();
            terrzx.Parent = datarxr;
            terrzx.CreateUniqueName();
            terrzx.Bounds = new RectangleF(10.4f * Units.Centimeters, 58.9f, Units.Centimeters * 20, Units.Centimeters * 0.5f);
            terrzx.Font = new Font("Times New Roman", 5.0f);
            terrzx.Text = "Model_Avtobusa"; //table and its field
            terrzx.Border.Lines = BorderLines.All;
            TextObject txerxr = new TextObject();
            txerxr.Parent = datarxr;
            txerxr.CreateUniqueName();
            txerxr.Bounds = new RectangleF(15 * Units.Centimeters, 58.9f, Units.Centimeters * 15, Units.Centimeters * 0.5f);
            txerxr.Font = new Font("Times New Roman", 4.0f);
            txerxr.Text = "Vremya_Proezda"; //table and its field
            txerxr.Border.Lines = BorderLines.All;
            TextObject txteff = new TextObject();
            txteff.Parent = datarxr;
            txteff.CreateUniqueName();
            txteff.Bounds = new RectangleF(0 * Units.Centimeters, 82.9f, 0.7f * Units.Centimeters, Units.Centimeters * 0.5f);
            txteff.Font = new Font("Times New Roman", 6.0f);
            txteff.Text = "[Marshuti.Nomer_Marshuta]"; //table and its field
            txteff.Border.Lines = BorderLines.All;
            TextObject tfeqafd = new TextObject();
            tfeqafd.Parent = datarxr;
            tfeqafd.CreateUniqueName();
            tfeqafd.Font = new Font("Times New Roman", 6.0f);
            tfeqafd.Bounds = new RectangleF(0.7f * Units.Centimeters, 82.9f, Units.Centimeters * 7, Units.Centimeters * 0.5f);

            tfeqafd.Text = "[Marshuti.Nachalni_Punkt]"; //table and its field
            tfeqafd.Border.Lines = BorderLines.All;
            TextObject tcqqcqd = new TextObject();
            tcqqcqd.Parent = datarxr;
            tcqqcqd.CreateUniqueName();
            tcqqcqd.Bounds = new RectangleF(4.5f * Units.Centimeters, 82.9f, Units.Centimeters * 15, Units.Centimeters * 0.5f);
            tcqqcqd.Font = new Font("Times New Roman", 5.0f);
            tcqqcqd.Text = "[Marshuti.Konechni_Punkt]"; //table and its field
            tcqqcqd.Border.Lines = BorderLines.All;
            TextObject txtweqq = new TextObject();
            txtweqq.Parent = datarxr;
            txtweqq.Font = new Font("Times New Roman", 5.0f);
            txtweqq.CreateUniqueName();
            txtweqq.Bounds = new RectangleF(7.7f * Units.Centimeters, 82.9f, Units.Centimeters * 20, Units.Centimeters * 0.5f);

            txtweqq.Text = "[Marshuti.Voditel]"; //table and its field
            txtweqq.Border.Lines = BorderLines.All;
            TextObject terrzxr = new TextObject();
            terrzxr.Parent = datarxr;
            terrzxr.CreateUniqueName();
            terrzxr.Bounds = new RectangleF(10.4f * Units.Centimeters, 82.9f, Units.Centimeters * 20, Units.Centimeters * 0.5f);
            terrzxr.Font = new Font("Times New Roman", 5.0f);
            terrzxr.Text = "[Marshuti.Model_Avtobusa]"; //table and its field
            terrzxr.Border.Lines = BorderLines.All;
            TextObject txerxxr = new TextObject();
            txerxxr.Parent = datarxr;
            txerxxr.CreateUniqueName();
            txerxxr.Bounds = new RectangleF(15 * Units.Centimeters, 82.9f, Units.Centimeters * 15, Units.Centimeters * 0.5f);
            txerxxr.Font = new Font("Times New Roman", 4.0f);
            txerxxr.Text = "[Marshuti.Vremya_Proezda]"; //table and its field
            txerxxr.Border.Lines = BorderLines.All;
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

            report.SavePrepared("Prepared Report.fpx");
            PDFSimpleExport pdf = new PDFSimpleExport();
            // Save the report 
            report.Export(pdf, "ExportedPDF.pdf");
        }

        private void ComplexRepExport_Click(object sender, RoutedEventArgs e)
        {
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            Report report = new Report();

            MsSqlDataConnection connection = new MsSqlDataConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();
            connection.CreateAllTables();

            report.Load("AvtoparkRepTemplate.frx");
            report.Dictionary.Connections.Add(connection);
            report.RegisterData(connection.DataSet, "mssql");

            // Exporting the report
            report.Prepare();

            report.SavePrepared("PreparedComplexReport.fpx");
            PDFSimpleExport pdf = new PDFSimpleExport();
            // Save the report 
            report.Export(pdf, "ExportedComplexPDF.pdf");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MsgBoxExtendedFunctionality ext = new MsgBoxExtendedFunctionality()
            {
                DetailsText = "Test, s"
            };
            MessageBoxEx.ShowEx("Here's some source code. Click the Details expander below.", "Details, Details"
                , MessageBoxButton.OK, MessageBoxImage.Information, ext);
        }
    }
}
