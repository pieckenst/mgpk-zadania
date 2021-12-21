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
    /// Interaction logic for EmpRecord.xaml
    /// </summary>
    public partial class EmpRecord : Window
    {
        public EmpRecord()
        {
            InitializeComponent();
        }

        private void UpdateGrid_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnn;
            string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

            cnn = new SqlConnection(conStr);
            cnn.Open();
            Console.Write("OPENING DB CONNECTION!!! \n");
            Console.Write("[MENU] Connect db clicked - test \n");
            var select = "SELECT * FROM Employees";

            var commandBuilder = new SqlCommand(select, cnn);
            commandBuilder.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandBuilder);
            DataTable ds = new DataTable("Avtobusx");
            dataAdapter.Fill(ds);
            dataGrid1.ItemsSource = ds.DefaultView;
            Console.WriteLine("Connection established and the datagrid filled!");
            cnn.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Num = Exed1.Text;
            string EmpName = Exed2.Text;
            string EmpsName = Exed3.Text;
            string Emppat = Exed4.Text;
            string EmpES = Exed5.Text;
            string Emptitle = Exed6.Text;
            string Empint = Exed7.Text;
            string query = "INSERT INTO Employees(Num, Surname, Name, Patronym,Employed_Since,Job,Internship) " +
               "Values('" + Num + "', '" + EmpName + "', '" + EmpsName + "', '" + Emppat + "','" + EmpES + "','" + Emptitle + "','" + Empint + "')";
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
    }
}
