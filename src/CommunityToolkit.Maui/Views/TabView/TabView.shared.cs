using System.Collections;
using Microsoft.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Helpers;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Sample.Helpers;

namespace CommunityToolkit.Maui.Views;
/// <summary>
/// The tab view.
/// </summary>
[ContentProperty(nameof(Tabs))]
public partial class TabView : ContentView
{
	bool disposedValue;

	public static readonly BindableProperty TabItemsSourceProperty = BindableProperty.Create(nameof(TabItemsSource), typeof(IList), typeof(TabView));
	/// <summary>
	/// Gets or sets the tab items source.
	/// </summary>
	public IList? TabItemsSource
	{
		get => GetValue(TabItemsSourceProperty) as IList;
		set
		{
			SetValue(TabItemsSourceProperty, value);
			UpdateTabItemsSource();
		}
	}


	public static readonly BindableProperty TabsProperty = BindableProperty.Create(nameof(Tabs), typeof(ObservableCollection<TabViewItem>), typeof(TabView),
		defaultValueCreator: _ => new ObservableCollection<TabViewItem>());
	/// <summary>
	/// Gets or sets the <see cref="TabViewItem"/> collection to be displayed
	/// </summary>
	public ObservableCollection<TabViewItem> Tabs
	{
		get => (ObservableCollection<TabViewItem>)GetValue(TabsProperty);
		set => SetValue(TabsProperty, value);
	}


	public static readonly BindableProperty TabViewItemDataTemplateProperty = BindableProperty.Create(nameof(TabViewItemDataTemplate), typeof(DataTemplate), typeof(TabView), defaultValueCreator: _ => new TabViewItem.DefaultTabViewItemTemplate());
	/// <summary>
	/// Gets or sets the tab view item data template.
	/// </summary>
	public DataTemplate? TabViewItemDataTemplate
	{
		get => GetValue(TabViewItemDataTemplateProperty) as DataTemplate;
		set => SetValue(TabViewItemDataTemplateProperty, value);
	}

	public static readonly BindableProperty TabContentDataTemplateProperty = BindableProperty.Create(nameof(TabContentDataTemplate), typeof(DataTemplate), typeof(TabView), null);
	/// <summary>
	/// Gets or sets the tab content data template.
	/// </summary>
	public DataTemplate? TabContentDataTemplate
	{
		get => GetValue(TabContentDataTemplateProperty) as DataTemplate;
		set => SetValue(TabContentDataTemplateProperty, value);
	}

	public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(TabView), 0);
	/// <summary>
	/// Gets or sets the selected index.
	/// </summary>
	public int SelectedIndex
	{
		get => (int)GetValue(SelectedIndexProperty);
		set => SetValue(SelectedIndexProperty, value);
	}

	public static readonly BindableProperty TabStripPlacementProperty = BindableProperty.Create(nameof(TabStripPlacement), typeof(TabStripPlacement), typeof(TabView), default(TabStripPlacement));
	/// <summary>
	/// Gets or sets the tab strip placement.
	/// </summary>
	public TabStripPlacement TabStripPlacement
	{
		get => (TabStripPlacement)GetValue(TabStripPlacementProperty);
		set => SetValue(TabStripPlacementProperty, value);
	}

	public static readonly BindableProperty TabStripBackgroundColorProperty = BindableProperty.Create(nameof(TabStripBackgroundColor), typeof(Color), typeof(TabView), default(Color));
	/// <summary>
	/// Gets or sets the tab strip background color.
	/// </summary>
	public Color TabStripBackgroundColor
	{
		get => (Color)GetValue(TabStripBackgroundColorProperty);
		set => SetValue(TabStripBackgroundColorProperty, value);
	}

	public static readonly BindableProperty TabStripBackgroundViewProperty = BindableProperty.Create(nameof(TabStripBackgroundView), typeof(View), typeof(TabView), null);
	/// <summary>
	/// Gets or sets the tab strip background view.
	/// </summary>
	public View? TabStripBackgroundView
	{
		get => GetValue(TabStripBackgroundViewProperty) as View;
		set => SetValue(TabStripBackgroundViewProperty, value);
	}

	public static readonly BindableProperty TabStripBorderColorProperty = BindableProperty.Create(nameof(TabStripBorderColor), typeof(Color), typeof(TabView), default(Color));
	/// <summary>
	/// Gets or sets the tab strip border color.
	/// </summary>
	public Color TabStripBorderColor
	{
		get => (Color)GetValue(TabStripBorderColorProperty);
		set => SetValue(TabStripBorderColorProperty, value);
	}

	public static readonly BindableProperty TabContentBackgroundColorProperty = BindableProperty.Create(nameof(TabContentBackgroundColor), typeof(Color), typeof(TabView), default(Color));
	/// <summary>
	/// Gets or sets the tab content background color.
	/// </summary>
	public Color TabContentBackgroundColor
	{
		get => (Color)GetValue(TabContentBackgroundColorProperty);
		set => SetValue(TabContentBackgroundColorProperty, value);
	}

	public static readonly BindableProperty TabStripHeightProperty = BindableProperty.Create(nameof(TabStripHeight), typeof(double), typeof(TabView), default(double));
	/// <summary>
	/// Gets or sets the tab strip height.
	/// </summary>
	public double TabStripHeight
	{
		get => (double)GetValue(TabStripHeightProperty);
		set => SetValue(TabStripHeightProperty, value);
	}

	public static readonly BindableProperty IsTabStripVisibleProperty = BindableProperty.Create(nameof(IsTabStripVisible), typeof(bool), typeof(TabView), true);
	/// <summary>
	/// Gets or sets a value indicating whether tab strip is visible.
	/// </summary>
	public bool IsTabStripVisible
	{
		get => (bool)GetValue(IsTabStripVisibleProperty);
		set => SetValue(IsTabStripVisibleProperty, value);
	}

	public static readonly BindableProperty TabContentHeightProperty = BindableProperty.Create(nameof(TabContentHeight), typeof(double), typeof(TabView), default(double));
	/// <summary>
	/// Gets or sets the tab content height.
	/// </summary>
	public double TabContentHeight
	{
		get => (double)GetValue(TabContentHeightProperty);
		set => SetValue(TabContentHeightProperty, value);
	}

	public static readonly BindableProperty TabIndicatorColorProperty = BindableProperty.Create(nameof(TabIndicatorColor), typeof(Color), typeof(TabView), default(Color));
	/// <summary>
	/// Gets or sets the tab indicator color.
	/// </summary>
	public Color TabIndicatorColor
	{
		get => (Color)GetValue(TabIndicatorColorProperty);
		set => SetValue(TabIndicatorColorProperty, value);
	}

	public static readonly BindableProperty TabIndicatorHeightProperty = BindableProperty.Create(nameof(TabIndicatorHeight), typeof(double), typeof(TabView), default(double));
	/// <summary>
	/// Gets or sets the tab indicator height.
	/// </summary>
	public double TabIndicatorHeight
	{
		get => (double)GetValue(TabIndicatorHeightProperty);
		set => SetValue(TabIndicatorHeightProperty, value);
	}

	public static readonly BindableProperty TabIndicatorWidthProperty = BindableProperty.Create(nameof(TabIndicatorWidth), typeof(double), typeof(TabView), default(double));
	/// <summary>
	/// Gets or sets the tab indicator width.
	/// </summary>
	public double TabIndicatorWidth
	{
		get => (double)GetValue(TabIndicatorWidthProperty);
		set => SetValue(TabIndicatorWidthProperty, value);
	}

	public static readonly BindableProperty TabIndicatorViewProperty = BindableProperty.Create(nameof(TabIndicatorView), typeof(View), typeof(TabView), null);
	/// <summary>
	/// Gets or sets the tab indicator view.
	/// </summary>
	public View? TabIndicatorView
	{
		get => GetValue(TabIndicatorViewProperty) as View;
		set => SetValue(TabIndicatorViewProperty, value);
	}

	public static readonly BindableProperty TabIndicatorPlacementProperty = BindableProperty.Create(nameof(TabIndicatorPlacement), typeof(TabIndicatorPlacement), typeof(TabView), default(TabIndicatorPlacement));
	/// <summary>
	/// Gets or sets the tab indicator placement.
	/// </summary>
	public TabIndicatorPlacement TabIndicatorPlacement
	{
		get => (TabIndicatorPlacement)GetValue(TabIndicatorPlacementProperty);
		set => SetValue(TabIndicatorPlacementProperty, value);
	}

	public static readonly BindableProperty IsTabTransitionEnabledProperty = BindableProperty.Create(nameof(IsTabTransitionEnabled), typeof(bool), typeof(TabView), true);
	/// <summary>
	/// Gets or sets a value indicating whether tab transition is enabled.
	/// </summary>
	public bool IsTabTransitionEnabled
	{
		get => (bool)GetValue(IsTabTransitionEnabledProperty);
		set => SetValue(IsTabTransitionEnabledProperty, value);
	}

	public static readonly BindableProperty IsSwipeEnabledProperty = BindableProperty.Create(nameof(IsSwipeEnabled), typeof(bool), typeof(TabView), false);
	/// <summary>
	/// Gets or sets the is swipe enabled.
	/// </summary>
	public string IsSwipeEnabled
	{
		get => (string)GetValue(IsSwipeEnabledProperty);
		set => SetValue(IsSwipeEnabledProperty, value);
	}

	readonly WeakEventManager<TabSelectionChangedEventArgs> selectionChangedManager = new();
	readonly WeakEventManager<TabViewScrolledEventArgs> tabViewScrolledManager = new();

	public event EventHandler<TabSelectionChangedEventArgs> SelectionChanged
	{
		add => selectionChangedManager.AddEventHandler(value);
		remove => selectionChangedManager.RemoveEventHandler(value);
	}

	public event EventHandler<TabViewScrolledEventArgs> Scrolled
	{
		add => tabViewScrolledManager.AddEventHandler(value);
		remove => tabViewScrolledManager.RemoveEventHandler(value);
	}

	#region UI Members

	INotifyCollectionChanged? internalTabItemSource;

	StackLayout TabContainer { get; } = CreateTabContainer();

	static StackLayout CreateTabContainer() => new()
	{
		Orientation = StackOrientation.Horizontal,
		HorizontalOptions = LayoutOptions.Center,
		VerticalOptions = LayoutOptions.Start,
		Spacing = 10u,
		MaximumHeightRequest = 200d,
		MinimumHeightRequest = 20d,
	};

	Grid TabViewContainer { get; } = CreateTabViewContainer();

	static Grid CreateTabViewContainer() => new Grid
	{
		HorizontalOptions = LayoutOptions.Fill,
		VerticalOptions = LayoutOptions.Fill
	};

	RowDefinition endRowDef;
	ColumnDefinition starColumnDef;

	ScrollView TabContentContainer { get; } = CreateTabContentContainer();

	static ScrollView CreateTabContentContainer()
	{
		return new ScrollView()
		{
			HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
			VerticalOptions = LayoutOptions.Fill,
			Orientation = ScrollOrientation.Horizontal,
			Shadow = new Shadow()
		};
	}

	enum GridColumn
	{
		First = 0,
		Second = 1,
		Third = 2
	}

	enum GridRow
	{
		TabItems = 0,
		TabContent = 1
	}

	#endregion

	/// <summary>
	/// Initializes a new instance of the <see cref="TabView"/> class.
	/// </summary>
	public TabView() : base()
	{
		Tabs = new ObservableCollection<TabViewItem>();
		Tabs.CollectionChanged += OnTabsCollectionChanged;


		endRowDef = new RowDefinition() { Height = GridLength.Star };
		starColumnDef = new ColumnDefinition() { Width = GridLength.Star };


		TabViewContainer.AddColumnDefinition(starColumnDef);
		TabViewContainer.AddColumnDefinition(new() { Width = GridLength.Auto });
		TabViewContainer.AddColumnDefinition(starColumnDef);
		
		TabViewContainer.AddRowDefinition(new() { Height = GridLength.Auto });
		TabViewContainer.AddRowDefinition(endRowDef);

		TabViewContainer.SetRow(TabContainer, (int)GridRow.TabItems);
		TabViewContainer.SetRow(TabContentContainer, (int)GridRow.TabContent);

		TabViewContainer.SetColumnSpan(TabContainer, (int)GridColumn.First | (int)GridColumn.Third);
		TabViewContainer.SetColumnSpan(TabContentContainer, (int)GridColumn.First | (int)GridColumn.Third);

		TabViewContainer.Children.Add(TabContainer);
		TabViewContainer.Children.Add(TabContentContainer);


		InitializeTabItems();

		Content = TabViewContainer;

		Padding = new Thickness(0, 10, 0, 0);
	}

	protected override void OnBindingContextChanged()
	{
		base.OnBindingContextChanged();
	}

	protected virtual void OnTabsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		InitializeTabItems();
	}

	void OnTabItemsSourceCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
			case NotifyCollectionChangedAction.Add:
				var index = e.NewStartingIndex;
				if (e.NewItems is not null)
				{
					foreach (var item in e.NewItems)
					{
						var tab = CreateTabItem(item);
						Tabs.Insert(index++, tab);
					}
				}
				break;
			case NotifyCollectionChangedAction.Remove:
				if (e.OldItems is not null && e.NewItems is not null)
				{
					for (int i = e.OldStartingIndex + (e.OldItems.Count - 1); i >= e.OldStartingIndex; i--)
					{
						Tabs.RemoveAt(i);
					}
				}
				break;
			default:
				throw new NotSupportedException("TabItemsSource only supports Add and Remove actions.");
		}
	}

	/// <summary>
	/// Create a new <see cref="TabViewItem"/> from a given <paramref name="tabModel"/>
	/// </summary>
	/// <param name="tabModel">The model from which the tab is to be created</param>
	protected virtual TabViewItem CreateTabItem(object tabModel)
	{
		View? result;

		if (TabViewItemDataTemplate is DataTemplateSelector selector)
		{
			var template = selector.SelectTemplate(tabModel, this);
			result = template.CreateContent() as View;
		}
		else
		{
			result = tabModel switch
			{
				TabViewItem tabViewItem => tabViewItem,
				_ => TabViewItemDataTemplate?.CreateContent() as View,
			};
		}

		if (result is not TabViewItem tabItemResult)
		{
			throw new InvalidOperationException($"The {nameof(TabViewItemDataTemplate)} should provide a content View which inherits from {nameof(TabViewItem)}");
		}

		tabItemResult.BindingContext = tabModel;

		return tabItemResult;
	}

	protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		base.OnPropertyChanged(propertyName);

		switch (propertyName)
		{
			case nameof(TabItemsSource):
				UpdateTabItemsSource();
				break;
			default:
				break;
		}
	}

	void UpdateTabItemsSource()
	{
		if (internalTabItemSource is not null)
		{
			internalTabItemSource.CollectionChanged -= OnTabItemsSourceCollectionChanged;
			internalTabItemSource = null;
		}
		if (TabItemsSource is INotifyCollectionChanged source)
		{
			internalTabItemSource = source;
			internalTabItemSource.CollectionChanged += OnTabItemsSourceCollectionChanged;
		}

		InitializeTabItems();
	}

	void InitializeTabItems()
	{
		foreach (var tab in Tabs)
		{
			var tabContent = (View)tab.ControlTemplate.CreateContent();

			TabContainer.Children.Add(tabContent);
		}
	}


	public virtual void OnSelectionChanged(object sender, TabSelectionChangedEventArgs args)
	{
		//TODO: Implement default OnSelectionChanged behavior
	}

	#region IDisposable Implementation

	/// <summary>
	/// Disposes the.
	/// </summary>
	/// <param name="disposing">If true, disposing.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				// TODO: dispose managed state (managed objects)
			}

			// TODO: set large fields to null
			disposedValue = true;
		}
	}

	/// <summary>
	/// Disposes the.
	/// </summary>
	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	#endregion
}