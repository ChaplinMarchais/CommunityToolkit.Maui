using CommunityToolkit.Maui.Sample.ViewModels.Behaviors;

namespace CommunityToolkit.Maui.Sample.Pages.Behaviors;

public partial class UserStoppedTypingBehaviorPage : BasePage
{
	public UserStoppedTypingBehaviorPage()		: base()
	{
		InitializeComponent();

		TimeThresholdSetting ??= new();
		AutoDismissKeyboardSetting ??= new();
		MinimumLengthThresholdSetting ??= new();
	}
}