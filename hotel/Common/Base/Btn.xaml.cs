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
        public static readonly RoutedEvent ClickEvent =
       EventManager.RegisterRoutedEvent(
           "Click",
           RoutingStrategy.Bubble,
           typeof(RoutedEventHandler),
           typeof(LabelMy));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ClickEvent));
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
        public static readonly DependencyProperty heig = DependencyProperty.
           Register("Heig", typeof(double), typeof(Btn),
           new PropertyMetadata(30.0));
        public double Heig
        {
            get => (double)GetValue(heig);
            set => SetValue(heig, value);
        }

        public static readonly DependencyProperty marginSet = DependencyProperty.Register("MarginSet", typeof(Thickness), typeof(Btn), new PropertyMetadata(new Thickness(5)));
        public Thickness MarginSet
        {
            get => (Thickness)GetValue(marginSet);
            set => SetValue(marginSet, value);
        }

        public static readonly DependencyProperty param = DependencyProperty.
            Register("Params", typeof(object), typeof(Btn),
            new PropertyMetadata(null));
        public object Params
        {
            get => GetValue(param);
            set => SetValue(param, value);
        }
        public static readonly DependencyProperty visib = DependencyProperty.Register("Visib", typeof(string), typeof(Btn), new PropertyMetadata(null));
        public string Visib
        {
            get => (string)GetValue(visib);
            set => SetValue(visib, value);
        }


    }
}