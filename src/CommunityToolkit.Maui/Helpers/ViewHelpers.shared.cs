using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolkit.Maui.Sample.Helpers;
/// <summary>
/// 
/// </summary>
public static class ViewHelpers
{
	/// <summary>
	/// Wraps the provided <see cref="View"/> inside of a <see cref="Frame"/>
	/// </summary>
	/// <param name="bindingContext"></param>
	/// <param name="view">The view to be wrapped</param>
	/// <param name="frameBuilder">Called to construct the <see cref="Frame"/> use for custom scenarios. If left as default, <see cref="ViewHelpers.DefaultFrameBuilder(BindableObject)"/> is called and passed <paramref name="bindingContext"/>.</param>
	/// <returns>The <see cref="Frame"/> with <paramref name="view"/> as it's <see cref="ContentView.Content"/> property</returns>
	public static Frame Wrap(this IView view, BindableObject bindingContext, Func<BindableObject, Frame>? frameBuilder = null)
	{
		Frame wrapper = frameBuilder is not null 
			? frameBuilder.Invoke(bindingContext) 
			: DefaultFrameBuilder(bindingContext);

		wrapper.Content = (View)view;
		return wrapper;
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="bindingContext"></param>
	/// <returns></returns>
	internal static Frame DefaultFrameBuilder(BindableObject bindingContext)
	{
		var style = bindingContext.GetPropertyIfSet<Style?>(NavigableElement.StyleProperty, null);

		Frame frame = new()
		{
			BindingContext = bindingContext,
		};

		if (style is not null)
		{
			frame.Style = style;
		} else
		{
			frame.CornerRadius = 8;
			frame.BackgroundColor = Color.FromArgb("#ffffff");
			frame.HasShadow = true;
			frame.HorizontalOptions = LayoutOptions.Fill;
			frame.VerticalOptions = LayoutOptions.Fill;
		}

		return frame;
	}
}
