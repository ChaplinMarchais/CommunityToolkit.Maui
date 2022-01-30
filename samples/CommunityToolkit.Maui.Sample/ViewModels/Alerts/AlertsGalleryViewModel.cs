using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Sample.Models;
using CommunityToolkit.Maui.Sample.Pages.Alerts;

namespace CommunityToolkit.Maui.Sample.ViewModels.Alerts;

public class AlertsGalleryViewModel : BaseGalleryViewModel
{
	protected override IEnumerable<SectionModel> CreateItems() => new[]
		{
			new SectionModel(
				typeof(SnackbarPage),
				nameof(Snackbar), 
				"Show Snackbar")
		};
}