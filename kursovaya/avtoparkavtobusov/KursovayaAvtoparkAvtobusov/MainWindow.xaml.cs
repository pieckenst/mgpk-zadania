using ModernWpf;

using MsgBoxEx;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using SQLServerLoginTemplate;
using Application = System.Windows.Application;

namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string a;
        public static string formations;
        public MainWindow()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            InitializeComponent();
            var form1 = new FormConnectToSQLServer();
            form1.ShowDialog();
            a = form1.ConnectionString;
            formations = a + ";Initial Catalog=KursovayaAvtoparkAvtobusov";
#if DEBUG
            Console.WriteLine(a);
            Console.WriteLine(formations);
#endif

        }

        private void ConnectDb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStr = MainWindow.formations;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                Console.Write("[MENU] Connect db clicked - test \n");
                var select = "SELECT * FROM Marshuti";

                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.ExecuteNonQuery();

                var dataAdapter = new SqlDataAdapter(commandBuilder);
                var ds = new DataTable("Avtobusx");
                dataAdapter.Fill(ds);
                dataGrid1.ItemsSource = ds.DefaultView;
                Console.WriteLine("Connection established and the datagrid filled!");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MsgBoxExtendedFunctionality ext = new MsgBoxExtendedFunctionality()
                {
                    DetailsText = ex.StackTrace
                };
                MessageBoxEx.ShowEx("An error has occured! Traceback: " + ex.Message, "Unexpected situation handling", MessageBoxButtonEx.OK, MessageBoxImage.Error, ext);
            }
        }

        private void AboutAutobus_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("[Menu] Opening about window!");
            var wnxd = new Window2();
            wnxd.Show();
        }

        private void ProdBiletovMenu_Click(object sender, RoutedEventArgs e)
        {
            var wndx = new Window3();
            wndx.Show();
        }

        private void DeleteMenu_Click(object sender, RoutedEventArgs e)
        {
            var wndxXx = new Window4();
            wndxXx.Show();
        }

        private void ObslugAvtobusov_Click(object sender, RoutedEventArgs e)
        {
            var wndxXxx = new TexObslugWindow();
            wndxXxx.Show();
        }

        private void EmpMenu_Click(object sender, RoutedEventArgs e)
        {
            var wndxXxxx = new EmpRecord();
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
                var conStr = MainWindow.formations;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var select =
                    "UPDATE Marshuti SET Nachalni_Punkt=@a1,Konechni_Punkt=@a2,Voditel=@a3,Model_Avtobusa=@a4,Vremya_Proezda=@a5 WHERE Nomer_Marshuta=@a6";
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
                ConnectDb_Click(sender, e);
            }
            catch (Exception ex)
            {
                MsgBoxExtendedFunctionality ext = new MsgBoxExtendedFunctionality()
                {
                    DetailsText = ex.StackTrace
                };
                MessageBoxEx.ShowEx("An error has occured! Traceback: " + ex.Message, "Unexpected situation handling", MessageBoxButtonEx.OK, MessageBoxImage.Error, ext);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var NomeMarshuta = Editor1.Text;
                var NachalnPunkt = Editor2.Text;
                var KonechnPunkt = Editor3.Text;
                var Vodit = Editor4.Text;
                var Modelvtobusa = Editor5.Text;
                var VremProezda = Editor6.Text;
                var query =
                    "INSERT INTO Marshuti(Nomer_Marshuta, Nachalni_Punkt, Konechni_Punkt, Voditel,Model_Avtobusa,Vremya_Proezda) " +
                    "Values('" + NomeMarshuta + "', '" + NachalnPunkt + "', '" + KonechnPunkt + "', '" + Vodit + "','" +
                    Modelvtobusa + "', '" + VremProezda + "')";
                SqlConnection cnn;
                var conStr = MainWindow.formations;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                var command = new SqlCommand(query, cnn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted!\n Closing connection ");
                cnn.Close();
                Console.WriteLine("Connection has been closed , database ready for next operation!");
                ConnectDb_Click(sender,e);
            }
            catch (Exception ex)
            {
                MsgBoxExtendedFunctionality ext = new MsgBoxExtendedFunctionality()
                {
                    DetailsText = ex.StackTrace
                };
                MessageBoxEx.ShowEx("An error has occured! Traceback: " + ex.Message, "Unexpected situation handling", MessageBoxButtonEx.OK, MessageBoxImage.Error, ext);
            }
        }

        private void RepView_Click(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            string sSelectedPath = null;
            fbd.Description = "Please locate your report viewer path";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sSelectedPath = fbd.SelectedPath;
            }
            else
            {
                return;
            }
            Process avReportLaunchProcess = new Process();
            avReportLaunchProcess.StartInfo.FileName = Path.Combine(sSelectedPath, "WpfReporter.exe");
            avReportLaunchProcess.Start();

        }

        private void Repexp_Click(object sender, RoutedEventArgs e)
        {
            var wndxXxxxX = new ReportExport();
            wndxXxxxX.Show();
        }

        private void Editor1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Editor1.Clear();
        }

        private void Editor3_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Editor3.Clear();
        }

        private void Editor5_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Editor5.Clear();
        }

        private void Editor2_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Editor2.Clear();
        }

        private void Editor4_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Editor4.Clear();
        }

        private void Editor6_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Editor6.Clear();
        }
    }
}