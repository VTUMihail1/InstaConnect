using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Domain.Models.ValueObjects;

namespace InstaConnect.Common.Tests.Utilities;
public static class CommonEquals
{
    public static bool Matches(this Name p, string value)
    {
        return p.Value.EqualsOrdinalIgnoreCase(value);
    }

    public static bool Matches(this Email p, string value)
    {
        return p.Value.EqualsOrdinalIgnoreCase(value);
    }

    public static bool Matches(this Image? p, string? url)
    {
        return p == null || p.Url == url;
    }

    public static bool MatchesCollection<T>(
        this ICollection<T> expected,
        ICollection<T> actual)
    {
        return expected.Count == actual.Count &&
               expected.All(actual.Contains);
    }
}
