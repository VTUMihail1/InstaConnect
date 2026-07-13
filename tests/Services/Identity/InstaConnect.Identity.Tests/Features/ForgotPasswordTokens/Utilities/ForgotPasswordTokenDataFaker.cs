namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenDataFaker
{
	public static string GetValue()
	{
		return DataFaker.GetAverageString(ForgotPasswordTokenConfigurations.ValueMaxLength, ForgotPasswordTokenConfigurations.ValueMinLength);
	}

	public static DateTimeOffset GetCreatedAtUtc()
	{
		return DataFaker.GetRecentDate();
	}

	public static DateTimeOffset GetExpiresAtUtc()
	{
		return DataFaker.GetRecentDate();
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
