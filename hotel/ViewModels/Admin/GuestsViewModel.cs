using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Models;
using hotel.Services;
using hotel.ViewModels.Admin.GuestActViewModel;
using hotel.Views.Admin.GuestAct;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;


namespace hotel.ViewModels.Admin
{
    public partial class GuestsViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _currentpage;

        [ObservableProperty]
        private ObservableCollection<usersModel> _guest = new();



        [ObservableProperty]
        private bool _isReadOnly = true;

        [ObservableProperty]
        private string _isVis = "Visibly";
        [ObservableProperty]
        private string _isVisBack = "Hidden";
        [ObservableProperty]
        private string _isVisEdit = "Hidden";
        [ObservableProperty]
        private string _isVisGuestAdd = "Visibly";


        public string Togle(string a)
        {
            a = a == "Visibly" ? "Hidden" : "Visibly";
            return a;
        }
        public GuestsViewModel()
        {
            Currentpage = null;
            LoadGuest();
        }

        public void LoadGuest()
        {
            Guest.Clear();

            DataTable dataTable = DataBaseService.Instance.ExecuteQuery("SELECT id_guest, name, lname,mname,birthday,log from users left join roles on users.id_role=roles.id_role WHERE roles.role like 'guest'");
            foreach (DataRow item in dataTable.Rows)
            {
                Guest.Add(new usersModel
                {
                    Id = Convert.ToInt32(item["id_guest"]),
                    Name = item["name"].ToString(),
                    Lname = item["lname"].ToString(),
                    Mname = item["mname"].ToString(),
                    Birthday = Convert.ToDateTime(item["birthday"]),
                    log = item["log"].ToString()



                });
            }


        }
        private AddGuestViewModel addGuest;
     
        [RelayCommand]
        public void AddGuest()
        {

            if (IsVis == "Visibly")
            {
                var addG = new AddGuestPage();
                addGuest = addG.DataContext as AddGuestViewModel;
                Currentpage = addG;
                IsVis = Togle(IsVis);
                IsVisBack = Togle(IsVisBack);

            }
            else 
            {
                if(addGuest != null)
                {
                    if (addGuest.Isnull())
                    {
                        MessageBox.Show("Заполните поля");
                        return;

                    }
                }
                addGuest.AddUser();
               
                LoadGuest();
                IsVis = Togle(IsVis);
                Currentpage = null;
                addGuest = null;
                IsVisBack = Togle(IsVisBack);

            }
           
            

        }
        [RelayCommand]
        public void DeleteGuest(usersModel param)
        {

            DataBaseService.Instance.ExecuteQuery($"DELETE FROM users WHERE id_guest={param.Id}");
            LoadGuest();
        }
       
        [RelayCommand]
        public void Back()
        {
            IsVis = Togle(IsVis);
            Currentpage = null;
            addGuest = null;
            IsVisEdit = "Hidden";
            IsVisGuestAdd = "Visible";
            IsVisBack = Togle(IsVisBack);
        }
            private EditGuestViewModel editVm;
        [RelayCommand]
        public void EditGuest(usersModel param)
        {
            if (IsVis == "Visibly")
            {

                 editVm = new EditGuestViewModel
                {
                    Id  = param.Id,
                     Name = param.Name,
                    Lname = param.Lname,
                    Mname = param.Mname,
                    Birthday = param.Birthday,
                    Log = param.log

                };
                
                var editG = new EditGuest();
                editG.DataContext = editVm;
                Currentpage = editG;
                IsVis = Togle(IsVis);
                IsVisEdit = Togle(IsVisEdit);
                IsVisGuestAdd = Togle(IsVisGuestAdd);
                IsVisBack = Togle(IsVisBack);
            }
            else
            {


                editVm.Update(param);
                LoadGuest();
                IsVis = Togle(IsVis);
                Currentpage = null;
                IsVisEdit = Togle(IsVisEdit);
                IsVisGuestAdd = "Visible";
                IsVisBack = Togle(IsVisBack);

            }



        }
    }
}
