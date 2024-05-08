using Ficbook.ModelsEF;
using Ficbook.Services;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class WriterStoriesPage : ContentPage
{
	public WriterStoriesPage(WriterStoriesViewModel writerStoriesViewModel)
	{
		BindingContext = writerStoriesViewModel;
		
		InitializeComponent();
	}
}
