using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hotel.Common.Base
{
    /// <summary>
    /// Логика взаимодействия для LabelMy.xaml
    /// </summary>
    public partial class LabelMy : UserControl
    {
        public LabelMy()
        {
            InitializeComponent();
        }
        private string placeholder;
        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                transtext.Text = placeholder;
            }
        }
        private void clearb_Click(object sender, RoutedEventArgs e)
        {
            txtMy.Clear();
            txtMy.Focus();
        }

        private void txtMy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMy.Text)) transtext.Visibility = Visibility.Visible;
            else transtext.Visibility = Visibility.Hidden;
        }
    }
}
