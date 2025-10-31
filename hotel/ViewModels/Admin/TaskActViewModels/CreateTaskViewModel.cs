using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Models;
using hotel.Services;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Org.BouncyCastle.Crypto;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls.Primitives;
using System.Xml.Linq;


namespace hotel.ViewModels.Admin.TaskActViewModels
{
    public partial class CreateTaskViewModel : ObservableObject
    {
   
        [ObservableProperty]
        private ObservableCollection<usersModel> _staff = new ObservableCollection<usersModel>();
        [ObservableProperty]
        private object _selectedStaff;
        [ObservableProperty]
        private string _disc;

        public CreateTaskViewModel()
        {
            Load();
         
        }

        private void Load()
        {
            string q = @"SELECT id_guest, name, lname, mname FROM users left join roles on users.id_role = roles.id_role WHERE roles.role LIKE 'staff'";
            DataTable dataTable = DataBaseService.Instance.ExecuteQuery(q);
            Staff.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                Staff.Add(new usersModel
                {
                    Id = Convert.ToInt32(row["id_guest"]),
                    Name = row["name"].ToString(),
                    Lname = row["lname"].ToString(),
                    Mname = row["mname"].ToString()

                });
            }
        }
       

      
        public void CreateTask()
        {
            if (SelectedStaff is usersModel staff)
            {
                var staffId = staff.Id;
                string q = @"INSERT INTO tasks(id_task, datetime, id_staff, discript, status_task_id) VALUES (@id_task, @datetime, @id_staff, @discript, 1)";
                var param = new Dictionary<string, object>
{
                    {"@id_task", GenerateTaskId() },
                    {"@datetime", DateTime.Now},
                    {"@id_staff", staffId},
                    {"@discript", Disc ?? ""},


};
                DataBaseService.Instance.ExecuteQuery(q, param);
            }

           
        }

        public bool IsNull()
        {
            return string.IsNullOrWhiteSpace(Disc) ||
           SelectedStaff == null;

        }
        private int GenerateTaskId()
        {
            var result = DataBaseService.Instance.ExecuteQuery("SELECT COALESCE(MAX(id_task), 0) + 1 FROM tasks");
            return Convert.ToInt32(result.Rows[0][0]);
        }
    }
}
