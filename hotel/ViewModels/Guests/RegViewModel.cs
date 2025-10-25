using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.ViewModels.Admin.GuestActViewModel;
using hotel.Views;
using hotel.Views.Admin.GuestAct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hotel.ViewModels.Guests
{
    public partial class RegViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _currentPage;

        private AddGuestViewModel _addGuestViewModel;

        public RegViewModel()
        {
            CurrentPage = new AddGuestPage();
            _addGuestViewModel = (CurrentPage as AddGuestPage)?.DataContext as AddGuestViewModel;
        }

        [RelayCommand]
        public void AddGuest()
        {
            
            if (_addGuestViewModel == null)
            {
                MessageBox.Show("Ошибка инициализации");
                return;
            }

          
            if (_addGuestViewModel.Isnull())
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

        
            _addGuestViewModel.AddUser();

            MessageBox.Show("Гость успешно добавлен");
        }
    }
    }

