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
    /// Логика взаимодействия для Btn.xaml
    /// </summary>
    public partial class Btn : UserControl
    {
        private string placeholder;
        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                Myb.Content = placeholder;
            }
        }
        private string wigth;
        public string Wigth
        {
            get { return wigth; }
            set
            {
                wigth = value;
                Myb.Width = double.Parse(wigth);
            }
        }

        

        public Btn()
        {
            InitializeComponent();
        }
        
    }
}
