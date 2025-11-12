

using hotel.Services;
using System.Windows;

namespace hotel.Models
{
   public class TaskModel
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
       public int id_staff { get; set; }
        public virtual usersModel Staff { get; set; }
       public string discript { get; set; }
        public int status_task_id { get; set; }
       public virtual statustaskModel StatusTask { get; set; }

        public Visibility Check => DataBaseService.Instance.Currentuser.Role.Role=="admin" ? Visibility.Visible : Visibility.Collapsed;
        public Visibility CheckGuest => DataBaseService.Instance.Currentuser.Role.Role=="staff" && StatusTask.StatusTask == "Выпоняется" ? Visibility.Visible : Visibility.Collapsed;
    }
}
