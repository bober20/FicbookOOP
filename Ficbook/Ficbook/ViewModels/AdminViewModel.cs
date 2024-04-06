using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class AdminViewModel : ObservableObject
{
    [ObservableProperty] private List<Writer> _writers;

    [ObservableProperty] private bool _isRefreshing;
    
    //private IDbServices _dbService = new SQLiteService();
    
    private ApplicationDbContext _dbContext;

    public AdminViewModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        
        GetWriters();
    }

    private void GetWriters()
    {
        Writers = _dbContext.Writers.Where(writer => !writer.IsAdmin && !writer.IsBanned).ToList();
        //Writers = new List<Writer>();

        // foreach (var writer in allWriters)
        // {
        //     if (!writer.IsAdmin && !writer.IsBanned)
        //     {
        //         Writers.Add(writer);
        //     }
        // }
        
        // //List<BannedWriters> bannedWriters = _dbService.GetAllBannedWriters().ToList();
        //
        // foreach (var item in bannedWriters)
        // {
        //     Writers.RemoveAll(writer => writer.Id == item.WriterId);
        // }
    }

    [RelayCommand]
    private void Refresh()
    {
        IsRefreshing = true;
        
        GetWriters();
        
        IsRefreshing = false;
    }
}