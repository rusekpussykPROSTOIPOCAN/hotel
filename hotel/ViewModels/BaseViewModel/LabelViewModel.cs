using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;



namespace hotel.ViewModels.BaseViewModel
{
    public partial class LabelViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _text;

        [ObservableProperty]
        private Visibility _placeholderVisibility = Visibility.Visible;

        
        [RelayCommand]
        private void ClearText()
        {
            Text = string.Empty;
        }

    
        [RelayCommand]
        private void TextChanged(string newText)
        {
            PlaceholderVisibility = string.IsNullOrEmpty(newText) ?
                Visibility.Visible : Visibility.Hidden;
        }
    }
}
