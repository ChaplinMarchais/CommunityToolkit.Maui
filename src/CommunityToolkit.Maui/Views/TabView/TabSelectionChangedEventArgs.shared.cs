namespace CommunityToolkit.Maui.Views;

public class TabSelectionChangedEventArgs : SelectedItemChangedEventArgs
{
	public TabSelectionChangedEventArgs(object selectedItem, int selectedItemIndex) : base(selectedItem, selectedItemIndex)
	{
	}
}
