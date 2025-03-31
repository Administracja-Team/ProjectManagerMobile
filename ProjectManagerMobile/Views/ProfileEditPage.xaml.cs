using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

public partial class ProfileEditPage : ContentPage
{
    private ProfileEditViewModel _profileVM;
	public ProfileEditPage(ProfileEditViewModel profileVM)
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