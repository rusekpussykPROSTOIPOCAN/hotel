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
        [ObservableProperty]
        private string _isVisGuestEdit = "Visibly";
        [ObservableProperty]
        private string _isVisGuestDelete= "Visibly";

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
            IsVisGuestDelete = Togle(IsVisGuestDelete);
            IsVisGuestEdit = Togle(IsVisGuestEdit);

        }
        [RelayCommand]
        public void DeleteGuest()
        {
            IsReadOnly = !IsReadOnly;
            IsVis = "Visibly";
            IsVisGuestAdd = Togle(IsVisGuestAdd);
          IsVisGuestEdit= Togle(IsVisGuestEdit);
        }
        [RelayCommand]
        public void EditGuest()
        {
            Currentpage = new EditGuest();
            IsVis = Togle(IsVis);
            IsVisGuestAdd = Togle(IsVisGuestAdd);
            IsVisGuestDelete = Togle(IsVisGuestDelete);

        }
    }
}
