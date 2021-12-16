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

        private void UpdateGrid_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
