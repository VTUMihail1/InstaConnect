namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserDataFaker
{
    public static string GetId()
    {
        return DataFaker.GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength);
    }

    public static string GetName()
    {
        return DataFaker.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
    }

    public static string GetFirstName()
    {
        return DataFaker.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength);
    }

    public static string GetLastName()
    {
        return DataFaker.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength);
    }

    public static string GetEmail()
    {
        return DataFaker.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength);
    }

    public static string GetProfileImage()
    {
        return DataFaker.GetAverageString(UserConfigurations.ProfileImageUrlMaxLength);
    }

    public static DateTimeOffset GetCreatedAtUtc()
    {
        return DataFaker.GetRecentDate();
    }

    public static DateTimeOffset GetUpdatedAtUtc()
    {
        return DataFaker.GetRecentDate();
    }
}
