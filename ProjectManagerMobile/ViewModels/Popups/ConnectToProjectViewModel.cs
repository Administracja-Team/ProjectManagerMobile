using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels.Popups
{
    public partial class ConnectToProjectViewModel : BaseViewModel
    {
        private TokenStorageService _tokenStorageService;
        private IProjectApi _projectApi;
        public ConnectToProjectViewModel(IProjectApi projectApi, TokenStorageService tokenStorageService)
        {
            _tokenStorageService = tokenStorageService;
            _projectApi = projectApi;
        }

        [ObservableProperty]
        public partial string ProjectId { get; set; }

        [RelayCommand]
        private async Task ConnectToProject()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                await SendConnectCode(token);
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

        private async Task SendConnectCode(string? token)
        {
            var response = await _projectApi.ConnectToProjectByCode(token, ProjectId);
            if (response.IsSuccessful)
            {
                await Toast.Make("Successfully added").Show();
            }
            else
            {
                var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content.ToString()).Message;
                await Toast.Make(message).Show();
            }
        }
    }
}
