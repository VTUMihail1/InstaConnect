namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimDataFaker
{
    public static string GetClaim()
    {
        return DataFaker.GetAverageString(UserClaimConfigurations.ClaimMaxLength, UserClaimConfigurations.ClaimMinLength);
    }

    public static DateTimeOffset GetCreatedAtUtc()
    {
        return DataFaker.GetRecentDate();
    }
}
