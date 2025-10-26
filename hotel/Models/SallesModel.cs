using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.Models
{
   public class SallesModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int id_staff { get; set; }
        public virtual usersModel Staff { get; set; }
        public int id_user { get; set; }
        public virtual usersModel User { get; set; }
        public int id_uslugi { get; set; }
        public virtual UslugiModel Uslugi { get; set; }

        public decimal Sale { get; set; }
    }
}
