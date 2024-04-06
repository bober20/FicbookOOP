using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Ficbook.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string _username;
    
    [ObservableProperty]
    private string _password;

    [RelayCommand]
    public void Login()
    {
        Username = "Hi";
    }
}