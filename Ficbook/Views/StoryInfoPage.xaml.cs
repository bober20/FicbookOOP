using Ficbook.ModelsEF;
using Ficbook.Services;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class StoryInfoPage : ContentPage
{
    private StoryInfoViewModel _storyInfoViewModel;
    
    public StoryInfoPage(StoryInfoViewModel storyInfoViewModel)
    {
        BindingContext = storyInfoViewModel;
        
        InitializeComponent();
    }

    // private async void RemoveStoryButtonClicked(object sender, EventArgs e)
    // {
    //     _storyInfoViewModel.RemoveStory();
    //     var pagesStack = Shell.Current.Navigation.NavigationStack.ToArray();
    //     foreach (var item in pagesStack)
    //     {
    //         if (item is WriterStoriesPage)
    //         {
    //             Navigation.RemovePage(item);
    //         }
    //     }
    //     
    //     await Navigation.PopAsync();
    // }
}