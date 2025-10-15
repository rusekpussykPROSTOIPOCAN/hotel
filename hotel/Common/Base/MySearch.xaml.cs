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
    /// Логика взаимодействия для MySearch.xaml
    /// </summary>
    public partial class MySearch : UserControl
    {
        public static readonly DependencyProperty visib = DependencyProperty.Register("Visib", typeof(string), typeof(MySearch), new PropertyMetadata(null));
        public string Visib
        {
            get => (string)GetValue(visib);
            set => SetValue(visib, value);
        }
       
        public static readonly DependencyProperty wight = DependencyProperty.
            Register("Wigth", typeof(double), typeof(MySearch),
            new PropertyMetadata(100.0));
        public double Wigth
        {
            get => (double)GetValue(wight);
            set => SetValue(wight, value);
        }
        public MySearch()
        {
            InitializeComponent();
        }
    }
}
