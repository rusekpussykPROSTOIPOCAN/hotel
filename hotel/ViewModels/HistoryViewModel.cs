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
                    Id = item["id_checkin"] != DBNull.Value ? Convert.ToInt32(item["id_checkin"]) : 0,
                    datein = item["datein"] != DBNull.Value ? Convert.ToDateTime(item["datein"]) : DateTime.MinValue,
                    dateout = item["dateout"] != DBNull.Value ? Convert.ToDateTime(item["dateout"]) : DateTime.MinValue,
                    id_room = item["id_num"] != DBNull.Value ? Convert.ToInt32(item["id_num"]) : 0,
                    room = new RoomModel
                    {
                        num = item["num"] != DBNull.Value ? item["num"].ToString() : string.Empty
                    },
                    id_guest = item["id_guest"] != DBNull.Value ? Convert.ToInt32(item["id_guest"]) : 0,
                    UsersModel = new usersModel
                    {
                        Name = item["name"] != DBNull.Value ? item["name"].ToString() : string.Empty,
                        Lname = item["lname"] != DBNull.Value ? item["lname"].ToString() : string.Empty,
                        Mname = item["mname"] != DBNull.Value ? item["mname"].ToString() : string.Empty
                    },
                    priceNigth = item["sell"] != DBNull.Value ? Convert.ToDecimal(item["sell"]) : 0m,
                    id_typeRoom = item["id_typeRoom"] != DBNull.Value ? Convert.ToInt32(item["id_typeRoom"]) : 0,
                    roomType = new RoomTypeModel
                    {
                        Type = item["type"] != DBNull.Value ? item["type"].ToString() : string.Empty
                    },
                    id_card = item["id_card"] != DBNull.Value ? Convert.ToInt32(item["id_card"]) : 0,
                    card = new CardModel
                    {
                        Card_num = item["card_num"] != DBNull.Value ? item["card_num"].ToString() : string.Empty
                    }
                });
            }

        }
       
        
    }
}
