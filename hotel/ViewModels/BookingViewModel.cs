using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Services;
using hotel.Views.Admin.NumsAct;

namespace hotel.ViewModels
{
    public partial class BookingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _vis1;

        [ObservableProperty]
        private string _vis2;

        public BookingViewModel()
        {
            if (DataBaseService.Instance.Currentuser.Role.Role=="admin")
            {
                _vis2 = "Visibly";
                _vis1 = "Hidden";
            }
            else
            {
                _vis1 = "Visibly";
                _vis2 = "Hidden";

            }
        }

        [RelayCommand]
        public void checkin()
        {

        }
        [RelayCommand]
        public void delete(object param)
        {

        }
    }
}
