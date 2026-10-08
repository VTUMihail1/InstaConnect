namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenDataFaker
{
	public static string GetValue()
	{
		return DataFaker.GetAverageString(RefreshTokenConfigurations.ValueMaxLength, RefreshTokenConfigurations.ValueMinLength);
	}

	public static DateTimeOffset GetCreatedAtUtc()
	{
		return DataFaker.GetSoonDate();
	}

	public static DateTimeOffset GetExpiresAtUtc()
	{
		return DataFaker.GetSoonDate();
	}

	public static int GetLifetimeSeconds()
	{
		return DataFaker.GetRandomNumber();
	}

	public static DateTimeOffset GetExpired(DateTimeOffset expiresAtUtc)
	{
		return DataFaker.GetFutureDate(expiresAtUtc);
	}

	public static DateTimeOffset GetUnexpired(DateTimeOffset expiresAtUtc)
	{
		return DataFaker.GetPastDate(expiresAtUtc);
	}
}
