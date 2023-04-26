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
                var Num = AvEditor1.Text;
                var ModAvtobus = AvEditor2.Text;
                var DatObslug = AvEditor3.Text;
                var Engineer = AvEditor4.Text;
                var ErAvto = AvEditor5.Text;
                var DatSlegObslug = AvEditor6.Text;
                var GodDorog = AvEditor7.Text;
                var query =
                    "INSERT INTO Maintenance(Num, Model_Avtobusa, Data_Poslednego_Obsluzhivania, Ingener_Obsluzhivania,Problemi_Avtobusa,Data_Sledueschego_Obsluzivania,Goden_K_Doroge) " +
                    "Values('" + Num + "', '" + ModAvtobus + "', '" + DatObslug + "', '" + Engineer + "','" + ErAvto +
                    "','" + DatSlegObslug + "','" + GodDorog + "')";
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
                var select = "SELECT * FROM Maintenance";

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

        private void UpdateMaintenaceTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStrs = SettingsPage.formations;

                cnn = new SqlConnection(conStrs);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var querier =
                    "UPDATE Maintenance SET Model_Avtobusa=@a1,Data_Poslednego_Obsluzhivania=@a2,Ingener_Obsluzhivania=@a3,Problemi_Avtobusa=@a4,Data_Sledueschego_Obsluzivania=@a5,Goden_K_Doroge=@a6 WHERE Num=@a7";
                var commandBuilders = new SqlCommand(querier, cnn);
                commandBuilders.Parameters.AddWithValue("a1", AvEditor2.Text);
                commandBuilders.Parameters.AddWithValue("a2", AvEditor3.Text);
                commandBuilders.Parameters.AddWithValue("a3", AvEditor4.Text);
                commandBuilders.Parameters.AddWithValue("a4", AvEditor5.Text);
                commandBuilders.Parameters.AddWithValue("a5", AvEditor6.Text);
                commandBuilders.Parameters.AddWithValue("a6", AvEditor7.Text);
                commandBuilders.Parameters.AddWithValue("a7", int.Parse(AvEditor1.Text));
                commandBuilders.ExecuteNonQuery();
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
