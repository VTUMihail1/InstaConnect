using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMatchAssertions
{
	extension(ForgotPasswordToken forgotPasswordToken)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenApiRequest request)
		{
			forgotPasswordToken.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(VerifyForgotPasswordTokenApiRequest request, IPasswordHasher passwordHasher)
		{
			forgotPasswordToken.ShouldSatisfy(p => p.Matches(request, passwordHasher));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(VerifyForgotPasswordTokenApiRequest request, IPasswordHasher passwordHasher)
		{
			user.ShouldSatisfy(p => p.Matches(request, passwordHasher));
		}
	}

	extension(ICollection<ForgotPasswordTokenAddedEventRequest> r)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenApiRequest request, ICollection<ForgotPasswordToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> r)
	{
		public void ShouldSatisfy(VerifyForgotPasswordTokenApiRequest request, ICollection<ForgotPasswordToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}
}
