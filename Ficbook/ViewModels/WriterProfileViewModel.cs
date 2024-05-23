using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class WriterProfileViewModel(ApplicationDbContext dbContext) : ObservableObject
{
    [ObservableProperty] private Writer _writer;
    [ObservableProperty] private List<Story> _writerStories;

    [RelayCommand]
    private async Task GetWriterInfo()
    {
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Writer = App.UserInfo;
            WriterStories = dbContext.Stories.Where(story => story.WriterId == Writer.Id).ToList();
        });
    }
    
    [RelayCommand]
    private async void LogOut()
    {
        if (Preferences.ContainsKey("User"))
        {
            Preferences.Remove("User");
        }
        
        await Shell.Current.GoToAsync($"//LoginPage");
    }
}