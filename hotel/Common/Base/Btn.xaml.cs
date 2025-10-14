using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace hotel.Common.Base
{
    public partial class Btn : UserControl
    {
        public Btn()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CommandProperty =
         DependencyProperty.Register("Command", typeof(ICommand),
         typeof(Btn), new PropertyMetadata(null));

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(object), typeof(Btn), 
                new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        

        public object Placeholder
        {
            get { return GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
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

       
    }
}