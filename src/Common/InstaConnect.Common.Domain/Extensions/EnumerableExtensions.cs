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
}
