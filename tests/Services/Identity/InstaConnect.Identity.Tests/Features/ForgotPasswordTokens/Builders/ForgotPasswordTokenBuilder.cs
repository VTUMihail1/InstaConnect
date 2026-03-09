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

    public ForgotPasswordTokenBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public ForgotPasswordTokenBuilder WithValue(IStringTransformer transformer)
    {
        _value = transformer.Transform(_value);

        return this;
    }

    public ForgotPasswordTokenBuilder WithCreatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _createdAtUtc = transformer.Transform(_createdAtUtc);

        return this;
    }

    public ForgotPasswordTokenBuilder WithExpiredAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _expiresAtUtc = transformer.Transform(_expiresAtUtc);

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
