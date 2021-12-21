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
    public sealed partial class Nav_salers : Page
    {
        public Nav_salers()
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
                var select = "SELECT * FROM Prodazhi";

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
                string Num = Edit1.Text;
                string SaleDat = Edit2.Text;
                string NomAvtobus = Edit3.Text;
                string Punkt = Edit4.Text;
                string Stoimost = Edit5.Text;
                string query = "INSERT INTO Prodazhi(Num, Sale_Date, Nomer_Avtobusa, Punkt_Posadki,Stoimost) " +
                   "Values('" + Num + "', '" + SaleDat + "', '" + NomAvtobus + "', '" + Punkt + "','" + Stoimost + "')";
                SqlConnection cnn;
                string conStr = ConnectionString.Constring;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                SqlCommand command = new SqlCommand(query, cnn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted!\n Closing connection ");
                var select = "SELECT * FROM Prodazhi";

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
                var querier = "UPDATE Prodazhi SET Sale_Date=@a1,Nomer_Avtobusa=@a2,Punkt_Posadki=@a3,Stoimost=@a4 WHERE Num=@a5";
                var commandBuilder = new SqlCommand(querier, cnn);
                commandBuilder.Parameters.AddWithValue("a1", Edit2.Text);
                commandBuilder.Parameters.AddWithValue("a2", int.Parse(Edit3.Text));
                commandBuilder.Parameters.AddWithValue("a3", Edit4.Text);
                commandBuilder.Parameters.AddWithValue("a4", Edit5.Text);
                commandBuilder.Parameters.AddWithValue("a5", int.Parse(Edit1.Text));
                commandBuilder.ExecuteNonQuery();
                Console.WriteLine("Connection established and the table updated!");
                var select = "SELECT * FROM Prodazhi";

                var commandBuilders = new SqlCommand(select, cnn);
                commandBuilders.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandBuilders);
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
    }
}
