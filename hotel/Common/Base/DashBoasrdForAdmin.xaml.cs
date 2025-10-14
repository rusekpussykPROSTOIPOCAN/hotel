using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace hotel.Common.Base
{
    /// <summary>
    /// Логика взаимодействия для DashBoasrdForAdmin.xaml
    /// </summary>
    public partial class DashBoasrdForAdmin : UserControl
    {
        public DashBoasrdForAdmin()
        {
            InitializeComponent();
        }
        public void ShowContent(object conn)
        {
            userControl = conn;
        } 
        public static readonly DependencyProperty dependency = DependencyProperty.Register("userControl", typeof(object), typeof(DashBoasrdForAdmin), new PropertyMetadata(null));
        public object userControl
        {
            get => GetValue(dependency);
            set => SetValue(dependency, value);
        }
       
    }
}
