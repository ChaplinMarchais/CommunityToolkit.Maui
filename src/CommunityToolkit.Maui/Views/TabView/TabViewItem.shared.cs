namespace CommunityToolkit.Maui.Views;

/// <summary>
/// The tab view item.
/// </summary>
[ContentProperty(nameof(Content))]
public partial class TabViewItem : ContentView
{
	///// <summary>
	///// Gets or sets the <see cref="IView"/> to be displayed when the <see cref="TabViewItem"/> is selected
	///// </summary>
	//public static readonly BindableProperty TabConentViewProperty = BindableProperty.Create(nameof(TabConentView), typeof(IView), typeof(TabViewItem), default(View));

	///// <summary>
	///// Gets or sets the <see cref="IView"/> to be displayed when the <see cref="TabViewItem"/> is selected
	///// </summary>
	//public IView? TabConentView
	//{
	//	get => (IView?)GetValue(TabConentViewProperty);
	//	set => SetValue(TabConentViewProperty, value);
	//}

	/// <summary>
	/// Gets or sets the icon.
	/// </summary>
	public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(TabViewItem), string.Empty);
	/// <summary>
	/// Gets or sets the icon.
	/// </summary>
	public string Icon
	{
		get => (string)GetValue(IconProperty);
		set => SetValue(IconProperty, value);
	}

	/// <summary>
	/// Gets or sets a value indicating whether seperator is visible.
	/// </summary>
	public static readonly BindableProperty IsSeperatorVisibleProperty = BindableProperty.Create(nameof(IsSeperatorVisible), typeof(bool), typeof(TabViewItem), true);

	/// <summary>
	/// Gets or sets a value indicating whether seperator is visible.
	/// </summary>
	public bool? IsSeperatorVisible
	{
		get => (bool)GetValue(IsSeperatorVisibleProperty);
		set => SetValue(IsSeperatorVisibleProperty, value);
	}

	/// <summary>
	/// Gets or sets the text.
	/// </summary>
	public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TabViewItem));
	/// <summary>
	/// Gets or sets the text.
	/// </summary>
	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}
	/// <summary>
	/// Gets or sets the text color.
	/// </summary>
	public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(TabViewItem), default(Color));
	/// <summary>
	/// Gets or sets the text color.
	/// </summary>
	public Color TextColor
	{
		get => (Color)GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}
	/// <summary>
	/// Gets or sets the text color selected.
	/// </summary>
	public static readonly BindableProperty TextColorSelectedProperty = BindableProperty.Create(nameof(TextColorSelected), typeof(Color), typeof(TabViewItem), default(Color));
	/// <summary>
	/// Gets or sets the text color selected.
	/// </summary>
	public Color TextColorSelected
	{
		get => (Color)GetValue(TextColorSelectedProperty);
		set => SetValue(TextColorSelectedProperty, value);
	}
	/// <summary>
	/// Gets or sets the font size.
	/// </summary>
	public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(TabViewItem), default(double));
	/// <summary>
	/// Gets or sets the font size.
	/// </summary>
	public double FontSize
	{
		get => (double)GetValue(FontSizeProperty);
		set => SetValue(FontSizeProperty, value);
	}

	/// <summary>
	/// Gets or sets the <see cref="TabViewItem"/> footer
	/// </summary>
	public static readonly BindableProperty FooterProperty = BindableProperty.Create(nameof(Footer),
		typeof(IView), typeof(TabViewItem));

	/// <summary>
	/// Gets or sets the <see cref="TabViewItem"/> footer
	/// </summary>
	public IView Footer
	{
		get => (IView)GetValue(FooterProperty);
		set => SetValue(FooterProperty, value);
	}


	/// <summary>
	/// This property tracks if the <see cref="TabViewItem"/> is selected
	/// </summary>
	public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(TabViewItem), false);

	/// <summary>
	/// This property tracks if the <see cref="TabViewItem"/> is selected
	/// </summary>
	public bool IsSelected
	{
		get => (bool)GetValue(IsSelectedProperty);
		set => SetValue(IsSelectedProperty, value);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="TabViewItem"/> class.
	/// </summary>
	public TabViewItem()
	{

	}

	///// <inheritdoc />
	//protected override void OnApplyTemplate()
	//{
	//	base.OnApplyTemplate();
	//}
}