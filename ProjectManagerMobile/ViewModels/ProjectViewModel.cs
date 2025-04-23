using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Services;
using ProjectManagerMobile.Services.Interfaces;
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
    public partial class ProjectViewModel : BaseViewModel
    {
        private long _projectId;
        private IProjectApi _projectApi;
        private TokenStorageService _tokenStorageService;

        private long _currentMemberId;
        private string _currentMemberSystemRole;
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
        public partial string ProjectName { get; set; }

        [ObservableProperty]
        public partial string ProjectDescription { get; set; }

        [ObservableProperty]
        public partial bool IsBottomSheetOpened { get; set; } = false;

        [ObservableProperty]
        public partial string CurrentRoleField { get; set; }

        public ObservableCollection<OtherProjectMemberDto> Members { get; set; } = new ObservableCollection<OtherProjectMemberDto>();

        public ObservableCollection<string> Sprints { get; set; } = new ObservableCollection<string>() 
        {
            "wafwaf",
        };


        [RelayCommand]
        private async Task ShowParticipants()
        {
            IsBottomSheetOpened = true;
        }

        [RelayCommand]
        private async Task CreateSprint()
        {

        }

        [RelayCommand]
        private async Task DeleteMemberFromProject()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                var response = await _projectApi.DeleteMemberFromProject(token, _currentMemberId);
                if (response.IsSuccessful)
                {
                    await LoadDataAsync(_projectId);
                }
                else
                {
                    var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content).Message;
                    await Toast.Make(message).Show();
                }
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

        [RelayCommand]
        private async Task SetAsAdmin()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                var response = await _projectApi.SetMemberSystemRole(token, _currentMemberId, new StringRequest
                {
                    Payload = _currentMemberSystemRole == "MEMBER" ? "ADMIN" : "MEMBER"
                });
                if (response.IsSuccessful)
                {
                    await LoadDataAsync(_projectId);
                }
                else
                {
                    var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content).Message;
                    await Toast.Make(message).Show();
                }
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

        [RelayCommand]
        private async Task ApplyRole()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                var response = await _projectApi.SetDescriptiveRole(token, _currentMemberId, new StringRequest
                {
                    Payload = CurrentRoleField
                });
                if (response.IsSuccessful)
                {
                    await LoadDataAsync(_projectId);
                }
                else
                {
                    var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content).Message;
                    await Toast.Make(message).Show();
                }
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

        [RelayCommand]
        private async Task ShowSetRolePopup()
        {
            CurrentRoleField = string.Empty;
            var popup = new SetRolePopup(this);
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        }

        [RelayCommand]
        private async Task ShowMorePopup()
        {
            var popup = new ProjectSettingsPopup(this);
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        }

        [RelayCommand]
        private async Task ShowMemberActionsPopup(OtherProjectMemberDto member)
        {
            _currentMemberId = member.MemberId;
            _currentMemberSystemRole = member.SystemRole;

            var popup = new MemberActionsPopup(this);
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        }


        [RelayCommand]
        private async Task GoToCreateSprint()
        {
            await Shell.Current.GoToAsync(nameof(CreateSprintPage));
        }

        [RelayCommand]
        private async Task ShowInvitationPopup()
        {
            try
            {
                IsBusy = true;

                var token = await _tokenStorageService.GetBearerTokenAsync();
                var response = await _projectApi.CreateInvitationCode(token, _projectId);
                if (response.IsSuccessful)
                {
                    var details = response.Content;

                    var popup = new InvitationPopup(details);
                    await Shell.Current.CurrentPage.ShowPopupAsync(popup);
                }
                else
                {
                    var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content).Message;
                    await Toast.Make(message).Show();
                }
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

        public async Task LoadDataAsync(long projectId)
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

        private async Task LoadProjectData(string? token, long projectId)
        {
            var response = await _projectApi.GetProjectDetails(token, projectId);
            if (response.IsSuccessful)
            {
                var details = response.Content;

                _projectId = details.Project.Id;
                ProjectName = details.Project.Name;
                ProjectDescription = details.Project.Description ?? "No info";

                Members.Clear();
                foreach (var p in details.Others)
                {
                    Members.Add(p);
                    if (p.SystemRole == "OWNER")
                    {
                        Owner = $"{p.User.Name} {p.User.Surname}";
                    }
                }

            }
            else
            {
                var message = JsonSerializer.Deserialize<ErrorResponse>(response.Error.Content).Message;
                await Toast.Make(message).Show();
            }
        }



    }
}
