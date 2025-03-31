using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.ViewModels.Popups
{
    public partial class ConnectToProjectViewModel : BaseViewModel
    {
        public ConnectToProjectViewModel()
        {
            
        }

        [ObservableProperty]
        public partial string ProjectId { get; set; }

        [RelayCommand]
        private async Task ConnectToProject()
        {
            try
            {
                IsBusy = true;

                // todo
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
    }
}
