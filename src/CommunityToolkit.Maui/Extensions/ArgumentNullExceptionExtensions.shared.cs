using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolkit.Maui.Extensions;

/// <summary>
/// Provides declarative extensions for null checking guard clauses
/// </summary>
public static class ArgumentNullExceptionExtensions
{
	/// <summary>
	/// Throws an <see cref="ArgumentNullException"/> if <paramref name="argument"/> is either an empty <see cref="String"/> or <see langword="null"/>
	/// </summary>
	/// <param name="argument">The argument.</param>
	/// <param name="parameterName">The parameter name.</param>
	public static void ThrowIfNullOrEmpty(object? argument, [CallerArgumentExpression("argument")] string? parameterName = null)
	{
		switch (argument)
		{
			case string paramString when string.IsNullOrEmpty(paramString):
				throw new ArgumentNullException(parameterName);
			case null:
				throw new ArgumentNullException(parameterName);
		};
	}

	/// <summary>
	/// Throws an <see cref="ArgumentNullException"/> if <paramref name="argument"/> is either a whitespace only <see cref="String"/> or <see langword="null"/>
	/// </summary>
	/// <param name="argument">The argument.</param>
	/// <param name="parameterName">The parameter name.</param>
	public static void ThrowIfNullOrWhitespace(object? argument, [CallerArgumentExpression("argument")] string? parameterName = null)
	{
		switch (argument)
		{
			case string paramString when string.IsNullOrWhiteSpace(paramString):
				throw new ArgumentNullException(parameterName);
			case null:
				throw new ArgumentNullException(parameterName);
		};
	}
}
