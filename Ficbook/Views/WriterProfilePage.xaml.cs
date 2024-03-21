using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class WriterProfilePage : ContentPage
{
    private WriterProfileViewModel _writerProfileViewModel;

    public WriterProfilePage(WriterProfileViewModel writerProfileViewModel)
    {
        InitializeComponent();

        BindingContext = _writerProfileViewModel = writerProfileViewModel;
    }

    private async void ShowStoriesButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WriterStoriesPage(new WriterStoriesViewModel(_writerProfileViewModel.GetWriter())));
    }

    private async void AddStoryButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddStoryPage(new AddStoryViewModel(_writerProfileViewModel.GetWriter())));
    }
}