using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Models;
using hotel.Services;
using hotel.Views.Admin.NumsAct;
using System.Collections.ObjectModel;
using System.Data;

namespace hotel.ViewModels
{
    public partial class BookingViewModel : ObservableObject
    {
        [ObservableProperty]
         ObservableCollection<BookingModel> _booking = new ObservableCollection<BookingModel>();
        [ObservableProperty]
        private string _vis1;

        [ObservableProperty]
        private string _vis2;

        public BookingViewModel()
        {
            if (DataBaseService.Instance.Currentuser.Role.Role=="admin")
            {
                _vis2 = "Visibly";
                _vis1 = "Hidden";
                LoadGuest();
            }
            else
            {
                _vis1 = "Visibly";
                _vis2 = "Hidden";

            }
        }
        public void LoadGuest()
        {
            Booking.Clear();

            DataTable dataTable = DataBaseService.Instance.ExecuteQuery("SELECT users.id_guest,users.name, users.lname,users.mname,statusesrooms.status, statusesrooms.id_status_room ,rooms.Id_Room, rooms.num ,id_booking, date, booking.id_room,  booking.idpaystatus,  booking.id_guest from booking left join rooms on booking.id_room=rooms.Id_Room \r\nleft join paystatus on paystatus.id_status =booking.idpaystatus left join users on users.id_guest = booking.id_guest \r\nLEFT JOIN statusesrooms ON rooms.id_status = statusesrooms.id_status_room ");
            foreach (DataRow item in dataTable.Rows)
            {
                Booking.Add(new BookingModel
                {
                    Id = Convert.ToInt32(item["id_booking"]),
                    date = Convert.ToDateTime(item["date"]),
                    id_room = Convert.ToInt32(item["id_room"]),
                    RoomModel = new RoomModel
                    {
                        Id= Convert.ToInt32(item["Id_Room"]),
                        num = item["num"].ToString()
                    },
                    idstatus = Convert.ToInt32(item["id_status_room"]),
                    Status = new StatusRoomModel { 
                        Id = Convert.ToInt32(item["id_status_room"]),
                        Status = item["status"].ToString()
                    },
                    id_guest = Convert.ToInt32(item["id_guest"]),
                    usersModel = new usersModel
                    {
                       Id = Convert.ToInt32(item["id_guest"]),
                       Name = item["name"].ToString(),
                       Lname = item["lname"].ToString(),
                       Mname = item["mname"].ToString()

                    }

                    
                });
            }


        }
        [RelayCommand]
        public void checkin()
        {

        }
        [RelayCommand]
        public void delete(object param)
        {

        }
    }
}
