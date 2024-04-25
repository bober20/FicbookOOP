using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.Services;
using Ficbook.ModelsEF;

namespace Ficbook.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private List<Genre> _genres;
    [ObservableProperty] private List<Story> _allWritersStories;
    [ObservableProperty] private List<Story> _favouriteStories;
    [ObservableProperty] private List<Writer> _writers;
    [ObservableProperty] private bool _isRefreshing;
    [ObservableProperty] private string _searchText;
    [ObservableProperty] private bool _favouriteStoriesStatus;
    
    private ApplicationDbContext _dbContext;
    
    public MainViewModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        Genres = _dbContext.Genres.ToList();
        Writers = _dbContext.Writers.ToList();
        
        GetFavouriteStories();
        GetAllStories();
        
        FavouriteStoriesStatus = FavouriteStories.Count != 0;
    }

    private void GetFavouriteStories()
    {
        var storiesIds = _dbContext.StoriesToReadLater
            .Where(item => item.WriterId == App.UserInfo.Id)
            .Select(item => item.StoryId).ToList();
        FavouriteStories = _dbContext.Stories.Where(story => storiesIds.Contains(story.Id)).ToList();
    }

    private void GetAllStories()
    {
        var activeWritersIds = _dbContext.Writers.Where(writer => writer.IsBanned == false)
            .Select(writer => writer.Id).ToList();
        AllWritersStories = _dbContext.Stories.Where(story => activeWritersIds.Contains(story.WriterId)).ToList();
    }
    
    [RelayCommand]
    private void Refresh()
    {
        IsRefreshing = true;
        
        GetFavouriteStories();
        GetAllStories();
        
        Writers = _dbContext.Writers.Where(writer => writer.IsBanned == false).ToList();
        FavouriteStoriesStatus = FavouriteStories.Count != 0;
        
        IsRefreshing = false;
    }

    [RelayCommand]
    public void Search()
    {
        GetAllStories();
        GetFavouriteStories();
        
        AllWritersStories = AllWritersStories.Where(story => story.Title.Contains(SearchText)).ToList();
        FavouriteStories = FavouriteStories.Where(story => story.Title.Contains(SearchText)).ToList();
    }
}