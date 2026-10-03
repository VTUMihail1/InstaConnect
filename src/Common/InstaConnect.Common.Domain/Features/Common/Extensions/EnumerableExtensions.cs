using InstaConnect.Common.Domain.Features.Databases.Abstractions;

namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class EnumerableExtensions
{
	extension<T>(IEnumerable<T> enumerable)
	{
		public bool IsEmpty()
		{
			return !enumerable.Any();
		}

		public string JoinWith(string separator)
		{
			return string.Join(separator, enumerable);
		}

		public string JoinWithComma()
		{
			return enumerable.JoinWith(", ");
		}

		public string JoinWithSemicolon()
		{
			return enumerable.JoinWith("; ");
		}
	}

	extension<TDestinationType, TIncludeType, TIncludeDescriptor>(IEnumerable<TIncludeDescriptor> descriptors)
		where TDestinationType : Enum
		where TIncludeType : Enum
		where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
	{
		public string JoinDescriptorsWithComma()
		{
			const string PropertyFormat = "descriptor(destinationType: {0}, includeType: {1})";

			return descriptors
				.Select(ip => PropertyFormat.FormatCurrentCulture(ip.DestinationType, ip.IncludeType))
				.JoinWithComma();
		}
	}
}
