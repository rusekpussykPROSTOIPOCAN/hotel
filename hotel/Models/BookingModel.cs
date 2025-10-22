namespace hotel.Models
{
    class BookingModel
    {
       public int Id { get; set; }
        public DateTime date { get; set; }
        public int id_room { get; set; }
        public virtual RoomModel RoomModel { get; set; }
        public int idstatus { get; set; }
        public virtual StatusRoomModel Status { get; set; }
        public int id_guest { get; set; }
        public virtual usersModel usersModel { get; set; }
       
    }
}
