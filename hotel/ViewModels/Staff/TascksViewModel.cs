using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Views.Admin.TasksAct;

namespace hotel.ViewModels.Staff
{
    public partial class TascksViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _currentpage;
        [ObservableProperty]
        private string _isVis = "Visibly";
        [ObservableProperty]
        private string _isVischeckin = "Visibly";

        public TascksViewModel(){
            Currentpage = null;
        }

        public string Togle(string a)
        {
            a = a == "Visibly" ? "Hidden" : "Visibly";
            return a;
        }
        [RelayCommand]
        public void delete(object param)
        {

        }
        [RelayCommand]
        public void edit(object param)
        {
            IsVis = Togle(IsVis);
            Currentpage = new EditTaskPage();

        }
        [RelayCommand]
        public void create(object param)
        {
            IsVis = Togle(IsVis);
            Currentpage = new CreateTaskPage();

        }
    }
}
