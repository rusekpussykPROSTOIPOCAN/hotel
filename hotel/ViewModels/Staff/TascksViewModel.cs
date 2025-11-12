using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Models;
using hotel.Services;
using hotel.ViewModels.Admin.GuestActViewModel;
using hotel.ViewModels.Admin.TaskActViewModels;
using hotel.Views.Admin.GuestAct;
using hotel.Views.Admin.TasksAct;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace hotel.ViewModels.Staff
{
    public partial class TascksViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _isVisBack = "Hidden";
        [ObservableProperty]
        private string _isAdmin = "Hidden";
        [ObservableProperty]
        private object _currentpage;
        [ObservableProperty]
        private string _isVis = "Hidden";
        [ObservableProperty]
        private string _isVisEdit = "Hidden";
        [ObservableProperty]
        private string _isVisCreate = "Hidden";
        [ObservableProperty]
        private ObservableCollection<TaskModel> _tasks =new();
        public TascksViewModel(){
            if (DataBaseService.Instance.Currentuser.Role.Role == "admin")
            {
                IsVisBack = "Hidden";
                IsVis = "Visibly";
                IsVisEdit = "Hidden";
                IsVisCreate = "Visibly";
                Currentpage = null;
                IsAdmin = "Visibly";
                LoadTask();
            }
            else
            {
                IsVis = "Visibly";
                IsAdmin = "Hidden";
                Currentpage = null;
                LoadTask();
            }
            
        }
       
        public string Togle(string a)
        {
            a = a == "Visibly" ? "Hidden" : "Visibly";
            return a;
        }
        public void LoadTask()
        {
            Tasks.Clear();

            DataTable dataTable = DataBaseService.Instance.ExecuteQuery(@"SELECT id_task, datetime, users.name, users.lname, users.mname,discript, statusestasks.status ,status_task_id FROM tasks left join users on users.id_guest = tasks.id_staff left join statusestasks on  statusestasks.Id_status = tasks.status_task_id");
            foreach (DataRow item in dataTable.Rows)
            {
                Tasks.Add(new TaskModel
                {
                    Id = Convert.ToInt32(item["id_task"]),
                    dateTime = Convert.ToDateTime(item["datetime"]),
                    id_staff = Convert.ToInt32(item["status_task_id"]),
                    discript = item["discript"].ToString(),
                    status_task_id = Convert.ToInt32(item["status_task_id"]),

                    Staff = new usersModel
                    {
                        Name = item["name"].ToString(),
                        Lname = item["lname"].ToString(),
                        Mname = item["mname"].ToString()
                    },

                    StatusTask = new statustaskModel
                    {
                        Id =Convert.ToInt32( item["status_task_id"]) ,
                        StatusTask = item["status"].ToString()
                    }
                });
            }


        }
        [RelayCommand]
        public void Complete(TaskModel task)
        {
            DataBaseService.Instance.ExecuteQuery($"Update tasks set status_task_id= 2 where id_task = {task.Id} ");
            LoadTask();
        }
        [RelayCommand]
        public void Cancel(TaskModel task)
        {
            DataBaseService.Instance.ExecuteQuery($"Update tasks set status_task_id= 3 where id_task = {task.Id} ");
            LoadTask();

        }
        

        [RelayCommand]
        public void delete(TaskModel param)
        {
            DataBaseService.Instance.ExecuteQuery($"DELETE FROM tasks WHERE id_task={param.Id}");
          LoadTask();
        }
        private TaskEditViewModel editVm;
        [RelayCommand]
        public void edit(TaskModel param)
        {


            if (IsVis == "Visibly") 
            {
                
                editVm = new TaskEditViewModel()
                {
                    Id = param.Id,
                    Disc = param.discript,
                    SelectedStaff = param.Staff,
                    Selectedstask = param.StatusTask,
                };

                var editT = new EditTaskPage();
                editT.DataContext = editVm;
                Currentpage = editT;

             
                IsVis = "Hidden"; 
                IsVisEdit = "Visibly"; 
                IsVisCreate = "Hidden"; 
                IsVisBack = "Visibly"; 
            }
            else 
            {
              
                if (editVm != null)
                {
                    editVm.Update(param);
                    LoadTask();
                }

               
                Currentpage = null;
                IsVis = "Visibly"; 
                IsVisEdit = "Hidden";
                IsVisCreate = "Visibly"; 
                IsVisBack = "Hidden"; 
                editVm = null;
            }
        }
        [RelayCommand]
        public void Back()
        {
            
            Currentpage = null;
            IsVis = "Visibly";
            IsVisEdit = "Hidden";
            IsVisCreate = "Visibly";
            IsVisBack = "Hidden";
            editVm = null;
        }
        [RelayCommand]
        public void create()
        {


            if (IsVis == "Visibly")
            {
                var addG = new CreateTaskPage();
                Currentpage = addG;
                IsVis = Togle(IsVis);
            }
            else
            {
              
                if (Currentpage is CreateTaskPage currentPage)
                {
                    var currentViewModel = currentPage.DataContext as CreateTaskViewModel;

                    if (currentViewModel == null)
                    {
                        MessageBox.Show("Ошибка инициализации страницы");
                        return;
                    }


                    if (currentViewModel.IsNull())
                    {
                        MessageBox.Show("Заполните поля");
                        return;
                    }

                    currentViewModel.CreateTask();
                    LoadTask();
                }

                IsVis = Togle(IsVis);
                Currentpage = null;
            }
        }
        }
}
