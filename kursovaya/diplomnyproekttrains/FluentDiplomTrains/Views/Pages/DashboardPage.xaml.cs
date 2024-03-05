using System.Data;
using System.Windows;
using System;
using System.Data.SqlClient;
using System.Windows.Input;
using Wpf.Ui.Controls;
using MessageBox = Wpf.Ui.Controls.MessageBox;
using TextBlock = System.Windows.Controls.TextBlock;

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
               
                var select2 = "SELECT * FROM Jobs";
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
                var Num = Exed1.Text;
                var EmpName = Exed2.Text;
                var EmpsurName = Exed3.Text;
                var Emppat = Exed4.Text;
                var EmpES = Exed5.Text;
                var Empnum = int.Parse(Exed6.Text);
                var Empinternyesorno = Exed7.Text;
                var Empjobtitle = Exed8.Text;
                var query = "INSERT INTO Employees(Num, Surname, Name, Patronym,Employed_Since,Job_Num) " +
                            "Values('" + Num + "', '" + EmpName + "', '" + EmpsurName + "', '" + Emppat + "','" + EmpES +
                            "','" + Empnum + "')";
                var query2 = "INSERT INTO Jobs(Job_Num, Job, Internship) " +
                            "Values('" + Empnum + "', '" + Empjobtitle + "', '" + Empinternyesorno + "')";
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

        private void EmpUpdat_Click(object sender, RoutedEventArgs e)
        {

            
            
            
            try
            {
                var Num = Exed1.Text;
                var EmpName = Exed2.Text;
                var EmpsurName = Exed3.Text;
                var Emppat = Exed4.Text;
                var EmpES = Exed5.Text;
                var Empnum = int.Parse(Exed6.Text);
                var Empinternyesorno = Exed7.Text;
                var Empjobtitle = Exed8.Text;
                SqlConnection cnn;
                var conStr = SettingsPage.formations;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var select =
                    "UPDATE Employees SET Surname=@a1,Name=@a2," +
                    "Patronym=@a3,Employed_Since=@a4," +
                    "Job_Num=@a5 WHERE Num=@a7";
                var querier2 =
                    "UPDATE Jobs SET Job=@a4,Internship=@a3 WHERE Job_Num=@a6";
                var commandBuilder = new SqlCommand(select, cnn);
                var commandBuilder2 = new SqlCommand(querier2, cnn);
                commandBuilder.Parameters.AddWithValue("a1",EmpsurName);
                commandBuilder.Parameters.AddWithValue("a2", EmpName);
                commandBuilder.Parameters.AddWithValue("a3", Emppat);
                commandBuilder.Parameters.AddWithValue("a4", EmpES);
                commandBuilder.Parameters.AddWithValue("a5", Empnum);
                commandBuilder2.Parameters.AddWithValue("a6", Empnum);
                commandBuilder2.Parameters.AddWithValue("a4", Empjobtitle);
                commandBuilder2.Parameters.AddWithValue("a3", Empinternyesorno);
                commandBuilder.Parameters.AddWithValue("a7", int.Parse(Num));
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

        private void Exed8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Exed8.Clear();
        }
    }
}