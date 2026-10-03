namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;

public class IssueRefreshTokenCommandBuilder
{
	private string _name;
	private readonly string _password;

	public IssueRefreshTokenCommandBuilder(User user, string password)
	{
		_name = user.Name.Value;
		_password = password;
	}

	public IssueRefreshTokenCommandBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public IssueRefreshTokenCommand Build()
	{
		return new(
			new(_name),
			_password);
	}
}
