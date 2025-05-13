using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

[QueryProperty(nameof(ProjectIdQuery), "projectId")]
[QueryProperty(nameof(SprintIdQuery), "sprintId")]
public partial class SprintDetailsPage : ContentPage
{
	private SprintDetailsViewModel _sprintDetailsVM;

    public string ProjectIdQuery
    {
        set
        {
            if (int.TryParse(value, out var id))
                _sprintDetailsVM.ProjectId = id;
        }
    }

    public string SprintIdQuery
    {
        set
        {
            if (int.TryParse(value, out var id))
                _sprintDetailsVM.SprintId = id;
        }
    }
    public SprintDetailsPage(SprintDetailsViewModel sprintDetailsVM)
	{
		InitializeComponent();

		BindingContext = sprintDetailsVM;
		_sprintDetailsVM = sprintDetailsVM;
	}

    protected override async void OnAppearing()
    {
        await _sprintDetailsVM.LoadSprintDetails();
    }
}