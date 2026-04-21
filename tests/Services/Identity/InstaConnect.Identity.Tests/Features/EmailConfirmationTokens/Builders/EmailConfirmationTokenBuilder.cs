using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;

public class EmailConfirmationTokenBuilder
{
    private string _id;
    private User _user;
    private string _value;
    private DateTimeOffset _expiresAtUtc;
    private DateTimeOffset _createdAtUtc;

    public EmailConfirmationTokenBuilder(User user)
    {
        _id = user.Id.Id;
        _user = user;
        _value = EmailConfirmationTokenDataFaker.GetValue();
        _expiresAtUtc = EmailConfirmationTokenDataFaker.GetExpiresAtUtc();
        _createdAtUtc = EmailConfirmationTokenDataFaker.GetCreatedAtUtc();
    }

    public EmailConfirmationTokenBuilder WithAlreadyExpiresAtUtc()
    {
        _expiresAtUtc = EmailConfirmationTokenDataFaker.GetAlreadyExpiresAtUtc();

        return this;
    }

    public EmailConfirmationToken Build()
    {
        var emailConfirmationToken = new EmailConfirmationToken(
            new(
                new(_id),
                _value),
            _expiresAtUtc,
            _createdAtUtc);

        emailConfirmationToken.AddUser(_user);
        _user.AddEmailConfirmationToken(emailConfirmationToken);

        return emailConfirmationToken;
    }
}
