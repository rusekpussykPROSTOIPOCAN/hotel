using CommunityToolkit.Mvvm.ComponentModel;
using hotel.Models;
using hotel.Services;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Linq;


namespace hotel.ViewModels.Admin.TaskActViewModels
{
    public partial class TaskEditViewModel:ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<usersModel> _staff = new ObservableCollection<usersModel>();
        [ObservableProperty]
        private object _selectedStaff;
        [ObservableProperty]
        private string _disc;
        [ObservableProperty]
        private ObservableCollection<statustaskModel> _stask = new ObservableCollection<statustaskModel>();
        [ObservableProperty]
        private object _selectedstask;
        [ObservableProperty]
        private int id;

        public TaskEditViewModel(){
            Load();
            Load1();
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
        private void Load1()
        {
            string q = @"SELECT Id_status, status FROM statusestasks";
            DataTable dataTable = DataBaseService.Instance.ExecuteQuery(q);
            Stask.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                Stask.Add(new statustaskModel
                {
                  Id = Convert.ToInt32(row["Id_status"]),
                  StatusTask = row["status"].ToString()
                });
            }
        }

        public void Update(TaskModel p)
        {
            if (string.IsNullOrWhiteSpace(Disc) || SelectedStaff == null || Selectedstask ==null)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            string sql = @"UPDATE tasks SET discript = @Disc,id_staff= @Staff,status_task_id = @statusid WHERE id_task=@Id ";
            if (SelectedStaff is usersModel users)
            {
                if (Selectedstask is statustaskModel statustaskModel)
                {



                    var parameters = new Dictionary<string, object>
                    {
                        {"@Id", Id  },
                        {"@Disc", Disc??"" },
                        {"@Staff", users.Id},
                        {"@statusid",statustaskModel.Id }


                    };
            DataBaseService.Instance.ExecuteQuery(sql, parameters);
            MessageBox.Show("Обновлено!");
                }
            }
        }
    }
}
