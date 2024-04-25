using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class WriterStoriesViewModel : ObservableObject
{
    [ObservableProperty]
    private Writer _writer;
    
    [ObservableProperty]
    private List<Story> _publishedStories;

    [ObservableProperty] private bool _isRefreshing;

    private ApplicationDbContext _dbContext;

    public WriterStoriesViewModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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
    
    public Writer GetWriter()
    {
        return Writer;
    }
}