using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels.Auth
{
    public partial class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            
        }

        [ObservableProperty]
        public partial string Username { get; set; }

        [ObservableProperty]
        public partial string FirstName { get; set; }

        [ObservableProperty]
        public partial string LastName { get; set; }

        [ObservableProperty]
        public partial string Email { get; set; }

        [ObservableProperty]
        public partial string Password { get; set; }

        [ObservableProperty]
        public partial string PasswordRepeat { get; set; }

        [RelayCommand]
        private async Task CreateAccount()
        {
            if (IsBusy)
                return;

            if (!await ValidateInputsAsync())
                return;

            try
            {

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
            if (string.IsNullOrWhiteSpace(Username))
                return await ShowToastAsync("Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(FirstName))
                return await ShowToastAsync("First name cannot be empty.");

            if (string.IsNullOrWhiteSpace(LastName))
                return await ShowToastAsync("Last name cannot be empty.");

            if (string.IsNullOrWhiteSpace(Email) || !IsValidEmail(Email))
                return await ShowToastAsync("Invalid email format.");

            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 6)
                return await ShowToastAsync("Password must be at least 6 characters.");

            if (Password != PasswordRepeat)
                return await ShowToastAsync("Passwords do not match.");

            return true;
        }

        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private async Task<bool> ShowToastAsync(string message)
        {
            var toast = Toast.Make(message, ToastDuration.Short);
            await toast.Show();
            return false;
        }

        public void ClearState()
        {
            Username = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            PasswordRepeat = string.Empty;
        }

    }
}
