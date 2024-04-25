using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class NotificationsViewModel : ObservableObject
{
    [ObservableProperty] private List<Notification> _notifications;
    [ObservableProperty] private bool _isRefreshing;
    [ObservableProperty] private bool _isNotificationsEmpty = true;

    private Writer _writer;

    private ApplicationDbContext _dbContext;

    public NotificationsViewModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _writer = App.UserInfo;
        _notifications = _dbContext.Notifications.Where(notification => notification.WriterId == _writer.Id).ToList();

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
        
        IsRefreshing = false;
        
        if (Notifications.Count > 0)
        {
            IsNotificationsEmpty = false;
            
            return;
        }
        
        IsNotificationsEmpty = true;
    }
}