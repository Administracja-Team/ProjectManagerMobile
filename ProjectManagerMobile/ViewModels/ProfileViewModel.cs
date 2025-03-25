using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private IUserApi _userApi;
        private TokenStorageService _tokenStorageService;
        public ProfileViewModel(IUserApi userApi, TokenStorageService tokenStorageService)
        {
            _userApi = userApi;
            _tokenStorageService = tokenStorageService;
        }

        [ObservableProperty]
        public partial string Name { get; set; }

        [ObservableProperty]
        public partial string Username { get; set; }

        [ObservableProperty]
        public partial string Email { get; set; }

        [ObservableProperty]
        public partial string About { get; set; } = "...";

        public async Task LoadDataAsync()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                var response = await _userApi.GetUserProfile(token);
                if (response.IsSuccessful)
                {
                    var user = response.Content;
                    Name = $"{user.Name} {user.Surname}";
                    Username = user.Username;
                    Email = user.Email; 
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
                IsBusy = false;
            }
        }
    }
}
