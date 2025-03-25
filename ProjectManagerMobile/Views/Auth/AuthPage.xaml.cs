using CommunityToolkit.Maui.Media;
using Microsoft.Maui.Platform;
using ProjectManagerMobile.ViewModels.Auth;

namespace ProjectManagerMobile.Views.Auth;

public partial class AuthPage : ContentPage
{
    private LoginViewModel _loginVM;
    private RegisterViewModel _registerVM;
    public AuthPage(LoginViewModel loginVM, RegisterViewModel registerVM)
	{
		InitializeComponent();

        BindingContext = loginVM;
        _loginVM = loginVM;
        _registerVM = registerVM;
    }

    private async void GoToRegister_Clicked(object sender, EventArgs e)
    {
        var t1 = MainBorder.TranslateTo(0, 0, 250, Easing.Linear);
        var t2 = ProjectManagerLabel.TranslateTo(0, 0, 250, Easing.Linear);
        await Task.WhenAll(t1, t2);

        _loginVM.ClearState();
        BindingContext = _registerVM;

        RegisterLayout.IsVisible = true;
        SignUpLabel.IsVisible = true;
        ProfileImageButton.IsVisible = true;
        BackButton.IsVisible = true;

        var t3 = LoginLayout.FadeTo(0, 0);
        var t4 = RegisterLayout.FadeTo(1, 0);
        var t5 = ProjectManagerLabel.FadeTo(0, 0);
        var t6 = SignUpLabel.FadeTo(1, 0);
        var t7 = ProfileImageButton.FadeTo(1, 250);
        var t8 = BackButton.FadeTo(1, 250);
        await Task.WhenAll(t3, t4, t5, t6, t7);

        LoginLayout.IsVisible = false;
        ProjectManagerLabel.IsVisible = false;
    }

    private async void GoToLogin_Clicked(object sender, EventArgs e)
    {
        LoginLayout.IsVisible = true;
        ProjectManagerLabel.IsVisible = true;

        _registerVM.ClearState();
        BindingContext = _loginVM;

        var t1 = LoginLayout.FadeTo(1, 0);
        var t2= RegisterLayout.FadeTo(0, 0);
        var t3 = ProjectManagerLabel.FadeTo(1, 0);
        var t4 = SignUpLabel.FadeTo(0, 0);
        var t5 = ProfileImageButton.FadeTo(0, 250);
        var t6 = BackButton.FadeTo(0, 250);
        await Task.WhenAll(t1, t2, t3, t4, t5, t6);

        RegisterLayout.IsVisible = false;
        SignUpLabel.IsVisible = false;
        ProfileImageButton.IsVisible = false;
        BackButton.IsVisible = false;

        var t7 = MainBorder.TranslateTo(0, 100, 250, Easing.Linear);
        var t8 = ProjectManagerLabel.TranslateTo(0, 50, 250, Easing.Linear);
        await Task.WhenAll(t7, t8);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _loginVM.ProcessCheckUserSession();
    }
}