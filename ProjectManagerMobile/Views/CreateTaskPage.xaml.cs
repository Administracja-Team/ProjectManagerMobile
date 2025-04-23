using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

public partial class CreateTaskPage : ContentPage
{
	public CreateTaskPage(CreateTaskViewModel createTaskVM)
	{
		InitializeComponent();

		BindingContext = createTaskVM;
	}
}