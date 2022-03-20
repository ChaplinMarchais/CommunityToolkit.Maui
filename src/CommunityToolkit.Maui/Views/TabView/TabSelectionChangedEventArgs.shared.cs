using Microsoft.Maui.Controls;

namespace CommunityToolkit.Maui.Views.TabView;

public class TabSelectionChangedEventArgs : SelectedItemChangedEventArgs
{
	public TabSelectionChangedEventArgs(object selectedItem, int selectedItemIndex) : base(selectedItem, selectedItemIndex)
	{
	}
}
