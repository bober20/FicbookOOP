using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class AdminViewModel(ApplicationDbContext dbContext) : ObservableObject
{
    [ObservableProperty] private List<Writer> _writers;
    [ObservableProperty] private Writer _selectedWriter;
    [ObservableProperty] private string _notificationContent;
    [ObservableProperty] private string _searchText;
    [ObservableProperty] private string _newShowName;
    
    private readonly ApplicationDbContext _dbContext = dbContext;

    [RelayCommand]
    private async void BanWriter()
    {
        if (SelectedWriter.IsBanned)
        {
            await App.Current.MainPage.DisplayAlert("Writers list", "Writer is already banned.", "Ok");
            
            return;
        }

        if (string.IsNullOrWhiteSpace(NotificationContent))
        {
            await App.Current.MainPage.DisplayAlert("Writers list", "Notification content is empty.", "Ok");
            
            return;
        }

        SelectedWriter.IsBanned = true;

        await _dbContext.Notifications.AddAsync(new Notification
        {
            Content = NotificationContent,
            WriterId = SelectedWriter.Id,
            NotificationDate = DateTime.Now,
            IsProblemSolved = false
        });

        await _dbContext.SaveChangesAsync();
        await App.Current.MainPage.DisplayAlert("Writers list", "Writer was successfully banned.", "Ok");

        NotificationContent = "";
    }
    
    [RelayCommand]
    private async void UnbanWriter()
    {
        if (!SelectedWriter.IsBanned)
        {
            await App.Current.MainPage.DisplayAlert("Writers list", "Writer is unbanned.", "Ok");
            
            return;
        }

        SelectedWriter.IsBanned = false;
        var notifications = _dbContext.Notifications
            .Where(n => n.IsProblemSolved == false && n.WriterId == SelectedWriter.Id).ToList();

        if (notifications.Count != 0)
        {
            foreach (var n in notifications)
            {
                n.IsProblemSolved = true;
            }
            
            await _dbContext.SaveChangesAsync();
        }
        
        await _dbContext.SaveChangesAsync();
        
        await App.Current.MainPage.DisplayAlert("Writers list", "Writer was successfully unbanned.", "Ok");
    }

    [RelayCommand]
    private static async void LogOut()
    {
        await Shell.Current.GoToAsync($"//LoginPage");
    }
    
    [RelayCommand]
    private void Search()
    {
        Writers = _dbContext.Writers.Where(writer => writer.Name.Contains(SearchText)).ToList();
    }

    [RelayCommand]
    private async Task AddShow()
    {
        if (!string.IsNullOrWhiteSpace(NewShowName))
        {
            await _dbContext.AddAsync(new Show
            {
                Name = NewShowName
            });
            await _dbContext.SaveChangesAsync();
            
            await App.Current.MainPage.DisplayAlert("Shows", "Show was successfully added.", "Ok");
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Shows", "Show was not added. Fields are empty.", "Ok");
        }
        
        NewShowName = "";
    }

    [RelayCommand]
    private void GetRequiredInfo()
    {
        Writers = _dbContext.Writers.ToList();
        SelectedWriter = Writers[0];
    }
}