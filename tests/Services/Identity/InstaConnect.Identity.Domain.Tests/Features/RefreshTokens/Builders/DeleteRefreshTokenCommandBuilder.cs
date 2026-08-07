namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;

public class DeleteRefreshTokenCommandBuilder
{
	private string _id;
	private string _value;

	public DeleteRefreshTokenCommandBuilder(RefreshToken refreshToken)
	{
		_id = refreshToken.Id.Id.Id;
		_value = refreshToken.Id.Value;
	}

	public DeleteRefreshTokenCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeleteRefreshTokenCommandBuilder WithValue(IStringTransformer transformer)
	{
		_value = transformer.Transform(_value);

		return this;
	}

	public DeleteRefreshTokenCommand Build()
	{
		return new(
			new(
				new(_id),
				_value));
	}
}
