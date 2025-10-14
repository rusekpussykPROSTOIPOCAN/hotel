using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Views.Admin;


namespace hotel.ViewModels.Admin
{
    public partial class AdminBoardModel:ObservableObject
    {
        [ObservableProperty]
        private object _currentPage;
        [RelayCommand]
        private void ShowFirst()
        {
            CurrentPage = new AdminBoard();
        }
    }
}
