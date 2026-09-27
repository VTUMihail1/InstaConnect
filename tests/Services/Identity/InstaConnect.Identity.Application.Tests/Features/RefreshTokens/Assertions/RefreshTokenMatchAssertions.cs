using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMatchAssertions
{
	extension(IssueRefreshTokenCommandResponse response)
	{
		public void ShouldSatisfy(IssueRefreshTokenCommandRequest request, RefreshToken refreshToken)
		{
			response.ShouldSatisfy(p => p.Matches(request, refreshToken));
		}
	}

	extension(RotateRefreshTokenCommandResponse response)
	{
		public void ShouldSatisfy(RotateRefreshTokenCommandRequest request, RefreshToken refreshToken)
		{
			response.ShouldSatisfy(p => p.Matches(request, refreshToken));
		}
	}

	extension(RefreshToken refreshToken)
	{
		public void ShouldSatisfy(IssueRefreshTokenCommandRequest request)
		{
			refreshToken.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(RotateRefreshTokenCommandRequest request)
		{
			refreshToken.ShouldSatisfy(p => p.Matches(request));
		}
	}
}
