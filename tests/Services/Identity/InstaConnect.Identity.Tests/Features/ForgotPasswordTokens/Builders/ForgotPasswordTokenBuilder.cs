using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

public class ForgotPasswordTokenBuilder
{
    private string _id;
    private User _user;
    private string _value;
    private DateTimeOffset _expiresAtUtc;
    private DateTimeOffset _createdAtUtc;

    public ForgotPasswordTokenBuilder(User user)
    {
        _id = user.Id.Id;
        _user = user;
        _value = ForgotPasswordTokenDataFaker.GetValue();
        _expiresAtUtc = ForgotPasswordTokenDataFaker.GetExpiresAtUtc();
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

    public ForgotPasswordTokenBuilder WithExpiresAtUtc(DateTimeOffset expiresAtUtc)
    {
        _expiresAtUtc = expiresAtUtc;

        return this;
    }

    public ForgotPasswordTokenBuilder WithAlreadyExpiresAtUtc()
    {
        return WithExpiresAtUtc(ForgotPasswordTokenDataFaker.GetAlreadyExpiresAtUtc());
    }

    public ForgotPasswordToken Build()
    {
        var forgotPasswordToken = new ForgotPasswordToken(
            new(
                new(_id),
                _value),
            _expiresAtUtc,
            _createdAtUtc);

        forgotPasswordToken.AddUser(_user);
        _user.AddForgotPasswordToken(forgotPasswordToken);

        return forgotPasswordToken;
    }
}
