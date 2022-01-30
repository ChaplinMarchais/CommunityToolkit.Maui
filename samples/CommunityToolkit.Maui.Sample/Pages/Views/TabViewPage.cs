using CommunityToolkit.Maui.Sample.Pages;
using CommunityToolkit.Maui.Views.TabView;

namespace CommunityToolkit.Maui.Sample.ViewModels.Views;

class TabViewPage : BasePage
{
	public TabViewPage()
	{
		Title = nameof(TabView);
		Content = new ScrollView()
		{
			Content = new TabView()
		};
	}
}