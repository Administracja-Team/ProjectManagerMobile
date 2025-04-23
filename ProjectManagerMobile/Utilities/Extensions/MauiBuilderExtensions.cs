using AiForms.Settings;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using ProjectManagerMobile.ViewModels;
using ProjectManagerMobile.ViewModels.Auth;
using ProjectManagerMobile.Views;
using ProjectManagerMobile.Views.Auth;
using Refit;

namespace ProjectManagerMobile.Utilities.Extensions
{
    public static class MauiBuilderExtensions
    {
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<AuthPage>();

            builder.Services.AddTransient<ProjectsListPage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<ProfileEditPage>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<CreateNewProjectPage>();
            builder.Services.AddTransient<ProjectPage>();
            builder.Services.AddTransient<CreateSprintPage>();
            builder.Services.AddTransient<CreateTaskPage>();



            return builder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();

            builder.Services.AddTransient<ProjectsListViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<ProfileEditViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();
            builder.Services.AddTransient<CreateNewProjectViewModel>();
            builder.Services.AddTransient<ProjectViewModel>();
            builder.Services.AddTransient<CreateSprintViewModel>();
            builder.Services.AddTransient<CreateTaskViewModel>();


            return builder;
        }
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<TokenStorageService>();

            builder.Services
            .AddRefitClient<IAuthApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://138.201.187.238:8888"));

            builder.Services
                .AddRefitClient<IUserApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://138.201.187.238:8888"));


            builder.Services
                .AddRefitClient<IProjectApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://138.201.187.238:8888"));



            return builder;
        }
    }
}
