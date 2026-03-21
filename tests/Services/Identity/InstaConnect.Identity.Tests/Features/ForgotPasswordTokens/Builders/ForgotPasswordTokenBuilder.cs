using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

public class ForgotPasswordTokenBuilder
{
    private string _id;
    private string _value;
    private DateTimeOffset _expiresAtUtc;
    private DateTimeOffset _createdAtUtc;

    public ForgotPasswordTokenBuilder(User user)
    {
        _id = user.Id.Id;
        _value = ForgotPasswordTokenDataFaker.GetValue();
        _expiresAtUtc = ForgotPasswordTokenDataFaker.GetCreatedAtUtc();
        _createdAtUtc = ForgotPasswordTokenDataFaker.GetCreatedAtUtc();
    }

    public ForgotPasswordTokenBuilder WithId(string id)
    {
        _id = id;

        return this;
    }

    public ForgotPasswordTokenBuilder WithValue(string value)
    {
        _value = value;

        return this;
    }

    public ForgotPasswordTokenBuilder WithCreatedAtUtc(DateTimeOffset createdAtUtc)
    {
        _createdAtUtc = createdAtUtc;

        return this;
    }

    public ForgotPasswordTokenBuilder WithExpiredAtUtc(DateTimeOffset expiresAtUtc)
    {
        _expiresAtUtc = expiresAtUtc;

        return this;
    }

    public ForgotPasswordToken Build()
    {
        return new(
            new(
                new(_id),
                _value),
            _expiresAtUtc,
            _createdAtUtc);
    }
}
