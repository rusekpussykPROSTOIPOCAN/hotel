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

        [ObservableProperty]
        private string _isVis = "Visibly";
        [ObservableProperty]
        private string _isVischeckin = "Visibly";
        [ObservableProperty]
        private string _isVischeckout = "Visibly";
        [ObservableProperty]
        private string _isVisEdit = "Visibly";

        public string Togle(  string  a )
        {
            a = a == "Visibly" ? "Hidden" : "Visibly";
            return a;
        }
        public NumsViewModel()
        {
            Currentpage = null;
        }

        [RelayCommand]
        public void checkin()
        {
            Currentpage = new CheckIn();
            IsVis = Togle(IsVis);
            IsVischeckout = Togle(IsVischeckout);
            IsVisEdit = Togle(IsVisEdit);
            
        }
        [RelayCommand]
        public void checkout()
        {
            Currentpage = new CheckOut();
            IsVis = Togle(IsVis);
            IsVischeckin = Togle(IsVischeckin);
            IsVisEdit = Togle(IsVisEdit);
        }
        [RelayCommand]
        public void edit()
        {
            IsReadOnly = !IsReadOnly;
            IsVis = "Visibly";
            IsVischeckin = Togle(IsVischeckin);
            IsVischeckout = Togle(IsVischeckout);
        }
    }
}
