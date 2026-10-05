using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenEquals
{
	extension(ForgotPasswordToken p)
	{
		public bool Matches(
			ForgotPasswordTokenId id,
			ForgotPasswordToken forgotPasswordToken)
		{
			return p.Matches(forgotPasswordToken);
		}
	}

	extension(bool response)
	{
		public bool Matches(ForgotPasswordTokenId id)
		{
			return response;
		}
	}
}
