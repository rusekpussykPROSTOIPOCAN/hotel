
using hotel.ViewModels;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.CloseWindowRequested += (s, args) => this.Close();
            }
        }


    }
}