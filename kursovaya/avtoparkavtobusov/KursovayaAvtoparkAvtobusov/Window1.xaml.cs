using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string NomeMarshuta = Edit1.Text;
                string NachalnPunkt = Edit2.Text;
                string KonechnPunkt = Edit3.Text;
                string Vodit = Edit4.Text;
                string Modelvtobusa = Edit5.Text;
                string VremProezda = Edit6.Text;
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
