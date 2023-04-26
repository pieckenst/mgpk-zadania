using FluentKursovayaAvtoparkA.Views.Windows;
using MsgBoxEx;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Common.Interfaces;
using MessageBox = Wpf.Ui.Controls.MessageBox;

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

                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.ExecuteNonQuery();

                var dataAdapter = new SqlDataAdapter(commandBuilder);
                var ds = new DataTable("Avtobusx");
                dataAdapter.Fill(ds);
                dataGrid1.ItemsSource = ds.DefaultView;
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
                    ButtonLeftName = "OK",
                    ButtonRightName = "Отмена",
                    Width = 800,
                    Height = 300,

                };
                uiMessageBox.ButtonLeftClick += (s, e) =>
                {

                    uiMessageBox.Close();
                };
                uiMessageBox.ButtonRightClick += (s, e) =>
                {

                    uiMessageBox.Close();
                };


                uiMessageBox.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Num = Edit1.Text;
                var SaleDat = Edit2.Text;
                var NomAvtobus = Edit3.Text;
                var Punkt = Edit4.Text;
                var Stoimost = Edit5.Text;
                var query = "INSERT INTO Prodazhi(Num, Sale_Date, Nomer_Avtobusa, Punkt_Posadki,Stoimost) " +
                            "Values('" + Num + "', '" + SaleDat + "', '" + NomAvtobus + "', '" + Punkt + "','" +
                            Stoimost + "')";
                SqlConnection cnn;
                var conStr = SettingsPage.formations;

                cnn = new SqlConnection(conStr);
                cnn.Open();
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
                    ButtonLeftName = "OK",
                    ButtonRightName = "Отмена",
                    Width = 800,
                    Height = 300,

                };
                uiMessageBox.ButtonLeftClick += (s, e) =>
                {

                    uiMessageBox.Close();
                };
                uiMessageBox.ButtonRightClick += (s, e) =>
                {

                    uiMessageBox.Close();
                };


                uiMessageBox.ShowDialog();
            }
        }

        private void SaleUpdateDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStrs = SettingsPage.formations;

                cnn = new SqlConnection(conStrs);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var querier =
                    "UPDATE Prodazhi SET Sale_Date=@a1,Nomer_Avtobusa=@a2,Punkt_Posadki=@a3,Stoimost=@a4 WHERE Num=@a5";
                var commandBuilder = new SqlCommand(querier, cnn);
                commandBuilder.Parameters.AddWithValue("a1", Edit2.Text);
                commandBuilder.Parameters.AddWithValue("a2", int.Parse(Edit3.Text));
                commandBuilder.Parameters.AddWithValue("a3", Edit4.Text);
                commandBuilder.Parameters.AddWithValue("a4", Edit5.Text);
                commandBuilder.Parameters.AddWithValue("a5", int.Parse(Edit1.Text));
                commandBuilder.ExecuteNonQuery();
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
                    ButtonLeftName = "OK",
                    ButtonRightName = "Отмена",
                    Width = 800,
                    Height = 300,

                };
                uiMessageBox.ButtonLeftClick += (s, e) =>
                {

                    uiMessageBox.Close();
                };
                uiMessageBox.ButtonRightClick += (s, e) =>
                {

                    uiMessageBox.Close();
                };


                uiMessageBox.ShowDialog();
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
    }
}
