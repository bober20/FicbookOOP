using Ficbook.Views;

namespace Ficbook;

public partial class AppShell : Shell
{
	public AppShell()
	{
		Routing.RegisterRoute(nameof(StoryInfoPage), typeof(StoryInfoPage));
		Routing.RegisterRoute(nameof(AddStoryPage), typeof(AddStoryPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		
		InitializeComponent();
	}
}

