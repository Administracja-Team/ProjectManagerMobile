using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Models;
using ProjectManagerMobile.ViewModels.Popups;
using ProjectManagerMobile.Views;
using ProjectManagerMobile.Views.Popups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels
{
    public partial class ProjectsListViewModel : BaseViewModel
    {
        public ProjectsListViewModel()
        {

        }

        public ObservableCollection<ProjectModel> ProjectsList { get; set; } = new ObservableCollection<ProjectModel>
        {
            new ProjectModel
            {
                Name = "Anitic emulator Keeper",
                OwnerName = "Tony",
                CurrentSprintName = "Starting",
                CurrentSprintDeadLine = DateTime.Now
            },
                        new ProjectModel
            {
                Name = "Anitic emulator Keeper",
                OwnerName = "Tony",
                CurrentSprintName = "Starting",
                CurrentSprintDeadLine = DateTime.Now
            },
                                    new ProjectModel
            {
                Name = "Anitic emulator Keeper",
                OwnerName = "Tony",
                CurrentSprintName = "Starting",
                CurrentSprintDeadLine = DateTime.Now
            },
                                                new ProjectModel
            {
                Name = "Anitic emulator Keeper",
                OwnerName = "Tony",
                CurrentSprintName = "Starting",
                CurrentSprintDeadLine = DateTime.Now
            },
        };

        [RelayCommand]
        private async Task GoToProjectActions()
        {
            var popup = new ProjectActionsPopup(this);
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        }

        [RelayCommand]
        private async Task GoToConnectToProject()
        {
            var popupVM = new ConnectToProjectViewModel();
            var popup = new ConnectToProjectPopup(popupVM);
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        }

        [RelayCommand]
        private async Task GoToCreateNewProject()
        {
            await Shell.Current.GoToAsync(nameof(CreateNewProjectPage));
        }
    }
}
