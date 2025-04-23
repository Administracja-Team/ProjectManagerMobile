using CommunityToolkit.Maui.Views;
using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views.Popups;

public partial class SetRolePopup : Popup
{
	public SetRolePopup(ProjectViewModel projectVM)
	{
		InitializeComponent();

		BindingContext = projectVM;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await this.CloseAsync();
    }
}