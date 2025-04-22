using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

public partial class CreateNewProjectPage : ContentPage
{
	public CreateNewProjectPage(CreateNewProjectViewModel createProjectVM)
	{
		InitializeComponent();

		BindingContext = createProjectVM;
	}
}