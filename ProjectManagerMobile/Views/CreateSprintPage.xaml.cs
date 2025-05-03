using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

[QueryProperty(nameof(ProjectId), "projectId")]
public partial class CreateSprintPage : ContentPage
{
    public int ProjectId { get; set; }

    public CreateSprintPage(CreateSprintViewModel createSprintVM)
	{
		InitializeComponent();

		BindingContext = createSprintVM;
		createSprintVM.ProjectId = ProjectId;
	}
}