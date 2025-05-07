using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
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
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels
{
    public partial class CreateSprintViewModel : BaseViewModel
    {
        public int ProjectId { get; set; }
        private CreateTaskViewModel _createTaskVM;

        private TokenStorageService _tokenStorageService;
        private ISprintApi _sprintApi;
        public CreateSprintViewModel(TokenStorageService tokenStorageService, ISprintApi sprintApi, INavigationDataService dataService)
        {
            _tokenStorageService = tokenStorageService;
            _sprintApi = sprintApi;

            _createTaskVM = new CreateTaskViewModel(task =>
            {
                Tasks.Add(task);
            });
            _createTaskVM.Members.Clear();
            foreach (var member in dataService.Get<ObservableCollection<OtherProjectMemberDto>>())
            {
                _createTaskVM.Members.Add(member);
            }
        }

        [ObservableProperty]
        public partial string SprintName { get; set; }

        [ObservableProperty]
        public partial string SprintDescription { get; set; }

        [ObservableProperty]
        public partial DateTime StartDate { get; set; } = DateTime.Now;

        [ObservableProperty]
        public partial DateTime EndDate { get; set; } = DateTime.Now;

        public ObservableCollection<SprintTaskDto> Tasks { get; set; } = new ObservableCollection<SprintTaskDto>();

        [RelayCommand]
        private async Task GoToCreateTask()
        {
            await Shell.Current.Navigation.PushAsync(new CreateTaskPage(_createTaskVM));
        }

        [RelayCommand]
        private void DeleteTask(SprintTaskDto task)
        {
            Tasks.Remove(task);
        }

        [RelayCommand]
        private async Task CreateSprint()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();

                var sprintCreateReq = new SprintCreateRequest
                {
                    Name = SprintName,
                    Description = SprintDescription,
                    StartAt = StartDate,
                    EndAt = EndDate,
                    Tasks = Tasks.ToList() // Преобразуем ObservableCollection в List
                };

                var response = await _sprintApi.CreateSprint(token, ProjectId, sprintCreateReq);
                if (response.IsSuccessful)
                {
                    await Toast.Make("Sprint successfully created!").Show();
                    await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content)?.Message ?? "Unknown error.";
                    await Toast.Make(message).Show();
                }
            }
            catch (Exception ex)
            {
                await Toast.Make($"Error: {ex.Message}").Show();
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
