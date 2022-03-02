using CommunityToolkit.Maui.Sample.Models;
using CommunityToolkit.Maui.Sample.Pages.Views;

namespace CommunityToolkit.Maui.Sample.ViewModels.Views;

public class ViewsGalleryViewModel : BaseGalleryViewModel
{
	public ViewsGalleryViewModel() 
		: base(new[]
		{
		SectionModel.Create<TabViewPageViewModel>(nameof(TabViewPage),
			"Use the TabView control when you need to provide heirarchical navigation") 
		})
	{
	}
}
