using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

[QueryProperty(nameof(ProjectIdQuery), "projectId")]
public partial class CreateSprintPage : ContentPage
{
    public int ProjectId { get; set; }

    public string ProjectIdQuery
    {
        get => ProjectId.ToString();
        set
        {
            if (int.TryParse(value, out var id))
                ProjectId = id;
        }
    }

    public CreateSprintPage(CreateSprintViewModel createSprintVM)
    {
        InitializeComponent();

        BindingContext = createSprintVM;
        createSprintVM.ProjectId = ProjectId;
    }
}