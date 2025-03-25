using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

public partial class ProfilePage : ContentPage
{
    private ProfileViewModel _profileVM;
	public ProfilePage(ProfileViewModel profileVM)
	{
		InitializeComponent();

		BindingContext = profileVM;
        _profileVM = profileVM;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _profileVM.LoadDataAsync();
    }
}