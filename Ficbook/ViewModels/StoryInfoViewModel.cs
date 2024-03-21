using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.Models;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class StoryInfoViewModel : ObservableObject
{
    [ObservableProperty] private Story _selectedStory;

    [ObservableProperty] private Genre _genre;

    [ObservableProperty] private Show _show;
    
    [ObservableProperty] private Writer _writer;

    [ObservableProperty] private List<Comment> _comments;

    [ObservableProperty] private string _commentContent;

    private IDbServices _dbService = new SQLiteService();

    public StoryInfoViewModel(Story selectedStory)
    {
        _selectedStory = selectedStory;

        Genre = _dbService.GetGenreById(SelectedStory.GenreId);
        Show = _dbService.GetShowById(SelectedStory.ShowId);
        Writer = _dbService.GetWriterById(SelectedStory.WriterId);
        Comments = _dbService.GetAllComments(SelectedStory.Id).ToList();
    }
    
    public void RemoveStory()
    {
        _dbService.RemoveCommentsByStoryId(SelectedStory.Id);
        _dbService.RemoveStory(SelectedStory.Id);
    }

    [RelayCommand]
    private void AddComment()
    {
        _dbService.AddComment(new Comment
        {
            Content = CommentContent,
            StoryId = SelectedStory.Id,
            WriterId = Writer.Id
        });
        
        Comments = _dbService.GetAllComments(SelectedStory.Id).ToList();
    }

}