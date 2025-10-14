using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Views.Admin.NumsAct;
using hotel.Views.Admin;
using System.Windows.Controls;

namespace hotel.ViewModels.Admin
{
  
    public partial class NumsViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _currentpage;

        [ObservableProperty]
        private bool _isReadOnly = true;

        


        [RelayCommand]
        public void checkin()
        {
            Currentpage = new CheckIn();
            
        }
        [RelayCommand]
        public void checkout()
        {
            Currentpage = new CheckOut();
        }
        [RelayCommand]
        public void edit()
        {
            IsReadOnly = !IsReadOnly;
        }
    }
}
