namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Builders;

public class VerifyEmailConfirmationTokenCommandBuilder
{
	private string _id;
	private string _value;

	public VerifyEmailConfirmationTokenCommandBuilder(EmailConfirmationToken emailConfirmationToken)
	{
		_id = emailConfirmationToken.Id.Id.Id;
		_value = emailConfirmationToken.Id.Value;
	}

	public VerifyEmailConfirmationTokenCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public VerifyEmailConfirmationTokenCommandBuilder WithValue(IStringTransformer transformer)
	{
		_value = transformer.Transform(_value);

		return this;
	}

	public VerifyEmailConfirmationTokenCommand Build()
	{
		return new(
			new(
				new(_id),
				_value));
	}
}
