
using System.Collections;

using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;


namespace hotel.Common.Base
{

    public partial class yCombobox : UserControl
    {
        public static readonly DependencyProperty wight = DependencyProperty.
           Register("Wigth", typeof(double), typeof(yCombobox),
           new PropertyMetadata(100.0));
        public double Wigth
        {
            get => (double)GetValue(wight);
            set => SetValue(wight, value);
        }
        public static readonly DependencyProperty heig = DependencyProperty.
           Register("Heig", typeof(double), typeof(yCombobox),
           new PropertyMetadata(30.0));
        public double Heig
        {
            get => (double)GetValue(heig);
            set => SetValue(heig, value);
        }
        public yCombobox()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty SelectedItemProperty =
         DependencyProperty.Register("SelectedItem", typeof(object), typeof(yCombobox),
             new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)); // ВАЖНО

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(yCombobox),
                new PropertyMetadata(null));

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
        public static readonly DependencyProperty DisplayMemberPathProperty =
        DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(yCombobox), new PropertyMetadata(null));
        public static readonly DependencyProperty marginSet = DependencyProperty.Register("MarginSet", typeof(Thickness), typeof(yCombobox), new PropertyMetadata(new Thickness(5)));
        public Thickness MarginSet
        {
            get => (Thickness)GetValue(marginSet);
            set => SetValue(marginSet, value);
        }
        public string DisplayMemberPath
        {
            get => (string)GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(yCombobox), new PropertyMetadata(null));
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private void MyBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            MyBox.IsDropDownOpen = true;
        }

        private void MyBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            Text = MyBox.Text;
            if (!string.IsNullOrEmpty(Text)) { MyBox.IsDropDownOpen = true; }
        }
        
    }
}
