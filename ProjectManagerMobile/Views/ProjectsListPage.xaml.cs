using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

public partial class ProjectsListPage : ContentPage
{
	public ProjectsListPage(ProjectsListViewModel projectsVM)
	{
		InitializeComponent();

		BindingContext = projectsVM;
	}
}