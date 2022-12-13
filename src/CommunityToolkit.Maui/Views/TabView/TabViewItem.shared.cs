
using System.Data.Common;
using CommunityToolkit.Maui.Core;

namespace CommunityToolkit.Maui.Views;

/// <summary>
/// The tab view item.
/// </summary>
[ContentProperty(nameof(TabViewContent))]
public partial class TabViewItem : ContentView, ITabViewItem
{
	/// <summary>
	/// Name of the style for the <see cref="TabViewItem"/> indicator's label
	/// </summary>
	public const string LabelStyle = "TabViewItemLabelStyle";
	/// <summary>
	/// Name of the style for the <see cref="TabViewItem"/> indicator's icon
	/// </summary>
	public const string ImageStyle = "TabViewItemImageStyle";
	/// <summary>
	/// Name of the style for the <see cref="TabViewItem"/> indicator's layout
	/// </summary>
	public const string LayoutStyle = "TabViewItemLayoutStyle";


	/// <summary>
	/// Gets or sets the icon.
	/// </summary>
	public static readonly BindableProperty TabViewContentProperty = BindableProperty.Create(nameof(TabViewContent), typeof(IView), typeof(TabViewItem), propertyChanged: TabViewContentPropertyChanged);

	static void TabViewContentPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
	{
		if (bindable is TabViewIndicator tvi)
		{
			//TODO: Tell the TabView that the content should be updated
		}
	}

	/// <summary>
	/// Gets or sets the icon.
	/// </summary>
	public IView? TabViewContent
	{
		get => (IView)GetValue(TabViewContentProperty);
		set => SetValue(TabViewContentProperty, value);
	}

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
	/// Gets or sets a value indicating whether separator is visible.
	/// </summary>
	public static readonly BindableProperty IsSeparatorVisibleProperty = BindableProperty.Create(nameof(IsSeparatorVisible), typeof(bool), typeof(TabViewItem), true);
	/// <summary>
	/// Gets or sets a value indicating whether separator is visible.
	/// </summary>
	public bool? IsSeparatorVisible
	{
		get => (bool)GetValue(IsSeparatorVisibleProperty);
		set => SetValue(IsSeparatorVisibleProperty, value);
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
	
	///// <summary>
	///// Gets or sets the tab indicator's background color.
	///// </summary>
	//public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(TabViewItem), Brush.Transparent);
	///// <summary>
	///// Gets or sets the tab indicator's background color.
	///// </summary>
	//public Color BackgroundColor
	//{
	//	get => (Color)GetValue(BackgroundColorProperty);
	//	set => SetValue(BackgroundColorProperty, value);
	//}

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

	
	internal static readonly BindablePropertyKey LabelTextColorPropertyKey =
		BindableProperty.CreateReadOnly(nameof(LabelTextColor), typeof(Color), typeof(TabViewItem.TabViewItemIndicator),
			Colors.White);

	/// <summary>
	/// Gets or sets the label's text color.
	/// </summary>
	public static readonly BindableProperty LabelTextColorProperty = LabelTextColorPropertyKey.BindableProperty;


	/// <summary>
	/// Gets or sets the label's text color.
	/// </summary>
	public Color LabelTextColor
	{
		get => (Color)GetValue(LabelTextColorProperty);
		internal set => SetValue(LabelTextColorPropertyKey, value);
	}

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
	public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(TabViewItem), false, propertyChanged: OnIsSelectedChanged);

	static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is TabViewItem tabViewItem)
		{
			tabViewItem.UpdateIndicator((bool)newValue);
		}
	}

	/// <summary>
	/// This property tracks if the <see cref="TabViewItem"/> is selected
	/// </summary>
	public bool IsSelected
	{
		get => (bool)GetValue(IsSelectedProperty);
		set => SetValue(IsSelectedProperty, value);
	}

	/// <summary>
	/// Update the <see cref="TabViewItemIndicator.NameLabel"/> to 
	/// </summary>
	/// <param name="isSelected"></param>
	public void UpdateIndicator(bool isSelected)
	{
		LabelTextColor = isSelected ? TextColorSelected : TextColor;
	}

	internal TabViewItemIndicator TabViewItemIndicatorView;

	/// <summary>
	/// Initializes a new instance of the <see cref="TabViewItem"/> class.
	/// </summary>
	public TabViewItem()
	{
		TabViewItemIndicatorView = new TabViewItemIndicator
		{
			BindingContext = this
		};
	}

	internal class TabViewItemIndicator : Frame
	{
		Grid NameLabel => CreateNameLabel();

		static Grid CreateNameLabel()
		{
			var labelGrid = new Grid
			{
				ColumnSpacing = 0,
				RowDefinitions =
					{
						new RowDefinition(GridLength.Auto),
						new RowDefinition(GridLength.Star),
					},
			};

			labelGrid.SetBinding(Grid.BackgroundColorProperty,
				nameof(TabViewItem.BackgroundColor));

			Image labelIcon = new()
			{
				Margin = new Thickness(5),
			};

			labelIcon.SetBinding(Image.SourceProperty, nameof(TabViewItem.Icon), BindingMode.OneWay);

			var labelText = new Label();

			labelText.SetBinding(Label.TextProperty, nameof(TabViewItem.Text));
			labelText.SetBinding(Label.TextColorProperty, nameof(TabViewItem.LabelTextColor));
			//labelText.SetBinding(Label.TextColorProperty, new Binding(nameof(TabViewItem.TabViewItemIndicator.LabelTextColor), source: new RelativeBindingSource(RelativeBindingSourceMode.Self)));
			labelText.SetBinding(Label.FontSizeProperty, nameof(TabViewItem.FontSize));

			labelGrid.Add(labelIcon);
			labelGrid.Add(labelText);

			labelGrid.SetRow(labelIcon, 0);
			labelGrid.SetRow(labelText, 1);

			return labelGrid;
		}

		BoxView Seperator
		{
			get
			{
				var seperator = new BoxView()
				{
					HeightRequest = 1,
					Margin = new Thickness(10, 0),
				};

				seperator.SetBinding(BoxView.IsVisibleProperty, nameof(TabViewItem.IsSeparatorVisible), BindingMode.OneWay);
				return seperator;
			}
		}


		//TODO: Create a bindable prop `TabViewItem.FooterView` of type IView and set visible only if provided with a value
		IView Footer
		{
			get
			{
				var footer = new ContentView { Padding = 5 };

				footer.SetBinding(ContentView.ContentProperty, nameof(TabViewItem.Footer), BindingMode.OneWay);

				footer.IsVisible = false;

				return footer;
			}
		}

		public TabViewItemIndicator()
		{
			CornerRadius = 2;
			Background = Brush.Transparent;
			HasShadow = true;

			var container = new Grid
			{
				RowSpacing = 0,

				RowDefinitions = new()
				{
					new RowDefinition() { Height = GridLength.Auto },
					new RowDefinition() { Height = 1 },
					new RowDefinition() { Height = GridLength.Auto },
				},

				Children =
				{
					NameLabel,
					Seperator,
					Footer,
				}
			}; 

			container.SetRow(NameLabel, 0);
			container.SetRow(Seperator, 1);
			container.SetRow(Footer, 2);

			this.Content = container;
		}

	}
}