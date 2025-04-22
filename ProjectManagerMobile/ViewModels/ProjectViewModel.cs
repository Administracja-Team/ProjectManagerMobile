using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels
{
    public partial class ProjectViewModel : BaseViewModel
    {
        private IProjectApi _projectApi;
        private TokenStorageService _tokenStorageService;
        public ProjectViewModel(IProjectApi projectApi, TokenStorageService tokenStorageService)
        {
            _projectApi = projectApi;
            _tokenStorageService = tokenStorageService;
        }

        [ObservableProperty]
        public partial string Owner { get; set; }

        [ObservableProperty]
        public partial string TermOfWorks { get; set; }

        [ObservableProperty]
        public partial string ProjectDescription { get; set; }

        public ObservableCollection<UserDto> Members { get; set; } = new ObservableCollection<UserDto>();

        public ObservableCollection<string> Sprints { get; set; } = new ObservableCollection<string>() 
        {
            "wafwaf",
            "fwafawf",
            "wafawf",
            "wafawf",
            "wafawf",
            "wafawf",
            "wafawf",
            "wafawf",
            "wafawf",
            "wafawf",
            "wafawf",
            "wafawf",
        };


        [RelayCommand]
        private async Task ShowParticipants()
        {

        }

        [RelayCommand]
        private async Task CreateSprint()
        {

        }

        public async Task LoadDataAsync(int projectId)
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                await LoadProjectData(token, projectId);
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

        private async Task LoadProjectData(string? token, int projectId)
        {
            var response = await _projectApi.GetProjectDetails(token, projectId);
            if (response.IsSuccessful)
            {

            }
            else
            {
                var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content).Message;
                await Toast.Make(message).Show();
            }
        }



    }
}
