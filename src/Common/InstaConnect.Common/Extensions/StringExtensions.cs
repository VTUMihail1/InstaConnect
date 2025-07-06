using System.Globalization;

namespace InstaConnect.Common.Extensions;
public static class StringExtensions
{
    public static string FormatInvariant(this string format, params object[] args)
    {
        var result = string.Format(CultureInfo.InvariantCulture, format, args);

        return result;
    }

    public static int GetLength(this string? str)
    {
        var length = str?.Length ?? default;

        return length;
    }
}
