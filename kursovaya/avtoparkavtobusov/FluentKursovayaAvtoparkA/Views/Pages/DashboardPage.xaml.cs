using FluentKursovayaAvtoparkA.Views.Windows;
using System.Data;
using System.Windows;
using System;
using Wpf.Ui.Common.Interfaces;
using System.Data.SqlClient;
using MsgBoxEx;
using System.Windows.Controls;
using MessageBox = Wpf.Ui.Controls.MessageBox;

namespace FluentKursovayaAvtoparkA.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : INavigableView<ViewModels.DashboardViewModel>
    {
        public ViewModels.DashboardViewModel ViewModel
        {
            get;
        }

        public DashboardPage(ViewModels.DashboardViewModel viewModel)
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
                var select = "SELECT * FROM Employees";

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
                var Num = Exed1.Text;
                var EmpName = Exed2.Text;
                var EmpsName = Exed3.Text;
                var Emppat = Exed4.Text;
                var EmpES = Exed5.Text;
                var Emptitle = int.Parse(Exed6.Text);
                var Empint = Exed7.Text;
                var query = "INSERT INTO Employees(Num, Surname, Name, Patronym,Employed_Since,Job_Num) " +
                            "Values('" + Num + "', '" + EmpName + "', '" + EmpsName + "', '" + Emppat + "','" + EmpES +
                            "','" + Emptitle  + "')";
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

        private void EmpUpdat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStr = SettingsPage.formations;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var select =
                    "UPDATE Employees SET Surname=@a1,Name=@a2,Patronym=@a3,Employed_Since=@a4,Job_Num=@a5 WHERE Num=@a7";
                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.Parameters.AddWithValue("a1", Exed2.Text);
                commandBuilder.Parameters.AddWithValue("a2", Exed3.Text);
                commandBuilder.Parameters.AddWithValue("a3", Exed4.Text);
                commandBuilder.Parameters.AddWithValue("a4", Exed5.Text);
                commandBuilder.Parameters.AddWithValue("a5", int.Parse(Exed6.Text));
                
                commandBuilder.Parameters.AddWithValue("a7", int.Parse(Exed1.Text));
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

        private void Exed1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Exed1.Clear();
        }

        private void Exed4_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Exed4.Clear();
        }

        private void Exed7_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Exed7.Clear();
        }

        private void Exed2_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Exed2.Clear();
        }

        private void Exed5_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Exed5.Clear();
        }

        private void Exed3_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Exed3.Clear();
        }

        private void Exed6_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Exed6.Clear();
        }
    }
}