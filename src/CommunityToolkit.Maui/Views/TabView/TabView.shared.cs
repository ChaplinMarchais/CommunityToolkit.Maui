using System.Collections;
using Microsoft.Maui;
using CommunityToolkit.Maui.Core;

namespace IGT.FluidConnect.Controls;

[ContentProperty(nameof(Content))]
public class TabView : ContentView, IDisposable
{
    private bool disposedValue;

    public static readonly BindableProperty TabItemsSourceProperty = BindableProperty.Create(nameof(TabItemsSource), typeof(IList), typeof(TabView), null);
    public IList? TabItemsSource
    {
        get => GetValue(TabItemsSourceProperty) as IList;
        set => SetValue(TabItemsSourceProperty, value);
    }

    public static readonly BindableProperty TabViewItemDataTemplateProperty = BindableProperty.Create(nameof(TabViewItemDataTemplate), typeof(DataTemplate), typeof(TabView), null);
    public DataTemplate? TabViewItemDataTemplate
    {
        get => GetValue(TabViewItemDataTemplateProperty) as DataTemplate;
        set => SetValue(TabViewItemDataTemplateProperty, value);
    }

    public static readonly BindableProperty TabContentDataTemplateProperty = BindableProperty.Create(nameof(TabContentDataTemplate), typeof(DataTemplate), typeof(TabView), null);
    public DataTemplate? TabContentDataTemplate
    {
        get => GetValue(TabContentDataTemplateProperty) as DataTemplate;
        set => SetValue(TabContentDataTemplateProperty, value);
    }

    public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(TabView), 0);
    public int SelectedIndex
    {
        get => (int)GetValue(SelectedIndexProperty);
        set => SetValue(SelectedIndexProperty, value);
    }

    public static readonly BindableProperty TabStripPlacementProperty = BindableProperty.Create(nameof(TabStripPlacement), typeof(TabStripPlacement), typeof(TabView), default(TabStripPlacement));
    public TabStripPlacement TabStripPlacement
    {
        get => (TabStripPlacement)GetValue(TabStripPlacementProperty);
        set => SetValue(TabStripPlacementProperty, value);
    }

    public static readonly BindableProperty TabStripBackgroundColorProperty = BindableProperty.Create(nameof(TabStripBackgroundColor), typeof(Color), typeof(TabView), default(Color));
    public Color TabStripBackgroundColor
    {
        get => (Color)GetValue(TabStripBackgroundColorProperty);
        set => SetValue(TabStripBackgroundColorProperty, value);
    }

    public static readonly BindableProperty TabStripBackgroundViewProperty = BindableProperty.Create(nameof(TabStripBackgroundView), typeof(View), typeof(TabView), null);
    public View? TabStripBackgroundView
    {
        get => GetValue(TabStripBackgroundViewProperty) as View;
        set => SetValue(TabStripBackgroundViewProperty, value);
    }

    public static readonly BindableProperty TabStripBorderColorProperty = BindableProperty.Create(nameof(TabStripBorderColor), typeof(Color), typeof(TabView), default(Color));
    public Color TabStripBorderColor
    {
        get => (Color)GetValue(TabStripBorderColorProperty);
        set => SetValue(TabStripBorderColorProperty, value);
    }

    public static readonly BindableProperty TabContentBackgroundColorProperty = BindableProperty.Create(nameof(TabContentBackgroundColor), typeof(Color), typeof(TabView), default(Color));
    public Color TabContentBackgroundColor
    {
        get => (Color)GetValue(TabContentBackgroundColorProperty);
        set => SetValue(TabContentBackgroundColorProperty, value);
    }

    public static readonly BindableProperty TabStripHeightProperty = BindableProperty.Create(nameof(TabStripHeight), typeof(double), typeof(TabView), default(double));
    public double TabStripHeight
    {
        get => (double)GetValue(TabStripHeightProperty);
        set => SetValue(TabStripHeightProperty, value);
    }

    public static readonly BindableProperty IsTabStripVisibleProperty = BindableProperty.Create(nameof(IsTabStripVisible), typeof(bool), typeof(TabView), true);
    public bool IsTabStripVisible
    {
        get => (bool)GetValue(IsTabStripVisibleProperty);
        set => SetValue(IsTabStripVisibleProperty, value);
    }

    public static readonly BindableProperty TabContentHeightProperty = BindableProperty.Create(nameof(TabContentHeight), typeof(double), typeof(TabView), default(double));
    public double TabContentHeight
    {
        get => (double)GetValue(TabContentHeightProperty);
        set => SetValue(TabContentHeightProperty, value);
    }

    public static readonly BindableProperty TabIndicatorColorProperty = BindableProperty.Create(nameof(TabIndicatorColor), typeof(Color), typeof(TabView), default(Color));
    public Color TabIndicatorColor
    {
        get => (Color)GetValue(TabIndicatorColorProperty);
        set => SetValue(TabIndicatorColorProperty, value);
    }

    public static readonly BindableProperty TabIndicatorHeightProperty = BindableProperty.Create(nameof(TabIndicatorHeight), typeof(double), typeof(TabView), default(double));
    public double TabIndicatorHeight
    {
        get => (double)GetValue(TabIndicatorHeightProperty);
        set => SetValue(TabIndicatorHeightProperty, value);
    }

    public static readonly BindableProperty TabIndicatorWidthProperty = BindableProperty.Create(nameof(TabIndicatorWidth), typeof(double), typeof(TabView), default(double));
    public double TabIndicatorWidth
    {
        get => (double)GetValue(TabIndicatorWidthProperty);
        set => SetValue(TabIndicatorWidthProperty, value);
    }

    public static readonly BindableProperty TabIndicatorViewProperty = BindableProperty.Create(nameof(TabIndicatorView), typeof(View), typeof(TabView), null);
    public View? TabIndicatorView
    {
        get => GetValue(TabIndicatorViewProperty) as View;
        set => SetValue(TabIndicatorViewProperty, value);
    }

    public static readonly BindableProperty TabIndicatorPlacementProperty = BindableProperty.Create(nameof(TabIndicatorPlacement), typeof(TabIndicatorPlacement), typeof(TabView), default(TabIndicatorPlacement));
    public TabIndicatorPlacement TabIndicatorPlacement
    {
        get => (TabIndicatorPlacement)GetValue(TabIndicatorPlacementProperty);
        set => SetValue(TabIndicatorPlacementProperty, value);
    }

    public static readonly BindableProperty IsTabTransitionEnabledProperty = BindableProperty.Create(nameof(IsTabTransitionEnabled), typeof(bool), typeof(TabView), true);
    public bool IsTabTransitionEnabled
    {
        get => (bool)GetValue(IsTabTransitionEnabledProperty);
        set => SetValue(IsTabTransitionEnabledProperty, value);
    }

    public static readonly BindableProperty IsSwipeEnabledProperty = BindableProperty.Create(nameof(IsSwipeEnabled), typeof(bool), typeof(TabView), false);
    public string IsSwipeEnabled
    {
        get => (string)GetValue(IsSwipeEnabledProperty);
        set => SetValue(IsSwipeEnabledProperty, value);
    }

    readonly WeakEventManager selectionChangedManager = new();
    readonly WeakEventManager tabViewScrolledManager = new();

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

    public TabView()
    {
        Content = new StackLayout
        {
            Children = {
                new Label { Text = "Welcome to .NET MAUI!" }
            }
        };
    }

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

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}