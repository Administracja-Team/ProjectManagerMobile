
using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

[QueryProperty(nameof(ProjectId), "projectId")]
public partial class ProjectPage : ContentPage
{
    private ProjectViewModel _projectVM;
    public int ProjectId { get; set; }

    public ProjectPage(ProjectViewModel projectVM)
    {
        InitializeComponent();

        BindingContext = projectVM;
        _projectVM = projectVM;
    }

    protected override async void OnAppearing()
    {
        await _projectVM.LoadDataAsync(ProjectId);
    }


}