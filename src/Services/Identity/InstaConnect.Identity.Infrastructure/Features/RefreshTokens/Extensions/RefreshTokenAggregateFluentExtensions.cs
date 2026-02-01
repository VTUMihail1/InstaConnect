using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

public static class RefreshTokenAggregateFluentExtensions
{
    public static IAggregateFluent<RefreshToken> Match(
        this IAggregateFluent<RefreshToken> aggregate,
        RefreshTokenId filter)
    {
        return aggregate.Match(filter.GetFilter());
    }
}
