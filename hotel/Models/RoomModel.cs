

namespace hotel.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public int id_card { get; set; }
        public virtual CardModel Card { get; set; }
        public int id_typeroom { get; set; }
        public virtual RoomTypeModel RoomType { get; set; }
        public int num { get; set; }
        public int count_bad { get; set; }
    }
}
