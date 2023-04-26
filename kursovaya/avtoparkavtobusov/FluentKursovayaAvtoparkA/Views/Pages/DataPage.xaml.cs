using FluentKursovayaAvtoparkA.Views.Windows;
using MsgBoxEx;
using System.Data.SqlClient;
using System.Windows;
using System;
using Wpf.Ui.Common.Interfaces;
using System.Data;
using Wpf.Ui.Controls;
using MessageBox = Wpf.Ui.Controls.MessageBox;
using System.Windows.Controls;
using System.Windows.Forms;

namespace FluentKursovayaAvtoparkA.Views.Pages
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataPage : INavigableView<ViewModels.DataViewModel>
    {
        public ViewModels.DataViewModel ViewModel
        {
            get;
        }

        public DataPage(ViewModels.DataViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
        private void UpdateTransportTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cnn;
                var conStr = SettingsPage.formations;

                cnn = new SqlConnection(conStr);
                cnn.Open();
                Console.Write("OPENING DB CONNECTION!!! \n");
                var select =
                    "UPDATE Marshuti SET Nachalni_Punkt=@a1,Konechni_Punkt=@a2,Voditel=@a3,Model_Avtobusa=@a4,Vremya_Proezda=@a5 WHERE Nomer_Marshuta=@a6";
                var commandBuilder = new SqlCommand(select, cnn);
                commandBuilder.Parameters.AddWithValue("a1", Edit2.Text);
                commandBuilder.Parameters.AddWithValue("a2", Edit3.Text);
                commandBuilder.Parameters.AddWithValue("a3", Edit4.Text);
                commandBuilder.Parameters.AddWithValue("a4", Edit5.Text);
                commandBuilder.Parameters.AddWithValue("a5", Edit6.Text);
                commandBuilder.Parameters.AddWithValue("a6", int.Parse(Edit1.Text));
                commandBuilder.ExecuteNonQuery();
                Console.WriteLine("Connection established and the table updated!");
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
                var conStr = SettingsPage.formations;

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
        private void MessageBox_LeftButtonClick() { 
        
        }
        private void UpdateGrid_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                SqlConnection cnn;
                var conStr = SettingsPage.formations;

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
                var uiMessageBox = new MessageBox
                {
                    Title = "Обработка ошибок",
                    Content = new TextBlock
                    {
                        Text = ex.Message,
                        TextWrapping = TextWrapping.Wrap,
                    },
                    ButtonLeftName = "OK",
                    ButtonRightName = "Отмена",
                    Width = 800,
                    Height= 500,
                    
                };
                uiMessageBox.ButtonLeftClick += (s, e) =>
                {
                   
                    uiMessageBox.Close();
                };
                uiMessageBox.ButtonRightClick += (s, e) =>
                {
                    
                    uiMessageBox.Close();
                };
                

                uiMessageBox.ShowDialog();
            }
        }
    }
}
