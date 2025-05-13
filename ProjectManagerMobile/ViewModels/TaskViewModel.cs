using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Models.DTO.Sprint;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels
{
    public partial class TaskViewModel : BaseViewModel
    {
        private readonly ISprintApi _sprintApi;
        private readonly TokenStorageService _tokenStorageService;

        public long ProjectId { get; set; }
        public long SprintId { get; set; }
        public long TaskId { get; set; }

        public TaskViewModel(ISprintApi sprintApi, TokenStorageService tokenStorageService)
        {
            _sprintApi = sprintApi;
            _tokenStorageService = tokenStorageService;
        }

        [ObservableProperty]
        private string taskName;

        [ObservableProperty]
        private string taskDescription;

        [ObservableProperty]
        private Priority selectedPriority = Priority.Medium;

        [ObservableProperty]
        private TaskStatus selectedStatus = TaskStatus.TODO;

        [RelayCommand]
        private void SelectStatus(TaskStatus status) => SelectedStatus = status;

        public ObservableCollection<OtherProjectMemberDto> TaskImplementers { get; set; } = new ObservableCollection<OtherProjectMemberDto>();

        public void Init(long projectId, long sprintId, long taskId, ObservableCollection<OtherProjectMemberDto> members, SprintTaskItemDto task)
        {
            ProjectId = projectId;
            SprintId = sprintId;
            TaskId = taskId;

            foreach (var implementer in task.Implementers)
            {
                TaskImplementers.Add(members.First(m => m.MemberId == implementer.Id));
            }

            TaskName = task.Name;
            TaskDescription = task.Description ?? "...";
            SelectedPriority = Enum.Parse<Priority>(task.Priority, ignoreCase: true);
            SelectedStatus = Enum.Parse<TaskStatus>(task.Status, ignoreCase: true);
        }

        [RelayCommand]
        private async Task SaveTaskStatus()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                var request = new TaskStatusUpdateRequest { Payload = SelectedStatus.ToString() };
                var response = await _sprintApi.UpdateTaskStatus(token, ProjectId, SprintId, TaskId, request);

                if (response.IsSuccessStatusCode)
                {
                    await Toast.Make("Task status updated successfully.").Show();
                    await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    await Toast.Make($"Failed to update task status: {response.Error.Content}").Show();
                }
            }
            catch (Exception ex)
            {
                await Toast.Make($"Error updating task status: {ex.Message}").Show();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    public enum TaskStatus
    {
        TODO,
        IN_PROGRESS,
        DONE
    }
}