using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Helpers;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.StyleSheets;

namespace CommunityToolkit.Maui.Views;

/// <summary>
/// Base class for <see cref="TabView.TabItems"/> elements.
/// </summary>
/// <remarks>
///	Inherit from this base class if you want to customize the behaviour of your <see cref="TabView.TabItems"/>. This base provides
/// the logic for navigation and resolution of the proper <see cref="Style"/> instances.
/// </remarks>
public class TabViewIndicator : NavigableElement, IPropertyPropagationController, IVisualController, IFlowDirectionController

{
	/// <summary>
	/// Triggered when the instance is being rendered
	/// </summary>
	public event EventHandler? Appearing;
	/// <summary>
	/// Triggered when the instance is disappearing
	/// </summary>
	public event EventHandler? Disappearing;

	bool? hasAppearing;
	const string defaultTabViewItemLabelStyle = "Default_TabViewItemLabelStyle";
	const string defaultTabViewItemImageStyle = "Default_TabViewItemImageStyle";
	const string defaultTabViewItemLayoutStyle = "Default_TabViewItemLayoutStyle";

	private protected ObservableCollection<Element> DeclaredChildren { get; } = new();
	readonly ObservableCollection<Element?> logicalChildren = new();
	internal override IReadOnlyList<Element?> LogicalChildrenInternal =>
		new ReadOnlyCollection<Element?>(logicalChildren);

	void IPropertyPropagationController.PropagatePropertyChanged(string propertyName)
	{
		PropertyPropagationExtensions.PropagatePropertyChanged(propertyName, this,
			((IElementController)this).LogicalChildren);
	}

	IVisual effectiveVisual = VisualMarker.Default;
	IVisual IVisualController.EffectiveVisual
	{
		get => effectiveVisual;
		set
		{
			if (value == effectiveVisual)
			{
				return;
			}

			effectiveVisual = value;
			OnPropertyChanged(VisualElement.VisualProperty.PropertyName);
		}
	}

	IVisual IVisualController.Visual => VisualMarker.MatchParent;

	EffectiveFlowDirection effectiveFlowDirection = default(EffectiveFlowDirection);

	EffectiveFlowDirection IFlowDirectionController.EffectiveFlowDirection
	{
		get => effectiveFlowDirection;
		set
		{
			if (effectiveFlowDirection == value)
			{
				return;
			}

			effectiveFlowDirection = value;
			var ve = (Parent as VisualElement);
			ve?.InvalidateMeasureInternal(InvalidationTrigger.Undefined);
			OnPropertyChanged(VisualElement.FlowDirectionProperty.PropertyName);
		}
	}
	
	double IFlowDirectionController.Width => (Parent as VisualElement)?.Width ?? 0;
	bool IFlowDirectionController.ApplyEffectiveFlowDirectionToChildContainer => true;

	/// <inheritdoc />
	public TabViewIndicator()
	{
		DeclaredChildren.CollectionChanged += (_, args) =>
		{
			if (args.NewItems is not null)
			{
				foreach (Element? ele in args.NewItems)
				{
					AddLogicalChild(ele);
				}
			}

			if (args.OldItems is not null)
			{
				foreach (Element? ele in args.OldItems)
				{
					RemoveLogicalChildren(ele);
				}
			}
		};
	}

	internal virtual void SendAppearing()
	{
		if (hasAppearing ?? false)
		{
			return;
		}

		hasAppearing = true;
		OnAppearing();
		Appearing?.Invoke(this, EventArgs.Empty);
	}

	internal virtual void SendDisappearing()
	{
		if (!hasAppearing ?? true)
		{
			return;
		}

		hasAppearing = false;
		OnDisappearing();
		Disappearing?.Invoke(this, EventArgs.Empty);
	}

	/// <summary>
	/// Invoked when <see cref="TabViewIndicator.Appearing"/> is fired.
	/// </summary>
	protected virtual void OnAppearing()
	{
	}

	/// <summary>
	/// Invoked when <see cref="TabViewIndicator.Disappearing"/> is fired.
	/// </summary>
	protected virtual void OnDisappearing()
	{

	}

	internal void OnAppearing(Action action)
	{
		if (hasAppearing ?? false)
		{
			action();
		}
		else
		{
			if (Navigation.ModalStack.Count > 0)
			{
				Navigation.ModalStack[^1]
					.OnAppearing(action);
				return;
			}
			else if (Navigation.NavigationStack.Count > 1)
			{
				Navigation.NavigationStack[^1]
					.OnAppearing(action);
				return;
			}

			void LocalHandler(object? _, EventArgs __)
			{
				this.Appearing -= LocalHandler;
				action();
			}

			this.Appearing += LocalHandler;
		}
	}
	
	/// <inheritdoc/>
	protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		base.OnPropertyChanged(propertyName);

		//TODO: Add support for nested indicators?
	}

	internal void RemoveLogicalChildren(Element? ele)
	{
		if (ele is null)
		{
			return;
		}

		ele.Parent = null;

		var index = logicalChildren.IndexOf(ele);
		if (index == -1)
		{
			return;
		}

		logicalChildren.Remove(ele);
		OnChildRemoved(ele, index);
		VisualDiagnostics.OnChildRemoved(this, ele, index);
	}

	internal void AddLogicalChild(Element? ele)
	{
		if (ele is null)
		{
			return;
		}

		if (logicalChildren.Contains(ele))
		{
			return;
		}

		logicalChildren.Add(ele);
		ele.Parent = this;
		OnChildAdded(ele);
		VisualDiagnostics.OnChildAdded(this, ele);
	}

	static void UpdateIndicatorItemStyles(Layout indicatorItemCell, IStyleSelectable? source)
	{
		List<string> bindableObjStyle = new()
		{
			defaultTabViewItemLabelStyle,
			defaultTabViewItemImageStyle,
			defaultTabViewItemLayoutStyle,
			TabViewItem.LabelStyle,
			TabViewItem.ImageStyle,
			TabViewItem.LayoutStyle };

		if (source?.Classes is not null)
		{
			bindableObjStyle.AddRange(source.Classes);
		}

		indicatorItemCell.StyleClass = bindableObjStyle;
		indicatorItemCell.Children.OfType<Label>().First().StyleClass = bindableObjStyle;
		indicatorItemCell.Children.OfType<Image>().First().StyleClass = bindableObjStyle;
	}
}