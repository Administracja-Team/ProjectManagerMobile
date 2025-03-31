using CommunityToolkit.Maui.Views;
using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views.Popups;

public partial class ProjectActionsPopup : Popup
{
	public ProjectActionsPopup(ProjectsListViewModel projectListVM)
	{
		InitializeComponent();

		BindingContext = projectListVM;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await this.CloseAsync();
    }
}