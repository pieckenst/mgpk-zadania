// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using ComposerAndTheirWorks.ViewModels.Pages;
using ComposerAndTheirWorks.Views.Windows;
using System.Data.SqlClient;
using System.Data;
using Wpf.Ui.Controls;
using System;
using System.Windows.Controls;

namespace ComposerAndTheirWorks.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public DashboardPage(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStr = MainWindow.formations;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                Console.Write("[MENU] Connect db clicked - test \n");
                var select = "SELECT * FROM ComposerWorksList";

                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.ExecuteNonQuery();

                var dataAdapter = new SqlDataAdapter(commandBuilder);
                var ds = new DataTable("Avtobusx");
                dataAdapter.Fill(ds);
                datagrid1.ItemsSource = ds.DefaultView;
                Console.WriteLine("Connection established and the datagrid filled!");
                cnn.Close();

            }
            catch (Exception ex)
            {
                Console.Write("Error");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var CompKey = Edit1.Text;
                var NameOfWork = Edit2.Text;
                var CreationDate = Edit3.Text;
                var LinkCompKey = Edit4.Text;
                var CompNameSurname = Edit5.Text;
                
                var query =
                    "INSERT INTO ComposerWorksList(ComposerWorkKey, WorkName, DateOfCreation, LinkComposerKey,NameAndSurnameComposer) " +
                    "Values('" + CompKey + "', '" + NameOfWork + "', '" + CreationDate + "', '" + LinkCompKey + "','" +
                    CompNameSurname + "')";
                SqlConnection cnn;
                var conStr = MainWindow.formations;

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
                Console.WriteLine(ex.ToString());
            }
    }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection cnn;
            var conStr = MainWindow.formations;

            cnn = new SqlConnection(conStr);
            cnn.Open();
            Console.Write("OPENING DB CONNECTION!!! \n");
            var select = "DELETE FROM ComposerWorksList WHERE ComposerWorkKey=@a2";
            var commandBuilder = new SqlCommand(select, cnn);
            commandBuilder.Parameters.AddWithValue("a2", Edit1.Text);
            try
            {
                commandBuilder.ExecuteNonQuery();
                Console.WriteLine("Delete operation successful!");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
                try
                {
                    SqlConnection cnn;
                    var conStr = MainWindow.formations;

                    cnn = new SqlConnection(conStr);
                    cnn.Open();
                    Console.Write("OPENING DB CONNECTION!!! \n");
                    Console.Write("[MENU] Connect db clicked - test \n");
                    var select = "Select * FROM ComposerWorksList WHERE NameAndSurnameComposer Like '%" + searchbox.Text + "%'";

                    var commandBuilder = new SqlCommand(select, cnn);
                    
                    commandBuilder.ExecuteNonQuery();

                    var dataAdapter = new SqlDataAdapter(commandBuilder);
                    var ds = new DataTable("Avtobusx");
                    dataAdapter.Fill(ds);
                    datagrid1.ItemsSource = ds.DefaultView;
                    Console.WriteLine("Connection established and the datagrid filled!");
                    cnn.Close();

                }
                catch (Exception ex)
                {
                    Console.Write("Error");
                }

            

        }
    }
}
