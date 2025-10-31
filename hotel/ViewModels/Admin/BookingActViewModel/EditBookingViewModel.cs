using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Models;
using hotel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.ViewModels.Admin.BookingActViewModel
{
  public partial  class EditBookingViewModel:ObservableObject
    {
        [ObservableProperty]
        private string _num ;
        [ObservableProperty]
        private string _nfm ;
        [ObservableProperty]
        private double _price;
        [ObservableProperty]
        private DateTime _checkin;
        [ObservableProperty]
        private DateTime _checkout;
        [ObservableProperty]
        private ObservableCollection<RoomTypeModel> _roomTypes = new ObservableCollection<RoomTypeModel>();

        public EditBookingViewModel()
        {
            Load();
        }

        [RelayCommand]
        private void CheckIn()
        {
            string q = @"INSERT INTO checkin (id_checkin, datein, dateout, id_num, id_guest, priceNigth, id_typeRoom) VALUES(@id_checkin, @datein, @dateout, @id_num, @id_guest, @priceNigth, @id_typeRoom)";
            DataTable dataTable = DataBaseService.Instance.ExecuteQuery(q);
            
        }

        private void Load()
        {
            string q = @"SELECT Id_TypeNum, type FROM roomtype";
            DataTable dataTable = DataBaseService.Instance.ExecuteQuery(q);
            RoomTypes.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                RoomTypes.Add(new RoomTypeModel
                {
                    Id = Convert.ToInt32(row["Id_TypeNum"]),
                    Type = row["type"].ToString()
                });
            }
        }
    }
}
