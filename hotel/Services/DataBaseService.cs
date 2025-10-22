using hotel.Models;
using MySql.Data.MySqlClient;
using System.Data;


namespace hotel.Services
{
   public class DataBaseService
    {
        private usersModel users;
        private UserManager userManager;
        public static DataBaseService Instance { get; } = new DataBaseService();
        public DataBaseService()
        {
          userManager = new UserManager();
        }
        public bool Login (string username, string pass)
        {
            var user = userManager.Aut(username, pass);
            if (user != null)
            {
                users = user;
               
                return true;
            }
            return false;
        }
        public usersModel Currentuser => users;
        public DataTable ExecuteQuery(string sql, Dictionary<string, object> parameters)
        {
            if (Currentuser == null || string.IsNullOrEmpty(Currentuser.roleconn))
            {
                throw new Exception("нет пользователя");
            }
            using (var conn = new MySqlConnection(Currentuser.roleconn))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }
        public DataTable ExecuteQuery(string sql)
        {
            if(Currentuser == null || string.IsNullOrEmpty(Currentuser.roleconn))
            {
                throw new Exception("нет пользователя");
            }
            using (var conn = new MySqlConnection(Currentuser.roleconn))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn)) {
                    using (var reader = cmd.ExecuteReader()) { 
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
            
        }
       
    }
}
