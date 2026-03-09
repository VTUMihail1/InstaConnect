namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenDataFaker
{
    public static string GetValue()
    {
        return DataFaker.GetAverageString(EmailConfirmationTokenConfigurations.ValueMaxLength, EmailConfirmationTokenConfigurations.ValueMinLength);
    }

    public static DateTimeOffset GetCreatedAtUtc()
    {
        return DataFaker.GetRecentDate();
    }

    public static DateTimeOffset GetExpiresAtUtc()
    {
        return DataFaker.GetRecentDate();
    }
}
