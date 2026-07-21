using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenEventAssertions
{
	extension(ICollection<ForgotPasswordTokenAddedEventRequest> r)
	{
		public bool ShouldSatisfy(AddForgotPasswordTokenCommand command, ICollection<ForgotPasswordToken> entities)
		{
			return r.Matches(command, entities);
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> r)
	{
		public bool ShouldSatisfy(VerifyForgotPasswordTokenCommand command, ICollection<ForgotPasswordToken> entities)
		{
			return r.Matches(command, entities);
		}
	}
}
