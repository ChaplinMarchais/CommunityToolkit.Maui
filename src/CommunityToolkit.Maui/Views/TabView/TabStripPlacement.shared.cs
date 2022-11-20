namespace CommunityToolkit.Maui.Views;

/// <summary>
/// Specifies the placement of the TabStrip for a <see cref="TabView"/>
/// </summary>
[Flags]
public enum TabStripPlacement
{
	/// <summary>
	/// Align with the top of parent container
	/// </summary>
	Top = 0,
	/// <summary>
	/// Align with the bottom of parent container
	/// </summary>
	Bottom,
	/// <summary>
	/// Align with the left of parent container
	/// </summary>
	Left
}
