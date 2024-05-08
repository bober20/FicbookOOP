using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

// [QueryProperty("Writer", "Writer")]
public partial class WriterProfileViewModel : ObservableObject
{
    [ObservableProperty]
    private Writer _writer;
    
    [ObservableProperty] private bool _isRefreshing;

    public WriterProfileViewModel(ApplicationDbContext dbContext)
    {
        
    }

    [RelayCommand]
    private void GetWriterInfo()
    {
        Writer = App.UserInfo;
    }
    
    [RelayCommand]
    private async void LogOut()
    {
        if (Preferences.ContainsKey(nameof(App.UserInfo)))
        {
            Preferences.Remove(nameof(App.UserInfo));
        }
        
        //var t = Shell.Current.Tab
        
        //Shell.Current.CurrentPage.Navigation.RemovePage(Shell.Current);
        await Shell.Current.GoToAsync($"//LoginPage");
    }

    // [RelayCommand]
    // private void DeleteAccount()
    // {
    //     
    // }
    
    // [RelayCommand]
    // private void Refresh()
    // {
    //     IsRefreshing = true;
    //     
    //     PublishedStories = _dbContext.Stories.Where(story => story.WriterId == Writer.Id).ToList();
    //     
    //     IsRefreshing = false;
    // }
}