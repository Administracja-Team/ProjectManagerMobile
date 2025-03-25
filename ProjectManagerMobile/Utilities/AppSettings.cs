using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Maui.Core;
using ProjectManagerMobile.Resources.Themes;
using ProjectManagerMobile.Resources.Languages;


namespace ProjectManagerMobile.Utilities
{
    public static class AppSettings
    {
        public static Theme CurrentTheme { get; private set; }
        public static Language CurrentLanguage { get; private set; }

        public static void SetTheme(Theme theme)
        {
            ClearResources();
            Preferences.Default.Set("app_theme", (int)theme);
            CurrentTheme = theme;

            switch (theme)
            {
                case Theme.Light:
                    Application.Current.UserAppTheme = AppTheme.Light;
                    Application.Current.Resources.MergedDictionaries.Add(new LightTheme());
                    break;

                case Theme.Dark:
                    Application.Current.UserAppTheme = AppTheme.Dark;
                    Application.Current.Resources.MergedDictionaries.Add(new DarkTheme());
                    break;
            }

            SetStatusBarStyle();
        }

        public static void SetLanguage(Language language)
        {
            ClearResources();
            Preferences.Default.Set("app_language", (int)language);
            CurrentLanguage = language;

            switch (language)
            {
                case Language.Polish:
                    Application.Current.Resources.MergedDictionaries.Add(new PolishLanguage());
                    break;

                case Language.English:
                    Application.Current.Resources.MergedDictionaries.Add(new EnglishLanguage());
                    break;

                case Language.Russian:
                    Application.Current.Resources.MergedDictionaries.Add(new RussianLanguage());
                    break;
            }
        }

        private static void SetStatusBarStyle()
        {
            //var statusBarStyle = App.Current.RequestedTheme == AppTheme.Dark ? StatusBarStyle.LightContent : StatusBarStyle.DarkContent;
            //var color = (Color)Application.Current.Resources["SecondaryBackgroundColor"];
            var statusBarStyle = StatusBarStyle.LightContent;
            var color = Color.FromArgb("#000000");

            if (Device.RuntimePlatform != Device.WinUI)
            {
                StatusBar.SetStyle(statusBarStyle);
                StatusBar.SetColor(color);
            }
        }

        public static string GetCurrentLanguageCode()
        {
            return CurrentLanguage switch
            {
                Language.Polish => "pl",
                Language.English => "en",
                Language.Russian => "ru",
                _ => "en",
            };
        }


        private static void ClearResources()
        {
            Application.Current.Resources.Clear();
        }

        #region Enums

        public enum Language
        {
            Polish,
            English,
            Russian
        }

        public enum Theme
        {
            Light,
            Dark
        }

        #endregion
    }
}
