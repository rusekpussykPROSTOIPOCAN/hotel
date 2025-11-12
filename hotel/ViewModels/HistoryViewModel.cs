using CommunityToolkit.Mvvm.ComponentModel;
using hotel.Models;
using hotel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.ViewModels
{
    public partial class HistoryViewModel:ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<CheckInModel> checkInModels= new ObservableCollection<CheckInModel>();
        public HistoryViewModel()
        {
            if(DataBaseService.Instance.Currentuser.Role.Role == "guest")
            {
                DataTable s = DataBaseService.Instance.ExecuteQuery($"SELECT rooms.num, roomtype.type,users.name,users.lname,users.mname,cards.card_num,checkin.id_checkin, checkin.datein, checkin.dateout, checkin.id_num, checkin.id_guest, checkin.id_typeRoom, checkin.id_card, checkin.sell FROM checkin left join rooms on rooms.Id_Room = checkin.id_num left join users on users.id_guest = checkin.id_guest left join roomtype on roomtype.Id_TypeNum= checkin.id_typeRoom left join cards on cards.id_cards = checkin.id_card where  checkin.id_guest = {DataBaseService.Instance.Currentuser.Id}");

               Load(s);
            }
            else
            {
                DataTable s = DataBaseService.Instance.ExecuteQuery("SELECT rooms.num, roomtype.type,users.name,users.lname,users.mname,cards.card_num,checkin.id_checkin, checkin.datein, checkin.dateout, checkin.id_num, checkin.id_guest, checkin.id_typeRoom, checkin.id_card, checkin.sell FROM checkin left join rooms on rooms.Id_Room = checkin.id_num left join users on users.id_guest = checkin.id_guest left join roomtype on roomtype.Id_TypeNum= checkin.id_typeRoom left join cards on cards.id_cards = checkin.id_card;");

                Load(s);
            }
        }
        public void Load(DataTable s)
        {
            foreach (DataRow item in s.Rows)
            {
                CheckInModels.Add(new CheckInModel {
                    Id = Convert.ToInt32(item["id_checkin"]),
                    datein = Convert.ToDateTime(item["datein"]),
                    dateout = Convert.ToDateTime(item["dateout"]),
                    id_room = Convert.ToInt32(item["id_num"]),
                   room = new RoomModel
                   {
                       num = item["num"].ToString()
                   },
                   id_guest = Convert.ToInt32(item["id_guest"]),
                    UsersModel = new usersModel
                    {
                        Name = item["name"].ToString(),
                        Lname=item["lname"].ToString(),
                        Mname=item["mname"].ToString()

                    },
                   priceNigth = Convert.ToDecimal(item["sell"]),
                    id_typeRoom=Convert.ToInt32(item["id_typeRoom"]),
                    roomType = new RoomTypeModel
                    {
                        Type = item["type"].ToString(),
                    },
                   id_card = Convert.ToInt32(item["id_card"]),
                   card = new CardModel
                   {
                       Card_num = item["card_num"].ToString(),
                   }
                });
            }

        }
       
        
    }
}
