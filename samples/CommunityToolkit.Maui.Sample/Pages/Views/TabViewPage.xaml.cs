using CommunityToolkit.Maui.Sample.ViewModels.Views;

namespace CommunityToolkit.Maui.Sample.Pages.Views;

public partial class TabViewPage : BasePage<TabViewViewModel>
{
	public TabViewPage(TabViewViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}
}