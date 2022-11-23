using System.Data.Common;

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

	public static readonly BindableProperty LabelTextColorProperty = BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(TabViewItem.TabViewItemIndicator), default);
	/// <summary>
	/// Gets or sets the label's text color.
	/// </summary>
	public Color LabelTextColor
	{
		get => (Color)GetValue(LabelTextColorProperty);
		set => SetValue(LabelTextColorProperty, value);
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
			tabViewItem.UpdateTextColor((bool)newValue);
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

	public void UpdateTextColor(bool isSelected)
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



		//static void OnLabelTextColorChanged(BindableObject bindable, object oldValue, object newValue)
		//{
		//	var indicatorGrid = (Grid)bindable;

		//	var indicatorLabel = indicatorGrid.Children.FirstOrDefault(c => c.GetType() == typeof(Label)) as Label;

		//	if (indicatorLabel is not null)
		//	{
		//		indicatorLabel.TextColor = (Color)newValue;
		//	}
		//}



		enum Rows { Title = 0, Seperator = 1, Footer = 2 }

		Grid NameLabel { get; set; } = GetNameLabel();

		static Grid GetNameLabel()
		{
			var labelGrid = new Grid
			{
				Background = Brush.Transparent,
				ColumnSpacing = 0,
				RowDefinitions =
					{
						new RowDefinition(GridLength.Auto),
						new RowDefinition(GridLength.Star),
					},
			};

			Image labelIcon = new()
			{
				Margin = new Thickness(5),
			};

			labelIcon.SetBinding(Image.SourceProperty, nameof(TabViewItem.Icon), BindingMode.OneWay);

			var labelText = new Label();

			labelText.SetBinding(Label.TextProperty, nameof(TabViewItem.Text));
			labelText.SetBinding(Label.TextColorProperty, nameof(TabViewItem.LabelTextColor), BindingMode.OneWay);
			//labelText.SetBinding(Label.TextColorProperty, new Binding(nameof(TabViewItem.TabViewItemIndicator.LabelTextColor), source: new RelativeBindingSource(RelativeBindingSourceMode.Self)));
			labelText.SetBinding(Label.FontSizeProperty, nameof(TabViewItem.FontSize), BindingMode.OneWay);

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

				seperator.SetBinding(BoxView.IsVisibleProperty, nameof(TabViewItem.IsSeperatorVisible), BindingMode.OneWay);

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