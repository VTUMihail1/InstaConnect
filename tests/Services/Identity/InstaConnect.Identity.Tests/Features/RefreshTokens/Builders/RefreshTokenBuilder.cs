using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

public class RefreshTokenBuilder
{
	private readonly string _id;
	private readonly User _user;
	private readonly string _value;
	private DateTimeOffset _expiresAtUtc;
	private readonly DateTimeOffset _createdAtUtc;

	public RefreshTokenBuilder(User user)
	{
		_id = user.Id.Id;
		_user = user;
		_value = RefreshTokenDataFaker.GetValue();
		_expiresAtUtc = RefreshTokenDataFaker.GetExpiresAtUtc();
		_createdAtUtc = RefreshTokenDataFaker.GetCreatedAtUtc();
	}

	public RefreshTokenBuilder WithAlreadyExpiresAtUtc()
	{
		_expiresAtUtc = RefreshTokenDataFaker.GetAlreadyExpiresAtUtc();

		return this;
	}

	public RefreshToken Build()
	{
		var refreshToken = new RefreshToken(
			new(
				new(_id),
				_value),
			_expiresAtUtc,
			_createdAtUtc);

		refreshToken.AddUser(_user);
		_user.AddRefreshToken(refreshToken);

		return refreshToken;
	}
}
