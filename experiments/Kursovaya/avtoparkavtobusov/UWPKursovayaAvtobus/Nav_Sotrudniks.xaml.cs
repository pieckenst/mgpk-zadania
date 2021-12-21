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
    public sealed partial class Nav_Sotrudniks : Page
    {
        public Nav_Sotrudniks()
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
                var select = "SELECT * FROM Employees";

                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandBuilder);
                DataTable ds = new DataTable("Avtobusx");
                dataAdapter.Fill(ds);
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

        private async  void Button_Click(object sender, RoutedEventArgs e)
        {
            try {
                string Num = Exed1.Text;
                string EmpName = Exed2.Text;
                string EmpsName = Exed3.Text;
                string Emppat = Exed4.Text;
                string EmpES = Exed5.Text;
                string Emptitle = Exed6.Text;
                string Empint = Exed7.Text;
                string query = "INSERT INTO Employees(Num, Surname, Name, Patronym,Employed_Since,Job,Internship) " +
                   "Values('" + Num + "', '" + EmpName + "', '" + EmpsName + "', '" + Emppat + "','" + EmpES + "','" + Emptitle + "','" + Empint + "')";
                SqlConnection cnn;
                string conStr = ConnectionString.Constring;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                SqlCommand command = new SqlCommand(query, cnn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted!\n Updating grid ");
                var select = "SELECT * FROM Employees";

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

        private async void XdbUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                string conStr = ConnectionString.Constring;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var select = "UPDATE Employees SET Surname=@a1,Name=@a2,Patronym=@a3,Employed_Since=@a4,Job=@a5,Internship=@a6 WHERE Num=@a7";
                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.Parameters.AddWithValue("a1", Exed2.Text);
                commandBuilder.Parameters.AddWithValue("a2", Exed3.Text);
                commandBuilder.Parameters.AddWithValue("a3", Exed4.Text);
                commandBuilder.Parameters.AddWithValue("a4", Exed5.Text);
                commandBuilder.Parameters.AddWithValue("a5", Exed6.Text);
                commandBuilder.Parameters.AddWithValue("a6", Exed7.Text);
                commandBuilder.Parameters.AddWithValue("a7", int.Parse(Exed1.Text));
                commandBuilder.ExecuteNonQuery();
                Console.WriteLine("Connection established and the table updated!");
                var selector = "SELECT * FROM Employees";

                var commandBuildersd = new SqlCommand(selector, cnn);
                commandBuilder.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandBuildersd);
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
