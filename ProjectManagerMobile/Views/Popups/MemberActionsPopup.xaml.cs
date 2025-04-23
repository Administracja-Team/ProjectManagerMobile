using CommunityToolkit.Maui.Views;
using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views.Popups;

public partial class MemberActionsPopup : Popup
{
	public MemberActionsPopup(ProjectViewModel projectVM)
	{
		InitializeComponent();

		BindingContext = projectVM;
	}
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await this.CloseAsync();
    }
}