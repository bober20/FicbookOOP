using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;
using Microsoft.EntityFrameworkCore;

namespace Ficbook.ViewModels;

[QueryProperty("Story", "Story")]
public partial class StoryInfoViewModel(ApplicationDbContext dbContext) : ObservableObject
{
    [ObservableProperty] private Story _story;
    [ObservableProperty] private Genre _genre;
    [ObservableProperty] private Show _show;
    [ObservableProperty] private Writer _writer;
    [ObservableProperty] private List<Comment> _comments;
    [ObservableProperty] private string _commentContent;
    [ObservableProperty] private bool _removeButtonStatus;

    [RelayCommand]
    private async Task RemoveStory()
    {
        foreach (var comment in Comments)
        {
            dbContext.Comments.Remove(comment);
        }

        var favouriteStories = dbContext.StoriesToReadLater
            .Where(story => story.StoryId == Story.Id);

        foreach (var fs in favouriteStories)
        {
            dbContext.Remove(fs);
        }

        dbContext.Remove(Story);
        await dbContext.SaveChangesAsync();

        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task AddComment()
    {
        await dbContext.AddAsync(new Comment
        {
            Content = CommentContent,
            StoryId = Story.Id,
            WriterId = Writer.Id
        });

        await dbContext.SaveChangesAsync();

        Comments = dbContext.Comments.Where(story => story.StoryId == Story.Id).ToList();
    }

    [RelayCommand]
    private async Task AddStoryToFavourite()
    {
        await dbContext.StoriesToReadLater.AddAsync(new StoriesToReadLater
        {
            StoryId = Story.Id,
            WriterId = App.UserInfo.Id
        });
        
        await dbContext.SaveChangesAsync();
        
        await App.Current.MainPage.DisplayAlert("Favourite story", "Story was added to favourite.", "Ok");
    }

    [RelayCommand]
    private async Task GetAllRequiredInformation()
    {
        Genre = (await dbContext.Genres.FindAsync(Story.GenreId))!;
        Show = (await dbContext.Shows.FindAsync(Story.ShowId))!;
        Writer = (await dbContext.Writers.FindAsync(Story.WriterId))!;
        Comments = dbContext.Comments.Where(story => story.StoryId == Story.Id).ToList();

        RemoveButtonStatus = Story.WriterId == App.UserInfo.Id;
    }
}