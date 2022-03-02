using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolkit.Maui.Views.TabView;
public class TabItemSourceChangedEventArgs : NotifyCollectionChangedEventArgs
{
	public TabItemSourceChangedEventArgs(NotifyCollectionChangedAction action) : base(action)
	{
	}

	public TabItemSourceChangedEventArgs(NotifyCollectionChangedAction action, IList? changedItems) : base(action, changedItems)
	{
	}

	public TabItemSourceChangedEventArgs(NotifyCollectionChangedAction action, object? changedItem) : base(action, changedItem)
	{
	}

	public TabItemSourceChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems) : base(action, newItems, oldItems)
	{
	}

	public TabItemSourceChangedEventArgs(NotifyCollectionChangedAction action, IList? changedItems, int startingIndex) : base(action, changedItems, startingIndex)
	{
	}

	public TabItemSourceChangedEventArgs(NotifyCollectionChangedAction action, object? changedItem, int index) : base(action, changedItem, index)
	{
	}

	public TabItemSourceChangedEventArgs(NotifyCollectionChangedAction action, object? newItem, object? oldItem) : base(action, newItem, oldItem)
	{
	}

	public TabItemSourceChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int startingIndex) : base(action, newItems, oldItems, startingIndex)
	{
	}

	public TabItemSourceChangedEventArgs(NotifyCollectionChangedAction action, IList? changedItems, int index, int oldIndex) : base(action, changedItems, index, oldIndex)
	{
	}

	public TabItemSourceChangedEventArgs(NotifyCollectionChangedAction action, object? changedItem, int index, int oldIndex) : base(action, changedItem, index, oldIndex)
	{
	}

	public TabItemSourceChangedEventArgs(NotifyCollectionChangedAction action, object? newItem, object? oldItem, int index) : base(action, newItem, oldItem, index)
	{
	}
}
