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
            string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

            cnn = new SqlConnection(conStr);
            cnn.Open();
            Console.Write("OPENING DB CONNECTION!!! \n");
            var select = "UPDATE Prodazhi SET Sale_Date=@a1,Nomer_Avtobusa=@a2,Punkt_Posadki=@a3,Stoimost=@a4 WHERE Num=@a5";
            var commandBuilder = new SqlCommand(select, cnn);
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
    }
}
