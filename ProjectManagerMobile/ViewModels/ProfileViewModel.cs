using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using ProjectManagerMobile.Views;
using ProjectManagerMobile.Views.Auth;
using ProjectManagerMobile.Views.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private IAuthApi _authApi;
        protected IUserApi _userApi;
        protected TokenStorageService _tokenStorageService;
        public ProfileViewModel(IAuthApi authApi, IUserApi userApi, TokenStorageService tokenStorageService)
        {
            _authApi = authApi;
            _userApi = userApi;
            _tokenStorageService = tokenStorageService;
        }

        [ObservableProperty]
        public partial string FirstName { get; set; }


        [ObservableProperty]
        public partial string LastName { get; set; }


        [ObservableProperty]
        public partial string FullName { get; set; }

        [ObservableProperty]
        public partial string Username { get; set; }

        [ObservableProperty]
        public partial string Email { get; set; }

        [ObservableProperty]
        public partial string About { get; set; } = "...";

        [ObservableProperty]
        public partial ImageSource Avatar { get; set; }

        [RelayCommand]
        private async Task ShowMorePopup()
        {
            var popup = new ProfileSettingsPopup(this);
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        }

        [RelayCommand]
        private async Task GoToEditInfo()
        {
            await Shell.Current.GoToAsync(nameof(ProfileEditPage));
        }

        [RelayCommand]
        private async Task GoToChangePassword()
        {

        }

        public async Task LoadDataAsync()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                await LoadUserData(token);
                await LoadUserAvatar(token);
            }
            catch(Exception ex)
            {
                await Toast.Make(ex.Message).Show();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoadUserAvatar(string? token)
        {
            var response = await _userApi.GetUserAvatar(token);
            if (response.IsSuccessStatusCode)
            {
                var imageBytes = await response.Content.ReadAsByteArrayAsync();
                Avatar = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }
            else
            {
                var message = JsonSerializer.Deserialize<ErrorResponse>(response.Content.ToString()).Message;
                await Toast.Make(message).Show();
            }
        }

        private async Task LoadUserData(string? token)
        {
            var response = await _userApi.GetUserProfile(token);
            if (response.IsSuccessful)
            {
                var user = response.Content;
                FirstName = user.Name;
                LastName = user.Surname;
                FullName = $"{FirstName} {LastName}";
                Username = user.Username;
                Email = user.Email;
            }
            else
            {
                var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content).Message;
                await Toast.Make(message).Show();
            }
        }

        [RelayCommand]
        private async Task Logout()
        {
            try
            {
                IsBusy = true;

                var tokensRequest = new Models.DTO.UserTokensRequest
                {
                    AccessToken = await _tokenStorageService.GetAccessTokenAsync(),
                    RefreshToken = await _tokenStorageService.GetRefreshTokenAsync()
                };

                var response = await _authApi.LogoutUser(tokensRequest);
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
            catch (Exception ex)
            {
                await Toast.Make(ex.Message).Show();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
