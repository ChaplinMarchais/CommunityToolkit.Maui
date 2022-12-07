using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Helpers;
using CommunityToolkit.Maui.Layouts;

namespace CommunityToolkit.Maui.Views;
/// <summary>
/// The tab view.
/// </summary>
[ContentProperty(nameof(TabItems))]
public partial class TabView : ContentView, IDisposable, ITabView
{
	bool disposedValue;


	/// <summary>
	/// Provides an 
	/// </summary>
	public static readonly BindableProperty TabItemsSourceProperty = BindableProperty.Create(nameof(TabItemsSource), typeof(IList), typeof(TabView));

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
	public static readonly BindableProperty TabItemsProperty = BindableProperty.Create(nameof(TabItems), typeof(ObservableCollection<ITabViewItem>), typeof(TabView), defaultValueCreator: _ => new ObservableCollection<ITabViewItem>());

	/// <summary>
	/// Gets or sets the <see cref="ObservableCollection{ITabViewItem}"/> to be displayed
	/// </summary>
	public ObservableCollection<ITabViewItem> TabItems
	{
		get => (ObservableCollection<ITabViewItem>) GetValue(TabItemsProperty);
		set => SetValue(TabItemsProperty, value);
	}

	/// <summary>
	/// Gets or sets the tab view item data template.
	/// </summary>
	public static readonly BindableProperty TabIndicatorDataTemplateProperty = BindableProperty.Create(nameof(TabIndicatorDataTemplate), typeof(DataTemplate), typeof(TabView), defaultValue: null);
	/// <summary>
	/// Gets or sets the tab view item data template.
	/// </summary>
	public DataTemplate? TabIndicatorDataTemplate
	{
		get => GetValue(TabIndicatorDataTemplateProperty) as DataTemplate;
		set => SetValue(TabIndicatorDataTemplateProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab content data template.
	/// </summary>
	public static readonly BindableProperty TabContentDataTemplateProperty = BindableProperty.Create(nameof(TabContentDataTemplate), typeof(DataTemplate), typeof(TabView), null);
	/// <summary>
	/// Gets or sets the tab content data template.
	/// </summary>
	public DataTemplate? TabContentDataTemplate
	{
		get => GetValue(TabContentDataTemplateProperty) as DataTemplate;
		set => SetValue(TabContentDataTemplateProperty, value);
	}

	/// <summary>
	/// Gets or sets the selected index.
	/// </summary>
	//TODO: Guard clauses to ensure that the value when set is valid for the current TabItems collection size
	public static readonly BindableProperty SelectedTabIndexProperty = BindableProperty.Create(nameof(SelectedTabIndex), typeof(int), typeof(TabView), defaultValue: 0, propertyChanged: SelectedTabIndexChanged);

	static void SelectedTabIndexChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is TabView tabView)
		{
			tabView.TabItems[(int) oldValue].IsSelected = false;
			tabView.TabItems[(int) newValue].IsSelected = true;
		}
	}

	/// <summary>
	/// Gets or sets the selected index.
	/// </summary>
	public int SelectedTabIndex
	{
		get => (int)GetValue(SelectedTabIndexProperty);
		set => SetValue(SelectedTabIndexProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab strip placement.
	/// </summary>
	public static readonly BindableProperty TabStripPlacementProperty = BindableProperty.Create(nameof(TabStripPlacement), typeof(TabStripPlacement), typeof(TabView), default(TabStripPlacement));
	/// <summary>
	/// Gets or sets the tab strip placement.
	/// </summary>
	public TabStripPlacement TabStripPlacement
	{
		get => (TabStripPlacement)GetValue(TabStripPlacementProperty);
		set => SetValue(TabStripPlacementProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab strip background color.
	/// </summary>
	public static readonly BindableProperty TabStripBackgroundColorProperty = BindableProperty.Create(nameof(TabStripBackgroundColor), typeof(Color), typeof(TabView), default(Color));
	/// <summary>
	/// Gets or sets the tab strip background color.
	/// </summary>
	public Color TabStripBackgroundColor
	{
		get => (Color)GetValue(TabStripBackgroundColorProperty);
		set => SetValue(TabStripBackgroundColorProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab strip background view.
	/// </summary>
	public static readonly BindableProperty TabStripBackgroundViewProperty = BindableProperty.Create(nameof(TabStripBackgroundView), typeof(IView), typeof(TabView), null);
	/// <summary>
	/// Gets or sets the tab strip background view.
	/// </summary>
	public IView? TabStripBackgroundView
	{
		get => GetValue(TabStripBackgroundViewProperty) as View;
		set => SetValue(TabStripBackgroundViewProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab strip border color.
	/// </summary>
	public static readonly BindableProperty TabStripBorderColorProperty = BindableProperty.Create(nameof(TabStripBorderColor), typeof(Color), typeof(TabView), default(Color));
	/// <summary>
	/// Gets or sets the tab strip border color.
	/// </summary>
	public Color TabStripBorderColor
	{
		get => (Color)GetValue(TabStripBorderColorProperty);
		set => SetValue(TabStripBorderColorProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab content background color.
	/// </summary>
	public static readonly BindableProperty TabContentBackgroundColorProperty = BindableProperty.Create(nameof(TabContentBackgroundColor), typeof(Color), typeof(TabView), default(Color));
	/// <summary>
	/// Gets or sets the tab content background color.
	/// </summary>
	public Color TabContentBackgroundColor
	{
		get => (Color)GetValue(TabContentBackgroundColorProperty);
		set => SetValue(TabContentBackgroundColorProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab strip height.
	/// </summary>
	public static readonly BindableProperty TabStripHeightProperty = BindableProperty.Create(nameof(TabStripHeight), typeof(double), typeof(TabView), 70d);
	/// <summary>
	/// Gets or sets the tab strip height.
	/// </summary>
	public double TabStripHeight
	{
		get => (double)GetValue(TabStripHeightProperty);
		set => SetValue(TabStripHeightProperty, value);
	}
	/// <summary>
	/// Gets or sets a value indicating whether tab strip is visible.
	/// </summary>
	public static readonly BindableProperty IsTabStripVisibleProperty = BindableProperty.Create(nameof(IsTabStripVisible), typeof(bool), typeof(TabView), true);
	/// <summary>
	/// Gets or sets a value indicating whether tab strip is visible.
	/// </summary>
	public bool IsTabStripVisible
	{
		get => (bool)GetValue(IsTabStripVisibleProperty);
		set => SetValue(IsTabStripVisibleProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab content height.
	/// </summary>
	public static readonly BindableProperty TabContentHeightProperty = BindableProperty.Create(nameof(TabContentHeight), typeof(double), typeof(TabView), default(double));
	/// <summary>
	/// Gets or sets the tab content height.
	/// </summary>
	public double TabContentHeight
	{
		get => (double)GetValue(TabContentHeightProperty);
		set => SetValue(TabContentHeightProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab indicator color.
	/// </summary>
	public static readonly BindableProperty TabIndicatorColorProperty = BindableProperty.Create(nameof(TabIndicatorColor), typeof(Color), typeof(TabView), default(Color));
	/// <summary>
	/// Gets or sets the tab indicator color.
	/// </summary>
	public Color TabIndicatorColor
	{
		get => (Color)GetValue(TabIndicatorColorProperty);
		set => SetValue(TabIndicatorColorProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab indicator height.
	/// </summary>
	public static readonly BindableProperty TabIndicatorHeightProperty = BindableProperty.Create(nameof(TabIndicatorHeight), typeof(double), typeof(TabView), default(double));
	/// <summary>
	/// Gets or sets the tab indicator height.
	/// </summary>
	public double TabIndicatorHeight
	{
		get => (double)GetValue(TabIndicatorHeightProperty);
		set => SetValue(TabIndicatorHeightProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab indicator width.
	/// </summary>
	public static readonly BindableProperty TabIndicatorWidthProperty = BindableProperty.Create(nameof(TabIndicatorWidth), typeof(double), typeof(TabView), default(double));
	/// <summary>
	/// Gets or sets the tab indicator width.
	/// </summary>
	public double TabIndicatorWidth
	{
		get => (double)GetValue(TabIndicatorWidthProperty);
		set => SetValue(TabIndicatorWidthProperty, value);
	}
	/// <summary>
	/// Gets or sets the tab indicator view.
	/// </summary>
	public static readonly BindableProperty TabIndicatorViewProperty = BindableProperty.Create(nameof(TabIndicatorView), typeof(View), typeof(TabView), default);
	/// <summary>
	/// Gets or sets the tab indicator view.
	/// </summary>
	public IView? TabIndicatorView	
	{
		get => (View)GetValue(TabIndicatorViewProperty);
		set => SetValue(TabIndicatorViewProperty, value);
	}

	/// <summary>
	/// Gets or sets the tab indicator placement.
	/// </summary>
	public static readonly BindableProperty TabIndicatorPlacementProperty = BindableProperty.Create(nameof(TabIndicatorPlacement), typeof(TabIndicatorPlacement), typeof(TabView), default(TabIndicatorPlacement));
	/// <summary>
	/// Gets or sets the tab indicator placement.
	/// </summary>
	public TabIndicatorPlacement TabIndicatorPlacement
	{
		get => (TabIndicatorPlacement)GetValue(TabIndicatorPlacementProperty);
		set => SetValue(TabIndicatorPlacementProperty, value);
	}

	/// <summary>
	/// Gets or sets a value indicating whether tab transition is enabled.
	/// </summary>
	public static readonly BindableProperty IsTabTransitionEnabledProperty = BindableProperty.Create(nameof(IsTabTransitionEnabled), typeof(bool), typeof(TabView), true);
	/// <summary>
	/// Gets or sets a value indicating whether tab transition is enabled.
	/// </summary>
	public bool IsTabTransitionEnabled
	{
		get => (bool)GetValue(IsTabTransitionEnabledProperty);
		set => SetValue(IsTabTransitionEnabledProperty, value);
	}

	/// <summary>
	/// Gets or sets the IsSwipeEnabled property.
	/// </summary>
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

	/// <summary>
	/// This event is called whenever the selected <see cref="TabViewItem"/> is changed.
	/// </summary>
	public event EventHandler<SelectionChangedEventArgs> SelectionChanged
	{
		add => selectionChangedManager.AddEventHandler(value);
		remove => selectionChangedManager.RemoveEventHandler(value);
	}

	/// <summary>
	/// This event is called whenever the <see cref="TabView"/>host object detects a scroll within the TabView.TabContent component.
	/// </summary>
	public event EventHandler<TabViewScrolledEventArgs> Scrolled
	{
		add => tabViewScrolledManager.AddEventHandler(value);
		remove => tabViewScrolledManager.RemoveEventHandler(value);
	}

	/// <inheritdoc/>
	public ITabViewItem? CurrentTab => TabItems.ElementAtOrDefault(SelectedTabIndex);

	/// <summary>
	/// Gets the currently displayed content for the selected <see cref="TabViewItem"/>
	/// </summary>
	public IView TabContentView { get; internal set; } = new Frame();

	/// <summary>
	/// Initializes a new instance of the <see cref="TabView"/> class.
	/// </summary>
	public TabView()
	{
		TabItems.CollectionChanged += OnTabItemsCollectionChanged;
		InitializeTabItems();

		TabIndicatorView = new UniformItemsLayout
		{
			BindingContext = this,
			MaxRows = 1,
		};

		((View)TabIndicatorView).SetBinding(HorizontalStackLayout.BackgroundColorProperty, nameof(TabView.TabIndicatorColor));

		var contentGrid = new Grid
		{
			RowDefinitions =
			{
				new RowDefinition(GridLength.Star),
				new RowDefinition(GridLength.Auto),
			},
		};

		contentGrid.SetRow(TabContentView, 0);
		contentGrid.SetRow(TabIndicatorView, 1);

		contentGrid.Add(TabContentView);
		contentGrid.Add(TabIndicatorView);

		Content = contentGrid;

		Padding = new Thickness(0, 10, 0, 0);
	}

	void OnTabItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (TabIndicatorView is null)
		{
			return;
		}

		switch (e.Action)
		{
			case NotifyCollectionChangedAction.Add:
				var index = e.NewStartingIndex;
				if (e.NewItems is not null)
				{
					foreach (var item in e.NewItems)
					{
						var tab = CreateTabIndicator(item);
						((UniformItemsLayout)TabIndicatorView).Insert(index++, tab);
					}
				}
				break;
			case NotifyCollectionChangedAction.Remove:
				if (e.OldItems is not null && e.NewItems is not null)
				{
					for (int i = e.OldStartingIndex + (e.OldItems.Count - 1); i >= e.OldStartingIndex; i--)
					{
						((UniformItemsLayout)TabIndicatorView).RemoveAt(i);
					}
				}
				break;
			default:
				throw new NotSupportedException("TabItemsSource only supports Add and Remove actions.");
		}
	}

	View CreateTabIndicator(object tabModel)
	{
		View? result;

		var tabViewItem = tabModel as TabViewItem
		                  ?? throw new InvalidCastException(
			                  $"Failed to cast the parameter tabModel to {nameof(TabViewItem)}");

		switch (TabIndicatorDataTemplate)
		{
			case DataTemplateSelector selector:
			{
				var template = selector.SelectTemplate(tabViewItem, this);
				result = template.CreateContent() as View;


				if (result is null)
				{
					throw new NullReferenceException(
						$"The provided TabIndicatorDataTemplate returned null when attempting to cast to View.");
				}

				break;
			}

			default:
				result = ((TabViewItem) tabViewItem).TabViewItemIndicatorView;
				break;
		}

		result.BindingContext = tabViewItem;

		return result;
	}

	void InitializeTabItems()
	{
		foreach (var tabModel in TabItems)
		{
			var tab = CreateTabIndicator(tabModel);
			TapGestureRecognizer tapGesture = new() { Command = new Command<TabViewItem>(OnTabViewItemSelected), CommandParameter = tab};
			tab.GestureRecognizers.Add(tapGesture);
			
			if(TabIndicatorView is StackLayout tabIndicatorView)
			{
				tabIndicatorView.Add(tab);
			}
		}
	}

	void OnTabViewItemSelected(Element element) => OnTabViewItemSelectedAsync(element).FireAndForget();

	Task OnTabViewItemSelectedAsync(Element element)
	{
		IView? contentView;

		switch (element)
		{
			case TabViewItem i:
				SelectedTabIndex = GetTabIndicatorIndex(i);
				contentView = i.Content;
				break;
			default:
				return Task.CompletedTask;
		}

		TabContentView = contentView;

		return Task.CompletedTask;
	}

	int GetTabIndicatorIndex(ITabViewItem tab) => TabItems.IndexOf(tab);

	#region IDisposable Implementation

	/// <summary>
	/// Disposes the.
	/// </summary>
	/// <param name="disposing">If true, disposing.</param>
	protected virtual void Dispose(bool disposing)/**/
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