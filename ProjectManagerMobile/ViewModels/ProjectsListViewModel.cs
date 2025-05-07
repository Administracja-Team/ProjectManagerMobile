using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Models;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using ProjectManagerMobile.ViewModels.Popups;
using ProjectManagerMobile.Views;
using ProjectManagerMobile.Views.Popups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels
{
    public partial class ProjectsListViewModel : BaseViewModel
    {
        private TokenStorageService _tokenStorageService;
        private IProjectApi _projectApi;
        public ProjectsListViewModel(TokenStorageService tokenStorageService, IProjectApi projectApi)
        {
            _tokenStorageService = tokenStorageService;
            _projectApi = projectApi;
        }

        public ObservableCollection<ProjectModel> ProjectsList { get; set; } = new ObservableCollection<ProjectModel>();

        [RelayCommand]
        private async Task GoToProjectActions()
        {
            var popup = new ProjectActionsPopup(this);
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        }

        [RelayCommand]
        private async Task GoToConnectToProject()
        {
            var popupVM = new ConnectToProjectViewModel(_projectApi, _tokenStorageService);
            popupVM.ProjectConnectedSuccessfully += async (c, e) => await LoadDataAsync();
            var popup = new ConnectToProjectPopup(popupVM);
            
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        }

        public async Task LoadDataAsync()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                await LoadProjects(token);
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

        private async Task LoadProjects(string? token)
        {
            var response = await _projectApi.GetAllUserProjects(token);
            if (response.IsSuccessful)
            {
                ProjectsList.Clear();
                foreach (var p in response.Content)
                {
                    var project = new ProjectModel
                    {
                        Id = p.Project.Id,
                        Name = p.Project.Name,
                        OwnerName = p.OwnerName,
                        CurrentSprintName = "Sprint",
                        CurrentSprintDeadLine = DateTime.Now,
                        DonePercents = (int)(p.Project.DonePercents)
                    };

                    ProjectsList.Add(project);
                }

                await Toast.Make("Projects loaded!").Show();
            }
            else
            {
                var message = JsonSerializer.Deserialize<ErrorResponse>(response.Content.ToString()).Message;
                await Toast.Make(message).Show();
            }
        }

        [RelayCommand]
        private async Task GoToCreateNewProject()
        {
            await Shell.Current.GoToAsync(nameof(CreateNewProjectPage));
        }

        [RelayCommand]
        private async Task GoToProject(ProjectModel project)
        {
            await Shell.Current.GoToAsync($"{nameof(ProjectPage)}?projectId={project.Id}");
        }

    }
}
