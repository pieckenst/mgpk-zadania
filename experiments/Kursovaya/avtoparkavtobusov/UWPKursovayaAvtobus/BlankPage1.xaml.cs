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
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
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
            try {
                var select = "SELECT * FROM Marshuti";

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
            catch(Exception ex)
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

        private async void UpdateTransportTable_Click(object sender, RoutedEventArgs e)
        {
            try {
                SqlConnection cnn;
                string conStr = ConnectionString.Constring;

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
                var selector = "SELECT * FROM Marshuti";

                var commandBuilders = new SqlCommand(selector, cnn);
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
                Console.WriteLine("Connection established and the table updated!");
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
            try
            {
                string NomeMarshuta = Editor1.Text;
                string NachalnPunkt = Editor2.Text;
                string KonechnPunkt = Editor3.Text;
                string Vodit = Editor4.Text;
                string Modelvtobusa = Editor5.Text;
                string VremProezda = Editor6.Text;
                string query = "INSERT INTO Marshuti(Nomer_Marshuta, Nachalni_Punkt, Konechni_Punkt, Voditel,Model_Avtobusa,Vremya_Proezda) " +
                   "Values('" + NomeMarshuta + "', '" + NachalnPunkt + "', '" + KonechnPunkt + "', '" + Vodit + "','" + Modelvtobusa + "', '" + VremProezda + "')";
                SqlConnection cnn;
                string conStr = ConnectionString.Constring;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                SqlCommand command = new SqlCommand(query, cnn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted!\n Closing connection ");
                var selector = "SELECT * FROM Marshuti";

                var commandBuilders = new SqlCommand(selector, cnn);
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
