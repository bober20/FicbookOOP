using Ficbook.ModelsEF;
using Ficbook.Services;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class StoryInfoPage : ContentPage
{
    public StoryInfoPage(StoryInfoViewModel storyInfoViewModel)
    {
        BindingContext = storyInfoViewModel;
        
        InitializeComponent();
    }
}