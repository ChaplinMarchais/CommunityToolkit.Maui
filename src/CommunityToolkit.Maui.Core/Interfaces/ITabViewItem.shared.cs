namespace CommunityToolkit.Maui.Core;

/// <summary>
/// Contract for <c>CommunityToolkit.Maui.Views.TabViewItem</c>
/// </summary>
public interface ITabViewItem : IContentView
{
	/// <summary>
	/// Gets or sets the text.
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// Gets or sets the <c>TabViewItem</c> footer
	/// </summary>
	IView Footer { get; set; }

	/// <summary>
	/// This property tracks if the <c>TabViewItem</c> is selected
	/// </summary>
	bool IsSelected { get; set; }
}