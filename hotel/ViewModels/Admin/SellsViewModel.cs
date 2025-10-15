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
          

        }
        [RelayCommand]
        public void delete(object param)
        {
            
        }
        [RelayCommand]
        public void edit(object param)
        {
            Currentpage = new EditSells();
            IsVis = Togle(IsVis);
            IsVisAdd = Togle(IsVisAdd);
           
        }
    }
}
