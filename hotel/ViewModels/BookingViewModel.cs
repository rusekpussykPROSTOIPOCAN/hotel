using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Models;
using hotel.Services;
using hotel.ViewModels.Admin.BookingActViewModel;
using hotel.Views.Admin.BookingAct;
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
        private object _currentpage;
        [ObservableProperty]
        private string _vis2 = "Visibly";
        [ObservableProperty]
        private string _isVisEdit = "Hidden";
        public string Togle(string a)
        {
            a = a == "Visibly" ? "Hidden" : "Visibly";
            return a;
        }
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

            DataTable dataTable = DataBaseService.Instance.ExecuteQuery("SELECT rooms.price,users.id_guest,rooms.id_typeRoom,users.name,paystatus.statuss,users.lname,users.mname,statusesrooms.status, " +
                "statusesrooms.id_status_room ,rooms.Id_Room, rooms.num ,id_booking, date, booking.id_room,  " +
                "booking.idpaystatus,  booking.id_guest from booking left join rooms on booking.id_room=rooms.Id_Room " +
                "left join paystatus on paystatus.id_status =booking.idpaystatus left join users on users.id_guest = booking.id_guest " +
                "LEFT JOIN statusesrooms ON rooms.id_status = statusesrooms.id_status_room");
            foreach (DataRow item in dataTable.Rows)
            {
                Booking.Add(new BookingModel
                {
                    Id = item["id_booking"] != DBNull.Value ? Convert.ToInt32(item["id_booking"]) : 0,
                    date = item["date"] != DBNull.Value ? Convert.ToDateTime(item["date"]) : DateTime.MinValue,
                    id_room = item["id_room"] != DBNull.Value ? Convert.ToInt32(item["id_room"]) : 0,
                    RoomModel = new RoomModel
                    {
                        Id = item["Id_Room"] != DBNull.Value ? Convert.ToInt32(item["Id_Room"]) : 0,
                        num = item["num"] != DBNull.Value ? item["num"].ToString() : string.Empty,
                        id_typeroom = item["id_typeRoom"] != DBNull.Value ? Convert.ToInt32(item["id_typeRoom"]) : 0,
                        PriceNigth = item["price"] != DBNull.Value ? Convert.ToDecimal(item["price"]) : 0m
                    },
                    idstatus = item["id_status_room"] != DBNull.Value ? Convert.ToInt32(item["id_status_room"]) : 0,
                    Status = new StatusRoomModel
                    {
                        Id = item["id_status_room"] != DBNull.Value ? Convert.ToInt32(item["id_status_room"]) : 0,
                        Status = item["status"] != DBNull.Value ? item["status"].ToString() : string.Empty
                    },
                    id_guest = item["id_guest"] != DBNull.Value ? Convert.ToInt32(item["id_guest"]) : 0,
                    usersModel = new usersModel
                    {
                        Id = item["id_guest"] != DBNull.Value ? Convert.ToInt32(item["id_guest"]) : 0,
                        Name = item["name"] != DBNull.Value ? item["name"].ToString() : string.Empty,
                        Lname = item["lname"] != DBNull.Value ? item["lname"].ToString() : string.Empty,
                        Mname = item["mname"] != DBNull.Value ? item["mname"].ToString() : string.Empty
                    },
                    id_pay = item["idpaystatus"] != DBNull.Value ? Convert.ToInt32(item["idpaystatus"]) : 0,
                    Paystatus = new PaystatusModel
                    {
                        Id = item["idpaystatus"] != DBNull.Value ? Convert.ToInt32(item["idpaystatus"]) : 0,
                        status = item["statuss"] != DBNull.Value ? item["statuss"].ToString() : string.Empty
                    }

                });
            }


        }
        private EditBookingViewModel p;
        [RelayCommand]
        public void checkin(BookingModel param)
        {
            if (Vis2 == "Visibly")
            {
                p = new EditBookingViewModel()
                {
                    Num = param.RoomModel.num,
                    Nfm = param.usersModel.FullName,
                    Price= param.RoomModel.PriceNigth,
                    Checkin = param.date,
                    Checkout = param.date,
                    RoomId = param.id_room,
                    GuestId = param.id_guest,
                    TypeRoomId = param.RoomModel.id_typeroom,
                    Id = param.Id

                };
                Vis2 = Togle(Vis2);
                var a = new EditBookingPage();
                a.DataContext = p;
                Currentpage = a;
                IsVisEdit = Togle(IsVisEdit);
            }
            else
            {
                
                p.CheckIn(param);
                LoadGuest();
                Vis2 = Togle(Vis2);
                IsVisEdit = Togle(IsVisEdit);

            }
        }

        
            [RelayCommand]
        public void delete(BookingModel param)
        {
            DataBaseService.Instance.ExecuteQuery($"DELETE FROM booking WHERE id_booking={param.Id}");
            LoadGuest();
        }
    }
}
