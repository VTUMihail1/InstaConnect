using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Helpers;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMatchAssertions
{
    extension(IssueRefreshTokenCommandResponse response)
    {
        public void ShouldSatisfy(RefreshToken refreshToken, AccessToken accessToken, IssueRefreshTokenCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(refreshToken, accessToken, request));
        }
    }

    extension(RotateRefreshTokenCommandResponse response)
    {
        public void ShouldSatisfy(RefreshToken refreshToken, AccessToken accessToken, RotateRefreshTokenCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(refreshToken, accessToken, request));
        }
    }

    extension(RefreshToken refreshToken)
    {
        public void ShouldSatisfy(IssueRefreshTokenCommandRequest request, IPasswordHasher passwordHasher)
        {
            refreshToken.ShouldSatisfy(p => p.Matches(request, passwordHasher));
        }

        public void ShouldSatisfy(RotateRefreshTokenCommandRequest request)
        {
            refreshToken.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
