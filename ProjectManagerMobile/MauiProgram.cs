using AiForms.Settings;
using CommunityToolkit.Maui;
using DevExpress.Maui;
using FluentIcons.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.BottomSheet.Hosting;
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
			.UseBottomSheet()
			.ConfigureMauiHandlers(handlers =>
			{
                handlers.AddSettingsViewHandler();
            })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                fonts.AddFont("SourceSans3-Regular.ttf", "SourceSansRegular");
                fonts.AddFont("SourceSans3-Bold.ttf", "SourceSansBold");
            });

        Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
		#if ANDROID
					handler.PlatformView.BackgroundTintList =
		Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
		#endif
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
