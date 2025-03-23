using CommunityToolkit.Maui;
using DevExpress.Maui;
using FluentIcons.Maui;
using Microsoft.Extensions.Logging;
using ProjectManagerMobile.Utilities.Extensions;

namespace ProjectManagerMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.UseDevExpress()
			.UseDevExpressCollectionView()
			.UseFluentIcons()
			.RegisterServices()
			.RegisterViews()
			.RegisterViewModels()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                fonts.AddFont("SourceSans3-Regular.ttf", "SourceSansRegular");
                fonts.AddFont("SourceSans3-Bold.ttf", "SourceSansBold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
