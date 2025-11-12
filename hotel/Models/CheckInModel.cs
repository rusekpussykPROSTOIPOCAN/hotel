using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.Models
{
    public class CheckInModel
    {
        public int Id { get; set; }
        public DateTime datein { get; set; }
        public DateTime dateout { get; set; }
        public int id_room { get; set; }
        public virtual RoomModel room { get; set; }
        public int id_guest { get; set; }
        public virtual usersModel UsersModel { get; set; }
        public decimal priceNigth { get; set; }
        public int id_typeRoom { get; set; }
        public virtual RoomTypeModel roomType { get; set; }
        public int id_card { get; set; }
        public virtual CardModel card { get; set; }

    }
}
