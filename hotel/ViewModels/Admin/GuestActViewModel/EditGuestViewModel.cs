using CommunityToolkit.Mvvm.ComponentModel;
using Google.Protobuf.WellKnownTypes;
using hotel.Models;
using hotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hotel.ViewModels.Admin.GuestActViewModel
{
  public partial  class EditGuestViewModel:ObservableObject
    {
        [ObservableProperty]
        private string _name ;

        [ObservableProperty]
        private string _lname;

        [ObservableProperty]
        private string _mname;

        [ObservableProperty]
        private DateTime _birthday = DateTime.Now; 

        [ObservableProperty]
        private string _log;

        public void Update(usersModel p)
        {
            if (Isnull())
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            string sql = @"UPDATE users SET name = @Name,lname=@Lname,mname = @Mname,birthday = @Birthday, log=@Log WHERE id_guest=@Id ";

            var parameters = new Dictionary<string, object>
                    {
                        {"@id", p.Id },
                        {"@Name", Name},
                        {"@Lname", Lname},
                        {"@Mname", Mname},
                        {"@Birthday", Birthday.ToString("yyyy-MM-dd")},
                       
                        {"@Log", Log},
                       
                    };

            DataBaseService.Instance.ExecuteQuery(sql, parameters);
            MessageBox.Show("Обновлено!");
        }
        public bool Isnull()
        {
            return string.IsNullOrWhiteSpace(Name) ||
                   string.IsNullOrWhiteSpace(Lname) ||
                   string.IsNullOrWhiteSpace(Mname) ||
                   string.IsNullOrWhiteSpace(Log) ||
                 
                   Birthday == default(DateTime);
        }

    }
}
