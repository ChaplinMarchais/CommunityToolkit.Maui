namespace CommunityToolkit.Maui.Views.TabView;

[ContentProperty(nameof(Content))]
public class TabViewItem : ContentView
{
	public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(TabViewItem), string.Empty);
	public string Icon
	{
		get => (string)GetValue(IconProperty);
		set => SetValue(IconProperty, value);
	}

	public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TabViewItem), string.Empty);
	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(TabViewItem), default(Color));
	public Color TextColor
	{
		get => (Color)GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}

	public static readonly BindableProperty TextColorSelectedProperty = BindableProperty.Create(nameof(TextColorSelected), typeof(Color), typeof(TabViewItem), default(Color));
	public Color TextColorSelected
	{
		get => (Color)GetValue(TextColorSelectedProperty);
		set => SetValue(TextColorSelectedProperty, value);
	}

	public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(TabViewItem), default(double));
	public double FontSize
	{
		get => (double)GetValue(FontSizeProperty);
		set => SetValue(FontSizeProperty, value);
	}

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