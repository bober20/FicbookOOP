using Ficbook.Services;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class MainPage : ContentPage
{
	private MainViewModel _mainViewModel;
	
	public MainPage()
	{
		_mainViewModel = new MainViewModel(new SQLiteService());
		
		InitializeComponent();
	}

	
}


