using CommunityToolkit.Mvvm.ComponentModel;

namespace hotel.ViewModels.Staff
{
    public partial class StaffBoardViewModel:ObservableObject
    {
        [ObservableProperty]
        private object _current;

        public StaffBoardViewModel()
        {
            Current = null;
        }


    }
}
