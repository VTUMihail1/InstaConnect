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

    public RefreshTokenBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public RefreshTokenBuilder WithValue(IStringTransformer transformer)
    {
        _value = transformer.Transform(_value);

        return this;
    }

    public RefreshTokenBuilder WithCreatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _createdAtUtc = transformer.Transform(_createdAtUtc);

        return this;
    }

    public RefreshTokenBuilder WithExpiredAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _expiresAtUtc = transformer.Transform(_expiresAtUtc);

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
