using Ficbook.Services;
using Ficbook.ViewModels;
using Ficbook.ModelsEF;

namespace Ficbook.Views;

public partial class MainPage : ContentPage
{
	private MainViewModel _mainViewModel;
	private readonly ApplicationDbContext _dbContext;
	
	public MainPage(ApplicationDbContext dbContext)
	{
		
		// _dbContext = new ApplicationDbContext();
		// //_mainViewModel = new MainViewModel(new SQLiteService());
		// InitializeComponent();
		//
		// _dbContext.Writers.Add(new Writer { Name = "Oleg"});
		// _dbContext.Writers.Add(new Writer { Name = "Masha"});
		//
		// _dbContext.SaveChanges();
		// var writers = _dbContext.Writers;
		//
		// Empl.ItemsSource = writers.ToList();
	}

	
}


