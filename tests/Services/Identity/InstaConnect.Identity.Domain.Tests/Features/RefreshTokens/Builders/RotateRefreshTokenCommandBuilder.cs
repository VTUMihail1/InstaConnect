namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;

public class RotateRefreshTokenCommandBuilder
{
	private string _id;
	private string _value;

	public RotateRefreshTokenCommandBuilder(RefreshToken refreshToken)
	{
		_id = refreshToken.Id.Id.Id;
		_value = refreshToken.Id.Value;
	}

	public RotateRefreshTokenCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public RotateRefreshTokenCommandBuilder WithValue(IStringTransformer transformer)
	{
		_value = transformer.Transform(_value);

		return this;
	}

	public RotateRefreshTokenCommand Build()
	{
		return new(
			new(
				new(_id),
				_value));
	}
}
