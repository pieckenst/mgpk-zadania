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
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Nav_Obslugers : Page
    {
        public Nav_Obslugers()
        {
            this.InitializeComponent();
        }

        private async void dataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection cnn;
            string conStr = ConnectionString.Constring;

            cnn = new SqlConnection(conStr);
            cnn.Open();
            Console.Write("OPENING DB CONNECTION!!! \n");
            Console.Write("[MENU] Connect db clicked - test \n");
            try
            {
                var select = "SELECT * FROM Maintenance";

                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandBuilder);
                DataTable ds = new DataTable("Avtobusx");
                dataAdapter.Fill(ds);
                dataGrid1.Columns.Clear();
                for (int i = 0; i < ds.Columns.Count; i++)
                {
                    dataGrid1.Columns.Add(new DataGridTextColumn()
                    {
                        Header = ds.Columns[i].ColumnName,
                        Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                    });
                }

                var collection = new ObservableCollection<object>();
                foreach (DataRow row in ds.Rows)
                {
                    collection.Add(row.ItemArray);
                }

                dataGrid1.ItemsSource = collection;
                Console.WriteLine("Connection established and the datagrid filled!");
                cnn.Close();
            }
            catch (Exception ex)
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

        private async void ClickSendDb_Click(object sender, RoutedEventArgs e)
        { 
            try {
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
                string conStr = ConnectionString.Constring;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                SqlCommand command = new SqlCommand(query, cnn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted!\n Updating grid");
                var select = "SELECT * FROM Maintenance";
                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandBuilder);
                DataTable ds = new DataTable("Avtobusx");
                dataAdapter.Fill(ds);
                dataGrid1.Columns.Clear();
                for (int i = 0; i < ds.Columns.Count; i++)
                {
                    dataGrid1.Columns.Add(new DataGridTextColumn()
                    {
                        Header = ds.Columns[i].ColumnName,
                        Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                    });
                }

                var collection = new ObservableCollection<object>();
                foreach (DataRow row in ds.Rows)
                {
                    collection.Add(row.ItemArray);
                }

                dataGrid1.ItemsSource = collection;
                Console.WriteLine("Connection established and the datagrid filled!");
                cnn.Close();

                Console.WriteLine("Connection has been closed , database ready for next operation!");

            }
            catch (Exception ex)
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

        private async void UpdateTable_Click(object sender, RoutedEventArgs e)
        {
            try {
                SqlConnection cnn;
                string conStrs = ConnectionString.Constring;

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
                var select = "SELECT * FROM Maintenance";
                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandBuilder);
                DataTable ds = new DataTable("Avtobusx");
                dataAdapter.Fill(ds);
                dataGrid1.Columns.Clear();
                for (int i = 0; i < ds.Columns.Count; i++)
                {
                    dataGrid1.Columns.Add(new DataGridTextColumn()
                    {
                        Header = ds.Columns[i].ColumnName,
                        Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                    });
                }

                var collection = new ObservableCollection<object>();
                foreach (DataRow row in ds.Rows)
                {
                    collection.Add(row.ItemArray);
                }

                dataGrid1.ItemsSource = collection;
                Console.WriteLine("Connection established and the datagrid filled!");
                cnn.Close();
                Console.WriteLine("Connection has been closed , database ready for next operation!");

            }
            catch (Exception ex)
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
    }
}
