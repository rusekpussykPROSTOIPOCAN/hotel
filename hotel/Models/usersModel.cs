

using System.Windows;

namespace hotel.Models
{
    public class usersModel 
    {
        private string _passHash;
      
        private string _SerianumHash;

        public int Id { get; set; }
        public string Name { get; set; }
        public int id_role { get; set; }
        public virtual RoleModel Role { get; set; }
        public string Lname { get; set; }
        public string Mname { get; set; }
        public DateTime Birthday { get; set; }
        public string PassHash
        {
            get => _passHash; set => _passHash = value;
        }
        public string log;
        public string SerianumHash
        {

            get => _SerianumHash; set => _SerianumHash = value;

        }
        public string roleconn {  get; set; }
        public string FullName => $"{Lname} {Name} {Mname}".Trim() ;
        public Visibility Check => !string.IsNullOrEmpty(FullName) ? Visibility.Visible : Visibility.Collapsed;
      
    }
}
