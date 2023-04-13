using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using MsgBoxEx;
using System;
using System.Drawing;
using System.Windows;
using Wpf.Ui.Common.Interfaces;


namespace FluentKursovayaAvtoparkA.Views.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : INavigableView<ViewModels.SettingsViewModel>
    {
        public static string formations = "server=localhost;Initial Catalog=KursovayaAvtoparkAvtobusov;User ID=sa;Password=ctrt55xx;";
        public ViewModels.SettingsViewModel ViewModel
        {
            get;
        }

        public SettingsPage(ViewModels.SettingsViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }

        private void SimpleRepExport_Click(object sender, RoutedEventArgs e)
        {
            Services.ReportSystem.SimpleRepExport_Handle();
        }
        private void ComplexRepExport_Click(object sender, RoutedEventArgs e)
        {
            Services.ReportSystem.ComplexRepExport_Handle();
        }

    } 
}