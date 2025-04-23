using ProjectManagerMobile.Views;
using ProjectManagerMobile.Views.Auth;

namespace ProjectManagerMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(ProfileEditPage), typeof(ProfileEditPage));
            Routing.RegisterRoute(nameof(CreateNewProjectPage), typeof(CreateNewProjectPage));
            Routing.RegisterRoute(nameof(ProjectPage), typeof(ProjectPage));
            Routing.RegisterRoute(nameof(CreateSprintPage), typeof(CreateSprintPage));
            Routing.RegisterRoute(nameof(CreateTaskPage), typeof(CreateTaskPage));
        }
    }
}
