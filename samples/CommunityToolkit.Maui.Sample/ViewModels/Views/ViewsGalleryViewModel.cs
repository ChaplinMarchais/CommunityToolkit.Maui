using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Maui.Sample.Models;
using CommunityToolkit.Maui.Views.TabView;

namespace CommunityToolkit.Maui.Sample.ViewModels.Views;

public class ViewsGalleryViewModel : BaseGalleryViewModel
{
	protected override IEnumerable<SectionModel> CreateItems() => new[] {
		new SectionModel(
			typeof(TabViewPage),
			nameof(TabView),
			"Use the TabView control when you need to provide heirarchical navigation")
	};
}
