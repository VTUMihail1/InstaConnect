namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Builders;

public class AddEmailConfirmationTokenCommandBuilder
{
	private string _name;

	public AddEmailConfirmationTokenCommandBuilder(User user)
	{
		_name = user.Name.Value;
	}

	public AddEmailConfirmationTokenCommandBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public AddEmailConfirmationTokenCommand Build()
	{
		return new(
			new(_name));
	}
}
