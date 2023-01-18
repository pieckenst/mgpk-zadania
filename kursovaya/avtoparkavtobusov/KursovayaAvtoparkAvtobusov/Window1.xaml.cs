using MsgBoxEx;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    ///     Interaction logic for Window1.xaml
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
                var NomeMarshuta = Edit1.Text;
                var NachalnPunkt = Edit2.Text;
                var KonechnPunkt = Edit3.Text;
                var Vodit = Edit4.Text;
                var Modelvtobusa = Edit5.Text;
                var VremProezda = Edit6.Text;
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
    }
}