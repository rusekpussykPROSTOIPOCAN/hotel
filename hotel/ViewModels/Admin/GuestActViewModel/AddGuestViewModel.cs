using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace hotel.ViewModels.Admin.GuestActViewModel
{
    public partial class AddGuestViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _lname;

        [ObservableProperty]
        private string _mname;

        [ObservableProperty]
        private DateTime _birthday = DateTime.Now; // Значение по умолчанию

        [ObservableProperty]
        private string _log;

        [ObservableProperty]
        private string _pass;

        [ObservableProperty]
        private string _sernum;

        public void AddUser()
        {
            if (Isnull())
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            try
            {
                string pass = HashPassword(Pass);
                string serNum = HashPassword(Sernum);

                // Проверяем, что пользователь с таким серийным номером не существует
                if (Convert.ToInt32(DataBaseService.Instance.ExecuteQuery(
                    $"SELECT COUNT(1) FROM users WHERE serianumHASH = '{serNum}'").Rows[0][0]) == 0)
                {
                    string sql = @"INSERT INTO users (id_guest, name, lname, mname, birthday, serianumHASH, log, pass_hash, id_role) 
               VALUES(@id, @Name, @Lname, @Mname, @Birthday, @SerNum, @Log, @Pass, 3)";

                    var parameters = new Dictionary<string, object>
                    {
                        {"@id", GenerateGuestId() }, 
                        {"@Name", Name},
                        {"@Lname", Lname},
                        {"@Mname", Mname},
                        {"@Birthday", Birthday.ToString("yyyy-MM-dd")}, 
                        {"@SerNum", serNum},
                        {"@Log", Log},
                        {"@Pass", pass}
                    };

                    DataBaseService.Instance.ExecuteQuery(sql, parameters);
                    MessageBox.Show("Гость успешно добавлен!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Гость с таким серийным номером уже существует!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении гостя: {ex.Message}");
            }
        }

        private int GenerateGuestId()
        {
          
            var result = DataBaseService.Instance.ExecuteQuery("SELECT COALESCE(MAX(id_guest), 0) + 1 FROM users");
            return Convert.ToInt32(result.Rows[0][0]);
        }

        public bool Isnull()
        {
            return string.IsNullOrWhiteSpace(Name) ||
                   string.IsNullOrWhiteSpace(Lname) ||
                   string.IsNullOrWhiteSpace(Mname) ||
                   string.IsNullOrWhiteSpace(Log) ||
                   string.IsNullOrWhiteSpace(Pass) ||
                   string.IsNullOrWhiteSpace(Sernum) ||
                   Birthday == default(DateTime);
        }

        private void ClearFields()
        {
            Name = string.Empty;
            Lname = string.Empty;
            Mname = string.Empty;
            Log = string.Empty;
            Pass = string.Empty;
            Sernum = string.Empty;
            Birthday = DateTime.Now;
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