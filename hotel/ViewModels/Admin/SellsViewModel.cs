using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hotel.Views.Admin.SellsAct;
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
        private object _currentpage;

        [ObservableProperty]
        private bool _isReadOnly = true;

        [ObservableProperty]
        private string _isVis = "Visibly";
        [ObservableProperty]
        private string _isVisAdd = "Visibly";
        [ObservableProperty]
        private string _isVisDelete = "Visibly";
        [ObservableProperty]
        private string _isVisEdit = "Visibly";

        public string Togle(string a)
        {
            a = a == "Visibly" ? "Hidden" : "Visibly";
            return a;
        }
        public SellsViewModel()
        {
            Currentpage = null;
        }

        [RelayCommand]
        public void add()
        {
            Currentpage = new AddSell();
            IsVis = Togle(IsVis);
          IsVisDelete = Togle(IsVisDelete);
            IsVisEdit = Togle(IsVisEdit);

        }
        [RelayCommand]
        public void delete()
        {
            IsReadOnly = !IsReadOnly;
            IsVis = "Visibly";
            IsVisEdit = Togle(IsVisEdit);
            IsVisAdd = Togle(IsVisAdd);
        }
        [RelayCommand]
        public void edit()
        {
            Currentpage = new EditSells();
            IsVis = Togle(IsVis);
            IsVisAdd = Togle(IsVisAdd);
            IsVisDelete = Togle(IsVisDelete);
        }
    }
}
