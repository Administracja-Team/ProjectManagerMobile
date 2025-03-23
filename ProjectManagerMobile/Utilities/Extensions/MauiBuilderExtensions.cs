using ProjectManagerMobile.ViewModels;
using ProjectManagerMobile.ViewModels.Auth;
using ProjectManagerMobile.Views;
using ProjectManagerMobile.Views.Auth;

namespace ProjectManagerMobile.Utilities.Extensions
{
    public static class MauiBuilderExtensions
    {
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<AuthPage>();

            builder.Services.AddTransient<ProjectsListPage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<SettingsPage>();


            return builder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();

            builder.Services.AddTransient<ProjectsListViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();

            return builder;
        }
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            //builder.Services.AddTransient<MainPage>();

            return builder;
        }
    }
}
