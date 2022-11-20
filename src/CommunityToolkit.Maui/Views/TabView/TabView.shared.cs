using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CommunityToolkit.Maui.Helpers;

namespace CommunityToolkit.Maui.Views;
/// <summary>
/// The tab view.
/// </summary>
[ContentProperty(nameof(TabItems))]
public partial class TabView : ContentView, IDisposable
{
	bool disposedValue;


	/// <summary>
	/// Provides an 
	/// </summary>
	public static readonly BindableProperty TabItemsSourceProperty = BindableProperty.Create(nameof(TabItemsSource), typeof(IList), typeof(TabView), propertyChanged: OnTabItemsSourceChanged);

	static void OnTabItemsSourceChanged(BindableObject bindable, object oldvalue, object newvalue)
	{

		((TabView)bindable).UpdateTabItemsSource();
	}

	/// <summary>
	/// Gets or sets the tab items source.
	/// </summary>
	public IList? TabItemsSource
	{
		get => GetValue(TabItemsSourceProperty) as IList;
		set => SetValue(TabItemsSourceProperty, value);
	}

	/// <summary>
	/// <see cref="ObservableCollection{TabViewItem}"/> to be displayed
	/// </summary>
	public static readonly BindableProperty TabItemsProperty = BindableProperty.Create(nameof(TabItems), typeof(ObservableCollection<TabViewItem>), typeof(TabView), defaultValueCreator: _ => new ObservableCollection<TabViewItem>(), propertyChanged: OnTabItemsChanged);

	static void OnTabItemsChanged(BindableObject bindable, object oldvalue, object newvalue)
	{
		((TabView)bindable).UpdateTabs();
	}

	/// <summary>
	/// Gets or sets the <see cref="ObservableCollection{TabViewItem}"/> to be displayed
	/// </summary>
	public ObservableCollection<TabViewItem> TabItems
	{
		get => (ObservableCollection<TabViewItem>)GetValue(TabItemsProperty);
		set => SetValue(TabItemsProperty, value);
	}


	public static readonly BindableProperty TabViewItemDataTemplateProperty = BindableProperty.Create(nameof(TabViewItemDataTemplate), typeof(DataTemplate), typeof(TabView), defaultValue: new TabViewItemDataTemplate());
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

	//TODO: Guard clauses to ensure that the value when set is valid for the current TabItems collection size
	public static readonly BindableProperty SelectedTabIndexProperty = BindableProperty.Create(nameof(SelectedTabIndex), typeof(int), typeof(TabView), defaultValue: 0, propertyChanged: OnSelectedTabChanged);

	/// <summary>
	/// Gets or sets the selected index.
	/// </summary>
	public int SelectedTabIndex
	{
		get => (int)GetValue(SelectedTabIndexProperty);
		set => SetValue(SelectedTabIndexProperty, value);
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

	public static readonly BindableProperty TabStripHeightProperty = BindableProperty.Create(nameof(TabStripHeight), typeof(double), typeof(TabView), 70d);
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

	public static readonly BindableProperty TabIndicatorViewProperty = BindableProperty.Create(nameof(TabIndicatorView), typeof(View), typeof(TabView), default);
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

	readonly WeakEventManager<SelectionChangedEventArgs> selectionChangedManager = new();
	readonly WeakEventManager<TabViewScrolledEventArgs> tabViewScrolledManager = new();
	IList<TabViewItem> tabItemsInternal;

	public event EventHandler<SelectionChangedEventArgs> SelectionChanged
	{
		add => selectionChangedManager.AddEventHandler(value);
		remove => selectionChangedManager.RemoveEventHandler(value);
	}

	public event EventHandler<TabViewScrolledEventArgs> Scrolled
	{
		add => tabViewScrolledManager.AddEventHandler(value);
		remove => tabViewScrolledManager.RemoveEventHandler(value);
	}

	static void OnSelectedTabChanged(BindableObject sender, object oldValue, object value)
	{
		if (sender is TabView tabView)
		{
			tabView.CurrentTab = tabView.TabItems[(int)value];
			tabView.CurrentTab.IsSelected = true;

			tabView.TabContentContainer.Content = tabView.CurrentTab.TabConentView as View;
		}
	}

	/// <inheritdoc/>
	public TabViewItem? CurrentTab { get; set; }

	#region UI Members
	CollectionView TabContainer { get; } = CreateTabContainer();

	static CollectionView CreateTabContainer() => new()
	{
		ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal),
		HorizontalOptions = LayoutOptions.Center,
		VerticalOptions = LayoutOptions.Start,
	};

	Grid TabViewContainer { get; } = CreateTabViewContainer();

	static Grid CreateTabViewContainer() => new Grid
	{
		HorizontalOptions = LayoutOptions.Fill,
		VerticalOptions = LayoutOptions.Center
	};

	ScrollView TabContentContainer { get; } = CreateTabContentContainer();

	static ScrollView CreateTabContentContainer() => new()
	{
		BackgroundColor = Colors.Transparent,
		HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
		VerticalOptions = LayoutOptions.Fill,
		Orientation = ScrollOrientation.Horizontal,
		Shadow = new Shadow()
	};

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
	public TabView()
	{
		this.tabItemsInternal = Array.Empty<TabViewItem>();
		TabItems.CollectionChanged += OnTabsCollectionChanged;

		TabContainer.BindingContext = this;
		TabContainer.ItemTemplate = new TabViewItemDataTemplate();

		TabViewContainer.AddRowDefinition(new() { Height = TabStripHeight });
		TabViewContainer.AddRowDefinition(new RowDefinition() { Height = GridLength.Star });

		TabViewContainer.Children.Add(TabContainer);

		TabViewContainer.SetRow(TabContainer, Convert.ToInt32(GridRow.TabItems));
		TabViewContainer.SetRow(TabContentContainer, Convert.ToInt32(GridRow.TabContent));

		TabViewContainer.SetColumn(TabContainer, Convert.ToInt32(GridColumn.Second));
		TabViewContainer.SetColumn(TabContentContainer, Convert.ToInt32(GridColumn.Second));



		InitializeTabItems();

		Content = TabViewContainer;

		Padding = new Thickness(0, 10, 0, 0);
	}

	void OnTabsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UpdateTabs();
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
						TabItems.Insert(index++, tab);
					}
				}
				break;
			case NotifyCollectionChangedAction.Remove:
				if (e.OldItems is not null && e.NewItems is not null)
				{
					for (int i = e.OldStartingIndex + (e.OldItems.Count - 1); i >= e.OldStartingIndex; i--)
					{
						TabItems.RemoveAt(i);
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
	protected TabViewItem CreateTabItem(object tabModel)
	{
		View? result;

		switch (TabViewItemDataTemplate)
		{
			case DataTemplateSelector selector:
			{
				var template = selector.SelectTemplate(tabModel, this);
				result = template.CreateContent() as View;
				break;
			}

			default:
				result = TabViewItemDataTemplate?.CreateContent() as View;
				break;
		}

		if (result is not TabViewItem resultTabViewItem)
		{
			throw new NullReferenceException($"The provided TabViewItemDataTemplate returned null when attempting to cast to View.");
		}

		resultTabViewItem.BindingContext = tabModel;

		return resultTabViewItem;
	}

	void UpdateTabItemsSource()
	{
		if (TabItemsSource is ObservableCollection<TabViewItem> source)
		{
			source.CollectionChanged += OnTabItemsSourceCollectionChanged;
		}

		InitializeTabItems();
	}

	void InitializeTabItems()
	{
		var i = 0;
		foreach (var tabModel in TabItems)
		{
			var tab = CreateTabItem(tabModel);
			tabItemsInternal.Insert(i++, tab);
		}

		UpdateTabs();
	}

	void UpdateTabs()
	{

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