using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
       

        private void ConnectDb_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnn;
            string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

            cnn = new SqlConnection(conStr);
            cnn.Open();
            Console.Write("OPENING DB CONNECTION!!! \n");
            Console.Write("[MENU] Connect db clicked - test \n");
            var select = "SELECT * FROM Marshuti";
            
            var commandBuilder = new SqlCommand(select, cnn);
            commandBuilder.ExecuteNonQuery();
            
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandBuilder);
            DataTable ds = new DataTable("Avtobusx");
            dataAdapter.Fill(ds);
            dataGrid1.ItemsSource = ds.DefaultView;
            Console.WriteLine("Connection established and the datagrid filled!");
            cnn.Close();


        }

        private void AboutAutobus_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("[Menu] Opening about window!");
            Window2 wnxd = new Window2();
            wnxd.Show();
        }

        private void OpenEditor_Click(object sender, RoutedEventArgs e)
        {
            Window1 wnd = new Window1();
            wnd.Show();
        }

        private void ProdBiletovMenu_Click(object sender, RoutedEventArgs e)
        {
            Window3 wndx = new Window3();
            wndx.Show();
        }

        private void UpdateDataInfo_Click(object sender, RoutedEventArgs e)
        {
            UpdateR wndxX = new UpdateR();
            wndxX.Show();
        }

        private void DeleteMenu_Click(object sender, RoutedEventArgs e)
        {
            Window4 wndxXx = new Window4();
            wndxXx.Show();
        }
    }
}
