using InstaConnect.Common.Domain.Features.Data.Abstractions;

namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class EnumerableExtensions
{
	extension<T>(IEnumerable<T> enumerable)
	{
		public bool IsEmpty()
		{
			return !enumerable.Any();
		}

		public string JoinAsString(string separator)
		{
			return string.Join(separator, enumerable);
		}

		public string JoinAsStringWithComa()
		{
			return enumerable.JoinAsString(", ");
		}

		public string JoinAsStringWithSemicolon()
		{
			return enumerable.JoinAsString("; ");
		}

		public string JoinAsStringWithNewLine()
		{
			return enumerable.JoinAsString("\n");
		}

		public string JoinAsStringWithDot()
		{
			return enumerable.JoinAsString(".");
		}
	}

	extension<TDestinationType, TIncludeType, TIncludeDescriptor>(IEnumerable<TIncludeDescriptor> descriptors)
		where TDestinationType : Enum
		where TIncludeType : Enum
		where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
	{
		public string JoinIncludeDescriptorsAsStringWithComa()
		{
			const string PropertyFormat = "descriptor(destinationType: {0}, includeType: {1})";

			return descriptors
				.Select(ip => PropertyFormat.FormatCurrentCulture(ip.DestinationType, ip.IncludeType))
				.JoinAsStringWithComa();
		}
	}
}
