using CommunityToolkit.Maui.Sample.Pages;

namespace CommunityToolkit.Maui.Sample.Models;

public sealed class SectionModel
{
	public SectionModel(in Type type, in string title, in string description)
		: this(type, title, new Color(), description)
	{
	}

	public SectionModel(in Type type, in string title, in Color color, in string description)
	{
		Type = type;
		Title = title;
		Description = description;
		Color = color;
	}

	public Type Type { get; }

	public string Title { get; } = String.Empty;

	public string Description { get; }

	public Color Color { get; }
}