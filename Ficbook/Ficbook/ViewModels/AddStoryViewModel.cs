using CommunityToolkit.Mvvm.ComponentModel;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class AddStoryViewModel : ObservableObject
{
    [ObservableProperty] private string _title;
    [ObservableProperty] private string _content;
    [ObservableProperty] private Genre _genre;
    [ObservableProperty] private List<Genre> _genres;
    [ObservableProperty] private Writer _writer;

    private IDbServices _dbService = new SQLiteService();
    
    private ApplicationDbContext _dbContext;

    public AddStoryViewModel(Writer writer, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        Genres = _dbContext.Genres.ToList();
        Writer = writer;
    }
    
    public void AddStory()
    {
        Story newStory = new Story
        {
            Title = Title,
            Content = Content,
            WriterId = Writer.Id,
            ShowId = 1,
            GenreId = Genre.Id
        };

        _dbContext.Add(newStory);
        _dbContext.SaveChanges();
    }
}