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

    //private IDbServices _dbService;

    private ApplicationDbContext _dbContext;

    public WriterStoriesViewModel(Writer writer, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        Writer = writer;
        //_dbService = new SQLiteService();

        //PublishedStories = _dbContext.Stories.Where(story => story.Writer == Writer).ToList();
        PublishedStories = _dbContext.Stories.Where(story => story.WriterId == Writer.Id).ToList();
    }
}