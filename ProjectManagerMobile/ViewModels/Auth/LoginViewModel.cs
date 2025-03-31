using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Platform.Compatibility;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using ProjectManagerMobile.Views;
using ProjectManagerMobile.Views.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels.Auth
{
    public partial class LoginViewModel : BaseViewModel
    {
        private IAuthApi _authApi;
        private TokenStorageService _tokenStorageService;
        public LoginViewModel(IAuthApi authApi, TokenStorageService tokenStorageService)
        {
            _authApi = authApi;
            _tokenStorageService = tokenStorageService;
        }

        [ObservableProperty]
        public partial string UsernameEmail { get; set; }

        [ObservableProperty]
        public partial string Password { get; set; }

        [RelayCommand]
        private async Task Login()
        {
            if (IsBusy)
                return;

            if (!await ValidateInputsAsync())
                return;

            try
            {
                IsBusy = true;

                var response = await _authApi.LoginUser(new UserLoginRequest
                {
                    Identifier = UsernameEmail,
                    Password = Password
                });

                if (response.IsSuccessStatusCode)
                {
                    var tokenData = response.Content;
                    await _tokenStorageService.SaveUserSession(tokenData);

                    await Shell.Current.GoToAsync($"//{nameof(ProjectsListPage)}");
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


        private async Task<bool> ValidateInputsAsync()
        {
            if (string.IsNullOrWhiteSpace(UsernameEmail))
                return await ShowToastAsync("Enter your username or email.");

            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 5)
                return await ShowToastAsync("Password must be at least 5 characters.");

            return true;
        }

        private async Task<bool> ShowToastAsync(string message)
        {
            var toast = Toast.Make(message, ToastDuration.Short);
            await toast.Show();
            return false;
        }

        public void ClearState()
        {
            UsernameEmail = string.Empty;
            Password = string.Empty;
        }

        public async Task ProcessCheckUserSession()
        {
            try
            {
                IsBusy = true;

                if (await _tokenStorageService.IsUserLoggedIn())
                {
                    if (await _tokenStorageService.ShouldRefreshTokens())
                    {
                        var userTokenReq = new UserTokensRequest
                        {
                            AccessToken = await _tokenStorageService.GetAccessTokenAsync(),
                            RefreshToken = await _tokenStorageService.GetRefreshTokenAsync()
                        };

                        var response = await _authApi.RefreshToken(userTokenReq);
                        if (response.IsSuccessful)
                        {
                            await Toast.Make("Token refreshed successfully.").Show();
                        }
                        else
                        {
                            var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content).Message;
                            await Toast.Make(message).Show();
                        }
                    }
                    else
                    {
                        await Shell.Current.GoToAsync($"//{nameof(ProjectsListPage)}");
                    }
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
