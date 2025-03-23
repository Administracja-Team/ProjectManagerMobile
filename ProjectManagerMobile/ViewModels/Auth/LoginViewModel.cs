using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Platform.Compatibility;
using ProjectManagerMobile.Views.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels.Auth
{
    public partial class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            
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
                // todo


            }
            catch (Exception ex)
            {
                await Toast.Make(ex.Message).Show();
            }
            finally
            {

            }
        }


        private async Task<bool> ValidateInputsAsync()
        {
            if (string.IsNullOrWhiteSpace(UsernameEmail))
                return await ShowToastAsync("Enter your username or email.");

            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 6)
                return await ShowToastAsync("Password must be at least 6 characters.");

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
    }
}
