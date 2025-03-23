using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel profileVM)
	{
		InitializeComponent();

		BindingContext = profileVM;
	}
}