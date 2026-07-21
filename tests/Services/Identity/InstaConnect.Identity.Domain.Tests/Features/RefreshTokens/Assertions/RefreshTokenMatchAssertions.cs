using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMatchAssertions
{
	extension(SessionToken response)
	{
		public void ShouldSatisfy(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			response.ShouldSatisfy(p => p.Matches(command, refreshToken));
		}

		public void ShouldSatisfy(RotateRefreshTokenCommand command, RefreshToken refreshToken)
		{
			response.ShouldSatisfy(p => p.Matches(command, refreshToken));
		}
	}

	extension(RefreshToken refreshToken)
	{
		public void ShouldSatisfy(IssueRefreshTokenCommand command, IPasswordHasher passwordHasher)
		{
			refreshToken.ShouldSatisfy(p => p.Matches(command, passwordHasher));
		}

		public void ShouldSatisfy(RotateRefreshTokenCommand command)
		{
			refreshToken.ShouldSatisfy(p => p.Matches(command));
		}
	}
}
