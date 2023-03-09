using Microsoft.Extensions.DependencyInjection;
using SPV_Project.ViewModel;

namespace SPV_Project;

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

		builder.Services.AddSingleton<FoodInformation>();
		builder.Services.AddSingleton<IzdelekViewModel>();
		builder.Services.AddSingleton<Profile>();
		builder.Services.AddSingleton<ProfileViewModel>();


        return builder.Build();
	}
}
