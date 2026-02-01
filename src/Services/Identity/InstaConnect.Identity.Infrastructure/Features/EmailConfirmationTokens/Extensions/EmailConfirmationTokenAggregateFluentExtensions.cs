using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

public static class EmailConfirmationTokenAggregateFluentExtensions
{
    public static IAggregateFluent<EmailConfirmationToken> Match(
        this IAggregateFluent<EmailConfirmationToken> aggregate,
        EmailConfirmationTokenId filter)
    {
        return aggregate.Match(filter.GetFilter());
    }
}
