using ProjectManagerMobile.ViewModels;

namespace ProjectManagerMobile.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel settingsVM)
	{
		InitializeComponent();

		BindingContext = settingsVM;
	}
}