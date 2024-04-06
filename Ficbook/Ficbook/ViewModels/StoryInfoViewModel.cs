using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;
using Microsoft.EntityFrameworkCore;

namespace Ficbook.ViewModels;

public partial class StoryInfoViewModel : ObservableObject
{
    [ObservableProperty] 
    private Story _selectedStory;

    [ObservableProperty] 
    private Genre _genre;
    
    [ObservableProperty]
    private Show _show;
    
    [ObservableProperty] 
    private Writer _writer;

    [ObservableProperty] 
    private List<Comment> _comments;

    [ObservableProperty] 
    private string _commentContent;

    //private IDbServices _dbService = new SQLiteService();
    
    private ApplicationDbContext _dbContext;

    public StoryInfoViewModel(Story selectedStory, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        
        SelectedStory = selectedStory;
        
        Genre = _dbContext.Genres.Find(SelectedStory.GenreId);
        Show = _dbContext.Shows.Find(SelectedStory.ShowId);
        Writer = _dbContext.Writers.Find(SelectedStory.WriterId);
        Comments = _dbContext.Comments.Where(genre => genre.StoryId == SelectedStory.Id).ToList();

        // Genre = SelectedStory.Genre;
        // Show = SelectedStory.Show;
        // Writer = SelectedStory.Writer;
        // Comments = SelectedStory.Comments;

        // Genre = _dbService.GetGenreById(SelectedStory.GenreId);
        // Show = _dbService.GetShowById(SelectedStory.ShowId);
        // Writer = _dbService.GetWriterById(SelectedStory.WriterId);
        // Comments = _dbService.GetAllComments(SelectedStory.Id).ToList();
    }
    
    public void RemoveStory()
    {
        foreach (var comment in Comments)
        {
            _dbContext.Comments.Remove(comment);
        }

        _dbContext.Remove(SelectedStory);
        _dbContext.SaveChanges();
    }

    [RelayCommand]
    private void AddComment()
    {
        _dbContext.Add(new Comment
        {
            Content = CommentContent,
            StoryId = SelectedStory.Id,
            WriterId = Writer.Id
        });

        _dbContext.SaveChanges();

        Comments = _dbContext.Comments.ToList();
    }

}