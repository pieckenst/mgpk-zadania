using System.Windows;

namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    ///     Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Agreed_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}