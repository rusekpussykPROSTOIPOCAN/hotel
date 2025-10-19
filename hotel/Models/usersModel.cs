

namespace hotel.Models
{
    public class usersModel 
    {
        private string _passHash;
        private string _logHash;
        private string _SerianumHash;

        public int Id { get; set; }
        public int Name { get; set; }
        public int id_role { get; set; }
        public virtual RoleModel Role { get; set; }
        public string Lname { get; set; }
        public string Mname { get; set; }
        public string Birthday { get; set; }
        public string PassHash
        {
            get => _passHash; set => _passHash = value;
        }
        public string LogHash
        {
            get => _logHash; set => _logHash = value;
        }
        public string SerianumHash
        {

            get => _SerianumHash; set => _SerianumHash = value;

        }
    }
}
