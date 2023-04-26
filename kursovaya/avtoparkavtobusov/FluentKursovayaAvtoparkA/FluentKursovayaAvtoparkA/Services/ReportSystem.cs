using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using FluentKursovayaAvtoparkA.Views.Pages;
using MsgBoxEx;
using System;
using System.Drawing;
using System.Windows;
using Wpf.Ui.Common.Interfaces;

namespace FluentKursovayaAvtoparkA.Services
{
    public static class ReportSystem
    {
        public static void SimpleRepExport_Handle()
        {
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            Report report = new Report();

            MsSqlDataConnection connection = new MsSqlDataConnection();
            connection.ConnectionString = SettingsPage.formations;
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
            try
            {
                // Exporting the report
                report.Prepare();

                report.SavePrepared("Prepared Report.fpx");
                PDFSimpleExport pdf = new PDFSimpleExport();
                // Save the report 
                report.Export(pdf, "ExportedPDF.pdf");
            }
            catch (Exception ex)
            {
                MsgBoxExtendedFunctionality ext = new MsgBoxExtendedFunctionality()
                {
                    DetailsText = ex.StackTrace
                };
                MessageBoxEx.ShowEx("An error has occured! Traceback: " + ex.Message, "Unexpected situation handling", MessageBoxButtonEx.OK, MessageBoxImage.Error, ext);
            }
        }

        public static void ComplexRepExport_Handle()
        {
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            Report report = new Report();

            MsSqlDataConnection connection = new MsSqlDataConnection();
            connection.ConnectionString = SettingsPage.formations;
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
            TextObject title2Text = new TextObject();
            title2Text.CreateUniqueName();
            title2Text.Left = 1.0f * Units.Centimeters;
            title2Text.Top = 1.0f * Units.Centimeters;
            title2Text.Width = 17.0f * Units.Centimeters;
            title2Text.Height = 2.0f * Units.Centimeters;
            title2Text.HorzAlign = HorzAlign.Center;
            title2Text.VertAlign = VertAlign.Center;
            title2Text.Font = new Font("Times New Roman", 32.0f);
            title2Text.TextColor = Color.Black;
            title2Text.FillColor = Color.Wheat;
            title2Text.Border.Color = Color.Black;
            title2Text.Border.Lines = BorderLines.All;
            title2Text.Border.Width = 4.0f;
            title2Text.Text = "Avtopark Report";
            page.ReportTitle.Objects.Add(title2Text);
            // Header object
            TextObject headerText = new TextObject();
            headerText.CreateUniqueName();
            headerText.Bounds = new RectangleF(0.0f, 3.2f * Units.Centimeters,
                19.0f * Units.Centimeters, 0.8f * Units.Centimeters);
            headerText.HorzAlign = HorzAlign.Left;
            headerText.VertAlign = VertAlign.Center;
            headerText.Font = new Font("Times New Roman", 10.0f);

            headerText.Text = "Employees";
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
            // page2
            ReportPage page2 = new ReportPage();

            report.Pages.Add(page2);
            page2.CreateUniqueName();
            page2.TopMargin = 10.0f;
            page2.LeftMargin = 10.0f;
            page2.RightMargin = 10.0f;
            page2.BottomMargin = 10.0f;
            page2.ReportTitle = new ReportTitleBand();
            page2.ReportTitle.CreateUniqueName();
            page2.ReportTitle.Height = 4.0f * Units.Centimeters;
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
            page2.ReportTitle.Objects.Add(titleText);
            // Maintenance table things\
            DataBand datax = new DataBand();

            datax.CreateUniqueName();
            page2.AddChild(datax);
            datax.DataSource = report.GetDataSource("Maintenance"); //adding a table to a bend

            datax.Height = Units.Centimeters * 5f;
            //Maintenance Header object
            TextObject headerSText = new TextObject();
            headerSText.CreateUniqueName();
            headerSText.Bounds = new RectangleF(0.0f, 3.2f * Units.Centimeters,
                19.0f * Units.Centimeters, 0.8f * Units.Centimeters);
            headerSText.HorzAlign = HorzAlign.Left;
            headerSText.VertAlign = VertAlign.Center;
            headerSText.Font = new Font("Times New Roman", 10.0f);

            headerSText.Border.Width = 4.0f;
            headerSText.Text = "Maintenance";
            page2.ReportTitle.Objects.Add(headerSText);
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
            //page3
            ReportPage page3 = new ReportPage();

            report.Pages.Add(page3);
            page3.CreateUniqueName();
            page3.TopMargin = 10.0f;
            page3.LeftMargin = 10.0f;
            page3.RightMargin = 10.0f;
            page3.BottomMargin = 10.0f;
            page3.ReportTitle = new ReportTitleBand();
            page3.ReportTitle.CreateUniqueName();
            page3.ReportTitle.Height = 4.0f * Units.Centimeters;
            TextObject Title3 = new TextObject();
            Title3.CreateUniqueName();
            Title3.Left = 1.0f * Units.Centimeters;
            Title3.Top = 1.0f * Units.Centimeters;
            Title3.Width = 17.0f * Units.Centimeters;
            Title3.Height = 2.0f * Units.Centimeters;
            Title3.HorzAlign = HorzAlign.Center;
            Title3.VertAlign = VertAlign.Center;
            Title3.Font = new Font("Times New Roman", 32.0f);
            Title3.TextColor = Color.Black;
            Title3.FillColor = Color.Wheat;
            Title3.Border.Color = Color.Black;
            Title3.Border.Lines = BorderLines.All;
            Title3.Border.Width = 4.0f;
            Title3.Text = "Avtopark Report";
            page3.ReportTitle.Objects.Add(Title3);
            TextObject headersSText = new TextObject();
            headersSText.CreateUniqueName();
            headersSText.Bounds = new RectangleF(0.0f, 3.2f * Units.Centimeters,
                19.0f * Units.Centimeters, 0.8f * Units.Centimeters);
            headersSText.HorzAlign = HorzAlign.Left;
            headersSText.VertAlign = VertAlign.Center;
            headersSText.Font = new Font("Times New Roman", 10.0f);

            headersSText.Text = "Prodazhi";
            page3.ReportTitle.Objects.Add(headersSText);
            // Prodazhi Table Info

            DataBand dataxr = new DataBand();

            dataxr.CreateUniqueName();
            page3.AddChild(dataxr);
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
            //page4
            ReportPage page4 = new ReportPage();

            report.Pages.Add(page4);
            page4.CreateUniqueName();
            page4.TopMargin = 10.0f;
            page4.LeftMargin = 10.0f;
            page4.RightMargin = 10.0f;
            page4.BottomMargin = 10.0f;
            page4.ReportTitle = new ReportTitleBand();
            page4.ReportTitle.CreateUniqueName();
            page4.ReportTitle.Height = 4.0f * Units.Centimeters;
            TextObject title4 = new TextObject();
            title4.CreateUniqueName();
            title4.Left = 1.0f * Units.Centimeters;
            title4.Top = 1.0f * Units.Centimeters;
            title4.Width = 17.0f * Units.Centimeters;
            title4.Height = 2.0f * Units.Centimeters;
            title4.HorzAlign = HorzAlign.Center;
            title4.VertAlign = VertAlign.Center;
            title4.Font = new Font("Times New Roman", 32.0f);
            title4.TextColor = Color.Black;
            title4.FillColor = Color.Wheat;
            title4.Border.Color = Color.Black;
            title4.Border.Lines = BorderLines.All;
            title4.Border.Width = 4.0f;
            title4.Text = "Avtopark Report";
            page4.ReportTitle.Objects.Add(title4);
            TextObject headtextx = new TextObject();
            headtextx.CreateUniqueName();
            headtextx.Bounds = new RectangleF(0.0f, 3.2f * Units.Centimeters,
                19.0f * Units.Centimeters, 0.8f * Units.Centimeters);
            headtextx.HorzAlign = HorzAlign.Left;
            headtextx.VertAlign = VertAlign.Center;
            headtextx.Font = new Font("Times New Roman", 10.0f);

            headtextx.Text = "Marshuti";
            page4.ReportTitle.Objects.Add(headtextx);
            // Marshuti fields
            DataBand datarxr = new DataBand();

            datarxr.CreateUniqueName();
            page4.AddChild(datarxr);
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
            page2.PageFooter = new PageFooterBand();
            page2.PageFooter.CreateUniqueName();
            page2.PageFooter.Height = 0.5f * Units.Centimeters;
            page3.PageFooter = new PageFooterBand();
            page3.PageFooter.CreateUniqueName();
            page3.PageFooter.Height = 0.5f * Units.Centimeters;
            page4.PageFooter = new PageFooterBand();
            page4.PageFooter.CreateUniqueName();
            page4.PageFooter.Height = 0.5f * Units.Centimeters;
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
            TextObject f2 = new TextObject();
            f2.CreateUniqueName();
            f2.HorzAlign = HorzAlign.Right;
            f2.VertAlign = VertAlign.Center;
            f2.Bounds = new RectangleF(0.0f, 0.0f,
                19.0f * Units.Centimeters, 0.5f * Units.Centimeters);
            f2.TextColor = Color.Black;
            f2.FillColor = Color.Wheat;
            titleText.Border.Color = Color.Black;
            titleText.Border.Lines = BorderLines.All;
            titleText.Border.Width = 4.0f;
            f2.Text = "Page [Page]";
            TextObject f3x = new TextObject();
            f3x.CreateUniqueName();
            f3x.HorzAlign = HorzAlign.Right;
            f3x.VertAlign = VertAlign.Center;
            f3x.Bounds = new RectangleF(0.0f, 0.0f,
                19.0f * Units.Centimeters, 0.5f * Units.Centimeters);
            f3x.TextColor = Color.Black;
            f3x.FillColor = Color.Wheat;
            titleText.Border.Color = Color.Black;
            titleText.Border.Lines = BorderLines.All;
            titleText.Border.Width = 4.0f;
            f3x.Text = "Page [Page]";
            TextObject f4x = new TextObject();
            f4x.CreateUniqueName();
            f4x.HorzAlign = HorzAlign.Right;
            f4x.VertAlign = VertAlign.Center;
            f4x.Bounds = new RectangleF(0.0f, 0.0f,
                19.0f * Units.Centimeters, 0.5f * Units.Centimeters);
            f4x.TextColor = Color.Black;
            f4x.FillColor = Color.Wheat;
            titleText.Border.Color = Color.Black;
            titleText.Border.Lines = BorderLines.All;
            titleText.Border.Width = 4.0f;
            f4x.Text = "Page [Page]";
            page.PageFooter.Objects.Add(footerText);
            page2.PageFooter.Objects.Add(f2);
            page3.PageFooter.Objects.Add(f3x);
            page4.PageFooter.Objects.Add(f4x);
            try
            {
                // Exporting the report
                report.Prepare();

                report.SavePrepared("PreparedComplexReport.fpx");
                PDFSimpleExport pdf = new PDFSimpleExport();
                // Save the report 
                report.Export(pdf, "ExportedComplexPDF.pdf");
            }
            catch (Exception ex)
            {
                MsgBoxExtendedFunctionality ext = new MsgBoxExtendedFunctionality()
                {
                    DetailsText = ex.StackTrace
                };
                MessageBoxEx.ShowEx("An error has occured! Traceback: " + ex.Message, "Unexpected situation handling", MessageBoxButtonEx.OK, MessageBoxImage.Error, ext);
            }

        }
    }
}
