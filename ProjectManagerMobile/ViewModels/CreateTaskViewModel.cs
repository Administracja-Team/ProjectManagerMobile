using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Models.DTO.Sprint;
using System.Collections.ObjectModel;

namespace ProjectManagerMobile.ViewModels;

public partial class CreateTaskViewModel : BaseViewModel
{
    #region Fields

    private readonly Action<SprintTaskDto> _onTaskSaved;

    private const string TaskNameRequiredMessage = "Please enter the task name.";
    private const string ImplementerRequiredMessage = "Please add at least one implementer.";

    #endregion

    #region Constructor

    public CreateTaskViewModel(Action<SprintTaskDto> onTaskSaved)
    {
        _onTaskSaved = onTaskSaved;
    }

    #endregion

    #region Properties

    [ObservableProperty]
    private string taskName;

    [ObservableProperty]
    private string taskDescription;

    [ObservableProperty]
    private Priority selectedPriority = Priority.Medium;

    [ObservableProperty]
    private DateTime startAt = DateTime.Now;

    [ObservableProperty]
    private DateTime endAt = DateTime.Now.AddDays(7);

    [ObservableProperty]
    private bool isBottomSheetOpened = false;

    public ObservableCollection<OtherProjectMemberDto> Members { get; } = new();
    public ObservableCollection<OtherProjectMemberDto> TaskImplementers { get; } = new();

    #endregion

    #region Commands

    [RelayCommand]
    private void SelectPriority(Priority priority) => SelectedPriority = priority;

    [RelayCommand]
    private Task ShowParticipants()
    {
        IsBottomSheetOpened = true;
        return Task.CompletedTask;
    }

    [RelayCommand]
    private void AddMemberAsImplementer(OtherProjectMemberDto member)
    {
        if (!TaskImplementers.Contains(member))
        {
            TaskImplementers.Add(member);
        }

        IsBottomSheetOpened = false;
    }

    [RelayCommand]
    private void DeleteImplementer(OtherProjectMemberDto member)
    {
        if (TaskImplementers.Contains(member))
        {
            TaskImplementers.Remove(member);
        }
    }

    [RelayCommand]
    private async Task SaveTask()
    {
        if (!ValidateForm())
            return;

        var task = new SprintTaskDto
        {
            Name = TaskName,
            Description = TaskDescription,
            Priority = SelectedPriority.ToString().ToUpper(),
            StartAt = StartAt,
            EndAt = EndAt,
            ImplementerMemberIds = TaskImplementers.Select(x => x.MemberId).ToList()
        };

        _onTaskSaved?.Invoke(task);

        await Shell.Current.Navigation.PopAsync();

        ResetForm();
    }

    #endregion

    #region Validation

    private bool ValidateForm()
    {
        if (string.IsNullOrWhiteSpace(TaskName))
        {
            Toast.Make(TaskNameRequiredMessage).Show();
            return false;
        }

        if (TaskImplementers.Count == 0)
        {
            Toast.Make(ImplementerRequiredMessage).Show();
            return false;
        }

        return true;
    }

    #endregion

    #region Helpers

    private void ResetForm()
    {
        TaskName = string.Empty;
        TaskDescription = string.Empty;
        SelectedPriority = Priority.Medium;
        StartAt = DateTime.Now;
        EndAt = DateTime.Now.AddDays(7);
        TaskImplementers.Clear();
        IsBottomSheetOpened = false;
    }

    #endregion
}

public enum Priority
{
    Low,
    Medium,
    High
}
