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
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class TicketPage : INavigableView<ViewModels.TicketPageViewModel>
    {
       
        public ViewModels.TicketPageViewModel ViewModel
        {
            get;
        }

        public TicketPage(ViewModels.TicketPageViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
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
                var select = "SELECT * FROM Prodazhi";
                var select2 = "SELECT * FROM Bilety";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Num = Edit1.Text;
                var SaleDat = Edit2.Text;
                var NomBiltetaKey = int.Parse(Edit3.Text);
                var Nomer_Biletaex = Edit4.Text;
                var Nomer_MarshutaKey = Edit5.Text;
                var Stoimost = Edit6.Text;
                var query = "INSERT INTO Prodazhi(Num, Sale_Date, Nomer_BiletaKey) " +
                            "Values('" + Num + "', '" + SaleDat + "', '" + NomBiltetaKey  + "')";
                var query2 = "INSERT INTO Bilety(Nomer_Bileta, Nomer_MarshutaKey, Stoimost) " +
                             "Values('" + Nomer_Biletaex + "', '" + Nomer_MarshutaKey + "', '" + Stoimost + "')";
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

        private void SaleUpdateDB_Click(object sender, RoutedEventArgs e)
        {
            var Num = int.Parse(Edit1.Text);
            var SaleDat = Edit2.Text;
            var NomBiltetaKey = int.Parse(Edit3.Text);
            var Nomer_Biletaex = Edit4.Text;
            var Nomer_MarshutaKey = Edit5.Text;
            var Stoimost = Edit6.Text;
            try
            {
                SqlConnection cnn;
                var conStrs = SettingsPage.formations;

                cnn = new SqlConnection(conStrs);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var querier =
                    "UPDATE Prodazhi SET Sale_Date=@a1,Nomer_BiletaKey=@a2 WHERE Num=@a5";
                var querier2 =
                    "UPDATE Bilety SET Stoimost=@a4,Nomer_MarshutaKey=@a3 WHERE Nomer_Bileta=@a6";
                var commandBuilder = new SqlCommand(querier, cnn);
                var commandBuilder2 = new SqlCommand(querier2, cnn);
                commandBuilder.Parameters.AddWithValue("a1", SaleDat);
                commandBuilder.Parameters.AddWithValue("a2", NomBiltetaKey);
                commandBuilder2.Parameters.AddWithValue("a3", Nomer_MarshutaKey);
                commandBuilder2.Parameters.AddWithValue("a4", Stoimost);
                commandBuilder.Parameters.AddWithValue("a5", Num);
                commandBuilder2.Parameters.AddWithValue("a6", Nomer_Biletaex);
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

        private void Edit1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Edit1.Clear();
        }

        private void Edit2_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Edit2.Clear();
        }

        private void Edit3_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Edit3.Clear();
        }

        private void Edit4_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Edit4.Clear();
        }

        private void Edit5_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Edit5.Clear();
        }
        private void Edit6_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Edit6.Clear();
        }
    }
}
