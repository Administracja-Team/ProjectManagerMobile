using CommunityToolkit.Maui.Views;
using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views.Popups;

public partial class ProfileSettingsPopup : Popup
{
	public ProfileSettingsPopup(ProfileViewModel profileVM)
	{
		InitializeComponent();

		BindingContext = profileVM;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await this.CloseAsync();
    }
}