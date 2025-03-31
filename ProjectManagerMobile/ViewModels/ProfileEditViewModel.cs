using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static DevExpress.Data.Helpers.FindSearchRichParser;

namespace ProjectManagerMobile.ViewModels
{
    public partial class ProfileEditViewModel : ProfileViewModel
    {
        public ProfileEditViewModel(IUserApi userApi, TokenStorageService tokenStorageService) : base(null, userApi, tokenStorageService)
        {
            
        }

        [RelayCommand]
        private async Task SaveUserInfo()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                await SendUserData(token);
                await SendUserAvatar(token);
                await Shell.Current.Navigation.PopAsync();
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

        private async Task SendUserAvatar(string? token)
        {
            var imageStream = await GetStreamFromImageSourceAsync(Avatar);
            var imageStreamPart = new StreamPart(imageStream, "avatar.png", "image/png");

            var response = await _userApi.UploadUserAvatar(token, imageStreamPart);
            if (response.IsSuccessful)
            {
                await Toast.Make("User avatar successfully updated!").Show();
            }
            else
            {
                var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content).Message;
                await Toast.Make(message).Show();
            }
        }

        private async Task SendUserData(string? token)
        {
            var newData = new UserUpdateProfileRequest
            {
                Name = FirstName,
                Surname = LastName
            };

            var response = await _userApi.UpdateUserProfile(token, newData);
            if (response.IsSuccessful)
            {
                await Toast.Make("User data successfully updated!").Show();
            }
            else
            {
                var message = JsonSerializer.Deserialize<ErrorResponse>(response.Content.ToString()).Message;
                await Toast.Make(message).Show();
            }
        }

        [RelayCommand]
        private async Task SelectAvatar()
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a photo",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                Avatar = ImageSource.FromFile(result.FullPath);
            }

        }

        private async Task<Stream> GetStreamFromImageSourceAsync(ImageSource imageSource)
        {
            if (imageSource is FileImageSource fileImageSource)
            {
                if (!string.IsNullOrEmpty(fileImageSource.File) && File.Exists(fileImageSource.File))
                {
                    return File.OpenRead(fileImageSource.File);
                }
            }
            else if (imageSource is StreamImageSource streamImageSource)
            {
                return await streamImageSource.Stream(CancellationToken.None);
            }

            return null;
        }
    }
}
