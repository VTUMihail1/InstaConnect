using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;
using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;


public static class RefreshTokenEquals
{
    extension(IssueRefreshTokenCommandRequest command)
    {
        public bool Matches(IssueRefreshTokenApiRequest request)
        {
            return command.Name == request.Name &&
                   command.Password == request.Body.Password;
        }
    }

    extension(RotateRefreshTokenCommandRequest command)
    {
        public bool Matches(RotateRefreshTokenApiRequest request)
        {
            return command.Id == request.Id &&
                   command.Value == request.Value;
        }
    }

    extension(DeleteCurrentRefreshTokenCommandRequest command)
    {
        public bool Matches(DeleteCurrentRefreshTokenApiRequest request)
        {
            return command.Id == request.Id &&
                   command.Value == request.Value;
        }
    }

    extension(IssueRefreshTokenApiResponse response)
    {
        public bool Matches(RefreshToken refreshToken, AccessToken accessToken, IssueRefreshTokenApiRequest request)
        {
            return response.AccessToken.Matches(accessToken);
        }
    }


    extension(RotateRefreshTokenApiResponse response)
    {
        public bool Matches(RefreshToken refreshToken, AccessToken accessToken, RotateRefreshTokenApiRequest request)
        {
            return response.AccessToken.Matches(accessToken);
        }
    }

    extension(RefreshToken refreshToken)
    {
        public bool Matches(IssueRefreshTokenApiRequest request, IPasswordHasher passwordHasher)
        {
            return refreshToken.User!.Name.Matches(request.Name) &&
                   passwordHasher.IsMatch(request.Body.Password, refreshToken.User.PasswordHash);
        }

        public bool Matches(RotateRefreshTokenApiRequest request)
        {
            return refreshToken.Id.Matches(request.Id, request.Value);
        }
    }


    extension(AccessTokenApiResponse response)
    {
        public bool Matches(AccessToken accessToken)
        {
            return response.Value == accessToken.Value &&
                   response.ExpiresAtUtc == accessToken.ExpiresAtUtc;
        }
    }
}
