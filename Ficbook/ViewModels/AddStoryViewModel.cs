using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.Models;
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

    public AddStoryViewModel(Writer writer)
    {
        _genres = _dbService.GetAllGenres().ToList();
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
        
        _dbService.AddStory(newStory);
    }
}