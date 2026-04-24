namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Builders;

public class VerifyForgotPasswordTokenCommandRequestBuilder
{
    private string _id;
    private string _value;
    private string _password;
    private string _confirmPassword;

    public VerifyForgotPasswordTokenCommandRequestBuilder(ForgotPasswordToken forgotPasswordToken)
    {
        _id = forgotPasswordToken.Id.Id.Id;
        _value = forgotPasswordToken.Id.Value;
        _password = UserDataFaker.GetPassword();
        _confirmPassword = _password;
    }

    public VerifyForgotPasswordTokenCommandRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public VerifyForgotPasswordTokenCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public VerifyForgotPasswordTokenCommandRequestBuilder WithValue(IStringTransformer transformer)
    {
        _value = transformer.Transform(_value);

        return this;
    }

    public VerifyForgotPasswordTokenCommandRequestBuilder WithPassword(IStringTransformer transformer)
    {
        _password = transformer.Transform(_password);
        _confirmPassword = _password;

        return this;
    }

    public VerifyForgotPasswordTokenCommandRequestBuilder WithConfirmPassword(IStringTransformer transformer)
    {
        _confirmPassword = transformer.Transform(_confirmPassword);

        return this;
    }

    public VerifyForgotPasswordTokenCommandRequest Build()
    {
        return new(_id, _value, _password, _confirmPassword);
    }
}
