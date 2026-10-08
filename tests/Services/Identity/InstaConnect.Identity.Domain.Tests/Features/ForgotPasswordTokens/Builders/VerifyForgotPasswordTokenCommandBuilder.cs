namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Builders;

public class VerifyForgotPasswordTokenCommandBuilder
{
	private string _id;
	private string _value;
	private readonly string _password;
	private readonly string _confirmPassword;

	public VerifyForgotPasswordTokenCommandBuilder(ForgotPasswordToken forgotPasswordToken)
	{
		_id = forgotPasswordToken.Id.Id.Id;
		_value = forgotPasswordToken.Id.Value;
		_password = UserDataFaker.GetPassword();
		_confirmPassword = _password;
	}

	public VerifyForgotPasswordTokenCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public VerifyForgotPasswordTokenCommandBuilder WithValue(IStringTransformer transformer)
	{
		_value = transformer.Transform(_value);

		return this;
	}

	public VerifyForgotPasswordTokenCommand Build()
	{
		return new(
			new(
				new(_id),
				_value),
			_password,
			_confirmPassword);
	}
}
