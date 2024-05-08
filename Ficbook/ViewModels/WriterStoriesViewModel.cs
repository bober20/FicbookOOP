using System.Collections;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;
using Ficbook.Views;

namespace Ficbook.ViewModels;

[QueryProperty("Writer", "Writer")]
public partial class WriterStoriesViewModel : ObservableObject
{
    [ObservableProperty] private Writer _writer;
    [ObservableProperty] private List<Story> _publishedStories;
    [ObservableProperty] private bool _isRefreshing;

    private readonly ApplicationDbContext _dbContext;

    public WriterStoriesViewModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [RelayCommand]
    private void GetStoriesInfo()
    {
        Writer = App.UserInfo;
        PublishedStories = _dbContext.Stories.Where(story => story.WriterId == Writer.Id).ToList();
    }
    
    [RelayCommand]
    private void Refresh()
    {
        IsRefreshing = true;
        
        PublishedStories = _dbContext.Stories.Where(story => story.WriterId == Writer.Id).ToList();
        
        IsRefreshing = false;
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
    private async Task AddStory()
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>
        {
            {"Writer", Writer}
        };
        
        await Shell.Current.GoToAsync(nameof(AddStoryPage), parameters);
    }
}