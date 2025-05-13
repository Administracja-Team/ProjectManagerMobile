using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

public partial class TaskPage : ContentPage
{
	public TaskPage(TaskViewModel taskVM)
	{
		InitializeComponent();

		BindingContext = taskVM;
	}
}