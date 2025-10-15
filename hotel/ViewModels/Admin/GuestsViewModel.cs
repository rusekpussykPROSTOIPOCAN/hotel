using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Views.Admin.GuestAct;


namespace hotel.ViewModels.Admin
{
    public partial class GuestsViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _currentpage;

        [ObservableProperty]
        private bool _isReadOnly = true;

        [ObservableProperty]
        private string _isVis = "Visibly";
        [ObservableProperty]
        private string _isVisGuestAdd = "Visibly";
        

        public string Togle(string a)
        {
            a = a == "Visibly" ? "Hidden" : "Visibly";
            return a;
        }
        public GuestsViewModel()
        {
            Currentpage = null;
        }

        [RelayCommand]
        public void AddGuest()
        {
            Currentpage = new AddGuestPage();
            IsVis = Togle(IsVis);
           

        }
        [RelayCommand]
        public void DeleteGuest(object param)
        {
            //Удаление
           
        }
        [RelayCommand]
        public void EditGuest(object param)
        {
            
            Currentpage = new EditGuest();
            IsVis = Togle(IsVis);
            IsVisGuestAdd = Togle(IsVisGuestAdd);
            

        }
    }
}
