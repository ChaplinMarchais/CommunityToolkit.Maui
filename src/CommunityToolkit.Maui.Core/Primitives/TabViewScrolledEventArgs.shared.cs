namespace CommunityToolkit.Maui.Core;
/// <summary>
/// The tab view scrolled event args.
/// </summary>

public class TabViewScrolledEventArgs : EventArgs
{
	/// <summary>
	/// Gets the distance scrolled on the X axis (horizontally)
	/// </summary>
	public double X { get; init; }

	/// <summary>
	/// Gets the distance scrolled on the Y axis (vertically)
	/// </summary>
	public double Y { get; init; }

	/// <summary>
	/// Initializes a new instance of the <see cref="TabViewScrolledEventArgs"/> class.
	/// </summary>
	/// <param name="x">The distance scrolled on the X axis (horizontally)</param>
	/// <param name="y">The distance scrolled on the Y axis (vertically)</param>
	public TabViewScrolledEventArgs(double x, double y)
	{
		X = x;
		Y = y;
	}
}
