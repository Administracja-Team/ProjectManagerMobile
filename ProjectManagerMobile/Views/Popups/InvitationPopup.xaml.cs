using CommunityToolkit.Maui.Views;
using ProjectManagerMobile.Models.DTO;

namespace ProjectManagerMobile.Views.Popups;

public partial class InvitationPopup : Popup
{
    private ProjectInvitationCode _invitation;
	public InvitationPopup(ProjectInvitationCode projectInvCode)
	{
		InitializeComponent();
        _invitation = projectInvCode;

        InvitationCodeLabel.Text += projectInvCode.Code;
        ExpiresAtLabel.Text += projectInvCode.ExpiresAt.ToString();

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(_invitation.Code);
    }
}