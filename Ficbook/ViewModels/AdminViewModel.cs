using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class AdminViewModel : ObservableObject
{
    [ObservableProperty] private List<Writer> _writers;
    [ObservableProperty] private Writer _selectedWriter;
    [ObservableProperty] private string _notificationContent;
    [ObservableProperty] private string _searchText;
    
    private ApplicationDbContext _dbContext;

    public AdminViewModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        
        Writers = _dbContext.Writers.Where(writer => writer.IsAdmin == false).ToList();
        SelectedWriter = Writers[0];
    }

    [RelayCommand]
    private async void BanWriter()
    {
        foreach (var writer in Writers)
        {
            if (writer.Id == SelectedWriter.Id)
            {
                writer.IsBanned = true;
                _dbContext.Writers.Update(writer);
                await _dbContext.Notifications.AddAsync(new Notification
                {
                    Content = NotificationContent,
                    WriterId = SelectedWriter.Id,
                    NotificationDate = DateTime.Now
                });
                
                await _dbContext.SaveChangesAsync();
                
                break;
            }
        }
    }
    
    [RelayCommand]
    private async void UnbanWriter()
    {
        foreach (var writer in Writers)
        {
            if (writer.Id == SelectedWriter.Id)
            {
                writer.IsBanned = false;
                
                _dbContext.Writers.Update(writer);
                await _dbContext.SaveChangesAsync();
                
                break;
            }
        }
    }

    [RelayCommand]
    private static async void LogOut()
    {
        await Shell.Current.GoToAsync($"//LoginPage");
    }
    
    public void Search()
    {
        Writers = _dbContext.Writers.Where(writer => writer.Name.Contains(SearchText)).ToList();
    }
}