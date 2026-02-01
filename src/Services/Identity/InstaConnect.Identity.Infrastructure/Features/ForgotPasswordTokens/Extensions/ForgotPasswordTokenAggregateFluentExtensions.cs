using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

public static class ForgotPasswordTokenAggregateFluentExtensions
{
    public static IAggregateFluent<ForgotPasswordToken> Match(
        this IAggregateFluent<ForgotPasswordToken> aggregate,
        ForgotPasswordTokenId filter)
    {
        return aggregate.Match(filter.GetFilter());
    }
}
