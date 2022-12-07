using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolkit.Maui.Core;

/// <summary>
/// Default settings for the <see cref="ITabView"/> control
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class TabViewDefaults
{
	/// <summary>
	/// Default placement of the <see cref="ITabView.TabIndicatorView"/>
	/// </summary>
	public static TabIndicatorPlacement TabIndicatorPlacement = TabIndicatorPlacement.Bottom;
}

/// <summary>
/// Determines the location and orientation of the <see cref="ITabView.TabIndicatorView"/>
/// </summary>
public enum TabIndicatorPlacement
{
	/// <summary>
	/// Tab Indicators are placed at the left edge of the <see cref="ITabView"/>
	/// </summary>
	Left = 1,
	/// <summary>
	/// Tab Indicators are placed at the Top of the <see cref="ITabView"/>
	/// </summary>
	Top = 2,
	/// <summary>
	/// Tab Indicators are placed at the right edge of the <see cref="ITabView"/>
	/// </summary>
	Right = 4,
	/// <summary>
	/// Tab Indicators are placed at the bottom of the <see cref="ITabView"/>
	/// </summary>
	Bottom = 8,
}
