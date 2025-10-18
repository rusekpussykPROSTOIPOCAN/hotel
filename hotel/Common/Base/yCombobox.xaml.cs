using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections;
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
    /// Логика взаимодействия для yCombobox.xaml
    /// </summary>
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
       DependencyProperty.Register("SelectedItem", typeof(object), typeof(yCombobox), new PropertyMetadata(null));
        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);

            set => SetValue(SelectedItemProperty, value);
        }
        public static readonly DependencyProperty ItemSoursePr =
      DependencyProperty.Register("ItemSourse", typeof(IEnumerable), typeof(yCombobox),new PropertyMetadata(null));
        public IEnumerable ItemSourse
        {
            get => (IEnumerable)GetValue(ItemSoursePr);

            set => SetValue(ItemSoursePr, value);
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

        private void MyBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            OnPreviewTextInput(e);
            MyBox.IsDropDownOpen = true;
        }
    }
}
