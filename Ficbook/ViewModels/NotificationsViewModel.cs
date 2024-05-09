using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class NotificationsViewModel(ApplicationDbContext dbContext) : ObservableObject
{
    [ObservableProperty] private List<Notification> _notifications;
    [ObservableProperty] private bool _isRefreshing;
    [ObservableProperty] private bool _isNotificationsEmpty = true;
    
    private Writer _writer;

    private readonly ApplicationDbContext _dbContext = dbContext;

    [RelayCommand]
    private void GetNotificationsInfo()
    {
        _writer = App.UserInfo;
        Notifications = _dbContext.Notifications.Where(notification => notification.WriterId == _writer.Id).ToList();

        if (Notifications.Count > 0)
        {
            IsNotificationsEmpty = false;
        }
    }
    
    [RelayCommand]
    private void Refresh()
    {
        IsRefreshing = true;
        Notifications = _dbContext.Notifications.Where(notification => notification.WriterId == _writer.Id).ToList();
        
        if (Notifications.Count > 0)
        {
            IsNotificationsEmpty = false;
            
            return;
        }
        
        IsNotificationsEmpty = true;
        IsRefreshing = false;
    }
}