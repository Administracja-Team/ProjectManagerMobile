using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using ProjectManagerMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagerMobile
{
    public partial class AppShellViewModel : BaseViewModel
    {
        private IUserApi _userApi;
        private TokenStorageService _tokenStorageService;

        public AppShellViewModel(TokenStorageService tokenStorageService, IUserApi userApi)
        {
            _tokenStorageService = tokenStorageService;
            _userApi = userApi;
        }

        [ObservableProperty]
        public partial ImageSource UserLogo { get; set; }

        [ObservableProperty]
        public partial string UserFullName { get; set; }

        public async Task LoadDataAsync()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                await LoadUserData(token);
                await LoadUserAvatar(token);
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

        private async Task LoadUserAvatar(string? token)
        {
            var response = await _userApi.GetUserAvatar(token);
            if (response.IsSuccessStatusCode)
            {
                var imageBytes = await response.Content.ReadAsByteArrayAsync();
                UserLogo = ImageSource.FromStream(() => new MemoryStream(imageBytes));
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

                UserFullName = user.FullName;
            }
            else
            {
                var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content).Message;
                await Toast.Make(message).Show();
            }
        }
    }
}
