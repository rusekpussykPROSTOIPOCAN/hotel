using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Models;
using hotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hotel.ViewModels.Guests
{
    public partial class ProfilViewModel: ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _lname;

        [ObservableProperty]
        private string _mname;

        [ObservableProperty]
        private string _log;

        [ObservableProperty]
        private string _pass;
        [ObservableProperty]
        private string _oldpass;

        
        public  ProfilViewModel()
        {

        }
        [RelayCommand]
        public void SavePass()
        {
            if (Pass != null && Oldpass != null && Name != null && Lname != null && Mname != null)
            {

            if ( HashPassword(Oldpass) == DataBaseService.Instance.Currentuser.PassHash)
            {
                try
                {

                    DataBaseService.Instance.ExecuteQuery($"Update users set name = '{Name}', lname = '{Lname}', mname = '{Mname}' ,pass_hash = '{HashPassword(Pass)}' where id_guest = {DataBaseService.Instance.Currentuser.Id}");
                    MessageBox.Show("Данные обновлены!");
                        DataBaseService.Instance.Login(Log,Pass);

                    }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка! Проверьте поля.");return;
                }

            }
            }
            else
            {
                MessageBox.Show("Где-то не хватает ваших данных(");
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
