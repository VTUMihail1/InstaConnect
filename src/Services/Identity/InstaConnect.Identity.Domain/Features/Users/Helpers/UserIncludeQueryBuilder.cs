using InstaConnect.Users.Domain.Features.Users.Abstractions;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Users.Domain.Features.Users.Helpers;

public class UserIncludeQueryBuilder
{
    private readonly ICollection<UserIncludeProperty> _includeProperties;

    internal UserIncludeQueryBuilder(ICollection<UserIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public UserIncludeQueryBuilder WithClaims()
    {
        _includeProperties.Add(UserIncludeProperty.Claims);

        return this;
    }

    public UserIncludeQueryBuilder WithEmailConfirmationTokens()
    {
        _includeProperties.Add(UserIncludeProperty.EmailConfirmationTokens);

        return this;
    }

    public UserIncludeQueryBuilder WithForgotPasswordTokens()
    {
        _includeProperties.Add(UserIncludeProperty.ForgotPasswordTokens);

        return this;
    }

    public UserIncludeQueryBuilder WithRefreshTokens()
    {
        _includeProperties.Add(UserIncludeProperty.RefreshTokens);

        return this;
    }

    public UserIncludeQuery Build()
    {
        return new UserIncludeQuery(_includeProperties);
    }
}
