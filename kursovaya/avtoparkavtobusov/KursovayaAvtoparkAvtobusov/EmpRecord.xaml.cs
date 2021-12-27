using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    ///     Interaction logic for EmpRecord.xaml
    /// </summary>
    public partial class EmpRecord : Window
    {
        public EmpRecord()
        {
            InitializeComponent();
        }

        private void UpdateGrid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

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
                MessageBox.Show("An error has occured! Traceback: " + ex.Message);
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
                var Emptitle = Exed6.Text;
                var Empint = Exed7.Text;
                var query = "INSERT INTO Employees(Num, Surname, Name, Patronym,Employed_Since,Job,Internship) " +
                            "Values('" + Num + "', '" + EmpName + "', '" + EmpsName + "', '" + Emppat + "','" + EmpES +
                            "','" + Emptitle + "','" + Empint + "')";
                SqlConnection cnn;
                var conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

                cnn = new SqlConnection(conStr);
                cnn.Open();
                var command = new SqlCommand(query, cnn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted!\n Closing connection ");
                cnn.Close();
                Console.WriteLine("Connection has been closed , database ready for next operation!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured! Traceback: " + ex.Message);
            }
        }

        private void EmpUpdat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var select =
                    "UPDATE Employees SET Surname=@a1,Name=@a2,Patronym=@a3,Employed_Since=@a4,Job=@a5,Internship=@a6 WHERE Num=@a7";
                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.Parameters.AddWithValue("a1", Exed2.Text);
                commandBuilder.Parameters.AddWithValue("a2", Exed3.Text);
                commandBuilder.Parameters.AddWithValue("a3", Exed4.Text);
                commandBuilder.Parameters.AddWithValue("a4", Exed5.Text);
                commandBuilder.Parameters.AddWithValue("a5", Exed6.Text);
                commandBuilder.Parameters.AddWithValue("a6", Exed7.Text);
                commandBuilder.Parameters.AddWithValue("a7", int.Parse(Exed1.Text));
                commandBuilder.ExecuteNonQuery();
                Console.WriteLine("Connection established and the table updated!");
                cnn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error has occured! Traceback: " + ex.Message);
            }
        }
    }
}