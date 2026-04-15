using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

public static class EmailConfirmationTokenAggregateFluentExtensions
{
    extension(IAggregateFluent<EmailConfirmationToken> aggregate)
    {
        public IAggregateFluent<EmailConfirmationToken> Match(EmailConfirmationTokenId filter)
        {
            return aggregate.Match(filter.GetFilter());
        }
    }
}
