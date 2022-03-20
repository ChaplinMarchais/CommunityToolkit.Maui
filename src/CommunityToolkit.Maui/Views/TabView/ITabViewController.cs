namespace CommunityToolkit.Maui.Views;

public interface ITabViewController
{
	public int SelectedTabIndex { get; set; }
	public TabViewItem CurrentTab { get; set; }

	public event EventHandler<SelectedItemChangedEventArgs> SelectedTabChanged;
}