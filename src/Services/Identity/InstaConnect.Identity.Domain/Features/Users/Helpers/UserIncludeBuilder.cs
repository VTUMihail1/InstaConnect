namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

public class UserIncludeBuilder
{
    private readonly ICollection<UserIncludeProperty> _includeProperties;

    internal UserIncludeBuilder(ICollection<UserIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public UserIncludeBuilder WithClaims()
    {
        _includeProperties.Add(UserIncludeProperty.Claims);

        return this;
    }

    public UserIncludeBuilder WithEmailConfirmationTokens()
    {
        _includeProperties.Add(UserIncludeProperty.EmailConfirmationTokens);

        return this;
    }

    public UserIncludeBuilder WithForgotPasswordTokens()
    {
        _includeProperties.Add(UserIncludeProperty.ForgotPasswordTokens);

        return this;
    }

    public UserIncludeBuilder WithRefreshTokens()
    {
        _includeProperties.Add(UserIncludeProperty.RefreshTokens);

        return this;
    }

    public UserInclude Build()
    {
        return new(_includeProperties);
    }
}
