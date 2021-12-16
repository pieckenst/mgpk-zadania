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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void closer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void deletedbdata_Click(object sender, RoutedEventArgs e)
        {
            if (TableName.Text == "Prodazhi")
            {
                SqlConnection cnn;
                string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var select = "DELETE FROM Prodazhi WHERE Num=@a2";
                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.Parameters.AddWithValue("a2", keybox.Text);
                try
                {
                    commandBuilder.ExecuteNonQuery();
                    Console.WriteLine("Delete operation successful!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (TableName.Text ==  "Marshuti") {
                SqlConnection cnn;
                string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var select = "DELETE FROM Marshuti WHERE Nomer_Marshuta=@a2";
                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.Parameters.AddWithValue("a2", keybox.Text);
                try
                {
                    commandBuilder.ExecuteNonQuery();
                    Console.WriteLine("Delete operation successful!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (TableName.Text == "Maintenance") {
                SqlConnection cnn;
                string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var select = "DELETE FROM Maintenance WHERE Num=@a2";
                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.Parameters.AddWithValue("a2", keybox.Text);
                try
                {
                    commandBuilder.ExecuteNonQuery();
                    Console.WriteLine("Delete operation successful!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Введено неправильное имя таблицы! Пожалуйста введите одно из следующих - Prodazhi или Marshuti или Maintenance!");
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
