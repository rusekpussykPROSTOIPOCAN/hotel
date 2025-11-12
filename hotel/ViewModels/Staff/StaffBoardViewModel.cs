using CommunityToolkit.Mvvm.ComponentModel;
using hotel.Views.Staff;
namespace hotel.ViewModels.Staff
{
    public partial class StaffBoardViewModel:ObservableObject
    {
        [ObservableProperty]
        private object _current;

        public StaffBoardViewModel()
        {
            Current = new Tasks();
        }


    }
}
