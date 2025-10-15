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
           
           
            
        }
        [RelayCommand]
        public void checkout(object param)
        {
           
        }
        [RelayCommand]
        public void edit(object param)
        {
            Currentpage = new EditNums();
            IsVis = Togle(IsVis);
            IsVischeckin = Togle(IsVischeckin);
           
            
        }
    }
}
