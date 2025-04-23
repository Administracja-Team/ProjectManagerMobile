using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

public partial class CreateSprintPage : ContentPage
{
	public CreateSprintPage(CreateSprintViewModel createSprintVM)
	{
		InitializeComponent();

		BindingContext = createSprintVM;
	}
}