
using hotel.Views.Admin;
using System.Windows;


namespace hotel
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminBoard board = new AdminBoard();
            board.Show();
            this.Close();
        }
    }
}