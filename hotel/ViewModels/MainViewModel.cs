using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Models;
using hotel.Services;
using hotel.Views.Admin;
using hotel.Views.Guests;
using hotel.Views.Staff;
using System.Data;
using System.Windows;

namespace hotel.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public event EventHandler? CloseWindowRequested;

        [ObservableProperty]
        private string _login = "";

        [ObservableProperty]
        private string _password = "";

        [ObservableProperty]
        private DataTable _dataTable;

        public MainViewModel() { }

        [RelayCommand]
        public void LoginT()
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Введите данные");
                return;
            }

            try
            {
                bool suc = DataBaseService.Instance.Login(Login, Password);
                string role = null;
                if (suc)
                {
                    role = DataBaseService.Instance.Currentuser.Role.Role;
                    if (role != null)
                    {
                        NextPage(role);
                    }
                }
                else
                {
                    MessageBox.Show("Вас нет в системе.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [RelayCommand]
        public void Registr()
        {
            Regist regist = new Regist();
            regist.Show();
        }

        private void NextPage(string role)
        {
           

            if (role == "admin")
            {
                AdminBoard adminBoard = new AdminBoard();
                adminBoard.Show();
            }
            else if (role == "staff")
            {
               StaffBoard a= new StaffBoard();
                a.Show();
            }
            else if (role == "guest")
            {
                usersModel usersModel = new usersModel();
               
                GuestDash guestsBoard = new GuestDash();
                guestsBoard.Show();
            }
            else
            {
                MessageBox.Show("Кажется вас нет в базе!");
            }
            CloseWindowRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}