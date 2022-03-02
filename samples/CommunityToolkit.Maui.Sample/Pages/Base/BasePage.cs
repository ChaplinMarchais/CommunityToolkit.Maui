﻿using System.Diagnostics;
using System.Windows.Input;

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

		Padding = Device.RuntimePlatform switch
		{
			// Work-around to ensure content doesn't get clipped by iOS Status Bar + Naviagtion Bar
			Device.iOS => new Thickness(12, 108, 12, 12),
			_ => 12
		};
	}

	//public ICommand? NavigateCommand { get; }

	protected override void OnAppearing()
	{
		Debug.WriteLine($"OnAppearing: {this}");
	}

	protected override void OnDisappearing()
	{
		Debug.WriteLine($"OnDisappearing: {this}");
	}

	protected static Page PreparePage(SectionModel sectionModel)
	{
		ArgumentNullException.ThrowIfNull(sectionModel);

		var page = (Page)(Activator.CreateInstance(sectionModel.ViewModelType) ?? throw new ArgumentException("Invalid SectionModel"));
		page.Title = sectionModel.Title;

		return page;
	}
}