using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using MsgBoxEx;
using SQLServerLoginTemplate;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Common.Interfaces;
using MessageBox = Wpf.Ui.Controls.MessageBox;

namespace FluentKursovayaAvtoparkA.Views.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : INavigableView<ViewModels.SettingsViewModel>
    {
        public static string a;
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
        private void DatabaseOptionbutton_Click(object sender, RoutedEventArgs e)
        {
            var uiMessageBox = new MessageBox
            {
                Title = "Подтвердите действие",
                Content = new TextBlock
                {
                    Text = "Вы хотите использовать значение по умолчанию или открыть панель настроек?",
                    TextWrapping = TextWrapping.Wrap,
                },
                ButtonLeftName = "Открыть панель настроек",
                ButtonRightName = "Использовать значение по умолчанию",
                Width = 800,
                Height = 200,

            };
            uiMessageBox.ButtonLeftClick += (s, e) =>
            {

                System.Windows.Forms.Application.EnableVisualStyles();
                uiMessageBox.Close();
                var form1 = new FormConnectToSQLServer();
                form1.ShowDialog();
                a = form1.ConnectionString;
                formations = a + ";Initial Catalog=KursovayaAvtoparkAvtobusov";
                
            };
            uiMessageBox.ButtonRightClick += (s, e) =>
            {
                formations= "server=localhost;Initial Catalog=KursovayaAvtoparkAvtobusov;User ID=sa;Password=ctrt55xx;";
                uiMessageBox.Close();
            };


            uiMessageBox.ShowDialog();
            
        }

    } 
}