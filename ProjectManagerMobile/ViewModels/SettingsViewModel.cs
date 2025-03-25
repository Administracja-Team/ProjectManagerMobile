using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using ProjectManagerMobile.Utilities;
using ProjectManagerMobile.Views.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        private IAuthApi _authApi;
        private TokenStorageService _tokenStorageService;

        public SettingsViewModel(IAuthApi authApi, TokenStorageService tokenStorageService)
        {
            _authApi = authApi;
            _tokenStorageService = tokenStorageService;
            SelectedTheme = AppSettings.CurrentTheme.ToString();
            SelectedLanguage = AppSettings.CurrentLanguage.ToString();
        }

        [ObservableProperty]
        public partial string? SelectedTheme { get; set; }

        partial void OnSelectedThemeChanged(string? value)
        {
            if (Enum.TryParse<AppSettings.Theme>(value, out var theme))
            {
                AppSettings.SetTheme(theme);
            }
        }

        [ObservableProperty]
        public partial string? SelectedLanguage { get; set; }

        partial void OnSelectedLanguageChanged(string? value)
        {
            if (Enum.TryParse<AppSettings.Language>(value, out var language))
            {
                AppSettings.SetLanguage(language);
            }
        }

        [RelayCommand]
        private async Task Logout()
        {
            try
            {
                var response = await _authApi.LogoutUser(new Models.DTO.UserTokensRequest
                {
                    AccessToken = await _tokenStorageService.GetAccessTokenAsync(),
                    RefreshToken = await _tokenStorageService.GetRefreshTokenAsync()
                });

                if (response.IsSuccessStatusCode)
                {
                    _tokenStorageService.RemoveUserSessionAsync();
                    await Shell.Current.GoToAsync($"//{nameof(AuthPage)}");
                }
                else
                {
                    var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content).Message;
                    await Toast.Make(message).Show();
                }
            } 
            catch(Exception ex)
            {
                await Toast.Make(ex.Message).Show();
            }
            finally
            {

            }
        }
    }
}
