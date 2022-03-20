using Microsoft.Maui.Controls;

namespace CommunityToolkit.Maui.Views;
/// <summary>
/// The tab view scrolled event args.
/// </summary>

public class TabViewScrolledEventArgs : ScrolledEventArgs
{
	/// <summary>
	/// Initializes a new instance of the <see cref="TabViewScrolledEventArgs"/> class.
	/// </summary>
	/// <param name="x">The distance scrolled on the X axis (horizontally)</param>
	/// <param name="y">The distance scrolled on the Y axis (vertically)</param>
	public TabViewScrolledEventArgs(double x, double y) : base(x, y)
	{
	}
}
