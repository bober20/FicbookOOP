using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class AddStoryPage : ContentPage
{
    private AddStoryViewModel _addStoryViewModel;
    
    public AddStoryPage(AddStoryViewModel addStoryViewModel)
    {
        BindingContext = _addStoryViewModel = addStoryViewModel;
        
        InitializeComponent();
    }

    private void AddStoryButtonClicked(object sender, EventArgs e)
    {
        _addStoryViewModel.AddStory();

        Navigation.PopAsync();
    }
}