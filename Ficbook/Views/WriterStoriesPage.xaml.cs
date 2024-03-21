using Ficbook.Models;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class WriterStoriesPage : ContentPage
{
	public WriterStoriesPage(WriterStoriesViewModel writerStoriesViewModel)
	{
		InitializeComponent();
		
		BindingContext = writerStoriesViewModel;
	}

	private async void StorySelected(object sender, SelectionChangedEventArgs e)
	{
		var collectionView = sender as CollectionView;

		if (collectionView?.SelectedItem is null) return;
		Story selectedStory = collectionView.SelectedItem as Story;
	
		collectionView.SelectedItem = null;
	
		await Navigation.PushAsync(new StoryInfoPage(selectedStory));
	}
}
