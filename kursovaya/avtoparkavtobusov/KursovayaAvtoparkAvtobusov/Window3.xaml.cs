﻿using System;
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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
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
            var select = "SELECT * FROM Prodazhi";

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
            string Num= Edit1.Text;
            string SaleDat =  Edit2.Text;
            string NomAvtobus = Edit3.Text;
            string Punkt = Edit4.Text;
            string Stoimost = Edit5.Text;
            string query = "INSERT INTO Prodazhi(Num, Sale_Date, Nomer_Avtobusa, Punkt_Posadki,Stoimost) " +
               "Values('" + Num + "', '" + SaleDat + "', '" + NomAvtobus + "', '" + Punkt + "','" + Stoimost + "')";
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
