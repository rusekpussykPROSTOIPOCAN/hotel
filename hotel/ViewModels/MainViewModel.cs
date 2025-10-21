using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Models;
using hotel.Services;
using hotel.Views.Admin;
using hotel.Views.Staff;
using hotel.Views.Guests;

using System.Data;

using System.Windows;

namespace hotel.ViewModels
{
    public partial class MainViewModel:ObservableObject
    {
        private readonly DataBaseService _dataBaseService;
       
        [ObservableProperty]
        private string _login="";
        [ObservableProperty]
        private string _password="";
        [ObservableProperty]
        private DataTable _dataTable;
        public MainViewModel()
        {
            _dataBaseService = new DataBaseService();
           
        }
        [RelayCommand]
        public void LoginT()
        {
           

            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password)) {
                MessageBox.Show("Введите данные");
                return;
            }
            bool suc = _dataBaseService.Login(Login,Password);
            string role = _dataBaseService.Currentuser.Role?.Role ?? "хз";
            NextPage(role);
           
        }
        private void NextPage(string role)
        {
            MainWindow main = new MainWindow();
            if (role == "admin")
            {
                AdminBoard adminBoard = new AdminBoard();
                adminBoard.Show();
                main.Close();
            }
            else if (role == "staff")
            {
               
                
            }
            else {
                MessageBox.Show("Кажется вас нет в базе!");
            }
        }
        
    }
}
