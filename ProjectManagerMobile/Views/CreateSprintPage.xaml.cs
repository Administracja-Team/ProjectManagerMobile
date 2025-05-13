using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

[QueryProperty(nameof(ProjectIdQuery), "projectId")]
public partial class CreateSprintPage : ContentPage
{
    private CreateSprintViewModel _createSprintVM;

    public string ProjectIdQuery
    {
        set
        {
            if (int.TryParse(value, out var id))
                _createSprintVM.ProjectId = id;
        }
    }

    public CreateSprintPage(CreateSprintViewModel createSprintVM)
    {
        InitializeComponent();

        BindingContext = createSprintVM;
        _createSprintVM = createSprintVM;
    }
}