using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    ///     Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
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
                MessageBox.Show("An error has occured! Traceback: " + ex.Message);
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

        private void SaleUpdateDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStrs = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

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
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error has occured! Traceback: " + ex.Message);
            }
        }
    }
}