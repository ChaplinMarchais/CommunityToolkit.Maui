using System.Collections;
using System.Collections.ObjectModel;

namespace CommunityToolkit.Maui.Core;

/// <summary>
/// Contract for <c>CommunityToolkit.Maui.Views.TabView</c>
/// </summary>
public interface ITabView
{
	/// <summary>
	/// Gets or sets the tab items source.
	/// </summary>
	IList? TabItemsSource { get; set; }

	/// <summary>
	/// Gets or sets the <see cref="ObservableCollection{ITabViewItem}"/> to be displayed
	/// </summary>
	ObservableCollection<ITabViewItem> TabItems { get; set; }

	/// <summary>
	/// Gets or sets the selected index.
	/// </summary>
	int SelectedTabIndex { get; set; }

	/// <summary>
	/// Gets or sets the tab strip background view.
	/// </summary>
	IView? TabStripBackgroundView { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether tab strip is visible.
	/// </summary>
	bool IsTabStripVisible { get; set; }

	/// <summary>
	/// Gets or sets the tab indicator view.
	/// </summary>
	IView? TabIndicatorView { get; set; }

	/// <inheritdoc/>
	ITabViewItem? CurrentTab { get; }

	/// <summary>
	/// Gets the currently displayed content for the selected <see cref="ITabViewItem"/>
	/// </summary>
	IView? TabContentView { get; }
}