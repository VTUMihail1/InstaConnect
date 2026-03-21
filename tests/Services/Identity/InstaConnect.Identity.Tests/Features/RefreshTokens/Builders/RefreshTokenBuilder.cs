using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

public class RefreshTokenBuilder
{
    private string _id;
    private string _value;
    private DateTimeOffset _expiresAtUtc;
    private DateTimeOffset _createdAtUtc;

    public RefreshTokenBuilder(User user)
    {
        _id = user.Id.Id;
        _value = RefreshTokenDataFaker.GetValue();
        _expiresAtUtc = RefreshTokenDataFaker.GetCreatedAtUtc();
        _createdAtUtc = RefreshTokenDataFaker.GetCreatedAtUtc();
    }

    public RefreshTokenBuilder WithId(string id)
    {
        _id = id;

        return this;
    }

    public RefreshTokenBuilder WithValue(string value)
    {
        _value = value;

        return this;
    }

    public RefreshTokenBuilder WithCreatedAtUtc(DateTimeOffset createdAtUtc)
    {
        _createdAtUtc = createdAtUtc;

        return this;
    }

    public RefreshTokenBuilder WithExpiredAtUtc(DateTimeOffset expiresAtUtc)
    {
        _expiresAtUtc = expiresAtUtc;

        return this;
    }

    public RefreshToken Build()
    {
        return new(
            new(
                new(_id),
                _value),
            _expiresAtUtc,
            _createdAtUtc);
    }
}
