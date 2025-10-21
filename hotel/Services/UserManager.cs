using hotel.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hotel.Services
{

    class UserManager
    {
        private string baseConn;
        public UserManager()
        {
            baseConn = "server=127.0.0.1;database=hotelbase;";
        }
        public usersModel Aut(string username, string pass)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pass))
                    return null;

                string hashp = HashPassword(pass);
                var user = GetUserWithPassHash(username, hashp);
                if (user != null)
                {
                    string rolepass = GetRolePass(user.Role.Role);
                    if (rolepass != null)
                    {
                        user.roleconn = $"{baseConn}uid={user.Role.Role};pwd={rolepass};";
                    }
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        private usersModel GetUserWithPassHash(string username, string passas)
        {
            string serviceUser = ConfigurationManager.AppSettings["getbasename"];
            string servicepass = ConfigurationManager.AppSettings["getbasepass"];
            string connstr = $"{baseConn}uid={serviceUser};pwd={servicepass};";
            using (var connection = new MySqlConnection(connstr))
            {
                connection.Open();
                string q = @"SELECT id_guest,name,lname,mname,birthday,serianumHASH,log,pass_hash,users.id_role,roles.id_role,roles.role FROM users LEFT JOIN roles ON users.id_role = roles.id_role WHERE log  = @username AND pass_hash = @passhash";

                using (var comm = new MySqlCommand(q, connection))
                {
                    comm.Parameters.AddWithValue("@username", username);
                    comm.Parameters.AddWithValue("@passhash", passas);
                    using (var reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            return new usersModel
                            {
                                Id = reader.GetInt32("id_guest"),
                                Name = reader.GetString("name"),
                                Lname = reader.GetString("lname"),
                                Mname = reader.GetString("mname"),
                                Birthday = reader.GetDateTime("birthday"),
                                PassHash = reader.GetString("pass_hash"),
                                log = reader.GetString("log"),
                                id_role = reader.GetInt32("id_role"),
                                Role = new RoleModel
                                {
                                    Id = reader.GetInt32("id_role"),
                                    Role = reader.GetString("role")
                                }
                                 
                            };
                        }
                    }
                }
            }
            return null;
        }
       private string GetRolePass(string roleName)
        {
            return ConfigurationManager.AppSettings[$"{roleName.ToLower()}pass"];
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

    }
}
