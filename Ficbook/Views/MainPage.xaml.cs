using Ficbook.Services;
using Ficbook.ViewModels;
using Ficbook.ModelsEF;

namespace Ficbook.Views;

public partial class MainPage : ContentPage
{
	private MainViewModel _mainViewModel;
	
	public MainPage(MainViewModel mainViewModel)
	{
		BindingContext = _mainViewModel = mainViewModel;
		
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
	
	private async void GenreSelected(object sender, SelectionChangedEventArgs e)
	{
		// var collectionView = sender as CollectionView;
		//
		// if (collectionView?.SelectedItem is null) return;
		// Genre? selectedGenre = collectionView.SelectedItem as Genre;
		//
		// collectionView.SelectedItem = null;
		//
		// await Navigation.PushAsync(new StoryInfoPage(selectedStory));
	}
		
	private void SearchBarTextChanged(object? sender, TextChangedEventArgs e)
	{
		_mainViewModel.Search();
	}

	// private void StorySelected(object? sender, SelectionChangedEventArgs e)
	// {
	// 	throw new NotImplementedException();
	// }
}


