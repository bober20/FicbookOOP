using CommunityToolkit.Mvvm.ComponentModel;
using Ficbook.Models;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private List<Genre> _genres;
    private IDbServices _dbServices;

    public MainViewModel(ApplicationDbContext dbContext)
    {
        //_dbServices = dbServices;
        
        //Genres = _dbServices.GetAllGenres().ToList();
    }

}