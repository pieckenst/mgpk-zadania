using System;
using System.Data.SqlClient;
using System.Linq;
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
using Wpf.Ui.Appearance;

namespace FluentKursovayaAvtoparkA.Views.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    ///
    public partial class ContentDialogViewModel(IContentDialogService contentDialogService) : ObservableObject
    {
        [ObservableProperty] private string _dialogResultText = String.Empty;

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
        public async Task OnShowSignInContentDialog(MainWindowViewModel ViewModel)
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
                System.Windows.Forms.Application.EnableVisualStyles();


                var form1 = new FormConnectToSQLServer();
                form1.ShowDialog();
                var a = form1.ConnectionString;
                SettingsPage.formations = a + ";Initial Catalog=KursovayaAvtoparkAvtobusov";
                form1.Close();

            }
            catch (Exception exception)
            {
                var uiMessageBox = new MessageBox
                {
                    Title = "Обработка ошибок",
                    Content = new TextBlock
                    {
                        Text = exception.Message,
                        TextWrapping = TextWrapping.Wrap,
                    },

                    Width = 800,
                    Height = 300,

                };


                uiMessageBox.ShowDialogAsync();
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)cmbSelect.SelectedItem;
            string value = typeItem.Content.ToString();
            var CurrentApplicationTheme = ApplicationThemeManager.GetAppTheme();
            var selectedthemedef = CurrentApplicationTheme.ToString();
            Console.WriteLine(selectedthemedef);



            switch (value)
            {
                case "Темная":
                    if (CurrentApplicationTheme != ApplicationTheme.Dark)
                    {
                        ApplicationThemeManager.Apply(ApplicationTheme.Dark);
                        CurrentApplicationTheme = ApplicationTheme.Dark;
                    }
                    else
                        break;

                    break;

                case "Светлая":
                    if (CurrentApplicationTheme != ApplicationTheme.Light)
                    {
                        ApplicationThemeManager.Apply(ApplicationTheme.Light);
                        CurrentApplicationTheme = ApplicationTheme.Light;
                    }
                    else
                        break;


                    break;

                case "Высокий контраст":
                    if (CurrentApplicationTheme != ApplicationTheme.HighContrast)
                    {
                        ApplicationThemeManager.Apply(ApplicationTheme
                            .HighContrast);
                        CurrentApplicationTheme = ApplicationTheme.HighContrast;
                    }
                    else
                        break;


                    break;




                    break;
                default:
                    ApplicationThemeManager.Apply(ApplicationTheme.Dark);
                    CurrentApplicationTheme = ApplicationTheme.Dark;


                    break;
            }
        }

        private void deletedbdata_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("в процессе");
            string value = SlctTable.SelectionBoxItem.ToString();
            switch (value)
            {
                case "Prodazhi":
                {
                    SqlConnection cnn;
                    var conStr = SettingsPage.formations;

                    cnn = new SqlConnection(conStr);
                    cnn.Open();
                    Console.Write("OPENING DB CONNECTION!!! \n");
                    var select = "DELETE FROM Prodazhi WHERE Num=@a2";
                    var commandBuilder = new SqlCommand(select, cnn);
                    commandBuilder.Parameters.AddWithValue("a2", keybox.Text);
                    try
                    {
                        commandBuilder.ExecuteNonQuery();
                        Console.WriteLine("Delete operation successful!");
                    }
                    catch (SqlException ex)
                    {
                        var uiMessageBox1 = new MessageBox
                        {
                            Title = "Обработка ошибок",
                            Content = new TextBlock
                            {
                                Text = ex.Message,
                                TextWrapping = TextWrapping.Wrap,
                            },

                            Width = 800,
                            Height = 300,

                        };


                        uiMessageBox1.ShowDialogAsync();

                    }

                    break;
                }

                case "Marshuti":
                {
                    SqlConnection cnn;
                    var conStr = SettingsPage.formations;

                    cnn = new SqlConnection(conStr);
                    cnn.Open();
                    Console.Write("OPENING DB CONNECTION!!! \n");
                    var select = "DELETE FROM Marshuti WHERE Nomer_Marshuta=@a2";
                    var commandBuilder = new SqlCommand(select, cnn);
                    commandBuilder.Parameters.AddWithValue("a2", keybox.Text);
                    try
                    {
                        commandBuilder.ExecuteNonQuery();
                        Console.WriteLine("Delete operation successful!");
                    }
                    catch (SqlException ex)
                    {
                        var uiMessageBox2 = new MessageBox
                        {
                            Title = "Обработка ошибок",
                            Content = new TextBlock
                            {
                                Text = ex.Message,
                                TextWrapping = TextWrapping.Wrap,
                            },

                            Width = 800,
                            Height = 300,

                        };
                        uiMessageBox2.ShowDialogAsync();

                    }

                    break;
                }

                case "Maintenance":
                {
                    SqlConnection cnn;
                    var conStr = SettingsPage.formations;

                    cnn = new SqlConnection(conStr);
                    cnn.Open();
                    Console.Write("OPENING DB CONNECTION!!! \n");
                    var select = "DELETE FROM Obsluzhivanie WHERE NomerObsluzhivania=@a2";
                    var commandBuilder = new SqlCommand(select, cnn);
                    commandBuilder.Parameters.AddWithValue("a2", keybox.Text);
                    try
                    {
                        commandBuilder.ExecuteNonQuery();
                        Console.WriteLine("Delete operation successful!");
                    }
                    catch (SqlException ex)
                    {
                        var uiMessageBox4 = new MessageBox
                        {
                            Title = "Обработка ошибок",
                            Content = new TextBlock
                            {
                                Text = ex.Message,
                                TextWrapping = TextWrapping.Wrap,
                            },

                            Width = 800,
                            Height = 300,

                        };
                        uiMessageBox4.ShowDialogAsync();

                    }

                    break;
                }

                case "Employees":
                {
                    SqlConnection cnn;
                    var conStr = SettingsPage.formations;

                    cnn = new SqlConnection(conStr);
                    cnn.Open();
                    Console.Write("OPENING DB CONNECTION!!! \n");
                    var select = "DELETE FROM Employees WHERE Num=@a2";
                    var commandBuilder = new SqlCommand(select, cnn);
                    commandBuilder.Parameters.AddWithValue("a2", keybox.Text);
                    try
                    {
                        commandBuilder.ExecuteNonQuery();
                        Console.WriteLine("Delete operation successful!");
                    }
                    catch (SqlException ex)
                    {
                        var uiMessageBox3 = new MessageBox
                        {
                            Title = "Обработка ошибок",
                            Content = new TextBlock
                            {
                                Text = ex.Message,
                                TextWrapping = TextWrapping.Wrap,
                            },

                            Width = 800,
                            Height = 300,

                        };
                        uiMessageBox3.ShowDialogAsync();

                    }

                    break;
                }

                default:
                    
                    var uiMessageBox = new MessageBox
                    {
                        Title = "Обработка ошибок",
                        Content = new TextBlock
                        {
                            Text = "Введено неправильное имя таблицы! Пожалуйста введите одно из следующих" +
                                   " - Prodazhi или Marshuti или Maintenance или Employees!",
                            TextWrapping = TextWrapping.Wrap,
                        },

                        Width = 800,
                        Height = 300,

                    };
                    uiMessageBox.ShowDialogAsync();
                    
                    //("Введено неправильное имя таблицы!
                    //Пожалуйста введите одно из следующих - Prodazhi или Marshuti или
                    //Maintenance или Employees!");

                    break;
            }
        }
    }
}