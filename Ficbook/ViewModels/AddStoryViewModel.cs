using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

[QueryProperty(nameof(Writer), nameof(Writer))]
public partial class AddStoryViewModel : ObservableObject
{
    [ObservableProperty] private string _title;
    [ObservableProperty] private string _content;
    [ObservableProperty] private string _imageUrl;
    [ObservableProperty] private Genre _genre;
    [ObservableProperty] private List<Genre> _genres;
    [ObservableProperty] private Writer _writer;
    
    private ApplicationDbContext _dbContext;

    public AddStoryViewModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [RelayCommand]
    private async Task AddStory()
    {
        if (!string.IsNullOrWhiteSpace(Title) ||
            !string.IsNullOrWhiteSpace(Content) ||
            !string.IsNullOrWhiteSpace(ImageUrl))
            
        {
            Story newStory = new Story
            {
                Title = Title,
                Content = Content,
                WriterId = Writer.Id,
                ShowId = 1,
                GenreId = Genre.Id,
                ImageSource = ImageUrl
            };

            await _dbContext.AddAsync(newStory);
            await _dbContext.SaveChangesAsync();
            
            await App.Current.MainPage.DisplayAlert("Story info", "Story was successfully added.", "Ok");
            await Shell.Current.Navigation.PopAsync();
            return;
        }
        
        await App.Current.MainPage.DisplayAlert("Story wasn't added", "Fields are empty. Try again.", "Ok");
    }

    [RelayCommand]
    private void GetAllRequiredInformation()
    {
        Genres = _dbContext.Genres.ToList();
        Genre = Genres[0];
    }
}