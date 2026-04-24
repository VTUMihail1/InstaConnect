using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Features.Common.Helpers;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMatchAssertions
{
    extension(IssueRefreshTokenCommandResponse response)
    {
        public void ShouldSatisfy(RefreshToken refreshToken, IssueRefreshTokenCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(refreshToken, request));
        }
    }

    extension(RotateRefreshTokenCommandResponse response)
    {
        public void ShouldSatisfy(RefreshToken refreshToken, RotateRefreshTokenCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(refreshToken, request));
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
