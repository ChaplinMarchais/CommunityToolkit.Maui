using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Sample.ViewModels.Behaviors;

namespace CommunityToolkit.Maui.Sample.Pages.Behaviors;

partial class MaxLengthReachedBehaviorPage : BasePage
{
	public MaxLengthReachedBehaviorPage()		: base()
	{
		InitializeComponent();

		NextEntry ??= new();
		MaxLengthSetting ??= new();
		AutoDismissKeyboardSetting ??= new();
	}

	void MaxLengthReachedBehavior_MaxLengthReached(object? sender, MaxLengthReachedEventArgs e)
	{
		NextEntry.Focus();
	}
}