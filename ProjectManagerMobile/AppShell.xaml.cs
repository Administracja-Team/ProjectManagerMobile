using ProjectManagerMobile.Views;
using ProjectManagerMobile.Views.Auth;

namespace ProjectManagerMobile
{
    public partial class AppShell : Shell
    {
        private AppShellViewModel _appShellVM;
        public AppShell(AppShellViewModel appShellVM)
        {
            InitializeComponent();
            RegisterRoutes();

            BindingContext = appShellVM;
            _appShellVM = appShellVM;
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(ProfileEditPage), typeof(ProfileEditPage));
            Routing.RegisterRoute(nameof(CreateNewProjectPage), typeof(CreateNewProjectPage));
            Routing.RegisterRoute(nameof(ProjectPage), typeof(ProjectPage));
            Routing.RegisterRoute(nameof(CreateSprintPage), typeof(CreateSprintPage));
            Routing.RegisterRoute(nameof(CreateTaskPage), typeof(CreateTaskPage));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _appShellVM.LoadDataAsync();
        }
    }
}
