using CommunityToolkit.Maui.Sample.Pages;
using CommunityToolkit.Maui.Sample.ViewModels.Views;

namespace CommunityToolkit.Maui.Sample.Pages.Views;

public partial class TabViewPage : BasePage<TabViewPageViewModel>
{
	public TabViewPage(TabViewPageViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}
}