using CommunityToolkit.Maui;
using Ficbook.Services;
using Microsoft.Extensions.Logging;
using Ficbook.ViewModels;
using Ficbook.Views;
using Microsoft.EntityFrameworkCore;

namespace Ficbook;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddDbContext<ApplicationDbContext>();
		
		builder.Services.AddTransient<WriterStoriesPage>();
		builder.Services.AddTransient<WriterStoriesViewModel>();
		
		builder.Services.AddTransient<WriterProfilePage>();
		builder.Services.AddTransient<WriterProfileViewModel>();
		
		builder.Services.AddTransient<AddStoryPage>();
		builder.Services.AddTransient<AddStoryViewModel>();
		
		builder.Services.AddTransient<AdminPage>();
		builder.Services.AddTransient<AdminViewModel>();
		
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<LoginViewModel>();
		
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<MainViewModel>();
		
		builder.Services.AddTransient<StoryInfoPage>();
		builder.Services.AddTransient<StoryInfoViewModel>();
		
		builder.Services.AddTransient<NotificationsPage>();
		builder.Services.AddTransient<NotificationsViewModel>();

		builder.Services.AddTransient<RegistrationPage>();
		builder.Services.AddTransient<RegistrationViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

