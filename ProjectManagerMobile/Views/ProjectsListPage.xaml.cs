using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

public partial class ProjectsListPage : ContentPage
{

    private bool _isFloatingButtonVisible = true;
    public ProjectsListPage(ProjectsListViewModel projectsVM)
	{
		InitializeComponent();

		BindingContext = projectsVM;
	}

    protected async void OnCollectionViewScrolled(object sender, DevExpress.Maui.CollectionView.DXCollectionViewScrolledEventArgs e)
    {
        if (e.Delta > 5)
        {
            // Scrolling down
            if (_isFloatingButtonVisible)
            {
                _isFloatingButtonVisible = false;
                await HideButtonAsync();
            }
        }
        else if (e.Delta < 0)
        {
            // Scrolling up
            if (!_isFloatingButtonVisible)
            {
                await ShowButtonAsync();
                _isFloatingButtonVisible = true;
            }
        }
    }

    private async Task ShowButtonAsync()
    {
        if (FloatingButton != null)
        {
            FloatingButton.IsVisible = true;
            await Task.WhenAll(
                FloatingButton.TranslateTo(0, 0, 300, Easing.CubicInOut),
                FloatingButton.FadeTo(1, 300, Easing.CubicInOut)
            );
        }
    }

    private async Task HideButtonAsync()
    {
        if (FloatingButton != null)
        {
            await Task.WhenAll(
                FloatingButton.TranslateTo(0, 100, 300, Easing.CubicInOut),
                FloatingButton.FadeTo(0, 300, Easing.CubicInOut)
            );

            FloatingButton.IsVisible = false;
        }
    }

}