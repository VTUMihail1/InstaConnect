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

    extension<TExpected>(ICollection<TExpected> expected)
    {
        public bool MatchesCollection<TEntity, TKey>(
        ICollection<TEntity> entities,
        Func<TExpected, TKey> expectedKey,
        Func<TEntity, TKey> entityKey,
        Func<TExpected, TEntity, bool> matcher)
        where TEntity : IEntity
        where TKey : notnull
        {
            var entitiesByKey = entities
                .OrderBy(a => a.CreatedAtUtc)
                .ToDictionary(entityKey);

            return expected.Count == entitiesByKey.Count &&
                   expected.Any() &&
                   expected.All(e =>
                   entitiesByKey.TryGetValue(expectedKey(e), out var a) &&
                   matcher(e, a));
        }
    }
}
