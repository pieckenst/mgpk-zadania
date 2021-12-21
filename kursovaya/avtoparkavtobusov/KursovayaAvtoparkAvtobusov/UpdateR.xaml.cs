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
    /// Interaction logic for UpdateR.xaml
    /// </summary>
    public partial class UpdateR : Window
    {
        public UpdateR()
        {
            InitializeComponent();
        }

        private void SaleUpdateDB_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnn;
            string conStrs = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

            cnn = new SqlConnection(conStrs);
            cnn.Open();
            Console.Write("OPENING DB CONNECTION!!! \n");
            var querier = "UPDATE Prodazhi SET Sale_Date=@a1,Nomer_Avtobusa=@a2,Punkt_Posadki=@a3,Stoimost=@a4 WHERE Num=@a5";
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

        private void UpdateTransportTable_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnn;
            string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

            cnn = new SqlConnection(conStr);
            cnn.Open();
            Console.Write("OPENING DB CONNECTION!!! \n");
            var select = "UPDATE Marshuti SET Nachalni_Punkt=@a1,Konechni_Punkt=@a2,Voditel=@a3,Model_Avtobusa=@a4,Vremya_Proezda=@a5 WHERE Nomer_Marshuta=@a6";
            var commandBuilder = new SqlCommand(select, cnn);
            commandBuilder.Parameters.AddWithValue("a1", Editor2.Text);
            commandBuilder.Parameters.AddWithValue("a2", Editor3.Text);
            commandBuilder.Parameters.AddWithValue("a3", Editor4.Text);
            commandBuilder.Parameters.AddWithValue("a4", Editor5.Text);
            commandBuilder.Parameters.AddWithValue("a5", Editor6.Text);
            commandBuilder.Parameters.AddWithValue("a6", int.Parse(Editor1.Text));
            commandBuilder.ExecuteNonQuery();
            Console.WriteLine("Connection established and the table updated!");
            cnn.Close();
        }

        private void UpdateMaintenaceTable_Click(object sender, RoutedEventArgs e)
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

        private void EmpUpdat_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnn;
            string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

            cnn = new SqlConnection(conStr);
            cnn.Open();
            Console.Write("OPENING DB CONNECTION!!! \n");
            var select = "UPDATE Employees SET Surname=@a1,Name=@a2,Patronym=@a3,Employed_Since=@a4,Job=@a5,Internship=@a6 WHERE Num=@a7";
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
    }
}
