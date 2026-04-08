using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

using Microsoft.Net.Http.Headers;

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
        public bool Matches(IssueRefreshTokenApiRequest request)
        {
            return response.AccessToken.Matches();
        }
    }


    extension(RotateRefreshTokenApiResponse response)
    {
        public bool Matches(RotateRefreshTokenApiRequest request)
        {
            return response.AccessToken.Matches();
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
        public bool Matches()
        {
            return response.Value.IsNotNullOrEmptyOrWhiteSpace() &&
                   response.ExpiresAtUtc != default;
        }
    }

    extension(ICollection<SetCookieHeaderValue> cookies)
    {
        public bool Matches(IssueRefreshTokenApiRequest request, User user)
        {
            var idCookie = cookies.GetId();
            var id = idCookie.GetStringValue();
            var valueCookie = cookies.GetValue();
            var value = valueCookie.GetStringValue();

            return user.Id.Matches(id) &&
                   idCookie.Expires != default &&
                   idCookie.Secure &&
                   idCookie.HttpOnly &&
                   user.RefreshTokens.Any(a => a.Id.Matches(id, value)) &&
                   valueCookie.Expires != default &&
                   valueCookie.Secure &&
                   valueCookie.HttpOnly;
        }

        public bool Matches(RotateRefreshTokenApiRequest request, User user)
        {
            var idCookie = cookies.GetId();
            var id = idCookie.GetStringValue();
            var valueCookie = cookies.GetValue();
            var value = valueCookie.GetStringValue();

            return user.Id.Matches(id) &&
                   idCookie.Expires != default &&
                   idCookie.Secure &&
                   idCookie.HttpOnly &&
                   user.RefreshTokens.Any(a => a.Id.Matches(id, value)) &&
                   valueCookie.Expires != default &&
                   valueCookie.Secure &&
                   valueCookie.HttpOnly;
        }

        public bool Matches(DeleteCurrentRefreshTokenApiRequest request, User user)
        {
            var idCookie = cookies.GetId();
            var id = idCookie.GetStringValue();
            var valueCookie = cookies.GetValue();
            var value = valueCookie.GetStringValue();

            return id.IsNullOrEmptyOrWhiteSpace() &&
                   value.IsNullOrEmptyOrWhiteSpace();
        }
    }
}
