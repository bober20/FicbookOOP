using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;
using Newtonsoft.Json;

namespace Ficbook.ViewModels;

public partial class LoginViewModel(ApplicationDbContext dbContext) : ObservableObject
{
    [ObservableProperty] private string _username;
    [ObservableProperty] private string _password;
    private List<Writer> _writers;
    private Admin _admin;
    private readonly ApplicationDbContext _dbContext = dbContext;

    [RelayCommand]
    private async void Login()
    {
        await MainThread.InvokeOnMainThreadAsync(() => { _writers = _dbContext.Writers.ToList(); });

        if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
        {
            foreach (var writer in _writers)
            {
                if (writer.Name == Username && writer.Password == Password)
                { 
                    if (Preferences.ContainsKey(nameof(App.UserInfo))) 
                    { 
                        Preferences.Remove(nameof(App.UserInfo));
                    }
        
                    string userDetails = JsonConvert.SerializeObject(writer);
                    Preferences.Set("User", userDetails);
                    App.UserInfo = writer;
                    
                    await Shell.Current.GoToAsync($"//AuthorPage");
                        
                    Username = "";
                    Password = "";
                    
                    return;
                }
            }
        }
        
        if (_admin.Name == Username && _admin.Password == Password)
        {
            await Shell.Current.GoToAsync($"//AdminPage");

            Username = "";
            Password = "";
            
            return;
        }
        
        await App.Current.MainPage.DisplayAlert("Authentication", "Invalid username or password.", "Ok");
    }
    
    [RelayCommand]
    private async Task GoToRegistrationPage()
    {
        await Shell.Current.GoToAsync($"//RegistrationPage");
    }
    
    [RelayCommand]
    private async Task GetRequiredInfo()
    {
        // if (App.UserInfo != null)
        // {
        //     await Shell.Current.GoToAsync($"//AuthorPage");
        // }
        
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            _writers = _dbContext.Writers.ToList();
            _admin = _dbContext.Admin.First();
        });
    }

    // [RelayCommand]
    // private async void Appearing()
    // {
    //     var user = App.UserInfo;
    //
    //     if (user != null)
    //     {
    //         await Shell.Current.GoToAsync($"//AuthorPage");
    //     }
    //     else
    //     {
    //         await Shell.Current.GoToAsync($"//LoginPage");
    //     }
    // }
}

