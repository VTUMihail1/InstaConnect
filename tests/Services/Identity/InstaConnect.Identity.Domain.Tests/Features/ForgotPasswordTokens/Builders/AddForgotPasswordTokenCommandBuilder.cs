namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Builders;

public class AddForgotPasswordTokenCommandBuilder
{
	private string _name;

	public AddForgotPasswordTokenCommandBuilder(User user)
	{
		_name = user.Name.Value;
	}

	public AddForgotPasswordTokenCommandBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public AddForgotPasswordTokenCommand Build()
	{
		return new(
			new(_name));
	}
}
