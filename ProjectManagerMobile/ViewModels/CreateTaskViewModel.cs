using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels
{
    public partial class CreateTaskViewModel : BaseViewModel
    {
        public CreateTaskViewModel()
        {
            
        }

        [ObservableProperty]
        public partial string TaskName { get; set; }


        [ObservableProperty]
        public partial string TaskDescription { get; set; }

        [ObservableProperty]
        public partial Priority SelectedPriority { get; set; } = Priority.Medium;

        [RelayCommand]
        private void SelectPriority(Priority priority)
        {
            SelectedPriority = priority;
        }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
