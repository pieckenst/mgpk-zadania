using PostSharp.Patterns.Diagnostics;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    ///     Interaction logic for Window4.xaml
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

        [Log("Audit")]
        private void deletedbdata_Click(object sender,
            RoutedEventArgs e)
        {
            switch (TableName.Text)
            {
                case "Prodazhi":
                    {
                        SqlConnection cnn;
                        var conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

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

                        break;
                    }

                case "Marshuti":
                    {
                        SqlConnection cnn;
                        var conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

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

                        break;
                    }

                case "Maintenance":
                    {
                        SqlConnection cnn;
                        var conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

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

                        break;
                    }

                case "Employees":
                    {
                        SqlConnection cnn;
                        var conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

                        cnn = new SqlConnection(conStr);
                        cnn.Open();
                        Console.Write("OPENING DB CONNECTION!!! \n");
                        var select = "DELETE FROM Employees WHERE Num=@a2";
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

                        break;
                    }

                default:
                    MessageBox.Show(
                        "Введено неправильное имя таблицы! Пожалуйста введите одно из следующих - Prodazhi или Marshuti или Maintenance!");
                    break;
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }
    }
}