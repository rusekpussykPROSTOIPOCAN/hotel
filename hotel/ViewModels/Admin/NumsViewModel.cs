using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Models;
using hotel.Services;
using hotel.Views.Admin;
using hotel.Views.Admin.NumsAct;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls;

namespace hotel.ViewModels.Admin
{

    
    public partial class NumsViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _currentpage;

        [ObservableProperty]
        private bool _isReadOnly = true;

        [ObservableProperty]
        private string _isVis = "Visibly";
        
        [ObservableProperty]
        private string _isVischeckin = "Visibly";
        [ObservableProperty]
        private ObservableCollection<RoomModel> rooms = new ObservableCollection<RoomModel>();
         

        public string Togle(  string  a )
        {
            a = a == "Visibly" ? "Hidden" : "Visibly";
            return a;
        }
        public NumsViewModel()
        {
            Currentpage = null;
            Load();
        }

        private void Load()
        {
            DataTable dataTable = DataBaseService.Instance.ExecuteQuery("SELECT statusesrooms.id_status_room, cards.card_num, roomtype.type, " +
                "statusesrooms.status,users.name, users.lname,users.mname,Id_Room, num, id_card, " +
                "count_bad, id_status, id_typeRoom, rooms.id_guest,roomtype.Id_TypeNum from rooms" +
                " left join roomtype on roomtype.Id_TypeNum = rooms.Id_Room left join statusesrooms " +
                "on statusesrooms.id_status_room = rooms.id_status left join users on users.id_guest " +
                "= rooms.id_guest left join cards on cards.id_cards = rooms.id_card");
            foreach (DataRow item in dataTable.Rows)
            {

                Rooms.Add(new RoomModel
                {
                    Id = Convert.ToInt32(item["Id_Room"]),
                    num = item["num"].ToString() ?? string.Empty,
                    id_card = item["id_card"] != DBNull.Value ? Convert.ToInt32(item["id_card"]) : 0,
                    count_bad = item["count_bad"] != DBNull.Value ? Convert.ToInt32(item["count_bad"]):0,
                    id_status =item["id_status"] != DBNull.Value ? Convert.ToInt32(item["id_status"]) : 0,
                    id_typeroom = item["Id_TypeNum"] != DBNull.Value ? Convert.ToInt32(item["Id_TypeNum"]) : 0,
                    id_guest =item["id_guest"] != DBNull.Value ? Convert.ToInt32(item["id_guest"]) : 0,
                    Card = new CardModel
                    {
                        Id = item["id_card"] != DBNull.Value ? Convert.ToInt32(item["id_card"]) : 0,
                        Card_num = item["card_num"].ToString() ?? string.Empty
                    },
                    RoomType = new RoomTypeModel
                    {
                        Id = item["Id_TypeNum"] != DBNull.Value ? Convert.ToInt32(item["Id_TypeNum"]) : 0,
                        Type = item["type"].ToString() ?? string.Empty
                    },
                    Guest = new usersModel
                    {
                        Id = item["id_guest"] != DBNull.Value ? Convert.ToInt32(item["id_guest"]) : 0,
                        Name = item["name"].ToString() ?? string.Empty,
                        Lname = item["lname"].ToString() ?? string.Empty,
                        Mname = item["mname"].ToString() ?? string.Empty
                    },
                    StatusRoom = new StatusRoomModel
                    {
                        Id = item["id_typeRoom"] != DBNull.Value ? Convert.ToInt32(item["id_typeRoom"]) : 0,
                        Status = item["status"].ToString() ?? string.Empty
                    }
                   
                });
               
            }
           
        }

        [RelayCommand]
        public void checkin()
        {
            Currentpage = new CheckIn();
            IsVis = Togle(IsVis);
           
           
            
        }
        [RelayCommand]
        public void checkout(object param)
        {
           
        }
        [RelayCommand]
        public void edit(object param)
        {
            Currentpage = new EditNums();
            IsVis = Togle(IsVis);
            IsVischeckin = Togle(IsVischeckin);
           
            
        }
    }
}
