using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Domain.Extensions;

public static class EnumerableExtensions
{
    public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
    {
        return !enumerable.Any();
    }

    public static string JoinAsString<T>(this IEnumerable<T> enumerable, string seperator)
    {
        return string.Join(seperator, enumerable);
    }

    public static string JoinAsStringWithComa<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.JoinAsString(", ");
    }

    public static string JoinAsStringWithNewLine<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.JoinAsString("\n");
    }

    public static string JoinAsStringWithDot<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.JoinAsString(".");
    }

    public static string JoinIncludeDescriptorsAsStringWithComa<TDestinationType, TIncludeType, TIncludeDescriptor>(
        this IEnumerable<TIncludeDescriptor> descriptors)
        where TDestinationType : Enum
        where TIncludeType : Enum
        where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
    {
        const string PropertyFormat = "descriptor(destinationType: {0}, includeType: {1})";

        return descriptors
            .Select(ip => PropertyFormat.FormatCurrentCulture(ip.DestinationType, ip.IncludeType))
            .JoinAsStringWithComa();
    }
}
