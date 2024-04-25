using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;
using Microsoft.EntityFrameworkCore;

namespace Ficbook.ViewModels;

public partial class StoryInfoViewModel : ObservableObject
{
    [ObservableProperty] private Story _selectedStory;
    [ObservableProperty] private Genre _genre;
    [ObservableProperty] private Show _show;
    [ObservableProperty] private Writer _writer;
    [ObservableProperty] private List<Comment> _comments;
    [ObservableProperty] private string _commentContent;
    [ObservableProperty] private bool _removeButtonStatus;
    
    private ApplicationDbContext _dbContext;

    public StoryInfoViewModel(Story selectedStory, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        SelectedStory = selectedStory;
        Genre = _dbContext.Genres.Find(SelectedStory.GenreId);
        Show = _dbContext.Shows.Find(SelectedStory.ShowId);
        Writer = _dbContext.Writers.Find(SelectedStory.WriterId);
        Comments = _dbContext.Comments.Where(story => story.StoryId == SelectedStory.Id).ToList();

        RemoveButtonStatus = SelectedStory.WriterId == Writer.Id;
    }
    
    public async void RemoveStory()
    {
        foreach (var comment in Comments)
        {
            _dbContext.Comments.Remove(comment);
        }

        _dbContext.Remove(SelectedStory);
        await _dbContext.SaveChangesAsync();
    }

    [RelayCommand]
    private async void AddComment()
    {
        await _dbContext.AddAsync(new Comment
        {
            Content = CommentContent,
            StoryId = SelectedStory.Id,
            WriterId = Writer.Id
        });

        await _dbContext.SaveChangesAsync();

        Comments = _dbContext.Comments.Where(story => story.StoryId == SelectedStory.Id).ToList();
    }

    [RelayCommand]
    private async void AddStoryToFavourite()
    {
        await _dbContext.StoriesToReadLater.AddAsync(new StoriesToReadLater
        {
            StoryId = SelectedStory.Id,
            WriterId = Writer.Id
        });
        
        await _dbContext.SaveChangesAsync();
    }
}