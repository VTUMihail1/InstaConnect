using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Identity.Application.Features.RefreshTokens.Models;
using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Helpers;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenEquals
{
    extension(IssueRefreshTokenCommand command)
    {
        public bool Matches(IssueRefreshTokenCommandRequest request)
        {
            return command.Name.Matches(request.Name) &&
                   command.Password == request.Password;
        }
    }

    extension(RotateRefreshTokenCommand command)
    {
        public bool Matches(RotateRefreshTokenCommandRequest request)
        {
            return command.Id.Matches(request.Id, request.Value);
        }
    }

    extension(DeleteRefreshTokenCommand command)
    {
        public bool Matches(DeleteCurrentRefreshTokenCommandRequest request)
        {
            return command.Id.Matches(request.Id, request.Value);
        }
    }

    extension(IssueRefreshTokenCommandResponse response)
    {
        public bool Matches(RefreshToken refreshToken, IssueRefreshTokenCommandRequest request)
        {
            return response.Response.Matches(refreshToken);
        }
    }

    extension(RotateRefreshTokenCommandResponse response)
    {
        public bool Matches(RefreshToken refreshToken, RotateRefreshTokenCommandRequest request)
        {
            return response.Response.Matches(refreshToken);
        }
    }

    extension(RefreshToken refreshToken)
    {
        public bool Matches(IssueRefreshTokenCommandRequest request, IPasswordHasher passwordHasher)
        {
            return refreshToken.User!.Name.Matches(request.Name) &&
                   passwordHasher.IsMatch(request.Password, refreshToken.User.PasswordHash);
        }

        public bool Matches(RotateRefreshTokenCommandRequest request)
        {
            return refreshToken.Id.Id.Matches(request.Id) && refreshToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace();
        }
    }

    extension(RefreshTokenIdCommandResponse response)
    {
        public bool Matches(RefreshTokenId id)
        {
            return id.Matches(response.Id, response.Value);
        }
    }

    extension(SessionTokenCommandResponse response)
    {
        public bool Matches(RefreshToken refreshToken)
        {
            return response.Id.Matches(refreshToken.Id) &&
                   response.AccessToken.Matches() &&
                   response.ExpiresAtUtc == refreshToken.ExpiresAtUtc;
        }
    }


    extension(AccessTokenCommandResponse response)
    {
        public bool Matches()
        {
            return response.Value.IsNotNullOrEmptyOrWhiteSpace() &&
                   response.ExpiresAtUtc != default;
        }
    }
}
