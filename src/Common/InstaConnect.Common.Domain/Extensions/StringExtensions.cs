using System.Globalization;

namespace InstaConnect.Common.Domain.Extensions;
public static class StringExtensions
{
    public static string FormatCurrentCulture(this string format, params object[] args)
    {
        var result = string.Format(CultureInfo.CurrentCulture, format, args);

        return result;
    }

    public static string ToSnakeCase(this string str)
    {
        const int Min = 0;
        const string Underscore = "_";

        var result = string.Concat(str.Select((x, i) => i > Min && char.IsUpper(x) ? Underscore + x : x.ToString()))
                     .ToLowerCurrentCulture();

        return result;
    }

    public static string ToLowerCurrentCulture(this string a)
    {
        var result = a.ToLower(CultureInfo.CurrentCulture);

        return result;
    }

    public static string ToUpperCurrentCulture(this string a)
    {
        var result = a.ToUpper(CultureInfo.CurrentCulture);

        return result;
    }

    public static bool EqualsOrdinalIgnoreCase(this string a, string b)
    {
        var result = string.Equals(a, b, StringComparison.OrdinalIgnoreCase);

        return result;
    }

    public static bool StartsWithOrdinalIgnoreCase(this string a, string b)
    {
        var result = a.StartsWith(b, StringComparison.OrdinalIgnoreCase);

        return result;
    }

    public static bool NotEqualsOrdinalIgnoreCase(this string a, string b)
    {
        var result = !a.EqualsOrdinalIgnoreCase(b);

        return result;
    }

    public static bool IsNullOrEmptyOrWhiteSpace(this string? a)
    {
        return string.IsNullOrEmpty(a) || string.IsNullOrWhiteSpace(a);
    }
}
