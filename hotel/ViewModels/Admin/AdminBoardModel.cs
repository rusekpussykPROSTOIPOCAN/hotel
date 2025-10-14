using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Views;
using hotel.Views.Admin;


namespace hotel.ViewModels.Admin
{
    public partial class AdminBoardModel:ObservableObject
    {
        [ObservableProperty]
        private object _currentPage;
        public AdminBoardModel()
        {
            ShowFirst();
        }
        [RelayCommand]
        private void ShowFirst()
        {
            CurrentPage = new Booking();
        }
        [RelayCommand]
        private void ShowSecond() {

            CurrentPage = new GuestsBoard();
        }

    }
}
