namespace CommunityToolkit.Maui.Views.TabView;

public class TabViewItem : ContentView
{
	public TabViewItem()
	{
		Content = new StackLayout
		{
			Children = {
				new Label { Text = "Welcome to .NET MAUI!" }
			}
		};
	}
}