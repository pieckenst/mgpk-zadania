using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPKursovayaAvtobus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Nav_deleters : Page
    {
        public Nav_deleters()
        {
            this.InitializeComponent();
        }

        private async void deleterbutton_Click(object sender, RoutedEventArgs e)
        {
            if (TableName.Text == "Prodazhi")
            {
                SqlConnection cnn;
                string conStr = ConnectionString.Constring;

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
                    var dialog = new ContentDialog()
                    {
                        Title = "An Exception has occured!",
                        Content = ex.Message,
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                }

            }
            else if (TableName.Text == "Marshuti")
            {
                SqlConnection cnn;
                string conStr = ConnectionString.Constring;

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
                    var dialog = new ContentDialog()
                    {
                        Title = "An Exception has occured!",
                        Content = ex.Message,
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                }
            }
            else if (TableName.Text == "Maintenance")
            {
                SqlConnection cnn;
                string conStr = ConnectionString.Constring;

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
                    var dialog = new ContentDialog()
                    {
                        Title = "An Exception has occured!",
                        Content = ex.Message,
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                }
            }
            else if (TableName.Text == "Employees")
            {
                SqlConnection cnn;
                string conStr = ConnectionString.Constring;

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
                    var dialog = new ContentDialog()
                    {
                        Title = "An Exception has occured!",
                        Content = ex.Message,
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                }
            }
            else
            {
                
                var dialog = new ContentDialog()
                {
                    Title = "Введено не подходящее значение",
                    Content = "Введено неправильное имя таблицы!",
                    CloseButtonText = "Ok"
                };
                
                await dialog.ShowAsync();
            }
        }
    }
}
