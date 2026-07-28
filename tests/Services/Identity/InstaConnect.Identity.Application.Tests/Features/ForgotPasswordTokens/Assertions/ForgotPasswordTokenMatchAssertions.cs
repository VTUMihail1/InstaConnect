using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMatchAssertions
{
	extension(ForgotPasswordToken forgotPasswordToken)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenCommandRequest request)
		{
			forgotPasswordToken.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(VerifyForgotPasswordTokenCommandRequest request, IPasswordHasher passwordHasher)
		{
			forgotPasswordToken.ShouldSatisfy(p => p.Matches(request, passwordHasher));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(VerifyForgotPasswordTokenCommandRequest request, IPasswordHasher passwordHasher)
		{
			user.ShouldSatisfy(p => p.Matches(request, passwordHasher));
		}
	}

	extension(ICollection<ForgotPasswordTokenAddedEventRequest> r)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenCommandRequest request, ICollection<ForgotPasswordToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> r)
	{
		public void ShouldSatisfy(VerifyForgotPasswordTokenCommandRequest request, ICollection<ForgotPasswordToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}
}
