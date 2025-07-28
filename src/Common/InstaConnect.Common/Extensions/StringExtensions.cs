using System.Globalization;

namespace InstaConnect.Common.Extensions;
public static class StringExtensions
{
    public static string FormatInvariantCulture(this string format, params object[] args)
    {
        var result = string.Format(CultureInfo.InvariantCulture, format, args);

        return result;
    }

    public static bool EqualsOrdinalIgnoreCase(this string a, string b)
    {
        var result = string.Equals(a, b, StringComparison.OrdinalIgnoreCase);

        return result;
    }

    public static bool NotEqualsOrdinalIgnoreCase(this string a, string b)
    {
        var result = !a.EqualsOrdinalIgnoreCase(b);

        return result;
    }
}
