using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Views.Admin.ScheduleAct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.ViewModels
{
    public partial class ScheduleViewModel:ObservableObject
    {
        [ObservableProperty]
        private object _currentpage;

        [ObservableProperty]
        private bool _isReadOnly = true;

        [ObservableProperty]
        private string _isVis = "Visibly";
        [ObservableProperty]
        private string _isVisAdd = "Visibly";


        public string Togle(string a)
        {
            a = a == "Visibly" ? "Hidden" : "Visibly";
            return a;
        }
        public ScheduleViewModel()
        {
            Currentpage = null;
        }

        [RelayCommand]
        public void AddGuest()
        {
            Currentpage = new CreateSchedule();
            IsVis = Togle(IsVis);


        }
        [RelayCommand]
        public void DeleteGuest(object param)
        {
            //Удаление

        }
        [RelayCommand]
        public void EditGuest(object param)
        {

            Currentpage = new EditSchedulre();
            IsVis = Togle(IsVis);
            IsVisAdd = Togle(IsVisAdd);


        }
    }
}
