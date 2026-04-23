using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

using Microsoft.Net.Http.Headers;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMatchAssertions
{
    extension(IssueRefreshTokenApiResponse response)
    {
        public void ShouldSatisfy(IssueRefreshTokenApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(request));
        }
    }

    extension(RotateRefreshTokenApiResponse response)
    {
        public void ShouldSatisfy(RotateRefreshTokenApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(request));
        }
    }

    extension(ActionResult<IssueRefreshTokenApiResponse> response)
    {
        public void ShouldSatisfy(
        IssueRefreshTokenApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(request));
        }
    }

    extension(ActionResult<RotateRefreshTokenApiResponse> response)
    {
        public void ShouldSatisfy(
        RotateRefreshTokenApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(request));
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

    extension(ICollection<SetCookieHeaderValue> cookies)
    {
        public void ShouldSatisfy(IssueRefreshTokenApiRequest request, User user)
        {
            cookies.ShouldSatisfy(p => p.Matches(request, user));
        }

        public void ShouldSatisfy(RotateRefreshTokenApiRequest request, User user)
        {
            cookies.ShouldSatisfy(p => p.Matches(request, user));
        }
        public void ShouldSatisfy(DeleteCurrentRefreshTokenApiRequest request, User user)
        {
            cookies.ShouldSatisfy(p => p.Matches(request, user));
        }
    }
}
