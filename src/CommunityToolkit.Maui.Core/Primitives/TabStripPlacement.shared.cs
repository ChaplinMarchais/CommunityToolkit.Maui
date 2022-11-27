namespace CommunityToolkit.Maui.Core;

/// <summary>
/// Specifies the placement of the Strip containing the TabViewItemIndicators for a <see cref="ITabView"/>
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
