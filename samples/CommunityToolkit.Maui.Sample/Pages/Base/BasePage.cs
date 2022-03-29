using System.Diagnostics;
using System.Windows.Input;

using CommunityToolkit.Maui.Sample.Models;
using CommunityToolkit.Maui.Sample.ViewModels;

namespace CommunityToolkit.Maui.Sample.Pages;

public abstract class BasePage<TViewModel> : BasePage where TViewModel : BaseViewModel
{
	protected BasePage(IDeviceInfo deviceInfo, TViewModel viewModel) : base(deviceInfo, viewModel)
	{
	}

	public new TViewModel BindingContext => (TViewModel)base.BindingContext;
}

public abstract class BasePage : ContentPage
{
	protected BasePage(IDeviceInfo deviceInfo, object? viewModel = null)
	{
		BindingContext = viewModel;

		BackgroundColor = (Color)(Application.Current?.Resources["AppBackgroundColor"] ?? throw new InvalidOperationException("Application.Current cannot be null"));

		if (deviceInfo.Platform == DevicePlatform.iOS || deviceInfo.Platform == DevicePlatform.MacCatalyst)
		{
			Padding = new Thickness(12, 108, 12, 12);
		}
		else
		{
			Padding = 12;
		}

		if (string.IsNullOrWhiteSpace(Title))
		{
			Title = this.GetType().Name;
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