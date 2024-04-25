using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class RegistrationViewModel : ObservableObject
{
    [ObservableProperty] private string _username;
    
    [ObservableProperty] private string _password;

    [ObservableProperty] private string _passwordConfirmation;
    
    [ObservableProperty] private List<Writer> _writers;
    private Admin _admin;
    private ApplicationDbContext _dbContext;
    
    public RegistrationViewModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        Writers = _dbContext.Writers.ToList();
        _admin = dbContext.Admin.First();
    }

    [RelayCommand]
    public async Task SignUp()
    {
        if (!string.IsNullOrWhiteSpace(Username) && 
            !string.IsNullOrWhiteSpace(Password) && 
            !string.IsNullOrWhiteSpace(PasswordConfirmation))
        {
            if (Writers.Select(writer => writer.Name).Contains(Username))
            {
                await App.Current.MainPage.DisplayAlert("Authentication",
                    "Choose other name, this one is taken.", "Ok");
            }

            if (Password.Length < 8)
            {
                await App.Current.MainPage.DisplayAlert("Authentication",
                    "Create password, which contains at least 8 characters.", "Ok");
            }

            if (Password != PasswordConfirmation)
            {
                await App.Current.MainPage.DisplayAlert("Authentication",
                    "Passwords doesn't match.", "Ok");
            }
            
            await _dbContext.AddAsync(new Writer
            {
                Name = Username,
                Age = 18,
                IsAdmin = false,
                IsBanned = false,
                Password = Password,
                MorePersonalInfo = "I am a writer."
            });

            await _dbContext.SaveChangesAsync();
            
            await Shell.Current.GoToAsync($"//LoginPage");
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Authentication",
                "Fields are empty.", "Ok");
        }
    }

    [RelayCommand]
    public async Task GoToLoginPage()
    {
        await Shell.Current.GoToAsync($"//LoginPage");
    }
}