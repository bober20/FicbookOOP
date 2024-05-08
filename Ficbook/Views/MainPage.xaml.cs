using Ficbook.Services;
using Ficbook.ViewModels;
using Ficbook.ModelsEF;

namespace Ficbook.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel mainViewModel)
	{
		BindingContext = mainViewModel;
		
		InitializeComponent();
	}
		
	// private void SearchBarTextChanged(object? sender, TextChangedEventArgs e)
	// {
	// 	_mainViewModel.Search();
	// }
}


