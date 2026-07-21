using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenEventAssertions
{
	extension(ICollection<ForgotPasswordTokenAddedEventRequest> r)
	{
		public bool ShouldSatisfy(AddForgotPasswordTokenApiRequest request, ICollection<ForgotPasswordToken> entities)
		{
			return r.Matches(request, entities);
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> r)
	{
		public bool ShouldSatisfy(VerifyForgotPasswordTokenApiRequest request, ICollection<ForgotPasswordToken> entities)
		{
			return r.Matches(request, entities);
		}
	}
}
