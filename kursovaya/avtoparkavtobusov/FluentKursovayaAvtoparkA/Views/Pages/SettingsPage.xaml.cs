using System;
using System.Threading.Tasks;
using SQLServerLoginTemplate;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Controls;
using MessageBox = Wpf.Ui.Controls.MessageBox;
using TextBlock = System.Windows.Controls.TextBlock;
using Wpf.Ui.Controls;
using Wpf.Ui;
using Wpf.Ui.Extensions;
using FluentKursovayaAvtoparkA.Controls;
using FluentKursovayaAvtoparkA.ViewModels.Windows;
using FluentKursovayaAvtoparkA.Views.Windows;

namespace FluentKursovayaAvtoparkA.Views.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    ///
    public partial class ContentDialogViewModel(IContentDialogService contentDialogService) : ObservableObject
    {
        [ObservableProperty]
        private string _dialogResultText = String.Empty;

        [RelayCommand]
        private async Task OnShowDialog(object content)
        {
            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = "Save your work?",
                    Content = content,
                    PrimaryButtonText = "Save",
                    SecondaryButtonText = "Don't Save",
                    CloseButtonText = "Cancel",
                }
            );

            DialogResultText = result switch
            {
                ContentDialogResult.Primary => "User saved their work",
                ContentDialogResult.Secondary => "User did not save their work",
                _ => "User cancelled the dialog"
            };
        }

        [RelayCommand]
        public async Task OnShowSignInContentDialog(MainWindowViewModel  ViewModel)
        {
            
        }
    }

    public partial class SettingsPage : INavigableView<ViewModels.SettingsViewModel>
    {
        public static string a;

        public static string formations =
            "server=localhost;Initial Catalog=KursovayaAvtoparkAvtobusov;User ID=sa;Password=ctrt55xx;";

        public static string exporttheme = "theme_dark";
        public ViewModels.SettingsViewModel ViewModel { get; }

        public SettingsPage(ViewModels.SettingsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

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


        private async void DatabaseOptionbutton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("В процессе разработки");
                
                ContentDialogService servics = new ContentDialogService();

              
                   // ContentPresenter fcontentpresenter = MainWindow.ContentPresenterexport;
                
               
                   // var termsOfUseContentDialog = new CallSQLConnectionSettingsContentDialog(fcontentpresenter,MainWindow.ViewModelexport);

                    //_ = await termsOfUseContentDialog.ShowAsync();
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            
        }
    }
}