using CommunityToolkit.Maui.Sample.ViewModels.Converters;

namespace CommunityToolkit.Maui.Sample.Pages.Converters;

public partial class DoubleToIntConverterPage : BasePage
{
	public DoubleToIntConverterPage()		: base()
	{
		InitializeComponent();

		ExampleText ??= new();
	}
}