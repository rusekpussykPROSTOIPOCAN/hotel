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
    public class LoginService
    {
        private string baseConn;
        public LoginService()
        {
            baseConn = "server=127.0.0.1;database=hotelbase;";
        }
        public static LoginService Instance { get; } = new LoginService();
        public DataTable LoginServic(string sql, Dictionary<string, object> parameters)
        {
            string serviceUser = ConfigurationManager.AppSettings["getbasename"];
            string servicepass = ConfigurationManager.AppSettings["getbasepass"];
            string connstr = $"{baseConn}uid={serviceUser};pwd={servicepass};";
            using (var connection = new MySqlConnection(connstr))
            {
                connection.Open();
               
                    using (var cmd = new MySqlCommand(sql, connection))
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
        public DataTable LoginServic(string sql)
        {
            string serviceUser = ConfigurationManager.AppSettings["getbasename"];
            string servicepass = ConfigurationManager.AppSettings["getbasepass"];
            string connstr = $"{baseConn}uid={serviceUser};pwd={servicepass};";
            using (var connection = new MySqlConnection(connstr))
            {
                connection.Open();
               
                    using (var cmd = new MySqlCommand(sql, connection))
                    {

                       
                        

                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            return dataTable;
                        }
                    }
                
             
                
            }
        }
    }
}
