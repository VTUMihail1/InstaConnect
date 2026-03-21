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

    public EmailConfirmationTokenBuilder WithId(string id)
    {
        _id = id;

        return this;
    }

    public EmailConfirmationTokenBuilder WithValue(string value)
    {
        _value = value;

        return this;
    }

    public EmailConfirmationTokenBuilder WithCreatedAtUtc(DateTimeOffset createdAtUtc)
    {
        _createdAtUtc = createdAtUtc;

        return this;
    }

    public EmailConfirmationTokenBuilder WithExpiredAtUtc(DateTimeOffset expiresAtUtc)
    {
        _expiresAtUtc = expiresAtUtc;

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
