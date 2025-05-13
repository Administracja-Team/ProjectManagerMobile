using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Models.DTO.Sprint;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using ProjectManagerMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels
{
    public partial class SprintDetailsViewModel : BaseViewModel
    {
        private readonly ISprintApi _sprintApi;
        private readonly TokenStorageService _tokenStorageService;
        private ObservableCollection<OtherProjectMemberDto> _members;

        public int ProjectId { get; set; }
        public long SprintId { get; set; }

        [ObservableProperty]
        private SprintDetailsDto sprintDetails;

        public SprintDetailsViewModel(TokenStorageService tokenStorageService, ISprintApi sprintApi, INavigationDataService dataService)
        {
            _tokenStorageService = tokenStorageService;
            _sprintApi = sprintApi;
            _members = dataService.Get<ObservableCollection<OtherProjectMemberDto>>();
        }

        [RelayCommand]
        private async Task GoToTask(SprintTaskItemDto task)
        {
            var taskVM = new TaskViewModel(_sprintApi, _tokenStorageService);
            taskVM.Init(ProjectId, SprintId, task.Id, _members, task);
            await Shell.Current.Navigation.PushAsync(new TaskPage(taskVM));
        }

        public async Task LoadSprintDetails()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                var response = await _sprintApi.GetSprintDetails(token, ProjectId, SprintId);

                if (response.IsSuccessStatusCode)
                {
                    SprintDetails = response.Content;
                    if (string.IsNullOrEmpty(SprintDetails.Description))
                        SprintDetails.Description = "...";
                }
                else
                {
                    await Toast.Make("Failed to load sprint details.").Show();
                }
            }
            catch (Exception ex)
            {
                await Toast.Make($"Error loading sprint details: {ex.Message}").Show();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}