using CommunityToolkit.Maui.Sample.ViewModels.Converters;

namespace CommunityToolkit.Maui.Sample.Pages.Converters;

public partial class IndexToArrayItemConverterPage : BasePage
{
	public IndexToArrayItemConverterPage()		: base()
	{
		InitializeComponent();
		Stepper ??= new();
	}
}