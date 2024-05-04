using Ficbook.ModelsEF;
using Ficbook.Services;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class WriterStoriesPage : ContentPage
{
	private WriterStoriesViewModel _writerStoriesViewModel;
	
	public WriterStoriesPage(WriterStoriesViewModel writerStoriesViewModel)
	{
		BindingContext = _writerStoriesViewModel = writerStoriesViewModel;
		
		InitializeComponent();
	}

	// private async void StorySelected(object sender, SelectionChangedEventArgs e)
	// {
	// 	var collectionView = sender as CollectionView;
	//
	// 	if (collectionView?.SelectedItem is null) return;
	// 	Story? selectedStory = collectionView.SelectedItem as Story;
	//
	// 	collectionView.SelectedItem = null;
	//
	// 	await Navigation.PushAsync(new StoryInfoPage(selectedStory));
	// }
	//
	// private async void AddStoryButtonClicked(object sender, EventArgs e)
	// {
	// 	await Navigation.PushAsync(new AddStoryPage(new AddStoryViewModel(_writerStoriesViewModel.GetWriter(), new ApplicationDbContext())));
	// }
}
