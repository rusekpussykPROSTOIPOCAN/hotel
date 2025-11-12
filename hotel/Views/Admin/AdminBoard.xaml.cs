
using System.Windows;


namespace hotel.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminBoard.xaml
    /// </summary>
    public partial class AdminBoard : Window
    {
        public AdminBoard()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
