// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using ComposerAndTheirWorks.ViewModels.Pages;
using Wpf.Ui.Controls;
using System.Data.SqlClient;
using ComposerAndTheirWorks.Views.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows;

namespace ComposerAndTheirWorks.Views.Pages
{
    public partial class DataPage : INavigableView<DataViewModel>
    {
        

        public DataViewModel ViewModel { get; }

        public DataPage(DataViewModel viewModel)
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
                var select = "SELECT * FROM ComposerList";

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
                var WorksCount = Edit6.Text;
                var BirthDate = Edit7.Text;
                var DeathDate = Edit8.Text;
                var BirthYear = Edit9.Text;
                var DeathYear = Edit10.Text;
                var query =
                    "INSERT INTO ComposerList(ComposerKey, Name, Surname, MiddleName,Genre,Numberofworks,BirthDate,DeathDate,BirthYear,DeathYear) " +
                    "Values('" + CompKey + "', '" + NameOfWork + "', '" + CreationDate + "', '" + LinkCompKey + "','" +
                    CompNameSurname + "','" + WorksCount + "','" + BirthDate + "','" + DeathDate + "', '" + BirthYear + "','" + DeathYear + "' )";
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
            var select = "DELETE FROM ComposerList WHERE ComposerKey=@a2";
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
                var select = "Select * FROM ComposerList WHERE Surname Like '%" + searchbox.Text + "%'";

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

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStr = MainWindow.formations;
                var filterquery= "Cочетание Электронной и Классической музыки";
                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                Console.Write("[MENU] Connect db clicked - test \n");
                var select = "Select * FROM ComposerList WHERE Genre Like '%" + filterquery + "%'";

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

        private void genre3_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStr = MainWindow.formations;
                var filterquery = "Современная классическая музыка";
                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                Console.Write("[MENU] Connect db clicked - test \n");
                var select = "Select * FROM ComposerList WHERE Genre Like '%" + filterquery + "%'";

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

        private void genre2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStr = MainWindow.formations;
                var filterquery = "Классическая музыка";
                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                Console.Write("[MENU] Connect db clicked - test \n");
                var select = "Select * FROM ComposerList WHERE Genre Like '%" + filterquery + "%'";

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
