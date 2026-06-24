using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class CommonEquals
{
	extension(Name p)
	{
		public bool Matches(string value)
		{
			return p.Value.EqualsOrdinalIgnoreCase(value);
		}

		public bool Matches(Name name)
		{
			return p.Matches(name.Value);
		}
	}

	extension(Email p)
	{
		public bool Matches(string value)
		{
			return p.Value.EqualsOrdinalIgnoreCase(value);
		}

		public bool Matches(Email email)
		{
			return p.Matches(email.Value);
		}
	}

	extension(Image? p)
	{
		public bool Matches(string? url)
		{
			return p == null || p.Url == url;
		}

		public bool Matches(Image? image)
		{
			return p.Matches(image?.Url);
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
