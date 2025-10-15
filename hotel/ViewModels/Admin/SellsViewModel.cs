using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.ViewModels.Admin
{
    public partial class SellsViewModel:ObservableObject
    {
        [ObservableProperty]
        private bool _isReadOnly = true;
        [RelayCommand]
        public void Read()
        {
            IsReadOnly = !IsReadOnly;
        }
    }
}
