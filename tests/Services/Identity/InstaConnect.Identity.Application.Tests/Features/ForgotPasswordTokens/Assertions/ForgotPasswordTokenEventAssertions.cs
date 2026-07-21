using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenEventAssertions
{
	extension(ICollection<ForgotPasswordTokenAddedEventRequest> r)
	{
		public bool ShouldSatisfy(AddForgotPasswordTokenCommandRequest request, ICollection<ForgotPasswordToken> entities)
		{
			return r.Matches(request, entities);
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> r)
	{
		public bool ShouldSatisfy(VerifyForgotPasswordTokenCommandRequest request, ICollection<ForgotPasswordToken> entities)
		{
			return r.Matches(request, entities);
		}
	}
}
