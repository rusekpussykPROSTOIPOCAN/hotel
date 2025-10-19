
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.Models
{
    class ScheduleModel
    {
        public int Id { get; set; }
        public string Discription { get; set; }
        public TimeSpan starttime { get; set; }
        public TimeSpan endtime { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int  id_staff { get; set; }
        public virtual usersModel User { get; set; }
     
    }
}
