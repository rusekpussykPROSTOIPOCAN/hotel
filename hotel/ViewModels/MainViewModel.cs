using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using hotel.Services;
using hotel.Views.Admin;


using System.Data;

using System.Windows;

namespace hotel.ViewModels
{
    public partial class MainViewModel:ObservableObject
    {
      
       
        [ObservableProperty]
        private string _login="";
        [ObservableProperty]
        private string _password="";
        [ObservableProperty]
        private DataTable _dataTable;

        public event Action? CloseAction;
        public MainViewModel()
        {


        }
        [RelayCommand]
        public void LoginT()
        {
           

            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password)) {
                MessageBox.Show("Введите данные");
                return;
            }
            bool suc = DataBaseService.Instance.Login(Login,Password);
            string role = DataBaseService.Instance.Currentuser.Role?.Role ?? "хз";
            if (suc) { 
            
            NextPage(role);
            }
            else
            {
                MessageBox.Show($"{role}");
            }
           
        }
        private void NextPage(string role)
        {
          
                CloseAction?.Invoke();
            if (role == "admin")
            {
                AdminBoard adminBoard = new AdminBoard();
               
                adminBoard.Show();
                
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
