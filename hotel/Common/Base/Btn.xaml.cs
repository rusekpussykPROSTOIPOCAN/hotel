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


        public static readonly DependencyProperty wight = DependencyProperty.
            Register("Wigth", typeof(double), typeof(Btn), 
            new PropertyMetadata(100.0));
        public double Wigth
        {
            get => (double)GetValue(wight);
            set => SetValue(wight, value);
        }
        public static readonly DependencyProperty param = DependencyProperty.
            Register("Params", typeof(object), typeof(Btn),
            new PropertyMetadata(null));
        public object Params
        {
            get => GetValue(param);
            set => SetValue(param, value);
        }


    }
}