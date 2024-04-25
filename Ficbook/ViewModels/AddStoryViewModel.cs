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
    
    private ApplicationDbContext _dbContext;

    public AddStoryViewModel(Writer writer, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        Genres = _dbContext.Genres.ToList();
        Writer = writer;
        Genre = Genres[0];
    }
    
    public async void AddStory()
    {
        if (!string.IsNullOrWhiteSpace(Title) ||
            !string.IsNullOrWhiteSpace(Content))
        {
            Story newStory = new Story
            {
                Title = Title,
                Content = Content,
                WriterId = Writer.Id,
                ShowId = 1,
                GenreId = Genre.Id
            };

            await _dbContext.AddAsync(newStory);
            await _dbContext.SaveChangesAsync();
        }
        
        await App.Current.MainPage.DisplayAlert("Story wasn't added",
            "Fields are empty. Try again.", "Ok");
    }
}