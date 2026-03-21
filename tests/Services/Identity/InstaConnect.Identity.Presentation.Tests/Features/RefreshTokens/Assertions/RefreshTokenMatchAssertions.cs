using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;
using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMatchAssertions
{
    extension(IssueRefreshTokenApiResponse response)
    {
        public void ShouldSatisfy(RefreshToken refreshToken, AccessToken accessToken, IssueRefreshTokenApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(refreshToken, accessToken, request));
        }
    }

    extension(RotateRefreshTokenApiResponse response)
    {
        public void ShouldSatisfy(RefreshToken refreshToken, AccessToken accessToken, RotateRefreshTokenApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(refreshToken, accessToken, request));
        }
    }

    extension(RefreshToken refreshToken)
    {
        public void ShouldSatisfy(IssueRefreshTokenApiRequest request, IPasswordHasher passwordHasher)
        {
            refreshToken.ShouldSatisfy(p => p.Matches(request, passwordHasher));
        }

        public void ShouldSatisfy(RotateRefreshTokenApiRequest request)
        {
            refreshToken.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
