using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Google.Protobuf.WellKnownTypes;
using hotel.Models;
using hotel.Services;
using hotel.Views.Admin;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hotel.ViewModels.Admin.BookingActViewModel
{
    public partial class EditBookingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _num;
        [ObservableProperty]
        private int _id;
        [ObservableProperty]
        private ObservableCollection<CardModel> _card = new ObservableCollection<CardModel>();
        [ObservableProperty]
        private string _nfm;
        [ObservableProperty]
        private object _selectedCard;


        [ObservableProperty]
        private decimal _price;
        [ObservableProperty]
        private DateTime _checkin;
        [ObservableProperty]
        private DateTime _checkout;
        [ObservableProperty]
        private int _roomId;
        [ObservableProperty]
        private int _guestId;
        [ObservableProperty]
        private int _typeRoomId;
        public EditBookingViewModel()
        {
            Load();

        }

        [RelayCommand]
        public void CheckIn(BookingModel a)
        {
            string q = @"INSERT INTO checkin ( datein, dateout, id_num, id_guest, sell, id_typeRoom, id_card) 
                VALUES( @datein, @dateout, @id_num, @id_guest, @priceNigth, @id_typeRoom, @id_card)";

            if (SelectedCard is CardModel ds)
            {
               
                var checkinParams = new Dictionary<string, object>
        {
            
            {"@datein", Checkin.ToString("yyyy-MM-dd")},
            {"@dateout", Checkout.ToString("yyyy-MM-dd")},
            {"@id_num", RoomId},
            {"@id_guest", GuestId },
            {"@priceNigth", Price},
            {"@id_typeRoom", TypeRoomId},
            {"@id_card", ds.Id }
        };

                DataTable dataTable = DataBaseService.Instance.ExecuteQuery(q, checkinParams);
                DataBaseService.Instance.ExecuteQuery($"DELETE FROM booking WHERE id_booking={Id}");

              
                string updateQuery = @"UPDATE rooms 
                              SET id_guest = @id_guest, 
                                  id_status = 3, 
                                  id_card = @id_card,
                                  datein = @datein,
                                  dateout = @dateout
                              WHERE Id_Room = @room_id";

                var roomParams = new Dictionary<string, object>  
        {
            {"@id_guest", GuestId},
            {"@id_card", ds.Id},
            {"@datein", Checkin.ToString("yyyy-MM-dd")}, 
            {"@dateout", Checkout.ToString("yyyy-MM-dd")},
            {"@room_id", RoomId} 
        };

                DataTable dataTables = DataBaseService.Instance.ExecuteQuery(updateQuery, roomParams);
                DataBaseService.Instance.ExecuteQuery($"UPDATE cards SET inproc = 1 WHERE id_cards = {ds.Id}");
            }
        }
        private void Load()
        {
            string q = @"SELECT id_cards, card_num from cards where inproc = 0";
            DataTable dataTable = DataBaseService.Instance.ExecuteQuery(q);
            Card.Clear();
            foreach (DataRow row in dataTable.Rows)
            {

                Card.Add(new CardModel
                {
                    Id = Convert.ToInt32(row["id_cards"]),
                    Card_num = row["card_num"].ToString()
                });
            }
        }

     
        


    }
}
