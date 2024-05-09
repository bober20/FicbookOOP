using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.Services;
using Ficbook.ModelsEF;
using Ficbook.Views;

namespace Ficbook.ViewModels;

public partial class MainViewModel(ApplicationDbContext dbContext) : ObservableObject
{
    [ObservableProperty] private List<Genre> _genres;
    [ObservableProperty] private List<Story> _allWritersStories;
    [ObservableProperty] private List<Story> _favouriteStories;
    [ObservableProperty] private List<Writer> _writers;
    [ObservableProperty] private bool _isRefreshing;
    [ObservableProperty] private string _searchText;
    [ObservableProperty] private bool _favouriteStoriesStatus;
    [ObservableProperty] private Writer _writer;
    [ObservableProperty] private List<Show> _shows;
    
    private readonly ApplicationDbContext _dbContext = dbContext;
    
    [RelayCommand]
    private void GetAllRequiredInfo()
    {
        Genres = _dbContext.Genres.ToList();
        Writers = _dbContext.Writers.ToList();
        Shows = _dbContext.Shows.ToList();
        Writer = App.UserInfo;

        UpdateStoriesCollections();
    }

    private void UpdateStoriesCollections()
    {
        GetFavouriteStories();
        GetAllStories();
        
        FavouriteStoriesStatus = FavouriteStories.Count != 0;
    }
    
    private void GetFavouriteStories()
    {
        var storiesIds = _dbContext.StoriesToReadLater
            .Where(item => item.WriterId == Writer.Id)
            .Select(item => item.StoryId).ToList();
        
        FavouriteStories = _dbContext.Stories.Where(story => storiesIds.Contains(story.Id)).ToList();
    }

    [RelayCommand]
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
    private void Search()
    {
        UpdateStoriesCollections();
        
        AllWritersStories = AllWritersStories.Where(story => story.Title.Contains(SearchText)).ToList();
        FavouriteStories = FavouriteStories.Where(story => story.Title.Contains(SearchText)).ToList();
    }
    
    [RelayCommand]
    private async Task StorySelected(Story story)
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "Story", story }
        };
        
        await Shell.Current.GoToAsync(nameof(StoryInfoPage), parameters);
    }

    [RelayCommand]
    private void GetStoriesByGenre(Genre genre)
    {
        UpdateStoriesCollections();
        
        AllWritersStories = AllWritersStories.Where(story => story.GenreId == genre.Id).ToList();
        FavouriteStories = FavouriteStories.Where(story => story.GenreId == genre.Id).ToList();
    }
    
    [RelayCommand]
    private void GetStoriesByShow(Show show)
    {
        UpdateStoriesCollections();
        
        AllWritersStories = AllWritersStories.Where(story => story.ShowId == show.Id).ToList();
        FavouriteStories = FavouriteStories.Where(story => story.ShowId == show.Id).ToList();
    }
    
    [RelayCommand]
    private void GetStoriesByWriter(Writer writer)
    {
        UpdateStoriesCollections();
        
        AllWritersStories = AllWritersStories.Where(story => story.WriterId == writer.Id).ToList();
        FavouriteStories = FavouriteStories.Where(story => story.WriterId == writer.Id).ToList();
    }
}