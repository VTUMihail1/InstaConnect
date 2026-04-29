using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

public class ForgotPasswordTokenBuilder
{
    private readonly string _id;
    private readonly User _user;
    private readonly string _value;
    private DateTimeOffset _expiresAtUtc;
    private readonly DateTimeOffset _createdAtUtc;

    public ForgotPasswordTokenBuilder(User user)
    {
        _id = user.Id.Id;
        _user = user;
        _value = ForgotPasswordTokenDataFaker.GetValue();
        _expiresAtUtc = ForgotPasswordTokenDataFaker.GetExpiresAtUtc();
        _createdAtUtc = ForgotPasswordTokenDataFaker.GetCreatedAtUtc();
    }

    public ForgotPasswordTokenBuilder WithAlreadyExpiresAtUtc()
    {
        _expiresAtUtc = ForgotPasswordTokenDataFaker.GetAlreadyExpiresAtUtc();

        return this;
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
