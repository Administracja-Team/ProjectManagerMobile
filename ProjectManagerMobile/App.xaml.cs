
using Microsoft.Maui.Platform;
using ProjectManagerMobile.Handlers;
using ProjectManagerMobile.Utilities;

namespace ProjectManagerMobile
{
    public partial class App : Application
    {
        private AppShellViewModel _appShelVM;
        public App(AppShellViewModel appShelVM)
        {
            InitializeComponent();
            InitializeHandlers();

            _appShelVM = appShelVM;
        }


        protected override void OnStart()
        {
            SetAppTheme();
            SetAppLanguage();
        }

        private void SetAppTheme()
        {
            var theme = Preferences.Default.Get("app_theme", 0);
            AppSettings.SetTheme((AppSettings.Theme)theme);
        }

        private void SetAppLanguage()
        {
            var language = Preferences.Default.Get("app_language", 0);
            AppSettings.SetLanguage((AppSettings.Language)language);
        }

        private void InitializeHandlers()
        {
            InitializeBorderlessEntry();
            InitializeBorderlessEditor();
        }

        private void InitializeBorderlessEntry()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
                }
            });
        }

        private void InitializeBorderlessEditor()
        {
            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping(nameof(BorderlessEditor), (handler, view) =>
            {
                if (view is BorderlessEditor)
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                    handler.PlatformView.Layer.BorderWidth = 0;
#elif WINDOWS
                    handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
#endif
                }
            });
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell(_appShelVM));
        }
    }
}