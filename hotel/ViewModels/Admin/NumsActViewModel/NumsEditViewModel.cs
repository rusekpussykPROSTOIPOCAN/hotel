using CommunityToolkit.Mvvm.ComponentModel;
using hotel.Models;
using hotel.Services;
using Org.BouncyCastle.Crypto;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace hotel.ViewModels.Admin.NumsActViewModel
{
   public partial class NumsEditViewModel:ObservableObject
    {
        [ObservableProperty]
        private RoomModel _num;
        [ObservableProperty]
        private string _vis = "Hidden";
        private int numid;
        [ObservableProperty]
        private ObservableCollection<RoomModel> _rooms = new ObservableCollection<RoomModel>();
        [ObservableProperty]
        private usersModel _guest;
        private int idguest;
        [ObservableProperty]
        private ObservableCollection<usersModel> _users = new ObservableCollection<usersModel>(); [ObservableProperty]

        private StatusRoomModel _statusnew;
        private int idstatus;
        [ObservableProperty]
        private ObservableCollection<StatusRoomModel> _status = new ObservableCollection<StatusRoomModel>();

        [ObservableProperty]
        private CardModel _card;
        private int idcard;
        [ObservableProperty]
        private ObservableCollection<CardModel> _cards = new ObservableCollection<CardModel>();
        [ObservableProperty]
        private RoomTypeModel _typenum;
        private int idtypenum;
        [ObservableProperty]
        private ObservableCollection<RoomTypeModel> _typeroom = new ObservableCollection<RoomTypeModel>();
        [ObservableProperty]
        private RoomModel _countbads;
        [ObservableProperty]
        private DateTime _checkInDate = DateTime.Now;
        [ObservableProperty]
        private DateTime _checkOutDate = DateTime.Now;
        [ObservableProperty]
        private ObservableCollection<RoomModel> _roombads = new ObservableCollection<RoomModel>();
        private decimal sell = 0;

        public NumsEditViewModel()
        {
            if (DataBaseService.Instance.Currentuser.Role.Role == "guest")
            {
                Vis = "Collapsed";
                Loadnum();
            }
            else
            {
                Vis = "Visibly";
                LoadGuest();
                Loadstatus();
            }
            LoadCards();
            LoadTypeRoom();
            LoadCountBads();
           
        }
        public void Booking()
        {

            if (sell == 0 || numid == 0 || idguest == 0 || idtypenum == 0 ||  Guest == null  || Typenum == null || Countbads == null)
            {
                MessageBox.Show("Введите данные"); return;
            }
           
            string q = "insert into booking( date, id_room, idpaystatus, id_guest) values( @date, @id_room, @idpaystatus, @id_guest)";
            var param = new Dictionary<string, object>
            {
                
                { "@date" , CheckInDate},
                { "@dateout", CheckOutDate},
                {"@id_room",  numid},
                {"@idpaystatus", 1},
                { "@id_guest", DataBaseService.Instance.Currentuser.Id},
               

            };
            DataBaseService.Instance.ExecuteQuery(q, param);
           

            
            
          
        }
        public void CheckIn()
        {

            if ((sell<=0||numid == 0 || idtypenum == 0 || Guest == null || Typenum == null || Countbads == null || idguest == 0 || idcard == 0) && idstatus==0)
            {
                MessageBox.Show("Введите данные"); return;
            }
            if (idstatus != 0 && idguest==0 )
            {
                DataTable data = DataBaseService.Instance.ExecuteQuery($"Update rooms set id_status = {idstatus} where Id_Room = {numid}");
            }
            else
            {

            sell *= (CheckOutDate.Date - CheckInDate.Date).Days+1;
            string q = "insert into checkin(id_checkin, datein, dateout, id_num, id_guest, id_typeRoom, id_card, sell) values(@id_checkin, @datein, @dateout, @id_num, @id_guest, " +
                 "@id_typeRoom, @id_card,@sell)";
            var param = new Dictionary<string, object>
            {
                {"@id_checkin", GenerateGuestId()},
                { "@datein" , CheckInDate},
                { "@dateout", CheckOutDate},
                {"@id_num",  numid},
                {"@id_guest", idguest},
                { "@id_typeRoom", idtypenum},
                { "@id_card", idcard },
                { "@sell", sell }

            };
            DataBaseService.Instance.ExecuteQuery(q, param);
            string updateQuery = @"UPDATE rooms 
                      SET id_guest = @id_guest, 
                          id_status = @st, 
                          id_card = @id_card,
                          datein = @datein,
                          dateout = @dateout
                      WHERE Id_Room = @room_id";

            var parameters = new Dictionary<string, object>
{
    {"@id_guest", idguest},
    {"@id_card", idcard},
    {"@datein", CheckInDate.Date},
    {"@dateout", CheckOutDate.Date},
    {"@room_id", numid},
                {"@st", idstatus},
};

            DataTable dataTable = DataBaseService.Instance.ExecuteQuery(updateQuery, parameters);
           
          /*  sell = 0; numid = 0; idguest = 0;  idtypenum = 0; idcard = 0; Num = null;
            Guest = null;Card = null;Typenum = null; Countbads = null;*/
            }
        }
        private int GenerateGuestId()
        {

            var result = DataBaseService.Instance.ExecuteQuery("SELECT COALESCE(MAX(id_checkin), 0) + 1 FROM checkin");
            return Convert.ToInt32(result.Rows[0][0]);
        }
        private void Loadnum()
        {

            Rooms.Clear();
            DataTable data = DataBaseService.Instance.ExecuteQuery("select rooms.Id_Room,num, id_typeRoom, price from rooms left join booking on booking.id_room = rooms.Id_Room where id_card is null and booking.id_room is null");
            foreach (DataRow row in data.Rows)
            {
                Rooms.Add(new RoomModel
                {
                    Id = Convert.ToInt32(row["Id_Room"]),
                    num = row["num"] != DBNull.Value? row["num"].ToString():"нет номеров",
                    id_typeroom = Convert.ToInt32(row["id_typeRoom"]),
                    
                });

            }
        }
        private void LoadCards()
        {
            Cards.Clear();
            DataTable data = DataBaseService.Instance.ExecuteQuery("select id_cards, card_num from cards where inproc = 0");
            foreach (DataRow row in data.Rows)
            {
                Cards.Add(new CardModel {
                    Id = Convert.ToInt32(row["id_cards"]),
                    Card_num = row["card_num"].ToString()
                });

            }
        } private void Loadstatus()
        {
            Status.Clear();
            DataTable data = DataBaseService.Instance.ExecuteQuery("select id_status_room,statusesrooms.status from statusesrooms;");
            foreach (DataRow item in data.Rows)
            {
                Status.Add(new StatusRoomModel
                {
                    Id = Convert.ToInt32(item["id_status_room"]),
                    Status = item["status"].ToString()
                });
            }
        }
        private void LoadTypeRoom()
        {
            Typeroom.Clear();
            DataTable data = DataBaseService.Instance.ExecuteQuery("select Id_TypeNum, type from roomtype left join rooms on rooms.id_typeRoom  = roomtype.Id_TypeNum where rooms.id_typeRoom is not null");
            foreach (DataRow row in data.Rows)
            {
                Typeroom.Add(new RoomTypeModel
                {
                    Id = Convert.ToInt32(row["Id_TypeNum"]),
                    Type = row["type"].ToString()
                });

            }
        }
        private void LoadCountBads()
        {
            Roombads.Clear();
            DataTable data = DataBaseService.Instance.ExecuteQuery("select  distinct count_bad, Id_Room, price from rooms where id_card is null");
            foreach (DataRow row in data.Rows)
            {
                Roombads.Add(new RoomModel
                {
                    Id = Convert.ToInt32(row["Id_Room"]),
                    count_bad = Convert.ToInt32(row["count_bad"]),
                    PriceNigth = Convert.ToDecimal(row["price"])

                });

            }
            
        }
        private void LoadGuest()
        {
            Users.Clear();
          
        
            DataTable data = DataBaseService.Instance.ExecuteQuery("Select users.id_guest,name,lname,mname from users left join rooms " +
                "on rooms.id_guest = users.id_guest left join roles on roles.id_role = users.id_role where  roles.role like 'guest'");
            foreach(DataRow row in data.Rows)
            {
                Users.Add(new usersModel
                {
                    Id = Convert.ToInt32(row["id_guest"]),
                    Name = row["name"].ToString(),
                    Lname = row["lname"].ToString(),
                    Mname = row["mname"].ToString()
                });
            }
        }

        partial void OnCardChanged(CardModel value)
        {
            idcard = value.Id;
        }
        partial void OnGuestChanged(usersModel value)
        {
            idguest = value.Id;
        }
        partial void OnNumChanged(RoomModel value)
        {
            if (value != null)
            {
                Countbads = Roombads.FirstOrDefault(t=>t.Id == value.Id);
                Typenum = Typeroom.FirstOrDefault(t=>t.Id == value.id_typeroom);
                numid = value.Id;
             
               

            }
        }
        partial void OnTypenumChanged(RoomTypeModel value)
        {
            if (value != null)
            {
               Num = Rooms.FirstOrDefault(t=>t.Id == value.Id);
               
                Countbads = Roombads.FirstOrDefault(t=>t.Id == Num.Id);
                idtypenum = value.Id;
            }
        }
        partial void OnCountbadsChanged(RoomModel value)
        {
            if (value!=null)
            {
                Num = Rooms.FirstOrDefault(t => t.Id == value.Id);
                var a  = Rooms.FirstOrDefault( t => t.Id == value.Id);
                Typenum = Typeroom.FirstOrDefault(t=>t.Id == a.id_typeroom);
                sell = value.PriceNigth;
            }
        }
        partial void OnStatusnewChanged(StatusRoomModel value)
        {
            idstatus = value.Id;
        }
    }
}
