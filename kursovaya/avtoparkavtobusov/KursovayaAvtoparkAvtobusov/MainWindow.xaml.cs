using ModernWpf;
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
            try {
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
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured! Traceback: {0} ", ex.Message);
            }


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

        private void ObslugAvtobusov_Click(object sender, RoutedEventArgs e)
        {
            TexObslugWindow wndxXxx = new TexObslugWindow();
            wndxXxx.Show();
        }

        private void EmpMenu_Click(object sender, RoutedEventArgs e)
        {
            EmpRecord wndxXxxx = new EmpRecord();
            wndxXxxx.Show();
        }

        private void Ribbon_Loaded(object sender, RoutedEventArgs e)
        {
            if (ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Dark)
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
                ControlzEx.Theming.ThemeManager.Current.ChangeThemeBaseColor(Application.Current, "Dark");
            }
            else
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                ControlzEx.Theming.ThemeManager.Current.ChangeThemeBaseColor(Application.Current, "Light");
            }
        }

        private void exiter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UpdateTransportTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

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
                Console.WriteLine("Connection established and the table updated!");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured! Traceback: {0} ", ex.Message);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                string conStr = ConfigurationManager.ConnectionStrings["KursovayaAvtoparkAvtobusov"].ToString();

                cnn = new SqlConnection(conStr);
                cnn.Open();
                SqlCommand command = new SqlCommand(query, cnn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted!\n Closing connection ");
                cnn.Close();
                Console.WriteLine("Connection has been closed , database ready for next operation!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured! Traceback: {0} ", ex.Message);
            }
        }
    }
}
