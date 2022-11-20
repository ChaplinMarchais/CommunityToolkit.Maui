using System.Diagnostics;

using CommunityToolkit.Maui.Sample.Models;
using CommunityToolkit.Maui.Sample.ViewModels;

namespace CommunityToolkit.Maui.Sample.Pages;

public abstract class BasePage<TViewModel> : BasePage where TViewModel : BaseViewModel
{
	protected BasePage(TViewModel viewModel) : base(viewModel)
	{
	}

	public new TViewModel BindingContext => (TViewModel)base.BindingContext;
}

public abstract class BasePage : ContentPage
{
	protected BasePage(object? viewModel = null)
	{
		BindingContext = viewModel;
		Padding = 12;

		if (string.IsNullOrWhiteSpace(Title))
		{
			Title = GetType().Name;
		}
	}

	//public ICommand? NavigateCommand { get; }

	protected override void OnAppearing()
	{
		base.OnAppearing();

		Debug.WriteLine($"OnAppearing: {Title}");
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();

		Debug.WriteLine($"OnDisappearing: {Title}");
	}

	protected static Page PreparePage(SectionModel sectionModel)
	{
		ArgumentNullException.ThrowIfNull(sectionModel);

		var page = (Page)(Activator.CreateInstance(sectionModel.ViewModelType) ?? throw new ArgumentException("Invalid SectionModel"));
		page.Title = sectionModel.Title;

		return page;
	}
}