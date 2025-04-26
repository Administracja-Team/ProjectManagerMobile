using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManagerMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels
{
    public partial class CreateSprintViewModel : BaseViewModel
    {
        public CreateSprintViewModel()
        {
            
        }

        [ObservableProperty]
        public partial string SprintName { get; set; }


        [ObservableProperty]
        public partial string SprintDescription { get; set; }

        [ObservableProperty]
        public partial DateTime StartDate { get; set; } = DateTime.Now;

        [ObservableProperty]
        public partial DateTime EndDate { get; set; } = DateTime.Now;

        public ObservableCollection<string> Tasks { get; set; } = new ObservableCollection<string>()
        {
            "fawfawfawwfwaf",
            "fawfawfawwfwaf",
            "fawfawfawwfwaf",
        };

        [RelayCommand]
        private async Task GoToCreateTask()
        {
            await Shell.Current.GoToAsync(nameof(CreateTaskPage));
        }
    }
}
