using hotel.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.Services
{
   public class DataBaseService
    {
        private usersModel users;
        private UserManager userManager;
 
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
        public DataBaseService()
        {
          userManager = new UserManager();
        }
        public usersModel Currentuser => users;
        public DataTable ExecuteQuery(string sql)
        {
            if(users == null || string.IsNullOrEmpty(Currentuser.roleconn))
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
