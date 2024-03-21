using Ficbook.Services;
using Microsoft.Extensions.Logging;
using Ficbook.ViewModels;
using Ficbook.Views;

namespace Ficbook;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<IDbServices, SQLiteService>();
		
		builder.Services.AddTransient<WriterStoriesPage>();
		builder.Services.AddTransient<WriterStoriesViewModel>();
		
		builder.Services.AddTransient<WriterProfilePage>();
		builder.Services.AddTransient<WriterProfileViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

