using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.Models;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class AdminViewModel : ObservableObject
{
    [ObservableProperty] private List<Writer> _writers;

    [ObservableProperty] private bool _isRefreshing;
    
    private IDbServices _dbService = new SQLiteService();

    public AdminViewModel()
    {
        GetWriters();
    }

    private void GetWriters()
    {
        Writers = _dbService.GetAllWriters().ToList();
        List<BannedWriters> bannedWriters = _dbService.GetAllBannedWriters().ToList();
        
        foreach (var item in bannedWriters)
        {
            Writers.RemoveAll(writer => writer.Id == item.WriterId);
        }
    }

    [RelayCommand]
    private void Refresh()
    {
        IsRefreshing = true;
        
        GetWriters();
        
        IsRefreshing = false;
    }
}