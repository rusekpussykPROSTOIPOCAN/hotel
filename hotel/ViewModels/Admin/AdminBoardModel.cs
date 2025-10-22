using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Services;
using hotel.Views;
using hotel.Views.Admin;
using hotel.Views.Staff;
using System.Data;
using System.Windows;


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
            GuestsViewModel viewModel = new GuestsViewModel();
            viewModel.LoadGuest();
        }
        [RelayCommand]
        private void ShowThird() {
            CurrentPage = new Nums();
        }
        [RelayCommand]
        private void ShowFourth() { 
            CurrentPage = new Sells();
        }
        [RelayCommand]
        private void ShowFiveth() {
            CurrentPage = new Schedule();
        }
        [RelayCommand]
        private void ShowSixth() {
            CurrentPage = new Tasks();
        }

    }
}
