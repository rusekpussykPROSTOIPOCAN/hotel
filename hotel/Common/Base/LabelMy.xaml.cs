using System.Windows;
using System.Windows.Controls;

namespace hotel.Common.Base
{
    public partial class LabelMy : UserControl
    {
        public LabelMy()
        {
            InitializeComponent();
        }

        // DependencyProperty для Text
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(LabelMy),
                new PropertyMetadata(string.Empty, OnTextPropertyChanged));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (LabelMy)d;
            control.UpdateTextBox();
        }

        private void UpdateTextBox()
        {
            if (txtMy.Text != Text)
            {
                txtMy.Text = Text;
            }
            UpdatePlaceholderVisibility();
        }

        // DependencyProperty для Placeholder
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(LabelMy),
                new PropertyMetadata(string.Empty, OnPlaceholderPropertyChanged));

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        private static void OnPlaceholderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (LabelMy)d;
            control.transtext.Text = e.NewValue?.ToString() ?? string.Empty;
            control.UpdatePlaceholderVisibility();
        }

        private void clearb_Click(object sender, RoutedEventArgs e)
        {
            Text = string.Empty;
            txtMy.Focus();
        }

        private void txtMy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtMy.Text != Text)
            {
                Text = txtMy.Text;
            }
            UpdatePlaceholderVisibility();
        }

        private void UpdatePlaceholderVisibility()
        {
            transtext.Visibility = string.IsNullOrEmpty(txtMy.Text) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}