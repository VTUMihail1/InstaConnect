using System.Linq.Expressions;

using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

public static class RefreshTokenFilterExtensions
{
	extension(RefreshTokenId filter)
	{
		public FilterDefinition<RefreshToken> GetFilter()
		{
			return filter.GetFilterForIdEquals<RefreshToken>(p => p.Id.Id.Id, p => p.Id.Value);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> valueField)
		{
			var id = filter.Id.GetFilterForIdEquals(idField);
			var value = Builders<T>.Filter.EqualsCaseInsensitive(valueField, filter.Value, filter.Value.IsNullOrEmptyOrWhiteSpace());

			return Builders<T>.Filter.And(id, value);
		}
	}
}
