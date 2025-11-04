using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Google.Protobuf.WellKnownTypes;
using hotel.Models;
using hotel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hotel.ViewModels.Admin.BookingActViewModel
{
  public partial  class EditBookingViewModel:ObservableObject
    {
        [ObservableProperty]
        private string _num ;
        [ObservableProperty]
        private int _id ;
        [ObservableProperty]
        private ObservableCollection<CardModel> _card = new ObservableCollection<CardModel>() ;
        [ObservableProperty]
        private string _nfm ;
        [ObservableProperty]
        private object _selectedCard ;
        [ObservableProperty]
        private decimal _price ;
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
        public EditBookingViewModel( )
        {
            Load();
           
        }

        [RelayCommand]
        public void CheckIn(BookingModel a)
        {
            string q = @"INSERT INTO checkin (id_checkin, datein, dateout, id_num, id_guest, priceNigth, id_typeRoom, id_card) VALUES(@id_checkin, @datein, @dateout, 
@id_num, @id_guest, @priceNigth, @id_typeRoom, @id_card )";
            if (SelectedCard is CardModel ds)
            {

            var parameters = new Dictionary<string, object>
                    {
                        {"@id_checkin", GenerateGuestId() },
                        {"@datein",Checkin.ToString("yyyy-MM-dd")},
                        {"@dateout", Checkout.ToString("yyyy-MM-dd")},
                        {"@id_num",RoomId},
                        {"@id_guest",GuestId },
                        {"@priceNigth", Price},
                        {"@id_typeRoom", TypeRoomId},
                        {"@id_card", ds.Id }

                        
                    };

            DataTable dataTable = DataBaseService.Instance.ExecuteQuery(q,parameters);
                DataBaseService.Instance.ExecuteQuery($"DELETE FROM booking WHERE id_booking={Id}");
                DataBaseService.Instance.ExecuteQuery($"UPDATE cards set inproc = 1 where id_cards = {ds.Id}");
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
        private int GenerateGuestId()
        {

            var result = DataBaseService.Instance.ExecuteQuery("SELECT COALESCE(MAX(id_checkin), 0) + 1 FROM checkin");
            return Convert.ToInt32(result.Rows[0][0]);
        }
       
        
    }
}
