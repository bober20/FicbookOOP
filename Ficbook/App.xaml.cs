using Ficbook.ModelsEF;
using Newtonsoft.Json;

namespace Ficbook;

public partial class App : Application
{
	public static Writer UserInfo;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		if (Preferences.ContainsKey("User"))
		{
			UserInfo = JsonConvert.DeserializeObject<ModelsEF.Writer>(Preferences.Get("User", null));
		}
		
		// Preferences.Set(nameof(UserInfo), null);
	}
	
	// protected override void OnResume()
	// {
	// 	MessagingCenter.Send(this, "ShareLocation");
	// }
}

