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
            //Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        }
    }
}
