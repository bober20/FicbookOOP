using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;
using Newtonsoft.Json;

namespace Ficbook.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string _username;
    
    [ObservableProperty]
    private string _password;

    private List<Writer> _writers;
    private Admin _admin;
    private ApplicationDbContext _dbContext;

    public LoginViewModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _writers = _dbContext.Writers.ToList();
        _admin = dbContext.Admin.First();
    }

    [RelayCommand]
    private async void Login()
    {
        _writers = _dbContext.Writers.ToList();
        
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
                    Preferences.Set(nameof(App.UserInfo), userDetails);
                    App.UserInfo = writer;
                
                    await Shell.Current.GoToAsync($"//AuthorPage");
        
                    return;
                }
            }
        }
        
        if (_admin.Name == Username && _admin.Password == Password)
        {
            await Shell.Current.GoToAsync($"//AdminPage");

            return;
        }
        
        await App.Current.MainPage.DisplayAlert("Authentication",
                "Invalid username or password.", "Ok");
            
    }
    
    [RelayCommand]
    private async void GoToRegistrationPage()
    {
        await Shell.Current.GoToAsync($"//RegistrationPage");
    }
}