using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using Wpf.Ui.Controls;
using MessageBox = Wpf.Ui.Controls.MessageBox;
using TextBlock = System.Windows.Controls.TextBlock;

namespace FluentKursovayaAvtoparkA.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MaintenancePage.xaml
    /// </summary>
    public partial class MaintenancePage : INavigableView<ViewModels.MaintenancePageViewModel>
    {
        
        public ViewModels.MaintenancePageViewModel ViewModel
        {
            get;
        }

        public MaintenancePage(ViewModels.MaintenancePageViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Num = int.Parse(AvEditor1.Text);
                var ModAvtobus = int.Parse(AvEditor2.Text);
                var DatObslug = AvEditor3.Text;
                var Engineer = AvEditor4.Text;
                var ErAvto = AvEditor5.Text;
                var DatSlegObslug = AvEditor6.Text;
                var GodDorog = AvEditor7.Text;
                var ModelAvtobusaText = AvEditor8.Text;
                var query =
                    "INSERT INTO Obsluzhivanie(NomerObsluzhivania, Model_AvtobusaKey, Data_Poslednego_Obsluzhivania, Ingener_Obsluzhivania,Problemi_Avtobusa,Data_Sledueschego_Obsluzivania,Goden_K_Doroge) " +
                    "Values('" + Num + "', '" + ModAvtobus + "', '" + DatObslug + "', '" + Engineer + "','" + ErAvto +
                    "','" + DatSlegObslug + "','" + GodDorog + "')";
                var query2 = "INSERT INTO Avtobusy(Numavtobusy,Model_Avtobusa) " +
                             "Values('" + ModAvtobus + "', '" + ModelAvtobusaText  + "')";
                SqlConnection cnn;
                var conStr = SettingsPage.formations;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                var command2 = new SqlCommand(query2, cnn);
                command2.ExecuteNonQuery();
                var command = new SqlCommand(query, cnn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted!\n Closing connection ");
                cnn.Close();
                Console.WriteLine("Connection has been closed , database ready for next operation!");
                UpdateGrid_Click(sender, e);
            }
            catch (Exception ex)
            {
                var uiMessageBox = new MessageBox
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
                


                uiMessageBox.ShowDialogAsync();
            }
        }

        private void UpdateGrid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStr = SettingsPage.formations;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                Console.Write("[MENU] Connect db clicked - test \n");
                var select = "SELECT * FROM Obsluzhivanie";

                var select2 = "SELECT * FROM Avtobusy";
                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.ExecuteNonQuery();
                var commandBuilder2 = new SqlCommand(select2, cnn);
                commandBuilder2.ExecuteNonQuery();
                var dataAdapter = new SqlDataAdapter(commandBuilder);
                var dataAdapter2 = new SqlDataAdapter(commandBuilder2);
                var ds = new DataTable("Avtobusx");
                dataAdapter.Fill(ds);
                var ds2 = new DataTable("Avtobusxi");
                dataAdapter2.Fill(ds2);
                dataGrid1.ItemsSource = ds.DefaultView;
                dataGrid2.ItemsSource = ds2.DefaultView;
                Console.WriteLine("Connection established and the datagrid filled!");
                cnn.Close();
            }
            catch (Exception ex)
            {
                var uiMessageBox = new MessageBox
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
                

                uiMessageBox.ShowDialogAsync();
            }
        }

        private void UpdateMaintenaceTable_Click(object sender, RoutedEventArgs e)
        {
            var Num = int.Parse(AvEditor1.Text);
            var ModAvtobus = int.Parse(AvEditor2.Text);
            var DatObslug = AvEditor3.Text;
            var Engineer = AvEditor4.Text;
            var ErAvto = AvEditor5.Text;
            var DatSlegObslug = AvEditor6.Text;
            var GodDorog = AvEditor7.Text;
            var ModelAvtobusaText = AvEditor8.Text;
            try
            {
                SqlConnection cnn;
                var conStrs = SettingsPage.formations;

                cnn = new SqlConnection(conStrs);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var querier =
                    "UPDATE Obsluzhivanie SET Model_AvtobusaKey=@a1,Data_Poslednego_Obsluzhivania=@a2," +
                    "Ingener_Obsluzhivania=@a3,Problemi_Avtobusa=@a4," +
                    "Data_Sledueschego_Obsluzivania=@a5,Goden_K_Doroge=@a6" +
                    " WHERE NomerObsluzhivania=@a7";
                var querier2 =
                    "UPDATE Avtobusy SET Model_Avtobusa=@a4 WHERE Numavtobusy=@a6";
                var commandBuilder = new SqlCommand(querier, cnn);
                var commandBuilder2 = new SqlCommand(querier2, cnn);
                commandBuilder.Parameters.AddWithValue("a1", ModAvtobus);
                commandBuilder.Parameters.AddWithValue("a2", DatObslug);
                commandBuilder.Parameters.AddWithValue("a3", Engineer);
                commandBuilder.Parameters.AddWithValue("a4", ErAvto);
                commandBuilder2.Parameters.AddWithValue("a4", ModelAvtobusaText);
                commandBuilder.Parameters.AddWithValue("a5", DatSlegObslug);
                commandBuilder.Parameters.AddWithValue("a6", GodDorog);
                commandBuilder.Parameters.AddWithValue("a7", Num);
                commandBuilder2.Parameters.AddWithValue("a6", ModAvtobus);
                commandBuilder.ExecuteNonQuery();
                commandBuilder2.ExecuteNonQuery();
                Console.WriteLine("Connection established and the table updated!");
                cnn.Close();
                UpdateGrid_Click(sender, e);
            }

            catch (Exception ex)
            {
                var uiMessageBox = new MessageBox
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
                


                uiMessageBox.ShowDialogAsync();
            }
        }

        private void AvEditor1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AvEditor1.Clear();
        }

        private void AvEditor2_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AvEditor2.Clear();
        }

        private void AvEditor3_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AvEditor3.Clear();
        }

        private void AvEditor4_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AvEditor4.Clear();
        }

        private void AvEditor5_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AvEditor5.Clear();
        }

        private void AvEditor6_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AvEditor6.Clear();
        }

        private void AvEditor7_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AvEditor7.Clear();
        }
    }
}
