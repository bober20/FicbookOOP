using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class RegistrationViewModel(ApplicationDbContext dbContext) : ObservableObject
{
    [ObservableProperty] private string _username;
    [ObservableProperty] private string _password;
    [ObservableProperty] private string _passwordConfirmation;
    [ObservableProperty] private List<Writer> _writers;
    [ObservableProperty] private int _age;
    [ObservableProperty] private Writer _writer;
    
    private readonly ApplicationDbContext _dbContext = dbContext;

    [RelayCommand]
    public async Task SignUp()
    {
        if (!string.IsNullOrWhiteSpace(Username) && 
            !string.IsNullOrWhiteSpace(Password) && 
            !string.IsNullOrWhiteSpace(PasswordConfirmation) && 
            !(Age == 0))
        {
            if (Writers.Select(writer => writer.Name).Contains(Username) || Username == "Admin")
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
                Age = Age,
                IsBanned = false,
                Password = Password,
            });

            await _dbContext.SaveChangesAsync();
            
            await Shell.Current.GoToAsync($"//LoginPage");
            
            Username = "";
            Password = "";
            PasswordConfirmation = "";
            Age = 0;
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Authentication", "Fields are empty.", "Ok");
        }
    }

    [RelayCommand]
    public async Task GoToLoginPage()
    {
        await Shell.Current.GoToAsync($"//LoginPage");
    }

    [RelayCommand]
    private async Task GetRequiredInfo()
    {
        await MainThread.InvokeOnMainThreadAsync(() => { Writers = _dbContext.Writers.ToList(); });

        Username = "";
        Password = "";
        PasswordConfirmation = "";
        Age = 0;
    }
}