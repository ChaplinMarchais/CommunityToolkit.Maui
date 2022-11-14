using System.Globalization;

namespace CommunityToolkit.Maui.Views;

public class TabViewItemDataTemplate : DataTemplate
{
	public TabViewItemDataTemplate() : base(CreateDataTemplate)
	{

	}

	enum Row { PaddingTop, Content, PaddingBottom }
	enum Column { PaddingLeft, Content, PaddingRight }


	static Grid CreateDataTemplate()
	{
		var tabItemCard = new TabItemCard();

		tabItemCard.SetValue(Grid.RowProperty, ToInt(Row.Content));
		tabItemCard.SetValue(Grid.ColumnProperty, ToInt(Column.Content));

		return new()
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

			Children = { tabItemCard }
		};
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

				nameLabel.SetBinding(Label.TextProperty, nameof(TabViewItem.Text), BindingMode.OneWay);
				nameLabel.SetBinding(Label.TextColorProperty, nameof(TabViewItem.TextColor), BindingMode.OneWay);

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

		public TabItemCard()
		{
			CornerRadius = 8;

			HasShadow = true;

			Content = new Grid
			{
				RowSpacing = 4,

				RowDefinitions = new()
				{
					new RowDefinition() { Height = 24 },
					new RowDefinition() { Height = 1 },
					new RowDefinition() { Height = GridLength.Star },
				},

				Children =
				{
					NameLabel,
					Seperator,
				}
			};
		}
	}

	static int ToInt(Enum value)
	{
		return Convert.ToInt32(value, CultureInfo.InvariantCulture);
	}
}