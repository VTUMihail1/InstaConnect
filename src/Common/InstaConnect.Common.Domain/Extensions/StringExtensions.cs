using System.Globalization;
using System.Text.RegularExpressions;

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

    public static string ToSpaceBetweenWordsCase(this string str)
    {
        const string OldCharsRegex = "([a-z])([A-Z])";
        const string NewCharsRegex = "$1 $2";

        return Regex.Replace(str, OldCharsRegex, NewCharsRegex);
    }

    public static string ToCamelCase(this string str)
    {
        if (str.IsNullOrEmptyOrWhiteSpace())
        {
            return str;
        }

        return char.ToLowerInvariant(str[0]) + str.Substring(1);
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
