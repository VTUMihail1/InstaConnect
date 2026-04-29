namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenDataFaker
{
	public static string GetValue()
	{
		return DataFaker.GetAverageString(RefreshTokenConfigurations.ValueMaxLength, RefreshTokenConfigurations.ValueMinLength);
	}

	public static DateTimeOffset GetCreatedAtUtc()
	{
		return DataFaker.GetRecentDate();
	}

	public static DateTimeOffset GetExpiresAtUtc()
	{
		return DataFaker.GetRecentDate();
	}

	public static DateTimeOffset GetAlreadyExpiresAtUtc()
	{
		return DataFaker.GetPastDate();
	}
}
