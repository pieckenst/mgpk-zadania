using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    /// Interaction logic for TexObslugWindow.xaml
    /// </summary>
    public partial class TexObslugWindow : Window
    {
        public TexObslugWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try {
                string Num = AvEditor1.Text;
                string ModAvtobus = AvEditor2.Text;
                string DatObslug = AvEditor3.Text;
                string Engineer = AvEditor4.Text;
                string ErAvto = AvEditor5.Text;
                string DatSlegObslug = AvEditor6.Text;
                string GodDorog = AvEditor7.Text;
                string query = "INSERT INTO Maintenance(Num, Model_Avtobusa, Data_Poslednego_Obsluzhivania, Ingener_Obsluzhivania,Problemi_Avtobusa,Data_Sledueschego_Obsluzivania,Goden_K_Doroge) " +
                   "Values('" + Num + "', '" + ModAvtobus + "', '" + DatObslug + "', '" + Engineer + "','" + ErAvto + "','" + DatSlegObslug + "','" + GodDorog + "')";
                SqlConnection cnn;
                string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

                cnn = new SqlConnection(conStr);
                cnn.Open();
                SqlCommand command = new SqlCommand(query, cnn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted!\n Closing connection ");
                cnn.Close();
                Console.WriteLine("Connection has been closed , database ready for next operation!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured! Traceback: {0} ", ex.Message);
            }
        }

        private void UpdateGrid_Click(object sender, RoutedEventArgs e)
        {
            try {
                SqlConnection cnn;
                string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                Console.Write("[MENU] Connect db clicked - test \n");
                var select = "SELECT * FROM Maintenance";

                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandBuilder);
                DataTable ds = new DataTable("Avtobusx");
                dataAdapter.Fill(ds);
                dataGrid1.ItemsSource = ds.DefaultView;
                Console.WriteLine("Connection established and the datagrid filled!");
                cnn.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured! Traceback: {0} ", ex.Message);
            }
        }

        private void UpdateMaintenaceTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                string conStrs = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

                cnn = new SqlConnection(conStrs);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var querier = "UPDATE Maintenance SET Model_Avtobusa=@a1,Data_Poslednego_Obsluzhivania=@a2,Ingener_Obsluzhivania=@a3,Problemi_Avtobusa=@a4,Data_Sledueschego_Obsluzivania=@a5,Goden_K_Doroge=@a6 WHERE Num=@a7";
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
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured! Traceback: {0} ", ex.Message);
            }
        }
    }
}
