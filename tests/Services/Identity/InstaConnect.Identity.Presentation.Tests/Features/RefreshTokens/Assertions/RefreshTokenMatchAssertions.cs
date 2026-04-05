using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMatchAssertions
{
    extension(IssueRefreshTokenApiResponse response)
    {
        public void ShouldSatisfy(RefreshToken refreshToken, IssueRefreshTokenApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(refreshToken, request));
        }
    }

    extension(RotateRefreshTokenApiResponse response)
    {
        public void ShouldSatisfy(RefreshToken refreshToken, RotateRefreshTokenApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(refreshToken, request));
        }
    }

    extension(ActionResult<IssueRefreshTokenApiResponse> response)
    {
        public void ShouldSatisfy(
        RefreshToken refreshToken,
        IssueRefreshTokenApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(refreshToken, request));
        }
    }

    extension(ActionResult<RotateRefreshTokenApiResponse> response)
    {
        public void ShouldSatisfy(
        RefreshToken refreshToken,
        RotateRefreshTokenApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(refreshToken, request));
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
