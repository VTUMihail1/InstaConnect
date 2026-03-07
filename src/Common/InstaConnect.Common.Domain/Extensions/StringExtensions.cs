using System.Globalization;
using System.Text.RegularExpressions;

namespace InstaConnect.Common.Domain.Extensions;

public static class StringExtensions
{
    extension(string str)
    {
        public string FormatCurrentCulture(params object?[] args)
        {
            return string.Format(CultureInfo.CurrentCulture, str, args);
        }

        public string FormatCurrentCultureSectionKey(string key)
        {
            const string Format = "{0}:{1}";

            return Format.FormatCurrentCulture(str, key);
        }

        public string ToSnakeCase()
        {
            const int Min = 0;
            const string Underscore = "_";

            return string.Concat(str.Select((x, i) => i > Min && char.IsUpper(x) ? Underscore + x : x.ToString()))
                         .ToLowerCurrentCulture();
        }

        public string ToSpaceBetweenWordsCase()
        {
            const string OldCharsRegex = "([a-z])([A-Z])";
            const string NewCharsRegex = "$1 $2";

            return Regex.Replace(str, OldCharsRegex, NewCharsRegex);
        }

        public string ToCamelCase()
        {
            if (str.IsNullOrEmptyOrWhiteSpace())
            {
                return str;
            }

            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        public string ToLowerCurrentCulture()
        {
            return str.ToLower(CultureInfo.CurrentCulture);
        }

        public string ToUpperCurrentCulture()
        {
            return str.ToUpper(CultureInfo.CurrentCulture);
        }

        public bool EqualsOrdinalIgnoreCase(string? b)
        {
            return string.Equals(str, b, StringComparison.OrdinalIgnoreCase);
        }

        public bool StartsWithOrdinalIgnoreCase(string? b)
        {
            return str.StartsWith(b ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        public bool NotEqualsOrdinalIgnoreCase(string? b)
        {
            return !str.EqualsOrdinalIgnoreCase(b);
        }

        public bool IsNullOrEmptyOrWhiteSpace()
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }
    }
}
