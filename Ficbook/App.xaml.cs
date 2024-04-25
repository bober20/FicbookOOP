using Ficbook.ModelsEF;

namespace Ficbook;

public partial class App : Application
{
	public static Writer UserInfo;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

