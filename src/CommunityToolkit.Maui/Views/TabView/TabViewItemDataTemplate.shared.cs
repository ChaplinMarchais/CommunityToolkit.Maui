using System.Globalization;
using Microsoft.Maui.Controls;

namespace CommunityToolkit.Maui.Views;

/// <summary>
/// Defines a <see cref="DataTemplate"/> for a <see cref="TabViewItem"/> instance
/// </summary>
public class TabViewItemDataTemplate : DataTemplate
{
	/// <summary>
	/// Instantiate new <see cref="TabViewItemDataTemplate"/>
	/// </summary>
	public TabViewItemDataTemplate() : base(CreateDataTemplate)
	{

	}

	enum Row { PaddingTop, Content, PaddingBottom }
	enum Column { PaddingLeft, Content, PaddingRight }


	static Grid CreateDataTemplate()
	{
		var tabItemCard = new TabItemCard();

		Grid.SetRow(tabItemCard, (int)Row.Content);
		Grid.SetColumn(tabItemCard, (int)Column.Content);

		var container = new Grid
		{

			RowDefinitions = new()
			{
				new RowDefinition() { Height = 6 },
				new RowDefinition() { Height = GridLength.Star },
				new RowDefinition() { Height = 6 },
			},

			ColumnDefinitions = new()
			{
				new ColumnDefinition() { Width = 6 },
				new ColumnDefinition() { Width = GridLength.Star },
				new ColumnDefinition() { Width = 6 },
			},
		};

		var templateBinding = new Binding();
		templateBinding.Source = new RelativeBindingSource(RelativeBindingSourceMode.TemplatedParent);
		container.BindingContext = templateBinding;

		container.Add(tabItemCard);

		return container;
	}

	class TabItemCard : Frame
	{
		enum Rows { Title, Seperator, Footer }

		static Label NameLabel
		{
			get
			{
				var nameLabel = new Label();

				nameLabel.SetValue(Grid.RowProperty, ToInt(Rows.Title));

				nameLabel.SetBinding(Label.TextProperty, nameof(TabViewItem.Text));
				nameLabel.SetBinding(Label.TextColorProperty, nameof(TabViewItem.TextColor), BindingMode.OneWay);
				nameLabel.SetBinding(Label.FontSizeProperty, nameof(TabViewItem.FontSize), BindingMode.OneWay);

				return nameLabel;
			}
		}

		static BoxView Seperator
		{
			get
			{
				var seperator = new BoxView()
				{
					HeightRequest = 1,
					Margin = new Thickness(10, 0, 10, 0),
				};

				seperator.SetValue(Grid.RowProperty, ToInt(Rows.Seperator));

				seperator.SetBinding(BoxView.IsVisibleProperty, nameof(TabViewItem.IsSeperatorVisible), BindingMode.OneWay);

				return seperator;
			}
		}

		static IView Footer
		{
			get
			{
				var footer = new ContentView { Padding = 5 };

				footer.SetValue(Grid.RowProperty, ToInt(Rows.Footer));
				footer.SetBinding(ContentView.ContentProperty, nameof(TabViewItem.Footer), BindingMode.OneWay);

				return footer;
			}
		}

		public TabItemCard()
		{
			CornerRadius = 8;

			HasShadow = true;

			Content = new Grid
			{
				RowSpacing = 4,

				RowDefinitions = new()
				{
					new RowDefinition() { Height = GridLength.Auto },
					new RowDefinition() { Height = 1 },
					new RowDefinition() { Height = GridLength.Star },
				},

				Children =
				{
					NameLabel,
					Seperator,
					Footer,
				}
			};
		}
	}

	static int ToInt(Enum value)
	{
		return Convert.ToInt32(value, CultureInfo.InvariantCulture);
	}
}