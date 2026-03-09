using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;

public class EmailConfirmationTokenBuilder
{
    private string _id;
    private string _value;
    private DateTimeOffset _expiresAtUtc;
    private DateTimeOffset _createdAtUtc;

    public EmailConfirmationTokenBuilder(User user)
    {
        _id = user.Id.Id;
        _value = EmailConfirmationTokenDataFaker.GetValue();
        _expiresAtUtc = EmailConfirmationTokenDataFaker.GetCreatedAtUtc();
        _createdAtUtc = EmailConfirmationTokenDataFaker.GetCreatedAtUtc();
    }

    public EmailConfirmationTokenBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public EmailConfirmationTokenBuilder WithValue(IStringTransformer transformer)
    {
        _value = transformer.Transform(_value);

        return this;
    }

    public EmailConfirmationTokenBuilder WithCreatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _createdAtUtc = transformer.Transform(_createdAtUtc);

        return this;
    }

    public EmailConfirmationTokenBuilder WithExpiredAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _expiresAtUtc = transformer.Transform(_expiresAtUtc);

        return this;
    }

    public EmailConfirmationToken Build()
    {
        return new(
            new(
                new(_id),
                _value),
            _expiresAtUtc,
            _createdAtUtc);
    }
}
