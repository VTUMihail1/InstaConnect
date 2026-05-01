using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

public static class ForgotPasswordTokenAggregateFluentExtensions
{
	extension(IAggregateFluent<ForgotPasswordToken> aggregate)
	{
		public IAggregateFluent<ForgotPasswordToken> Match(ForgotPasswordTokenId filter)
		{
			return aggregate.Match(filter.GetFilter());
		}
	}
}
