

namespace hotel.Models
{
   public class TaskModel
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
       public int id_staff { get; set; }
        public virtual Staff Staff { get; set; }
       public string discript { get; set; }
        public int status_task_id { get; set; }
       public virtual statustaskModel StatusTask { get; set; }
      
    }
}
