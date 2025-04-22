using CommunityToolkit.Maui.Views;
using ProjectManagerMobile.ViewModels;
using ProjectManagerMobile.ViewModels.Popups;

namespace ProjectManagerMobile.Views.Popups;

public partial class ConnectToProjectPopup : Popup
{
	public ConnectToProjectPopup(ConnectToProjectViewModel connectToProjectVM)
	{
		InitializeComponent();

		BindingContext = connectToProjectVM;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		//await this.CloseAsync();
    }
}