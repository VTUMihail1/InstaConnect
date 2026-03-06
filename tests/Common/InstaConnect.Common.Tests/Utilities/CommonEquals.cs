using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Domain.Models.ValueObjects;

namespace InstaConnect.Common.Tests.Utilities;

public static class CommonEquals
{
    extension(Name p)
    {
        public bool Matches(string value)
        {
            return p.Value.EqualsOrdinalIgnoreCase(value);
        }
    }

    extension(Email p)
    {
        public bool Matches(string value)
        {
            return p.Value.EqualsOrdinalIgnoreCase(value);
        }
    }

    extension(Image? p)
    {
        public bool Matches(string? url)
        {
            return p == null || p.Url == url;
        }
    }

    extension<T>(ICollection<T> expected)
    {
        public bool MatchesCollection(ICollection<T> actual)
        {
            return expected.Count == actual.Count &&
                   expected.All(actual.Contains);
        }
    }
}
