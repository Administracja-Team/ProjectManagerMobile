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

namespace ProjectManagerMobile.ViewModels
{
    public partial class CreateNewProjectViewModel : BaseViewModel
    {
        private TokenStorageService _tokenStorageService;
        private IProjectApi _projectApi;

        public CreateNewProjectViewModel(TokenStorageService tokenStorageService, IProjectApi projectApi)
        {
            _tokenStorageService = tokenStorageService;
            _projectApi = projectApi;
        }

        [ObservableProperty]
        public partial string Name { get; set; }

        [ObservableProperty]
        public partial string Description { get; set; }

        [RelayCommand]
        private async Task CreateProject()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                var req = new ProjectCreateRequest
                {
                    Name = Name,
                    Description = Description
                };

                var response = await _projectApi.CreateProject(token, req);
                if (response.IsSuccessful)
                {
                    await Toast.Make("Project created!").Show();
                    await Shell.Current.Navigation.PopAsync();
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
