using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

public static class RefreshTokenAggregateFluentExtensions
{
	extension(IAggregateFluent<RefreshToken> aggregate)
	{
		public IAggregateFluent<RefreshToken> Match(RefreshTokenId filter)
		{
			return aggregate.Match(filter.GetFilter());
		}
	}
}
