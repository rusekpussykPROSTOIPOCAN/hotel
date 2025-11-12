using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Models;
using hotel.Services;
using hotel.ViewModels.Admin.NumsActViewModel;
using hotel.Views;
using hotel.Views.Admin.NumsAct;
using hotel.Views.Guests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hotel.ViewModels.Guests
{
    public partial class GuestBoarsViewModel:ObservableObject
    {
        [ObservableProperty]
        private object _currentPage;
        [ObservableProperty]
        private string _visB = "Hidden";
        public GuestBoarsViewModel() {
            MessageBox.Show($"Привет, {DataBaseService.Instance.Currentuser.Name}");
            GoToPageProfil();
        }
        private ProfilViewModel vm;
        [RelayCommand]
        public void GoToPageProfil()
        {
            VisB = "Hidden";
            vm = new ProfilViewModel { 
                Name = DataBaseService.Instance.Currentuser.Name,
                Lname = DataBaseService.Instance.Currentuser.Lname,
                Mname = DataBaseService.Instance.Currentuser.Mname,
                Log= DataBaseService.Instance.Currentuser.log
                

            };
            var a = new ProfilPage();
            a.DataContext = vm;
            CurrentPage = a;

        }
        private NumsEditViewModel nums = new();
        private ObservableCollection<usersModel> guest = new();
        private EditNums a = new EditNums();
        [RelayCommand]
        public void GoToPageBooking()
        {
          
            guest.Add( new usersModel
            {
                Id = DataBaseService.Instance.Currentuser.Id,
                Name = DataBaseService.Instance.Currentuser.Name,
                Lname = DataBaseService.Instance.Currentuser.Lname,
                Mname = DataBaseService.Instance.Currentuser.Mname,
            });
           

            nums = new NumsEditViewModel { 
                Users = guest
                

            };
           
            a.DataContext = nums;
            CurrentPage = a;
            VisB = "Visibly";
        }
        [RelayCommand]
        public void Booking()
        {
            nums.Booking();
            VisB = "Hidden";
            GoToPageProfil();
        }
        [RelayCommand]
        public void MyNum()
        {
            VisB = "Hidden";
            CurrentPage = new History();
        }
    }
}
